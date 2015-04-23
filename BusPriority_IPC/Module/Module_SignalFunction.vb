Module Module_SignalFunction
    Public Sub ShowReceiveLightStatusSoftWare(ByVal ReceiveDisplayIntArray As Integer())

        Try
            ShowReceiveLightStatus2textBoxSoftWare(-1, "")
            For i As Integer = 0 To 47
                Dim sLight As String = ""
                Dim isflash As Boolean = False
                Select Case i Mod 8
                    Case 0
                        If ReceiveDisplayIntArray(i) = 1 And ReceiveDisplayIntArray(i + 1) = 1 Then
                            isflash = True
                            sLight = "行閃|"
                        Else
                            sLight = "行紅|"
                        End If
                    Case 1
                        sLight = "行綠|"
                        If ReceiveDisplayIntArray(i) = 1 And ReceiveDisplayIntArray(i - 1) = 1 Then
                            Continue For
                        End If
                    Case 2
                        sLight = "右|"
                    Case 3
                        sLight = "直|"
                    Case 4
                        sLight = "左|"
                    Case 5
                        sLight = "綠|"
                    Case 6
                        sLight = "黃|"
                    Case 7
                        sLight = "紅|"
                End Select
                If isflash Then
                    ShowReceiveLightStatus2textBoxSoftWare(i \ 8, "行閃|")
                Else
                    If ReceiveDisplayIntArray(i) = 1 Then
                        ShowReceiveLightStatus2textBoxSoftWare(i \ 8, sLight)
                    End If
                End If
            Next i
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SignalFunction", "ShowReceiveLightStatusSoftWare Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)

        End Try

    End Sub
    Public Sub ShowReceiveLightStatus2textBoxSoftWare(ByVal i As Integer, ByVal showtext As String)
        Try
            If i = -1 Then
                BusPriority_IPC.MainForm.TBox_LightRec_0.Text = ""
                BusPriority_IPC.MainForm.TBox_LightRec_1.Text = ""
                BusPriority_IPC.MainForm.TBox_LightRec_2.Text = ""
                BusPriority_IPC.MainForm.TBox_LightRec_3.Text = ""
                BusPriority_IPC.MainForm.TBox_LightRec_4.Text = ""
                BusPriority_IPC.MainForm.TBox_LightRec_5.Text = ""
            Else
                Select Case i
                    Case 0
                        BusPriority_IPC.MainForm.TBox_LightRec_0.Text += showtext
                        Dim lastShowText As String = BusPriority_IPC.MainForm.TBox_LightRec_0.Text
                        If lastShowText.Contains("左") = True Or lastShowText.Contains("直") = True Or lastShowText.Contains("右") = True Or lastShowText.Contains("綠") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_0.ForeColor = Color.Green
                        ElseIf lastShowText.Contains("黃") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_0.ForeColor = Color.Yellow
                        Else
                            BusPriority_IPC.MainForm.TBox_LightRec_0.ForeColor = Color.Red
                        End If
                        'TBox_LightRec_0.ForeColor = IIf(colorTag = 1, Color.Fuchsia, Color.OrangeRed)
                    Case 1
                        BusPriority_IPC.MainForm.TBox_LightRec_1.Text += showtext
                        Dim lastShowText As String = BusPriority_IPC.MainForm.TBox_LightRec_1.Text
                        If lastShowText.Contains("左") = True Or lastShowText.Contains("直") = True Or lastShowText.Contains("右") = True Or lastShowText.Contains("綠") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_1.ForeColor = Color.Green
                        ElseIf lastShowText.Contains("黃") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_1.ForeColor = Color.Yellow
                        Else
                            BusPriority_IPC.MainForm.TBox_LightRec_1.ForeColor = Color.Red
                        End If
                    Case 2
                        BusPriority_IPC.MainForm.TBox_LightRec_2.Text += showtext
                        Dim lastShowText As String = BusPriority_IPC.MainForm.TBox_LightRec_2.Text
                        If lastShowText.Contains("左") = True Or lastShowText.Contains("直") = True Or lastShowText.Contains("右") = True Or lastShowText.Contains("綠") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_2.ForeColor = Color.Green
                        ElseIf lastShowText.Contains("黃") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_2.ForeColor = Color.Yellow
                        Else
                            BusPriority_IPC.MainForm.TBox_LightRec_2.ForeColor = Color.Red
                        End If
                    Case 3
                        BusPriority_IPC.MainForm.TBox_LightRec_3.Text += showtext
                        Dim lastShowText As String = BusPriority_IPC.MainForm.TBox_LightRec_3.Text
                        If lastShowText.Contains("左") = True Or lastShowText.Contains("直") = True Or lastShowText.Contains("右") = True Or lastShowText.Contains("綠") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_3.ForeColor = Color.Green
                        ElseIf lastShowText.Contains("黃") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_3.ForeColor = Color.Yellow
                        Else
                            BusPriority_IPC.MainForm.TBox_LightRec_3.ForeColor = Color.Red
                        End If
                    Case 4
                        BusPriority_IPC.MainForm.TBox_LightRec_4.Text += showtext
                        Dim lastShowText As String = BusPriority_IPC.MainForm.TBox_LightRec_4.Text
                        If lastShowText.Contains("左") = True Or lastShowText.Contains("直") = True Or lastShowText.Contains("右") = True Or lastShowText.Contains("綠") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_4.ForeColor = Color.Green
                        ElseIf lastShowText.Contains("黃") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_4.ForeColor = Color.Yellow
                        Else
                            BusPriority_IPC.MainForm.TBox_LightRec_4.ForeColor = Color.Red
                        End If
                    Case 5
                        BusPriority_IPC.MainForm.TBox_LightRec_5.Text += showtext
                        Dim lastShowText As String = BusPriority_IPC.MainForm.TBox_LightRec_5.Text
                        If lastShowText.Contains("左") = True Or lastShowText.Contains("直") = True Or lastShowText.Contains("右") = True Or lastShowText.Contains("綠") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_5.ForeColor = Color.Green
                        ElseIf lastShowText.Contains("黃") = True Then
                            BusPriority_IPC.MainForm.TBox_LightRec_5.ForeColor = Color.Yellow
                        Else
                            BusPriority_IPC.MainForm.TBox_LightRec_5.ForeColor = Color.Red
                        End If
                End Select
                '其它參數.

                Dim sDir As Byte() = StrToByteArray2(NowSingalMap)
                Dim DirByte As Byte = sDir(0)
                Dim ShifByte As Byte = &H1
                Dim TextDirect As String = ""
                BusPriority_IPC.MainForm.TBox_Dir.Text = ""
                For j As Integer = 0 To 7
                    If DirByte And ShifByte Then
                        Select Case ShifByte
                            Case &H1
                                TextDirect = "北|"
                            Case &H2
                                TextDirect = "東北|"
                            Case &H4
                                TextDirect = "東|"
                            Case &H8
                                TextDirect = "東南|"
                            Case &H10
                                TextDirect = "南|"
                            Case &H20
                                TextDirect = "西南|"
                            Case &H40
                                TextDirect = "西|"
                            Case &H80
                                TextDirect = "西北"
                        End Select
                        BusPriority_IPC.MainForm.TBox_Dir.Text = BusPriority_IPC.MainForm.TBox_Dir.Text + TextDirect
                    End If
                    ShifByte = ShifByte << 1
                Next j
                BusPriority_IPC.MainForm.TBox_SubPhaseOrder.Text = HexStringTOIntString(NowSubPhaseIDstring, 2)
                BusPriority_IPC.MainForm.TBox_StepOrder.Text = HexStringTOIntString(NowStepIDstring, 2)
                BusPriority_IPC.MainForm.TBox_StepSec.Text = HexStringTOIntString(NowStepSec, 4)
            End If
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SignalFunction", "ShowReceiveLightStatus2textBoxSoftWare Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)

        End Try
    End Sub
    Public Function getLightOut_LightStepBySoftWare(ByVal lightString As String) As Integer()
        Try
            Dim tmpbyte() As Byte = StrToByteArray2(lightString)

            Dim tmpString As String = ""
            For i As Integer = 0 To tmpbyte.Length - 1
                tmpString += Convert.ToString(tmpbyte(i), 2).PadLeft(8, "0")
            Next i
            Dim tmpary(47) As Integer
            For i As Integer = 0 To tmpString.Length - 1
                Dim spiltstr As String = tmpString.Substring(i, 1)
                tmpary(i) = Val(spiltstr)
            Next i
            Return tmpary

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_SignalFunction", "getLightOut_LightStep Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function
End Module
