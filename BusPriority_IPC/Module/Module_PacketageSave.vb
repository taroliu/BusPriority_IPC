Imports System.Text

Module Module_PacketageSave  '-->BusPriority_daemon
    'Public Data_5F03 As Class_5F03
    'Public Data_5F18 As Class_5F18
    'Public Data_5F13 As Class_5F13
    'Public Data_5F14 As Class_5F14
    'Public Data_5F15 As Class_5F15

    'Public Data_A1 As Class_A1
    'Public Data_A2 As Class_A2
    Public Function isDisablePolicyCommand(ByVal ComString As String) As Boolean
        'isEnableBusPriority
        Dim Command As String = ComString.Substring(14, 6)
        If Command = "5F1040" Then
            Return True
        End If
        Return False
    End Function
    Public Function SaveDataFunction(ByVal SaveString As String) As Boolean
        Try
            Dim SaveCode As String = SaveString.Substring(14, 4)
            '移除INFO中的AA,改變AAAA為AA,不重算LEN及CKS
            'S---------------------------------------------------------------------------
            Dim InfoString As String = SaveString.Substring(14, SaveString.Length - 20)
            InfoString = InfoString.Replace("AAAA", "AA")
            SaveString = SaveString.Substring(0, 14) + InfoString + SaveString.Substring(SaveString.Length - 6, 6)
            'E---------------------------------------------------------------------------

            Select Case SaveCode
                'Jason20150114 系統對時功能
                'S---------------------------------------------------------------------------
                Case "0FC2"
                    SetSysteTime(SaveString)
                    Return True
                    'E-----------------------------------------------------------------------
                Case "5F10"     '目前策略管理回報
                    Return True
                Case "5FC3", "5F13"    '時相資料庫回報
                    SaveData_5FC3(SaveString)
                    Report5F43Xml(COMMON_GroupID, COMMON_GroupID, SaveString.Substring(14, SaveString.Length - 20))
                    _mainForm.Show_LBox_PolicyRightNowText("5F13 Get")
                    Return True
                Case "5FC4", "5F14"     '時制計畫基本參數回報
                    SaveData_5FC4(SaveString)
                    Report5F44Xml(COMMON_GroupID, COMMON_GroupID, SaveString.Substring(14, SaveString.Length - 20))
                    _mainForm.Show_LBox_PolicyRightNowText("5F14 Get")
                    Return True
                Case "5FC5", "5F15"     '時制計畫資料庫回報
                    SaveData_5FC5(SaveString)
                    Report5F45Xml(COMMON_GroupID, COMMON_GroupID, SaveString.Substring(14, SaveString.Length - 20))
                    _mainForm.Show_LBox_PolicyRightNowText("5F15 Get")
                    Return True
                Case "5FC6", "5F16"   '一般日時段型態回報
                    If SaveCode = "5F16" Then
                        BusPriority_IPC.MainForm.SetAutoLoad5F46()
                    End If
                    If SaveCode = "5F46" Then
                        Report5F46Xml(COMMON_GroupID, COMMON_GroupID, SaveString.Substring(14, SaveString.Length - 20))
                    End If

                    Return True
                Case "5FC8"     '目前時制計畫管理回報
                    'Return True
                    SaveData_5FC8(SaveString)
                    '_mainForm.Show_LBox_PolicyRightNowText("5FC8 Get")
                    Return True
                Case "5F03"     '步階主動回報
                    SaveData_5F03(SaveString)
                    Report5F03Xml(COMMON_GroupID, COMMON_GroupID, SaveString.Substring(14, SaveString.Length - 20))
                    Return True
                    '    SaveData_5F03(SendString)
                    'Case "5F08"     '現場操作
                    '新增協定儲存
                    '總開關協定控制
                    'S-----------------------------------------------------------------------
                Case "5F80"
                    isRunSystemFromCC = Trim(SaveString.Substring(19, 1))
                    WriteINIValue("BUS_POLICY", "isRunSystemFromCC", isRunSystemFromCC)
                    Return True
                    'E-----------------------------------------------------------------------
                    'jason 20150413 查詢回報公車優先啟動狀態
                    'S-----------------------------------------------------------------------
                Case "5F90"
                    ReturnBusPriorityRuningState("1")
                    Return True
                    'E-----------------------------------------------------------------------
                Case "5F81" '公車優先觸發點管理(設定)
                    If DB_ACCESS_ENABLE = "1" Then
                        SaveData_5F81_DB(SaveString)
                    End If
                    Return True
                Case "5F91" '公車優先觸發點管理(查詢回報)
                    If DB_ACCESS_ENABLE = "1" Then
                        ReportData_5F91_DB(SaveString)
                    End If
                    Return True
                Case "5F82" '公車優先一般時段排程管理(設定)
                    If DB_ACCESS_ENABLE = "1" Then
                        SaveData_5F82_DB(SaveString)
                    End If
                    Return True
                Case "5F92" '公車優先一般時段排程管理(查詢回報)

                    Return True
                Case "5F83", "5F93" '公車優先特殊時段排程管理
                    Return True
                Case "5F85" '公車優先OTA管理-重新啟動
                    Dim isRestart As String = SaveString.Substring(18, 2)
                    If isRestart = "01" Then
                        LoadBusPriority_HistoryInsert("NONE", "NONE", 1) '記錄更新
                        Environment.Exit(Environment.ExitCode)
                        Application.Exit()
                    End If

                    Return True
                Case "5F86", "5F96" '公車優先群組管理
                    'Group,BusLine 功能開發
                    'S-------------------------------------------------------
                    If DB_ACCESS_ENABLE = "1" Then
                        SaveData_5F86_DB(SaveString)
                    End If
                    Return True
                Case "5F88" '公車優先路線管理
                    If DB_ACCESS_ENABLE = "1" Then
                        SaveData_5F88_DB(SaveString)
                    End If
                    'E-------------------------------------------------------
                    Return True
                Case "5FCC"     '目前步階剩餘秒數回報
                    SaveData_5FCC(SaveString)
                    Return True
                Case Else
                    Return False
            End Select
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveDataFunction Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
        Return False
    End Function
    'Jason20150114 系統對時功能
    'S---------------------------------------------------------------------------
    Public Sub SetSysteTime(ByVal SaveData As String)
        Try
            Dim timstring As String = SaveData.Substring(14, 18)
            If timstring.Length = 18 Then
                Dim Y_str As String = HexStringTOIntString(timstring.Substring(4, 2), 2)
                Dim Y_Int As Integer = Val(Y_str) + 1911
                Y_str = Trim(Y_Int.ToString)
                Dim M_str As String = Trim(HexStringTOIntString(timstring.Substring(6, 2), 2))
                Dim D_str As String = Trim(HexStringTOIntString(timstring.Substring(8, 2), 2))
                Dim HH_str As String = Trim(HexStringTOIntString(timstring.Substring(12, 2), 2))
                Dim mm_str As String = Trim(HexStringTOIntString(timstring.Substring(14, 2), 2))
                Dim ss_str As String = Trim(HexStringTOIntString(timstring.Substring(16, 2), 2))

                Dim SetTimeString As String = "#" + HH_str + ":" + mm_str + ":" + ss_str + "#"
                Dim SetDayString As String = "#" + M_str + "/" + D_str + "/" + Y_str + "#"
                TimeOfDay = SetTimeString
                Today = SetDayString
                _mainForm.ToolStripStatusLabel2.Text = " /最近校時時間:" + Y_str + "/" + M_str + "/" + D_str + " " + HH_str + ":" + mm_str + ":" + ss_str
            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SetSysteTime Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    'E---------------------------------------------------------------------------
    Public Sub SaveData_5FC3(ByVal SaveData As String)
        Try
            Dim sPhaseOrder As String = SaveData.Substring(18, 2)
            Dim sSignalMap As String = SaveData.Substring(20, 2)
            Dim sSignalCount As String = SaveData.Substring(22, 2)
            Dim sSubPhaseCount As String = SaveData.Substring(24, 2)
            Dim sSignalStatus As String = SaveData.Substring(26, Val(sSignalCount) * Val(sSubPhaseCount) * 2) '4481 4481

            Data_5F13 = New Class_5F13(sPhaseOrder, sSignalMap, sSignalCount, sSubPhaseCount, sSignalStatus, Now)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5FC3 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub SaveData_5FC4(ByVal SaveData As String)
        Try
            Dim sPlanID As String = SaveData.Substring(18, 2)
            Dim sSubPhaseCount As String = SaveData.Substring(20, 2)
            Dim sLightStatus(sSubPhaseCount - 1) As String
            For i As Integer = 0 To (Val(sSubPhaseCount) - 1)
                sLightStatus(i) = SaveData.Substring(22 + i * 14, 14)
            Next i
            If Current_Planid = sPlanID Then  '20150922 只儲存目前時制計畫
                Data_5F14 = New Class_5F14(sPlanID, sSubPhaseCount, sLightStatus, Now)
            End If

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5FC4 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub SaveData_5FC5(ByVal SaveData As String)
        Try
            Dim sPlanID As String = SaveData.Substring(18, 2)
            Dim sDirect As String = SaveData.Substring(20, 2)
            Dim sPhaseOrder As String = SaveData.Substring(22, 2)
            Dim sSubPhaseCount As String = SaveData.Substring(24, 2)
            Dim sGreen As String = SaveData.Substring(26, 4 * Val(sSubPhaseCount))
            Dim sCycleTime As String = SaveData.Substring(26 + 4 * Val(sSubPhaseCount), 4)
            Dim sOffset As String = SaveData.Substring(26 + 4 * Val(sSubPhaseCount) + 4, 4)
            If Current_Planid = sPlanID Then  '20150922 只儲存目前時制計畫
                Data_5F15 = New Class_5F15(sPlanID, sDirect, sPhaseOrder, sSubPhaseCount, sGreen, sCycleTime, sOffset, Now)
            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5FC5 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    Public Sub SaveData_5FC8(ByVal SaveData As String)
        Try

            Dim sPlanID As String = SaveData.Substring(18, 2)
            Dim sDirect As String = SaveData.Substring(20, 2)
            Dim sPhaseOrder As String = SaveData.Substring(22, 2)
            Dim sSubPhaseCount As String = SaveData.Substring(24, 2)
            Dim sGreen As String = SaveData.Substring(26, 4 * Val(sSubPhaseCount))
            Dim sCycleTime As String = SaveData.Substring(26 + 4 * Val(sSubPhaseCount), 4)
            Dim sOffset As String = SaveData.Substring(26 + 4 * Val(sSubPhaseCount) + 4, 4)

            Data_5F18 = New Class_5F18(sPlanID, sDirect, sPhaseOrder, sSubPhaseCount, sGreen, sCycleTime, sOffset, Now)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5FC8 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    Public Sub SaveData_5F03(ByVal SaveData As String)
        '_mainForm.Show_LBox_PolicyRightNowText("5F03 Time " + Now.ToString)

        Try
            Dim sPhaseOrder As String = SaveData.Substring(18, 2)
            Dim sSignalMap As String = SaveData.Substring(20, 2)
            Dim sSignalCount As String = SaveData.Substring(22, 2)
            Dim sSubPhaseID As String = SaveData.Substring(24, 2)
            Dim sStepID As String = SaveData.Substring(26, 2)
            Dim sStepSec As String = SaveData.Substring(28, 4)
            Dim sSignalStatus As String = SaveData.Substring(32, SaveData.Length - 38)

            Dim Rec As Boolean = False
            Dim paybackamount As Integer = 0
            Dim paybackamountStr As String = ""

            Dim Now_Green As Integer = 0
            Dim small_Green As Integer = 0
            Dim big_Green As Integer = 0


            Data_5F03 = New Class_5F03(sPhaseOrder, sSignalMap, sSignalCount, sSubPhaseID, sStepID, sStepSec, sSignalStatus, Now)

            If Changed_Planid = True Then
                Original_Phase_Step.Clear()


                _mainForm.Show_LBox_PolicyRightNowText("Original_Phase_Step Cleared")
                RanFullCycle = False

            End If


            Try
                Dim stepid As Integer = HexStringTOInt(sStepID, 2)

                If stepid > 8 Or stepid < 1 Then
                    _mainForm.Show_LBox_PolicyRightNowText(sStepID + " 異常時制 " + stepid.ToString)
                    Abnormal_Plan = True
                Else
                    '_mainForm.Show_LBox_PolicyRightNowText(sStepID + " Normal Stepid " + stepid.ToString)
                    Abnormal_Plan = False
                End If

            Catch ex As Exception
                _mainForm.Show_LBox_PolicyRightNowText("Error in Detecting abnormal stepid " + ex.Message)
            End Try

            Try
                If SaveData_5F03_LastPhase Is Nothing Or SaveData_5F03_LastPhase <> sSubPhaseID Then
                    'Dim timetemp = TimeValue(Now)
                    'Dim SecondsDifference As Integer
                    'SecondsDifference = DateDiff(DateInterval.Second, SaveData_5F03_TimeStamp, timetemp)
                    '_mainForm.Show_LBox_PolicyRightNowText("Time Stamp Difference " + SecondsDifference.ToString)

                    
                    '_mainForm.Show_LBox_PolicyRightNowText("路口ID " + _mainForm.TBox_CrossRoadID.Text.ToString + " 第" + sSubPhaseID.ToString + "分相 Time Stamp  " + SaveData_5F03_TimeStamp.ToString)

                    If _mainForm.Label_BusPrimEnable.Text = "啟動" And RanFullCycle = True Then

                        'SubPhase_Log(_mainForm.TBox_CrossRoadID.Text.ToString, sSubPhaseID.ToString, SaveData_5F03_TimeStamp)
                        Dim Greenint As Integer
                        Dim Yellowrr As Integer
                        Dim PhaseLength As Long
                        Dim PedFlash As Integer
                        'Public PublicNormalGreen As Integer()
                        'Public PublicShortGreen As Integer()
                        'Public PublicMaxGreen As Integer()

                        Dim index As Integer = Val(SaveData_5F03_LastPhase) - 1

                        Try
                            
                            Greenint = CurrentGreen(Data_5F15.Green(index))
                            Yellowrr = YellowplusRed(Data_5F14.LightStatus(index))
                            PedFlash = PedGreenFlashRed(Data_5F14.LightStatus(index))
                            PhaseLength = Greenint + Yellowrr
                            '_mainForm.Show_LBox_PolicyRightNowText(" 正常綠 " + Greenint.ToString + " PedFlash " + Yellowrr.ToString)
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error in Calculating Phase Length " + ex.Message)
                        End Try



                        Dim wD As Long = DateDiff(DateInterval.Second, SaveData_5F03_TimeStamp, Now)
                        '_mainForm.Show_LBox_PolicyRightNowText(" Interval " + wD.ToString)

                        Dim difference As Integer = wD - PhaseLength
                        Dim difference2 As Integer = 0
                        '_mainForm.Show_LBox_PolicyRightNowText(SaveData_5F03_LastPhase.ToString + " 分相 : " + wD.ToString + " 秒  正常秒數 : " + PhaseLength.ToString + " 變化 " + difference.ToString)

                        'SubPhase_Log(_mainForm.TBox_CrossRoadID.Text.ToString, SaveData_5F03_LastPhase.ToString, wD.ToString, SaveData_5F03_TimeStamp, PhaseLength, difference)

                        SubPhase_Log(_mainForm.TBox_CrossRoadID.Text.ToString, SaveData_5F03_LastPhase.ToString, wD.ToString, SaveData_5F03_TimeStamp, PhaseLength, difference)
                        '_mainForm.Show_LBox_PolicyRightNowText("Message " + SaveData)



                        Dim difftime As TimeSpan


                        If StartRec_TimeStamp <> Nothing Then

                            difftime = Now - StartRec_TimeStamp

                            If difftime.TotalMinutes < 3 And Abnormal_Plan = False And Rec = False Then
                                Rec = True
                                _mainForm.Show_LBox_PolicyRightNowText("Strategy Activated Start Recording Difference")

                            End If

                        End If

                        'If StopRec_TimeStamp <> Nothing Then

                        '    difftime = Now - StopRec_TimeStamp

                        '    If difftime.TotalSeconds < 30 And Abnormal_Plan = False Then
                        '        Rec = True
                        '    ElseIf difftime.TotalSeconds > 30 And Rec = True And difftime.TotalMinutes < 3 Then
                        '        Rec = False
                        '        _mainForm.Show_LBox_PolicyRightNowText("Strategy DeActivated Stop Recording Difference")
                        '    End If

                        'End If
                        _mainForm.Show_LBox_PolicyRightNowText(" CycleID " + CycleID.ToString + " Rec_CycleID " + Rec_CycleID.ToString + " Rec " + Rec.ToString)

                        If Rec_CycleID <> -1 And CycleID = Rec_CycleID And Abnormal_Plan = False Then
                            Rec = True
                        ElseIf CycleID >= (Rec_CycleID + 1) Then
                            Rec = False
                            '_mainForm.Show_LBox_PolicyRightNowText("Strategy DeActivated Stop Recording Difference")
                        End If


                        If difference > 0 Then
                            _mainForm.Show_LBox_PolicyRightNowText(" 分相 " + SaveData_5F03_LastPhase.ToString + " 多跑了 " + difference.ToString + " 秒")
                        ElseIf difference < 0 Then
                            _mainForm.Show_LBox_PolicyRightNowText(" 分相 " + SaveData_5F03_LastPhase.ToString + " 少跑了 " + difference.ToString + " 秒")
                        Else
                            _mainForm.Show_LBox_PolicyRightNowText(" 分相 " + SaveData_5F03_LastPhase.ToString)
                        End If

                        If Rec = True Then
                            difference2 = difference
                            
                        End If

                        Try
                            If Payback.Contains(SaveData_5F03_LastPhase) Then
                                Dim tempstorage As Integer = Payback(SaveData_5F03_LastPhase)
                                _mainForm.Show_LBox_PolicyRightNowText("Payback Storage " + tempstorage.ToString)
                                difference2 = difference2 + tempstorage
                                _mainForm.Show_LBox_PolicyRightNowText("Payback Total " + difference2.ToString)
                            End If
                        Catch lx As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error in getting payback balance " + lx.Message)
                        End Try
                       

                        'Dim Now_Green As Integer = PublicNormalGreen(index)
                        'Dim small_Green As Integer = PublicShortGreen(index)
                        'Dim big_Green As Integer = PublicMaxGreen(index)

                        Dim tempint As Integer = 0
                        Dim original_amount = 0

                        Try
                            Now_Green = CurrentGreen(Data_5F15.Green(index))
                            small_Green = MinGreen(Data_5F14.LightStatus(index))


                            Dim tempindex As Integer = 0

                            If index = 0 Then
                                tempindex = TotalPhaseInt - 1
                            Else
                                tempindex = index - 1
                            End If

                            big_Green = Now_Green + MinGreen(Data_5F14.LightStatus(tempindex)) + 10

                            _mainForm.Show_LBox_PolicyRightNowText(" 正常綠 " + Now_Green.ToString + " 最小綠 " + small_Green.ToString + " pedflash " + PedFlash.ToString)
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText(" Error in Getting Now_Green small_Green big_Green " + ex.Message)
                        End Try
                        

                        If difference2 > 3 Then
                            If Now_Green = small_Green Then
                                _mainForm.Show_LBox_PolicyRightNowText(" 正常綠 等於最小綠 不進行補償 ")
                                original_amount = 0

                            Else

                                If (Now_Green - difference2) >= small_Green Then
                                    tempint = Now_Green - difference2

                                    If tempint < 0 Then
                                        tempint = 0
                                    End If

                                    paybackamountStr = IntToHexString(tempint, 2)

                                    _mainForm.Show_LBox_PolicyRightNowText(" 應該將 " + SaveData_5F03_LastPhase + " 分相 正常綠 " + Now_Green.ToString + " 減少至 " + tempint.ToString + " 秒 $")

                                    PayBack_Commands.Add(SaveData_5F03_LastPhase, "5F1C" + SaveData_5F03_LastPhase + "01" + paybackamountStr)
                                    _mainForm.Show_LBox_PolicyRightNowText(" 存入補償命令 " + "5F1C" + SaveData_5F03_LastPhase + "01" + paybackamountStr)
                                    original_amount = 0

                                ElseIf (Now_Green - difference2) < small_Green Then
                                    tempint = small_Green - PedFlash

                                    If tempint <= 0 Then
                                        tempint = 0
                                    End If

                                    If tempint = 0 Then
                                        paybackamountStr = IntToHexString(1, 2)
                                    ElseIf tempint > 0 Then
                                        paybackamountStr = IntToHexString(tempint, 2)
                                    End If

                                    _mainForm.Show_LBox_PolicyRightNowText(" 應該將 " + SaveData_5F03_LastPhase + " 分相 正常綠 " + Now_Green.ToString + " 減少至 " + paybackamountStr + " 秒 *")

                                    PayBack_Commands.Add(SaveData_5F03_LastPhase, "5F1C" + SaveData_5F03_LastPhase + "01" + paybackamountStr)
                                    _mainForm.Show_LBox_PolicyRightNowText(" 存入補償命令 " + "5F1C" + SaveData_5F03_LastPhase + "01" + paybackamountStr)

                                    If tempint = 0 Then
                                        original_amount = difference2 - (Now_Green - small_Green)
                                    ElseIf tempint > 0 Then
                                        original_amount = difference2 - (Now_Green - (small_Green - PedFlash))
                                    End If


                                    _mainForm.Show_LBox_PolicyRightNowText(" 還需繼續從 " + SaveData_5F03_LastPhase + " 分相取回 " + original_amount.ToString + " 秒 ")
                                End If


                            End If

                        ElseIf difference2 < -3 Then
                            Dim ABSTest As Integer = System.Math.Abs(difference2)

                            paybackamountStr = IntToHexString(Now_Green + ABSTest - PedFlash, 2)
                            tempint = Now_Green + ABSTest - PedFlash
                            _mainForm.Show_LBox_PolicyRightNowText(" 應該將 " + SaveData_5F03_LastPhase + " 分相 正常綠 " + Now_Green.ToString + " 增加至 " + tempint.ToString + " 秒 ")

                            PayBack_Commands.Add(SaveData_5F03_LastPhase, "5F1C" + SaveData_5F03_LastPhase + "01" + paybackamountStr)
                            _mainForm.Show_LBox_PolicyRightNowText(" 存入補償命令 " + "5F1C" + SaveData_5F03_LastPhase + "01" + paybackamountStr)

                            original_amount = 0

                        Else
                            original_amount = 0

                        End If



                        If Payback.Contains(SaveData_5F03_LastPhase) And original_amount <> 0 Then

                            Payback.Remove(SaveData_5F03_LastPhase)
                            Payback.Add(SaveData_5F03_LastPhase, original_amount)
                            _mainForm.Show_LBox_PolicyRightNowText(SaveData_5F03_LastPhase + " Save PayBack Amount " + original_amount.ToString)
                        ElseIf Payback.Contains(SaveData_5F03_LastPhase) And original_amount = 0 Then
                            Payback.Remove(SaveData_5F03_LastPhase)

                        ElseIf original_amount <> 0 Then
                            Payback.Add(SaveData_5F03_LastPhase, original_amount)
                            _mainForm.Show_LBox_PolicyRightNowText(SaveData_5F03_LastPhase + " Save PayBack Amount " + original_amount.ToString)
                        End If

                    End If

                    SaveData_5F03_TimeStamp = Now.ToString("yyyy-MM-dd HH:mm:ss")
                    SaveData_5F03_LastPhase = sSubPhaseID


                End If

            Catch ax As Exception
                Dim trace As New System.Diagnostics.StackTrace(ax, True)
                _mainForm.Show_LBox_PolicyRightNowText("5F03 Time Stamp Error " + ax.StackTrace + " Trace" + trace.GetFrame(0).GetFileLineNumber().ToString)
            End Try


            Try
                If Original_Phase_Step.Contains(sSubPhaseID + "_" + sStepID) Then

                    RanFullCycle = True

                    '_mainForm.Show_LBox_PolicyRightNowText(" Already Exists " + sSubPhaseID + "_" + sStepID)
                    'add refund sequnece
                    Dim MyKeys As ICollection
                    MyKeys = Original_Phase_Step.Keys()
                    TotalCycleSec = 0

                    For Each Key In MyKeys

                        '_mainForm.Show_LBox_PolicyRightNowText("Phase key " + Key.ToString + "  Value " + Original_Phase_Step(Key))

                        TotalCycleSec = TotalCycleSec + Convert.ToInt32(Original_Phase_Step(Key), 16)

                        Dim iSecond As Double = TotalCycleSec + 60 'Total number of seconds plus 1 minute buffer
                        Dim iSpan As TimeSpan = TimeSpan.FromSeconds(iSecond)

                        TotalCycleMin = iSpan.Minutes.ToString.PadLeft(2, "0"c)
                        '_mainForm.Show_LBox_PolicyRightNowText("TempCycleSec " + TotalCycleSec.ToString)
                        '_mainForm.Show_LBox_PolicyRightNowText("TotalCycleMin " + TotalCycleMin)

                        'temp_p_position As String = TriggerPointxy(Key)
                        'temp_A1_distance = distance(temp_A1_position, temp_p_position)
                        '_mainForm.Show_LBox_PolicyRightNowText("temp_A1_position = " + temp_A1_position + "   temp_p_position = " + temp_p_position)
                        '_mainForm.Show_LBox_PolicyRightNowText("A1 Distance with " + Key)
                    Next

                Else
                    Original_Phase_Step.Add(sSubPhaseID + "_" + sStepID, sStepSec)
                    _mainForm.Show_LBox_PolicyRightNowText("ADD Phase " + sSubPhaseID + " Step " + sStepID)
                    RanFullCycle = False
                    Payback.Clear()

                End If



            Catch ex As Exception
                '_mainForm.Show_LBox_PolicyRightNowText("Original_Phase_Step is full")
                'Phase_Step_Collect = True
                _mainForm.Show_LBox_PolicyRightNowText("Original_Phase_Step error" + ex.StackTrace)
            End Try



            '_mainForm.Show_LBox_PolicyRightNowText("sSubPhaseID =" + sSubPhaseID + " sStepID = " + sStepID + " sStepSec = " + sStepSec)

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5F03 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub


    Public Sub SaveData_5F81_DB(ByVal SaveData As String)
        Try
            Dim nCrossRoadID As String = SaveData.Substring(18, 4)
            Dim nStopLineLatI As String = SaveData.Substring(22, 2)
            Dim nStopLineLatF As String = SaveData.Substring(24, 6)
            Dim nStopLineLat As String = HexStringTOIntString(nStopLineLatI, 2) + "." + Trim(HexStringTOIntString(nStopLineLatF, 6))
            Dim nStopLineLonI As String = SaveData.Substring(30, 2)
            Dim nStopLineLonF As String = SaveData.Substring(32, 6)
            Dim nStopLineLon As String = HexStringTOIntString(nStopLineLonI, 2) + "." + Trim(HexStringTOIntString(nStopLineLonF, 6))
            Dim nTriggerPointCount As Integer = Val(HexStringTOIntString(SaveData.Substring(38, 2), 2))
            DeleteTriggerPoint(nCrossRoadID)
            For i As Integer = 0 To nTriggerPointCount - 1
                Dim nTriggerPointID As String = SaveData.Substring(40 + 34 * i, 12)
                Dim nDirect As String = SaveData.Substring(52 + 34 * i, 2)
                Dim nTriggerOrder As String = HexStringTOIntString(SaveData.Substring(54 + 34 * i, 2), 2)
                Dim nPosLatitudeI As String = SaveData.Substring(56 + 34 * i, 2)
                Dim nPosLatitudeF As String = SaveData.Substring(58 + 34 * i, 6)
                Dim nPosLat As String = HexStringTOIntString(nPosLatitudeI, 2) + "." + Trim(HexStringTOIntString(nPosLatitudeF, 6))
                Dim nPosLongitudeI As String = SaveData.Substring(64 + 34 * i, 2)
                Dim nPosLongitudeF As String = SaveData.Substring(66 + 34 * i, 6)
                Dim nPosLon As String = HexStringTOIntString(nPosLongitudeI, 2) + "." + Trim(HexStringTOIntString(nPosLongitudeF, 6))
                Dim nPointType As String = SaveData.Substring(72 + 34 * i, 2)
                NewTriggerPoint(nCrossRoadID, nTriggerPointID, nDirect, nTriggerOrder, nPosLat, nPosLon, nPointType, nStopLineLat, nStopLineLon)
            Next i
            LoadBusPriority_HistoryInsert("NONE", nCrossRoadID, 3) '記錄更新
            initTouchPoint2DGridView(nCrossRoadID)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5F81_DB Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    Public Sub ReportData_5F91_DB(ByVal SaveData As String)
        Try
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "ReportData_5F91_DB Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    '5F H+82 H+ CrossRoadID + SegmentType +SegmentCount+(Hour+Min)(SegmentCount)+NumWeekDay+WeekDay(NumWeekDay) +isEnable(NumWeekDay)(SegmentCount)

    Public Sub SaveData_5F82_DB(ByVal SaveData As String)
        Try
            Dim nCrossRoadID As String = SaveData.Substring(18, 4)
            Dim nSegmentType As String = SaveData.Substring(22, 2)
            Dim nSegmentCount As String = SaveData.Substring(24, 2)
            Dim nSegmentIndex As Integer = Val(nSegmentCount) - 1
            Dim nSegmentData(nSegmentIndex) As String
            Dim nHour, nMin, nPlanID As String
            Dim CountIndex As Integer = 26
            For i As Integer = 0 To nSegmentIndex
                nHour = Trim(HexStringTOIntString(SaveData.Substring(26 + i * 6, 2), 2))
                nHour = nHour.PadLeft(2, "0")
                nMin = Trim(HexStringTOIntString(SaveData.Substring(28 + i * 6, 2), 2))
                nMin = nMin.PadLeft(2, "0")
                nPlanID = Trim(HexStringTOIntString(SaveData.Substring(30 + i * 6, 2), 2))
                nPlanID = nPlanID.PadLeft(2, "0")
                nSegmentData(i) = nHour + "," + nMin + "," + nPlanID
                CountIndex += 6
            Next i

            Dim nNumWeekDay As Integer = Val(SaveData.Substring(CountIndex, 2))
            CountIndex += 2

            Dim nWeekDay As String = SaveData.Substring(CountIndex, 2 * nNumWeekDay)
            CountIndex += 2 * nNumWeekDay

            Dim nIsEnable(nSegmentIndex) As String
            For i As Integer = 0 To nSegmentIndex
                nIsEnable(i) = SaveData.Substring(CountIndex, 2 * nNumWeekDay)
                CountIndex += 2 * nNumWeekDay
            Next i
            DeleteSegmentDate(nCrossRoadID, nSegmentType)
            For i As Integer = 0 To nSegmentIndex
                NewSegmentDate(nCrossRoadID, nSegmentType, nSegmentData(i), IntToHexString(nNumWeekDay, 2), nWeekDay, nIsEnable(i))
            Next i
            LoadBusPriority_HistoryInsert("NONE", nCrossRoadID, 2) '記錄更新
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5F82_DB Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    'Group,BusLine 功能開發
    'S-------------------------------------------------------
    Public Sub SaveData_5F86_DB(ByVal SaveData As String)
        Try
            '?????????????????????????????????????再補
            LoadBusPriority_HistoryInsert("NONE", "NONE", 4) '記錄更新
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5F86_DB Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    '5F H+88 H + BusLineID(2)+ BusLineName(20)+ GoBack(1)+CrossRoadCount(1)+(CrossRoadID(2)+Direct(1)+ BusSubPhaseID(1))* CrossRoadCount
    Public Sub SaveData_5F88_DB(ByVal SaveData As String)
        Try
            Dim BusLineID As String = SaveData.Substring(18, 4)
            Dim BusLineName As String = SaveData.Substring(22, 40)
            Dim GoBack As String = SaveData.Substring(62, 2)
            Dim CrossRoadCount As String = SaveData.Substring(64, 2)
            Dim nCrossRoadCount As Integer = Val(CrossRoadCount) - 1

            Dim CrossRoadID, Direct, BusSubPhaseID As String
            Dim CrossRoadData(nCrossRoadCount) As String
            For i As Integer = 0 To nCrossRoadCount
                CrossRoadID = SaveData.Substring(66 + i * 8, 4)
                Direct = SaveData.Substring(70 + i * 8, 2)
                BusSubPhaseID = SaveData.Substring(72 + i * 8, 2)
                CrossRoadData(i) = CrossRoadID + "," + Direct + "," + BusSubPhaseID
            Next i

        
            DeleteBusLineDate(BusLineID)
            For i As Integer = 0 To nCrossRoadCount
                NewBusLineDate(BusLineID, BusLineName, GoBack, i.ToString, CrossRoadData(i))
            Next i
            initComBusLineDate()
            LoadBusPriority_HistoryInsert(BusLineID, "NONE", 5) '記錄更新
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5F88_DB Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    'E-------------------------------------------------------
    '************************************************************
    '**
    '**紀錄查詢SeqNumbe 不往CC回報
    '**
    '************************************************************
    Public KeepSeqNumbe_5F48 As Integer
    Public KeepSeqNumbe_5F43 As Integer
    Public KeepSeqNumbe_5F44 As Integer
    Public KeepSeqNumbe_5F45 As Integer
    Public KeepSeqNumbe_5F3F As Integer
    Public Sub setNowIC_Param_5F48()
        Try
            Dim sendByte As Byte()
            Dim tranStr As String = "5F48"
            Dim SeqNumber As Integer = getSeqNum()
            sendByte = Incode_Step1(SeqNumber, MarkAACommand(tranStr))
            _mainForm.send_IC(sendByte)
            KeepSeqNumbe_5F48 = SeqNumber
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "getNowIC_Param_5F48 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub setNowIC_Param_5F43(ByVal PhaseOrder_5F34 As String)
        Try
            Dim sendByte As Byte()
            Dim tranStr As String = "5F43" + PhaseOrder_5F34
            Dim SeqNumber As Integer = getSeqNum()
            sendByte = Incode_Step1(SeqNumber, MarkAACommand(tranStr))
            _mainForm.send_IC(sendByte)
            KeepSeqNumbe_5F43 = SeqNumber
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "getNowIC_Param_5F43 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub setNowIC_Param_5F44(ByVal PlanID_5F34 As String)
        Try
            Dim sendByte As Byte()
            Dim tranStr As String = "5F44" + PlanID_5F34
            Dim SeqNumber As Integer = getSeqNum()
            sendByte = Incode_Step1(SeqNumber, MarkAACommand(tranStr))
            _mainForm.send_IC(sendByte)
            KeepSeqNumbe_5F44 = SeqNumber
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "setNowIC_Param_5F44 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub setNowIC_Param_5F45(ByVal PlanID_5F35 As String)
        Try
            Dim sendByte As Byte()
            Dim tranStr As String = "5F45" + PlanID_5F35
            Dim SeqNumber As Integer = getSeqNum()
            sendByte = Incode_Step1(SeqNumber, MarkAACommand(tranStr))
            _mainForm.send_IC(sendByte)
            KeepSeqNumbe_5F45 = SeqNumber
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "setNowIC_Param_5F45 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    'Public Sub setNowIC_Param_5F3F()
    '    Try
    '        Dim sendByte As Byte()
    '        Dim tranStr As String = "5F3F0200" '有改變回報
    '        Dim SeqNumber As Integer = getSeqNum()
    '        sendByte = Incode_Step1(SeqNumber, MarkAACommand(tranStr))
    '        _mainForm.send_IC(sendByte)
    '        KeepSeqNumbe_5F3F = SeqNumber
    '    Catch ex As Exception
    '        Dim trace As New System.Diagnostics.StackTrace(ex, True)
    '        WriteLog(curPath, "Module_SaveData", "setNowIC_Param_5F3F Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
    '    End Try
    'End Sub
    '************************************************************
    '**
    '**車機資料處理
    '**
    '************************************************************
 
    Public Sub SaveData_A1(ByVal SaveData As String())
        Try
            Data_A1 = New Class_A1(SaveData)   '-->BusPriority_daemon
            AcceptA1_Procedure_1(Data_A1)


        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_A1 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub SaveData_A2(ByVal SaveData As String())
        Try
            Data_A2 = New Class_A2(SaveData) '-->BusPriority_daemon
            AcceptA2_Procedure_1(Data_A2)



        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_A2 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub SaveData_5FCC(ByVal SaveData As String)
        Try

            Dim SubPhaseID As String = SaveData.Substring(20, 2)
            Dim StepID As String = SaveData.Substring(22, 2)
            Dim RemainingTime As String = SaveData.Substring(24, 4)

            Data_5FCC = New Class_5FCC(SubPhaseID, StepID, RemainingTime)

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SaveData", "SaveData_5FCC Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
End Module
