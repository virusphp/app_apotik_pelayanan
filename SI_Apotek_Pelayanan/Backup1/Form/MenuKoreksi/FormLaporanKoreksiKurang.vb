Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.XlsIO
Imports System.Data.SqlClient

Public Class FormLaporanKoreksiKurang
    Inherits Office2010Form
    Dim Stok As String
    Dim BDPertanggal, BDPerBarang, BDDataBarang As New BindingSource

    Sub kosongkan1()
        TglServer()
        DTPTanggalAwalTab1.Value = TanggalServer
        DTPTanggalAkhirTab1.Value = TanggalServer
        txtGrandTotalTab1.DecimalValue = 0
        GridTab1.DataSource = Nothing
        GridTab1.BackgroundColor = Color.Azure
        DTPTanggalAwalTab1.Focus()
    End Sub

    Sub kosongkan2()
        TglServer()
        DTPTanggalAwalTab2.Value = TanggalServer
        DTPTanggalAkhirTab2.Value = TanggalServer
        txtGrandTotalTab2.DecimalValue = 0
        GridTab2.DataSource = Nothing
        GridTab2.BackgroundColor = Color.Azure
        txtKodeObat.Clear()
        txtNamaBarang.Clear()
        DTPTanggalAwalTab2.Focus()
    End Sub

    Sub tampilBarang()
        If pkdapo = "001" Then
            Stok = "stok001"
        ElseIf pkdapo = "002" Then
            Stok = "stok002"
        ElseIf pkdapo = "003" Then
            Stok = "stok003"
        ElseIf pkdapo = "004" Then
            Stok = "stok004"
        ElseIf pkdapo = "005" Then
            Stok = "stok005"
        ElseIf pkdapo = "006" Then
            Stok = "stok006"
        ElseIf pkdapo = "007" Then
            Stok = "stok007"
        End If
        Try
            konek()
            DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from barang_farmasi WHERE stsaktif ='1' order by kd_barang", CONN)
            DS = New DataSet
            DA.Fill(DS, "obat")
            BDDataBarang.DataSource = DS
            BDDataBarang.DataMember = "obat"

            With gridBarang
                .DataSource = Nothing
                .DataSource = BDDataBarang
                .Columns(1).HeaderText = "ID Barang"
                .Columns(2).HeaderText = "Kode Barang"
                .Columns(3).HeaderText = "Nama Barang"
                .Columns(4).HeaderText = "Stok"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).HeaderText = "Satuan"
                .Columns(6).HeaderText = "Keterangan"
                .Columns(0).Width = 30
                .Columns(1).Width = 50
                .Columns(2).Width = 75
                .Columns(3).Width = 190
                .Columns(4).Width = 40
                .Columns(5).Width = 50
                .Columns(6).Width = 120
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilPerTanggal()
        Try
            konek()
            DA = New OleDb.OleDbDataAdapter("select nmkasir, nokoreksi, tanggal, idx_barang, kd_barang, RTRIM(LTRIM(nama_barang)) as nama_barang, jml, RTRIM(LTRIM(nmsatuan)) as nmsatuan, harga, jmlharga, RTRIM(LTRIM(keterangan)) as keterangan from ap_koreksiapo_kurang where tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' and tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' and kdbagian='" & pkdapo & "' order by tanggal,noid", CONN)
            DS = New DataSet
            DA.Fill(DS, "KoreksiKurangPerTanggal")
            BDPertanggal.DataSource = DS
            BDPertanggal.DataMember = "KoreksiKurangPerTanggal"
            With GridTab1
                .DataSource = Nothing
                .DataSource = BDPertanggal
                .Columns(0).HeaderText = "Petugas"
                .Columns(1).HeaderText = "No Koreksi"
                .Columns(2).HeaderText = "Tanggal"
                .Columns(3).HeaderText = "ID Barang"
                .Columns(4).HeaderText = "Kode Barang"
                .Columns(5).HeaderText = "Nama Barang"
                .Columns(6).HeaderText = "Jumlah Koreksi"
                .Columns(6).DefaultCellStyle.Format = "N2"
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).HeaderText = "Satuan"
                .Columns(8).HeaderText = "Harga"
                .Columns(8).DefaultCellStyle.Format = "N2"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(9).HeaderText = "Jumlah Harga"
                .Columns(9).DefaultCellStyle.Format = "N2"
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Keterangan"
                .Columns(0).Width = 100
                .Columns(1).Width = 75
                .Columns(2).Width = 75
                .Columns(3).Width = 75
                .Columns(4).Width = 80
                .Columns(5).Width = 230
                .Columns(6).Width = 60
                .Columns(7).Width = 80
                .Columns(8).Width = 80
                .Columns(9).Width = 100
                .Columns(10).Width = 200
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
                TotalHargaTab1()
            End With
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilPerBarang()
        Try
            konek()
            DA = New OleDb.OleDbDataAdapter("select nmkasir, nokoreksi, tanggal, idx_barang, kd_barang, RTRIM(LTRIM(nama_barang)) as nama_barang, jml, RTRIM(LTRIM(nmsatuan)) as nmsatuan, harga, jmlharga, RTRIM(LTRIM(keterangan)) as keterangan from ap_koreksiapo_kurang where tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' and tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' and kdbagian='" & pkdapo & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal,noid", CONN)
            DS = New DataSet
            DA.Fill(DS, "KoreksiKurangPerBarang")
            BDPerBarang.DataSource = DS
            BDPerBarang.DataMember = "KoreksiKurangPerBarang"
            With GridTab2
                .DataSource = Nothing
                .DataSource = BDPerBarang
                .Columns(0).HeaderText = "Petugas"
                .Columns(1).HeaderText = "No Koreksi"
                .Columns(2).HeaderText = "Tanggal"
                .Columns(3).HeaderText = "ID Barang"
                .Columns(4).HeaderText = "Kode Barang"
                .Columns(5).HeaderText = "Nama Barang"
                .Columns(6).HeaderText = "Jumlah Koreksi"
                .Columns(6).DefaultCellStyle.Format = "N2"
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).HeaderText = "Satuan"
                .Columns(8).HeaderText = "Harga"
                .Columns(8).DefaultCellStyle.Format = "N2"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(9).HeaderText = "Jumlah Harga"
                .Columns(9).DefaultCellStyle.Format = "N2"
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Keterangan"
                .Columns(0).Width = 100
                .Columns(1).Width = 75
                .Columns(2).Width = 75
                .Columns(3).Width = 75
                .Columns(4).Width = 80
                .Columns(5).Width = 230
                .Columns(6).Width = 60
                .Columns(7).Width = 80
                .Columns(8).Width = 80
                .Columns(9).Width = 100
                .Columns(10).Width = 200
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
                TotalHargaTab2()
            End With
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub TotalHargaTab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("jmlharga").Value
        Next
        txtGrandTotalTab1.DecimalValue = HitungTotal
    End Sub

    Sub TotalHargaTab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("jmlharga").Value
        Next
        txtGrandTotalTab2.DecimalValue = HitungTotal
    End Sub

    Private Sub btnProsesTab1_Click(sender As Object, e As EventArgs) Handles btnProsesTab1.Click
        tampilPerTanggal()
    End Sub

    Private Sub FormLaporanKoreksiKurang_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormLaporanKoreksiKurang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        kosongkan1()
        kosongkan2()
    End Sub

    Private Sub btnExcelTab1_Click(sender As Object, e As EventArgs) Handles btnExcelTab1.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtXls As DataTable = CType(DS.Tables("KoreksiKurangPerTanggal"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanKoreksiKurangPerTanggalXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab1.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab1.Text
                sheet.Range("B9").Text = pnmapo
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Koreksi Kurang Per Tanggal.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Koreksi Kurang Per Tanggal.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnBaruTab1_Click(sender As Object, e As EventArgs) Handles btnBaruTab1.Click
        kosongkan1()
    End Sub

    Private Sub txtCariObat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariObat.KeyDown
        If e.KeyCode = Keys.Down Then
            gridBarang.Focus()
        End If
    End Sub

    Private Sub txtCariObat_TextChanged(sender As Object, e As EventArgs) Handles txtCariObat.TextChanged
        BDDataBarang.Filter = "nama_barang like '%" & txtCariObat.Text & "%'"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelObat.Visible = False
    End Sub

    Private Sub txtKodeObat_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObat.GotFocus
        tampilBarang()
        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub txtKodeObat_TextChanged(sender As Object, e As EventArgs) Handles txtKodeObat.TextChanged

    End Sub

    Private Sub DTPTanggalAwalTab1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAwalTab1.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPTanggalAkhirTab1.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAkhirTab1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAkhirTab1.KeyPress
        If e.KeyChar = Chr(13) Then
            btnProsesTab1.Focus()
        End If
    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                txtKodeObat.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                txtNamaBarang.Text = gridBarang.Rows(e.RowIndex).Cells(3).Value
                PanelObat.Visible = False
                btnProsesTab2.Focus()
            End If
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                txtKodeObat.Text = gridBarang.Rows(i).Cells(2).Value
                txtNamaBarang.Text = gridBarang.Rows(i).Cells(3).Value
                PanelObat.Visible = False
                btnProsesTab2.Focus()
            End If
        End If
    End Sub

    Private Sub btnProsesTab2_Click(sender As Object, e As EventArgs) Handles btnProsesTab2.Click
        tampilPerBarang()
    End Sub

    Private Sub DTPTanggalAwalTab2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAwalTab2.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPTanggalAkhirTab2.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAkhirTab2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAkhirTab2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKodeObat.Focus()
        End If
    End Sub

    Private Sub btnBaruTab2_Click(sender As Object, e As EventArgs) Handles btnBaruTab2.Click
        kosongkan2()
    End Sub

    Private Sub btnExcelTab2_Click(sender As Object, e As EventArgs) Handles btnExcelTab2.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtXls As DataTable = CType(DS.Tables("KoreksiKurangPerBarang"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanKoreksiKurangPerBarangXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab1.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab1.Text
                sheet.Range("B9").Text = pnmapo
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Koreksi Kurang Per Barang.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Koreksi Kurang Per Barang.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class