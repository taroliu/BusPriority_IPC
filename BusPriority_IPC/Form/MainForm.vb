Option Explicit On
Imports System.Threading
Imports System.Net.Sockets
Imports System.IO

Public Class MainForm
    Dim init_finish As Boolean
    '*********************************************************
    '**
    '** Delegate
    '**
    '*********************************************************
    Delegate Sub SetTextCallback(ByVal [text] As String)

    Public Sub Show_LBox_ReceivedText_IC(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.LBox_IC.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_LBox_ReceivedText_IC)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.LBox_IC.Items.Add("[" + Date.Now.ToString("HH:mm:ss ") + "]" & [text])
            If LBox_IC.Items.Count > LBox_limit Then
                LBox_IC.Items.RemoveAt(0)
            End If
            WriteLog(curPath, "IC_comm", [text], _logEnable)
        End If
    End Sub

    Public Sub Show_LBox_ReceivedText_CC(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.LBox_CC.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_LBox_ReceivedText_CC)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.LBox_CC.Items.Add("[" + Date.Now.ToString("HH:mm:ss ") + "]" & [text])
            If LBox_CC.Items.Count > LBox_limit Then
                LBox_CC.Items.RemoveAt(0)
            End If
            WriteLog(curPath, "CC_comm", [text], _logEnable)
        End If
    End Sub

    Public Sub Show_LBox_ReceivedText_ATMS(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.LBox_ATMS.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_LBox_ReceivedText_ATMS)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.LBox_ATMS.Items.Add("[" + Date.Now.ToString("HH:mm:ss ") + "]" & [text])
            If LBox_ATMS.Items.Count > LBox_limit Then
                LBox_ATMS.Items.RemoveAt(0)
            End If
            WriteLog(curPath, "ATMS_comm", [text], _logEnable)
        End If
    End Sub

    Public Sub Show_LBox_ReceivedText_CAR(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.LBox_Car.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_LBox_ReceivedText_CAR)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.LBox_Car.Items.Add("[" + Date.Now.ToString("HH:mm:ss ") + "]" & [text])
            If LBox_Car.Items.Count > LBox_limit Then
                LBox_Car.Items.RemoveAt(0)
            End If
            WriteLog(curPath, "CAR_comm", [text], _logEnable)
        End If
    End Sub

    Public Sub Show_Lab_ComStatus_IC(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.Lab_ComStatus_IC.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_Lab_ComStatus_IC)
            Me.Invoke(x, New Object() {(text)})
        Else
            Dim ConStatus As String = [text]
            If ConStatus.Substring(0, 1) = "0" Then
                _mainForm.Lab_ComStatus_IC.Text = "[" + ConStatus.Substring(1, ConStatus.Length - 1) + "]開啟失敗"
                _mainForm.Lab_ComStatus_IC.BackColor = Color.Red
            Else
                _mainForm.Lab_ComStatus_IC.Text = "[" + ConStatus.Substring(1, ConStatus.Length - 1) + "]開啟成功"
                _mainForm.Lab_ComStatus_IC.BackColor = Color.LawnGreen
            End If

        End If
    End Sub

    Public Sub Show_Lab_ComStatus_CC(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.Lab_ComStatus_CC.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_Lab_ComStatus_CC)
            Me.Invoke(x, New Object() {(text)})
        Else

            If [text] = "0" Then
                _mainForm.Lab_ComStatus_CC.Text = "通訊斷線"
                _mainForm.Lab_ComStatus_CC.BackColor = Color.Red
            Else
                _mainForm.Lab_ComStatus_CC.Text = "通訊連線"
                _mainForm.Lab_ComStatus_CC.BackColor = Color.LawnGreen
            End If

        End If
    End Sub
    Public Sub Show_Lab_ComStatus_Car(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.Lab_ComStatus_CC.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_Lab_ComStatus_Car)
            Me.Invoke(x, New Object() {(text)})
        Else

            If [text] = "0" Then
                _mainForm.Lab_ComStatus_Car.Text = "通訊斷線"
                _mainForm.Lab_ComStatus_Car.BackColor = Color.Red
            Else
                _mainForm.Lab_ComStatus_Car.Text = "通訊連線"
                _mainForm.Lab_ComStatus_Car.BackColor = Color.LawnGreen
            End If

        End If
    End Sub

    Public Sub Show_Lab_ComStatus_ATMS(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.Lab_ComStatus_ATMS.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_Lab_ComStatus_ATMS)
            Me.Invoke(x, New Object() {(text)})
        Else

            If [text] = "0" Then
                _mainForm.Lab_ComStatus_ATMS.Text = "通訊斷線"
                _mainForm.Lab_ComStatus_ATMS.BackColor = Color.Red
            Else
                _mainForm.Lab_ComStatus_ATMS.Text = "通訊連線"
                _mainForm.Lab_ComStatus_ATMS.BackColor = Color.LawnGreen
            End If

        End If
    End Sub

    Public Sub Show_LBox_PolicyRightNowText(ByVal [text] As String)
        If CBox_Filter_A1_A2.Checked Then
            Dim tmpText As String = [text]
            If tmpText.IndexOf("A1") > 0 Or tmpText.IndexOf("A2") > 0 Then
                Exit Sub
            End If
        End If
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.LBox_PolicyExecute.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_LBox_PolicyRightNowText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.LBox_PolicyExecute.Items.Add("[" + Date.Now.ToString("HH:mm:ss ") + "]" & [text])
            If LBox_PolicyExecute.Items.Count > LBox_limit Then
                LBox_PolicyExecute.Items.RemoveAt(0)
            End If
            WriteLog(curPath, "Strategy_log", [text], _logEnable) 'Why does it appear twice??
        End If

    End Sub

    Public Sub Show_BusPolicyText(ByVal [text] As String)
        'compares the ID of the creating Thread to the ID of the calling Thread
        If Me.TBox_BusPolicy.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf Show_BusPolicyText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.TBox_BusPolicy.Text = ("[" + Date.Now.ToString("HH:mm:ss ") + "]" & [text])
        End If
    End Sub
    '*********************************************************
    '**
    '** MainForm
    '**
    '*********************************************************
    'DB Erro AutoClose Application 201505041400
    'S---------------------------------------------------------------------------------------
    Private Sub CloseAP_Thread()
        Dim t As New Threading.Thread(AddressOf closeMsgbox)
        t.Start() '10 second delay
    End Sub
    Private Sub closeMsgbox()
        Threading.Thread.Sleep(10 * 1000)
        If SelectCloseMessageboxFlag = 999 Then
            Environment.Exit(Environment.ExitCode)
            Application.Exit()
        End If
    End Sub
    Private SelectCloseMessageboxFlag As Integer
    'E---------------------------------------------------------------------------------------
    Private Sub MainForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try


            init_finish = False
            Module_Comm._mainForm = Me '20131216介面承接LCS燈號 下載成功訊息.
            iniSemaphore()
            setWorkFolderPath()
            getAll_ParamINI()
            SelectCloseMessageboxFlag = 999
            If DB_ACCESS_ENABLE = "1" Then
                If isConnectDataBase() = False Then
                    DB_Error = True
                    'DB Erro AutoClose Application 201505041400
                    'S--------------------------------------------------------------------------------------------------
                    WriteLog(curPath, "systeminfo", "資料庫連結錯誤!系統將自動關閉...", _logEnable)
                    CloseAP_Thread()
                    If MessageBox.Show("資料庫連結錯誤!", "請確認", MessageBoxButtons.OK, MessageBoxIcon.Error) = 1 Then
                        SelectCloseMessageboxFlag = 1
                    End If
                    'E--------------------------------------------------------------------------------------------------
                Else

                    DB_Error = False
                    'jason 20150413 檢查表格及檢視表是否存在
                    'S-------------------------------------------------------------------------
                    If DB_Check = "1" Then
                        DB_CheckTable()
                    End If
                    'E-------------------------------------------------------------------------
                End If
            End If

            init_Layout()
            If DB_ACCESS_ENABLE = "1" Then
                initCrossRoad2TreeView()
            End If

            Panel_Select(1)

            'Open Comm
            OpenSerialPort()
            OpenCC_Com()
            OpenATMS_Com() 'Jason 20140926 ATMS Connect
            OpenCar_Com()


            Me.Text = "公車優先路側設備(群組-" + COMMON_GroupID + "-" + COMMON_GroupName + ")         ********* BuildDay [" + HexStringTOIntString(VersionYear, 2) +
                      "/" + HexStringTOIntString(VersionMonth, 2) + "/" + HexStringTOIntString(VersionDay, 2) + "] Version [" + VersionID.Substring(0, 1) + "." +
                      VersionID.Substring(1, 1) + "] ********* " 'jason 20150413 Form加版本於TITLE
            Timer_Connect_TCP.Enabled = True

            ToolStripStatusLabel1.Text = "系統啟動時間:" + Date.Now.ToString("yyyy/MM/dd HH:mm:ss ")
            DiffTimeOfTC_Request = Now 'Jason20150527三分鐘未收到TC封包,回報IPC通訊異常
            RunOTAResponse() 'Jason 20150205 OTA Modify
            SetAutoLoad5F46() 'Jason20150205 自動查詢時段資料放進XML,供中心查詢.
            init_finish = True
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "MainForm", "  MainForm_Load Catch:" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    Private Sub But_IC_Download_Click(sender As System.Object, e As System.EventArgs) Handles But_IC_Download.Click
        Try
            Dim sendByte As Byte()
            Dim tranStr As String = TBox_IC_Download.Text
            tranStr = tranStr.Replace(" ", "")
            tranStr = tranStr.Replace("H", "")
            tranStr = tranStr.Replace("+", "")
            sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
            Thread.Sleep(100)
            send_IC_Manual(sendByte)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "MainForm", "  But_IC_Download_Click Catch:" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub send_IC_Manual(ByVal sendData As Byte())
        Try
            mySerialPort.Write(sendData, 0, sendData.Length)
            LBox_IC.Items.Add("[" + Date.Now.ToString("HH:mm:ss ") + "][Manual-Send] " & ByteArrayToStr2(sendData))
            WriteLog(curPath, "IC_comm", "[Manual-Send] " + ByteArrayToStr2(sendData), _logEnable)
        Catch ex As Exception
            WriteLog(curPath, "MainForm", "  send_IC_Manual Catch:" + ex.Message, True)
        End Try
    End Sub
    'jason20150930未下成功重傳.
    'S------------------------------------------------------------------------------
    'OLD
    'Public Sub send_IC(ByVal sendData As Byte())
    '    Try
    '        If mySerialPort.IsOpen Then
    '            mySerialPort.Write(sendData, 0, sendData.Length)
    '            'Show_LBox_ReceivedText_IC("[" + Date.Now.ToString("HH:mm:ss ") + "][w-->IC] " & ByteArrayToStr2(sendData))
    '            Show_LBox_ReceivedText_IC("[w-->IC] " + ByteArrayToStr2(sendData))
    '            'LBox_IC.Items.Add("[" + Date.Now.ToString("HH:mm:ss ") + "][w-->IC] " & ByteArrayToStr2(sendData))
    '            'WriteLog(curPath, "IC_comm", "[w-->IC] " + ByteArrayToStr2(sendData), _logEnable)
    '        Else

    '            WriteLog(curPath, "IC_comm", "[w-->IC] Serial Port Not Open!!!", _logEnable)
    '        End If

    '    Catch ex As Exception
    '        WriteLog(curPath, "MainForm", "  send_IC Catch:" + ex.Message, True)
    '    End Try
    'End Sub
    'NEW
    Dim ICSendThread As Thread
    Public Sub send_IC(ByVal sendData As Byte())
        Try
            ICSendThread = New Thread(AddressOf SendIC_Thread)
            ICSendThread.Name = "SendICThread"
            ICSendThread.IsBackground = True
            ICSendThread.Priority = ThreadPriority.Highest
            ICSendThread.Start(sendData)
           
        Catch ex As Exception
            WriteLog(curPath, "MainForm", "  send_IC Catch:" + ex.Message, True)
        End Try
    End Sub
    Public Sub SendIC_Thread(ByVal sendData As Byte())
        Try
            If mySerialPort.IsOpen Then
                SetNowLog(ByteArrayToStr2(sendData), True)
                Dim V3Object As New V3_Object(ByteArrayToStr2(sendData))
                If V3Object.CommandType = "0" Then
                    Dim SendCount As Integer = 1
                    Do
                        If isFeedBackNowLog(ByteArrayToStr2(sendData)) Then
                            Exit Do
                        Else
                            mySerialPort.Write(sendData, 0, sendData.Length)
                            Show_LBox_ReceivedText_IC("[w-->IC] " + ByteArrayToStr2(sendData) + " (" + SendCount.ToString + "次)")
                        End If
                        Thread.Sleep(Val(SendNowLog_SleepTime))
                        SendCount += 1
                    Loop Until SendCount > 5
                Else
                    mySerialPort.Write(sendData, 0, sendData.Length)
                    Show_LBox_ReceivedText_IC("[w-->IC] " + ByteArrayToStr2(sendData))
                End If
            Else
                WriteLog(curPath, "IC_comm", "[w-->IC] Serial [" + mySerialPort.PortName.ToString + "] Port Not Open!!!", _logEnable)
                Show_LBox_ReceivedText_IC("[w-->IC] Serial [" + mySerialPort.PortName.ToString + "] Port Not Open!!!")
            End If
        Catch ex As Exception
            WriteLog(curPath, "MainForm", "  SendIC_Thread Catch:" + ex.Message, True)
        End Try
    End Sub
    'E------------------------------------------------------------------------------

    Private Sub LBox_IC_ControlAdded(sender As System.Object, e As System.Windows.Forms.ControlEventArgs) Handles LBox_IC.ControlAdded
        If LBox_IC.Items.Count > LBox_limit Then
            LBox_IC.Items.RemoveAt(0)
        End If
    End Sub

    Private Sub LBox_IC_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LBox_IC.SelectedIndexChanged
        If LBox_IC.Items.Count > LBox_limit Then
            LBox_IC.Items.RemoveAt(0)
        End If
    End Sub

    Private Sub But_clean_IC_Click(sender As System.Object, e As System.EventArgs) Handles But_clean_IC.Click
        LBox_IC.Items.Clear()
    End Sub

    Private Sub But_clean_CC_Click(sender As System.Object, e As System.EventArgs) Handles But_clean_CC.Click
        LBox_CC.Items.Clear()
    End Sub

    Private Sub But_clean_CAR_Click(sender As System.Object, e As System.EventArgs) Handles But_clean_CAR.Click
        LBox_Car.Items.Clear()
    End Sub

    Private Sub But_ConfigSave_Click(sender As System.Object, e As System.EventArgs) Handles But_ConfigSave.Click
        save_Configdata()
    End Sub

    '*********************************************************
    '**
    '** Layout Form
    '**
    '*********************************************************
    Private Sub MainForm_Resize(sender As System.Object, e As System.EventArgs) Handles MyBase.Resize
        If init_finish Then
            init_Layout()
        End If
    End Sub


    Private Sub ToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Resize_Monitor_Panel()
        Panel_Select(1)
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem2.Click
        Try
            Dim SelecNodeItemID As String

            If DB_ACCESS_ENABLE = "1" Then
                If Not TView_CrossRoad.SelectedNode Is Nothing Then
                    SelecNodeItemID = TView_CrossRoad.SelectedNode.Text
                Else
                    SelecNodeItemID = TView_CrossRoad.Nodes(0).Text
                End If
                SelecNodeItemID = SelecNodeItemID.Substring(SelecNodeItemID.IndexOf("[") + 1, SelecNodeItemID.IndexOf("]") - SelecNodeItemID.IndexOf("[") - 1)
                If DB_Error Then
                    MessageBox.Show("資料庫連結錯誤!", "請確認", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    initComSegmentCom2DGridView(SelecNodeItemID)
                    initTouchPoint2DGridView(SelecNodeItemID)
                End If
            Else
                SelecNodeItemID = ""
            End If

            getSystemSerialPort()
            init_Configdata(SelecNodeItemID)

            Resize_Manage_Panel()
            Panel_Select(2)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Resize_History_Panel()
        Panel_Select(3)
    End Sub
    Private Sub LBox_IC_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles LBox_IC.MouseDoubleClick
        Try
            MessageBox.Show(LBox_IC.SelectedItem.ToString, "回報內容,請確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LBox_CC_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles LBox_CC.MouseDoubleClick
        Try
            MessageBox.Show(LBox_CC.SelectedItem.ToString, "回報內容,請確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LBox_Car_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles LBox_Car.MouseDoubleClick
        Try
            MessageBox.Show(LBox_Car.SelectedItem.ToString, "回報內容,請確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LBox_PolicyExecute_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles LBox_PolicyExecute.MouseDoubleClick
        Try
            MessageBox.Show(LBox_PolicyExecute.SelectedItem.ToString, "回報內容,請確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LinkLabel_ID_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_ID.LinkClicked
        SelectConfigPanel(0)
    End Sub

    Private Sub LinkLabel_Com_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_Com.LinkClicked
        SelectConfigPanel(1)
    End Sub

    Private Sub LinkLabel_db_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_db.LinkClicked
        SelectConfigPanel(2)
    End Sub

    Private Sub LinkLabel_busPrim_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_busPrim.LinkClicked
        SelectConfigPanel(3)
    End Sub
    Public TimeSegmentFlag As Integer = 0
    Private Sub LinkLabel_Seg1_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_Seg1.LinkClicked
        Try
            Dim SelecNodeItemID As String
            TimeSegmentFlag = 0
            If Not TView_CrossRoad.SelectedNode Is Nothing Then
                SelecNodeItemID = TView_CrossRoad.SelectedNode.Text
            Else
                SelecNodeItemID = TView_CrossRoad.Nodes(0).Text
            End If
            SelecNodeItemID = SelecNodeItemID.Substring(SelecNodeItemID.IndexOf("[") + 1, SelecNodeItemID.IndexOf("]") - SelecNodeItemID.IndexOf("[") - 1)
            initComSegmentCom2DGridView(SelecNodeItemID)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "MainForm", "  LinkLabel_Seg1_LinkClicked Catch:" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    Private Sub LinkLabel_Seg2_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_Seg2.LinkClicked

        TimeSegmentFlag = 1
        'Dim SelecNodeItemID As String
        'If Not TView_CrossRoad.SelectedNode Is Nothing Then
        '    SelecNodeItemID = TView_CrossRoad.SelectedNode.Text
        'Else
        '    SelecNodeItemID = TView_CrossRoad.Nodes(0).Text
        'End If
        'SelecNodeItemID = SelecNodeItemID.Substring(SelecNodeItemID.IndexOf("[") + 1, SelecNodeItemID.IndexOf("]") - SelecNodeItemID.IndexOf("[") - 1)
        'initComSegmentSpec2DGridView(SelecNodeItemID)
    End Sub

    'jason test
    Public IC_Soul As New BusPriority_daemon
    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        '***************************************
        'Dim write_Bytes(1) As Byte
        'write_Bytes(0) = &HAA
        'write_Bytes(1) = &HEE
        'Socket_WriteToCC(write_Bytes)
        '***************************************
        'Dim test_5F13 As New Class_5F13(&HAA, &HBB, &HCC, write_Bytes, Now())
        'IC_Soul.Set_5F13(&H22, test_5F13)

        'Dim recdata As DateTime = IC_Soul.Get_5FC3(&H22).UpdateTime
        '***************************************
        'Dim SecParma1 As Integer = SecondOfCar2CrossRoad("25.073598,121.579224", "25.075075,121.583687", 50)
        'SecParma1 = 0
        '***************************************
        'Dim SecParma1 As Boolean = isBusSameDirection("1", Data_5F13)
        '***************************************
        'Dim SecParma1 As Integer = RG_i("1", Data_5F03, Data_5F13, Data_5F15)
        '***************************************
        'SaveData_5FC3("AABB0200A000225FC306D7060381817C817C817C81817C8181817C8181817CAACCBF")
        '***************************************
        'SaveData_5FC5("AABB0400A0001A5FC50200060300280023001E00780000AACC39")
        '***************************************
        'Dim SecParma1 As Integer = RG_i_max("1", Data_5F03, Data_5F13, Data_5F14, Data_5F15)
        '***************************************
        'Dim SecParma1 As Integer = G_j("1", Data_5F03, Data_5F13, Data_5F14, Data_5F15)
        '***************************************
        'Dim SecParma1 As Integer = G_j_min("1", Data_5F03, Data_5F13, Data_5F14, Data_5F15)
        '***************************************
        'Dim SecParma1 As Integer = RG_j("1", Data_5F03, Data_5F13, Data_5F14, Data_5F15)
        '***************************************
        'ResponeUserDefineFunction("AABB3400A000285F81000B190104297A08CEE2010001000B020103011901043A7A08CEF602AACC10")
        'ResponeUserDefineFunction("AABB3400A000395F81000B190104297A08CEE2020001000B020103011901043A7A08CEF6020001000B020103011901043A7A08CEF602AACC10")
        '***************************************
        'ResponeUserDefineFunction("AABB3400A000145F820501152401020506AACC10")
        '***************************************
        'ResponeUserDefineFunction("AABB0100A000375F82010508000A000C001000160005010203040501010101010101010101010101010101010101010101010101AACC35")
        '***************************************
        'Show_LBox_PolicyRightNowText("<000100010202>公車到路口剩餘秒數(999) 大於公車時相剩餘綠燈(999)加衝突時相所有步階(最小綠)秒數(999)-->將衝突時相綠燈改為到路口秒數(999)減到路口剩餘秒數(999),平均分配[1-5]")
        '***************************************
        'SendLightRemainSec("TestBUSID", "G", "30")
        '***************************************
        'SaveData_5F81_DB("AABB34003F00285F810001190104297A08CEE2020001000B020103011901043A7A08CEF602AAA2000B020103011901043A7A08CEF602AACC10")
        'SaveData_5F81_DB("AABB0100A0005B5F8100011901158D7908B29C040001000102000200190118C67908D37E000001000102010201190116927908CB9D030001000102020202190116757908C574020001000102030203190116757908C57401AACC28")
        '***************************************
        'SaveData_5F82_DB("AABB0100A000265F82000101020000080A000905010203040501010101010101010101AACC20")
        '***************************************
        'SaveDataFunction("AABB34003F00285F8501AACC10")
        'Show_LBox_PolicyRightNowText("AABB0100A0005B5F8100011901158D7908B29C040001000102000200190118C67908D37E000001000102010201190116927908CB9D030001000102020202190116757908C574020001000102030203190116757908C57401AACC28")
        'isDisablePolicyCommand("AABB34003F00285F1040FFAACC00")
        'isResponeUserDefine_0F80("AABB34003F00285F1040FFAACC00")
        'Report5F03Xml("0001", "0002", "5F035055040301000F81448181")
        'SaveDataFunction("AABB21FFFF001C5F1601020800010D00050101AACC11")
        'SaveDataFunction("AABB21FFFF001C5F8000AACC11")
        'SetIPC_ConnectError(True)
        'Dim Testtime As DateTime
        'Dim Testtime2 As DateTime
        'Dim DiffYear As Integer = DateDiff(DateInterval.Year, Testtime, Now)
        'If DiffYear > 1 Then
        '    _mainForm.Show_LBox_PolicyRightNowText("Busted Empty Date Time")
        'End If
        'Testtime = "2015-03-27 16:54:29.000"
        'Testtime2 = "2015-03-27 17:54:29.000"
        '_mainForm.Show_LBox_PolicyRightNowText("Time " + Testtime)
        'If Testtime2 > Testtime Then
        '    _mainForm.Show_LBox_PolicyRightNowText("Testtime2 is the Latest")
        'End If
        'SetIPC_ConnectError(False)
        Dim nowdate As DateTime = Now

        Dim span As TimeSpan = New TimeSpan(0, 0, 0, 30, 0)

        Dim pastdate As DateTime = nowdate.Subtract(span)

        Dim edate As DateTime
        Dim emptydate As String = "1900-01-01 00:00:00"
        _mainForm.Show_LBox_PolicyRightNowText("Now Time is " + nowdate.ToString + " PastDate " + pastdate.ToString)

        'If edate = emptydate Then
        '    _mainForm.Show_LBox_PolicyRightNowText(" equal to empty date")
        'Else

        '    _mainForm.Show_LBox_PolicyRightNowText(" Not equal to empty date " + edate.ToString)
        'End If

        'For counter As Integer = 2 To 0 Step -1
        '    _mainForm.Show_LBox_PolicyRightNowText(counter.ToString)
        'Next


    End Sub

    Private Sub Timer_Connect_TCP_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Connect_TCP.Tick
        If _ConnectFlag_CC = False Then
            OpenCC_Com()
        End If
        If _ConnectFlag_Car = False Then
            OpenCar_Com()
        End If
        'Jason 20140926 ATMS Connect
        'S-----------------------------------------------------------------------
        If _ConnectFlag_ATMS = False And _ConnectFlag_ATMS_Accept = False Then
            OpenATMS_Com()
        End If
        'E-----------------------------------------------------------------------
    End Sub



    '****************************************************************************
    '***
    '*** 步階解析
    '***
    '****************************************************************************

    Private Sub Timer_AnalysisLightOutBySoft_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_AnalysisLightOutBySoft.Tick
        If orgNowSignalStatusString <> NowSignalStatusString Then
            Dim LightOut2IntArray As Integer() = getLightOut_LightStepBySoftWare(NowSignalStatusString)
            ShowReceiveLightStatusSoftWare(LightOut2IntArray)  '顯示在Form上
            orgNowSignalStatusString = NowSignalStatusString
            '有改變且第一分相,第一步階則下參數查詢.
            'MessageBox.Show("NowStepIDstring = " + NowStepIDstring + "/ NowSubPhaseIDstring = " + NowSubPhaseIDstring, "回報內容,請確認", MessageBoxButtons.OK, MessageBoxIcon.Information)

            '_mainForm.Show_LBox_PolicyRightNowText("download timer NowStepID" + NowStepIDstring.ToString + " NowSubPhaseID " + NowSubPhaseIDstring.ToString)
            If NowStepIDstring = "01" Then 'If NowStepIDstring = "01" And NowSubPhaseIDstring = "01" Then
                If Data_5F18 Is Nothing Then
                    _mainForm.Show_LBox_PolicyRightNowText("First 5f48 ")
                    setNowIC_Param_5F48()
                    Changed_Planid = False
                ElseIf Current_Planid <> Data_5F18.PlanID And Current_Planid <> Nothing Then
                    _mainForm.Show_LBox_PolicyRightNowText("download new 5f48 ")
                    setNowIC_Param_5F48()
                    Changed_Planid = True
                Else

                    '_mainForm.Show_LBox_PolicyRightNowText("Old Planid 5f48 do nothing")
                    Changed_Planid = False
                End If
                ' it's better if you wait until a full cycle before running the strategy           

            End If

        End If
        Try
            ' _mainForm.Show_LBox_PolicyRightNowText("download " + complete_5F48_AutoDownload.ToString)

            If complete_5F48_AutoDownload = 3 And Changed_Planid = True Then
                setNowIC_Param_5F45(Data_5F18.PlanID)
                complete_5F48_AutoDownload = 0
            End If
            If complete_5F48_AutoDownload = 2 And Changed_Planid = True Then
                setNowIC_Param_5F44(Data_5F18.PlanID)
                complete_5F48_AutoDownload = 3
            End If
            If complete_5F48_AutoDownload = 1 And Changed_Planid = True Then
                setNowIC_Param_5F43(Data_5F18.PhaseOrder)
                complete_5F48_AutoDownload = 2
            End If

            If Data_5F18 Is Nothing Then

            Else

                If Data_5F13 Is Nothing Then
                    setNowIC_Param_5F43(Data_5F18.PhaseOrder)
                End If

                If Data_5F14 Is Nothing Then
                    setNowIC_Param_5F44(Data_5F18.PlanID)
                End If

                If Data_5F15 Is Nothing Then

                    setNowIC_Param_5F45(Data_5F18.PlanID)

                End If


            End If

            'If BusComm_TimeStamp = Nothing Then

            '    '_mainForm.Show_LBox_PolicyRightNowText("No Bus Communication Yet")
            'Else

            '    Dim DiffSecond As Integer = DateDiff(DateInterval.Second, BusComm_TimeStamp, Now)

            '    If DiffSecond > 10 Then
            '        '_mainForm.Show_LBox_PolicyRightNowText("Lost Communication with Bus ")

            '        If FiveFB4.Count > 0 Then

            '            Try
            '                _mainForm.Show_LBox_PolicyRightNowText("BackUP 離開點 關閉時相控制")
            '                BusPrime_activate = False
            '                Dim sendByte As Byte()
            '                Dim tranStr As String = "5F100400"   '5F10  路口手動 + 時相控制
            '                sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
            '                _mainForm.send_IC(sendByte)
            '                '_mainForm.Show_LBox_PolicyRightNowText("離開點 啟動補償機制")
            '                A1_Counter = 0
            '                ActivatedBusID.Remove(FiveFB4("BusID"))
            '                Try
            '                    'FiveFB4.Add("P32", DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss"))
            '                    FiveFB4.Add("P3", Now.ToString("yyyy-MM-dd HH:mm:ss"))
            '                Catch ex As Exception
            '                    _mainForm.Show_LBox_PolicyRightNowText(" Error FiveFB4 P32 P3 " + ex.Message)
            '                End Try
            '                _mainForm.Show_LBox_PolicyRightNowText("GroupID " + FiveFB4("GroupID"))
            '                _mainForm.Show_LBox_PolicyRightNowText("CrossRoadID " + FiveFB4("CrossRoadID"))
            '                _mainForm.Show_LBox_PolicyRightNowText("BusID " + FiveFB4("BusID"))
            '                _mainForm.Show_LBox_PolicyRightNowText("BusLineID " + FiveFB4("BusLineID"))
            '                _mainForm.Show_LBox_PolicyRightNowText("GoBack " + FiveFB4("GoBack"))
            '                _mainForm.Show_LBox_PolicyRightNowText("BusPhase " + FiveFB4("BusPhase"))
            '                _mainForm.Show_LBox_PolicyRightNowText("Bus2CrossRoad " + FiveFB4("Bus2CrossRoad"))
            '                _mainForm.Show_LBox_PolicyRightNowText("Strategy " + FiveFB4("Strategy"))
            '                _mainForm.Show_LBox_PolicyRightNowText("Currentphase " + FiveFB4("Currentphase"))

            '                _mainForm.Show_LBox_PolicyRightNowText("P1  time " + FiveFB4("P1"))
            '                _mainForm.Show_LBox_PolicyRightNowText("P2  time " + FiveFB4("P2"))
            '                _mainForm.Show_LBox_PolicyRightNowText("P3  time " + FiveFB4("P3"))

            '                'Dim FiveFB4Str As String = "5FB4" + FiveFB4("GroupID") + FiveFB4("CrossRoadID") + FiveFB4("BusID") + "0" + FiveFB4("BusLineID") + "0" + FiveFB4("GoBack") + FiveFB4("BusPhase") + "0" + FiveFB4("Bus2CrossRoad") + FiveFB4("Strategy") + FiveFB4("Currentphase") + FiveFB4("P12") + FiveFB4("P22") + FiveFB4("P32")
            '                '_mainForm.Show_LBox_PolicyRightNowText("5FB4 Str " + FiveFB4Str + " Length " + FiveFB4Str.Length.ToString)
            '                'BusStrategy_Log2(ByVal GroupID As String, ByVal CrossRoadID As String, ByVal BusID As String, ByVal BusLineID As String, ByVal GoBack As String, ByVal BusPhase As String, ByVal Bus2CrossRoad As String, ByVal Strategy As String, ByVal Currentphase As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal Play1 As String, ByVal Play2 As String)
            '                Try
            '                    BusStrategy_Log2(_mainForm.TBox_GroupID.Text.ToString, _mainForm.TBox_CrossRoadID.Text.ToString, FiveFB4("BusID"), FiveFB4("BusLineID"), FiveFB4("GoBack"), FiveFB4("BusPhase"), FiveFB4("Bus2CrossRoad"), FiveFB4("Strategy"), FiveFB4("Currentphase"), FiveFB4("P1"), FiveFB4("P2"), FiveFB4("P3"), FiveFB4("Play1"), FiveFB4("Play2"))
            '                Catch ex As Exception
            '                    _mainForm.Show_LBox_PolicyRightNowText("Error  BusStrategy_Log " + ex.Message)
            '                End Try

            '                'Dim FiveFB4byte As Byte() = Incode_Step1(getSeqNum(), MarkAACommand(FiveFB4Str))
            '                'Dim tempstr As String = ByteArrayToStr2(FiveFB4byte)
            '                '_mainForm.Show_LBox_PolicyRightNowText("5FB4 message " + tempstr)

            '                FiveFB4.Clear()
            '                'BusComm_CommunicationStamp.Clear()
            '                BusComm_CommunicationStamp.Remove(nowPlayBusID)
            '                nowPlayBusID = "-1"
            '                _mainForm.Show_LBox_PolicyRightNowText("*****************************************************************************************************************************************")

            '            Catch pp As Exception
            '                _mainForm.Show_LBox_PolicyRightNowText("$$$$$$$$$$$ Error in BackupP3 " + pp.Message)
            '            End Try

            '        End If



            '        BusPrime_activate = False
            '        Phase_Commands.Clear()
            '        FiveFB4.Clear()
            '        A1_Counter = 0
            '        nowPlayBusID = "-1"
            '        SlowBusID.Clear()
            '        ActivatedBusID.Clear()
            '        BusComm_CommunicationStamp.Clear()

            '    Else
            '        '_mainForm.Show_LBox_PolicyRightNowText("Communicating with Bus ")

            '    End If



            'End If



            'Try
            '    If nowPlayBusID <> "-1" Then

            '        Dim BusComm_LastTime As DateTime = BusComm_CommunicationStamp(nowPlayBusID)

            '        Dim DiffSecond As Integer = DateDiff(DateInterval.Second, BusComm_LastTime, Now)

            '        If DiffSecond > 300 Then

            '            nowPlayBusID = "-1"
            '            A1_Counter = 0
            '            'BusComm_CommunicationStamp.Clear()
            '            BusComm_CommunicationStamp.Remove(nowPlayBusID)

            '        End If

            '    End If

            'Catch ex As Exception
            '    _mainForm.Show_LBox_PolicyRightNowText("ErrorBusComm_CommunicationStamp" + ex.Message)
            'End Try





            Try
                '_mainForm.Show_LBox_PolicyRightNowText("Current phase " + Data_5FCC.Current_SubPhaseID.ToString + " Current Step " + Data_5FCC.Current_StepID + " Remaining Time " + Data_5FCC.Current_RemainingTime.ToString + "  Time 2 " + HexStringTOIntString(Data_5FCC.Current_RemainingTime, 4).ToString)
                '_mainForm.Show_LBox_PolicyRightNowText("Current phase " + Data_5FCC.Current_SubPhaseID.ToString + " Current Step " + Data_5FCC.Current_StepID + " Remaining Time " + HexStringTOIntString(Data_5FCC.Current_RemainingTime, 4).ToString)

                'For index As Integer = 0 To 7
                '    If Data_5FCC.Current_SubPhaseID.ToString = All_Phases(index) Then
                '        _mainForm.Show_LBox_PolicyRightNowText("Phase " + All_Phases(index).ToString + " XXXX")
                '    End If
                'Next

            Catch ex As Exception
                _mainForm.Show_LBox_PolicyRightNowText("Error :Empty Data_5FCC  ")
            End Try


        Catch ex As Exception
            _mainForm.Show_LBox_PolicyRightNowText("Error :Empty Data_5FCC  ")
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            _mainForm.Show_LBox_PolicyRightNowText(trace.ToString)
        End Try
    End Sub

    '****************************************************************************
    '***
    '*** 群組運作
    '***
    '****************************************************************************

    Private Sub TView_CrossRoad_AfterSelect(sender As System.Object, e As System.Windows.Forms.TreeViewEventArgs) Handles TView_CrossRoad.AfterSelect
        'COMMON_EquipID Change
    End Sub

    '****************************************************************************
    '***
    '*** 優先號誌運作
    '***
    '****************************************************************************
    Public RecovyTriggerPointGridView_X As Integer = 0
    Public RecovyTriggerPointGridView_Y As Integer = 0
    Private Sub DGrid_TriggerPoint_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid_TriggerPoint.CellClick
        RecovyTriggerPointGridView_X = e.ColumnIndex
        RecovyTriggerPointGridView_Y = e.RowIndex
    End Sub
    Public RecovySegmentGridView_X As Integer = 0
    Public RecovySegmentGridView_Y As Integer = 0

    Private Sub DGrid_Segment_CellClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGrid_Segment.CellClick
        RecovySegmentGridView_X = e.ColumnIndex
        RecovySegmentGridView_Y = e.RowIndex
    End Sub

    '時段控制
    Private Sub Timer_Segment_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_RefreshDataGrid.Tick
        Try
            If DB_ACCESS_ENABLE = "1" Then
                Dim SelecNodeItemID As String
                If Not TView_CrossRoad.SelectedNode Is Nothing Then
                    SelecNodeItemID = TView_CrossRoad.SelectedNode.Text
                Else
                    SelecNodeItemID = TView_CrossRoad.Nodes(0).Text
                End If
                SelecNodeItemID = SelecNodeItemID.Substring(SelecNodeItemID.IndexOf("[") + 1, SelecNodeItemID.IndexOf("]") - SelecNodeItemID.IndexOf("[") - 1)
                If TimeSegmentFlag = 0 Then
                    initComSegmentCom2DGridView(SelecNodeItemID)
                    DGrid_Segment.CurrentCell = DGrid_Segment.Rows(RecovySegmentGridView_Y).Cells(RecovySegmentGridView_X)

                Else
                    initComSegmentSpec2DGridView(SelecNodeItemID)
                End If

                initTouchPoint2DGridView(SelecNodeItemID)
                DGrid_TriggerPoint.CurrentCell = DGrid_TriggerPoint.Rows(RecovyTriggerPointGridView_Y).Cells(RecovyTriggerPointGridView_X)
                initComBusLineDate()
                '總開關協定控制
                'S---------------------------------------------------------------------------
                'OLD
                'SetBusPrimParam()
                'NEW
                If isRunSystemFromCC = "1" Then
                    SetBusPrimParam()

                    initBusStopDistance()
                Else
                    Label_BusPrimEnable.Text = "中央關閉"
                    Label_BusPrimEnable.BackColor = Color.Red
                End If
                'E---------------------------------------------------------------------------
            Else
                Label_BusPrimEnable.Text = "啟動"
                Label_BusPrimEnable.BackColor = Color.LimeGreen
                TBox_Sgm.Text = "資料庫關閉"
                complete_5F10_AutoDownload = 0  '5F3F?
                initBusPrimEnble = 1  'Start    '5F10?   
                Timer_SegmentAutoSend.Start()
                Timer_RefreshDataGrid.Stop()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public initBusPrimEnble As Integer = 0 'init=0 1=true 2=false       'what is this for?
    Public Sub SetBusPrimParam()
        Try

            Dim intDayOfWeek As Integer = Now.DayOfWeek()
            If intDayOfWeek = 0 Then
                intDayOfWeek = 7
            End If
            Dim nowPlanIBusPrim As String() = getWeekOfSegment_PlanID_BusPrim(intDayOfWeek.ToString, Now)
            If IsNothing(nowPlanIBusPrim) Then
                'If initBusPrimEnble <> 1 Then
                '    EanbleProcotolSend(1)
                'initBusPrimEnble = 2
                'Timer_SegmentAutoSend.Start()
                'End If

                Label_BusPrimEnable.Text = "關閉-時段(空)"
                Label_BusPrimEnable.BackColor = Color.Red
                isRunSystemFromSeqment = "0"   '總開關協定控制
            Else
                TBox_Sgm.Text = "時段開始 " + nowPlanIBusPrim(0).PadRight(2, "0") + ":" + nowPlanIBusPrim(1).PadRight(2, "0") + "  時制計畫編號 " + nowPlanIBusPrim(2)
                If nowPlanIBusPrim(3) = "1" Then
                    'If initBusPrimEnble <> 2 Then
                    'EanbleProcotolSend(2)

                    If Label_BusPrimEnable.Text = "關閉" Then
                        complete_5F10_AutoDownload = 0
                        initBusPrimEnble = 1  'Start
                        Timer_SegmentAutoSend.Start()
                    End If


                    'End If
                    Label_BusPrimEnable.Text = "啟動"
                    Label_BusPrimEnable.BackColor = Color.LimeGreen
                    isRunSystemFromSeqment = "1"   '總開關協定控制
                Else
                    'If initBusPrimEnble <> 1 Then
                    '    EanbleProcotolSend(1)
                    If Label_BusPrimEnable.Text = "啟動" Then
                        complete_5F10_AutoDownload = 0
                        initBusPrimEnble = 2  'Stop
                        Timer_SegmentAutoSend.Start()
                    End If

                    'End If
                    Label_BusPrimEnable.Text = "關閉"
                    Label_BusPrimEnable.BackColor = Color.Red
                    isRunSystemFromSeqment = "0"   '總開關協定控制
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub
    'Public Sub EanbleProcotolSend(ByVal BusPrimEnable As Integer)
    '    Try
    '        '未來群組要考慮,其它IC用UDP
    '        If BusPrimEnable = 2 Then
    '            'send_IC(StrToByteArray2("5F101400"))
    '            'Thread.Sleep(200)
    '            'send_IC(StrToByteArray2("5F3F0200"))
    '            Dim sendByte As Byte()
    '            Dim tranStr As String = "5F101400"
    '            sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
    '            send_IC(sendByte)

    '            tranStr = "5F3F0200"
    '            sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
    '            Thread.Sleep(1000)
    '            send_IC(sendByte)

    '        Else
    '            '?????應該要一起機先查,要能回復
    '            Dim sendByte As Byte()
    '            Dim tranStr As String = "5F100100"
    '            sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
    '            send_IC(sendByte)
    '        End If

    '    Catch ex As Exception

    '    End Try
    'End Sub
    '<補>如果IC沒收到,需再傳送三次
    Public complete_5F10_AutoDownload As Integer = 0     'what is this for???  1? 0?
    Private Sub Timer_SegmentAutoSend_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_SegmentAutoSend.Tick
        Try
            If initBusPrimEnble = 1 Then

                If complete_5F10_AutoDownload = 1 Then
                    Dim sendByte As Byte()
                    Dim tranStr As String = "5F3F0200"
                    sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
                    send_IC(sendByte)
                    Timer_SegmentAutoSend.Stop()
                End If
                If complete_5F10_AutoDownload = 0 Then
                    Dim sendByte As Byte()
                    Dim tranStr As String = "5F101400"
                    sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
                    'send_IC(sendByte)
                    complete_5F10_AutoDownload = 1
                End If
            ElseIf initBusPrimEnble = 2 Then

                If complete_5F10_AutoDownload = 0 Then
                    Dim sendByte As Byte()
                    Dim tranStr As String = "5F100400"
                    sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
                    'send_IC(sendByte)
                    Timer_SegmentAutoSend.Stop()
                End If

            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "MainForm", "  Timer_SegmentAutoSend_Tick Catch:" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    '****************************************************************************
    '***
    '*** 紀錄查詢功能
    '***
    '****************************************************************************
    Private Sub LinkLabel_RecordRightNow_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_RecordRightNow.LinkClicked
        SelectRecordPanel(1)
    End Sub

    Private Sub LinkLabel_History_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel_History.LinkClicked
        SelectRecordPanel(0)
        LoadCrossRoadID_Name()
    End Sub

    Private Sub But_RecordRightNow_Clear_Click(sender As System.Object, e As System.EventArgs) Handles But_RecordRightNow_Clear.Click
        LBox_PolicyExecute.Items.Clear()
    End Sub

    Private Sub But_HistoryRun_Click(sender As System.Object, e As System.EventArgs) Handles But_HistoryRun.Click
        SetCharLayout(False) 'Jason 20150212 分析圖功能
       
        But_csv.Visible = True
        Dim sCrossRoadID As String() = CBox_CrossRoadID_His.Text.Split("|")
        LoadBusPriority_HistorySearch(sCrossRoadID(0), CBox_History_Record.SelectedIndex)
    End Sub
    'Jason 20150212 分析圖功能
    'S---------------------------------------------------------------------------
    Private Sub But_Graph_Click(sender As System.Object, e As System.EventArgs) Handles But_Graph.Click
        SetCharLayout(True)
        But_csv.Visible = False
        Dim sCrossRoadID As String() = CBox_CrossRoadID_His.Text.Split("|")
        SetCharFromDB(sCrossRoadID(0), CBox_History_Record.SelectedIndex)
    End Sub
    Private Sub CBox_History_Record_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles CBox_History_Record.SelectedIndexChanged
        If init_finish Then
            If CBox_History_Record.SelectedIndex = "1" Then
                But_Graph.Visible = True
                Lab_Interval.Visible = True
                TBox_Interval.Visible = True
                But_csv.Visible = False
            Else
                SetCharLayout(False)
                Lab_Interval.Visible = False
                TBox_Interval.Visible = False
            End If
        End If

    End Sub
    'E---------------------------------------------------------------------------
    '****************************************************************************
    '***
    '*** ATMS運作功能
    '***
    '****************************************************************************

    Private Sub LBox_ATMS_MouseDoubleClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles LBox_ATMS.MouseDoubleClick
        Try
            MessageBox.Show(LBox_ATMS.SelectedItem.ToString, "回報內容,請確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub But_clean_ATMS_Click(sender As System.Object, e As System.EventArgs) Handles But_clean_ATMS.Click
        LBox_ATMS.Items.Clear()
    End Sub



    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs)
        Try

            _mainForm.Show_LBox_PolicyRightNowText("Time sent to Bus")
            If SentTime > 0 Then
                SendLightRemainSec(Data_A2.BusID, SentLight, SentTime)
                SentTime = SentTime - 1
            Else
                Timer1.Enabled = False
            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "MainForm", "  Timer1_Tick Catch:" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try

    End Sub

  
    '****************************************************************************
    '***
    '*** Watch Dog 運作功能
    '***
    '****************************************************************************
    Private Sub Timer_WatchDog_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_WatchDog.Tick
        Try
            OrderSend2WatchDog()
            'Jason 20150205 OTA Modify
            'S-----------------------------------------------------------------------
            Dim OTAbinFile As String = curPath + "\BusPriority_IPC.bin"
            If File.Exists(OTAbinFile) Then
                'MessageBox.Show("檔案 " & OTAbinFile & " 不存在。", "請注意", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                WriteINIValue("Common", "OTARebootFlag", "1")
                Environment.Exit(Environment.ExitCode)
                Application.Exit()
            End If
            'E-----------------------------------------------------------------------
        Catch ex As Exception
            WriteLog(curPath, "MainForm", "  Timer_WatchDog_Tick Catch:" + ex.Message, True)
        End Try
    End Sub
    '****************************************************************************
    '***
    '*** 其它 運作功能
    '***
    '****************************************************************************
    '可錄製車機資料
    'S---------------------------------------------------------------------------
    Private Sub But_RecData_Click(sender As System.Object, e As System.EventArgs) Handles But_RecData.Click
        If But_RecData.BackColor = Color.Red Then
            Lab_DataSave.Text = "抄錄中"
            isOpenSaveBusData = True
            But_RecData.BackColor = Color.LawnGreen
        Else
            isOpenSaveBusData = False
            But_RecData.BackColor = Color.Red
            Lab_DataSave.Text = "開始抄錄"
            'save data
            Dim sFileDialog As New SaveFileDialog
            sFileDialog.Filter = "DAT檔 (*.dat)|*.dat" ' 只能寫入dat檔
            sFileDialog.FilterIndex = 1
            'sFileDialog.RestoreDirectory = True
            sFileDialog.InitialDirectory = curPath & "\BusDataFolder"

            If sFileDialog.ShowDialog() = DialogResult.OK Then
                Dim fileName As String = sFileDialog.FileName
                SaveAsBusDataFile(fileName)
            Else
                Dim FileToDelete As String
                FileToDelete = curPath & "\BusDataFolder\BusData.tmp"
                If System.IO.File.Exists(FileToDelete) = True Then
                    System.IO.File.Delete(FileToDelete)
                End If
            End If
        End If
    End Sub
    'E---------------------------------------------------------------------------
    'Jason20150114 系統對時功能
    'S---------------------------------------------------------------------------
    Private Sub Timer_Clock_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Clock.Tick
        Try
            '每天早上二點自動關閉,重啟AP
            'S------------------------------------------------------------------
            If Now.Hour = 2 And Now.Minute = 0 Then
                Me.Close()
            End If
            'E------------------------------------------------------------------
            setNowIC_Param_5F48() 'ask the planid every minute

            If Now.ToString("mm") = "00" Then
                'send_IC(StrToByteArray2("0F42"))
                Dim sendByte As Byte() = Incode_Step1(getSeqNum(), "0F42")
                send_IC(sendByte)
            End If
            '20150512 Auto Report 0F04 ,if IC Not Connect
            'S-------------------------------------------------------------------
            If Lab_ComStatus_IC.BackColor = Color.Red Then
                SetHardWareStatusToIPC_ERROR()
            End If

            'E-------------------------------------------------------------------
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "MainForm", "  Timer_Clock_Tick Catch:" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    'E---------------------------------------------------------------------------
    'Jason20150205 自動查詢時段資料放進XML,供中心查詢.
    '程式一啟動時查詢一次,收到5F16查詢一次.
    'S---------------------------------------------------------------------------
    Dim AutoLoad5F46StepID As Integer
    Public Sub SetAutoLoad5F46()
        If Timer_AutoLoad5F46.Enabled <> True Then
            AutoLoad5F46StepID = 1
            Timer_AutoLoad5F46.Enabled = True
        End If
    End Sub
    Private Sub Timer_AutoLoad5F46_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_AutoLoad5F46.Tick
        Try
            Dim sendByte As Byte()
            Dim tranStr As String
            tranStr = "5F460" + AutoLoad5F46StepID.ToString + "FF"
            sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
            send_IC(sendByte)
            AutoLoad5F46StepID += 1
            If AutoLoad5F46StepID > 7 Then
                Timer_AutoLoad5F46.Enabled = False
                AutoLoad5F46StepID = 1
            End If

        Catch ex As Exception
            WriteLog(curPath, "MainForm", "  Timer_AutoLoad5F46_Tick Catch:" + ex.Message, True)
        End Try
    End Sub
    'E---------------------------------------------------------------------------
    '偷放個最小化在主頁面裏
    Private Sub But_Min_Click(sender As System.Object, e As System.EventArgs) Handles But_Min.Click
        Me.WindowState = FormWindowState.Minimized

    End Sub


    Private Sub DataPicker_Start_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DataPicker_Start.ValueChanged
        Lab_DateStart.Text = Trim(DataPicker_Start.Value.ToString("yyyy/MM/dd"))
    End Sub

    Private Sub DataPicker_End_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DataPicker_End.ValueChanged
        Lab_DateEnd.Text = Trim(DataPicker_End.Value.ToString("yyyy/MM/dd"))
    End Sub

    Private Sub But_csv_Click(sender As System.Object, e As System.EventArgs) Handles But_csv.Click
        SaveXLS(CBox_History_Record.SelectedIndex)
    End Sub
    'jason 20150413 查詢回報公車優先啟動狀態
    'S-------------------------------------------------------------------------------------
    Public StartResponseIPC_Error As Boolean = False
    Private Sub Timer_AutoReportSystemRun_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_AutoReport2CC.Tick
        Timer_AutoReport2CC.Interval = 5000
        StartResponseIPC_Error = True
        ReturnBusPriorityRuningState("0")
        
    End Sub
    'E-------------------------------------------------------------------------------------
    'jason 20150413 設備異常回報加IPC設備連線異常
    'S-------------------------------------------------------------------------------------
    Private Sub Lab_ComStatus_IC_TextChanged(sender As System.Object, e As System.EventArgs) Handles Lab_ComStatus_IC.TextChanged
        If StartResponseIPC_Error Then
            SetHardWareStatusToIPC_ERROR()
        End If
    End Sub


    Private Sub Lab_ComStatus_CC_TextChanged(sender As System.Object, e As System.EventArgs) Handles Lab_ComStatus_CC.TextChanged
        If StartResponseIPC_Error Then
            SetHardWareStatusToIPC_ERROR()
        End If
    End Sub

    Private Sub Lab_ComStatus_Car_TextChanged(sender As System.Object, e As System.EventArgs) Handles Lab_ComStatus_Car.TextChanged
        If StartResponseIPC_Error Then
            SetHardWareStatusToIPC_ERROR()
        End If
    End Sub

    Private Sub Lab_ComStatus_ATMS_TextChanged(sender As System.Object, e As System.EventArgs) Handles Lab_ComStatus_ATMS.TextChanged
        If StartResponseIPC_Error Then
            SetHardWareStatusToIPC_ERROR()
        End If
    End Sub
    'E-------------------------------------------------------------------------------------

    'Jason20150527三分鐘未收到TC封包,回報IPC通訊異常
    'S-------------------------------------------------------------------------------------
    Private Sub Timer_Auto0F04_Tick(sender As System.Object, e As System.EventArgs) Handles Timer_Auto0F04.Tick

        Dim iSpan As Double = (Now() - DiffTimeOfTC_Request).TotalSeconds
        _mainForm.Show_LBox_ReceivedText_IC("無訊息己經 " + iSpan.ToString + " 秒") 'Jason 20150826 號誌通訊異常,重新啟動-II
        If iSpan > 180 Then
            Dim newHardWareStatus As String = SetIPC_ConnectError(True)
            'Jason 20150826 號誌通訊異常,重新啟動-II
            'S----------------------------------------------------
            'OLD
            'If mySerialPort.IsOpen() Then
            '    mySerialPort.Close()
            '    _mainForm.Show_LBox_ReceivedText_IC("Timer_Auto0F04_Tick OpenSerialPort".ToString)
            '    OpenSerialPort()
            'End If
            'NEW
            If iSpan > 240 Then
                System.Diagnostics.Process.Start("shutdown", "-f -r -t 00")
            End If
            'E---------------------------------------------------
        End If
    End Sub
    'E-------------------------------------------------------------------------------------

    Private Sub BusComm_Tick(sender As System.Object, e As System.EventArgs) Handles BusComm.Tick
        '_mainForm.Show_LBox_PolicyRightNowText("BusComm_Tick Ticking ")
        Try

            If BusComm_TimeStamp = Nothing Then

                '_mainForm.Show_LBox_PolicyRightNowText("No Bus Communication Yet")
            Else

                Dim DiffSecond As Integer = DateDiff(DateInterval.Second, BusComm_TimeStamp, Now)

                If DiffSecond > 10 Then
                    '_mainForm.Show_LBox_PolicyRightNowText("Lost Communication with Bus ")

                    If FiveFB4.Count > 0 Then

                        Try
                            _mainForm.Show_LBox_PolicyRightNowText("BackUP 離開點 關閉時相控制")
                            BusPrime_activate = False
                            Dim sendByte As Byte()
                            Dim tranStr As String = "5F100400"   '5F10  路口手動 + 時相控制
                            sendByte = Incode_Step1(getSeqNum(), MarkAACommand(tranStr))
                            '_mainForm.send_IC(sendByte)
                            '_mainForm.Show_LBox_PolicyRightNowText("離開點 啟動補償機制")
                            A1_Counter = 0
                            ActivatedBusID.Remove(FiveFB4("BusID"))
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
                            'BusStrategy_Log2(ByVal GroupID As String, ByVal CrossRoadID As String, ByVal BusID As String, ByVal BusLineID As String, ByVal GoBack As String, ByVal BusPhase As String, ByVal Bus2CrossRoad As String, ByVal Strategy As String, ByVal Currentphase As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal Play1 As String, ByVal Play2 As String)
                            Try
                                BusStrategy_Log2(_mainForm.TBox_GroupID.Text.ToString, _mainForm.TBox_CrossRoadID.Text.ToString, FiveFB4("BusID"), FiveFB4("BusLineID"), FiveFB4("GoBack"), FiveFB4("BusPhase"), FiveFB4("Bus2CrossRoad"), FiveFB4("Strategy"), FiveFB4("Currentphase"), FiveFB4("P1"), FiveFB4("P2"), FiveFB4("P3"), FiveFB4("Play1"), FiveFB4("Play2"))
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

                        Catch pp As Exception
                            _mainForm.Show_LBox_PolicyRightNowText("$$$$$$$$$$$ Error in BackupP3 " + pp.Message)
                        End Try

                    End If



                    BusPrime_activate = False
                    Phase_Commands.Clear()
                    FiveFB4.Clear()
                    A1_Counter = 0
                    nowPlayBusID = "-1"
                    SlowBusID.Clear()
                    ActivatedBusID.Clear()
                    BusComm_CommunicationStamp.Clear()
                    BusComm_TimeStamp = Nothing

                    _mainForm.Show_LBox_PolicyRightNowText("Bus left, Clear all  Bus Commands ")
                Else
                    '_mainForm.Show_LBox_PolicyRightNowText("Communicating with Bus ")

                End If



            End If

            Try
                If nowPlayBusID <> "-1" Then

                    Dim BusComm_LastTime As DateTime = BusComm_CommunicationStamp(nowPlayBusID)

                    Dim DiffSecond As Integer = DateDiff(DateInterval.Second, BusComm_LastTime, Now)

                    If DiffSecond > 300 Then

                        nowPlayBusID = "-1"
                        A1_Counter = 0
                        'BusComm_CommunicationStamp.Clear()
                        BusComm_CommunicationStamp.Remove(nowPlayBusID)

                    End If

                End If

            Catch ex As Exception
                _mainForm.Show_LBox_PolicyRightNowText("ErrorBusComm_CommunicationStamp" + ex.Message)
            End Try


        Catch ex As Exception
            _mainForm.Show_LBox_PolicyRightNowText("Error in BusComm_Tick " + ex.Message)
        End Try


    End Sub
End Class
