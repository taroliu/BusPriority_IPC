Module Module_TransTool
    ' 將字串轉成byte陣列
    Function StrToByteArray(ByVal str As String) As Byte()
        Try
            Dim encoding As New System.Text.ASCIIEncoding()
            Return encoding.GetBytes(str)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_TransTool", "StrToByteArray Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function
    ' 將字串轉成byte陣列
    Function StrToByteArray2(ByVal str As String) As Byte()
        Dim encoding As New System.Text.ASCIIEncoding()
        Try
            str = str.ToUpper
            Dim ary((str.Length \ 2) - 1) As Byte
            For i As Integer = 0 To (str.Length \ 2) - 1
                Dim myBytes() As Byte = encoding.GetBytes(str.Substring(i * 2, 2))
                ary(i) = IIf(myBytes(0) < &H40, ((myBytes(0) - &H30) << 4), ((myBytes(0) - &H37) << 4)) + IIf(myBytes(1) < &H40, (myBytes(1) - &H30), (myBytes(1) - &H37))
            Next i
            Return ary
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_TransTool", "StrToByteArray2 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function
    ' 將整數轉BYTE字串
    Function IntToHexString(ByVal val As Integer, ByVal ipos As Integer) As String
        Try
            'Dim byArray() As Byte
            Dim byString As String = ""
            Dim encoding As New System.Text.ASCIIEncoding()
            Dim val1, val2 As Integer
            val1 = val
            For i As Integer = 0 To ipos - 1
                val2 = val1 \ Math.Pow(16, ipos - i - 1)

                byString = byString + Trim(IIf(val2 > 9, Chr(&H41 + val2 - 10), Str(val2)))
                'String.Format("{FFFF}", byString)
                val1 = val1 Mod Math.Pow(16, ipos - i - 1)
                'byString = byString + encoding.GetString(BitConverter.GetBytes(val / 16))
                'Array(7 + i / 2) = IIf(myBytes(i) < &H40, ((myBytes(i) - &H30) << 4), ((myBytes(i) - &H37) << 4)) + IIf(myBytes(i + 1) < &H40, (myBytes(i + 1) - &H30), (myBytes(i + 1) - &H37))
            Next i
            Return byString
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_TransTool", "StrToByteString Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function

    Function HexStringTOIntString(ByVal tstr As String, ByVal len As Integer) As String
        Try
            Dim newary() As Byte = StrToByteArray(tstr)
            'Dim byString As String
            Dim byInteger As Integer
            For i As Integer = 0 To len - 1
                If (newary(i) < &H40) Then
                    byInteger = byInteger + (newary(i) - &H30) * Math.Pow(16, len - i - 1)
                Else
                    byInteger = byInteger + (newary(i) - &H37) * Math.Pow(16, len - i - 1)
                End If
            Next i
            Return Str(byInteger)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_TransTool", "HexStringTOIntString Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function


    ' 將byte陣列轉成字串
    Function ByteArrayToStr(ByVal bt As Byte()) As String
        Try
            Dim encoding As New System.Text.ASCIIEncoding()
            Return encoding.GetString(bt)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_TransTool", "ByteArrayToStr Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function

    ' 將byte陣列轉成字串位元,再轉成字串
    Function ByteArrayToStr2(ByVal bt As Byte()) As String
        Try
            Dim array_full(bt.Length * 2 - 1) As Byte
            'Dim encoding As New System.Text.ASCIIEncoding()
            For i As Integer = 0 To bt.Length - 1
                array_full(2 * i) = IIf(((bt(i) And &HF0) >> 4) > &H9, ((bt(i) And &HF0) >> 4) + &H37, ((bt(i) And &HF0) >> 4) + &H30)
                array_full(2 * i + 1) = IIf((bt(i) And &HF) > &H9, (bt(i) And &HF) + &H37, (bt(i) And &HF) + &H30)
            Next i
            Return ByteArrayToStr(array_full)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_TransTool", "ByteArrayToStr2 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function
    '****************************************************************************************************
    'Integer to Byte()
    'Dim vOut As Byte() = BitConverter.GetBytes(vIn)
    '****************************************************************************************************
    'Byte() to Integer
    'BitConverter.ToInt32(vIn, 0)
    '****************************************************************************************************
    'Byte to Integer
    'Convert.ToInt32(vIn)
    '****************************************************************************************************
    'Byte()  Default
    'Dim vIn() As Byte = New Byte(){ 1, 1, 0 }
    '****************************************************************************************************
    '小三角形,小圓形
    'Chr(&HA1B6),Chr(&HA140)
    '****************************************************************************************************
    'ASC Hex
    '****************************************************************************************************
    'Byte to Binnary
    'Convert.ToString(bytedata(i), 2).PadLeft(8, "0")
    '****************************************************************************************************
    'Byte() to OtherType
    'Dim vIn() As Byte = New Byte() {"F", "O", "O"}
    'Dim vOut As String = System.Text.Encoding.UTF8.GetString(vIn)
    'System.Text.Encoding.ASCII;
    'System.Text.Encoding.BigEndianUnicode;
    'System.Text.Encoding.Unicode;
    'System.Text.Encoding.UTF32;
    'System.Text.Encoding.UTF7;
    'System.Text.Encoding.UTF8;
    '****************************************************************************************************
    'Integer to Byte
    'CByte(Integer)
    '****************************************************************************************************
    '****************************************************************************************************
    '****************************************************************************************************
    '****************************************************************************************************
    '****************************************************************************************************
    '****************************************************************************************************
End Module
