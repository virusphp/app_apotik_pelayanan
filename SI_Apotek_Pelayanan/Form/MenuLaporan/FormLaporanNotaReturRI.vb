Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports Syncfusion.XlsIO

Public Class FormLaporanNotaReturRI
    Inherits Office2010Form
    Dim kdBagian, nmBagian As String
    Dim BDLaporanNotaReturRI As New BindingSource
    Dim DSLaporanNotaReturRI As New DataSet

    Sub Kosongkan()
        GridObat.DataSource = Nothing
        GridObat.BackgroundColor = Color.Azure
        cmbBagian.Text = ""
        DSLaporanNotaReturRI.Clear()
        txtCariPasien.Enabled = False
        TglServer()
        DTPTanggalAwal.Value = TanggalServer
        DTPTanggalAkhir.Value = TanggalServer
        rNama.Checked = True
        txtCariPasien.Clear()
        txtTotalPaket.DecimalValue = 0
        txtTotalPaketBulat.DecimalValue = 0
        txtTotalNonPaket.DecimalValue = 0
        txtTotalNonPaketBulat.DecimalValue = 0
        txtTotalRetur.DecimalValue = 0
        txtTotalReturBulat.DecimalValue = 0
        txtTotalDijamin.DecimalValue = 0
        txtTotalDijaminBulat.DecimalValue = 0
        txtTotalIurPasien.DecimalValue = 0
        txtTotalIurPasienBulat.DecimalValue = 0
        ListBagian()
        cmbBagian.SelectedIndex = 2
    End Sub

    Sub cariBagian()
        Dim cari As String = InStr(cmbBagian.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbBagian.Text, "|", -1, CompareMethod.Binary)
            kdBagian = Trim((ary(1)))
            nmBagian = Trim((ary(0)))
        End If
    End Sub

    Sub ListBagian()
        'konek()
        CMD = New OleDb.OleDbCommand("select kdbagian, nmbagian from ap_bagian where Status_Apotik=1 order by kdbagian", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbBagian.Items.Clear()
        cmbBagian.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbBagian.Items.Add(DT.Rows(i)("nmbagian") & "|" & DT.Rows(i)("kdbagian"))
        Next
        cmbBagian.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbBagian.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub TotalPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("jmlretpkt").Value
        Next
        txtTotalPaket.DecimalValue = HitungTotal
    End Sub

    Sub TotalNonPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("jmlretnpkt").Value
        Next
        txtTotalNonPaket.DecimalValue = HitungTotal
    End Sub

    Sub TotalRetur()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalretur").Value
        Next
        txtTotalRetur.DecimalValue = HitungTotal
    End Sub

    Sub TotalDijamin()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("dijamin").Value
        Next
        txtTotalDijamin.DecimalValue = HitungTotal
    End Sub

    Sub TotalIurPasien()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("iurpasien").Value
        Next
        txtTotalIurPasien.DecimalValue = HitungTotal
    End Sub

    Sub TotalPaketBulat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("jmlretpktblt").Value
        Next
        txtTotalPaketBulat.DecimalValue = HitungTotal
    End Sub

    Sub TotalNonPaketBulat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("jmlretnpktblt").Value
        Next
        txtTotalNonPaketBulat.DecimalValue = HitungTotal
    End Sub

    Sub TotalReturBulat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalreturblt").Value
        Next
        txtTotalReturBulat.DecimalValue = HitungTotal
    End Sub

    Sub TotalDijaminBulat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("dijaminblt").Value
        Next
        txtTotalDijaminBulat.DecimalValue = HitungTotal
    End Sub

    Sub TotalIurPasienBulat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("iurpasienblt").Value
        Next
        txtTotalIurPasienBulat.DecimalValue = HitungTotal
    End Sub

    Sub tampilLaporan()
        cariBagian()
        Try
            'konek()
            DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, RTRIM(LTRIM(nmkasir)) as nmkasir, tanggal, notaretur, no_reg, no_rm , RTRIM(LTRIM(nama_pasien)) as nama_pasien, RTRIM(LTRIM(nm_penjamin)) as nm_penjamin, jmlretpkt, jmlretpktblt, jmlretnpkt, jmlretnpktblt, totalretur, totalreturblt, dijamin, dijaminblt, iurpasien, iurpasienblt, posting from ap_returinap1 where kdbagian='" & kdBagian & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' ORDER BY tanggal,notaretur", CONN)
            DSLaporanNotaReturRI = New DataSet
            DA.Fill(DSLaporanNotaReturRI, "LaporanNotaReturRI")
            BDLaporanNotaReturRI.DataSource = DSLaporanNotaReturRI
            BDLaporanNotaReturRI.DataMember = "LaporanNotaReturRI"

            With GridObat
                .DataSource = Nothing
                .DataSource = BDLaporanNotaReturRI
                .Columns(0).HeaderText = "Unit Far"
                .Columns(1).HeaderText = "Petugas"
                .Columns(2).HeaderText = "Tanggal"
                .Columns(3).HeaderText = "Nota Retur"
                .Columns(4).HeaderText = "No Register"
                .Columns(5).HeaderText = "No RM"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(7).HeaderText = "Penjamin"
                .Columns(8).HeaderText = "Total Retur Paket"
                .Columns(8).DefaultCellStyle.Format = "N2"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(9).HeaderText = "Total Retur Paket Bulat"
                .Columns(9).DefaultCellStyle.Format = "N2"
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Total Retur Paket Lain"
                .Columns(10).DefaultCellStyle.Format = "N2"
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).HeaderText = "Total Retur Paket Lain Bulat"
                .Columns(11).DefaultCellStyle.Format = "N2"
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).HeaderText = "Jumlah Harga Retur"
                .Columns(12).DefaultCellStyle.Format = "N2"
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).HeaderText = "Jumlah Harga Retur"
                .Columns(13).DefaultCellStyle.Format = "N2"
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).HeaderText = "Dijamin"
                .Columns(14).DefaultCellStyle.Format = "N2"
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).HeaderText = "Dijamin Bulat"
                .Columns(15).DefaultCellStyle.Format = "N2"
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).HeaderText = "Sisa Bayar Pasien"
                .Columns(16).DefaultCellStyle.Format = "N2"
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(17).HeaderText = "Sisa Bayar Pasien Bulat"
                .Columns(17).DefaultCellStyle.Format = "N2"
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(18).HeaderText = "P"
                .Columns(0).Width = 50
                .Columns(1).Width = 100
                .Columns(2).Width = 75
                .Columns(3).Width = 100
                .Columns(4).Width = 90
                .Columns(5).Width = 60
                .Columns(6).Width = 180
                .Columns(7).Width = 180
                .Columns(8).Width = 85
                .Columns(9).Width = 85
                .Columns(10).Width = 85
                .Columns(11).Width = 85
                .Columns(12).Width = 85
                .Columns(13).Width = 85
                .Columns(14).Width = 85
                .Columns(15).Width = 85
                .Columns(16).Width = 85
                .Columns(17).Width = 85
                .Columns(18).Width = 30
                .ReadOnly = True
            End With

            TotalPaket()
            TotalNonPaket()
            TotalRetur()
            TotalDijamin()
            TotalIurPasien()
            TotalPaketBulat()
            TotalNonPaketBulat()
            TotalReturBulat()
            TotalDijaminBulat()
            TotalIurPasienBulat()
            TotalDijaminBulat()
            txtCariPasien.Enabled = True
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormLaporanNotaReturRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosongkan()
    End Sub

    Private Sub btnProsesTab1_Click(sender As Object, e As EventArgs) Handles btnProsesTab1.Click
        tampilLaporan()
        txtCariPasien.Enabled = True
    End Sub

    Private Sub btnBaruTab1_Click(sender As Object, e As EventArgs) Handles btnBaruTab1.Click
        Kosongkan()
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
        If rNama.Checked = True Then
            BDLaporanNotaReturRI.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
        Else
            BDLaporanNotaReturRI.Filter = "no_rm like '%" & txtCariPasien.Text & "%'"
        End If
    End Sub

    Private Sub btnExcelTab1_Click(sender As Object, e As EventArgs) Handles btnExcelTab1.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtXls As DataTable = CType(DSLaporanNotaReturRI.Tables("LaporanNotaReturRI"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanNotaReturRIXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwal.Text
                sheet.Range("B8").Text = DTPTanggalAkhir.Text
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Nota Retur Rawat Inap.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Nota Retur Rawat Inap.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class