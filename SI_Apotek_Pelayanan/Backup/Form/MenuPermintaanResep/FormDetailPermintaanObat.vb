Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools

Public Class FormDetailPermintaanObat
    Inherits Office2010Form



    Public Sub TampilResepObatJadi(ByVal noPermintaan As String)
        DA = New OleDb.OleDbDataAdapter("SELECT DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_Barang, DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Nama_Obat, DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Obat, Pegawai.nama_pegawai, Sub_Unit.nama_sub_unit, ap_seting_apotek.nmapo, (DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Signa1 + ' x ' + DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Signa2) AS signa, DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_takaran, DBSIMRM.dbo.etiket_takaran.Nama_takaran, DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_waktu, DBSIMRM.dbo.etiket_waktu.nama_waktu, DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_ketminum, DBSIMRM.dbo.etiket_ketminum.nama_ketminum, DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Keterangan, DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Status_Obat FROM DBSIMRM.dbo.RJ_Permintaan_Obat INNER JOIN DBSIMRM.dbo.RJ_Permintaan_Obat_Detail ON DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat = DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.No_Permintaan_Obat INNER JOIN Sub_Unit ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Sub_Unit = Sub_Unit.kd_sub_unit INNER JOIN Pegawai ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Dokter = Pegawai.kd_pegawai INNER JOIN ap_seting_apotek ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi = ap_seting_apotek.kdapo INNER JOIN DBSIMRM.dbo.etiket_takaran ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_takaran = DBSIMRM.dbo.etiket_takaran.kd_takaran INNER JOIN DBSIMRM.dbo.etiket_waktu ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_waktu = DBSIMRM.dbo.etiket_waktu.kd_waktu INNER JOIN DBSIMRM.dbo.etiket_ketminum ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_ketminum = DBSIMRM.dbo.etiket_ketminum.kd_ketminum WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & noPermintaan & "'", CONN)
        DS = New DataSet
        DA.Fill(DS)
        With gridObatJadi
            .DataSource = DS.Tables(0)
            .Columns(0).HeaderText = "Kode Obat"
            .Columns(0).Width = 80
            .Columns(1).HeaderText = "Nama Obat"
            .Columns(1).Width = 200
            .Columns(2).HeaderText = "Jumlah Obat"
            .Columns(2).Width = 50
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(2).DefaultCellStyle.Format = "N2"
            .Columns(3).Visible = False
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).HeaderText = "Signa"
            .Columns(6).Width = 40
            .Columns(7).Visible = False
            .Columns(8).HeaderText = "Takaran"
            .Columns(8).Width = 150
            .Columns(9).Visible = False
            .Columns(10).HeaderText = "Waktu"
            .Columns(10).Width = 150
            .Columns(11).Visible = False
            .Columns(12).HeaderText = "Keterangan Minum"
            .Columns(12).Width = 150
            .Columns(13).HeaderText = "Keterangan"
            .Columns(13).Width = 150
            .Columns(14).Visible = False
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .ReadOnly = True
        End With
    End Sub

    Public Sub TampilResepObatRacikan(ByVal noPermintaan As String)
        DA = New OleDb.OleDbDataAdapter("Select DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Nama_Racikan, DBSIMRM.dbo.Jenis_Racikan_Obat.Nama_Jenis_Racikan, (DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Signa1 + ' x ' + DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Signa2) AS signa, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_takaran, DBSIMRM.dbo.etiket_takaran.Nama_takaran, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_waktu, DBSIMRM.dbo.etiket_waktu.nama_waktu, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_ketminum, DBSIMRM.dbo.etiket_ketminum.nama_ketminum, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Keterangan, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_Barang, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Nama_Obat, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Kekuatan_Obat, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Dosis_Obat, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Bungkus, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Obat, DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Urut_Racikan From DBSIMRM.dbo.RJ_Permintaan_Obat INNER Join Sub_Unit ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Sub_Unit = Sub_Unit.kd_sub_unit INNER Join Pegawai ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Dokter = Pegawai.kd_pegawai INNER Join ap_seting_apotek ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi = ap_seting_apotek.kdapo INNER Join DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan On DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat = DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Permintaan_Obat INNER Join DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Racikan = DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.No_Racikan INNER Join DBSIMRM.dbo.Jenis_Racikan_Obat On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Kd_Jenis_Racikan = DBSIMRM.dbo.Jenis_Racikan_Obat.Kd_Jenis_Racikan INNER Join DBSIMRM.dbo.etiket_takaran On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_takaran = DBSIMRM.dbo.etiket_takaran.kd_takaran INNER Join DBSIMRM.dbo.etiket_waktu On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_waktu = DBSIMRM.dbo.etiket_waktu.kd_waktu INNER Join DBSIMRM.dbo.etiket_ketminum On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_ketminum = DBSIMRM.dbo.etiket_ketminum.kd_ketminum WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & noPermintaan & "' ORDER BY DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Nama_Racikan", CONN)
        DS = New DataSet
        DA.Fill(DS)
        With gridObatRacikan
            .DataSource = DS.Tables(0)
            .Columns(0).HeaderText = "Nama Racikan"
            .Columns(0).Width = 80
            .Columns(1).HeaderText = "Jenis Racikan"
            .Columns(1).Width = 60
            .Columns(2).HeaderText = "Signa"
            .Columns(2).Width = 40
            .Columns(3).Visible = False
            .Columns(4).HeaderText = "Takaran"
            .Columns(4).Width = 140
            .Columns(5).Visible = False
            .Columns(6).HeaderText = "Waktu"
            .Columns(6).Width = 140
            .Columns(7).Visible = False
            .Columns(8).HeaderText = "Keterangan Minum"
            .Columns(8).Width = 140
            .Columns(9).HeaderText = "Keterangan"
            .Columns(10).HeaderText = "Kode Obat"
            .Columns(10).Width = 80
            .Columns(11).HeaderText = "Nama Obat"
            .Columns(11).Width = 200
            .Columns(12).HeaderText = "Kekuatan"
            .Columns(12).Width = 40
            .Columns(12).DefaultCellStyle.Format = "N2"
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(13).HeaderText = "Dosis"
            .Columns(13).Width = 40
            .Columns(13).DefaultCellStyle.Format = "N2"
            .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(14).HeaderText = "Jumlah Bungkus"
            .Columns(14).Width = 40
            .Columns(14).DefaultCellStyle.Format = "N2"
            .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(15).HeaderText = "Jumlah Obat"
            .Columns(15).Width = 40
            .Columns(15).DefaultCellStyle.Format = "N2"
            .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(16).Visible = False
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .ReadOnly = True
            gridRacikanWarna()
        End With
    End Sub

    Public Sub gridRacikanWarna()
        For j As Integer = 0 To gridObatRacikan.Rows.Count - 1
            For i = 0 To gridObatRacikan.ColumnCount - 1
                If gridObatRacikan.Rows(j).Cells("No_Urut_Racikan").Value Mod 2 = 0 Then
                    gridObatRacikan.Rows(j).Cells(i).Style.BackColor = Color.Turquoise
                Else
                    gridObatRacikan.Rows(j).Cells(i).Style.BackColor = Color.WhiteSmoke
                End If
            Next
        Next
    End Sub

    Private Sub FormDetailPermintaanObat_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormDetailPermintaanObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gridRacikanWarna()
    End Sub

End Class