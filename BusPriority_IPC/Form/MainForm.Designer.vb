<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Title2 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel_Top = New System.Windows.Forms.Panel()
        Me.But_Min = New System.Windows.Forms.Button()
        Me.TBox_StepSec = New System.Windows.Forms.TextBox()
        Me.TBox_StepOrder = New System.Windows.Forms.TextBox()
        Me.TBox_SubPhaseOrder = New System.Windows.Forms.TextBox()
        Me.TBox_Dir = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TBox_BusPolicy = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label_BusPrimEnable = New System.Windows.Forms.Label()
        Me.TBox_Sgm = New System.Windows.Forms.TextBox()
        Me.TBox_Car_Config = New System.Windows.Forms.TextBox()
        Me.TBox_CC_Config = New System.Windows.Forms.TextBox()
        Me.TBox_IC_Config = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBox_LightRec_5 = New System.Windows.Forms.TextBox()
        Me.TBox_LightRec_4 = New System.Windows.Forms.TextBox()
        Me.TBox_LightRec_3 = New System.Windows.Forms.TextBox()
        Me.TBox_LightRec_2 = New System.Windows.Forms.TextBox()
        Me.TBox_LightRec_1 = New System.Windows.Forms.TextBox()
        Me.TBox_LightRec_0 = New System.Windows.Forms.TextBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.But_IC_Download = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBox_IC_Download = New System.Windows.Forms.TextBox()
        Me.Panel_Monitor = New System.Windows.Forms.Panel()
        Me.Lab_ATMS = New System.Windows.Forms.Label()
        Me.But_clean_ATMS = New System.Windows.Forms.Button()
        Me.Lab_ComStatus_ATMS = New System.Windows.Forms.Label()
        Me.LBox_ATMS = New System.Windows.Forms.ListBox()
        Me.Lab_ComStatus_IC = New System.Windows.Forms.Label()
        Me.Lab_ComStatus_Car = New System.Windows.Forms.Label()
        Me.Lab_ComStatus_CC = New System.Windows.Forms.Label()
        Me.But_clean_CAR = New System.Windows.Forms.Button()
        Me.But_clean_CC = New System.Windows.Forms.Button()
        Me.But_clean_IC = New System.Windows.Forms.Button()
        Me.Lab_CAR = New System.Windows.Forms.Label()
        Me.Lab_CC = New System.Windows.Forms.Label()
        Me.Lab_IC = New System.Windows.Forms.Label()
        Me.LBox_Car = New System.Windows.Forms.ListBox()
        Me.LBox_CC = New System.Windows.Forms.ListBox()
        Me.LBox_IC = New System.Windows.Forms.ListBox()
        Me.Panel_Manage = New System.Windows.Forms.Panel()
        Me.LinkLabel_Seg2 = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_Seg1 = New System.Windows.Forms.LinkLabel()
        Me.PanelOfConfig_busPrim = New System.Windows.Forms.Panel()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.TBox_OnlyBusID = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.TBox_PolicyDiffSecond = New System.Windows.Forms.TextBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TBox_PolicySpeedLimit = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.PanelOfConfig_db = New System.Windows.Forms.Panel()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.TBox_ServerName = New System.Windows.Forms.TextBox()
        Me.TBox_DataBaseName = New System.Windows.Forms.TextBox()
        Me.TBox_LoginName = New System.Windows.Forms.TextBox()
        Me.TBox_LoginPassword = New System.Windows.Forms.TextBox()
        Me.PanelOfConfig_Com = New System.Windows.Forms.Panel()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TBox_ATMSPort_Receive = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.TBox_CCPort_Receive = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CBox_PortName = New System.Windows.Forms.ComboBox()
        Me.CBox_Baudrate = New System.Windows.Forms.ComboBox()
        Me.CBox_Parity = New System.Windows.Forms.ComboBox()
        Me.CBox_Databits = New System.Windows.Forms.ComboBox()
        Me.CBox_Stopbits = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TBox_IP = New System.Windows.Forms.TextBox()
        Me.TBox_CCPort_Send = New System.Windows.Forms.TextBox()
        Me.TBox_CarPort = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.TBox_CarIP = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.PanelOfConfig_ID = New System.Windows.Forms.Panel()
        Me.CBox_isMaster = New System.Windows.Forms.CheckBox()
        Me.TBox_CrossRoadName = New System.Windows.Forms.TextBox()
        Me.TBox_GroupName = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TBox_GroupID = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label_CrossRoadID = New System.Windows.Forms.Label()
        Me.TBox_CrossRoadID = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.TBox_EditDeviceID = New System.Windows.Forms.TextBox()
        Me.LinkLabel_busPrim = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_db = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_Com = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_ID = New System.Windows.Forms.LinkLabel()
        Me.But_ConfigSave = New System.Windows.Forms.Button()
        Me.DGrid_TriggerPoint = New System.Windows.Forms.DataGridView()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label_Point = New System.Windows.Forms.Label()
        Me.DGrid_Segment = New System.Windows.Forms.DataGridView()
        Me.Label_Seg = New System.Windows.Forms.Label()
        Me.Label_Config = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.Timer_Connect_TCP = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_AnalysisLightOutBySoft = New System.Windows.Forms.Timer(Me.components)
        Me.Panel_Record = New System.Windows.Forms.Panel()
        Me.Panel_Record_RightNow = New System.Windows.Forms.Panel()
        Me.Lab_DataSave = New System.Windows.Forms.Label()
        Me.But_RecData = New System.Windows.Forms.Button()
        Me.CBox_Filter_A1_A2 = New System.Windows.Forms.CheckBox()
        Me.But_RecordRightNow_Clear = New System.Windows.Forms.Button()
        Me.LBox_PolicyExecute = New System.Windows.Forms.ListBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Panel_Record_History = New System.Windows.Forms.Panel()
        Me.TBox_Interval = New System.Windows.Forms.TextBox()
        Me.But_csv = New System.Windows.Forms.Button()
        Me.Lab_Interval = New System.Windows.Forms.Label()
        Me.Lab_DateEnd = New System.Windows.Forms.Label()
        Me.Lab_DateStart = New System.Windows.Forms.Label()
        Me.Chart_Data = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.But_Graph = New System.Windows.Forms.Button()
        Me.CBox_CrossRoadID_His = New System.Windows.Forms.ComboBox()
        Me.CBox_History_Record = New System.Windows.Forms.ComboBox()
        Me.DGrid_History = New System.Windows.Forms.DataGridView()
        Me.But_HistoryRun = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataPicker_Start = New System.Windows.Forms.DateTimePicker()
        Me.DataPicker_End = New System.Windows.Forms.DateTimePicker()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.LinkLabel_History = New System.Windows.Forms.LinkLabel()
        Me.LinkLabel_RecordRightNow = New System.Windows.Forms.LinkLabel()
        Me.Label_Histroy = New System.Windows.Forms.Label()
        Me.ShapeContainer2 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Panel_CrossRoadTree = New System.Windows.Forms.Panel()
        Me.Label_CrossRoad = New System.Windows.Forms.Label()
        Me.TView_CrossRoad = New System.Windows.Forms.TreeView()
        Me.Timer_RefreshDataGrid = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_SegmentAutoSend = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_WatchDog = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Clock = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_AutoLoad5F46 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_AutoReport2CC = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_Auto0F04 = New System.Windows.Forms.Timer(Me.components)
        Me.BusComm = New System.Windows.Forms.Timer(Me.components)
        Me.Timer_IC_Buff = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel_Top.SuspendLayout()
        Me.Panel_Monitor.SuspendLayout()
        Me.Panel_Manage.SuspendLayout()
        Me.PanelOfConfig_busPrim.SuspendLayout()
        Me.PanelOfConfig_db.SuspendLayout()
        Me.PanelOfConfig_Com.SuspendLayout()
        Me.PanelOfConfig_ID.SuspendLayout()
        CType(Me.DGrid_TriggerPoint, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid_Segment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_Record.SuspendLayout()
        Me.Panel_Record_RightNow.SuspendLayout()
        Me.Panel_Record_History.SuspendLayout()
        CType(Me.Chart_Data, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGrid_History, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel_CrossRoadTree.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.ToolStripStatusLabel2})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 720)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1276, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(132, 17)
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(0, 17)
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MenuStrip1.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1276, 24)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(68, 20)
        Me.ToolStripMenuItem1.Text = "系統監視"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(68, 20)
        Me.ToolStripMenuItem2.Text = "系統管理"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(68, 20)
        Me.ToolStripMenuItem3.Text = "執行記錄"
        '
        'Panel_Top
        '
        Me.Panel_Top.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Top.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Panel_Top.Controls.Add(Me.But_Min)
        Me.Panel_Top.Controls.Add(Me.TBox_StepSec)
        Me.Panel_Top.Controls.Add(Me.TBox_StepOrder)
        Me.Panel_Top.Controls.Add(Me.TBox_SubPhaseOrder)
        Me.Panel_Top.Controls.Add(Me.TBox_Dir)
        Me.Panel_Top.Controls.Add(Me.Label37)
        Me.Panel_Top.Controls.Add(Me.Label36)
        Me.Panel_Top.Controls.Add(Me.Label35)
        Me.Panel_Top.Controls.Add(Me.Label20)
        Me.Panel_Top.Controls.Add(Me.TBox_BusPolicy)
        Me.Panel_Top.Controls.Add(Me.Label9)
        Me.Panel_Top.Controls.Add(Me.Label_BusPrimEnable)
        Me.Panel_Top.Controls.Add(Me.TBox_Sgm)
        Me.Panel_Top.Controls.Add(Me.TBox_Car_Config)
        Me.Panel_Top.Controls.Add(Me.TBox_CC_Config)
        Me.Panel_Top.Controls.Add(Me.TBox_IC_Config)
        Me.Panel_Top.Controls.Add(Me.Label7)
        Me.Panel_Top.Controls.Add(Me.Label6)
        Me.Panel_Top.Controls.Add(Me.Label5)
        Me.Panel_Top.Controls.Add(Me.Label3)
        Me.Panel_Top.Controls.Add(Me.Label4)
        Me.Panel_Top.Controls.Add(Me.TBox_LightRec_5)
        Me.Panel_Top.Controls.Add(Me.TBox_LightRec_4)
        Me.Panel_Top.Controls.Add(Me.TBox_LightRec_3)
        Me.Panel_Top.Controls.Add(Me.TBox_LightRec_2)
        Me.Panel_Top.Controls.Add(Me.TBox_LightRec_1)
        Me.Panel_Top.Controls.Add(Me.TBox_LightRec_0)
        Me.Panel_Top.Controls.Add(Me.Label93)
        Me.Panel_Top.Controls.Add(Me.Label94)
        Me.Panel_Top.Controls.Add(Me.Label89)
        Me.Panel_Top.Controls.Add(Me.Label90)
        Me.Panel_Top.Controls.Add(Me.Label88)
        Me.Panel_Top.Controls.Add(Me.Label87)
        Me.Panel_Top.Controls.Add(Me.Label86)
        Me.Panel_Top.Controls.Add(Me.Button1)
        Me.Panel_Top.Controls.Add(Me.But_IC_Download)
        Me.Panel_Top.Controls.Add(Me.Label1)
        Me.Panel_Top.Controls.Add(Me.TBox_IC_Download)
        Me.Panel_Top.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel_Top.Location = New System.Drawing.Point(72, 27)
        Me.Panel_Top.Name = "Panel_Top"
        Me.Panel_Top.Size = New System.Drawing.Size(1187, 141)
        Me.Panel_Top.TabIndex = 2
        '
        'But_Min
        '
        Me.But_Min.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.But_Min.Cursor = System.Windows.Forms.Cursors.PanSouth
        Me.But_Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.But_Min.ForeColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.But_Min.Location = New System.Drawing.Point(2, 3)
        Me.But_Min.Name = "But_Min"
        Me.But_Min.Size = New System.Drawing.Size(14, 135)
        Me.But_Min.TabIndex = 72
        Me.But_Min.Text = "－"
        Me.But_Min.UseVisualStyleBackColor = False
        '
        'TBox_StepSec
        '
        Me.TBox_StepSec.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_StepSec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_StepSec.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_StepSec.ForeColor = System.Drawing.Color.Black
        Me.TBox_StepSec.Location = New System.Drawing.Point(494, 83)
        Me.TBox_StepSec.Name = "TBox_StepSec"
        Me.TBox_StepSec.ReadOnly = True
        Me.TBox_StepSec.Size = New System.Drawing.Size(36, 23)
        Me.TBox_StepSec.TabIndex = 71
        '
        'TBox_StepOrder
        '
        Me.TBox_StepOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_StepOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_StepOrder.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_StepOrder.ForeColor = System.Drawing.Color.Black
        Me.TBox_StepOrder.Location = New System.Drawing.Point(396, 83)
        Me.TBox_StepOrder.Name = "TBox_StepOrder"
        Me.TBox_StepOrder.ReadOnly = True
        Me.TBox_StepOrder.Size = New System.Drawing.Size(36, 23)
        Me.TBox_StepOrder.TabIndex = 70
        '
        'TBox_SubPhaseOrder
        '
        Me.TBox_SubPhaseOrder.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_SubPhaseOrder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_SubPhaseOrder.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_SubPhaseOrder.ForeColor = System.Drawing.Color.Black
        Me.TBox_SubPhaseOrder.Location = New System.Drawing.Point(307, 83)
        Me.TBox_SubPhaseOrder.Name = "TBox_SubPhaseOrder"
        Me.TBox_SubPhaseOrder.ReadOnly = True
        Me.TBox_SubPhaseOrder.Size = New System.Drawing.Size(36, 23)
        Me.TBox_SubPhaseOrder.TabIndex = 69
        '
        'TBox_Dir
        '
        Me.TBox_Dir.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_Dir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_Dir.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_Dir.ForeColor = System.Drawing.Color.Black
        Me.TBox_Dir.Location = New System.Drawing.Point(134, 83)
        Me.TBox_Dir.Name = "TBox_Dir"
        Me.TBox_Dir.ReadOnly = True
        Me.TBox_Dir.Size = New System.Drawing.Size(125, 23)
        Me.TBox_Dir.TabIndex = 68
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label37.Location = New System.Drawing.Point(442, 88)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(51, 15)
        Me.Label37.TabIndex = 66
        Me.Label37.Text = "步階時間"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label36.Location = New System.Drawing.Point(353, 88)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(40, 15)
        Me.Label36.TabIndex = 65
        Me.Label36.Text = "步階序"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label35.Location = New System.Drawing.Point(268, 88)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(40, 15)
        Me.Label35.TabIndex = 64
        Me.Label35.Text = "分相序"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(95, 88)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(29, 15)
        Me.Label20.TabIndex = 63
        Me.Label20.Text = "方向"
        '
        'TBox_BusPolicy
        '
        Me.TBox_BusPolicy.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_BusPolicy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_BusPolicy.Enabled = False
        Me.TBox_BusPolicy.Location = New System.Drawing.Point(594, 9)
        Me.TBox_BusPolicy.Name = "TBox_BusPolicy"
        Me.TBox_BusPolicy.ReadOnly = True
        Me.TBox_BusPolicy.Size = New System.Drawing.Size(542, 23)
        Me.TBox_BusPolicy.TabIndex = 61
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(532, 12)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 60
        Me.Label9.Text = "執行策略"
        '
        'Label_BusPrimEnable
        '
        Me.Label_BusPrimEnable.AutoSize = True
        Me.Label_BusPrimEnable.BackColor = System.Drawing.Color.Red
        Me.Label_BusPrimEnable.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_BusPrimEnable.ForeColor = System.Drawing.Color.Black
        Me.Label_BusPrimEnable.Location = New System.Drawing.Point(475, 12)
        Me.Label_BusPrimEnable.Name = "Label_BusPrimEnable"
        Me.Label_BusPrimEnable.Size = New System.Drawing.Size(32, 16)
        Me.Label_BusPrimEnable.TabIndex = 59
        Me.Label_BusPrimEnable.Text = "關閉"
        '
        'TBox_Sgm
        '
        Me.TBox_Sgm.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_Sgm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_Sgm.Location = New System.Drawing.Point(101, 9)
        Me.TBox_Sgm.Name = "TBox_Sgm"
        Me.TBox_Sgm.ReadOnly = True
        Me.TBox_Sgm.Size = New System.Drawing.Size(261, 23)
        Me.TBox_Sgm.TabIndex = 57
        '
        'TBox_Car_Config
        '
        Me.TBox_Car_Config.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_Car_Config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_Car_Config.ForeColor = System.Drawing.Color.Black
        Me.TBox_Car_Config.Location = New System.Drawing.Point(872, 34)
        Me.TBox_Car_Config.Name = "TBox_Car_Config"
        Me.TBox_Car_Config.ReadOnly = True
        Me.TBox_Car_Config.Size = New System.Drawing.Size(264, 23)
        Me.TBox_Car_Config.TabIndex = 56
        '
        'TBox_CC_Config
        '
        Me.TBox_CC_Config.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_CC_Config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_CC_Config.ForeColor = System.Drawing.Color.Black
        Me.TBox_CC_Config.Location = New System.Drawing.Point(520, 34)
        Me.TBox_CC_Config.Name = "TBox_CC_Config"
        Me.TBox_CC_Config.ReadOnly = True
        Me.TBox_CC_Config.Size = New System.Drawing.Size(264, 23)
        Me.TBox_CC_Config.TabIndex = 55
        '
        'TBox_IC_Config
        '
        Me.TBox_IC_Config.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_IC_Config.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_IC_Config.ForeColor = System.Drawing.Color.Black
        Me.TBox_IC_Config.Location = New System.Drawing.Point(101, 34)
        Me.TBox_IC_Config.Name = "TBox_IC_Config"
        Me.TBox_IC_Config.ReadOnly = True
        Me.TBox_IC_Config.Size = New System.Drawing.Size(331, 23)
        Me.TBox_IC_Config.TabIndex = 54
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(390, 12)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 53
        Me.Label7.Text = "優先號誌功能"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "優先號誌時段"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(795, 38)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 51
        Me.Label5.Text = "車機通訊組態"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "號誌通訊組態"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(443, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 49
        Me.Label4.Text = "中心通訊組態"
        '
        'TBox_LightRec_5
        '
        Me.TBox_LightRec_5.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_LightRec_5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_LightRec_5.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_LightRec_5.ForeColor = System.Drawing.Color.Fuchsia
        Me.TBox_LightRec_5.Location = New System.Drawing.Point(1011, 59)
        Me.TBox_LightRec_5.Name = "TBox_LightRec_5"
        Me.TBox_LightRec_5.ReadOnly = True
        Me.TBox_LightRec_5.Size = New System.Drawing.Size(125, 23)
        Me.TBox_LightRec_5.TabIndex = 47
        '
        'TBox_LightRec_4
        '
        Me.TBox_LightRec_4.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_LightRec_4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_LightRec_4.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_LightRec_4.ForeColor = System.Drawing.Color.Fuchsia
        Me.TBox_LightRec_4.Location = New System.Drawing.Point(835, 59)
        Me.TBox_LightRec_4.Name = "TBox_LightRec_4"
        Me.TBox_LightRec_4.ReadOnly = True
        Me.TBox_LightRec_4.Size = New System.Drawing.Size(125, 23)
        Me.TBox_LightRec_4.TabIndex = 46
        '
        'TBox_LightRec_3
        '
        Me.TBox_LightRec_3.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_LightRec_3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_LightRec_3.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_LightRec_3.ForeColor = System.Drawing.Color.Fuchsia
        Me.TBox_LightRec_3.Location = New System.Drawing.Point(659, 59)
        Me.TBox_LightRec_3.Name = "TBox_LightRec_3"
        Me.TBox_LightRec_3.ReadOnly = True
        Me.TBox_LightRec_3.Size = New System.Drawing.Size(125, 23)
        Me.TBox_LightRec_3.TabIndex = 45
        '
        'TBox_LightRec_2
        '
        Me.TBox_LightRec_2.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_LightRec_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_LightRec_2.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_LightRec_2.ForeColor = System.Drawing.Color.Fuchsia
        Me.TBox_LightRec_2.Location = New System.Drawing.Point(483, 59)
        Me.TBox_LightRec_2.Name = "TBox_LightRec_2"
        Me.TBox_LightRec_2.ReadOnly = True
        Me.TBox_LightRec_2.Size = New System.Drawing.Size(125, 23)
        Me.TBox_LightRec_2.TabIndex = 44
        '
        'TBox_LightRec_1
        '
        Me.TBox_LightRec_1.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_LightRec_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_LightRec_1.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_LightRec_1.ForeColor = System.Drawing.Color.Fuchsia
        Me.TBox_LightRec_1.Location = New System.Drawing.Point(307, 59)
        Me.TBox_LightRec_1.Name = "TBox_LightRec_1"
        Me.TBox_LightRec_1.ReadOnly = True
        Me.TBox_LightRec_1.Size = New System.Drawing.Size(125, 23)
        Me.TBox_LightRec_1.TabIndex = 43
        '
        'TBox_LightRec_0
        '
        Me.TBox_LightRec_0.BackColor = System.Drawing.Color.FromArgb(CType(CType(173, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TBox_LightRec_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_LightRec_0.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_LightRec_0.ForeColor = System.Drawing.Color.Fuchsia
        Me.TBox_LightRec_0.Location = New System.Drawing.Point(134, 59)
        Me.TBox_LightRec_0.Name = "TBox_LightRec_0"
        Me.TBox_LightRec_0.ReadOnly = True
        Me.TBox_LightRec_0.Size = New System.Drawing.Size(125, 23)
        Me.TBox_LightRec_0.TabIndex = 42
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label93.Location = New System.Drawing.Point(971, 64)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(40, 15)
        Me.Label93.TabIndex = 41
        Me.Label93.Text = "時相六"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label94.Location = New System.Drawing.Point(795, 64)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(40, 15)
        Me.Label94.TabIndex = 40
        Me.Label94.Text = "時相五"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label89.Location = New System.Drawing.Point(619, 64)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(40, 15)
        Me.Label89.TabIndex = 39
        Me.Label89.Text = "時相四"
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label90.Location = New System.Drawing.Point(443, 64)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(40, 15)
        Me.Label90.TabIndex = 38
        Me.Label90.Text = "時相三"
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label88.Location = New System.Drawing.Point(267, 64)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(40, 15)
        Me.Label88.TabIndex = 37
        Me.Label88.Text = "時相二"
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label87.Location = New System.Drawing.Point(94, 64)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(40, 15)
        Me.Label87.TabIndex = 36
        Me.Label87.Text = "時相一"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label86.Location = New System.Drawing.Point(13, 63)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(80, 16)
        Me.Label86.TabIndex = 35
        Me.Label86.Text = "目前燈號回報"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Button1.Location = New System.Drawing.Point(622, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(72, 22)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "TEST"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'But_IC_Download
        '
        Me.But_IC_Download.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.But_IC_Download.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_IC_Download.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.But_IC_Download.Location = New System.Drawing.Point(1053, 110)
        Me.But_IC_Download.Name = "But_IC_Download"
        Me.But_IC_Download.Size = New System.Drawing.Size(62, 22)
        Me.But_IC_Download.TabIndex = 6
        Me.But_IC_Download.Text = "下載"
        Me.But_IC_Download.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "號誌手動下載"
        '
        'TBox_IC_Download
        '
        Me.TBox_IC_Download.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_IC_Download.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TBox_IC_Download.Location = New System.Drawing.Point(98, 109)
        Me.TBox_IC_Download.Name = "TBox_IC_Download"
        Me.TBox_IC_Download.Size = New System.Drawing.Size(951, 25)
        Me.TBox_IC_Download.TabIndex = 3
        Me.TBox_IC_Download.Text = "0FH+40H+00H"
        '
        'Panel_Monitor
        '
        Me.Panel_Monitor.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Monitor.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Panel_Monitor.Controls.Add(Me.Lab_ATMS)
        Me.Panel_Monitor.Controls.Add(Me.But_clean_ATMS)
        Me.Panel_Monitor.Controls.Add(Me.Lab_ComStatus_ATMS)
        Me.Panel_Monitor.Controls.Add(Me.LBox_ATMS)
        Me.Panel_Monitor.Controls.Add(Me.Lab_ComStatus_IC)
        Me.Panel_Monitor.Controls.Add(Me.Lab_ComStatus_Car)
        Me.Panel_Monitor.Controls.Add(Me.Lab_ComStatus_CC)
        Me.Panel_Monitor.Controls.Add(Me.But_clean_CAR)
        Me.Panel_Monitor.Controls.Add(Me.But_clean_CC)
        Me.Panel_Monitor.Controls.Add(Me.But_clean_IC)
        Me.Panel_Monitor.Controls.Add(Me.Lab_CAR)
        Me.Panel_Monitor.Controls.Add(Me.Lab_CC)
        Me.Panel_Monitor.Controls.Add(Me.Lab_IC)
        Me.Panel_Monitor.Controls.Add(Me.LBox_Car)
        Me.Panel_Monitor.Controls.Add(Me.LBox_CC)
        Me.Panel_Monitor.Controls.Add(Me.LBox_IC)
        Me.Panel_Monitor.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel_Monitor.Location = New System.Drawing.Point(134, 232)
        Me.Panel_Monitor.Name = "Panel_Monitor"
        Me.Panel_Monitor.Size = New System.Drawing.Size(1026, 232)
        Me.Panel_Monitor.TabIndex = 3
        '
        'Lab_ATMS
        '
        Me.Lab_ATMS.AutoSize = True
        Me.Lab_ATMS.BackColor = System.Drawing.Color.Maroon
        Me.Lab_ATMS.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_ATMS.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Lab_ATMS.Location = New System.Drawing.Point(374, 164)
        Me.Lab_ATMS.Name = "Lab_ATMS"
        Me.Lab_ATMS.Size = New System.Drawing.Size(134, 16)
        Me.Lab_ATMS.TabIndex = 30
        Me.Lab_ATMS.Text = "中心端(ATMS)通訊內容"
        '
        'But_clean_ATMS
        '
        Me.But_clean_ATMS.BackgroundImage = CType(resources.GetObject("But_clean_ATMS.BackgroundImage"), System.Drawing.Image)
        Me.But_clean_ATMS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.But_clean_ATMS.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_clean_ATMS.Location = New System.Drawing.Point(509, 164)
        Me.But_clean_ATMS.Name = "But_clean_ATMS"
        Me.But_clean_ATMS.Size = New System.Drawing.Size(16, 16)
        Me.But_clean_ATMS.TabIndex = 29
        Me.But_clean_ATMS.UseVisualStyleBackColor = True
        '
        'Lab_ComStatus_ATMS
        '
        Me.Lab_ComStatus_ATMS.AutoSize = True
        Me.Lab_ComStatus_ATMS.BackColor = System.Drawing.Color.Red
        Me.Lab_ComStatus_ATMS.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_ComStatus_ATMS.Location = New System.Drawing.Point(531, 164)
        Me.Lab_ComStatus_ATMS.Name = "Lab_ComStatus_ATMS"
        Me.Lab_ComStatus_ATMS.Size = New System.Drawing.Size(56, 16)
        Me.Lab_ComStatus_ATMS.TabIndex = 28
        Me.Lab_ComStatus_ATMS.Text = "通訊斷線"
        '
        'LBox_ATMS
        '
        Me.LBox_ATMS.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LBox_ATMS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBox_ATMS.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LBox_ATMS.FormattingEnabled = True
        Me.LBox_ATMS.ItemHeight = 16
        Me.LBox_ATMS.Location = New System.Drawing.Point(322, 41)
        Me.LBox_ATMS.Name = "LBox_ATMS"
        Me.LBox_ATMS.Size = New System.Drawing.Size(84, 98)
        Me.LBox_ATMS.TabIndex = 27
        '
        'Lab_ComStatus_IC
        '
        Me.Lab_ComStatus_IC.AutoSize = True
        Me.Lab_ComStatus_IC.BackColor = System.Drawing.Color.Red
        Me.Lab_ComStatus_IC.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_ComStatus_IC.Location = New System.Drawing.Point(138, 8)
        Me.Lab_ComStatus_IC.Name = "Lab_ComStatus_IC"
        Me.Lab_ComStatus_IC.Size = New System.Drawing.Size(56, 16)
        Me.Lab_ComStatus_IC.TabIndex = 26
        Me.Lab_ComStatus_IC.Text = "通訊斷線"
        '
        'Lab_ComStatus_Car
        '
        Me.Lab_ComStatus_Car.AutoSize = True
        Me.Lab_ComStatus_Car.BackColor = System.Drawing.Color.Red
        Me.Lab_ComStatus_Car.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_ComStatus_Car.Location = New System.Drawing.Point(942, 7)
        Me.Lab_ComStatus_Car.Name = "Lab_ComStatus_Car"
        Me.Lab_ComStatus_Car.Size = New System.Drawing.Size(56, 16)
        Me.Lab_ComStatus_Car.TabIndex = 25
        Me.Lab_ComStatus_Car.Text = "通訊斷線"
        '
        'Lab_ComStatus_CC
        '
        Me.Lab_ComStatus_CC.AutoSize = True
        Me.Lab_ComStatus_CC.BackColor = System.Drawing.Color.Red
        Me.Lab_ComStatus_CC.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_ComStatus_CC.Location = New System.Drawing.Point(557, 9)
        Me.Lab_ComStatus_CC.Name = "Lab_ComStatus_CC"
        Me.Lab_ComStatus_CC.Size = New System.Drawing.Size(56, 16)
        Me.Lab_ComStatus_CC.TabIndex = 24
        Me.Lab_ComStatus_CC.Text = "通訊斷線"
        '
        'But_clean_CAR
        '
        Me.But_clean_CAR.BackgroundImage = CType(resources.GetObject("But_clean_CAR.BackgroundImage"), System.Drawing.Image)
        Me.But_clean_CAR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.But_clean_CAR.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_clean_CAR.Location = New System.Drawing.Point(794, 8)
        Me.But_clean_CAR.Name = "But_clean_CAR"
        Me.But_clean_CAR.Size = New System.Drawing.Size(16, 16)
        Me.But_clean_CAR.TabIndex = 23
        Me.But_clean_CAR.UseVisualStyleBackColor = True
        '
        'But_clean_CC
        '
        Me.But_clean_CC.BackgroundImage = CType(resources.GetObject("But_clean_CC.BackgroundImage"), System.Drawing.Image)
        Me.But_clean_CC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.But_clean_CC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_clean_CC.Location = New System.Drawing.Point(461, 8)
        Me.But_clean_CC.Name = "But_clean_CC"
        Me.But_clean_CC.Size = New System.Drawing.Size(16, 16)
        Me.But_clean_CC.TabIndex = 22
        Me.But_clean_CC.UseVisualStyleBackColor = True
        '
        'But_clean_IC
        '
        Me.But_clean_IC.BackgroundImage = CType(resources.GetObject("But_clean_IC.BackgroundImage"), System.Drawing.Image)
        Me.But_clean_IC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.But_clean_IC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_clean_IC.Location = New System.Drawing.Point(121, 8)
        Me.But_clean_IC.Name = "But_clean_IC"
        Me.But_clean_IC.Size = New System.Drawing.Size(16, 16)
        Me.But_clean_IC.TabIndex = 21
        Me.But_clean_IC.UseVisualStyleBackColor = True
        '
        'Lab_CAR
        '
        Me.Lab_CAR.AutoSize = True
        Me.Lab_CAR.BackColor = System.Drawing.Color.Maroon
        Me.Lab_CAR.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_CAR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Lab_CAR.Location = New System.Drawing.Point(677, 9)
        Me.Lab_CAR.Name = "Lab_CAR"
        Me.Lab_CAR.Size = New System.Drawing.Size(92, 16)
        Me.Lab_CAR.TabIndex = 5
        Me.Lab_CAR.Text = "車載機通訊內容"
        '
        'Lab_CC
        '
        Me.Lab_CC.AutoSize = True
        Me.Lab_CC.BackColor = System.Drawing.Color.Maroon
        Me.Lab_CC.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_CC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Lab_CC.Location = New System.Drawing.Point(341, 8)
        Me.Lab_CC.Name = "Lab_CC"
        Me.Lab_CC.Size = New System.Drawing.Size(116, 16)
        Me.Lab_CC.TabIndex = 4
        Me.Lab_CC.Text = "中心端(CC)通訊內容"
        '
        'Lab_IC
        '
        Me.Lab_IC.AutoSize = True
        Me.Lab_IC.BackColor = System.Drawing.Color.Maroon
        Me.Lab_IC.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_IC.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Lab_IC.Location = New System.Drawing.Point(4, 8)
        Me.Lab_IC.Name = "Lab_IC"
        Me.Lab_IC.Size = New System.Drawing.Size(116, 16)
        Me.Lab_IC.TabIndex = 3
        Me.Lab_IC.Text = "號誌控制器通訊內容"
        '
        'LBox_Car
        '
        Me.LBox_Car.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LBox_Car.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBox_Car.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LBox_Car.FormattingEnabled = True
        Me.LBox_Car.ItemHeight = 16
        Me.LBox_Car.Location = New System.Drawing.Point(224, 32)
        Me.LBox_Car.Name = "LBox_Car"
        Me.LBox_Car.Size = New System.Drawing.Size(84, 98)
        Me.LBox_Car.TabIndex = 2
        '
        'LBox_CC
        '
        Me.LBox_CC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LBox_CC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBox_CC.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LBox_CC.FormattingEnabled = True
        Me.LBox_CC.ItemHeight = 16
        Me.LBox_CC.Location = New System.Drawing.Point(3, 126)
        Me.LBox_CC.Name = "LBox_CC"
        Me.LBox_CC.Size = New System.Drawing.Size(112, 98)
        Me.LBox_CC.TabIndex = 1
        '
        'LBox_IC
        '
        Me.LBox_IC.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LBox_IC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBox_IC.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LBox_IC.FormattingEnabled = True
        Me.LBox_IC.ItemHeight = 16
        Me.LBox_IC.Location = New System.Drawing.Point(3, 30)
        Me.LBox_IC.Name = "LBox_IC"
        Me.LBox_IC.Size = New System.Drawing.Size(215, 82)
        Me.LBox_IC.TabIndex = 0
        '
        'Panel_Manage
        '
        Me.Panel_Manage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Manage.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Panel_Manage.Controls.Add(Me.LinkLabel_Seg2)
        Me.Panel_Manage.Controls.Add(Me.LinkLabel_Seg1)
        Me.Panel_Manage.Controls.Add(Me.PanelOfConfig_busPrim)
        Me.Panel_Manage.Controls.Add(Me.PanelOfConfig_db)
        Me.Panel_Manage.Controls.Add(Me.PanelOfConfig_Com)
        Me.Panel_Manage.Controls.Add(Me.PanelOfConfig_ID)
        Me.Panel_Manage.Controls.Add(Me.LinkLabel_busPrim)
        Me.Panel_Manage.Controls.Add(Me.LinkLabel_db)
        Me.Panel_Manage.Controls.Add(Me.LinkLabel_Com)
        Me.Panel_Manage.Controls.Add(Me.LinkLabel_ID)
        Me.Panel_Manage.Controls.Add(Me.But_ConfigSave)
        Me.Panel_Manage.Controls.Add(Me.DGrid_TriggerPoint)
        Me.Panel_Manage.Controls.Add(Me.Label_Point)
        Me.Panel_Manage.Controls.Add(Me.DGrid_Segment)
        Me.Panel_Manage.Controls.Add(Me.Label_Seg)
        Me.Panel_Manage.Controls.Add(Me.Label_Config)
        Me.Panel_Manage.Controls.Add(Me.ShapeContainer1)
        Me.Panel_Manage.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel_Manage.Location = New System.Drawing.Point(52, 221)
        Me.Panel_Manage.Name = "Panel_Manage"
        Me.Panel_Manage.Size = New System.Drawing.Size(60, 51)
        Me.Panel_Manage.TabIndex = 4
        '
        'LinkLabel_Seg2
        '
        Me.LinkLabel_Seg2.AutoSize = True
        Me.LinkLabel_Seg2.Location = New System.Drawing.Point(437, 11)
        Me.LinkLabel_Seg2.Name = "LinkLabel_Seg2"
        Me.LinkLabel_Seg2.Size = New System.Drawing.Size(44, 16)
        Me.LinkLabel_Seg2.TabIndex = 110
        Me.LinkLabel_Seg2.TabStop = True
        Me.LinkLabel_Seg2.Text = "特殊日"
        '
        'LinkLabel_Seg1
        '
        Me.LinkLabel_Seg1.AutoSize = True
        Me.LinkLabel_Seg1.Location = New System.Drawing.Point(383, 11)
        Me.LinkLabel_Seg1.Name = "LinkLabel_Seg1"
        Me.LinkLabel_Seg1.Size = New System.Drawing.Size(44, 16)
        Me.LinkLabel_Seg1.TabIndex = 109
        Me.LinkLabel_Seg1.TabStop = True
        Me.LinkLabel_Seg1.Text = "一般日"
        '
        'PanelOfConfig_busPrim
        '
        Me.PanelOfConfig_busPrim.Controls.Add(Me.Label45)
        Me.PanelOfConfig_busPrim.Controls.Add(Me.TBox_OnlyBusID)
        Me.PanelOfConfig_busPrim.Controls.Add(Me.Label44)
        Me.PanelOfConfig_busPrim.Controls.Add(Me.Label42)
        Me.PanelOfConfig_busPrim.Controls.Add(Me.TBox_PolicyDiffSecond)
        Me.PanelOfConfig_busPrim.Controls.Add(Me.Label41)
        Me.PanelOfConfig_busPrim.Controls.Add(Me.TBox_PolicySpeedLimit)
        Me.PanelOfConfig_busPrim.Controls.Add(Me.Label39)
        Me.PanelOfConfig_busPrim.Location = New System.Drawing.Point(16, 164)
        Me.PanelOfConfig_busPrim.Name = "PanelOfConfig_busPrim"
        Me.PanelOfConfig_busPrim.Size = New System.Drawing.Size(29, 25)
        Me.PanelOfConfig_busPrim.TabIndex = 108
        Me.PanelOfConfig_busPrim.Visible = False
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label45.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label45.Location = New System.Drawing.Point(280, 36)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(124, 16)
        Me.Label45.TabIndex = 110
        Me.Label45.Text = "(為空時接受所有公車)"
        '
        'TBox_OnlyBusID
        '
        Me.TBox_OnlyBusID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_OnlyBusID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_OnlyBusID.Location = New System.Drawing.Point(131, 33)
        Me.TBox_OnlyBusID.Name = "TBox_OnlyBusID"
        Me.TBox_OnlyBusID.Size = New System.Drawing.Size(147, 23)
        Me.TBox_OnlyBusID.TabIndex = 109
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label44.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label44.Location = New System.Drawing.Point(70, 35)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(63, 16)
        Me.Label44.TabIndex = 108
        Me.Label44.Text = "測試BusID"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label42.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label42.Location = New System.Drawing.Point(71, 12)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(56, 16)
        Me.Label42.TabIndex = 107
        Me.Label42.Text = "最低速度"
        '
        'TBox_PolicyDiffSecond
        '
        Me.TBox_PolicyDiffSecond.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_PolicyDiffSecond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_PolicyDiffSecond.Location = New System.Drawing.Point(259, 9)
        Me.TBox_PolicyDiffSecond.Name = "TBox_PolicyDiffSecond"
        Me.TBox_PolicyDiffSecond.Size = New System.Drawing.Size(66, 23)
        Me.TBox_PolicyDiffSecond.TabIndex = 106
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label41.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label41.Location = New System.Drawing.Point(202, 12)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(56, 16)
        Me.Label41.TabIndex = 105
        Me.Label41.Text = "持續秒數"
        '
        'TBox_PolicySpeedLimit
        '
        Me.TBox_PolicySpeedLimit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_PolicySpeedLimit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_PolicySpeedLimit.Location = New System.Drawing.Point(131, 9)
        Me.TBox_PolicySpeedLimit.Name = "TBox_PolicySpeedLimit"
        Me.TBox_PolicySpeedLimit.Size = New System.Drawing.Size(66, 23)
        Me.TBox_PolicySpeedLimit.TabIndex = 104
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label39.Location = New System.Drawing.Point(10, 12)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(56, 16)
        Me.Label39.TabIndex = 103
        Me.Label39.Text = "策略取消"
        '
        'PanelOfConfig_db
        '
        Me.PanelOfConfig_db.Controls.Add(Me.Label25)
        Me.PanelOfConfig_db.Controls.Add(Me.Label24)
        Me.PanelOfConfig_db.Controls.Add(Me.Label28)
        Me.PanelOfConfig_db.Controls.Add(Me.Label29)
        Me.PanelOfConfig_db.Controls.Add(Me.Label30)
        Me.PanelOfConfig_db.Controls.Add(Me.TBox_ServerName)
        Me.PanelOfConfig_db.Controls.Add(Me.TBox_DataBaseName)
        Me.PanelOfConfig_db.Controls.Add(Me.TBox_LoginName)
        Me.PanelOfConfig_db.Controls.Add(Me.TBox_LoginPassword)
        Me.PanelOfConfig_db.Location = New System.Drawing.Point(629, 44)
        Me.PanelOfConfig_db.Name = "PanelOfConfig_db"
        Me.PanelOfConfig_db.Size = New System.Drawing.Size(27, 20)
        Me.PanelOfConfig_db.TabIndex = 107
        Me.PanelOfConfig_db.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label25.Location = New System.Drawing.Point(10, 12)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(44, 16)
        Me.Label25.TabIndex = 85
        Me.Label25.Text = "資料庫"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(69, 13)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(62, 15)
        Me.Label24.TabIndex = 86
        Me.Label24.Text = "伺服器名稱"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(261, 13)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(62, 15)
        Me.Label28.TabIndex = 91
        Me.Label28.Text = "資料庫名稱"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(461, 13)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(51, 15)
        Me.Label29.TabIndex = 92
        Me.Label29.Text = "登入帳號"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(657, 13)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(51, 15)
        Me.Label30.TabIndex = 93
        Me.Label30.Text = "登入密碼"
        '
        'TBox_ServerName
        '
        Me.TBox_ServerName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_ServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_ServerName.Location = New System.Drawing.Point(135, 9)
        Me.TBox_ServerName.Name = "TBox_ServerName"
        Me.TBox_ServerName.Size = New System.Drawing.Size(121, 23)
        Me.TBox_ServerName.TabIndex = 94
        '
        'TBox_DataBaseName
        '
        Me.TBox_DataBaseName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_DataBaseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_DataBaseName.Location = New System.Drawing.Point(328, 9)
        Me.TBox_DataBaseName.Name = "TBox_DataBaseName"
        Me.TBox_DataBaseName.Size = New System.Drawing.Size(123, 23)
        Me.TBox_DataBaseName.TabIndex = 95
        '
        'TBox_LoginName
        '
        Me.TBox_LoginName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_LoginName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_LoginName.Location = New System.Drawing.Point(518, 9)
        Me.TBox_LoginName.Name = "TBox_LoginName"
        Me.TBox_LoginName.Size = New System.Drawing.Size(123, 23)
        Me.TBox_LoginName.TabIndex = 96
        '
        'TBox_LoginPassword
        '
        Me.TBox_LoginPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_LoginPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_LoginPassword.Location = New System.Drawing.Point(714, 9)
        Me.TBox_LoginPassword.Name = "TBox_LoginPassword"
        Me.TBox_LoginPassword.Size = New System.Drawing.Size(123, 23)
        Me.TBox_LoginPassword.TabIndex = 97
        '
        'PanelOfConfig_Com
        '
        Me.PanelOfConfig_Com.Controls.Add(Me.Label43)
        Me.PanelOfConfig_Com.Controls.Add(Me.TBox_ATMSPort_Receive)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label40)
        Me.PanelOfConfig_Com.Controls.Add(Me.TBox_CCPort_Receive)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label10)
        Me.PanelOfConfig_Com.Controls.Add(Me.CBox_PortName)
        Me.PanelOfConfig_Com.Controls.Add(Me.CBox_Baudrate)
        Me.PanelOfConfig_Com.Controls.Add(Me.CBox_Parity)
        Me.PanelOfConfig_Com.Controls.Add(Me.CBox_Databits)
        Me.PanelOfConfig_Com.Controls.Add(Me.CBox_Stopbits)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label13)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label14)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label15)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label16)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label17)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label11)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label18)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label19)
        Me.PanelOfConfig_Com.Controls.Add(Me.TBox_IP)
        Me.PanelOfConfig_Com.Controls.Add(Me.TBox_CCPort_Send)
        Me.PanelOfConfig_Com.Controls.Add(Me.TBox_CarPort)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label23)
        Me.PanelOfConfig_Com.Controls.Add(Me.TBox_CarIP)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label12)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label26)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label22)
        Me.PanelOfConfig_Com.Controls.Add(Me.Label27)
        Me.PanelOfConfig_Com.Location = New System.Drawing.Point(11, 44)
        Me.PanelOfConfig_Com.Name = "PanelOfConfig_Com"
        Me.PanelOfConfig_Com.Size = New System.Drawing.Size(49, 49)
        Me.PanelOfConfig_Com.TabIndex = 106
        Me.PanelOfConfig_Com.Visible = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label43.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label43.Location = New System.Drawing.Point(771, 37)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(144, 15)
        Me.Label43.TabIndex = 94
        Me.Label43.Text = "交控系統-TCP Receive Port"
        '
        'TBox_ATMSPort_Receive
        '
        Me.TBox_ATMSPort_Receive.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_ATMSPort_Receive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_ATMSPort_Receive.Location = New System.Drawing.Point(920, 33)
        Me.TBox_ATMSPort_Receive.Name = "TBox_ATMSPort_Receive"
        Me.TBox_ATMSPort_Receive.Size = New System.Drawing.Size(77, 23)
        Me.TBox_ATMSPort_Receive.TabIndex = 93
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label40.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label40.Location = New System.Drawing.Point(531, 37)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(71, 15)
        Me.Label40.TabIndex = 91
        Me.Label40.Text = "Receive Port"
        '
        'TBox_CCPort_Receive
        '
        Me.TBox_CCPort_Receive.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_CCPort_Receive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_CCPort_Receive.Location = New System.Drawing.Point(604, 33)
        Me.TBox_CCPort_Receive.Name = "TBox_CCPort_Receive"
        Me.TBox_CCPort_Receive.Size = New System.Drawing.Size(63, 23)
        Me.TBox_CCPort_Receive.TabIndex = 92
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(10, 12)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 59
        Me.Label10.Text = "號誌通訊"
        '
        'CBox_PortName
        '
        Me.CBox_PortName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBox_PortName.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CBox_PortName.FormattingEnabled = True
        Me.CBox_PortName.Location = New System.Drawing.Point(133, 9)
        Me.CBox_PortName.Name = "CBox_PortName"
        Me.CBox_PortName.Size = New System.Drawing.Size(123, 23)
        Me.CBox_PortName.TabIndex = 63
        '
        'CBox_Baudrate
        '
        Me.CBox_Baudrate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBox_Baudrate.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CBox_Baudrate.FormattingEnabled = True
        Me.CBox_Baudrate.Items.AddRange(New Object() {"19200", "14400", "9600", "4800", "2400", "1200"})
        Me.CBox_Baudrate.Location = New System.Drawing.Point(323, 9)
        Me.CBox_Baudrate.Name = "CBox_Baudrate"
        Me.CBox_Baudrate.Size = New System.Drawing.Size(123, 23)
        Me.CBox_Baudrate.TabIndex = 64
        '
        'CBox_Parity
        '
        Me.CBox_Parity.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBox_Parity.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CBox_Parity.FormattingEnabled = True
        Me.CBox_Parity.Items.AddRange(New Object() {"None", "Odd", "Even", "Mark", "Space"})
        Me.CBox_Parity.Location = New System.Drawing.Point(506, 9)
        Me.CBox_Parity.Name = "CBox_Parity"
        Me.CBox_Parity.Size = New System.Drawing.Size(123, 23)
        Me.CBox_Parity.TabIndex = 65
        '
        'CBox_Databits
        '
        Me.CBox_Databits.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBox_Databits.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CBox_Databits.FormattingEnabled = True
        Me.CBox_Databits.Items.AddRange(New Object() {"8"})
        Me.CBox_Databits.Location = New System.Drawing.Point(689, 9)
        Me.CBox_Databits.Name = "CBox_Databits"
        Me.CBox_Databits.Size = New System.Drawing.Size(123, 23)
        Me.CBox_Databits.TabIndex = 66
        '
        'CBox_Stopbits
        '
        Me.CBox_Stopbits.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CBox_Stopbits.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CBox_Stopbits.FormattingEnabled = True
        Me.CBox_Stopbits.Items.AddRange(New Object() {"None", "One", "Two", "OnePointFive"})
        Me.CBox_Stopbits.Location = New System.Drawing.Point(873, 9)
        Me.CBox_Stopbits.Name = "CBox_Stopbits"
        Me.CBox_Stopbits.Size = New System.Drawing.Size(123, 23)
        Me.CBox_Stopbits.TabIndex = 67
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(69, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 15)
        Me.Label13.TabIndex = 68
        Me.Label13.Text = "COM Port"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(264, 13)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 15)
        Me.Label14.TabIndex = 69
        Me.Label14.Text = "BaudRate"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label15.Location = New System.Drawing.Point(454, 13)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 15)
        Me.Label15.TabIndex = 70
        Me.Label15.Text = "DataBits"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label16.Location = New System.Drawing.Point(649, 13)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(37, 15)
        Me.Label16.TabIndex = 71
        Me.Label16.Text = "Parity"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(822, 13)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(50, 15)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "StopBits"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 36)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 60
        Me.Label11.Text = "中心通訊"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label18.Location = New System.Drawing.Point(168, 37)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(53, 15)
        Me.Label18.TabIndex = 75
        Me.Label18.Text = "Target IP"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(392, 37)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 15)
        Me.Label19.TabIndex = 76
        Me.Label19.Text = "Send Port"
        '
        'TBox_IP
        '
        Me.TBox_IP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_IP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_IP.Location = New System.Drawing.Point(222, 33)
        Me.TBox_IP.Name = "TBox_IP"
        Me.TBox_IP.Size = New System.Drawing.Size(160, 23)
        Me.TBox_IP.TabIndex = 77
        '
        'TBox_CCPort_Send
        '
        Me.TBox_CCPort_Send.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_CCPort_Send.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_CCPort_Send.Location = New System.Drawing.Point(452, 33)
        Me.TBox_CCPort_Send.Name = "TBox_CCPort_Send"
        Me.TBox_CCPort_Send.Size = New System.Drawing.Size(65, 23)
        Me.TBox_CCPort_Send.TabIndex = 78
        '
        'TBox_CarPort
        '
        Me.TBox_CarPort.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_CarPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_CarPort.Location = New System.Drawing.Point(382, 57)
        Me.TBox_CarPort.Name = "TBox_CarPort"
        Me.TBox_CarPort.Size = New System.Drawing.Size(65, 23)
        Me.TBox_CarPort.TabIndex = 90
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(69, 37)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(101, 15)
        Me.Label23.TabIndex = 84
        Me.Label23.Text = "公車優先系統-UDP"
        '
        'TBox_CarIP
        '
        Me.TBox_CarIP.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_CarIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_CarIP.Location = New System.Drawing.Point(152, 57)
        Me.TBox_CarIP.Name = "TBox_CarIP"
        Me.TBox_CarIP.Size = New System.Drawing.Size(160, 23)
        Me.TBox_CarIP.TabIndex = 89
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 61)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(56, 16)
        Me.Label12.TabIndex = 61
        Me.Label12.Text = "車機通訊"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label26.Location = New System.Drawing.Point(350, 61)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(29, 15)
        Me.Label26.TabIndex = 88
        Me.Label26.Text = "Port"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(69, 61)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(27, 15)
        Me.Label22.TabIndex = 83
        Me.Label22.Text = "TCP"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(98, 61)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(53, 15)
        Me.Label27.TabIndex = 87
        Me.Label27.Text = "Target IP"
        '
        'PanelOfConfig_ID
        '
        Me.PanelOfConfig_ID.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.PanelOfConfig_ID.Controls.Add(Me.CBox_isMaster)
        Me.PanelOfConfig_ID.Controls.Add(Me.TBox_CrossRoadName)
        Me.PanelOfConfig_ID.Controls.Add(Me.TBox_GroupName)
        Me.PanelOfConfig_ID.Controls.Add(Me.Label33)
        Me.PanelOfConfig_ID.Controls.Add(Me.Label34)
        Me.PanelOfConfig_ID.Controls.Add(Me.TBox_GroupID)
        Me.PanelOfConfig_ID.Controls.Add(Me.Label32)
        Me.PanelOfConfig_ID.Controls.Add(Me.Label_CrossRoadID)
        Me.PanelOfConfig_ID.Controls.Add(Me.TBox_CrossRoadID)
        Me.PanelOfConfig_ID.Controls.Add(Me.Label31)
        Me.PanelOfConfig_ID.Controls.Add(Me.TBox_EditDeviceID)
        Me.PanelOfConfig_ID.Location = New System.Drawing.Point(129, 44)
        Me.PanelOfConfig_ID.Name = "PanelOfConfig_ID"
        Me.PanelOfConfig_ID.Size = New System.Drawing.Size(376, 93)
        Me.PanelOfConfig_ID.TabIndex = 105
        '
        'CBox_isMaster
        '
        Me.CBox_isMaster.AutoSize = True
        Me.CBox_isMaster.Enabled = False
        Me.CBox_isMaster.Location = New System.Drawing.Point(216, 59)
        Me.CBox_isMaster.Name = "CBox_isMaster"
        Me.CBox_isMaster.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBox_isMaster.Size = New System.Drawing.Size(111, 20)
        Me.CBox_isMaster.TabIndex = 108
        Me.CBox_isMaster.Text = "是否為主控路口"
        Me.CBox_isMaster.UseVisualStyleBackColor = True
        '
        'TBox_CrossRoadName
        '
        Me.TBox_CrossRoadName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_CrossRoadName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_CrossRoadName.Location = New System.Drawing.Point(277, 34)
        Me.TBox_CrossRoadName.Name = "TBox_CrossRoadName"
        Me.TBox_CrossRoadName.ReadOnly = True
        Me.TBox_CrossRoadName.Size = New System.Drawing.Size(241, 23)
        Me.TBox_CrossRoadName.TabIndex = 106
        '
        'TBox_GroupName
        '
        Me.TBox_GroupName.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_GroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_GroupName.Location = New System.Drawing.Point(277, 10)
        Me.TBox_GroupName.Name = "TBox_GroupName"
        Me.TBox_GroupName.ReadOnly = True
        Me.TBox_GroupName.Size = New System.Drawing.Size(241, 23)
        Me.TBox_GroupName.TabIndex = 105
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label33.Location = New System.Drawing.Point(218, 36)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(56, 16)
        Me.Label33.TabIndex = 104
        Me.Label33.Text = "路口名稱"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label34.Location = New System.Drawing.Point(218, 12)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 16)
        Me.Label34.TabIndex = 103
        Me.Label34.Text = "群組名稱"
        '
        'TBox_GroupID
        '
        Me.TBox_GroupID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_GroupID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_GroupID.Location = New System.Drawing.Point(66, 9)
        Me.TBox_GroupID.Name = "TBox_GroupID"
        Me.TBox_GroupID.ReadOnly = True
        Me.TBox_GroupID.Size = New System.Drawing.Size(135, 23)
        Me.TBox_GroupID.TabIndex = 102
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label32.Location = New System.Drawing.Point(10, 36)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(56, 16)
        Me.Label32.TabIndex = 101
        Me.Label32.Text = "路口編號"
        '
        'Label_CrossRoadID
        '
        Me.Label_CrossRoadID.AutoSize = True
        Me.Label_CrossRoadID.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_CrossRoadID.Location = New System.Drawing.Point(10, 12)
        Me.Label_CrossRoadID.Name = "Label_CrossRoadID"
        Me.Label_CrossRoadID.Size = New System.Drawing.Size(56, 16)
        Me.Label_CrossRoadID.TabIndex = 53
        Me.Label_CrossRoadID.Text = "群組編號"
        '
        'TBox_CrossRoadID
        '
        Me.TBox_CrossRoadID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_CrossRoadID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_CrossRoadID.Location = New System.Drawing.Point(66, 33)
        Me.TBox_CrossRoadID.Name = "TBox_CrossRoadID"
        Me.TBox_CrossRoadID.ReadOnly = True
        Me.TBox_CrossRoadID.Size = New System.Drawing.Size(135, 23)
        Me.TBox_CrossRoadID.TabIndex = 58
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label31.Location = New System.Drawing.Point(10, 60)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(86, 16)
        Me.Label31.TabIndex = 99
        Me.Label31.Text = "號誌編號(Hex)"
        '
        'TBox_EditDeviceID
        '
        Me.TBox_EditDeviceID.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TBox_EditDeviceID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_EditDeviceID.Location = New System.Drawing.Point(102, 57)
        Me.TBox_EditDeviceID.Name = "TBox_EditDeviceID"
        Me.TBox_EditDeviceID.ReadOnly = True
        Me.TBox_EditDeviceID.Size = New System.Drawing.Size(99, 23)
        Me.TBox_EditDeviceID.TabIndex = 100
        '
        'LinkLabel_busPrim
        '
        Me.LinkLabel_busPrim.AutoSize = True
        Me.LinkLabel_busPrim.Location = New System.Drawing.Point(234, 11)
        Me.LinkLabel_busPrim.Name = "LinkLabel_busPrim"
        Me.LinkLabel_busPrim.Size = New System.Drawing.Size(80, 16)
        Me.LinkLabel_busPrim.TabIndex = 104
        Me.LinkLabel_busPrim.TabStop = True
        Me.LinkLabel_busPrim.Text = "優先號誌參數"
        '
        'LinkLabel_db
        '
        Me.LinkLabel_db.AutoSize = True
        Me.LinkLabel_db.Location = New System.Drawing.Point(183, 11)
        Me.LinkLabel_db.Name = "LinkLabel_db"
        Me.LinkLabel_db.Size = New System.Drawing.Size(44, 16)
        Me.LinkLabel_db.TabIndex = 103
        Me.LinkLabel_db.TabStop = True
        Me.LinkLabel_db.Text = "資料庫"
        '
        'LinkLabel_Com
        '
        Me.LinkLabel_Com.AutoSize = True
        Me.LinkLabel_Com.Location = New System.Drawing.Point(143, 11)
        Me.LinkLabel_Com.Name = "LinkLabel_Com"
        Me.LinkLabel_Com.Size = New System.Drawing.Size(32, 16)
        Me.LinkLabel_Com.TabIndex = 102
        Me.LinkLabel_Com.TabStop = True
        Me.LinkLabel_Com.Text = "通訊"
        '
        'LinkLabel_ID
        '
        Me.LinkLabel_ID.AutoSize = True
        Me.LinkLabel_ID.Location = New System.Drawing.Point(104, 11)
        Me.LinkLabel_ID.Name = "LinkLabel_ID"
        Me.LinkLabel_ID.Size = New System.Drawing.Size(32, 16)
        Me.LinkLabel_ID.TabIndex = 101
        Me.LinkLabel_ID.TabStop = True
        Me.LinkLabel_ID.Text = "編號"
        '
        'But_ConfigSave
        '
        Me.But_ConfigSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.But_ConfigSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_ConfigSave.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.But_ConfigSave.Location = New System.Drawing.Point(1074, 40)
        Me.But_ConfigSave.Name = "But_ConfigSave"
        Me.But_ConfigSave.Size = New System.Drawing.Size(62, 22)
        Me.But_ConfigSave.TabIndex = 98
        Me.But_ConfigSave.Text = "儲存"
        Me.But_ConfigSave.UseVisualStyleBackColor = False
        '
        'DGrid_TriggerPoint
        '
        Me.DGrid_TriggerPoint.AllowUserToAddRows = False
        Me.DGrid_TriggerPoint.AllowUserToDeleteRows = False
        Me.DGrid_TriggerPoint.AllowUserToResizeColumns = False
        Me.DGrid_TriggerPoint.AllowUserToResizeRows = False
        Me.DGrid_TriggerPoint.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGrid_TriggerPoint.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.DGrid_TriggerPoint.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid_TriggerPoint.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column8, Me.Column9, Me.Column11, Me.Column13, Me.Column10, Me.Column12})
        Me.DGrid_TriggerPoint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DGrid_TriggerPoint.Location = New System.Drawing.Point(146, 213)
        Me.DGrid_TriggerPoint.MultiSelect = False
        Me.DGrid_TriggerPoint.Name = "DGrid_TriggerPoint"
        Me.DGrid_TriggerPoint.RowHeadersVisible = False
        Me.DGrid_TriggerPoint.RowTemplate.Height = 24
        Me.DGrid_TriggerPoint.Size = New System.Drawing.Size(43, 15)
        Me.DGrid_TriggerPoint.TabIndex = 82
        '
        'Column8
        '
        Me.Column8.HeaderText = "方向"
        Me.Column8.Name = "Column8"
        Me.Column8.ReadOnly = True
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column9
        '
        Me.Column9.HeaderText = "順序"
        Me.Column9.Name = "Column9"
        Me.Column9.ReadOnly = True
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column11
        '
        Me.Column11.FillWeight = 200.0!
        Me.Column11.HeaderText = "編號"
        Me.Column11.Name = "Column11"
        Me.Column11.ReadOnly = True
        Me.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column11.Width = 200
        '
        'Column13
        '
        Me.Column13.HeaderText = "型別"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column10
        '
        Me.Column10.FillWeight = 200.0!
        Me.Column10.HeaderText = "座標"
        Me.Column10.Name = "Column10"
        Me.Column10.ReadOnly = True
        Me.Column10.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column10.Width = 200
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column12.FillWeight = 200.0!
        Me.Column12.HeaderText = "最後觸發時間"
        Me.Column12.Name = "Column12"
        Me.Column12.ReadOnly = True
        Me.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Label_Point
        '
        Me.Label_Point.AutoSize = True
        Me.Label_Point.BackColor = System.Drawing.Color.DarkRed
        Me.Label_Point.ForeColor = System.Drawing.Color.Yellow
        Me.Label_Point.Location = New System.Drawing.Point(30, 393)
        Me.Label_Point.Name = "Label_Point"
        Me.Label_Point.Size = New System.Drawing.Size(68, 16)
        Me.Label_Point.TabIndex = 81
        Me.Label_Point.Text = "觸發點資訊"
        '
        'DGrid_Segment
        '
        Me.DGrid_Segment.AllowUserToAddRows = False
        Me.DGrid_Segment.AllowUserToDeleteRows = False
        Me.DGrid_Segment.AllowUserToResizeColumns = False
        Me.DGrid_Segment.AllowUserToResizeRows = False
        Me.DGrid_Segment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGrid_Segment.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.DGrid_Segment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid_Segment.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DGrid_Segment.Location = New System.Drawing.Point(192, 152)
        Me.DGrid_Segment.MultiSelect = False
        Me.DGrid_Segment.Name = "DGrid_Segment"
        Me.DGrid_Segment.RowHeadersVisible = False
        Me.DGrid_Segment.RowTemplate.Height = 24
        Me.DGrid_Segment.Size = New System.Drawing.Size(43, 23)
        Me.DGrid_Segment.TabIndex = 80
        '
        'Label_Seg
        '
        Me.Label_Seg.AutoSize = True
        Me.Label_Seg.BackColor = System.Drawing.Color.DarkRed
        Me.Label_Seg.ForeColor = System.Drawing.Color.Yellow
        Me.Label_Seg.Location = New System.Drawing.Point(27, 299)
        Me.Label_Seg.Name = "Label_Seg"
        Me.Label_Seg.Size = New System.Drawing.Size(56, 16)
        Me.Label_Seg.TabIndex = 79
        Me.Label_Seg.Text = "排程資訊"
        '
        'Label_Config
        '
        Me.Label_Config.AutoSize = True
        Me.Label_Config.BackColor = System.Drawing.Color.DarkRed
        Me.Label_Config.ForeColor = System.Drawing.Color.Yellow
        Me.Label_Config.Location = New System.Drawing.Point(17, 11)
        Me.Label_Config.Name = "Label_Config"
        Me.Label_Config.Size = New System.Drawing.Size(56, 16)
        Me.Label_Config.TabIndex = 50
        Me.Label_Config.Text = "組態設定"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(60, 51)
        Me.ShapeContainer1.TabIndex = 51
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape3
        '
        Me.LineShape3.BorderColor = System.Drawing.Color.Maroon
        Me.LineShape3.BorderWidth = 2
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 22
        Me.LineShape3.X2 = 720
        Me.LineShape3.Y1 = 411
        Me.LineShape3.Y2 = 411
        '
        'LineShape2
        '
        Me.LineShape2.BorderColor = System.Drawing.Color.Maroon
        Me.LineShape2.BorderWidth = 2
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 22
        Me.LineShape2.X2 = 720
        Me.LineShape2.Y1 = 333
        Me.LineShape2.Y2 = 333
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.Maroon
        Me.LineShape1.BorderWidth = 2
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 16
        Me.LineShape1.X2 = 714
        Me.LineShape1.Y1 = 29
        Me.LineShape1.Y2 = 29
        '
        'Timer_Connect_TCP
        '
        Me.Timer_Connect_TCP.Interval = 10000
        '
        'Timer_AnalysisLightOutBySoft
        '
        Me.Timer_AnalysisLightOutBySoft.Enabled = True
        Me.Timer_AnalysisLightOutBySoft.Interval = 1000
        '
        'Panel_Record
        '
        Me.Panel_Record.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel_Record.BackColor = System.Drawing.Color.FromArgb(CType(CType(166, Byte), Integer), CType(CType(189, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.Panel_Record.Controls.Add(Me.Panel_Record_RightNow)
        Me.Panel_Record.Controls.Add(Me.Panel_Record_History)
        Me.Panel_Record.Controls.Add(Me.LinkLabel_History)
        Me.Panel_Record.Controls.Add(Me.LinkLabel_RecordRightNow)
        Me.Panel_Record.Controls.Add(Me.Label_Histroy)
        Me.Panel_Record.Controls.Add(Me.ShapeContainer2)
        Me.Panel_Record.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Panel_Record.Location = New System.Drawing.Point(135, 183)
        Me.Panel_Record.Name = "Panel_Record"
        Me.Panel_Record.Size = New System.Drawing.Size(53, 33)
        Me.Panel_Record.TabIndex = 5
        '
        'Panel_Record_RightNow
        '
        Me.Panel_Record_RightNow.Controls.Add(Me.Lab_DataSave)
        Me.Panel_Record_RightNow.Controls.Add(Me.But_RecData)
        Me.Panel_Record_RightNow.Controls.Add(Me.CBox_Filter_A1_A2)
        Me.Panel_Record_RightNow.Controls.Add(Me.But_RecordRightNow_Clear)
        Me.Panel_Record_RightNow.Controls.Add(Me.LBox_PolicyExecute)
        Me.Panel_Record_RightNow.Controls.Add(Me.Label38)
        Me.Panel_Record_RightNow.Location = New System.Drawing.Point(70, 219)
        Me.Panel_Record_RightNow.Name = "Panel_Record_RightNow"
        Me.Panel_Record_RightNow.Size = New System.Drawing.Size(507, 114)
        Me.Panel_Record_RightNow.TabIndex = 106
        '
        'Lab_DataSave
        '
        Me.Lab_DataSave.AutoSize = True
        Me.Lab_DataSave.Location = New System.Drawing.Point(195, 11)
        Me.Lab_DataSave.Name = "Lab_DataSave"
        Me.Lab_DataSave.Size = New System.Drawing.Size(56, 16)
        Me.Lab_DataSave.TabIndex = 100
        Me.Lab_DataSave.Text = "開始抄錄"
        '
        'But_RecData
        '
        Me.But_RecData.BackColor = System.Drawing.Color.Red
        Me.But_RecData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.But_RecData.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_RecData.Location = New System.Drawing.Point(172, 9)
        Me.But_RecData.Name = "But_RecData"
        Me.But_RecData.Size = New System.Drawing.Size(20, 21)
        Me.But_RecData.TabIndex = 99
        Me.But_RecData.UseVisualStyleBackColor = False
        '
        'CBox_Filter_A1_A2
        '
        Me.CBox_Filter_A1_A2.AutoSize = True
        Me.CBox_Filter_A1_A2.Location = New System.Drawing.Point(279, 11)
        Me.CBox_Filter_A1_A2.Name = "CBox_Filter_A1_A2"
        Me.CBox_Filter_A1_A2.Size = New System.Drawing.Size(99, 20)
        Me.CBox_Filter_A1_A2.TabIndex = 98
        Me.CBox_Filter_A1_A2.Text = "過瀘車機訊息"
        Me.CBox_Filter_A1_A2.UseVisualStyleBackColor = True
        '
        'But_RecordRightNow_Clear
        '
        Me.But_RecordRightNow_Clear.BackgroundImage = CType(resources.GetObject("But_RecordRightNow_Clear.BackgroundImage"), System.Drawing.Image)
        Me.But_RecordRightNow_Clear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.But_RecordRightNow_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_RecordRightNow_Clear.Location = New System.Drawing.Point(144, 9)
        Me.But_RecordRightNow_Clear.Name = "But_RecordRightNow_Clear"
        Me.But_RecordRightNow_Clear.Size = New System.Drawing.Size(20, 21)
        Me.But_RecordRightNow_Clear.TabIndex = 97
        Me.But_RecordRightNow_Clear.UseVisualStyleBackColor = True
        '
        'LBox_PolicyExecute
        '
        Me.LBox_PolicyExecute.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.LBox_PolicyExecute.FormattingEnabled = True
        Me.LBox_PolicyExecute.HorizontalScrollbar = True
        Me.LBox_PolicyExecute.ItemHeight = 16
        Me.LBox_PolicyExecute.Location = New System.Drawing.Point(9, 34)
        Me.LBox_PolicyExecute.Name = "LBox_PolicyExecute"
        Me.LBox_PolicyExecute.Size = New System.Drawing.Size(76, 52)
        Me.LBox_PolicyExecute.TabIndex = 96
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label38.Location = New System.Drawing.Point(40, 11)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(104, 16)
        Me.Label38.TabIndex = 95
        Me.Label38.Text = "策略運作即時訊息"
        '
        'Panel_Record_History
        '
        Me.Panel_Record_History.Controls.Add(Me.TBox_Interval)
        Me.Panel_Record_History.Controls.Add(Me.But_csv)
        Me.Panel_Record_History.Controls.Add(Me.Lab_Interval)
        Me.Panel_Record_History.Controls.Add(Me.Lab_DateEnd)
        Me.Panel_Record_History.Controls.Add(Me.Lab_DateStart)
        Me.Panel_Record_History.Controls.Add(Me.Chart_Data)
        Me.Panel_Record_History.Controls.Add(Me.But_Graph)
        Me.Panel_Record_History.Controls.Add(Me.CBox_CrossRoadID_His)
        Me.Panel_Record_History.Controls.Add(Me.CBox_History_Record)
        Me.Panel_Record_History.Controls.Add(Me.DGrid_History)
        Me.Panel_Record_History.Controls.Add(Me.But_HistoryRun)
        Me.Panel_Record_History.Controls.Add(Me.Label8)
        Me.Panel_Record_History.Controls.Add(Me.DataPicker_Start)
        Me.Panel_Record_History.Controls.Add(Me.DataPicker_End)
        Me.Panel_Record_History.Controls.Add(Me.Label21)
        Me.Panel_Record_History.Location = New System.Drawing.Point(17, 36)
        Me.Panel_Record_History.Name = "Panel_Record_History"
        Me.Panel_Record_History.Size = New System.Drawing.Size(1075, 157)
        Me.Panel_Record_History.TabIndex = 105
        Me.Panel_Record_History.Visible = False
        '
        'TBox_Interval
        '
        Me.TBox_Interval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TBox_Interval.Location = New System.Drawing.Point(995, 7)
        Me.TBox_Interval.Name = "TBox_Interval"
        Me.TBox_Interval.Size = New System.Drawing.Size(37, 23)
        Me.TBox_Interval.TabIndex = 115
        Me.TBox_Interval.Text = "10"
        Me.TBox_Interval.Visible = False
        '
        'But_csv
        '
        Me.But_csv.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.But_csv.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_csv.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.But_csv.Location = New System.Drawing.Point(1034, 8)
        Me.But_csv.Name = "But_csv"
        Me.But_csv.Size = New System.Drawing.Size(52, 22)
        Me.But_csv.TabIndex = 114
        Me.But_csv.Text = "匯出"
        Me.But_csv.UseVisualStyleBackColor = False
        Me.But_csv.Visible = False
        '
        'Lab_Interval
        '
        Me.Lab_Interval.AutoSize = True
        Me.Lab_Interval.Location = New System.Drawing.Point(940, 11)
        Me.Lab_Interval.Name = "Lab_Interval"
        Me.Lab_Interval.Size = New System.Drawing.Size(52, 16)
        Me.Lab_Interval.TabIndex = 113
        Me.Lab_Interval.Text = "間隔(秒)"
        Me.Lab_Interval.Visible = False
        '
        'Lab_DateEnd
        '
        Me.Lab_DateEnd.AutoSize = True
        Me.Lab_DateEnd.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_DateEnd.Location = New System.Drawing.Point(708, 11)
        Me.Lab_DateEnd.Name = "Lab_DateEnd"
        Me.Lab_DateEnd.Size = New System.Drawing.Size(74, 16)
        Me.Lab_DateEnd.TabIndex = 112
        Me.Lab_DateEnd.Text = "2015/02/26"
        '
        'Lab_DateStart
        '
        Me.Lab_DateStart.AutoSize = True
        Me.Lab_DateStart.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Lab_DateStart.Location = New System.Drawing.Point(465, 11)
        Me.Lab_DateStart.Name = "Lab_DateStart"
        Me.Lab_DateStart.Size = New System.Drawing.Size(74, 16)
        Me.Lab_DateStart.TabIndex = 111
        Me.Lab_DateStart.Text = "2015/02/26"
        '
        'Chart_Data
        '
        ChartArea2.Name = "ChartArea1"
        Me.Chart_Data.ChartAreas.Add(ChartArea2)
        Me.Chart_Data.Location = New System.Drawing.Point(752, 37)
        Me.Chart_Data.Name = "Chart_Data"
        Me.Chart_Data.Size = New System.Drawing.Size(190, 106)
        Me.Chart_Data.TabIndex = 108
        Me.Chart_Data.Text = "Chart_Work"
        Title2.Name = "Title1"
        Me.Chart_Data.Titles.Add(Title2)
        Me.Chart_Data.Visible = False
        '
        'But_Graph
        '
        Me.But_Graph.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.But_Graph.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_Graph.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.But_Graph.Location = New System.Drawing.Point(872, 8)
        Me.But_Graph.Name = "But_Graph"
        Me.But_Graph.Size = New System.Drawing.Size(62, 22)
        Me.But_Graph.TabIndex = 107
        Me.But_Graph.Text = "分析圖"
        Me.But_Graph.UseVisualStyleBackColor = False
        Me.But_Graph.Visible = False
        '
        'CBox_CrossRoadID_His
        '
        Me.CBox_CrossRoadID_His.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CBox_CrossRoadID_His.FormattingEnabled = True
        Me.CBox_CrossRoadID_His.Location = New System.Drawing.Point(89, 7)
        Me.CBox_CrossRoadID_His.Name = "CBox_CrossRoadID_His"
        Me.CBox_CrossRoadID_His.Size = New System.Drawing.Size(114, 23)
        Me.CBox_CrossRoadID_His.TabIndex = 106
        '
        'CBox_History_Record
        '
        Me.CBox_History_Record.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CBox_History_Record.FormattingEnabled = True
        Me.CBox_History_Record.Items.AddRange(New Object() {"執行策略紀錄", "路口車速紀錄", "軟體更新紀錄", "時段更新紀錄", "設備組態更新紀錄"})
        Me.CBox_History_Record.Location = New System.Drawing.Point(205, 7)
        Me.CBox_History_Record.Name = "CBox_History_Record"
        Me.CBox_History_Record.Size = New System.Drawing.Size(130, 23)
        Me.CBox_History_Record.TabIndex = 105
        Me.CBox_History_Record.Text = "執行策略紀錄"
        '
        'DGrid_History
        '
        Me.DGrid_History.AllowUserToAddRows = False
        Me.DGrid_History.AllowUserToDeleteRows = False
        Me.DGrid_History.AllowUserToResizeColumns = False
        Me.DGrid_History.AllowUserToResizeRows = False
        Me.DGrid_History.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGrid_History.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(220, Byte), Integer), CType(CType(215, Byte), Integer))
        Me.DGrid_History.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGrid_History.Cursor = System.Windows.Forms.Cursors.Default
        Me.DGrid_History.Location = New System.Drawing.Point(9, 34)
        Me.DGrid_History.MultiSelect = False
        Me.DGrid_History.Name = "DGrid_History"
        Me.DGrid_History.RowHeadersVisible = False
        Me.DGrid_History.RowTemplate.Height = 24
        Me.DGrid_History.Size = New System.Drawing.Size(604, 109)
        Me.DGrid_History.TabIndex = 83
        '
        'But_HistoryRun
        '
        Me.But_HistoryRun.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.But_HistoryRun.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.But_HistoryRun.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.But_HistoryRun.Location = New System.Drawing.Point(808, 8)
        Me.But_HistoryRun.Name = "But_HistoryRun"
        Me.But_HistoryRun.Size = New System.Drawing.Size(62, 22)
        Me.But_HistoryRun.TabIndex = 104
        Me.But_HistoryRun.Text = "查詢"
        Me.But_HistoryRun.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 11)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "歷史記錄查詢"
        '
        'DataPicker_Start
        '
        Me.DataPicker_Start.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DataPicker_Start.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DataPicker_Start.Location = New System.Drawing.Point(341, 8)
        Me.DataPicker_Start.Name = "DataPicker_Start"
        Me.DataPicker_Start.Size = New System.Drawing.Size(120, 22)
        Me.DataPicker_Start.TabIndex = 87
        '
        'DataPicker_End
        '
        Me.DataPicker_End.Font = New System.Drawing.Font("微軟正黑體", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.DataPicker_End.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.DataPicker_End.Location = New System.Drawing.Point(581, 8)
        Me.DataPicker_End.Name = "DataPicker_End"
        Me.DataPicker_End.Size = New System.Drawing.Size(120, 22)
        Me.DataPicker_End.TabIndex = 88
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.Green
        Me.Label21.Location = New System.Drawing.Point(555, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(20, 16)
        Me.Label21.TabIndex = 89
        Me.Label21.Text = "至"
        '
        'LinkLabel_History
        '
        Me.LinkLabel_History.AutoSize = True
        Me.LinkLabel_History.Location = New System.Drawing.Point(207, 10)
        Me.LinkLabel_History.Name = "LinkLabel_History"
        Me.LinkLabel_History.Size = New System.Drawing.Size(56, 16)
        Me.LinkLabel_History.TabIndex = 103
        Me.LinkLabel_History.TabStop = True
        Me.LinkLabel_History.Text = "歷史紀錄"
        '
        'LinkLabel_RecordRightNow
        '
        Me.LinkLabel_RecordRightNow.AutoSize = True
        Me.LinkLabel_RecordRightNow.Location = New System.Drawing.Point(146, 10)
        Me.LinkLabel_RecordRightNow.Name = "LinkLabel_RecordRightNow"
        Me.LinkLabel_RecordRightNow.Size = New System.Drawing.Size(56, 16)
        Me.LinkLabel_RecordRightNow.TabIndex = 102
        Me.LinkLabel_RecordRightNow.TabStop = True
        Me.LinkLabel_RecordRightNow.Text = "即時訊息"
        '
        'Label_Histroy
        '
        Me.Label_Histroy.AutoSize = True
        Me.Label_Histroy.BackColor = System.Drawing.Color.DarkRed
        Me.Label_Histroy.ForeColor = System.Drawing.Color.Yellow
        Me.Label_Histroy.Location = New System.Drawing.Point(29, 10)
        Me.Label_Histroy.Name = "Label_Histroy"
        Me.Label_Histroy.Size = New System.Drawing.Size(104, 16)
        Me.Label_Histroy.TabIndex = 84
        Me.Label_Histroy.Text = "優先號誌執行紀錄"
        '
        'ShapeContainer2
        '
        Me.ShapeContainer2.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer2.Name = "ShapeContainer2"
        Me.ShapeContainer2.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4})
        Me.ShapeContainer2.Size = New System.Drawing.Size(53, 33)
        Me.ShapeContainer2.TabIndex = 85
        Me.ShapeContainer2.TabStop = False
        '
        'LineShape4
        '
        Me.LineShape4.BorderColor = System.Drawing.Color.Maroon
        Me.LineShape4.BorderWidth = 2
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 17
        Me.LineShape4.X2 = 715
        Me.LineShape4.Y1 = 30
        Me.LineShape4.Y2 = 30
        '
        'Panel_CrossRoadTree
        '
        Me.Panel_CrossRoadTree.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel_CrossRoadTree.Controls.Add(Me.Label_CrossRoad)
        Me.Panel_CrossRoadTree.Controls.Add(Me.TView_CrossRoad)
        Me.Panel_CrossRoadTree.Location = New System.Drawing.Point(0, 27)
        Me.Panel_CrossRoadTree.Name = "Panel_CrossRoadTree"
        Me.Panel_CrossRoadTree.Size = New System.Drawing.Size(29, 32)
        Me.Panel_CrossRoadTree.TabIndex = 6
        '
        'Label_CrossRoad
        '
        Me.Label_CrossRoad.AutoSize = True
        Me.Label_CrossRoad.BackColor = System.Drawing.Color.Maroon
        Me.Label_CrossRoad.Font = New System.Drawing.Font("微軟正黑體", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label_CrossRoad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Label_CrossRoad.Location = New System.Drawing.Point(12, 11)
        Me.Label_CrossRoad.Name = "Label_CrossRoad"
        Me.Label_CrossRoad.Size = New System.Drawing.Size(69, 19)
        Me.Label_CrossRoad.TabIndex = 8
        Me.Label_CrossRoad.Text = "路口列表"
        '
        'TView_CrossRoad
        '
        Me.TView_CrossRoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TView_CrossRoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TView_CrossRoad.Enabled = False
        Me.TView_CrossRoad.Location = New System.Drawing.Point(3, 32)
        Me.TView_CrossRoad.Name = "TView_CrossRoad"
        Me.TView_CrossRoad.Size = New System.Drawing.Size(166, 405)
        Me.TView_CrossRoad.TabIndex = 7
        '
        'Timer_RefreshDataGrid
        '
        Me.Timer_RefreshDataGrid.Enabled = True
        Me.Timer_RefreshDataGrid.Interval = 20000
        '
        'Timer_SegmentAutoSend
        '
        Me.Timer_SegmentAutoSend.Interval = 1000
        '
        'Timer_WatchDog
        '
        Me.Timer_WatchDog.Enabled = True
        Me.Timer_WatchDog.Interval = 10000
        '
        'Timer_Clock
        '
        Me.Timer_Clock.Enabled = True
        Me.Timer_Clock.Interval = 60000
        '
        'Timer_AutoLoad5F46
        '
        Me.Timer_AutoLoad5F46.Interval = 5000
        '
        'Timer_AutoReport2CC
        '
        Me.Timer_AutoReport2CC.Enabled = True
        Me.Timer_AutoReport2CC.Interval = 20000
        '
        'Timer_Auto0F04
        '
        Me.Timer_Auto0F04.Enabled = True
        Me.Timer_Auto0F04.Interval = 60000
        '
        'BusComm
        '
        Me.BusComm.Enabled = True
        Me.BusComm.Interval = 5000
        '
        'Timer_IC_Buff
        '
        Me.Timer_IC_Buff.Enabled = True
        Me.Timer_IC_Buff.Interval = 800
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1276, 742)
        Me.Controls.Add(Me.Panel_CrossRoadTree)
        Me.Controls.Add(Me.Panel_Record)
        Me.Controls.Add(Me.Panel_Monitor)
        Me.Controls.Add(Me.Panel_Top)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.Panel_Manage)
        Me.Font = New System.Drawing.Font("微軟正黑體", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "MainForm"
        Me.Text = "公車優先路側設備"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel_Top.ResumeLayout(False)
        Me.Panel_Top.PerformLayout()
        Me.Panel_Monitor.ResumeLayout(False)
        Me.Panel_Monitor.PerformLayout()
        Me.Panel_Manage.ResumeLayout(False)
        Me.Panel_Manage.PerformLayout()
        Me.PanelOfConfig_busPrim.ResumeLayout(False)
        Me.PanelOfConfig_busPrim.PerformLayout()
        Me.PanelOfConfig_db.ResumeLayout(False)
        Me.PanelOfConfig_db.PerformLayout()
        Me.PanelOfConfig_Com.ResumeLayout(False)
        Me.PanelOfConfig_Com.PerformLayout()
        Me.PanelOfConfig_ID.ResumeLayout(False)
        Me.PanelOfConfig_ID.PerformLayout()
        CType(Me.DGrid_TriggerPoint, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid_Segment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_Record.ResumeLayout(False)
        Me.Panel_Record.PerformLayout()
        Me.Panel_Record_RightNow.ResumeLayout(False)
        Me.Panel_Record_RightNow.PerformLayout()
        Me.Panel_Record_History.ResumeLayout(False)
        Me.Panel_Record_History.PerformLayout()
        CType(Me.Chart_Data, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGrid_History, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel_CrossRoadTree.ResumeLayout(False)
        Me.Panel_CrossRoadTree.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel_Top As System.Windows.Forms.Panel
    Friend WithEvents Panel_Monitor As System.Windows.Forms.Panel
    Friend WithEvents TBox_IC_Download As System.Windows.Forms.TextBox
    Friend WithEvents LBox_Car As System.Windows.Forms.ListBox
    Friend WithEvents LBox_CC As System.Windows.Forms.ListBox
    Friend WithEvents LBox_IC As System.Windows.Forms.ListBox
    Friend WithEvents Panel_Manage As System.Windows.Forms.Panel
    Friend WithEvents Lab_IC As System.Windows.Forms.Label
    Friend WithEvents Lab_CAR As System.Windows.Forms.Label
    Friend WithEvents Lab_CC As System.Windows.Forms.Label
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents But_IC_Download As System.Windows.Forms.Button
    Friend WithEvents But_clean_CAR As System.Windows.Forms.Button
    Friend WithEvents But_clean_CC As System.Windows.Forms.Button
    Friend WithEvents But_clean_IC As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer_Connect_TCP As System.Windows.Forms.Timer
    Friend WithEvents Lab_ComStatus_CC As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TBox_LightRec_5 As System.Windows.Forms.TextBox
    Friend WithEvents TBox_LightRec_4 As System.Windows.Forms.TextBox
    Friend WithEvents TBox_LightRec_3 As System.Windows.Forms.TextBox
    Friend WithEvents TBox_LightRec_2 As System.Windows.Forms.TextBox
    Friend WithEvents TBox_LightRec_1 As System.Windows.Forms.TextBox
    Friend WithEvents TBox_LightRec_0 As System.Windows.Forms.TextBox
    Friend WithEvents Label93 As System.Windows.Forms.Label
    Friend WithEvents Label94 As System.Windows.Forms.Label
    Friend WithEvents Label89 As System.Windows.Forms.Label
    Friend WithEvents Label90 As System.Windows.Forms.Label
    Friend WithEvents Label88 As System.Windows.Forms.Label
    Friend WithEvents Label87 As System.Windows.Forms.Label
    Friend WithEvents Label86 As System.Windows.Forms.Label
    Friend WithEvents Timer_AnalysisLightOutBySoft As System.Windows.Forms.Timer
    Friend WithEvents TBox_Car_Config As System.Windows.Forms.TextBox
    Friend WithEvents TBox_CC_Config As System.Windows.Forms.TextBox
    Friend WithEvents TBox_IC_Config As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label_BusPrimEnable As System.Windows.Forms.Label
    Friend WithEvents TBox_Sgm As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TBox_BusPolicy As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel_Record As System.Windows.Forms.Panel
    Friend WithEvents Label_Config As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label_CrossRoadID As System.Windows.Forms.Label
    Friend WithEvents TBox_CrossRoadID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CBox_Stopbits As System.Windows.Forms.ComboBox
    Friend WithEvents CBox_Databits As System.Windows.Forms.ComboBox
    Friend WithEvents CBox_Parity As System.Windows.Forms.ComboBox
    Friend WithEvents CBox_Baudrate As System.Windows.Forms.ComboBox
    Friend WithEvents CBox_PortName As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TBox_CCPort_Send As System.Windows.Forms.TextBox
    Friend WithEvents TBox_IP As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label_Seg As System.Windows.Forms.Label
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents DGrid_Segment As System.Windows.Forms.DataGridView
    Friend WithEvents Lab_ComStatus_Car As System.Windows.Forms.Label
    Friend WithEvents Lab_ComStatus_IC As System.Windows.Forms.Label
    Friend WithEvents Label_Point As System.Windows.Forms.Label
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents DGrid_TriggerPoint As System.Windows.Forms.DataGridView
    Friend WithEvents Label_Histroy As System.Windows.Forms.Label
    Friend WithEvents DGrid_History As System.Windows.Forms.DataGridView
    Friend WithEvents ShapeContainer2 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents DataPicker_End As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataPicker_Start As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TBox_CarPort As System.Windows.Forms.TextBox
    Friend WithEvents TBox_CarIP As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TBox_LoginPassword As System.Windows.Forms.TextBox
    Friend WithEvents TBox_LoginName As System.Windows.Forms.TextBox
    Friend WithEvents TBox_DataBaseName As System.Windows.Forms.TextBox
    Friend WithEvents TBox_ServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents But_ConfigSave As System.Windows.Forms.Button
    Friend WithEvents TBox_EditDeviceID As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel_ID As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_busPrim As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_db As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_Com As System.Windows.Forms.LinkLabel
    Friend WithEvents PanelOfConfig_ID As System.Windows.Forms.Panel
    Friend WithEvents PanelOfConfig_busPrim As System.Windows.Forms.Panel
    Friend WithEvents PanelOfConfig_db As System.Windows.Forms.Panel
    Friend WithEvents PanelOfConfig_Com As System.Windows.Forms.Panel
    Friend WithEvents Panel_CrossRoadTree As System.Windows.Forms.Panel
    Friend WithEvents TView_CrossRoad As System.Windows.Forms.TreeView
    Friend WithEvents Label_CrossRoad As System.Windows.Forms.Label
    Friend WithEvents TBox_CrossRoadName As System.Windows.Forms.TextBox
    Friend WithEvents TBox_GroupName As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TBox_GroupID As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents CBox_isMaster As System.Windows.Forms.CheckBox
    Friend WithEvents LinkLabel_Seg2 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_Seg1 As System.Windows.Forms.LinkLabel
    Friend WithEvents Timer_RefreshDataGrid As System.Windows.Forms.Timer
    Friend WithEvents Timer_SegmentAutoSend As System.Windows.Forms.Timer
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TBox_StepSec As System.Windows.Forms.TextBox
    Friend WithEvents TBox_StepOrder As System.Windows.Forms.TextBox
    Friend WithEvents TBox_SubPhaseOrder As System.Windows.Forms.TextBox
    Friend WithEvents TBox_Dir As System.Windows.Forms.TextBox
    Friend WithEvents LinkLabel_History As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel_RecordRightNow As System.Windows.Forms.LinkLabel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents But_HistoryRun As System.Windows.Forms.Button
    Friend WithEvents Panel_Record_History As System.Windows.Forms.Panel
    Friend WithEvents CBox_History_Record As System.Windows.Forms.ComboBox
    Friend WithEvents Panel_Record_RightNow As System.Windows.Forms.Panel
    Friend WithEvents LBox_PolicyExecute As System.Windows.Forms.ListBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents But_RecordRightNow_Clear As System.Windows.Forms.Button
    Friend WithEvents TBox_PolicySpeedLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TBox_CCPort_Receive As System.Windows.Forms.TextBox
    Friend WithEvents CBox_Filter_A1_A2 As System.Windows.Forms.CheckBox
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents TBox_PolicyDiffSecond As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents LBox_ATMS As System.Windows.Forms.ListBox
    Friend WithEvents Lab_ATMS As System.Windows.Forms.Label
    Friend WithEvents But_clean_ATMS As System.Windows.Forms.Button
    Friend WithEvents Lab_ComStatus_ATMS As System.Windows.Forms.Label
    Friend WithEvents TBox_ATMSPort_Receive As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Timer_WatchDog As System.Windows.Forms.Timer
    Friend WithEvents CBox_CrossRoadID_His As System.Windows.Forms.ComboBox
    Friend WithEvents Lab_DataSave As System.Windows.Forms.Label
    Friend WithEvents But_RecData As System.Windows.Forms.Button
    Friend WithEvents Timer_Clock As System.Windows.Forms.Timer
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer_AutoLoad5F46 As System.Windows.Forms.Timer
    Friend WithEvents But_Min As System.Windows.Forms.Button
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents TBox_OnlyBusID As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents But_Graph As System.Windows.Forms.Button
    Friend WithEvents Chart_Data As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents Lab_DateEnd As System.Windows.Forms.Label
    Friend WithEvents Lab_DateStart As System.Windows.Forms.Label
    Friend WithEvents TBox_Interval As System.Windows.Forms.TextBox
    Friend WithEvents But_csv As System.Windows.Forms.Button
    Friend WithEvents Lab_Interval As System.Windows.Forms.Label
    Friend WithEvents Timer_AutoReport2CC As System.Windows.Forms.Timer
    Friend WithEvents Timer_Auto0F04 As System.Windows.Forms.Timer
    Friend WithEvents BusComm As System.Windows.Forms.Timer
    Friend WithEvents Timer_IC_Buff As System.Windows.Forms.Timer

End Class
