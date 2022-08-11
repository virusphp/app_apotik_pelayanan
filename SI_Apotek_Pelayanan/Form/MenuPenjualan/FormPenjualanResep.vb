Imports Syncfusion.Windows.Forms
Imports System.Data.SqlClient
Imports System.Globalization
Imports CrystalDecisions.CrystalReports.Engine
Imports Syncfusion.XlsIO
Imports CrystalDecisions.Shared
Imports GemBox.Spreadsheet

Public Class FormPenjualanResep
    Inherits Office2010Form
    Public rptNota, rptBPJS, rptLain As New ReportDocument
    Dim StatusRawat, JenisRawat, KdPenjamin, kdDokter, kdPoliklinik, kdTempatTidur, Stok, Generik, KdJenisObat, kdPabrik, kdKelompokObat, kdGolonganObat, NamaPenjamin, NamaDokter, kdTakaran, kdWaktu, kdKeterangan, JenisObat, memStok, kdSubUnit, nmPaket, kDRekening, modelEtiket, kdKeteranganModel3, nmKeteranganModel3 As String
    Public nmSubUnit, bilang, nmTakaran, nmWaktu, nmKeterangan, kdIcdSKU, kdIcdRM, noKartu, noSep As String
    Dim tglLahirPasien As DateTime
    Dim HargaBeli, DiskonDinkes As Double
    Dim BDEtiket, BDEtiketModel4 As New BindingSource
    Dim DSEtiket, DSEtiketModel4 As New DataSet
    Dim DRWEtiket, DRWEtiketModel4 As DataRowView
    Public jmlHariEtiketModel4 As Integer

    Dim BDPenjualanResep, BDPenjualanResepKh, BDDataBarang, BDDataPasienRI, BDDataPasienRJ, BDDataPasienRD As New BindingSource
    Dim DSPenjualanResep, DSPenjualanResepKh As New DataSet
    Dim DRWPenjualanResep, DRWPenjualanResepKh As DataRowView

    'Dim Trans As SqlTransaction
    Dim Trans As OleDb.OleDbTransaction

    Sub KosongkanHeader()
        DSPenjualanResep = Table.BuatTabelPenjualanResep("PenjualanResep")
        DSPenjualanResepKh = Table.BuatTabelPenjualanResepKh("PenjualanResepKh")
        DSEtiketModel4 = Table.BuatTabelEtiketModel4("EtiketModel4")
        gridDetailObat.BackgroundColor = Color.Azure
        DSPenjualanResep.Clear()
        gridDetailObat.DataSource = Nothing
        gridDetailObatKh.BackgroundColor = Color.Azure
        DSPenjualanResepKh.Clear()
        gridDetailObatKh.DataSource = Nothing
        DSEtiketModel4.Clear()
        gridEtiket.DataSource = Nothing
        TglServer()
        DTPTanggalTrans.Value = TanggalServer
        DTPJamAwal.Value = TanggalServer
        If pkdapo = "002" Then
            'DTPTanggalExp.Value = TanggalServer
            DTPTanggalExp.Value = DateAdd("d", 30, DTPTanggalTrans.Value)
        Else
            DTPTanggalExp.Value = DateAdd("d", 30, DTPTanggalTrans.Value)
        End If
        If pkdapo = "004" Then
            DTPTanggalTrans.Enabled = True
        End If
        lblKamarBed.Text = ""
        txtNoResep.Clear()
        txtNoReg.Clear()
        txtJnsRawat.Clear()
        txtNoUrut.Clear()
        txtRM.Clear()
        txtSex.Clear()
        txtUmurBln.Clear()
        txtUmurThn.Clear()
        txtNamaPasien.Clear()
        txtAlamat.Clear()
        txtGrandTotal.Clear()
        txtGrandTotalBulat.Clear()
        txtGrandDijamin.Clear()
        txtGrandDijaminBulat.Clear()
        txtGrandIurBayar.Clear()
        txtGrandIurBayarBulat.Clear()
        txtGrandTotalPaket.Clear()
        txtGrandTotalPaketBulat.Clear()
        txtGrandTotalNonPaket.Clear()
        txtGrandTotalNonPaketBulat.Clear()
        txtQty.Clear()
        txtQtyKh.Clear()
        cmbUnitAsal.Text = ""
        cmbPenjamin.Text = ""
        cmbDokter.Text = ""
        txtNota.Text = "-"
        btnSimpan.Enabled = False
        btnCetakNota.Enabled = False
        btnCetakEtiket.Enabled = False
        btnInfoResep.Enabled = False
        btnBaru.Enabled = False
        btnSimpanKh.Enabled = False
        btnCetakBPJS.Enabled = False
        btnCetakLain.Enabled = False
        btnInfoResepKh.Enabled = False
        btnCetakEtiketKh.Enabled = False
        btnBaruKh.Enabled = False
        TabPktUmum.TabVisible = True
        TabPktKhusus.TabVisible = False
        cmbPkt.SelectedIndex = 0
        NoUrut()
        'If  pkdapo = "002" Or  pkdapo = "005" Then
        '    btnModel2.Enabled = True
        'Else
        '    btnModel2.Enabled = False
        'End If
        CariLaba()
        txtNoResep.Focus()
    End Sub

    Sub KosongkanDetailPaketUmum()
        cmbRacikNon.Text = "N"
        lblNamaObat.Text = ""
        txtKodeObat.Clear()
        txtIdObat.Clear()
        txtDosis.Clear()
        txtDosisResep.Clear()
        txtJmlBungkus.Clear()
        txtSatDosis.Clear()
        txtHargaJual.Clear()
        txtJumlahJual.Clear()
        txtKdSatuan.Clear()
        txtSenPotBeli.Clear()
        txtJumlahHarga.Clear()
        txtDijamin.Clear()
        cmbDijamin.Text = ""
        txtIuranSisaBayar.Clear()
        txtJmlHari.IntegerValue = 0
        cmbEtiket.Text = "N"
        txtNamaObatEtiket.Clear()
        cmbTakaran.SelectedIndex = 1
        cmbWaktu.SelectedIndex = 1
        cmbKeterangan.SelectedIndex = 1
        cmbKeteranganModel3.SelectedIndex = 1
        txtSigna1.Text = "0"
        txtSigna2.Text = "0"
        txtQty3.DecimalValue = 0
        txtJumlahObatEtiket.DecimalValue = 0
        txtJarakED.DecimalValue = 0
        modelEtiket = "1"
        txtNamaObatEtiketInfus.Clear()
        txtJumlahObatEtiketInfus.Clear()
        txtNamaObatEtiketModel3.Clear()
        txtJumlahObatEtiketModel3.Clear()
        txtJarakEDModel3.Clear()
        txtObatInfus.Clear()
        txtTetesInfus.Clear()
        txtNamaObatEtiketModel4.Clear()
        cbMalam.Checked = False
        cbSore.Checked = False
        cbSiang.Checked = False
        cbPagi.Checked = False
        rSesudah.Checked = True
        cbInjeksi.Checked = False
    End Sub

    Sub KosongkanDetailPaketKhusus()
        cmbRacikNonKh.Text = "N"
        lblNamaObatKh.Text = ""
        txtKodeObatKh.Clear()
        txtIdObatKh.Clear()
        txtDosisKh.Clear()
        txtSatDosisKh.Clear()
        txtHargaJualKh.Clear()
        txtDosisResepKh.Clear()
        txtJmlCapBPJSKh.Clear()
        txtJmlCapLainKh.Clear()
        txtJmlObatKh.Clear()
        txtPaketBPJSKh.Clear()
        txtSatPaketBPJSKh.Clear()
        txtPaketLainKh.Clear()
        txtSatPaketLainKh.Clear()
        txtTotalPaketBPJSKh.Clear()
        txtTotalPaketLainKh.Clear()
        txtJmlHariKh.IntegerValue = 0
        cmbEtiketKh.Text = "N"
        txtNamaObatEtiket.Clear()
        cmbTakaran.SelectedIndex = 1
        cmbWaktu.SelectedIndex = 1
        cmbKeterangan.SelectedIndex = 1
        cmbKeteranganModel3.SelectedIndex = 1
        txtSigna1.Text = "0"
        txtSigna2.Text = "0"
        txtQty3.DecimalValue = 0
        txtJumlahObatEtiket.DecimalValue = 0
        txtJarakED.DecimalValue = 0
        modelEtiket = "1"
        txtNamaObatEtiketInfus.Clear()
        txtJumlahObatEtiketInfus.Clear()
        txtJumlahObatEtiketModel3.Clear()
        txtNamaObatEtiketModel3.Clear()
        txtJarakEDModel3.Clear()
        txtObatInfus.Clear()
        txtTetesInfus.Clear()
        txtNamaObatEtiketModel4.Clear()
        cbMalam.Checked = False
        cbSore.Checked = False
        cbSiang.Checked = False
        cbPagi.Checked = False
        rSesudah.Checked = True
        cbInjeksi.Checked = False
    End Sub

    'Sub CariLaba()
    '    CMD = New OleDb.OleDbCommand("select laba,ppn from ap_labafarmasi where kode='rj'", CONN)
    '    DA = New OleDb.OleDbDataAdapter(CMD)
    '    DS = New DataSet
    '    DA.Fill(DT, "laba")
    '    Dim BDCek As New BindingSource
    '    Dim DRWCek As DataRowView
    '    BDCek.DataSource = DS
    '    BDCek.DataMember = "laba"
    '    If BDCek.Count > 0 Then
    '        BDCek.MoveFirst()
    '        DRWCek = BDCek.Current
    '        txtLaba.DecimalValue = DRWCek.Item("laba")
    '        txtPPN.DecimalValue = DRWCek.Item("ppn")
    '    Else
    '        MsgBox("Setting Laba belum benar", vbInformation, "Informasi")
    '        Return
    '    End If
    'End Sub

    Sub CariLaba()
        CMD = New OleDb.OleDbCommand("select laba,ppn from ap_labafarmasi where kode='rj'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            txtLaba.DecimalValue = DT.Rows(0).Item("laba")
            txtPPN.DecimalValue = DT.Rows(0).Item("ppn")
        Else
            MsgBox("Setting Laba belum benar", vbInformation, "Informasi")
            Return
        End If
    End Sub

    Sub NoResep()
        Try
            CMD = New OleDb.OleDbCommand("select max(notaresep) as notaresep from ap_jualr1 where tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and kdbagian='" & pkdapo & "' and stsrawat='" & StatusRawat & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If IsDBNull(DT.Rows(0).Item("notaresep")) Then
                txtNoResep.Text = StatusRawat + Format(DTPTanggalTrans.Value, "ddMMyy") + pkdnota + "001"
            Else
                txtNoResep.Text = Microsoft.VisualBasic.Right(DT.Rows(0).Item("notaresep").ToString, 3) + 1
                If Len(txtNoResep.Text) = 1 Then
                    txtNoResep.Text = StatusRawat + Format(DTPTanggalTrans.Value, "ddMMyy") + pkdnota + "00" & txtNoResep.Text & ""
                ElseIf Len(txtNoResep.Text) = 2 Then
                    txtNoResep.Text = StatusRawat + Format(DTPTanggalTrans.Value, "ddMMyy") + pkdnota + "0" & txtNoResep.Text & ""
                ElseIf Len(txtNoResep.Text) = 3 Then
                    txtNoResep.Text = StatusRawat + Format(DTPTanggalTrans.Value, "ddMMyy") + pkdnota + "" & txtNoResep.Text & ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ListDokter()
        CMD = New OleDb.OleDbCommand("select kd_pegawai,nama_pegawai,gelar_depan from pegawai where kd_jns_pegawai=1 order by nama_pegawai", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
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

    Sub ListEtiketTakaran()
        CMD = New OleDb.OleDbCommand("select * from ap_etiket_takaran order by noid", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbTakaran.Items.Clear()
        cmbTakaran.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbTakaran.Items.Add(DT.Rows(i)("takaran") & "|" & DT.Rows(i)("noid"))
        Next
        cmbTakaran.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbTakaran.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListEtiketWaktu()
        CMD = New OleDb.OleDbCommand("select * from ap_etiket_waktu order by noid", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbWaktu.Items.Clear()
        cmbWaktu.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbWaktu.Items.Add(DT.Rows(i)("waktu") & "|" & DT.Rows(i)("noid"))
        Next
        cmbWaktu.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbWaktu.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListEtiketKeterangan()
        CMD = New OleDb.OleDbCommand("select * from ap_etiket_ketminum order by noid", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbKeterangan.Items.Clear()
        cmbKeterangan.Items.Add("")
        cmbKeteranganModel3.Items.Clear()
        cmbKeteranganModel3.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbKeterangan.Items.Add(DT.Rows(i)("ketminum") & "|" & DT.Rows(i)("noid"))
            cmbKeteranganModel3.Items.Add(DT.Rows(i)("ketminum") & "|" & DT.Rows(i)("noid"))
        Next
        cmbKeterangan.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKeterangan.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbKeteranganModel3.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKeteranganModel3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub tampilPasienRI()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT TOP (1000) Registrasi.tgl_reg, Registrasi.no_reg, Registrasi.no_RM, 
					LTRIM(RTRIM(Pasien.nama_pasien)) AS nama_pasien, Sub_Unit.nama_sub_unit, Registrasi.jns_rawat, 
					Registrasi.kd_penjamin, Registrasi.no_SJP, Penjamin_Pasien.no_kartu,Tempat_Tidur.keterangan
					FROM Registrasi 
					INNER JOIN Pasien ON Registrasi.no_RM = Pasien.no_RM 
					INNER JOIN Rawat_Inap ON Registrasi.no_reg = Rawat_Inap.no_reg 
					INNER JOIN Tempat_Tidur ON Rawat_Inap.kd_tempat_tidur = Tempat_Tidur.kd_tempat_tidur 
					INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar 
					INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit 
					LEFT OUTER JOIN Penjamin_Pasien ON Registrasi.no_RM = Penjamin_Pasien.no_RM and Registrasi.kd_penjamin = Penjamin_Pasien.kd_penjamin
					where
                    Registrasi.jns_rawat='" & JenisRawat & "' 
                    and Registrasi.status_keluar=0 
                    order by registrasi.tgl_reg Desc", CONN)
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
                .Columns(8).Visible = False
                .Columns(9).Visible = False

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

    Sub tampilPasienRJ()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT DISTINCT Registrasi.tgl_reg, Registrasi.no_reg, Registrasi.no_RM, 
				LTRIM(RTRIM(Pasien.nama_pasien)) AS nama_pasien, Sub_Unit.nama_sub_unit, Registrasi.jenis_pasien, 
				Registrasi.kd_penjamin,Registrasi.no_SJP, Penjamin_Pasien.no_kartu, ap_jualr1.notaresep
				FROM Registrasi 
				INNER JOIN Pasien ON Registrasi.no_RM = Pasien.no_RM 
				INNER JOIN Rawat_Jalan ON Registrasi.no_reg = Rawat_Jalan.no_reg 
				INNER JOIN Sub_Unit ON Rawat_Jalan.kd_poliklinik = Sub_Unit.kd_sub_unit
                LEFT JOIN ap_jualr1 ON Registrasi.no_reg = ap_jualr1.no_reg
				LEFT JOIN Penjamin_Pasien ON Registrasi.no_RM = Penjamin_Pasien.no_RM AND registrasi.kd_penjamin = Penjamin_pasien.kd_penjamin
                WHERE registrasi.tgl_reg='" & Format(DTPPasienReg.Value, "yyyy/MM/dd") & "' 
                AND Registrasi.jns_rawat='" & JenisRawat & "' 
                AND Registrasi.status_keluar <> 2 order by registrasi.no_reg Asc", CONN)
            'Left OUTER JOIN Diagnosa ON Registrasi.no_reg = Diagnosa.no_reg 
            '	Left OUTER JOIN Surat_Rujukan_Internal ON Registrasi.no_reg = Surat_Rujukan_Internal.no_reg And Surat_Rujukan_Internal.Jenis_Surat='SKU' OR Registrasi.no_reg = Surat_Rujukan_Internal.no_reg AND Surat_Rujukan_Internal.Jenis_Surat='SKO'
            'DA = New OleDb.OleDbDataAdapter("SELECT Registrasi.tgl_reg, Registrasi.no_reg, Registrasi.no_RM, 
            '	LTRIM(RTRIM(pasien.nama_pasien)) as nama_pasien, Sub_Unit.nama_sub_unit, Registrasi.jenis_pasien, 
            '	Registrasi.kd_penjamin, Registrasi.no_SJP
            '	FROM Registrasi 
            '	INNER JOIN Pasien ON Registrasi.no_RM = Pasien.no_RM 
            '	INNER JOIN Rawat_Jalan ON Registrasi.no_reg = Rawat_Jalan.no_reg 
            '	INNER JOIN Sub_Unit ON Rawat_Jalan.kd_poliklinik = Sub_Unit.kd_sub_unit 
            '	where registrasi.tgl_reg='" & Format(DTPPasienReg.Value, "yyyy/MM/dd") & "' and Registrasi.jns_rawat='" & JenisRawat & "' and Registrasi.status_keluar <> 2 order by registrasi.no_reg Asc", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasienRJ")
            BDDataPasienRJ.DataSource = DS
            BDDataPasienRJ.DataMember = "pasienRJ"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDDataPasienRJ
                .Columns(1).HeaderText = "Tanggal Daftar"
                .Columns(2).HeaderText = "No Registrasi"
                .Columns(3).HeaderText = "No RM"
                .Columns(4).HeaderText = "Nama Pasien"
                .Columns(5).HeaderText = "Ruang"
                .Columns(0).Width = 30
                .Columns(1).Width = 75
                .Columns(2).Width = 100
                .Columns(3).Width = 50
                .Columns(4).Width = 130
                .Columns(5).Width = 120
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                '.Columns(10).Visible = False
                '.Columns(11).Visible = False
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            lblKetDaftar.Text = "Daftar Pasien Rawat Jalan"
            AturGridPasien()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AturGridPasien()
        With gridPasien
            .DataSource = Nothing
            .DataSource = BDDataPasienRJ
            '.AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            '.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .ReadOnly = True
            For i As Integer = 0 To .RowCount - 1
                If Not IsDBNull(.Rows(i).Cells("notaresep").Value) And Not .Rows(i).Cells("no_reg").Value = "" Then
                    .Rows(i).Cells("tgl_reg").Style.BackColor = Color.LightGreen
                    .Rows(i).Cells("no_reg").Style.BackColor = Color.LightGreen
                    .Rows(i).Cells("nama_pasien").Style.BackColor = Color.LightGreen
                    .Rows(i).Cells("nama_sub_unit").Style.BackColor = Color.LightGreen
                End If
            Next
        End With
    End Sub

    Sub tampilPasienRD()
        Try
            DA = New OleDb.OleDbDataAdapter("select registrasi.tgl_reg, registrasi.no_reg, registrasi.no_rm, 
				LTRIM(RTRIM(pasien.nama_pasien)) as nama_pasien, registrasi.jenis_pasien, registrasi.jenis_pasien, 
				Registrasi.kd_penjamin, Registrasi.no_SJP, Penjamin_Pasien.no_kartu,
				Surat_Rujukan_Internal.Kd_ICD as kd_icd_sku, Diagnosa.kd_ICD AS kd_icd_rm
                From registrasi 
				inner join pasien on registrasi.no_rm=pasien.no_rm 
				LEFT OUTER JOIN Penjamin_Pasien ON Registrasi.no_RM = Penjamin_Pasien.no_RM and Registrasi.kd_penjamin = Penjamin_Pasien.kd_penjamin
				LEFT OUTER JOIN Diagnosa ON Registrasi.no_reg = Diagnosa.no_reg 
				LEFT OUTER JOIN Surat_Rujukan_Internal ON Registrasi.no_reg = Surat_Rujukan_Internal.no_reg
				where registrasi.tgl_reg='" & Format(DTPPasienReg.Value, "yyyy/MM/dd") & "' and Registrasi.jns_rawat='" & JenisRawat & "' and Registrasi.status_keluar <> 2 order by registrasi.no_reg Asc", CONN)
            'DA = New OleDb.OleDbDataAdapter("select registrasi.tgl_reg, registrasi.no_reg, registrasi.no_rm, LTRIM(RTRIM(pasien.nama_pasien)) as nama_pasien, registrasi.jenis_pasien, registrasi.jenis_pasien, Registrasi.kd_penjamin from registrasi inner join pasien on registrasi.no_rm=pasien.no_rm where Registrasi.jns_rawat='" & JenisRawat & "' and Registrasi.status_keluar <> 2 order by registrasi.no_reg Asc", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasienRD")
            BDDataPasienRD.DataSource = DS
            BDDataPasienRD.DataMember = "pasienRD"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDDataPasienRD
                .Columns(1).HeaderText = "Tanggal Daftar"
                .Columns(2).HeaderText = "No Registrasi"
                .Columns(3).HeaderText = "No RM"
                .Columns(4).HeaderText = "Nama Pasien"
                .Columns(0).Width = 30
                .Columns(1).Width = 75
                .Columns(2).Width = 100
                .Columns(3).Width = 50
                .Columns(4).Width = 200
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                .Columns(10).Visible = False
                .Columns(11).Visible = False
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            lblKetDaftar.Text = "Daftar Pasien Rawat Darurat"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampilDiagnosa(ByVal kd_icd As String)
        CMD = New OleDb.OleDbCommand("SELECT top(1) nama_icd FROM ICD WHERE kd_icd='" & kd_icd & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
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
        CMD = New OleDb.OleDbCommand("SELECT kd_penjamin,nama_penjamin FROM penjamin WHERE kd_penjamin='" & KdPenjamin & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            cmbPenjamin.Text = DT.Rows(0).Item("nama_penjamin") & "|" & DT.Rows(0).Item("kd_penjamin")
        Else
            cmbPenjamin.Text = "-|UMUM"
        End If
        'Dokter
        If JenisRawat = "1" Then    'Rawat Jalan
            CMD = New OleDb.OleDbCommand("SELECT no_reg, kd_dokter, kd_poliklinik FROM rawat_jalan WHERE no_reg='" & txtNoReg.Text & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            kdDokter = DT.Rows(0).Item("kd_dokter")
            kdPoliklinik = DT.Rows(0).Item("kd_poliklinik")

            CMD = New OleDb.OleDbCommand("select kd_pegawai, nama_pegawai from pegawai where kd_pegawai='" & kdDokter & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                cmbDokter.Text = DT.Rows(0).Item("nama_pegawai") & "|" & DT.Rows(0).Item("kd_pegawai")
            End If

            CMD = New OleDb.OleDbCommand("select kd_sub_unit, nama_sub_unit from sub_unit where kd_sub_unit='" & kdPoliklinik & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                cmbUnitAsal.Text = DT.Rows(0).Item("nama_sub_unit") & "|" & DT.Rows(0).Item("kd_sub_unit")
                nmSubUnit = Trim(DT.Rows(0).Item("nama_sub_unit"))
                kdSubUnit = Trim(DT.Rows(0).Item("kd_sub_unit"))
            End If
            cmbPkt.Focus()
        ElseIf JenisRawat = "2" Then    'Rawat Inap
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
            cmbDokter.Focus()
        ElseIf JenisRawat = "3" Then
            CMD = New OleDb.OleDbCommand("SELECT no_reg, kd_dokter FROM rawat_darurat  WHERE no_reg='" & txtNoReg.Text & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            kdDokter = DT.Rows(0).Item("kd_dokter")

            CMD = New OleDb.OleDbCommand("select kd_pegawai, nama_pegawai from pegawai where kd_pegawai='" & kdDokter & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                cmbDokter.Text = DT.Rows(0).Item("nama_pegawai") & "|" & DT.Rows(0).Item("kd_pegawai")
            End If

            CMD = New OleDb.OleDbCommand("select kd_sub_unit, nama_sub_unit from sub_unit where kd_sub_unit='13'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                cmbUnitAsal.Text = DT.Rows(0).Item("nama_sub_unit") & "|" & DT.Rows(0).Item("kd_sub_unit")
            End If
            cmbPkt.Focus()
        End If
    End Sub

    Sub cariNamaPenjamin()
        Dim cari As String = InStr(cmbPenjamin.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbPenjamin.Text, "|", -1, CompareMethod.Binary)
            NamaPenjamin = (ary(0))
            KdPenjamin = (ary(1))
        End If
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

    Sub cariSubUnitAsal()
        Dim cari As String = InStr(cmbUnitAsal.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbUnitAsal.Text, "|", -1, CompareMethod.Binary)
            nmSubUnit = (ary(0))
            kdSubUnit = (ary(1))
        End If
    End Sub

    Sub carikdEtiketTakaran()
        Dim cari As String = InStr(cmbTakaran.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbTakaran.Text, "|", -1, CompareMethod.Binary)
            kdTakaran = (ary(1))
            nmTakaran = (ary(0))
        End If
    End Sub

    Sub carikdEtiketWaktu()
        Dim cari As String = InStr(cmbWaktu.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbWaktu.Text, "|", -1, CompareMethod.Binary)
            kdWaktu = (ary(1))
            nmWaktu = (ary(0))
        End If
    End Sub

    Sub carikdEtiketKeterangan()
        Dim cari As String = InStr(cmbKeterangan.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbKeterangan.Text, "|", -1, CompareMethod.Binary)
            kdKeterangan = (ary(1))
            nmKeterangan = (ary(0))
        End If
    End Sub

    Sub carikdEtiketKeteranganModel3()
        Dim cari As String = InStr(cmbKeteranganModel3.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbKeteranganModel3.Text, "|", -1, CompareMethod.Binary)
            kdKeteranganModel3 = (ary(1))
            nmKeteranganModel3 = (ary(0))
        End If
    End Sub

    Sub NoUrut()
        If BDPenjualanResep.Count > 0 Then
            txtNoUrut.Text = Val(txtNoUrut.Text) + 1
        Else
            txtNoUrut.Text = "1"
        End If
    End Sub

    Sub cetakNota()
        rptNota = New ReportDocument
        Try
            Dim str As String = Application.StartupPath & "\Report\notaResep.rpt"
            rptNota.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rptNota.SetDatabaseLogon(dbUser, dbPassword)
            rptNota.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
            rptNota.SetParameterValue("notaresep", txtNoResep.Text)
            rptNota.SetParameterValue("alamat", txtAlamat.Text)
            rptNota.SetParameterValue("unit", nmSubUnit)
            rptNota.SetParameterValue("totalHarga", txtGrandTotalBulat.DecimalValue)
            rptNota.SetParameterValue("totalDijamin", txtGrandDijaminBulat.DecimalValue)
            rptNota.SetParameterValue("totalSisaBayar", txtGrandIurBayarBulat.DecimalValue)
            rptNota.SetParameterValue("terbilang", bilang)
            rptNota.SetParameterValue("nmdepo", pnmapo)
            rptNota.SetParameterValue("umur", txtUmurThn.Text)
            FormCetak.CrystalReportViewer1.ReportSource = rptNota
            FormCetak.CrystalReportViewer1.Show()
            FormCetak.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cetakNotaBPJS()
        rptBPJS = New ReportDocument
        Try
            Dim str As String = Application.StartupPath & "\Report\notaResepBPJS.rpt"
            rptBPJS.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rptBPJS.SetDatabaseLogon(dbUser, dbPassword)
            rptBPJS.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
            rptBPJS.SetParameterValue("notaresep", txtNoResep.Text)
            rptBPJS.SetParameterValue("alamat", txtAlamat.Text)
            rptBPJS.SetParameterValue("unit", nmSubUnit)
            rptBPJS.SetParameterValue("totalPaketBulat", txtGrandTotalPaketBulat.DecimalValue)
            rptBPJS.SetParameterValue("terbilang", bilang)
            FormCetak.CrystalReportViewer1.ReportSource = rptBPJS
            FormCetak.CrystalReportViewer1.Show()
            FormCetak.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub cetakNotaLain()
        rptLain = New ReportDocument
        Try
            Dim str As String = Application.StartupPath & "\Report\notaResepLain.rpt"
            rptLain.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rptLain.SetDatabaseLogon(dbUser, dbPassword)
            rptLain.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
            rptLain.SetParameterValue("notaresep", txtNoResep.Text)
            rptLain.SetParameterValue("alamat", txtAlamat.Text)
            rptLain.SetParameterValue("unit", nmSubUnit)
            rptLain.SetParameterValue("totalNonPaketBulat", txtGrandTotalNonPaketBulat.DecimalValue)
            rptLain.SetParameterValue("terbilang", bilang)
            FormCetak.CrystalReportViewer1.ReportSource = rptLain
            FormCetak.CrystalReportViewer1.Show()
            FormCetak.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub addBarang()
        cariNamaPenjamin()
        cariDokter()
        carikdEtiketTakaran()
        carikdEtiketWaktu()
        carikdEtiketKeterangan()
        carikdEtiketKeteranganModel3()

        BDPenjualanResep.DataSource = DSPenjualanResep
        BDPenjualanResep.DataMember = "PenjualanResep"

        BDPenjualanResep.AddNew()
        DRWPenjualanResep = BDPenjualanResep.Current
        DRWPenjualanResep("stsrawat") = StatusRawat
        DRWPenjualanResep("kdkasir") = Trim(FormLogin.LabelKode.Text)
        DRWPenjualanResep("nmkasir") = Trim(FormLogin.LabelNama.Text)
        DRWPenjualanResep("tanggal") = DTPTanggalTrans.Value
        DRWPenjualanResep("notaresep") = Trim(txtNoResep.Text)
        DRWPenjualanResep("no_reg") = Trim(txtNoReg.Text)
        DRWPenjualanResep("no_rm") = Trim(txtRM.Text)
        DRWPenjualanResep("nmpasien") = Trim(txtNamaPasien.Text)
        DRWPenjualanResep("umurthn") = txtUmurThn.Text
        DRWPenjualanResep("umurbln") = txtUmurBln.Text
        DRWPenjualanResep("kd_penjamin") = KdPenjamin
        DRWPenjualanResep("nm_penjamin") = NamaPenjamin
        DRWPenjualanResep("kddokter") = kdDokter
        DRWPenjualanResep("nmdokter") = NamaDokter
        DRWPenjualanResep("nonota") = Trim(txtNota.Text)
        DRWPenjualanResep("urut") = txtNoUrut.Text
        DRWPenjualanResep("kd_barang") = Trim(txtKodeObat.Text)
        DRWPenjualanResep("idx_barang") = Trim(txtIdObat.Text)
        DRWPenjualanResep("nama_barang") = Trim(lblNamaObat.Text)
        DRWPenjualanResep("kd_jns_obat") = KdJenisObat
        DRWPenjualanResep("kd_gol_obat") = kdGolonganObat
        DRWPenjualanResep("kd_kel_obat") = kdKelompokObat
        DRWPenjualanResep("kdpabrik") = kdPabrik
        DRWPenjualanResep("generik") = Generik
        DRWPenjualanResep("formularium") = "FORMULARIUM"
        DRWPenjualanResep("racik") = Trim(cmbRacikNon.Text)
        DRWPenjualanResep("harga") = txtHargaJual.DecimalValue
        DRWPenjualanResep("jmlp") = txtJumlahJual.DecimalValue
        DRWPenjualanResep("totalp") = txtJumlahHarga.DecimalValue
        DRWPenjualanResep("jmln") = 0
        DRWPenjualanResep("totaln") = 0
        DRWPenjualanResep("jml") = txtJumlahJual.DecimalValue
        DRWPenjualanResep("nmsatuan") = Trim(txtKdSatuan.Text)
        DRWPenjualanResep("totalharga") = txtJumlahHarga.DecimalValue
        DRWPenjualanResep("senpot") = 0
        DRWPenjualanResep("potongan") = 0
        DRWPenjualanResep("jmlnet") = txtJumlahHarga.DecimalValue
        DRWPenjualanResep("dijamin") = txtDijamin.DecimalValue
        DRWPenjualanResep("sisabayar") = txtIuranSisaBayar.DecimalValue
        DRWPenjualanResep("hrgbeli") = HargaBeli
        DRWPenjualanResep("jamawal") = Format(DTPJamAwal.Value, "HH:mm:ss").ToString
        DRWPenjualanResep("kdbagian") = pkdapo
        DRWPenjualanResep("stsresep") = "PKTUMUM"
        DRWPenjualanResep("rek_p") = kDRekening
        DRWPenjualanResep("stsetiket") = cmbEtiket.Text
        DRWPenjualanResep("qty1") = txtSigna1.Text
        DRWPenjualanResep("qty2") = txtSigna2.Text
        DRWPenjualanResep("qty3") = txtQty3.DecimalValue
        DRWPenjualanResep("jmlhari") = 0
        DRWPenjualanResep("takaran") = kdTakaran
        DRWPenjualanResep("waktu") = kdWaktu
        DRWPenjualanResep("takaran_s") = nmTakaran
        DRWPenjualanResep("waktu_s") = nmWaktu
        DRWPenjualanResep("ketminum_s") = nmKeterangan
        If modelEtiket = "1" Then
            DRWPenjualanResep("ketminum") = kdKeterangan
            DRWPenjualanResep("nmobat_etiket") = txtNamaObatEtiket.Text
            DRWPenjualanResep("jmlobat_etiket") = txtJumlahObatEtiket.DecimalValue
        ElseIf modelEtiket = "3" Then
            DRWPenjualanResep("ketminum") = kdKeteranganModel3
            DRWPenjualanResep("nmobat_etiket") = txtNamaObatEtiketModel3.Text
            DRWPenjualanResep("jmlobat_etiket") = txtJumlahObatEtiketModel3.DecimalValue
            DRWPenjualanResep("ketminum_s") = nmKeteranganModel3
        ElseIf modelEtiket = "4" Then
            DRWPenjualanResep("nmobat_etiket") = txtNamaObatEtiketModel4.Text
        End If
        DRWPenjualanResep("posting") = "1"
        DRWPenjualanResep("diserahkan") = "B"
        DRWPenjualanResep("jns_obat") = JenisObat
        DRWPenjualanResep("jmljatah") = txtJmlHari.IntegerValue
        DRWPenjualanResep("tglakhir") = DTPTglAkhir.Value
        DRWPenjualanResep("jml_awal") = 0
        DRWPenjualanResep("tgl_exp") = DTPTanggalExp.Value
        DRWPenjualanResep("model_etiket") = modelEtiket
        DRWPenjualanResep("nmobat_etiket_infus") = txtNamaObatEtiketInfus.Text
        DRWPenjualanResep("jmlobat_etiket_infus") = txtJumlahObatEtiketInfus.DecimalValue
        DRWPenjualanResep("obat_infus") = txtObatInfus.Text
        DRWPenjualanResep("tetes_infus") = txtTetesInfus.Text

        If cbPagi.Checked = True Then
            DRWPenjualanResep("ket_waktu_pagi_model4") = "2"
        Else
            DRWPenjualanResep("ket_waktu_pagi_model4") = "1"
        End If
        If cbSiang.Checked = True Then
            DRWPenjualanResep("ket_waktu_siang_model4") = "2"
        Else
            DRWPenjualanResep("ket_waktu_siang_model4") = "1"
        End If
        If cbMalam.Checked = True Then
            DRWPenjualanResep("ket_waktu_malam_model4") = "2"
        Else
            DRWPenjualanResep("ket_waktu_malam_model4") = "1"
        End If
        If cbSore.Checked = True Then
            DRWPenjualanResep("ket_waktu_sore_model4") = "2"
        Else
            DRWPenjualanResep("ket_waktu_sore_model4") = "1"
        End If
        If rSebelum.Checked = True Then
            DRWPenjualanResep("ket_minum_model4") = "1"
        ElseIf rBersama.Checked = True Then
            DRWPenjualanResep("ket_minum_model4") = "2"
        ElseIf rSesudah.Checked = True Then
            DRWPenjualanResep("ket_minum_model4") = "3"
        ElseIf rInjeksi.Checked = True Then
            DRWPenjualanResep("ket_minum_model4") = "4"
        End If

        BDPenjualanResep.EndEdit()

        gridDetailObat.DataSource = Nothing
        gridDetailObat.DataSource = BDPenjualanResep

        TotalHarga()
        TotalDijamin()
        TotalIurBayar()
    End Sub

    Sub addBarangKh()
        cariNamaPenjamin()
        cariDokter()
        carikdEtiketTakaran()
        carikdEtiketWaktu()
        carikdEtiketKeterangan()
        carikdEtiketKeteranganModel3()

        BDPenjualanResepKh.DataSource = DSPenjualanResepKh
        BDPenjualanResepKh.DataMember = "PenjualanResepKh"

        BDPenjualanResepKh.AddNew()
        DRWPenjualanResepKh = BDPenjualanResepKh.Current
        DRWPenjualanResepKh("stsrawat") = StatusRawat
        DRWPenjualanResepKh("kdkasir") = Trim(FormLogin.LabelKode.Text)
        DRWPenjualanResepKh("nmkasir") = Trim(FormLogin.LabelNama.Text)
        DRWPenjualanResepKh("tanggal") = DTPTanggalTrans.Value
        DRWPenjualanResepKh("notaresep") = Trim(txtNoResep.Text)
        DRWPenjualanResepKh("no_reg") = Trim(txtNoReg.Text)
        DRWPenjualanResepKh("no_rm") = Trim(txtRM.Text)
        DRWPenjualanResepKh("nmpasien") = Trim(txtNamaPasien.Text)
        DRWPenjualanResepKh("umurthn") = txtUmurThn.Text
        DRWPenjualanResepKh("umurbln") = txtUmurBln.Text
        DRWPenjualanResepKh("kd_penjamin") = KdPenjamin
        DRWPenjualanResepKh("nm_penjamin") = NamaPenjamin
        DRWPenjualanResepKh("kddokter") = kdDokter
        DRWPenjualanResepKh("nmdokter") = NamaDokter
        DRWPenjualanResepKh("nonota") = Trim(txtNota.Text)
        DRWPenjualanResepKh("urut") = txtNoUrut.Text
        DRWPenjualanResepKh("kd_barang") = Trim(txtKodeObatKh.Text)
        DRWPenjualanResepKh("idx_barang") = Trim(txtIdObatKh.Text)
        DRWPenjualanResepKh("nama_barang") = Trim(lblNamaObatKh.Text)
        DRWPenjualanResepKh("kd_jns_obat") = KdJenisObat
        DRWPenjualanResepKh("kd_gol_obat") = kdGolonganObat
        DRWPenjualanResepKh("kd_kel_obat") = kdKelompokObat
        DRWPenjualanResepKh("kdpabrik") = kdPabrik
        DRWPenjualanResepKh("generik") = Generik
        DRWPenjualanResepKh("formularium") = "FORMULARIUM"
        DRWPenjualanResepKh("racik") = Trim(cmbRacikNonKh.Text)
        DRWPenjualanResepKh("harga") = txtHargaJualKh.DecimalValue
        DRWPenjualanResepKh("jmlp") = txtPaketBPJSKh.DecimalValue
        DRWPenjualanResepKh("totalp") = txtTotalPaketBPJSKh.DecimalValue
        DRWPenjualanResepKh("jmln") = txtPaketLainKh.DecimalValue
        DRWPenjualanResepKh("totaln") = txtTotalPaketLainKh.DecimalValue
        DRWPenjualanResepKh("jml") = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
        DRWPenjualanResepKh("nmsatuan") = Trim(txtSatPaketBPJSKh.Text)
        DRWPenjualanResepKh("totalharga") = txtTotalPaketBPJSKh.DecimalValue + txtTotalPaketLainKh.DecimalValue
        DRWPenjualanResepKh("senpot") = 0
        DRWPenjualanResepKh("potongan") = 0
        DRWPenjualanResepKh("jmlnet") = txtPaketBPJSKh.DecimalValue
        DRWPenjualanResepKh("dijamin") = txtTotalPaketBPJSKh.DecimalValue
        DRWPenjualanResepKh("sisabayar") = 0
        DRWPenjualanResepKh("hrgbeli") = HargaBeli
        DRWPenjualanResepKh("jamawal") = Format(DTPJamAwal.Value, "HH:mm:ss")
        DRWPenjualanResepKh("kdbagian") = pkdapo
        DRWPenjualanResepKh("stsresep") = "PKTKHUSUS"
        DRWPenjualanResepKh("rek_p") = kDRekening
        DRWPenjualanResepKh("stsetiket") = cmbEtiketKh.Text
        DRWPenjualanResepKh("qty1") = txtSigna1.Text
        DRWPenjualanResepKh("qty2") = txtSigna2.Text
        DRWPenjualanResepKh("qty3") = txtQty3.DecimalValue
        DRWPenjualanResepKh("jmlhari") = 0
        DRWPenjualanResepKh("takaran") = kdTakaran
        DRWPenjualanResepKh("waktu") = kdWaktu
        DRWPenjualanResepKh("takaran_s") = nmTakaran
        DRWPenjualanResepKh("waktu_s") = nmWaktu
        DRWPenjualanResepKh("ketminum_s") = nmKeterangan
        If modelEtiket = "1" Then
            DRWPenjualanResepKh("ketminum") = kdKeterangan
            DRWPenjualanResepKh("nmobat_etiket") = txtNamaObatEtiket.Text
            DRWPenjualanResepKh("jmlobat_etiket") = txtJumlahObatEtiket.DecimalValue
        ElseIf modelEtiket = "3" Then
            DRWPenjualanResepKh("ketminum") = kdKeteranganModel3
            DRWPenjualanResepKh("nmobat_etiket") = txtNamaObatEtiketModel3.Text
            DRWPenjualanResepKh("jmlobat_etiket") = txtJumlahObatEtiketModel3.DecimalValue
            DRWPenjualanResepKh("ketminum_s") = nmKeteranganModel3
        ElseIf modelEtiket = "4" Then
            DRWPenjualanResepKh("nmobat_etiket") = txtNamaObatEtiketModel4.Text
        End If
        DRWPenjualanResepKh("posting") = "1"
        DRWPenjualanResepKh("diserahkan") = "B"
        DRWPenjualanResepKh("jns_obat") = JenisObat
        DRWPenjualanResepKh("jmljatah") = txtJmlHariKh.IntegerValue
        DRWPenjualanResepKh("tglakhir") = DTPTglAkhirKh.Value
        DRWPenjualanResepKh("jml_awal") = 0

        DRWPenjualanResepKh("tgl_exp") = DTPTanggalExp.Value

        DRWPenjualanResepKh("model_etiket") = modelEtiket
        DRWPenjualanResepKh("nmobat_etiket_infus") = txtNamaObatEtiketInfus.Text
        DRWPenjualanResepKh("jmlobat_etiket_infus") = txtJumlahObatEtiketInfus.DecimalValue
        DRWPenjualanResepKh("obat_infus") = txtObatInfus.Text
        DRWPenjualanResepKh("tetes_infus") = txtTetesInfus.Text

        If cbPagi.Checked = True Then
            DRWPenjualanResepKh("ket_waktu_pagi_model4") = "2"
        Else
            DRWPenjualanResepKh("ket_waktu_pagi_model4") = "1"
        End If
        If cbSiang.Checked = True Then
            DRWPenjualanResepKh("ket_waktu_siang_model4") = "2"
        Else
            DRWPenjualanResepKh("ket_waktu_siang_model4") = "1"
        End If
        If cbMalam.Checked = True Then
            DRWPenjualanResepKh("ket_waktu_malam_model4") = "2"
        Else
            DRWPenjualanResepKh("ket_waktu_malam_model4") = "1"
        End If
        If cbSore.Checked = True Then
            DRWPenjualanResepKh("ket_waktu_sore_model4") = "2"
        Else
            DRWPenjualanResepKh("ket_waktu_sore_model4") = "1"
        End If
        If rSebelum.Checked = True Then
            DRWPenjualanResepKh("ket_minum_model4") = "1"
        ElseIf rBersama.Checked = True Then
            DRWPenjualanResepKh("ket_minum_model4") = "2"
        ElseIf rSesudah.Checked = True Then
            DRWPenjualanResepKh("ket_minum_model4") = "3"
        End If

        BDPenjualanResepKh.EndEdit()

        gridDetailObatKh.DataSource = Nothing
        gridDetailObatKh.DataSource = BDPenjualanResepKh

        TotalPaket()
        TotalNonPaket()
    End Sub

    Sub exportExcelEtiket()
        Try
            Dim dtXls As DataTable = CType(DSPenjualanResepKh.Tables("PenjualanResepKh"), DataTable)
            Dim excelEngine As New ExcelEngine
            excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
            Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\daftarEtiket.xlsx")
            Dim sheet As IWorksheet = workbook.Worksheets(0)
            sheet.Range("A1").Text = Format(DTPTanggalTrans.Value, "dd MMM yyyy")
            sheet.Range("A2").Text = txtNamaPasien.Text & " - RM. " & txtRM.Text
            Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
            marker.AddVariable("Data", dtXls)
            marker.ApplyMarkers()
            workbook.Version = ExcelVersion.Excel2007
            workbook.SaveAs("daftarEtiketRJ_.xlsx")
            workbook.Close()
            excelEngine.Dispose()
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY")
            Dim WB As ExcelFile = ExcelFile.Load(Application.StartupPath & "\daftarEtiketRJ_.xlsx")
            WB.Print()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub TotalHarga()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("totalharga").Value
        Next
        txtGrandTotal.DecimalValue = HitungTotal
        txtGrandTotalBulat.DecimalValue = buletin(txtGrandTotal.DecimalValue, 100)
    End Sub

    Sub TotalDijamin()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("dijamin").Value
        Next
        txtGrandDijamin.DecimalValue = HitungTotal
        txtGrandDijaminBulat.DecimalValue = buletin(txtGrandDijamin.DecimalValue, 100)
    End Sub

    Sub TotalIurBayar()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("sisabayar").Value
        Next
        txtGrandIurBayar.DecimalValue = HitungTotal
        txtGrandIurBayarBulat.DecimalValue = buletin(txtGrandIurBayar.DecimalValue, 100)
    End Sub

    Sub TotalPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObatKh.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObatKh.Rows(baris).Cells("totalp").Value
        Next
        txtGrandTotalPaket.DecimalValue = HitungTotal
        txtGrandTotalPaketBulat.DecimalValue = buletin(txtGrandTotalPaket.DecimalValue, 100)
    End Sub

    Sub TotalNonPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObatKh.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObatKh.Rows(baris).Cells("totaln").Value
        Next
        txtGrandTotalNonPaket.DecimalValue = HitungTotal
        txtGrandTotalNonPaketBulat.DecimalValue = buletin(txtGrandTotalNonPaket.DecimalValue, 100)
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
            .Columns(6).HeaderText = "Jumlah Harga"
            .Columns(6).ReadOnly = True
            .Columns(6).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderText = "Dijamin"
            .Columns(7).ReadOnly = True
            .Columns(7).DefaultCellStyle.Format = "N2"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).HeaderText = "Iur Pasien"
            .Columns(8).ReadOnly = True
            .Columns(8).DefaultCellStyle.Format = "N2"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).HeaderText = "Jml Hari"
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).ReadOnly = True
            .Columns(0).Width = 40
            .Columns(1).Width = 40
            .Columns(2).Width = 320
            .Columns(3).Width = 100
            .Columns(4).Width = 100
            .Columns(5).Width = 80
            .Columns(6).Width = 120
            .Columns(7).Width = 100
            .Columns(8).Width = 100
            .Columns(9).Width = 40
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
            .Columns(35).Visible = False
            .Columns(36).Visible = False
            .Columns(37).Visible = False
            .Columns(38).Visible = False
            .Columns(39).Visible = False
            .Columns(40).Visible = False
            .Columns(41).Visible = False
            .Columns(42).Visible = False
            .Columns(43).Visible = False
            .Columns(44).Visible = False
            .Columns(45).Visible = False
            .Columns(46).Visible = False
            .Columns(47).Visible = False
            .Columns(48).Visible = False
            .Columns(49).Visible = False
            .Columns(50).Visible = False
            .Columns(51).Visible = False
            .Columns(52).Visible = False
            .Columns(53).Visible = False
            .Columns(54).Visible = False
            .Columns(55).Visible = False
            .Columns(56).Visible = False
            .Columns(57).Visible = False
            .Columns(58).Visible = False
            .Columns(59).Visible = False
            .Columns(60).Visible = False
            .Columns(61).Visible = False
            .Columns(62).Visible = False
            .Columns(63).Visible = False
            .Columns(64).Visible = False
            .Columns(65).Visible = False
            .Columns(66).Visible = False
            .Columns(67).Visible = False
            .Columns(68).Visible = False
            .Columns(69).Visible = False
            .Columns(70).Visible = False
            .Columns(71).Visible = False
            .Columns(72).Visible = False
            .Columns(73).Visible = False
            .BackgroundColor = Color.Azure
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            .RowHeadersDefaultCellStyle.BackColor = Color.Black
        End With
    End Sub

    Sub AturGriddetailBarangKh()
        With gridDetailObatKh
            .Columns(0).HeaderText = "No"
            .Columns(1).HeaderText = "R/N"
            .Columns(2).HeaderText = "Nama Barang"
            .Columns(3).HeaderText = "Harga"
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Jumlah Paket BPJS"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "Total Paket BPJS"
            .Columns(5).DefaultCellStyle.Format = "N2"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).HeaderText = "Jumlah Paket Lain"
            .Columns(6).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderText = "Total Paket Lain"
            .Columns(7).DefaultCellStyle.Format = "N2"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).HeaderText = "Jumlah Obat"
            .Columns(8).DefaultCellStyle.Format = "N2"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).HeaderText = "Satuan"
            .Columns(10).HeaderText = "Jml Hari"
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).Width = 40
            .Columns(1).Width = 40
            .Columns(2).Width = 320
            .Columns(3).Width = 100
            .Columns(4).Width = 70
            .Columns(5).Width = 80
            .Columns(6).Width = 70
            .Columns(7).Width = 100
            .Columns(8).Width = 70
            .Columns(9).Width = 100
            .Columns(10).Width = 40
            .Columns(0).Visible = False
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
            .Columns(35).Visible = False
            .Columns(36).Visible = False
            .Columns(37).Visible = False
            .Columns(38).Visible = False
            .Columns(39).Visible = False
            .Columns(40).Visible = False
            .Columns(41).Visible = False
            .Columns(42).Visible = False
            .Columns(43).Visible = False
            .Columns(44).Visible = False
            .Columns(45).Visible = False
            .Columns(46).Visible = False
            .Columns(47).Visible = False
            .Columns(48).Visible = False
            .Columns(49).Visible = False
            .Columns(50).Visible = False
            .Columns(51).Visible = False
            .Columns(52).Visible = False
            .Columns(53).Visible = False
            .Columns(54).Visible = False
            .Columns(55).Visible = False
            .Columns(56).Visible = False
            .Columns(57).Visible = False
            .Columns(58).Visible = False
            .Columns(59).Visible = False
            .Columns(60).Visible = False
            .Columns(61).Visible = False
            .Columns(62).Visible = False
            .Columns(63).Visible = False
            .Columns(64).Visible = False
            .Columns(65).Visible = False
            .Columns(66).Visible = False
            .Columns(67).Visible = False
            .Columns(68).Visible = False
            .Columns(69).Visible = False
            .Columns(70).Visible = False
            .Columns(71).Visible = False
            .Columns(72).Visible = False
            .Columns(73).Visible = False
            .Columns(74).Visible = False
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

    Sub tampilBarang()
        If pkdapo = "001" Then
            Stok = "stok001"
        ElseIf pkdapo = "002" Then
            Stok = "stok002"
        ElseIf pkdapo = "003" Then
            Stok = "stok003"
        ElseIf pkdapo = "004" Then
            Stok = "stok004"
        ElseIf pkdapo = "005" Then
            Stok = "stok005"
        ElseIf pkdapo = "006" Then
            Stok = "stok006"
        ElseIf pkdapo = "007" Then
            Stok = "stok007"
        End If
        Try
            DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", 
                 LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan 
                 FROM Barang_Farmasi WHERE stsaktif ='1' and " & Stok & ">0 order by nama_barang", CONN)
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

    Sub tampilBarangSemua()
        If pkdapo = "001" Then
            Stok = "stok001"
        ElseIf pkdapo = "002" Then
            Stok = "stok002"
        ElseIf pkdapo = "003" Then
            Stok = "stok003"
        ElseIf pkdapo = "004" Then
            Stok = "stok004"
        ElseIf pkdapo = "005" Then
            Stok = "stok005"
        ElseIf pkdapo = "006" Then
            Stok = "stok006"
        ElseIf pkdapo = "007" Then
            Stok = "stok007"
        End If
        Try
            If pkdapo = "001" And Trim(FormLogin.LabelKode.Text) = "P01" Then
                DA = New OleDb.OleDbDataAdapter("select bf.idx_barang, bf.kd_barang, LTRIM(RTRIM(bf.nama_barang)) as nama_barang,
                        " & Stok & ", LTRIM(RTRIM(bf.kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(bf.keterangan)) as keterangan,
                        max(ambl.tglexp) as tglexp 
                        from Barang_Farmasi as bf
                        LEFT JOIN ap_ambil as ambl on bf.kd_barang=ambl.kd_barang 
                        WHERE stsaktif ='1' AND " & Stok & ">=0 
                        group by bf.idx_barang, bf.kd_barang, bf.nama_barang," & Stok & ", bf.kd_satuan_kecil, bf.keterangan                                                
                        order by nama_barang", CONN)
            Else
                'DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from Barang_Farmasi WHERE stsaktif ='1' AND " & Stok & ">0 order by nama_barang", CONN)
                DA = New OleDb.OleDbDataAdapter("select bf.idx_barang, bf.kd_barang, LTRIM(RTRIM(bf.nama_barang)) as nama_barang,
                        " & Stok & ", LTRIM(RTRIM(bf.kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(bf.keterangan)) as keterangan, 
                        max(ambl.tglexp) as tglexp 
                        from Barang_Farmasi as bf 
                        LEFT JOIN ap_ambil as ambl on bf.kd_barang=ambl.kd_barang 
                        WHERE stsaktif ='1' AND " & Stok & ">0
                        group by bf.idx_barang, bf.kd_barang, bf.nama_barang," & Stok & ", bf.kd_satuan_kecil, bf.keterangan                                                
                        order by nama_barang", CONN)
            End If

            'If pkdapo = "004" Or pkdapo = "005" Or pkdapo = "001" Then
            '    DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from Barang_Farmasi WHERE stsaktif ='1' AND " & Stok & ">0 order by nama_barang", CONN)
            'Else
            '    DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from Barang_Farmasi WHERE stsaktif ='1' AND " & Stok & ">=0 order by nama_barang", CONN)
            'End If
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
                .Columns(7).HeaderText = "Expired"
                .Columns(0).Width = 30
                .Columns(1).Width = 50
                .Columns(2).Width = 75
                .Columns(3).Width = 190
                .Columns(4).Width = 40
                .Columns(5).Width = 50
                .Columns(6).Width = 120
                .Columns(7).Width = 75
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


    Sub cekJangkaPemberianObatBPJS(ByVal KodeObat As String)
        CMD = New OleDb.OleDbCommand("SELECT top(1) no_rm, kd_barang, tglakhir FROM ap_jualr2_bpjs WHERE no_rm='" & Trim(txtRM.Text) & "' AND kd_barang='" & KodeObat & "' AND kdbagian='" & pkdapo & "' order by tglakhir desc", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Sub tampilICD(ByVal noReg As String)
        CMD = New OleDb.OleDbCommand("SELECT top(1) sri.Kd_Icd as sku_icd, dg.Kd_Icd as rm_icd FROM Surat_Rujukan_Internal as sri
									LEFT OUTER JOIN Diagnosa as dg ON sri.no_reg = dg.no_reg 
									WHERE sri.no_reg='" & noReg & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            If IsDBNull(DT.Rows(0).Item("sku_icd")) Then
                kdIcdSKU = "-"
                kdIcdRM = DT.Rows(0).Item("rm_icd")
            ElseIf IsDBNull(DT.Rows(0).Item("rm_icd")) Then
                kdIcdSKU = DT.Rows(0).Item("sku_icd")
                kdIcdRM = "-"
            Else
                kdIcdSKU = DT.Rows(0).Item("sku_icd")
                kdIcdRM = DT.Rows(0).Item("rm_icd")
            End If
        Else
            kdIcdSKU = "-"
            kdIcdRM = "-"
        End If
    End Sub

    Sub detailObat(ByVal KodeObat As String)
        CMD = New OleDb.OleDbCommand("SELECT 
                        bf.idx_barang,  
                        LTRIM(RTRIM(bf.nama_barang)) as nama_barang, 
                        bf.harga_jual, 
                        bf.kd_satuan_kecil, 
                        bf.dosis, 
                        bf.satdosis,
                        bf.kd_jns_obat, 
                        bf.generik, 
                        bf.kdpabrik, 
                        bf.kd_kel_obat, 
                        bf.kd_gol_obat, 
                        bf.senpotbeli,
                        max(ambl.tglexp) as tglexp, 
                        ppn1, 
                        ppn2 
                    FROM Barang_Farmasi as bf 
                    LEFT JOIN ap_ambil as ambl on bf.kd_barang=ambl.kd_barang 
                    WHERE bf.kd_barang='" & KodeObat & "'
                        GROUP BY 
                        idx_barang, bf.nama_barang, bf.kd_jns_obat, bf.senpotbeli, harga_jual, kd_satuan_kecil, dosis, satdosis,
                        generik, kdpabrik, kd_kel_obat, kd_gol_obat, bf.ppn1, bf.ppn2 ", CONN)
        'CMD = New OleDb.OleDbCommand("SELECT * FROM Barang_Farmasi as bf 
        '                            WHERE bf.kd_barang='" & KodeObat & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            If cmbPkt.Text = "Paket Umum" Then
                ' PPN SESUAI MASTER
                txtPPN.DecimalValue = DT.Rows(0).Item("ppn2")
                txtIdObat.Text = Trim(DT.Rows(0).Item("idx_barang"))
                lblNamaObat.Text = Trim(DT.Rows(0).Item("nama_barang"))
                If DT.Rows(0).Item("kd_jns_obat") = 17 Then
                    DiskonDinkes = 0
                Else
                    DiskonDinkes = DT.Rows(0).Item("harga_jual")
                End If
                HargaBeli = DiskonDinkes
                txtHargaJual.DecimalValue = DiskonDinkes
                'txtHargaJual.DecimalValue = DT.Rows(0).Item("harga_jual")
                txtKdSatuan.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
                txtDosis.DecimalValue = DT.Rows(0).Item("dosis")
                txtSatDosis.Text = Trim(DT.Rows(0).Item("satdosis"))
                HargaJual()
                If cmbPenjamin.Text = "-|UMUM" Then
                    cmbDijamin.Text = "N"
                Else
                    cmbDijamin.Text = "Y"
                End If
                If cmbRacikNon.Text = "R" Then
                    txtDosisResep.Focus()
                Else
                    cmbDijamin.Focus()
                End If
            ElseIf cmbPkt.Text = "Paket Khusus" Then
                txtPPN.DecimalValue = DT.Rows(0).Item("ppn2")
                txtIdObatKh.Text = Trim(DT.Rows(0).Item("idx_barang"))
                lblNamaObatKh.Text = Trim(DT.Rows(0).Item("nama_barang"))
                If DT.Rows(0).Item("kd_jns_obat") = 17 Then
                    DiskonDinkes = 0
                Else
                    DiskonDinkes = DT.Rows(0).Item("harga_jual")
                End If
                HargaBeli = DiskonDinkes
                txtHargaJualKh.DecimalValue = DiskonDinkes
                'txtHargaJualKh.DecimalValue = DT.Rows(0).Item("harga_jual")
                txtSatPaketBPJSKh.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
                txtSatPaketLainKh.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
                txtDosisKh.DecimalValue = DT.Rows(0).Item("dosis")
                txtSatDosisKh.Text = Trim(DT.Rows(0).Item("satdosis"))
                HargaJualKh()
                If cmbRacikNonKh.Text = "N" Then
                    txtPaketBPJSKh.Focus()
                Else
                    txtDosisResepKh.Focus()
                End If
            End If

            Generik = Trim(DT.Rows(0).Item("generik"))
            KdJenisObat = Trim(DT.Rows(0).Item("kd_jns_obat"))
            kdPabrik = Trim(DT.Rows(0).Item("kdpabrik"))
            kdKelompokObat = Trim(DT.Rows(0).Item("kd_kel_obat"))
            kdGolonganObat = Trim(DT.Rows(0).Item("kd_gol_obat"))
            txtSenPotBeli.DecimalValue = DT.Rows(0).Item("senpotbeli")
        End If

        CMD = New OleDb.OleDbCommand("SELECT * FROM jenis_obat WHERE kd_jns_obat='" & Trim(KdJenisObat) & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            JenisObat = Trim(DT.Rows(0).Item("jns_obat"))
            kDRekening = Trim(DT.Rows(0).Item("rek_p"))
        End If
    End Sub

    Sub HargaJual()
        txtHargaJual.DecimalValue = (txtHargaJual.DecimalValue + (txtHargaJual.DecimalValue * txtPPN.DecimalValue / 100)) + (txtHargaJual.DecimalValue * txtLaba.DecimalValue / 100)
    End Sub

    Sub HargaJualKh()
        txtHargaJualKh.DecimalValue = (txtHargaJualKh.DecimalValue + (txtHargaJualKh.DecimalValue * txtPPN.DecimalValue / 100)) + (txtHargaJualKh.DecimalValue * txtLaba.DecimalValue / 100)
    End Sub

    Sub cetakEtiketModel4()
        'Try
        Dim dtReport As New DataTable
        With dtReport
            .Columns.Add("namaObat")
            .Columns.Add("waktuMinum")
            .Columns.Add("ketMinum")
            '.Columns.Add("jenisObat")
        End With
        For i = 0 To gridEtiket.RowCount - 2
            If Not IsDBNull(gridEtiket.Rows(i).Cells(0).Value) Then
                dtReport.Rows.Add(gridEtiket.Rows(i).Cells("namaObat").Value, gridEtiket.Rows(i).Cells("waktuMinum").Value, gridEtiket.Rows(i).Cells("ketMinum").Value)
            End If
        Next
        Dim rpt As New ReportDocument
        'Dim param As New ParameterFields
        'Dim paramdesc As New ParameterDiscreteValue
        'Dim paramfield As New ParameterField
        'paramfield.Name = "nmPasien"
        'paramfield.Name = "noRM"
        'paramfield.Name = "bulan"
        'paramfield.Name = "tahun"

        Dim str As String = Application.StartupPath & "\report\etiketModel4.rpt"

        'param = rpt.ParameterFields
        'rpt.ParameterFields.Add(paramfield)
        'param("nmPasien").CurrentValues.Clear()
        'paramdesc.Value = txtNamaPasien.Text
        'param("nmPasien").CurrentValues.Add(paramdesc)
        rpt.Load(str)
        rpt.SetDataSource(dtReport)
        rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
        rpt.SetParameterValue("noRM", Trim(txtRM.Text))
        rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
        rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
        'rpt.Refresh()
        rpt.SetParameterValue("ruang", Trim(nmSubUnit))
        rpt.SetParameterValue("bed", Trim(lblKamarBed.Text))


        'FormCetak.CrystalReportViewer1.ReportSource = rpt
        'FormCetak.CrystalReportViewer1.Refresh()
        'FormCetak.ShowDialog()
        'FormCetak.ShowIcon = False
        rpt.PrintToPrinter(1, False, 0, 0)
        rpt.Close()
        rpt.Dispose()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Private Sub FormPenjualanResep_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dispose()
        FormInfoResepObat.Dispose()
    End Sub

    Private Sub FormPenjualanResep_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F12 Then
            If cmbPkt.Text = "Paket Umum" Then
                btnSimpan.PerformClick()
            ElseIf cmbPkt.Text = "Paket Khusus" Then
                btnSimpanKh.PerformClick()
            End If
        ElseIf e.KeyCode = Keys.F1 Then
            btnCetakNota.PerformClick()
        ElseIf e.KeyCode = Keys.F5 Then
            If cmbPkt.Text = "Paket Umum" Then
                btnCetakEtiket.PerformClick()
            ElseIf cmbPkt.Text = "Paket Khusus" Then
                btnCetakEtiketKh.PerformClick()
            End If
        ElseIf e.KeyCode = Keys.F10 Then
            If cmbPkt.Text = "Paket Umum" Then
                btnBaru.PerformClick()
            ElseIf cmbPkt.Text = "Paket Khusus" Then
                btnBaruKh.PerformClick()
            End If
        ElseIf e.KeyCode = Keys.F4 Then
            If cmbPkt.Text = "Paket Umum" Then
                btnInfoResep.PerformClick()
            ElseIf cmbPkt.Text = "Paket Khusus" Then
                btnInfoResepKh.PerformClick()
            End If
        ElseIf e.KeyCode = Keys.F2 Then
            btnCetakBPJS.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            btnCetakLain.PerformClick()
        End If
    End Sub

    Private Sub FormPenjualanResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Location = New Point(0, Screen.PrimaryScreen.WorkingArea.Height - 673)
        setApo()
        Me.KeyPreview = True
        FormPemanggil = "FormPenjualanResep"
        cmbJenisRawat.SelectedIndex = 0
        ListDokter()
        ListEtiketTakaran()
        ListEtiketWaktu()
        ListEtiketKeterangan()
        KosongkanDetailPaketUmum()
        KosongkanDetailPaketKhusus()
        KosongkanHeader()
        NoResep()
        cmbJenisRawat.Focus()
    End Sub

    Private Sub cmbJenisRawat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbJenisRawat.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNoReg.Focus()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisRawat.SelectedIndexChanged
        If cmbJenisRawat.SelectedIndex = 0 Then
            StatusRawat = "RJ"
            JenisRawat = "1"
            cmbPkt.SelectedIndex = 0
            cmbPkt.Enabled = True
        ElseIf cmbJenisRawat.SelectedIndex = 1 Then
            StatusRawat = "RI"
            JenisRawat = "2"
            cmbPkt.SelectedIndex = 0
            cmbPkt.Enabled = True
        ElseIf cmbJenisRawat.SelectedIndex = 2 Then
            StatusRawat = "RD"
            JenisRawat = "3"
            cmbPkt.SelectedIndex = 0
            cmbPkt.Enabled = True
        Else
            MsgBox("Coba Lagi")
        End If
        NoResep()
        txtNoReg.Focus()
    End Sub

    Private Sub txtNoReg_Click(sender As Object, e As EventArgs) Handles txtNoReg.Click
        TglServer()
        DTPPasienReg.Value = TanggalServer
        If cmbJenisRawat.SelectedIndex = 0 Then
            tampilPasienRJ()
        ElseIf cmbJenisRawat.SelectedIndex = 1 Then
            tampilPasienRI()
        ElseIf cmbJenisRawat.SelectedIndex = 2 Then
            tampilPasienRD()
        End If
        PanelPasien.Visible = True
        rNama.Checked = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnEx.Click
        PanelPasien.Visible = False
    End Sub

    Private Sub txtCariPasien_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPasien.KeyDown
        If e.KeyCode = Keys.Down Then
            gridPasien.Focus()
        End If
    End Sub

    Private Sub gridPasien_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPasien.CellContentClick
        Try
            If cmbJenisRawat.SelectedIndex = 1 Then
                lblKamarBed.Text = Trim(gridPasien.Rows(e.RowIndex).Cells("keterangan").Value)
            End If
            If cmbJenisRawat.SelectedIndex = 0 Then
                CMD = New OleDb.OleDbCommand("SELECT Registrasi.tgl_reg as tgl_reg, Registrasi.no_reg as no_reg, 
                        Registrasi.no_RM, Pasien.nama_pasien, Sub_Unit.nama_sub_unit, Registrasi.jns_rawat, Registrasi.jenis_pasien, 
                        Registrasi.status_keluar 
                        FROM Registrasi 
                        INNER JOIN Pasien ON Registrasi.no_RM = Pasien.no_RM 
                        INNER JOIN Rawat_Jalan ON Registrasi.no_reg = Rawat_Jalan.no_reg 
                        INNER JOIN Sub_Unit ON Rawat_Jalan.kd_poliklinik = Sub_Unit.kd_sub_unit 
                        WHERE registrasi.tgl_reg='" & Format(DTPPasienReg.Value, "yyyy/MM/dd") & "'  
                        AND registrasi.jns_rawat='" & JenisRawat & "' AND registrasi.status_keluar <> '2' 
                        AND registrasi.no_reg='" & gridPasien.Rows(e.RowIndex).Cells(2).Value & "' 
                        AND registrasi.no_reg IN (Select no_reg from kwitansi_header 
                                where no_reg='" & gridPasien.Rows(e.RowIndex).Cells(2).Value & "' 
                        AND jenis_pasien<>'UMUM') 
                        order by registrasi.no_reg", CONN)
                DA = New OleDb.OleDbDataAdapter(CMD)
                DT = New DataTable
                DA.Fill(DT)
                If DT.Rows.Count > 0 Then
                    MsgBox("Nomor registrasi sudah ada kwitansi, hubungi kasir untuk pembatalan")
                    Exit Sub
                End If
            ElseIf cmbJenisRawat.SelectedIndex = 2 Then
                CMD = New OleDb.OleDbCommand("select registrasi.tgl_reg as tgl_reg,registrasi.no_reg as no_reg, registrasi.no_rm, 
                    pasien.nama_pasien, registrasi.jns_rawat as jns_rawat, registrasi.jenis_pasien, registrasi.status_keluar 
                    from registrasi inner join pasien on registrasi.no_rm=pasien.no_rm 
                    where registrasi.tgl_reg='" & Format(DTPPasienReg.Value, "yyyy/MM/dd") & "'  
                    AND registrasi.jns_rawat='" & JenisRawat & "' 
                    AND registrasi.status_keluar <> '2' 
                    AND registrasi.no_reg='" & gridPasien.Rows(e.RowIndex).Cells(2).Value & "' 
                    AND registrasi.no_reg IN (Select no_reg from kwitansi_header 
                        where no_reg='" & gridPasien.Rows(e.RowIndex).Cells(2).Value & "') 
                    order by registrasi.no_reg", CONN)
                DA = New OleDb.OleDbDataAdapter(CMD)
                DT = New DataTable
                DA.Fill(DT)
                If DT.Rows.Count > 0 Then
                    MsgBox("Nomor registrasi sudah ada kwitansi, hubungi kasir untuk pembatalan")
                    Exit Sub
                End If
            End If
            If e.ColumnIndex = 0 Then
                If Not IsDBNull(gridPasien.Rows(e.RowIndex).Cells(1).Value) Then
                    txtNoReg.Text = gridPasien.Rows(e.RowIndex).Cells(2).Value
                    txtRM.Text = gridPasien.Rows(e.RowIndex).Cells(3).Value
                    txtNamaPasien.Text = gridPasien.Rows(e.RowIndex).Cells(4).Value

                    If IsDBNull(gridPasien.Rows(e.RowIndex).Cells(8).Value) Then
                        noSep = "-"
                    Else
                        noSep = gridPasien.Rows(e.RowIndex).Cells(8).Value
                    End If

                    If IsDBNull(gridPasien.Rows(e.RowIndex).Cells(9).Value) Then
                        noKartu = "-"
                    Else
                        noKartu = gridPasien.Rows(e.RowIndex).Cells(9).Value
                    End If

                    tampilICD(Trim(txtNoReg.Text))

                    txtSEP.Text = noSep
                    txtNoKartu.Text = noKartu
                    txtIcdSKU.Text = kdIcdSKU
                    txtIcdRM.Text = kdIcdRM
                    txtJnsRawat.Text = JenisRawat

                    tampilDiagnosa(txtIcdSKU.Text)

                    If DT.Rows.Count > 0 Then
                        txtNmICDSKU.Text = DT.Rows(0).Item("nama_icd")
                    Else
                        txtNmICDSKU.Text = "-"
                    End If

                    tampilDiagnosa(txtIcdRM.Text)
                    If DT.Rows.Count > 0 Then
                        txtNmICDRM.Text = DT.Rows(0).Item("nama_icd")
                    Else
                        txtNmICDRM.Text = "-"
                    End If

                    If IsDBNull(gridPasien.Rows(e.RowIndex).Cells(7).Value) Then
                        KdPenjamin = "UMUM"
                    Else
                        KdPenjamin = gridPasien.Rows(e.RowIndex).Cells(7).Value
                    End If
                    cmbPenjamin.Text = KdPenjamin
                    PanelPasien.Visible = False
                    detailPasien()
                End If
                btnInfoResep.Enabled = True
                btnBaru.Enabled = True
                btnInfoResepKh.Enabled = True
                btnBaruKh.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DTPPasienReg_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPPasienReg.KeyPress
        If e.KeyChar = Chr(13) Then
            If cmbJenisRawat.SelectedIndex = 0 Then
                tampilPasienRJ()
                'AturGridPasien()
            ElseIf cmbJenisRawat.SelectedIndex = 1 Then
                tampilPasienRI()
            ElseIf cmbJenisRawat.SelectedIndex = 2 Then
                tampilPasienRD()
            End If
        End If
        txtCariPasien.Focus()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        PanelObat.Visible = False
    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                If cmbPkt.Text = "Paket Umum" Then
                    txtKodeObat.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                    PanelObat.Visible = False
                    cekJangkaPemberianObatBPJS(Trim(txtKodeObat.Text))
                    If DT.Rows.Count > 0 Then
                        DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                        If DTPCekObat.Value > DTPTanggalTrans.Value Then
                            MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                            'Exit Sub
                        End If
                    End If
                    detailObat(Trim(txtKodeObat.Text))
                ElseIf cmbPkt.Text = "Paket Khusus" Then
                    txtKodeObatKh.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                    PanelObat.Visible = False
                    cekJangkaPemberianObatBPJS(Trim(txtKodeObatKh.Text))
                    If DT.Rows.Count > 0 Then
                        DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                        If DTPCekObat.Value > DTPTanggalTrans.Value Then
                            MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                            'Exit Sub
                        End If
                    End If
                    detailObat(Trim(txtKodeObatKh.Text))
                End If
            End If
        End If
    End Sub

    Private Sub txtCariObat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariObat.KeyDown
        If e.KeyCode = Keys.Down Then
            gridBarang.Focus()
        End If
    End Sub

    Private Sub txtJumlahJual_DragOver(sender As Object, e As DragEventArgs) Handles txtJumlahJual.DragOver

    End Sub

    Private Sub txtJumlahJual_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJumlahJual.KeyDown
        If e.KeyCode = Keys.Up Then
            cmbDijamin.Focus()
        End If
    End Sub

    Private Sub txtJumlahJual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahJual.KeyPress
        If e.KeyChar = Chr(13) Then
            If cmbDijamin.Text = "Y" Then
                SendKeys.Send("{TAB}")
            Else
                txtDijamin.Focus()
            End If

        End If
    End Sub

    Private Sub txtJumlahJual_TextChanged(sender As Object, e As EventArgs) Handles txtJumlahJual.TextChanged
        txtJumlahHarga.DecimalValue = txtHargaJual.DecimalValue * txtJumlahJual.DecimalValue
        If cmbDijamin.Text = "N" Then
            txtDijamin.DecimalValue = 0
            txtIuranSisaBayar.DecimalValue = txtJumlahHarga.DecimalValue
        ElseIf cmbDijamin.Text = "Y" Then
            txtIuranSisaBayar.DecimalValue = 0
            txtDijamin.DecimalValue = txtJumlahHarga.DecimalValue
        End If
    End Sub

    Private Sub txtNoReg_GotFocus(sender As Object, e As EventArgs) Handles txtNoReg.GotFocus
        TglServer()
        DTPPasienReg.Value = TanggalServer
        If cmbJenisRawat.SelectedIndex = 0 Then
            tampilPasienRJ()
            'AturGridPasien()
        ElseIf cmbJenisRawat.SelectedIndex = 1 Then
            tampilPasienRI()
        ElseIf cmbJenisRawat.SelectedIndex = 2 Then
            tampilPasienRD()
        End If
        PanelPasien.Visible = True
        rNama.Checked = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub txtKodeObat_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObat.GotFocus
        If stok0 = "1" Then
            tampilBarangSemua()
        Else
            tampilBarang()
        End If

        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub txtJmlHari_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlHari.KeyDown
        If e.KeyCode = Keys.Up Then
            txtJumlahJual.Focus()
        End If
    End Sub

    Private Sub IntegerTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlHari.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub IntegerTextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtJmlHari.TextChanged
        TglServer()
        DTPTglAkhir.Value = DateAdd("d", Val(txtJmlHari.Text), DTPTanggalTrans.Value)
    End Sub

    Private Sub gridPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridPasien.KeyPress
        Dim i As Integer
        'If gridPasien.Rows.Count() = 1 Then
        i = gridPasien.CurrentRow.Index - 1
        'End If
        If cmbJenisRawat.SelectedIndex = 1 Then
            lblKamarBed.Text = Trim(gridPasien.Rows(i).Cells("keterangan").Value)
        End If
        If e.KeyChar = Chr(13) Then
            If cmbJenisRawat.SelectedIndex = 0 Then
                CMD = New OleDb.OleDbCommand("SELECT Registrasi.tgl_reg as tgl_reg, Registrasi.no_reg as no_reg, 
                        Registrasi.no_RM, Registrasi.no_SJP, Pasien.nama_pasien, Sub_Unit.nama_sub_unit, 
                        Registrasi.jns_rawat, Registrasi.jenis_pasien, Registrasi.status_keluar 
                        FROM Registrasi INNER JOIN Pasien ON Registrasi.no_RM = Pasien.no_RM 
                        INNER JOIN Rawat_Jalan ON Registrasi.no_reg = Rawat_Jalan.no_reg 
                        INNER JOIN Sub_Unit ON Rawat_Jalan.kd_poliklinik = Sub_Unit.kd_sub_unit 
                        where registrasi.tgl_reg='" & Format(DTPPasienReg.Value, "yyyy/MM/dd") & "'  
                        AND registrasi.jns_rawat='" & JenisRawat & "' 
                        AND registrasi.status_keluar <> '2' 
                        AND registrasi.no_reg='" & gridPasien.Rows(i).Cells(2).Value & "' 
                        AND registrasi.no_reg IN (Select no_reg 
                        FROM kwitansi_header 
                        WHERE no_reg='" & gridPasien.Rows(i).Cells(2).Value & "' 
                        AND jenis_pasien<>'Umum') order by registrasi.no_reg", CONN)
                DA = New OleDb.OleDbDataAdapter(CMD)
                DT = New DataTable
                DA.Fill(DT)
                If DT.Rows.Count > 0 Then
                    MsgBox("Nomor registrasi sudah ada kwitansi, hubungi kasir untuk pembatalan")
                    Exit Sub
                End If
            ElseIf cmbJenisRawat.SelectedIndex = 2 Then
                CMD = New OleDb.OleDbCommand("select registrasi.tgl_reg as tgl_reg,registrasi.no_reg as no_reg, registrasi.no_rm, pasien.nama_pasien, registrasi.jns_rawat as jns_rawat, registrasi.jenis_pasien, registrasi.status_keluar from registrasi inner join pasien on registrasi.no_rm=pasien.no_rm where registrasi.tgl_reg='" & Format(DTPPasienReg.Value, "yyyy/MM/dd") & "'  AND registrasi.jns_rawat='" & JenisRawat & "' AND registrasi.status_keluar <> '2' AND registrasi.no_reg='" & gridPasien.Rows(i).Cells(2).Value & "' AND registrasi.no_reg IN (Select no_reg from kwitansi_header where no_reg='" & gridPasien.Rows(i).Cells(2).Value & "') order by registrasi.no_reg", CONN)
                DA = New OleDb.OleDbDataAdapter(CMD)
                DT = New DataTable
                DA.Fill(DT)
                If DT.Rows.Count > 0 Then
                    MsgBox("Nomor registrasi sudah ada kwitansi, hubungi kasir untuk pembatalan")
                    Exit Sub
                End If
            End If
            If Not IsDBNull(gridPasien.Rows(i).Cells(1).Value) Then

                txtNoReg.Text = gridPasien.Rows(i).Cells(2).Value
                txtRM.Text = gridPasien.Rows(i).Cells(3).Value
                txtNamaPasien.Text = gridPasien.Rows(i).Cells(4).Value
                If IsDBNull(gridPasien.Rows(i).Cells(8).Value) Then
                    noSep = "-"
                Else
                    noSep = gridPasien.Rows(i).Cells(8).Value
                End If

                If IsDBNull(gridPasien.Rows(i).Cells(9).Value) Then
                    noKartu = "-"
                Else
                    noKartu = gridPasien.Rows(i).Cells(9).Value
                End If

                tampilICD(Trim(txtNoReg.Text))

                txtSEP.Text = noSep
                txtNoKartu.Text = noKartu
                txtIcdSKU.Text = kdIcdSKU
                txtIcdRM.Text = kdIcdRM

                tampilDiagnosa(txtIcdSKU.Text)

                If DT.Rows.Count > 0 Then
                    txtNmICDSKU.Text = DT.Rows(0).Item("nama_icd")
                Else
                    txtNmICDSKU.Text = "-"
                End If

                tampilDiagnosa(txtIcdRM.Text)
                If DT.Rows.Count > 0 Then
                    txtNmICDRM.Text = DT.Rows(0).Item("nama_icd")
                Else
                    txtNmICDRM.Text = "-"
                End If

                txtJnsRawat.Text = JenisRawat
                If IsDBNull(gridPasien.Rows(i).Cells(7).Value) Then
                    KdPenjamin = "UMUM"
                Else
                    KdPenjamin = gridPasien.Rows(i).Cells(7).Value
                End If
                cmbPenjamin.Text = KdPenjamin
                PanelPasien.Visible = False
                detailPasien()
            End If
            btnInfoResep.Enabled = True
            btnBaru.Enabled = True
            btnInfoResepKh.Enabled = True
            btnBaruKh.Enabled = True
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                If cmbPkt.Text = "Paket Umum" Then
                    txtKodeObat.Text = gridBarang.Rows(i).Cells(2).Value
                    PanelObat.Visible = False
                    cekJangkaPemberianObatBPJS(Trim(txtKodeObat.Text))
                    If DT.Rows.Count > 0 Then
                        DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                        If DTPCekObat.Value > DTPTanggalTrans.Value Then
                            MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                            'Exit Sub
                        End If
                    End If
                    detailObat(Trim(txtKodeObat.Text))
                ElseIf cmbPkt.Text = "Paket Khusus" Then
                    txtKodeObatKh.Text = gridBarang.Rows(i).Cells(2).Value
                    PanelObat.Visible = False
                    cekJangkaPemberianObatBPJS(Trim(txtKodeObatKh.Text))
                    If DT.Rows.Count > 0 Then
                        DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                        If DTPCekObat.Value > DTPTanggalTrans.Value Then
                            MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                            'Exit Sub
                        End If
                    End If
                    detailObat(Trim(txtKodeObatKh.Text))
                End If
            End If
        End If
    End Sub

    Private Sub txtNoResep_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoResep.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoReg.Focus()
        End If
    End Sub

    Private Sub cmbRacikNon_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbRacikNon.KeyDown
        If e.KeyCode = Keys.Up Then
            cmbPkt.Focus()
        End If
    End Sub

    Private Sub cmbRacikNon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRacikNon.KeyPress
        If e.KeyChar = Chr(13) Then
            If e.KeyChar = Chr(13) Then
                If cmbRacikNon.Text = "R" Or cmbRacikNon.Text = "r" Or cmbRacikNon.Text = "N" Or cmbRacikNon.Text = "n" Then
                    SendKeys.Send("{TAB}")
                Else
                    MsgBox("Pilih yang benar", vbCritical, "Kesalahan")
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub cmbDijamin_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDijamin.KeyDown
        If e.KeyCode = Keys.Left Then
            txtKodeObat.Focus()
        End If
    End Sub

    Private Sub cmbDijamin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbDijamin.KeyPress
        If e.KeyChar = Chr(13) Then
            If e.KeyChar = Chr(13) Then
                If cmbDijamin.Text = "Y" Or cmbDijamin.Text = "y" Or cmbDijamin.Text = "N" Or cmbDijamin.Text = "n" Then
                    SendKeys.Send("{TAB}")
                Else
                    MsgBox("Pilih yang benar", vbCritical, "Kesalahan")
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub cmbEtiket_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEtiket.KeyDown
        If e.KeyCode = Keys.Left Then
            txtJmlHari.Focus()
        End If
    End Sub

    Private Sub cmbEtiket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbEtiket.KeyPress
        If e.KeyChar = Chr(13) Then
            If cmbEtiket.Text = "Y" Or cmbEtiket.Text = "y" Or cmbEtiket.Text = "N" Or cmbEtiket.Text = "n" Then
                If cmbEtiket.Text = "N" Then
                    PanelEtiket.Visible = False
                    PanelEtiketModel4.Visible = False
                    SendKeys.Send("{TAB}")
                Else
                    If pkdapo = "002" Then
                        PanelEtiketModel4.Visible = True
                        modelEtiket = "4"
                        txtNamaObatEtiketModel4.Focus()
                    Else
                        PanelEtiket.Visible = True
                        txtNamaObatEtiket.Text = lblNamaObat.Text
                        txtJumlahObatEtiket.DecimalValue = txtJumlahJual.DecimalValue
                        txtNamaObatEtiket.Focus()
                    End If
                End If
            Else
                MsgBox("Pilih yang benar", vbCritical, "Kesalahan")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub cmbEtiket_LostFocus(sender As Object, e As EventArgs) Handles cmbEtiket.LostFocus
        cmbEtiket.Text = (cmbEtiket.Text.ToUpper)
        nmPaket = "PKTUMUM"
        If cmbEtiket.Text = "Y" Then
            If pkdapo = "002" Then
                PanelEtiketModel4.Visible = True
                modelEtiket = "4"
                txtNamaObatEtiketModel4.Focus()
            Else
                PanelEtiket.Visible = True
                txtNamaObatEtiket.Focus()
            End If
        Else
            PanelEtiket.Visible = False
            PanelEtiketModel4.Visible = False
        End If
    End Sub

    Private Sub cmbEtiket_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEtiket.SelectedIndexChanged
        If cmbEtiket.Text = "Y" Then
            If pkdapo = "002" Then
                PanelEtiketModel4.Visible = True
                modelEtiket = "4"
            Else
                PanelEtiket.Visible = True
            End If
            txtNamaObatEtiket.Text = lblNamaObat.Text
            txtNamaObatEtiketInfus.Text = lblNamaObat.Text
            txtNamaObatEtiketModel3.Text = lblNamaObat.Text
            txtNamaObatEtiketModel4.Text = lblNamaObat.Text
            txtJumlahObatEtiket.DecimalValue = txtJumlahJual.DecimalValue
            txtJumlahObatEtiketInfus.DecimalValue = txtJumlahJual.DecimalValue
            txtJumlahObatEtiketModel3.DecimalValue = txtJumlahJual.DecimalValue
            txtNamaObatEtiket.Focus()
        Else
            PanelEtiket.Visible = False
            PanelEtiketInfus.Visible = False
            PanelEtiketModel3.Visible = False
            PanelEtiketModel4.Visible = False
        End If
    End Sub

    Private Sub txtQty1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtQty2_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbTakaran_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTakaran.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbWaktu.Focus()
        End If
        If e.KeyCode = Keys.Left Then
            txtSigna2.Focus()
        End If
    End Sub

    Private Sub cmbWaktu_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbWaktu.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbKeterangan.Focus()
        End If
        If e.KeyCode = Keys.Left Then
            cmbTakaran.Focus()
        End If
    End Sub

    Private Sub cmbKeterangan_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbKeterangan.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJarakED.Focus()
        End If
        If e.KeyCode = Keys.Left Then
            cmbWaktu.Focus()
        End If
    End Sub

    Private Sub cmbRacikNon_LostFocus(sender As Object, e As EventArgs) Handles cmbRacikNon.LostFocus
        cmbRacikNon.Text = (cmbRacikNon.Text.ToUpper)
    End Sub

    Private Sub cmbDijamin_LostFocus(sender As Object, e As EventArgs) Handles cmbDijamin.LostFocus
        cmbDijamin.Text = (cmbDijamin.Text.ToUpper)
    End Sub

    Private Sub txtDijamin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDijamin.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJmlHari.Focus()
        End If
    End Sub

    Private Sub txtDijamin_TextChanged(sender As Object, e As EventArgs) Handles txtDijamin.TextChanged
        txtIuranSisaBayar.DecimalValue = txtJumlahHarga.DecimalValue - txtDijamin.DecimalValue
    End Sub

    Private Sub gridDetailObat_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gridDetailObat.CellEndEdit
        gridDetailObat.Rows(e.RowIndex).Cells("totalharga").Value = gridDetailObat.Rows(e.RowIndex).Cells("harga").Value * gridDetailObat.Rows(e.RowIndex).Cells("jml").Value
        If cmbPenjamin.Text = "-|UMUM" Then
            gridDetailObat.Rows(e.RowIndex).Cells(8).Value = gridDetailObat.Rows(e.RowIndex).Cells(6).Value
        Else
            gridDetailObat.Rows(e.RowIndex).Cells(7).Value = gridDetailObat.Rows(e.RowIndex).Cells(6).Value
        End If
        TotalHarga()
        TotalDijamin()
        TotalIurBayar()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        KosongkanHeader()
        KosongkanDetailPaketUmum()
        NoResep()
        txtNoResep.Focus()
    End Sub

    Private Sub btnInfoResep_Click(sender As Object, e As EventArgs) Handles btnInfoResep.Click
        FormPemanggil = "FormPenjualanResep"
        If txtNoReg.Text = "" Then
            MsgBox("Pilih pasien terlebih dahulu")
            txtNoReg.Focus()
        Else
            FormInfoResepObat.ShowDialog()
        End If
    End Sub


    Private Sub btnAdd_Click_1(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtNoReg.Text = "" Then
            MsgBox("Pilih pasien terlebih dahulu")
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
            'For barisGrid As Integer = 0 To gridDetailObat.RowCount - 1
            '    If Trim(txtKodeObat.Text) = gridDetailObat.Rows(barisGrid).Cells("kd_barang").Value Then
            '        MsgBox("Obat ini sudah dientry")
            '        KosongkanDetailPaketUmum()
            '        txtKodeObat.Focus()
            '        Exit Sub
            '    End If
            'Next
            txtJumlahHarga.DecimalValue = txtHargaJual.DecimalValue * txtJumlahJual.DecimalValue
            If cmbDijamin.Text = "N" Then
                'txtDijamin.DecimalValue = 0
                txtIuranSisaBayar.DecimalValue = txtJumlahHarga.DecimalValue - txtDijamin.DecimalValue
            ElseIf cmbDijamin.Text = "Y" Then
                txtIuranSisaBayar.DecimalValue = 0
                txtDijamin.DecimalValue = txtJumlahHarga.DecimalValue
                txtIuranSisaBayar.DecimalValue = txtJumlahHarga.DecimalValue - txtDijamin.DecimalValue
            End If
            PanelEtiketModel4.Visible = False
            addBarang()
            AturGriddetailBarang()
            NoUrut()
            KosongkanDetailPaketUmum()
            btnSimpan.Enabled = True
            txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
            cmbRacikNon.Focus()
        End If
    End Sub

    Private Sub FormPenjualanResep_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        PanelPasien.Top = txtNoReg.Top + 61
        PanelPasien.Left = txtNoReg.Left
        PanelObat.Top = txtKodeObat.Top + 218
        PanelObat.Left = txtKodeObat.Left + 4
        PanelEtiket.Location = New Point(769, 325)
        PanelEtiketInfus.Location = New Point(769, 325)
        PanelEtiketModel3.Location = New Point(769, 325)
        PanelEtiketModel4.Location = New Point(769, 325)
    End Sub

    Private Sub cmbPkt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPkt.KeyPress
        If e.KeyChar = Chr(13) Then
            If cmbPkt.Text = "Paket Umum" Then
                cmbRacikNon.Focus()
            ElseIf cmbPkt.Text = "Paket Khusus" Then
                cmbRacikNonKh.Focus()
            End If
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbPkt.SelectedIndexChanged
        If cmbPkt.SelectedIndex = 1 Then
            If KdPenjamin <> "23" And KdPenjamin <> "24" Then
                MsgBox("Hanya pasien BPJS yang bisa Paket Khusus")
                cmbPkt.SelectedIndex = 0
                Exit Sub
            End If
        End If

        If cmbPkt.SelectedIndex = 0 Then
            TabPktUmum.TabVisible = True
            TabPktKhusus.TabVisible = False
            cmbRacikNon.Focus()
        ElseIf cmbPkt.SelectedIndex = 1 Then
            TabPktUmum.TabVisible = False
            TabPktKhusus.TabVisible = True
            cmbRacikNonKh.Focus()
        Else
            TabPktUmum.TabVisible = False
            TabPktKhusus.TabVisible = False
        End If
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

    Private Sub txtDosisResep_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDosisResep.KeyDown
        If e.KeyCode = Keys.Up Then
            txtKodeObat.Focus()
        End If
    End Sub

    Private Sub txtDosisResep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDosisResep.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJmlBungkus.Focus()
        End If
    End Sub

    Private Sub txtJmlBungkus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlBungkus.KeyDown
        If e.KeyCode = Keys.Up Then
            txtDosisResep.Focus()
        End If
    End Sub

    Private Sub txtJmlBungkus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlBungkus.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbDijamin.Focus()
        End If
    End Sub

    Private Sub cmbDijamin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDijamin.SelectedIndexChanged
        If cmbDijamin.Text = "Y" Then
            txtDijamin.Enabled = False
        Else
            txtDijamin.Enabled = True
        End If
    End Sub

    Private Sub cmbRacikNonKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRacikNonKh.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKodeObatKh.Focus()
        End If
    End Sub

    Private Sub txtKodeObatKh_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObatKh.GotFocus
        If Stok = "1" Then
            tampilBarangSemua()
        Else
            tampilBarang()
        End If
        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub cmbRacikNonKh_LostFocus(sender As Object, e As EventArgs) Handles cmbRacikNonKh.LostFocus
        cmbRacikNonKh.Text = (cmbRacikNonKh.Text.ToUpper)
    End Sub

    Private Sub cmbEtiketKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbEtiketKh.KeyPress
        If e.KeyChar = Chr(13) Then
            If cmbEtiketKh.Text = "N" Then
                PanelEtiket.Visible = False
                PanelEtiketModel3.Visible = False
                PanelEtiketInfus.Visible = False
                SendKeys.Send("{TAB}")
            Else
                PanelEtiket.Visible = True
                txtNamaObatEtiket.Text = lblNamaObatKh.Text
                txtNamaObatEtiketInfus.Text = lblNamaObatKh.Text
                txtNamaObatEtiketModel3.Text = lblNamaObatKh.Text
                txtJumlahObatEtiket.DecimalValue = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
                txtNamaObatEtiket.Focus()
            End If

        End If
    End Sub

    Private Sub cmbEtiketKh_LostFocus(sender As Object, e As EventArgs) Handles cmbEtiketKh.LostFocus
        cmbEtiketKh.Text = (cmbEtiketKh.Text.ToUpper)
        nmPaket = "PKTKHUSUS"
        If cmbEtiketKh.Text = "Y" Then
            txtNamaObatEtiket.Text = lblNamaObatKh.Text
            txtJumlahObatEtiket.DecimalValue = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
        Else
            txtNamaObatEtiket.Clear()
        End If
    End Sub

    Private Sub cmbEtiketKh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEtiketKh.SelectedIndexChanged
        If cmbEtiketKh.Text = "N" Then
            PanelEtiket.Visible = False
            PanelEtiketInfus.Visible = False
            PanelEtiketModel3.Visible = False
            PanelEtiketModel4.Visible = False
        Else
            PanelEtiket.Visible = True
            txtNamaObatEtiket.Text = lblNamaObatKh.Text
            txtNamaObatEtiketInfus.Text = lblNamaObatKh.Text
            txtNamaObatEtiketModel3.Text = lblNamaObatKh.Text
            txtNamaObatEtiketModel4.Text = lblNamaObatKh.Text
            txtJumlahObatEtiket.DecimalValue = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
            txtJumlahObatEtiketInfus.DecimalValue = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
            txtJumlahObatEtiketModel3.DecimalValue = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
            txtNamaObatEtiket.Focus()
        End If
    End Sub

    Private Sub cmbRacikNonKh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRacikNonKh.SelectedIndexChanged
        If cmbRacikNonKh.Text = "R" Then
            txtDosisResepKh.Enabled = True
            txtJmlCapBPJSKh.Enabled = True
            txtJmlCapLainKh.Enabled = True
            txtJmlObatKh.Enabled = True
        Else
            txtDosisResepKh.Enabled = False
            txtJmlCapBPJSKh.Enabled = False
            txtJmlCapLainKh.Enabled = False
            txtJmlObatKh.Enabled = False
        End If
    End Sub

    Private Sub txtDosisResepKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDosisResepKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtKodeObatKh.Focus()
        End If
    End Sub

    Private Sub txtDosisResepKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDosisResepKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlCapBPJSKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlCapBPJSKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtDosisResepKh.Focus()
        End If
    End Sub

    Private Sub txtJmlCapBPJSKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlCapBPJSKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlCapLainKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlCapLainKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtJmlCapBPJSKh.Focus()
        End If
    End Sub

    Private Sub txtJmlCapLainKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlCapLainKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlObatKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlObatKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtJmlCapLainKh.Focus()
        End If
    End Sub

    Private Sub txtJmlObatKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlObatKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPaketBPJSKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPaketBPJSKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtKodeObatKh.Focus()
        End If
    End Sub

    Private Sub txtPaketBPJSKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaketBPJSKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPaketLainKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPaketLainKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtPaketBPJSKh.Focus()
        End If
    End Sub

    Private Sub txtPaketLainKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaketLainKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlHariKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlHariKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtPaketLainKh.Focus()
        End If
    End Sub

    Private Sub txtJmlHariKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlHariKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlHariKh_TextChanged(sender As Object, e As EventArgs) Handles txtJmlHariKh.TextChanged
        TglServer()
        DTPTglAkhirKh.Value = DateAdd("d", Val(txtJmlHariKh.Text), DTPTanggalTrans.Value)
    End Sub

    Private Sub txtPaketBPJSKh_TextChanged(sender As Object, e As EventArgs) Handles txtPaketBPJSKh.TextChanged
        txtTotalPaketBPJSKh.DecimalValue = txtPaketBPJSKh.DecimalValue * txtHargaJualKh.DecimalValue
    End Sub

    Private Sub txtPaketLainKh_TextChanged(sender As Object, e As EventArgs) Handles txtPaketLainKh.TextChanged
        txtTotalPaketLainKh.DecimalValue = txtPaketLainKh.DecimalValue * txtHargaJualKh.DecimalValue
    End Sub

    Private Sub btnAddKh_Click(sender As Object, e As EventArgs) Handles btnAddKh.Click
        If txtNoReg.Text = "" Then
            MsgBox("Pilih pasien terlebih dahulu")
            Exit Sub
        End If
        If txtKodeObatKh.Text = "" Then
            MsgBox("Obat belum dipilih")
            Exit Sub
        End If
        'For barisGrid As Integer = 0 To gridDetailObatKh.RowCount - 1
        '    If Trim(txtKodeObatKh.Text) = gridDetailObatKh.Rows(barisGrid).Cells("kd_barang").Value Then
        '        MsgBox("Obat ini sudah dientry")
        '        KosongkanDetailPaketKhusus()
        '        txtKodeObatKh.Focus()
        '        Exit Sub
        '    End If
        'Next
        PanelEtiketModel4.Visible = False
        addBarangKh()
        AturGriddetailBarangKh()
        NoUrut()
        KosongkanDetailPaketKhusus()
        txtQtyKh.DecimalValue = gridDetailObatKh.Rows.Count() - 1
        cmbRacikNonKh.Focus()
        btnSimpanKh.Enabled = True
    End Sub

    Private Sub btnKeluarKh_Click(sender As Object, e As EventArgs) Handles btnKeluarKh.Click
        Dispose()
    End Sub

    Private Sub btnInfoKh_Click(sender As Object, e As EventArgs) Handles btnInfoResepKh.Click
        FormPemanggil = "FormPenjualanResep"
        If txtNoReg.Text = "" Then
            MsgBox("Pilih pasien terlebih dahulu")
            txtNoReg.Focus()
        Else
            FormInfoResepObat.ShowDialog()
        End If
    End Sub

    Private Sub gridDetailObatKh_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObatKh.CellFormatting
        gridDetailObatKh.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub gridDetailObat_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObat.CellFormatting
        gridDetailObat.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles txtHapusBaris.Click
        If MessageBox.Show("Yakin Akan Dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If gridDetailObat.CurrentRow.Index <> gridDetailObat.NewRowIndex Then
                    gridDetailObat.Rows.RemoveAt(gridDetailObat.CurrentRow.Index)
                End If
                txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
                TotalHarga()
                TotalDijamin()
                TotalIurBayar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button2_Click_2(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("Yakin Akan Dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If gridDetailObatKh.CurrentRow.Index <> gridDetailObatKh.NewRowIndex Then
                gridDetailObatKh.Rows.RemoveAt(gridDetailObatKh.CurrentRow.Index)
            End If
            txtQtyKh.DecimalValue = gridDetailObatKh.Rows.Count() - 1
            TotalPaket()
            TotalNonPaket()
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        cariSubUnitAsal()
        cariNamaPenjamin()
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

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Cek Stok
        If CekKunciStokPenjualan = "Y" Then
            For i = 0 To gridDetailObat.RowCount - 2
                CMD = New OleDb.OleDbCommand("select idx_barang,kd_barang,nama_barang, " & memStok & " as stok, kd_satuan_kecil from barang_farmasi where kd_barang='" & gridDetailObat.Rows(i).Cells("kd_barang").Value & "'", CONN)
                DA = New OleDb.OleDbDataAdapter(CMD)
                DT = New DataTable
                DA.Fill(DT)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("stok") < gridDetailObat.Rows(i).Cells("jml").Value Then
                        MsgBox("Stok " + Trim(DT.Rows(0).Item("nama_barang")) + " hanya " + DT.Rows(0).Item("stok").ToString + " masukan ulang jumlah barang", vbInformation, "Informasi")
                        Exit Sub
                    End If
                End If
            Next
        End If
        If MessageBox.Show("Data Penjualan sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlPenjualanObat As String = ""
            NoResep()
            TglServer()
            DTPJamAkhir.Value = TanggalServer
            'CONN.Open()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Apotek
                sqlPenjualanObat = "insert into ap_jualr1(stsrawat,kdkasir,nmkasir,tanggal,notaresep,no_reg,no_rm,nama_pasien,kd_penjamin,nm_penjamin,kddokter,nmdokter,kdbagian,stsresep,totalpaket,totalpaket_bulat,totalnonpaket,totalnonpaket_bulat,totaldijamin,totaldijamin_bulat,totalselisih_bayar,totalselisih_bayar_bulat,kd_sub_unit,kd_sub_unit_asal,nama_sub_unit,jam,rsp_pulang,posting,diserahkan) values ('" & StatusRawat & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "', '" & KdPenjamin & "', '" & NamaPenjamin & "', '" & kdDokter & "', '" & NamaDokter & "', '" & pkdapo & "', 'PKTUMUM', '" & Num_En_US(txtGrandTotal.DecimalValue) & "', '" & Num_En_US(txtGrandTotalBulat.DecimalValue) & "', '0', '0', '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "', '" & Num_En_US(txtGrandIurBayar.DecimalValue) & "', '" & Num_En_US(txtGrandIurBayarBulat.DecimalValue) & "', '" & kdSubUnit & "', '" & kdSubUnit & "', '" & nmSubUnit & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', 'N', '1', 'B')"

                For i = 0 To gridDetailObat.RowCount - 2
                    sqlPenjualanObat = sqlPenjualanObat & vbCrLf & "INSERT INTO ap_jualr2(
                        stsrawat,kdkasir,nmkasir,
                        tanggal,notaresep,no_reg,no_rm,
                        nmpasien,umurthn,umurbln,
                        kd_penjamin,nm_penjamin,kddokter,
                        nmdokter,nonota,urut,kd_barang,
                        idx_barang,nama_barang,kd_jns_obat,
                        kd_gol_obat,kd_kel_obat,kdpabrik,
                        generik,formularium,racik,
                        harga,jmlpaket,totalpaket,
                        jmlnonpaket,totalnonpaket,jml,
                        nmsatuan,totalharga,senpot,
                        potongan,jmlnet,dijamin,
                        sisabayar,hrgbeli,jamawal,
                        kdbagian,stsresep,rek_p,
                        stsetiket,jmlhari,posting,
                        diserahkan,jam,rsp_pulang,
                        jns_obat,jmljatah,tglakhir) 
                    VALUES (
                        '" & StatusRawat & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "',
                        '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtNoReg.Text) & "',
                        '" & Trim(txtRM.Text) & "','" & Trim(txtNamaPasien.Text) & "','" & Trim(txtUmurThn.Text) & "',
                        '" & Trim(txtUmurBln.Text) & "', '" & KdPenjamin & "', '" & NamaPenjamin & "', 
                        '" & kdDokter & "', '" & NamaDokter & "', '" & Trim(txtNota.Text) & "', 
                        " & i + 1 & ", '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "',
                        '" & Trim(gridDetailObat.Rows(i).Cells("idx_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nama_barang").Value)) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_jns_obat").Value) & "', 
                        '" & Trim(gridDetailObat.Rows(i).Cells("kd_gol_obat").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_kel_obat").Value) & "','" & Trim(gridDetailObat.Rows(i).Cells("kdpabrik").Value) & "', 
                        '" & Trim(gridDetailObat.Rows(i).Cells("generik").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("formularium").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("racik").Value) & "', 
                        '" & Num_En_US(gridDetailObat.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "','" & Num_En_US(gridDetailObat.Rows(i).Cells("totalharga").Value) & "',
                        '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmln").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totaln").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "', 
                        '" & Trim(gridDetailObat.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalharga").Value) & "', '" & gridDetailObat.Rows(i).Cells("senpot").Value & "',
                        '" & Num_En_US(gridDetailObat.Rows(i).Cells("potongan").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalharga").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', 
                        '" & Num_En_US(gridDetailObat.Rows(i).Cells("sisabayar").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgbeli").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("jamawal").Value) & "', 
                        '" & Trim(gridDetailObat.Rows(i).Cells("kdbagian").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("stsresep").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("rek_p").Value) & "', 
                        '" & Trim(gridDetailObat.Rows(i).Cells("stsetiket").Value) & "',  '" & gridDetailObat.Rows(i).Cells("jmlhari").Value & "', '" & Trim(gridDetailObat.Rows(i).Cells("posting").Value) & "', 
                        '" & Trim(gridDetailObat.Rows(i).Cells("diserahkan").Value) & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', 'N', '" & Trim(gridDetailObat.Rows(i).Cells("jns_obat").Value) & "', 
                        '" & gridDetailObat.Rows(i).Cells("jmljatah").Value & "', '" & Format(gridDetailObat.Rows(i).Cells("tglakhir").Value, "yyyy/MM/dd") & "')"
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Cek Jatah Paket
                For i = 0 To gridDetailObat.RowCount - 2
                    If gridDetailObat.Rows(i).Cells("jmljatah").Value > 0 Then
                        sqlPenjualanObat = sqlPenjualanObat & vbCrLf & "INSERT INTO ap_jualr2_bpjs(stsrawat,tglresep,notaresep,no_rm,kd_penjamin,kd_barang,nama_barang,jmlpaket,jmlnonpaket,jmljatah,tglakhir,kdbagian) VALUES ('" & StatusRawat & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & KdPenjamin & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nama_barang").Value)) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmln").Value) & "', '" & gridDetailObat.Rows(i).Cells("jmljatah").Value & "', '" & Format(gridDetailObat.Rows(i).Cells("tglakhir").Value, "yyyy/MM/dd") & "',  '" & Trim(gridDetailObat.Rows(i).Cells("kdbagian").Value) & "')"
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Simpan Etiket
                'If  pkdapo = "002" Or  pkdapo = "005" Then
                For i = 0 To gridDetailObat.RowCount - 2
                    'Dim a = gridDetailObat.CurrentRow.Index - 1
                    If gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObat.Rows(i).Cells("model_etiket").Value = "1" Then
                        sqlPenjualanObat = sqlPenjualanObat & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, signa1, signa2, tgl_exp, jml_obat, urut, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket").Value)) & "', '" & gridDetailObat.Rows(i).Cells("takaran").Value & "', '" & gridDetailObat.Rows(i).Cells("waktu").Value & "', '" & gridDetailObat.Rows(i).Cells("ketminum").Value & "','" & Trim(gridDetailObat.Rows(i).Cells("qty1").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("qty2").Value) & "',  '" & Format(gridDetailObat.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ",'1')"
                    ElseIf gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObat.Rows(i).Cells("model_etiket").Value = "2" Then
                        sqlPenjualanObat = sqlPenjualanObat & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, jml_obat, urut, obat, tetes, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket_infus").Value)) & "',  '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlobat_etiket_infus").Value) & "', " & i + 1 & ", '" & Rep(Trim(gridDetailObat.Rows(i).Cells("obat_infus").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("tetes_infus").Value)) & "','2')"
                    ElseIf gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObat.Rows(i).Cells("model_etiket").Value = "3" Then
                        sqlPenjualanObat = sqlPenjualanObat & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, jml_obat, urut, kd_ketminum, tgl_exp, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket").Value)) & "',  '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ", '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ketminum").Value)) & "', '" & Format(gridDetailObat.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '3')"
                    ElseIf gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObat.Rows(i).Cells("model_etiket").Value = "4" Then
                        sqlPenjualanObat = sqlPenjualanObat & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, urut, ket_waktu_pagi_model4, ket_waktu_siang_model4, ket_waktu_sore_model4,ket_waktu_malam_model4, ket_minum_model4, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket").Value)) & "',  " & i + 1 & ", '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_waktu_pagi_model4").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_waktu_siang_model4").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_waktu_sore_model4").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_waktu_malam_model4").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_minum_model4").Value)) & "', '4')"
                    End If
                Next

                'Else
                'For i = 0 To gridDetailObat.RowCount - 2
                '    'Dim a = gridDetailObat.CurrentRow.Index - 1
                '    If gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" Then
                '        sqlPenjualanObat = sqlPenjualanObat + vbCrLf + "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, signa1, signa2, tgl_exp, jml_obat, urut) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket").Value)) & "', '" & gridDetailObat.Rows(i).Cells("takaran").Value & "', '" & gridDetailObat.Rows(i).Cells("waktu").Value & "', '" & gridDetailObat.Rows(i).Cells("ketminum").Value & "','" & Trim(gridDetailObat.Rows(i).Cells("qty1").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("qty2").Value) & "',  '" & Format(gridDetailObat.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ")"
                '    End If
                'Next
                'End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Kasir
                sqlPenjualanObat = sqlPenjualanObat & vbCrLf & "insert into resep_jual(no_nota, no_rm, no_reg, jenis_rawat, tgl_jual, waktu, kd_dokter, kd_sub_unit, status_bayar, kd_kelompok_pelanggan, metode_bayar, total, user_id, user_nama, waktu_in, waktu_out, kd_sub_unit_asal, total_bulat, total_non_paket, total_non_paket_bulat, total_tunai, total_tunai_bulat, total_piutang, total_piutang_bulat) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNoReg.Text) & "',  '" & StatusRawat & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss").ToString & "', '" & kdDokter & "', '" & pkdsubunit & "', 'BELUM', '0', 'KREDIT', '" & Num_En_US(txtGrandTotal.DecimalValue) & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', '-', '" & kdSubUnit & "', '" & Num_En_US(txtGrandTotalBulat.DecimalValue) & "', '0', '0','" & Num_En_US(txtGrandIurBayar.DecimalValue) & "', '" & Num_En_US(txtGrandIurBayarBulat.DecimalValue) & "', '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "')"

                For i = 0 To gridDetailObat.RowCount - 2
                    sqlPenjualanObat = sqlPenjualanObat & vbCrLf & "INSERT INTO resep_jual_detail(no_nota, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, nr, urutan, kd_sub_unit_asal, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("idx_barang").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgbeli").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '0', '0', '" & Num_En_US((gridDetailObat.Rows(i).Cells("totalharga").Value) - (gridDetailObat.Rows(i).Cells("dijamin").Value)) & "',  '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalharga").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("racik").Value) & "', " & i + 1 & ", '" & kdSubUnit & "', '0', '0', '" & Trim(gridDetailObat.Rows(i).Cells("rek_p").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nama_barang").Value)) & "', '0')"
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Update Stok
                If psts_stok = "1" Then
                    For i = 0 To gridDetailObat.RowCount - 2
                        sqlPenjualanObat = sqlPenjualanObat & vbCrLf & "UPDATE Barang_Farmasi SET " & memStok & "=(" & memStok & "-" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & ") WHERE kd_barang='" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "'"
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CMD.CommandText = sqlPenjualanObat
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi penjualan berhasil tersimpan", vbInformation, "Informasi")
                btnSimpan.Enabled = False
                btnCetakNota.Enabled = True
                btnCetakEtiket.Enabled = True
                btnCetakNota.Focus()
                ServiceApi.updateTaskAntrianBPJS(txtNoReg.Text, "6")
            Catch ex As Exception
                Try
                    Trans.Rollback()
                    MsgBox(" Commit Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                    MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                Catch ex2 As Exception
                    MsgBox(" Rollback Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                    MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                End Try
            End Try
        End If
    End Sub

    Private Sub txtCariObat_TextChanged(sender As Object, e As EventArgs) Handles txtCariObat.TextChanged
        BDDataBarang.Filter = "nama_barang like '%" & txtCariObat.Text & "%'"
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
        If rRm.Checked = True Then
            If cmbJenisRawat.SelectedIndex = 0 Then
                BDDataPasienRJ.Filter = "no_RM like '%" & txtCariPasien.Text & "%'"
                AturGridPasien()
            ElseIf cmbJenisRawat.SelectedIndex = 1 Then
                BDDataPasienRI.Filter = "no_RM like '%" & txtCariPasien.Text & "%'"
            ElseIf cmbJenisRawat.SelectedIndex = 2 Then
                BDDataPasienRD.Filter = "no_RM like '%" & txtCariPasien.Text & "%'"
            End If
        Else
            If cmbJenisRawat.SelectedIndex = 0 Then
                BDDataPasienRJ.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
                AturGridPasien()
            ElseIf cmbJenisRawat.SelectedIndex = 1 Then
                BDDataPasienRI.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
            ElseIf cmbJenisRawat.SelectedIndex = 2 Then
                BDDataPasienRD.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
            End If
        End If
    End Sub

    Private Sub btnSimpanKh_Click(sender As Object, e As EventArgs) Handles btnSimpanKh.Click
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

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Cek Stok
        If CekKunciStokPenjualan = "Y" Then
            For i = 0 To gridDetailObatKh.RowCount - 2
                CMD = New OleDb.OleDbCommand("select idx_barang,kd_barang,nama_barang, " & memStok & " as stok, kd_satuan_kecil from Barang_Farmasi where kd_barang='" & gridDetailObatKh.Rows(i).Cells("kd_barang").Value & "'", CONN)
                DA = New OleDb.OleDbDataAdapter(CMD)
                DT = New DataTable
                DA.Fill(DT)
                If DT.Rows.Count > 0 Then
                    If DT.Rows(0).Item("stok") < gridDetailObatKh.Rows(i).Cells("jml").Value Then
                        MsgBox("Stok " + Trim(DT.Rows(0).Item("nama_barang")) + " hanya " + DT.Rows(0).Item("stok").ToString + " masukan ulang jumlah barang", vbInformation, "Informasi")
                        Exit Sub
                    End If
                End If
            Next
        End If
        If MessageBox.Show("Data Penjualan sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlPenjualanObatKh As String = ""
            NoResep()
            TglServer()
            DTPJamAkhir.Value = TanggalServer
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Apotek
                sqlPenjualanObatKh = "insert into ap_jualr1 (stsrawat,kdkasir,nmkasir,tanggal,notaresep,no_reg,no_rm,nama_pasien,kd_penjamin,nm_penjamin,kddokter,nmdokter,kdbagian,stsresep,totalpaket,totalpaket_bulat,totalnonpaket,totalnonpaket_bulat,totaldijamin,totaldijamin_bulat,totalselisih_bayar,totalselisih_bayar_bulat,kd_sub_unit,kd_sub_unit_asal,nama_sub_unit,jam,rsp_pulang,posting,diserahkan) values ('" & StatusRawat & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "', '" & KdPenjamin & "', '" & NamaPenjamin & "', '" & kdDokter & "', '" & NamaDokter & "', '" & pkdapo & "', 'PKTKHUSUS', '" & Num_En_US(txtGrandTotalPaket.DecimalValue) & "', '" & Num_En_US(txtGrandTotalPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalNonPaket.DecimalValue) & "', '" & Num_En_US(txtGrandTotalNonPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalPaket.DecimalValue) & "', '" & Num_En_US(txtGrandTotalPaketBulat.DecimalValue) & "', '0', '0', '" & kdSubUnit & "', '" & kdSubUnit & "', '" & nmSubUnit & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', 'N', '1', 'B')"

                For i = 0 To gridDetailObatKh.RowCount - 2
                    sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "INSERT INTO ap_jualr2(stsrawat,kdkasir,nmkasir,tanggal,notaresep,no_reg,no_rm,nmpasien,umurthn,umurbln,kd_penjamin,nm_penjamin,kddokter,nmdokter,nonota,urut,kd_barang,idx_barang,nama_barang,kd_jns_obat,kd_gol_obat,kd_kel_obat,kdpabrik,generik,formularium,racik,harga,jmlpaket,totalpaket,jmlnonpaket,totalnonpaket,jml,nmsatuan,totalharga,senpot,potongan,jmlnet,dijamin,sisabayar,hrgbeli,jamawal,kdbagian,stsresep,rek_p,stsetiket,jmlhari,posting,diserahkan,jam,rsp_pulang,jns_obat,jmljatah,tglakhir) VALUES ('" & StatusRawat & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "','" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "','" & Trim(txtUmurThn.Text) & "', '" & Trim(txtUmurBln.Text) & "', '" & KdPenjamin & "', '" & NamaPenjamin & "', '" & kdDokter & "', '" & NamaDokter & "', '" & Trim(txtNota.Text) & "', " & i + 1 & ", '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("idx_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nama_barang").Value)) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_jns_obat").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_gol_obat").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_kel_obat").Value) & "','" & Trim(gridDetailObatKh.Rows(i).Cells("kdpabrik").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("generik").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("formularium").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("racik").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlp").Value) & "','" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalp").Value) & "','" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmln").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totaln").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jml").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalharga").Value) & "', '" & gridDetailObatKh.Rows(i).Cells("senpot").Value & "','" & Num_En_US(gridDetailObatKh.Rows(i).Cells("potongan").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlnet").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("sisabayar").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("hrgbeli").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("jamawal").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kdbagian").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("stsresep").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("rek_p").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("stsetiket").Value) & "', '" & gridDetailObatKh.Rows(i).Cells("jmlhari").Value & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("posting").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("diserahkan").Value) & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', 'N', '" & Trim(gridDetailObatKh.Rows(i).Cells("jns_obat").Value) & "', '" & gridDetailObatKh.Rows(i).Cells("jmljatah").Value & "', '" & Format(gridDetailObatKh.Rows(i).Cells("tglakhir").Value, "yyyy/MM/dd") & "')"
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Jatah Paket
                For i = 0 To gridDetailObatKh.RowCount - 2
                    If gridDetailObatKh.Rows(i).Cells("jmljatah").Value > 0 Then
                        sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "INSERT INTO ap_jualr2_bpjs(stsrawat,tglresep,notaresep,no_rm,kd_penjamin,kd_barang,nama_barang,jmlpaket,jmlnonpaket,jmljatah,tglakhir,kdbagian) VALUES ('" & StatusRawat & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & KdPenjamin & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nama_barang").Value)) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlp").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmln").Value) & "', '" & gridDetailObatKh.Rows(i).Cells("jmljatah").Value & "', '" & Format(gridDetailObatKh.Rows(i).Cells("tglakhir").Value, "yyyy/MM/dd") & "',  '" & Trim(gridDetailObatKh.Rows(i).Cells("kdbagian").Value) & "')"
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Simpan Etiket
                'If  pkdapo = "002" Or  pkdapo = "005" Then
                For i = 0 To gridDetailObatKh.RowCount - 2
                    'Dim a = gridDetailObatKh.CurrentRow.Index - 1
                    If gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "1" Then
                        sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, signa1, signa2, tgl_exp, jml_obat, urut, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value)) & "', '" & gridDetailObatKh.Rows(i).Cells("takaran").Value & "', '" & gridDetailObatKh.Rows(i).Cells("waktu").Value & "', '" & gridDetailObatKh.Rows(i).Cells("ketminum").Value & "','" & Trim(gridDetailObatKh.Rows(i).Cells("qty1").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("qty2").Value) & "',  '" & Format(gridDetailObatKh.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ",'1')"
                    ElseIf gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "2" Then
                        sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, jml_obat, urut, obat, tetes, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nmobat_etiket_infus").Value)) & "',  '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlobat_etiket_infus").Value) & "', " & i + 1 & ", '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("obat_infus").Value)) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("tetes_infus").Value)) & "','2')"
                    ElseIf gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "3" Then
                        sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, jml_obat, urut, kd_ketminum, tgl_exp, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value)) & "',  '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ", '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("ketminum").Value)) & "', '" & Format(gridDetailObatKh.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '3')"
                    ElseIf gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "4" Then
                        sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, urut, ket_waktu_pagi_model4, ket_waktu_siang_model4, ket_waktu_sore_model4, ket_waktu_malam_model4, ket_minum_model4, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value)) & "',  " & i + 1 & ", '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("ket_waktu_pagi_model4").Value)) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("ket_waktu_siang_model4").Value)) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("ket_waktu_sore_model4").Value)) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("ket_waktu_malam_model4").Value)) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("ket_minum_model4").Value)) & "', '4')"
                    End If

                Next

                'Else
                'For i = 0 To gridDetailObatKh.RowCount - 2
                '    If gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" Then
                '        sqlPenjualanObatKh = sqlPenjualanObatKh + vbCrLf + "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, signa1, signa2, tgl_exp, jml_obat, urut) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value)) & "', '" & gridDetailObatKh.Rows(i).Cells("takaran").Value & "', '" & gridDetailObatKh.Rows(i).Cells("waktu").Value & "', '" & gridDetailObatKh.Rows(i).Cells("ketminum").Value & "','" & Trim(gridDetailObatKh.Rows(i).Cells("qty1").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("qty2").Value) & "', '" & Format(gridDetailObatKh.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ")"
                '    End If
                'Next
                'End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Kasir
                sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "insert into resep_jual(no_nota, no_rm, no_reg, jenis_rawat, tgl_jual, waktu, kd_dokter, kd_sub_unit, status_bayar, kd_kelompok_pelanggan, metode_bayar, total, user_id, user_nama, waktu_in, waktu_out, kd_sub_unit_asal, total_bulat, total_non_paket, total_non_paket_bulat, total_tunai, total_tunai_bulat, total_piutang, total_piutang_bulat) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNoReg.Text) & "',  '" & StatusRawat & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss").ToString & "', '" & kdDokter & "', '" & pkdsubunit & "', 'BELUM', '0', 'KREDIT', '" & Num_En_US(txtGrandTotalPaket.DecimalValue) & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', '-', '" & kdSubUnit & "', '" & Num_En_US(txtGrandTotalPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalNonPaket.DecimalValue) & "', '" & Num_En_US(txtGrandTotalNonPaketBulat.DecimalValue) & "','0', '0', '" & Num_En_US(txtGrandTotalPaket.DecimalValue) & "', '" & Num_En_US(txtGrandTotalPaketBulat.DecimalValue) & "')"

                For i = 0 To gridDetailObatKh.RowCount - 2
                    If gridDetailObatKh.Rows(i).Cells("jmlp").Value > 0 Then
                        sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "INSERT INTO resep_jual_detail(no_nota, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, nr, urutan, kd_sub_unit_asal, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("idx_barang").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("hrgbeli").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlp").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalp").Value) & "', '0', '0', '0',  '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalp").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalp").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("racik").Value) & "', " & i + 1 & ", '" & kdSubUnit & "', '0', '0', '" & Trim(gridDetailObatKh.Rows(i).Cells("rek_p").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nama_barang").Value)) & "', '0')"
                    End If
                Next

                For i = 0 To gridDetailObatKh.RowCount - 2
                    If gridDetailObatKh.Rows(i).Cells("totaln").Value > 0 Then
                        sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "INSERT INTO resep_jual_detail(no_nota, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, nr, urutan, kd_sub_unit_asal, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("idx_barang").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("hrgbeli").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmln").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totaln").Value) & "', '0', '0', '0',  '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totaln").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totaln").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("racik").Value) & "', " & i + 1 & ", '" & kdSubUnit & "', '0', '0', '" & Trim(gridDetailObatKh.Rows(i).Cells("rek_p").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nama_barang").Value)) & "', '1')"
                    End If
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Update Stok
                If psts_stok = "1" Then
                    For i = 0 To gridDetailObatKh.RowCount - 2
                        sqlPenjualanObatKh = sqlPenjualanObatKh & vbCrLf & "UPDATE Barang_Farmasi SET " & memStok & "=(" & memStok & "-" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jml").Value) & ") WHERE kd_barang='" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "'"

                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CMD.CommandText = sqlPenjualanObatKh
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi penjualan berhasil tersimpan", vbInformation, "Informasi")
                btnSimpanKh.Enabled = False
                btnCetakBPJS.Enabled = True
                btnCetakLain.Enabled = True
                btnCetakEtiketKh.Enabled = True
                btnCetakBPJS.Focus()
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

    Private Sub txtQty1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub btnBaruKh_Click(sender As Object, e As EventArgs) Handles btnBaruKh.Click
        KosongkanHeader()
        KosongkanDetailPaketKhusus()
        NoResep()
        cmbPkt.SelectedIndex = 1
        txtNoResep.Focus()
    End Sub

    Private Sub btnCetakNota_Click(sender As Object, e As EventArgs) Handles btnCetakNota.Click
        FormPemanggil = "FormPenjualanResep_Nota"
        bilang = Terbilang(txtGrandTotalBulat.DecimalValue)
        cetakNota()
        btnCetakNota.Enabled = False
        btnCetakEtiket.Focus()
    End Sub

    Private Sub btnCetakBPJS_Click(sender As Object, e As EventArgs) Handles btnCetakBPJS.Click
        FormPemanggil = "FormPenjualanResep_BPJS"
        bilang = Terbilang(txtGrandTotalPaketBulat.DecimalValue)
        cetakNotaBPJS()
        btnCetakBPJS.Enabled = False
    End Sub

    Private Sub btnCetakLain_Click(sender As Object, e As EventArgs) Handles btnCetakLain.Click
        FormPemanggil = "FormPenjualanResep_Lain"
        bilang = Terbilang(txtGrandTotalNonPaketBulat.DecimalValue)
        cetakNotaLain()
        btnCetakLain.Enabled = False
    End Sub

    Private Sub btnCetakEtiket_Click(sender As Object, e As EventArgs) Handles btnCetakEtiket.Click
        If MessageBox.Show("Apakah akan cetak etiket ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            For i = 0 To gridDetailObat.RowCount - 2
                If gridDetailObat.Rows(i).Cells("model_etiket").Value = "1" And gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" Then
                    Dim dtReport As New DataTable
                    With dtReport
                        .Columns.Add("tanggal").DataType = GetType(Date)
                        .Columns.Add("no_rm")
                        .Columns.Add("nama_barang")
                        .Columns.Add("jml_obat").DataType = GetType(Integer)
                        .Columns.Add("signa1")
                        .Columns.Add("signa2")
                        If DTPTanggalTrans.Value = DTPTanggalExp.Value Then
                            .Columns.Add("tgl_exp")
                        Else
                            .Columns.Add("tgl_exp").DataType = GetType(Date)
                        End If
                        .Columns.Add("waktu")
                        .Columns.Add("ketminum")
                        .Columns.Add("takaran")
                    End With
                    dtReport.Rows.Add(gridDetailObat.Rows(i).Cells("tanggal").Value,
                                      gridDetailObat.Rows(i).Cells("no_rm").Value,
                                      gridDetailObat.Rows(i).Cells("nmobat_etiket").Value,
                                      gridDetailObat.Rows(i).Cells("jmlobat_etiket").Value,
                                      gridDetailObat.Rows(i).Cells("qty1").Value,
                                      gridDetailObat.Rows(i).Cells("qty2").Value,
                                      Replace(gridDetailObat.Rows(i).Cells("tgl_exp").Value, DTPTanggalTrans.Value, "-"),
                                      gridDetailObat.Rows(i).Cells("waktu_s").Value,
                                      gridDetailObat.Rows(i).Cells("ketminum_s").Value,
                                      gridDetailObat.Rows(i).Cells("takaran_s").Value)
                    'gridDetailObat.Rows(i).Cells("tgl_exp").Value,
                    Dim rpt As New ReportDocument
                    Dim str As String = Application.StartupPath & "\report\EtiketDT.rpt"
                    rpt.Load(str)
                    rpt.SetDataSource(dtReport)
                    rpt.SetParameterValue("nama", Trim(txtNamaPasien.Text))
                    rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                    rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
                    rpt.SetParameterValue("user", Trim(MenuUtama.PanelNama.Text))
                    rpt.PrintToPrinter(1, False, 0, 0)
                    rpt.Close()
                    rpt.Dispose()
                ElseIf gridDetailObat.Rows(i).Cells("model_etiket").Value = "2" And gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" Then
                    For a = 1 To gridDetailObat.Rows(i).Cells("jmlobat_etiket_infus").Value
                        Dim dtReport As New DataTable
                        With dtReport
                            .Columns.Add("tanggal").DataType = GetType(Date)
                            .Columns.Add("no_rm")
                            .Columns.Add("nama_barang")
                            .Columns.Add("obat")
                            .Columns.Add("tetes")
                        End With
                        dtReport.Rows.Add(gridDetailObat.Rows(i).Cells("tanggal").Value, gridDetailObat.Rows(i).Cells("no_rm").Value, gridDetailObat.Rows(i).Cells("nmobat_etiket_infus").Value, gridDetailObat.Rows(i).Cells("obat_infus").Value, gridDetailObat.Rows(i).Cells("tetes_infus").Value)

                        Dim rpt As New ReportDocument
                        Dim str As String = Application.StartupPath & "\report\EtiketDT2.rpt"
                        rpt.Load(str)
                        rpt.SetDataSource(dtReport)
                        rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                        rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                        rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
                        rpt.SetParameterValue("user", Trim(MenuUtama.PanelNama.Text))
                        rpt.SetParameterValue("ruang", Trim(nmSubUnit))
                        rpt.SetParameterValue("kamar", lblKamarBed.Text)
                        rpt.PrintToPrinter(1, False, 0, 0)
                        rpt.Close()
                        rpt.Dispose()
                    Next
                ElseIf gridDetailObat.Rows(i).Cells("model_etiket").Value = "3" And gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" Then
                    Dim dtReport As New DataTable
                    With dtReport
                        .Columns.Add("tanggal").DataType = GetType(Date)
                        .Columns.Add("no_rm")
                        .Columns.Add("nama_barang")
                        .Columns.Add("jml_obat").DataType = GetType(Integer)
                        If DTPTanggalTrans.Value = DTPTanggalExp.Value Then
                            .Columns.Add("tgl_exp")
                        Else
                            .Columns.Add("tgl_exp").DataType = GetType(Date)
                        End If
                        .Columns.Add("ketminum")
                    End With
                    dtReport.Rows.Add(gridDetailObat.Rows(i).Cells("tanggal").Value,
                                      gridDetailObat.Rows(i).Cells("no_rm").Value,
                                      gridDetailObat.Rows(i).Cells("nmobat_etiket").Value,
                                      gridDetailObat.Rows(i).Cells("jmlobat_etiket").Value,
                                      Replace(gridDetailObat.Rows(i).Cells("tgl_exp").Value, DTPTanggalTrans.Value, "-"),
                                      gridDetailObat.Rows(i).Cells("ketminum_s").Value)

                    Dim rpt As New ReportDocument
                    Dim str As String = Application.StartupPath & "\report\EtiketDT3.rpt"
                    rpt.Load(str)
                    rpt.SetDataSource(dtReport)
                    rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                    rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                    rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
                    rpt.SetParameterValue("user", Trim(MenuUtama.PanelNama.Text))
                    rpt.PrintToPrinter(1, False, 0, 0)
                    rpt.Close()
                    rpt.Dispose()
                End If
            Next

            For a = 0 To gridDetailObat.RowCount - 2
                If gridDetailObat.Rows(a).Cells("model_etiket").Value = "4" And gridDetailObat.Rows(a).Cells("stsetiket").Value = "Y" Then
                    Try
                        DA = New OleDb.OleDbDataAdapter("SELECT tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, qty1, qty2, tgl_exp, signa1, signa2, jml_obat, urut, model, obat, tetes, CASE ket_waktu_pagi_model4 WHEN '1' THEN '' ELSE 'Pagi' END AS ket_waktu_pagi_model4, CASE ket_waktu_siang_model4 WHEN '1' THEN '' ELSE 'Siang' END AS ket_waktu_siang_model4, CASE ket_waktu_sore_model4 WHEN '1' THEN '' ELSE 'Sore' END AS ket_waktu_sore_model4, CASE ket_waktu_malam_model4 WHEN '1' THEN '' ELSE 'Malam' END AS ket_waktu_malam_model4, CASE ket_minum_model4 WHEN '1' THEN 'Sebelum Makan' WHEN '2' THEN 'Bersama Makan' WHEN '3' THEN 'Sesudah Makan' ELSE 'Injeksi' END AS ket_minum_model4 FROM ap_etiketNew where notaresep='" & Trim(txtNoResep.Text) & "' and tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and model='4'", CONN)
                        DS = New DataSet
                        DA.Fill(DS, "cetakEtiket")
                        BDEtiket.DataSource = DS
                        BDEtiket.DataMember = "cetakEtiket"
                        BDEtiketModel4.DataSource = DSEtiketModel4
                        BDEtiketModel4.DataMember = "EtiketModel4"
                        If BDEtiket.Count > 0 Then
                            BDEtiket.MoveFirst()
                            For i = 1 To BDEtiket.Count
                                DRWEtiket = BDEtiket.Current
                                If DRWEtiket.Item("model") = "4" Then
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Injeksi" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_sore_model4") = "Sore" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_sore_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_sore_model4") = "Sore" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_sore_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_sore_model4") = "Sore" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_sore_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                    If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                                        BDEtiketModel4.AddNew()
                                        DRWEtiketModel4 = BDEtiketModel4.Current
                                        DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                        DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                                        DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                        BDEtiketModel4.EndEdit()
                                    End If
                                End If
                                BDEtiket.MoveNext()
                            Next
                        End If

                        If pkdapo = "002" Or pkdapo = "005" Then
                            gridEtiket.DataSource = Nothing
                            gridEtiket.DataSource = BDEtiketModel4
                            BDEtiketModel4.RemoveFilter()
                            ''''''''''' Kondisi 1 pagi, sebelum
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                FormKonfirmasiEtiketModel4.ShowDialog()
                                For i = 0 To jmlHariEtiketModel4 - 1
                                    BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Sebelum Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ''''''''''' Kondisi 2 pagi, bersama
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Bersama Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ''''''''''' Kondisi 3 pagi, sesudah
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Sesudah Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ' ''''''''''' Kondisi 4 pagi, Injeksi
                                    'BDEtiketModel4.RemoveFilter()
                                    'BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Injeksi'"
                                    'If (gridEtiket.Rows.Count() - 1) > 0 Then
                                    '    cetakEtiketModel4()
                                    'End If

                                    ''''''''''' Kondisi 5 siang, sebelum
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Siang' AND ketMinum='Sebelum Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ''''''''''' Kondisi 6 siang, bersama
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Siang' AND ketMinum='Bersama Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ''''''''''' Kondisi 7 siang, sesudah
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Siang' AND ketMinum='Sesudah Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ''''''''''' Kondisi 8 sore, sebelum
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Sore' AND ketMinum='Sebelum Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ''''''''''' Kondisi 9 sore, bersama
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Sore' AND ketMinum='Bersama Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ''''''''''' Kondisi 10 sore, sesudah
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Sore' AND ketMinum='Sesudah Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If
                                    ''''''''''' Kondisi 11 malam, sebelum
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Malam' AND ketMinum='Sebelum Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ''''''''''' Kondisi 12 malam, bersama
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Malam' AND ketMinum='Bersama Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If

                                    ''''''''''' Kondisi 13 malam, sesudah
                                    BDEtiketModel4.RemoveFilter()
                                    BDEtiketModel4.Filter = "waktuMinum='Malam' AND ketMinum='Sesudah Makan'"
                                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                                        cetakEtiketModel4()
                                    End If
                                Next
                                ''''''''''' Kondisi 4 pagi, Injeksi
                                BDEtiketModel4.RemoveFilter()
                                BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Injeksi'"
                                If (gridEtiket.Rows.Count() - 1) > 0 Then
                                    cetakEtiketModel4()
                                End If
                                BDEtiketModel4.RemoveFilter()
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    btnCetakEtiket.Enabled = False
                    Exit Sub
                End If
            Next
            btnCetakEtiket.Enabled = False
        End If
    End Sub

    Private Sub btnCetakEtiketKh_Click(sender As Object, e As EventArgs) Handles btnCetakEtiketKh.Click
        If MessageBox.Show("Apakah akan cetak etiket ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            For i = 0 To gridDetailObatKh.RowCount - 2
                If gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "1" And gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" Then
                    Dim dtReport As New DataTable
                    With dtReport
                        .Columns.Add("tanggal").DataType = GetType(Date)
                        .Columns.Add("no_rm")
                        .Columns.Add("nama_barang")
                        .Columns.Add("jml_obat").DataType = GetType(Integer)
                        .Columns.Add("signa1")
                        .Columns.Add("signa2")
                        .Columns.Add("tgl_exp").DataType = GetType(Date)
                        .Columns.Add("waktu")
                        .Columns.Add("ketminum")
                        .Columns.Add("takaran")
                    End With
                    dtReport.Rows.Add(gridDetailObatKh.Rows(i).Cells("tanggal").Value, gridDetailObatKh.Rows(i).Cells("no_rm").Value, gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value, gridDetailObatKh.Rows(i).Cells("jmlobat_etiket").Value, gridDetailObatKh.Rows(i).Cells("qty1").Value, gridDetailObatKh.Rows(i).Cells("qty2").Value, gridDetailObatKh.Rows(i).Cells("tgl_exp").Value, gridDetailObatKh.Rows(i).Cells("waktu_s").Value, gridDetailObatKh.Rows(i).Cells("ketminum_s").Value, gridDetailObatKh.Rows(i).Cells("takaran_s").Value)

                    Dim rpt As New ReportDocument
                    Dim str As String = Application.StartupPath & "\report\EtiketDT.rpt"
                    rpt.Load(str)
                    rpt.SetDataSource(dtReport)
                    rpt.SetParameterValue("nama", Trim(txtNamaPasien.Text))
                    rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                    rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
                    rpt.SetParameterValue("user", Trim(MenuUtama.PanelNama.Text))
                    rpt.PrintToPrinter(1, False, 0, 0)
                    rpt.Close()
                    rpt.Dispose()
                ElseIf gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "2" And gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" Then
                    For a = 1 To gridDetailObatKh.Rows(i).Cells("jmlobat_etiket_infus").Value
                        Dim dtReport As New DataTable
                        With dtReport
                            .Columns.Add("tanggal").DataType = GetType(Date)
                            .Columns.Add("no_rm")
                            .Columns.Add("nama_barang")
                            .Columns.Add("obat")
                            .Columns.Add("tetes")
                        End With
                        dtReport.Rows.Add(gridDetailObatKh.Rows(i).Cells("tanggal").Value, gridDetailObatKh.Rows(i).Cells("no_rm").Value, gridDetailObatKh.Rows(i).Cells("nmobat_etiket_infus").Value, gridDetailObatKh.Rows(i).Cells("obat_infus").Value, gridDetailObatKh.Rows(i).Cells("tetes_infus").Value)

                        Dim rpt As New ReportDocument
                        Dim str As String = Application.StartupPath & "\report\EtiketDT2.rpt"
                        rpt.Load(str)
                        rpt.SetDataSource(dtReport)
                        rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                        rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                        rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
                        rpt.SetParameterValue("user", Trim(MenuUtama.PanelNama.Text))
                        rpt.SetParameterValue("ruang", Trim(nmSubUnit))
                        rpt.SetParameterValue("kamar", lblKamarBed.Text)
                        rpt.PrintToPrinter(1, False, 0, 0)
                        rpt.Close()
                        rpt.Dispose()
                    Next
                ElseIf gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "3" And gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" Then
                    Dim dtReport As New DataTable
                    With dtReport
                        .Columns.Add("tanggal").DataType = GetType(Date)
                        .Columns.Add("no_rm")
                        .Columns.Add("nama_barang")
                        .Columns.Add("jml_obat").DataType = GetType(Integer)
                        .Columns.Add("tgl_exp").DataType = GetType(Date)
                        .Columns.Add("ketminum")
                    End With
                    dtReport.Rows.Add(gridDetailObatKh.Rows(i).Cells("tanggal").Value, gridDetailObatKh.Rows(i).Cells("no_rm").Value, gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value, gridDetailObatKh.Rows(i).Cells("jmlobat_etiket").Value, gridDetailObatKh.Rows(i).Cells("tgl_exp").Value, gridDetailObatKh.Rows(i).Cells("ketminum_s").Value)

                    Dim rpt As New ReportDocument
                    Dim str As String = Application.StartupPath & "\report\EtiketDT3.rpt"
                    rpt.Load(str)
                    rpt.SetDataSource(dtReport)
                    rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                    rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                    rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
                    rpt.SetParameterValue("user", Trim(MenuUtama.PanelNama.Text))
                    rpt.PrintToPrinter(1, False, 0, 0)
                    rpt.Close()
                    rpt.Dispose()
                End If
            Next
            btnCetakEtiketKh.Enabled = False
        End If
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If cmbJenisRawat.SelectedIndex = 0 Then
            If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim dtXls As DataTable = CType(DS.Tables("pasienRJ"), DataTable)
                    Dim excelEngine As New ExcelEngine
                    excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                    Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\DataKunjunganPasienRJXLSIO.xlsx")
                    Dim sheet As IWorksheet = workbook.Worksheets(0)
                    sheet.Range("B7").Text = DTPPasienReg.Text
                    Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                    marker.AddVariable("Data", dtXls)
                    marker.ApplyMarkers()
                    workbook.Version = ExcelVersion.Excel2007
                    workbook.SaveAs("Data Kunjungan Pasien Rawat Jalan.xlsx")
                    workbook.Close()
                    excelEngine.Dispose()
                    System.Diagnostics.Process.Start("Data Kunjungan Pasien Rawat Jalan.xlsx")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        ElseIf cmbJenisRawat.SelectedIndex = 1 Then
            If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim dtXls As DataTable = CType(DS.Tables("pasienRI"), DataTable)
                    Dim excelEngine As New ExcelEngine
                    excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                    Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\DataPasienRIDalamPerawatanXLSIO.xlsx")
                    Dim sheet As IWorksheet = workbook.Worksheets(0)
                    Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                    marker.AddVariable("Data", dtXls)
                    marker.ApplyMarkers()
                    workbook.Version = ExcelVersion.Excel2007
                    workbook.SaveAs("Data Pasien Rawat Inap Dalam Perawatan.xlsx")
                    workbook.Close()
                    excelEngine.Dispose()
                    System.Diagnostics.Process.Start("Data Pasien Rawat Inap Dalam Perawatan.xlsx")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        ElseIf cmbJenisRawat.SelectedIndex = 2 Then
            If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim dtXls As DataTable = CType(DS.Tables("pasienRD"), DataTable)
                    Dim excelEngine As New ExcelEngine
                    excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                    Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\DataKunjunganPasienRDXLSIO.xlsx")
                    Dim sheet As IWorksheet = workbook.Worksheets(0)
                    sheet.Range("B7").Text = DTPPasienReg.Text
                    Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                    marker.AddVariable("Data", dtXls)
                    marker.ApplyMarkers()
                    workbook.Version = ExcelVersion.Excel2007
                    workbook.SaveAs("Data Kunjungan Pasien Rawat Jalan.xlsx")
                    workbook.Close()
                    excelEngine.Dispose()
                    System.Diagnostics.Process.Start("Data Kunjungan Pasien Rawat Jalan.xlsx")
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If
    End Sub

    Private Sub txtNamaObatEtiket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamaObatEtiket.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJumlahObatEtiket.Focus()
        End If
    End Sub

    Private Sub txtSigna1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSigna1.KeyDown
        If e.KeyCode = Keys.Up Then
            txtJumlahObatEtiket.Focus()
        End If
    End Sub
    Private Sub txtSigna1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSigna1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtSigna2.Focus()
        End If
    End Sub

    Private Sub txtSigna2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSigna2.KeyDown
        If e.KeyCode = Keys.Up Then
            txtSigna1.Focus()
        End If
    End Sub

    Private Sub txtSigna2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSigna2.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbTakaran.Focus()
        End If
    End Sub

    Private Sub txtJumlahObatEtiket_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJumlahObatEtiket.KeyDown
        If e.KeyCode = Keys.Up Then
            txtNamaObatEtiket.Focus()
        End If
    End Sub

    Private Sub txtJumlahObatEtiket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahObatEtiket.KeyPress
        If e.KeyChar = Chr(13) Then
            txtSigna1.Focus()
        End If
    End Sub

    Private Sub txtJarakED_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJarakED.KeyDown
        If e.KeyCode = Keys.Up Then
            cmbKeterangan.Focus()
        End If
    End Sub

    Private Sub txtJarakED_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJarakED.KeyPress
        If e.KeyChar = Chr(13) Then
            PanelEtiket.Visible = False
            If nmPaket = "PKTUMUM" Then
                btnAdd.Focus()
            Else
                btnAddKh.Focus()
            End If
        End If
    End Sub

    Private Sub txtJarakED_TextChanged(sender As Object, e As EventArgs) Handles txtJarakED.TextChanged
        DTPTanggalExp.Value = DateAdd("d", Val(txtJarakED.DecimalValue), DTPTanggalTrans.Value)
    End Sub

    Private Sub txtJumlahObatEtiket_TextChanged(sender As Object, e As EventArgs) Handles txtJumlahObatEtiket.TextChanged

    End Sub

    Private Sub txtSigna1_TextChanged(sender As Object, e As EventArgs) Handles txtSigna1.TextChanged

    End Sub

    Private Sub txtSigna2_TextChanged(sender As Object, e As EventArgs) Handles txtSigna2.TextChanged

    End Sub

    Private Sub txtDosisResepKh_TextChanged(sender As Object, e As EventArgs) Handles txtDosisResepKh.TextChanged

    End Sub

    Private Sub txtJmlCapBPJSKh_TextChanged(sender As Object, e As EventArgs) Handles txtJmlCapBPJSKh.TextChanged

    End Sub

    Private Sub txtJmlCapLainKh_TextChanged(sender As Object, e As EventArgs) Handles txtJmlCapLainKh.TextChanged

    End Sub

    Private Sub txtJmlObatKh_TextChanged(sender As Object, e As EventArgs) Handles txtJmlObatKh.TextChanged

    End Sub

    Private Sub cmbWaktu_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbWaktu.SelectedIndexChanged

    End Sub

    Private Sub cmbTakaran_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTakaran.SelectedIndexChanged

    End Sub

    Private Sub cmbKeterangan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKeterangan.SelectedIndexChanged

    End Sub

    Private Sub cmbDokter_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDokter.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbPkt.Focus()
        End If
    End Sub

    Private Sub cmbDokter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDokter.SelectedIndexChanged

    End Sub

    Private Sub btnUpdateDijamin_Click(sender As Object, e As EventArgs) Handles btnUpdateDijamin.Click
        For i = 0 To gridDetailObat.RowCount - 2
            gridDetailObat.Rows(i).Cells("dijamin").Value = gridDetailObat.Rows(i).Cells("jmlnet").Value
            gridDetailObat.Rows(i).Cells("sisabayar").Value = 0
        Next
        cmbDijamin.Text = "Y"
        TotalHarga()
        TotalDijamin()
        TotalIurBayar()
    End Sub

    Private Sub btnUpdateIurPasien_Click(sender As Object, e As EventArgs) Handles btnUpdateIurPasien.Click
        For i = 0 To gridDetailObat.RowCount - 2
            gridDetailObat.Rows(i).Cells("dijamin").Value = 0
            gridDetailObat.Rows(i).Cells("sisabayar").Value = gridDetailObat.Rows(i).Cells("jmlnet").Value
        Next
        cmbDijamin.Text = "N"
        TotalHarga()
        TotalDijamin()
        TotalIurBayar()
    End Sub

    Private Sub btnModel2_Click(sender As Object, e As EventArgs) Handles btnModel2.Click
        PanelEtiket.Visible = False
        PanelEtiketInfus.Visible = True
        modelEtiket = "2"
        txtNamaObatEtiketInfus.Focus()
    End Sub

    Private Sub btnModel1_Click(sender As Object, e As EventArgs) Handles btnModel1.Click
        PanelEtiketInfus.Visible = False
        PanelEtiket.Visible = True
        modelEtiket = "1"
        txtNamaObatEtiket.Focus()
    End Sub

    Private Sub txtNamaObatEtiketInfus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNamaObatEtiketInfus.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJumlahObatEtiketInfus.Focus()
        End If
    End Sub

    Private Sub txtNamaObatEtiketInfus_TextChanged(sender As Object, e As EventArgs) Handles txtNamaObatEtiketInfus.TextChanged

    End Sub

    Private Sub txtJumlahObatEtiketInfus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJumlahObatEtiketInfus.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtObatInfus.Focus()
        End If
    End Sub

    Private Sub txtJumlahObatEtiketInfus_TextChanged(sender As Object, e As EventArgs) Handles txtJumlahObatEtiketInfus.TextChanged

    End Sub

    Private Sub txtObatInfus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtObatInfus.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTetesInfus.Focus()
        End If
    End Sub

    Private Sub txtObatInfus_TextChanged(sender As Object, e As EventArgs) Handles txtObatInfus.TextChanged

    End Sub

    Private Sub txtTetesInfus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTetesInfus.KeyDown
        If e.KeyCode = Keys.Enter Then
            PanelEtiketInfus.Visible = False
            If nmPaket = "PKTUMUM" Then
                btnAdd.Focus()
            Else
                btnAddKh.Focus()
            End If
        End If
    End Sub

    Private Sub DTPPasienReg_ValueChanged(sender As Object, e As EventArgs) Handles DTPPasienReg.ValueChanged
        If cmbJenisRawat.SelectedIndex = 0 Then
            tampilPasienRJ()
        ElseIf cmbJenisRawat.SelectedIndex = 1 Then
            tampilPasienRI()
        ElseIf cmbJenisRawat.SelectedIndex = 2 Then
            tampilPasienRD()
        End If
        'txtCariPasien.Focus()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        PanelEtiket.Visible = False
        PanelEtiketModel3.Visible = True
        modelEtiket = "3"
        txtNamaObatEtiketModel3.Focus()
    End Sub

    Private Sub txtNamaObatEtiket_TextChanged(sender As Object, e As EventArgs) Handles txtNamaObatEtiket.TextChanged

    End Sub

    Private Sub txtNamaObatEtiketModel3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamaObatEtiketModel3.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJumlahObatEtiketModel3.Focus()
        End If
    End Sub


    Private Sub cmbKeteranganModel3_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbKeteranganModel3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJarakEDModel3.Focus()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        PanelEtiketModel3.Visible = False
        PanelEtiket.Visible = True
        modelEtiket = "1"
        txtNamaObatEtiket.Focus()
    End Sub

    Private Sub txtNamaObatEtiketModel3_TextChanged(sender As Object, e As EventArgs) Handles txtNamaObatEtiketModel3.TextChanged, txtJarakEDModel3.TextChanged

    End Sub

    Private Sub txtJumlahObatEtiketModel3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahObatEtiketModel3.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbKeteranganModel3.Focus()
        End If
    End Sub

    Private Sub txtJarakEDModel3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJarakEDModel3.KeyDown
        If e.KeyCode = Keys.Enter Then
            PanelEtiketModel3.Visible = False
            If nmPaket = "PKTUMUM" Then
                btnAdd.Focus()
            Else
                btnAddKh.Focus()
            End If
        End If
    End Sub

    Private Sub txtJarakEDModel3_TextChanged(sender As Object, e As EventArgs)
        'DateAdd("d", 30, DTPTanggalTrans.Value)
        DTPTanggalExp.Value = DateAdd("d", Val(txtJarakED.DecimalValue), DTPTanggalTrans.Value)
    End Sub

    Private Sub cmbKeteranganModel3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKeteranganModel3.SelectedIndexChanged

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        PanelEtiket.Visible = False
        PanelEtiketModel4.Visible = True
        modelEtiket = "4"
        txtNamaObatEtiketModel4.Focus()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        PanelEtiketModel4.Visible = False
        PanelEtiket.Visible = True
        modelEtiket = "1"
        txtNamaObatEtiket.Focus()
    End Sub

    Private Sub rInjeksi_CheckedChanged(sender As Object, e As EventArgs) Handles rInjeksi.CheckedChanged
        If rInjeksi.Checked = True Then
            cbPagi.Checked = True
            cbSiang.Checked = False
            cbSore.Checked = False
            cbMalam.Checked = False
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        PanelEtiketModel4.Visible = False
        PanelEtiketInfus.Visible = True
        modelEtiket = "2"
        txtNamaObatEtiketInfus.Focus()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        PanelEtiketModel4.Visible = False
        PanelEtiketModel3.Visible = True
        modelEtiket = "3"
        txtNamaObatEtiketModel3.Focus()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles btnCetakDaftarEtiket.Click
        If txtQtyKh.DecimalValue = 0 Then
            MsgBox("Data barang belum ada", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If
        Try
            Dim dtReport As New DataTable
            With dtReport
                .Columns.Add("tanggal").DataType = GetType(Date)
                .Columns.Add("no_rm")
                .Columns.Add("nama_barang")
                .Columns.Add("jml_obat").DataType = GetType(Integer)
                .Columns.Add("signa1")
                .Columns.Add("signa2")
                .Columns.Add("tgl_exp").DataType = GetType(Date)
                .Columns.Add("waktu")
                .Columns.Add("ketminum")
                .Columns.Add("takaran")
            End With
            For i = 0 To gridDetailObatKh.RowCount - 2
                If gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "1" And gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" Then
                    dtReport.Rows.Add(gridDetailObatKh.Rows(i).Cells("tanggal").Value, gridDetailObatKh.Rows(i).Cells("no_rm").Value, gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value, gridDetailObatKh.Rows(i).Cells("jmlobat_etiket").Value, gridDetailObatKh.Rows(i).Cells("qty1").Value, gridDetailObatKh.Rows(i).Cells("qty2").Value, gridDetailObatKh.Rows(i).Cells("tgl_exp").Value, gridDetailObatKh.Rows(i).Cells("waktu_s").Value, gridDetailObatKh.Rows(i).Cells("ketminum_s").Value, gridDetailObatKh.Rows(i).Cells("takaran_s").Value)
                End If
            Next
            Dim rpt As New ReportDocument
            Dim str As String = Application.StartupPath & "\report\EtiketDaftarDT.rpt"
            rpt.Load(str)
            rpt.SetDataSource(dtReport)
            rpt.SetParameterValue("nama", Trim(txtNamaPasien.Text))
            rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
            rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
            rpt.SetParameterValue("user", Trim(MenuUtama.PanelNama.Text))
            rpt.PrintToPrinter(1, False, 0, 0)
            rpt.Close()
            rpt.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class

