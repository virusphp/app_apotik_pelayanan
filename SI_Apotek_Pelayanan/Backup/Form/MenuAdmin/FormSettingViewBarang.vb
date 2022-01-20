Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports Newtonsoft.Json
Imports System.IO

Public Class FormSettingViewBarang
    Inherits Office2010Form


    Private Sub FormSettingViewBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        If stok0 = "1" Then
            ComboBox1.SelectedIndex = 0
        Else
            ComboBox1.SelectedIndex = 1
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim config As SettingApotik = JsonConvert.DeserializeObject(Of SettingApotik)(File.ReadAllText(".\config.json"))
        config.stok0 = Val(ComboBox1.SelectedIndex + 1)
        Dim modifiedJsonString = JsonConvert.SerializeObject(config)
        File.WriteAllText(".\config.json", modifiedJsonString)
        MsgBox("Setting berhasil", vbInformation, "Informasi")
    End Sub
End Class