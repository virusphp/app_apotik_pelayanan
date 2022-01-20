Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.IO
Imports System.Data.SqlClient

Public Class MenuUtama
    Inherits RibbonForm
    Private myPicRow As DataRowView
    Private dsDataPegawai As DataSet
    Private bdDataPegawai As New BindingSource
    Private JumUltah As Integer
    Private fs As MemoryStream = Nothing
    Public menuPemanggil As String

    Private Sub ToolStripButton10_Click(sender As Object, e As EventArgs) Handles ToolStripButton10.Click
        FormKoneksi.ShowDialog()
    End Sub

    Private Sub MenuUtama_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        FormLogin.Close()
        CONN.Close()
    End Sub

    Private Sub MenuUtama_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        konek()
        Me.IsMdiContainer = True
        Dim fs As MemoryStream = Nothing
        CMD = New OleDb.OleDbCommand("SELECT kd_pegawai,Tgl_Lahir, Tempat_Lahir, nip,nama_pegawai,foto FROM Pegawai WHERE month(tgl_lahir) =(select MONTH(getdate())) AND day(tgl_lahir) =(select DAY(getdate())) AND Status_pegawai = '1'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            dsDataPegawai = New DataSet
            DA.Fill(dsDataPegawai, "Pegawai")
            bdDataPegawai.DataSource = dsDataPegawai
            bdDataPegawai.DataMember = "Pegawai"

            myPicRow = bdDataPegawai.Current
            Dim DataPDF() As Byte
            If IsDBNull(myPicRow.Item("Foto")) Then
                DataPDF = Nothing
                PictureBox2.Image = PictureBox3.Image
                lblNamaUltah.Text = myPicRow.Item("Nama_Pegawai").ToString
                lblTglUltah.Text = myPicRow.Item("Tempat_Lahir").ToString & ", " & Format(myPicRow.Item("Tgl_Lahir").ToString, "dd-MM-yyyy")
            Else
                DataPDF = myPicRow.Item("Foto")
                fs = New System.IO.MemoryStream(DataPDF)
                PictureBox2.Image = Image.FromStream(fs)
                lblNamaUltah.Text = myPicRow.Item("Nama_Pegawai").ToString
                lblTglUltah.Text = myPicRow.Item("Tempat_Lahir").ToString & ", " & Format(myPicRow.Item("Tgl_Lahir").ToString, "dd-MM-yyyy")
            End If
        Else
            PictureBox2.Image = PictureBox3.Image
            lblNamaUltah.Text = ""
            lblTglUltah.Text = ""
        End If
        btnLogout.Enabled = False
    End Sub

    Private Sub MenuUtama_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PictureBox1.Left = Me.Width - PictureBox1.Width - 40
        PictureBox2.Left = PictureBox1.Left - PictureBox2.Width - 5
        lblNamaUltah.Left = PictureBox2.Left - lblNamaUltah.Width - 7
        lblTglUltah.Left = PictureBox2.Left - lblTglUltah.Width - 7
        lblTitle.Left = PictureBox2.Left - lblTitle.Width - 7
        lblDepo.Left = PictureBox2.Left - lblDepo.Width - 7
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        JumUltah = JumUltah + 1
        myPicRow = bdDataPegawai.Current
        If bdDataPegawai.Count > 0 Then
            Dim DataPDF() As Byte
            If IsDBNull(myPicRow.Item("Foto")) Then
                DataPDF = Nothing
                PictureBox2.Image = PictureBox3.Image
                lblNamaUltah.Text = myPicRow.Item("Nama_Pegawai").ToString
                lblTglUltah.Text = myPicRow.Item("Tempat_Lahir").ToString & ", " & Format(myPicRow.Item("Tgl_Lahir"), "dd-MM-yyyy")
            Else
                DataPDF = myPicRow.Item("Foto")
                fs = New System.IO.MemoryStream(DataPDF)
                PictureBox2.Image = Image.FromStream(fs)
                lblNamaUltah.Text = myPicRow.Item("Nama_Pegawai").ToString
                lblTglUltah.Text = myPicRow.Item("Tempat_Lahir").ToString & ", " & Format(myPicRow.Item("Tgl_Lahir"), "dd-MM-yyyy")
            End If

            If JumUltah < bdDataPegawai.Count Then
                bdDataPegawai.MoveNext()
            Else
                bdDataPegawai.MoveFirst()
                JumUltah = 0
            End If

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PanelJam.Text = Format(Now, "HH:mm:ss")
    End Sub

    Private Sub ToolStripButton12_Click(sender As Object, e As EventArgs) Handles btnSetFarmasi.Click
        FormSetApotik.ShowDialog()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        FormPenjualanResep.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        FormEditPenjualanResep.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        FormPenjualanNonResep.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        FormEditPenjualanNonResep.ShowDialog()
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles ToolStripButton6.Click
        menuPemanggil = "FormReturRI"
        FormReturRI.ShowDialog()
    End Sub

    Private Sub toolstripButton_retur_rr_Click(sender As Object, e As EventArgs) Handles toolstripButton_retur_rr.Click
        menuPemanggil = "FormReturObatPasienPulang"
        FormReturRI.ShowDialog()
    End Sub

    Private Sub ToolStripButton7_Click(sender As Object, e As EventArgs) Handles ToolStripButton7.Click
        menuPemanggil = "FormEditReturRI"
        FormEditReturRI.ShowDialog()
    End Sub

    Private Sub ToolStripButton14_Click(sender As Object, e As EventArgs) Handles ToolStripButton14.Click
        FormPermintaanGudangBPJSKeGudang.ShowDialog()
    End Sub

    Private Sub ToolStripButton20_Click(sender As Object, e As EventArgs) Handles ToolStripButton20.Click
        FormRincianObatPasienRI.ShowDialog()
    End Sub

    Private Sub ToolStripButton8_Click(sender As Object, e As EventArgs) Handles ToolStripButton8.Click
        FormPenyerahanObat.ShowDialog()
    End Sub

    Private Sub btnFormLaba_Click(sender As Object, e As EventArgs) Handles btnFormLaba.Click
        FormSettingLaba.ShowDialog()
    End Sub

    Private Sub ToolStripButton15_Click(sender As Object, e As EventArgs) Handles ToolStripButton15.Click
        FormLaporanPermintaanBarangKeGudang.ShowDialog()
    End Sub

    Private Sub ToolStripButton17_Click(sender As Object, e As EventArgs) Handles ToolStripButton17.Click
        FormLaporanRealisasiPermintaan.ShowDialog()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        FormPermintaanKeGudang.ShowDialog()
    End Sub

    Private Sub ToolStripButton18_Click(sender As Object, e As EventArgs) Handles ToolStripButton18.Click
        FormMutasiAntarUnit.ShowDialog()
    End Sub

    Private Sub ToolStripButton19_Click(sender As Object, e As EventArgs) Handles ToolStripButton19.Click
        FormLaporanMutasiAntarUnit.ShowDialog()
    End Sub

    Private Sub ToolStripButton9_Click(sender As Object, e As EventArgs) Handles ToolStripButton9.Click
        FormStokPerbulan.ShowDialog()
    End Sub

    Private Sub ToolStripButton23_Click(sender As Object, e As EventArgs) Handles ToolStripButton23.Click
        FormEtiketTakaran.ShowDialog()
    End Sub

    Private Sub ToolStripButton24_Click(sender As Object, e As EventArgs) Handles ToolStripButton24.Click
        FormEtiketWaktuMinum.ShowDialog()
    End Sub

    Private Sub ToolStripButton25_Click(sender As Object, e As EventArgs) Handles ToolStripButton25.Click
        FormEtiketKeteranganMinum.ShowDialog()
    End Sub

    Private Sub ToolStripButton13_Click(sender As Object, e As EventArgs) Handles ToolStripButton13.Click
        FormKartuStok.ShowDialog()
    End Sub

    Private Sub ToolStripButton21_Click(sender As Object, e As EventArgs) Handles ToolStripButton21.Click
        FormStokHarian.ShowDialog()
    End Sub

    Private Sub ToolStripButton22_Click(sender As Object, e As EventArgs) Handles ToolStripButton22.Click
        MsgBox("TUTUP STOK ADA PADA MENU STOK BARANG", vbInformation, "Informasi")
    End Sub

    Private Sub ToolStripButton26_Click(sender As Object, e As EventArgs) Handles ToolStripButton26.Click
        FormKoreksiTambah.ShowDialog()
    End Sub

    Private Sub ToolStripButton27_Click(sender As Object, e As EventArgs) Handles ToolStripButton27.Click
        FormKoreksiKurang.ShowDialog()
    End Sub

    Private Sub ToolStripButton28_Click(sender As Object, e As EventArgs) Handles ToolStripButton28.Click
        FormLaporanKoreksiTambah.ShowDialog()
    End Sub

    Private Sub ToolStripButton29_Click(sender As Object, e As EventArgs) Handles ToolStripButton29.Click
        FormLaporanKoreksiKurang.ShowDialog()
    End Sub

    Private Sub ToolStripButton30_Click(sender As Object, e As EventArgs) Handles ToolStripButton30.Click
        FormAlarmKoreksi.ShowDialog()
    End Sub

    Private Sub ToolStripButton31_Click(sender As Object, e As EventArgs) Handles ToolStripButton31.Click
        FormLaporanNotaPenjualanObatBebas.ShowDialog()
    End Sub

    Private Sub ToolStripButton32_Click(sender As Object, e As EventArgs) Handles ToolStripButton32.Click
        FormLaporanDetailPenjualanObatBebas.ShowDialog()
    End Sub

    Private Sub ToolStripButton33_Click(sender As Object, e As EventArgs) Handles ToolStripButton33.Click
        FormLaporanHarianJualBebas.ShowDialog()
    End Sub

    Private Sub ToolStripButton34_Click(sender As Object, e As EventArgs) Handles ToolStripButton34.Click
        FormLaporanNotaPenjualanResep.ShowDialog()
    End Sub

    Private Sub ToolStripButton35_Click(sender As Object, e As EventArgs) Handles ToolStripButton35.Click
        FormLaporanDetailPenjualanResepObat.ShowDialog()
    End Sub

    Private Sub ToolStripButton36_Click(sender As Object, e As EventArgs) Handles ToolStripButton36.Click
        FormLaporanRekapHarianPenjualanResep.ShowDialog()
    End Sub

    Private Sub ToolStripButton37_Click(sender As Object, e As EventArgs) Handles ToolStripButton37.Click
        FormLaporanRekapHarianPenjualanResepNonPaket.ShowDialog()
    End Sub

    Private Sub ToolStripButton38_Click(sender As Object, e As EventArgs) Handles ToolStripButton38.Click
        FormLaporanNotaReturRI.ShowDialog()
    End Sub

    Private Sub ToolStripButton39_Click(sender As Object, e As EventArgs) Handles ToolStripButton39.Click
        FormLaporanDetailReturRI.ShowDialog()
    End Sub

    Private Sub ToolStripButton42_Click(sender As Object, e As EventArgs) Handles ToolStripButton42.Click
        Close()
        Dispose()
    End Sub

    Private Sub ToolStripButton40_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        FormLogin.Show()
    End Sub

    Private Sub ToolStripButton41_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Anda yakin akan Logout ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            FormLogin.Close()
            FormLogin.Dispose()
            btnLogin.Enabled = True
            btnLogout.Enabled = False
            MenuMaster.Enabled = False
            MenuPenjualan.Enabled = False
            MenuStok.Enabled = False
            MenuMutasi.Enabled = False
            MenuKoreksi.Enabled = False
            MenuLaporan.Enabled = False
            MenuAdmin.Enabled = False
            MenuVerifikasi.Enabled = False
            PanelApotek.Text = "Depo"
            PanelKode.Text = "Kode"
            PanelNama.Text = "Nama"
            lblDepo.Text = "Depo"
            PictureBox1.Image = PictureBox3.Image
            UserPic.Image = PictureBox3.Image
        End If
    End Sub

    Private Sub ToolStripButton40_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton40.Click
        FormStokPerperperiode.ShowDialog()
    End Sub

    Private Sub ToolStripButton4_Click_1(sender As Object, e As EventArgs) Handles btnEditPenjualanResep.Click
        FormEditPenjualanResep.ShowDialog()
    End Sub

    Private Sub ToolStripButton12_Click_1(sender As Object, e As EventArgs) Handles btnEditStatusBayar.Click
        FormEditStatusBayar.ShowDialog()
    End Sub

    Private Sub ToolStripButton12_Click_2(sender As Object, e As EventArgs) Handles ToolStripButton12.Click
        FormSettingViewBarang.ShowDialog()
    End Sub

    Private Sub ToolStripButton3_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        FormPenjualanResep.ShowDialog()
    End Sub

    Private Sub ToolStripButton41_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton41.Click
        FormPenjualanResepEMR.ShowDialog()
    End Sub

    Private Sub btnEditPenjulanEMR_Click(sender As Object, e As EventArgs) Handles btnEditPenjulanEMR.Click
        FormEditPenjualanResepEMR.ShowDialog()
    End Sub

    Private Sub ToolStripButton44_Click(sender As Object, e As EventArgs) Handles ToolStripButton44.Click
        FormDaftarPermintaanResep.ShowDialog()
    End Sub

    Private Sub ToolStripButton45_Click(sender As Object, e As EventArgs) Handles ToolStripButton45.Click
        menuPemanggil = "FormEditStatusRetur"
        FormEditReturRI.ShowDialog()
    End Sub

    Private Sub laporanReturResepRJ_Click(sender As Object, e As EventArgs) Handles laporanReturResepRJ.Click
        'menuPemanggil = "FormLaporanReturRJ"

    End Sub

    Private Sub btnReturRawatJalan_Click(sender As Object, e As EventArgs) Handles btnReturRawatJalan.Click
        menuPemanggil = "FormReturRawatJalan"
        FormReturPenjualan.ShowDialog()
    End Sub

    Private Sub btnLaporanReturResepRJ_Click(sender As Object, e As EventArgs) Handles btnLaporanReturResepRJ.Click
        menuPemanggil = "FormLapoaranReturRJ"

    End Sub
End Class
