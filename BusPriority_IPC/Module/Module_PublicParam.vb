Imports System.IO
Imports System.Data.OleDb
Imports System.Collections.ObjectModel

Module Module_PublicParam
    '--Version MustFill-請轉成Hex
    Public VersionYear As String = "68" '104 HEX
    Public VersionMonth As String = "05" 'HEX
    Public VersionDay As String = "0C" 'HEX
    Public VersionID As String = "01"  '0.1  0.0~9.9

    '-- File Parameter
    Public _logEnable As Integer = 1 'log
    Public curPath As String

    '-- Device Parameter
    Public COMMON_GroupID As String
    Public COMMON_GroupName As String
    Public COMMON_EquipID As String
    Public SelectCrossRoadID As String 'jason 20150413 OTA SaveTo Table

    '-- Device Parameter
    Public SERIAL_Baudrate As String
    Public SERIAL_Databits As String
    Public SERIAL_Parity As String
    Public SERIAL_COMPortName As String
    Public SERIAL_Stopbits As String

    Public IP_CC As String
    Public PORT_CC_Send As String
    Public PORT_CC_Receive As String

    Public PORT_ATMS_Receive As String

    Public IP_CAR As String
    Public PORT_CAR As String

    Public All_Phases As String() = {"01", "02", "03", "04", "05", "06", "07", "08"}
    Public RefundSwitch As Boolean = False


    Public Current_Planid As String
    Public Changed_Planid As Boolean = False

    Public TotalCycleSec As Integer = 0
    Public TotalCycleMin As String

    Public TotalPhase As String
    Public TotalPhaseInt As Integer
    Public SaveData_5F03_TimeStamp As Date
    Public SaveData_5F03_LastPhase As String

    '-- BusPrim Parameter
    Public CrossRoadList As New Hashtable '-->BusPriority_daemon
    Public TriggerPointdList As New Hashtable  '-->BusPriority_daemon
    Public SegmentDataList As New Hashtable '-->BusPriority_daemon
    Public Phase_Commands As New Hashtable
    Public Original_Phase_Step As New Hashtable
    Public Monitor_Phase_Step As New Hashtable
    Public Refund_Commands As New Hashtable
    Public Current_BusLineID As String
    Public BusLineList As New Hashtable   'Group,BusLine 功能開發
    Public A1_Counter As Integer = 0
    Public BusStopDist_Tab As New Hashtable
    Public BusStopDelay_Tab As New Hashtable
    Public Total_BusDelay As Integer = 0
    Public isBusStopNear As Boolean = False
    Public RanFullCycle As Boolean = False

    Public Payback As New Hashtable
   
    Public SlowBusID As New Hashtable
    Public ActivatedBusID As New Hashtable



    Dim A1Speed = New List(Of String)

    Public FiveFB4 As New Hashtable

    Public BusPrime_activate As Boolean = False

    Public CrossRoadCenter As String

    Public TriggerPointxy As New Hashtable
    Public TriggerPointP123_Direction As New Hashtable
    Public BusGoBack_Direction As New Hashtable

    Public BusComm_TimeStamp As DateTime = Nothing

    Public BusComm_CommunicationStamp As New Hashtable

    Public Bus_Distance As New Hashtable

    Public PolicySpeedLimit As Integer '-->BusPriority_daemon
    Public PolicyDiffSecond As Integer '-->BusPriority_daemon
    Public isEnableBusPriority As Boolean
    Public BusPassPhases As BitArray = New BitArray(8)
    '-- DB Param
    Public DB_ACCESS_ENABLE As String
    Public DB_ACCESS_DISABLE_DEVICEID As String
    Public DB_UserId As String
    Public DB_PassWd As String
    Public DB_SevName As String
    Public DB_DBName As String
    Public DB_Error As Boolean

    Public DB_Check As String 'jason 20150413 檢查表格及檢視表是否存在
    Public HardWareStatusFrom0F04 As String = "0000" 'jason 20150413 設備異常回報加IPC設備連線異常
    '-- Other Param
    Public LBox_limit As Integer
    Public WDRemoteIP As String
    Public WDRemotePort As String

    '-- Signal Param
    Public orgNowSignalStatusString, NowSignalStatusString, NowSingalMap, NowSubPhaseIDstring, NowStepIDstring, NowStepSec, LastSubPhaseIDstring, LastSubPhaseIDstring2 As String
    '-- SaveBusDataEnable
    Public isOpenSaveBusData As Boolean   '可錄製車機資料

    Public OnlyOneBusID As String 'Jason 20150122 TestMode
    Public OTARebootFlag As String 'Jason 20150205 OTA Modify

    Public NEAR_BusStop As String

    Public isRunSystemFromCC        '總開關協定控制
    Public isRunSystemFromSeqment   '總開關協定控制
    Public Sub setWorkFolderPath()
        Dim nIndex As Integer
        curPath = Trim(System.Reflection.Assembly.GetExecutingAssembly().Location)
        nIndex = curPath.LastIndexOf("\")
        curPath = curPath.Substring(0, nIndex)
        If Not File.Exists(curPath + "\BusPriority_IPC.ini") Then
            MessageBox.Show("BusPriority_IPC.ini不存在!", "請注意", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            MainForm.Close()
        End If
    End Sub

    Public Sub getAll_ParamINI()
        Dim strIniFile As String = curPath + "\BusPriority_IPC.ini"

        Try
            Dim pp As String = GetIniInfo(strIniFile, "PP", "9600")
            SERIAL_Baudrate = GetIniInfo(strIniFile, "BAUDRATE", "9600")
            SERIAL_Databits = GetIniInfo(strIniFile, "DATABITS", "8")
            SERIAL_Parity = GetIniInfo(strIniFile, "PARITY", "None")
            SERIAL_COMPortName = GetIniInfo(strIniFile, "COMPORTNAME", "COM1")
            SERIAL_Stopbits = GetIniInfo(strIniFile, "STOPBITS", "1")

            IP_CC = GetIniInfo(strIniFile, "IP_CC", "127.0.0.1")
            PORT_CC_Send = GetIniInfo(strIniFile, "PORT_CC_SEND", "8888")
            PORT_CC_Receive = GetIniInfo(strIniFile, "PORT_CC_RECEIVE", "8888")

            PORT_ATMS_Receive = GetIniInfo(strIniFile, "PORT_ATMS_RECEIVE", "8888")

            IP_CAR = GetIniInfo(strIniFile, "IP_CAR", "127.0.0.1")
            PORT_CAR = GetIniInfo(strIniFile, "PORT_CAR", "8888")

            LBox_limit = GetIniInfo(strIniFile, "LBox_LIMIT", "100")

            DB_ACCESS_ENABLE = GetIniInfo(strIniFile, "DB_ACCESS_ENABLE", "1")
            DB_ACCESS_DISABLE_DEVICEID = GetIniInfo(strIniFile, "DB_ACCESS_DISABLE_DEVICEID", "FFFF")
            DB_UserId = GetIniInfo(strIniFile, "UserId", "")
            DB_PassWd = GetIniInfo(strIniFile, "Password", "")
            DB_SevName = GetIniInfo(strIniFile, "ServerName", "")
            DB_DBName = GetIniInfo(strIniFile, "DataBase", "")
            DB_Check = GetIniInfo(strIniFile, "DB_CHECK", "1") 'jason 20150413 檢查表格及檢視表是否存在

            NEAR_BusStop = GetIniInfo(strIniFile, "NEAR_BusStop", "0")

            BusStopDelay_Tab.Add("BusStopDelay_1", GetIniInfo(strIniFile, "BusStopDelay_Go", 0).ToString)
            BusStopDelay_Tab.Add("BusStopDelay_2", GetIniInfo(strIniFile, "BusStopDelay_Back", 0).ToString)
            BusStopDelay_Tab.Add("BusStop2Cross_1", GetIniInfo(strIniFile, "BusStop2Cross_Go", 0).ToString)
            BusStopDelay_Tab.Add("BusStop2Cross_2", GetIniInfo(strIniFile, "BusStop2Cross_Go", 0).ToString)

            PolicySpeedLimit = Val(GetIniInfo(strIniFile, "SPEEDLIMIET", "15"))
            PolicyDiffSecond = Val(GetIniInfo(strIniFile, "DIFFSECOND", "5"))

            WDRemoteIP = GetIniInfo(strIniFile, "WDRemoteIP", "127.0.0.1")
            WDRemotePort = GetIniInfo(strIniFile, "WDRemotePort", "9000")

            isEnableBusPriority = True

            '可錄製車機資料
            'S-----------------------------------------------------------------------
            isOpenSaveBusData = False
            Dim FileToDelete As String
            FileToDelete = curPath & "\BusDataFolder\BusData.tmp"
            If System.IO.File.Exists(FileToDelete) = True Then
                System.IO.File.Delete(FileToDelete)
            End If
            'E-----------------------------------------------------------------------
            OnlyOneBusID = GetIniInfo(strIniFile, "OnlyOneBusID", "") 'Jason 20150122 TestMode
            OTARebootFlag = Val(GetIniInfo(strIniFile, "OTARebootFlag", "0")) 'Jason 20150205 OTA Modify

            isRunSystemFromCC = GetIniInfo(strIniFile, "isRunSystemFromCC", "1") '總開關協定控制

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_PublicParam", "getAll_ParamINI Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try

    End Sub

    Public Sub init_Configdata(ByVal vCrossRoadID As String)
        Try
            '-------------------------------------------------------------------------------
            'Serial Parma由INI設定
            BusPriority_IPC.MainForm.CBox_PortName.Text = SERIAL_COMPortName
            BusPriority_IPC.MainForm.CBox_Baudrate.Text = SERIAL_Baudrate
            BusPriority_IPC.MainForm.CBox_Databits.Text = SERIAL_Databits
            BusPriority_IPC.MainForm.CBox_Parity.Text = SERIAL_Parity
            BusPriority_IPC.MainForm.CBox_Stopbits.Text = SERIAL_Stopbits
            '-------------------------------------------------------------------------------
            '中心Param由INI設定
            BusPriority_IPC.MainForm.TBox_IP.Text = IP_CC
            BusPriority_IPC.MainForm.TBox_CCPort_Send.Text = PORT_CC_Send
            BusPriority_IPC.MainForm.TBox_CCPort_Receive.Text = PORT_CC_Receive

            BusPriority_IPC.MainForm.TBox_ATMSPort_Receive.Text = PORT_ATMS_Receive
            '-------------------------------------------------------------------------------
            '車機Param由INI設定
            BusPriority_IPC.MainForm.TBox_CarIP.Text = IP_CAR
            BusPriority_IPC.MainForm.TBox_CarPort.Text = PORT_CAR
            '-------------------------------------------------------------------------------
            'DB Param由INI設定
            BusPriority_IPC.MainForm.TBox_ServerName.Text = DB_SevName
            BusPriority_IPC.MainForm.TBox_DataBaseName.Text = DB_DBName
            BusPriority_IPC.MainForm.TBox_LoginName.Text = DB_UserId
            BusPriority_IPC.MainForm.TBox_LoginPassword.Text = DB_PassWd
            '-------------------------------------------------------------------------------
            BusPriority_IPC.MainForm.TBox_CC_Config.Text = "[UDP]IP－" + IP_CC + "/SendPort－" + PORT_CC_Send + "/ReceivePort－" + PORT_CC_Receive

            BusPriority_IPC.MainForm.TBox_Car_Config.Text = "[TCP Client]IP－" + IP_CAR + "/Port－" + PORT_CAR
            BusPriority_IPC.MainForm.TBox_IC_Config.Text = "[Serial]COM－" + SERIAL_COMPortName + "/Baudrate－" + SERIAL_Baudrate + "/Parity－" + SERIAL_Parity + "/Databits－" + SERIAL_Databits + "/Stopbits－" + SERIAL_Stopbits

            '-------------------------------------------------------------------------------
            BusPriority_IPC.MainForm.TBox_GroupID.Text = Trim(COMMON_GroupID)
            BusPriority_IPC.MainForm.TBox_GroupName.Text = Trim(COMMON_GroupName)
            BusPriority_IPC.MainForm.TBox_CrossRoadID.Text = Trim(vCrossRoadID)
            If DB_ACCESS_ENABLE = "1" Then
                BusPriority_IPC.MainForm.TBox_CrossRoadName.Text = CrossRoadList.Item(vCrossRoadID).CrossRoadName
                BusPriority_IPC.MainForm.TBox_EditDeviceID.Text = CrossRoadList.Item(vCrossRoadID).CrossRoad_IC_Addr
            Else
                BusPriority_IPC.MainForm.TBox_CrossRoadName.Text = ""
                BusPriority_IPC.MainForm.TBox_EditDeviceID.Text = DB_ACCESS_DISABLE_DEVICEID
            End If

            If CrossRoadList.Item(vCrossRoadID).CrossRoad_isMaster = "1" Then
                BusPriority_IPC.MainForm.CBox_isMaster.Checked = True
            Else
                BusPriority_IPC.MainForm.CBox_isMaster.Checked = False
            End If

            BusPriority_IPC.MainForm.TBox_PolicySpeedLimit.Text = PolicySpeedLimit.ToString
            BusPriority_IPC.MainForm.TBox_PolicyDiffSecond.Text = PolicyDiffSecond.ToString

            BusPriority_IPC.MainForm.TBox_PolicyDiffSecond.Text = PolicyDiffSecond.ToString

            BusPriority_IPC.MainForm.TBox_OnlyBusID.Text = OnlyOneBusID.ToString

            'Group,BusLine 功能開發
            'S--------------------------------------------------------------------------------------------------------
            'E--------------------------------------------------------------------------------------------------------
            BusPriority_IPC.MainForm.Lab_DateStart.Text = Now.ToString("yyyy/MM/dd")
            BusPriority_IPC.MainForm.Lab_DateEnd.Text = Now.ToString("yyyy/MM/dd")
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_PublicParam", "init_Configdata Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try

    End Sub
    Public Sub save_Configdata()
        Try
            WriteINIValue("Common", "CrossRoadID", Trim(BusPriority_IPC.MainForm.TBox_CrossRoadID.Text))
            WriteINIValue("Common", "EquipID", Trim(BusPriority_IPC.MainForm.TBox_EditDeviceID.Text))


            WriteINIValue("SERIAL", "COMPORTNAME", Trim(BusPriority_IPC.MainForm.CBox_PortName.Text))
            WriteINIValue("SERIAL", "BAUDRATE", Trim(BusPriority_IPC.MainForm.CBox_Baudrate.Text))
            WriteINIValue("SERIAL", "DATABITS", Trim(BusPriority_IPC.MainForm.CBox_Databits.Text))
            WriteINIValue("SERIAL", "PARITY", Trim(BusPriority_IPC.MainForm.CBox_Parity.Text))
            WriteINIValue("SERIAL", "STOPBITS", Trim(BusPriority_IPC.MainForm.CBox_Stopbits.Text))


            WriteINIValue("CONNECT_CC", "IP_CC", Trim(BusPriority_IPC.MainForm.TBox_IP.Text))
            WriteINIValue("CONNECT_CC", "PORT_CC_SEND", Trim(BusPriority_IPC.MainForm.TBox_CCPort_Send.Text))
            WriteINIValue("CONNECT_CC", "PORT_CC_RECEIVE", Trim(BusPriority_IPC.MainForm.TBox_CCPort_Receive.Text))

            WriteINIValue("CONNECT_ATMS", "PORT_ATMS_RECEIVE", Trim(BusPriority_IPC.MainForm.TBox_ATMSPort_Receive.Text))

            WriteINIValue("CONNECT_CAR", "IP_CAR", Trim(BusPriority_IPC.MainForm.TBox_CarIP.Text))
            WriteINIValue("CONNECT_CAR", "PORT_CAR", Trim(BusPriority_IPC.MainForm.TBox_CarPort.Text))


            WriteINIValue("DB Setting", "ServerName", Trim(BusPriority_IPC.MainForm.TBox_ServerName.Text))
            WriteINIValue("DB Setting", "DataBase", Trim(BusPriority_IPC.MainForm.TBox_DataBaseName.Text))
            WriteINIValue("DB Setting", "UserId", Trim(BusPriority_IPC.MainForm.TBox_LoginName.Text))
            WriteINIValue("DB Setting", "Password", Trim(BusPriority_IPC.MainForm.TBox_LoginPassword.Text))

            WriteINIValue("BUS_POLICY", "SPEEDLIMIET", Trim(BusPriority_IPC.MainForm.TBox_PolicySpeedLimit.Text))
            WriteINIValue("BUS_POLICY", "DIFFSECOND", Trim(BusPriority_IPC.MainForm.TBox_PolicyDiffSecond.Text))

            WriteINIValue("BUS_POLICY", "DIFFSECOND", Trim(BusPriority_IPC.MainForm.TBox_PolicyDiffSecond.Text))

            WriteINIValue("Common", "OnlyOneBusID", Trim(BusPriority_IPC.MainForm.TBox_OnlyBusID.Text))
            OnlyOneBusID = Trim(BusPriority_IPC.MainForm.TBox_OnlyBusID.Text)

            MessageBox.Show("組態已儲存完成，請重新啟動系統!", "請確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_PublicParam", "save_Configdata Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try

    End Sub
    Public Sub getSystemSerialPort()
        Dim ports As ReadOnlyCollection(Of String) = My.Computer.Ports.SerialPortNames
        BusPriority_IPC.MainForm.CBox_PortName.Items.Clear()
        For Each port As String In ports
            BusPriority_IPC.MainForm.CBox_PortName.Items.Add(port)
        Next
    End Sub
End Module


