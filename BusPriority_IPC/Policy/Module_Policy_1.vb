Imports System
Imports System.Timers
Imports System.Threading

Module Module_Policy_1

    Public Data_5F03 As Class_5F03
    Public Data_5F18 As Class_5F18
    Public Data_5F13 As Class_5F13
    Public Data_5F14 As Class_5F14
    Public Data_5F15 As Class_5F15
    Public Data_5FCC As Class_5FCC
    Public Data_Refund As Class_Refund

    Public Data_A1 As Class_A1
    Public Data_A2 As Class_A2
    Public SentTime As Integer
    Public SentLight As String



    '************************************************************************************************
    '**
    '**  1.當 nowPlayBusID=-1時,該BusID獨占至-1為止,其它車才可以經由A2設定nowPlayBusID
    '**  2.下了決策後,該車離開後,才接受新的公車
    '**
    '************************************************************************************************
    Public nowPlayBusID As String = "-1"  'This means there are no buses in que
    Public Sub SaveDataFunction_Car(ByVal SaveString As String())
        BusComm_TimeStamp = Now

        Try


            Try
                If SaveString(0) = "A1" Then

                    If A1_Counter = 0 And _mainForm.Label_BusPrimEnable.Text = "啟動" Then
                        Dim sendByte As Byte()
                        Dim tranStr As String = "5F1014"   '5F10  路口手動 + 時相控制

                        If TotalCycleMin = "" Then
                            TotalCycleMin = "05"
                        End If

                        'tranStr = tranStr + TotalCycleMin
                        tranStr = tranStr + "0A"
                        

                        sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
                        _mainForm.send_IC(sendByte)
                        A1_Counter = 1
                        _mainForm.Show_LBox_PolicyRightNowText("A1  開啟時相控制")


                        Try
                            FiveFB4.Add("BusLineID", SaveString(5))
                            FiveFB4.Add("GoBack", SaveString(6))
                            FiveFB4.Add("BusID", "0" + SaveString(2))
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText(" Error FiveFB4 BusLineID GoBack BusID " + ex.Message)
                        End Try

                        Try
                            'FiveFB4.Add("P12", DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss"))
                            FiveFB4.Add("P1", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 P12 P1 " + ex.Message)
                        End Try


                    Else
                        Dim pp As String = " "
                    End If

                    BusA1_Log(_mainForm.TBox_GroupID.Text.ToString, _mainForm.TBox_CrossRoadID.Text.ToString, SaveString(2), SaveString(5), SaveString(6), SaveString(9), SaveString(7) + "," + SaveString(8))


                End If

            Catch ex6 As Exception
                _mainForm.Show_LBox_PolicyRightNowText(" error in New A1 log" + ex6.StackTrace)
            End Try

            Dim arriveBusID As String = SaveString(2)  'Create a New Thread For each new bus ID
            If arriveBusID = Trim(OnlyOneBusID) Or Trim(OnlyOneBusID) = "" Then  'Jason 20150122 TestMode
                If nowPlayBusID = "-1" Then

                    If SaveString(0) = "A2" Then
                        nowPlayBusID = arriveBusID
                        BusComm_CommunicationStamp.Add(nowPlayBusID, Now)
                    End If

                    'If SpeedKeepHash.ContainsKey(arriveBusID) Then
                    'Dim orgTime As DateTime = SpeedKeepHash.Item(arriveBusID)

                    '    Dim DiffSecond As Long = DateDiff(DateInterval.Second, orgTime, Now)
                    '    '_mainForm.Show_LBox_PolicyRightNowText(" orgTime " + orgTime.ToString + " DiffSecond " + DiffSecond.ToString)
                    '    If DiffSecond < 180 Then
                    '        nowPlayBusID = "-1"
                    '        _mainForm.Show_LBox_PolicyRightNowText("<" + arriveBusID + ">公車速度低於最低速度,收到訊息 " + SaveString(0) + "無效")
                    '        Exit Sub
                    '    Else
                    '        'SpeedKeepHash.Remove(arriveBusID)
                    '        'nowPlayBusID = arriveBusID
                    '    End If
                    'Else
                    '    'nowPlayBusID = arriveBusID
                    '    'BusComm_CommunicationStamp.Add(nowPlayBusID, Now)
                    '    If SaveString(0) = "A2" Then
                    '        nowPlayBusID = arriveBusID
                    '        BusComm_CommunicationStamp.Add(nowPlayBusID, Now)
                    '    End If
                    'End If

                End If
                If nowPlayBusID = arriveBusID Or nowPlayBusID = "-1" Then
                    If SaveString(0) = "A1" Then
                        SaveData_A1(SaveString)
                        A1_Counter = A1_Counter + 1
                        '_mainForm.Show_LBox_PolicyRightNowText("<" + arriveBusID + ">收到訊息 A1:Speed=" + SaveString(9) + " 座標:" + SaveString(7) + "," + SaveString(8))

                        '_mainForm.Show_LBox_PolicyRightNowText("GroupID " + FiveFB4("GroupID"))
                        '_mainForm.Show_LBox_PolicyRightNowText("CrossRoadID " + FiveFB4("CrossRoadID"))
                        '_mainForm.Show_LBox_PolicyRightNowText("BusID " + FiveFB4("BusID"))
                        '_mainForm.Show_LBox_PolicyRightNowText("BusLineID " + FiveFB4("BusLineID"))
                        '_mainForm.Show_LBox_PolicyRightNowText("GoBack " + FiveFB4("GoBack"))

                        'BusA1_Log(FiveFB4("GroupID"), FiveFB4("CrossRoadID"), FiveFB4("BusID"), FiveFB4("BusLineID"), FiveFB4("GoBack"), SaveString(9), SaveString(7) + "," + SaveString(8))

                        Dim temp_A1_position As String = SaveString(7) + "," + SaveString(8)
                        Dim temp_A1_distance As Integer
                        'Dim temp_A1_distance As Integer = distance(temp_A1_position, CrossRoadCenter)

                        '_mainForm.Show_LBox_PolicyRightNowText("A1 Distance = " + temp_A1_distance.ToString)



                        Try
                            Dim MyKeys As ICollection
                            'Dim Key As Object
                            Dim temp_p_position As String
                            If (TriggerPointxy.Count = 0) Then
                                _mainForm.Show_LBox_PolicyRightNowText("The HashTable is empty")
                            Else
                                '_mainForm.Show_LBox_PolicyRightNowText("Accessing keys property to return keys collection")
                                MyKeys = TriggerPointxy.Keys()

                                'For Each Key In MyKeys
                                '    _mainForm.Show_LBox_PolicyRightNowText(Key.ToString)
                                '    temp_p_position As String = TriggerPointxy(Key)
                                '    temp_A1_distance = distance(temp_A1_position, temp_p_position)
                                '    _mainForm.Show_LBox_PolicyRightNowText("temp_A1_position = " + temp_A1_position + "   temp_p_position = " + temp_p_position)
                                '    _mainForm.Show_LBox_PolicyRightNowText("A1 Distance with " + Key)
                                'Next


                                For index As Integer = 1 To 3
                                    temp_p_position = TriggerPointxy("P" + index.ToString + "_" + BusGoBack_Direction(Data_A1.Route + "_" + Data_A1.GoBack))
                                    temp_A1_distance = distance(temp_A1_position, temp_p_position)
                                    '_mainForm.Show_LBox_PolicyRightNowText("temp_A1_position = " + temp_A1_position + "   temp_p_position = " + temp_p_position)

                                    Dim temp_label As String = "P" + index.ToString
                                    If temp_A1_distance < 2 And "P" + index.ToString = "P2" Then

                                        '_mainForm.Show_LBox_PolicyRightNowText("A1 Distance with " + "P" + index.ToString + "_" + BusGoBack_Direction(Data_A1.GoBack) + "  -> " + temp_A1_distance.ToString)

                                        Try
                                            Dim DataStructTouchPoint As Class_TriggerPoint = TriggerPointP123_Direction("P" + index.ToString + "_" + BusGoBack_Direction(Data_A1.Route + "_" + Data_A1.GoBack))
                                            'Dim DataStructTouchPoint As Class_TriggerPoint = TriggerPointdList(TriggerPointP123_Direction("P" + index.ToString + "_" + BusGoBack_Direction(Data_A1.GoBack)))
                                            'Dim DataStructTouchPoint As Class_TriggerPoint = TriggerPointdList(TriggerPointP123_Direction("P" + index.ToString + "_6"))
                                            AcceptA2_Procedure_3(DataStructTouchPoint, Data_A1)

                                        Catch ex3 As Exception
                                            _mainForm.Show_LBox_PolicyRightNowText(" new trigger mechanism error" + ex3.StackTrace)
                                        End Try


                                    End If


                                Next index

                            End If
                        Catch ex As Exception

                        End Try

                        If Bus_Distance.ContainsKey(arriveBusID) Then

                            If Bus_Distance(arriveBusID) > temp_A1_distance Then
                                Bus_Distance.Remove(arriveBusID)
                                Bus_Distance.Add(arriveBusID, temp_A1_distance)
                            End If
                        Else
                            Bus_Distance.Add(arriveBusID, temp_A1_distance)
                        End If


                        If A1_Counter = 0 And _mainForm.Label_BusPrimEnable.Text = "啟動" Then
                            Dim sendByte As Byte()
                            Dim tranStr As String = "5F1014"   '5F10  路口手動 + 時相控制

                            If TotalCycleMin = "" Then
                                TotalCycleMin = "05"
                            End If

                            'tranStr = tranStr + TotalCycleMin
                            tranStr = tranStr + "0A"

                            sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
                            _mainForm.send_IC(sendByte)
                            Thread.Sleep(500)
                            _mainForm.send_IC(sendByte)
                            A1_Counter = 1

                        End If


                        If A1_Counter = 3 And _mainForm.Label_BusPrimEnable.Text = "啟動" Then
                            Command2("5F4C")
                            A1_Counter = 1

                        End If




                    ElseIf SaveString(0) = "A2" Then

                        If TriggerPointdList.ContainsKey(Trim(SaveString(7))) Then
                            Dim DataStructTouchPoint As Class_TriggerPoint
                            DataStructTouchPoint = TriggerPointdList.Item(Trim(SaveString(7)))
                            _mainForm.Show_LBox_PolicyRightNowText("<" + arriveBusID + ">收到訊息 A2:TouchPointID=" + SaveString(7) + "  Order=" + DataStructTouchPoint.TriggerPointOrder + "  PointType=" + DataStructTouchPoint.PointType + "(0:開始點,1:離開點,2:決策點,3:參考點)")
                            SaveData_A2(SaveString)



                            If DataStructTouchPoint.PointType.ToString = "00" Then
                                _mainForm.Show_LBox_PolicyRightNowText("第一觸動點 啟動時相控制")


                                Try
                                    FiveFB4.Clear()
                                    FiveFB4.Add("GroupID", _mainForm.TBox_GroupID.Text.ToString)
                                    FiveFB4.Add("CrossRoadID", _mainForm.TBox_CrossRoadID.Text.ToString)
                                Catch ex As Exception
                                    _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 GroupID CrossRoadID " + ex.Message)

                                End Try



                                If _mainForm.Label_BusPrimEnable.Text = "啟動" Then
                                    _mainForm.Show_LBox_PolicyRightNowText("A2 啟動時相控制 ")


                                    Dim sendByte As Byte()
                                    Dim tranStr As String = "5F1014"   '5F10  路口手動 + 時相控制

                                    If TotalCycleMin = "" Then
                                        TotalCycleMin = "05"
                                    End If

                                    'tranStr = tranStr + TotalCycleMin
                                    tranStr = tranStr + "0A"

                                    sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
                                    _mainForm.send_IC(sendByte)
                                End If
                               


                                Try
                                    'FiveFB4.Add("P12", DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss"))
                                    FiveFB4.Add("P1", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                Catch ex As Exception
                                    _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 P12 P1 " + ex.Message)
                                End Try



                                'tranStr = "5F48"                    '5F48  查詢目前時制
                                'sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
                                '_mainForm.send_IC(sendByte)

                            ElseIf DataStructTouchPoint.PointType.ToString = "01" Then
                                _mainForm.Show_LBox_PolicyRightNowText("離開點 關閉時相控制")
                                BusPrime_activate = False
                                Dim sendByte As Byte()
                                Dim tranStr As String = "5F100400"   '5F10  路口手動 + 時相控制
                                sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
                                '_mainForm.send_IC(sendByte)

                                '_mainForm.Show_LBox_PolicyRightNowText("離開點 啟動補償機制")


                                A1_Counter = 0

                                ActivatedBusID.Remove(SaveString(2))

                                Try
                                    'FiveFB4.Add("P32", DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss"))
                                    FiveFB4.Add("P3", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                                    StopRec_TimeStamp = Now
                                Catch ex As Exception
                                    _mainForm.Show_LBox_PolicyRightNowText(" Error FiveFB4 P32 P3 " + ex.Message)
                                End Try


                                _mainForm.Show_LBox_PolicyRightNowText("GroupID " + FiveFB4("GroupID"))
                                _mainForm.Show_LBox_PolicyRightNowText("CrossRoadID " + FiveFB4("CrossRoadID"))
                                _mainForm.Show_LBox_PolicyRightNowText("BusID " + FiveFB4("BusID"))
                                _mainForm.Show_LBox_PolicyRightNowText("BusLineID " + FiveFB4("BusLineID"))
                                _mainForm.Show_LBox_PolicyRightNowText("GoBack " + FiveFB4("GoBack"))
                                _mainForm.Show_LBox_PolicyRightNowText("BusPhase " + FiveFB4("BusPhase"))
                                _mainForm.Show_LBox_PolicyRightNowText("Bus2CrossRoad " + FiveFB4("Bus2CrossRoad"))
                                _mainForm.Show_LBox_PolicyRightNowText("Strategy " + FiveFB4("Strategy"))
                                _mainForm.Show_LBox_PolicyRightNowText("Currentphase " + FiveFB4("Currentphase"))

                                _mainForm.Show_LBox_PolicyRightNowText("P1  time " + FiveFB4("P1"))
                                _mainForm.Show_LBox_PolicyRightNowText("P2  time " + FiveFB4("P2"))
                                _mainForm.Show_LBox_PolicyRightNowText("P3  time " + FiveFB4("P3"))

                                'Dim FiveFB4Str As String = "5FB4" + FiveFB4("GroupID") + FiveFB4("CrossRoadID") + FiveFB4("BusID") + "0" + FiveFB4("BusLineID") + "0" + FiveFB4("GoBack") + FiveFB4("BusPhase") + "0" + FiveFB4("Bus2CrossRoad") + FiveFB4("Strategy") + FiveFB4("Currentphase") + FiveFB4("P12") + FiveFB4("P22") + FiveFB4("P32")
                                '_mainForm.Show_LBox_PolicyRightNowText("5FB4 Str " + FiveFB4Str + " Length " + FiveFB4Str.Length.ToString)
                                Try
                                    BusStrategy_Log2(_mainForm.TBox_GroupID.Text.ToString, _mainForm.TBox_CrossRoadID.Text.ToString, SaveString(2), SaveString(5), SaveString(6), FiveFB4("BusPhase"), FiveFB4("Bus2CrossRoad"), FiveFB4("Strategy"), FiveFB4("Currentphase"), FiveFB4("P1"), FiveFB4("P2"), FiveFB4("P3"), FiveFB4("Play1"), FiveFB4("Play2"))
                                Catch ex As Exception
                                    _mainForm.Show_LBox_PolicyRightNowText("Error  BusStrategy_Log " + ex.Message)
                                End Try


                                'Dim FiveFB4byte As Byte() = Incode_Step1(getSeqNum(), MarkAACommand(FiveFB4Str))
                                'Dim tempstr As String = ByteArrayToStr2(FiveFB4byte)

                                '_mainForm.Show_LBox_PolicyRightNowText("5FB4 message " + tempstr)

                                FiveFB4.Clear()
                                'BusComm_CommunicationStamp.Clear()
                                BusComm_CommunicationStamp.Remove(nowPlayBusID)
                                nowPlayBusID = "-1"

                                _mainForm.Show_LBox_PolicyRightNowText("*****************************************************************************************************************************************")
                            ElseIf DataStructTouchPoint.PointType.ToString = "02" Then

                                Try
                                    'FiveFB4.Add("P22", DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss"))
                                    FiveFB4.Add("P2", Now.ToString("yyyy-MM-dd HH:mm:ss"))

                                Catch ex As Exception
                                    _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 P22 P2 " + ex.Message)
                                End Try




                            End If

                        Else
                            _mainForm.Show_LBox_PolicyRightNowText("<" + arriveBusID + ">收到訊息 A2:StopID=" + SaveString(7) + "  不在觸動表單內")

                            If arriveBusID = nowPlayBusID Then
                                BusComm_CommunicationStamp.Remove(nowPlayBusID)
                                nowPlayBusID = "-1"
                                'BusComm_CommunicationStamp.Clear()
                            End If



                        End If
                    End If
                Else
                    _mainForm.Show_LBox_PolicyRightNowText("<" + arriveBusID + ">已有公車<" + nowPlayBusID + ">執行中,收到訊息 " + SaveString(0) + "無效")


                    

                End If
            Else 'Jason 20150122 TestMode
                _mainForm.Show_LBox_PolicyRightNowText("測試模式 BusID非<" + arriveBusID + ">,收到訊息 " + SaveString(0) + "無效") 'Jason 20150122 TestMode
            End If 'Jason 20150122 TestMode

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Policy_1", "SaveDataFunction_Car Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try

    End Sub


    Dim SpeedKeepHash As New Hashtable
    Public Sub AcceptA1_Procedure_1(ByVal AcceptA1 As Class_A1)
        Try


            If Val(AcceptA1.Speed) < PolicySpeedLimit And ActivatedBusID.ContainsKey(AcceptA1.BusID.ToString) = False Then
                If SpeedKeepHash.ContainsKey(AcceptA1.BusID) Then
                    Dim orgTime As DateTime = SpeedKeepHash.Item(AcceptA1.BusID)
                    Dim DiffSecond As Long = DateDiff(DateInterval.Second, orgTime, Now)
                    If DiffSecond > PolicyDiffSecond Then
                        'nowPlayBusID = "-1"
                        _mainForm.Show_LBox_PolicyRightNowText("低速策略 啟動")

                        

                        If SlowBusID.ContainsKey(AcceptA1.BusID) = False And ActivatedBusID.ContainsKey(AcceptA1.BusID) = False Then
                            SlowBusID.Add(AcceptA1.BusID.ToString, Now)

                            Try
                                FiveFB4.Add("Strategy", "55")
                                FiveFB4.Add("Play2", "NoChange")
                            Catch ex As Exception
                                _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 55 " + ex.Message)
                            End Try

                        End If

                    End If
                Else
                    SpeedKeepHash.Add(AcceptA1.BusID, Now)
                End If
            Else
                If SpeedKeepHash.ContainsKey(AcceptA1.BusID) Then
                    SpeedKeepHash.Remove(AcceptA1.BusID)
                End If
            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Policy_1", "AcceptA1_Procedure_1 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    'TriggerPointdList can find all infomation
    Public Sub AcceptA2_Procedure_1(ByVal AcceptA2 As Class_A2)
        Try
            Dim DataStructTouchPoint As Class_TriggerPoint

            'SendLightRemainSec(Data_A2.BusID, "R", 100)
            'If isBusSameDirection(DataStructTouchPoint) Then

            '_mainForm.Show_LBox_PolicyRightNowText("Sending to buS")
            'End If

           

            If TriggerPointdList.ContainsKey(Trim(Data_A2._Stop)) Then
                DataStructTouchPoint = TriggerPointdList(Trim(Data_A2._Stop))   'Data_A2._Stop is triggerpointid of the A2 data 

               

                If DataStructTouchPoint.PointType = "1" Or DataStructTouchPoint.PointType = "01" Then '離開點
                    nowPlayBusID = "-1"  ' What needs to go when there are two buses
                    BusPrime_activate = False

                    Try
                        Phase_Commands.Clear()
                        _mainForm.Show_LBox_PolicyRightNowText("Bus left, Clear all  Bus Commands ")
                        StopRec_TimeStamp = Now

                    Catch tx As Exception

                    End Try


                   

                ElseIf DataStructTouchPoint.PointType = "2" Or DataStructTouchPoint.PointType = "02" Then '決策點
                    Current_BusLineID = Data_A1.Route
                    AcceptA2_Procedure_2(DataStructTouchPoint, AcceptA2)

                End If
            End If

            
          

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Policy_1", "AcceptA2_Procedure_1 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub AcceptA2_Procedure_2(ByVal rTouchPoint As Class_TriggerPoint, ByVal AcceptA2 As Class_A2)

        Try
            If _mainForm.Label_BusPrimEnable.Text = "啟動" And BusPrime_activate = False And SlowBusID.ContainsKey(AcceptA2.BusID.ToString) = False And PayBack_Status = False Then
                'If _mainForm.Label_BusPrimEnable.Text = "啟動" And BusPrime_activate = False Then

                BusPrime_activate = True 'one Bus can only activate the bus prime Strategy once
                ActivatedBusID.Add(AcceptA2.BusID.ToString, Now)


                _mainForm.Show_LBox_PolicyRightNowText(" 公車優先策略啟動 1")

                Try
                    'FiveFB4.Add("P22", DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss"))
                    FiveFB4.Add("P2", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    StartRec_TimeStamp = Now
                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 P22 P2 " + ex.Message)
                End Try

                Dim CrossRoadID As String = _mainForm.TBox_CrossRoadID.Text.ToString
                'Dim BusLineID As String = Current_BusLineID
                Dim BusLineID As String = AcceptA2.Route.ToString
                Dim Running_BusID As String = AcceptA2.BusID.ToString
                Dim Running_Bus_Goback As String = AcceptA2.GoBack.ToString

                Dim onethree As Boolean = False

                _mainForm.Show_LBox_PolicyRightNowText("BusLineID " + BusLineID)
                _mainForm.Show_LBox_PolicyRightNowText("BusID " + Running_BusID)
                _mainForm.Show_LBox_PolicyRightNowText("Bus_Goback " + Running_Bus_Goback)



                Dim Year As String = DateTime.Today.ToString("yyyy")
                Dim Month As String = DateTime.Today.ToString("MM")
                Dim Day As String = DateTime.Today.ToString("dd")
                Dim Hour As String = DateTime.Now.ToString("HH")
                Dim Min As String = DateTime.Now.ToString("mm")
                Dim Sec As String = DateTime.Now.ToString("ss")

                '_mainForm.Show_LBox_PolicyRightNowText(" Year " + Year + " Month " + Month + " Day " + Day + " Hour " + Hour + " Min " + Min + " Sec " + Sec)

                Command2("5F4C")
                Thread.Sleep(1000)

                _mainForm.Show_LBox_PolicyRightNowText("現在分相 " + Data_5FCC.Current_SubPhaseID.ToString + " 現在步階 " + Data_5FCC.Current_StepID + " 剩餘秒數 " + HexStringTOIntString(Data_5FCC.Current_RemainingTime, 4).ToString)

                Try
                    FiveFB4.Add("Currentphase", Data_5FCC.Current_SubPhaseID.ToString + Data_5FCC.Current_StepID + Data_5FCC.Current_RemainingTime)
                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Currentphase " + ex.Message)
                End Try


                '_mainForm.Show_LBox_PolicyRightNowText("Signal Map " + Data_5F03.SignalMap)

                '公車第幾分相 bug 如果第一步階 不是可過綠燈則不會認定是可過分相
                '須從每分相裏頭的每步階的燈態下去判斷
                If NEAR_BusStop = "1" Then
                    Try
                        'Phase_Commands.Add("01", "5F1C") 'Each Phase should put its commands inside the hashtable and exceute the results elsewhere Except the commands that need to be excuted imediatlly 
                        '_mainForm.Show_LBox_PolicyRightNowText(BusPhaseOrNot(BusLineID, CrossRoadID, Running_Bus_Goback)) '301 0001 1  -> 0001_0001_00 the data is wrong convert it
                        _mainForm.Show_LBox_PolicyRightNowText("BusStop Distance  String " + BusStopDist_Tab(CrossRoadID + "_" + Running_Bus_Goback).ToString)
                        Dim BusStopDistInt As Integer = Val(BusStopDist_Tab(CrossRoadID + "_" + Running_Bus_Goback).ToString)


                        If BusStopDistInt > 0 Then

                            If BusStopDistInt < 60 Then
                                _mainForm.Show_LBox_PolicyRightNowText("上游站牌距離路口小於60公尺屬近端設站")
                                isBusStopNear = True

                                Dim BusStopDelay_Int As Integer = Val(BusStopDelay_Tab("BusStopDelay_" + Running_Bus_Goback))
                                Dim Bus2Cross_Int As Integer = Val(BusStopDelay_Tab("BusStop2Cross_" + Running_Bus_Goback))

                                Total_BusDelay = BusStopDelay_Int + Bus2Cross_Int
                                '_mainForm.Show_LBox_PolicyRightNowText("Total_BusDelay =" + Total_BusDelay.ToString)
                            Else
                                _mainForm.Show_LBox_PolicyRightNowText("上游站牌距離路口大於60公尺不屬近端設站")
                                isBusStopNear = False

                            End If


                        Else
                            _mainForm.Show_LBox_PolicyRightNowText("此路口無上游站牌 ")
                            isBusStopNear = False
                        End If


                    Catch ex As Exception

                        _mainForm.Show_LBox_PolicyRightNowText(" Test Area Error " + ex.StackTrace)
                    End Try
                End If


                'Try
                '    'BusLineList key -> buslineID_CrossRoadID

                '    '_mainForm.Show_LBox_PolicyRightNowText("BusLine Route  " + Current_BusLineID.ToString() + "  Bus Line Data " + BusLineList("0001_0002").ToString + " CrossRoadID " + _mainForm.TBox_CrossRoadID.Text)
                '    'Dim BusLineData As String = BusLineList("0001_0002")
                '    'Dim BusLineData As String() = BusLineList().Split(",")

                '    _mainForm.Show_LBox_PolicyRightNowText("NowPhase =" + Data_5FCC.Current_SubPhaseID)

                '    'If (BusPhaseOrNot(BusLineID, CrossRoadID, Running_Bus_Goback)) Then
                '    '    _mainForm.Show_LBox_PolicyRightNowText("PASSSSSSSSSSSSSSSSSSSSSSSSSSSSS")
                '    'Else
                '    '    _mainForm.Show_LBox_PolicyRightNowText("NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO")
                '    'End If

                '    Dim BusLineData As String() = BusLineList("0001_0001_00").Split(",")   ' BusLineList key = "BusLineID_CrossRoadID_GoBack"  

                '    _mainForm.Show_LBox_PolicyRightNowText(" BuslineData PassPhase " + BusLineData(4))

                '    Dim BusPassPhases As BitArray = New BitArray(8)
                '    Dim a() As Byte = {BusLineData(4)}
                '    BusPassPhases = New BitArray(a)




                'Catch ex As Exception
                '    _mainForm.Show_LBox_PolicyRightNowText("Bus Line Data error " + ex.StackTrace.ToString)

                'End Try



                'TRY USING 5F03 INSTEAD OF 5F13 
                Try
                    'If Data_5F18 Is Nothing Then
                    '    TotalPhase = Data_5F13.SubPhaseCount.ToString
                    'ElseIf Data_5F13 Is Nothing Then
                    '    TotalPhase = Data_5F18.SubPhaseCount.ToString
                    'End If

                    TotalPhase = Data_5F13.SubPhaseCount.ToString

                Catch ex As Exception

                    _mainForm.Show_LBox_PolicyRightNowText("Error Can't get the total phase " + ex.StackTrace)
                End Try
                'TotalPhase = Data_5F18.SubPhaseCount.ToString
                'TotalPhase = Data_5F13.SubPhaseCount.ToString
                TotalPhaseInt = Convert.ToDecimal(TotalPhase)  'Total Subphases at this intercection 

                Dim LightArray(0 To TotalPhaseInt) As String
                Dim Massgg(0 To TotalPhaseInt) As Integer
                Dim Massggstr(0 To TotalPhaseInt) As String
                Dim Microgg(0 To TotalPhaseInt) As Integer
                Dim Microggstr(0 To TotalPhaseInt) As String
                Dim Yellowrr(0 To TotalPhaseInt) As Integer
                Dim Greenint(0 To TotalPhaseInt) As Integer
                Dim Longer(0 To TotalPhaseInt) As Integer
                Dim Shorter(0 To TotalPhaseInt) As Integer
                Dim PedFlash(0 To TotalPhaseInt) As Integer

                Dim BusPassPhase As String = ""


                Dim RemanSecBusCrossRoad As Integer

                Dim Pplay1 As String = ""
                Dim Pplay2 As String = ""


                For index As Integer = 0 To TotalPhaseInt - 1

                    'Try
                    '    '_mainForm.Show_LBox_PolicyRightNowText(" rTouchPoint.Direct " + rTouchPoint.Direct.ToString + " Data_5F13.SignalStatus(index) " + Data_5F13.SignalStatus(index) + "  Data_5F13.SignalMap " + Data_5F13.SignalMap)

                    '    If isPass(rTouchPoint.Direct, Data_5F13.SignalStatus(index), Data_5F13.SignalMap) Then
                    '        _mainForm.Show_LBox_PolicyRightNowText("這分相我能過 " + index.ToString)
                    '        BusPassPhase = All_Phases(index)

                    '    End If
                    '    '_mainForm.Show_LBox_PolicyRightNowText("Index " + HexNum(index) + "Data_5F13.SignalStatus(index)" + Data_5F13.SignalStatus(index))
                    'Catch ex As Exception
                    '    _mainForm.Show_LBox_PolicyRightNowText(" 無法判斷公車能通過的分相 " + ex.StackTrace.ToString)

                    'End Try


                    LightArray(index) = Data_5F14.LightStatus(index)
                    '_mainForm.Show_LBox_PolicyRightNowText(" Light " + LightArray(index))
                    '_mainForm.Show_LBox_PolicyRightNowText("Signal Status " + Data_5F13.SignalStatus(index))

                    Try


                        Yellowrr(index) = YellowplusRed(Data_5F14.LightStatus(index)) 'yellow plus red  
                        PedFlash(index) = PedGreenFlashRed(Data_5F14.LightStatus(index))
                        Microgg(index) = MinGreen(Data_5F14.LightStatus(index)) - PedFlash(index)
                        Microggstr(index) = IntToHexString(Microgg(index), 2)
                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("取不到最小綠 使用預設 10 秒")
                        Microgg(index) = 10
                        Microggstr(index) = "0A"
                        Yellowrr(index) = 5
                    End Try


                    Try
                        Greenint(index) = CurrentGreen(Data_5F15.Green(index))

                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("取不到正常綠 無法跑策略")
                    End Try


                    'Massgg(index) = MaxGreen(Data_5F14.LightStatus(index))
                    _mainForm.Show_LBox_PolicyRightNowText(" 分相 " + index.ToString + "  綠燈 " + Greenint(index).ToString + " 最小綠 " + Microgg(index).ToString + " 行閃行紅 " + PedFlash(index).ToString + " 黃燈+全紅 " + Yellowrr(index).ToString)
                    Pplay1 = Pplay1 + Greenint(index).ToString + "," + Yellowrr(index).ToString + ";"

                Next


                FiveFB4.Add("Play1", Pplay1)

                For index As Integer = 0 To TotalPhaseInt - 1
                    Dim TempMicro As Integer

                    Try
                        If index < (TotalPhaseInt - 1) Then
                            TempMicro = Microgg(index + 1)
                        Else
                            TempMicro = Microgg(0)
                        End If

                        Massgg(index) = Greenint(index) + TempMicro + 10
                        Massggstr(index) = IntToHexString(Massgg(index), 2)

                        _mainForm.Show_LBox_PolicyRightNowText(index.ToString + " 最大綠 " + Massgg(index).ToString)
                        '_mainForm.Show_LBox_PolicyRightNowText(index.ToString + " 最大綠 " + Massgg(index).ToString + "Hex " + Massggstr(index).ToString)
                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("無法計算最大綠" + ex.Message)
                    End Try

                Next


                Try
                    For index As Integer = 0 To TotalPhaseInt - 1
                        Shorter(index) = Greenint(index) - Microgg(index)
                        Longer(index) = Massgg(index) - Greenint(index)
                        '_mainForm.Show_LBox_PolicyRightNowText(index.ToString + " Longer " + Longer(index).ToString)
                        '_mainForm.Show_LBox_PolicyRightNowText(index.ToString + " Shorter " + Shorter(index).ToString)
                    Next
                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Error on extention" + ex.StackTrace)
                End Try


                'Dim Point1 As String = "25.072813,121.576059"  
                'Dim Point2 As String = "25.073241,121.577815"
                'Dim Point3 As String = "25.073532,121.578643"

                '_mainForm.Show_LBox_PolicyRightNowText("MOS > Hilife  Distance: " + distance(Point1, Point2).ToString)
                '_mainForm.Show_LBox_PolicyRightNowText(" Hilife > Parking  Distance: " + distance(Point2, Point3).ToString)


                'Dim NowPhaseID As String = "0" + BusPriority_IPC.MainForm.TBox_SubPhaseOrder.Text   'minus 1 twaut 
                'Dim NowPhaseID As String = NowSubPhaseIDstring

                'Dim NowStepID As String = NowStepIDstring
                'Dim NowPlanID As String = Data_5F18.PlanID
                'Dim NowGreen As String = Data_5F18.Green
                'HexStringTOIntString(Data_5F03.StepSec, 4)
                'Dim Light As String = Data_5F14.LightStatus(NowSubPhaseIDstring - 1)
                'Dim Max As String = MaxGreen(Light)
                'Dim Min As String = MinGreen(Light)
                'Min = HexStringTOIntString(Min, 2)
                'Max = HexStringTOIntString(Max, 2)

                'TBox_StepOrder
                'TBox_SubPhaseOrder

                'Dim StrNextMaxGreenSecond As String = Data_5F14.LightStatus(NowPhaseID)
                'Dim IntNextMaxGreenSecnod As Integer = Val(HexStringTOIntString(StrNextMaxGreenSecond.Substring(2, 4), 4))
                'Dim iRG_i_2 As Integer = IntNextMaxGreenSecnod
                'Dim NowPhaseID As Integer = Val(Data_5F03.SubPhaseID)
                'Dim tmpString As String = Data_5F14.LightStatus(0)
                '_mainForm.Show_LBox_PolicyRightNowText("Lights " + Data_5F14.PlanID)

                'Dim maxGreenSec As Integer = Val(HexStringTOIntString(tmpString.Substring(2, 4), 4))

                Dim CurrentPhaseInt As Integer = Convert.ToDecimal(Data_5FCC.Current_SubPhaseID)
                Dim CurrentStepInt As Integer = Convert.ToDecimal(Data_5FCC.Current_StepID)
                Dim CurrentRemainingTime As Integer = Data_5FCC.Current_RemainingInt


                Dim RG_Status As String
                RemanSecBusCrossRoad = SecondOfCar2CrossRoad(Data_A1.X + "," + Data_A1.Y, rTouchPoint.StopLineLatLon, Data_A1.Speed)
                Try
                    FiveFB4.Add("Bus2CrossRoad", RemanSecBusCrossRoad.ToString)
                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Bus2CrossRoad " + ex.Message)
                End Try




                If BusPhaseOrNot(BusLineID, CrossRoadID, Running_Bus_Goback) Then      'If isBusSameDirection(rTouchPoint.Direct) Then
                    _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">目前公車方向燈號為綠燈[1]")
                    RemanSecBusCrossRoad = SecondOfCar2CrossRoad(Data_A1.X + "," + Data_A1.Y, rTouchPoint.StopLineLatLon, Data_A1.Speed)
                    RG_Status = "G"



                    'Dim Cal_RG_i As Integer = RG_i(rTouchPoint.Direct) '公車時相剩餘綠燈
                    Dim Cal_RG_i As Integer = RemainingLightTime(True)
                    'Dim Remain2 As Integer = RemainingLightTime2(True)
                    _mainForm.Show_LBox_PolicyRightNowText("Remaining Green Time " + Cal_RG_i.ToString)
                    '_mainForm.Show_LBox_PolicyRightNowText("Remaining Green Time2 " + Remain2.ToString)
                    If RemanSecBusCrossRoad < Cal_RG_i Then 'OK
                        '公車到路口剩餘秒數小於公車時相剩餘綠燈-->維持原時制
                        _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小於 公車時相剩餘綠燈 " + Cal_RG_i.ToString + " -->維持原時制[1-1]")
                        _mainForm.Show_BusPolicyText("維持原時制")

                        Try
                            FiveFB4.Add("Strategy", "11")
                            FiveFB4.Add("Play2", "NoChange")
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 11 " + ex.Message)
                        End Try

                    Else

                        '_mainForm.Show_LBox_PolicyRightNowText(" 此分相最大綠 " + Massgg(CurrentPhaseInt - 1).ToString + " 此分相正常綠燈 " + Greenint(CurrentPhaseInt - 1).ToString + " 剩餘綠燈 " + Cal_RG_i.ToString)

                        If Data_5FCC.Current_StepID = "01" And Data_5FCC.Current_RemainingInt > 4 Then
                            _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於 公車時相剩餘綠燈 " + Cal_RG_i.ToString + " -->公車時相延長至最大綠[1-2]")
                            Command("5F1C" + Data_5FCC.Current_SubPhaseID + "01" + Massggstr(CurrentPhaseInt - 1))
                            _mainForm.Show_LBox_PolicyRightNowText(" 延長 " + CurrentPhaseInt.ToString + "分相 " + Longer(CurrentPhaseInt - 1).ToString + " 秒")
                            Pplay2 = CurrentPhaseInt.ToString + "," + Longer(CurrentPhaseInt - 1).ToString + ";"


                            Try
                                Rec_CycleID = CycleID
                                FiveFB4.Add("Strategy", "12")
                                FiveFB4.Add("Play2", Pplay2)
                            Catch ex As Exception
                                _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 12 " + ex.Message)
                            End Try

                        Else
                            _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 非第一步階無法延長綠燈 " + Cal_RG_i.ToString + " -->公車競爭分相縮短至最短綠[1-3]")

                            Try
                                Rec_CycleID = CycleID
                                FiveFB4.Add("Strategy", "13")
                            Catch ex As Exception
                                _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 13 " + ex.Message)
                            End Try

                            'If Data_5FCC.Current_StepID = "01" Then

                            '    Command("5F1C" + Data_5FCC.Current_SubPhaseID + "01" + IntToHexString(Microgg(CurrentPhaseInt - 1), 2))
                            'Else
                            '    _mainForm.Show_LBox_PolicyRightNowText("非第一步接不能縮此分相")
                            'End If


                            onethree = True

                            For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                                If BusPassPhases(index - 1) = False Then
                                    _mainForm.Show_LBox_PolicyRightNowText("Save Command " + "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                    Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                    _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + index.ToString + "分相 " + Shorter(index - 1).ToString + " 秒")
                                    Pplay2 = Pplay2 + index.ToString + ",-" + Shorter(index - 1).ToString + ";"
                                Else
                                    Exit For
                                End If

                            Next index

                            For index As Integer = 1 To CurrentPhaseInt - 1
                                If BusPassPhases(index - 1) = False Then
                                    _mainForm.Show_LBox_PolicyRightNowText("Save Command " + "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                    Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                    _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + index.ToString + "分相 " + Shorter(index - 1).ToString + " 秒")
                                    Pplay2 = Pplay2 + index.ToString + ",-" + Shorter(index - 1).ToString + ";"
                                Else
                                    Exit For
                                End If

                            Next index

                            Try
                                FiveFB4.Add("Play2", Pplay2)
                            Catch ex As Exception
                                _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy Play2 " + ex.Message)
                            End Try

                            'For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                            '    If BusPassPhases(index - 1) = False Then
                            '        Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                            '        If CurrentPhaseInt <> 1 Then
                            '            For index2 As Integer = 1 To CurrentPhaseInt - 1

                            '                If BusPassPhases(index2 - 1) = False Then
                            '                    Phase_Commands.Add(IntToHexString(index2, 2), "5F1C" + IntToHexString(index2, 2) + "01" + IntToHexString(Microgg(index2 - 1), 2))
                            '                End If


                            '            Next

                            '        End If


                            '    End If

                            'Next

                        End If
                        'Dim Cal_G_j As Integer = G_j(rTouchPoint.Direct)
                        'If RemanSecBusCrossRoad > (Cal_RG_i + Cal_G_j) Then
                        '    '公車到路口剩餘秒數大於公車時相剩餘綠燈加衝突時相所有步階秒數-->維持原時制  This is clearly Bougos
                        '    '_mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於 公車時相剩餘綠燈(" + Cal_RG_i.ToString + ")加衝突時相所有步階秒數(" + Cal_G_j.ToString + ")-->維持原時制[1-2]")
                        '    '_mainForm.Show_BusPolicyText("維持原時制")
                        'Else
                        '    Dim Cal_RG_iMax As Integer = RG_i_max(rTouchPoint.Direct)
                        '    If RemanSecBusCrossRoad <= Cal_RG_iMax Then
                        '        '公車到路口剩餘秒數小(等)於公車時相最大綠剩餘綠燈-->將綠燈延長至RemanSecBusCrossRoad
                        '        Dim stepsec As Integer = _mainForm.TBox_StepSec.Text
                        '        Dim passed As Integer = stepsec - Cal_RG_i
                        '        Dim RemainHex = IntToHexString(RemanSecBusCrossRoad + passed, 2)
                        '        ' NowPhase = Data_5FCC.Current_SubPhaseID  NowStep =  Data_5FCC.Current_StepID   RemaingTime = Data_5FCC.Current_RemainingInt)

                        '        _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小(等)於公車時相最大綠剩餘綠燈(" + Cal_RG_iMax.ToString + ")-->將綠燈秒數延長至(" + RemanSecBusCrossRoad.ToString + ")[1-3]")
                        '        _mainForm.Show_BusPolicyText("將公車時相綠燈延長至(" + RemanSecBusCrossRoad.ToString + ")")
                        '        '_mainForm.Show_LBox_PolicyRightNowText("步階時間 " + stepsec.ToString + " 已經過時間 " + passed.ToString + " 該下時間 " + (RemanSecBusCrossRoad + passed).ToString)

                        '        Dim index As Integer = Val(Data_5FCC.Current_SubPhaseID) - 1
                        '        _mainForm.Show_LBox_PolicyRightNowText(" Original Green  " + Greenint(index).ToString)

                        '        Command("5F1C" + NowSubPhaseIDstring + "00" + RemainHex)
                        '        _mainForm.Show_LBox_PolicyRightNowText(" Modified Green  " + (RemanSecBusCrossRoad + passed).ToString)

                        '        'Cal_RG_i = RemanSecBusCrossRoad + passed
                        '    Else
                        '        Dim Cal_G_jMin As Integer = G_j_min(rTouchPoint.Direct)
                        '        If RemanSecBusCrossRoad <= (Cal_RG_i + Cal_G_jMin) Then
                        '            '公車到路口剩餘秒數小(等)於公車時相剩餘綠燈加衝突時相所有步階(最小綠)秒數-->將衝突時相綠燈改為最小綠

                        '            _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小(等)於公車時相剩餘綠燈(" + Cal_RG_i.ToString + ")加衝突時相所有步階(最小綠)秒數(" + Cal_G_jMin.ToString + ")-->將衝突時相綠燈改為最小綠[1-4]")
                        '            _mainForm.Show_BusPolicyText("將衝突相綠燈改為最小綠")

                        '            For index As Integer = 0 To TotalPhaseInt - 1    'Except the phase of the bus
                        '                If All_Phases(index) <> BusPassPhase Then
                        '                    Command("5F1C" + All_Phases(index) + "00" + Microggstr(index))
                        '                    _mainForm.Show_LBox_PolicyRightNowText("將分相 " + All_Phases(index) + " 步階 " + "01" + " 縮短至最小綠 " + HexStringTOIntString(Microggstr(index), 2))
                        '                End If
                        '            Next
                        '        Else
                        '            '公車到路口剩餘秒數大於公車時相剩餘綠燈加衝突時相所有步階(最小綠)秒數-->將衝突時相綠燈改為RemanSecBusCrossRoad減G_j,平均分配

                        '            _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於公車時相剩餘綠燈(" + Cal_RG_i.ToString + ")加衝突時相所有步階(最小綠)秒數(" + Cal_G_jMin.ToString + ")-->將衝突時相綠燈改為到路口秒數(" + RemanSecBusCrossRoad.ToString + ")減綠燈剩餘秒數(" + Cal_RG_i.ToString + "),平均分配[1-5]")
                        '            _mainForm.Show_BusPolicyText("將衝突相綠燈改為到路口剩餘數減去衝突相步階秒數")
                        '            Try
                        '                Dim Split As Integer = (RemanSecBusCrossRoad - Cal_RG_i) / (Val(TotalPhase) - 1)
                        '                Dim SplitHex As String = IntToHexString(Split, 2)
                        '                For index As Integer = 0 To TotalPhaseInt - 1    'Except the phase of the bus
                        '                    If All_Phases(index) <> BusPassPhase Then

                        '                        Command("5F1C" + All_Phases(index) + "00" + SplitHex)
                        '                        _mainForm.Show_LBox_PolicyRightNowText("將分相 " + All_Phases(index) + " 步階 " + "01" + " 縮短至 " + SplitHex)

                        '                    End If
                        '                Next
                        '            Catch ex As Exception
                        '                _mainForm.Show_LBox_PolicyRightNowText("Error on 1-5")
                        '            End Try

                        '        End If
                        '    End If
                        'End If
                    End If
                Else
                    _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">目前公車方向燈號為紅燈[2]")
                    RemanSecBusCrossRoad = SecondOfCar2CrossRoad(Data_A1.X + "," + Data_A1.Y, rTouchPoint.StopLineLatLon, Data_A1.Speed)
                    'Dim Cal_RG_j As Integer = RG_j(rTouchPoint.Direct) '剩餘紅燈
                    Dim Cal_RG_j As Integer = RemainingLightTime(False)
                    'Dim Remain2 As Integer = RemainingLightTime2(False)
                    RG_Status = "R"
                    _mainForm.Show_LBox_PolicyRightNowText("Remaining Red Time " + Cal_RG_j.ToString)
                    '_mainForm.Show_LBox_PolicyRightNowText("Remaining Red Time2 " + Remain2.ToString)

                    If RemanSecBusCrossRoad > Cal_RG_j Then
                        '公車到路口剩餘秒數大於公車衝突時相剩餘所有步階秒數-->維持原時制
                        _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於公車衝突時相剩餘紅燈(" + Cal_RG_j.ToString + ")-->維持原時制[2-1]")


                        Try
                            FiveFB4.Add("Strategy", "21")
                            FiveFB4.Add("Play2", "NoChange")
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 21 " + ex.Message)
                        End Try

                    Else

                        _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小於公車衝突時相剩餘紅燈(" + Cal_RG_j.ToString + ")-->縮短衝突時相[2-2]")


                        Try
                            Rec_CycleID = CycleID
                            FiveFB4.Add("Strategy", "22")
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 22 " + ex.Message)
                        End Try

                        If Data_5FCC.Current_StepID = "01" And Data_5FCC.Current_RemainingInt > 4 Then

                            Command("5F1C" + Data_5FCC.Current_SubPhaseID + "01" + Microggstr(CurrentPhaseInt - 1))
                            _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + CurrentPhaseInt.ToString + "分相 " + Shorter(CurrentPhaseInt - 1).ToString + " 秒")
                            Pplay2 = Pplay2 + CurrentPhaseInt.ToString + ",-" + Shorter(CurrentPhaseInt - 1).ToString + ";"
                        Else
                            _mainForm.Show_LBox_PolicyRightNowText("非第一步階，不能縮短此分相 " + Data_5FCC.Current_SubPhaseID.ToString)

                        End If

                        For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                            If BusPassPhases(index - 1) = False Then
                                _mainForm.Show_LBox_PolicyRightNowText("Save Command " + "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + index.ToString + "分相 " + Shorter(index - 1).ToString + " 秒")
                                Pplay2 = Pplay2 + index.ToString + ",-" + Shorter(index - 1).ToString + ";"
                            Else
                                Exit For
                            End If

                        Next index

                        For index As Integer = 1 To CurrentPhaseInt - 1
                            If BusPassPhases(index - 1) = False Then
                                _mainForm.Show_LBox_PolicyRightNowText("Save Command " + "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + index.ToString + "分相 " + Shorter(index - 1).ToString + " 秒")
                                Pplay2 = Pplay2 + index.ToString + ",-" + Shorter(index - 1).ToString + ";"
                            Else
                                Exit For
                            End If

                        Next index

                        Try

                            FiveFB4.Add("Play2", Pplay2)
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy Play2 2-2" + ex.Message)
                        End Try

                        'For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                        '    If BusPassPhases(index - 1) = False Then
                        '        Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                        '        If CurrentPhaseInt <> 1 Then
                        '            For index2 As Integer = 1 To CurrentPhaseInt - 1

                        '                If BusPassPhases(index2 - 1) = False Then
                        '                    Phase_Commands.Add(IntToHexString(index2, 2), "5F1C" + IntToHexString(index2, 2) + "01" + IntToHexString(Microgg(index2 - 1), 2))
                        '                End If


                        '            Next

                        '        End If


                        '    End If

                        'Next

                        'Dim Cal_RG_jMin As Integer = RG_j_min(rTouchPoint.Direct)
                        'If RemanSecBusCrossRoad > Cal_RG_jMin Then
                        '    '公車到路口剩餘秒數大於公車衝突時相剩餘所有步階(最小綠)秒數-->將衝突時相綠燈改為RemanSecBusCrossRoad平均分配

                        '    _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於公車衝突時相剩餘所有步階(最小綠)秒數(" + Cal_RG_jMin.ToString + ")-->將衝突時相綠燈改為(" + RemanSecBusCrossRoad.ToString + ")平均分配[2-2]")
                        '    _mainForm.Show_BusPolicyText("將衝突時相綠燈改為到路口剩餘秒數")

                        '    Try
                        '        Dim Split As Integer = (RemanSecBusCrossRoad - Cal_RG_j) / (Val(TotalPhase) - 1)
                        '        Dim SplitHex As String = IntToHexString(Split, 2)
                        '        For index As Integer = 0 To TotalPhaseInt - 1    'Except the phase of the bus
                        '            If All_Phases(index) <> BusPassPhase Then

                        '                Command("5F1C" + All_Phases(index) + "00" + SplitHex)
                        '                _mainForm.Show_LBox_PolicyRightNowText("將分相 " + All_Phases(index) + " 步階 " + "00" + " 縮短至 " + SplitHex)
                        '            End If
                        '        Next
                        '    Catch ex As Exception
                        '        _mainForm.Show_LBox_PolicyRightNowText("Error on 2-2")
                        '    End Try
                        'Else
                        '    Dim Cal_RG_i As Integer = RG_i(rTouchPoint.Direct)
                        '    '公車到路口剩餘秒數小(等)於公車衝突時相剩餘所有步階(最小綠)秒數-->將衝突時剩餘相綠燈改為最小綠

                        '    _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小(等)於公車衝突時相剩餘所有步階(最小綠)秒數(" + Cal_RG_jMin.ToString + ")-->將衝突時剩餘相綠燈改為最小綠[2-3]")
                        '    _mainForm.Show_BusPolicyText("將衝突相綠燈改為剩餘最小綠")

                        '    'Dim TotalPhase As String = Data_5F13.SubPhaseCount
                        '    'Dim TotalPhaseInt As Integer = Convert.ToDecimal(TotalPhase)  'Total Subphases at this intercection 
                        '    For index As Integer = 0 To TotalPhaseInt - 1    'Except the phase of the bus
                        '        If All_Phases(index) <> BusPassPhase Then
                        '            Command("5F1C" + All_Phases(index) + "00" + Microggstr(index))
                        '            _mainForm.Show_LBox_PolicyRightNowText("將分相 " + All_Phases(index) + " 步階 " + "01" + " 縮短至最小綠 " + HexStringTOIntString(Microggstr(index), 2))
                        '        End If
                        '        '_mainForm.Show_LBox_PolicyRightNowText("Hi " + HexNum(index))

                        '    Next
                        'End If
                    End If

                End If

                Try


                    'Command("5F4C")
                    'Thread.Sleep(3000)





                    '_mainForm.Show_LBox_PolicyRightNowText(" GroupID" + COMMON_GroupID.ToString + " BusID " + Data_A2.BusID.ToString + " Direct " + rTouchPoint.Direct.ToString + " BusPhaseID " + BusPassPhase.ToString + "Bus ETA  " + RemanSecBusCrossRoad.ToString + " BusWayLightStatus " + RG_Status + " BusWayRemainLight " + "N/A" + " Modify PhaseID" + "N/A" + " OriginalGreenTime " + " N/A " + " Modified Green " + " N/A " + " DateTime " + " N/A ")

                    'Data_A2.BusID   COMMON_GroupID  rTouchPoint.Direct CrossRoadID  BusPassPhase  RemanSecBusCrossRoad.ToString  RG_Stauts  Data_5FCC.Current_RemainingInt
                    'StrategyLog(GroupID, CrossRoadID, Direct , BusID , BusPhaseID ,BusETA , BusWayLightStatus , BusWayRemainLight, ModifyPhaseID , OriginalGreenTime , ModifiedGreenTime , TimeDate )

                    'StrategyLog(COMMON_GroupID, )



                    Dim Cal_RG_i As Integer
                    Dim Cal_RG_j As Integer
                    If RG_Status = "G" Then
                        Cal_RG_i = RemainingLightTime(True)
                        SentTime = Cal_RG_i

                        SentLight = "G"

                        'If onethree = True Then
                        '    Cal_RG_i = Cal_RG_i + Greenint(CurrentPhaseInt) + 5
                        '    RG_Status = "R"
                        'End If


                    Else
                        Cal_RG_j = RemainingLightTime(False)
                        SentTime = Cal_RG_j
                        SentLight = "R"
                    End If
                    SendLightRemainSec(Data_A2.BusID, SentLight, SentTime)




                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Send Time Error")
                End Try

            Else

                If PayBack_Status = True Then
                    _mainForm.Show_LBox_PolicyRightNowText("進行補償 不執行公車優先 ")
                    Try
                        FiveFB4.Add("Strategy", "88")
                        FiveFB4.Add("Play2", "NoChange")
                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 88 " + ex.Message)
                    End Try
                ElseIf _mainForm.Label_BusPrimEnable.Text <> "啟動" Then
                    _mainForm.Show_LBox_PolicyRightNowText(" 公車優先關閉 不執行公車優先 ")
                    Try
                        FiveFB4.Add("Strategy", "E9")
                        FiveFB4.Add("Play2", "NoChange")
                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy E9 " + ex.Message)
                    End Try

                End If


            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            _mainForm.Show_LBox_PolicyRightNowText(trace.ToString)
            WriteLog(curPath, "Module_Policy_1", "AcceptA2_Procedure_2 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try

    End Sub


    Public Sub AcceptA2_Procedure_3(ByVal rTouchPoint As Class_TriggerPoint, ByVal AcceptA2 As Class_A1)


        Try
            
            If _mainForm.Label_BusPrimEnable.Text = "啟動" And BusPrime_activate = False And SlowBusID.ContainsKey(AcceptA2.BusID.ToString) = False And PayBack_Status = False Then
                'If _mainForm.Label_BusPrimEnable.Text = "啟動" And BusPrime_activate = False Then

                BusPrime_activate = True 'one Bus can only activate the bus prime Strategy once
                ActivatedBusID.Add(AcceptA2.BusID.ToString, Now)


                _mainForm.Show_LBox_PolicyRightNowText(" 公車優先策略啟動 2")

                Try
                    'FiveFB4.Add("P22", DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss"))
                    FiveFB4.Add("P2", Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    StartRec_TimeStamp = Now
                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 P22 P2 " + ex.Message)
                End Try

                Dim CrossRoadID As String = _mainForm.TBox_CrossRoadID.Text.ToString
                'Dim BusLineID As String = Current_BusLineID
                Dim BusLineID As String = AcceptA2.Route.ToString
                Dim Running_BusID As String = AcceptA2.BusID.ToString
                Dim Running_Bus_Goback As String = AcceptA2.GoBack.ToString

                Dim onethree As Boolean = False

                _mainForm.Show_LBox_PolicyRightNowText("BusLineID " + BusLineID)
                _mainForm.Show_LBox_PolicyRightNowText("BusID " + Running_BusID)
                _mainForm.Show_LBox_PolicyRightNowText("Bus_Goback " + Running_Bus_Goback)



                Dim Year As String = DateTime.Today.ToString("yyyy")
                Dim Month As String = DateTime.Today.ToString("MM")
                Dim Day As String = DateTime.Today.ToString("dd")
                Dim Hour As String = DateTime.Now.ToString("HH")
                Dim Min As String = DateTime.Now.ToString("mm")
                Dim Sec As String = DateTime.Now.ToString("ss")

                '_mainForm.Show_LBox_PolicyRightNowText(" Year " + Year + " Month " + Month + " Day " + Day + " Hour " + Hour + " Min " + Min + " Sec " + Sec)

                Command2("5F4C")
                Thread.Sleep(1000)

                _mainForm.Show_LBox_PolicyRightNowText("現在分相 " + Data_5FCC.Current_SubPhaseID.ToString + " 現在步階 " + Data_5FCC.Current_StepID + " 剩餘秒數 " + HexStringTOIntString(Data_5FCC.Current_RemainingTime, 4).ToString)

                Try
                    FiveFB4.Add("Currentphase", Data_5FCC.Current_SubPhaseID.ToString + Data_5FCC.Current_StepID + Data_5FCC.Current_RemainingTime)
                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Currentphase " + ex.Message)
                End Try


                '_mainForm.Show_LBox_PolicyRightNowText("Signal Map " + Data_5F03.SignalMap)

                '公車第幾分相 bug 如果第一步階 不是可過綠燈則不會認定是可過分相
                '須從每分相裏頭的每步階的燈態下去判斷
                If NEAR_BusStop = "1" Then
                    Try
                        'Phase_Commands.Add("01", "5F1C") 'Each Phase should put its commands inside the hashtable and exceute the results elsewhere Except the commands that need to be excuted imediatlly 
                        '_mainForm.Show_LBox_PolicyRightNowText(BusPhaseOrNot(BusLineID, CrossRoadID, Running_Bus_Goback)) '301 0001 1  -> 0001_0001_00 the data is wrong convert it
                        _mainForm.Show_LBox_PolicyRightNowText("BusStop Distance  String " + BusStopDist_Tab(CrossRoadID + "_" + Running_Bus_Goback).ToString)
                        Dim BusStopDistInt As Integer = Val(BusStopDist_Tab(CrossRoadID + "_" + Running_Bus_Goback).ToString)


                        If BusStopDistInt > 0 Then

                            If BusStopDistInt < 60 Then
                                _mainForm.Show_LBox_PolicyRightNowText("上游站牌距離路口小於60公尺屬近端設站")
                                isBusStopNear = True

                                Dim BusStopDelay_Int As Integer = Val(BusStopDelay_Tab("BusStopDelay_" + Running_Bus_Goback))
                                Dim Bus2Cross_Int As Integer = Val(BusStopDelay_Tab("BusStop2Cross_" + Running_Bus_Goback))

                                Total_BusDelay = BusStopDelay_Int + Bus2Cross_Int
                                '_mainForm.Show_LBox_PolicyRightNowText("Total_BusDelay =" + Total_BusDelay.ToString)
                            Else
                                _mainForm.Show_LBox_PolicyRightNowText("上游站牌距離路口大於60公尺不屬近端設站")
                                isBusStopNear = False

                            End If


                        Else
                            _mainForm.Show_LBox_PolicyRightNowText("此路口無上游站牌 ")
                            isBusStopNear = False
                        End If


                    Catch ex As Exception

                        _mainForm.Show_LBox_PolicyRightNowText(" Test Area Error " + ex.StackTrace)
                    End Try
                End If


                'Try
                '    'BusLineList key -> buslineID_CrossRoadID

                '    '_mainForm.Show_LBox_PolicyRightNowText("BusLine Route  " + Current_BusLineID.ToString() + "  Bus Line Data " + BusLineList("0001_0002").ToString + " CrossRoadID " + _mainForm.TBox_CrossRoadID.Text)
                '    'Dim BusLineData As String = BusLineList("0001_0002")
                '    'Dim BusLineData As String() = BusLineList().Split(",")

                '    _mainForm.Show_LBox_PolicyRightNowText("NowPhase =" + Data_5FCC.Current_SubPhaseID)

                '    'If (BusPhaseOrNot(BusLineID, CrossRoadID, Running_Bus_Goback)) Then
                '    '    _mainForm.Show_LBox_PolicyRightNowText("PASSSSSSSSSSSSSSSSSSSSSSSSSSSSS")
                '    'Else
                '    '    _mainForm.Show_LBox_PolicyRightNowText("NOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO")
                '    'End If

                '    Dim BusLineData As String() = BusLineList("0001_0001_00").Split(",")   ' BusLineList key = "BusLineID_CrossRoadID_GoBack"  

                '    _mainForm.Show_LBox_PolicyRightNowText(" BuslineData PassPhase " + BusLineData(4))

                '    Dim BusPassPhases As BitArray = New BitArray(8)
                '    Dim a() As Byte = {BusLineData(4)}
                '    BusPassPhases = New BitArray(a)




                'Catch ex As Exception
                '    _mainForm.Show_LBox_PolicyRightNowText("Bus Line Data error " + ex.StackTrace.ToString)

                'End Try



                'TRY USING 5F03 INSTEAD OF 5F13 
                Try
                    'If Data_5F18 Is Nothing Then
                    '    TotalPhase = Data_5F13.SubPhaseCount.ToString
                    'ElseIf Data_5F13 Is Nothing Then
                    '    TotalPhase = Data_5F18.SubPhaseCount.ToString
                    'End If

                    TotalPhase = Data_5F13.SubPhaseCount.ToString

                Catch ex As Exception

                    _mainForm.Show_LBox_PolicyRightNowText("Error Can't get the total phase " + ex.StackTrace)
                End Try
                'TotalPhase = Data_5F18.SubPhaseCount.ToString
                'TotalPhase = Data_5F13.SubPhaseCount.ToString
                TotalPhaseInt = Convert.ToDecimal(TotalPhase)  'Total Subphases at this intercection 

                Dim LightArray(0 To TotalPhaseInt) As String
                Dim Massgg(0 To TotalPhaseInt) As Integer
                Dim Massggstr(0 To TotalPhaseInt) As String
                Dim Microgg(0 To TotalPhaseInt) As Integer
                Dim Microggstr(0 To TotalPhaseInt) As String
                Dim Yellowrr(0 To TotalPhaseInt) As Integer
                Dim Greenint(0 To TotalPhaseInt) As Integer
                Dim Longer(0 To TotalPhaseInt) As Integer
                Dim Shorter(0 To TotalPhaseInt) As Integer
                Dim PedFlash(0 To TotalPhaseInt) As Integer

                Dim BusPassPhase As String = ""


                Dim RemanSecBusCrossRoad As Integer

                Dim Pplay1 As String = ""
                Dim Pplay2 As String = ""


                For index As Integer = 0 To TotalPhaseInt - 1

                    'Try
                    '    '_mainForm.Show_LBox_PolicyRightNowText(" rTouchPoint.Direct " + rTouchPoint.Direct.ToString + " Data_5F13.SignalStatus(index) " + Data_5F13.SignalStatus(index) + "  Data_5F13.SignalMap " + Data_5F13.SignalMap)

                    '    If isPass(rTouchPoint.Direct, Data_5F13.SignalStatus(index), Data_5F13.SignalMap) Then
                    '        _mainForm.Show_LBox_PolicyRightNowText("這分相我能過 " + index.ToString)
                    '        BusPassPhase = All_Phases(index)

                    '    End If
                    '    '_mainForm.Show_LBox_PolicyRightNowText("Index " + HexNum(index) + "Data_5F13.SignalStatus(index)" + Data_5F13.SignalStatus(index))
                    'Catch ex As Exception
                    '    _mainForm.Show_LBox_PolicyRightNowText(" 無法判斷公車能通過的分相 " + ex.StackTrace.ToString)

                    'End Try


                    LightArray(index) = Data_5F14.LightStatus(index)
                    '_mainForm.Show_LBox_PolicyRightNowText(" Light " + LightArray(index))
                    '_mainForm.Show_LBox_PolicyRightNowText("Signal Status " + Data_5F13.SignalStatus(index))

                    Try
                        Yellowrr(index) = YellowplusRed(Data_5F14.LightStatus(index)) 'yellow plus red  
                        PedFlash(index) = PedGreenFlashRed(Data_5F14.LightStatus(index))
                        Microgg(index) = MinGreen(Data_5F14.LightStatus(index)) - PedFlash(index)
                        Microggstr(index) = IntToHexString(Microgg(index), 2)
                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("取不到最小綠 使用預設 10 秒")
                        Microgg(index) = 10
                        Microggstr(index) = "0A"
                        Yellowrr(index) = 5
                    End Try


                    Try
                        Greenint(index) = CurrentGreen(Data_5F15.Green(index))

                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("取不到正常綠 無法跑策略")
                    End Try


                    'Massgg(index) = MaxGreen(Data_5F14.LightStatus(index))
                    _mainForm.Show_LBox_PolicyRightNowText(" 分相 " + index.ToString + "  綠燈 " + Greenint(index).ToString + " 最小綠 " + Microgg(index).ToString + " 行閃行紅 " + PedFlash(index).ToString + " 黃燈+全紅 " + Yellowrr(index).ToString)
                    Pplay1 = Pplay1 + Greenint(index).ToString + "," + Yellowrr(index).ToString + ";"

                Next




                FiveFB4.Add("Play1", Pplay1)

                For index As Integer = 0 To TotalPhaseInt - 1
                    Dim TempMicro As Integer

                    Try
                        If index < (TotalPhaseInt - 1) Then
                            TempMicro = Microgg(index + 1)
                        Else
                            TempMicro = Microgg(0)
                        End If

                        Massgg(index) = Greenint(index) + TempMicro + 10
                        Massggstr(index) = IntToHexString(Massgg(index), 2)

                        _mainForm.Show_LBox_PolicyRightNowText(index.ToString + " 最大綠 " + Massgg(index).ToString)
                        '_mainForm.Show_LBox_PolicyRightNowText(index.ToString + " 最大綠 " + Massgg(index).ToString + "Hex " + Massggstr(index).ToString)
                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("無法計算最大綠" + ex.Message)
                    End Try

                Next


                Try
                    For index As Integer = 0 To TotalPhaseInt - 1
                        Shorter(index) = Greenint(index) - Microgg(index)
                        Longer(index) = Massgg(index) - Greenint(index)
                        '_mainForm.Show_LBox_PolicyRightNowText(index.ToString + " Longer " + Longer(index).ToString)
                        '_mainForm.Show_LBox_PolicyRightNowText(index.ToString + " Shorter " + Shorter(index).ToString)
                    Next
                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Error on extention" + ex.StackTrace)
                End Try


                'Dim Point1 As String = "25.072813,121.576059"  
                'Dim Point2 As String = "25.073241,121.577815"
                'Dim Point3 As String = "25.073532,121.578643"

                '_mainForm.Show_LBox_PolicyRightNowText("MOS > Hilife  Distance: " + distance(Point1, Point2).ToString)
                '_mainForm.Show_LBox_PolicyRightNowText(" Hilife > Parking  Distance: " + distance(Point2, Point3).ToString)


                'Dim NowPhaseID As String = "0" + BusPriority_IPC.MainForm.TBox_SubPhaseOrder.Text   'minus 1 twaut 
                'Dim NowPhaseID As String = NowSubPhaseIDstring

                'Dim NowStepID As String = NowStepIDstring
                'Dim NowPlanID As String = Data_5F18.PlanID
                'Dim NowGreen As String = Data_5F18.Green
                'HexStringTOIntString(Data_5F03.StepSec, 4)
                'Dim Light As String = Data_5F14.LightStatus(NowSubPhaseIDstring - 1)
                'Dim Max As String = MaxGreen(Light)
                'Dim Min As String = MinGreen(Light)
                'Min = HexStringTOIntString(Min, 2)
                'Max = HexStringTOIntString(Max, 2)

                'TBox_StepOrder
                'TBox_SubPhaseOrder

                'Dim StrNextMaxGreenSecond As String = Data_5F14.LightStatus(NowPhaseID)
                'Dim IntNextMaxGreenSecnod As Integer = Val(HexStringTOIntString(StrNextMaxGreenSecond.Substring(2, 4), 4))
                'Dim iRG_i_2 As Integer = IntNextMaxGreenSecnod
                'Dim NowPhaseID As Integer = Val(Data_5F03.SubPhaseID)
                'Dim tmpString As String = Data_5F14.LightStatus(0)
                '_mainForm.Show_LBox_PolicyRightNowText("Lights " + Data_5F14.PlanID)

                'Dim maxGreenSec As Integer = Val(HexStringTOIntString(tmpString.Substring(2, 4), 4))

                Dim CurrentPhaseInt As Integer = Convert.ToDecimal(Data_5FCC.Current_SubPhaseID)
                Dim CurrentStepInt As Integer = Convert.ToDecimal(Data_5FCC.Current_StepID)
                Dim CurrentRemainingTime As Integer = Data_5FCC.Current_RemainingInt


                Dim RG_Status As String
                RemanSecBusCrossRoad = SecondOfCar2CrossRoad(Data_A1.X + "," + Data_A1.Y, rTouchPoint.StopLineLatLon, Data_A1.Speed)
                Try
                    FiveFB4.Add("Bus2CrossRoad", RemanSecBusCrossRoad.ToString)
                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Bus2CrossRoad " + ex.Message)
                End Try




                If BusPhaseOrNot(BusLineID, CrossRoadID, Running_Bus_Goback) Then      'If isBusSameDirection(rTouchPoint.Direct) Then
                    _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">目前公車方向燈號為綠燈[1]")
                    RemanSecBusCrossRoad = SecondOfCar2CrossRoad(Data_A1.X + "," + Data_A1.Y, rTouchPoint.StopLineLatLon, Data_A1.Speed)
                    RG_Status = "G"



                    'Dim Cal_RG_i As Integer = RG_i(rTouchPoint.Direct) '公車時相剩餘綠燈
                    Dim Cal_RG_i As Integer = RemainingLightTime(True)
                    'Dim Remain2 As Integer = RemainingLightTime2(True)
                    _mainForm.Show_LBox_PolicyRightNowText("Remaining Green Time " + Cal_RG_i.ToString)
                    '_mainForm.Show_LBox_PolicyRightNowText("Remaining Green Time2 " + Remain2.ToString)
                    If RemanSecBusCrossRoad < Cal_RG_i Then 'OK
                        '公車到路口剩餘秒數小於公車時相剩餘綠燈-->維持原時制
                        _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小於 公車時相剩餘綠燈 " + Cal_RG_i.ToString + " -->維持原時制[1-1]")
                        _mainForm.Show_BusPolicyText("維持原時制")

                        Try
                            FiveFB4.Add("Strategy", "11")
                            FiveFB4.Add("Play2", "NoChange")
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 11 " + ex.Message)
                        End Try

                    Else

                        '_mainForm.Show_LBox_PolicyRightNowText(" 此分相最大綠 " + Massgg(CurrentPhaseInt - 1).ToString + " 此分相正常綠燈 " + Greenint(CurrentPhaseInt - 1).ToString + " 剩餘綠燈 " + Cal_RG_i.ToString)

                        If Data_5FCC.Current_StepID = "01" And Data_5FCC.Current_RemainingInt > 4 Then
                            _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於 公車時相剩餘綠燈 " + Cal_RG_i.ToString + " -->公車時相延長至最大綠[1-2]")
                            Command("5F1C" + Data_5FCC.Current_SubPhaseID + "01" + Massggstr(CurrentPhaseInt - 1))
                            _mainForm.Show_LBox_PolicyRightNowText(" 延長 " + CurrentPhaseInt.ToString + "分相 " + Longer(CurrentPhaseInt - 1).ToString + " 秒")
                            Pplay2 = CurrentPhaseInt.ToString + "," + Longer(CurrentPhaseInt - 1).ToString + ";"


                            Try
                                Rec_CycleID = CycleID
                                FiveFB4.Add("Strategy", "12")
                                FiveFB4.Add("Play2", Pplay2)
                            Catch ex As Exception
                                _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 12 " + ex.Message)
                            End Try

                        Else
                            _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 非第一步階無法延長綠燈 " + Cal_RG_i.ToString + " -->公車競爭分相縮短至最短綠[1-3]")

                            Try
                                Rec_CycleID = CycleID
                                FiveFB4.Add("Strategy", "13")
                            Catch ex As Exception
                                _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 13 " + ex.Message)
                            End Try

                            'If Data_5FCC.Current_StepID = "01" Then

                            '    Command("5F1C" + Data_5FCC.Current_SubPhaseID + "01" + IntToHexString(Microgg(CurrentPhaseInt - 1), 2))
                            'Else
                            '    _mainForm.Show_LBox_PolicyRightNowText("非第一步接不能縮此分相")
                            'End If


                            onethree = True

                            For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                                If BusPassPhases(index - 1) = False Then
                                    _mainForm.Show_LBox_PolicyRightNowText("Save Command " + "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                    Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                    _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + index.ToString + "分相 " + Shorter(index - 1).ToString + " 秒")
                                    Pplay2 = Pplay2 + index.ToString + ",-" + Shorter(index - 1).ToString + ";"
                                Else
                                    Exit For
                                End If

                            Next index

                            For index As Integer = 1 To CurrentPhaseInt - 1
                                If BusPassPhases(index - 1) = False Then
                                    _mainForm.Show_LBox_PolicyRightNowText("Save Command " + "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                    Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                    _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + index.ToString + "分相 " + Shorter(index - 1).ToString + " 秒")
                                    Pplay2 = Pplay2 + index.ToString + ",-" + Shorter(index - 1).ToString + ";"
                                Else
                                    Exit For
                                End If

                            Next index

                            Try
                                FiveFB4.Add("Play2", Pplay2)
                            Catch ex As Exception
                                _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy Play2 " + ex.Message)
                            End Try

                            'For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                            '    If BusPassPhases(index - 1) = False Then
                            '        Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                            '        If CurrentPhaseInt <> 1 Then
                            '            For index2 As Integer = 1 To CurrentPhaseInt - 1

                            '                If BusPassPhases(index2 - 1) = False Then
                            '                    Phase_Commands.Add(IntToHexString(index2, 2), "5F1C" + IntToHexString(index2, 2) + "01" + IntToHexString(Microgg(index2 - 1), 2))
                            '                End If


                            '            Next

                            '        End If


                            '    End If

                            'Next

                        End If
                        'Dim Cal_G_j As Integer = G_j(rTouchPoint.Direct)
                        'If RemanSecBusCrossRoad > (Cal_RG_i + Cal_G_j) Then
                        '    '公車到路口剩餘秒數大於公車時相剩餘綠燈加衝突時相所有步階秒數-->維持原時制  This is clearly Bougos
                        '    '_mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於 公車時相剩餘綠燈(" + Cal_RG_i.ToString + ")加衝突時相所有步階秒數(" + Cal_G_j.ToString + ")-->維持原時制[1-2]")
                        '    '_mainForm.Show_BusPolicyText("維持原時制")
                        'Else
                        '    Dim Cal_RG_iMax As Integer = RG_i_max(rTouchPoint.Direct)
                        '    If RemanSecBusCrossRoad <= Cal_RG_iMax Then
                        '        '公車到路口剩餘秒數小(等)於公車時相最大綠剩餘綠燈-->將綠燈延長至RemanSecBusCrossRoad
                        '        Dim stepsec As Integer = _mainForm.TBox_StepSec.Text
                        '        Dim passed As Integer = stepsec - Cal_RG_i
                        '        Dim RemainHex = IntToHexString(RemanSecBusCrossRoad + passed, 2)
                        '        ' NowPhase = Data_5FCC.Current_SubPhaseID  NowStep =  Data_5FCC.Current_StepID   RemaingTime = Data_5FCC.Current_RemainingInt)

                        '        _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小(等)於公車時相最大綠剩餘綠燈(" + Cal_RG_iMax.ToString + ")-->將綠燈秒數延長至(" + RemanSecBusCrossRoad.ToString + ")[1-3]")
                        '        _mainForm.Show_BusPolicyText("將公車時相綠燈延長至(" + RemanSecBusCrossRoad.ToString + ")")
                        '        '_mainForm.Show_LBox_PolicyRightNowText("步階時間 " + stepsec.ToString + " 已經過時間 " + passed.ToString + " 該下時間 " + (RemanSecBusCrossRoad + passed).ToString)

                        '        Dim index As Integer = Val(Data_5FCC.Current_SubPhaseID) - 1
                        '        _mainForm.Show_LBox_PolicyRightNowText(" Original Green  " + Greenint(index).ToString)

                        '        Command("5F1C" + NowSubPhaseIDstring + "00" + RemainHex)
                        '        _mainForm.Show_LBox_PolicyRightNowText(" Modified Green  " + (RemanSecBusCrossRoad + passed).ToString)

                        '        'Cal_RG_i = RemanSecBusCrossRoad + passed
                        '    Else
                        '        Dim Cal_G_jMin As Integer = G_j_min(rTouchPoint.Direct)
                        '        If RemanSecBusCrossRoad <= (Cal_RG_i + Cal_G_jMin) Then
                        '            '公車到路口剩餘秒數小(等)於公車時相剩餘綠燈加衝突時相所有步階(最小綠)秒數-->將衝突時相綠燈改為最小綠

                        '            _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小(等)於公車時相剩餘綠燈(" + Cal_RG_i.ToString + ")加衝突時相所有步階(最小綠)秒數(" + Cal_G_jMin.ToString + ")-->將衝突時相綠燈改為最小綠[1-4]")
                        '            _mainForm.Show_BusPolicyText("將衝突相綠燈改為最小綠")

                        '            For index As Integer = 0 To TotalPhaseInt - 1    'Except the phase of the bus
                        '                If All_Phases(index) <> BusPassPhase Then
                        '                    Command("5F1C" + All_Phases(index) + "00" + Microggstr(index))
                        '                    _mainForm.Show_LBox_PolicyRightNowText("將分相 " + All_Phases(index) + " 步階 " + "01" + " 縮短至最小綠 " + HexStringTOIntString(Microggstr(index), 2))
                        '                End If
                        '            Next
                        '        Else
                        '            '公車到路口剩餘秒數大於公車時相剩餘綠燈加衝突時相所有步階(最小綠)秒數-->將衝突時相綠燈改為RemanSecBusCrossRoad減G_j,平均分配

                        '            _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於公車時相剩餘綠燈(" + Cal_RG_i.ToString + ")加衝突時相所有步階(最小綠)秒數(" + Cal_G_jMin.ToString + ")-->將衝突時相綠燈改為到路口秒數(" + RemanSecBusCrossRoad.ToString + ")減綠燈剩餘秒數(" + Cal_RG_i.ToString + "),平均分配[1-5]")
                        '            _mainForm.Show_BusPolicyText("將衝突相綠燈改為到路口剩餘數減去衝突相步階秒數")
                        '            Try
                        '                Dim Split As Integer = (RemanSecBusCrossRoad - Cal_RG_i) / (Val(TotalPhase) - 1)
                        '                Dim SplitHex As String = IntToHexString(Split, 2)
                        '                For index As Integer = 0 To TotalPhaseInt - 1    'Except the phase of the bus
                        '                    If All_Phases(index) <> BusPassPhase Then

                        '                        Command("5F1C" + All_Phases(index) + "00" + SplitHex)
                        '                        _mainForm.Show_LBox_PolicyRightNowText("將分相 " + All_Phases(index) + " 步階 " + "01" + " 縮短至 " + SplitHex)

                        '                    End If
                        '                Next
                        '            Catch ex As Exception
                        '                _mainForm.Show_LBox_PolicyRightNowText("Error on 1-5")
                        '            End Try

                        '        End If
                        '    End If
                        'End If
                    End If
                Else
                    _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">目前公車方向燈號為紅燈[2]")
                    RemanSecBusCrossRoad = SecondOfCar2CrossRoad(Data_A1.X + "," + Data_A1.Y, rTouchPoint.StopLineLatLon, Data_A1.Speed)
                    'Dim Cal_RG_j As Integer = RG_j(rTouchPoint.Direct) '剩餘紅燈
                    Dim Cal_RG_j As Integer = RemainingLightTime(False)
                    'Dim Remain2 As Integer = RemainingLightTime2(False)
                    RG_Status = "R"
                    _mainForm.Show_LBox_PolicyRightNowText("Remaining Red Time " + Cal_RG_j.ToString)
                    '_mainForm.Show_LBox_PolicyRightNowText("Remaining Red Time2 " + Remain2.ToString)

                    If RemanSecBusCrossRoad > Cal_RG_j Then
                        '公車到路口剩餘秒數大於公車衝突時相剩餘所有步階秒數-->維持原時制
                        _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於公車衝突時相剩餘紅燈(" + Cal_RG_j.ToString + ")-->維持原時制[2-1]")



                        Try
                            FiveFB4.Add("Strategy", "21")
                            FiveFB4.Add("Play2", "NoChange")
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 21 " + ex.Message)
                        End Try

                    Else

                        _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小於公車衝突時相剩餘紅燈(" + Cal_RG_j.ToString + ")-->縮短衝突時相[2-2]")


                        Try
                            Rec_CycleID = CycleID
                            FiveFB4.Add("Strategy", "22")
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 22 " + ex.Message)
                        End Try

                        If Data_5FCC.Current_StepID = "01" And Data_5FCC.Current_RemainingInt > 4 Then

                            Command("5F1C" + Data_5FCC.Current_SubPhaseID + "01" + Microggstr(CurrentPhaseInt - 1))
                            _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + CurrentPhaseInt.ToString + "分相 " + Shorter(CurrentPhaseInt - 1).ToString + " 秒")
                            Pplay2 = Pplay2 + CurrentPhaseInt.ToString + ",-" + Shorter(CurrentPhaseInt - 1).ToString + ";"
                        Else
                            _mainForm.Show_LBox_PolicyRightNowText("非第一步階，不能縮短此分相 " + Data_5FCC.Current_SubPhaseID.ToString)

                        End If

                        For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                            If BusPassPhases(index - 1) = False Then
                                _mainForm.Show_LBox_PolicyRightNowText("Save Command " + "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + index.ToString + "分相 " + Shorter(index - 1).ToString + " 秒")
                                Pplay2 = Pplay2 + index.ToString + ",-" + Shorter(index - 1).ToString + ";"
                            Else
                                Exit For
                            End If

                        Next index

                        For index As Integer = 1 To CurrentPhaseInt - 1
                            If BusPassPhases(index - 1) = False Then
                                _mainForm.Show_LBox_PolicyRightNowText("Save Command " + "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                                _mainForm.Show_LBox_PolicyRightNowText(" 縮短 " + index.ToString + "分相 " + Shorter(index - 1).ToString + " 秒")
                                Pplay2 = Pplay2 + index.ToString + ",-" + Shorter(index - 1).ToString + ";"
                            Else
                                Exit For
                            End If

                        Next index

                        Try

                            FiveFB4.Add("Play2", Pplay2)
                        Catch ex As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy Play2 2-2" + ex.Message)
                        End Try

                        'For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                        '    If BusPassPhases(index - 1) = False Then
                        '        Phase_Commands.Add(IntToHexString(index, 2), "5F1C" + IntToHexString(index, 2) + "01" + IntToHexString(Microgg(index - 1), 2))
                        '        If CurrentPhaseInt <> 1 Then
                        '            For index2 As Integer = 1 To CurrentPhaseInt - 1

                        '                If BusPassPhases(index2 - 1) = False Then
                        '                    Phase_Commands.Add(IntToHexString(index2, 2), "5F1C" + IntToHexString(index2, 2) + "01" + IntToHexString(Microgg(index2 - 1), 2))
                        '                End If


                        '            Next

                        '        End If


                        '    End If

                        'Next

                        'Dim Cal_RG_jMin As Integer = RG_j_min(rTouchPoint.Direct)
                        'If RemanSecBusCrossRoad > Cal_RG_jMin Then
                        '    '公車到路口剩餘秒數大於公車衝突時相剩餘所有步階(最小綠)秒數-->將衝突時相綠燈改為RemanSecBusCrossRoad平均分配

                        '    _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 大於公車衝突時相剩餘所有步階(最小綠)秒數(" + Cal_RG_jMin.ToString + ")-->將衝突時相綠燈改為(" + RemanSecBusCrossRoad.ToString + ")平均分配[2-2]")
                        '    _mainForm.Show_BusPolicyText("將衝突時相綠燈改為到路口剩餘秒數")

                        '    Try
                        '        Dim Split As Integer = (RemanSecBusCrossRoad - Cal_RG_j) / (Val(TotalPhase) - 1)
                        '        Dim SplitHex As String = IntToHexString(Split, 2)
                        '        For index As Integer = 0 To TotalPhaseInt - 1    'Except the phase of the bus
                        '            If All_Phases(index) <> BusPassPhase Then

                        '                Command("5F1C" + All_Phases(index) + "00" + SplitHex)
                        '                _mainForm.Show_LBox_PolicyRightNowText("將分相 " + All_Phases(index) + " 步階 " + "00" + " 縮短至 " + SplitHex)
                        '            End If
                        '        Next
                        '    Catch ex As Exception
                        '        _mainForm.Show_LBox_PolicyRightNowText("Error on 2-2")
                        '    End Try
                        'Else
                        '    Dim Cal_RG_i As Integer = RG_i(rTouchPoint.Direct)
                        '    '公車到路口剩餘秒數小(等)於公車衝突時相剩餘所有步階(最小綠)秒數-->將衝突時剩餘相綠燈改為最小綠

                        '    _mainForm.Show_LBox_PolicyRightNowText("<" + Data_A2.BusID + ">公車到路口剩餘秒數(" + RemanSecBusCrossRoad.ToString + ") 小(等)於公車衝突時相剩餘所有步階(最小綠)秒數(" + Cal_RG_jMin.ToString + ")-->將衝突時剩餘相綠燈改為最小綠[2-3]")
                        '    _mainForm.Show_BusPolicyText("將衝突相綠燈改為剩餘最小綠")

                        '    'Dim TotalPhase As String = Data_5F13.SubPhaseCount
                        '    'Dim TotalPhaseInt As Integer = Convert.ToDecimal(TotalPhase)  'Total Subphases at this intercection 
                        '    For index As Integer = 0 To TotalPhaseInt - 1    'Except the phase of the bus
                        '        If All_Phases(index) <> BusPassPhase Then
                        '            Command("5F1C" + All_Phases(index) + "00" + Microggstr(index))
                        '            _mainForm.Show_LBox_PolicyRightNowText("將分相 " + All_Phases(index) + " 步階 " + "01" + " 縮短至最小綠 " + HexStringTOIntString(Microggstr(index), 2))
                        '        End If
                        '        '_mainForm.Show_LBox_PolicyRightNowText("Hi " + HexNum(index))

                        '    Next
                        'End If
                    End If

                End If

                Try


                    'Command("5F4C")
                    'Thread.Sleep(3000)





                    '_mainForm.Show_LBox_PolicyRightNowText(" GroupID" + COMMON_GroupID.ToString + " BusID " + Data_A2.BusID.ToString + " Direct " + rTouchPoint.Direct.ToString + " BusPhaseID " + BusPassPhase.ToString + "Bus ETA  " + RemanSecBusCrossRoad.ToString + " BusWayLightStatus " + RG_Status + " BusWayRemainLight " + "N/A" + " Modify PhaseID" + "N/A" + " OriginalGreenTime " + " N/A " + " Modified Green " + " N/A " + " DateTime " + " N/A ")

                    'Data_A2.BusID   COMMON_GroupID  rTouchPoint.Direct CrossRoadID  BusPassPhase  RemanSecBusCrossRoad.ToString  RG_Stauts  Data_5FCC.Current_RemainingInt
                    'StrategyLog(GroupID, CrossRoadID, Direct , BusID , BusPhaseID ,BusETA , BusWayLightStatus , BusWayRemainLight, ModifyPhaseID , OriginalGreenTime , ModifiedGreenTime , TimeDate )

                    'StrategyLog(COMMON_GroupID, )



                    Dim Cal_RG_i As Integer
                    Dim Cal_RG_j As Integer
                    If RG_Status = "G" Then
                        Cal_RG_i = RemainingLightTime(True)
                        SentTime = Cal_RG_i

                        SentLight = "G"

                        'If onethree = True Then
                        '    Cal_RG_i = Cal_RG_i + Greenint(CurrentPhaseInt) + 5
                        '    RG_Status = "R"
                        'End If


                    Else
                        Cal_RG_j = RemainingLightTime(False)
                        SentTime = Cal_RG_j
                        SentLight = "R"
                    End If
                    SendLightRemainSec(Data_A2.BusID, SentLight, SentTime)




                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("Send Time Error")
                End Try

            Else

                If PayBack_Status = True Then
                    _mainForm.Show_LBox_PolicyRightNowText("進行補償 不執行公車優先 ")
                    Try
                        FiveFB4.Add("Strategy", "88")
                        FiveFB4.Add("Play2", "NoChange")
                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy 88 " + ex.Message)
                    End Try

                ElseIf _mainForm.Label_BusPrimEnable.Text <> "啟動" Then
                    _mainForm.Show_LBox_PolicyRightNowText(" 公車優先關閉 不執行公車優先 ")
                    Try
                        FiveFB4.Add("Strategy", "E9")
                        FiveFB4.Add("Play2", "NoChange")
                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("Error FiveFB4 Strategy E9 " + ex.Message)
                    End Try

                End If


            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            _mainForm.Show_LBox_PolicyRightNowText(trace.ToString)
            WriteLog(curPath, "Module_Policy_1", "AcceptA2_Procedure_2 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try

    End Sub
    
End Module
