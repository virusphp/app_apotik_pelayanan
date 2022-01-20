Imports Syncfusion.Windows.Forms

Public Class FormKonfirmasiEtiketModel4
    Inherits MetroForm


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormPenjualanResep.jmlHariEtiketModel4 = txtJumlahHari.DecimalValue
        Me.Close()
    End Sub

    Private Sub FormKonfirmasiEtiketModel4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtJumlahHari.DecimalValue = 1
        txtJumlahHari.Focus()
    End Sub

    Private Sub txtJumlahHari_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJumlahHari.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub
End Class
