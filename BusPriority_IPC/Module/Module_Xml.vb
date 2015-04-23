Imports System.Xml

Module Module_Xml
    Public Sub Report5F03Xml(ByVal rGroupId As String, ByVal rCrossRoadID As String, ByVal ReportData As String)
        Try
            If System.IO.Directory.Exists("c:\XmlRightNow") = False Then
                System.IO.Directory.CreateDirectory("c:\XmlRightNow")
            End If
            '-------------------------------------------------------------
            Dim rPhaseOrder As String = Trim(HexStringTOIntString(ReportData.Substring(4, 2), 2))

            Dim rSignalMap As String = ReportData.Substring(6, 2)
            Dim rSingMap_byte As Byte() = StrToByteArray2(rSignalMap)
            Dim rSingMap_binary As String = Convert.ToString(rSingMap_byte(0), 2).PadLeft(8, "0")

            Dim rSignalCount As Integer = Val(ReportData.Substring(8, 2))
            Dim rSignalCount_str As String = rSignalCount.ToString

            Dim rSubPhaseID As Integer = Val(ReportData.Substring(10, 2))
            Dim rSubPhaseID_str As String = rSubPhaseID.ToString

            Dim rStepID As String = Val(ReportData.Substring(12, 2))
            Dim rStepID_str As String = rStepID.ToString

            Dim rStepSec As String = Trim(HexStringTOIntString(ReportData.Substring(14, 4), 4))

            Dim rSignalStatus As String = ReportData.Substring(18, ReportData.Length - 18)
            '-------------------------------------------------------------
            Dim Doc As New XmlDocument()

            Dim XmlProc As XmlDeclaration
            XmlProc = Doc.CreateXmlDeclaration("1.0", "UTF-8", "")
            Doc.AppendChild(XmlProc)

            ' Create the root node.
            Dim Root As XmlElement

            Root = Doc.CreateElement("XML_Head")

            Dim RootAttr As XmlAttribute
            RootAttr = Doc.CreateAttribute("version")
            RootAttr.Value = "1.1"
            Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("listname")
            RootAttr.Value = "主動回報資訊"
            Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("interval")
            RootAttr.Value = ""
            Root.Attributes.Append(RootAttr)
            ' Create a child node.
            Dim Child As XmlElement
            Child = Doc.CreateElement("infos")
            Child.InnerText = ""
            Root.AppendChild(Child)


            ' Add an attribute to the child node.
            Dim Attr As XmlAttribute
            Dim Child2 As XmlElement

            Child2 = Doc.CreateElement("info")
            Child2.InnerText = ""
            Child.AppendChild(Child2)

            Attr = Doc.CreateAttribute("GroupId")
            Attr.Value = rGroupId
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("CrossRoadID")
            Attr.Value = rCrossRoadID
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("PhaseOrder")
            Attr.Value = rPhaseOrder
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SingMap")
            Attr.Value = rSingMap_binary
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SignalCount")
            Attr.Value = rSignalCount_str
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SubPhaseID")
            Attr.Value = rSubPhaseID_str
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("StepID")
            Attr.Value = rStepID_str
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("StepSec")
            Attr.Value = rStepSec
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SignalStatus")
            Attr.Value = rSignalStatus
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("UpdateTime")
            Attr.Value = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            Child2.Attributes.Append(Attr)

            Doc.AppendChild(Root)

            ' Write the document to disk.
            Dim Output As New XmlTextWriter("c:\XmlRightNow\5F03_info.xml", System.Text.Encoding.UTF8)
            Doc.WriteTo(Output)
            Output.Close()



        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Xml", "Report5F03Xml Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub Report5F43Xml(ByVal rGroupId As String, ByVal rCrossRoadID As String, ByVal ReportData As String)
        Try
            If System.IO.Directory.Exists("c:\XmlRightNow") = False Then
                System.IO.Directory.CreateDirectory("c:\XmlRightNow")
            End If
            '-------------------------------------------------------------
            Dim rPhaseOrder As String = Trim(HexStringTOIntString(ReportData.Substring(4, 2), 2))

            Dim rSignalMap As String = ReportData.Substring(6, 2)
            Dim rSingMap_byte As Byte() = StrToByteArray2(rSignalMap)
            Dim rSingMap_binary As String = Convert.ToString(rSingMap_byte(0), 2).PadLeft(8, "0")

            Dim rSignalCount As Integer = Val(ReportData.Substring(8, 2))
            Dim rSignalCount_str As String = rSignalCount.ToString

            Dim rSubPhaseCount As Integer = Val(ReportData.Substring(10, 2))
            Dim rSubPhaseCount_str As String = rSubPhaseCount.ToString

            Dim rSignalStatus As String = ReportData.Substring(12, ReportData.Length - 12)
            '-------------------------------------------------------------
            Dim Doc As New XmlDocument()

            Dim XmlProc As XmlDeclaration
            XmlProc = Doc.CreateXmlDeclaration("1.0", "UTF-8", "")
            Doc.AppendChild(XmlProc)

            ' Create the root node.
            Dim Root As XmlElement

            Root = Doc.CreateElement("XML_Head")

            Dim RootAttr As XmlAttribute
            RootAttr = Doc.CreateAttribute("version")
            RootAttr.Value = "1.1"
            Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("listname")
            RootAttr.Value = "查詢5F43回報資訊"
            Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("interval")
            RootAttr.Value = ""
            Root.Attributes.Append(RootAttr)
            ' Create a child node.
            Dim Child As XmlElement
            Child = Doc.CreateElement("infos")
            Child.InnerText = ""
            Root.AppendChild(Child)


            ' Add an attribute to the child node.
            Dim Attr As XmlAttribute
            Dim Child2 As XmlElement

            Child2 = Doc.CreateElement("info")
            Child2.InnerText = ""
            Child.AppendChild(Child2)

            Attr = Doc.CreateAttribute("GroupId")
            Attr.Value = rGroupId
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("CrossRoadID")
            Attr.Value = rCrossRoadID
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("PhaseOrder")
            Attr.Value = rPhaseOrder
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SingMap")
            Attr.Value = rSingMap_binary
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SignalCount")
            Attr.Value = rSignalCount_str
            Child2.Attributes.Append(Attr)



            Attr = Doc.CreateAttribute("SubPhaseCount")
            Attr.Value = rSubPhaseCount_str
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SignalStatus")
            Attr.Value = rSignalStatus
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("UpdateTime")
            Attr.Value = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            Child2.Attributes.Append(Attr)

            Doc.AppendChild(Root)

            ' Write the document to disk.
            Dim Output As New XmlTextWriter("c:\XmlRightNow\5F43_info.xml", System.Text.Encoding.UTF8)
            Doc.WriteTo(Output)
            Output.Close()



        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Xml", "Report5F43Xml Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub Report5F44Xml(ByVal rGroupId As String, ByVal rCrossRoadID As String, ByVal ReportData As String)
        Try
            If System.IO.Directory.Exists("c:\XmlRightNow") = False Then
                System.IO.Directory.CreateDirectory("c:\XmlRightNow")
            End If
            '-------------------------------------------------------------
            Dim rPlanID As String = Trim(HexStringTOIntString(ReportData.Substring(4, 2), 2))

            Dim rSubPhaseCount As Integer = Val(ReportData.Substring(6, 2))
            Dim rSubPhaseCount_str As String = rSubPhaseCount.ToString

            Dim rLightSecond As String = ReportData.Substring(8, ReportData.Length - 8)
            '-------------------------------------------------------------
            Dim Doc As New XmlDocument()

            Dim XmlProc As XmlDeclaration
            XmlProc = Doc.CreateXmlDeclaration("1.0", "UTF-8", "")
            Doc.AppendChild(XmlProc)

            ' Create the root node.
            Dim Root As XmlElement

            Root = Doc.CreateElement("XML_Head")

            Dim RootAttr As XmlAttribute
            RootAttr = Doc.CreateAttribute("version")
            RootAttr.Value = "1.1"
            Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("listname")
            RootAttr.Value = "查詢5F44回報資訊"
            Root.Attributes.Append(RootAttr)

            'RootAttr = Doc.CreateAttribute("updatetime")
            'RootAttr.Value = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            'Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("interval")
            RootAttr.Value = ""
            Root.Attributes.Append(RootAttr)
            ' Create a child node.
            Dim Child As XmlElement
            Child = Doc.CreateElement("infos")
            Child.InnerText = ""
            Root.AppendChild(Child)


            ' Add an attribute to the child node.
            Dim Attr As XmlAttribute
            Dim Child2 As XmlElement
            'For i = 0 To AutoXmlReport.ExternalMainFrom.ParkGridTab.Rows.Count - 1

            Child2 = Doc.CreateElement("info")
            Child2.InnerText = ""
            Child.AppendChild(Child2)

            Attr = Doc.CreateAttribute("GroupId")
            Attr.Value = rGroupId
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("CrossRoadID")
            Attr.Value = rCrossRoadID
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("PlanID")
            Attr.Value = rPlanID
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SubPhaseCount")
            Attr.Value = rSubPhaseCount_str
            Child2.Attributes.Append(Attr)


            Attr = Doc.CreateAttribute("LightSecond")
            Attr.Value = rLightSecond
            Child2.Attributes.Append(Attr)


            Attr = Doc.CreateAttribute("UpdateTime")
            Attr.Value = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            Child2.Attributes.Append(Attr)

            Doc.AppendChild(Root)

            ' Write the document to disk.
            Dim Output As New XmlTextWriter("c:\XmlRightNow\5F44_info.xml", System.Text.Encoding.UTF8)
            Doc.WriteTo(Output)
            Output.Close()



        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Xml", "Report5F44Xml Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub Report5F45Xml(ByVal rGroupId As String, ByVal rCrossRoadID As String, ByVal ReportData As String)
        Try
            If System.IO.Directory.Exists("c:\XmlRightNow") = False Then
                System.IO.Directory.CreateDirectory("c:\XmlRightNow")
            End If
            '-------------------------------------------------------------
            Dim rPlanID As String = Trim(HexStringTOIntString(ReportData.Substring(4, 2), 2))

            Dim rDirect As String = ReportData.Substring(6, 2)
            Dim rDirect_byte As Byte() = StrToByteArray2(rDirect)
            Dim rDirect_binary As String = Convert.ToString(rDirect_byte(0), 2).PadLeft(8, "0")

            Dim rPhaseOrder As String = Trim(HexStringTOIntString(ReportData.Substring(8, 2), 2))

            Dim rSubPhaseCount As Integer = Val(ReportData.Substring(10, 2))
            Dim rSubPhaseCount_str As String = rSubPhaseCount.ToString

            Dim rGreen As String = ReportData.Substring(12, 4 * rSubPhaseCount)


            Dim rCycleTime As String = Trim(HexStringTOIntString(ReportData.Substring(12 + 4 * rSubPhaseCount, 4), 4))
            Dim rOffset As String = Trim(HexStringTOIntString(ReportData.Substring(12 + 4 * rSubPhaseCount + 4, 4), 4))

          
            '-------------------------------------------------------------
            Dim Doc As New XmlDocument()

            Dim XmlProc As XmlDeclaration
            XmlProc = Doc.CreateXmlDeclaration("1.0", "UTF-8", "")
            Doc.AppendChild(XmlProc)

            ' Create the root node.
            Dim Root As XmlElement

            Root = Doc.CreateElement("XML_Head")

            Dim RootAttr As XmlAttribute
            RootAttr = Doc.CreateAttribute("version")
            RootAttr.Value = "1.1"
            Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("listname")
            RootAttr.Value = "查詢5F45回報資訊"
            Root.Attributes.Append(RootAttr)

            'RootAttr = Doc.CreateAttribute("updatetime")
            'RootAttr.Value = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            'Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("interval")
            RootAttr.Value = ""
            Root.Attributes.Append(RootAttr)
            ' Create a child node.
            Dim Child As XmlElement
            Child = Doc.CreateElement("infos")
            Child.InnerText = ""
            Root.AppendChild(Child)


            ' Add an attribute to the child node.
            Dim Attr As XmlAttribute
            Dim Child2 As XmlElement
            'For i = 0 To AutoXmlReport.ExternalMainFrom.ParkGridTab.Rows.Count - 1

            Child2 = Doc.CreateElement("info")
            Child2.InnerText = ""
            Child.AppendChild(Child2)

            Attr = Doc.CreateAttribute("GroupId")
            Attr.Value = rGroupId
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("CrossRoadID")
            Attr.Value = rCrossRoadID
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("PlanID")
            Attr.Value = rPlanID
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("Direct")
            Attr.Value = rDirect_binary
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("PhaseOrder")
            Attr.Value = rPhaseOrder
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SubPhaseCount")
            Attr.Value = rSubPhaseCount_str
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("Green")
            Attr.Value = rGreen
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("CycleTime")
            Attr.Value = rCycleTime
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("Offset")
            Attr.Value = rOffset
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("UpdateTime")
            Attr.Value = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            Child2.Attributes.Append(Attr)

            Doc.AppendChild(Root)

            ' Write the document to disk.
            Dim Output As New XmlTextWriter("c:\XmlRightNow\5F45_info.xml", System.Text.Encoding.UTF8)
            Doc.WriteTo(Output)
            Output.Close()



        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Xml", "Report5F45Xml Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
    Public Sub Report5F46Xml(ByVal rGroupId As String, ByVal rCrossRoadID As String, ByVal ReportData As String)
        Try
            If System.IO.Directory.Exists("c:\XmlRightNow") = False Then
                System.IO.Directory.CreateDirectory("c:\XmlRightNow")
            End If
            '-------------------------------------------------------------
            Dim rSegmentType As String = Trim(HexStringTOIntString(ReportData.Substring(4, 2), 2))

            Dim rSegmentCount As Integer = Val(ReportData.Substring(6, 2))
            Dim rSegmentCount_str As String = rSegmentCount.ToString

            Dim rSegmentContext As String = ReportData.Substring(8, 6 * rSegmentCount)


            Dim rNumWeekDay As String = ReportData.Substring(8 + 6 * rSegmentCount, 2)


            Dim rWeekDay As String = ReportData.Substring(8 + 6 * rSegmentCount + 2, 2 * Val(rNumWeekDay))

            '-------------------------------------------------------------
            Dim Doc As New XmlDocument()

            Dim XmlProc As XmlDeclaration
            XmlProc = Doc.CreateXmlDeclaration("1.0", "UTF-8", "")
            Doc.AppendChild(XmlProc)

            ' Create the root node.
            Dim Root As XmlElement

            Root = Doc.CreateElement("XML_Head")

            Dim RootAttr As XmlAttribute
            RootAttr = Doc.CreateAttribute("version")
            RootAttr.Value = "1.1"
            Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("listname")
            RootAttr.Value = "查詢5F46回報資訊"
            Root.Attributes.Append(RootAttr)

            'RootAttr = Doc.CreateAttribute("updatetime")
            'RootAttr.Value = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            'Root.Attributes.Append(RootAttr)

            RootAttr = Doc.CreateAttribute("interval")
            RootAttr.Value = ""
            Root.Attributes.Append(RootAttr)
            ' Create a child node.
            Dim Child As XmlElement
            Child = Doc.CreateElement("infos")
            Child.InnerText = ""
            Root.AppendChild(Child)


            ' Add an attribute to the child node.
            Dim Attr As XmlAttribute
            Dim Child2 As XmlElement
            'For i = 0 To AutoXmlReport.ExternalMainFrom.ParkGridTab.Rows.Count - 1

            Child2 = Doc.CreateElement("info")
            Child2.InnerText = ""
            Child.AppendChild(Child2)

            Attr = Doc.CreateAttribute("GroupId")
            Attr.Value = rGroupId
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("CrossRoadID")
            Attr.Value = rCrossRoadID
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SegmentType")
            Attr.Value = rSegmentType
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SegmentCount")
            Attr.Value = rSegmentCount_str
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("SegmentContext")
            Attr.Value = rSegmentContext
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("NumWeekDay")
            Attr.Value = rNumWeekDay
            Child2.Attributes.Append(Attr)

            Attr = Doc.CreateAttribute("WeekDay")
            Attr.Value = rWeekDay
            Child2.Attributes.Append(Attr)


            Attr = Doc.CreateAttribute("UpdateTime")
            Attr.Value = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            Child2.Attributes.Append(Attr)

            Doc.AppendChild(Root)

            Dim CreateFineName As String = "5F46_" + rSegmentType + "_info.xml"
            ' Write the document to disk.
            Dim Output As New XmlTextWriter("c:\XmlRightNow\" + CreateFineName, System.Text.Encoding.UTF8)
            Doc.WriteTo(Output)
            Output.Close()



        Catch ex As Exception
            Dim trace As New System.Diagnostics.StackTrace(ex, True)
            WriteLog(curPath, "Module_Xml", "Report5F46Xml Catch(" + trace.GetFrame(0).GetFileLineNumber().ToString + ")" + ex.Message, _logEnable)
        End Try
    End Sub
End Module
