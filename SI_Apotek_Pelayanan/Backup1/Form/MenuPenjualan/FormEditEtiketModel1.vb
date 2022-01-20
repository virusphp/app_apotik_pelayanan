Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports System.ComponentModel

Public Class FormEditEtiketModel1
    Inherits Office2010Form
    Public kdBarang, urut As String

    Sub ListEtiketTakaran()
        DA = New OleDb.OleDbDataAdapter("select * from ap_etiket_takaran order by noid", CONN)
        DT = New DataTable
        DA.Fill(DT)
        cmbTakaran.DataSource = DT
        cmbTakaran.DisplayMember = "takaran"
        cmbTakaran.ValueMember = "noid"
        cmbTakaran.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbTakaran.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListEtiketWaktu()
        DA = New OleDb.OleDbDataAdapter("select * from ap_etiket_waktu order by noid", CONN)
        DT = New DataTable
        DA.Fill(DT)
        cmbWaktu.DataSource = DT
        cmbWaktu.DisplayMember = "waktu"
        cmbWaktu.ValueMember = "noid"
        cmbWaktu.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbWaktu.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListEtiketKeterangan()
        DA = New OleDb.OleDbDataAdapter("select * from ap_etiket_ketminum order by noid", CONN)
        DT = New DataTable
        DA.Fill(DT)
        cmbKeterangan.DataSource = DT
        cmbKeterangan.DisplayMember = "ketminum"
        cmbKeterangan.ValueMember = "noid"
        cmbKeterangan.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKeterangan.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub FormEditEtiketMode1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'ListEtiketKeterangan()
        'ListEtiketTakaran()
        'ListEtiketWaktu()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim edit As String = "UPDATE ap_etiketNew SET nama_barang='" & txtNamaObatEtiket.Text & "', jml_obat='" & Num_En_US(txtJumlahObatEtiket.DecimalValue) & "', signa1='" & txtSigna1.Text & "', signa2='" & txtSigna2.Text & "', kd_takaran='" & cmbTakaran.SelectedValue.ToString & "', kd_waktu='" & cmbWaktu.SelectedValue.ToString & "', kd_ketminum='" & cmbKeterangan.SelectedValue & "', tgl_exp='" & Format(DTPTanggalExp.Value, "yyyy/MM/dd") & "' where tanggal='" & Format(FormCetakEtiketPerBarang.DTPTanggalResep.Value, "yyyy/MM/dd") & "' AND notaresep='" & FormCetakEtiketPerBarang.txtNotaResep.Text & "' AND kd_barang='" & kdBarang & "' AND urut='" & urut & "'"
            CMD = New OleDb.OleDbCommand(edit, CONN)
            CMD.ExecuteNonQuery()

            MsgBox("Berhasil diedit", vbInformation, "Informasi")
            FormCetakEtiketPerBarang.cetakEtiket()
            FormCetakEtiketPerBarang.tampilObat()
            Me.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtJarakED_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJarakED.KeyDown
        If e.KeyCode = Keys.Enter Then
            Button1.Focus()
        End If
    End Sub

    Private Sub txtJarakED_TextChanged(sender As Object, e As EventArgs) Handles txtJarakED.TextChanged
        DTPTanggalExp.Value = DateAdd("d", Val(txtJarakED.DecimalValue), FormCetakEtiketPerBarang.DTPTanggalResep.Value)
    End Sub

    Private Sub txtNamaObatEtiket_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNamaObatEtiket.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJumlahObatEtiket.Focus()
        End If
    End Sub

    Private Sub txtJumlahObatEtiket_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJumlahObatEtiket.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSigna1.Focus()
        End If
    End Sub

    Private Sub txtSigna2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSigna2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbTakaran.Focus()
        End If
    End Sub

    Private Sub cmbTakaran_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTakaran.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbWaktu.Focus()
        End If
    End Sub

    Private Sub cmbWaktu_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbWaktu.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbKeterangan.Focus()
        End If
    End Sub

    Private Sub cmbWaktu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWaktu.SelectedIndexChanged

    End Sub

    Private Sub cmbKeterangan_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbKeterangan.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJarakED.Focus()
        End If
    End Sub

    Private Sub txtSigna1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSigna1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSigna2.Focus()
        End If
    End Sub

End Class