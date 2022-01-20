Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormEditReturRI
    Inherits Office2010Form
    Public rpt As New ReportDocument

    Dim BDDataPasienRIEdit, BDReturObatInapEdit, BDobatInap As New BindingSource
    Dim DRWReturObatInapEdit As DataRowView
    Dim DSReturObatInapEdit As New DataSet

    Dim NamaPenjamin, kdPenjamin, kdDokter, NamaDokter, kdTempatTidur, noidBarang, Generik, kdJnsObat, KdKelObat, kdGolObat, kdPabrik, Formularium, Rekening, JenisObat, nmSubUnit, kdSubUnit, memStok, Posting, bilang As String
    Dim Bulan, Tahun As Integer
    Dim tglLahirPasien As DateTime
    Dim Trans As SqlTransaction

    Sub KosongkanHeader()
        DSReturObatInapEdit = Table.BuatTabelReturObatInap("ReturObatInapEdit")
        gridDetailObat.BackgroundColor = Color.Azure
        DSReturObatInapEdit.Clear()
        gridDetailObat.DataSource = Nothing
        gridStokKembali.DataSource = Nothing
        TglServer()
        DTPTanggalTrans.Value = TanggalServer
        txtNoRetur.Clear()
        txtNoReg.Clear()
        txtJnsRawat.Clear()
        txtRM.Clear()
        txtSex.Clear()
        txtUmurBln.Clear()
        txtUmurThn.Clear()
        txtNamaPasien.Clear()
        txtAlamat.Clear()
        cmbUnitAsal.Text = ""
        cmbPenjamin.Text = ""
        cmbDokter.Text = ""
        cmbPkt.SelectedIndex = 0
        txtGrandJmlHargaRetPaket.DecimalValue = 0
        txtGrandJmlHargaRetPaketBulat.DecimalValue = 0
        txtGrandJmlHargaRetNonPaket.DecimalValue = 0
        txtGrandJmlHargaRetNonPaketBulat.DecimalValue = 0
        txtGrandTotalRetur.DecimalValue = 0
        txtGrandTotalReturBulat.DecimalValue = 0
        txtGrandDijamin.DecimalValue = 0
        txtGrandDijaminBulat.DecimalValue = 0
        txtGrandIurBayar.DecimalValue = 0
        txtGrandIurBayarBulat.DecimalValue = 0
        txtQty.DecimalValue = 0
        DTPTanggalTrans.Focus()


        btnSimpan.Enabled = False
        btnBaru.Enabled = False
        btnHapusNota.Enabled = False
        btnCetakNota.Enabled = False
    End Sub

    Sub kosongkanDetail()
        TglServer()
        lblNamaObat.Text = ""
        txtKodeObat.Clear()
        txtIdxBarang.Clear()
        DTPTanggalResep.Value = TanggalServer
        txtNotaResep.Clear()
        CmbDokterResep.Text = ""
        txtJmlPaket.DecimalValue = 0
        txtJmlNonPaket.DecimalValue = 0
        txtTotalQty.DecimalValue = 0
        txtJmlResepAwal.DecimalValue = 0
        txtDijaminResepAwal.DecimalValue = 0
        txtIurResepAwal.DecimalValue = 0
        txtHarga.DecimalValue = 0
        txtRetPaket.DecimalValue = 0
        txtRetNonPaket.DecimalValue = 0
        txtJumlahRetur.DecimalValue = 0
        txtSatuan.Clear()
        txtJmlHargaPaket.DecimalValue = 0
        txtJmlHargaNonPaket.DecimalValue = 0
        txtTotalHargaRetur.DecimalValue = 0
        txtDijamin.DecimalValue = 0
        txtIurPasien.DecimalValue = 0
    End Sub

    Sub tampilPasienRetur()
        Try
            konek()
            DA = New SqlDataAdapter("SELECT noid, tanggal, notaretur, no_reg, no_rm, nama_pasien, posting from ap_returinap1 where tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "'", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasienRIReturEdit")
            BDDataPasienRIEdit.DataSource = DS
            BDDataPasienRIEdit.DataMember = "pasienRIReturEdit"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDDataPasienRIEdit
                .Columns(1).HeaderText = "Noid"
                .Columns(2).HeaderText = "Tanggal Retur"
                .Columns(3).HeaderText = "Nota Retur"
                .Columns(4).HeaderText = "No Registrasi"
                .Columns(5).HeaderText = "No RM"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(0).Width = 30
                .Columns(1).Width = 50
                .Columns(2).Width = 75
                .Columns(3).Width = 110
                .Columns(4).Width = 90
                .Columns(5).Width = 60
                .Columns(6).Width = 200
                .Columns(7).Visible = False
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

    Sub cariNamaPenjamin()
        Dim cari As String = InStr(cmbPenjamin.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbPenjamin.Text, "|", -1, CompareMethod.Binary)
            NamaPenjamin = (ary(0))
            kdPenjamin = (ary(1))
        End If
    End Sub

    Sub cariDokter()
        Dim cari As String = InStr(CmbDokterResep.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(CmbDokterResep.Text, "|", -1, CompareMethod.Binary)
            NamaDokter = (ary(0))
            kdDokter = (ary(1))
        End If
    End Sub

    Sub cariDokter2()
        Dim cari As String = InStr(cmbDokter.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbDokter.Text, "|", -1, CompareMethod.Binary)
            NamaDokter = (ary(0))
            kdDokter = (ary(1))
        End If
    End Sub

    Sub cariSubUnitAsal()
        Dim cari As String = InStr(cmbUnitAsal.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbUnitAsal.Text, "|", -1, CompareMethod.Binary)
            nmSubUnit = (ary(0))
            kdSubUnit = (ary(1))
        End If
    End Sub

    Sub addBarang()
        cariNamaPenjamin()
        cariDokter()

        BDReturObatInapEdit.DataSource = DSReturObatInapEdit
        BDReturObatInapEdit.DataMember = "pasienRIReturEdit"

        BDReturObatInapEdit.AddNew()
        DRWReturObatInapEdit = BDReturObatInapEdit.Current
        DRWReturObatInapEdit("kdkasir") = Trim(FormLogin.LabelKode.Text)
        DRWReturObatInapEdit("nmkasir") = Trim(FormLogin.LabelNama.Text)
        DRWReturObatInapEdit("kdbagian") = My.Settings.pkdapo
        DRWReturObatInapEdit("tanggal") = DTPTanggalTrans.Value
        DRWReturObatInapEdit("notaretur") = Trim(txtNoRetur.Text)
        DRWReturObatInapEdit("no_reg") = Trim(txtNoReg.Text)
        DRWReturObatInapEdit("no_rm") = Trim(txtRM.Text)
        DRWReturObatInapEdit("nmpasien") = Trim(txtNamaPasien.Text)
        DRWReturObatInapEdit("umurthn") = Trim(txtUmurThn.Text)
        DRWReturObatInapEdit("umurbln") = Trim(txtUmurBln.Text)
        DRWReturObatInapEdit("kd_penjamin") = Trim(kdPenjamin)
        DRWReturObatInapEdit("nm_penjamin") = Trim(NamaPenjamin)
        DRWReturObatInapEdit("urut") = 1
        DRWReturObatInapEdit("noid") = Trim(noidBarang)
        DRWReturObatInapEdit("kd_barang") = Trim(txtKodeObat.Text)
        DRWReturObatInapEdit("idx_barang") = Trim(txtIdxBarang.Text)
        DRWReturObatInapEdit("nama_barang") = Trim(lblNamaObat.Text)
        DRWReturObatInapEdit("generik") = Trim(Generik)
        DRWReturObatInapEdit("kd_jns_obat") = Trim(kdJnsObat)
        DRWReturObatInapEdit("kd_gol_obat") = Trim(kdGolObat)
        DRWReturObatInapEdit("kd_kel_obat") = Trim(KdKelObat)
        DRWReturObatInapEdit("kdpabrik") = Trim(kdPabrik)
        DRWReturObatInapEdit("rek_p") = Trim(Rekening)
        DRWReturObatInapEdit("formularium") = Trim(Formularium)
        DRWReturObatInapEdit("tglresep") = DTPTanggalResep.Value
        DRWReturObatInapEdit("notaresep") = Trim(txtNotaResep.Text)
        DRWReturObatInapEdit("kddokter") = Trim(kdDokter)
        DRWReturObatInapEdit("nmdokter") = Trim(NamaDokter)
        DRWReturObatInapEdit("hrgppn") = txtHarga.DecimalValue
        DRWReturObatInapEdit("jmlretpkt") = txtRetPaket.DecimalValue
        DRWReturObatInapEdit("jmlretnpkt") = txtRetNonPaket.DecimalValue
        DRWReturObatInapEdit("totalqty") = txtJumlahRetur.DecimalValue
        DRWReturObatInapEdit("nmsatuan") = Trim(txtSatuan.Text)
        DRWReturObatInapEdit("jmlhrgpkt") = txtJmlHargaPaket.DecimalValue
        DRWReturObatInapEdit("jmlhrgnpkt") = txtJmlHargaNonPaket.DecimalValue
        DRWReturObatInapEdit("jmlhrgret") = txtTotalHargaRetur.DecimalValue
        DRWReturObatInapEdit("dijamin") = txtDijamin.DecimalValue
        DRWReturObatInapEdit("iurpasien") = txtIurPasien.DecimalValue
        DRWReturObatInapEdit("jns_obat") = Trim(JenisObat)

        BDReturObatInapEdit.EndEdit()

        gridDetailObat.DataSource = Nothing
        gridDetailObat.DataSource = BDReturObatInapEdit

        TotalHargaRetPaket()
        TotalHargaRetNonPaket()
        TotalRetur()
        TotalDijamin()
        TotalIurPasien()
    End Sub

    Sub cekTutupStok()
        konek()
        CMD = New SqlCommand("select kdbagian, bulan, tahun FROM ap_stok_awalapo WHERE kdbagian=" & My.Settings.pkdapo & " and bulan='" & Bulan & "' and tahun='" & Tahun & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
    End Sub

    Sub tampilObat()
        Try
            konek()
            DA = New SqlDataAdapter("SELECT noid, tanggal, notaresep, LTRIM(RTRIM(nmdokter)), LTRIM(RTRIM(nama_barang)) as nama_barang, jmlpaket, jmlnonpaket, jml, LTRIM(RTRIM(nmsatuan)) FROM ap_jualr2 WHERE no_reg='" & txtNoReg.Text & "' ORDER BY tanggal,notaresep,noid", CONN)
            DS = New DataSet
            DA.Fill(DS, "ObatInap")
            BDobatInap.DataSource = DS
            BDobatInap.DataMember = "ObatInap"
            With gridBarang
                .DataSource = Nothing
                .DataSource = BDobatInap
                .Columns(1).HeaderText = "NOID"
                .Columns(2).HeaderText = "Tanggal Resep"
                .Columns(3).HeaderText = "Nota Resep"
                .Columns(4).HeaderText = "Nama Dokter"
                .Columns(5).HeaderText = "Nama Barang"
                .Columns(6).HeaderText = "Jumlah Paket"
                .Columns(6).DefaultCellStyle.Format = "N2"
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).HeaderText = "Jumlah Non Paket"
                .Columns(7).DefaultCellStyle.Format = "N2"
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).HeaderText = "Total Qty"
                .Columns(8).DefaultCellStyle.Format = "N2"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(9).HeaderText = "Satuan"
                .Columns(0).Width = 30
                .Columns(2).Width = 75
                .Columns(3).Width = 90
                .Columns(4).Width = 150
                .Columns(5).Width = 130
                .Columns(6).Width = 50
                .Columns(7).Width = 50
                .Columns(8).Width = 50
                .Columns(9).Width = 90
                .Columns(1).Visible = False
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

    Sub AturGriddetailBarang()
        With gridDetailObat
            .Columns(0).HeaderText = "No"
            .Columns(1).HeaderText = "Nama Barang"
            .Columns(2).HeaderText = "Harga"
            .Columns(2).DefaultCellStyle.Format = "N2"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).HeaderText = "Jumlah Retur Paket"
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Jumlah Retur Non Paket"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "Total Qty Retur"
            .Columns(5).DefaultCellStyle.Format = "N2"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.BackColor = Color.LightYellow
            .Columns(6).HeaderText = "Satuan"
            .Columns(7).HeaderText = "Jumlah Harga Retur Paket"
            .Columns(7).DefaultCellStyle.Format = "N2"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).HeaderText = "Jumlah Harga Retur Non Paket"
            .Columns(8).DefaultCellStyle.Format = "N2"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).HeaderText = "Total Harga Retur"
            .Columns(9).DefaultCellStyle.Format = "N2"
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).DefaultCellStyle.BackColor = Color.LightYellow
            .Columns(10).HeaderText = "Dijamin"
            .Columns(10).DefaultCellStyle.Format = "N2"
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).HeaderText = "Iur Pasien"
            .Columns(11).DefaultCellStyle.Format = "N2"
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).Width = 40
            .Columns(1).Width = 275
            .Columns(2).Width = 90
            .Columns(3).Width = 50
            .Columns(4).Width = 50
            .Columns(5).Width = 50
            .Columns(6).Width = 65
            .Columns(7).Width = 90
            .Columns(8).Width = 90
            .Columns(9).Width = 90
            .Columns(10).Width = 90
            .Columns(11).Width = 90
            .Columns(0).Visible = False
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
            .Columns(35).Visible = False
            .Columns(36).Visible = False
            .Columns(37).Visible = False
            .Columns(38).Visible = False
            .Columns(39).Visible = False
            .BackgroundColor = Color.Azure
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            .RowHeadersDefaultCellStyle.BackColor = Color.Black
            .ReadOnly = True
        End With
    End Sub

    Sub TampilRetur()
        'Data Diri Pasien
        konek()
        CMD = New SqlCommand("Select * from ap_returinap1 where notaretur='" & txtNoRetur.Text & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        DTPTanggalTrans.Value = DR.Item("tanggal")
        txtNoReg.Text = Trim(DR.Item("no_reg"))
        txtRM.Text = Trim(DR.Item("no_rm"))
        kdPenjamin = Trim(DR.Item("kd_penjamin"))
        'txtGrandJmlHargaRetPaket.DecimalValue = DR.Item("jmlretpkt")
        'txtGrandJmlHargaRetPaketBulat.DecimalValue = DR.Item("jmlretpktblt")
        'txtGrandJmlHargaRetNonPaket.DecimalValue = DR.Item("jmlretnpkt")
        'txtGrandJmlHargaRetNonPaketBulat.DecimalValue = DR.Item("jmlretnpktblt")


        konek()
        CMD = New SqlCommand("SELECT Pasien.no_RM, Pasien.alamat, Pasien.RT, Pasien.RW, Kelurahan.nama_kelurahan, Kecamatan.nama_kecamatan,Kabupaten.nama_kabupaten, Propinsi.nama_propinsi, pasien.nama_pasien, case pasien.jns_kel when '0' then 'P' else 'L' end as jns_kel, pasien.tgl_lahir FROM Pasien INNER JOIN Kelurahan ON Pasien.kd_kelurahan = Kelurahan.kd_kelurahan INNER JOIN Kecamatan ON Kelurahan.kd_kecamatan = Kecamatan.kd_kecamatan INNER JOIN Kabupaten ON Kecamatan.kd_kabupaten = Kabupaten.kd_kabupaten INNER JOIN Propinsi ON Kabupaten.kd_propinsi = Propinsi.kd_propinsi where Pasien.no_RM='" & txtRM.Text & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        txtAlamat.Text = DR.Item("alamat") + " RT " + DR.Item("rt") + " RW " + DR.Item("rw") + " Kel : " + DR.Item("nama_kelurahan") + " Kec : " + DR.Item("nama_kecamatan") + " Kab : " + DR.Item("nama_kabupaten") + " Prov : " + DR.Item("nama_propinsi")
        tglLahirPasien = DR.Item("tgl_lahir")
        txtSex.Text = DR.Item("jns_kel")
        TglServer()
        'txtUmurThn.Text = DateDiff(DateInterval.Year, tglLahirPasien, TanggalServer)
        'txtUmurBln.Text = DateDiff(DateInterval.Month, tglLahirPasien, TanggalServer) Mod 12
        txtUmurThn.Text = TanggalServer.Year - tglLahirPasien.Year
        txtUmurBln.Text = TanggalServer.Month - tglLahirPasien.Month
        If Val(txtUmurBln.Text) < 0 Then
            txtUmurThn.Text = Val(txtUmurThn.Text) - 1
            txtUmurBln.Text = 12 + Val(txtUmurBln.Text)
        End If

        'Penjamin
        konek()
        CMD = New SqlCommand("SELECT kd_penjamin,nama_penjamin FROM penjamin WHERE kd_penjamin='" & kdPenjamin & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            cmbPenjamin.Text = DR.Item("nama_penjamin") & "|" & DR.Item("kd_penjamin")
        Else
            cmbPenjamin.Text = "-|UMUM"
        End If

        'Dokter
        konek()
        CMD = New SqlCommand("SELECT no_reg, kd_dokter, kd_tempat_tidur FROM rawat_inap WHERE no_reg='" & txtNoReg.Text & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        kdDokter = DR.Item("kd_dokter")
        kdTempatTidur = DR.Item("kd_tempat_tidur")

        konek()
        CMD = New SqlCommand("select kd_pegawai, nama_pegawai from pegawai where kd_pegawai='" & kdDokter & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            cmbDokter.Text = DR.Item("nama_pegawai") & "|" & DR.Item("kd_pegawai")
        End If

        konek()
        CMD = New SqlCommand("select Sub_Unit.nama_sub_unit, Sub_Unit.kd_sub_unit from Tempat_Tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit where Tempat_Tidur.kd_tempat_tidur='" & kdTempatTidur & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            cmbUnitAsal.Text = DR.Item("nama_sub_unit") & "|" & DR.Item("kd_sub_unit")
        End If

        cmbPkt.SelectedIndex = 0
        cmbPkt.Focus()

        Try
            konek()
            DA = New SqlDataAdapter("select urut, nama_barang, hrgppn, jmlretpkt, jmlretnpkt, totalqty, nmsatuan, jmlhrgpkt, jmlhrgnpkt, jmlhrgret, dijamin, iurpasien, kdkasir, nmkasir, kdbagian, tanggal, notaretur, no_reg, no_rm, nama_pasien as nmpasien, umurthn, umurbln, kd_penjamin, nm_penjamin, idkdbrg as noid, kd_barang, idx_barang,  generik, kd_jns_obat, kd_kel_obat, kd_gol_obat, kdpabrik, rek_p, formularium, tglresep, notaresep, kddokter, nmdokter, posting, jns_obat from ap_returinap2 where notaretur='" & Trim(txtNoRetur.Text) & "' order by notaretur,urut", CONN)
            DSReturObatInapEdit = New DataSet
            DA.Fill(DSReturObatInapEdit, "pasienRIReturEdit")
            BDReturObatInapEdit.DataSource = DSReturObatInapEdit
            BDReturObatInapEdit.DataMember = "pasienRIReturEdit"
            With gridDetailObat
                .DataSource = Nothing
                .DataSource = BDReturObatInapEdit
            End With
            AturGriddetailBarang()
            TotalHargaRetPaket()
            TotalHargaRetNonPaket()
            TotalRetur()
            TotalDijamin()
            TotalIurPasien()
            txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1

            DS = New DataSet '''''''''''''''' Bantu Tambahan
            DA.Fill(DS) ''''''''''''''''''''' Bantu Tambahan
            With gridStokKembali
                .DataSource = Nothing
                .DataSource = DS.Tables(0)
            End With

            btnSimpan.Enabled = True
            btnBaru.Enabled = True
            btnHapusNota.Enabled = True
            btnCetakNota.Enabled = True
            cmbPkt.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub TotalHargaRetPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("jmlhrgpkt").Value
        Next
        txtGrandJmlHargaRetPaket.DecimalValue = HitungTotal
        txtGrandJmlHargaRetPaketBulat.DecimalValue = buletin(txtGrandJmlHargaRetPaket.DecimalValue, 100)
    End Sub

    Sub TotalHargaRetNonPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("jmlhrgnpkt").Value
        Next
        txtGrandJmlHargaRetNonPaket.DecimalValue = HitungTotal
        txtGrandJmlHargaRetNonPaketBulat.DecimalValue = buletin(txtGrandJmlHargaRetNonPaket.DecimalValue, 100)
    End Sub

    Sub TotalRetur()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("jmlhrgret").Value
        Next
        txtGrandTotalRetur.DecimalValue = HitungTotal
        txtGrandTotalReturBulat.DecimalValue = buletin(txtGrandTotalRetur.DecimalValue, 100)
        bilang = Terbilang(txtGrandTotalReturBulat.DecimalValue)
    End Sub

    Sub TotalDijamin()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("dijamin").Value
        Next
        txtGrandDijamin.DecimalValue = HitungTotal
        txtGrandDijaminBulat.DecimalValue = buletin(txtGrandDijamin.DecimalValue, 100)
    End Sub

    Sub TotalIurPasien()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("iurpasien").Value
        Next
        txtGrandIurBayar.DecimalValue = HitungTotal
        txtGrandIurBayarBulat.DecimalValue = buletin(txtGrandIurBayar.DecimalValue, 100)
    End Sub

    Sub detailObat()
        Try
            konek()
            CMD = New SqlCommand("select * FROM ap_jualr2 WHERE no_reg='" & txtNoReg.Text & "' AND  noid='" & noidBarang & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                txtIdxBarang.Text = Trim(DR.Item("idx_barang"))
                txtKodeObat.Text = Trim(DR.Item("kd_barang"))
                lblNamaObat.Text = Trim(DR.Item("nama_barang"))
                txtHarga.DecimalValue = DR.Item("hrgbeli")
                DTPTanggalResep.Value = DR.Item("tanggal")
                txtNotaResep.Text = Trim(DR.Item("notaresep"))
                CmbDokterResep.Text = Trim(DR.Item("nmdokter")) & "|" & Trim(DR.Item("kddokter"))
                txtJmlPaket.DecimalValue = DR.Item("jmlpaket")
                txtJmlNonPaket.DecimalValue = DR.Item("jmlnonpaket")
                txtTotalQty.DecimalValue = DR.Item("jml")
                txtSatuan.Text = Trim(DR.Item("nmsatuan"))
                txtJmlResepAwal.DecimalValue = Trim(DR.Item("jmlnet"))
                txtDijaminResepAwal.DecimalValue = DR.Item("dijamin")
                txtIurResepAwal.DecimalValue = DR.Item("sisabayar")
            End If
            konek()
            CMD = New SqlCommand("select * FROM barang_farmasi WHERE kd_barang='" & txtKodeObat.Text & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                Generik = Trim(DR.Item("generik"))
                kdJnsObat = Trim(DR.Item("kd_jns_obat"))
                KdKelObat = Trim(DR.Item("kd_kel_obat"))
                kdGolObat = Trim(DR.Item("kd_gol_obat"))
                kdPabrik = Trim(DR.Item("kdpabrik"))
                Formularium = Trim(DR.Item("formularium"))
                Rekening = "1105010010010001"
            End If
            konek()
            CMD = New SqlCommand("select * FROM jenis_obat WHERE kd_jns_obat='" & kdJnsObat & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                JenisObat = Trim(DR.Item("jns_obat"))
            End If
            txtRetPaket.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cetakNota()
        rpt = New ReportDocument
        Try
            Dim str As String = Application.StartupPath & "\Report\notaRetur.rpt"
            rpt.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rpt.SetDatabaseLogon(dbUser, dbPassword)
            rpt.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
            rpt.SetParameterValue("notaretur", txtNoRetur.Text)
            rpt.SetParameterValue("Alamat", txtAlamat.Text)
            rpt.SetParameterValue("unit", My.Settings.pnmapo)
            rpt.SetParameterValue("terbilang", bilang)
            rpt.SetParameterValue("totalJmlRetBulat", txtGrandJmlHargaRetPaketBulat.DecimalValue)
            rpt.SetParameterValue("totalDijaminBulat", txtGrandDijaminBulat.DecimalValue)
            rpt.SetParameterValue("totalIurPasienBulat", txtGrandIurBayarBulat.DecimalValue)
            FormCetak.CrystalReportViewer1.ReportSource = rpt
            FormCetak.CrystalReportViewer1.Show()
            FormCetak.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormEditReturRI_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnSimpan.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then
            btnCetakNota.PerformClick()
        ElseIf e.KeyCode = Keys.F10 Then
            btnBaru.PerformClick()
        End If
    End Sub

    Private Sub FormEditReturRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        KosongkanHeader()
        kosongkanDetail()
    End Sub

    Private Sub FormEditReturRI_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelPasien.Top = txtNoRetur.Top + 21
        PanelPasien.Left = txtNoRetur.Left
        PanelBarang.Top = txtKodeObat.Top + 140
        PanelBarang.Left = txtKodeObat.Left
    End Sub

    Private Sub txtNoRetur_Click(sender As Object, e As EventArgs) Handles txtNoRetur.Click
        DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
        Bulan = Month(DTPBantu.Value)
        Tahun = Year(DTPBantu.Value)
        cekTutupStok()
        If DR.HasRows Then
            DTPTanggalTrans.Focus()
            MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut sudah tutup stok", vbInformation, "Informasi")
            Exit Sub
        Else
            tampilPasienRetur()
            PanelPasien.Visible = True
            txtCariPasien.Clear()
            txtCariPasien.Focus()
        End If
    End Sub

    Private Sub txtNoRetur_GotFocus(sender As Object, e As EventArgs) Handles txtNoRetur.GotFocus
        DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
        Bulan = Month(DTPBantu.Value)
        Tahun = Year(DTPBantu.Value)
        cekTutupStok()
        If DR.HasRows Then
            DTPTanggalTrans.Focus()
            MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut sudah tutup stok", vbInformation, "Informasi")
            Exit Sub
        Else
            tampilPasienRetur()
            PanelPasien.Visible = True
            txtCariPasien.Clear()
            txtCariPasien.Focus()
        End If
    End Sub

    Private Sub btnEx_Click(sender As Object, e As EventArgs) Handles btnEx.Click
        tampilPasienRetur()
        PanelPasien.Visible = False
    End Sub

    Private Sub txtCariPasien_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPasien.KeyDown
        If e.KeyCode = Keys.Down Then
            gridPasien.Focus()
        End If
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
        BDDataPasienRIEdit.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
    End Sub

    Private Sub gridPasien_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPasien.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridPasien.Rows(e.RowIndex).Cells(1).Value) Then
                txtNoRetur.Text = gridPasien.Rows(e.RowIndex).Cells(3).Value
                txtNamaPasien.Text = gridPasien.Rows(e.RowIndex).Cells(6).Value
                Posting = gridPasien.Rows(e.RowIndex).Cells(7).Value
                txtJnsRawat.Text = "2"
                PanelPasien.Visible = False
                TampilRetur()
            End If
        End If
    End Sub

    Private Sub gridPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridPasien.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridPasien.CurrentRow.Index - 1
            If Not IsDBNull(gridPasien.Rows(i).Cells(1).Value) Then
                txtNoRetur.Text = gridPasien.Rows(i).Cells(3).Value
                txtNamaPasien.Text = gridPasien.Rows(i).Cells(6).Value
                txtJnsRawat.Text = "2"
                PanelPasien.Visible = False
                TampilRetur()
            End If
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub gridDetailObat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridDetailObat.CellContentClick

    End Sub

    Private Sub gridDetailObat_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObat.CellFormatting
        gridDetailObat.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub DTPTanggalTrans_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalTrans.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbPkt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPkt.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKodeObat.Focus()
        End If
    End Sub

    Private Sub cmbPkt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPkt.SelectedIndexChanged

    End Sub

    Private Sub txtKodeObat_Click(sender As Object, e As EventArgs) Handles txtKodeObat.Click
        tampilObat()
        PanelBarang.Visible = True
        txtCariBarang.Clear()
        txtCariBarang.Focus()
    End Sub

    Private Sub txtKodeObat_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObat.GotFocus
        tampilObat()
        PanelBarang.Visible = True
        txtCariBarang.Clear()
        txtCariBarang.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelBarang.Visible = False
    End Sub

    Private Sub txtKodeObat_TextChanged(sender As Object, e As EventArgs) Handles txtKodeObat.TextChanged

    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                noidBarang = gridBarang.Rows(e.RowIndex).Cells(1).Value
                PanelBarang.Visible = False
                detailObat()
            End If
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                noidBarang = gridBarang.Rows(i).Cells(1).Value
                PanelBarang.Visible = False
                detailObat()
            End If
        End If
    End Sub

    Private Sub txtCariBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariBarang.KeyDown
        If e.KeyCode = Keys.Down Then
            gridBarang.Focus()
        End If
    End Sub

    Private Sub txtCariBarang_TextChanged(sender As Object, e As EventArgs) Handles txtCariBarang.TextChanged
        BDobatInap.Filter = "nama_barang like '%" & txtCariBarang.Text & "%'"
    End Sub

    Private Sub txtRetPaket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRetPaket.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtRetPaket_LostFocus(sender As Object, e As EventArgs) Handles txtRetPaket.LostFocus
        If txtJmlPaket.DecimalValue < txtRetPaket.DecimalValue Then
            MsgBox("Jumlah retur melebihi jumlah resep", vbCritical, "Kesalahan")
            txtRetPaket.DecimalValue = 0
            txtRetPaket.Focus()
        End If
    End Sub

    Private Sub txtRetPaket_TextChanged(sender As Object, e As EventArgs) Handles txtRetPaket.TextChanged
        txtJmlHargaPaket.DecimalValue = txtRetPaket.DecimalValue * txtHarga.DecimalValue
        txtTotalHargaRetur.DecimalValue = txtJmlHargaPaket.DecimalValue + txtJmlHargaNonPaket.DecimalValue
        txtJumlahRetur.DecimalValue = txtRetPaket.DecimalValue + txtRetNonPaket.DecimalValue
    End Sub

    Private Sub txtRetNonPaket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRetNonPaket.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtRetNonPaket_LostFocus(sender As Object, e As EventArgs) Handles txtRetNonPaket.LostFocus
        If txtJmlNonPaket.DecimalValue < txtRetNonPaket.DecimalValue Then
            MsgBox("Jumlah retur melebihi jumlah resep", vbCritical, "Kesalahan")
            txtRetNonPaket.DecimalValue = 0
            txtRetNonPaket.Focus()
            Exit Sub
        End If
        If txtDijaminResepAwal.DecimalValue > 0 Then
            txtDijamin.DecimalValue = txtTotalHargaRetur.DecimalValue
        End If
    End Sub

    Private Sub txtRetNonPaket_TextChanged(sender As Object, e As EventArgs) Handles txtRetNonPaket.TextChanged
        txtJmlHargaNonPaket.DecimalValue = txtRetNonPaket.DecimalValue * txtHarga.DecimalValue
        txtTotalHargaRetur.DecimalValue = txtJmlHargaPaket.DecimalValue + txtJmlHargaNonPaket.DecimalValue
        txtJumlahRetur.DecimalValue = txtRetPaket.DecimalValue + txtRetNonPaket.DecimalValue
    End Sub

    Private Sub txtDijamin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDijamin.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtIurPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIurPasien.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtNoReg.Text = "" Then
            MsgBox("Pasien belum dipilih")
            txtNoReg.Focus()
            Exit Sub
        End If
        If txtKodeObat.Text = "" Then
            MsgBox("Obat belum dipilih")
            txtKodeObat.Focus()
            Exit Sub
        End If
        If txtJumlahRetur.DecimalValue = 0 Then
            MsgBox("Jumlah retur belum diisi")
            txtRetPaket.Focus()
            Exit Sub
        End If
        If txtTotalHargaRetur.DecimalValue = 0 Then
            MsgBox("Jumlah retur belum diisi")
            txtRetPaket.Focus()
            Exit Sub
        End If
        For barisGrid As Integer = 0 To gridDetailObat.RowCount - 1
            If noidBarang = gridDetailObat.Rows(barisGrid).Cells("noid").Value Then
                MsgBox("Obat ini sudah dientry")
                kosongkanDetail()
                txtKodeObat.Focus()
                Exit Sub
            End If
        Next
        addBarang()
        AturGriddetailBarang()
        kosongkanDetail()
        txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
        cmbPkt.Focus()
    End Sub

    Private Sub txtHapusBaris_Click(sender As Object, e As EventArgs) Handles txtHapusBaris.Click
        If MessageBox.Show("Yakin Akan Dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If gridDetailObat.CurrentRow.Index <> gridDetailObat.NewRowIndex Then
                    gridDetailObat.Rows.RemoveAt(gridDetailObat.CurrentRow.Index)
                End If
                txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
                TotalHargaRetPaket()
                TotalHargaRetNonPaket()
                TotalRetur()
                TotalDijamin()
                TotalIurPasien()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnHapusNota_Click(sender As Object, e As EventArgs) Handles btnHapusNota.Click
        If MessageBox.Show("Yakin transaksi ini akan dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If Posting = "2" Then
                MsgBox("Transaksi tidak bisa diedit, sudah diposting oleh kasir", vbInformation, "Informasi")
                Exit Sub
            End If
            cariSubUnitAsal()
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
            Dim sqlHapusReturObatRI As String = ""
            konek()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try

                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS APOTEK'''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_returinap1
                sqlHapusReturObatRI = "delete from ap_returinap1 where kdbagian='" & My.Settings.pkdapo & "' and notaretur='" & Trim(txtNoRetur.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_returinap2
                sqlHapusReturObatRI = sqlHapusReturObatRI + vbCrLf + "delete from ap_returinap2 where kdbagian='" & My.Settings.pkdapo & "' and notaretur='" & Trim(txtNoRetur.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS KASIR'''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual
                sqlHapusReturObatRI = sqlHapusReturObatRI + vbCrLf + "Delete from resep_jual_retur WHERE no_retur='" & Trim(txtNoRetur.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual_detail
                sqlHapusReturObatRI = sqlHapusReturObatRI + vbCrLf + "Delete from resep_jual_detail_retur WHERE no_retur='" & Trim(txtNoRetur.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''Stok Kembali Asal'''''''''''''''''''''''''''''''''''''''''''''
                If My.Settings.psts_stok = "1" Then
                    For i = 0 To gridStokKembali.RowCount - 2
                        'konek()
                        sqlHapusReturObatRI = sqlHapusReturObatRI + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "-" & Num_En_US((Num_En_US(gridDetailObat.Rows(i).Cells("jmlretpkt").Value) + Num_En_US(gridDetailObat.Rows(i).Cells("jmlretnpkt").Value))) & " WHERE kd_barang='" & Trim(gridStokKembali.Rows(i).Cells("kd_barang").Value) & "'"
                        'CMD.ExecuteNonQuery()
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CMD.CommandText = sqlHapusReturObatRI
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi retur berhasil dihapus", vbInformation, "Informasi")
                KosongkanHeader()
                kosongkanDetail()
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

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Posting = "2" Then
            MsgBox("Transaksi tidak bisa diedit, sudah diposting oleh kasir", vbInformation, "Informasi")
            Exit Sub
        End If
        cariSubUnitAsal()
        cariDokter2()
        cariNamaPenjamin()
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

        If MessageBox.Show("Data tersebut sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlEditReturRI As String = ""
            TglServer()
            DTPJamAkhir.Value = TanggalServer
            konek()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS APOTEK'''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_returinap1
                sqlEditReturRI = "delete from ap_returinap1 where kdbagian='" & My.Settings.pkdapo & "' and notaretur='" & Trim(txtNoRetur.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_returinap2
                sqlEditReturRI = sqlEditReturRI + vbCrLf + "delete from ap_returinap2 where kdbagian='" & My.Settings.pkdapo & "' and notaretur='" & Trim(txtNoRetur.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS KASIR'''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual
                sqlEditReturRI = sqlEditReturRI + vbCrLf + "Delete from resep_jual_retur WHERE no_retur='" & Trim(txtNoRetur.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual_detail
                sqlEditReturRI = sqlEditReturRI + vbCrLf + "Delete from resep_jual_detail_retur WHERE no_retur='" & Trim(txtNoRetur.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''Stok Kembali Asal'''''''''''''''''''''''''''''''''''''''''''''
                If My.Settings.psts_stok = "1" Then
                    For i = 0 To gridStokKembali.RowCount - 2
                        'konek()
                        sqlEditReturRI = sqlEditReturRI + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "-" & Num_En_US((Num_En_US(gridDetailObat.Rows(i).Cells("jmlretpkt").Value) + Num_En_US(gridDetailObat.Rows(i).Cells("jmlretnpkt").Value))) & " WHERE kd_barang='" & Trim(gridStokKembali.Rows(i).Cells("kd_barang").Value) & "'"
                        'CMD.ExecuteNonQuery()
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Apotek
                'konek()
                sqlEditReturRI = sqlEditReturRI + vbCrLf + "insert into ap_returinap1(kdkasir, nmkasir, kdbagian, tanggal, notaretur, no_reg, no_rm , nama_pasien, umurthn, umurbln, kd_penjamin, nm_penjamin, kddokter, nmdokter, jmlretpkt, jmlretpktblt, jmlretnpkt, jmlretnpktblt, totalretur, totalreturblt, dijamin, dijaminblt, iurpasien, iurpasienblt, posting)VALUES('" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & My.Settings.pkdapo & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoRetur.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "', '" & Trim(txtUmurThn.Text) & "', '" & Trim(txtUmurBln.Text) & "', '" & Trim(kdPenjamin) & "', '" & Trim(NamaPenjamin) & "', '" & Trim(kdDokter) & "', '" & Trim(NamaDokter) & "', '" & Num_En_US(txtGrandJmlHargaRetPaket.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaket.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalRetur.DecimalValue) & "', '" & Num_En_US(txtGrandTotalReturBulat.DecimalValue) & "', '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "', '" & Num_En_US(txtGrandIurBayar.DecimalValue) & "', '" & Num_En_US(txtGrandIurBayarBulat.DecimalValue) & "', '1')"
                'CMD.ExecuteNonQuery()

                For i = 0 To gridDetailObat.RowCount - 2
                    'konek()
                    sqlEditReturRI = sqlEditReturRI + vbCrLf + "INSERT INTO ap_returinap2(kdkasir, nmkasir, kdbagian, tanggal, notaretur, no_reg, no_rm , nama_pasien, umurthn, umurbln, kd_penjamin, nm_penjamin, urut, idkdbrg, kd_barang, idx_barang, nama_barang, generik, kd_jns_obat, kd_kel_obat, kd_gol_obat, kdpabrik, rek_p, formularium, tglresep, notaresep, kddokter, nmdokter, hrgppn, jmlretpkt, jmlretnpkt, totalqty, nmsatuan, jmlhrgpkt, jmlhrgnpkt, jmlhrgret, dijamin, iurpasien, posting, jns_obat) VALUES ('" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & My.Settings.pkdapo & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoRetur.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "', '" & Trim(txtUmurThn.Text) & "', '" & Trim(txtUmurBln.Text) & "', '" & Trim(kdPenjamin) & "', '" & Trim(NamaPenjamin) & "', " & i + 1 & ", '" & gridDetailObat.Rows(i).Cells("noid").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_barang").Value & "', '" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "', '" & gridDetailObat.Rows(i).Cells("nama_barang").Value & "', '" & gridDetailObat.Rows(i).Cells("generik").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_jns_obat").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_kel_obat").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_gol_obat").Value & "', '" & gridDetailObat.Rows(i).Cells("kdpabrik").Value & "', '" & gridDetailObat.Rows(i).Cells("rek_p").Value & "', '" & gridDetailObat.Rows(i).Cells("formularium").Value & "', '" & Format(gridDetailObat.Rows(i).Cells("tglresep").Value, "yyyy/MM/dd") & "', '" & gridDetailObat.Rows(i).Cells("notaresep").Value & "', '" & gridDetailObat.Rows(i).Cells("kddokter").Value & "', '" & gridDetailObat.Rows(i).Cells("nmdokter").Value & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgppn").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlretpkt").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlretnpkt").Value) & "', '" & Val(gridDetailObat.Rows(i).Cells("totalqty").Value) & "', '" & gridDetailObat.Rows(i).Cells("nmsatuan").Value & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgpkt").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgnpkt").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgret").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("iurpasien").Value) & "', '1', '" & gridDetailObat.Rows(i).Cells("jns_obat").Value & "')"
                    'CMD.ExecuteNonQuery()
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Kasir
                'konek()
                sqlEditReturRI = sqlEditReturRI + vbCrLf + "insert into resep_jual_retur(no_retur, no_rm, no_reg, jenis_rawat, tgl_retur, waktu, kd_dokter, kd_sub_unit, status_bayar, kd_kelompok_pelanggan, metode_bayar, total, user_id, user_nama, kd_sub_unit_asal, total_bulat, total_non_paket, total_non_paket_bulat, total_tunai, total_tunai_bulat, total_piutang, total_piutang_bulat)values('" & Trim(txtNoRetur.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNoReg.Text) & "', 'RI', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', '" & Trim(kdDokter) & "', '" & My.Settings.pkdsubunit & "', 'BELUM', '0', 'KREDIT', '" & Num_En_US(txtGrandJmlHargaRetPaket.DecimalValue) & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "','" & Trim(kdSubUnit) & "', '" & Num_En_US(txtGrandJmlHargaRetPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaket.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalRetur.DecimalValue) & "', '" & Num_En_US(txtGrandTotalReturBulat.DecimalValue) & "', '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "')"
                'CMD.ExecuteNonQuery()

                For i = 0 To gridDetailObat.RowCount - 2
                    'konek()
                    sqlEditReturRI = sqlEditReturRI + vbCrLf + "INSERT INTO resep_jual_detail_retur(no_retur, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, sesi_uid, nr, urutan, kd_sub_unit_asal, no_nota, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket)VALUES('" & Trim(txtNoRetur.Text) & "', '" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "', '" & gridDetailObat.Rows(i).Cells("nmsatuan").Value & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgppn").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgppn").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalqty").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '0', '0', '" & Num_En_US((Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgret").Value) - Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value))) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgret").Value) & "', '-', 'n',  " & i + 1 & ", '" & Trim(kdSubUnit) & "', '" & gridDetailObat.Rows(i).Cells("notaresep").Value & "', '0', '0', '" & gridDetailObat.Rows(i).Cells("rek_p").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_barang").Value & "', '" & gridDetailObat.Rows(i).Cells("nama_barang").Value & "', '0')"
                    'CMD.ExecuteNonQuery()
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Update Stok
                If My.Settings.psts_stok = "1" Then
                    For i = 0 To gridDetailObat.RowCount - 2
                        'konek()
                        sqlEditReturRI = sqlEditReturRI + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "+" & Num_En_US((Num_En_US(gridDetailObat.Rows(i).Cells("jmlretpkt").Value) + Num_En_US(gridDetailObat.Rows(i).Cells("jmlretnpkt").Value))) & " WHERE kd_barang='" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "'"
                        'CMD.ExecuteNonQuery()
                    Next
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CMD.CommandText = sqlEditReturRI
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi retur berhasil disimpan", vbInformation, "Informasi")
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

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        KosongkanHeader()
        kosongkanDetail()
    End Sub

    Private Sub btnCetakNota_Click(sender As Object, e As EventArgs) Handles btnCetakNota.Click
        FormPemanggil = "FormEditReturRI"
        cetakNota()
        btnCetakNota.Enabled = False
    End Sub
End Class