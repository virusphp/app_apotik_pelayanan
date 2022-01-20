Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports Syncfusion.XlsIO

Public Class FormLaporanNotaPenjualanResep
    Inherits Office2010Form
    Dim kdBagian, nmBagian, kdPenjamin, nmPenjamin, JenisPasien, XopPenjamin, XopStatus As String
    Dim BDLaporanNotaPenjualanResep As New BindingSource
    Dim DSLaporanNotaPenjualanResep As New DataSet
    Dim DRWLaporanNotaPenjualanResep As DataRowView

    Sub Kosongkan()
        TglServer()
        cmbPenjamin.Text = ""
        cmbBagian.Text = ""
        cmbJenisPasien.Text = ""
        DTPTanggalAwal.Value = TanggalServer
        DTPTanggalAkhir.Value = TanggalServer
        GridObat.DataSource = Nothing
        GridObat.BackgroundColor = Color.Azure
        txtNota.DecimalValue = 0
        txtTotalPaket.DecimalValue = 0
        txtTotalPaketBulat.DecimalValue = 0
        txtTotalNonPaket.DecimalValue = 0
        txtTotalNonPaketBulat.DecimalValue = 0
        txtTotalDijamin.DecimalValue = 0
        txtTotalDijaminBulat.DecimalValue = 0
        txtTotalIurBayar.DecimalValue = 0
        txtTotalIurBayarBulat.DecimalValue = 0
        txtCariPasien.Enabled = False
        txtCariPasien.Clear()
        rNama.Checked = True
        cmbPenjamin.Focus()
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

    Sub ListPenjamin()
        'konek()
        CMD = New OleDb.OleDbCommand("select kd_penjamin, nama_penjamin from Penjamin order by nama_penjamin", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbPenjamin.Items.Clear()
        cmbPenjamin.Items.Add("")
        cmbPenjamin.Items.Add("Semua")
        cmbPenjamin.Items.Add("UMUM")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbPenjamin.Items.Add(DT.Rows(i)("nama_penjamin") & "|" & DT.Rows(i)("kd_penjamin"))
        Next
        cmbPenjamin.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbPenjamin.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListJenisPasien()
        cmbJenisPasien.Items.Clear()
        cmbJenisPasien.Items.Add("")
        cmbJenisPasien.Items.Add("Semua")
        cmbJenisPasien.Items.Add("Rawat Inap")
        cmbJenisPasien.Items.Add("Rawat Jalan")
        cmbJenisPasien.Items.Add("Rawat Darurat")
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

    Sub cariPenjamin()
        Dim cari As String = InStr(cmbPenjamin.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbPenjamin.Text, "|", -1, CompareMethod.Binary)
            kdPenjamin = Trim((ary(1)))
            nmPenjamin = Trim((ary(0)))
        End If
    End Sub

    Sub cariJenisPasien()
        If cmbJenisPasien.SelectedIndex = 2 Then
            JenisPasien = "RI"
        ElseIf cmbJenisPasien.SelectedIndex = 3 Then
            JenisPasien = "RJ"
        ElseIf cmbJenisPasien.SelectedIndex = 4 Then
            JenisPasien = "RD"
        End If
    End Sub

    Sub tampilLaporan()
        cariBagian()
        cariJenisPasien()
        If cmbPenjamin.Text = "Semua" Then
            XopPenjamin = "<>"
        Else
            XopPenjamin = "="
        End If
        If cmbJenisPasien.Text = "Semua" Then
            XopStatus = "<>"
        Else
            XopStatus = "="
        End If
        If cmbPenjamin.Text = "UMUM" Then
            kdPenjamin = "UMUM"
        Else
            cariPenjamin()
        End If

        Try
            'konek()
            DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, stsrawat, RTRIM(LTRIM(nmkasir)) as nmkasir, stsresep, tanggal, notaresep, no_reg ,no_rm, RTRIM(LTRIM(nama_pasien)) as nama_pasien, RTRIM(LTRIM(nmdokter)) as nmdokter, RTRIM(LTRIM(nm_penjamin)) as nm_penjamin, totalpaket, totalpaket_bulat, totalnonpaket, totalnonpaket_bulat, totaldijamin, totaldijamin_bulat, totalselisih_bayar, totalselisih_bayar_bulat, kd_sub_unit, RTRIM(LTRIM(nama_sub_unit)) as nama_sub_unit FROM ap_jualr1 where kdbagian='" & kdBagian & "' and kd_penjamin" & XopPenjamin & "'" & kdPenjamin & "' and stsrawat" & XopStatus & "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' ORDER BY tanggal,notaresep", CONN)
            DSLaporanNotaPenjualanResep = New DataSet
            DA.Fill(DSLaporanNotaPenjualanResep, "LaporanNotaPenjualanResep")
            BDLaporanNotaPenjualanResep.DataSource = DSLaporanNotaPenjualanResep
            BDLaporanNotaPenjualanResep.DataMember = "LaporanNotaPenjualanResep"
            GridObat.DataSource = Nothing
            GridObat.DataSource = BDLaporanNotaPenjualanResep

            txtNota.DecimalValue = GridObat.Rows.Count() - 1
            TotalPaket()
            TotalPaketBulat()
            TotalNonPaket()
            TotalNonPaketBulat()
            TotalDijamin()
            TotalDijaminBulat()
            TotalIurBayar()
            TotalIurBayarBulat()
            txtCariPasien.Enabled = True
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub TotalPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalpaket").Value
        Next
        txtTotalPaket.DecimalValue = HitungTotal
    End Sub

    Sub TotalPaketBulat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalpaket_bulat").Value
        Next
        txtTotalPaketBulat.DecimalValue = HitungTotal
    End Sub

    Sub TotalNonPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalnonpaket").Value
        Next
        txtTotalNonPaket.DecimalValue = HitungTotal
    End Sub

    Sub TotalNonPaketBulat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalnonpaket_bulat").Value
        Next
        txtTotalNonPaketBulat.DecimalValue = HitungTotal
    End Sub

    Sub TotalDijamin()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totaldijamin").Value
        Next
        txtTotalDijamin.DecimalValue = HitungTotal
    End Sub

    Sub TotalDijaminBulat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totaldijamin_bulat").Value
        Next
        txtTotalDijaminBulat.DecimalValue = HitungTotal
    End Sub

    Sub TotalIurBayar()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalselisih_bayar").Value
        Next
        txtTotalIurBayar.DecimalValue = HitungTotal
    End Sub

    Sub TotalIurBayarBulat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalselisih_bayar_bulat").Value
        Next
        txtTotalIurBayarBulat.DecimalValue = HitungTotal
    End Sub

    Sub AturGriddetailBarang()
        With GridObat
            .Columns(0).HeaderText = "Unit Far"
            .Columns(1).HeaderText = "Status Rawat"
            .Columns(2).HeaderText = "Petugas"
            .Columns(3).HeaderText = "Status Resep"
            .Columns(4).HeaderText = "Tanggal"
            .Columns(5).HeaderText = "Nota Resep"
            .Columns(6).HeaderText = "No Register"
            .Columns(7).HeaderText = "No RM"
            .Columns(8).HeaderText = "Nama Pasien"
            .Columns(9).HeaderText = "Nama Dokter"
            .Columns(10).HeaderText = "Penjamin"
            .Columns(11).HeaderText = "Total Paket"
            .Columns(11).DefaultCellStyle.Format = "N2"
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(12).HeaderText = "Total Paket Bulat"
            .Columns(12).DefaultCellStyle.Format = "N2"
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(13).HeaderText = "Total Non Paket"
            .Columns(13).DefaultCellStyle.Format = "N2"
            .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(14).HeaderText = "Total Non Paket Bulat"
            .Columns(14).DefaultCellStyle.Format = "N2"
            .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(15).HeaderText = "Total Dijamin"
            .Columns(15).DefaultCellStyle.Format = "N2"
            .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(16).HeaderText = "Total Dijamin Bulat"
            .Columns(16).DefaultCellStyle.Format = "N2"
            .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(17).HeaderText = "Total Iur Bayar"
            .Columns(17).DefaultCellStyle.Format = "N2"
            .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(18).HeaderText = "Total Iur Bayar Bulat"
            .Columns(18).DefaultCellStyle.Format = "N2"
            .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(19).HeaderText = "Kode Sub Unit"
            .Columns(20).HeaderText = "Nama Sub Unit"
            .Columns(0).Width = 50
            .Columns(1).Width = 50
            .Columns(2).Width = 100
            .Columns(3).Width = 75
            .Columns(4).Width = 75
            .Columns(5).Width = 90
            .Columns(6).Width = 90
            .Columns(7).Width = 60
            .Columns(8).Width = 160
            .Columns(9).Width = 160
            .Columns(10).Width = 150
            .Columns(11).Width = 85
            .Columns(12).Width = 85
            .Columns(13).Width = 85
            .Columns(14).Width = 85
            .Columns(15).Width = 85
            .Columns(16).Width = 85
            .Columns(17).Width = 85
            .Columns(18).Width = 85
            .Columns(20).Width = 150
            .Columns(19).Visible = False
            .ReadOnly = True
        End With
    End Sub

    Private Sub FormLaporanNotaPenjualanResep_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormLaporanNotaPenjualanResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosongkan()
        ListBagian()
        ListPenjamin()
        ListJenisPasien()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        tampilLaporan()
        AturGriddetailBarang()
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
        If rNama.Checked = True Then
            BDLaporanNotaPenjualanResep.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
        Else
            BDLaporanNotaPenjualanResep.Filter = "no_rm like '%" & txtCariPasien.Text & "%'"
        End If
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Kosongkan()
    End Sub

    Private Sub cmbPenjamin_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPenjamin.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbBagian.Focus()
        End If
    End Sub

    Private Sub cmbBagian_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBagian.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbJenisPasien.Focus()
        End If
    End Sub

    Private Sub cmbJenisPasien_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbJenisPasien.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTPTanggalAwal.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAkhir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAkhir.KeyPress
        If e.KeyChar = Chr(13) Then
            btnProses.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAwal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAwal.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPTanggalAkhir.Focus()
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'GridTab1.DataSource = DS.Tables("permintaanGudangPerTanggal")
            cariBagian()
            Try
                Dim dtXls As New DataTable
                With dtXls
                    .Columns.Add("tanggal")
                    .Columns.Add("nmkasir")
                    .Columns.Add("stsresep")
                    .Columns.Add("notaresep")
                    .Columns.Add("no_reg")
                    .Columns.Add("no_rm")
                    .Columns.Add("nama_pasien")
                    .Columns.Add("nmdokter")
                    .Columns.Add("nm_penjamin")
                    .Columns.Add("totalpaket")
                    .Columns.Add("totalpaket_bulat")
                    .Columns.Add("totalnonpaket")
                    .Columns.Add("totalnonpaket_bulat")
                    .Columns.Add("totaldijamin")
                    .Columns.Add("totaldijamin_bulat")
                    .Columns.Add("totalselisih_bayar")
                    .Columns.Add("totalselisih_bayar_bulat")
                    .Columns.Add("nama_sub_unit")

                End With

                For i = 0 To GridObat.RowCount - 2
                    If Not IsDBNull(GridObat.Rows(i).Cells(0).Value) Then
                        dtXls.Rows.Add(GridObat.Rows(i).Cells("tanggal").Value, GridObat.Rows(i).Cells("nmkasir").Value, GridObat.Rows(i).Cells("stsresep").Value, GridObat.Rows(i).Cells("notaresep").Value, GridObat.Rows(i).Cells("no_reg").Value, GridObat.Rows(i).Cells("no_rm").Value, GridObat.Rows(i).Cells("nama_pasien").Value, GridObat.Rows(i).Cells("nmdokter").Value, GridObat.Rows(i).Cells("nm_penjamin").Value, GridObat.Rows(i).Cells("totalpaket").Value, GridObat.Rows(i).Cells("totalpaket_bulat").Value, GridObat.Rows(i).Cells("totalnonpaket").Value, GridObat.Rows(i).Cells("totalnonpaket_bulat").Value, GridObat.Rows(i).Cells("totaldijamin").Value, GridObat.Rows(i).Cells("totaldijamin_bulat").Value, GridObat.Rows(i).Cells("totalselisih_bayar").Value, GridObat.Rows(i).Cells("totalselisih_bayar_bulat").Value, GridObat.Rows(i).Cells("nama_sub_unit").Value)
                    End If
                Next

                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanNotaPenjualanResepXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwal.Text
                sheet.Range("B8").Text = DTPTanggalAkhir.Text
                sheet.Range("B9").Text = nmBagian
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Nota Penjualan Resep.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Nota Penjualan Resep.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbJenisPasien_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisPasien.SelectedIndexChanged

    End Sub
End Class