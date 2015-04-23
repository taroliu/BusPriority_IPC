Imports System.IO
Imports System.Text
Imports System.Threading

Module Module_File
    Dim MaxLogSize As Long = 4000000

    Dim wFileThread As Thread
    Public _poolFile_thread As Semaphore
    Public Class wFile
        Public wPath As String
        Public wFileName As String
        Public wMsg As String
        Public bWriteEnable As Integer
    End Class

    Public Sub WriteLog(ByVal curPath As String, ByVal sLogEntry As String, ByVal sLogMsg As String, ByVal comlogEnable As Integer)
        Try
            If comlogEnable = False Then
                Exit Sub
            End If
            Dim wFileObj As New wFile
            wFileObj.wPath = curPath
            wFileObj.wFileName = sLogEntry
            wFileObj.wMsg = sLogMsg
            wFileObj.bWriteEnable = True
            wFileThread = New Thread(AddressOf th_WriteLog)
            wFileThread.Name = "th_WriteFile"
            wFileThread.IsBackground = True
            wFileThread.Start(wFileObj)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub th_WriteLog(ByVal wFileObj As wFile)
        Try
            Dim curPath As String = wFileObj.wPath
            Dim sLogEntry As String = wFileObj.wFileName
            Dim sLogMsg As String = wFileObj.wMsg
            Dim comlogEnable As Integer = wFileObj.bWriteEnable
            Dim sLogFile As String, iLogSize As Long
            Dim isInit As Boolean = False
            _poolFile_thread.WaitOne()
            If comlogEnable = 0 Then
                _poolFile_thread.Release()
                'Return False
            End If
            '可錄製車機資料
            'S-------------------------------------------------------------------
            If isOpenSaveBusData Then
                Dim BusDataLogFolder As String
                Dim BusDataLogFile As String
                BusDataLogFolder = curPath & "\BusDataFolder"
                If System.IO.Directory.Exists(BusDataLogFolder) = False Then
                    System.IO.Directory.CreateDirectory(BusDataLogFolder)
                End If
                BusDataLogFile = curPath & "\BusDataFolder\BusData.tmp"
                If Not File.Exists(BusDataLogFile) Then
                    File.Create(BusDataLogFile).Dispose()
                End If
                Dim pp1 As Integer = sLogMsg.IndexOf("A1")
                Dim pp2 As Integer = sLogMsg.IndexOf("A2")
                If sLogMsg.IndexOf("A1") > 0 And sLogMsg.IndexOf("A2") > 0 Then
                    Dim writeFiledata As System.IO.TextWriter = New StreamWriter(BusDataLogFile, True)
                    writeFiledata.WriteLine(Date.Now.ToString("yyyy/MM/dd HH:mm:ss ") & vbTab & sLogMsg)
                    writeFiledata.Flush()
                    writeFiledata.Dispose()
                End If
            End If
            'E-------------------------------------------------------------------
            sLogFile = curPath & "\LogFolder"
            If System.IO.Directory.Exists(sLogFile) = False Then
                System.IO.Directory.CreateDirectory(sLogFile)
            End If
            sLogFile = curPath & "\LogFolder\" & sLogEntry & ".log"
            If Not File.Exists(sLogFile) Then
                File.Create(sLogFile).Dispose()
                isInit = True
            End If
            'Get the size of the log to check if it's getting unwieldly
            iLogSize = My.Computer.FileSystem.GetFileInfo(sLogFile).Length
            If iLogSize <> 0 Then
                If iLogSize > MaxLogSize Then
                    File.Copy(sLogFile, sLogFile & "_" & Date.Now.ToString("yyyy_MM_dd_HH_mm_ss") & ".old")
                    Dim writeFile2 As System.IO.TextWriter = New StreamWriter(sLogFile, False)
                    writeFile2.WriteLine(Date.Now.ToString("yyyy/MM/dd HH:mm:ss ") & "create this file")
                    writeFile2.Flush()
                    'writeFile2.Close()
                    'writeFile2 = Nothing
                    writeFile2.Dispose()
                End If
            End If


            Dim writeFile As System.IO.TextWriter = New StreamWriter(sLogFile, True)
            If isInit Then
                writeFile.WriteLine(Date.Now.ToString("yyyy/MM/dd HH:mm:ss ") & "create this file")
            Else
                writeFile.WriteLine(Date.Now.ToString("yyyy/MM/dd HH:mm:ss ") & vbTab & sLogMsg)
            End If
            writeFile.Flush()
            'writeFile.Close()
            'writeFile = Nothing
            writeFile.Dispose()
            '_poolFile_thread.Release()
        Catch ex As Exception

        Finally
            _poolFile_thread.Release()
        End Try
    End Sub

    '------------------------------------------------------
    '--
    '--     功能:讀取 INI file
    '--     日期:2012/04/02
    '--     設計:Jason
    '--
    '------------------------------------------------------
    Public Function GetIniInfo(ByVal PathFileName As String, ByVal strSection As String, ByVal defaultVal As String) As String
        Try
            Dim strIniFile As String = PathFileName
            If Not File.Exists(strIniFile) Then
                MessageBox.Show("檔案 " & strIniFile & " 不存在。", "請注意", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
            Dim ayStr As String
            Dim array() As String = System.IO.File.ReadAllLines(strIniFile)
            For i As Int32 = 0 To array.Length - 1
                ayStr = array(i)
                If InStr(ayStr, "=") > 0 Then
                    If Trim(ayStr.Substring(0, InStr(ayStr, "=") - 1)) = strSection Then
                        Return Trim(ayStr.Substring(InStr(ayStr, "="), ayStr.Length - InStr(ayStr, "=")))
                    End If
                End If
            Next i



            Dim array_W(array.Length + 1) As String
            System.Array.Copy(array, array_W, array.Length)
            array_W(array.Length) = "[NEW" + "_" + Now.ToString("yyyy/MM/dd HH:mm:ss") + "]"
            array_W(array.Length + 1) = strSection + "=" + defaultVal
            Dim objWriter As New System.IO.StreamWriter(strIniFile, False)
            For i As Int32 = 0 To array_W.Length - 1
                objWriter.WriteLine(array_W(i))
            Next i
            objWriter.Close()
            Return defaultVal
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_File", "GetIniInfo Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return defaultVal
        End Try
    End Function
    Public Sub WriteINIValue(ByVal sSection As String, ByVal sVariableName As String, ByVal sValue As String)
        Try
            Dim strIniFile As String = curPath + "\BusPriority_IPC.ini"
            If Not File.Exists(strIniFile) Then
                MessageBox.Show("檔案 " & strIniFile & " 不存在。", "請注意", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                'Return False
            End If

            Dim ayStr As String
            Dim array() As String = System.IO.File.ReadAllLines(strIniFile)
            Dim objWriter As New System.IO.StreamWriter(strIniFile, False)
            For i As Int32 = 0 To array.Length - 1
                ayStr = array(i)
                If InStr(ayStr, "=") > 0 Then
                    If Trim(ayStr.Substring(0, InStr(ayStr, "=") - 1)) = sVariableName Then
                        array(i) = sVariableName + "=" + sValue
                    End If
                End If
                objWriter.WriteLine(array(i))
            Next i
            objWriter.Close()
            'Return True

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_File", sVariableName + "/" + sValue + "  WriteINIValue Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            'Return False
        End Try
    End Sub
    '可錄製車機資料
    'S---------------------------------------------------------------------------
    Public Sub SaveAsBusDataFile(ByVal sValue As String)
        Try
            Dim BusDataLogFile As String
            BusDataLogFile = curPath & "\BusDataFolder\BusData.tmp"
            If File.Exists(BusDataLogFile) Then
                
                If System.IO.File.Exists(sValue) = True Then
                    System.IO.File.Delete(sValue)
                End If
                My.Computer.FileSystem.RenameFile(BusDataLogFile, Path.GetFileName(sValue))
                If System.IO.File.Exists(BusDataLogFile) = True Then
                    System.IO.File.Delete(BusDataLogFile)
                End If
            Else
                MessageBox.Show("無任何車機訊息。", "請注意", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If


        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_File", "SaveAsBusDataFile Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)

        End Try
    End Sub
    'E---------------------------------------------------------------------------
End Module


