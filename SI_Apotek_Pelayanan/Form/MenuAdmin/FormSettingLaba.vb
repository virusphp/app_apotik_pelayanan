Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools

Public Class FormSettingLaba
    Inherits Office2010Form

    Sub Kosong()
        With My.Settings
            txtLaba.Text = .laba
            txtPPN.Text = .ppn
        End With
    End Sub

    Private Sub FormSettingLaba_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosong()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        With My.Settings
            .laba = txtLaba.Text
            .ppn = txtPPN.Text
            .Save()
        End With
        MsgBox("Setting Laba PPN Berhasil")
    End Sub

End Class