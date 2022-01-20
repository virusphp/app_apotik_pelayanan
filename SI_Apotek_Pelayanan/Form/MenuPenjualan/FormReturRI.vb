Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.ComponentModel

Public Class FormReturRI
	Inherits Office2010Form
	Public rpt As New ReportDocument

	Dim BDDataPasienRI, BDObatInap, BDReturObatInap As New BindingSource
	Dim DRWReturObatInap As DataRowView
	Dim DSReturObatInap As New DataSet
	Dim NamaPenjamin, kdPenjamin, kdDokter, NamaDokter, kdTempatTidur, noidBarang, Generik, kdJnsObat, KdKelObat, kdGolObat, kdPabrik, Formularium, Rekening, JenisObat, nmSubUnit, kdSubUnit, memStok, bilang As String
	Dim tglLahirPasien As DateTime
	'Dim Trans As SqlTransaction
	Dim Trans As OleDb.OleDbTransaction

	Sub KosongkanHeader()
		TglServer()
		DSReturObatInap = Table.BuatTabelReturObatInap("ReturObatInap")
		gridDetailObat.BackgroundColor = Color.Azure
		DSReturObatInap.Clear()
		gridDetailObat.DataSource = Nothing
		btnSimpan.Enabled = False
		btnCetakNota.Enabled = False
		btnBaru.Enabled = False
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
        'If MenuUtama.menuPemanggil = "FormReturObatPasienPulang" Then
        '    Me.Text = "Retur Obat Pasien Rawat Inap Pasien Pulang"
        'End If
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

	Sub NoRetur()
		Try
			CMD = New OleDb.OleDbCommand("select max(notaretur) as notaretur from ap_returinap1 where tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and kdbagian='" & pkdapo & "'", CONN)
			DA = New OleDb.OleDbDataAdapter(CMD)
			DT = New DataTable
			DA.Fill(DT)
			If IsDBNull(DT.Rows(0).Item("notaretur")) Then
				txtNoRetur.Text = pkdapo + "-" + "RT" + Format(DTPTanggalTrans.Value, "ddMMyy") + "001"
			Else
				txtNoRetur.Text = Microsoft.VisualBasic.Right(DT.Rows(0).Item("notaretur").ToString, 3) + 1
				If Len(txtNoRetur.Text) = 1 Then
					txtNoRetur.Text = pkdapo + "-" + "RT" + Format(DTPTanggalTrans.Value, "ddMMyy") + "00" & txtNoRetur.Text & ""
				ElseIf Len(txtNoRetur.Text) = 2 Then
					txtNoRetur.Text = pkdapo + "-" + "RT" + Format(DTPTanggalTrans.Value, "ddMMyy") + "0" & txtNoRetur.Text & ""
				ElseIf Len(txtNoRetur.Text) = 3 Then
					txtNoRetur.Text = pkdapo + "-" + "RT" + Format(DTPTanggalTrans.Value, "ddMMyy") + "" & txtNoRetur.Text & ""
				End If
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try
	End Sub

	Sub detailPasien()
		'Data Diri Pasien
		CMD = New OleDb.OleDbCommand("SELECT Pasien.no_RM, Pasien.alamat, Pasien.RT, Pasien.RW, Kelurahan.nama_kelurahan, Kecamatan.nama_kecamatan,Kabupaten.nama_kabupaten, Propinsi.nama_propinsi, pasien.nama_pasien, case pasien.jns_kel when '0' then 'P' else 'L' end as jns_kel, pasien.tgl_lahir FROM Pasien INNER JOIN Kelurahan ON Pasien.kd_kelurahan = Kelurahan.kd_kelurahan INNER JOIN Kecamatan ON Kelurahan.kd_kecamatan = Kecamatan.kd_kecamatan INNER JOIN Kabupaten ON Kecamatan.kd_kabupaten = Kabupaten.kd_kabupaten INNER JOIN Propinsi ON Kabupaten.kd_propinsi = Propinsi.kd_propinsi where Pasien.no_RM='" & txtRM.Text & "'", CONN)
		DA = New OleDb.OleDbDataAdapter(CMD)
		DT = New DataTable
		DA.Fill(DT)
		txtAlamat.Text = DT.Rows(0).Item("alamat") + " RT " + DT.Rows(0).Item("rt") + " RW " + DT.Rows(0).Item("rw") + " Kel : " + DT.Rows(0).Item("nama_kelurahan") + " Kec : " + DT.Rows(0).Item("nama_kecamatan") + " Kab : " + DT.Rows(0).Item("nama_kabupaten") + " Prov : " + DT.Rows(0).Item("nama_propinsi")
		tglLahirPasien = DT.Rows(0).Item("tgl_lahir")
		txtSex.Text = DT.Rows(0).Item("jns_kel")
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
		CMD = New OleDb.OleDbCommand("SELECT kd_penjamin,nama_penjamin FROM penjamin WHERE kd_penjamin='" & kdPenjamin & "'", CONN)
		DA = New OleDb.OleDbDataAdapter(CMD)
		DT = New DataTable
		DA.Fill(DT)
		If DT.Rows.Count > 0 Then
			cmbPenjamin.Text = DT.Rows(0).Item("nama_penjamin") & "|" & DT.Rows(0).Item("kd_penjamin")
		Else
			cmbPenjamin.Text = "-|UMUM"
		End If

		'Dokter
		CMD = New OleDb.OleDbCommand("SELECT no_reg, kd_dokter, kd_tempat_tidur FROM rawat_inap WHERE no_reg='" & txtNoReg.Text & "'", CONN)
		DA = New OleDb.OleDbDataAdapter(CMD)
		DT = New DataTable
		DA.Fill(DT)
		kdDokter = DT.Rows(0).Item("kd_dokter")
		kdTempatTidur = DT.Rows(0).Item("kd_tempat_tidur")

		CMD = New OleDb.OleDbCommand("select kd_pegawai, nama_pegawai from pegawai where kd_pegawai='" & kdDokter & "'", CONN)
		DA = New OleDb.OleDbDataAdapter(CMD)
		DT = New DataTable
		DA.Fill(DT)
		If DT.Rows.Count > 0 Then
			cmbDokter.Text = DT.Rows(0).Item("nama_pegawai") & "|" & DT.Rows(0).Item("kd_pegawai")
		End If

		CMD = New OleDb.OleDbCommand("select Sub_Unit.nama_sub_unit, Sub_Unit.kd_sub_unit from Tempat_Tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit where Tempat_Tidur.kd_tempat_tidur='" & kdTempatTidur & "'", CONN)
		DA = New OleDb.OleDbDataAdapter(CMD)
		DT = New DataTable
		DA.Fill(DT)
		If DT.Rows.Count > 0 Then
			cmbUnitAsal.Text = DT.Rows(0).Item("nama_sub_unit") & "|" & DT.Rows(0).Item("kd_sub_unit")
		End If
		cmbPkt.SelectedIndex = 0
		cmbPkt.Focus()
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

    'Sub ListDokter()
    '    konek()
    '    CMD = New OleDb.OleDbCommand("select kd_pegawai,nama_pegawai,gelar_depan from pegawai where kd_jns_pegawai=1 order by nama_pegawai", CONN)
    '    DA = New OleDb.OleDbDataAdapter(CMD)
    '    DT = New DataTable
    '    DA.Fill(DT)
    '    cmbDokter.Items.Clear()
    '    cmbDokter.Items.Add("")
    '    For i As Integer = 0 To DT.Rows.Count - 1
    '        cmbDokter.Items.Add(DT.Rows(i)("nama_pegawai") & "|" & DT.Rows(i)("kd_pegawai"))
    '    Next
    '    cmbDokter.AutoCompleteSource = AutoCompleteSource.ListItems
    '    cmbDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    'End Sub

    Sub tampilPasienRI()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT top 1000 Registrasi.tgl_reg, Registrasi.no_reg, Registrasi.no_RM, LTRIM(RTRIM(pasien.nama_pasien)) as nama_pasien, Sub_Unit.nama_sub_unit, Registrasi.jns_rawat, Registrasi.kd_penjamin FROM  Registrasi INNER JOIN Pasien ON Registrasi.no_RM = Pasien.no_RM INNER JOIN Rawat_Inap ON Registrasi.no_reg = Rawat_Inap.no_reg INNER JOIN Tempat_Tidur ON Rawat_Inap.kd_tempat_tidur = Tempat_Tidur.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit where Registrasi.jns_rawat='2' and Registrasi.status_keluar=0 order by registrasi.tgl_reg Desc", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasienRI")
            BDDataPasienRI.DataSource = DS
            BDDataPasienRI.DataMember = "pasienRI"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDDataPasienRI
                .Columns(1).HeaderText = "Tanggal Daftar"
                .Columns(2).HeaderText = "No Registrasi"
                .Columns(3).HeaderText = "No RM"
                .Columns(4).HeaderText = "Nama Pasien"
                .Columns(5).HeaderText = "Ruang"
                .Columns(0).Width = 30
                .Columns(1).Width = 75
                .Columns(2).Width = 90
                .Columns(3).Width = 50
                .Columns(4).Width = 130
                .Columns(5).Width = 120
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            lblKetDaftar.Text = "Daftar Pasien Rawat Inap Dalam Perawatan"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampilPasienRIPulang()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT top 1000 Registrasi.tgl_reg, Registrasi.no_reg, Registrasi.no_RM, LTRIM(RTRIM(pasien.nama_pasien)) as nama_pasien, Sub_Unit.nama_sub_unit, Registrasi.jns_rawat, Registrasi.kd_penjamin FROM  Registrasi INNER JOIN Pasien ON Registrasi.no_RM = Pasien.no_RM INNER JOIN Rawat_Inap ON Registrasi.no_reg = Rawat_Inap.no_reg INNER JOIN Tempat_Tidur ON Rawat_Inap.kd_tempat_tidur = Tempat_Tidur.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit where Registrasi.jns_rawat='2' and Registrasi.status_keluar=1 order by registrasi.tgl_reg Desc", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasienRI")
            BDDataPasienRI.DataSource = DS
            BDDataPasienRI.DataMember = "pasienRI"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDDataPasienRI
                .Columns(1).HeaderText = "Tanggal Daftar"
                .Columns(2).HeaderText = "No Registrasi"
                .Columns(3).HeaderText = "No RM"
                .Columns(4).HeaderText = "Nama Pasien"
                .Columns(5).HeaderText = "Ruang"
                .Columns(0).Width = 30
                .Columns(1).Width = 75
                .Columns(2).Width = 90
                .Columns(3).Width = 50
                .Columns(4).Width = 130
                .Columns(5).Width = 120
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            lblKetDaftar.Text = "Daftar Pasien Rawat Inap Dalam Perawatan"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampilObat()
		Try
			DA = New OleDb.OleDbDataAdapter("SELECT noid, tanggal, notaresep, LTRIM(RTRIM(nmdokter)), LTRIM(RTRIM(nama_barang)) as nama_barang, jmlpaket, jmlnonpaket, jml, LTRIM(RTRIM(nmsatuan)) FROM ap_jualr2 WHERE no_reg='" & txtNoReg.Text & "' ORDER BY tanggal,notaresep,noid", CONN)
			DS = New DataSet
			DA.Fill(DS, "ObatInap")
			BDObatInap.DataSource = DS
			BDObatInap.DataMember = "ObatInap"
			With gridBarang
				.DataSource = Nothing
				.DataSource = BDObatInap
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
			lblKetDaftar.Text = "Daftar Pasien Rawat Inap Dalam Perawatan"
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try

	End Sub

	Sub detailObat()
		Try
			CMD = New OleDb.OleDbCommand("select * FROM ap_jualr2 WHERE no_reg='" & txtNoReg.Text & "' AND  noid='" & noidBarang & "'", CONN)
			DA = New OleDb.OleDbDataAdapter(CMD)
			DT = New DataTable
			DA.Fill(DT)
			If DT.Rows.Count > 0 Then
				txtIdxBarang.Text = Trim(DT.Rows(0).Item("idx_barang"))
				txtKodeObat.Text = Trim(DT.Rows(0).Item("kd_barang"))
				lblNamaObat.Text = Trim(DT.Rows(0).Item("nama_barang"))
				txtHarga.DecimalValue = DT.Rows(0).Item("hrgbeli")
				DTPTanggalResep.Value = DT.Rows(0).Item("tanggal")
				txtNotaResep.Text = Trim(DT.Rows(0).Item("notaresep"))
				CmbDokterResep.Text = Trim(DT.Rows(0).Item("nmdokter")) & "|" & Trim(DT.Rows(0).Item("kddokter"))
				txtJmlPaket.DecimalValue = DT.Rows(0).Item("jmlpaket")
				txtJmlNonPaket.DecimalValue = DT.Rows(0).Item("jmlnonpaket")
				txtTotalQty.DecimalValue = DT.Rows(0).Item("jml")
				txtSatuan.Text = Trim(DT.Rows(0).Item("nmsatuan"))
				txtJmlResepAwal.DecimalValue = Trim(DT.Rows(0).Item("jmlnet"))
				txtDijaminResepAwal.DecimalValue = DT.Rows(0).Item("dijamin")
				txtIurResepAwal.DecimalValue = DT.Rows(0).Item("sisabayar")
			End If

			CMD = New OleDb.OleDbCommand("select * FROM barang_farmasi WHERE kd_barang='" & txtKodeObat.Text & "'", CONN)
			DA = New OleDb.OleDbDataAdapter(CMD)
			DT = New DataTable
			DA.Fill(DT)
			If DT.Rows.Count > 0 Then
				Generik = Trim(DT.Rows(0).Item("generik"))
				kdJnsObat = Trim(DT.Rows(0).Item("kd_jns_obat"))
				KdKelObat = Trim(DT.Rows(0).Item("kd_kel_obat"))
				kdGolObat = Trim(DT.Rows(0).Item("kd_gol_obat"))
				kdPabrik = Trim(DT.Rows(0).Item("kdpabrik"))
				Formularium = Trim(DT.Rows(0).Item("formularium"))

			End If
			CMD = New OleDb.OleDbCommand("select * FROM jenis_obat WHERE kd_jns_obat='" & kdJnsObat & "'", CONN)
			DA = New OleDb.OleDbDataAdapter(CMD)
			DT = New DataTable
			DA.Fill(DT)
			If DT.Rows.Count > 0 Then
				JenisObat = Trim(DT.Rows(0).Item("jns_obat"))
				Rekening = Trim(DT.Rows(0).Item("rek_p"))
			End If
			txtRetPaket.Focus()
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
			'kdPenjamin = (ary(1))
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

	Sub addBarang()
		cariNamaPenjamin()
		cariDokter()

		BDReturObatInap.DataSource = DSReturObatInap
		BDReturObatInap.DataMember = "ReturObatInap"

		BDReturObatInap.AddNew()
		DRWReturObatInap = BDReturObatInap.Current
		DRWReturObatInap("kdkasir") = Trim(FormLogin.LabelKode.Text)
		DRWReturObatInap("nmkasir") = Trim(FormLogin.LabelNama.Text)
		DRWReturObatInap("kdbagian") = pkdapo
		DRWReturObatInap("tanggal") = DTPTanggalTrans.Value
		DRWReturObatInap("notaretur") = Trim(txtNoRetur.Text)
		DRWReturObatInap("no_reg") = Trim(txtNoReg.Text)
		DRWReturObatInap("no_rm") = Trim(txtRM.Text)
		DRWReturObatInap("nmpasien") = Trim(txtNamaPasien.Text)
		DRWReturObatInap("umurthn") = Trim(txtUmurThn.Text)
		DRWReturObatInap("umurbln") = Trim(txtUmurBln.Text)
		DRWReturObatInap("kd_penjamin") = Trim(kdPenjamin)
		DRWReturObatInap("nm_penjamin") = Trim(NamaPenjamin)
		DRWReturObatInap("urut") = 1
		DRWReturObatInap("noid") = Trim(noidBarang)
		DRWReturObatInap("kd_barang") = Trim(txtKodeObat.Text)
		DRWReturObatInap("idx_barang") = Trim(txtIdxBarang.Text)
		DRWReturObatInap("nama_barang") = Trim(lblNamaObat.Text)
		DRWReturObatInap("generik") = Trim(Generik)
		DRWReturObatInap("kd_jns_obat") = Trim(kdJnsObat)
		DRWReturObatInap("kd_gol_obat") = Trim(kdGolObat)
		DRWReturObatInap("kd_kel_obat") = Trim(KdKelObat)
		DRWReturObatInap("kdpabrik") = Trim(kdPabrik)
		DRWReturObatInap("rek_p") = Trim(Rekening)
		DRWReturObatInap("formularium") = Trim(Formularium)
		DRWReturObatInap("tglresep") = DTPTanggalResep.Value
		DRWReturObatInap("notaresep") = Trim(txtNotaResep.Text)
		DRWReturObatInap("kddokter") = Trim(kdDokter)
		DRWReturObatInap("nmdokter") = Trim(NamaDokter)
		DRWReturObatInap("hrgppn") = txtHarga.DecimalValue
		DRWReturObatInap("jmlretpkt") = txtRetPaket.DecimalValue
		DRWReturObatInap("jmlretnpkt") = txtRetNonPaket.DecimalValue
		DRWReturObatInap("totalqty") = txtJumlahRetur.DecimalValue
		DRWReturObatInap("nmsatuan") = Trim(txtSatuan.Text)
		DRWReturObatInap("jmlhrgpkt") = txtJmlHargaPaket.DecimalValue
		DRWReturObatInap("jmlhrgnpkt") = txtJmlHargaNonPaket.DecimalValue
		DRWReturObatInap("jmlhrgret") = txtTotalHargaRetur.DecimalValue
		DRWReturObatInap("dijamin") = txtDijamin.DecimalValue
		DRWReturObatInap("iurpasien") = txtIurPasien.DecimalValue
		DRWReturObatInap("jns_obat") = Trim(JenisObat)

		BDReturObatInap.EndEdit()

		gridDetailObat.DataSource = Nothing
		gridDetailObat.DataSource = BDReturObatInap

		TotalHargaRetPaket()
		TotalHargaRetNonPaket()
		TotalRetur()
		TotalDijamin()
		TotalIurPasien()
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
			rpt.SetParameterValue("unit", pnmapo)
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

	Private Sub FormReturRI_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
		If e.KeyCode = Keys.F12 Then
			btnSimpan.PerformClick()
		ElseIf e.KeyCode = Keys.F1 Then
			btnCetakNota.PerformClick()
		ElseIf e.KeyCode = Keys.F10 Then
			btnBaru.PerformClick()
		End If
	End Sub

	Private Sub FormReturRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		setApo()
		Me.KeyPreview = True
        FormPemanggil = "FormReturRI"
        KosongkanHeader()
        NoRetur()
	End Sub

    Private Sub txtNoReg_Click(sender As Object, e As EventArgs) Handles txtNoReg.Click
        'If MenuUtama.menuPemanggil = "FormReturObatPasienPulang" Then
        '    tampilPasienRIPulang()
        'Else
        tampilPasienRI()
        'End If
        PanelPasien.Visible = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub txtNoReg_GotFocus(sender As Object, e As EventArgs) Handles txtNoReg.GotFocus
		tampilPasienRI()
		PanelPasien.Visible = True
		txtCariPasien.Clear()
		txtCariPasien.Focus()
	End Sub

	Private Sub FormReturRI_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
		PanelPasien.Top = txtNoReg.Top + 21
		PanelPasien.Left = txtNoReg.Left
		PanelBarang.Top = txtKodeObat.Top + 140
		PanelBarang.Left = txtKodeObat.Left
	End Sub

	Private Sub txtNoRetur_KeyPress(sender As Object, e As KeyPressEventArgs)
		If e.KeyChar = Chr(13) Then
			SendKeys.Send("{TAB}")
		End If
	End Sub

	Private Sub gridPasien_CellContentClick_1(sender As Object, e As DataGridViewCellEventArgs) Handles gridPasien.CellContentClick
		If e.ColumnIndex = 0 Then
			If Not IsDBNull(gridPasien.Rows(e.RowIndex).Cells(1).Value) Then
				txtNoReg.Text = gridPasien.Rows(e.RowIndex).Cells(2).Value
				txtRM.Text = gridPasien.Rows(e.RowIndex).Cells(3).Value
				txtNamaPasien.Text = gridPasien.Rows(e.RowIndex).Cells(4).Value
				txtJnsRawat.Text = "2"
				If IsDBNull(gridPasien.Rows(e.RowIndex).Cells(7).Value) Then
					kdPenjamin = "UMUM"
				Else
					kdPenjamin = gridPasien.Rows(e.RowIndex).Cells(7).Value
				End If
				cmbPenjamin.Text = kdPenjamin
				PanelPasien.Visible = False
				detailPasien()
				btnBaru.Enabled = True
			End If
			'btnInfoResep.Enabled = True
			'btnBaru.Enabled = True
			'btnInfoResepKh.Enabled = True
			'btnBaruKh.Enabled = True
		End If
	End Sub

	Private Sub gridPasien_KeyPress1(sender As Object, e As KeyPressEventArgs) Handles gridPasien.KeyPress
		If e.KeyChar = Chr(13) Then
			Dim i = gridPasien.CurrentRow.Index - 1
			If Not IsDBNull(gridPasien.Rows(i).Cells(1).Value) Then
				txtNoReg.Text = gridPasien.Rows(i).Cells(2).Value
				txtRM.Text = gridPasien.Rows(i).Cells(3).Value
				txtNamaPasien.Text = gridPasien.Rows(i).Cells(4).Value
				txtJnsRawat.Text = "2"
				If IsDBNull(gridPasien.Rows(i).Cells(7).Value) Then
					kdPenjamin = "UMUM"
				Else
					kdPenjamin = gridPasien.Rows(i).Cells(7).Value
				End If
				cmbPenjamin.Text = kdPenjamin
				PanelPasien.Visible = False
				detailPasien()
				btnBaru.Enabled = True
			End If
			'btnInfoResep.Enabled = True
			'btnBaru.Enabled = True
			'btnInfoResepKh.Enabled = True
			'btnBaruKh.Enabled = True
		End If
	End Sub

	Private Sub btnEx_Click_1(sender As Object, e As EventArgs) Handles btnEx.Click
		PanelPasien.Visible = False
	End Sub

	Private Sub txtCariPasien_KeyDown1(sender As Object, e As KeyEventArgs) Handles txtCariPasien.KeyDown
		If e.KeyCode = Keys.Down Then
			gridPasien.Focus()
		End If
	End Sub

	Private Sub txtCariPasien_TextChanged_1(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
		If rRm.Checked = True Then
			BDDataPasienRI.Filter = "no_RM like '%" & txtCariPasien.Text & "%'"
		Else
			BDDataPasienRI.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
		End If
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		PanelBarang.Visible = False
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

	Private Sub cmbPkt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPkt.KeyPress
		If e.KeyChar = Chr(13) Then
			txtKodeObat.Focus()
		End If
	End Sub

	Private Sub txtCariBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariBarang.KeyDown
		If e.KeyCode = Keys.Down Then
			gridBarang.Focus()
		End If
	End Sub

	Private Sub txtCariBarang_TextChanged(sender As Object, e As EventArgs) Handles txtCariBarang.TextChanged
		BDObatInap.Filter = "nama_barang like '%" & txtCariBarang.Text & "%'"
	End Sub

	Private Sub GridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
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

	Private Sub txtNoRetur_KeyPress_1(sender As Object, e As KeyPressEventArgs) Handles txtNoRetur.KeyPress
		If e.KeyChar = Chr(13) Then
			SendKeys.Send("{TAB}")
		End If
	End Sub

	Private Sub txtRetPaket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRetPaket.KeyPress
		If e.KeyChar = Chr(13) Then
			SendKeys.Send("{TAB}")
		End If
	End Sub

    Private Sub CurrencyTextBox3_LostFocus(sender As Object, e As EventArgs) Handles txtRetPaket.LostFocus
        If txtJmlPaket.DecimalValue < txtRetPaket.DecimalValue Then
            MsgBox("Jumlah retur melebihi jumlah resep", vbCritical, "Kesalahan")
            txtRetPaket.DecimalValue = 0
            txtRetPaket.Focus()
        End If
    End Sub

    Private Sub CurrencyTextBox3_TextChanged(sender As Object, e As EventArgs) Handles txtRetPaket.TextChanged
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

	Private Sub CurrencyTextBox6_TextChanged(sender As Object, e As EventArgs) Handles txtRetNonPaket.TextChanged
		txtJmlHargaNonPaket.DecimalValue = txtRetNonPaket.DecimalValue * txtHarga.DecimalValue
		txtTotalHargaRetur.DecimalValue = txtJmlHargaPaket.DecimalValue + txtJmlHargaNonPaket.DecimalValue
		txtJumlahRetur.DecimalValue = txtRetPaket.DecimalValue + txtRetNonPaket.DecimalValue
	End Sub

	Private Sub CurrencyTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIurPasien.KeyPress
		If e.KeyChar = Chr(13) Then
			SendKeys.Send("{TAB}")
		End If
	End Sub

	Private Sub txtDijamin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDijamin.KeyPress
		If e.KeyChar = Chr(13) Then
			SendKeys.Send("{TAB}")
		End If
	End Sub

	Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
		Dispose()
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
		btnSimpan.Enabled = True
		cmbPkt.Focus()
	End Sub

	Private Sub gridDetailObat_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObat.CellFormatting
		gridDetailObat.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
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

	Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
		KosongkanHeader()
		kosongkanDetail()
		NoRetur()
		txtNoRetur.Focus()
	End Sub

	Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
		If MessageBox.Show("Data tersebut sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
			cariSubUnitAsal()
			If pkdapo = "001" Then
				memStok = "stok001"
			ElseIf pkdapo = "002" Then
				memStok = "stok002"
			ElseIf pkdapo = "003" Then
				memStok = "stok003"
			ElseIf pkdapo = "004" Then
				memStok = "stok004"
			ElseIf pkdapo = "005" Then
				memStok = "stok005"
			ElseIf pkdapo = "006" Then
				memStok = "stok006"
			ElseIf pkdapo = "007" Then
				memStok = "stok007"
			Else
				MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
			End If

			Dim sqlReturObatInap As String = ""
			NoRetur()
			TglServer()
			DTPJamAkhir.Value = TanggalServer
			Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
			CMD.Connection = CONN
			CMD.Transaction = Trans
			Try
				'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Apotek
				'konek()
				sqlReturObatInap = "insert into ap_returinap1(kdkasir, nmkasir, kdbagian, tanggal, notaretur, no_reg, no_rm , nama_pasien, umurthn, umurbln, kd_penjamin, nm_penjamin, kddokter, nmdokter, jmlretpkt, jmlretpktblt, jmlretnpkt, jmlretnpktblt, totalretur, totalreturblt, dijamin, dijaminblt, iurpasien, iurpasienblt, posting)VALUES('" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & pkdapo & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoRetur.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "', '" & Trim(txtUmurThn.Text) & "', '" & Trim(txtUmurBln.Text) & "', '" & Trim(kdPenjamin) & "', '" & Trim(NamaPenjamin) & "', '" & Trim(kdDokter) & "', '" & Trim(NamaDokter) & "', '" & Num_En_US(txtGrandJmlHargaRetPaket.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaket.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalRetur.DecimalValue) & "', '" & Num_En_US(txtGrandTotalReturBulat.DecimalValue) & "', '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "', '" & Num_En_US(txtGrandIurBayar.DecimalValue) & "', '" & Num_En_US(txtGrandIurBayarBulat.DecimalValue) & "', '1')"
				'CMD.ExecuteNonQuery()

				For i = 0 To gridDetailObat.RowCount - 2
					'konek()
					sqlReturObatInap = sqlReturObatInap + vbCrLf + "INSERT INTO ap_returinap2(kdkasir, nmkasir, kdbagian, tanggal, notaretur, no_reg, no_rm , nama_pasien, umurthn, umurbln, kd_penjamin, nm_penjamin, urut, idkdbrg, kd_barang, idx_barang, nama_barang, generik, kd_jns_obat, kd_kel_obat, kd_gol_obat, kdpabrik, rek_p, formularium, tglresep, notaresep, kddokter, nmdokter, hrgppn, jmlretpkt, jmlretnpkt, totalqty, nmsatuan, jmlhrgpkt, jmlhrgnpkt, jmlhrgret, dijamin, iurpasien, posting, jns_obat) VALUES ('" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & pkdapo & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoRetur.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "', '" & Trim(txtUmurThn.Text) & "', '" & Trim(txtUmurBln.Text) & "', '" & Trim(kdPenjamin) & "', '" & Trim(NamaPenjamin) & "', " & i + 1 & ", '" & gridDetailObat.Rows(i).Cells("noid").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_barang").Value & "', '" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "', '" & Rep(gridDetailObat.Rows(i).Cells("nama_barang").Value) & "', '" & gridDetailObat.Rows(i).Cells("generik").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_jns_obat").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_kel_obat").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_gol_obat").Value & "', '" & gridDetailObat.Rows(i).Cells("kdpabrik").Value & "', '" & gridDetailObat.Rows(i).Cells("rek_p").Value & "', '" & gridDetailObat.Rows(i).Cells("formularium").Value & "', '" & Format(gridDetailObat.Rows(i).Cells("tglresep").Value, "yyyy/MM/dd") & "', '" & gridDetailObat.Rows(i).Cells("notaresep").Value & "', '" & gridDetailObat.Rows(i).Cells("kddokter").Value & "', '" & gridDetailObat.Rows(i).Cells("nmdokter").Value & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgppn").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlretpkt").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlretnpkt").Value) & "', '" & Val(gridDetailObat.Rows(i).Cells("totalqty").Value) & "', '" & gridDetailObat.Rows(i).Cells("nmsatuan").Value & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgpkt").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgnpkt").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgret").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("iurpasien").Value) & "', '1', '" & gridDetailObat.Rows(i).Cells("jns_obat").Value & "')"
					'CMD.ExecuteNonQuery()
				Next
				'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Kasir
				'konek()
				sqlReturObatInap = sqlReturObatInap + vbCrLf + "insert into resep_jual_retur(no_retur, no_rm, no_reg, jenis_rawat, tgl_retur, waktu, kd_dokter, kd_sub_unit, status_bayar, kd_kelompok_pelanggan, metode_bayar, total, user_id, user_nama, kd_sub_unit_asal, total_bulat, total_non_paket, total_non_paket_bulat, total_tunai, total_tunai_bulat, total_piutang, total_piutang_bulat)values('" & Trim(txtNoRetur.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNoReg.Text) & "', 'RI', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', '" & Trim(kdDokter) & "', '" & pkdsubunit & "', 'BELUM', '0', 'KREDIT', '" & Num_En_US(txtGrandJmlHargaRetPaket.DecimalValue) & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "','" & Trim(kdSubUnit) & "', '" & Num_En_US(txtGrandJmlHargaRetPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaket.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalRetur.DecimalValue) & "', '" & Num_En_US(txtGrandTotalReturBulat.DecimalValue) & "', '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "')"
				'CMD.ExecuteNonQuery()

				For i = 0 To gridDetailObat.RowCount - 2
					'konek()
					sqlReturObatInap = sqlReturObatInap + vbCrLf + "INSERT INTO resep_jual_detail_retur(no_retur, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, sesi_uid, nr, urutan, kd_sub_unit_asal, no_nota, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket)VALUES('" & Trim(txtNoRetur.Text) & "', '" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "', '" & gridDetailObat.Rows(i).Cells("nmsatuan").Value & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgppn").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgppn").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalqty").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '0', '0', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgret").Value - gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgret").Value) & "', '-', 'n',  " & i + 1 & ", '" & Trim(kdSubUnit) & "', '" & gridDetailObat.Rows(i).Cells("notaresep").Value & "', '0', '0', '" & gridDetailObat.Rows(i).Cells("rek_p").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_barang").Value & "', '" & Rep(gridDetailObat.Rows(i).Cells("nama_barang").Value) & "', '0')"
					'CMD.ExecuteNonQuery()
				Next

				'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Update Stok
				If psts_stok = "1" Then
					For i = 0 To gridDetailObat.RowCount - 2
						sqlReturObatInap = sqlReturObatInap + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "+" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlretpkt").Value + gridDetailObat.Rows(i).Cells("jmlretnpkt").Value) & " WHERE kd_barang='" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "'"
						'CMD.ExecuteNonQuery()
					Next
				End If
				''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
				CMD.CommandText = sqlReturObatInap
				CMD.ExecuteNonQuery()
				Trans.Commit()
				MsgBox("Transaksi retur berhasil disimpan", vbInformation, "Informasi")
				btnSimpan.Enabled = False
				btnCetakNota.Enabled = True
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

    Private Sub btnCetakNota_Click(sender As Object, e As EventArgs) Handles btnCetakNota.Click
        FormPemanggil = "FormReturRI"
        cetakNota()
        btnCetakNota.Enabled = False
    End Sub

    Private Sub FormReturRI_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
		Dispose()
	End Sub

    Private Sub FormReturRI_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dispose()
    End Sub
End Class