Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.ComponentModel
Imports Syncfusion.XlsIO

Public Class FormDaftarPermintaanResep
    Inherits Office2010Form
    Public BDPermintaanObat As New BindingSource

    Public DRWPermintaanObat As DataRowView
    Dim CurrrentRow As Integer

    Public DSPermintaan As New DataSet
    Public DAPermintaan As OleDb.OleDbDataAdapter

    Sub tampilPermintaanObat()
        Try
            DAPermintaan = New OleDb.OleDbDataAdapter("SELECT 
                    po.No_Permintaan_Obat, 
                    po.No_Reg, 
                    po.No_RM, 
                    ps.nama_pasien, 
                    po.tgl_Permintaan, 
                    po.kd_dokter, 
                    po.kd_sub_unit, 
                    po.kd_farmasi, 
                    po.user_Id, 
                    pg.nama_pegawai  as nama_dokter, 
                    su.nama_sub_unit as nama_klinik, 
                    asa.nmapo, 
                    CASE pg.gelar_depan WHEN '-' THEN '' 
                        ELSE pg.gelar_depan + '.' END + pg.nama_pegawai +
                    CASE pg.gelar_belakang WHEN '-' THEN ''
                        ELSE ', ' + pg.gelar_belakang END AS Nama_Gelar,
                    po.status,
                    CASE po.iteration
                        WHEN '0' THEN 
                        'Tidak' 
                        ELSE
                        'Ya'
                    END as iteration,
                    po.iteration_banyak,
                    th.no_pengkajian_resep, 
                    th.keterangan, 
                    Case  isnull(th.no_pengkajian_resep,'') when '' then 'B' else 'S' end as status_pengkajian
                    FROM DBSIMRM.dbo.RJ_Permintaan_Obat as po 
                    LEFT JOIN DBSIMRM.dbo.rj_pengkajian_resep_header as th ON po.no_permintaan_obat = th.no_permintaan_obat 
                    INNER JOIN DBSIMRS.dbo.Sub_Unit as su ON po.Kd_Sub_Unit = su.kd_sub_unit 
                    INNER JOIN DBSIMRS.dbo.Pegawai as pg ON po.Kd_Dokter = pg.kd_pegawai 
                    INNER JOIN DBSIMRS.dbo.ap_seting_apotek as asa ON po.Kd_Farmasi = asa.kdapo 
                    INNER JOIN DBSIMRS.dbo.Pasien as ps ON po.No_RM = ps.no_RM 
                    WHERE po.Kd_Farmasi='" & pkdapo & "' 
                    AND (CONVERT(date,po.tgl_Permintaan) 
                    BETWEEN '" & Format(DTPTanggal1.Value, "yyyy/MM/dd") & "' AND '" & Format(DTPTanggal2.Value, "yyyy/MM/dd") & "')", CONN)
            DSPermintaan = New DataSet
            DAPermintaan.Fill(DSPermintaan, "PermintaanObat")
            BDPermintaanObat.RemoveFilter()
            BDPermintaanObat.DataSource = DSPermintaan
            BDPermintaanObat.DataMember = "PermintaanObat"
            txtTotalPermintanResep.Text = BDPermintaanObat.Count
            setHeaderGRID()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub setHeaderGRID()
        BDPermintaanObat.DataSource = DSPermintaan
        BDPermintaanObat.DataMember = "PermintaanObat"
        With gridPermintaanObat
            .DataSource = Nothing
            .DataSource = BDPermintaanObat
            .Columns(0).Width = 50
            .Columns(1).HeaderText = "No Permintaan"
            .Columns(1).Width = 100
            .Columns(2).HeaderText = "No Registrasi"
            .Columns(2).Width = 80
            .Columns(3).HeaderText = "No RM"
            .Columns(3).Width = 50
            .Columns(4).HeaderText = "Nama Pasien"
            .Columns(4).Width = 180
            .Columns(5).HeaderText = "Tanggal / Jam Permintaan"
            .Columns(5).Width = 110
            .Columns(6).Visible = False     'kdDokter
            .Columns(7).Visible = False     'kdSubUnit
            .Columns(8).Visible = False     'kdFarmasi
            .Columns(9).Visible = False     'userID
            .Columns(10).HeaderText = "Petugas Entry"
            .Columns(10).Width = 150
            .Columns(11).HeaderText = "Permintaan Dari Unit"
            .Columns(11).Width = 150
            .Columns(12).Visible = False
            .Columns(13).HeaderText = "Dokter Pemberi Resep"
            .Columns(13).Width = 180
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False
            .Columns(19).HeaderText = "Pengkajian"
            .Columns(19).DataPropertyName = "status_pengkajian"
            .Columns(19).Width = 80
            .ReadOnly = True

            .Refresh()
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .ReadOnly = True
            refreshWarnaGRID()
        End With
    End Sub

    Sub refreshWarnaGRID()
        With gridPermintaanObat
            For i As Integer = 0 To .RowCount - 1
                If .Rows(i).Cells("status").Value = 0 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.White
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                ElseIf .Rows(i).Cells("status").Value = 0 And IsDBNull(.Rows(i).Cells("no_pengkajian_resep").Value) = False Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.LightCyan
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                ElseIf .Rows(i).Cells("status").Value = 1 And IsDBNull(.Rows(i).Cells("no_pengkajian_resep").Value) = False Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                ElseIf .Rows(i).Cells("status").Value = 1 And IsDBNull(.Rows(i).Cells("no_pengkajian_resep").Value) Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.Gold
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                End If

                If .Rows(i).Cells("status_pengkajian").Value = "B" Then
                    .Rows(i).Cells("status_pengkajian").Style.BackColor = Color.Red
                ElseIf .Rows(i).Cells("status_pengkajian").Value = "S" Then
                    .Rows(i).Cells("status_pengkajian").Style.BackColor = Color.LawnGreen

                End If
            Next
        End With
    End Sub

    Public Sub updateStatusPengkajian(ByVal no_permintaan_obat As String, ByVal status_pengkajian As String, ByVal no_pengkajian_resep As String)
        BDPermintaanObat.Filter = "no_permintaan_obat = '" + no_permintaan_obat + "'"
        If BDPermintaanObat.Count > 0 Then
            BDPermintaanObat.MoveFirst()
            DRWPermintaanObat = BDPermintaanObat.Current
            DRWPermintaanObat("no_pengkajian_resep") = no_pengkajian_resep
            DRWPermintaanObat("status_pengkajian") = status_pengkajian
            DRWPermintaanObat.EndEdit()
        End If
        BDPermintaanObat.RemoveFilter()
        refreshWarnaGRID()

        If gridPermintaanObat.Rows.Count > CurrrentRow + 1 Then
            gridPermintaanObat.Focus()
            Me.gridPermintaanObat.Rows(CurrrentRow + 1).Selected = True
            Me.gridPermintaanObat.CurrentCell = gridPermintaanObat.Item(0, CurrrentRow + 1)
        End If
    End Sub


    Private Sub FormDaftarPermintaanResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
    End Sub

    Private Sub btnProsesTab5_Click(sender As Object, e As EventArgs) Handles btnProsesTab5.Click
        tampilPermintaanObat()
    End Sub

    Private Sub btnBaruTab5_Click(sender As Object, e As EventArgs) Handles btnBaruTab5.Click
        gridPermintaanObat.DataSource = Nothing
    End Sub

    Private Sub gridPermintaanObat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPermintaanObat.CellContentClick
        Dim senderGrid = DirectCast(sender, DataGridView)
        If TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn AndAlso
           e.RowIndex >= 0 Then
            CurrrentRow = e.RowIndex
            If e.ColumnIndex = 0 Then
                Dim NO_PERMINTAAN As String = gridPermintaanObat.Rows(e.RowIndex).Cells("no_permintaan_Obat").Value
                Dim NO_PENGKAJIAN_RESEP As String = If(IsDBNull(gridPermintaanObat.Rows(e.RowIndex).Cells("no_pengkajian_resep").Value), "", gridPermintaanObat.Rows(e.RowIndex).Cells("no_pengkajian_resep").Value)
                Dim NAMA_DOKTER As String = gridPermintaanObat.Rows(e.RowIndex).Cells("nama_dokter").Value
                Dim NAMA_KLINIK As String = gridPermintaanObat.Rows(e.RowIndex).Cells("nama_klinik").Value
                Dim ITERATION As String = gridPermintaanObat.Rows(e.RowIndex).Cells("iteration").Value
                Dim ITERATION_BANYAK As String = gridPermintaanObat.Rows(e.RowIndex).Cells("iteration_banyak").Value
                Dim NO_RM As String = gridPermintaanObat.Rows(e.RowIndex).Cells("no_rm").Value
                Dim NAMA_PASIEN As String = gridPermintaanObat.Rows(e.RowIndex).Cells("nama_pasien").Value

                BDPermintaanObat.Filter = "no_permintaan_obat = '" + NO_PERMINTAAN + "'"
                If MessageBox.Show("Apa anda ingin menelaah Resep dokter ? " + NAMA_DOKTER, "Informasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    FormDetailPermintaanObat.TampilResepObatJadi(NO_PERMINTAAN)
                    FormDetailPermintaanObat.TampilResepObatRacikan(NO_PERMINTAAN)
                    FormDetailPermintaanObat.TampilDataTelaah(NO_PERMINTAAN)
                    FormDetailPermintaanObat.TampilDataTelaahHeader(NO_PERMINTAAN)

                    FormDetailPermintaanObat.NO_PENGKAJIAN_RESEP_EDIT = NO_PENGKAJIAN_RESEP
                    FormDetailPermintaanObat.txtNoPermintaan.Text = NO_PERMINTAAN
                    FormDetailPermintaanObat.txtNamaDokter.Text = NAMA_DOKTER
                    FormDetailPermintaanObat.txtPoliklinik.Text = NAMA_KLINIK
                    FormDetailPermintaanObat.txtIterasi.Text = ITERATION
                    FormDetailPermintaanObat.txtBanyakIterasi.Text = ITERATION_BANYAK
                    FormDetailPermintaanObat.txtRM.Text = NO_RM
                    FormDetailPermintaanObat.txtNamaPasien.Text = NAMA_PASIEN
                    FormDetailPermintaanObat.ShowDialog()
                Else
                    BDPermintaanObat.RemoveFilter()
                    refreshWarnaGRID()
                End If

            End If
        End If


    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtExcel As New DataTable
                With dtExcel
                    .Columns.Add("No_Permintaan_Obat")
                    .Columns.Add("No_Reg")
                    .Columns.Add("No_RM")
                    .Columns.Add("nama_pasien")
                    .Columns.Add("Tgl_Permintaan")
                    .Columns.Add("nama_pegawai")
                    .Columns.Add("nama_sub_unit")
                    .Columns.Add("Nama_Gelar")
                End With

                For i = 0 To gridPermintaanObat.RowCount - 2
                    If Not IsDBNull(gridPermintaanObat.Rows(i).Cells(0).Value) Then
                        dtExcel.Rows.Add(gridPermintaanObat.Rows(i).Cells("No_Permintaan_Obat").Value, gridPermintaanObat.Rows(i).Cells("No_Reg").Value, gridPermintaanObat.Rows(i).Cells("No_RM").Value, gridPermintaanObat.Rows(i).Cells("nama_pasien").Value, gridPermintaanObat.Rows(i).Cells("Tgl_Permintaan").Value, gridPermintaanObat.Rows(i).Cells("nama_pegawai").Value, gridPermintaanObat.Rows(i).Cells("nama_sub_unit").Value, gridPermintaanObat.Rows(i).Cells("Nama_Gelar").Value)
                    End If
                Next
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\DaftarPermintaanObatXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggal1x.Text & " s/d " & DTPTanggal2x.Text
                sheet.Range("B8").Text = pnmapo
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtExcel)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Daftar Permintaan Obat.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Daftar Permintaan Obat.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtPencarian_TextChanged(sender As Object, e As EventArgs) Handles txtPencarian.TextChanged
        Dim ch(10) As Char
        Dim len As Integer
        len = txtPencarian.Text.Length
        ch = txtPencarian.Text.ToCharArray()
        If len > 2 Then
            For i = 0 To len - 1
                If Not IsNumeric(ch(i)) Then
                    BDPermintaanObat.Filter = "nama_pasien like '%" & txtPencarian.Text & "%'"
                Else
                    BDPermintaanObat.Filter = "no_rm like '%" & txtPencarian.Text & "%'"
                End If
            Next
        Else
            BDPermintaanObat.RemoveFilter()
        End If
        refreshWarnaGRID()
    End Sub

    Private Sub FormDaftarPermintaanResep_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Me.Dispose()
    End Sub
End Class