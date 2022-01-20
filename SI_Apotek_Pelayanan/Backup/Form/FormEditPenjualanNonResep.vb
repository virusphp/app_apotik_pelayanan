Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormEditPenjualanNonResep
    Inherits Office2007Form
    Public rpt As New ReportDocument

    Dim Stok, Generik, kdJenisObat, kdPabrik, kdKelompokObat, kdGolonganObat, JenisObat, NamaDokter, kdDokter, NamaKonsumen, kdKonsumen, memStok, Posting As String
    Public bilang As String
    Dim Bulan, Tahun As Integer
    Dim HargaBeli, SenPotBeli As Double
    Dim BDDataPasien, BDDataBarang, BDPenjualanNonResep As New BindingSource
    Dim DSPenjualanNonResep As New DataSet
    Dim DRWPenjualanNonResep As DataRowView

    Dim Trans As SqlTransaction

    Sub KosongkanHeader()
        DSPenjualanNonResep = Table.BuatTabelPenjualanNonResep("PenjualanNonResep")
        gridDetailObat.BackgroundColor = Color.Azure
        DSPenjualanNonResep.Clear()
        gridDetailObat.DataSource = Nothing
        gridStokKembali.DataSource = Nothing
        TglServer()
        DTPTanggalTrans.Value = TanggalServer
        DTPJam.Value = TanggalServer
        txtNota.Clear()
        txtKdPelanggan.Clear()
        txtNoReg.Clear()
        lblNamaObat.Text = ""
        txtNamaPasien.Text = ""
        cmbDokter.Text = ""
        cmbKonsumen.Text = ""
        cmbRacikNon.SelectedIndex = 1
        btnSimpan.Enabled = False
        btnCetak.Enabled = False
        btnBaru.Enabled = False
        btnHapusNota.Enabled = False
        DTPTanggalTrans.Focus()
    End Sub

    Sub KosongkanDetail()
        cmbRacikNon.Text = "N"
        lblNamaObat.Text = ""
        txtPersenPotong.Enabled = False
        txtKodeObat.Clear()
        txtIdObat.Clear()
        txtDosis.Clear()
        txtSatDosis.Clear()
        txtHargaJual.Clear()
        txtJumlahJual.Clear()
        txtKdSatuan.Clear()
        txtPersenPotong.Clear()
        txtJumlahHarga.Clear()
        txtPotonganHarga.Clear()
    End Sub

    Sub AturGriddetailBarang()
        With gridDetailObat
            .Columns(0).HeaderText = "No"
            .Columns(0).ReadOnly = True
            .Columns(1).HeaderText = "R/N"
            .Columns(1).ReadOnly = True
            .Columns(2).HeaderText = "Nama Barang"
            .Columns(2).ReadOnly = True
            .Columns(3).HeaderText = "Harga"
            .Columns(3).ReadOnly = True
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Jumlah"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).DefaultCellStyle.BackColor = Color.LightYellow
            .Columns(5).HeaderText = "Satuan"
            .Columns(5).ReadOnly = True
            .Columns(6).HeaderText = "Total2"
            .Columns(6).ReadOnly = True
            .Columns(6).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderText = "% Pot"
            If Trim(kdKonsumen) = "001" Then
                .Columns(7).ReadOnly = True
            Else
                .Columns(7).ReadOnly = False
            End If
            .Columns(7).DefaultCellStyle.Format = "N2"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).DefaultCellStyle.BackColor = Color.LightYellow
            .Columns(8).HeaderText = "Potongan"
            .Columns(8).ReadOnly = True
            .Columns(8).DefaultCellStyle.Format = "N2"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).ReadOnly = True
            .Columns(9).HeaderText = "Jumlah Harga"
            .Columns(9).DefaultCellStyle.Format = "N2"
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).Width = 40
            .Columns(1).Width = 40
            .Columns(2).Width = 320
            .Columns(3).Width = 100
            .Columns(4).Width = 80
            .Columns(5).Width = 80
            .Columns(6).Width = 120
            .Columns(7).Width = 80
            .Columns(8).Width = 100
            .Columns(9).Width = 120
            .Columns(0).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
            .Columns(18).Visible = False
            .Columns(19).Visible = False
            .Columns(20).Visible = False
            .Columns(21).Visible = False
            .Columns(22).Visible = False
            .Columns(23).Visible = False
            .Columns(24).Visible = False
            .Columns(25).Visible = False
            .Columns(26).Visible = False
            .Columns(27).Visible = False
            .Columns(28).Visible = False
            .Columns(29).Visible = False
            .Columns(30).Visible = False
            .Columns(31).Visible = False
            .Columns(32).Visible = False
            .Columns(33).Visible = False
            .Columns(34).Visible = False
            .BackgroundColor = Color.Azure
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            .RowHeadersDefaultCellStyle.BackColor = Color.Black
        End With
    End Sub

    Sub TotalHarga1_2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells(6).Value
        Next
        txtGrandTotal1.DecimalValue = HitungTotal
        txtGrandTotal2.DecimalValue = HitungTotal
    End Sub

    Sub TotalPotongan_JumlahHarga()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells(8).Value
        Next
        txtGrandJumlahPotongan.DecimalValue = HitungTotal
        txtGrandTotal3.DecimalValue = txtGrandTotal2.DecimalValue - txtGrandJumlahPotongan.DecimalValue
        txtGrandJumlahHarga.DecimalValue = buletin(txtGrandTotal3.DecimalValue, 100)
        txtGrandTotalBulat.DecimalValue = txtGrandJumlahHarga.DecimalValue - txtGrandTotal3.DecimalValue
        bilang = Terbilang(txtGrandJumlahHarga.DecimalValue)
    End Sub

    Sub cetakNota()
        rpt = New ReportDocument
        Try
            Dim str As String = Application.StartupPath & "\Report\notaBebas.rpt"
            rpt.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rpt.SetDatabaseLogon(dbUser, dbPassword)
            rpt.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
            rpt.SetParameterValue("nota", txtNota.Text)
            rpt.SetParameterValue("totalNet", txtGrandTotal3.DecimalValue)
            rpt.SetParameterValue("pembulatan", txtGrandTotalBulat.DecimalValue)
            rpt.SetParameterValue("hargatotal", txtGrandJumlahHarga.DecimalValue)
            rpt.SetParameterValue("terbilang", bilang)
            FormCetak.CrystalReportViewer1.ReportSource = rpt
            FormCetak.CrystalReportViewer1.Show()
            FormCetak.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub HargaJual()
        txtHargaJual.DecimalValue = (txtHargaJual.DecimalValue + (txtHargaJual.DecimalValue * Val(My.Settings.ppn) / 100)) + (txtHargaJual.DecimalValue * Val(My.Settings.laba) / 100)
    End Sub

    Sub cariDokter()
        Dim cari As String = InStr(cmbDokter.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbDokter.Text, "|", -1, CompareMethod.Binary)
            NamaDokter = (ary(0))
            kdDokter = (ary(1))
        End If
    End Sub

    Sub cariKonsumen()
        Dim cari As String = InStr(cmbKonsumen.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbKonsumen.Text, "|", -1, CompareMethod.Binary)
            NamaKonsumen = (ary(0))
            kdKonsumen = (ary(1))
        End If
    End Sub

    Sub addBarang()
        cariDokter()
        cariKonsumen()

        BDPenjualanNonResep.DataSource = DSPenjualanNonResep
        BDPenjualanNonResep.DataMember = "PenjualanNonResep"

        BDPenjualanNonResep.AddNew()
        DRWPenjualanNonResep = BDPenjualanNonResep.Current
        DRWPenjualanNonResep("kdbagian") = My.Settings.pkdapo
        DRWPenjualanNonResep("nmbagian") = My.Settings.pnmapo
        DRWPenjualanNonResep("kdkasir") = Trim(FormLogin.LabelKode.Text)
        DRWPenjualanNonResep("nmkasir") = Trim(FormLogin.LabelNama.Text)
        DRWPenjualanNonResep("tanggal") = DTPTanggalTrans.Value
        DRWPenjualanNonResep("nota") = Trim(txtNota.Text)
        DRWPenjualanNonResep("kdkons") = Trim(kdKonsumen)
        DRWPenjualanNonResep("nmkons") = Trim(NamaKonsumen)
        DRWPenjualanNonResep("nama") = Trim(txtNamaPasien.Text)
        DRWPenjualanNonResep("kddokter") = Trim(kdDokter)
        DRWPenjualanNonResep("nmdokter") = Trim(NamaDokter)
        DRWPenjualanNonResep("urut") = 1
        DRWPenjualanNonResep("idx_barang") = Trim(txtIdObat.Text)
        DRWPenjualanNonResep("kdbarang") = Trim(txtKodeObat.Text)
        DRWPenjualanNonResep("nmbarang") = Trim(lblNamaObat.Text)
        DRWPenjualanNonResep("kdjenis") = Trim(kdJenisObat)
        DRWPenjualanNonResep("nmjenis") = Trim(JenisObat)
        DRWPenjualanNonResep("kdkel") = Trim(kdKelompokObat)
        DRWPenjualanNonResep("kdgol") = Trim(kdGolonganObat)
        DRWPenjualanNonResep("generik") = Generik
        DRWPenjualanNonResep("harga") = txtHargaJual.DecimalValue
        DRWPenjualanNonResep("jml") = txtJumlahJual.DecimalValue
        DRWPenjualanNonResep("nmsatuan") = Trim(txtKdSatuan.Text)
        DRWPenjualanNonResep("jmltotal") = txtJumlahHarga.DecimalValue
        DRWPenjualanNonResep("tuslah") = 0
        DRWPenjualanNonResep("jmlharga") = txtJumlahHarga.DecimalValue
        DRWPenjualanNonResep("senpot") = txtPersenPotong.DecimalValue
        DRWPenjualanNonResep("potongan") = txtPotonganHarga.DecimalValue
        DRWPenjualanNonResep("jmlnet") = txtJumlahHarga2.DecimalValue
        DRWPenjualanNonResep("posting") = "1"
        DRWPenjualanNonResep("diserahkan") = "B"
        DRWPenjualanNonResep("hpp") = HargaBeli
        DRWPenjualanNonResep("racik") = Trim(cmbRacikNon.Text)
        DRWPenjualanNonResep("jmlracik") = "1"
        DRWPenjualanNonResep("jml_awal") = 0

        BDPenjualanNonResep.EndEdit()

        gridDetailObat.DataSource = Nothing
        gridDetailObat.DataSource = BDPenjualanNonResep

        TotalHarga1_2()
        TotalPotongan_JumlahHarga()

    End Sub

    Sub tampilBarang()
        If My.Settings.pkdapo = "001" Then
            Stok = "stok001"
        ElseIf My.Settings.pkdapo = "002" Then
            Stok = "stok002"
        ElseIf My.Settings.pkdapo = "003" Then
            Stok = "stok003"
        ElseIf My.Settings.pkdapo = "004" Then
            Stok = "stok004"
        ElseIf My.Settings.pkdapo = "005" Then
            Stok = "stok005"
        ElseIf My.Settings.pkdapo = "006" Then
            Stok = "stok006"
        End If
        Try
            konek()
            DA = New SqlDataAdapter("select idx_barang,kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from barang_farmasi WHERE stsaktif ='1' order by kd_barang", CONN)
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

    Sub cekTutupStok()
        konek()
        CMD = New SqlCommand("select kdbagian, bulan, tahun FROM ap_stok_awalapo WHERE kdbagian=" & My.Settings.pkdapo & " and bulan='" & Bulan & "' and tahun='" & Tahun & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
    End Sub

    Sub tampilPenjualanNonResep()
        konek()
        CMD = New SqlCommand("SELECT tanggal,nota,posting, nama, kdkons, kddokter, nmdokter FROM ap_jualbbs1 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' AND nota='" & Trim(txtNota.Text) & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        Posting = Trim(DR.Item("posting"))
        txtNamaPasien.Text = Trim(DR.Item("nama"))
        kdKonsumen = Trim(DR.Item("kdkons"))
        kdDokter = Trim(DR.Item("kddokter"))
        NamaDokter = Trim(DR.Item("nmdokter"))
        cmbDokter.Text = NamaDokter & "|" & kdDokter

        konek()
        CMD = New SqlCommand("SELECT * FROM ap_konsumen WHERE kdkonsumen='" & kdKonsumen & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        NamaKonsumen = Trim(DR.Item("nmkonsumen"))
        cmbKonsumen.Text = NamaKonsumen & "|" & kdKonsumen

        konek()
        CMD = New SqlCommand("SELECT kd_pelanggan, no_reg FROM jual_header WHERE no_nota='" & Trim(txtNota.Text) & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        txtKdPelanggan.Text = Trim(DR.Item("kd_pelanggan"))
        txtNoReg.Text = Trim(DR.Item("no_reg"))

        Try
            konek()
            DA = New SqlDataAdapter("select  urut, racik, nama_barang as nmbarang, harga, jml, nmsatuan, jmlharga, senpot, potongan, jmlnet, kdbagian, nmbagian, kdkasir, nmkasir, tanggal, nota,kdkons,nmkons,nama,kdDokter, nmdokter, idx_barang, kd_barang AS kdbarang,  kd_jns_obat AS kdjenis, jns_obat as nmjenis, kd_kel_obat as kdkel, kd_gol_obat as kdgol, Generik, jmltotal,tuslah,posting,diserahkan,hpp,jmlracik, jml as jml_awal from ap_jualbbs2 where tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' AND nota='" & Trim(txtNota.Text) & "' order by noid", CONN)
            DSPenjualanNonResep = New DataSet

            DA.Fill(DSPenjualanNonResep, "PenjualanNonResep")
            BDPenjualanNonResep.DataSource = DSPenjualanNonResep
            BDPenjualanNonResep.DataMember = "PenjualanNonResep"
            With gridDetailObat
                .DataSource = Nothing
                .DataSource = BDPenjualanNonResep
            End With

            AturGriddetailBarang()
            TotalHarga1_2()
            TotalPotongan_JumlahHarga()
            txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1

            DS = New DataSet '''''''''''''''' Bantu Tambahan
            DA.Fill(DS) ''''''''''''''''''''' Bantu Tambahan
            With gridStokKembali
                .DataSource = Nothing
                .DataSource = DS.Tables(0)
            End With

            btnSimpan.Enabled = True
            btnCetak.Enabled = True
            btnBaru.Enabled = True
            btnHapusNota.Enabled = True
            cmbRacikNon.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampilPasien()
        Try
            konek()
            DA = New SqlDataAdapter("select tanggal, nota, nama, nmbagian from ap_jualbbs1 where tanggal ='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and kdbagian='" & My.Settings.pkdapo & "' order by tanggal, nota", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasien")
            BDDataPasien.DataSource = DS
            BDDataPasien.DataMember = "pasien"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDDataPasien
                .Columns(1).HeaderText = "Tanggal Resep"
                .Columns(2).HeaderText = "Nota"
                .Columns(3).HeaderText = "Nama Pasien"
                .Columns(4).HeaderText = "Unit"
                .Columns(0).Width = 30
                .Columns(1).Width = 75
                .Columns(2).Width = 90
                .Columns(3).Width = 130
                .Columns(4).Width = 120
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

    Sub detailObat(ByVal KodeObat As String)
        konek()
        CMD = New SqlCommand("SELECT * FROM barang_farmasi WHERE kd_barang='" & KodeObat & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            txtIdObat.Text = Trim(DR.Item("idx_barang"))
            lblNamaObat.Text = Trim(DR.Item("nama_barang"))
            HargaBeli = DR.Item("harga_jual")
            txtHargaJual.DecimalValue = DR.Item("harga_jual")
            txtKdSatuan.Text = Trim(DR.Item("kd_satuan_kecil"))
            txtDosis.DecimalValue = DR.Item("dosis")
            txtSatDosis.Text = Trim(DR.Item("satdosis"))
            HargaJual()
            If cmbRacikNon.Text = "R" Then
                txtDosisResep.Focus()
            Else
                txtJumlahJual.Focus()
            End If
            Generik = Trim(DR.Item("generik"))
            kdJenisObat = Trim(DR.Item("kd_jns_obat"))
            kdPabrik = Trim(DR.Item("kdpabrik"))
            kdKelompokObat = Trim(DR.Item("kd_kel_obat"))
            kdGolonganObat = Trim(DR.Item("kd_gol_obat"))
            SenPotBeli = DR.Item("senpotbeli")
        End If
        konek()
        CMD = New SqlCommand("SELECT * FROM jenis_obat WHERE kd_jns_obat='" & Trim(kdJenisObat) & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()

        If DR.HasRows Then
            JenisObat = Trim(DR.Item("jns_obat"))
        End If
    End Sub

    Sub ListDokter()
        konek()
        CMD = New SqlCommand("select kd_pegawai,nama_pegawai,gelar_depan from pegawai where kd_jns_pegawai=1 order by nama_pegawai", CONN)
        DA = New SqlDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbDokter.Items.Clear()
        cmbDokter.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbDokter.Items.Add(DT.Rows(i)("nama_pegawai") & "|" & DT.Rows(i)("kd_pegawai"))
        Next
        cmbDokter.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListKonsumen()
        konek()
        CMD = New SqlCommand("select kdkonsumen, nmkonsumen from ap_konsumen order by kdkonsumen", CONN)
        DA = New SqlDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbKonsumen.Items.Clear()
        cmbKonsumen.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbKonsumen.Items.Add(DT.Rows(i)("nmkonsumen") & "|" & DT.Rows(i)("kdkonsumen"))
        Next
        cmbKonsumen.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKonsumen.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub FormEditPenjualanNonResep_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnSimpan.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then
            btnCetak.PerformClick()
        ElseIf e.KeyCode = Keys.F10 Then
            btnBaru.PerformClick()
        End If
    End Sub

    Private Sub FormEditPenjualanNonResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        KosongkanHeader()
        KosongkanDetail()
        ListDokter()
        ListKonsumen()
    End Sub

    Private Sub FormEditPenjualanNonResep_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelPasien.Top = txtNota.Top + 22
        PanelPasien.Left = txtNota.Left + 0
        PanelObat.Top = txtKodeObat.Top + 122
        PanelObat.Left = txtKodeObat.Left + 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelPasien.Visible = False
    End Sub

    Private Sub txtNota_Click(sender As Object, e As EventArgs) Handles txtNota.Click
        DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
        Bulan = Month(DTPBantu.Value)
        Tahun = Year(DTPBantu.Value)
        cekTutupStok()
        If DR.HasRows Then
            DTPTanggalTrans.Focus()
            MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut sudah tutup stok", vbInformation, "Informasi")
            Exit Sub
        Else
            tampilPasien()
            PanelPasien.Visible = True
            txtCariPasien.Clear()
            txtCariPasien.Focus()
        End If
    End Sub

    Private Sub txtNota_GotFocus(sender As Object, e As EventArgs) Handles txtNota.GotFocus
        DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
        Bulan = Month(DTPBantu.Value)
        Tahun = Year(DTPBantu.Value)
        cekTutupStok()
        If DR.HasRows Then
            DTPTanggalTrans.Focus()
            MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut sudah tutup stok", vbInformation, "Informasi")
            Exit Sub
        Else
            tampilPasien()
            PanelPasien.Visible = True
            txtCariPasien.Clear()
            txtCariPasien.Focus()
        End If
    End Sub

    Private Sub txtCariPasien_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPasien.KeyDown
        If e.KeyCode = Keys.Down Then
            gridPasien.Focus()
        End If
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
        BDDataPasien.Filter = "nama like '%" & txtCariPasien.Text & "%'"
    End Sub

    Private Sub gridPasien_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPasien.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridPasien.Rows(e.RowIndex).Cells(1).Value) Then
                txtNota.Text = gridPasien.Rows(e.RowIndex).Cells(2).Value
                PanelPasien.Visible = False
                tampilPenjualanNonResep()
            End If
        End If
    End Sub

    Private Sub gridPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridPasien.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridPasien.CurrentRow.Index - 1
            If Not IsDBNull(gridPasien.Rows(i).Cells(1).Value) Then
                txtNota.Text = gridPasien.Rows(i).Cells(2).Value
                PanelPasien.Visible = False
                tampilPenjualanNonResep()
            End If
        End If
    End Sub

    Private Sub txtHapusBaris_Click(sender As Object, e As EventArgs) Handles txtHapusBaris.Click
        If MessageBox.Show("Yakin Akan Dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If gridDetailObat.CurrentRow.Index <> gridDetailObat.NewRowIndex Then
                    gridDetailObat.Rows.RemoveAt(gridDetailObat.CurrentRow.Index)
                End If
                txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
                TotalHarga1_2()
                TotalPotongan_JumlahHarga()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub DTPTanggalTrans_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalTrans.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKodeObat_Click(sender As Object, e As EventArgs) Handles txtKodeObat.Click
        tampilBarang()
        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub txtKodeObat_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObat.GotFocus
        tampilBarang()
        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub cmbRacikNon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRacikNon.KeyPress
        If e.KeyChar = Chr(13) Then
            If e.KeyChar = Chr(13) Then
                If cmbRacikNon.Text = "R" Or cmbRacikNon.Text = "r" Or cmbRacikNon.Text = "N" Or cmbRacikNon.Text = "n" Then
                    txtKodeObat.Focus()
                Else
                    MsgBox("Pilih yang benar", vbCritical, "Kesalahan")
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PanelObat.Visible = False
    End Sub

    Private Sub txtCariObat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariObat.KeyDown
        If e.KeyCode = Keys.Down Then
            gridBarang.Focus()
        End If
    End Sub

    Private Sub txtCariObat_TextChanged(sender As Object, e As EventArgs) Handles txtCariObat.TextChanged
        BDDataBarang.Filter = "nama_barang like '%" & txtCariObat.Text & "%'"
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtNamaPasien.Text = "" Then
            MsgBox("Nama pasien masih kosong")
            Exit Sub
        End If
        If cmbKonsumen.Text = "" Then
            MsgBox("Konsumen belum dipilih")
            Exit Sub
        End If
        If cmbDokter.Text = "" Then
            MsgBox("Dokter belum dipilih")
            Exit Sub
        End If
        If txtKodeObat.Text = "" Then
            MsgBox("Obat belum dipilih")
            Exit Sub
        End If
        If txtJumlahJual.DecimalValue <= 0 Then
            MsgBox("Jumlah belum diisi")
            txtJumlahJual.Focus()
        Else
            For barisGrid As Integer = 0 To gridDetailObat.RowCount - 1
                If Trim(txtKodeObat.Text) = gridDetailObat.Rows(barisGrid).Cells("kdbarang").Value Then
                    MsgBox("Obat ini sudah dientry")
                    KosongkanDetail()
                    txtKodeObat.Focus()
                    Exit Sub
                End If
            Next
            addBarang()
            AturGriddetailBarang()
            TotalHarga1_2()
            TotalPotongan_JumlahHarga()
            KosongkanDetail()
            btnSimpan.Enabled = True
            btnBaru.Enabled = True
            txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
            cmbRacikNon.Focus()
        End If
    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                txtKodeObat.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                PanelObat.Visible = False
                detailObat(txtKodeObat.Text)
                cariKonsumen()
            End If
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                txtKodeObat.Text = gridBarang.Rows(i).Cells(2).Value
                PanelObat.Visible = False
                detailObat(txtKodeObat.Text)
                cariKonsumen()
            End If
        End If
    End Sub

    Private Sub txtJumlahJual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahJual.KeyPress
        If e.KeyChar = Chr(13) Then
            If Trim(kdKonsumen) = "001" Then
                btnAdd.Focus()
            Else
                txtPersenPotong.Enabled = True
                txtPersenPotong.Focus()
            End If
        End If
    End Sub

    Private Sub txtJumlahJual_TextChanged(sender As Object, e As EventArgs) Handles txtJumlahJual.TextChanged
        txtJumlahHarga.DecimalValue = txtHargaJual.DecimalValue * txtJumlahJual.DecimalValue
        txtJumlahHarga2.DecimalValue = txtJumlahHarga.DecimalValue - txtPotonganHarga.DecimalValue
    End Sub

    Private Sub cmbRacikNon_LostFocus(sender As Object, e As EventArgs) Handles cmbRacikNon.LostFocus
        cmbRacikNon.Text = (cmbRacikNon.Text.ToUpper)
    End Sub

    Private Sub cmbRacikNon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRacikNon.SelectedIndexChanged
        If cmbRacikNon.Text = "R" Then
            txtDosisResep.Enabled = True
            txtJmlBungkus.Enabled = True
        Else
            txtDosisResep.Enabled = False
            txtJmlBungkus.Enabled = False
        End If
    End Sub

    Private Sub txtDosisResep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDosisResep.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJmlBungkus.Focus()
        End If
    End Sub

    Private Sub txtDosisResep_TextChanged(sender As Object, e As EventArgs) Handles txtDosisResep.TextChanged

    End Sub

    Private Sub txtJmlBungkus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlBungkus.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJumlahJual.Focus()
        End If
    End Sub

    Private Sub txtPersenPotong_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPersenPotong.KeyPress
        If e.KeyChar = Chr(13) Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        KosongkanHeader()
        KosongkanDetail()
    End Sub

    Private Sub gridDetailObat_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gridDetailObat.CellEndEdit
        gridDetailObat.Rows(e.RowIndex).Cells(6).Value = gridDetailObat.Rows(e.RowIndex).Cells(3).Value * gridDetailObat.Rows(e.RowIndex).Cells(4).Value
        Dim potongan As Double = gridDetailObat.Rows(e.RowIndex).Cells(6).Value * (gridDetailObat.Rows(e.RowIndex).Cells(7).Value / 100)
        gridDetailObat.Rows(e.RowIndex).Cells(8).Value = buletin(potongan, 1)
        gridDetailObat.Rows(e.RowIndex).Cells(9).Value = gridDetailObat.Rows(e.RowIndex).Cells(6).Value - gridDetailObat.Rows(e.RowIndex).Cells(8).Value
        TotalHarga1_2()
        TotalPotongan_JumlahHarga()
    End Sub

    Private Sub gridDetailObat_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObat.CellFormatting
        gridDetailObat.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Posting = "2" Then
            MsgBox("Transaksi tidak bisa diedit, sudah diposting oleh kasir", vbInformation, "Informasi")
            Exit Sub
        End If
        If My.Settings.pkdapo = "001" Then
            memStok = "stok001"
        ElseIf My.Settings.pkdapo = "002" Then
            memStok = "stok002"
        ElseIf My.Settings.pkdapo = "003" Then
            memStok = "stok003"
        ElseIf My.Settings.pkdapo = "004" Then
            memStok = "stok004"
        ElseIf My.Settings.pkdapo = "005" Then
            memStok = "stok005"
        ElseIf My.Settings.pkdapo = "006" Then
            memStok = "stok006"
        Else
            MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
        End If


        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Cek Stok
        If My.Settings.CekKunciStokPenjualan = "Y" Then
            For i = 0 To gridDetailObat.RowCount - 2
                konek()
                CMD = New SqlCommand("select idx_barang,kd_barang,nama_barang, " & memStok & " as stok, kd_satuan_kecil from barang_farmasi where idx_barang='" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "'", CONN)
                DR = CMD.ExecuteReader
                DR.Read()
                If DR.HasRows Then
                    If (DR.Item("stok") + gridDetailObat.Rows(i).Cells("jml_awal").Value) < gridDetailObat.Rows(i).Cells("jml").Value Then
                        MsgBox("Stok " + Trim(DR.Item("nama_barang")) + " hanya " + (DR.Item("stok") + gridDetailObat.Rows(i).Cells("jml_awal").Value).ToString + " masukan ulang jumlah barang", vbInformation, "Informasi")
                        Exit Sub
                    End If
                End If
            Next
        End If

        If MessageBox.Show("Data Penjualan sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlEditPenjualanObatNonResep As String = ""
            TglServer()
            DTPJam.Value = TanggalServer
            konek()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS APOTEK'''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualbbs1
                sqlEditPenjualanObatNonResep = "Delete from ap_jualbbs1 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and nota='" & Trim(txtNota.Text) & "'"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualbbs2
                sqlEditPenjualanObatNonResep = sqlEditPenjualanObatNonResep + vbCrLf + "Delete from ap_jualbbs2 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and nota='" & Trim(txtNota.Text) & "'"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS KASIR'''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus jual_header
                sqlEditPenjualanObatNonResep = sqlEditPenjualanObatNonResep + vbCrLf + "Delete from jual_header WHERE no_nota='" & Trim(txtNota.Text) & "'"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus jual_detail
                sqlEditPenjualanObatNonResep = sqlEditPenjualanObatNonResep + vbCrLf + "Delete from jual_detail WHERE no_nota='" & Trim(txtNota.Text) & "'"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''Stok Kembali Asal'''''''''''''''''''''''''''''''''''''''''''''
                If My.Settings.psts_stok = "1" Then
                    For i = 0 To gridStokKembali.RowCount - 2
                        sqlEditPenjualanObatNonResep = sqlEditPenjualanObatNonResep + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "+" & Num_En_US(gridStokKembali.Rows(i).Cells("jml").Value) & " WHERE kd_barang='" & Trim(gridStokKembali.Rows(i).Cells("kdbarang").Value) & "'"
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''TRAN KE APOTEK'''''''''''''''''''''''''''''''''''''' 
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Simpan ap_jualbbs1
                sqlEditPenjualanObatNonResep = sqlEditPenjualanObatNonResep + vbCrLf + "insert into ap_jualbbs1 (kdbagian, nmbagian, kdkasir, nmkasir, tanggal, nota, kdkons, nmkons, nama, kddokter, nmdokter, jmltotal, tuslah, jmlharga1, potongan, jmlharga2, bulat, jmlnet, posting, jam, diserahkan) values ('" & My.Settings.pkdapo & "', '" & My.Settings.pnmapo & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "','" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "','" & Trim(txtNota.Text) & "', '" & Trim(kdKonsumen) & "', '" & Trim(NamaKonsumen) & "', '" & Trim(txtNamaPasien.Text) & "', '" & Trim(kdDokter) & "', '" & Trim(NamaDokter) & "', '" & Num_En_US(txtGrandTotal1.DecimalValue) & "', '" & Num_En_US(txtGrandTuslah.DecimalValue) & "', '" & Num_En_US(txtGrandTotal2.DecimalValue) & "', '" & Num_En_US(txtGrandJumlahPotongan.DecimalValue) & "', '" & Num_En_US(txtGrandTotal3.DecimalValue) & "', '" & Num_En_US(txtGrandTotalBulat.DecimalValue) & "', '" & Num_En_US(txtGrandJumlahHarga.DecimalValue) & "', '1', '" & Format(DTPJam.Value, "HH:mm:ss") & "', 'B')"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Simpan ap_jualbbs2
                For i = 0 To gridDetailObat.RowCount - 2
                    sqlEditPenjualanObatNonResep = sqlEditPenjualanObatNonResep + vbCrLf + "INSERT INTO ap_jualbbs2(kdbagian,nmbagian,kdkasir,nmkasir,tanggal,nota,kdkons,nmkons,nama, kdDokter, nmdokter, urut, idx_barang, kd_barang, nama_barang, kd_jns_obat, jns_obat, kd_kel_obat, kd_gol_obat, Generik, harga, jml, nmsatuan, jmltotal, tuslah, jmlharga, senpot,potongan,jmlnet,posting,diserahkan,hpp,racik,jmlracik,jam) VALUES ('" & My.Settings.pkdapo & "', '" & My.Settings.pnmapo & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "','" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "','" & Trim(txtNota.Text) & "', '" & Trim(kdKonsumen) & "', '" & Trim(NamaKonsumen) & "', '" & Trim(txtNamaPasien.Text) & "', '" & Trim(kdDokter) & "', '" & Trim(NamaDokter) & "', '" & i + 1 & "', '" & Trim(gridDetailObat.Rows(i).Cells("idx_barang").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kdbarang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmbarang").Value)) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kdjenis").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("nmjenis").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kdkel").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kdgol").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("generik").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmltotal").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("tuslah").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlharga").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("senpot").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("potongan").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlnet").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("posting").Value) & "', 'B', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hpp").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("racik").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlracik").Value) & "', '" & Format(DTPJam.Value, "yyyy/MM/dd HH:mm:ss") & "')"
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''TRAN KE KASIR'''''''''''''''''''''''''''''''''''''' 
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Simpan jual_header
                sqlEditPenjualanObatNonResep = sqlEditPenjualanObatNonResep + vbCrLf + "insert into jual_header(no_nota, kd_pelanggan, no_reg, jenis_rawat, nama_pelanggan, alamat, tgl_jual, waktu, kd_sub_unit, status_bayar, kd_kelompok_pelanggan, metode_bayar, total, user_id, user_nama, waktu_in, waktu_out, kd_sub_unit_asal, total_bulat, total_tunai, total_tunai_bulat, total_piutang, total_piutang_bulat)values('" & Trim(txtNota.Text) & "', '" & Trim(txtKdPelanggan.Text) & "', '" & Trim(txtNoReg.Text) & "', 'BS', '" & Trim(txtNamaPasien.Text) & "', '-',  '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Format(DTPJam.Value, "HH:mm:ss") & "', '" & My.Settings.pkdsubunit & "', 'BELUM', '0', 'TUNAI', '" & Num_En_US(txtGrandTotal3.DecimalValue) & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPJam.Value, "HH:mm:ss") & "', '-', '0', '" & Num_En_US(txtGrandJumlahHarga.DecimalValue) & "', '" & Num_En_US(txtGrandTotal3.DecimalValue) & "', '" & Num_En_US(txtGrandJumlahHarga.DecimalValue) & "', '0', '0')"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Simpan jual_detail
                For i = 0 To gridDetailObat.RowCount - 2
                    sqlEditPenjualanObatNonResep = sqlEditPenjualanObatNonResep + vbCrLf + "INSERT INTO jual_detail(no_nota, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, nr, urutan, kd_sub_unit_asal, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket) values ('" & Trim(txtNota.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("idx_barang").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hpp").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "', '0', '0', '0', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlnet").Value) & "', '0', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlnet").Value) & "', '-', '0', '" & My.Settings.pkdsubunit & "', '0', '0', '-', '" & Trim(gridDetailObat.Rows(i).Cells("kdbarang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmbarang").Value)) & "', '0') "
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Update Stok
                If My.Settings.psts_stok = "1" Then
                    For i = 0 To gridDetailObat.RowCount - 2
                        sqlEditPenjualanObatNonResep = sqlEditPenjualanObatNonResep + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "-" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & " WHERE kd_barang='" & Trim(gridDetailObat.Rows(i).Cells("kdbarang").Value) & "'"
                    Next
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CMD.CommandText = sqlEditPenjualanObatNonResep
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi penjualan berhasil diedit", vbInformation, "Informasi")
                btnSimpan.Enabled = False
            Catch ex As Exception
                MsgBox(" Commit Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                Try
                    Trans.Rollback()
                Catch ex2 As Exception
                    MsgBox(" Rollback Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                    MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                End Try
            End Try
        End If

    End Sub

    Private Sub btnHapusNota_Click(sender As Object, e As EventArgs) Handles btnHapusNota.Click
        If MessageBox.Show("Yakin transaksi ini akan dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If Posting = "2" Then
                MsgBox("Transaksi tidak bisa dihapus, sudah diposting oleh kasir", vbInformation, "Informasi")
                Exit Sub
            End If

            If My.Settings.pkdapo = "001" Then
                memStok = "stok001"
            ElseIf My.Settings.pkdapo = "002" Then
                memStok = "stok002"
            ElseIf My.Settings.pkdapo = "003" Then
                memStok = "stok003"
            ElseIf My.Settings.pkdapo = "004" Then
                memStok = "stok004"
            ElseIf My.Settings.pkdapo = "005" Then
                memStok = "stok005"
            ElseIf My.Settings.pkdapo = "006" Then
                memStok = "stok006"
            Else
                MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
            End If

            Dim sqlHapusPenjualanObatNonResep As String = ""
            konek()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS APOTEK'''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualbbs1
                sqlHapusPenjualanObatNonResep = "Delete from ap_jualbbs1 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and nota='" & Trim(txtNota.Text) & "'"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualbbs2
                sqlHapusPenjualanObatNonResep = sqlHapusPenjualanObatNonResep + vbCrLf + "Delete from ap_jualbbs2 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and nota='" & Trim(txtNota.Text) & "'"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS KASIR'''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus jual_header
                sqlHapusPenjualanObatNonResep = sqlHapusPenjualanObatNonResep + vbCrLf + "Delete from jual_header WHERE no_nota='" & Trim(txtNota.Text) & "'"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus jual_detail
                sqlHapusPenjualanObatNonResep = sqlHapusPenjualanObatNonResep + vbCrLf + "Delete from jual_detail WHERE no_nota='" & Trim(txtNota.Text) & "'"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''Stok Kembali Asal'''''''''''''''''''''''''''''''''''''''''''''
                If My.Settings.psts_stok = "1" Then
                    For i = 0 To gridStokKembali.RowCount - 2
                        sqlHapusPenjualanObatNonResep = sqlHapusPenjualanObatNonResep + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "+" & Num_En_US(gridStokKembali.Rows(i).Cells("jml").Value) & " WHERE kd_barang='" & Trim(gridStokKembali.Rows(i).Cells("kdbarang").Value) & "'"
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CMD.CommandText = sqlHapusPenjualanObatNonResep
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi penjualan berhasil dihapus", vbInformation, "Informasi")
                KosongkanHeader()
                KosongkanDetail()
            Catch ex As Exception
                MsgBox(" Commit Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                Try
                    Trans.Rollback()
                Catch ex2 As Exception
                    MsgBox(" Rollback Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                    MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                End Try
            End Try
        End If
    End Sub

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        FormPemanggil = "FormEditPenjualanNonResep"
        cetakNota()
        btnCetak.Enabled = False
    End Sub

    Private Sub PanelObat_Paint(sender As Object, e As PaintEventArgs) Handles PanelObat.Paint

    End Sub

    Private Sub DTPTanggalTrans_ValueChanged(sender As Object, e As EventArgs) Handles DTPTanggalTrans.ValueChanged

    End Sub
End Class