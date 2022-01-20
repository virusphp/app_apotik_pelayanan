Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports Syncfusion.XlsIO

Public Class FormLaporanDetailPenjualanResepObat
    Inherits Office2010Form
    Dim kdBagian, nmBagian, kdPenjamin, nmPenjamin, JenisPasien, XopPenjamin, XopStatus, XopBagian, kdDokter, nmDokter, Stok, kdJenisObat, nmJenisObat, kdKelompokObat, nmKelompokObat, nmGolonganObat, kdGolonganObat, Kriteria, kdGenerik As String
    Dim BDLaporanDetailPenjualanResep, BDDataBarang As New BindingSource
    Dim DSLaporanDetailPenjualanResep As New DataSet
    Dim DRWLaporanDetailPenjualanResep As DataRowView

    Sub KosongkanHeader()
        TglServer()
        cmbPenjamin.Text = ""
        cmbBagian.Text = ""
        cmbJenisPasien.Text = ""
    End Sub

    Sub KosongkanPerTanggal()
        DTPTanggalAwalTab1.Value = TanggalServer
        DTPTanggalAkhirTab1.Value = TanggalServer
        GridObat.DataSource = Nothing
        GridObat.BackgroundColor = Color.Azure
        txtJumlahObat.DecimalValue = 0
        txtTotalPaket.DecimalValue = 0
        txtTotalNonPaket.DecimalValue = 0
        txtTotalDijamin.DecimalValue = 0
        txtTotalIurBayar.DecimalValue = 0
        txtJumlahHarga.DecimalValue = 0
        txtCariPasienTab1.Enabled = False
        txtCariPasienTab1.Clear()
        rNama.Checked = True
        If cmbPenjamin.Text = "BPJS" Then
            lblPilihanTab1.Visible = True
            cmbPilihanTab1.Visible = True
        Else
            lblPilihanTab1.Visible = False
            cmbPilihanTab1.Visible = False
        End If
        cmbPilihanTab1.Text = ""
        DTPTanggalAwalTab1.Focus()
    End Sub

    Sub KosongkanPerDokter()
        DTPTanggalAwalTab2.Value = TanggalServer
        DTPTanggalAkhirTab2.Value = TanggalServer
        GridObat.DataSource = Nothing
        GridObat.BackgroundColor = Color.Azure
        txtJumlahObat.DecimalValue = 0
        txtTotalPaket.DecimalValue = 0
        txtTotalNonPaket.DecimalValue = 0
        txtTotalDijamin.DecimalValue = 0
        txtTotalIurBayar.DecimalValue = 0
        txtJumlahHarga.DecimalValue = 0
        cmbDokterTab2.Text = ""
        If cmbPenjamin.Text = "BPJS" Then
            lblPilihanTab2.Visible = True
            cmbPilihanTab2.Visible = True
        Else
            lblPilihanTab2.Visible = False
            cmbPilihanTab2.Visible = False
        End If
        cmbPilihanTab2.Text = ""
        DTPTanggalAwalTab2.Focus()
    End Sub

    Sub KosongkanPerBarang()
        DTPTanggalAwalTab3.Value = TanggalServer
        DTPTanggalAkhirTab3.Value = TanggalServer
        GridObat.DataSource = Nothing
        GridObat.BackgroundColor = Color.Azure
        txtJumlahObat.DecimalValue = 0
        txtTotalPaket.DecimalValue = 0
        txtTotalNonPaket.DecimalValue = 0
        txtTotalDijamin.DecimalValue = 0
        txtTotalIurBayar.DecimalValue = 0
        txtJumlahHarga.DecimalValue = 0
        txtKodeObatTab3.Text = ""
        lblNamaObat.Text = ""
        If cmbPenjamin.Text = "BPJS" Then
            lblPilihanTab3.Visible = True
            cmbPilihanTab3.Visible = True
        Else
            lblPilihanTab3.Visible = False
            cmbPilihanTab3.Visible = False
        End If
        cmbPilihanTab3.Text = ""
        DTPTanggalAwalTab3.Focus()
    End Sub

    Sub KosongkanPerJenis()
        DTPTanggalAwalTab4.Value = TanggalServer
        DTPTanggalAkhirTab4.Value = TanggalServer
        GridObat.DataSource = Nothing
        GridObat.BackgroundColor = Color.Azure
        txtJumlahObat.DecimalValue = 0
        txtTotalPaket.DecimalValue = 0
        txtTotalNonPaket.DecimalValue = 0
        txtTotalDijamin.DecimalValue = 0
        txtTotalIurBayar.DecimalValue = 0
        txtJumlahHarga.DecimalValue = 0
        cmbJenisBarangTab4.Text = ""
        If cmbPenjamin.Text = "BPJS" Then
            lblPilihanTab4.Visible = True
            cmbPilihanTab4.Visible = True
        Else
            lblPilihanTab4.Visible = False
            cmbPilihanTab4.Visible = False
        End If
        cmbPilihanTab4.Text = ""
        DTPTanggalAwalTab4.Focus()
    End Sub

    Sub KosongkanPerKelompok()
        DTPTanggalAwalTab5.Value = TanggalServer
        DTPTanggalAkhirTab5.Value = TanggalServer
        GridObat.DataSource = Nothing
        GridObat.BackgroundColor = Color.Azure
        txtJumlahObat.DecimalValue = 0
        txtTotalPaket.DecimalValue = 0
        txtTotalNonPaket.DecimalValue = 0
        txtTotalDijamin.DecimalValue = 0
        txtTotalIurBayar.DecimalValue = 0
        txtJumlahHarga.DecimalValue = 0
        cmbKelompokObatTab5.Text = ""
        If cmbPenjamin.Text = "BPJS" Then
            lblPilihanTab5.Visible = True
            cmbPilihanTab5.Visible = True
        Else
            lblPilihanTab5.Visible = False
            cmbPilihanTab5.Visible = False
        End If
        cmbPilihanTab5.Text = ""
        DTPTanggalAwalTab5.Focus()
    End Sub

    Sub KosongkanPerGolongan()
        DTPTanggalAwalTab6.Value = TanggalServer
        DTPTanggalAkhirTab6.Value = TanggalServer
        GridObat.DataSource = Nothing
        GridObat.BackgroundColor = Color.Azure
        txtJumlahObat.DecimalValue = 0
        txtTotalPaket.DecimalValue = 0
        txtTotalNonPaket.DecimalValue = 0
        txtTotalDijamin.DecimalValue = 0
        txtTotalIurBayar.DecimalValue = 0
        txtJumlahHarga.DecimalValue = 0
        cmbGolonganObatTab6.Text = ""
        If cmbPenjamin.Text = "BPJS" Then
            lblPilihanTab6.Visible = True
            cmbPilihanTab6.Visible = True
        Else
            lblPilihanTab6.Visible = False
            cmbPilihanTab6.Visible = False
        End If
        cmbPilihanTab6.Text = ""
        DTPTanggalAwalTab6.Focus()
    End Sub

    Sub KosongkanPerGenerik()
        DTPTanggalAwalTab7.Value = TanggalServer
        DTPTanggalAkhirTab7.Value = TanggalServer
        GridObat.DataSource = Nothing
        GridObat.BackgroundColor = Color.Azure
        txtJumlahObat.DecimalValue = 0
        txtTotalPaket.DecimalValue = 0
        txtTotalNonPaket.DecimalValue = 0
        txtTotalDijamin.DecimalValue = 0
        txtTotalIurBayar.DecimalValue = 0
        txtJumlahHarga.DecimalValue = 0
        cmbGenerik.Text = ""
        DTPTanggalAwalTab7.Focus()
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
        cmbPenjamin.Items.Add("BPJS")
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

    Sub ListDokter()
        'konek()
        CMD = New OleDb.OleDbCommand("select kd_pegawai,nama_pegawai,gelar_depan from pegawai where kd_jns_pegawai=1 order by nama_pegawai", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbDokterTab2.Items.Clear()
        cmbDokterTab2.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbDokterTab2.Items.Add(DT.Rows(i)("nama_pegawai") & "|" & DT.Rows(i)("kd_pegawai"))
        Next
        cmbDokterTab2.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbDokterTab2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListJenisObat()
        'konek()
        CMD = New OleDb.OleDbCommand("select jns_obat, kd_jns_obat from Jenis_Obat where stsaktif='1' order by kd_jns_obat", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbJenisBarangTab4.Items.Clear()
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbJenisBarangTab4.Items.Add(DT.Rows(i)("jns_obat") & "|" & DT.Rows(i)("kd_jns_obat"))
        Next
        cmbJenisBarangTab4.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbJenisBarangTab4.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListKelompokObat()
        'konek()
        CMD = New OleDb.OleDbCommand("select kel_obat, kd_kel_obat from Kelompok_Obat order by kd_kel_obat", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbKelompokObatTab5.Items.Clear()
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbKelompokObatTab5.Items.Add(DT.Rows(i)("kel_obat") & "|" & DT.Rows(i)("kd_kel_obat"))
        Next
        cmbKelompokObatTab5.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKelompokObatTab5.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListGolonganObat()
        'konek()
        CMD = New OleDb.OleDbCommand("select gol_obat, kd_gol_obat from Golongan_Obat order by kd_gol_obat", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbGolonganObatTab6.Items.Clear()
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbGolonganObatTab6.Items.Add(DT.Rows(i)("gol_obat") & "|" & DT.Rows(i)("kd_gol_obat"))
        Next
        cmbGolonganObatTab6.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbGolonganObatTab6.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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

    Sub cariDokter()
        Dim cari As String = InStr(cmbDokterTab2.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbDokterTab2.Text, "|", -1, CompareMethod.Binary)
            kdDokter = Trim((ary(1)))
            nmDokter = Trim((ary(0)))
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

    Sub cariJenisObat()
        Dim cari As String = InStr(cmbJenisBarangTab4.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbJenisBarangTab4.Text, "|", -1, CompareMethod.Binary)
            kdJenisObat = Trim((ary(1)))
            nmJenisObat = Trim((ary(0)))
        End If
    End Sub

    Sub cariKelompokObat()
        Dim cari As String = InStr(cmbKelompokObatTab5.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbKelompokObatTab5.Text, "|", -1, CompareMethod.Binary)
            kdKelompokObat = Trim((ary(1)))
            nmKelompokObat = Trim((ary(0)))
        End If
    End Sub

    Sub cariGolonganObat()
        Dim cari As String = InStr(cmbGolonganObatTab6.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbGolonganObatTab6.Text, "|", -1, CompareMethod.Binary)
            kdGolonganObat = Trim((ary(1)))
            nmGolonganObat = Trim((ary(0)))
        End If
    End Sub

    Sub TotalObat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("jml").Value
        Next
        txtJumlahObat.DecimalValue = HitungTotal
    End Sub

    Sub TotalPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalpaket").Value
        Next
        txtTotalPaket.DecimalValue = HitungTotal
    End Sub

    Sub TotalNonPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalnonpaket").Value
        Next
        txtTotalNonPaket.DecimalValue = HitungTotal
    End Sub

    Sub TotalJumlahHarga()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("jmlnet").Value
        Next
        txtJumlahHarga.DecimalValue = HitungTotal
    End Sub

    Sub TotalDijamin()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("dijamin").Value
        Next
        txtTotalDijamin.DecimalValue = HitungTotal
    End Sub

    Sub TotalIurBayar()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("sisabayar").Value
        Next
        txtTotalIurBayar.DecimalValue = HitungTotal
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
            konek()
            DA = New OleDb.OleDbDataAdapter("select idx_barang,kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from barang_farmasi WHERE stsaktif ='1' order by kd_barang", CONN)
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

    Sub tampilPerTanggal()
        cariBagian()
        cariJenisPasien()
        If cmbPenjamin.Text <> "BPJS" Then
            If cmbPenjamin.Text = "Semua" Then
                XopPenjamin = "<>"
            Else
                XopPenjamin = "="
            End If
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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
                konek()
                DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" + kdBagian & "' and ap_jualr2.kd_penjamin" + XopPenjamin + "'" & kdPenjamin & "' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                DSLaporanDetailPenjualanResep = New DataSet
                DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                GridObat.DataSource = Nothing
                GridObat.DataSource = BDLaporanDetailPenjualanResep
                aturGrid()
                TotalObat()
                TotalPaket()
                TotalNonPaket()
                TotalJumlahHarga()
                TotalDijamin()
                TotalIurBayar()
                txtCariPasienTab1.Enabled = True
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Proses perhitungan gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
            End Try
        Else
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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

            If cmbPilihanTab1.Text = "Semua" Then
                Try
                    'konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    txtCariPasienTab1.Enabled = True
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab1.Text = "Dijamin" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.dijamin>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    txtCariPasienTab1.Enabled = True
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab1.Text = "Iur Pasien" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.sisabayar>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    txtCariPasienTab1.Enabled = True
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If
        End If

    End Sub

    Sub tampilPerDokter()
        cariBagian()
        cariJenisPasien()
        cariDokter()
        If cmbPenjamin.Text <> "BPJS" Then
            If cmbPenjamin.Text = "Semua" Then
                XopPenjamin = "<>"
            Else
                XopPenjamin = "="
            End If
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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
                konek()
                DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and ap_jualr2.kd_penjamin" + XopPenjamin + "'" & kdPenjamin & "' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab2.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab2.Value, "yyyy/MM/dd") & "' AND ap_jualr2.kddokter='" & kdDokter & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                DSLaporanDetailPenjualanResep = New DataSet
                DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                GridObat.DataSource = Nothing
                GridObat.DataSource = BDLaporanDetailPenjualanResep
                aturGrid()
                TotalObat()
                TotalPaket()
                TotalNonPaket()
                TotalJumlahHarga()
                TotalDijamin()
                TotalIurBayar()
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Proses perhitungan gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
            End Try
        Else
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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

            If cmbPilihanTab2.Text = "Semua" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab2.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab2.Value, "yyyy/MM/dd") & "' AND ap_jualr2.kddokter='" & kdDokter & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab2.Text = "Dijamin" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.dijamin>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab2.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab2.Value, "yyyy/MM/dd") & "' AND ap_jualr2.kddokter='" & kdDokter & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab2.Text = "Iur Pasien" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.sisabayar>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab2.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab2.Value, "yyyy/MM/dd") & "' AND ap_jualr2.kddokter='" & kdDokter & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If
        End If

    End Sub

    Sub tampilPerBarang()
        cariBagian()
        cariJenisPasien()
        If cmbPenjamin.Text <> "BPJS" Then
            If cmbPenjamin.Text = "Semua" Then
                XopPenjamin = "<>"
            Else
                XopPenjamin = "="
            End If
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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
                konek()
                DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and ap_jualr2.kd_penjamin" + XopPenjamin + "'" & kdPenjamin & "' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr2.kd_barang='" & Trim(txtKodeObatTab3.Text) & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                DSLaporanDetailPenjualanResep = New DataSet
                DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                GridObat.DataSource = Nothing
                GridObat.DataSource = BDLaporanDetailPenjualanResep
                aturGrid()
                TotalObat()
                TotalPaket()
                TotalNonPaket()
                TotalJumlahHarga()
                TotalDijamin()
                TotalIurBayar()
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Proses perhitungan gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
            End Try
        Else
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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

            If cmbPilihanTab3.Text = "Semua" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr2.kd_barang='" & Trim(txtKodeObatTab3.Text) & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab3.Text = "Dijamin" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.dijamin>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr2.kd_barang='" & Trim(txtKodeObatTab3.Text) & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab3.Text = "Iur Pasien" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, RTRIM(LTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.sisabayar>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr2.kd_barang='" & Trim(txtKodeObatTab3.Text) & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If
        End If

    End Sub

    Sub tampilPerJenisObat()
        cariBagian()
        cariJenisPasien()
        cariJenisObat()
        If cmbPenjamin.Text <> "BPJS" Then
            If cmbPenjamin.Text = "Semua" Then
                XopPenjamin = "<>"
            Else
                XopPenjamin = "="
            End If
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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
                konek()
                DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg WHERE (ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "') AND (ap_jualr2.kd_penjamin" + XopPenjamin + "'" & kdPenjamin & "') AND (ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "') AND (ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab4.Value, "yyyy/MM/dd") & "') AND (ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab4.Value, "yyyy/MM/dd") & "') AND (Barang_Farmasi.kd_jns_obat = '" & kdJenisObat & "') ORDER BY ap_jualr2.tanggal, ap_jualr2.notaresep", CONN)
                DSLaporanDetailPenjualanResep = New DataSet
                DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                GridObat.DataSource = Nothing
                GridObat.DataSource = BDLaporanDetailPenjualanResep
                aturGrid()
                TotalObat()
                TotalPaket()
                TotalNonPaket()
                TotalJumlahHarga()
                TotalDijamin()
                TotalIurBayar()
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Proses perhitungan gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
            End Try
        Else
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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

            If cmbPilihanTab4.Text = "Semua" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab4.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab4.Value, "yyyy/MM/dd") & "' AND Barang_Farmasi.kd_jns_obat = '" & kdJenisObat & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab4.Text = "Dijamin" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.dijamin>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab4.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab4.Value, "yyyy/MM/dd") & "' AND Barang_Farmasi.kd_jns_obat = '" & kdJenisObat & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab4.Text = "Iur Pasien" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.sisabayar>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab4.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab4.Value, "yyyy/MM/dd") & "' AND Barang_Farmasi.kd_jns_obat = '" & kdJenisObat & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If
        End If

    End Sub

    Sub tampilPerKelompokObat()
        cariBagian()
        cariJenisPasien()
        cariKelompokObat()
        If cmbPenjamin.Text <> "BPJS" Then
            If cmbPenjamin.Text = "Semua" Then
                XopPenjamin = "<>"
            Else
                XopPenjamin = "="
            End If
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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
                konek()
                DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg WHERE (ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "') AND (ap_jualr2.kd_penjamin" + XopPenjamin + "'" & kdPenjamin & "') AND (ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "') AND (ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab5.Value, "yyyy/MM/dd") & "') AND (ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab5.Value, "yyyy/MM/dd") & "') AND (Barang_Farmasi.kd_kel_obat = '" & kdKelompokObat & "') ORDER BY ap_jualr2.tanggal, ap_jualr2.notaresep", CONN)
                DSLaporanDetailPenjualanResep = New DataSet
                DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                GridObat.DataSource = Nothing
                GridObat.DataSource = BDLaporanDetailPenjualanResep
                aturGrid()
                TotalObat()
                TotalPaket()
                TotalNonPaket()
                TotalJumlahHarga()
                TotalDijamin()
                TotalIurBayar()
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Proses perhitungan gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
            End Try
        Else
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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

            If cmbPilihanTab5.Text = "Semua" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab5.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab5.Value, "yyyy/MM/dd") & "' AND Barang_Farmasi.kd_kel_obat = '" & kdKelompokObat & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab5.Text = "Dijamin" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.dijamin>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab5.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab5.Value, "yyyy/MM/dd") & "' AND Barang_Farmasi.kd_kel_obat = '" & kdKelompokObat & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab5.Text = "Iur Pasien" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.sisabayar>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab5.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab5.Value, "yyyy/MM/dd") & "' AND Barang_Farmasi.kd_kel_obat = '" & kdKelompokObat & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If
        End If

    End Sub

    Sub tampilPerGolonganObat()
        cariBagian()
        cariJenisPasien()
        cariGolonganObat()
        If cmbPenjamin.Text <> "BPJS" Then
            If cmbPenjamin.Text = "Semua" Then
                XopPenjamin = "<>"
            Else
                XopPenjamin = "="
            End If
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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
                konek()
                DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg WHERE (ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "') AND (ap_jualr2.kd_penjamin" + XopPenjamin + "'" & kdPenjamin & "') AND (ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "') AND (ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab6.Value, "yyyy/MM/dd") & "') AND (ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab6.Value, "yyyy/MM/dd") & "') AND (Barang_Farmasi.kd_gol_obat = '" & kdGolonganObat & "') ORDER BY ap_jualr2.tanggal, ap_jualr2.notaresep", CONN)
                DSLaporanDetailPenjualanResep = New DataSet
                DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                GridObat.DataSource = Nothing
                GridObat.DataSource = BDLaporanDetailPenjualanResep
                aturGrid()
                TotalObat()
                TotalPaket()
                TotalNonPaket()
                TotalJumlahHarga()
                TotalDijamin()
                TotalIurBayar()
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Proses perhitungan gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
            End Try
        Else
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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

            If cmbPilihanTab6.Text = "Semua" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab6.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab6.Value, "yyyy/MM/dd") & "' AND Barang_Farmasi.kd_gol_obat = '" & kdGolonganObat & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab6.Text = "Dijamin" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.dijamin>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab6.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab6.Value, "yyyy/MM/dd") & "' AND Barang_Farmasi.kd_gol_obat = '" & kdGolonganObat & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab6.Text = "Iur Pasien" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.sisabayar>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab6.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab6.Value, "yyyy/MM/dd") & "' AND Barang_Farmasi.kd_gol_obat = '" & kdGolonganObat & "' ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If
        End If

    End Sub

    Sub tampilPerGolonganGenerik()
        cariBagian()
        cariJenisPasien()
        cariGolonganObat()
        If cmbGenerik.Text = "Generik" Then
            kdGenerik = "G"
        ElseIf cmbGenerik.Text = "Non Generik" Then
            kdGenerik = "N"
        End If
        If cmbPenjamin.Text <> "BPJS" Then
            If cmbPenjamin.Text = "Semua" Then
                XopPenjamin = "<>"
            Else
                XopPenjamin = "="
            End If
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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
                konek()
                DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg WHERE (ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "') AND (ap_jualr2.kd_penjamin" + XopPenjamin + "'" & kdPenjamin & "') AND (ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "') AND (ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab7.Value, "yyyy/MM/dd") & "') AND (ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab7.Value, "yyyy/MM/dd") & "') AND (Barang_Farmasi.generik = '" & kdGenerik & "') ORDER BY ap_jualr2.tanggal, ap_jualr2.notaresep", CONN)
                DSLaporanDetailPenjualanResep = New DataSet
                DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                GridObat.DataSource = Nothing
                GridObat.DataSource = BDLaporanDetailPenjualanResep
                aturGrid()
                TotalObat()
                TotalPaket()
                TotalNonPaket()
                TotalJumlahHarga()
                TotalDijamin()
                TotalIurBayar()
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Proses perhitungan gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
            End Try
        Else
            If cmbBagian.Text = "Semua" Then
                XopBagian = "<>"
            Else
                XopBagian = "="
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

            If cmbPilihanTab6.Text = "Semua" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab7.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab7.Value, "yyyy/MM/dd") & "' AND (Barang_Farmasi.generik = '" & kdGenerik & "') ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab6.Text = "Dijamin" Then
                Try
                    'konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.dijamin>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab7.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab7.Value, "yyyy/MM/dd") & "' AND (Barang_Farmasi.generik = '" & kdGenerik & "') ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If

            If cmbPilihanTab6.Text = "Iur Pasien" Then
                Try
                    konek()
                    DA = New OleDb.OleDbDataAdapter("SELECT ap_jualr2.kdbagian, ap_jualr2.stsrawat, RTRIM(LTRIM(ap_jualr2.nmkasir)) AS nmkasir, RTRIM(LTRIM(ap_jualr2.stsresep)) AS stsresep, ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.no_reg, ap_jualr2.no_rm, RTRIM(LTRIM(ap_jualr2.nmpasien)) AS nmpasien, LTRIM(RTRIM(ap_jualr2.nmdokter)) AS nmdokter, RTRIM(LTRIM(ap_jualr2.nm_penjamin)) AS nm_penjamin, ap_jualr2.kd_barang, RTRIM(LTRIM(ap_jualr2.nama_barang)) AS nama_barang, ap_jualr2.racik, ap_jualr2.harga, ap_jualr2.jmlpaket, ap_jualr2.totalpaket, ap_jualr2.jmlnonpaket, ap_jualr2.totalnonpaket, ap_jualr2.jml, RTRIM(LTRIM(ap_jualr2.nmsatuan)) AS nmsatuan, ap_jualr2.jmlnet, ap_jualr2.dijamin, ap_jualr2.sisabayar, ap_jualr2.hrgbeli, ap_jualr2.idx_barang, Sub_Unit.nama_sub_unit FROM Tempat_Tidur INNER JOIN Rawat_Inap ON Tempat_Tidur.kd_tempat_tidur = Rawat_Inap.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit RIGHT OUTER JOIN ap_jualr2 INNER JOIN Barang_Farmasi ON ap_jualr2.idx_barang = Barang_Farmasi.idx_barang ON Rawat_Inap.no_reg = ap_jualr2.no_reg where ap_jualr2.kdbagian" + XopBagian + "'" & kdBagian & "' and (ap_jualr2.kd_penjamin='23' or ap_jualr2.kd_penjamin='24') and ap_jualr2.sisabayar>'0' and ap_jualr2.stsrawat" + XopStatus + "'" & JenisPasien & "' and ap_jualr2.tanggal >= '" & Format(DTPTanggalAwalTab7.Value, "yyyy/MM/dd") & "' AND ap_jualr2.tanggal <= '" & Format(DTPTanggalAkhirTab7.Value, "yyyy/MM/dd") & "' AND (Barang_Farmasi.generik = '" & kdGenerik & "') ORDER BY ap_jualr2.tanggal,ap_jualr2.notaresep", CONN)
                    DSLaporanDetailPenjualanResep = New DataSet
                    DA.Fill(DSLaporanDetailPenjualanResep, "LaporanDetailPenjualanResep")
                    BDLaporanDetailPenjualanResep.DataSource = DSLaporanDetailPenjualanResep
                    BDLaporanDetailPenjualanResep.DataMember = "LaporanDetailPenjualanResep"
                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanDetailPenjualanResep
                    aturGrid()
                    TotalObat()
                    TotalPaket()
                    TotalNonPaket()
                    TotalJumlahHarga()
                    TotalDijamin()
                    TotalIurBayar()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                Catch ex As Exception
                    MsgBox(ex.Message)
                    MsgBox("Proses gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
                End Try
            End If
        End If

    End Sub

    Sub aturGrid()
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
            .Columns(11).HeaderText = "Kode Barang"
            .Columns(12).HeaderText = "Nama Barang"
            .Columns(13).HeaderText = "R/N"
            .Columns(14).HeaderText = "Harga Jual"
            .Columns(14).DefaultCellStyle.Format = "N2"
            .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(15).HeaderText = "Jumlah Paket"
            .Columns(15).DefaultCellStyle.Format = "N2"
            .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(16).HeaderText = "Jumlah Harga Paket"
            .Columns(16).DefaultCellStyle.Format = "N2"
            .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(17).HeaderText = "Jumlah Non Paket"
            .Columns(17).DefaultCellStyle.Format = "N2"
            .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(18).HeaderText = "Jumlah Harga Non Paket"
            .Columns(18).DefaultCellStyle.Format = "N2"
            .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(19).HeaderText = "Jumlah Obat"
            .Columns(19).DefaultCellStyle.Format = "N2"
            .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(20).HeaderText = "Satuan"
            .Columns(21).HeaderText = "Jumlah Harga Obat"
            .Columns(21).DefaultCellStyle.Format = "N2"
            .Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(22).HeaderText = "Dijamin"
            .Columns(22).DefaultCellStyle.Format = "N2"
            .Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(23).HeaderText = "Iur Pasien"
            .Columns(23).DefaultCellStyle.Format = "N2"
            .Columns(23).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(24).HeaderText = "HPP + PPN"
            .Columns(24).DefaultCellStyle.Format = "N2"
            .Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(26).HeaderText = "Ruang Inap"
            .Columns(0).Width = 40
            .Columns(1).Width = 40
            .Columns(2).Width = 120
            .Columns(3).Width = 75
            .Columns(4).Width = 75
            .Columns(5).Width = 95
            .Columns(6).Width = 95
            .Columns(7).Width = 60
            .Columns(8).Width = 150
            .Columns(9).Width = 150
            .Columns(10).Width = 150
            .Columns(11).Width = 90
            .Columns(12).Width = 150
            .Columns(13).Width = 40
            .Columns(14).Width = 75
            .Columns(15).Width = 60
            .Columns(16).Width = 75
            .Columns(17).Width = 75
            .Columns(18).Width = 75
            .Columns(19).Width = 75
            .Columns(20).Width = 75
            .Columns(21).Width = 75
            .Columns(22).Width = 75
            .Columns(23).Width = 75
            .Columns(24).Width = 75
            .Columns(25).Visible = False
            .Columns(26).Width = 150
            .BackgroundColor = Color.Azure
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            .RowHeadersDefaultCellStyle.BackColor = Color.Black
            .ReadOnly = True
        End With
    End Sub

    Sub EksportExcel()
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtXls As DataTable = CType(DSLaporanDetailPenjualanResep.Tables("LaporanDetailPenjualanResep"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanDetailPenjualanResepXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                If cmbPenjamin.Text = "Semua" Then
                    sheet.Range("B7").Text = "Semua"
                ElseIf cmbPenjamin.Text = "UMUM" Then
                    sheet.Range("B7").Text = "UMUM"
                ElseIf cmbPenjamin.Text = "BPJS" Then
                    sheet.Range("B7").Text = "BPJS"
                Else
                    sheet.Range("B7").Text = nmPenjamin
                End If
                sheet.Range("B8").Text = nmBagian
                sheet.Range("B9").Text = cmbJenisPasien.Text
                If Kriteria = "Per Tanggal" Then
                    sheet.Range("E7").Text = DTPTanggalAwalTab1.Text
                    sheet.Range("E8").Text = DTPTanggalAkhirTab1.Text
                ElseIf Kriteria = "Per Dokter" Then
                    sheet.Range("E7").Text = DTPTanggalAwalTab2.Text
                    sheet.Range("E8").Text = DTPTanggalAkhirTab2.Text
                ElseIf Kriteria = "Per Barang" Then
                    sheet.Range("E7").Text = DTPTanggalAwalTab3.Text
                    sheet.Range("E8").Text = DTPTanggalAkhirTab3.Text
                ElseIf Kriteria = "Per Jenis" Then
                    sheet.Range("E7").Text = DTPTanggalAwalTab4.Text
                    sheet.Range("E8").Text = DTPTanggalAkhirTab4.Text
                ElseIf Kriteria = "Per Kelompok" Then
                    sheet.Range("E7").Text = DTPTanggalAwalTab5.Text
                    sheet.Range("E8").Text = DTPTanggalAkhirTab5.Text
                Else
                    sheet.Range("E7").Text = DTPTanggalAwalTab6.Text
                    sheet.Range("E8").Text = DTPTanggalAkhirTab6.Text
                End If
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Detail Penjualan Resep.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Detail Penjualan Resep.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FormLaporanDetailPenjualanResepObat_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormLaporanDetailPenjualanResepObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        KosongkanHeader()
        KosongkanPerTanggal()
        ListBagian()
        ListPenjamin()
        ListJenisPasien()
        ListDokter()
        ListJenisObat()
        ListKelompokObat()
        ListGolonganObat()
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs)
        If rNama.Checked = True Then
            BDLaporanDetailPenjualanResep.Filter = "nama_pasien like '%" & txtCariPasienTab1.Text & "%'"
        Else
            BDLaporanDetailPenjualanResep.Filter = "no_rm like '%" & txtCariPasienTab1.Text & "%'"
        End If
    End Sub

    Private Sub TabControlAdv1_SelectedIndexChanging(sender As Object, args As SelectedIndexChangingEventArgs) Handles TabControlAdv1.SelectedIndexChanging
        If TabControlAdv1.SelectedIndex = 0 Then
            KosongkanPerTanggal()
        ElseIf TabControlAdv1.SelectedIndex = 1 Then
            KosongkanPerDokter()
        ElseIf TabControlAdv1.SelectedIndex = 2 Then
            KosongkanPerBarang()
        ElseIf TabControlAdv1.SelectedIndex = 3 Then
            KosongkanPerJenis()
        ElseIf TabControlAdv1.SelectedIndex = 4 Then
            KosongkanPerKelompok()
        ElseIf TabControlAdv1.SelectedIndex = 5 Then
            KosongkanPerGolongan()
        End If
    End Sub

    Private Sub cmbPenjamin_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbPenjamin.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbBagian.Focus()
        End If
    End Sub

    Private Sub cmbPenjamin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPenjamin.SelectedIndexChanged
        If cmbPenjamin.Text = "BPJS" Then
            lblPilihanTab1.Visible = True
            cmbPilihanTab1.Visible = True
            lblPilihanTab2.Visible = True
            cmbPilihanTab2.Visible = True
            lblPilihanTab3.Visible = True
            cmbPilihanTab3.Visible = True
            lblPilihanTab4.Visible = True
            cmbPilihanTab4.Visible = True
            lblPilihanTab5.Visible = True
            cmbPilihanTab5.Visible = True
            lblPilihanTab6.Visible = True
            cmbPilihanTab6.Visible = True
        Else
            lblPilihanTab1.Visible = False
            cmbPilihanTab1.Visible = False
            lblPilihanTab2.Visible = False
            cmbPilihanTab2.Visible = False
            lblPilihanTab3.Visible = False
            cmbPilihanTab3.Visible = False
            lblPilihanTab4.Visible = False
            cmbPilihanTab4.Visible = False
            lblPilihanTab5.Visible = False
            cmbPilihanTab5.Visible = False
            lblPilihanTab6.Visible = False
            cmbPilihanTab6.Visible = False
        End If
    End Sub

    Private Sub btnProsesTab1_Click(sender As Object, e As EventArgs) Handles btnProsesTab1.Click
        If cmbPenjamin.Text = "" Or cmbBagian.Text = "" Or cmbJenisPasien.Text = "" Then
            MsgBox("Ada yang belum dipilih, silahkan cek lagi", vbInformation, "Informasi")
            Exit Sub
        End If
        If cmbPenjamin.Text = "BPJS" Then
            If cmbPilihanTab1.Text = "" Then
                MsgBox("Pilihan belum dipilih", vbInformation, "Informasi")
                Exit Sub
            End If
        End If
        Kriteria = "Per Tanggal"
        tampilPerTanggal()
    End Sub

    Private Sub btnProsesTab2_Click(sender As Object, e As EventArgs) Handles btnProsesTab2.Click
        If cmbPenjamin.Text = "" Or cmbBagian.Text = "" Or cmbJenisPasien.Text = "" Or cmbDokterTab2.Text = "" Then
            MsgBox("Ada yang belum dipilih, silahkan cek lagi", vbInformation, "Informasi")
            Exit Sub
        End If
        If cmbPenjamin.Text = "BPJS" Then
            If cmbPilihanTab2.Text = "" Then
                MsgBox("Pilihan belum dipilih", vbInformation, "Informasi")
                Exit Sub
            End If
        End If
        Kriteria = "Per Dokter"
        tampilPerDokter()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

    Private Sub txtKodeObatTab3_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObatTab3.GotFocus
        tampilBarang()
        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub txtKodeObatTab3_TextChanged(sender As Object, e As EventArgs) Handles txtKodeObatTab3.TextChanged

    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                txtKodeObatTab3.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                lblNamaObat.Text = gridBarang.Rows(e.RowIndex).Cells(3).Value
                PanelObat.Visible = False
                btnProsesTab3.Focus()
            End If
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                txtKodeObatTab3.Text = gridBarang.Rows(i).Cells(2).Value
                lblNamaObat.Text = gridBarang.Rows(i).Cells(3).Value
                PanelObat.Visible = False
                btnProsesTab3.Focus()
            End If
        End If
    End Sub

    Private Sub btnProsesTab3_Click(sender As Object, e As EventArgs) Handles btnProsesTab3.Click
        If cmbPenjamin.Text = "" Or cmbBagian.Text = "" Or cmbJenisPasien.Text = "" Or txtKodeObatTab3.Text = "" Then
            MsgBox("Ada yang belum dipilih, silahkan cek lagi", vbInformation, "Informasi")
            Exit Sub
        End If
        If cmbPenjamin.Text = "BPJS" Then
            If cmbPilihanTab3.Text = "" Then
                MsgBox("Pilihan belum dipilih", vbInformation, "Informasi")
                Exit Sub
            End If
        End If
        Kriteria = "Per Barang"
        tampilPerBarang()
    End Sub

    Private Sub btnProsesTab4_Click(sender As Object, e As EventArgs) Handles btnProsesTab4.Click
        If cmbPenjamin.Text = "" Or cmbBagian.Text = "" Or cmbJenisPasien.Text = "" Or cmbJenisBarangTab4.Text = "" Then
            MsgBox("Ada yang belum dipilih, silahkan cek lagi", vbInformation, "Informasi")
            Exit Sub
        End If
        If cmbPenjamin.Text = "BPJS" Then
            If cmbPilihanTab4.Text = "" Then
                MsgBox("Pilihan belum dipilih", vbInformation, "Informasi")
                Exit Sub
            End If
        End If
        Kriteria = "Per Jenis"
        tampilPerJenisObat()
    End Sub

    Private Sub btnProsesTab5_Click(sender As Object, e As EventArgs) Handles btnProsesTab5.Click
        If cmbPenjamin.Text = "" Or cmbBagian.Text = "" Or cmbJenisPasien.Text = "" Or cmbKelompokObatTab5.Text = "" Then
            MsgBox("Ada yang belum dipilih, silahkan cek lagi", vbInformation, "Informasi")
            Exit Sub
        End If
        If cmbPenjamin.Text = "BPJS" Then
            If cmbPilihanTab5.Text = "" Then
                MsgBox("Pilihan belum dipilih", vbInformation, "Informasi")
                Exit Sub
            End If
        End If
        Kriteria = "Per Kelompok"
        tampilPerKelompokObat()
    End Sub

    Private Sub btnProsesTab6_Click(sender As Object, e As EventArgs) Handles btnProsesTab6.Click
        If cmbPenjamin.Text = "" Or cmbBagian.Text = "" Or cmbJenisPasien.Text = "" Or cmbGolonganObatTab6.Text = "" Then
            MsgBox("Ada yang belum dipilih, silahkan cek lagi", vbInformation, "Informasi")
            Exit Sub
        End If
        If cmbPenjamin.Text = "BPJS" Then
            If cmbPilihanTab6.Text = "" Then
                MsgBox("Pilihan belum dipilih", vbInformation, "Informasi")
                Exit Sub
            End If
        End If
        Kriteria = "Per Golongan"
        tampilPerGolonganObat()
    End Sub

    Private Sub txtCariPasienTab1_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasienTab1.TextChanged
        If rNama.Checked = True Then
            BDLaporanDetailPenjualanResep.Filter = "nmpasien like '%" & txtCariPasienTab1.Text & "%'"
        Else
            BDLaporanDetailPenjualanResep.Filter = "no_rm like '%" & txtCariPasienTab1.Text & "%'"
        End If
    End Sub

    Private Sub btnExcelTab1_Click(sender As Object, e As EventArgs) Handles btnExcelTab1.Click
        EksportExcel()
    End Sub

    Private Sub btnExcelTab2_Click(sender As Object, e As EventArgs) Handles btnExcelTab2.Click
        EksportExcel()
    End Sub

    Private Sub btnExcelTab3_Click(sender As Object, e As EventArgs) Handles btnExcelTab3.Click
        EksportExcel()
    End Sub

    Private Sub btnExcelTab4_Click(sender As Object, e As EventArgs) Handles btnExcelTab4.Click
        EksportExcel()
    End Sub

    Private Sub btnExcelTab5_Click(sender As Object, e As EventArgs) Handles btnExcelTab5.Click
        EksportExcel()
    End Sub

    Private Sub btnExcelTab6_Click(sender As Object, e As EventArgs) Handles btnExcelTab6.Click
        EksportExcel()
    End Sub

    Private Sub btnBaruTab1_Click(sender As Object, e As EventArgs) Handles btnBaruTab1.Click
        KosongkanPerTanggal()
    End Sub

    Private Sub btnBaruTab2_Click(sender As Object, e As EventArgs) Handles btnBaruTab2.Click
        KosongkanPerDokter()
    End Sub

    Private Sub btnBaruTab3_Click(sender As Object, e As EventArgs) Handles btnBaruTab3.Click
        KosongkanPerBarang()
    End Sub

    Private Sub btnBaruTab4_Click(sender As Object, e As EventArgs) Handles btnBaruTab4.Click
        KosongkanPerJenis()
    End Sub

    Private Sub btnBaruTab5_Click(sender As Object, e As EventArgs) Handles btnBaruTab5.Click
        KosongkanPerKelompok()
    End Sub

    Private Sub btnBaruTab6_Click(sender As Object, e As EventArgs) Handles btnBaruTab6.Click
        KosongkanPerGolongan()
    End Sub

    Private Sub cmbBagian_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBagian.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbJenisPasien.Focus()
        End If
    End Sub

    Private Sub btnProsesTab7_Click(sender As Object, e As EventArgs) Handles btnProsesTab7.Click
        If cmbGenerik.Text = "" Then
            MsgBox("Kelompok generik belum dipilih", MsgBoxStyle.Exclamation, "Peringatan")
            cmbGenerik.Focus()
            Exit Sub
        End If
        tampilPerGolonganGenerik()
    End Sub

    Private Sub btnBaruTab7_Click(sender As Object, e As EventArgs) Handles btnBaruTab7.Click
        KosongkanPerGenerik()
    End Sub

    Private Sub btnExcelTab7_Click(sender As Object, e As EventArgs) Handles btnExcelTab7.Click
        EksportExcel()
    End Sub
End Class