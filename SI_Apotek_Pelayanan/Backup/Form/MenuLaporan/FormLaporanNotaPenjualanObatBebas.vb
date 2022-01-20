Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports Syncfusion.XlsIO

Public Class FormLaporanNotaPenjualanObatBebas
    Inherits Office2010Form
    Dim kdBagianTab1, nmBagianTab1, kdBagianTab2, nmBagianTab2, kdPetugas, nmPetugas As String
    Dim BDPertanggal, BDPerKasir As New BindingSource

    Sub Kosongkan1()
        TglServer()
        cmbBagianTab1.Text = ""
        DTPTanggalAwalTab1.Value = TanggalServer
        DTPTanggalAkhirTab1.Value = TanggalServer
        GridTab1.BackgroundColor = Color.Azure
        GridTab1.DataSource = Nothing
        txtNota.DecimalValue = 0
        txtJumlahHarga1Tab1.DecimalValue = 0
        txtPotonganTab1.DecimalValue = 0
        txtJumlahHarga2Tab1.DecimalValue = 0
        txtPembulatanTab1.DecimalValue = 0
        txtJumlahHargaJualTab1.DecimalValue = 0
        txtNamaPasien.Enabled = False
        txtNamaPasien.Clear()
        cmbDiserahkan.Enabled = False
        cmbDiserahkan.Text = ""
        cmbBagianTab1.Focus()
    End Sub

    Sub Kosongkan2()
        TglServer()
        cmbBagianTab2.Text = ""
        cmbPetugasTab2.Text = ""
        DTPTanggalAwalTab2.Value = TanggalServer
        DTPTanggalAkhirTab2.Value = TanggalServer
        GridTab2.BackgroundColor = Color.Azure
        GridTab2.DataSource = Nothing
        txtJumlahHarga1Tab2.DecimalValue = 0
        txtPotonganTab2.DecimalValue = 0
        txtJumlahHarga2Tab2.DecimalValue = 0
        txtPembulatanTab2.DecimalValue = 0
        txtJumlahHargaJualTab2.DecimalValue = 0
        txtNota2.DecimalValue = 0
        cmbBagianTab2.Focus()
    End Sub

    Sub ListBagian1()
        'konek()
        CMD = New OleDb.OleDbCommand("select kdbagian, nmbagian from ap_bagian where Status_Apotik=1 order by kdbagian", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbBagianTab1.Items.Clear()
        cmbBagianTab1.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbBagianTab1.Items.Add(DT.Rows(i)("nmbagian") & "|" & DT.Rows(i)("kdbagian"))
        Next
        cmbBagianTab1.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbBagianTab1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListBagian2()
        'konek()
        CMD = New OleDb.OleDbCommand("select kdbagian, nmbagian from ap_bagian where Status_Apotik=1 order by kdbagian", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbBagianTab2.Items.Clear()
        cmbBagianTab2.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbBagianTab2.Items.Add(DT.Rows(i)("nmbagian") & "|" & DT.Rows(i)("kdbagian"))
        Next
        cmbBagianTab2.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbBagianTab2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListPetugas()
        'konek()
        CMD = New OleDb.OleDbCommand("select kdkasir,nmkasir from ap_pas_farmasi ORDER BY nmkasir", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbPetugasTab2.Items.Clear()
        cmbPetugasTab2.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbPetugasTab2.Items.Add(DT.Rows(i)("nmkasir") & "|" & DT.Rows(i)("kdkasir"))
        Next
        cmbPetugasTab2.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbPetugasTab2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub cariBagianTab1()
        Dim cari As String = InStr(cmbBagianTab1.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbBagianTab1.Text, "|", -1, CompareMethod.Binary)
            kdBagianTab1 = Trim((ary(1)))
            nmBagianTab1 = Trim((ary(0)))
        End If
    End Sub

    Sub cariBagianTab2()
        Dim cari As String = InStr(cmbBagianTab2.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbBagianTab2.Text, "|", -1, CompareMethod.Binary)
            kdBagianTab2 = Trim((ary(1)))
            nmBagianTab2 = Trim((ary(0)))
        End If
    End Sub

    Sub cariPetugas()
        Dim cari As String = InStr(cmbPetugasTab2.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbPetugasTab2.Text, "|", -1, CompareMethod.Binary)
            kdPetugas = Trim((ary(1)))
            nmPetugas = Trim((ary(0)))
        End If
    End Sub

    Sub tampilPerTanggal()
        cariBagianTab1()
        Try
            'konek()
            DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, RTRIM(LTRIM(nmbagian)) as nmbagian, RTRIM(LTRIM(nmkasir)) as nmkasir, tanggal, nota, RTRIM(LTRIM(nmkons)) as nmkons, RTRIM(LTRIM(nama)) as nama, RTRIM(LTRIM(nmdokter)) as nmdokter, jmlharga1, potongan, jmlharga2, bulat, jmlnet, posting, diserahkan FROM ap_jualbbs1 where tanggal >='" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' and tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' AND kdbagian='" & kdBagianTab1 & "' ORDER BY tanggal,nota", CONN)
            DS = New DataSet
            DA.Fill(DS, "notaPerTanggal")
            BDPertanggal.DataSource = DS
            BDPertanggal.DataMember = "notaPerTanggal"
            With GridTab1
                .DataSource = Nothing
                .DataSource = BDPertanggal
                .Columns(0).HeaderText = "Kode Depo"
                .Columns(1).HeaderText = "Nama Bagian"
                .Columns(2).HeaderText = "Petugas"
                .Columns(3).HeaderText = "Tanggal"
                .Columns(4).HeaderText = "Nota"
                .Columns(5).HeaderText = "Jenis Konsumen"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(7).HeaderText = "Nama Dokter"
                .Columns(8).HeaderText = "Jumlah Total"
                .Columns(8).DefaultCellStyle.Format = "N2"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(9).HeaderText = "Potongan"
                .Columns(9).DefaultCellStyle.Format = "N2"
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Jumlah Harga"
                .Columns(10).DefaultCellStyle.Format = "N2"
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).HeaderText = "Bulat"
                .Columns(11).DefaultCellStyle.Format = "N2"
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).HeaderText = "Jumlah Harga Jual Bulat"
                .Columns(12).DefaultCellStyle.Format = "N2"
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).HeaderText = "Posting"
                .Columns(14).HeaderText = "Diserahkan"
                .Columns(0).Width = 40
                .Columns(1).Width = 120
                .Columns(2).Width = 100
                .Columns(3).Width = 75
                .Columns(4).Width = 100
                .Columns(5).Width = 80
                .Columns(6).Width = 150
                .Columns(7).Width = 150
                .Columns(8).Width = 75
                .Columns(9).Width = 75
                .Columns(10).Width = 75
                .Columns(11).Width = 75
                .Columns(12).Width = 75
                .Columns(13).Width = 50
                .Columns(14).Width = 70
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            txtNota.DecimalValue = GridTab1.Rows.Count() - 1
            JumlahHarga1Tab1()
            JumlahPotonganTab1()
            JumlahHarga2Tab1()
            JumlahPembulatanTab1()
            JumlahHargaJualTab1()
            txtNamaPasien.Enabled = True
            cmbDiserahkan.Enabled = True
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilPerPetugas()
        cariBagianTab2()
        cariPetugas()
        Try
            'konek()
            DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, RTRIM(LTRIM(nmbagian)) as nmbagian, RTRIM(LTRIM(nmkasir)) as nmkasir, tanggal, nota, RTRIM(LTRIM(nmkons)) as nmkons, RTRIM(LTRIM(nama)) as nama, RTRIM(LTRIM(nmdokter)) as nmdokter, jmlharga1, potongan, jmlharga2, bulat, jmlnet, posting, diserahkan FROM ap_jualbbs1 where tanggal >='" & Format(DTPTanggalAwalTab2.Value, "yyyy/MM/dd") & "' and tanggal <= '" & Format(DTPTanggalAkhirTab2.Value, "yyyy/MM/dd") & "' AND kdbagian='" & kdBagianTab2 & "' and kdkasir='" & kdPetugas & "' ORDER BY tanggal,nota", CONN)
            DS = New DataSet
            DA.Fill(DS, "notaPerKasir")
            BDPerKasir.DataSource = DS
            BDPerKasir.DataMember = "notaPerKasir"
            With GridTab2
                .DataSource = Nothing
                .DataSource = BDPerKasir
                .Columns(0).HeaderText = "Kode Depo"
                .Columns(1).HeaderText = "Nama Bagian"
                .Columns(2).HeaderText = "Petugas"
                .Columns(3).HeaderText = "Tanggal"
                .Columns(4).HeaderText = "Nota"
                .Columns(5).HeaderText = "Jenis Konsumen"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(7).HeaderText = "Nama Dokter"
                .Columns(8).HeaderText = "Jumlah Total"
                .Columns(8).DefaultCellStyle.Format = "N2"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(9).HeaderText = "Potongan"
                .Columns(9).DefaultCellStyle.Format = "N2"
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Jumlah Harga"
                .Columns(10).DefaultCellStyle.Format = "N2"
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).HeaderText = "Pembulatan"
                .Columns(11).DefaultCellStyle.Format = "N2"
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).HeaderText = "Jumlah Harga Jual Bulat"
                .Columns(12).DefaultCellStyle.Format = "N2"
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).HeaderText = "Posting"
                .Columns(14).HeaderText = "Diserahkan"
                .Columns(0).Width = 40
                .Columns(1).Width = 120
                .Columns(2).Width = 100
                .Columns(3).Width = 75
                .Columns(4).Width = 100
                .Columns(5).Width = 80
                .Columns(6).Width = 150
                .Columns(7).Width = 150
                .Columns(8).Width = 75
                .Columns(9).Width = 75
                .Columns(10).Width = 75
                .Columns(11).Width = 75
                .Columns(12).Width = 75
                .Columns(13).Width = 50
                .Columns(14).Width = 70
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            txtNota2.DecimalValue = GridTab2.Rows.Count() - 1
            JumlahHarga1Tab2()
            JumlahPotonganTab2()
            JumlahHarga2Tab2()
            JumlahPembulatanTab2()
            JumlahHargaJualTab2()
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub JumlahHarga1Tab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("jmlharga1").Value
        Next
        txtJumlahHarga1Tab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHarga1Tab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("jmlharga1").Value
        Next
        txtJumlahHarga1Tab2.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPotonganTab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("potongan").Value
        Next
        txtPotonganTab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPotonganTab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("potongan").Value
        Next
        txtPotonganTab2.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHarga2Tab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("jmlharga2").Value
        Next
        txtJumlahHarga2Tab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHarga2Tab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("jmlharga2").Value
        Next
        txtJumlahHarga2Tab2.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPembulatanTab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("bulat").Value
        Next
        txtPembulatanTab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPembulatanTab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("bulat").Value
        Next
        txtPembulatanTab2.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHargaJualTab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("jmlnet").Value
        Next
        txtJumlahHargaJualTab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHargaJualTab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("jmlnet").Value
        Next
        txtJumlahHargaJualTab2.DecimalValue = HitungTotal
    End Sub

    Private Sub FormLaporanNotaPenjualanObatBebas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub FormLaporanNotaPenjualanObatBebas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosongkan1()
        Kosongkan2()
        ListBagian1()
        ListBagian2()
        ListPetugas()
    End Sub

    Private Sub btnProsesTab1_Click(sender As Object, e As EventArgs) Handles btnProsesTab1.Click
        tampilPerTanggal()
    End Sub

    Private Sub btnProsesTab2_Click(sender As Object, e As EventArgs) Handles btnProsesTab2.Click
        tampilPerPetugas()
    End Sub

    Private Sub btnBaruTab2_Click(sender As Object, e As EventArgs) Handles btnBaruTab2.Click
        Kosongkan2()
    End Sub

    Private Sub btnBaruTab1_Click(sender As Object, e As EventArgs) Handles btnBaruTab1.Click
        Kosongkan1()
    End Sub

    Private Sub cmbBagianTab1_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBagianTab1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTPTanggalAwalTab1.Focus()
        End If
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

    Private Sub cmbBagianTab2_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBagianTab2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbPetugasTab2.Focus()
        End If
    End Sub

    Private Sub cmbBagianTab2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbBagianTab2.SelectedIndexChanged

    End Sub

    Private Sub cmbPetugasTab2_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPetugasTab2.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTPTanggalAwalTab2.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAwalTab2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAwalTab2.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPTanggalAkhirTab2.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAkhirTab2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAkhirTab2.KeyPress
        If e.KeyChar = Chr(13) Then
            btnProsesTab2.Focus()
        End If
    End Sub

    Private Sub txtNamaPasien_TextChanged(sender As Object, e As EventArgs) Handles txtNamaPasien.TextChanged
        BDPertanggal.Filter = "nama like '%" & txtNamaPasien.Text & "%'"
    End Sub

    Private Sub cmbDiserahkan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiserahkan.SelectedIndexChanged
        If cmbDiserahkan.SelectedIndex = 0 Then
            BDPertanggal.RemoveFilter()
        ElseIf cmbDiserahkan.SelectedIndex = 1 Then
            BDPertanggal.RemoveFilter()
            BDPertanggal.Filter = "diserahkan = 'S'"
        ElseIf cmbDiserahkan.SelectedIndex = 2 Then
            BDPertanggal.RemoveFilter()
            BDPertanggal.Filter = "diserahkan = 'B'"
        End If
    End Sub

    Private Sub btnExcelTab1_Click(sender As Object, e As EventArgs) Handles btnExcelTab1.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            cariBagianTab1()
            Try
                Dim dtXls As New DataTable
                With dtXls
                    .Columns.Add("tanggal")
                    .Columns.Add("nmkasir")
                    .Columns.Add("nota")
                    .Columns.Add("nmkons")
                    .Columns.Add("nama")
                    .Columns.Add("nmdokter")
                    .Columns.Add("jmlharga1")
                    .Columns.Add("potongan")
                    .Columns.Add("jmlharga2")
                    .Columns.Add("bulat")
                    .Columns.Add("jmlnet")
                    .Columns.Add("posting")
                    .Columns.Add("diserahkan")
                End With

                For i = 0 To GridTab1.RowCount - 2
                    If Not IsDBNull(GridTab1.Rows(i).Cells(0).Value) Then
                        dtXls.Rows.Add(GridTab1.Rows(i).Cells("tanggal").Value, GridTab1.Rows(i).Cells("nmkasir").Value, GridTab1.Rows(i).Cells("nota").Value, GridTab1.Rows(i).Cells("nmkons").Value, GridTab1.Rows(i).Cells("nama").Value, GridTab1.Rows(i).Cells("nmdokter").Value, GridTab1.Rows(i).Cells("jmlharga1").Value, GridTab1.Rows(i).Cells("potongan").Value, GridTab1.Rows(i).Cells("jmlharga2").Value, GridTab1.Rows(i).Cells("bulat").Value, GridTab1.Rows(i).Cells("jmlnet").Value, GridTab1.Rows(i).Cells("posting").Value, GridTab1.Rows(i).Cells("diserahkan").Value)
                    End If
                Next
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanNotaPenjualanBebasPerTanggalXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab1.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab1.Text
                sheet.Range("B9").Text = nmBagianTab1
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Nota Penjualan Bebas Per Tanggal.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Nota Penjualan Bebas Per Tanggal.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnExcelTab2_Click(sender As Object, e As EventArgs) Handles btnExcelTab2.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            cariBagianTab2()
            Try
                Dim dtXls As New DataTable
                With dtXls
                    .Columns.Add("tanggal")
                    .Columns.Add("nmkasir")
                    .Columns.Add("nota")
                    .Columns.Add("nmkons")
                    .Columns.Add("nama")
                    .Columns.Add("nmdokter")
                    .Columns.Add("jmlharga1")
                    .Columns.Add("potongan")
                    .Columns.Add("jmlharga2")
                    .Columns.Add("bulat")
                    .Columns.Add("jmlnet")
                    .Columns.Add("posting")
                    .Columns.Add("diserahkan")
                End With

                For i = 0 To GridTab2.RowCount - 2
                    If Not IsDBNull(GridTab2.Rows(i).Cells(0).Value) Then
                        dtXls.Rows.Add(GridTab2.Rows(i).Cells("tanggal").Value, GridTab2.Rows(i).Cells("nmkasir").Value, GridTab2.Rows(i).Cells("nota").Value, GridTab2.Rows(i).Cells("nmkons").Value, GridTab2.Rows(i).Cells("nama").Value, GridTab2.Rows(i).Cells("nmdokter").Value, GridTab2.Rows(i).Cells("jmlharga1").Value, GridTab2.Rows(i).Cells("potongan").Value, GridTab2.Rows(i).Cells("jmlharga2").Value, GridTab2.Rows(i).Cells("bulat").Value, GridTab2.Rows(i).Cells("jmlnet").Value, GridTab2.Rows(i).Cells("posting").Value, GridTab2.Rows(i).Cells("diserahkan").Value)
                    End If
                Next
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanNotaPenjualanBebasPerTanggalXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab2.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab2.Text
                sheet.Range("B9").Text = nmBagianTab2
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Nota Penjualan Bebas Per Petugas.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Nota Penjualan Bebas Per Petugas.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Class