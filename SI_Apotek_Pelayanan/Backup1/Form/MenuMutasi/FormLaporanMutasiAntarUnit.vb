Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports Syncfusion.XlsIO

Public Class FormLaporanMutasiAntarUnit
    Inherits Office2010Form
    Dim BDPertanggal, BDPerUnit As New BindingSource
    Dim kdDariUnit, kdKeUnit, nmDariUnit, nmKeUnit As String

    Sub Kosongkan()
        TglServer()
        DTPTanggalAkhirTab1.Value = TanggalServer
        DTPTanggalAwalTab1.Value = TanggalServer
        DTPTanggalAkhirTab2.Value = TanggalServer
        DTPTanggalAwalTab2.Value = TanggalServer
        cmbDariUnitTab2.Text = ""
        cmbKeUnitTab2.Text = ""
        GridTab1.DataSource = Nothing
        GridTab2.DataSource = Nothing
        GridTab1.BackgroundColor = Color.Azure
        GridTab2.BackgroundColor = Color.Azure
        txtGrandTotalTab1.DecimalValue = 0
        txtGrandTotalTab2.DecimalValue = 0
    End Sub

    Sub ListBagian()
        CMD = New OleDb.OleDbCommand("select kdbagian, nmbagian from ap_bagian order by kdbagian", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbDariUnitTab2.Items.Clear()
        cmbDariUnitTab2.Items.Add("")
        cmbKeUnitTab2.Items.Clear()
        cmbKeUnitTab2.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbDariUnitTab2.Items.Add(DT.Rows(i)("nmbagian") & "|" & DT.Rows(i)("kdbagian"))
            cmbKeUnitTab2.Items.Add(DT.Rows(i)("nmbagian") & "|" & DT.Rows(i)("kdbagian"))
        Next
        cmbDariUnitTab2.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbDariUnitTab2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbKeUnitTab2.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKeUnitTab2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub tampilPerTanggal()
        Try
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kdbagian)) as kdbagian, RTRIM(LTRIM(nmkasir)) as nmkasir, tanggal, LTRIM(RTRIM(nmbagian1)) as nmbagian1, RTRIM(LTRIM(nmbagian2)) as nmbagian2, kd_barang, RTRIM(LTRIM(nama_barang)) as nama_barang, jml, RTRIM(LTRIM(nmsatuan)) as nmsatuan, harga, jmlharga,RTRIM(LTRIM(posting)) as posting from ap_ambilunit where kdbagian='" & pkdapo & "' and tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' and tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' order by tanggal,noid", CONN)
            DS = New DataSet
            DA.Fill(DS, "mutasiPerTanggal")
            BDPertanggal.DataSource = DS
            BDPertanggal.DataMember = "mutasiPerTanggal"
            With GridTab1
                .DataSource = Nothing
                .DataSource = BDPertanggal
                .Columns(0).HeaderText = "Unit"
                .Columns(1).HeaderText = "Petugas"
                .Columns(2).HeaderText = "Tanggal"
                .Columns(3).HeaderText = "Dari Unit"
                .Columns(4).HeaderText = "Ke Unit"
                .Columns(5).HeaderText = "Kode Barang"
                .Columns(6).HeaderText = "Nama Barang"
                .Columns(7).HeaderText = "Jumlah Yang Dimutasi"
                .Columns(7).DefaultCellStyle.Format = "N2"
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).HeaderText = "Satuan"
                .Columns(9).HeaderText = "Harga"
                .Columns(9).DefaultCellStyle.Format = "N2"
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Jumlah Harga"
                .Columns(10).DefaultCellStyle.Format = "N2"
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).HeaderText = "Posting"
                .Columns(0).Width = 50
                .Columns(1).Width = 100
                .Columns(2).Width = 75
                .Columns(3).Width = 150
                .Columns(4).Width = 150
                .Columns(5).Width = 80
                .Columns(6).Width = 150
                .Columns(7).Width = 50
                .Columns(8).Width = 75
                .Columns(9).Width = 90
                .Columns(10).Width = 120
                .Columns(11).Width = 50
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilPerUnit()
        Try
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kdbagian)) as kdbagian, RTRIM(LTRIM(nmkasir)) as nmkasir, tanggal, LTRIM(RTRIM(nmbagian1)) as nmbagian1, RTRIM(LTRIM(nmbagian2)) as nmbagian2, kd_barang, RTRIM(LTRIM(nama_barang)) as nama_barang, jml, RTRIM(LTRIM(nmsatuan)) as nmsatuan, harga, jmlharga,RTRIM(LTRIM(posting)) as posting from ap_ambilunit where tanggal >=  '" & Format(DTPTanggalAwalTab2.Value, "yyyy/MM/dd") & "' and tanggal <= '" & Format(DTPTanggalAkhirTab2.Value, "yyyy/MM/dd") & "' and kdbagian1='" & kdDariUnit & "' and kdbagian2='" & kdKeUnit & "' order by tanggal,noid", CONN)
            DS = New DataSet
            DA.Fill(DS, "mutasiPerUnit")
            BDPerUnit.DataSource = DS
            BDPerUnit.DataMember = "mutasiPerUnit"
            With GridTab2
                .DataSource = Nothing
                .DataSource = BDPerUnit
                .Columns(0).HeaderText = "Unit"
                .Columns(1).HeaderText = "Petugas"
                .Columns(2).HeaderText = "Tanggal"
                .Columns(3).HeaderText = "Dari Unit"
                .Columns(4).HeaderText = "Ke Unit"
                .Columns(5).HeaderText = "Kode Barang"
                .Columns(6).HeaderText = "Nama Barang"
                .Columns(7).HeaderText = "Jumlah Yang Dimutasi"
                .Columns(7).DefaultCellStyle.Format = "N2"
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).HeaderText = "Satuan"
                .Columns(9).HeaderText = "Harga"
                .Columns(9).DefaultCellStyle.Format = "N2"
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Jumlah Harga"
                .Columns(10).DefaultCellStyle.Format = "N2"
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).HeaderText = "Posting"
                .Columns(0).Width = 50
                .Columns(1).Width = 100
                .Columns(2).Width = 75
                .Columns(3).Width = 150
                .Columns(4).Width = 150
                .Columns(5).Width = 80
                .Columns(6).Width = 150
                .Columns(7).Width = 50
                .Columns(8).Width = 75
                .Columns(9).Width = 90
                .Columns(10).Width = 120
                .Columns(11).Width = 50
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cariDariUnit()
        Dim cari As String = InStr(cmbDariUnitTab2.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbDariUnitTab2.Text, "|", -1, CompareMethod.Binary)
            kdDariUnit = Trim((ary(1)))
            nmDariUnit = Trim((ary(0)))
        End If
    End Sub

    Sub cariKeUnit()
        Dim cari As String = InStr(cmbKeUnitTab2.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbKeUnitTab2.Text, "|", -1, CompareMethod.Binary)
            kdKeUnit = Trim((ary(1)))
            nmKeUnit = Trim((ary(0)))
        End If
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

    Private Sub FormLaporanMutasiAntarUnit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormLaporanMutasiAntarUnit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Kosongkan()
        ListBagian()
    End Sub

    Private Sub btnProsesTab1_Click(sender As Object, e As EventArgs) Handles btnProsesTab1.Click
        tampilPerTanggal()
        TotalHargaTab1()
    End Sub

    Private Sub btnBaruTab1_Click(sender As Object, e As EventArgs) Handles btnBaruTab1.Click
        Kosongkan()
    End Sub

    Private Sub btnProsesTab2_Click(sender As Object, e As EventArgs) Handles btnProsesTab2.Click
        cariDariUnit()
        cariKeUnit()
        tampilPerUnit()
        TotalHargaTab2()
    End Sub

    Private Sub btnBaruTab2_Click(sender As Object, e As EventArgs) Handles btnBaruTab2.Click
        Kosongkan()
    End Sub

    Private Sub btnExcelTab1_Click(sender As Object, e As EventArgs) Handles btnExcelTab1.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'GridTab1.DataSource = DS.Tables("permintaanGudangPerTanggal")
            Try
                Dim dtXls As DataTable = CType(DS.Tables("mutasiPerTanggal"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanMutasiAntarUnitPerTanggalXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab1.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab1.Text
                sheet.Range("B9").Text = pnmapo
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Mutasi Antar Unit Per Tanggal.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Mutasi Antar Unit Per Tanggal.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnExcelTab2_Click(sender As Object, e As EventArgs) Handles btnExcelTab2.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'GridTab1.DataSource = DS.Tables("permintaanGudangPerTanggal")
            Try
                Dim dtXls As DataTable = CType(DS.Tables("mutasiPerUnit"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanMutasiAntarUnitPerUnitXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab1.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab1.Text
                sheet.Range("B9").Text = nmDariUnit
                sheet.Range("B10").Text = nmKeUnit
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Mutasi Antar Unit Per Unit.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Mutasi Antar Unit Per Unit.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class