Imports System.Data.SqlClient
Imports System.Text
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.IO
Imports NPOI.HSSF.UserModel


Module Moudule_DBAccess



    '*********************************************************
    '**
    '** DataBase Option
    '**
    '*********************************************************
    Public connectionString As String
    Public connection As SqlConnection

    Public Function isConnectDataBase() As Boolean
        Try
            connectionString = "Data Source=" + DB_SevName + ";Initial Catalog=" + DB_DBName + ";User ID=" + DB_UserId + ";Password=" + DB_PassWd
            connection = New SqlConnection(connectionString)

            connection.Open()
            connection.Close()
            'connection.Dispose()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    'jason 20150413 OTA SaveTo Table
    'S-----------------------------------------------------------------------
    Public Sub SaveOTAUpdateToDB(ByVal rGroupID As String, ByVal rCrossRoadID As String)
        Try
            Dim sql_insert As String = "INSERT BusPriority_Update_Log (GroupID,CrossRoadID,UpdateType,TimeDate,Description) " +
                           "VALUES ('" + Trim(rGroupID) + "','" + Trim(rCrossRoadID) + "','1','" + Trim(Now.ToString("yyyy-MM-dd HH:mm:ss")) + "','" + "軟體更新" + "')"

            Dim adapter_insert As New SqlDataAdapter(sql_insert, connection)
            connection.Open()
            adapter_insert.UpdateCommand = connection.CreateCommand
            adapter_insert.UpdateCommand.CommandText = sql_insert
            adapter_insert.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_insert.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "SaveOTAUpdateToDB is exit:" + ex.Message, _logEnable)
        End Try
    End Sub
    'E-----------------------------------------------------------------------
    'jason 20150413 檢查表格及檢視表是否存在
    'S-------------------------------------------------------------------------------------------
    Public Sub DB_CheckTable()
        Try
            connection.Open()
            Dim sql_cmd As String
            Dim cmd As SqlCommand
            'Create Table
            Try
                Dim sql_create As String = "CREATE TABLE BusPriority_Update_Log " & _
                                          "(" & _
                                          "GroupID         nvarchar(50), " & _
                                          "CrossRoadID     nvarchar(50), " & _
                                          "UpdateType      int, " & _
                                          "TimeDate        datetime, " & _
                                          "Description     nvarchar(MAX) " & _
                                          ") "

                Dim adapter_ceate As New SqlDataAdapter(sql_create, connection)
                adapter_ceate.UpdateCommand = connection.CreateCommand
                adapter_ceate.UpdateCommand.CommandText = sql_create
                adapter_ceate.UpdateCommand.ExecuteNonQuery()
                adapter_ceate.Dispose()
            Catch ex As Exception
                WriteLog(curPath, "Moudule_DBAccess", "BusPriority_Update_Log is exit:" + ex.Message, _logEnable)
            End Try
            'Create View
            Try
                Dim sql_view As String = "CREATE VIEW BusPriority_Update_Log_View AS " & _
                                         "SELECT      BusPriority_Update_Log.GroupID, BusPrority_Group_Info_Tab.GroupName, " & _
                                            "BusPriority_Update_Log.CrossRoadID, BusPrority_CrossRoad_Info_Tab.CrossRoadName, " & _
                                            "BusPriority_Update_Log.UpdateType, BusPriority_Update_Log.TimeDate, " & _
                                            "BusPriority_Update_Log.Description " & _
                                         "FROM    BusPriority_Update_Log LEFT OUTER JOIN " & _
                                            "BusPrority_CrossRoad_Info_Tab ON " & _
                                            "BusPriority_Update_Log.CrossRoadID = BusPrority_CrossRoad_Info_Tab.CrossRoadID LEFT OUTER JOIN " & _
                                            "BusPrority_Group_Info_Tab ON BusPriority_Update_Log.GroupID = BusPrority_Group_Info_Tab.GroupID"

                Dim adapter_view As New SqlDataAdapter(sql_view, connection)
                adapter_view.UpdateCommand = connection.CreateCommand
                adapter_view.UpdateCommand.CommandText = sql_view
                adapter_view.UpdateCommand.ExecuteNonQuery()
                adapter_view.Dispose()
            Catch ex As Exception
                WriteLog(curPath, "Moudule_DBAccess", "BusPriority_Update_Log_View is exit:" + ex.Message, _logEnable)
            End Try

            'Try
            '    sql_cmd = "ALTER TABLE BusStrategy_Log ADD Play1 nvarchar(50)"

            '    cmd = New SqlCommand(sql_cmd, connection)
            '    cmd.Connection.Open()
            '    cmd.ExecuteNonQuery()
            '    cmd.Connection.Close()
            '    cmd.Dispose()
            'Catch ex As Exception
            '    WriteLog(curPath, "Moudule_DBAccess", "BusStrategy_Log,Add [Play1] is exit:" + ex.Message, _logEnable)
            'Finally
            '    If (cmd.Connection.State = ConnectionState.Open) Then
            '        cmd.Connection.Close()
            '    End If
            'End Try


            Try
                Dim sql_create As String = "ALTER TABLE BusStrategy_Log ADD Play1 nvarchar(50)"

                Dim adapter_ceate As New SqlDataAdapter(sql_create, connection)
                adapter_ceate.UpdateCommand = connection.CreateCommand
                adapter_ceate.UpdateCommand.CommandText = sql_create
                adapter_ceate.UpdateCommand.ExecuteNonQuery()
                adapter_ceate.Dispose()
            Catch ex As Exception
                WriteLog(curPath, "Moudule_DBAccess", "BusStrategy_Log is exit:" + ex.Message, _logEnable)
            End Try

            Try
                Dim sql_create As String = "ALTER TABLE BusStrategy_Log ADD Play2 nvarchar(50)"

                Dim adapter_ceate As New SqlDataAdapter(sql_create, connection)
                adapter_ceate.UpdateCommand = connection.CreateCommand
                adapter_ceate.UpdateCommand.CommandText = sql_create
                adapter_ceate.UpdateCommand.ExecuteNonQuery()
                adapter_ceate.Dispose()
            Catch ex As Exception
                WriteLog(curPath, "Moudule_DBAccess", "BusStrategy_Log is exit:" + ex.Message, _logEnable)
            End Try


            connection.Close()


        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "DB_CheckTable Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    'E-------------------------------------------------------------------------------------------
    '*********************************************************
    '**
    '** 時段控制管理(特別日時段)
    '**
    '*********************************************************
    Public Sub initComSegmentSpec2DGridView(ByVal vCrossRoadID As String)
        Try
            'Dim sql As String = "SELECT CrossRoadID,SegmentType,Hour,Min,PlanID,YearStart,MonthStart,DayStart,YearEnd,MonthEnd,DayEnd,BusPrimEnable FROM TrafficSignal_Segment_Special_Tab WHERE CrossRoadID=" + Trim(vCrossRoadID) +
            '                    "AND  Order BY  SegmentType,YearStart,MonthStart,DayStart,Hour,Min  "

            Dim sql As String = "SELECT * FROM TrafficSignal_Segment_Special_Tab WHERE  Convert(DateTime,YearEnd+'/'+MonthEnd+'/'+DayEnd) >=Convert(DateTime,'" + Now.Year().ToString + "/" + Now.Month().ToString + "/" + Now.Day().ToString + "') "
            'Dim connection As New SqlConnection(connectionString)
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            connection.Open()
            dataadapter.Fill(ds, "SegmentSpecTab")
            connection.Close()
            'connection.Dispose()

            BusPriority_IPC.MainForm.DGrid_Segment.Rows.Clear()
            SegmentDataList.Clear()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim WeekSegmentString = Trim(ds.Tables(0).Rows(i).Item(2).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(3).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(4).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(6).ToString)
                If OneDayOfWeek("1", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("1", WeekSegmentString)
                End If
                If OneDayOfWeek("2", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("2", WeekSegmentString)
                End If
                If OneDayOfWeek("3", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("3", WeekSegmentString)
                End If
                If OneDayOfWeek("4", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("4", WeekSegmentString)
                End If
                If OneDayOfWeek("5", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("5", WeekSegmentString)
                End If
                If OneDayOfWeek("6", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("6", WeekSegmentString)
                End If
                If OneDayOfWeek("7", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("7", WeekSegmentString)
                End If

            Next i

            SetSegmentGrieView()

            dataadapter.Dispose()
            ds.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "initComSegmentSpec2DGridView Catch:" + ex.Message, _logEnable)
        End Try

    End Sub
    '*********************************************************
    '**
    '** 時段控制管理(一般日時段)
    '**
    '*********************************************************
    Public Sub initComSegmentCom2DGridView(ByVal vCrossRoadID As String)
        Try
            Dim sql As String = "SELECT CrossRoadID,SegmentType,Hour,Min,PlanID,WeekDay,BusPrimEnable FROM [TaoyuanBusPrim].[dbo].[TrafficSingal_Segment_Common_Tab] WHERE CrossRoadID=" + Trim(vCrossRoadID) + " Order BY  SegmentType,Hour  "

            'Dim connection As New SqlConnection(connectionString)
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            connection.Open()
            dataadapter.Fill(ds, "SegmentComTab")
            connection.Close()
            'connection.Dispose()

            BusPriority_IPC.MainForm.DGrid_Segment.Rows.Clear()
            SegmentDataList.Clear()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim WeekSegmentString = Trim(ds.Tables(0).Rows(i).Item(2).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(3).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(4).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(6).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(5).ToString)

                If OneDayOfWeek("1", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("1", WeekSegmentString)
                End If
                If OneDayOfWeek("2", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("2", WeekSegmentString)
                End If
                If OneDayOfWeek("3", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("3", WeekSegmentString)
                End If
                If OneDayOfWeek("4", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("4", WeekSegmentString)
                End If
                If OneDayOfWeek("5", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("5", WeekSegmentString)
                End If
                If OneDayOfWeek("6", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("6", WeekSegmentString)
                End If
                If OneDayOfWeek("7", ds.Tables(0).Rows(i).Item(5).ToString) Then
                    AddToWeekOfSegmentList("7", WeekSegmentString)
                End If
            Next i

            'Dim nowTime As DateTime = DateTime.Parse("2014/9/1 06:10:00")
            'getWeekOfSegment_PlanID_BusPrim("1", nowTime)
            'nowTime = DateTime.Parse("2014/9/1 07:10:00")
            'getWeekOfSegment_PlanID_BusPrim("1", nowTime)
            'nowTime = DateTime.Parse("2014/9/1 12:10:00")
            'getWeekOfSegment_PlanID_BusPrim("1", nowTime)
            'nowTime = DateTime.Parse("2014/9/1 15:10:00")
            'getWeekOfSegment_PlanID_BusPrim("1", nowTime)
            SetSegmentGrieView()

            dataadapter.Dispose()
            ds.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "initComSegmentCom2DGridView Catch:" + ex.Message, _logEnable)
        End Try

    End Sub
    Public Sub SetSegmentGrieView()
        Try
            Dim MaxDaysOfweek As Integer = -1
            init_Segment_Common()
            Dim tmpHashTable As Hashtable
            For Each WeekDayValue As String In SegmentDataList.Keys
                tmpHashTable = SegmentDataList.Item(WeekDayValue)
                If tmpHashTable.Count > MaxDaysOfweek Then
                    MaxDaysOfweek = tmpHashTable.Count
                End If
            Next
            Dim ContentText As String()

            For i As Integer = 0 To MaxDaysOfweek - 1
                ContentText = {"", "", "", "", "", "", ""}
                tmpHashTable = SegmentDataList.Item("1")
                If Not tmpHashTable Is Nothing Then
                    If tmpHashTable.Count > i Then
                        ContentText(0) = tmpHashTable.Item(i.ToString)
                    Else
                        ContentText(0) = ",,,,,,"
                    End If
                Else
                    ContentText(0) = ",,,,,,"
                End If

                tmpHashTable = SegmentDataList.Item("2")
                If Not tmpHashTable Is Nothing Then
                    If tmpHashTable.Count > i Then
                        ContentText(1) = tmpHashTable.Item(i.ToString)
                    Else
                        ContentText(1) = ",,,,,,"
                    End If
                Else
                    ContentText(1) = ",,,,,,"
                End If


                tmpHashTable = SegmentDataList.Item("3")
                If Not tmpHashTable Is Nothing Then
                    If tmpHashTable.Count > i Then
                        ContentText(2) = tmpHashTable.Item(i.ToString)
                    Else
                        ContentText(2) = ",,,,,,"
                    End If
                Else
                    ContentText(2) = ",,,,,,"
                End If

                tmpHashTable = SegmentDataList.Item("4")
                If Not tmpHashTable Is Nothing Then
                    If tmpHashTable.Count > i Then
                        ContentText(3) = tmpHashTable.Item(i.ToString)
                    Else
                        ContentText(3) = ",,,,,,"
                    End If
                Else
                    ContentText(3) = ",,,,,,"
                End If

                tmpHashTable = SegmentDataList.Item("5")
                If Not tmpHashTable Is Nothing Then
                    If tmpHashTable.Count > i Then
                        ContentText(4) = tmpHashTable.Item(i.ToString)
                    Else
                        ContentText(4) = ",,,,,,"
                    End If
                Else
                    ContentText(4) = ",,,,,,"
                End If
                tmpHashTable = SegmentDataList.Item("6")
                If Not tmpHashTable Is Nothing Then
                    If tmpHashTable.Count > i Then
                        ContentText(5) = tmpHashTable.Item(i.ToString)
                    Else
                        ContentText(5) = ",,,,,,"
                    End If
                Else
                    ContentText(5) = ",,,,,,"
                End If
                tmpHashTable = SegmentDataList.Item("7")
                If Not tmpHashTable Is Nothing Then
                    If tmpHashTable.Count > i Then
                        ContentText(6) = tmpHashTable.Item(i.ToString)
                    Else
                        ContentText(6) = ",,,,,,"
                    End If
                Else
                    ContentText(6) = ",,,,,,"
                End If
                'Dim row As String() = New String() {ContentText(0), ContentText(1), ContentText(2), ContentText(3), ContentText(4), ContentText(5), ContentText(6)}
                'BusPriority_IPC.MainForm.DGrid_Segment.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                'BusPriority_IPC.MainForm.DGrid_Segment.Rows.Add(row)
                Dim row As String() = New String() {IIf(ContentText(0).Split(",")(2) <> "", "[PID] ", "") + ContentText(0).Split(",")(2) & System.Environment.NewLine & ContentText(0).Split(",")(0) + IIf(ContentText(0).Split(",")(0) <> "", ":", "") + ContentText(0).Split(",")(1),
                                                    IIf(ContentText(1).Split(",")(2) <> "", "[PID] ", "") + ContentText(1).Split(",")(2) & System.Environment.NewLine & ContentText(1).Split(",")(0) + IIf(ContentText(1).Split(",")(0) <> "", ":", "") + ContentText(1).Split(",")(1),
                                                    IIf(ContentText(2).Split(",")(2) <> "", "[PID] ", "") + ContentText(2).Split(",")(2) & System.Environment.NewLine & ContentText(2).Split(",")(0) + IIf(ContentText(2).Split(",")(0) <> "", ":", "") + ContentText(2).Split(",")(1),
                                                    IIf(ContentText(3).Split(",")(2) <> "", "[PID] ", "") + ContentText(3).Split(",")(2) & System.Environment.NewLine & ContentText(3).Split(",")(0) + IIf(ContentText(3).Split(",")(0) <> "", ":", "") + ContentText(3).Split(",")(1),
                                                    IIf(ContentText(4).Split(",")(2) <> "", "[PID] ", "") + ContentText(4).Split(",")(2) & System.Environment.NewLine & ContentText(4).Split(",")(0) + IIf(ContentText(4).Split(",")(0) <> "", ":", "") + ContentText(4).Split(",")(1),
                                                    IIf(ContentText(5).Split(",")(2) <> "", "[PID] ", "") + ContentText(5).Split(",")(2) & System.Environment.NewLine & ContentText(5).Split(",")(0) + IIf(ContentText(5).Split(",")(0) <> "", ":", "") + ContentText(5).Split(",")(1),
                                                    IIf(ContentText(6).Split(",")(2) <> "", "[PID] ", "") + ContentText(6).Split(",")(2) & System.Environment.NewLine & ContentText(6).Split(",")(0) + IIf(ContentText(6).Split(",")(0) <> "", ":", "") + ContentText(6).Split(",")(1)}

                BusPriority_IPC.MainForm.DGrid_Segment.DefaultCellStyle.WrapMode = DataGridViewTriState.True
                BusPriority_IPC.MainForm.DGrid_Segment.Rows.Add(row)
                For j As Integer = 0 To 6
                    If ContentText(j).Split(",")(3) = "1" Then
                        BusPriority_IPC.MainForm.DGrid_Segment.Item(j, i).Style.BackColor = Color.YellowGreen 'PaleGreen
                    End If
                Next j
            Next i

        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "SetSegmentGrieView Catch:" + ex.Message, _logEnable)

        End Try
    End Sub
    Public Function OneDayOfWeek(ByVal vIndexOfWeek As String, ByVal WeekString As String) As Boolean '1...7
        Try
            If WeekString.IndexOf(vIndexOfWeek) > 0 Then
                Return True
            End If
            Return False
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "OneDayOfWeek Catch:" + ex.Message, _logEnable)
            Return False
        End Try
    End Function
    Public Sub AddToWeekOfSegmentList(ByVal DayofWeek As String, ByVal rSegment As String)
        Try
            Dim WeekDay_LinkTab As New Hashtable
            Dim tmpSegment As String() = rSegment.Split(",")
            Dim WeekString As String = tmpSegment(4)
            Dim EnableString As String = tmpSegment(3)
            tmpSegment(3) = EnableString.Substring(WeekString.IndexOf(DayofWeek), 1)
            Dim newSegment As String = tmpSegment(0) + "," + tmpSegment(1) + "," + tmpSegment(2) + "," + tmpSegment(3)
            If SegmentDataList.ContainsKey(DayofWeek) Then
                WeekDay_LinkTab = SegmentDataList.Item(DayofWeek)
                'Sorting SegmentDataList
                Dim orgTagArray As String()
                Dim newTagArray As String() = newSegment.Split(",")
                Dim insertTagArray As String = newSegment
                'S--------------------------------------------------------------------------
                For i As Integer = 0 To WeekDay_LinkTab.Count - 1
                    orgTagArray = WeekDay_LinkTab.Item(i.ToString).ToString.Split(",")
                    If newTagArray(0) < orgTagArray(0) Or (newTagArray(0) = orgTagArray(0) And newTagArray(1) < orgTagArray(1)) Then
                        WeekDay_LinkTab.Item(i.ToString) = insertTagArray
                        insertTagArray = orgTagArray(0) + "," + orgTagArray(1) + "," + orgTagArray(2) + "," + orgTagArray(3)
                        newTagArray = orgTagArray
                    End If

                Next i
                'E--------------------------------------------------------------------------
                WeekDay_LinkTab.Add(WeekDay_LinkTab.Count.ToString, insertTagArray)
                SegmentDataList.Item(DayofWeek) = WeekDay_LinkTab
            Else
                WeekDay_LinkTab.Add("0", newSegment)
                SegmentDataList.Add(DayofWeek, WeekDay_LinkTab)
            End If
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "AddToWeekOfSegmentList Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Function getWeekOfSegment_PlanID_BusPrim(ByVal DayofWeek As String, ByVal checkTime As DateTime) As String() '[0]PlanID  [1]BusPrim
        Try
            Dim returnString As String() = {"", "", "", ""}

            Dim tagWeekDay_LinkTab As New Hashtable
            If SegmentDataList.ContainsKey(DayofWeek) Then
                tagWeekDay_LinkTab = SegmentDataList.Item(DayofWeek)
                Dim minValue As Integer = 86401
                Dim maxValue As Integer = -1
                Dim maxTagIndex As Integer = 0
                For i As Integer = 0 To tagWeekDay_LinkTab.Count - 1
                    Dim tagHourValue As Integer = Val(tagWeekDay_LinkTab.Item(i.ToString).split(",")(0))
                    Dim tagMinValue As Integer = Val(tagWeekDay_LinkTab.Item(i.ToString).split(",")(1))
                    Dim tagPlanID As String = tagWeekDay_LinkTab.Item(i.ToString).split(",")(2)
                    Dim tagBusPrim As String = tagWeekDay_LinkTab.Item(i.ToString).split(",")(3)
                    Dim tagDayMin As Integer = tagHourValue * 60 + tagMinValue

                    Dim checkTimeMin As Integer = checkTime.Hour * 60 + checkTime.Minute
                    If (checkTimeMin - tagDayMin) >= 0 Then
                        If (checkTimeMin - tagDayMin) < minValue Then
                            minValue = checkTimeMin - tagDayMin
                            returnString(0) = tagHourValue
                            returnString(1) = tagMinValue
                            returnString(2) = tagPlanID
                            returnString(3) = tagBusPrim
                        End If
                    Else  '記錄最後一個時間,如果是最小的,就用最後一個時間內容回報.
                        If tagDayMin > maxValue Then
                            maxValue = tagDayMin
                            maxTagIndex = i
                        End If
                    End If
                Next i

                If minValue = 86401 Then '每有任何一個時間檢核時間小
                    returnString(0) = tagWeekDay_LinkTab.Item(maxTagIndex.ToString).split(",")(0)
                    returnString(1) = tagWeekDay_LinkTab.Item(maxTagIndex.ToString).split(",")(1)
                    returnString(2) = tagWeekDay_LinkTab.Item(maxTagIndex.ToString).split(",")(2)
                    returnString(3) = tagWeekDay_LinkTab.Item(maxTagIndex.ToString).split(",")(3)
                End If
                Return returnString
            Else
                Return Nothing
            End If
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "getWeekOfSegment_PlanID_BusPrim Catch:" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function

    Public Sub DeleteSegmentDate(ByVal nCrossRoadID As String, ByVal nSegmentType As String)
        Try
            Dim sql_delete As String = "DELETE TrafficSingal_Segment_Common_Tab  " +
                                       "WHERE CrossRoadID='" + nCrossRoadID + "' AND SegmentType='" + nSegmentType + "' "
            'Dim connection As New SqlConnection(connectionString)
            Dim adapter_delete As New SqlDataAdapter(sql_delete, connection)
            connection.Open()
            adapter_delete.UpdateCommand = connection.CreateCommand
            adapter_delete.UpdateCommand.CommandText = sql_delete
            adapter_delete.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_delete.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "DeleteSegmentDate Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    'NewSegmentDate(nCrossRoadID, nSegmentType, Val(nSegmentCount), nSegmentData(i), nNumWeekDay, nWeekDay, nIsEnable(i))
    Public Sub NewSegmentDate(ByVal nCrossRoadID As String, ByVal nSegmentType As String, ByVal nSegmentData_1 As String, ByVal nNumWeekDay As String, ByVal nWeekDay As String, ByVal nIsEnable_1 As String)
        Try
            Dim nSegmentData_2() As String = nSegmentData_1.Split(",")
            Dim sql_insert As String = "INSERT TrafficSingal_Segment_Common_Tab (CrossRoadID,SegmentType,Hour,Min,PlanID,NumWeekDay,WeekDay,BusPrimEnable) " +
                        "VALUES ('" + Trim(nCrossRoadID) + "','" + Trim(nSegmentType) + "','" + Trim(nSegmentData_2(0)) + "','" + Trim(nSegmentData_2(1)) + "','" +
                                      Trim(nSegmentData_2(2)) + "','" + Trim(nNumWeekDay) + "','" + Trim(nWeekDay) + "','" + Trim(nIsEnable_1) + "')"
            'Dim connection As New SqlConnection(connectionString)
            Dim adapter_insert As New SqlDataAdapter(sql_insert, connection)
            connection.Open()
            adapter_insert.UpdateCommand = connection.CreateCommand
            adapter_insert.UpdateCommand.CommandText = sql_insert
            adapter_insert.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_insert.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "NewTriggerPoint Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub BusStrategy_Log(ByVal GroupID As String, ByVal CrossRoadID As String, ByVal BusID As String, ByVal BusLineID As String, ByVal GoBack As String, ByVal BusPhase As String, ByVal Bus2CrossRoad As String, ByVal Strategy As String, ByVal Currentphase As String, ByVal P1 As String, ByVal P2 As String, ByVal P3 As String, ByVal Play1 As String, ByVal Play2 As String)

        Try
            Dim timedata As Boolean = True
            Dim Ptime = {P1, P2, P3}
            '_mainForm.Show_LBox_PolicyRightNowText("PTime 1 " + Ptime(0))
            '_mainForm.Show_LBox_PolicyRightNowText("PTime 2 " + Ptime(1))
            '_mainForm.Show_LBox_PolicyRightNowText("PTime 3 " + Ptime(2))
            Try

                For index As Integer = 0 To 2
                    Dim temptime As DateTime = Ptime(index)
                    Dim DiffYear As Integer = DateDiff(DateInterval.Hour, temptime, Now)
                    If DiffYear > 1 Then
                        timedata = False
                    End If
                Next index

                If Ptime(0) > Ptime(1) Or Ptime(1) > Ptime(2) Or Ptime(0) > Ptime(2) Then
                    timedata = False
                Else
                    timedata = True
                End If

            Catch ex As Exception
                _mainForm.Show_LBox_PolicyRightNowText("Time Data Error " + ex.Message)
                timedata = False
            End Try



            If Strategy <> "55" And (Bus2CrossRoad Is Nothing Or Bus2CrossRoad = "" Or Strategy Is Nothing Or Strategy = "" Or Currentphase Is Nothing Or Currentphase = "00000000" Or Currentphase = "" Or timedata = False) Then
                _mainForm.Show_LBox_PolicyRightNowText("Missing Data")

            Else
                Dim sql_insert As String = "INSERT BusStrategy_Log (GroupID,CrossRoadID,BusID,BusLineID,GoBack,BusPhase,Bus2CrossRoad,Strategy,Currentphase,P1,P2,P3,Play1,Play2) " +
                      "VALUES ('" + Trim(GroupID) + "','" + Trim(CrossRoadID) + "','" + Trim(BusID) + "','" + Trim(BusLineID) + "','" +
                                    Trim(GoBack) + "','" + Trim(BusPhase) + "','" + Trim(Bus2CrossRoad) + "','" + Trim(Strategy) + "','" + Trim(Currentphase) + "','" + Trim(P1) + "','" + Trim(P2) + "','" + Trim(P3) + "','" + Trim(Play1) + "','" + Trim(Play2) + "')"
                'Dim connection As New SqlConnection(connectionString)

                Dim adapter_insert As New SqlDataAdapter(sql_insert, connection)
                connection.Open()
                adapter_insert.UpdateCommand = connection.CreateCommand
                adapter_insert.UpdateCommand.CommandText = sql_insert
                adapter_insert.UpdateCommand.ExecuteNonQuery()
                connection.Close()
                adapter_insert.Dispose()

            End If
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "NewTriggerPoint Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub BusA1_Log(ByVal GroupID As String, ByVal CrossRoadID As String, ByVal BusID As String, ByVal BusLineID As String, ByVal GoBack As String, ByVal Speed As String, ByVal GPS As String)

        Try
            Dim time As String = DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss")

            Dim sql_insert As String = "INSERT BusA1_Log (GroupID,CrossRoadID,BusID,BusLineID,GoBack,Speed,GPS,Time) " +
                        "VALUES ('" + Trim(GroupID) + "','" + Trim(CrossRoadID) + "','" + Trim(BusID) + "','" + Trim(BusLineID) + "','" +
                                      Trim(GoBack) + "','" + Trim(Speed) + "','" + Trim(GPS) + "','" + Trim(Now.ToString("yyyy-MM-dd HH:mm:ss")) + "')"
            '
            Dim adapter_insert As New SqlDataAdapter(sql_insert, connection)
            connection.Open()
            adapter_insert.UpdateCommand = connection.CreateCommand
            adapter_insert.UpdateCommand.CommandText = sql_insert
            adapter_insert.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_insert.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "NewTriggerPoint Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub SubPhase_Log(ByVal CrossRoadID As String, ByVal SubphaseID As String, ByVal interval As Long, ByVal time As DateTime, ByVal original As Long, ByVal changed As Integer)

        Try
            'Dim time As String = DateTime.Today.ToString("yyyy") + DateTime.Today.ToString("MM") + DateTime.Today.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss")

            Dim sql_insert As String = "INSERT SubPhaseLog (CrossRoadID,SubPhaseID,SubPhaseInterval,TimeStarted,SubPhaseOriginal,Changed) " +
                        "VALUES ('" + Trim(CrossRoadID) + "','" + Trim(SubphaseID) + "','" + Trim(interval.ToString) + "','" + Trim(Now.ToString("yyyy-MM-dd HH:mm:ss")) + "','" + Trim(original.ToString) + "','" + Trim(changed.ToString) + "')"

            Dim adapter_insert As New SqlDataAdapter(sql_insert, connection)
            connection.Open()
            adapter_insert.UpdateCommand = connection.CreateCommand
            adapter_insert.UpdateCommand.CommandText = sql_insert
            adapter_insert.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_insert.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "NewSubPhase_Log Catch:" + ex.Message, _logEnable)
            _mainForm.Show_LBox_PolicyRightNowText("NewSubPhase_Log Catch:" + ex.Message)
        End Try
    End Sub

    '*********************************************************
    '**
    '** 公車線管理
    '**
    '*********************************************************
    Public Sub initComBusLineDate()
        Try
            Dim sql As String = "SELECT BusLineID,BusLine_Name,CrossRoadID,BusLine_Order,GoBack,Direct,BusSubPhaseID FROM [TaoyuanBusPrim].[dbo].[BusLine_Info_Tab]  Order BY  BusLineID,CrossRoadID,BusLine_Order  "

            'Dim connection As New SqlConnection(connectionString)
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()

            Try
                connection.Open()
            Catch ex As Exception
                _mainForm.Show_LBox_PolicyRightNowText("Can't open DB")
            End Try

            dataadapter.Fill(ds, "BusLineTab")

            Try
                connection.Close()
            Catch ex As Exception
                _mainForm.Show_LBox_PolicyRightNowText("Can't Close DB")
            End Try

            'connection.Dispose()


            BusLineList.Clear()
            BusGoBack_Direction.Clear()
            'BusLineID-CrossRoadID分類
            'HahsTable Key=BusLineID_CrossRoadID

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                BusLineList.Add(ds.Tables(0).Rows(i).Item(0).ToString + "_" + ds.Tables(0).Rows(i).Item(2).ToString + "_" + ds.Tables(0).Rows(i).Item(4).ToString,
                                ds.Tables(0).Rows(i).Item(2).ToString + "," + ds.Tables(0).Rows(i).Item(3).ToString + "," +
                                ds.Tables(0).Rows(i).Item(4).ToString + "," + ds.Tables(0).Rows(i).Item(5).ToString + "," +
                                ds.Tables(0).Rows(i).Item(6).ToString)

                '_mainForm.Show_LBox_PolicyRightNowText(" BusRoute " + ds.Tables(0).Rows(i).Item(0).ToString)
                '_mainForm.Show_LBox_PolicyRightNowText(" buslinelist " + BusLineList(ds.Tables(0).Rows(i).Item(0).ToString + "_" + ds.Tables(0).Rows(i).Item(2).ToString + "_" + ds.Tables(0).Rows(i).Item(4).ToString))

                If ds.Tables(0).Rows(i).Item(4).ToString = "00" Or ds.Tables(0).Rows(i).Item(4).ToString = "0" Then
                    BusGoBack_Direction.Add(ds.Tables(0).Rows(i).Item(0).ToString + "_1", Val(ds.Tables(0).Rows(i).Item(5)).ToString)
                    '_mainForm.Show_LBox_PolicyRightNowText(" New Bus Route Key " + ds.Tables(0).Rows(i).Item(0).ToString + "_1")
                    '_mainForm.Show_LBox_PolicyRightNowText(" Go " + BusGoBack_Direction("1").ToString)

                ElseIf ds.Tables(0).Rows(i).Item(4).ToString = "01" Or ds.Tables(0).Rows(i).Item(4).ToString = "1" Then
                    BusGoBack_Direction.Add(ds.Tables(0).Rows(i).Item(0).ToString + "_2", Val(ds.Tables(0).Rows(i).Item(5)).ToString)
                    '_mainForm.Show_LBox_PolicyRightNowText(" New Bus Route Key " + ds.Tables(0).Rows(i).Item(0).ToString + "_2")
                    '_mainForm.Show_LBox_PolicyRightNowText(" Back " + BusGoBack_Direction("2"))
                End If


            Next i

        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "initComBusLineDate Catch:" + ex.Message, _logEnable)
            _mainForm.Show_LBox_PolicyRightNowText("Moudule_DBAccess " + ex.StackTrace)
        End Try

    End Sub
    Public Sub DeleteBusLineDate(ByVal nBusLineID As String)
        Try
            Dim sql_delete As String = "DELETE BusLine_Info_Tab  " +
                                       "WHERE BusLineID='" + nBusLineID + "' "
            'Dim connection As New SqlConnection(connectionString)
            Dim adapter_delete As New SqlDataAdapter(sql_delete, connection)
            connection.Open()
            adapter_delete.UpdateCommand = connection.CreateCommand
            adapter_delete.UpdateCommand.CommandText = sql_delete
            adapter_delete.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_delete.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "DeleteBusLineDate Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    'NewBusLineDate(BusLineID, BusLineName, GoBack, i, CrossRoadData(i))
    Public Sub NewBusLineDate(ByVal nBusLineID As String, ByVal nBusLineName As String, ByVal nGoBack As String, ByVal nBusLine_Order As String, ByVal nCrossRoadData As String)
        Try
            Dim BusLineNameArry As Byte() = StrToByteArray2(nBusLineName)
            Dim nBusLineName_2 As String = System.Text.Encoding.GetEncoding(950).GetString(BusLineNameArry, 0, BusLineNameArry.Length) '?????????????
            Dim nCrossRoadData_2() As String = nCrossRoadData.Split(",")
            Dim nCrossRoadID As String = nCrossRoadData_2(0) '0

            Dim nDirect As String = nCrossRoadData_2(1)
            Dim nBusSubPhaseID As String = nCrossRoadData_2(2)

            Dim sql_insert As String = "INSERT BusLine_Info_Tab (BusLineID,BusLine_Name,CrossRoadID,BusLine_Order,GoBack,Direct,BusSubPhaseID) " +
                        "VALUES ('" + Trim(nBusLineID) + "','" + Trim(nBusLineName_2) + "','" + Trim(nCrossRoadID) + "','" + Trim(nBusLine_Order) + "','" +
                                      Trim(nGoBack) + "','" + Trim(nDirect) + "','" + Trim(nBusSubPhaseID) + "')"
            'Dim connection As New SqlConnection(connectionString)
            Dim adapter_insert As New SqlDataAdapter(sql_insert, connection)
            connection.Open()
            adapter_insert.UpdateCommand = connection.CreateCommand
            adapter_insert.UpdateCommand.CommandText = sql_insert
            adapter_insert.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_insert.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "NewBusLineDate Catch:" + ex.Message, _logEnable)
        End Try
    End Sub

    '*********************************************************
    '**
    '** 觸動點控制管理
    '**
    '*********************************************************
    Public Sub initTouchPoint2DGridView(ByVal vCrossRoadID As String)
        Try
            Dim sql As String = "SELECT Direct,TriggerPointOrder,TriggerPointID,Lat+','+Lon,PointType,StopLineLat+','+StopLineLon FROM BusPriority_TriggerPoint_Tab WHERE CrossRoadID=" + Trim(vCrossRoadID) + " Order BY  Direct,TriggerPointOrder  "

            'Dim connection As New SqlConnection(connectionString)
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            connection.Open()
            dataadapter.Fill(ds, "TriggerTab")
            connection.Close()
            'connection.Dispose()
            Dim BusDirection As String = "0"
            Dim TriggerOrder As String = ""
            Dim TriggerType As String = ""
            BusPriority_IPC.MainForm.DGrid_TriggerPoint.Rows.Clear()
            TriggerPointdList.Clear()
            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim newTriggerPoint As New Class_TriggerPoint(Trim(vCrossRoadID), Trim(ds.Tables(0).Rows(i).Item(2).ToString),
                                        Trim(ds.Tables(0).Rows(i).Item(0).ToString), Trim(ds.Tables(0).Rows(i).Item(1).ToString),
                                        Trim(ds.Tables(0).Rows(i).Item(3).ToString), Trim(ds.Tables(0).Rows(i).Item(4).ToString), Trim(ds.Tables(0).Rows(i).Item(5).ToString))
                TriggerPointdList.Add(Trim(ds.Tables(0).Rows(i).Item(2)).ToString, newTriggerPoint)

                Select Case ds.Tables(0).Rows(i).Item(0).ToString
                    Case "0"
                        BusDirection = "北向"
                    Case "1"
                        BusDirection = "東北向"
                    Case "2"
                        BusDirection = "東向"
                    Case "3"
                        BusDirection = "東南向"
                    Case "4"
                        BusDirection = "南向"
                    Case "5"
                        BusDirection = "西南向"
                    Case "6"
                        BusDirection = "西向"
                    Case "7"
                        BusDirection = "西北向"
                End Select
                TriggerOrder = (Val(ds.Tables(0).Rows(i).Item(1).ToString) + 1).ToString

                If Trim(ds.Tables(0).Rows(i).Item(4)) = "0" Or Trim(ds.Tables(0).Rows(i).Item(4)) = "00" Then
                    TriggerType = "第一觸發點"
                    Try
                        '_mainForm.Show_LBox_PolicyRightNowText("第一觸發點   xy = " + ds.Tables(0).Rows(i).Item(3).ToString)
                        '_mainForm.Show_LBox_PolicyRightNowText("第一觸發點   方向 = " + ds.Tables(0).Rows(i).Item(0).ToString)

                        If TriggerPointxy.ContainsKey("P1_" + ds.Tables(0).Rows(i).Item(0).ToString) Then

                            TriggerPointxy.Remove("P1_" + ds.Tables(0).Rows(i).Item(0).ToString)
                            TriggerPointxy.Add("P1_" + ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(3).ToString)
                            '_mainForm.Show_LBox_PolicyRightNowText("第一觸發點  方向 " + +ds.Tables(0).Rows(i).Item(0).ToString + " xy =" + ds.Tables(0).Rows(i).Item(3).ToString)
                            TriggerPointP123_Direction.Remove("P1_" + ds.Tables(0).Rows(i).Item(0).ToString)
                            TriggerPointP123_Direction.Add("P1_" + ds.Tables(0).Rows(i).Item(0).ToString, newTriggerPoint)
                        Else

                            TriggerPointxy.Add("P1_" + ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(3).ToString)
                            TriggerPointP123_Direction.Add("P1_" + ds.Tables(0).Rows(i).Item(0).ToString, newTriggerPoint)
                            '_mainForm.Show_LBox_PolicyRightNowText("第一觸發點  方向 " + +ds.Tables(0).Rows(i).Item(0).ToString + " xy =" + ds.Tables(0).Rows(i).Item(3).ToString)

                        End If


                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("Show P1 error " + ex.StackTrace)
                    End Try

                ElseIf Trim(ds.Tables(0).Rows(i).Item(4)) = "1" Or Trim(ds.Tables(0).Rows(i).Item(4)) = "01" Then
                    TriggerType = "離開觸發點"

                    Try
                        '_mainForm.Show_LBox_PolicyRightNowText("離開觸發點   xy = " + ds.Tables(0).Rows(i).Item(3).ToString)
                        '_mainForm.Show_LBox_PolicyRightNowText("離開觸發點   方向 = " + ds.Tables(0).Rows(i).Item(0).ToString)

                        If TriggerPointxy.ContainsKey("P3_" + ds.Tables(0).Rows(i).Item(0).ToString) Then

                            TriggerPointxy.Remove("P3_" + ds.Tables(0).Rows(i).Item(0).ToString)
                            TriggerPointxy.Add("P3_" + ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(3).ToString)
                            TriggerPointP123_Direction.Remove("P3_" + ds.Tables(0).Rows(i).Item(0).ToString)
                            TriggerPointP123_Direction.Add("P3_" + ds.Tables(0).Rows(i).Item(0).ToString, newTriggerPoint)
                            '_mainForm.Show_LBox_PolicyRightNowText("第一觸發點  方向 " + +ds.Tables(0).Rows(i).Item(0).ToString + " xy =" + ds.Tables(0).Rows(i).Item(3).ToString)
                        Else

                            TriggerPointxy.Add("P3_" + ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(3).ToString)
                            TriggerPointP123_Direction.Add("P3_" + ds.Tables(0).Rows(i).Item(0).ToString, newTriggerPoint)
                            '_mainForm.Show_LBox_PolicyRightNowText("第一觸發點  方向 " + +ds.Tables(0).Rows(i).Item(0).ToString + " xy =" + ds.Tables(0).Rows(i).Item(3).ToString)

                        End If


                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("Show P3 error " + ex.StackTrace)
                    End Try
                ElseIf Trim(ds.Tables(0).Rows(i).Item(4)) = "2" Or Trim(ds.Tables(0).Rows(i).Item(4)) = "02" Then
                    TriggerType = "決策觸發點"

                    Try
                        '_mainForm.Show_LBox_PolicyRightNowText("決策觸發點   xy = " + ds.Tables(0).Rows(i).Item(3).ToString)
                        '_mainForm.Show_LBox_PolicyRightNowText("決策觸發點   方向 = " + ds.Tables(0).Rows(i).Item(0).ToString)

                        If TriggerPointxy.ContainsKey("P2_" + ds.Tables(0).Rows(i).Item(0).ToString) Then

                            TriggerPointxy.Remove("P2_" + ds.Tables(0).Rows(i).Item(0).ToString)
                            TriggerPointxy.Add("P2_" + ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(3).ToString)
                            TriggerPointP123_Direction.Remove("P2_" + ds.Tables(0).Rows(i).Item(0).ToString)
                            TriggerPointP123_Direction.Add("P2_" + ds.Tables(0).Rows(i).Item(0).ToString, newTriggerPoint)
                            '_mainForm.Show_LBox_PolicyRightNowText("第一觸發點  方向 " + +ds.Tables(0).Rows(i).Item(0).ToString + " xy =" + ds.Tables(0).Rows(i).Item(3).ToString)
                        Else

                            TriggerPointxy.Add("P2_" + ds.Tables(0).Rows(i).Item(0).ToString, ds.Tables(0).Rows(i).Item(3).ToString)
                            TriggerPointP123_Direction.Add("P2_" + ds.Tables(0).Rows(i).Item(0).ToString, newTriggerPoint)
                            '_mainForm.Show_LBox_PolicyRightNowText("第一觸發點  方向 " + +ds.Tables(0).Rows(i).Item(0).ToString + " xy =" + ds.Tables(0).Rows(i).Item(3).ToString)

                        End If


                    Catch ex As Exception
                        _mainForm.Show_LBox_PolicyRightNowText("Show P2 error " + ex.StackTrace)
                    End Try
                Else
                    TriggerType = "參考觸發點(" + (Val(ds.Tables(0).Rows(i).Item(4)) - 2).ToString + ")"
                End If

                Dim row As String() = New String() {BusDirection, TriggerOrder, ds.Tables(0).Rows(i).Item(2).ToString, TriggerType, ds.Tables(0).Rows(i).Item(3).ToString}
                BusPriority_IPC.MainForm.DGrid_TriggerPoint.Rows.Add(row)
            Next i

            dataadapter.Dispose()
            ds.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "initTouchPoint2DGridView Catch:" + ex.Message, _logEnable)
        End Try

    End Sub

    Public Sub DeleteTriggerPoint(ByVal nCrossRoadID As String)
        Try
            Dim sql_delete As String = "DELETE BusPriority_TriggerPoint_Tab  " +
                                       "WHERE CrossRoadID='" + nCrossRoadID + "'"
            'Dim connection As New SqlConnection(connectionString)
            Dim adapter_delete As New SqlDataAdapter(sql_delete, connection)
            connection.Open()
            adapter_delete.UpdateCommand = connection.CreateCommand
            adapter_delete.UpdateCommand.CommandText = sql_delete
            adapter_delete.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_delete.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "UpdateTriggerPoint Catch:" + ex.Message, _logEnable)
        End Try
    End Sub

    Public Sub NewTriggerPoint(ByVal nCrossRoadID As String, ByVal nTriggerPointID As String, ByVal nDirect As String, ByVal nTriggerOrder As String, ByVal nPosLat As String, ByVal nPosLon As String, ByVal nPointType As String, ByVal nStopLineLat As String, ByVal nStopLineLon As String)
        Try
            Dim sql_insert As String = "INSERT BusPriority_TriggerPoint_Tab (CrossRoadID,TriggerPointID,Direct,TriggerPointOrder,Lat,Lon,PointType,StopLineLat,StopLineLon) " +
                        "VALUES ('" + Trim(nCrossRoadID) + "','" + Trim(nTriggerPointID) + "','" + Trim(nDirect) + "','" + Trim(nTriggerOrder) + "','" +
                                      Trim(nPosLat) + "','" + Trim(nPosLon) + "','" + Trim(nPointType) + "','" + Trim(nStopLineLat) + "','" + Trim(nStopLineLon) + "')"
            'Dim connection As New SqlConnection(connectionString)
            Dim adapter_insert As New SqlDataAdapter(sql_insert, connection)
            connection.Open()
            adapter_insert.UpdateCommand = connection.CreateCommand
            adapter_insert.UpdateCommand.CommandText = sql_insert
            adapter_insert.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_insert.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "NewTriggerPoint Catch:" + ex.Message, _logEnable)
        End Try
    End Sub

    '*********************************************************
    '**
    '** 路口控制管理
    '**
    '*********************************************************
    Public Sub initCrossRoad2TreeView()
        Try
            Dim sql As String = "SELECT DISTINCT GroupID,GroupName FROM BusPrority_Group_Info_Tab  "

            ' Dim connection As New SqlConnection(connectionString)
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            connection.Open()
            dataadapter.Fill(ds, "GroupTab")
            connection.Close()
            If ds.Tables(0).Rows.Count > 0 Then
                Dim GroupID As String = ds.Tables(0).Rows(0).Item(0).ToString
                Dim GroupName As String = ds.Tables(0).Rows(0).Item(1).ToString
                COMMON_GroupID = GroupID
                COMMON_GroupName = GroupName
                sql = "SELECT CrossRoadID,CrossRoadName,CrossRoadIP,CrossRoadPort,CrossRoadLat,CrossRoadLon,isMaster,IC_Addr FROM BusPrority_CrossRoad_Info_Tab WHERE GroupID='" + GroupID + "' Order By CrossRoadID"
                Dim dataadapter2 As New SqlDataAdapter(sql, connection)
                Dim ds2 As New DataSet()
                dataadapter2.Fill(ds2, "CrossRoadTab")
                CrossRoadList.Clear()
                COMMON_EquipID = Trim(ds2.Tables(0).Rows(0).Item(7).ToString) 'IntToHexString(Val(ds2.Tables(0).Rows(0).Item(7).ToString), 4)
                For i As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                    Dim newCrossRoad As New Class_CrossRoad(Trim(ds2.Tables(0).Rows(i).Item(0).ToString), Trim(ds2.Tables(0).Rows(i).Item(1).ToString),
                                                            Trim(ds2.Tables(0).Rows(i).Item(2).ToString), Trim(ds2.Tables(0).Rows(i).Item(3).ToString),
                                                            Trim(ds2.Tables(0).Rows(i).Item(4).ToString) + "," + Trim(ds2.Tables(0).Rows(i).Item(5).ToString),
                                                            Trim(ds2.Tables(0).Rows(i).Item(6).ToString), Trim(ds2.Tables(0).Rows(i).Item(7).ToString))
                    CrossRoadList.Add(Trim(ds2.Tables(0).Rows(i).Item(0).ToString), newCrossRoad)
                    If Trim(ds2.Tables(0).Rows(i).Item(6).ToString) = "1" Then
                        BusPriority_IPC.MainForm.TView_CrossRoad.Nodes.Add("[" + ds2.Tables(0).Rows(i).Item(0).ToString + "]-M-" + ds2.Tables(0).Rows(i).Item(1).ToString)
                    Else
                        BusPriority_IPC.MainForm.TView_CrossRoad.Nodes.Add("[" + ds2.Tables(0).Rows(i).Item(0).ToString + "]" + ds2.Tables(0).Rows(i).Item(1).ToString)
                    End If

                Next i
                dataadapter2.Dispose()
                ds2.Dispose()
            End If
            'connection.Close()
            'connection.Dispose()
            dataadapter.Dispose()
            ds.Dispose()

            Dim SelecNodeItemID As String = BusPriority_IPC.MainForm.TView_CrossRoad.Nodes(0).Text
            SelecNodeItemID = SelecNodeItemID.Substring(SelecNodeItemID.IndexOf("[") + 1, SelecNodeItemID.IndexOf("]") - SelecNodeItemID.IndexOf("[") - 1)
            SelectCrossRoadID = SelecNodeItemID 'jason 20150413 OTA SaveTo Table ??
            init_Configdata(SelecNodeItemID)
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "initCrossRoad2TreeView Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    '??????????????????????????????????
    Public Sub UpdateCrossRoad(ByVal nCrossRoadID As String, ByVal nTriggerPointID As String, ByVal nDirect As String, ByVal nTriggerOrder As String, ByVal nPosLat As String, ByVal nPosLon As String, ByVal nPointType As String, ByVal nStopLineLat As String, ByVal nStopLineLon As String)
        Try
            Dim sql_update As String = "UPDATE BusPriority_TriggerPoint_Tab " +
                                       "SET CrossRoadID='" + Trim(nCrossRoadID) +
                                       "',StopLineLat='" + Trim(nStopLineLat) +
                                       "',StopLineLon='" + Trim(nStopLineLon) +
                                       "',Direct='" + Trim(nDirect) +
                                       "',TriggerPointOrder='" + Trim(nTriggerOrder) +
                                       "',Lat='" + Trim(nPosLat) +
                                       "',Lon='" + Trim(nPosLon) +
                                       "',PointType='" + Trim(nPointType) +
                                       "' WHERE TriggerPointID='" + nTriggerPointID + "'"
            'Dim connection As New SqlConnection(connectionString)
            Dim adapter_update As New SqlDataAdapter(sql_update, connection)
            connection.Open()
            adapter_update.UpdateCommand = connection.CreateCommand
            adapter_update.UpdateCommand.CommandText = sql_update
            adapter_update.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_update.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "UpdateTriggerPoint Catch:" + ex.Message, _logEnable)
        End Try
    End Sub

    Public Sub NewCrossRoad(ByVal nCrossRoadID As String, ByVal nTriggerPointID As String, ByVal nDirect As String, ByVal nTriggerOrder As String, ByVal nPosLat As String, ByVal nPosLon As String, ByVal nPointType As String, ByVal nStopLineLat As String, ByVal nStopLineLon As String)
        Try
            Dim sql_insert As String = "INSERT BusPriority_TriggerPoint_Tab (CrossRoadID,TriggerPointID,Direct,TriggerPointOrder,Lat,Lon,PointType,StopLineLat,StopLineLon) " +
                        "VALUES ('" + Trim(nCrossRoadID) + "','" + Trim(nTriggerPointID) + "','" + Trim(nDirect) + "','" + Trim(nTriggerOrder) + "','" +
                                      Trim(nPosLat) + "','" + Trim(nPosLon) + "','" + Trim(nPointType) + "','" + Trim(nStopLineLat) + "','" + Trim(nStopLineLon) + "')"
            'Dim connection As New SqlConnection(connectionString)
            Dim adapter_insert As New SqlDataAdapter(sql_insert, connection)
            connection.Open()
            adapter_insert.UpdateCommand = connection.CreateCommand
            adapter_insert.UpdateCommand.CommandText = sql_insert
            adapter_insert.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_insert.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "NewTriggerPoint Catch:" + ex.Message, _logEnable)
        End Try
    End Sub

    Public Sub StrategyLog(ByVal GroupID As String, ByVal CrossRoadID As String, ByVal Direct As String, ByVal BusID As String, ByVal BusPhaseID As String, ByVal BusETA As String, ByVal BusWayLightStatus As String, ByVal BusWayRemainLight As String, ByVal ModifyPhaseID As String, ByVal OriginalGreenTime As String, ByVal ModifiedGreenTime As String, ByVal TimeDate As String)

        '5FH+B4H+GroupID+CrossRoadID+Direct+BusID+Year+Month+Day+Hour+Min+Second+ BusWaySubPhaseID+BusWayReachSec+BusWayLightStatus+
        'BusWayLightSecRemain + ModifyGreenCount + (SubPhaseID + OrgGreen +
        'NewGreen) * ModifyGreenCount

        '  [GroupID]
        ',[CrossRoadID]
        ',[Direct]
        ',[BusID]
        ',[BusWaySubPhaseID]
        ',[BusWayReachSec]
        ',[BusWayLightStatus]
        ',[BusWayLightSecRemain]
        ',[ModifiedSubPhaseID]
        ',[OriginalGreen]
        ',[ModifiedGreen]
        ',[TimeDate]

        Try
            Dim sql_insert As String = "INSERT BusPriority_Strategy_Log (GroupID,CrossRoadID,Direct,BusID,BusWaySubPhaseID,BusWayReachSec,BusWayLightStatus,BusWayLightSecRemain,ModifiedSubPhaseID,OriginalGreen,ModifiedGreen,TimeDate) " +
                        "VALUES ('" + Trim(GroupID) + "','" + Trim(CrossRoadID) + "','" + Trim(Direct) + "','" + Trim(BusID) + "','" + Trim(BusPhaseID) + "','" + Trim(BusETA) + "','" + Trim(BusWayLightStatus) + "','" + Trim(BusWayRemainLight) + "','" + Trim(ModifyPhaseID) + "','" + Trim(OriginalGreenTime) + "','" + Trim(ModifiedGreenTime) + "','" + Trim(TimeDate) + "')"
            'Dim connection As New SqlConnection(connectionString)
            Dim adapter_insert As New SqlDataAdapter(sql_insert, connection)
            connection.Open()
            adapter_insert.UpdateCommand = connection.CreateCommand
            adapter_insert.UpdateCommand.CommandText = sql_insert
            adapter_insert.UpdateCommand.ExecuteNonQuery()
            connection.Close()
            adapter_insert.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "NewTriggerPoint Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    '*********************************************************
    '**
    '** 紀錄查詢功能
    '**
    '*********************************************************


    Public Sub LoadCrossRoadID_Name()
        Try

            BusPriority_IPC.MainForm.CBox_CrossRoadID_His.Items.Clear()
            Dim sql As String = "SELECT CrossRoadID,CrossRoadName FROM BusPrority_CrossRoad_Info_Tab  "

            'Dim connection As New SqlConnection(connectionString)
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            connection.Open()
            dataadapter.Fill(ds, "CrossRoadItem")
            connection.Close()

            If ds.Tables(0).Rows.Count > 0 Then
                BusPriority_IPC.MainForm.CBox_CrossRoadID_His.Text = ds.Tables(0).Rows(0).Item(0).ToString + "|" + ds.Tables(0).Rows(0).Item(1).ToString
                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim ItemName As String = ds.Tables(0).Rows(i).Item(0).ToString + "|" + ds.Tables(0).Rows(i).Item(1).ToString
                    BusPriority_IPC.MainForm.CBox_CrossRoadID_His.Items.Add(ItemName)
                Next i
            End If
            connection.Close()
            'connection.Dispose()
            dataadapter.Dispose()
            ds.Dispose()


        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "LoadCrossRoadID_Name Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub LoadBusPriority_HistorySearch(ByVal rCrossRoadID As String, ByVal rStrategyIndex As String)
        Try
            Dim StartDay, EndDay, StartTime, EndTime As String

            StartDay = Trim(BusPriority_IPC.MainForm.DataPicker_Start.Value.ToString("MM/dd/yyyy"))
            EndDay = Trim(BusPriority_IPC.MainForm.DataPicker_End.Value.ToString("MM/dd/yyyy"))
            StartTime = Trim(BusPriority_IPC.MainForm.DataPicker_Start.Value.ToString("HH:mm:ss"))
            EndTime = Trim(BusPriority_IPC.MainForm.DataPicker_End.Value.ToString("HH:mm:ss"))
            If BusPriority_IPC.MainForm.DGrid_History.Rows.Count > 0 Then
                'BusPriority_IPC.MainForm.DGrid_History.Rows.Clear()
                BusPriority_IPC.MainForm.DGrid_History.Columns.Clear()
            End If

            Select Case rStrategyIndex
                Case 0 '執行策略紀錄
                    Dim sql As String = "SELECT BusID ,BusLineID,GoBack as '方向',BusPhase as '公車時相',Bus2CrossRoad as 'P2到路口(sec)',Strategy '策略',CurrentPhase as '目前時相',convert(varchar(22), P1, 120) as 'P1觸發時間',convert(varchar(22), P2, 120) as 'P2觸發時間',convert(varchar(22), P3, 120) as 'P3觸發時間' " +
                                        "FROM BusStrategy_Log " +
                    "WHERE CrossRoadID='" + rCrossRoadID + "' AND P3>'" + StartDay + " " + StartTime + "' AND P3<'" + EndDay + " " + EndTime + "'" +
                    " Order by P3 ASC"
                    'Dim connection As New SqlConnection(connectionString)
                    Dim dataadapter As New SqlDataAdapter(sql, connection)
                    Dim ds As New DataSet()
                    connection.Open()
                    dataadapter.Fill(ds, "StrategyRec")
                    connection.Close()
                    Dim pp = ds.Tables(0).Rows.Count
                    BusPriority_IPC.MainForm.DGrid_History.DataSource = ds
                    BusPriority_IPC.MainForm.DGrid_History.DataMember = "StrategyRec"
                    ds.Dispose()
                    dataadapter.Dispose()
                Case 1 '車速紀錄
                    Dim sql As String = "SELECT BusID ,GoBack as '方向',Speed as '時速',GPS as 'GPS座標',convert(varchar(22), Time, 120) as '時間' " +
                                        "FROM BusA1_Log " +
                    "WHERE CrossRoadID='" + rCrossRoadID + "' AND Time>'" + StartDay + " " + StartTime + "' AND Time<'" + EndDay + " " + EndTime + "'" +
                    " Order by Time ASC"
                    'Dim connection As New SqlConnection(connectionString)
                    Dim dataadapter As New SqlDataAdapter(sql, connection)
                    Dim ds As New DataSet()
                    connection.Open()
                    dataadapter.Fill(ds, "SpeedRec")
                    connection.Close()
                    Dim pp = ds.Tables(0).Rows.Count
                    BusPriority_IPC.MainForm.DGrid_History.DataSource = ds
                    BusPriority_IPC.MainForm.DGrid_History.DataMember = "SpeedRec"
                    ds.Dispose()
                    dataadapter.Dispose()

                Case 2 '軟體更新紀錄
                    Dim sql As String = "SELECT GroupID as '群組編號',GroupName as '群組名稱',CrossRoadID as '路口編號',CrossRoadName as '路口名稱'," +
                                        "convert(varchar(22), TimeDate, 120) as '更新時間',Description as '說明' FROM BusPriority_Update_Log_View " +
                                        "WHERE UpdateType=1 AND TimeDate>'" + StartDay + " " + StartTime + "' AND TimeDate<'" + EndDay + " " + EndTime + "' Order by TimeDate ASC"

                    Dim dataadapter As New SqlDataAdapter(sql, connection)
                    Dim ds As New DataSet()
                    connection.Open()
                    dataadapter.Fill(ds, "OTARec")
                    connection.Close()
                    Dim pp = ds.Tables(0).Rows.Count
                    BusPriority_IPC.MainForm.DGrid_History.DataSource = ds
                    BusPriority_IPC.MainForm.DGrid_History.DataMember = "OTARec"
                    ds.Dispose()
                    dataadapter.Dispose()


                Case 3 '排程更新紀錄
                    Dim sql As String = "SELECT GroupID as '群組編號',GroupName as '群組名稱',CrossRoadID as '路口編號',CrossRoadName as '路口名稱'," +
                                        "convert(varchar(22), TimeDate, 120) as '更新時間',Description as '說明' FROM BusPriority_Update_Log_View " +
                                        "WHERE UpdateType=2 AND TimeDate>'" + StartDay + " " + StartTime + "' AND TimeDate<'" + EndDay + " " + EndTime + "' Order by TimeDate ASC"

                    Dim dataadapter As New SqlDataAdapter(sql, connection)
                    Dim ds As New DataSet()
                    connection.Open()
                    dataadapter.Fill(ds, "SegmentRec")
                    connection.Close()
                    Dim pp = ds.Tables(0).Rows.Count
                    BusPriority_IPC.MainForm.DGrid_History.DataSource = ds
                    BusPriority_IPC.MainForm.DGrid_History.DataMember = "SegmentRec"
                    ds.Dispose()
                    dataadapter.Dispose()

                Case 4 '組態更新紀錄
                    Dim sql As String = "SELECT GroupID as '群組編號',GroupName as '群組名稱',CrossRoadID as '路口編號',CrossRoadName as '路口名稱'," +
                                        "convert(varchar(22), TimeDate, 120) as '更新時間',Description as '說明' FROM BusPriority_Update_Log_View " +
                                        "WHERE UpdateType=3 AND TimeDate>'" + StartDay + " " + StartTime + "' AND TimeDate<'" + EndDay + " " + EndTime + "' Order by TimeDate ASC"

                    Dim dataadapter As New SqlDataAdapter(sql, connection)
                    Dim ds As New DataSet()
                    connection.Open()
                    dataadapter.Fill(ds, "GroupInfoRec")
                    connection.Close()
                    Dim pp = ds.Tables(0).Rows.Count
                    BusPriority_IPC.MainForm.DGrid_History.DataSource = ds
                    BusPriority_IPC.MainForm.DGrid_History.DataMember = "GroupInfoRec"
                    ds.Dispose()
                    dataadapter.Dispose()




            End Select
            BusPriority_IPC.MainForm.DGrid_History.Columns(9).Width = 150


        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "LoadBusPriority_HistorySearch Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub LoadBusPriority_HistoryInsert(ByVal rGroupID As String, ByVal rCrossRoadID As String, ByVal rStrategyIndex As String)
        Try

            Dim SaveType As String = rStrategyIndex
            Dim rDescription As String = ""
            Select Case rStrategyIndex
                Case 0 '執行策略紀錄
                    ' 略-策略在另一個表格
                Case 1 '軟體更新紀錄
                Case 2 '排程更新紀錄
                Case 3 '組態更新紀錄-5F81觸發點 
                    rDescription = "觸發點管理更新"
                Case 4 '組態更新紀錄-5F86群組
                    rStrategyIndex = 3
                    rDescription = "群組管理更新"
                Case 5 '組態更新紀錄-5F88路線
                    rStrategyIndex = 3
                    rDescription = "路線管理更新"
            End Select
            Dim adapter_insert As New SqlDataAdapter
            Dim sql_insert As String
            sql_insert = "INSERT BusPriority_Update_Log (GroupID,CrossRoadID,UpdateType,TimeDate,Description) " +
                                       "VALUES ('" + rGroupID + "'," + rCrossRoadID + "," + rStrategyIndex.ToString + ",'" + Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + rDescription + "')"
            connection.Open()
            adapter_insert.InsertCommand = connection.CreateCommand
            adapter_insert.InsertCommand.CommandText = sql_insert
            adapter_insert.InsertCommand.ExecuteNonQuery()
            connection.Close()

            adapter_insert.Dispose()

        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "LoadBusPriority_HistoryInsert Catch:" + ex.Message, _logEnable)
        End Try
    End Sub
    '*********************************************************
    '**
    '** 分析圖
    '**
    '*********************************************************
    Public Sub SetCharFromDB(ByVal rCrossRoadID As String, ByVal rStrategyIndex As String)
        Try
            'BusPriority_IPC.MainForm.Chart_Data.Series.Clear()
            'BusPriority_IPC.MainForm.Chart_Data.Legends.Clear()
            'BusPriority_IPC.MainForm.Chart_Data.Name = "Chart1"

            'Dim DataSeries(1) As Series
            'DataSeries(0) = New Series()
            'DataSeries(0).ChartArea = "ChartArea1"
            'DataSeries(0).Name = "Series_0"
            'DataSeries(0).Color = Color.Red


            'DataSeries(1) = New Series()
            'DataSeries(1).ChartArea = "ChartArea1"
            'DataSeries(1).Name = "Series_1"
            'DataSeries(1).Color = Color.Blue


            Dim StartDay, EndDay, StartTime, EndTime As String

            StartDay = BusPriority_IPC.MainForm.Lab_DateStart.Text
            EndDay = BusPriority_IPC.MainForm.Lab_DateEnd.Text
            StartTime = Trim(BusPriority_IPC.MainForm.DataPicker_Start.Value.ToString("HH:mm:ss"))
            EndTime = Trim(BusPriority_IPC.MainForm.DataPicker_End.Value.ToString("HH:mm:ss"))

            Dim sql As String = "SELECT BusID  " +
                                       "FROM BusA1_Log " +
                   "WHERE CrossRoadID='" + rCrossRoadID + "' AND Time>'" + StartDay + " " + StartTime + "' AND Time<'" + EndDay + " " + EndTime + "'" +
                   " GROUP by BusID"
            connection.Open()
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            dataadapter.Fill(ds, "SpeedRecChar1")
            connection.Close()
            dataadapter.Dispose()


            Dim DataSeries(ds.Tables(0).Rows.Count - 1) As Series
            BusPriority_IPC.MainForm.Chart_Data.Series.Clear()
            BusPriority_IPC.MainForm.Chart_Data.Legends.Clear()
            BusPriority_IPC.MainForm.Chart_Data.Name = "Chart1"
            Dim InterVal_Sec As Double = Val(BusPriority_IPC.MainForm.TBox_Interval.Text) / 1000000
            BusPriority_IPC.MainForm.Chart_Data.ChartAreas(0).AxisX.Interval = InterVal_Sec

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1

                sql = "SELECT (CONVERT(float, (convert(varchar(22), Time, 112)+'.'" +
                      "+REPLICATE('0',2-LEN(CONVERT(varchar(10), DATEPART(hh,Time)))) + RTRIM(CAST(CONVERT(varchar(10), DATEPART(hh,Time)) AS CHAR))" +
                      "+REPLICATE('0',2-LEN(CONVERT(varchar(10), DATEPART(mi,Time)))) + RTRIM(CAST(CONVERT(varchar(10), DATEPART(mi,Time)) AS CHAR))" +
                      "+REPLICATE('0',2-LEN(CONVERT(varchar(10), DATEPART(ss,Time)))) + RTRIM(CAST(CONVERT(varchar(10), DATEPART(ss,Time)) AS CHAR)))))" +
                      " as 時間,CONVERT(INT, Speed) as 速度,GoBack  " +
                                      "FROM BusA1_Log " +
                  "WHERE CrossRoadID='" + rCrossRoadID + "' AND BUSID='" + ds.Tables(0).Rows(i).Item(0) + "' AND Time>'" + StartDay + " " + StartTime + "' AND Time<'" + EndDay + " " + EndTime + "'" +
                  " Order by Time ASC"
                'REPLICATE('0',2-LEN(CONVERT(varchar(10), DATEPART(mi,Time)))) + RTRIM(CAST(CONVERT(varchar(10), DATEPART(mi,Time)) AS CHAR))
                connection.Open()

                Dim dataadapter1 As New SqlDataAdapter(sql, connection)
                Dim ds1 As New DataSet()
                dataadapter1.Fill(ds1, "SpeedRecChar2")
                connection.Close()



                If ds1.Tables(0).Rows.Count > 0 Then
                    DataSeries(i) = New Series()

                    'BusPriority_IPC.MainForm.Chart_Data.Name = "Chart1"
                    DataSeries(i).ChartArea = "ChartArea1"

                    DataSeries(i).Name = "Series" + i.ToString

                    Select Case i
                        Case 0
                            DataSeries(i).Color = Color.Red
                        Case 1
                            DataSeries(i).Color = Color.Blue
                        Case 2
                            DataSeries(i).Color = Color.LimeGreen
                        Case 3
                            DataSeries(i).Color = Color.Brown
                        Case 4
                            DataSeries(i).Color = Color.Yellow
                        Case 5
                            DataSeries(i).Color = Color.DarkSeaGreen
                    End Select

                    BusPriority_IPC.MainForm.Chart_Data.Series.Add(DataSeries(i))
                    BusPriority_IPC.MainForm.Chart_Data.TabIndex = 0
                    BusPriority_IPC.MainForm.Chart_Data.Text = "Chart1"

                    Dim Legend1 As Legend = New Legend()
                    BusPriority_IPC.MainForm.Chart_Data.Legends.Add(Legend1)
                    BusPriority_IPC.MainForm.Chart_Data.Series(DataSeries(i).Name).LegendText = ds.Tables(0).Rows(i).Item(0) + IIf(Trim(ds1.Tables(0).Rows(0).Item(2)) = "1", "(去)", "(回)")

                    '折線-3
                    BusPriority_IPC.MainForm.Chart_Data.Series(i).ChartType = 3

                    If i = 0 Then
                        BusPriority_IPC.MainForm.Chart_Data.Legends(0).Title = "BUSID"
                        'BusPriority_IPC.MainForm.Chart_Data.Series(0).XValueMember = "時間"
                        'BusPriority_IPC.MainForm.Chart_Data.Series(0).YValueMembers = "速度"
                        BusPriority_IPC.MainForm.Chart_Data.ChartAreas(0).AxisX.Title = "(日期.時間)"
                        BusPriority_IPC.MainForm.Chart_Data.ChartAreas(0).AxisY.Title = "時速(KM/H)"

                    End If
                    Dim xarray1 As Double() = (From myRow In ds1.Tables(0).AsEnumerable
                        Select myRow.Field(Of Double)("時間")).ToArray
                    Dim yarray1 As Integer() = (From myRow In ds1.Tables(0).AsEnumerable
                        Select myRow.Field(Of Integer)("速度")).ToArray

                    BusPriority_IPC.MainForm.Chart_Data.Series(DataSeries(i).Name).Points.DataBindXY(xarray1, yarray1)

                    BusPriority_IPC.MainForm.Chart_Data.Series(DataSeries(i).Name).MarkerStyle = MarkerStyle.Circle
                    BusPriority_IPC.MainForm.Chart_Data.Series(DataSeries(i).Name).MarkerColor = Color.Black
                    BusPriority_IPC.MainForm.Chart_Data.Series(DataSeries(i).Name).MarkerSize = 5
                    'BusPriority_IPC.MainForm.Chart_Data.Series(DataSeries(i).Name).Points.AddXY(ds1.Tables(0).Rows(RowIndex).Item(0), ds1.Tables(0).Rows(RowIndex).Item(1))

                    'BusPriority_IPC.MainForm.Chart_Data.Series(DataSeries(i).Name).Points.Item(0).Label = ds1.Tables(0).Rows(RowIndex).Item(0)

                    'Next RowIndex
                End If
                dataadapter1.Dispose()
                ds1.Dispose()
            Next i

            ds.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "SetCharFromDB Catch:" + ex.Message, _logEnable)
        End Try



    End Sub
    Public Sub initBusStopDistance()
        If NEAR_BusStop = "1" Then

            Try
                Dim sql As String = "SELECT CrossRoadID,GoBack,BusStopDist FROM BusStopDist_Tab order by CrossRoadID,GoBack"

                'Dim connection As New SqlConnection(connectionString)
                Dim dataadapter As New SqlDataAdapter(sql, connection)
                Dim ds As New DataSet()
                connection.Open()
                dataadapter.Fill(ds, "BusStopDist")
                connection.Close()
                'connection.Dispose()
                BusStopDist_Tab.Clear()

                For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    'Dim WeekSegmentString = Trim(ds.Tables(0).Rows(i).Item(1).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(2).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(3).ToString)
                    '_mainForm.Show_LBox_PolicyRightNowText("BusStopDist Data 1 : " + Trim(ds.Tables(0).Rows(i).Item(0).ToString) + " 2 : " + Trim(ds.Tables(0).Rows(i).Item(1).ToString) + " 3 : " + Trim(ds.Tables(0).Rows(i).Item(2).ToString))
                    BusStopDist_Tab.Add(Trim(ds.Tables(0).Rows(i).Item(0).ToString) + "_" + Trim(ds.Tables(0).Rows(i).Item(1).ToString), Trim(ds.Tables(0).Rows(i).Item(2).ToString))
                    'BusStopDist_Tab.Add(vCrossRoadID, )
                Next i

                dataadapter.Dispose()
                ds.Dispose()
            Catch ex As Exception
                WriteLog(curPath, "Moudule_DBAccess", "initBusStopDistance Catch:" + ex.Message, _logEnable)
                _mainForm.Show_LBox_PolicyRightNowText("BusStopDist Data Error " + ex.Message.ToString)
            End Try
        End If
    End Sub
    Public Sub BusStopDelay()

        Try
            Dim sql As String = "SELECT  CrossRoadID,PlanID,AvgBusStopTime_GO,BusStop2CrossTime_GO,AvgBusStopTime_BACK,BusStop2CrossTime_BACK FROM BusStopDelay_Tab"

            'Dim connection As New SqlConnection(connectionString)
            Dim dataadapter As New SqlDataAdapter(sql, connection)
            Dim ds As New DataSet()
            connection.Open()
            dataadapter.Fill(ds, "BusStopDist")
            connection.Close()
            'connection.Dispose()
            BusStopDist_Tab.Clear()

            For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
                'Dim WeekSegmentString = Trim(ds.Tables(0).Rows(i).Item(1).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(2).ToString) + "," + Trim(ds.Tables(0).Rows(i).Item(3).ToString)
                '_mainForm.Show_LBox_PolicyRightNowText("BusStopDist Data 1 : " + Trim(ds.Tables(0).Rows(i).Item(0).ToString) + " 2 : " + Trim(ds.Tables(0).Rows(i).Item(1).ToString) + " 3 : " + Trim(ds.Tables(0).Rows(i).Item(2).ToString))
                BusStopDist_Tab.Add(Trim(ds.Tables(0).Rows(i).Item(0).ToString) + "_" + Trim(ds.Tables(0).Rows(i).Item(1).ToString), Trim(ds.Tables(0).Rows(i).Item(2).ToString))
                'BusStopDist_Tab.Add(vCrossRoadID, )
            Next i

            dataadapter.Dispose()
            ds.Dispose()
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "initBusStopDistance Catch:" + ex.Message, _logEnable)
            _mainForm.Show_LBox_PolicyRightNowText("BusStopDist Data Error " + ex.Message.ToString)
        End Try

    End Sub




    Public Sub SaveXLS(ByVal save_type As Integer)

        'jason 20150413 報表匯出功能擴增
        'S-----------------------------------------------------------------
        'If save_type > 1 Then
        '    MessageBox.Show("未建置完成!", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'E-----------------------------------------------------------------
        Dim fileName As String
        Try
            Dim sFileDialog As New SaveFileDialog
            sFileDialog.Filter = "EXCEL檔 (*.xls)|*.xls" ' 只能寫入EXCEL檔
            sFileDialog.FilterIndex = 1
            sFileDialog.RestoreDirectory = True

            If _mainForm.DGrid_History.RowCount > 0 Then
                If sFileDialog.ShowDialog() = DialogResult.OK Then
                    fileName = sFileDialog.FileName
                    Dim workbook As HSSFWorkbook = New HSSFWorkbook()
                    Dim sheet1 As HSSFSheet = workbook.CreateSheet("sheet1")

                    'Fill Data
                    Dim StartDay, EndDay As String
                    Dim Sdate As DateTime = _mainForm.DataPicker_Start.Value
                    Dim Edate As DateTime = _mainForm.DataPicker_End.Value
                    StartDay = Sdate.ToString("yyyy/MM/dd HH:mm:ss")
                    EndDay = Edate.ToString("yyyy/MM/dd HH:mm:ss")

                    Dim rowIndex As Integer = 0

                    Select Case save_type
                        Case 0
                            sheet1.SetColumnWidth(0, 20 * 256)
                            sheet1.SetColumnWidth(1, 20 * 256)
                            sheet1.SetColumnWidth(2, 20 * 256)
                            sheet1.SetColumnWidth(3, 20 * 256)
                            sheet1.SetColumnWidth(4, 20 * 256)
                            sheet1.SetColumnWidth(5, 20 * 256)
                            sheet1.SetColumnWidth(6, 20 * 256)
                            sheet1.SetColumnWidth(7, 20 * 256)
                            sheet1.SetColumnWidth(8, 20 * 256)
                            sheet1.SetColumnWidth(9, 20 * 256)
                            Dim row_0, row_1 As HSSFRow
                            Dim cell_0, cell_1, cell_2, cell_3, cell_4, cell_5, cell_6, cell_7, cell_8, cell_9, cell_10 As HSSFCell
                            row_0 = sheet1.CreateRow(0)
                            cell_0 = row_0.CreateCell(0)
                            cell_0.SetCellValue("執行策略紀錄")
                            cell_0 = row_0.CreateCell(1)
                            cell_0.SetCellValue("時間:" + StartDay + " - " + EndDay)

                            row_1 = sheet1.CreateRow(1)
                            cell_1 = row_1.CreateCell(0)
                            cell_1.SetCellValue("BUSID")
                            cell_2 = row_1.CreateCell(1)
                            cell_2.SetCellValue("BusLineID")
                            cell_3 = row_1.CreateCell(2)
                            cell_3.SetCellValue("方向")
                            cell_4 = row_1.CreateCell(3)
                            cell_4.SetCellValue("公車時相")
                            cell_5 = row_1.CreateCell(4)
                            cell_5.SetCellValue("P2到路口(Sec)")

                            cell_6 = row_1.CreateCell(5)
                            cell_6.SetCellValue("策略")
                            cell_7 = row_1.CreateCell(6)
                            cell_7.SetCellValue("目前時相")
                            cell_8 = row_1.CreateCell(7)
                            cell_8.SetCellValue("P1觸發時間")
                            cell_9 = row_1.CreateCell(8)
                            cell_9.SetCellValue("P2觸發時間")
                            cell_10 = row_1.CreateCell(9)
                            cell_10.SetCellValue("P3觸發時間")


                            For i = 0 To _mainForm.DGrid_History.RowCount - 1
                                Dim row As HSSFRow
                                Dim cell As HSSFCell
                                row = sheet1.CreateRow(2 + i)
                                cell = row.CreateCell(0)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(0).Value.ToString())
                                cell = row.CreateCell(1)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(1).Value.ToString())

                                cell = row.CreateCell(2)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(2).Value.ToString())
                                cell = row.CreateCell(3)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(3).Value.ToString())
                                cell = row.CreateCell(4)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(4).Value.ToString())

                                cell = row.CreateCell(5)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(5).Value.ToString())
                                cell = row.CreateCell(6)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(6).Value.ToString())
                                cell = row.CreateCell(7)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(7).Value.ToString())
                                cell = row.CreateCell(8)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(8).Value.ToString())
                                cell = row.CreateCell(9)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(9).Value.ToString())


                            Next i
                        Case 1
                            sheet1.SetColumnWidth(0, 20 * 256)
                            sheet1.SetColumnWidth(1, 20 * 256)
                            sheet1.SetColumnWidth(2, 20 * 256)
                            sheet1.SetColumnWidth(3, 50 * 256)
                            sheet1.SetColumnWidth(4, 20 * 256)
                            Dim row_0, row_1 As HSSFRow
                            Dim cell_0, cell_1, cell_2, cell_3, cell_4, cell_5 As HSSFCell
                            row_0 = sheet1.CreateRow(0)
                            cell_0 = row_0.CreateCell(0)
                            cell_0.SetCellValue("路口車速紀錄")
                            cell_0 = row_0.CreateCell(1)
                            cell_0.SetCellValue("時間:" + StartDay + " - " + EndDay)

                            row_1 = sheet1.CreateRow(1)
                            cell_1 = row_1.CreateCell(0)
                            cell_1.SetCellValue("BUSID")
                            cell_2 = row_1.CreateCell(1)
                            cell_2.SetCellValue("方向")
                            cell_3 = row_1.CreateCell(2)
                            cell_3.SetCellValue("時速")
                            cell_4 = row_1.CreateCell(3)
                            cell_4.SetCellValue("GPS座標")
                            cell_5 = row_1.CreateCell(4)
                            cell_5.SetCellValue("時間")

                            For i = 0 To _mainForm.DGrid_History.RowCount - 1
                                Dim row As HSSFRow
                                Dim cell As HSSFCell
                                row = sheet1.CreateRow(2 + i)
                                cell = row.CreateCell(0)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(0).Value.ToString())
                                cell = row.CreateCell(1)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(1).Value.ToString())

                                cell = row.CreateCell(2)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(2).Value.ToString())
                                cell = row.CreateCell(3)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(3).Value.ToString())
                                cell = row.CreateCell(4)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(4).Value.ToString())

                            Next i
                            'jason 20150413 報表匯出功能擴增
                            'S---------------------------------------------------------------------------------
                        Case 2 '更新軟體紀錄匯出
                            sheet1.SetColumnWidth(0, 20 * 256)
                            sheet1.SetColumnWidth(1, 20 * 256)
                            sheet1.SetColumnWidth(2, 20 * 256)
                            sheet1.SetColumnWidth(3, 50 * 256)
                            sheet1.SetColumnWidth(4, 20 * 256)
                            Dim row_0, row_1 As HSSFRow
                            Dim cell_0, cell_1, cell_2, cell_3, cell_4, cell_5, cell_6 As HSSFCell
                            row_0 = sheet1.CreateRow(0)
                            cell_0 = row_0.CreateCell(0)
                            cell_0.SetCellValue("軟體更新紀錄")
                            cell_0 = row_0.CreateCell(1)
                            cell_0.SetCellValue("時間:" + StartDay + " - " + EndDay)

                            row_1 = sheet1.CreateRow(1)
                            cell_1 = row_1.CreateCell(0)
                            cell_1.SetCellValue("群組編號")
                            cell_2 = row_1.CreateCell(1)
                            cell_2.SetCellValue("群組名稱")
                            cell_3 = row_1.CreateCell(2)
                            cell_3.SetCellValue("路口編號")
                            cell_4 = row_1.CreateCell(3)
                            cell_4.SetCellValue("路口名稱")
                            cell_5 = row_1.CreateCell(4)
                            cell_5.SetCellValue("更新時間")
                            cell_6 = row_1.CreateCell(5)
                            cell_6.SetCellValue("說明")
                            For i = 0 To _mainForm.DGrid_History.RowCount - 1
                                Dim row As HSSFRow
                                Dim cell As HSSFCell
                                row = sheet1.CreateRow(2 + i)
                                cell = row.CreateCell(0)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(0).Value.ToString())
                                cell = row.CreateCell(1)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(1).Value.ToString())
                                cell = row.CreateCell(2)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(2).Value.ToString())
                                cell = row.CreateCell(3)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(3).Value.ToString())
                                cell = row.CreateCell(4)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(4).Value.ToString())
                                cell = row.CreateCell(5)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(5).Value.ToString())
                            Next i
                        Case 4 '更新組態紀錄匯出
                            sheet1.SetColumnWidth(0, 20 * 256)
                            sheet1.SetColumnWidth(1, 20 * 256)
                            sheet1.SetColumnWidth(2, 20 * 256)
                            sheet1.SetColumnWidth(3, 50 * 256)
                            sheet1.SetColumnWidth(4, 20 * 256)
                            Dim row_0, row_1 As HSSFRow
                            Dim cell_0, cell_1, cell_2, cell_3, cell_4, cell_5, cell_6 As HSSFCell
                            row_0 = sheet1.CreateRow(0)
                            cell_0 = row_0.CreateCell(0)
                            cell_0.SetCellValue("軟體更新紀錄")
                            cell_0 = row_0.CreateCell(1)
                            cell_0.SetCellValue("時間:" + StartDay + " - " + EndDay)

                            row_1 = sheet1.CreateRow(1)
                            cell_1 = row_1.CreateCell(0)
                            cell_1.SetCellValue("群組編號")
                            cell_2 = row_1.CreateCell(1)
                            cell_2.SetCellValue("群組名稱")
                            cell_3 = row_1.CreateCell(2)
                            cell_3.SetCellValue("路口編號")
                            cell_4 = row_1.CreateCell(3)
                            cell_4.SetCellValue("路口名稱")
                            cell_5 = row_1.CreateCell(4)
                            cell_5.SetCellValue("更新時間")
                            cell_6 = row_1.CreateCell(5)
                            cell_6.SetCellValue("說明")
                            For i = 0 To _mainForm.DGrid_History.RowCount - 1
                                Dim row As HSSFRow
                                Dim cell As HSSFCell
                                row = sheet1.CreateRow(2 + i)
                                cell = row.CreateCell(0)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(0).Value.ToString())
                                cell = row.CreateCell(1)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(1).Value.ToString())
                                cell = row.CreateCell(2)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(2).Value.ToString())
                                cell = row.CreateCell(3)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(3).Value.ToString())
                                cell = row.CreateCell(4)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(4).Value.ToString())
                                cell = row.CreateCell(5)
                                cell.SetCellValue(_mainForm.DGrid_History.Rows(i).Cells(5).Value.ToString())
                            Next i
                            'E---------------------------------------------------------------------------------
                    End Select


                    'Save File
                    Dim file As New FileStream(Path.Combine(Application.StartupPath, fileName), FileMode.Create)
                    workbook.Write(file)
                    file.Close()
                    MessageBox.Show("存檔完成!", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        Catch ex As Exception
            WriteLog(curPath, "Moudule_DBAccess", "SaveXLS Catchh(NPOI):" + ex.Message, _logEnable)
            MessageBox.Show("存檔失敗!", "請確認", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Module
