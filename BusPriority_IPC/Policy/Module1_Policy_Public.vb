Module Module1_Policy_Public
    '************************************************************************************************
    '**
    '** 策略函數
    '**
    '************************************************************************************************
    'A(i):計算到路口秒數
    Public Function SecondOfCar2CrossRoad(ByVal CarPostion As String, ByVal CrossRoadPostion As String, ByVal CarSpeed As Integer) As Integer
        Dim iSecReport As Integer = 0
        Try
            Dim StartPostion As String() = CarPostion.Split(",")
            Dim EndPostion As String() = CrossRoadPostion.Split(",")
            Dim EarthRadius As Integer = 6371
            Dim factor As Double = Math.PI / 180
            Dim dLat As Double = (Val(StartPostion(0)) - Val(EndPostion(0))) * factor
            Dim dLon As Double = (Val(StartPostion(1)) - Val(EndPostion(1))) * factor

            Dim dis_a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(Val(StartPostion(0)) * factor) * Math.Cos(Val(EndPostion(0)) * factor) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
            Dim dis_b As Double = 2 * Math.Atan2(Math.Sqrt(dis_a), Math.Sqrt(1 - dis_a))
            Dim dis_c As Double = EarthRadius * dis_b * 1000


            Dim SedondOfSpeedMeter As Double = (CarSpeed * 1000) / 3600
            iSecReport = dis_c / SedondOfSpeedMeter

            If isBusStopNear = True Then

                _mainForm.Show_LBox_PolicyRightNowText("原到路口時間 " + iSecReport.ToString)

                iSecReport = iSecReport + Total_BusDelay
                _mainForm.Show_LBox_PolicyRightNowText("近端設站調整時間 " + iSecReport.ToString)

            End If




        Catch ex As Exception
            iSecReport = 0
        End Try
        Return iSecReport
    End Function

    Public Function distance(ByVal CarPostion As String, ByVal CrossRoadPostion As String) As Integer
        Dim iSecReport As Integer = 0
        Try
            Dim StartPostion As String() = CarPostion.Split(",")
            Dim EndPostion As String() = CrossRoadPostion.Split(",")
            Dim EarthRadius As Integer = 6371
            Dim factor As Double = Math.PI / 180
            Dim dLat As Double = (Val(StartPostion(0)) - Val(EndPostion(0))) * factor
            Dim dLon As Double = (Val(StartPostion(1)) - Val(EndPostion(1))) * factor

            Dim dis_a As Double = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(Val(StartPostion(0)) * factor) * Math.Cos(Val(EndPostion(0)) * factor) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2)
            Dim dis_b As Double = 2 * Math.Atan2(Math.Sqrt(dis_a), Math.Sqrt(1 - dis_a))
            Dim dis_c As Double = EarthRadius * dis_b * 1000

            iSecReport = dis_c


        Catch ex As Exception
            iSecReport = 0
        End Try
        Return iSecReport
    End Function
    '是否為公車時相
    '依順編方向1北,2東北,3東,4東南,5南,6西南,7西,8西北
    Public Function isBusSameDirection(ByVal TriggerPhaseDirect As String) As Boolean
        Dim isSame As Boolean = False
        Try
            If Not IsNothing(Data_5F03) Then
                Return isPass(Val(TriggerPhaseDirect) - 1, Data_5F03.SignalStatus, Data_5F03.SignalMap)
            End If
        Catch ex As Exception
        End Try
        Return isSame
    End Function
    Public Function isPass(ByVal intIndex As Integer, ByVal strStatus As String, ByVal strSingalMap As String) As Boolean
        Try
            'Jason 2014-9-24
            'S-------------------------------------------------------------
            Dim SingalOrder As Integer = 0
            Dim SingalByte As Byte() = StrToByteArray2(strSingalMap)
            Dim SingalBinary As String = Convert.ToString(SingalByte(0), 2).PadLeft(8, "0")
            For i As Integer = 0 To intIndex - 1
                If SingalBinary.Substring(SingalBinary.Length - i - 1, 1) = "1" Then
                    SingalOrder += 1
                End If
            Next i

            'E-------------------------------------------------------------
            Dim tmpByte As Byte() = StrToByteArray2(strStatus)
            If (SingalOrder - 1) > tmpByte.Length - 1 Then
                Return False
            End If
            If (tmpByte(SingalOrder - 1) And &H1) = &H1 Then
                Return False
            End If
            tmpByte(SingalOrder - 1) = tmpByte(SingalOrder - 1) And &H3C
            If tmpByte(SingalOrder - 1) <> &H0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module1_Policy_Public", "isPass Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
        Return False
    End Function

    '目前公車為綠燈
    'RG(i):計算目前綠燈剩餘秒數.
    '要把早開和遲閉的綠燈分相算進去.
    Public Function RG_i(ByVal TriggerPhaseDirect As String) As Integer
        Dim iRG_i_1 As Integer = 0
        Dim iRG_i_2 As Integer = 0
        Dim NowPhaseID As Integer = Val(Data_5F03.SubPhaseID)
        Dim Now5F03Update As DateTime = Data_5F03.UpdateTime
        Try

            If Not IsNothing(Data_5F03) And Not IsNothing(Data_5F13) And Not IsNothing(Data_5F15) Then


                If isPass(Val(TriggerPhaseDirect) - 1, Data_5F13.SignalStatus(NowPhaseID - 1), Data_5F13.SignalMap) Then
                    '_mainForm.Show_LBox_PolicyRightNowText("TriggerPhaseDirect.ToString " + TriggerPhaseDirect.ToString + " Data_5F13.SignalStatus(NowPhaseID - 1) " + Data_5F13.SignalStatus(NowPhaseID - 1).ToString + " Data_5F13.SignalMap " + Data_5F13.SignalMap.ToString)
                    Dim GreenLihgRunYet As Integer = DateDiff(DateInterval.Second, Now5F03Update, Now())
                    '_mainForm.Show_LBox_PolicyRightNowText("GreenLihgRunYet " + GreenLihgRunYet.ToString)
                    Dim ReminRunSec As Integer = Val(HexStringTOIntString(Data_5F03.StepSec, 4)) - GreenLihgRunYet
                    '_mainForm.Show_LBox_PolicyRightNowText("ReminRunSec " + ReminRunSec.ToString)
                    iRG_i_1 = ReminRunSec
                    '_mainForm.Show_LBox_PolicyRightNowText("iRG_i_1 " + iRG_i_1.ToString)
                    If NowPhaseID <> Data_5F13.SubPhaseCount Then '不是最後一個分相
                        If isPass(Val(TriggerPhaseDirect) - 1, Data_5F13.SignalStatus(NowPhaseID), Data_5F13.SignalMap(NowPhaseID)) Then
                            '下一個分相,同相也是綠燈.
                            Dim NextGreenSecond As String = Data_5F15.Green(NowPhaseID)
                            iRG_i_2 = Val(HexStringTOIntString(NextGreenSecond, 4)) 'nextGreenSecond
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return iRG_i_1 + iRG_i_2
    End Function
  
    'RG(i_max):公車時相最大綠燈剩餘秒數
    '要把早開和遲閉的綠燈分相算進去.
    Public Function RG_i_max(ByVal TriggerPhaseDirect As String) As Integer
        Dim iRG_i_1 As Integer = 0
        Dim iRG_i_2 As Integer = 0
        Dim NowPhaseID As Integer = Val(Data_5F03.SubPhaseID)
        Dim Now5F03Update As DateTime = Data_5F03.UpdateTime        

        Try
            If Not IsNothing(Data_5F03) And Not IsNothing(Data_5F13) And Not IsNothing(Data_5F14) And Not IsNothing(Data_5F15) Then               
                If isPass(Val(TriggerPhaseDirect) - 1, Data_5F13.SignalStatus(NowPhaseID - 1), Data_5F13.SignalMap) Then
                    Dim GreenLihgRunYet As Integer = DateDiff(DateInterval.Second, Now5F03Update, Now())
                    Dim tmpString As String = Data_5F14.LightStatus(NowPhaseID - 1)
                    Dim maxGreenSec As Integer = Val(HexStringTOIntString(tmpString.Substring(2, 4), 4))
                    Dim ReminRunSec As Integer = maxGreenSec - GreenLihgRunYet
                    iRG_i_1 = ReminRunSec
                    If NowPhaseID <> Data_5F13.SubPhaseCount Then '不是最後一個分相
                        If isPass(Val(TriggerPhaseDirect) - 1, Data_5F13.SignalStatus(NowPhaseID), Data_5F13.SignalMap(NowPhaseID)) Then
                            '下一個分相,同相也是綠燈.
                            Dim StrNextMaxGreenSecond As String = Data_5F14.LightStatus(NowPhaseID)
                            Dim IntNextMaxGreenSecnod As Integer = Val(HexStringTOIntString(StrNextMaxGreenSecond.Substring(2, 4), 4))
                            iRG_i_2 = IntNextMaxGreenSecnod
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return iRG_i_1 + iRG_i_2
    End Function

    'G(j):衝突時相綠燈總和-->黃紅燈也要算進去.
    '如早開遅閉,也要扣掉.
    Public Function G_j(ByVal TriggerPhaseDirect As String) As Integer
        Dim iG_j_1 As Integer = 0
        Dim iG_j_2 As Integer = 0
        Dim NowPhaseID As Integer = Val(Data_5F03.SubPhaseID)        
        Try
            If Not IsNothing(Data_5F03) And Not IsNothing(Data_5F13) And Not IsNothing(Data_5F14) And Not IsNothing(Data_5F15) Then
                Dim NowStepGreenSec As Integer = Val(HexStringTOIntString(Data_5F15.Green(NowPhaseID - 1), 4))
                Dim AllCycle As Integer = Val(HexStringTOIntString(Data_5F15.CycleTime, 4))
                Dim OtherPhaseSec As Integer = AllCycle - NowStepGreenSec
                iG_j_1 = OtherPhaseSec
                If NowPhaseID <> Data_5F13.SubPhaseCount Then '不是最後一個分相
                    If isPass(Val(TriggerPhaseDirect) - 1, Data_5F13.SignalStatus(NowPhaseID), Data_5F13.SignalMap(NowPhaseID)) Then
                        '下一個分相,同相也是綠燈.
                        Dim StrNextGreenSecond As String = Data_5F15.Green(NowPhaseID) 'data_5F15.Green(Val(data_5F03.SubPhaseID))
                        Dim IntNextGreenSecnod As Integer = Val(HexStringTOIntString(StrNextGreenSecond, 4))
                        iG_j_2 = IntNextGreenSecnod
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return iG_j_1 - iG_j_2
    End Function
    'G(j_min):衝突時相綠燈最小綠總和-->黃紅燈也要算進去.
    '如早開遅閉,也要扣掉.
    Public Function G_j_min(ByVal TriggerPhaseDirect As String) As Integer
        Dim iG_j_min_1 As Integer = 0
        Dim iG_j_min_2 As Integer = 0

        Dim NowPhaseID As Integer = Val(Data_5F03.SubPhaseID)
        Try
            If Not IsNothing(Data_5F03) And Not IsNothing(Data_5F13) And Not IsNothing(Data_5F14) And Not IsNothing(Data_5F15) Then
                'Dim tmpString As String = data_5F14.LightStatus(Val(data_5F03.SubPhaseID) - 1)
                Dim SumMinGreenSec As Integer = 0 '= Val(HexStringTOIntString(tmpString.Substring(0, 2), 2))

                For i As Integer = 0 To Data_5F14.LightStatus.Length - 1
                    If i <> (NowPhaseID - 1) Then
                        SumMinGreenSec = SumMinGreenSec + Val(HexStringTOIntString(Data_5F14.LightStatus(i).Substring(0, 2), 2))
                    End If
                Next i
                iG_j_min_1 = SumMinGreenSec

                If NowPhaseID <> Data_5F13.SubPhaseCount Then '不是最後一個分相
                    If isPass(Val(TriggerPhaseDirect) - 1, Data_5F13.SignalStatus(NowPhaseID), Data_5F13.SignalMap(NowPhaseID)) Then
                        '下一個分相,同相也是綠燈.
                        Dim StrNextMinGreenSecond As String = Data_5F14.LightStatus(NowPhaseID)
                        Dim IntNextMinGreenSecnod As Integer = Val(HexStringTOIntString(StrNextMinGreenSecond.Substring(0, 2), 2))
                        iG_j_min_2 = IntNextMinGreenSecnod
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
        Return iG_j_min_1 - iG_j_min_2
    End Function

    '目前公車為紅燈
    'RG(j):衝突時相剩餘秒數-->黃紅燈也要算進去.
    '先算目前步階剩幾秒,再算後面分相剩幾秒.
    Public Function RG_j(ByVal TriggerPhaseDirect As String) As Integer
        Dim iRG_j_1 As Integer = 0
        Dim iRG_j_2 As Integer = 0

        Dim NowPhaseID As Integer = Val(Data_5F03.SubPhaseID)
        Dim NowStepID As Integer = Val(Data_5F03.StepID) '1,2,3,4,5
        Dim Now5F03Update As DateTime = Data_5F03.UpdateTime

        Try
            If Not IsNothing(Data_5F03) And Not IsNothing(Data_5F13) And Not IsNothing(Data_5F14) And Not IsNothing(Data_5F15) Then
                '目前步階走完剩幾秒
                Dim StepReminSec As Integer = 0
                For i As Integer = (Val(NowStepID) - 1) To 4
                    If i = (Val(NowStepID) - 1) Then
                        Dim nowStepRunYet As Integer = DateDiff(DateInterval.Second, Now5F03Update, Now())  '目前步階剩餘秒數
                        StepReminSec = StepReminSec + nowStepRunYet
                    Else  '不可能第一步階綠燈
                        Dim LightStatus As String = Data_5F14.LightStatus(NowPhaseID - 1)
                        Dim SubLightStatus(4) As String
                        SubLightStatus(0) = 0  '綠
                        SubLightStatus(1) = HexStringTOIntString(LightStatus.Substring(10, 2), 2)  '行綠
                        SubLightStatus(2) = HexStringTOIntString(LightStatus.Substring(12, 2), 2)  '行紅
                        SubLightStatus(3) = HexStringTOIntString(LightStatus.Substring(8, 2), 2)  '黃
                        SubLightStatus(4) = HexStringTOIntString(LightStatus.Substring(6, 2), 2) '紅
                        StepReminSec = StepReminSec + Val(SubLightStatus(i))
                    End If
                Next i
                iRG_j_1 = StepReminSec
                '後面分相剩幾秒
                Dim PhaseStepID As Integer = 0
                For i As Integer = 0 To Val(Data_5F13.SubPhaseCount) - 1
                    PhaseStepID = (NowPhaseID + i) Mod Val(Data_5F13.SubPhaseCount)  '0,1,2,3,4,5,6,7,8

                    If isPass(Val(TriggerPhaseDirect) - 1, Data_5F13.SignalStatus(PhaseStepID), Data_5F13.SignalMap(PhaseStepID)) Then
                        Exit For
                    Else
                        Dim GreenSec As Integer = HexStringTOIntString(Data_5F15.Green(PhaseStepID), 4)
                        Dim SubLightStatus(1) As String
                        Dim LightStatus As String = Data_5F14.LightStatus(PhaseStepID)
                        SubLightStatus(0) = HexStringTOIntString(LightStatus.Substring(8, 2), 2)  '黃
                        SubLightStatus(1) = HexStringTOIntString(LightStatus.Substring(6, 2), 2) '紅

                        iRG_j_2 = iRG_j_2 + GreenSec + Val(SubLightStatus(0)) + Val(SubLightStatus(1))
                    End If
                Next i
            End If

        Catch ex As Exception
        End Try
        Return iRG_j_1 + iRG_j_2
    End Function

    'RG(j_min):衝突時相最小綠燈總和剩餘秒數-->黃紅燈也要算進去.
    '先算目前步階剩幾秒,再算後面分相剩幾秒.
    Public Function RG_j_min(ByVal TriggerPhaseDirect As String) As Integer
        Dim iRG_j_min_1 As Integer = 0
        Dim iRG_j_min_2 As Integer = 0

        Dim NowPhaseID As Integer = Val(Data_5F03.SubPhaseID)
        Dim NowStepID As Integer = Val(Data_5F03.StepID) '1,2,3,4,5
        Dim Now5F03Update As DateTime = Data_5F03.UpdateTime

        Try
            If Not IsNothing(Data_5F03) And Not IsNothing(Data_5F13) And Not IsNothing(Data_5F14) And Not IsNothing(Data_5F15) Then
                '目前步階走完剩幾秒
                Dim StepReminSec As Integer = 0
                For i As Integer = (Val(NowStepID) - 1) To 4
                    If i = 0 Then

                    ElseIf i = (Val(NowStepID) - 1) Then
                        Dim nowStepRunYet As Integer = DateDiff(DateInterval.Second, Now5F03Update, Now())
                        If i = 0 Then
                            Dim tmpMinGreean As String = HexStringTOIntString(Data_5F14.LightStatus(NowPhaseID - 1).Substring(0, 2), 2)
                            Dim nowPhaseMinGreen As Integer = Val(tmpMinGreean)  '最小綠
                            If nowStepRunYet > nowPhaseMinGreen Then
                                StepReminSec = nowPhaseMinGreen
                            Else
                                StepReminSec = nowStepRunYet
                            End If
                        Else
                            StepReminSec = StepReminSec + nowStepRunYet
                        End If

                    Else  '不可能第一步階綠燈
                        Dim LightStatus As String = Data_5F14.LightStatus(NowPhaseID - 1)
                        Dim SubLightStatus(4) As String
                        SubLightStatus(0) = 0  '綠
                        SubLightStatus(1) = HexStringTOIntString(LightStatus.Substring(10, 2), 2)  '行綠
                        SubLightStatus(2) = HexStringTOIntString(LightStatus.Substring(12, 2), 2)  '行紅
                        SubLightStatus(3) = HexStringTOIntString(LightStatus.Substring(8, 2), 2)  '黃
                        SubLightStatus(4) = HexStringTOIntString(LightStatus.Substring(6, 2), 2) '紅
                        StepReminSec = StepReminSec + Val(SubLightStatus(i))
                    End If
                Next i
                iRG_j_min_1 = StepReminSec
                '後面分相剩幾秒
                Dim PhaseStepID As Integer = 0
                For i As Integer = 0 To Val(Data_5F13.SubPhaseCount) - 1
                    PhaseStepID = (NowPhaseID + i) Mod Val(Data_5F13.SubPhaseCount)  '0,1,2,3,4,5,6,7,8

                    If isPass(Val(TriggerPhaseDirect) - 1, Data_5F13.SignalStatus(PhaseStepID), Data_5F13.SignalMap(PhaseStepID)) Then
                        Exit For
                    Else
                        Dim MinGreenSec As Integer = HexStringTOIntString(Data_5F14.LightStatus(PhaseStepID).Substring(0, 2), 2)
                        Dim SubLightStatus(1) As String
                        Dim LightStatus As String = Data_5F14.LightStatus(PhaseStepID)
                        SubLightStatus(0) = HexStringTOIntString(LightStatus.Substring(8, 2), 2)  '黃
                        SubLightStatus(1) = HexStringTOIntString(LightStatus.Substring(6, 2), 2) '紅

                        iRG_j_min_2 = iRG_j_min_2 + MinGreenSec + Val(SubLightStatus(0)) + Val(SubLightStatus(1))
                    End If
                Next i
            End If

        Catch ex As Exception

        End Try
        Return iRG_j_min_1 + iRG_j_min_2
    End Function
    Public Function Command(ByVal Send As String) As Boolean

        Try
            Dim sendByte As Byte() = Incode_Step1(getSeqNum(), MarkAACommand(Send))
            _mainForm.Show_LBox_PolicyRightNowText(" Send to IC  " + ByteArrayToStr2(sendByte))
            _mainForm.send_IC(sendByte)

            If Send.Contains("5F1C") Then
                'Put the payback here
                _mainForm.Show_LBox_PolicyRightNowText("******************************")
            End If

            Return True
        Catch ex As Exception
            _mainForm.Show_LBox_PolicyRightNowText(" Somthing Wrong with Command")
            Return False
        End Try

    End Function
    Public Function Command2(ByVal Send As String) As Boolean

        Try
            Dim sendByte As Byte() = Incode_Step1(getSeqNum(), MarkAACommand(Send))

            _mainForm.send_IC(sendByte)

            If Send.Contains("5F1C") Then
                'Put the payback here

            End If

            Return True
        Catch ex As Exception
            _mainForm.Show_LBox_PolicyRightNowText(" Somthing Wrong with Command")
            Return False
        End Try

    End Function
    Public Function MaxGreen(ByVal Light As String) As Integer

        Try
            Dim Max As Integer = Val(HexStringTOIntString(Light.Substring(2, 4), 4))
            Return Max
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function MinGreen(ByVal Light As String) As Integer

        Try
            Dim Min As Integer = Val(HexStringTOIntString(Light.Substring(0, 2), 2))
            If Min = 0 Then
                Min = 5
            End If

            Return Min
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function MinGreenHex(ByVal Light As String) As String

        Try
            Dim Min As String = Light.Substring(0, 2)
            If Min = "00" Then
                Min = "05"
            End If
            Return Min
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function YellowplusRed(ByVal Light As String) As Integer

        Try
            Dim Yellow As Integer = Val(HexStringTOIntString(Light.Substring(6, 2), 2))
            Dim Red As Integer = Val(HexStringTOIntString(Light.Substring(8, 2), 2))
            Return Yellow + Red
            
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function PedGreenFlashRed(ByVal Light As String) As Integer

        Try
            Dim PedGreenFlash As Integer = Val(HexStringTOIntString(Light.Substring(10, 2), 2))
            Dim PedRed As Integer = Val(HexStringTOIntString(Light.Substring(12, 2), 2))
            Return PedGreenFlash + PedRed

        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function CurrentGreen(ByVal Light As String) As Integer

        Try
            Dim green As Integer = Val(HexStringTOIntString(Light, 4))

            Return green
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function BusPhaseOrNot(ByVal BusLineID As String, ByVal CrossRoadID As String, ByVal Goback As String) As Boolean

        Try
            If Goback = "1" Then
                Goback = "00"
            ElseIf Goback = "2" Then
                Goback = "01"
            End If


            Dim BusLineDataKey As String = BusLineID + "_" + CrossRoadID + "_" + Goback

            Dim CurrentPhaseInt As Integer = HexStringTOIntString(Data_5FCC.Current_SubPhaseID.ToString, 2)

            Dim CurrentStepInt As Integer = HexStringTOIntString(Data_5FCC.Current_StepID.ToString, 2)

            'BusLineList key -> buslineID_CrossRoadID

            '_mainForm.Show_LBox_PolicyRightNowText("BusLine Route  " + Current_BusLineID.ToString() + "  Bus Line Data " + BusLineList("0001_0002").ToString + " CrossRoadID " + _mainForm.TBox_CrossRoadID.Text)
            'Dim BusLineData As String = BusLineList("0001_0002")
            'Dim BusLineData As String() = BusLineList().Split(",")
            '_mainForm.Show_LBox_PolicyRightNowText("Current phase " + Data_5FCC.Current_SubPhaseID.ToString + " Current Step " + Data_5FCC.Current_StepID + " Remaining Time " + HexStringTOIntString(Data_5FCC.Current_RemainingTime, 4).ToString)

            Dim RemanSecBusCrossRoad As Integer = 0
            ' Dim BusLineData As String() = BusLineList(BusLineID + "_" + CrossRoadID + "_" + Goback).Split(",")  ' BusLineList key = "BusLineID_CrossRoadID_GoBack" 
            'Dim BusLineData As String() = BusLineList("0001_0001_00").Split(",")
            Dim MyKeys As ICollection
            Dim Key As Object

            MyKeys = BusLineList.Keys()
            For Each Key In MyKeys
                '_mainForm.Show_LBox_PolicyRightNowText("BusLineList has  " + Key.ToString)
                '_mainForm.Show_LBox_PolicyRightNowText("Bus Line data has " + BusLineList(Key.ToString))
            Next

            Dim BusLineData As String()

            'If Goback = "01" Then               
            '    BusLineData = "0001,1,01,06,02".Split(",")
            'Else
            '    BusLineData = BusLineList(BusLineDataKey).Split(",")
            'End If

            BusLineData = BusLineList(BusLineDataKey).Split(",")

            '_mainForm.Show_LBox_PolicyRightNowText("Bus Line Key " + BusLineDataKey)

            '_mainForm.Show_LBox_PolicyRightNowText("Bus Line data " + BusLineList(BusLineDataKey))

            ' Dim BusLineData As String() = BusLineList(BusLineDataKey).Split(",")        'return route has a strange error  doesn't occure upon departure 

            '_mainForm.Show_LBox_PolicyRightNowText(" BuslineData PassPhase " + BusLineData(4))


            'Dim BusPassPhases As BitArray = New BitArray(8)
            Dim a() As Byte = {BusLineData(4)}

            Try
                FiveFB4.Add("BusPhase", BusLineData(4))

            Catch ex As Exception
                _mainForm.Show_LBox_PolicyRightNowText("  Error FiveFB4 BusPhase " + ex.Message)

            End Try


            BusPassPhases = New BitArray(a)




            '_mainForm.Show_LBox_PolicyRightNowText("Bit array ")

            'For i = 0 To 7
            '    If BusPassPhases(i) Then

            '        _mainForm.Show_LBox_PolicyRightNowText("Pass " + (i + 1).ToString)
            '    Else
            '        _mainForm.Show_LBox_PolicyRightNowText("Block " + (i + 1).ToString)
            '    End If
            'Next i

            ' _mainForm.Show_LBox_PolicyRightNowText("Bit array ")

            For i As Integer = 0 To BusPassPhases.Count - 1
                If BusPassPhases(i) And (i + 1) = CurrentPhaseInt And CurrentStepInt <> 5 Then

                    '_mainForm.Show_LBox_PolicyRightNowText("Green Light Now " + (i + 1).ToString)
                    Return True

                End If
            Next i


        Catch ex As Exception
            _mainForm.Show_LBox_PolicyRightNowText("Bus Line Data error " + ex.StackTrace.ToString)
            Return False
        End Try
        '_mainForm.Show_LBox_PolicyRightNowText("Red Light Now ")
        Return False
    End Function
    '************************************************************************************************
    '**
    '** 觸發點函數
    '**
    '************************************************************************************************
    '觸發點型別1:起始點  2決策點  3:結束點
    'TriggerPointdList


    '************************************************************************************************
    '**
    '** 車載機剩餘秒數回報
    '**
    '************************************************************************************************
    'RG_Stauts:紅燈-->R,綠燈-->G
    Public SeqNumber As Double
    Public Function SendLightRemainSec(ByVal strBusID As String, ByVal RG_Stauts As String, ByVal RemainSec As String) As Boolean
        Dim isSuccess As Boolean = False
        Try
            If _ConnectFlag_Car Then
                Dim Sendstring As String
                Dim YearString As String = Now.Year.ToString("0000")
                Dim MonthString As String = Now.Month.ToString("00")
                Dim DayString As String = Now.Day.ToString("00")
                Dim HourString As String = Now.Hour.ToString("00")
                Dim MinuteString As String = Now.Minute.ToString("00")
                Dim SecondString As String = Now.Second.ToString("00")
                Dim TimeString As String = YearString + MonthString + DayString + HourString + MinuteString + SecondString
                SeqNumber = (SeqNumber + 1) Mod 1000000000
                Dim SeqString As String = SeqNumber.ToString("00000000")
                Sendstring = "B2," + strBusID + ",SET01010," + HourString + MinuteString + SecondString + "_" + Trim(RG_Stauts) + Trim(RemainSec) + ",0,2," + TimeString + "," + SeqString + "," + TimeString
                TCP_ClientWriteToCAR(Sendstring)
                Dim text As String = "[R-->Bus] " + Sendstring

                WriteLog(curPath, "CAR_comm", [text], _logEnable)
            End If
        Catch ex As Exception
        End Try
        Return isSuccess
    End Function
    Public Function RemainingLightTime(ByVal GreenOrNot As Boolean) As Integer
        Dim Remaining As Integer
        Try
            Dim TotalPhase As String
            Try
                TotalPhase = Data_5F18.SubPhaseCount.ToString
            Catch ex As Exception
                TotalPhase = Data_5F13.SubPhaseCount.ToString
            End Try

            Dim TotalPhaseInt As Integer = Convert.ToDecimal(TotalPhase)
            Dim CurrentPhaseInt As Integer = Convert.ToDecimal(Data_5FCC.Current_SubPhaseID)
            Dim CurrentStepInt As Integer = Convert.ToDecimal(Data_5FCC.Current_StepID)
            Dim CurrentRemainingTime As Integer = Data_5FCC.Current_RemainingInt

            Dim LightArray(0 To TotalPhaseInt) As String
            Dim Massgg(0 To TotalPhaseInt) As Integer
            Dim Microgg(0 To TotalPhaseInt) As Integer
            Dim Microggstr(0 To TotalPhaseInt) As String
            Dim Yellowrr(0 To TotalPhaseInt) As Integer
            Dim Greenint(0 To TotalPhaseInt) As Integer




            Dim prepare As Integer

            For index As Integer = 0 To TotalPhaseInt - 1




                '_mainForm.Show_LBox_PolicyRightNowText(" 分相 " + index.ToString + "  Nowgreen " + Greenint(index).ToString + " Mingreen " + Microgg(index).ToString + "  Yellow Red " + Yellowrr(index).ToString)
                Try
                    Greenint(index) = CurrentGreen(Data_5F15.Green(index))
                    Microgg(index) = MinGreen(Data_5F14.LightStatus(index))

                    Yellowrr(index) = YellowplusRed(Data_5F14.LightStatus(index)) 'yellow plus red  
                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText("取不到最小綠 使用預設 10 秒")
                    Microgg(index) = 10
                    Microggstr(index) = "0A"
                    Yellowrr(index) = 5
                End Try

            Next

            For index As Integer = 0 To TotalPhaseInt - 1
                Dim TempMicro As Integer


                If index < (TotalPhaseInt - 1) Then
                    TempMicro = Microgg(index + 1)
                Else
                    TempMicro = Microgg(0)
                End If

                Massgg(index) = Greenint(index) + TempMicro

            Next

            'Needs 5F14 data pedgreenflash pedred


            If GreenOrNot Then
                '_mainForm.Show_LBox_PolicyRightNowText(" Calculate Remaining Green ")

                If CurrentStepInt = 1 Then
                    prepare = Greenint(CurrentPhaseInt - 1) - CurrentRemainingTime
                    Remaining = Greenint(CurrentPhaseInt - 1) - prepare

                ElseIf CurrentStepInt = 2 Then
                    Remaining = CurrentRemainingTime + 4 + 3
                ElseIf CurrentStepInt = 3 Then
                    Remaining = CurrentRemainingTime + 3
                Else
                    Remaining = CurrentRemainingTime

                End If

                For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                    If BusPassPhases(index - 1) Then
                        Remaining = Remaining + Greenint(index - 1)
                        If CurrentPhaseInt <> 1 Then
                            For index2 As Integer = 1 To CurrentPhaseInt - 1

                                If BusPassPhases(index2 - 1) Then
                                    Remaining = Remaining + Greenint(index2 - 1)
                                End If


                            Next

                        End If


                    End If

                Next

                'If BusPassPhases(CurrentPhaseInt) Then
                '    Remaining = Remaining + Greenint(CurrentPhaseInt)

                'End If
                Return Remaining
            Else
                '_mainForm.Show_LBox_PolicyRightNowText(" Calculate Remaining Red ")
                If CurrentStepInt = 1 Then
                    prepare = Greenint(CurrentPhaseInt - 1) - CurrentRemainingTime
                    Remaining = Greenint(CurrentPhaseInt - 1) - prepare

                ElseIf CurrentStepInt = 2 Then
                    Remaining = CurrentRemainingTime + 4 + 3 + 2
                ElseIf CurrentStepInt = 3 Then
                    Remaining = CurrentRemainingTime + 3 + 2
                Else
                    Remaining = CurrentRemainingTime

                End If

                For index As Integer = CurrentPhaseInt + 1 To TotalPhaseInt
                    If BusPassPhases(index - 1) = False Then
                        Remaining = Remaining + Greenint(index - 1) + 5
                        If CurrentPhaseInt <> 1 Then
                            For index2 As Integer = 1 To CurrentPhaseInt - 1

                                If BusPassPhases(index2 - 1) = False Then
                                    Remaining = Remaining + Greenint(index2 - 1) + 5
                                End If


                            Next

                        End If


                    End If

                Next
                Return Remaining



            End If
        Catch ex As Exception
            _mainForm.Show_LBox_PolicyRightNowText(" RemainingLightTime Error" + ex.StackTrace.ToString)
        End Try
        Return Remaining
    End Function
    Public Function NextBusPhaseOrNot() As Boolean

        Try
           

            Dim RemanSecBusCrossRoad As Integer = 0
            Dim TotalPhase As String
            Try
                TotalPhase = Data_5F18.SubPhaseCount.ToString
            Catch ex As Exception
                TotalPhase = Data_5F13.SubPhaseCount.ToString
            End Try

            Dim TotalPhaseInt As Integer = Convert.ToDecimal(TotalPhase)
            Dim CurrentPhaseInt As Integer = Convert.ToDecimal(Data_5FCC.Current_SubPhaseID)
            Dim CurrentStepInt As Integer = Convert.ToDecimal(Data_5FCC.Current_StepID)
            Dim CurrentRemainingTime As Integer = Data_5FCC.Current_RemainingInt

            Dim LightArray(0 To TotalPhaseInt) As String
            Dim Massgg(0 To TotalPhaseInt) As Integer
            Dim Microgg(0 To TotalPhaseInt) As Integer
            Dim Microggstr(0 To TotalPhaseInt) As String
            Dim Yellowrr(0 To TotalPhaseInt) As Integer
            Dim Greenint(0 To TotalPhaseInt) As Integer


            '_mainForm.Show_LBox_PolicyRightNowText(" BuslineData PassPhase " + BusLineData(4))


            'Dim BusPassPhases As BitArray = New BitArray(8)




            '_mainForm.Show_LBox_PolicyRightNowText("Bit array ")
            Dim i As Integer
            'For i = 0 To 7
            '    If BusPassPhases(i) Then

            '        _mainForm.Show_LBox_PolicyRightNowText("Pass " + (i + 1).ToString)
            '    Else
            '        _mainForm.Show_LBox_PolicyRightNowText("Block " + (i + 1).ToString)
            '    End If
            'Next i

            ' _mainForm.Show_LBox_PolicyRightNowText("Bit array ")

            For i = 0 To BusPassPhases.Count - 1
                If BusPassPhases(i) And (i + 1) = CurrentPhaseInt And CurrentStepInt <> 5 And CurrentStepInt <> 4 Then

                    _mainForm.Show_LBox_PolicyRightNowText("Green Light Now " + (i + 1).ToString)
                    Return True

                End If
            Next i


        Catch ex As Exception
            _mainForm.Show_LBox_PolicyRightNowText("Bus Line Data error " + ex.StackTrace.ToString)
            Return False
        End Try
        _mainForm.Show_LBox_PolicyRightNowText("Next Phase Red Light ")
        Return False
    End Function
    Public Function Sub_5F4C() As Integer

        Try
            Dim timetemp = TimeValue(Now)
            Dim SecondsDifference As Integer
            SecondsDifference = DateDiff(DateInterval.Second, SaveData_5F03_TimeStamp, timetemp)
            '_mainForm.Show_LBox_PolicyRightNowText("Time Stamp Difference " + SecondsDifference.ToString)

            Dim TempSec As String = Original_Phase_Step(Data_5F03.SubPhaseID + "_" + Data_5F03.StepID)


            Return SecondsDifference
        Catch ex As Exception
            Return Nothing
        End Try

    End Function
    Public Function RemainingLightTime2(ByVal GreenOrNot As Boolean) As Integer
        Dim sec As Integer = 0
        Try
            Dim TotalPhase As String

            Try
                TotalPhase = Data_5F18.SubPhaseCount.ToString
            Catch ex As Exception
                TotalPhase = Data_5F13.SubPhaseCount.ToString
            End Try


            Dim MyKeys As ICollection
            Dim Key As Object

            If (Original_Phase_Step.Count = 0) Then
                _mainForm.Show_LBox_PolicyRightNowText("The Original_Phase_Step HashTable is empty")

            Else

                MyKeys = Original_Phase_Step.Keys()
                For Each Key In MyKeys
                    ' _mainForm.Show_LBox_PolicyRightNowText("Original_Phase_Step " + Key.ToString + "  Value = " + Original_Phase_Step(Key).ToString)

                Next

            End If


            Dim TotalPhaseInt As Integer = Convert.ToDecimal(TotalPhase)
            Dim CurrentPhaseInt As Integer = Convert.ToDecimal(Data_5FCC.Current_SubPhaseID)
            Dim CurrentStepInt As Integer = Convert.ToDecimal(Data_5FCC.Current_StepID)
            Dim CurrentPhaseStr As Integer = Data_5FCC.Current_SubPhaseID
            Dim CurrentStepStr As Integer = Data_5FCC.Current_StepID
            Dim CurrentRemainingTime As Integer = Data_5FCC.Current_RemainingInt



            For i As Integer = 1 To TotalPhaseInt
                For j As Integer = 1 To 5
                    Dim Hexphase As String = IntToHexString(i, 2)
                    Dim Hexstep As String = IntToHexString(j, 2)
                    If Original_Phase_Step.ContainsKey(Hexphase + "_" + Hexstep) Then
                        Dim tempint As String = HexStringTOIntString(Original_Phase_Step(Hexphase + "_" + Hexstep), 4)
                        '_mainForm.Show_LBox_PolicyRightNowText("分相 " + Hexphase + "  步階 " + Hexstep + "  Value = " + Original_Phase_Step(Hexphase + "_" + Hexstep).ToString)
                        '_mainForm.Show_LBox_PolicyRightNowText("分相 " + Hexphase + "  步階 " + Hexstep + "  Value = " + tempint)
                    End If
                Next

            Next
            






            'For index As Integer = 0 To TotalPhaseInt - 1

            '    '_mainForm.Show_LBox_PolicyRightNowText(" 分相 " + index.ToString + "  Nowgreen " + Greenint(index).ToString + " Mingreen " + Microgg(index).ToString + "  Yellow Red " + Yellowrr(index).ToString)
            '    Try
            '        Greenint(index) = CurrentGreen(Data_5F15.Green(index))
            '        Microgg(index) = MinGreen(Data_5F14.LightStatus(index))

            '        Yellowrr(index) = YellowplusRed(Data_5F14.LightStatus(index)) 'yellow plus red  
            '    Catch ex As Exception
            '        _mainForm.Show_LBox_PolicyRightNowText("取不到最小綠 使用預設 10 秒")
            '        Microgg(index) = 10
            '        Microggstr(index) = "0A"
            '        Yellowrr(index) = 5
            '    End Try

            'Next

            'For index As Integer = 0 To TotalPhaseInt - 1
            '    Dim TempMicro As Integer


            '    If index < (TotalPhaseInt - 1) Then
            '        TempMicro = Microgg(index + 1)
            '    Else
            '        TempMicro = Microgg(0)
            '    End If

            '    Massgg(index) = Greenint(index) + TempMicro

            'Next

            'Needs 5F14 data pedgreenflash pedred



            If GreenOrNot Then
                '_mainForm.Show_LBox_PolicyRightNowText(" Calculate Remaining Green ")
                'Original_Phase_Step(sSubPhaseID + "_" + sStepID)
                'IntToHexString(ByVal val As Integer, ByVal ipos As Integer)
                'For i As Integer = 0 To ds.Tables(0).Rows.Count - 1


                Try

                    For i As Integer = CurrentPhaseInt To TotalPhaseInt

                        For j As Integer = CurrentStepInt To 5

                            Dim Hexphase As String = IntToHexString(i, 2)
                            Dim Hexstep As String = IntToHexString(j, 2)
                            Dim hexsec As String

                            If j = CurrentStepInt And i = CurrentPhaseInt Then
                                sec = CurrentRemainingTime

                            ElseIf BusPassPhases(i - 1) = False Then
                                Return sec
                            Else

                                If Original_Phase_Step.ContainsKey(Hexphase + "_" + Hexstep) And CurrentStepInt <> 5 And BusPassPhases(i - 1) Then

                                    hexsec = Original_Phase_Step(Hexphase + "_" + Hexstep)

                                    'sec = sec + Val(Convert.ToDecimal(hexsec))
                                    sec = sec + CLng("&H" & hexsec)



                                End If



                            End If

                        Next
                       

                    Next

                    For i As Integer = 1 To CurrentPhaseInt - 1
                        For j As Integer = 1 To 5

                            Dim Hexphase As String = IntToHexString(i, 2)
                            Dim Hexstep As String = IntToHexString(j, 2)
                            Dim hexsec As String

                            If Original_Phase_Step.ContainsKey(Hexphase + "_" + Hexstep) And CurrentStepInt <> 5 And BusPassPhases(i - 1) Then

                                hexsec = Original_Phase_Step(Hexphase + "_" + Hexstep)
                                'sec = sec + Val(Convert.ToDecimal(hexsec))
                                sec = sec + CLng("&H" & hexsec)
                            ElseIf BusPassPhases(i - 1) = False Then
                                Return sec
                            End If
                            '_mainForm.Show_LBox_PolicyRightNowText(" Phase_Step ")
                        Next
                    Next

                    Return sec

                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText(" Phase Step Loop Green " + ex.StackTrace.ToString)
                End Try

            Else

                Try

                    For i As Integer = CurrentPhaseInt To TotalPhaseInt
                        Dim Hexphase As String = IntToHexString(i, 2)

                        For j As Integer = CurrentStepInt To 5


                            Dim Hexstep As String = IntToHexString(j, 2)
                            Dim hexsec As String

                            If j = CurrentStepInt And i = CurrentPhaseInt Then
                                sec = CurrentRemainingTime

                            ElseIf BusPassPhases(i - 1) = True Then
                                Return sec

                            Else

                                If Original_Phase_Step.ContainsKey(Hexphase + "_" + Hexstep) And BusPassPhases(i - 1) = False Then

                                    hexsec = Original_Phase_Step(Hexphase + "_" + Hexstep)

                                    'sec = sec + Convert.ToDecimal(hexsec)
                                    sec = sec + CLng("&H" & hexsec)
                                End If

                            End If

                        Next

                    Next

                    For i As Integer = 1 To CurrentPhaseInt - 1
                        Dim Hexphase As String = IntToHexString(i, 2)

                        For j As Integer = 1 To 5


                            Dim Hexstep As String = IntToHexString(j, 2)
                            Dim hexsec As String

                            If BusPassPhases(i - 1) = True Then
                                Return sec
                            End If


                            If Original_Phase_Step.ContainsKey(Hexphase + "_" + Hexstep) And BusPassPhases(i - 1) = False Then

                                hexsec = Original_Phase_Step(Hexphase + "_" + Hexstep)
                                'sec = sec + Convert.ToDecimal(hexsec)

                                sec = sec + CLng("&H" & hexsec)
                            End If
                            '_mainForm.Show_LBox_PolicyRightNowText(" Phase_Step ")
                        Next
                    Next

                    Return sec

                Catch ex As Exception
                    _mainForm.Show_LBox_PolicyRightNowText(" Phase Step Loop Red " + ex.StackTrace.ToString)
                End Try



            End If
        Catch ex As Exception
            _mainForm.Show_LBox_PolicyRightNowText(" RemainingLightTime Error" + ex.StackTrace.ToString)
        End Try
        Return sec
    End Function
End Module
