﻿Imports System.Threading

Module Module_PacketageOption
    '車機封包串接問題處理 Jason 20150817
    'S--------------------------------------------------------------------------------------------
    Public _poolCarPackOption As Semaphore
    Public AcceptPoolFromCar As String = ""
    Public Sub AcceptCarOption(ByVal CarData As String)
        Try
            _poolCarPackOption.WaitOne()
            AcceptPoolFromCar = AcceptPoolFromCar + CarData
            '先把格式轉成台南格式再處理
            Dim Ary_data As String() = AcceptPoolFromCar.Split(",")
            For i As Integer = 1 To Ary_data.Length - 1
                Dim tmpIndex As Integer = -1
                If Ary_data(i).IndexOf("A1") <> -1 Then
                    tmpIndex = Ary_data(i).IndexOf("A1")
                ElseIf Ary_data(i).IndexOf("A2") <> -1 Then
                    tmpIndex = Ary_data(i).IndexOf("A2")
                End If
                If tmpIndex <> -1 Then
                    Ary_data(i) = Ary_data(i).Substring(0, tmpIndex) + "/r/n" + Ary_data(i).Substring(tmpIndex, Ary_data(i).Length - tmpIndex)
                End If
            Next i
            Dim newString As String = ""
            For i As Integer = 0 To Ary_data.Length - 1
                newString = newString + "," + Trim(Ary_data(i))
            Next i
            AcceptPoolFromCar = newString.Substring(1, newString.Length - 1)
            _poolCarPackOption.Release()
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_PacketageOption", "AcceptCarString Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)

        End Try
    End Sub

    Public Function getComplishPacketFromCar() As String
        Dim BackString As String = ""
        Try


            Dim start_A1_index As Integer = IIf(AcceptPoolFromCar.IndexOf("A1") = -1, 999, AcceptPoolFromCar.IndexOf("A1"))
            Dim start_A2_index As Integer = IIf(AcceptPoolFromCar.IndexOf("A2") = -1, 999, AcceptPoolFromCar.IndexOf("A2"))
            Dim start_index As Integer = 0
            '決定A1,A2
            Dim A_Type As String  '0-A1,1-A2
            If start_A1_index = 999 And start_A2_index = 999 Then
                Return ""
            End If
            If start_A1_index < start_A2_index Then  'A1-(A2)
                A_Type = 0
                start_index = start_A1_index
            Else  'A2-(A1)
                A_Type = 1
                start_index = start_A2_index
            End If
            '清掉A1,A2前面亂碼
            If start_index <> 0 Then
                AcceptPoolFromCar = AcceptPoolFromCar.Substring(start_index, AcceptPoolFromCar.Length - start_index)
            End If

            '是否有完滿封包
           

            Dim end_index As Integer = AcceptPoolFromCar.IndexOf("/r/n")
            If end_index >= 0 Then
                BackString = AcceptPoolFromCar.Substring(0, end_index)
                AcceptPoolFromCar = AcceptPoolFromCar.Substring(end_index + 4, AcceptPoolFromCar.Length - (end_index + 4))
                Return BackString
            Else
                '如果沒有來/r/n要把前面不完整封包去掉
                Dim tmpStringafter As String = AcceptPoolFromCar.Substring(2, AcceptPoolFromCar.Length - 2)
                Dim tmpA1_index As Integer = IIf(tmpStringafter.IndexOf("A1") = -1, 999, tmpStringafter.IndexOf("A1"))
                Dim tmpA2_index As Integer = IIf(tmpStringafter.IndexOf("A2") = -1, 999, tmpStringafter.IndexOf("A2"))
                If tmpA1_index = 999 And tmpA2_index = 999 Then
                    Return ""
                Else
                    If tmpA1_index < tmpA2_index Then
                        AcceptPoolFromCar = AcceptPoolFromCar.Substring(tmpA1_index + 2, AcceptPoolFromCar.Length - (tmpA1_index + 2))
                    Else
                        AcceptPoolFromCar = AcceptPoolFromCar.Substring(tmpA2_index + 2, AcceptPoolFromCar.Length - (tmpA2_index + 2))
                    End If
                End If

                Return ""
            End If


        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_PacketageOption", "getComplishPacketFromCar Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return "-1"
        End Try
    End Function
    'E--------------------------------------------------------------------------------------------

    '接收設備封包,皆放至ArrayPool,進行檢查,是否串接,是否分段,再產出
    'S------------------------------------------------------------------------------------------------
    Public AcceptPoolArray(1024) As Byte
    Public AcceptPoolArrayLength As Integer = 0

    Public SeqNum As Integer
    Public _poolSeqNumber As Semaphore
    Public Function getComplishPacket() As String
        Dim newToken As Integer = 0
        Try
            For i As Integer = 1 To AcceptPoolArrayLength - 2  '從第2 byte至到數第2 byte
                If AcceptPoolArray(i) = &HCC And AcceptPoolArray(i - 1) = &HAA Then
                    newToken = i
                    Exit For
                End If
            Next i
            If newToken = 0 Then
                Return ""
            Else
                Dim newArray(newToken + 1) As Byte
                Array.Copy(AcceptPoolArray, 0, newArray, 0, newToken + 2)
                Array.Clear(AcceptPoolArray, 0, newToken + 2)
                AcceptPoolArrayLength = VertifyPacketStepFirst(AcceptPoolArray, AcceptPoolArrayLength)
                Return ByteArrayToStr2(newArray)
            End If

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Packetage", "getComplishPacket Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return ""
        End Try
    End Function
    '清掉Pool內不為AABB,AADD,AAEE開頭的封包
    Private Function VertifyPacketStepFirst(ByRef cpPacket() As Byte, ByVal cpToken As Integer) As Integer
        Dim newToken As Integer = cpToken
        Try
            If cpToken = 1 Then
                If cpPacket(0) <> &HAA Then
                    cpPacket(0) = &H0
                    newToken = 0
                End If
            Else
                While newToken > 0
                    If cpPacket(0) = &HAA And (cpPacket(1) = &HBB Or cpPacket(1) = &HDD Or cpPacket(1) = &HEE) Then
                        Exit While
                    Else
                        For i As Integer = 0 To newToken - 1
                            cpPacket(i) = cpPacket(i + 1)
                        Next i
                        newToken -= 1
                    End If
                End While
            End If

            Return newToken
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Packetage", "VertifyPacketStepFirst Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return newToken
        End Try
    End Function

    Public Sub InsertAcceptPoolArray(ByVal iData() As Byte, ByVal DataLen As Integer)
        Try
            Array.Copy(iData, 0, AcceptPoolArray, AcceptPoolArrayLength, DataLen)
            AcceptPoolArrayLength += DataLen
            AcceptPoolArrayLength = VertifyPacketStepFirst(AcceptPoolArray, AcceptPoolArrayLength)
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Packetage", "InsertAcceptPoolArray Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub

    ' Packetage Reorganize
    'S------------------------------------------------------------------------------------------------
    Function Incode_Step1(ByVal seqNum As Integer, ByVal setPacket As String) As Byte() '需分辦 COMMAND OR ACK OR NAK

        Dim HighDevNumber As Byte()
        Dim LowDevNumber As Byte()
        If DB_ACCESS_ENABLE = 1 Then
            HighDevNumber = StrToByteArray2(COMMON_EquipID.Substring(0, 2)) 'COMMON_EquipID-->BusPriority_daemon
            LowDevNumber = StrToByteArray2(COMMON_EquipID.Substring(2, 2)) 'COMMON_EquipID-->BusPriority_daemon
        Else
            HighDevNumber = StrToByteArray2(DB_ACCESS_DISABLE_DEVICEID.Substring(0, 2))
            LowDevNumber = StrToByteArray2(DB_ACCESS_DISABLE_DEVICEID.Substring(2, 2))
        End If

        Try
            If Trim(setPacket) = "ACK" Then
                Dim ayACK(7) As Byte
                ayACK(0) = &HAA
                ayACK(1) = &HDD
                ayACK(2) = Convert.ToByte(seqNum)
                ayACK(3) = HighDevNumber(0)
                ayACK(4) = LowDevNumber(0)
                ayACK(5) = &H0
                ayACK(6) = &H8
                ayACK = InCRC(ayACK, 7)
                'WriteLog(curPath, "comm", "[Send] " + ByteArrayToStr2(ayACK), _logEnable)
                Return ayACK
            End If
            If Global.Microsoft.VisualBasic.Left(setPacket, 3) = "NAK" Then
                Dim ayNAK(8) As Byte
                ayNAK(0) = &HAA
                ayNAK(1) = &HEE
                ayNAK(2) = Convert.ToByte(seqNum)
                ayNAK(3) = HighDevNumber(0)
                ayNAK(4) = LowDevNumber(0)
                ayNAK(5) = &H0
                ayNAK(6) = &H9
                Dim tmp As String
                tmp = setPacket.Substring(3, 1)
                ayNAK(7) = Convert.ToByte(Val(tmp))
                ayNAK = InCRC(ayNAK, 8)
                'WriteLog(curPath, "comm", "[Send] " + ByteArrayToStr2(ayNAK), _logEnable)
                Return ayNAK
            End If
            '-----Commond 
            Dim myBytes As Byte() = StrToByteArray(setPacket)
            Dim array((10 + setPacket.Length / 2) - 1) As Byte

            '----MAKE DEL :AA   (len:1)
            array(0) = &HAA
            '----MAKE STX :BB   (len:1)
            array(1) = &HBB
            '----MAKE DEL :SEQ  (len:1)
            array(2) = Convert.ToByte(seqNum)
            '----MAKE ADDR :FFFF(len:2)
            array(3) = HighDevNumber(0)
            array(4) = LowDevNumber(0)
            '----MAKE LEN :     (len:2)-->10+info
            array(5) = Convert.ToByte(array.Length \ 256)
            array(6) = Convert.ToByte(array.Length Mod 256)
            '----MAKE INFO :    (start at byte(7))
            For i As Integer = 0 To setPacket.Length - 1 Step 2
                array(7 + i / 2) = IIf(myBytes(i) < &H40, ((myBytes(i) - &H30) << 4), ((myBytes(i) - &H37) << 4)) + IIf(myBytes(i + 1) < &H40, (myBytes(i + 1) - &H30), (myBytes(i + 1) - &H37))
            Next i
            '----MAKE DEL :AA
            array(6 + (setPacket.Length / 2) + 1) = &HAA
            '----MAKE ETX :CC
            array(6 + (setPacket.Length / 2) + 2) = &HCC
            '----MAKE CKS :
            array = InCRC(array, array.Length - 1)
            'WriteLog(curPath, "comm", "[Send] " + ByteArrayToStr2(array), _logEnable)
            Return array
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Packetage", "[Send] " + "  Incode_Step1 Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function
    Function InCRC(ByVal data() As Byte, ByVal pos As Integer) As Byte()
        Try
            Dim localdata() As Byte = data
            Dim cc As Byte = &H0
            For i As Integer = 0 To pos
                If i = pos Then
                    localdata(i) = cc
                    Exit For
                End If
                cc = cc Xor localdata(i)
            Next i
            Return localdata
        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Packetage", "InCRC Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
            Return Nothing
        End Try
    End Function

    Public Function getSeqNum() As Integer
        Try
            _poolSeqNumber.WaitOne()
            SeqNum = (SeqNum + 1) Mod 255
            _poolSeqNumber.Release()
            Return SeqNum

        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Packetage", "  getSeqNum Catch:" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)

            Return False
        End Try
    End Function

    Public Function MarkAACommand(ByVal sendCom As String) As String
        Try
            If sendCom = "" Then
                Return ""
            End If
            sendCom = sendCom.Replace("AA", "AAAA")
            Return sendCom

        Catch ex As Exception
            WriteLog(curPath, "Module_Command", "  MarkCommand Catch:" + sendCom + "\" + ex.Message, True)
            Return Nothing
        End Try
    End Function
    'jason 20150413 設備異常回報加IPC設備連線異常
    'S-------------------------------------------------------------------------------
    Public Sub SetHardWareStatusToIPC_ERROR()
        Try
            Dim _ConnectFlag_IC As Boolean
            Dim newHardWareStatus As String
            If _mainForm.Lab_ComStatus_IC.BackColor = Color.Red Then
                _ConnectFlag_IC = False
            Else
                _ConnectFlag_IC = True
            End If

            If _ConnectFlag_CC Or _ConnectFlag_ATMS Or _ConnectFlag_IC Then 'Jason201511_1 0F04 Report Status
                newHardWareStatus = SetIPC_ConnectError(True)
            Else
                newHardWareStatus = SetIPC_ConnectError(False)
            End If
            Dim sendByte As Byte() = Incode_Step1(getSeqNum(), MarkAACommand("0F04" + newHardWareStatus))
            Socket_WriteToCC(sendByte)
        Catch ex As Exception
            WriteLog(curPath, "Module_Command", "  SetHardWareStatusToIPC_ERROR Catch:" + ex.Message, True)
        End Try
    End Sub
    Public Function SetIPC_ConnectError(ByVal setValue As Boolean) As String
        Dim FinialString As String = HardWareStatusFrom0F04
        Try
            Dim tmpByte1 As Byte() = StrToByteArray2(FinialString)
            If setValue Then
                tmpByte1(1) = tmpByte1(1) Or &H4
            Else
                tmpByte1(1) = tmpByte1(1) And &HFFFB
            End If
            FinialString = ByteArrayToStr2(tmpByte1)
            Return FinialString
        Catch ex As Exception
            WriteLog(curPath, "Module_Command", "  SetIPC_ConnectError Catch:" + ex.Message, True)
            Return FinialString
        End Try

    End Function
    'E-------------------------------------------------------------------------------
End Module
