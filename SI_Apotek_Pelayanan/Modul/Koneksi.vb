Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports System.IO

Module koneksi
    Public dbServer As String
    Public dbUser As String
    Public dbPassword As String
    Public dbName As String
    Public WsService As String
    Public WsToken As String
    Public pkdapo, pnmapo, pkdnota, psts_stok, pkdsubunit, CekKunciStokPenjualan, stok0 As String
    Public sLocalConn As String
    'Public CONN As SqlConnection
    Public CONN As OleDb.OleDbConnection
    'Public DA As SqlDataAdapter
    Public DA As OleDb.OleDbDataAdapter
    Public DS As New DataSet
    'Public CMD As SqlCommand
    Public CMD As OleDb.OleDbCommand
    ' Public DR As SqlDataReader
    Public DR As OleDb.OleDbDataReader
    Public DT As DataTable
    Public DV As DataView
    Public BD As New BindingSource
    Public FormPemanggil As String

    'Public Sub GetDatabaseSetting()
    '    dbServer = My.Settings.dbServer
    '    dbUser = My.Settings.dbUser
    '    dbPassword = Enkripsi.Dekrip(My.Settings.dbPassword)
    '    dbName = My.Settings.dbName
    '    sLocalConn = "server=" & dbServer & ";user id=" & dbUser & ";" & _
    '                 "password=" & dbPassword & ";database=" & dbName
    'End Sub

    Public Sub GetDatabaseSetting()
        Dim config As SettingApotik = JsonConvert.DeserializeObject(Of SettingApotik)(File.ReadAllText(Application.StartupPath & "\config.json"))
        dbServer = config.dbServer
        dbUser = config.dbUser
        dbPassword = Enkripsi.Dekrip(config.dbPassword)
        dbName = config.dbName
        WsService = config.WsServiceBPJS
        WsToken = config.TokenWs
        'sLocalConn = "server=" & dbServer & ";user id=" & dbUser & ";" & _
        '             "password=" & dbPassword & ";database=" & dbName
        sLocalConn = "Provider=SQLOLEDB; Data Source=" & dbServer & "; Initial Catalog=" & dbName & "; Persist Security Info=True;User ID=" & dbUser & "; Password=" & dbPassword & ""
    End Sub

    Public Sub GetDataSettingWS()
        Dim config As SettingApotik = JsonConvert.DeserializeObject(Of SettingApotik)(File.ReadAllText(Application.StartupPath & "\config.json"))
        WsService = config.WsServiceBPJS
        WsToken = config.TokenWs
    End Sub

    Public Function DatabaseConnected(Optional ByVal Server As String = "", _
            Optional ByVal User As String = "", _
            Optional ByVal Password As String = "", _
            Optional ByVal DatabaseName As String = "") As Boolean
        Dim config As SettingApotik = JsonConvert.DeserializeObject(Of SettingApotik)(File.ReadAllText(".\config.json"))
        dbServer = config.dbServer
        dbUser = config.dbUser
        dbPassword = Enkripsi.Dekrip(config.dbPassword)
        dbName = config.dbName
        CONN = New OleDb.OleDbConnection()
        If Server = "" And User = "" And Password = "" And DatabaseName = "" Then
            CONN.ConnectionString = sLocalConn
        Else
            'CONN.ConnectionString = "server=" & Server & ";user id=" & _
            '                        User & ";password=" & Password & _
            '                        ";database=" & DatabaseName
            CONN.ConnectionString = "Provider=SQLOLEDB; Data Source=" & Server & "; Initial Catalog=" & DatabaseName & "; Persist Security Info=True;User ID=" & User & "; Password=" & Password & ""
        End If
        Try
            CONN.Open()
            'CONN.Close()
            Return True
        Catch myerror As SqlException
            Return False
            MessageBox.Show("Error: " & myerror.Message)
        Finally
            CONN.Close()
            'CONN.Dispose()
        End Try
        Return False
    End Function

    Public Sub konek()
        'Try
        '    GetDatabaseSetting()
        '    CONN = New SqlConnection()
        '    CONN.ConnectionString = "Server=" & dbServer & "; Database=" & dbName & "; User Id=" & dbUser & "; Password=" & dbPassword & ";"
        '    CONN.Open()
        'Catch ex As Exception
        '    MsgBox("KONEKSI KE DATABASE GAGAL")
        '    FormKoneksi.ShowDialog()
        'End Try
        'Exit Sub
        Try
            GetDatabaseSetting()
            CONN = New OleDb.OleDbConnection
            CONN.ConnectionString = "Provider=SQLOLEDB; Data Source=" & dbServer & "; Initial Catalog=" & dbName & "; Persist Security Info=True;User ID=" & dbUser & "; Password=" & dbPassword & ""
            If CONN.State <> ConnectionState.Open Then
                CONN.Open()
                'CONN.Close()
            Else
                CONN.Close()
            End If
        Catch ex As Exception
            MsgBox("KONEKSI KE DATABASE GAGAL")
            FormKoneksi.ShowDialog()
        End Try
        Exit Sub
    End Sub

    Public Sub setApo()
        Dim config As SettingApotik = JsonConvert.DeserializeObject(Of SettingApotik)(File.ReadAllText(".\config.json"))
        pkdapo = config.pkdapo
        pnmapo = config.pnmapo
        pkdnota = config.pkdnota
        psts_stok = config.psts_stok
        pkdsubunit = config.pkdsubunit
        CekKunciStokPenjualan = config.CekKunciStokPenjualan
        stok0 = config.stok0
    End Sub
End Module
