Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.ComponentModel
Imports Syncfusion.XlsIO

Public Class FormDaftarPermintaanResep
    Inherits Office2010Form
    Dim BDPermintaanObat As New BindingSource

    Sub tampilPermintaanObat()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat, 
                    DBSIMRM.dbo.RJ_Permintaan_Obat.No_Reg, DBSIMRM.dbo.RJ_Permintaan_Obat.No_RM, 
                    DBSIMRS.dbo.Pasien.nama_pasien, DBSIMRM.dbo.RJ_Permintaan_Obat.Tgl_Permintaan, 
                    DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Dokter, DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Sub_Unit, 
                    DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi, DBSIMRM.dbo.RJ_Permintaan_Obat.User_Id, 
                    DBSIMRS.dbo.Pegawai.nama_pegawai, DBSIMRS.dbo.Sub_Unit.nama_sub_unit, 
                    DBSIMRS.dbo.ap_seting_apotek.nmapo, 
                    CASE DBSIMRS.dbo.Pegawai.gelar_depan WHEN '-' THEN '' 
                    ELSE DBSIMRS.dbo.Pegawai.gelar_depan + '.' END + DBSIMRS.dbo.Pegawai.nama_pegawai + 
                    CASE DBSIMRS.dbo.Pegawai.gelar_belakang WHEN '-' THEN '' 
                    ELSE ', ' + DBSIMRS.dbo.Pegawai.gelar_belakang END AS Nama_Gelar, 
                    DBSIMRM.dbo.RJ_Permintaan_Obat.Status 
                    FROM DBSIMRM.dbo.RJ_Permintaan_Obat 
                    INNER JOIN DBSIMRS.dbo.Sub_Unit ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Sub_Unit = DBSIMRS.dbo.Sub_Unit.kd_sub_unit 
                    INNER JOIN DBSIMRS.dbo.Pegawai ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Dokter = DBSIMRS.dbo.Pegawai.kd_pegawai 
                    INNER JOIN DBSIMRS.dbo.ap_seting_apotek ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi = DBSIMRS.dbo.ap_seting_apotek.kdapo 
                    INNER JOIN DBSIMRS.dbo.Pasien ON DBSIMRM.dbo.RJ_Permintaan_Obat.No_RM = DBSIMRS.dbo.Pasien.no_RM 
                    WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi='" & pkdapo & "' 
                    AND (DBSIMRM.dbo.RJ_Permintaan_Obat.Tgl_Permintaan 
                    BETWEEN '" & Format(DTPTanggal1.Value, "yyyy/MM/dd") & "' AND '" & Format(DTPTanggal2.Value, "yyyy/MM/dd") & "')", CONN)
            DS = New DataSet
            DA.Fill(DS, "PermintaanObat")
            BDPermintaanObat.DataSource = DS
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
                .Columns(10).Width = 180
                .Columns(11).HeaderText = "Permintaan Dari Unit"
                .Columns(11).Width = 180
                .Columns(12).Visible = False
                .Columns(13).HeaderText = "Dokter Pemberi Resep"
                .Columns(13).Width = 180
                .Columns(14).Visible = False
                .ReadOnly = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub GridWarna()
        'For i As Integer = 0 To gridPermintaanObat.RowCount - 1
        '    If Val(gridPermintaanObat.Rows(i).Cells("status").Value) = "0" Then
        '        gridPermintaanObat.Rows(i).Cells("No_Permintaan_Obat").Style.BackColor = Color.Red
        '    End If
        'Next
        With gridPermintaanObat
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .ReadOnly = True
            For i As Integer = 0 To .RowCount - 1
                If .Rows(i).Cells("status").Value = 1 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                End If
            Next
        End With
    End Sub

    Private Sub FormDaftarPermintaanResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
    End Sub

    Private Sub btnProsesTab5_Click(sender As Object, e As EventArgs) Handles btnProsesTab5.Click
        tampilPermintaanObat()
        GridWarna()
    End Sub

    Private Sub btnBaruTab5_Click(sender As Object, e As EventArgs) Handles btnBaruTab5.Click
        gridPermintaanObat.DataSource = Nothing
    End Sub

    Private Sub gridPermintaanObat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPermintaanObat.CellContentClick
        If e.ColumnIndex = 0 Then
            FormDetailPermintaanObat.TampilResepObatJadi(gridPermintaanObat.Rows(e.RowIndex).Cells("no_Permintaan_Obat").Value)
            FormDetailPermintaanObat.TampilResepObatRacikan(gridPermintaanObat.Rows(e.RowIndex).Cells("no_Permintaan_Obat").Value)
            FormDetailPermintaanObat.txtNoPermintaan.Text = gridPermintaanObat.Rows(e.RowIndex).Cells("no_Permintaan_Obat").Value
            FormDetailPermintaanObat.txtRM.Text = gridPermintaanObat.Rows(e.RowIndex).Cells("No_RM").Value
            FormDetailPermintaanObat.txtNamaPasien.Text = gridPermintaanObat.Rows(e.RowIndex).Cells("nama_pasien").Value
            FormDetailPermintaanObat.ShowDialog()
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
        GridWarna()
    End Sub
End Class