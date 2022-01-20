Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient

Public Class FormEditEtiketModel2
    Inherits Office2010Form
    Public kdBarang, urut As String

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim edit As String = "UPDATE ap_etiketNew SET nama_barang='" & txtNamaObatEtiketInfus.Text & "', jml_obat='" & Num_En_US(txtJumlahObatEtiketInfus.DecimalValue) & "', obat='" & txtObatInfus.Text & "', tetes='" & txtTetesInfus.Text & "' WHERE tanggal='" & Format(FormCetakEtiketPerBarang.DTPTanggalResep.Value, "yyyy/MM/dd") & "' AND notaresep='" & FormCetakEtiketPerBarang.txtNotaResep.Text & "' AND kd_barang='" & kdBarang & "' AND urut='" & urut & "'"
            CMD = New OleDb.OleDbCommand(edit, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Berhasil diedit", vbInformation, "Informasi")
            FormCetakEtiketPerBarang.cetakEtiketInfus()
            FormCetakEtiketPerBarang.tampilObat()
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtNamaObatEtiketInfus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNamaObatEtiketInfus.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJumlahObatEtiketInfus.Focus()
        End If
    End Sub

    Private Sub txtNamaObatEtiketInfus_TextChanged(sender As Object, e As EventArgs) Handles txtNamaObatEtiketInfus.TextChanged

    End Sub

    Private Sub txtJumlahObatEtiketInfus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJumlahObatEtiketInfus.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtObatInfus.Focus()
        End If
    End Sub

    Private Sub txtObatInfus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObatInfus.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTetesInfus.Focus()
        End If
    End Sub

    Private Sub txtTetesInfus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTetesInfus.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub FormEditEtiketModel2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class