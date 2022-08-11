Imports Newtonsoft.Json.Linq
Imports System.Net
Imports System.IO
Imports System.Collections.Specialized
Imports System.Data.SqlClient

Public Class ServiceApi
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
        GetDataSettingWS()
        Dim nvc As NameValueCollection = New NameValueCollection
        nvc.Add("token", Replace(Trim(WsToken), vbCrLf, ""))
        nvc.Add("kodebooking", Replace(Trim(kodebooking), vbCrLf, ""))
        nvc.Add("taskid", Replace(Trim(taskid), vbCrLf, ""))
        nvc.Add("waktu", getTimeStampNow() * 1000)
        'Dim uFile As String()
        'uFile = {""}

        Dim JsonObject As JObject
        Dim JsonResults As List(Of JToken)
        Dim JSonItem As JProperty
        Dim ResCode, ResMsg, Respon As String

        Dim osVer As Version = Environment.OSVersion.Version
        Dim os As OperatingSystem = Environment.OSVersion
        Dim SqlLokal As String = ""
        Dim strSQL As String

        If osVer.Major = 6 And osVer.Minor = 1 Then
            SqlLokal = "select * from task_log  " &
                 " where kodebooking = '" & Replace(Trim(kodebooking), vbCrLf, "") & "'" &
                 " And taskid ='" & Replace(Trim(taskid), vbCrLf, "") & "' And status ='1' And code ='200'"
            If isAdaSIMRS(SqlLokal) = False Then
                strSQL = "update task_log set " &
                        "waktu      ='" & getTimeStampNow() * 1000 & "'," &
                        "code       ='200'," &
                        "message    ='Belum dikirim'," &
                        "status     ='0'," &
                        "created_at ='" & Format(SetTglServer, "yyyy-MM-dd HH:mm:ss") & "' Where " &
                        "kodebooking='" & Replace(Trim(kodebooking), vbCrLf, "") & "' AND " &
                        "taskid     ='" & Replace(Trim(taskid), vbCrLf, "") & "'"
            Else
                strSQL = "insert into task_log (kodebooking,taskid,waktu,code,message,status,created_at) Values (" &
                        "'" & Replace(Trim(kodebooking), vbCrLf, "") & "'," &
                        "'" & Replace(Trim(taskid), vbCrLf, "") & "'," &
                        "'" & getTimeStampNow() * 1000 & "'," &
                        "'200'," &
                        "'Belum dikirim'," &
                        "'0'," &
                        "'" & Format(SetTglServer, "yyyy-MM-dd HH:mm:ss") & "')"
            End If
            If ExecuteNonQuery(CONN, strSQL) = True Then
                updateTaskAntrianBPJS = True
            Else
                updateTaskAntrianBPJS = False
            End If
        Else

            Try
                ResCode = ""
                ResMsg = ""
                Respon = sendRequestJson(WsService & "simrs/antrean/updatewaktu", "POST", nvc)
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
                If ResCode = 200 Then
                    updateTaskAntrianBPJS = True
                Else
                    updateTaskAntrianBPJS = False
                End If
                MsgBox("Berhasil di kirim ke Antrian Obat BPJS", vbInformation, "Informasi")
                Return updateTaskAntrianBPJS
            Catch ex As Exception
                updateTaskAntrianBPJS = False
                Return updateTaskAntrianBPJS
            End Try
        End If
    End Function

    Public Shared Function isAdaSIMRS(ByVal strSQL As String) As Boolean
        Dim bdCek As New BindingSource
        Dim dsCek As DataSet = ExecuteQuery(koneksi.CONN, strSQL, "tabel")
        bdCek.DataSource = dsCek
        bdCek.DataMember = "tabel"
        If bdCek.Count > 0 Then
            isAdaSIMRS = True
        Else
            isAdaSIMRS = False
        End If
    End Function

    Public Shared Function ExecuteQuery(ByVal Koneksi As OleDb.OleDbConnection, ByVal query As String, Optional ByVal NamaTabel As String = "Table1") As DataSet
        Dim dataAdapter As OleDb.OleDbDataAdapter = New OleDb.OleDbDataAdapter(query, Koneksi)
        Dim ds As DataSet = New DataSet
        Try
            dataAdapter.Fill(ds, NamaTabel)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "DataManager-ExecuteQuery")
        End Try
        Return ds
    End Function

    Public Shared Function ExecuteNonQuery(ByVal Koneksi As OleDb.OleDbConnection, ByVal query As String) As Boolean
        Try
            Dim dataCommand As New OleDb.OleDbCommand(query, Koneksi)
            dataCommand.ExecuteNonQuery()
            ExecuteNonQuery = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            ExecuteNonQuery = False
        End Try
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
            Respon = sendRequestJson(Url, Method, nvc)

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
        uTime = (SetTglServer().ToUniversalTime - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds
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
