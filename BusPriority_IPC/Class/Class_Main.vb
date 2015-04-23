Public Class BusPriority_daemon
    Private _5F10 As New Hashtable   '目前控制策略管理             --->5F40
    Private _5F13 As New Hashtable   '時相資料庫管理               --->5F43    
    Private _5F03 As New Hashtable   '時相資料庫主動回報<主>       
    Private _5F14 As New Hashtable   '時相計畫基本參數管理         --->5F44
    Private _5F15 As New Hashtable   '時制計畫資料庫管理           --->5F45
    Private _5F16 As New Hashtable   '一般日時段型態管理           --->5F46
    Private _5F76 As New Hashtable   '優先號誌時段                 --->5F76下,5F86查,5F96回
    'Private _5F1C As New Hashtable  '時相步階變換控制管理         --->5F4C
    Private _5F0C As New Hashtable   '時相步階變換控制主動回報<主>

    '選擇功能
    Private _5F19() As String   '觸動控制組態管理             --->5F49
    Private _5F09() As String   '觸動控制主動回報<主>

    Public Function Set_5F10(ByVal Data_5F10 As Class_5F10) As Boolean
        Try
            _5F10.Clear()
            _5F10.Add("5F10", Data_5F10)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Get_5FC0() As Class_5F10
        Return _5F10.Item("5F10")
    End Function
    Public Function Set_5F13(ByVal PhaseOrder As Byte, ByVal Data_5F13 As Class_5F13) As Boolean
        Try
            _5F13.Remove(PhaseOrder)
            _5F13.Add(PhaseOrder, Data_5F13)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Get_5FC3(ByVal PhaseOrder As Byte) As Class_5F13
        Return _5F13.Item(PhaseOrder)
    End Function

    Public Function Set_5F14(ByVal PlanID As Byte, ByVal Data_5F14 As Class_5F14) As Boolean
        Try
            _5F14.Remove(PlanID)
            _5F14.Add(PlanID, Data_5F14)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Get_5FC4(ByVal PlanID As Byte) As Class_5F14
        Return _5F14.Item(PlanID)
    End Function
    Public Function Set_5F15(ByVal PlanID As Byte, ByVal Data_5F15 As Class_5F15) As Boolean
        Try
            _5F15.Remove(PlanID)
            _5F15.Add(PlanID, Data_5F15)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    'Public Function Set_5F16() As Boolean
    '    Try
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function Set_5F76() As Boolean
    '    Try
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    Public Function Set_5F03(ByVal Data_5F03 As Class_5F03) As Boolean
        Try
            _5F03.Clear()
            _5F03.Add("5F03", Data_5F03)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Get_5F03() As Class_5F03
        Return _5F03.Item("5F03")
    End Function
    Public Function Set_5F1C() As Boolean
        Try
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Function Set_5F0C() As Boolean
        Try
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function Set_5F19() As Boolean
        Try
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Function Set_5F09() As Boolean
        Try
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class


