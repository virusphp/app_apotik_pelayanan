
Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.IO
Imports System.Collections.Specialized
Public Class webService

    Public Shared Function sendRequestJson(ByVal url As String, ByVal Method As String, ByVal Optional formFields As NameValueCollection = Nothing) As String
        Dim boundary As String = "----------------------------" & DateTime.Now.Ticks.ToString("x")
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

        request.ContentType = "multipart/form-data; boundary=" & boundary
        request.Method = Method
        request.KeepAlive = True
        Dim memStream As Stream = New MemoryStream()
        Dim boundarybytes = Text.Encoding.ASCII.GetBytes(vbCrLf & "--" & boundary & vbCrLf)
        Dim endBoundaryBytes = Text.Encoding.ASCII.GetBytes(vbCrLf & "--" & boundary & "--")
        Dim formdataTemplate As String = vbCrLf & "--" & boundary & vbCrLf & "Content-Disposition: form-data; name=""{0}"";" & vbCrLf & vbCrLf & "{1}"

        If formFields IsNot Nothing Then
            For Each key As String In formFields.Keys
                Dim formitem As String = String.Format(formdataTemplate, key, formFields(key))
                Dim formitembytes As Byte() = System.Text.Encoding.UTF8.GetBytes(formitem)
                memStream.Write(formitembytes, 0, formitembytes.Length)
            Next
        End If

        Dim headerTemplate As String = "Content-Disposition: form-data; name=""{0}""; filename=""{1}""" & vbCrLf & "Content-Type: application/octet-stream" & vbCrLf & vbCrLf

        memStream.Write(endBoundaryBytes, 0, endBoundaryBytes.Length)
        request.ContentLength = memStream.Length

        Using requestStream As Stream = request.GetRequestStream()
            memStream.Position = 0
            Dim tempBuffer As Byte() = New Byte(memStream.Length - 1) {}
            memStream.Read(tempBuffer, 0, tempBuffer.Length)
            memStream.Close()
            requestStream.Write(tempBuffer, 0, tempBuffer.Length)
        End Using

        Using response = request.GetResponse()
            Dim stream2 As Stream = response.GetResponseStream()
            Dim reader2 As StreamReader = New StreamReader(stream2)
            Return newMethod(reader2)
        End Using
    End Function
    Private Shared Function newMethod(reader2 As StreamReader) As String
        Return reader2.ReadToEnd()
    End Function

    Public Shared Function updateTaskAntrianBPJS(ByVal kodebooking As String,
                                                  ByVal taskid As String) As Boolean

        updateTaskAntrianBPJS = False
        Dim nvc As NameValueCollection = New NameValueCollection
        nvc.Add("token", Replace(Trim(My.Settings.TokenBPJS), vbCrLf, ""))
        nvc.Add("kodebooking", Replace(Trim(kodebooking), vbCrLf, ""))
        nvc.Add("taskid", Replace(Trim(taskid), vbCrLf, ""))
        nvc.Add("waktu", getTimeStampNow() * 1000)
        'Dim uFile As String()
        'uFile = {""}

        Dim JsonObject As JObject
        Dim JsonResults As List(Of JToken)
        Dim JSonItem As JProperty
        Dim ResCode, ResMsg, Respon As String

        Try
            ResCode = ""
            ResMsg = ""
            Respon = webService.sendRequestJson(webService.URLService & "simrs/antrean/updatewaktu", "POST", nvc)
            JsonObject = JObject.Parse(Respon)
            JsonResults = JsonObject.Children().ToList
            For Each JSonItem In JsonResults
                JSonItem.CreateReader()
                JSonItem.ToString()
                Select Case JSonItem.Name
                    Case "metadata"
                        For Each JsonObject In JSonItem
                            ResCode = JsonObject("code")
                            ResMsg = JsonObject("message")
                        Next
                End Select
            Next
            If ResCode = "200" Or ResCode = "208" Then
                updateTaskAntrianBPJS = True
            Else
                updateTaskAntrianBPJS = False
            End If
        Catch ex As Exception
            updateTaskAntrianBPJS = False
        End Try

        Return updateTaskAntrianBPJS
    End Function

    Public Shared Function kirimDataJsonBPJS(ByVal Url As String,
                                             ByVal Method As String,
                                             ByVal nvc As NameValueCollection) As Boolean

        kirimDataJsonBPJS = False
        Dim JsonObject As JObject
        Dim JsonResults As List(Of JToken)
        Dim JSonItem As JProperty
        Dim ResCode, ResMsg, Respon As String

        Try
            ResCode = ""
            ResMsg = ""
            Respon = webService.sendRequestJson(Url, Method, nvc)

            JsonObject = JObject.Parse(Respon)
            JsonResults = JsonObject.Children().ToList
            For Each JSonItem In JsonResults
                JSonItem.CreateReader()
                JSonItem.ToString()
                Select Case JSonItem.Name
                    Case "metadata"
                        For Each JsonObject In JSonItem
                            ResCode = JsonObject("code")
                            ResMsg = JsonObject("message")
                        Next
                End Select
            Next
            If ResCode = "200" Then
                kirimDataJsonBPJS = True
            Else
                kirimDataJsonBPJS = False
            End If
        Catch ex As Exception
            kirimDataJsonBPJS = False
        End Try

        Return kirimDataJsonBPJS
    End Function

    Public Shared Function getTimeStampNow() As String
        Dim uTime As Integer
        uTime = (SetTglServer() - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds
        Return uTime
    End Function

    Public Shared Function getTimeStamp(ByVal Tanggal As DateTime) As String
        Dim uTime As Integer
        uTime = (Tanggal - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds
        Return uTime
    End Function

    Public Shared Function getTokenAntrianOnline() As String
        Return Replace(Trim(My.Settings.TokenBPJS), vbCrLf, "")
    End Function
End Class
