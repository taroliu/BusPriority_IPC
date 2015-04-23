Imports System.Windows.Forms.VisualStyles

Module Module_Layout
    Public Sub init_Layout()
        Resize_Top_Panel()
        Resize_Monitor_Panel()
        Resize_Manage_Panel()
        Resize_History_Panel()
    End Sub
    Public Sub init_Segment_Common()
        With BusPriority_IPC.MainForm.DGrid_Segment
            .Columns.Clear()
            .ColumnCount = 7
            .Columns(0).Name = "一"
            .Columns(1).Name = "二"
            .Columns(2).Name = "三"
            .Columns(3).Name = "四"
            .Columns(4).Name = "五"
            .Columns(5).Name = "六"
            .Columns(6).Name = "日"
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells                                     '自動調整行高模式      自動與調整行高
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter     '欄位標題對位模式      水平垂直置中
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(0).ReadOnly = True
            .Columns(1).ReadOnly = True
            .Columns(2).ReadOnly = True
            .Columns(3).ReadOnly = True
            .Columns(4).ReadOnly = True
            .Columns(5).ReadOnly = True
            .Columns(6).ReadOnly = True

        End With


        'BusPriority_IPC.MainForm.DGrid_Segment.Columns.Clear()
        'BusPriority_IPC.MainForm.DGrid_Segment.ColumnCount = 7
        'BusPriority_IPC.MainForm.DGrid_Segment.Columns(0).Name = "一"

        'BusPriority_IPC.MainForm.DGrid_Segment.Columns(1).Name = "二"
        'BusPriority_IPC.MainForm.DGrid_Segment.Columns(2).Name = "三"
        'BusPriority_IPC.MainForm.DGrid_Segment.Columns(3).Name = "四"
        'BusPriority_IPC.MainForm.DGrid_Segment.Columns(4).Name = "五"
        'BusPriority_IPC.MainForm.DGrid_Segment.Columns(5).Name = "六"
        'BusPriority_IPC.MainForm.DGrid_Segment.Columns(6).Name = "日"
        For i As Integer = 0 To 6
            BusPriority_IPC.MainForm.DGrid_Segment.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            BusPriority_IPC.MainForm.DGrid_Segment.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next i
    End Sub
    Public Sub Resize_Top_Panel()

        BusPriority_IPC.MainForm.Width = 1355 'jason 20150107
        BusPriority_IPC.MainForm.Height = 780 'jason 20150107
        BusPriority_IPC.MainForm.Panel_Top.Top = 25
        BusPriority_IPC.MainForm.Panel_Top.Left = 200
        BusPriority_IPC.MainForm.Panel_Top.Height = 146 '106
        BusPriority_IPC.MainForm.Panel_Top.Width = BusPriority_IPC.MainForm.Width - 210

        BusPriority_IPC.MainForm.Panel_CrossRoadTree.Top = 25
        BusPriority_IPC.MainForm.Panel_CrossRoadTree.Left = 2
        BusPriority_IPC.MainForm.Panel_CrossRoadTree.Width = 196
        BusPriority_IPC.MainForm.Panel_CrossRoadTree.Height = BusPriority_IPC.MainForm.Height - 73

        BusPriority_IPC.MainForm.Label_CrossRoad.Top = 10
        BusPriority_IPC.MainForm.Label_CrossRoad.Left = 12

        BusPriority_IPC.MainForm.TView_CrossRoad.Top = 30
        BusPriority_IPC.MainForm.TView_CrossRoad.Left = 3
        BusPriority_IPC.MainForm.TView_CrossRoad.Width = 190
        BusPriority_IPC.MainForm.TView_CrossRoad.Height = BusPriority_IPC.MainForm.Panel_CrossRoadTree.Height - 40
    End Sub
    Public Sub SelectConfigPanel(ByVal selectIndex As Integer)
        Select Case selectIndex
            Case 0
                BusPriority_IPC.MainForm.PanelOfConfig_ID.Visible = True
                BusPriority_IPC.MainForm.PanelOfConfig_Com.Visible = False
                BusPriority_IPC.MainForm.PanelOfConfig_db.Visible = False
                BusPriority_IPC.MainForm.PanelOfConfig_busPrim.Visible = False
            Case 1
                BusPriority_IPC.MainForm.PanelOfConfig_ID.Visible = False
                BusPriority_IPC.MainForm.PanelOfConfig_Com.Visible = True
                BusPriority_IPC.MainForm.PanelOfConfig_db.Visible = False
                BusPriority_IPC.MainForm.PanelOfConfig_busPrim.Visible = False
            Case 2
                BusPriority_IPC.MainForm.PanelOfConfig_ID.Visible = False
                BusPriority_IPC.MainForm.PanelOfConfig_Com.Visible = False
                BusPriority_IPC.MainForm.PanelOfConfig_db.Visible = True
                BusPriority_IPC.MainForm.PanelOfConfig_busPrim.Visible = False
            Case 3
                BusPriority_IPC.MainForm.PanelOfConfig_ID.Visible = False
                BusPriority_IPC.MainForm.PanelOfConfig_Com.Visible = False
                BusPriority_IPC.MainForm.PanelOfConfig_db.Visible = False
                BusPriority_IPC.MainForm.PanelOfConfig_busPrim.Visible = True
        End Select
    End Sub
    Public Sub Resize_Monitor_Panel()
        BusPriority_IPC.MainForm.Panel_Monitor.Top = 172 '142
        BusPriority_IPC.MainForm.Panel_Monitor.Left = 200
        BusPriority_IPC.MainForm.Panel_Monitor.Width = BusPriority_IPC.MainForm.Width - 210
        BusPriority_IPC.MainForm.Panel_Monitor.Height = BusPriority_IPC.MainForm.Height - 190 - 30

        '//---------------------IC
        BusPriority_IPC.MainForm.LBox_IC.Top = 26
        BusPriority_IPC.MainForm.LBox_IC.Left = 8
        BusPriority_IPC.MainForm.LBox_IC.Width = (BusPriority_IPC.MainForm.Width - 120) / 2 - 60
        BusPriority_IPC.MainForm.LBox_IC.Height = BusPriority_IPC.MainForm.Panel_Monitor.Height / 2 - 30

        BusPriority_IPC.MainForm.Lab_IC.Top = 8
        BusPriority_IPC.MainForm.Lab_IC.Left = 9
        BusPriority_IPC.MainForm.But_clean_IC.Top = 8
        BusPriority_IPC.MainForm.But_clean_IC.Left = BusPriority_IPC.MainForm.Lab_IC.Left + BusPriority_IPC.MainForm.Lab_IC.Width + 2
        BusPriority_IPC.MainForm.Lab_ComStatus_IC.Top = 8
        BusPriority_IPC.MainForm.Lab_ComStatus_IC.Left = BusPriority_IPC.MainForm.But_clean_IC.Left + BusPriority_IPC.MainForm.But_clean_IC.Width + 2

        '//---------------------CAR
        BusPriority_IPC.MainForm.LBox_Car.Top = 26
        BusPriority_IPC.MainForm.LBox_Car.Left = BusPriority_IPC.MainForm.LBox_IC.Left + BusPriority_IPC.MainForm.LBox_IC.Width + 4 '9 + 2 * BusPriority_IPC.MainForm.Width / 3 - 145
        BusPriority_IPC.MainForm.LBox_Car.Width = BusPriority_IPC.MainForm.Width - BusPriority_IPC.MainForm.LBox_Car.Left - 220
        BusPriority_IPC.MainForm.LBox_Car.Height = BusPriority_IPC.MainForm.Panel_Monitor.Height / 2 - 30
        BusPriority_IPC.MainForm.Lab_CAR.Top = 8
        BusPriority_IPC.MainForm.Lab_CAR.Left = BusPriority_IPC.MainForm.LBox_Car.Left + 1
        BusPriority_IPC.MainForm.But_clean_CAR.Top = 8
        BusPriority_IPC.MainForm.But_clean_CAR.Left = BusPriority_IPC.MainForm.Lab_CAR.Left + BusPriority_IPC.MainForm.Lab_CAR.Width + 2
        BusPriority_IPC.MainForm.Lab_ComStatus_Car.Top = 8
        BusPriority_IPC.MainForm.Lab_ComStatus_Car.Left = BusPriority_IPC.MainForm.But_clean_CAR.Left + BusPriority_IPC.MainForm.But_clean_CAR.Width + 2

        '//---------------------CC
        BusPriority_IPC.MainForm.Lab_CC.Top = BusPriority_IPC.MainForm.LBox_IC.Top + BusPriority_IPC.MainForm.LBox_IC.Height + 4
        BusPriority_IPC.MainForm.Lab_CC.Left = 9

        BusPriority_IPC.MainForm.But_clean_CC.Top = BusPriority_IPC.MainForm.LBox_IC.Top + BusPriority_IPC.MainForm.LBox_IC.Height + 4
        BusPriority_IPC.MainForm.But_clean_CC.Left = BusPriority_IPC.MainForm.Lab_CC.Left + BusPriority_IPC.MainForm.Lab_CC.Width + 2

        BusPriority_IPC.MainForm.Lab_ComStatus_CC.Top = BusPriority_IPC.MainForm.LBox_IC.Top + BusPriority_IPC.MainForm.LBox_IC.Height + 4
        BusPriority_IPC.MainForm.Lab_ComStatus_CC.Left = BusPriority_IPC.MainForm.But_clean_CC.Left + BusPriority_IPC.MainForm.But_clean_CC.Width + 2

        BusPriority_IPC.MainForm.LBox_CC.Top = BusPriority_IPC.MainForm.Lab_CC.Top + BusPriority_IPC.MainForm.Lab_CC.Height + 4
        BusPriority_IPC.MainForm.LBox_CC.Left = 8
        BusPriority_IPC.MainForm.LBox_CC.Width = (BusPriority_IPC.MainForm.Width - 120) / 2 - 60
        BusPriority_IPC.MainForm.LBox_CC.Height = BusPriority_IPC.MainForm.Panel_Monitor.Height / 2 - 20


        '//---------------------ATMS
        BusPriority_IPC.MainForm.Lab_ATMS.Top = BusPriority_IPC.MainForm.LBox_Car.Top + BusPriority_IPC.MainForm.LBox_Car.Height + 4
        BusPriority_IPC.MainForm.Lab_ATMS.Left = BusPriority_IPC.MainForm.LBox_CC.Left + BusPriority_IPC.MainForm.LBox_CC.Width + 4

        BusPriority_IPC.MainForm.But_clean_ATMS.Top = BusPriority_IPC.MainForm.Lab_ATMS.Top
        BusPriority_IPC.MainForm.But_clean_ATMS.Left = BusPriority_IPC.MainForm.Lab_ATMS.Left + BusPriority_IPC.MainForm.Lab_ATMS.Width + 2

        BusPriority_IPC.MainForm.Lab_ComStatus_ATMS.Top = BusPriority_IPC.MainForm.Lab_ATMS.Top
        BusPriority_IPC.MainForm.Lab_ComStatus_ATMS.Left = BusPriority_IPC.MainForm.But_clean_ATMS.Left + BusPriority_IPC.MainForm.But_clean_ATMS.Width + 2

        BusPriority_IPC.MainForm.LBox_ATMS.Top = BusPriority_IPC.MainForm.Lab_ATMS.Top + BusPriority_IPC.MainForm.Lab_ATMS.Height + 4
        BusPriority_IPC.MainForm.LBox_ATMS.Left = BusPriority_IPC.MainForm.LBox_CC.Left + BusPriority_IPC.MainForm.LBox_CC.Width + 4
        BusPriority_IPC.MainForm.LBox_ATMS.Width = (BusPriority_IPC.MainForm.Width - 120) / 2 - 60
        BusPriority_IPC.MainForm.LBox_ATMS.Height = BusPriority_IPC.MainForm.Panel_Monitor.Height / 2 - 20

    End Sub

    Public Sub Resize_Manage_Panel()
        BusPriority_IPC.MainForm.Panel_Manage.Top = 172 '142
        BusPriority_IPC.MainForm.Panel_Manage.Left = 200
        BusPriority_IPC.MainForm.Panel_Manage.Width = BusPriority_IPC.MainForm.Width - 210
        BusPriority_IPC.MainForm.Panel_Manage.Height = BusPriority_IPC.MainForm.Height - 190 - 30

        '組態設定
        BusPriority_IPC.MainForm.PanelOfConfig_ID.Top = 31
        BusPriority_IPC.MainForm.PanelOfConfig_ID.Left = 17
        BusPriority_IPC.MainForm.PanelOfConfig_ID.Width = BusPriority_IPC.MainForm.Width - 130 - 210
        BusPriority_IPC.MainForm.PanelOfConfig_ID.Height = 90

        BusPriority_IPC.MainForm.PanelOfConfig_Com.Top = 31
        BusPriority_IPC.MainForm.PanelOfConfig_Com.Left = 17
        BusPriority_IPC.MainForm.PanelOfConfig_Com.Width = BusPriority_IPC.MainForm.Width - 130 - 210
        BusPriority_IPC.MainForm.PanelOfConfig_Com.Height = 90

        BusPriority_IPC.MainForm.PanelOfConfig_db.Top = 31
        BusPriority_IPC.MainForm.PanelOfConfig_db.Left = 17
        BusPriority_IPC.MainForm.PanelOfConfig_db.Width = BusPriority_IPC.MainForm.Width - 130 - 210
        BusPriority_IPC.MainForm.PanelOfConfig_db.Height = 90

        BusPriority_IPC.MainForm.PanelOfConfig_busPrim.Top = 31
        BusPriority_IPC.MainForm.PanelOfConfig_busPrim.Left = 17
        BusPriority_IPC.MainForm.PanelOfConfig_busPrim.Width = BusPriority_IPC.MainForm.Width - 130 - 210
        BusPriority_IPC.MainForm.PanelOfConfig_busPrim.Height = 90

        BusPriority_IPC.MainForm.Label_Config.Top = 11
        BusPriority_IPC.MainForm.Label_Config.Left = 27
        BusPriority_IPC.MainForm.LineShape1.X1 = 16
        BusPriority_IPC.MainForm.LineShape1.X2 = BusPriority_IPC.MainForm.Width - 20 - 210
        BusPriority_IPC.MainForm.LineShape1.Y1 = 29
        BusPriority_IPC.MainForm.LineShape1.Y2 = 29

        '時段管理
        BusPriority_IPC.MainForm.Label_Seg.Top = 125
        BusPriority_IPC.MainForm.Label_Seg.Left = 27
        BusPriority_IPC.MainForm.LineShape2.X1 = 16
        BusPriority_IPC.MainForm.LineShape2.X2 = BusPriority_IPC.MainForm.Width - 20 - 210
        BusPriority_IPC.MainForm.LineShape2.Y1 = 143
        BusPriority_IPC.MainForm.LineShape2.Y2 = 143

        BusPriority_IPC.MainForm.LinkLabel_Seg1.Top = 125
        BusPriority_IPC.MainForm.LinkLabel_Seg1.Left = BusPriority_IPC.MainForm.Label_Seg.Left + 75
        BusPriority_IPC.MainForm.LinkLabel_Seg2.Top = 125
        BusPriority_IPC.MainForm.LinkLabel_Seg2.Left = BusPriority_IPC.MainForm.Label_Seg.Left + 130

        BusPriority_IPC.MainForm.DGrid_Segment.Top = 148
        BusPriority_IPC.MainForm.DGrid_Segment.Left = 16
        BusPriority_IPC.MainForm.DGrid_Segment.Width = BusPriority_IPC.MainForm.Width - 35 - 210
        BusPriority_IPC.MainForm.DGrid_Segment.Height = (BusPriority_IPC.MainForm.Panel_Manage.Height - 163) / 2

        '虛擬點
        BusPriority_IPC.MainForm.Label_Point.Top = BusPriority_IPC.MainForm.DGrid_Segment.Top + BusPriority_IPC.MainForm.DGrid_Segment.Height + 5
        BusPriority_IPC.MainForm.Label_Point.Left = 27
        BusPriority_IPC.MainForm.LineShape3.X1 = 16
        BusPriority_IPC.MainForm.LineShape3.X2 = BusPriority_IPC.MainForm.Width - 20 - 210
        BusPriority_IPC.MainForm.LineShape3.Y1 = BusPriority_IPC.MainForm.Label_Point.Top + 18
        BusPriority_IPC.MainForm.LineShape3.Y2 = BusPriority_IPC.MainForm.Label_Point.Top + 18

        BusPriority_IPC.MainForm.DGrid_TriggerPoint.Top = BusPriority_IPC.MainForm.LineShape3.Y1 + 5
        BusPriority_IPC.MainForm.DGrid_TriggerPoint.Left = 16
        BusPriority_IPC.MainForm.DGrid_TriggerPoint.Width = BusPriority_IPC.MainForm.Width - 35 - 210
        BusPriority_IPC.MainForm.DGrid_TriggerPoint.Height = BusPriority_IPC.MainForm.Panel_Manage.Height - BusPriority_IPC.MainForm.LineShape3.Y1 - 15

    End Sub


    Public Sub Resize_History_Panel()
        BusPriority_IPC.MainForm.Panel_Record.Top = 172 '142
        BusPriority_IPC.MainForm.Panel_Record.Left = 200
        BusPriority_IPC.MainForm.Panel_Record.Width = BusPriority_IPC.MainForm.Width - 210
        BusPriority_IPC.MainForm.Panel_Record.Height = BusPriority_IPC.MainForm.Height - 190 - 30

        BusPriority_IPC.MainForm.Label_Histroy.Top = 11
        BusPriority_IPC.MainForm.Label_Histroy.Left = 27

        BusPriority_IPC.MainForm.LineShape4.X1 = 16
        BusPriority_IPC.MainForm.LineShape4.X2 = BusPriority_IPC.MainForm.Width - 20 - 210
        BusPriority_IPC.MainForm.LineShape4.Y1 = BusPriority_IPC.MainForm.Label_Histroy.Top + 18
        BusPriority_IPC.MainForm.LineShape4.Y2 = BusPriority_IPC.MainForm.Label_Histroy.Top + 18

        BusPriority_IPC.MainForm.Panel_Record_History.Top = 30
        BusPriority_IPC.MainForm.Panel_Record_History.Left = 16
        BusPriority_IPC.MainForm.Panel_Record_History.Width = BusPriority_IPC.MainForm.Panel_Record.Width - 20
        BusPriority_IPC.MainForm.Panel_Record_History.Height = BusPriority_IPC.MainForm.Panel_Record.Height - 20

        BusPriority_IPC.MainForm.Panel_Record_RightNow.Top = 30
        BusPriority_IPC.MainForm.Panel_Record_RightNow.Left = 16
        BusPriority_IPC.MainForm.Panel_Record_RightNow.Width = BusPriority_IPC.MainForm.Panel_Record.Width - 20
        BusPriority_IPC.MainForm.Panel_Record_RightNow.Height = BusPriority_IPC.MainForm.Panel_Record.Height - 20

        BusPriority_IPC.MainForm.DGrid_History.Top = 38
        BusPriority_IPC.MainForm.DGrid_History.Left = 10
        BusPriority_IPC.MainForm.DGrid_History.Width = BusPriority_IPC.MainForm.Panel_Record.Width - 50
        BusPriority_IPC.MainForm.DGrid_History.Height = BusPriority_IPC.MainForm.Panel_Record.Height - 90

        BusPriority_IPC.MainForm.LBox_PolicyExecute.Top = 38
        BusPriority_IPC.MainForm.LBox_PolicyExecute.Left = 10
        BusPriority_IPC.MainForm.LBox_PolicyExecute.Width = BusPriority_IPC.MainForm.Panel_Record.Width - 50
        BusPriority_IPC.MainForm.LBox_PolicyExecute.Height = BusPriority_IPC.MainForm.Panel_Record.Height - 80


        BusPriority_IPC.MainForm.CBox_Filter_A1_A2.Left = BusPriority_IPC.MainForm.Panel_Record.Width - 150
        BusPriority_IPC.MainForm.CBox_Filter_A1_A2.Top = 11


        If BusPriority_IPC.MainForm.Chart_Data.Visible Then
            SetCharLayout(True)
        End If

    End Sub
    Public Sub Panel_Select(ByVal page_index As Integer)
        BusPriority_IPC.MainForm.Panel_Monitor.Visible = IIf(page_index = 1, True, False)
        BusPriority_IPC.MainForm.Panel_Manage.Visible = IIf(page_index = 2, True, False)
        BusPriority_IPC.MainForm.Panel_Record.Visible = IIf(page_index = 3, True, False)
        If page_index = 1 Then
            BusPriority_IPC.MainForm.But_IC_Download.Enabled = True
        Else
            BusPriority_IPC.MainForm.But_IC_Download.Enabled = False
        End If
    End Sub

    Public Sub SelectRecordPanel(ByVal selectIndex As Integer)
        Select Case selectIndex
            Case 0
                BusPriority_IPC.MainForm.Panel_Record_History.Visible = True
                BusPriority_IPC.MainForm.Panel_Record_RightNow.Visible = False
            Case 1
                BusPriority_IPC.MainForm.Panel_Record_History.Visible = False
                BusPriority_IPC.MainForm.Panel_Record_RightNow.Visible = True
        End Select
    End Sub


    'Jason 20150212 分析圖功能
    'S---------------------------------------------------------------------------
    Public Sub SetCharLayout(ByVal isShow As Boolean)
        If isShow Then

            BusPriority_IPC.MainForm.Chart_Data.Top = BusPriority_IPC.MainForm.DGrid_History.Top
            BusPriority_IPC.MainForm.Chart_Data.Left = BusPriority_IPC.MainForm.DGrid_History.Left
            BusPriority_IPC.MainForm.Chart_Data.Width = BusPriority_IPC.MainForm.DGrid_History.Width
            BusPriority_IPC.MainForm.Chart_Data.Height = BusPriority_IPC.MainForm.DGrid_History.Height
            BusPriority_IPC.MainForm.Chart_Data.Visible = True
            BusPriority_IPC.MainForm.DGrid_History.Visible = False
        Else
            BusPriority_IPC.MainForm.DGrid_History.Visible = True
            BusPriority_IPC.MainForm.Chart_Data.Visible = False
        End If
    End Sub
    'E---------------------------------------------------------------------------

End Module
