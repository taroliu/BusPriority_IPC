Imports System.Net.Sockets
Imports System.Threading

Imports System.Net
Imports System.IO.Ports
Imports System.Text

Module Module_Comm
    Dim writeThread As Thread
    Dim readThread As Thread

    '*********************************************************
    '**
    '** Delegate
    '**
    '*********************************************************
    Private m_mainForm As BusPriority_IPC.MainForm

    Public Property _mainForm As BusPriority_IPC.MainForm
        Get
            Return m_mainForm
        End Get
        Set(ByVal value As BusPriority_IPC.MainForm)
            m_mainForm = value
        End Set
    End Property


    '************************************************************************************************
    '** 
    '** Serial Create(號誌控制器)
    '**
    '************************************************************************************************
    Public mySerialPort As New SerialPort
    Public Function OpenSerialPort() As Boolean
        Try
            mySerialPort.PortName = SERIAL_COMPortName
            mySerialPort.BaudRate = SERIAL_Baudrate         'Set Baud rate to the selected value on

            Select Case Trim(SERIAL_Parity)
                Case "None"
                    mySerialPort.Parity = IO.Ports.Parity.None
                Case "Odd"
                    mySerialPort.Parity = IO.Ports.Parity.Odd
                Case "Even"
                    mySerialPort.Parity = IO.Ports.Parity.Even
                Case "Mark"
                    mySerialPort.Parity = IO.Ports.Parity.Mark
                Case "Space"
                    mySerialPort.Parity = IO.Ports.Parity.Space
            End Select
            Select Case Trim(SERIAL_Stopbits)
                Case "None"
                    mySerialPort.StopBits = IO.Ports.StopBits.None
                Case "One"
                    mySerialPort.StopBits = IO.Ports.StopBits.One
                Case "Two"
                    mySerialPort.StopBits = IO.Ports.StopBits.Two
                Case "OnePointFive"
                    mySerialPort.StopBits = IO.Ports.StopBits.OnePointFive
            End Select
            mySerialPort.DataBits = 8            'Open our serial port
            AddHandler mySerialPort.DataReceived, AddressOf DataReceivedHandler

            mySerialPort.Open()
            _mainForm.Show_Lab_ComStatus_IC("1" + SERIAL_COMPortName)
            Return True
        Catch ex As Exception
            _mainForm.Show_Lab_ComStatus_IC("0" + SERIAL_COMPortName)
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Comm", "OpenSerialPort Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return False
        End Try
    End Function
    Public complete_5F48_AutoDownload As Integer = 0
    Private Sub DataReceivedHandler(sender As Object, e As SerialDataReceivedEventArgs)
        RecByte2()
        Dim complishPacket As String
        Try
            While True
                Thread.Sleep(20)
                complishPacket = getComplishPacket()
                If complishPacket <> "" Then
                    _mainForm.Show_LBox_ReceivedText_IC("[R<--IC] " + complishPacket)
                    Dim SendString As String = complishPacket
                    Dim exitflag As Boolean
                    Do
                        exitflag = False
                        If SendString.Substring(0, 4) = "AADD" Then
                            If _ConnectFlag_CC Or _ConnectFlag_ATMS Then
                                '如果為IPC定時查詢,則不回報CC
                                Dim seqNumber As Integer = Val(HexStringTOIntString(SendString.Substring(4, 2), 2))
                                If seqNumber <> KeepSeqNumbe_5F48 And seqNumber <> KeepSeqNumbe_5F43 And seqNumber <> KeepSeqNumbe_5F44 And seqNumber <> KeepSeqNumbe_5F45 Then
                                    If _ConnectFlag_CC Then
                                        Socket_WriteToCC(StrToByteArray2(SendString.Substring(0, 16)))
                                    End If
                                    If _ConnectFlag_ATMS Then
                                        Socket_WriteToATMS(StrToByteArray2(SendString.Substring(0, 16)))
                                    End If
                                End If

                            End If
                           
                            SendString = SendString.Substring(16, SendString.Length - 16)
                            exitflag = True
                        End If

                        If SendString.Substring(0, 4) = "AAEE" Then
                            If _ConnectFlag_CC Or _ConnectFlag_ATMS Then
                                Dim seqNumber As Integer = Val(HexStringTOIntString(SendString.Substring(4, 2), 2))
                                If seqNumber <> KeepSeqNumbe_5F48 And seqNumber <> KeepSeqNumbe_5F43 And seqNumber <> KeepSeqNumbe_5F44 And seqNumber <> KeepSeqNumbe_5F45 Then
                                    If _ConnectFlag_CC Then
                                        Socket_WriteToCC(StrToByteArray2(SendString.Substring(0, 18)))
                                    End If
                                    If _ConnectFlag_ATMS Then
                                        Socket_WriteToATMS(StrToByteArray2(SendString.Substring(0, 18)))
                                    End If
                                End If
                            End If
                          
                            SendString = SendString.Substring(18, SendString.Length - 18)
                            exitflag = True
                        End If
                        If Not exitflag Then
                            Exit Do
                        End If
                    Loop

                    If SendString.Substring(0, 4) = "AABB" Then
                        SaveDataFunction(SendString) 'Save Data Struct
                        If _ConnectFlag_CC Or _ConnectFlag_ATMS Then
                            Dim recHeadstr As String = SendString.Substring(14, 4)
                            Dim recSeqint As Integer = Val(HexStringTOIntString(SendString.Substring(4, 2), 2))
                            Dim isReport2CC As Boolean = True
                            '如果為IPC定時查詢,則不回報CC
                            Select Case recHeadstr
                                Case "0F04"
                                    HardWareStatusFrom0F04 = SendString.Substring(18, 4)
                                Case "5FC3"
                                    If recSeqint = KeepSeqNumbe_5F43 Then
                                        isReport2CC = False
                                        KeepSeqNumbe_5F43 = -1
                                    End If
                                Case "5FC4"
                                    If recSeqint = KeepSeqNumbe_5F44 Then
                                        isReport2CC = False
                                        KeepSeqNumbe_5F44 = -1
                                    End If
                                Case "5FC5"
                                    If recSeqint = KeepSeqNumbe_5F45 Then
                                        isReport2CC = False
                                        KeepSeqNumbe_5F45 = -1
                                    End If
                                Case "5FC8"
                                    If recSeqint = KeepSeqNumbe_5F48 Then
                                        isReport2CC = False
                                        KeepSeqNumbe_5F48 = -1
                                        complete_5F48_AutoDownload = 1

                                        If Current_Planid Is Nothing Then
                                            Current_Planid = Data_5F18.PlanID
                                            _mainForm.Show_LBox_PolicyRightNowText("New Planid")
                                            Changed_Planid = False
                                        ElseIf Current_Planid <> Data_5F18.PlanID Then
                                            _mainForm.Show_LBox_PolicyRightNowText("Changed Planid")
                                            Current_Planid = Data_5F18.PlanID
                                            Changed_Planid = True
                                        Else
                                            _mainForm.Show_LBox_PolicyRightNowText("Old Planid")
                                            Changed_Planid = False
                                        End If

                                    End If
                            End Select

                            If isReport2CC Then
                                If _ConnectFlag_CC Then
                                    Socket_WriteToCC(StrToByteArray2(SendString))
                                End If
                                If _ConnectFlag_ATMS Then
                                    Socket_WriteToATMS(StrToByteArray2(SendString))
                                End If
                            End If
                        End If
                        'SaveDataFunction(SendString) 'Save Data Struct
                    End If

                    '收到完整封包回ACK
                    'S------------------------------------------------------------------------------
                    Dim ack_seq As String = SendString.Substring(4, 2)
                    Dim sendByte2 As Byte() = Incode_Step1(Val(HexStringTOIntString(ack_seq, 2)), "ACK")
                    'E------------------------------------------------------------------------------
                    '處理步階解析及顯示
                    'S------------------------------------------------------------------------------
                    Dim recstr As String = SendString.Substring(14, 4)
                    If recstr = "5F03" Then
                        If SendString.Length > 32 Then
                            NowSingalMap = SendString.Substring(20, 2)
                            NowSubPhaseIDstring = SendString.Substring(24, 2)
                            NowStepIDstring = SendString.Substring(26, 2)
                            NowStepSec = SendString.Substring(28, 4)
                            NowSignalStatusString = SendString.Substring(32, SendString.Length - 38)
                        End If
                    End If
                    'E------------------------------------------------------------------------------

                    'For Refund sequence 
                    'Try
                    '    If NowSubPhaseIDstring <> LastSubPhaseIDstring2 And Data_5FCC.Current_StepID = "01" Then 'needs another flag start checkinh after decision point
                    '        _mainForm.Show_LBox_PolicyRightNowText("Check Refund ")

                    '        _mainForm.Show_LBox_PolicyRightNowText("Original Settings PhaseID " + NowSubPhaseIDstring + " StepID " + NowStepIDstring + "  Seconds " + HexStringTOIntString(NowStepSec, 4))

                    '        If Original_Step_One.ContainsKey(NowSubPhaseIDstring) = False Then
                    '            Original_Step_One.Add(NowSubPhaseIDstring, HexStringTOIntString(NowStepSec, 4))
                    '        ElseIf Original_Step_One.ContainsKey(NowSubPhaseIDstring) = True Then

                    '            If Original_Step_One(NowSubPhaseIDstring) = HexStringTOIntString(NowStepSec, 4) Then

                    '            Else
                    '                _mainForm.Show_LBox_PolicyRightNowText("Original Changed Original = " + Original_Step_One(NowSubPhaseIDstring) + " Current = " + HexStringTOIntString(NowStepSec, 4))
                    '                Original_Step_One.Remove(NowSubPhaseIDstring)
                    '                Original_Step_One.Add(NowSubPhaseIDstring, HexStringTOIntString(NowStepSec, 4))
                    '            End If


                    '        End If



                    '        If Data_5FCC.Current_StepID = "01" Then
                    '            _mainForm.Show_LBox_PolicyRightNowText(" PayBack checking step 1 NowPhase " + Data_5FCC.Current_SubPhaseID + " NowStep " + Data_5FCC.Current_StepID + " RemaingTime " + Data_5FCC.Current_RemainingInt)
                    '            _mainForm.Show_LBox_PolicyRightNowText(" Current Phase " + NowSubPhaseIDstring + " Time " + HexStringTOIntString(NowStepSec, 4) + " Target Phase " + Data_5FCC.Current_SubPhaseID + " Time " + Data_5FCC.Current_RemainingInt)
                    '            If Data_5FCC.Current_RemainingInt <> HexStringTOIntString(NowStepSec, 4) And Data_5FCC.Current_SubPhaseID = NowSubPhaseIDstring And Data_5FCC.Current_StepID = NowStepIDstring Then

                    '                _mainForm.Show_LBox_PolicyRightNowText("Needs Refund !!!")
                    '                If Data_5FCC.Current_RemainingInt > HexStringTOIntString(NowStepSec, 4) Then
                    '                    _mainForm.Show_LBox_PolicyRightNowText("  Reduction Needed ")


                    '                Else
                    '                    _mainForm.Show_LBox_PolicyRightNowText("Extention Needed")



                    '                End If

                    '                If BusInPlay = False Then
                    '                    RefundSwitch = True

                    '                End If


                    '            Else
                    '                _mainForm.Show_LBox_PolicyRightNowText(" Doesn't need Refund Current " + Data_5FCC.Current_RemainingInt + "  Original " + HexStringTOIntString(NowStepSec, 4))

                    '            End If

                    '        End If

                    '        LastSubPhaseIDstring2 = NowSubPhaseIDstring

                    '    End If

                    'Catch ex As Exception
                    '    _mainForm.Show_LBox_PolicyRightNowText(ex.ToString)
                    'End Try

                    ' For Bus phase commands 
                    Try
                        If NowSubPhaseIDstring <> LastSubPhaseIDstring Then
                            'Command("5F1C" + NowSubPhaseIDstring + "00" + RemainHex)

                            Try

                                If Phase_Commands.ContainsKey(NowSubPhaseIDstring) Then
                                    _mainForm.Show_LBox_PolicyRightNowText("傳送 5F1C  " + Phase_Commands(NowSubPhaseIDstring))

                                    Command(Phase_Commands(NowSubPhaseIDstring))
                                End If


                            Catch ex As Exception
                                _mainForm.Show_LBox_PolicyRightNowText("Error in phase Commands" + ex.ToString)
                            End Try

                            'If Not String.IsNullOrEmpty(Phase_Commands(NowSubPhaseIDstring)) Then

                            '    ' bus commands that can't be casted immediately are casted at the beginning of each phase

                            '    'Command("5F1C" + All_Phases(index) + "00" + Microggstr(index))

                            'End If
                            LastSubPhaseIDstring = NowSubPhaseIDstring

                        End If


                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText(ex.ToString)
                    End Try

                   

                    


                    '_mainForm.Show_LBox_PolicyRightNowText("Last Phase  " + LastSubPhaseIDstring.ToString)

                    mySerialPort.Write(sendByte2, 0, sendByte2.Length)

                Else
                    Exit While
                End If
            End While
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "MainForm", "SerialPort_DataReceived Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    Public Sub RecByte2()
        Dim bRead, nRead As Integer
        bRead = mySerialPort.BytesToRead
        Dim cData(bRead - 1) As Byte
        mySerialPort.ReadTimeout = 1000

        nRead = mySerialPort.Read(cData, 0, bRead) 'Reading the Data
        'WriteLog(curPath, "SerialComm", "[Read] " + ByteArrayToStr2(cData), _logEnable)
        InsertAcceptPoolArray(cData, bRead)
    End Sub
    '************************************************************************************************
    '**
    '** SOCKET Create(中心端) UDP
    '**
    '************************************************************************************************
    Public ServerUDP_Socket As UdpClient
    Public ServerUDP_Socket_Send As UdpClient 'Jason 20150322 UDP CC
    Public _ConnectFlag_CC As Boolean = False
 
    Public Sub OpenCC_Com()
        Try
            Dim RemoteIpEndPoint_Send As IPEndPoint = New IPEndPoint(IPAddress.Parse(IP_CC), Val(PORT_CC_Send)) 'Jason 20150322 UDP CC
            ServerUDP_Socket_Send = New UdpClient() 'Jason 20150322 UDP CC
            ServerUDP_Socket_Send.Connect(RemoteIpEndPoint_Send) 'Jason 20150322 UDP CC
            writeThread = New Thread(AddressOf UDP_ReceiveData)
            writeThread.Name = "CC_thead"
            writeThread.IsBackground = True
            writeThread.Priority = ThreadPriority.Highest '20130328_重啟造成當機_1 提高SOCKET的優先權
            writeThread.Start()
        Catch ex As Exception
            WriteLog(curPath, "Module_Comm", "  OpenCC_Com Catch:" + ex.Message, _logEnable)
        End Try
    End Sub

   
    Public Sub UDP_ReceiveData()
        Try
            Dim InBytesCount As Integer = 0
            Dim myReceiveBytes(1023) As Byte
            Dim i As Integer = 0
            ServerUDP_Socket = New UdpClient()

            Dim RemoteIpEndPoint As IPEndPoint = New IPEndPoint(IPAddress.Any, Val(PORT_CC_Receive))

            ServerUDP_Socket.Client.Bind(RemoteIpEndPoint)
            _mainForm.Show_Lab_ComStatus_CC("1")
            _ConnectFlag_CC = True

            While True
                Array.Clear(myReceiveBytes, 0, myReceiveBytes.Length)
                myReceiveBytes = ServerUDP_Socket.Receive(RemoteIpEndPoint)
                System.Threading.Thread.Sleep(100)
                'Dim RecString As String = ByteArrayToStr2(myReceiveBytes)

                Dim SendString As String = ByteArrayToStr2(myReceiveBytes) '.Substring(0, 2 * InBytesCount)
                _mainForm.Show_LBox_ReceivedText_CC("[R<--CC] " + SendString)
                If SendString.Substring(0, 4) = "AABB" Then
                    If isDisablePolicyCommand(SendString) Then
                        If SendString.Substring(20, 2) = "FF" Then
                            isEnableBusPriority = False
                        Else
                            isEnableBusPriority = True
                        End If
                        ResponeUserDefineFunction(SendString)
                    Else
                        If SaveDataFunction(SendString) Then 'Save Data Struct 
                            ResponeUserDefineFunction(SendString)
                        End If
                        Thread.Sleep(50)
                        If SendString.Substring(14, 3) <> "5F8" And SendString.Substring(14, 3) <> "5F9" Then
                            _mainForm.send_IC(myReceiveBytes)
                        End If
                    End If
                End If

            End While
        Catch ex As Exception
            _mainForm.Show_Lab_ComStatus_CC("0")
            _ConnectFlag_CC = False

            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Comm", "ReceiveData Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    Public Sub UDP_WriteToCC(ByVal sendData As Byte())
        Try
            'Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Parse(IP_CC), Val(PORT_CC_Send))  ' two lines needs checking
            'ServerUDP_Socket.Connect(IP_CC, PORT_CC_Send) 'jason 20140808 two lines needs checking
            ServerUDP_Socket_Send.Send(sendData, sendData.Length) 'Jason 20150322 UDP CC

        Catch ex As Exception
            WriteLog(curPath, "Module_Command", "  send Catch:" + ex.Message, True)
        End Try
    End Sub
    Public Sub Socket_WriteToCC(ByVal writeData() As Byte)
        Try
            UDP_WriteToCC(writeData)
            _mainForm.Show_LBox_ReceivedText_CC("[w-->CC] " + ByteArrayToStr2(writeData))
        Catch ex As Exception
            WriteLog(curPath, "Module_Comm", "  Socket_WriteToCC Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    '************************************************************************************************
    '**
    '** 中心端- UDP - 運作
    '**
    '************************************************************************************************
    'jason 20150413 查詢回報公車優先啟動狀態
    'S-----------------------------------------------------------------------
    Public SystemRuningState As String = "關閉"
    Public Sub ReturnBusPriorityRuningState(ByVal RebackType As String)
        Try
            If RebackType = "1" Then '查詢回報
                Dim isSystemRuning As String = "00"
                If _mainForm.Label_BusPrimEnable.Text = "啟動" Then
                    isSystemRuning = "01"
                End If
                Dim sendByte As Byte() = Incode_Step1(getSeqNum(), MarkAACommand("5FA001" + isSystemRuning))
                Socket_WriteToCC(sendByte)
            Else '主動回報
                If _mainForm.Label_BusPrimEnable.Text <> SystemRuningState Then
                    SystemRuningState = _mainForm.Label_BusPrimEnable.Text

                    Dim isSystemRuning As String = "00"
                    If _mainForm.Label_BusPrimEnable.Text = "啟動" Then
                        isSystemRuning = "01"
                    End If
                    Dim sendByte As Byte() = Incode_Step1(getSeqNum(), MarkAACommand("5FB001" + isSystemRuning))
                    Socket_WriteToCC(sendByte)
                End If
            End If

        Catch ex As Exception
            WriteLog(curPath, "Module_Comm", "  ReturnBusPriorityRuningState Catch:" + ex.Message, _logEnable)
        End Try
    End Sub

    'E-----------------------------------------------------------------------
    'IPC收到新的協定,要做ACK和NAK,0F80和0F81檢查
    Public Sub ResponeUserDefineFunction(ByVal SaveString As String)
        Try
            Dim SaveCode As String = SaveString.Substring(14, 4)
            If SaveCode = "5F10" Or SaveCode = "5F81" Or SaveCode = "5F82" Or SaveCode = "5F83" Or SaveCode = "5F85" Or SaveCode = "5F86" Then
                If isResponeUserDefine_ACK(SaveString) Then
                    isResponeUserDefine_0F80(SaveString)
                End If
            ElseIf SaveCode = "5F91" Or SaveCode = "5F92" Or SaveCode = "5F93" Or SaveCode = "5F96" Then
                If isResponeUserDefine_ACK(SaveString) Then
                    '<補>?????????????從擷取資訊內容回報
                End If
            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Command", "ResponeUserDefineFunction Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Function isResponeUserDefine_ACK(ByVal SaveString As String) As Boolean
        Dim acceptByteArray As Byte() = StrToByteArray2(SaveString)
        Try

            '1:核對位元錯誤
            'InCRC(acceptByteArray, acceptByteArray.Length - 1) ' jason test
            If Not isCRC(acceptByteArray, acceptByteArray.Length) Then
                Dim SendNakString() As Byte = {&HAA, &HEE, acceptByteArray(2), acceptByteArray(3), acceptByteArray(4), &H0, &H9, &H1, &H0}
                InCRC(SendNakString, 8)
                Socket_WriteToCC(SendNakString)
                Return False
            End If
            '2:碼框錯誤
            If acceptByteArray(0) <> &HAA Or acceptByteArray(1) <> &HBB Or acceptByteArray(acceptByteArray.Length - 3) <> &HAA Or acceptByteArray(acceptByteArray.Length - 2) <> &HCC Then
                Dim SendNakString() As Byte = {&HAA, &HEE, acceptByteArray(2), acceptByteArray(3), acceptByteArray(4), &H0, &H9, &H2, &H0}
                InCRC(SendNakString, 8)
                Socket_WriteToCC(SendNakString)
                Return False
            End If
            '4:位址錯誤
            Dim AddrString As String = SaveString.Substring(6, 4)
            Dim EquipID As String
            If DB_ACCESS_ENABLE = "1" Then
                EquipID = COMMON_EquipID
            Else
                EquipID = DB_ACCESS_DISABLE_DEVICEID
            End If
            If AddrString <> EquipID Then   'COMMON_EquipID -->BusPriority_daemon
                Dim SendNakString() As Byte = {&HAA, &HEE, acceptByteArray(2), acceptByteArray(3), acceptByteArray(4), &H0, &H9, &H4, &H0}
                InCRC(SendNakString, 8)
                Socket_WriteToCC(SendNakString)
                Return False
            End If
            '8:長度錯誤
            If Not CheckLEN(acceptByteArray, acceptByteArray.Length) Then
                Dim SendNakString() As Byte = {&HAA, &HEE, acceptByteArray(2), acceptByteArray(3), acceptByteArray(4), &H0, &H9, &H8, &H0}
                InCRC(SendNakString, 8)
                Socket_WriteToCC(SendNakString)
                Return False
            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Command", "ResponeUserDefine_isACK Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return False
        End Try
        Dim SendACKString() As Byte = {&HAA, &HDD, acceptByteArray(2), acceptByteArray(3), acceptByteArray(4), &H0, &H8, &H0}
        InCRC(SendACKString, 7)
        Socket_WriteToCC(SendACKString)
        Return True
    End Function
    Public Sub isResponeUserDefine_0F80(ByVal SaveString As String)
        Try
            '檢查每一個新增定,有範圍的參數是否有誤
            Dim acceptByteArray As Byte() = StrToByteArray2(SaveString)
            Dim SaveCode As String = SaveString.Substring(14, 4)
            Dim _0F80_success As Boolean = True
            Dim _0F81_failtype As Integer = 0
            Dim _0F81_failParam As Byte = &H0
            Select Case SaveCode
                Case "5F81" '觸動點管理
                    Dim iTriggerCount As Integer = Val(SaveString.Substring(38, 2))
                    Dim pp As Integer = ((iTriggerCount - 1) * 17 + 40) * 2
                    If ((iTriggerCount - 1) * 17 + 40) * 2 <> SaveString.Length Then 'bit 3 :總數有誤
                        _0F81_failtype = 3 'bit 3 is true
                        _0F80_success = False
                    Else 'bit 2 :參數值有誤-->direct
                        For i As Integer = 0 To iTriggerCount - 1
                            Dim iDirect As Integer = Val(SaveString.Substring(52 + i * 34, 2))
                            If iDirect < 1 Or iDirect > 7 Then
                                _0F81_failtype = 2 'bit 2 is true
                                Dim posdirect As Integer = 24 + 17 * i + 7
                                _0F81_failParam = CByte(posdirect)
                                _0F80_success = False
                                Exit For
                            End If
                        Next i
                    End If
                Case "5F91"

                Case "5F82" '設定公車一般時段
                    'Sum Number
                    Dim iSegmentCount As Integer = acceptByteArray(10)
                    Dim iNumWeekDayt As Integer = acceptByteArray(10 + 2 * iSegmentCount + 1)
                    Dim totalLength_ByInfo As Integer = 15 + iSegmentCount * 2 + iNumWeekDayt + iSegmentCount * iNumWeekDayt
                    If totalLength_ByInfo <> acceptByteArray.Length Then
                        _0F81_failtype = 3 'bit 3 is true
                        _0F80_success = False
                        Exit Select
                    End If

                    'SegmentType
                    If acceptByteArray(9) < 1 Or acceptByteArray(9) > 7 Then
                        _0F81_failtype = 2 'bit 2 is true
                        _0F81_failParam = &H9
                        _0F80_success = False
                        Exit Select
                    End If
                    'SegmentCount 1~32
                    If acceptByteArray(10) < 1 Or acceptByteArray(10) > 32 Then
                        _0F81_failtype = 2 'bit 2 is true
                        _0F81_failParam = &HA
                        _0F80_success = False
                        Exit Select
                    End If

                    'Hour-Min-Enable
                    For i As Integer = 0 To acceptByteArray(10) - 1
                        If acceptByteArray(i * 2 + 11) < 0 Or acceptByteArray(i * 2 + 11) > 23 Then
                            _0F81_failtype = 2 'bit 2 is true
                            _0F81_failParam = CByte(i * 2 + 11)
                            _0F80_success = False
                            Exit Select
                        End If
                        If acceptByteArray(i * 2 + 12) < 0 Or acceptByteArray(i * 2 + 12) > 59 Then
                            _0F81_failtype = 2 'bit 2 is true
                            _0F81_failParam = CByte(i * 2 + 12)
                            _0F80_success = False
                            Exit Select
                        End If
                    Next i
                    'NumWeekDay 1~14
                    If acceptByteArray(11 + acceptByteArray(10) * 2) < 1 Or acceptByteArray(11 + acceptByteArray(10) * 2) > 14 Then
                        _0F81_failtype = 2 'bit 2 is true
                        _0F81_failParam = CByte(11 + acceptByteArray(10) * 2)
                        _0F80_success = False
                        Exit Select
                    End If
                    'WeekDay
                    For i As Integer = 0 To acceptByteArray(11 + acceptByteArray(10) * 2) - 1
                        If Not ((acceptByteArray(12 + acceptByteArray(10) * 2 + i) > 0 And acceptByteArray(12 + acceptByteArray(10) * 2 + i) < 8) Or
                            (acceptByteArray(12 + acceptByteArray(10) * 2 + i) > 10 And acceptByteArray(12 + acceptByteArray(10) * 2 + i) < 18)) Then
                            _0F81_failtype = 2 'bit 2 is true
                            _0F81_failParam = CByte(12 + acceptByteArray(10) * 3 + i)
                            _0F80_success = False
                        End If
                    Next i
                Case "5F92"
                    _0F81_failtype = 0 'bit 0 is true
                    _0F81_failParam = &H0
                    _0F80_success = False
                    Exit Select
                Case "5F83"
                    _0F81_failtype = 0 'bit 0 is true
                    _0F81_failParam = &H0
                    _0F80_success = False
                    Exit Select
                Case "5F93"
                    _0F81_failtype = 0 'bit 0 is true
                    _0F81_failParam = &H0
                    _0F80_success = False
                    Exit Select
                Case "5F85"
                    _0F81_failtype = 0 'bit 0 is true
                    _0F81_failParam = &H0
                    _0F80_success = False
                    Exit Select
                Case "5F86"
                    _0F81_failtype = 0 'bit 0 is true
                    _0F81_failParam = &H0
                    _0F80_success = False
                    Exit Select
                Case "5F96"
                    _0F81_failtype = 0 'bit 0 is true
                    _0F81_failParam = &H0
                    _0F80_success = False
                    Exit Select
            End Select

            If _0F80_success Then
                Dim Send0F80Byte() As Byte = {&HAA, &HBB, acceptByteArray(2), acceptByteArray(3), acceptByteArray(4), &H0, &HF,
                                              &HF, &H80, acceptByteArray(7), acceptByteArray(8),
                                              &HAA, &HCC, &H0}
                InCRC(Send0F80Byte, 13)
                Socket_WriteToCC(Send0F80Byte)
            Else
                Dim Send0F81Byte As Byte() = {}
                Select Case _0F81_failtype
                    Case 0
                        Send0F81Byte = {&HAA, &HBB, acceptByteArray(2), acceptByteArray(3), acceptByteArray(4), &H0, &HF,
                                                      &HF, &H81, acceptByteArray(7), acceptByteArray(8), &H1, &H0,
                                                      &HAA, &HCC, &H0}
                    Case 2
                        Send0F81Byte = {&HAA, &HBB, acceptByteArray(2), acceptByteArray(3), acceptByteArray(4), &H0, &HF,
                                                      &HF, &H81, acceptByteArray(7), acceptByteArray(8), &H4, _0F81_failParam,
                                                      &HAA, &HCC, &H0}
                    Case 3
                        Send0F81Byte = {&HAA, &HBB, acceptByteArray(2), acceptByteArray(3), acceptByteArray(4), &H0, &HF,
                                                      &HF, &H81, acceptByteArray(7), acceptByteArray(8), &H8, &H0,
                                                      &HAA, &HCC, &H0}
                End Select
                InCRC(Send0F81Byte, 15)
                Socket_WriteToCC(Send0F81Byte)
            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Command", "ResponeUserDefine_is0F80 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Function CheckLEN(ByVal recbuf As Byte(), ByVal reclen As Integer) As Boolean
        Try
            If reclen = (Convert.ToInt32(recbuf(5)) * 256 + Convert.ToInt32(recbuf(6))) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            WriteLog(curPath, "Module_Command", ByteArrayToStr2(recbuf) + "  CheckLEN Catch:" + ex.Message, _logEnable)
            Return False
        End Try
    End Function
    Function isCRC(ByVal recbuf As Byte(), ByVal reclen As Integer) As Boolean
        Try
            Dim array() As Byte = recbuf
            Dim cc As Byte = &H0
            For i As Integer = 0 To reclen - 1
                If i = reclen - 1 Then
                    If cc = array(i) Then
                        Return True
                    Else
                        Return False
                    End If
                End If
                cc = cc Xor array(i)
            Next i
            Return True
        Catch ex As Exception
            WriteLog(curPath, "Module_Command", ByteArrayToStr2(recbuf) + "  isCRC Catch:" + ex.Message, _logEnable)
            Return False
        End Try
    End Function

 

    '************************************************************************************************
    '**
    '** SOCKET Create(車機端)--TCP Client
    '**
    '************************************************************************************************
    Public Sub OpenCar_Com()
        Try

            writeThread = New Thread(AddressOf th_startCar_TCP_ClientConnect)
            writeThread.Name = "CAR_thead"
            writeThread.IsBackground = True
            writeThread.Priority = ThreadPriority.Highest '20130328_重啟造成當機_1 提高SOCKET的優先權
            writeThread.Start()

        Catch ex As Exception
            WriteLog(curPath, "Module_Comm", "  OpenCar_Com Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    Public RemoteIpEndPoint_Car As IPEndPoint
    Public myTcpClient_Car As TcpClient
    Public _ConnectFlag_Car As Boolean = False
    Public _ServerConnectFlag_Car As Boolean = False
    Public Sub th_startCar_TCP_ClientConnect()
        Try

            'Dim myTcpClient As TcpClient
            Dim myIPEndPoint As New IPEndPoint(IPAddress.Any, 0)
            Dim myNetworkStream As NetworkStream
            Dim Buffsize As Integer = 300  'Jason 20140923
            Dim InBytesLength As Integer = 0
            Dim myReceiveBytes(Buffsize) As Byte
            myTcpClient_Car = New TcpClient(myIPEndPoint)
            RemoteIpEndPoint_Car = New IPEndPoint(IPAddress.Parse(IP_CAR), Val(PORT_CAR))
            myTcpClient_Car.Connect(RemoteIpEndPoint_Car)
            If myTcpClient_Car.Client.Connected Then
                _ConnectFlag_Car = True
                _ServerConnectFlag_Car = True
                _mainForm.Show_Lab_ComStatus_Car("1")

                myNetworkStream = myTcpClient_Car.GetStream()
                Do
                    Array.Clear(myReceiveBytes, 0, myReceiveBytes.Length)
                    myNetworkStream.Read(myReceiveBytes, 0, myReceiveBytes.Length)
                    'Jason 20140923
                    'S-------------------------------------------------------------------------
                    If myReceiveBytes(0) = &H0 Then
                        _ConnectFlag_Car = False
                        _mainForm.Show_Lab_ComStatus_Car("0")
                        Exit Do
                    End If
                    'E-------------------------------------------------------------------------
                    Thread.Sleep(200)
                    Dim recFromCarData As String = Encoding.ASCII.GetString(myReceiveBytes, 0, myReceiveBytes.Length)
                    SaveDataFunction_Car(recFromCarData.Split(","))
                    '_mainForm.Show_LBox_PolicyRightNowText("CarComm " + recFromCarData.ToString)
                    _mainForm.Show_LBox_ReceivedText_CAR("[R<--Bus] " + recFromCarData)
                Loop

            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Comm", "th_startCar_TCP_ClientConnect Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            _ConnectFlag_Car = False
            _mainForm.Show_Lab_ComStatus_Car("0")
        End Try
    End Sub
    Public Sub TCP_ClientWriteToCAR(ByVal sendbyte As String)
        Try
            Dim bytesSent As [Byte]() = Encoding.ASCII.GetBytes(Trim(sendbyte))
            Dim myNetworkStream As NetworkStream
            myNetworkStream = myTcpClient_Car.GetStream()

            myNetworkStream.Write(bytesSent, 0, bytesSent.Length)
            myNetworkStream.Flush()
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Comm", "TCP_ClientWriteToCAR Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try

    End Sub
    '************************************************************************************************
    '**
    '** SOCKET Create(交控中心)--TCP listen
    '**
    '************************************************************************************************
    Public _ConnectFlag_ATMS As Boolean = False
    Public _ConnectFlag_ATMS_Accept As Boolean = False
    Public myTcpListener As TcpListener
    Public myClientNetworkStream As NetworkStream
    Private Class CSState
        Public myTcpListener As TcpListener
        Public ClientSocket As Socket
        Public mystring As String

    End Class
    Public Sub OpenATMS_Com()
        Try

            writeThread = New Thread(AddressOf th_startTCP_ATMSConnect)
            writeThread.Name = "ATMS_thead"
            writeThread.IsBackground = True
            writeThread.Priority = ThreadPriority.Highest '20130328_重啟造成當機_1 提高SOCKET的優先權
            writeThread.Start()
        Catch ex As Exception
            WriteLog(curPath, "Module_Comm", "  OpenATMS_Com Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub th_startTCP_ATMSConnect()
        Try
            Dim ClientSocket As Socket
            myTcpListener = New TcpListener(IPAddress.Any, Val(PORT_ATMS_Receive))
            myTcpListener.Start()
            Dim iCount As Integer = 0
            _ConnectFlag_ATMS = False
            Do
                _ConnectFlag_ATMS_Accept = True
                ClientSocket = myTcpListener.AcceptSocket()
                _ConnectFlag_ATMS_Accept = False
                If ClientSocket.Connected = True Then
                    _ConnectFlag_ATMS = True
                    _mainForm.Show_Lab_ComStatus_ATMS("1")
                    Dim myObj As New CSState
                    myObj.myTcpListener = myTcpListener
                    myObj.ClientSocket = ClientSocket
                    myObj.mystring = Now.ToString("yyyy/MM/dd HH:mm:ss") & "已連線"

                    Dim ReceiveThread As New Thread(AddressOf ATMS_ReceiveData)
                    ReceiveThread.IsBackground = True
                    ReceiveThread.Start(myObj)
                    iCount += 1
                End If
            Loop
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Comm", "th_startTCP_ATMSConnect Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            _ConnectFlag_ATMS = False
            _mainForm.Show_Lab_ComStatus_ATMS("0")
        End Try
    End Sub
    Private Sub ATMS_ReceiveData(ByVal state As Object)
        Dim myObj As New CSState
        myObj.ClientSocket = CType(state, CSState).ClientSocket
        myObj.myTcpListener = CType(state, CSState).myTcpListener
        myObj.mystring = ""

        myClientNetworkStream = New NetworkStream(myObj.ClientSocket)
        Dim InBytesCount As Integer = 0
        Dim myReceiveBytes(1023) As Byte
        Dim i As Integer = 0
        'Dim myBytes As Byte()
        While True
            Try
                Array.Clear(myReceiveBytes, 0, myReceiveBytes.Length)
                InBytesCount = myClientNetworkStream.Read(myReceiveBytes, 0, myReceiveBytes.Length)
                System.Threading.Thread.Sleep(50)
                If InBytesCount = 0 Then
                    _mainForm.Show_Lab_ComStatus_ATMS("0")
                    Exit While
                Else
                    Dim SendString As String = ByteArrayToStr2(myReceiveBytes).Substring(0, 2 * InBytesCount)
                    _mainForm.Show_LBox_ReceivedText_ATMS("[R<--ATMS] " + SendString)
                    If SendString.Substring(0, 4) = "AABB" Then
                        SaveDataFunction(SendString) 'Save Data Struct
                    End If
                    Thread.Sleep(50)
                    _mainForm.send_IC(StrToByteArray2(SendString))

                End If
            Catch ex As Exception
                _mainForm.Show_Lab_ComStatus_ATMS("0")
                Dim trace As New System.Diagnostics.StackTrace(ex, True)
                WriteLog(curPath, "Module_Comm", "ATMS_ReceiveData Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
                Exit Sub
            End Try
        End While
    End Sub
    Public Sub TCP_WriteToATMS(ByVal sendbyte() As Byte)
        Try
            myClientNetworkStream.Write(sendbyte, 0, sendbyte.Length)
            myClientNetworkStream.Flush()
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Comm", "TCP_WriteToATMS Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try

    End Sub
    Public Sub Socket_WriteToATMS(ByVal writeData() As Byte)
        Try
            TCP_WriteToATMS(writeData)
            _mainForm.Show_LBox_ReceivedText_ATMS("[w-->ATMS] " + ByteArrayToStr2(writeData))
        Catch ex As Exception
            WriteLog(curPath, "Module_Comm", "  Socket_WriteToATMS Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    '****************************************************************************
    '***
    '*** Watch Dog 運作功能
    '***
    '****************************************************************************

    Public Sub OrderSend2WatchDog()
        Try
            Dim myUDPClient = New UdpClient()
            Dim RemoteIpEndPoint As New IPEndPoint(IPAddress.Parse(WDRemoteIP), WDRemotePort)
            Dim write_Bytes() As Byte
            Dim order_name As String

            order_name = "WatchDogEvent"
            write_Bytes = StrToByteArray(order_name)
            myUDPClient.Send(write_Bytes, write_Bytes.Length, RemoteIpEndPoint)


        Catch ex As Exception
            WriteLog(curPath, "Module_Comm", "OrderSend2WatchDog Catch:" + ex.Message, _logEnable)
        End Try
    End Sub

    '****************************************************************************
    '***
    '*** OTA 運作功能  'Jason 20150205 OTA Modify
    '***
    '****************************************************************************

    Public Sub RunOTAResponse()
        Try
            'If OTARebootFlag = "1" Then  '是因為OTA更新,所以重啟,需主動回報CC且必需記錄 'jason 20150413 OTA SaveTo Table
            Dim sendByte As Byte() = Incode_Step1(getSeqNum(), MarkAACommand("5FB5" + VersionYear + VersionMonth + VersionDay + VersionID))
            Socket_WriteToCC(sendByte)
            WriteINIValue("Common", "OTARebootFlag", "0")
            'End If 'jason 20150413 OTA SaveTo Table
            'jason 20150413 OTA SaveTo Table
            'S-----------------------------------------------------------------------
            If OTARebootFlag = "1" Then
                SaveOTAUpdateToDB(COMMON_GroupID, SelectCrossRoadID)
            End If
            'E-----------------------------------------------------------------------
        Catch ex As Exception
            WriteLog(curPath, "Module_Comm", "RunOTAResponse Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
End Module
