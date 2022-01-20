Imports Syncfusion.Windows.Forms
Imports Newtonsoft.Json
Imports System.IO

Public Class FormKoneksi
    Inherits Office2010Form

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If DatabaseConnected(txtDbServer.Text, txtDbUser.Text, _
                             txtDbPassword.Text, txtDbName.Text) = True Then
            Dim config As SettingApotik = JsonConvert.DeserializeObject(Of SettingApotik)(File.ReadAllText(".\config.json"))
            config.dbServer = txtDbServer.Text
            config.dbUser = txtDbUser.Text
            config.dbPassword = Enkripsi.Enkrip(txtDbPassword.Text)
            config.dbName = txtDbName.Text

            Dim modifiedJsonString = JsonConvert.SerializeObject(config)
            File.WriteAllText(".\config.json", modifiedJsonString)
            GetDatabaseSetting()
            MsgBox("KONEKSI KE DATABASE BERHASIL")
            Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Else
            GetDatabaseSetting()
            MsgBox("KONEKSI KE DATABASE GAGAL")
        End If
    End Sub

    Private Sub FormKoneksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetDatabaseSetting()
        txtDbServer.Text = dbServer
        txtDbUser.Text = dbUser
        txtDbPassword.Text = dbPassword
        txtDbName.Text = dbName
    End Sub

	Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

	End Sub
End Class
