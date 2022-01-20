Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports Syncfusion.XlsIO

Public Class FormLaporanHarianJualBebas
    Inherits Office2010Form
    Dim kdBagian, nmBagian As String
    Dim DSHarianBebas, DSHitungRacik, DSHitungBebas As New DataSet
    Dim BDHarianBebas, BDHitungRacik, BDHitungBebas As New BindingSource
    Dim DRWHarianBebas, DRWHitungRacik, DRWHitungBebas As DataRowView

    Sub Kosongkan1()
        TglServer()
        cmbBagianTab1.Text = ""
        DTPTanggalAwalTab1.Value = TanggalServer
        DTPTanggalAkhirTab1.Value = TanggalServer
        DSHarianBebas = Table.BuatTabelLaporanHarianJualBebas("LaporanHarianBebas")
        DSHarianBebas.Clear()
        GridObat.BackgroundColor = Color.Azure
        GridObat.DataSource = Nothing
        txtNota.DecimalValue = 0
        txtTotalObat.DecimalValue = 0
        txtTotalSeluruh.DecimalValue = 0
        cmbBagianTab1.Focus()
    End Sub

    Sub AturGriddetailBarang()
        With GridObat
            .Columns(0).HeaderText = "Unit Far"
            .Columns(1).HeaderText = "Petugas"
            .Columns(2).HeaderText = "Tanggal"
            .Columns(3).HeaderText = "Nota"
            .Columns(4).HeaderText = "Jenis Konsumen"
            .Columns(5).HeaderText = "Nama Pasien"
            .Columns(6).HeaderText = "Kode Dokter"
            .Columns(7).HeaderText = "Nama Dokter"
            .Columns(8).HeaderText = "L"
            .Columns(8).DefaultCellStyle.Format = "N0"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).HeaderText = "R"
            .Columns(9).DefaultCellStyle.Format = "N0"
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(10).HeaderText = "Obat"
            .Columns(10).DefaultCellStyle.Format = "N2"
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).HeaderText = "Total"
            .Columns(11).DefaultCellStyle.Format = "N2"
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).Width = 50
            .Columns(1).Width = 150
            .Columns(2).Width = 75
            .Columns(3).Width = 100
            .Columns(4).Width = 80
            .Columns(5).Width = 180
            .Columns(6).Width = 50
            .Columns(7).Width = 180
            .Columns(8).Width = 30
            .Columns(9).Width = 30
            .Columns(10).Width = 85
            .Columns(11).Width = 85
            .Columns(6).Visible = False
            .ReadOnly = True
        End With
    End Sub

    Sub ListBagian()
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

    Sub cariBagianTab1()
        Dim cari As String = InStr(cmbBagianTab1.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbBagianTab1.Text, "|", -1, CompareMethod.Binary)
            kdBagian = Trim((ary(1)))
            nmBagian = Trim((ary(0)))
        End If
    End Sub

    Sub TotalObat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalobt").Value
        Next
        txtTotalObat.DecimalValue = HitungTotal
    End Sub

    Sub TotalSeluruh()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalhrg").Value
        Next
        txtTotalSeluruh.DecimalValue = HitungTotal
    End Sub

    Sub tampilHarian1()
        cariBagianTab1()
        Try
            'konek()
            DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, RTRIM(LTRIM(nmkasir)) as petugas, tanggal, RTRIM(LTRIM(nota)) as nonota, RTRIM(LTRIM(nmkons)) as konsumen, RTRIM(LTRIM(nama)) as nama, kddokter, RTRIM(LTRIM(nmdokter)) as nmdokter, 1 as lembar, 0 as racik, 0 as totalobt, jmlnet as totalhrg FROM ap_jualbbs1 where kdbagian='" & kdBagian & "' and tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "'  ORDER BY tanggal,nota", CONN)
            DSHarianBebas = New DataSet
            DA.Fill(DSHarianBebas, "LaporanHarianBebas")
            BDHarianBebas.DataSource = DSHarianBebas
            BDHarianBebas.DataMember = "LaporanHarianBebas"

            '''''''''''menghitung obat racik
            'konek()
            DA = New OleDb.OleDbDataAdapter("select tanggal, RTRIM(LTRIM(nota)) as nonota,racik,jmlracik from ap_jualbbs2 where kdbagian='" & kdBagian & "' and tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' AND kd_jns_obat='1'", CONN)
            DSHitungRacik = New DataSet
            DA.Fill(DSHitungRacik, "HitungRacik")
            BDHitungRacik.DataSource = DSHitungRacik
            BDHitungRacik.DataMember = "HitungRacik"

            If BDHarianBebas.Count > 0 Then
                BDHarianBebas.MoveFirst()
                For i = 1 To BDHarianBebas.Count
                    DRWHarianBebas = BDHarianBebas.Current
                    DRWHitungRacik = BDHitungRacik.Current
                    DRWHarianBebas("racik") = DSHitungRacik.Tables("HitungRacik").Compute("Sum(jmlracik)", "nonota = '" & Trim(DRWHarianBebas.Item("nonota").ToString) & "'")
                    If IsDBNull(DRWHarianBebas("racik")) Then
                        DRWHarianBebas("racik") = 0
                    End If
                    BDHarianBebas.MoveNext()
                Next
            End If

            '''''''''''menghitung obat bebas
            'konek()
            DA = New OleDb.OleDbDataAdapter("select tanggal,RTRIM(LTRIM(nota)) as nonota,kd_jns_obat,jmlnet from ap_jualbbs2 where kdbagian='" & kdBagian & "' and tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' and kd_jns_obat=1", CONN)
            DSHitungBebas = New DataSet
            DA.Fill(DSHitungBebas, "HitungBebas")
            BDHitungBebas.DataSource = DSHitungBebas
            BDHitungBebas.DataMember = "HitungBebas"

            If BDHarianBebas.Count > 0 Then
                BDHarianBebas.MoveFirst()
                For i = 1 To BDHarianBebas.Count
                    DRWHarianBebas = BDHarianBebas.Current
                    DRWHitungBebas = BDHitungBebas.Current
                    DRWHarianBebas("totalobt") = DSHitungBebas.Tables("HitungBebas").Compute("Sum(jmlnet)", "nonota = '" & Trim(DRWHarianBebas.Item("nonota").ToString) & "'")
                    If IsDBNull(DRWHarianBebas("totalobt")) Then
                        DRWHarianBebas("totalobt") = 0
                    Else
                        Dim a As Decimal
                        a = DSHitungBebas.Tables("HitungBebas").Compute("Sum(jmlnet)", "nonota = '" & Trim(DRWHarianBebas.Item("nonota").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWHarianBebas("totalobt") = Math.Ceiling(a)
                        Else
                            DRWHarianBebas("totalobt") = a
                        End If
                    End If
                    BDHarianBebas.MoveNext()
                Next
            End If

            BDHarianBebas.RemoveFilter()
            GridObat.DataSource = Nothing
            GridObat.DataSource = BDHarianBebas
            txtNota.DecimalValue = GridObat.Rows.Count() - 1
            TotalObat()
            TotalSeluruh()
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormLaporanHarianJualBebas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosongkan1()
        ListBagian()
    End Sub

    Private Sub btnProsesTab1_Click(sender As Object, e As EventArgs) Handles btnProsesTab1.Click
        tampilHarian1()
        AturGriddetailBarang()
    End Sub

    Private Sub btnBaruTab1_Click(sender As Object, e As EventArgs) Handles btnBaruTab1.Click
        Kosongkan1()
    End Sub

    Private Sub btnExcelTab1_Click(sender As Object, e As EventArgs) Handles btnExcelTab1.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'GridTab1.DataSource = DS.Tables("permintaanGudangPerTanggal")
            Try
                Dim dtXls As New DataTable
                With dtXls
                    .Columns.Add("tanggal")
                    .Columns.Add("petugas")
                    .Columns.Add("nonota")
                    .Columns.Add("konsumen")
                    .Columns.Add("nama")
                    .Columns.Add("nmdokter")
                    .Columns.Add("lembar")
                    .Columns.Add("racik")
                    .Columns.Add("totalobt")
                    .Columns.Add("totalhrg")
                   
                End With

                For i = 0 To GridObat.RowCount - 2
                    If Not IsDBNull(GridObat.Rows(i).Cells(0).Value) Then
                        dtXls.Rows.Add(GridObat.Rows(i).Cells("tanggal").Value, GridObat.Rows(i).Cells("petugas").Value, GridObat.Rows(i).Cells("nonota").Value, GridObat.Rows(i).Cells("konsumen").Value, GridObat.Rows(i).Cells("nama").Value, GridObat.Rows(i).Cells("nmdokter").Value, GridObat.Rows(i).Cells("lembar").Value, GridObat.Rows(i).Cells("racik").Value, GridObat.Rows(i).Cells("totalobt").Value, GridObat.Rows(i).Cells("totalhrg").Value)
                    End If
                Next

                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanHarianPenjualanBebasXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab1.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab1.Text
                sheet.Range("B9").Text = nmBagian
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Harian Penjualan Bebas.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Harian Penjualan Bebas.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
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

End Class