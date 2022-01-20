Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient

Public Class FormInfoResepObat
    Inherits Office2010Form

    Dim BDInfoObat As New BindingSource

    Sub tampilObat()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.tanggal, ap_jualr2.notaresep, LTRIM(RTRIM(ap_jualr2.nama_barang)) as nama_barang, ap_jualr2.jmlpaket, ap_jualr2.jmlnonpaket, ap_jualr2.jmljatah, ap_jualr2.tglakhir, case Penjamin.nama_penjamin when '' then 'UMUM' else Penjamin.nama_penjamin end as nama_penjamin FROM ap_jualr2 LEFT OUTER JOIN Penjamin ON ap_jualr2.kd_penjamin = Penjamin.kd_penjamin where ap_jualr2.no_rm = '" & Trim(txtRM.Text) & "' ORDER BY ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.noid desc", CONN)
            DS = New DataSet
            DA.Fill(DS, "infoObat")
            BDInfoObat.DataSource = DS
            BDInfoObat.DataMember = "infoObat"
            With gridResep
                .DataSource = Nothing
                .DataSource = BDInfoObat
                .Columns(0).HeaderText = "Tanggal"
                .Columns(1).HeaderText = "Nota Resep"
                .Columns(2).HeaderText = "Nama Obat"
                .Columns(3).HeaderText = "Jml Paket"
                .Columns(3).DefaultCellStyle.Format = "N2"
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(4).HeaderText = "Jml Non Paket"
                .Columns(4).DefaultCellStyle.Format = "N2"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).HeaderText = "Utk Jml Hari"
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(6).HeaderText = "Tgl Akhir"
                .Columns(7).HeaderText = "Penjamin"
                .Columns(0).Width = 70
                .Columns(1).Width = 85
                .Columns(2).Width = 170
                .Columns(3).Width = 50
                .Columns(4).Width = 50
                .Columns(5).Width = 50
                .Columns(6).Width = 70
                .Columns(7).Width = 160
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
        Catch ex As Exception
            MsgBox("Time Out")
        End Try

    End Sub

    Sub TotalObat()
        Dim Hitung As Decimal = 0
        For baris As Integer = 0 To gridResep.RowCount - 1
            Hitung = Hitung + gridResep.Rows(baris).Cells(3).Value
        Next
        txtJmlObat.DecimalValue = Hitung
    End Sub

    Private Sub FormInfoResepObat_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub FormInfoResepObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        If FormPemanggil = "FormPenjualanResep" Then
            txtRM.Text = FormPenjualanResep.txtRM.Text
            txtNamaPasien.Text = FormPenjualanResep.txtNamaPasien.Text
        ElseIf FormPemanggil = "FormPenjualanResepEMR" Then
            txtRM.Text = FormPenjualanResepEMR.txtRM.Text
            txtNamaPasien.Text = FormPenjualanResepEMR.txtNamaPasien.Text
        ElseIf FormPemanggil = "FormEditPenjualanResepEMR" Then
            txtRM.Text = FormEditPenjualanResepEMR.txtRM.Text
            txtNamaPasien.Text = FormEditPenjualanResepEMR.txtNamaPasien.Text
        Else
            txtRM.Text = FormEditPenjualanResep.txtRM.Text
            txtNamaPasien.Text = FormEditPenjualanResep.txtNamaPasien.Text
        End If
        tampilObat()
        TotalObat()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub txtNamaObat_TextChanged(sender As Object, e As EventArgs) Handles txtNamaObat.TextChanged
        BDInfoObat.Filter = "nama_barang like '%" & txtNamaObat.Text & "%'"
    End Sub
End Class