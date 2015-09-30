'*********************************************************
'**
'** V3.0 structure
'**
'*********************************************************
'jason20150930未下成功重傳.
'S---------------------------------------------------------------------------
Public Class V3_Object
    Public CommandType As String '0-AABB,1-ACK,2-NAK
    Public CommandSeq As Integer
    Public CommandADDR As String
    Public CommandLength As String
    Public CommandHeader As String
    Public CommandContext As String
    Public CommandCRC As String
    Public isNewCommand As Boolean  '非標準3.0=true

    Public Sub New(ByVal initString As String)
        Try
            Select Case Trim(initString.Substring(0, 4))
                Case "AABB"
                    CommandType = "0"
                    CommandLength = Val(HexStringTOIntString(initString.Substring(10, 4), 4))
                    CommandHeader = initString.Substring(14, 4)
                    CommandContext = initString.Substring(18, initString.Length - 24)
                Case "AADD"
                    CommandType = "1"
                    CommandLength = 8
                    CommandHeader = "ACK"
                    CommandContext = ""
                Case "AAEE"
                    CommandType = "2"
                    CommandLength = 9
                    CommandHeader = "NAK"
                    CommandContext = initString.Substring(14, 2)
                Case Else
                    CommandType = "-1"
            End Select
            If CommandType <> -1 Then
                CommandSeq = Val(HexStringTOIntString(initString.Substring(4, 2), 2))
                CommandADDR = initString.Substring(6, 4)
                CommandCRC = Right(initString, 2)
                If CommandHeader = "0F80" Or CommandHeader = "0F81" Or CommandHeader = "0F8F" Or CommandHeader = "0F8E" Or CommandHeader = "0F10" Or CommandHeader = "0F90" Or
                   CommandHeader = "0F40" Or CommandHeader = "0FC0" Or CommandHeader = "0F00" Or CommandHeader = "0F11" Or CommandHeader = "0F91" Or CommandHeader = "0F41" Or
                   CommandHeader = "0FC1" Or CommandHeader = "0F12" Or CommandHeader = "0F92" Or CommandHeader = "0F42" Or CommandHeader = "0FC2" Or CommandHeader = "0F02" Or
                   CommandHeader = "0F13" Or CommandHeader = "0F43" Or CommandHeader = "0FC3" Or CommandHeader = "0F14" Or CommandHeader = "0F44" Or CommandHeader = "0FC4" Or
                   CommandHeader = "0F04" Or CommandHeader = "0F15" Or CommandHeader = "0F45" Or CommandHeader = "0FC5" Or CommandHeader = "0F16" Or CommandHeader = "0F46" Or
                   CommandHeader = "0FC6" Or CommandHeader = "0F47" Or CommandHeader = "0FC7" Or CommandHeader = "5F10" Or CommandHeader = "5F40" Or CommandHeader = "5FC0" Or
                   CommandHeader = "5F00" Or CommandHeader = "5F11" Or CommandHeader = "5F41" Or CommandHeader = "5FC1" Or CommandHeader = "5F01" Or CommandHeader = "5F12" Or
                   CommandHeader = "5F42" Or CommandHeader = "5FC2" Or CommandHeader = "5F02" Or CommandHeader = "5F13" Or CommandHeader = "5F43" Or CommandHeader = "5FC3" Or
                   CommandHeader = "5F03" Or CommandHeader = "5F14" Or CommandHeader = "5F44" Or CommandHeader = "5FC4" Or CommandHeader = "5F15" Or CommandHeader = "5F45" Or
                   CommandHeader = "5FC5" Or CommandHeader = "5F16" Or CommandHeader = "5F46" Or CommandHeader = "5FC6" Or CommandHeader = "5F17" Or CommandHeader = "5F47" Or
                   CommandHeader = "5FC7" Or CommandHeader = "5F18" Or CommandHeader = "5F48" Or CommandHeader = "5FC8" Or CommandHeader = "5F19" Or CommandHeader = "5F49" Or
                   CommandHeader = "5FC9" Or CommandHeader = "5F09" Or CommandHeader = "5F1A" Or CommandHeader = "5F4A" Or CommandHeader = "5FCA" Or CommandHeader = "5F1B" Or
                   CommandHeader = "5F4B" Or CommandHeader = "5FCB" Or CommandHeader = "5F1C" Or CommandHeader = "5F4C" Or CommandHeader = "5FCC" Or CommandHeader = "5F0C" Or
                   CommandHeader = "5F1D" Or CommandHeader = "5F1E" Or CommandHeader = "5F4E" Or CommandHeader = "5FCE" Or CommandHeader = "5F2F" Or CommandHeader = "5F5F" Or
                   CommandHeader = "5FDF" Or CommandHeader = "5F31" Or CommandHeader = "5F61" Or CommandHeader = "5FE1" Or CommandHeader = "5F32" Or CommandHeader = "5F62" Or
                   CommandHeader = "5FE2" Or CommandHeader = "5F33" Or CommandHeader = "5F63" Or CommandHeader = "5FE3" Or CommandHeader = "5F08" Or CommandHeader = "5F0A" Or
                   CommandHeader = "5F0B" Or CommandHeader = "5F3F" Or CommandHeader = "5F6F" Or CommandHeader = "5FE6" Or CommandHeader = "5F0F" Or CommandHeader = "5F3E" Or
                   CommandHeader = "5F6E" Or CommandHeader = "5FEE" Or CommandHeader = "5F0E" Or CommandHeader = "5F19" Then
                    isNewCommand = False
                Else
                    isNewCommand = True
                End If
            End If

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "GModule_Comm_Level_1", "V3_Object NEW  Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

End Class

'E---------------------------------------------------------------------------
Public Class Class_5F10
    Public ControlStrategy As Byte
    Public EffectTime As Byte
    Public UpdateTime As DateTime
    Sub New(ByVal nSignalMap As Byte, ByVal nControlStrategy As Byte, ByVal nEffectTime As Byte, ByVal nUpdateTime As DateTime)
        ControlStrategy = nControlStrategy
        EffectTime = nEffectTime
        UpdateTime = nUpdateTime
    End Sub
End Class

Public Class Class_5F13
    Public PhaseOrder As String
    Public SignalMap As String
    Public SignalCount As String
    Public SubPhaseCount As String
    Public SignalStatus As String()
    Public UpdateTime As DateTime
    Sub New(ByVal nPhaseOrder As String, ByVal nSignalMap As String, ByVal nSignalCount As String, ByVal nSubPhaseCount As String, ByVal nSignalStatus As String, ByVal nUpdateTime As DateTime)
        Try
            PhaseOrder = nPhaseOrder
            SignalMap = nSignalMap
            SignalCount = nSignalCount
            SubPhaseCount = nSubPhaseCount
            ReDim SignalStatus(Val(nSubPhaseCount) - 1)
            For i As Integer = 0 To Val(nSubPhaseCount) - 1
                SignalStatus(i) = nSignalStatus.Substring(i * Val(nSignalCount) * 2, Val(nSignalCount) * 2)
            Next i

            UpdateTime = nUpdateTime
        Catch ex As Exception

        End Try



    End Sub

End Class
Public Class Class_5F14
    Public PlanID As String
    Public SubPhaseCount As String
    Public LightStatus() As String

    Public UpdateTime As DateTime
    Sub New(ByVal nPlanID As String, ByVal nSubPhaseCount As String, ByVal nLightStatus() As String, ByVal nUpdateTime As DateTime)
        PlanID = nPlanID
        SubPhaseCount = nSubPhaseCount
        LightStatus = nLightStatus
        UpdateTime = nUpdateTime
    End Sub

End Class
Public Class Class_5F15
    Public PlanID As String
    Public Direct As String
    Public PhaseOrder As String
    Public SubPhaseCount As String
    Public Green As String()
    Public CycleTime As String
    Public Offset As String
    Public UpdateTime As DateTime
    Sub New(ByVal nPlanID As String, ByVal nDirect As String, ByVal nPhaseOrder As String, ByVal nSubPhaseCount As String,
            ByVal nGreen As String, ByVal nCycleTime As String, ByVal nOffset As String,
            ByVal nUpdateTime As DateTime)
        PlanID = nPlanID
        Direct = nDirect
        PhaseOrder = nPhaseOrder
        SubPhaseCount = nSubPhaseCount
        ReDim Green(Val(SubPhaseCount) - 1)
        For i As Integer = 0 To Val(SubPhaseCount) - 1
            Green(i) = nGreen.Substring(i * 4, 4)
        Next i

        CycleTime = nCycleTime
        Offset = nOffset
        UpdateTime = nUpdateTime
    End Sub
End Class
Public Class Class_5F18
    Public PlanID As String
    Public Direct As String
    Public PhaseOrder As String
    Public SubPhaseCount As String
    Public Green As String
    Public CycleTime As String
    Public Offset As String
    Public UpdateTime As DateTime
    Sub New(ByVal nPlanID As String, ByVal nDirect As String, ByVal nPhaseOrder As String,
            ByVal nSubPhaseCount As String, ByVal nGreen As String, ByVal nCycleTime As String,
             ByVal nOffset As String, ByVal nUpdateTime As DateTime)
        PlanID = nPlanID
        Direct = nDirect
        PhaseOrder = nPhaseOrder
        SubPhaseCount = nSubPhaseCount
        CycleTime = nCycleTime
        Green = nGreen
        Offset = nOffset
        UpdateTime = nUpdateTime
    End Sub
End Class
Public Class Class_5F03
    Public PhaseOrder As String
    Public SignalMap As String
    Public PhaseCount As String
    Public SubPhaseID As String
    Public StepID As String
    Public StepSec As String
    Public SignalStatus As String
    Public UpdateTime As DateTime
    Sub New(ByVal nPhaseOrder As String, ByVal nSignalMap As String, ByVal nPhaseCount As String,
            ByVal nSubPhaseID As String, ByVal nStepID As String, ByVal nStepSec As String,
            ByVal nSignalStatus As String, ByVal nUpdateTime As DateTime)
        PhaseOrder = nPhaseOrder
        SignalMap = nSignalMap
        PhaseCount = nPhaseCount
        SubPhaseID = nSubPhaseID
        StepID = nStepID
        StepSec = nStepSec
        SignalStatus = nSignalStatus
        UpdateTime = nUpdateTime
    End Sub
End Class

'*********************************************************
'**
'** TTIA structure
'**
'*********************************************************
Public Class Class_A1
    Public Cmp As String
    Public BusID As String
    Public ButyStatus As String
    Public BusStatus As String
    Public Route As String
    Public GoBack As String
    Public X As String
    Public Y As String
    Public Speed As String
    Public Azimuth As String
    Public GPSTime As String
    Public Type As String
    Public TrasTime As String
    Public SN As String
    Public RecTime As String
    Public ToCrossRoadSec As String
    Sub New(ByVal RecDataString As String())
        Cmp = RecDataString(1)
        BusID = RecDataString(2)
        ButyStatus = RecDataString(3)
        BusStatus = RecDataString(4)
        Route = RecDataString(5)
        GoBack = RecDataString(6)
        X = RecDataString(7)
        Y = RecDataString(8)
        Speed = RecDataString(9)
        Azimuth = RecDataString(10)
        GPSTime = RecDataString(11)
        Type = RecDataString(12)
        TrasTime = RecDataString(13)
        SN = RecDataString(14)
        RecTime = RecDataString(15)
    End Sub
    Sub SetToCrossRoadSec(ByVal SetSec As String)
        ToCrossRoadSec = SetSec
    End Sub
End Class
Public Class Class_A2
    Public Cmp As String
    Public BusID As String
    Public ButyStatus As String
    Public BusStatus As String
    Public Route As String
    Public GoBack As String
    Public _Stop As String
    Public Leave As String
    Public GPSTime As String
    Public Type As String
    Public TrasTime As String
    Public SN As String
    Public RecTime As String
    Sub New(ByVal RecDataString As String())
        Cmp = RecDataString(1)
        BusID = RecDataString(2)
        ButyStatus = RecDataString(3)
        BusStatus = RecDataString(4)
        Route = RecDataString(5)
        GoBack = RecDataString(6)
        _Stop = RecDataString(7)
        Leave = RecDataString(8)
        GPSTime = RecDataString(9)
        Type = RecDataString(10)
        TrasTime = RecDataString(11)
        SN = RecDataString(12)
        RecTime = RecDataString(13)
    End Sub
End Class
'*********************************************************
'**
'** BusPrim structure
'**
'*********************************************************
Public Class Class_CrossRoad
    Public CrossRoadID As String
    Public CrossRoadName As String
    Public CrossRoadIP As String
    Public CrossRoadPort As String
    Public CrossRoadLatLon As String
    Public CrossRoad_isMaster As String
    Public CrossRoad_IC_Addr As String
  
    Sub New(ByVal vCrossRoadID As String, ByVal vCrossRoadName As String, ByVal vCrossRoadIP As String,
            ByVal vCrossRoadPort As String, ByVal vCrossRoadLatLon As String, ByVal vCrossRoad_isMaster As String,
            ByVal vCrossRoad_IC_Addr As String)
        CrossRoadID = vCrossRoadID
        CrossRoadName = vCrossRoadName
        CrossRoadIP = vCrossRoadIP
        CrossRoadPort = vCrossRoadPort
        CrossRoadLatLon = vCrossRoadLatLon

        CrossRoadCenter = CrossRoadLatLon 'CrossRoadCenter

        CrossRoad_isMaster = vCrossRoad_isMaster
        CrossRoad_IC_Addr = vCrossRoad_IC_Addr
    End Sub
End Class
Public Class Class_TriggerPoint
    Public CrossRoadID As String
    Public TriggerPointID As String
    Public Direct As String
    Public TriggerPointOrder As String
    Public TriggerLatLon As String
    Public PointType As String
    Public StopLineLatLon As String

    Sub New(ByVal vCrossRoadID As String, ByVal vTriggerPointID As String, ByVal vDirect As String,
            ByVal vTriggerPointOrder As String, ByVal vTriggerLatLon As String, ByVal vPointType As String, vStopLineLatLon As String)
        CrossRoadID = vCrossRoadID
        TriggerPointID = vTriggerPointID
        Direct = vDirect
        TriggerPointOrder = vTriggerPointOrder
        TriggerLatLon = vTriggerLatLon
        PointType = vPointType
        StopLineLatLon = vStopLineLatLon
        
    End Sub

    '*********************************************************
    '**
    '** LinkedList structure
    '**
    '*********************************************************
 
End Class
Public Class Class_5FCC
    Public Current_SubPhaseID As String
    Public Current_StepID As String
    Public Current_RemainingTime As String
    Public Current_RemainingInt As String
    Sub New(ByVal SubPhaseID As String, ByVal StepID As String, ByVal RemainingTime As String)
        Current_SubPhaseID = SubPhaseID
        Current_StepID = StepID
        Current_RemainingTime = RemainingTime
        Current_RemainingInt = HexStringTOIntString(RemainingTime, 4)
    End Sub

End Class
Public Class Class_Refund
    Public Phase1 As String
    Public Phase2 As String
    Public Phase3 As String
    Public Phase4 As String
    Public Phase5 As String
    Public Phase6 As String
    Public Phase7 As String
    Public Phase8 As String
    Public Phase As String()
    Sub New(ByVal RecDataString As String())

        Phase1 = RecDataString(0)
        Phase2 = RecDataString(1)
        Phase3 = RecDataString(2)
        Phase4 = RecDataString(3)
        Phase5 = RecDataString(4)
        Phase6 = RecDataString(5)
        Phase7 = RecDataString(6)
        Phase8 = RecDataString(7)


    End Sub
End Class
Public Class Class_BusData
    Public Strategy_GroupID As String
    Public Strategy_CrossRoadID As String
    Public Strategy_BusLineID As String
    Public Strategy_Direct As String
    Public Strategy_BusID As String


    'Public Strategy_P2Time As String
    'Public Strategy_BusWaySubPhaseID As String
    'Public Strategy_BusStrategy As String
    'Public Strategy_BusWayReachSec As String
    'Public Strategy_P1Time As String
    'Public Strategy_P3Time As String
    'Public Strategy_orgGreen As String()
    'Public Strategy_newGreen As String()
    Sub New(ByVal GroupID As String, ByVal CrossRoadID As String, ByVal BusLineID As String, ByVal Direct As String, ByVal BusID As String)

        Strategy_GroupID = GroupID
        Strategy_CrossRoadID = CrossRoadID
        Strategy_BusLineID = BusLineID
        Strategy_Direct = Direct
        Strategy_BusID = BusID

    End Sub

End Class


