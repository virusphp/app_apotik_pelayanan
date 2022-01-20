Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient

Public Class FormEditEtiketModel3
    Inherits Office2010Form
    Public kdBarang, urut As String

    Sub ListEtiketKeterangan()
        DA = New OleDb.OleDbDataAdapter("select * from ap_etiket_ketminum order by noid", CONN)
        DT = New DataTable
        DA.Fill(DT)
        cmbKeteranganModel3.DataSource = DT
        cmbKeteranganModel3.DisplayMember = "ketminum"
        cmbKeteranganModel3.ValueMember = "noid"
        cmbKeteranganModel3.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKeteranganModel3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub FormEditEtiketModel3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ListEtiketKeterangan()
    End Sub

    Private Sub txtNamaObatEtiketModel3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNamaObatEtiketModel3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJumlahObatEtiketModel3.Focus()
        End If
    End Sub

    Private Sub txtJumlahObatEtiketModel3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJumlahObatEtiketModel3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbKeteranganModel3.Focus()
        End If
    End Sub

    Private Sub cmbKeteranganModel3_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbKeteranganModel3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJarakEDModel3.Focus()
        End If
    End Sub

    Private Sub txtJarakEDModel3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJarakEDModel3.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim edit As String = "UPDATE ap_etiketNew SET nama_barang='" & txtNamaObatEtiketModel3.Text & "', jml_obat='" & Num_En_US(txtJumlahObatEtiketModel3.DecimalValue) & "', kd_ketminum='" & cmbKeteranganModel3.SelectedValue & "', tgl_exp='" & Format(DTPTanggalExp.Value, "yyyy/MM/dd") & "' where tanggal='" & Format(FormCetakEtiketPerBarang.DTPTanggalResep.Value, "yyyy/MM/dd") & "' AND notaresep='" & FormCetakEtiketPerBarang.txtNotaResep.Text & "' AND kd_barang='" & kdBarang & "' AND urut='" & urut & "'"
            CMD = New OleDb.OleDbCommand(edit, CONN)
            CMD.ExecuteNonQuery()

            MsgBox("Berhasil diedit", vbInformation, "Informasi")
            FormCetakEtiketPerBarang.cetakEtiketModel3()
            FormCetakEtiketPerBarang.tampilObat()
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtJarakEDModel3_TextChanged(sender As Object, e As EventArgs) Handles txtJarakEDModel3.TextChanged
        DTPTanggalExp.Value = DateAdd("d", Val(txtJarakEDModel3.DecimalValue), FormCetakEtiketPerBarang.DTPTanggalResep.Value)
    End Sub
End Class