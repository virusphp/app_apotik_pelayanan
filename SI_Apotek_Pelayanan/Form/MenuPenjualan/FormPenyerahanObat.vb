Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports Syncfusion.XlsIO

Public Class FormPenyerahanObat
    Inherits Office2010Form
    Dim BDDataPasienResep, BDPenjualanResep, BDPenjualanNonResep, BDPlastik, BDDataPasienNonResep, BDLaporanResepSudahDiserahkan, BDLaporanResepBelumDiserahkan, BDLaporanObatBebasSudahDiserahkan, BDLaporanObatBebasBelumDiserahkan As New BindingSource
    Dim DSPenjualanResep, DSPenjualanNonResep As New DataSet
    Dim tglLahirPasien As DateTime
    Dim TabPemanggil, JenisRawat, kdDokter, kdPenjamin, kdSubUnit, NamaDokter, NamaPenjamin, nmSubUnit, Posting, StatusRawat, memStok As String
    'Dim Trans As SqlTransaction
    Dim Trans As OleDb.OleDbTransaction

    Sub KosongkanTab1()
        TglServer()
        DTPTanggalTransTab1.Value = TanggalServer
        txtNoResepTab1.Clear()
        txtNoRegTab1.Clear()
        txtJnsRawatTab1.Clear()
        txtRMTab1.Clear()
        txtSexTab1.Clear()
        txtUmurThnTab1.Clear()
        txtUmurBlnTab1.Clear()
        txtNamaPasienTab1.Clear()
        txtAlamatTab1.Clear()
        cmbUnitAsalTab1.Text = ""
        cmbPenjaminTab1.Text = ""
        cmbDokterTab1.Text = ""
        txtPostingTab1.Clear()
        gridDetailObatResep.DataSource = Nothing
        gridDetailObatResep.BackgroundColor = Color.Azure
        gridPlastikTab1.DataSource = Nothing
        gridPlastikTab1.BackgroundColor = Color.Azure
        DTPTanggalInputTab1.Value = TanggalServer
        DTPTanggalPenyerahanTab1.Value = TanggalServer
        txtJamInputTab1.Clear()
        txtJamPenyerahanTab1.Clear()
        txtResponJamTab1.Clear()
        txtResponMenitTab1.Clear()
        txtResponMenitTotalTab1.Clear()
        txtPiutang.DecimalValue = 0
        txtTunai.DecimalValue = 0
        txtPaketLain.DecimalValue = 0
        btnSimpan.Enabled = True
        DTPTanggalTransTab1.Focus()
    End Sub

    Sub KosongkanTab2()
        TglServer()
        DTPTanggalTransTab2.Value = TanggalServer
        gridDetailObatNonResep.DataSource = Nothing
        gridDetailObatNonResep.BackgroundColor = Color.Azure
        gridPlastikTab2.DataSource = Nothing
        gridPlastikTab2.BackgroundColor = Color.Azure
        DTPTanggalInputTab2.Value = TanggalServer
        DTPTanggalPenyerahanTab2.Value = TanggalServer
        txtJamInputTab2.Clear()
        txtJamPenyerahanTab2.Clear()
        txtResponJamTab2.Clear()
        txtResponMenitTab2.Clear()
        txtResponMenitTotalTab2.Clear()
        txtNotaTab2.Clear()
        txtNamaPasienTab2.Clear()
        txtDokterTab2.Clear()
        txtPostingTab2.Clear()
        txtTunaiTab2.DecimalValue = 0
        btnSimpanTab2.Enabled = True
        DTPTanggalTransTab2.Focus()
    End Sub

    Sub KosongkanTab3()
        TglServer()
        DTPTanggalAwalTab3.Value = TanggalServer
        DTPTanggalAkhirTab3.Value = TanggalServer
        txtRMTab3.Clear()
        txtRMTab3.Enabled = False
        txtNamaPasienTab3.Clear()
        txtNamaPasienTab3.Enabled = False
        gridLaporanObatSudahDiserahkan.DataSource = Nothing
        gridLaporanObatSudahDiserahkan.BackgroundColor = Color.Azure
        txtJmlNotaTab3.DecimalValue = 0
    End Sub

    Sub KosongkanTab4()
        TglServer()
        DTPTanggalAwalTab4.Value = TanggalServer
        DTPTanggalAkhirTab4.Value = TanggalServer
        txtNamaPasienTab4.Clear()
        txtNamaPasienTab4.Enabled = False
        gridLaporanObatBebasSudahDiserahkan.DataSource = Nothing
        gridLaporanObatBebasSudahDiserahkan.BackgroundColor = Color.Azure
        txtJmlNotaTab4.DecimalValue = 0
    End Sub

    Sub KosongkanTab5()
        TglServer()
        DTPTanggalAwalTab5.Value = TanggalServer
        DTPTanggalAkhirTab5.Value = TanggalServer
        txtRMTab5.Clear()
        txtRMTab5.Enabled = False
        txtNamaPasienTab5.Clear()
        txtNamaPasienTab5.Enabled = False
        gridLaporanObatBelumDiserahkan.DataSource = Nothing
        gridLaporanObatBelumDiserahkan.BackgroundColor = Color.Azure
        txtJmlNotaTab5.DecimalValue = 0
    End Sub

    Sub KosongkanTab6()
        TglServer()
        DTPTanggalAwalTab6.Value = TanggalServer
        DTPTanggalAkhirTab6.Value = TanggalServer
        txtNamaPasienTab6.Clear()
        txtNamaPasienTab6.Enabled = False
        gridLaporanObatBebasBelumDiserahkan.DataSource = Nothing
        gridLaporanObatBebasBelumDiserahkan.BackgroundColor = Color.Azure
        txtJmlNotaTab6.DecimalValue = 0
    End Sub

    Sub tampilPasienResep()
        Try
            DA = New OleDb.OleDbDataAdapter("select distinct kdbagian,stsrawat,tanggal,notaresep,no_rm,RTRIM(LTRIM(nmpasien)) as nmpasien,RTRIM(LTRIM(nmdokter)) as nmdokter,diserahkan from ap_jualr2 where kdbagian='" & pkdapo & "' AND tanggal='" & Format(DTPTanggalTransTab1.Value, "yyyy/MM/dd") & "' order by tanggal,notaresep", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasienResep")
            BDDataPasienResep.DataSource = DS
            BDDataPasienResep.DataMember = "pasienResep"
            With gridPasienPenyerahan
                .DataSource = Nothing
                .DataSource = BDDataPasienResep
                .Columns(1).HeaderText = "Unit Depo"
                .Columns(2).HeaderText = "Status Rawat"
                .Columns(3).HeaderText = "Tanggal Resep"
                .Columns(4).HeaderText = "Nota Resep"
                .Columns(5).HeaderText = "No RM"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(7).HeaderText = "Nama Dokter"
                .Columns(8).HeaderText = "Diserahkan"
                .Columns(0).Width = 30
                .Columns(1).Width = 40
                .Columns(2).Width = 45
                .Columns(3).Width = 75
                .Columns(4).Width = 100
                .Columns(5).Width = 60
                .Columns(6).Width = 130
                .Columns(7).Width = 130
                .Columns(8).Width = 70
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

    Sub tampilPasienNonResep()
        Try
            DA = New OleDb.OleDbDataAdapter("select distinct kdbagian,RTRIM(LTRIM(nmkasir)) as nmkasir,tanggal,nota,RTRIM(LTRIM(nmkons)) as nmkons,RTRIM(LTRIM(nama)) as nmpasien,RTRIM(LTRIM(nmdokter)) as nmdokter,diserahkan from ap_jualbbs2 where kdbagian='" & pkdapo & "' AND tanggal='" & Format(DTPTanggalTransTab2.Value, "yyyy/MM/dd") & "' order by tanggal,nota", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasienNonResep")
            BDDataPasienNonResep.DataSource = DS
            BDDataPasienNonResep.DataMember = "pasienNonResep"
            With gridPasienPenyerahan
                .DataSource = Nothing
                .DataSource = BDDataPasienNonResep
                .Columns(1).HeaderText = "Unit Depo"
                .Columns(2).HeaderText = "Nama Petugas"
                .Columns(3).HeaderText = "Tanggal Nota"
                .Columns(4).HeaderText = "Nomor Nota"
                .Columns(5).HeaderText = "Konsumen"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(7).HeaderText = "Nama Dokter"
                .Columns(8).HeaderText = "Diserahkan"
                .Columns(0).Width = 30
                .Columns(1).Width = 40
                .Columns(2).Width = 70
                .Columns(3).Width = 70
                .Columns(4).Width = 90
                .Columns(5).Width = 75
                .Columns(6).Width = 130
                .Columns(7).Width = 130
                .Columns(8).Width = 70
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

    Sub tampilLaporanResepSudahDiserahkan()
        Try
            'DA = New OleDb.OleDbDataAdapter("SELECT RTRIM(LTRIM(kdbagian)) as kdbagian,stsrawat,RTRIM(LTRIM(nmkasir)) as nmkasir,diserahkan,tanggal,notaresep,no_reg,no_rm,RTRIM(LTRIM(nama_pasien)) as nama_pasien,RTRIM(LTRIM(nmdokter)) as nmdokter,LEFT(jam,8) as jamdiserahkan,jam2,RTRIM(LTRIM(respontime)) as respontime,posting,respontime_menit FROM ap_jualr1 where kdbagian='" & pkdapo & "' AND tanggal >= '" & Format(DTPTanggalAwalTab3.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab3.Value, "yyyy/MM/dd") & "' AND diserahkan='S' ORDER BY tanggal,notaresep", CONN)
            DA = New OleDb.OleDbDataAdapter("SELECT DISTINCT RTRIM(LTRIM(ap_jualr1.kdbagian)) AS kdbagian, ap_jualr1.stsrawat, RTRIM(LTRIM(ap_jualr1.nmkasir)) AS nmkasir, ap_jualr1.diserahkan, ap_jualr1.tanggal, ap_jualr1.notaresep, ap_jualr1.no_reg, ap_jualr1.no_rm, RTRIM(LTRIM(ap_jualr1.nama_pasien)) AS nama_pasien, RTRIM(LTRIM(ap_jualr1.nmdokter)) AS nmdokter, LEFT(ap_jualr1.jam, 8) AS jamdiserahkan, ap_jualr1.jam2, RTRIM(LTRIM(ap_jualr1.respontime)) AS respontime, ap_jualr1.posting, ap_jualr1.respontime_menit, ap_plastik_keluar.nmkasir AS petugas_penyerahan FROM ap_jualr1 LEFT OUTER JOIN ap_plastik_keluar ON ap_jualr1.notaresep = ap_plastik_keluar.notaresep where ap_jualr1.kdbagian='" & pkdapo & "' AND ap_jualr1.tanggal >= '" & Format(DTPTanggalAwalTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr1.tanggal <= '" & Format(DTPTanggalAkhirTab3.Value, "yyyy/MM/dd") & "' AND ap_jualr1.diserahkan='S' ORDER BY ap_jualr1.tanggal,ap_jualr1.notaresep", CONN)
            DS = New DataSet
            DA.Fill(DS, "LaporanResepSudahDiserahkan")
            BDLaporanResepSudahDiserahkan.DataSource = DS
            BDLaporanResepSudahDiserahkan.DataMember = "LaporanResepSudahDiserahkan"
            With gridLaporanObatSudahDiserahkan
                .DataSource = Nothing
                .DataSource = BDLaporanResepSudahDiserahkan
                .Columns(0).HeaderText = "Unit Depo"
                .Columns(1).HeaderText = "Status Rawat"
                .Columns(2).HeaderText = "Petugas"
                .Columns(3).HeaderText = "S/B"
                .Columns(4).HeaderText = "Tanggal"
                .Columns(5).HeaderText = "Nota Resep"
                .Columns(6).HeaderText = "No Registrasi"
                .Columns(7).HeaderText = "No RM"
                .Columns(8).HeaderText = "Nama Pasien"
                .Columns(9).HeaderText = "Nama Dokter"
                .Columns(10).HeaderText = "Jam Masuk Resep"
                .Columns(11).HeaderText = "Jam Obat di Serahkan"
                .Columns(12).HeaderText = "Respon Time"
                .Columns(13).HeaderText = "P"
                .Columns(15).HeaderText = "Petugas Yang Menyerahkan"
                .Columns(0).Width = 30
                .Columns(1).Width = 30
                .Columns(2).Width = 75
                .Columns(3).Width = 30
                .Columns(4).Width = 75
                .Columns(5).Width = 90
                .Columns(6).Width = 90
                .Columns(7).Width = 70
                .Columns(8).Width = 130
                .Columns(9).Width = 120
                .Columns(10).Width = 75
                .Columns(11).Width = 75
                .Columns(12).Width = 100
                .Columns(13).Width = 25
                .Columns(14).Visible = False
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilLaporanResepBelumDiserahkan()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT RTRIM(LTRIM(kdbagian)) as kdbagian,stsrawat,RTRIM(LTRIM(nmkasir)) as nmkasir,diserahkan,tanggal,notaresep,no_reg,no_rm,RTRIM(LTRIM(nama_pasien)) as nama_pasien,RTRIM(LTRIM(nmdokter)) as nmdokter,LEFT(jam,8) as jamdiserahkan,jam2,RTRIM(LTRIM(respontime)) as respontime,posting FROM ap_jualr1 where kdbagian='" & pkdapo & "' AND tanggal >= '" & Format(DTPTanggalAwalTab5.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab5.Value, "yyyy/MM/dd") & "' AND diserahkan='B' ORDER BY tanggal,notaresep", CONN)
            DS = New DataSet
            DA.Fill(DS, "LaporanResepBelumDiserahkan")
            BDLaporanResepBelumDiserahkan.DataSource = DS
            BDLaporanResepBelumDiserahkan.DataMember = "LaporanResepBelumDiserahkan"
            With gridLaporanObatBelumDiserahkan
                .DataSource = Nothing
                .DataSource = BDLaporanResepBelumDiserahkan
                .Columns(0).HeaderText = "Unit Depo"
                .Columns(1).HeaderText = "Status Rawat"
                .Columns(2).HeaderText = "Petugas"
                .Columns(3).HeaderText = "S/B"
                .Columns(4).HeaderText = "Tanggal"
                .Columns(5).HeaderText = "Nota Resep"
                .Columns(6).HeaderText = "No Registrasi"
                .Columns(7).HeaderText = "No RM"
                .Columns(8).HeaderText = "Nama Pasien"
                .Columns(9).HeaderText = "Nama Dokter"
                .Columns(10).HeaderText = "Jam Masuk Resep"
                .Columns(11).HeaderText = "Jam Obat di Serahkan"
                .Columns(12).HeaderText = "Respon Time"
                .Columns(13).HeaderText = "P"
                .Columns(0).Width = 30
                .Columns(1).Width = 30
                .Columns(2).Width = 75
                .Columns(3).Width = 30
                .Columns(4).Width = 75
                .Columns(5).Width = 90
                .Columns(6).Width = 90
                .Columns(7).Width = 70
                .Columns(8).Width = 130
                .Columns(9).Width = 120
                .Columns(10).Width = 75
                .Columns(11).Width = 75
                .Columns(12).Width = 100
                .Columns(13).Width = 25
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilLaporanObatBebasSudahDiserahkan()
        Try
            'DA = New OleDb.OleDbDataAdapter("SELECT RTRIM(LTRIM(kdbagian)) as kdbagian,diserahkan,RTRIM(LTRIM(nmkasir)) as nmkasir,tanggal,nota,RTRIM(LTRIM(nama)) as nama,RTRIM(LTRIM(nmdokter)) as nmdokter,LEFT(jam,8) as jamdiserahkan,jam2,respontime,posting,respontime_menit FROM ap_jualbbs1 where kdbagian='" & pkdapo & "' AND tanggal >= '" & Format(DTPTanggalAwalTab4.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab4.Value, "yyyy/MM/dd") & "' AND diserahkan='S' ORDER BY tanggal,nota", CONN)
            DA = New OleDb.OleDbDataAdapter("SELECT DISTINCT RTRIM(LTRIM(ap_jualbbs1.kdbagian)) AS kdbagian, ap_jualbbs1.diserahkan, RTRIM(LTRIM(ap_jualbbs1.nmkasir)) AS nmkasir, ap_jualbbs1.tanggal, ap_jualbbs1.nota, RTRIM(LTRIM(ap_jualbbs1.nama)) AS nama, RTRIM(LTRIM(ap_jualbbs1.nmdokter)) AS nmdokter, LEFT(ap_jualbbs1.jam, 8) AS jamdiserahkan, ap_jualbbs1.jam2, ap_jualbbs1.respontime, ap_jualbbs1.posting, ap_jualbbs1.respontime_menit, ap_plastik_keluar.nmkasir AS petugas_penyerahan FROM ap_jualbbs1 INNER JOIN ap_plastik_keluar ON ap_jualbbs1.nota = ap_plastik_keluar.notaresep where ap_jualbbs1.kdbagian='" & pkdapo & "' AND ap_jualbbs1.tanggal >= '" & Format(DTPTanggalAwalTab4.Value, "yyyy/MM/dd") & "' AND ap_jualbbs1.tanggal <= '" & Format(DTPTanggalAkhirTab4.Value, "yyyy/MM/dd") & "' AND ap_jualbbs1.diserahkan='S' ORDER BY ap_jualbbs1.tanggal,ap_jualbbs1.nota", CONN)
            DS = New DataSet
            DA.Fill(DS, "LaporanObatBebasSudahDiserahkan")
            BDLaporanObatBebasSudahDiserahkan.DataSource = DS
            BDLaporanObatBebasSudahDiserahkan.DataMember = "LaporanObatBebasSudahDiserahkan"
            With gridLaporanObatBebasSudahDiserahkan
                .DataSource = Nothing
                .DataSource = BDLaporanObatBebasSudahDiserahkan
                .Columns(0).HeaderText = "Unit Depo"
                .Columns(1).HeaderText = "S/B"
                .Columns(2).HeaderText = "Petugas"
                .Columns(3).HeaderText = "Tanggal"
                .Columns(4).HeaderText = "Nota Resep"
                .Columns(5).HeaderText = "Nama Pasien"
                .Columns(6).HeaderText = "Nama Dokter"
                .Columns(7).HeaderText = "Jam Masuk Resep"
                .Columns(8).HeaderText = "Jam Obat di Serahkan"
                .Columns(9).HeaderText = "Respon Time"
                .Columns(10).HeaderText = "P"
                .Columns(12).HeaderText = "Petugas Yang Menyerahkan"
                .Columns(0).Width = 30
                .Columns(1).Width = 30
                .Columns(2).Width = 100
                .Columns(3).Width = 75
                .Columns(4).Width = 90
                .Columns(5).Width = 170
                .Columns(6).Width = 170
                .Columns(7).Width = 100
                .Columns(8).Width = 100
                .Columns(9).Width = 120
                .Columns(10).Width = 30
                .Columns(11).Visible = False
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilLaporanObatBebasBelumDiserahkan()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT RTRIM(LTRIM(kdbagian)) as kdbagian,diserahkan,RTRIM(LTRIM(nmkasir)) as nmkasir,tanggal,nota,RTRIM(LTRIM(nama)) as nama,RTRIM(LTRIM(nmdokter)) as nmdokter,LEFT(jam,8) as jamdiserahkan,jam2,respontime,posting FROM ap_jualbbs1 where kdbagian='" & pkdapo & "' AND tanggal >= '" & Format(DTPTanggalAwalTab6.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab6.Value, "yyyy/MM/dd") & "' AND diserahkan='B' ORDER BY tanggal,nota", CONN)
            DS = New DataSet
            DA.Fill(DS, "LaporanObatBebasBelumDiserahkan")
            BDLaporanObatBebasBelumDiserahkan.DataSource = DS
            BDLaporanObatBebasBelumDiserahkan.DataMember = "LaporanObatBebasBelumDiserahkan"
            With gridLaporanObatBebasBelumDiserahkan
                .DataSource = Nothing
                .DataSource = BDLaporanObatBebasBelumDiserahkan
                .Columns(0).HeaderText = "Unit Depo"
                .Columns(1).HeaderText = "S/B"
                .Columns(2).HeaderText = "Petugas"
                .Columns(3).HeaderText = "Tanggal"
                .Columns(4).HeaderText = "Nota Resep"
                .Columns(5).HeaderText = "Nama Pasien"
                .Columns(6).HeaderText = "Nama Dokter"
                .Columns(7).HeaderText = "Jam Masuk Resep"
                .Columns(8).HeaderText = "Jam Obat di Serahkan"
                .Columns(9).HeaderText = "Respon Time"
                .Columns(10).HeaderText = "P"
                .Columns(0).Width = 30
                .Columns(1).Width = 30
                .Columns(2).Width = 100
                .Columns(3).Width = 75
                .Columns(4).Width = 90
                .Columns(5).Width = 170
                .Columns(6).Width = 170
                .Columns(7).Width = 100
                .Columns(8).Width = 100
                .Columns(9).Width = 120
                .Columns(10).Width = 30
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AturWarnaGrid(ByVal gridWarna As DataGridView)
        For i As Integer = 0 To gridWarna.RowCount - 1
            If gridWarna.Rows(i).Cells(8).Value = "S" Then
                gridWarna.Rows(i).Cells(6).Style.BackColor = Color.Aquamarine
            End If
        Next
    End Sub

    Sub tampilPlastik(ByVal gridPlastik As DataGridView)
        Try
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kdplastik)) as kdplastik, RTRIM(LTRIM(nmplastik)) as nmplastik, 'Bungkus'as bungkus, 0 as jumlah from ap_plastik order by kdplastik", CONN)
            DS = New DataSet
            DA.Fill(DS, "plastik")
            BDPlastik.DataSource = DS
            BDPlastik.DataMember = "plastik"
            With gridPlastik
                .DataSource = Nothing
                .DataSource = BDPlastik
                .Columns(0).HeaderText = "Kode"
                .Columns(0).ReadOnly = True
                .Columns(1).HeaderText = "Jenis / Ukuran Plastik"
                .Columns(1).ReadOnly = True
                .Columns(2).HeaderText = "Satuan"
                .Columns(2).ReadOnly = True
                .Columns(3).HeaderText = "Jumlah"
                .Columns(3).DefaultCellStyle.BackColor = Color.LightYellow
                .Columns(0).Width = 50
                .Columns(1).Width = 200
                .Columns(2).Width = 80
                .Columns(3).Width = 70
                .Columns(3).DefaultCellStyle.Format = "N2"
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black

            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampilDetailPenyerahanObatResep()
        CMD = New OleDb.OleDbCommand("SELECT * FROM ap_jualr1 WHERE notaresep='" & Trim(txtNoResepTab1.Text) & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)

        If DT.Rows.Count > 0 Then
            txtNoRegTab1.Text = Trim(DT.Rows(0).Item("no_reg"))
            txtRMTab1.Text = Trim(DT.Rows(0).Item("no_rm"))
            StatusRawat = Trim(DT.Rows(0).Item("stsrawat"))
            txtJnsRawatTab1.Text = StatusRawat
            txtNamaPasienTab1.Text = Trim(DT.Rows(0).Item("nama_pasien"))
            kdSubUnit = Trim(DT.Rows(0).Item("kd_sub_unit_asal"))
            nmSubUnit = Trim(DT.Rows(0).Item("nama_sub_unit"))
            kdPenjamin = Trim(DT.Rows(0).Item("kd_penjamin"))
            NamaPenjamin = Trim(DT.Rows(0).Item("nm_penjamin"))
            kdDokter = Trim(DT.Rows(0).Item("kddokter"))
            NamaDokter = Trim(DT.Rows(0).Item("nmdokter"))
            Posting = Trim(DT.Rows(0).Item("posting"))
            txtPostingTab1.Text = Posting
            txtJamInputTab1.Text = DT.Rows(0).Item("jam").ToString
            DTPTanggalInputTab1.Value = DT.Rows(0).Item("tanggal")
            txtTunai.DecimalValue = DT.Rows(0).Item("totalselisih_bayar_bulat")
            txtPiutang.DecimalValue = DT.Rows(0).Item("totaldijamin_bulat")
            txtPaketLain.DecimalValue = DT.Rows(0).Item("totalnonpaket_bulat")
            TglServer()
            DTPTanggalPenyerahanTab1.Value = TanggalServer
            txtJamPenyerahanTab1.Text = Format(TanggalServer, "HH:mm:ss")
            If NamaPenjamin = "-" Then
                cmbPenjaminTab1.Text = "-|UMUM"
            Else
                cmbPenjaminTab1.Text = NamaPenjamin + "|" + kdPenjamin
            End If
            cmbUnitAsalTab1.Text = nmSubUnit + "|" + kdSubUnit
            cmbDokterTab1.Text = NamaDokter + "|" + kdDokter
            'txtJnsRawatTab1.Text = JenisRawat
        End If

        CMD = New OleDb.OleDbCommand("SELECT Pasien.no_RM, Pasien.alamat, Pasien.RT, Pasien.RW, Kelurahan.nama_kelurahan, Kecamatan.nama_kecamatan,Kabupaten.nama_kabupaten, Propinsi.nama_propinsi, pasien.nama_pasien, case pasien.jns_kel when '0' then 'P' else 'L' end as jns_kel, pasien.tgl_lahir FROM Pasien INNER JOIN Kelurahan ON Pasien.kd_kelurahan = Kelurahan.kd_kelurahan INNER JOIN Kecamatan ON Kelurahan.kd_kecamatan = Kecamatan.kd_kecamatan INNER JOIN Kabupaten ON Kecamatan.kd_kabupaten = Kabupaten.kd_kabupaten INNER JOIN Propinsi ON Kabupaten.kd_propinsi = Propinsi.kd_propinsi where Pasien.no_RM='" & txtRMTab1.Text & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        txtAlamatTab1.Text = DT.Rows(0).Item("alamat") + " RT " + DT.Rows(0).Item("rt") + " RW " + DT.Rows(0).Item("rw") + " Kel : " + DT.Rows(0).Item("nama_kelurahan") + " Kec : " + DT.Rows(0).Item("nama_kecamatan") + " Kab : " + DT.Rows(0).Item("nama_kabupaten") + " Prov : " + DT.Rows(0).Item("nama_propinsi")
        tglLahirPasien = DT.Rows(0).Item("tgl_lahir")
        txtSexTab1.Text = DT.Rows(0).Item("jns_kel")
        TglServer()
        'txtUmurThn.Text = DateDiff(DateInterval.Year, tglLahirPasien, TanggalServer)
        'txtUmurBln.Text = DateDiff(DateInterval.Month, tglLahirPasien, TanggalServer) Mod 12
        txtUmurThnTab1.Text = TanggalServer.Year - tglLahirPasien.Year
        txtUmurBlnTab1.Text = TanggalServer.Month - tglLahirPasien.Month
        If Val(txtUmurBlnTab1.Text) < 0 Then
            txtUmurThnTab1.Text = Val(txtUmurThnTab1.Text) - 1
            txtUmurBlnTab1.Text = 12 + Val(txtUmurBlnTab1.Text)
        End If

        tampilDetailObatResep()

    End Sub

    Sub tampilDetailObatResep()
        Try
            DA = New OleDb.OleDbDataAdapter("select urut, racik, nama_barang, harga, jml, nmsatuan, kd_barang, jml from ap_jualr2 WHERE tanggal='" & Format(DTPTanggalTransTab1.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResepTab1.Text) & "' order by urut", CONN)
            DSPenjualanResep = New DataSet

            DA.Fill(DSPenjualanResep, "PenjualanResep")
            BDPenjualanResep.DataSource = DSPenjualanResep
            BDPenjualanResep.DataMember = "PenjualanResep"
            With gridDetailObatResep
                .DataSource = Nothing
                .DataSource = BDPenjualanResep
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub tampilDetailPenyerahanObatNonResep()
        CMD = New OleDb.OleDbCommand("SELECT jmlnet, posting, tanggal, jam FROM ap_jualbbs1 WHERE nota='" & Trim(txtNotaTab2.Text) & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            txtTunaiTab2.DecimalValue = DT.Rows(0).Item("jmlnet")
            txtPostingTab2.Text = DT.Rows(0).Item("posting")
            DTPTanggalInputTab2.Value = DT.Rows(0).Item("tanggal")
            txtJamInputTab2.Text = DT.Rows(0).Item("jam").ToString
        End If

        TglServer()
        DTPTanggalPenyerahanTab2.Value = TanggalServer
        txtJamPenyerahanTab2.Text = Format(TanggalServer, "HH:mm:ss")

        tampilDetailObatNonResep()
    End Sub

    Sub tampilDetailObatNonResep()
        Try
            DA = New OleDb.OleDbDataAdapter("select urut, racik, nama_barang, harga, jml, nmsatuan, kd_barang, jml from ap_jualbbs2 WHERE tanggal='" & Format(DTPTanggalTransTab2.Value, "yyyy/MM/dd") & "' and nota='" & Trim(txtNotaTab2.Text) & "' order by urut", CONN)
            DSPenjualanNonResep = New DataSet

            DA.Fill(DSPenjualanNonResep, "PenjualanNonResep")
            BDPenjualanNonResep.DataSource = DSPenjualanNonResep
            BDPenjualanNonResep.DataMember = "PenjualanNonResep"
            With gridDetailObatNonResep
                .DataSource = Nothing
                .DataSource = BDPenjualanNonResep
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AturGridTab(ByVal grid As DataGridView)
        With grid
            .Columns(0).HeaderText = "No"
            .Columns(1).HeaderText = "R/N"
            .Columns(2).HeaderText = "Nama Barang"
            .Columns(3).HeaderText = "Harga"
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Jumlah"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).DefaultCellStyle.BackColor = Color.LightYellow
            .Columns(5).HeaderText = "Satuan"
            .Columns(0).Width = 40
            .Columns(1).Width = 40
            .Columns(2).Width = 280
            .Columns(3).Width = 90
            .Columns(4).Width = 70
            .Columns(5).Width = 80
            .Columns(0).Visible = False
            .Columns(6).Visible = False
            .Columns(7).Visible = False
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

    Private Sub FormPenyerahanObat_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormPenyerahanObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        KosongkanTab1()
        KosongkanTab2()
        KosongkanTab3()
        KosongkanTab4()
        KosongkanTab5()
    End Sub

    Private Sub txtCariPasien_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPasien.KeyDown
        If e.KeyCode = Keys.Down Then
            gridPasienPenyerahan.Focus()
        End If
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
        If TabPemanggil = "Tab1" Then
            If rRm.Checked = True Then
                BDDataPasienResep.Filter = "no_RM like '%" & txtCariPasien.Text & "%'"
                AturWarnaGrid(gridPasienPenyerahan)
            Else
                BDDataPasienResep.Filter = "nmpasien like '%" & txtCariPasien.Text & "%'"
                AturWarnaGrid(gridPasienPenyerahan)
            End If

        ElseIf TabPemanggil = "Tab2" Then
            If rRm.Checked = True Then
                MsgBox("Tidak bisa melakukan pencarian berdasarkan RM", vbCritical, "Kesalahan")
                rNama.Checked = True
                txtCariPasien.Clear()
                txtCariPasien.Focus()
            Else
                BDDataPasienNonResep.Filter = "nmpasien like '%" & txtCariPasien.Text & "%'"
                AturWarnaGrid(gridPasienPenyerahan)
            End If

        End If

    End Sub

    Private Sub gridPasienResep_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPasienPenyerahan.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridPasienPenyerahan.Rows(e.RowIndex).Cells(1).Value) Then
                If TabPemanggil = "Tab1" Then
                    txtNoResepTab1.Text = Trim(gridPasienPenyerahan.Rows(e.RowIndex).Cells(4).Value)
                    tampilDetailPenyerahanObatResep()
                    AturGridTab(gridDetailObatResep)
                    PanelPasienResep.Visible = False
                    btnProsesTab1.Focus()
                ElseIf TabPemanggil = "Tab2" Then
                    txtNotaTab2.Text = Trim(gridPasienPenyerahan.Rows(e.RowIndex).Cells(4).Value)
                    PanelPasienResep.Visible = False
                    txtNamaPasienTab2.Text = Trim(gridPasienPenyerahan.Rows(e.RowIndex).Cells(6).Value)
                    txtDokterTab2.Text = Trim(gridPasienPenyerahan.Rows(e.RowIndex).Cells(7).Value)
                    tampilDetailPenyerahanObatNonResep()
                    AturGridTab(gridDetailObatNonResep)
                    btnProsesTab2.Focus()
                End If
            End If

        End If
    End Sub

    Private Sub txtNoResep_Click(sender As Object, e As EventArgs) Handles txtNoResepTab1.Click
        TabPemanggil = "Tab1"
        tampilPasienResep()
        AturWarnaGrid(gridPasienPenyerahan)
        PanelPasienResep.Visible = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub btnEx_Click(sender As Object, e As EventArgs) Handles btnEx.Click
        PanelPasienResep.Visible = False
    End Sub

    Private Sub FormPenyerahanObat_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelPasienResep.Top = txtNoResepTab1.Top + 48
        PanelPasienResep.Left = txtNoResepTab1.Left + 1
    End Sub

    Private Sub txtNoResepTab1_GotFocus(sender As Object, e As EventArgs) Handles txtNoResepTab1.GotFocus
        TabPemanggil = "Tab1"
        tampilPasienResep()
        AturWarnaGrid(gridPasienPenyerahan)
        PanelPasienResep.Visible = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub gridDetailObatResep_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObatResep.CellFormatting
        gridDetailObatResep.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnProsesTab1_Click(sender As Object, e As EventArgs) Handles btnProsesTab1.Click
        tampilPlastik(gridPlastikTab1)
        gridPlastikTab1.Focus()
        gridPlastikTab1.CurrentCell = gridPlastikTab1.Rows(0).Cells(3)
        Dim JamInput As Date = Convert.ToDateTime(txtJamInputTab1.Text)
        Dim JamPenyerahan As Date = Convert.ToDateTime(txtJamPenyerahanTab1.Text)
        Dim selisihWaktu = DateDiff(DateInterval.Minute, JamInput, JamPenyerahan)
        txtResponMenitTotalTab1.Text = selisihWaktu
        txtResponMenitTab1.Text = selisihWaktu Mod 60
        txtResponJamTab1.Text = Math.Floor(selisihWaktu / 60)
        Dim selisihTanggal = DateDiff(DateInterval.Day, DTPTanggalInputTab1.Value, DTPTanggalPenyerahanTab1.Value)
        txtResponJamTab1.Text = Val(txtResponJamTab1.Text) + (selisihTanggal * 24)
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        KosongkanTab1()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub gridPasienResep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridPasienPenyerahan.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridPasienPenyerahan.CurrentRow.Index - 1
            If Not IsDBNull(gridPasienPenyerahan.Rows(i).Cells(1).Value) Then
                If TabPemanggil = "Tab1" Then
                    txtNoResepTab1.Text = Trim(gridPasienPenyerahan.Rows(i).Cells(4).Value)
                    tampilDetailPenyerahanObatResep()
                    AturGridTab(gridDetailObatResep)
                    PanelPasienResep.Visible = False
                    btnProsesTab1.Focus()
                ElseIf TabPemanggil = "Tab2" Then
                    txtNotaTab2.Text = Trim(gridPasienPenyerahan.Rows(i).Cells(4).Value)
                    PanelPasienResep.Visible = False
                    txtNamaPasienTab2.Text = Trim(gridPasienPenyerahan.Rows(i).Cells(6).Value)
                    txtDokterTab2.Text = Trim(gridPasienPenyerahan.Rows(i).Cells(7).Value)
                    tampilDetailPenyerahanObatNonResep()
                    AturGridTab(gridDetailObatNonResep)
                    btnProsesTab2.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtTunai.DecimalValue > 0 Then
            If txtPostingTab1.Text = "1" Then
                MsgBox("Ada tagihan Tunai-Obat belum bisa diserahkan, belum ada pembayaran dikasir", vbInformation, "Informasi")
                Exit Sub
            End If
        End If
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
        If MessageBox.Show("Data sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlPenyerahanObatResep As String = ""
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                sqlPenyerahanObatResep = "UPDATE ap_jualr1 SET diserahkan='S', jam2='" & txtJamPenyerahanTab1.Text & "', respontime='" & txtResponJamTab1.Text & " Jam" & " - " & txtResponMenitTab1.Text & " Menit" & "', respontime_menit='" & Val(txtResponMenitTotalTab1.Text) & "'  WHERE tanggal='" & Format(DTPTanggalTransTab1.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResepTab1.Text) & "'"

                sqlPenyerahanObatResep = sqlPenyerahanObatResep + vbCrLf + "UPDATE ap_jualr2 SET diserahkan='S'  WHERE tanggal='" & Format(DTPTanggalTransTab1.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResepTab1.Text) & "'"

                If psts_stok = "1" Then
                    For i = 0 To gridDetailObatResep.RowCount - 2
                        sqlPenyerahanObatResep = sqlPenyerahanObatResep + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "-" & Num_En_US(gridDetailObatResep.Rows(i).Cells("jml").Value) & " WHERE kd_barang='" & Trim(gridDetailObatResep.Rows(i).Cells("kd_barang").Value) & "'"
                    Next
                End If

                For i = 0 To gridPlastikTab1.RowCount - 2
                    If gridPlastikTab1.Rows(i).Cells("jumlah").Value > 0 Then
                        sqlPenyerahanObatResep = sqlPenyerahanObatResep + vbCrLf + "insert into ap_plastik_keluar(kdbagian,kdkasir,nmkasir,tanggal,notaresep,nourut,kdplastik,nmplastik,jml,nmsatuan) values( '" & pkdapo & "', '" & FormLogin.LabelKode.Text & "', '" & FormLogin.LabelNama.Text & "','" & Format(DTPTanggalTransTab1.Value, "yyyy/MM/dd") & "', '" & txtNoResepTab1.Text & "', '0', '" & Trim(gridPlastikTab1.Rows(i).Cells("kdplastik").Value) & "', '" & Trim(gridPlastikTab1.Rows(i).Cells("nmplastik").Value) & "', '" & Val(gridPlastikTab1.Rows(i).Cells("jumlah").Value) & "', 'Bungkus')"
                    End If
                Next

                CMD.CommandText = sqlPenyerahanObatResep
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi berhasil disimpan", vbInformation, "Informasi")
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


    Private Sub txtNotaTab2_Click(sender As Object, e As EventArgs) Handles txtNotaTab2.Click
        TabPemanggil = "Tab2"
        tampilPasienNonResep()
        AturWarnaGrid(gridPasienPenyerahan)
        PanelPasienResep.Visible = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub txtNotaTab2_GotFocus(sender As Object, e As EventArgs) Handles txtNotaTab2.GotFocus
        TabPemanggil = "Tab2"
        tampilPasienNonResep()
        AturWarnaGrid(gridPasienPenyerahan)
        PanelPasienResep.Visible = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub txtNoResepTab1_TextChanged(sender As Object, e As EventArgs) Handles txtNoResepTab1.TextChanged

    End Sub

    Private Sub btnKeluarTab2_Click(sender As Object, e As EventArgs) Handles btnKeluarTab2.Click
        Dispose()
    End Sub

    Private Sub btnProsesTab2_Click(sender As Object, e As EventArgs) Handles btnProsesTab2.Click
        tampilPlastik(gridPlastikTab2)
        gridPlastikTab2.Focus()
        gridPlastikTab2.CurrentCell = gridPlastikTab2.Rows(0).Cells(3)
        Dim JamInput As Date = Convert.ToDateTime(txtJamInputTab2.Text)
        Dim JamPenyerahan As Date = Convert.ToDateTime(txtJamPenyerahanTab2.Text)
        Dim selisihWaktu = DateDiff(DateInterval.Minute, JamInput, JamPenyerahan)
        txtResponMenitTab2.Text = selisihWaktu Mod 60
        txtResponMenitTotalTab2.Text = selisihWaktu
        txtResponJamTab2.Text = Math.Floor(selisihWaktu / 60)
        Dim selisihTanggal = DateDiff(DateInterval.Day, DTPTanggalInputTab2.Value, DTPTanggalPenyerahanTab2.Value)
        txtResponJamTab2.Text = Val(txtResponJamTab2.Text) + (selisihTanggal * 24)
    End Sub

    Private Sub gridDetailObatNonResep_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObatNonResep.CellFormatting
        gridDetailObatNonResep.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub btnSimpanTab2_Click(sender As Object, e As EventArgs) Handles btnSimpanTab2.Click
        If txtPostingTab2.Text = "1" Then
            MsgBox("Ada tagihan Tunai-Obat belum bisa diserahkan, belum ada pembayaran dikasir", vbInformation, "Informasi")
            Exit Sub
        End If
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
        If MessageBox.Show("Data sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlPenyerahanObatNonResep As String = ""
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                sqlPenyerahanObatNonResep = "UPDATE ap_jualbbs1 SET diserahkan='S', jam2='" & txtJamPenyerahanTab2.Text & "', respontime='" & txtResponJamTab2.Text & " Jam" & " - " & txtResponMenitTab2.Text & " Menit" & "', respontime_menit='" & Val(txtResponMenitTotalTab2.Text) & "'  WHERE tanggal='" & Format(DTPTanggalTransTab2.Value, "yyyy/MM/dd") & "' and nota='" & Trim(txtNotaTab2.Text) & "'"

                sqlPenyerahanObatNonResep = sqlPenyerahanObatNonResep + vbCrLf + "UPDATE ap_jualbbs2 SET diserahkan='S'  WHERE tanggal='" & Format(DTPTanggalTransTab2.Value, "yyyy/MM/dd") & "' and nota='" & Trim(txtNotaTab2.Text) & "'"

                If psts_stok = "1" Then
                    For i = 0 To gridDetailObatNonResep.RowCount - 2
                        sqlPenyerahanObatNonResep = sqlPenyerahanObatNonResep + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "-" & Num_En_US(gridDetailObatNonResep.Rows(i).Cells("jml").Value) & " WHERE kd_barang='" & Trim(gridDetailObatNonResep.Rows(i).Cells("kd_barang").Value) & "'"
                    Next
                End If

                For i = 0 To gridPlastikTab2.RowCount - 2
                    If gridPlastikTab2.Rows(i).Cells("jumlah").Value > 0 Then
                        sqlPenyerahanObatNonResep = sqlPenyerahanObatNonResep + vbCrLf + "insert into ap_plastik_keluar(kdbagian,kdkasir,nmkasir,tanggal,notaresep,nourut,kdplastik,nmplastik,jml,nmsatuan) values( '" & pkdapo & "', '" & FormLogin.LabelKode.Text & "', '" & FormLogin.LabelNama.Text & "','" & Format(DTPTanggalTransTab2.Value, "yyyy/MM/dd") & "', '" & txtNotaTab2.Text & "', '0', '" & Trim(gridPlastikTab2.Rows(i).Cells("kdplastik").Value) & "', '" & Trim(gridPlastikTab2.Rows(i).Cells("nmplastik").Value) & "', '" & Val(gridPlastikTab2.Rows(i).Cells("jumlah").Value) & "', 'Bungkus')"
                    End If
                Next

                CMD.CommandText = sqlPenyerahanObatNonResep
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi berhasil disimpan", vbInformation, "Informasi")
                btnSimpanTab2.Enabled = False
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

    Private Sub btnBaruTab2_Click(sender As Object, e As EventArgs) Handles btnBaruTab2.Click
        KosongkanTab2()
    End Sub

    Private Sub DTPTanggalTransTab1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalTransTab1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNoResepTab1.Focus()
        End If
    End Sub

    Private Sub DTPTanggalTransTab2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalTransTab2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNotaTab2.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnProsesTab3.Click
        tampilLaporanResepSudahDiserahkan()
        txtJmlNotaTab3.DecimalValue = gridLaporanObatSudahDiserahkan.Rows.Count() - 1
        txtNamaPasienTab3.Enabled = True
        txtRMTab3.Enabled = True
    End Sub

    Private Sub txtRMTab3_TextChanged(sender As Object, e As EventArgs) Handles txtRMTab3.TextChanged
        BDLaporanResepSudahDiserahkan.Filter = "no_rm like '%" & txtRMTab3.Text & "%'"
    End Sub

    Private Sub txtNamaPasienTab3_TextChanged(sender As Object, e As EventArgs) Handles txtNamaPasienTab3.TextChanged
        BDLaporanResepSudahDiserahkan.Filter = "nama_pasien like '%" & txtNamaPasienTab3.Text & "%'"
    End Sub

    Private Sub btnExcelTab3_Click(sender As Object, e As EventArgs) Handles btnExcelTab3.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'GridTab1.DataSource = DS.Tables("permintaanGudangPerTanggal")
            Try
                Dim dtXls As DataTable = CType(DS.Tables("LaporanResepSudahDiserahkan"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanObatResepSudahDiserahkanXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab3.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab3.Text
                sheet.Range("B9").Text = pnmapo
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Obat Resep Sudah Diserahkan.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Obat Resep Sudah Diserahkan.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnBaruTab3_Click(sender As Object, e As EventArgs) Handles btnBaruTab3.Click
        KosongkanTab3()
    End Sub

    Private Sub btnProsesTab5_Click(sender As Object, e As EventArgs) Handles btnProsesTab5.Click
        tampilLaporanResepBelumDiserahkan()
        txtJmlNotaTab5.DecimalValue = gridLaporanObatBelumDiserahkan.Rows.Count() - 1
        txtNamaPasienTab5.Enabled = True
        txtRMTab5.Enabled = True
    End Sub

    Private Sub btnBaruTab5_Click(sender As Object, e As EventArgs) Handles btnBaruTab5.Click
        KosongkanTab5()
    End Sub

    Private Sub btnExcelTab5_Click(sender As Object, e As EventArgs) Handles btnExcelTab5.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'GridTab1.DataSource = DS.Tables("permintaanGudangPerTanggal")
            Try
                Dim dtXls As DataTable = CType(DS.Tables("LaporanResepBelumDiserahkan"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanObatResepBelumDiserahkanXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab5.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab5.Text
                sheet.Range("B9").Text = pnmapo
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Obat Resep Belum Diserahkan.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Obat Resep Belum Diserahkan.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub txtRMTab5_TextChanged(sender As Object, e As EventArgs) Handles txtRMTab5.TextChanged
        BDLaporanResepBelumDiserahkan.Filter = "no_rm like '%" & txtRMTab5.Text & "%'"
    End Sub

    Private Sub txtNamaPasienTab5_TextChanged(sender As Object, e As EventArgs) Handles txtNamaPasienTab5.TextChanged
        BDLaporanResepBelumDiserahkan.Filter = "nama_pasien like '%" & txtNamaPasienTab5.Text & "%'"
    End Sub

    Private Sub btnProsesTab4_Click(sender As Object, e As EventArgs) Handles btnProsesTab4.Click
        tampilLaporanObatBebasSudahDiserahkan()
        txtJmlNotaTab4.DecimalValue = gridLaporanObatBebasSudahDiserahkan.Rows.Count() - 1
        txtNamaPasienTab4.Enabled = True
    End Sub

    Private Sub btnBaruTab4_Click(sender As Object, e As EventArgs) Handles btnBaruTab4.Click
        KosongkanTab4()
    End Sub

    Private Sub txtNamaPasienTab4_TextChanged(sender As Object, e As EventArgs) Handles txtNamaPasienTab4.TextChanged
        BDLaporanObatBebasSudahDiserahkan.Filter = "nama like '%" & txtNamaPasienTab4.Text & "%'"
    End Sub

    Private Sub btnExcelTab4_Click(sender As Object, e As EventArgs) Handles btnExcelTab4.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'GridTab1.DataSource = DS.Tables("permintaanGudangPerTanggal")
            Try
                Dim dtXls As DataTable = CType(DS.Tables("LaporanObatBebasSudahDiserahkan"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanObatBebasSudahDiserahkanXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab4.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab4.Text
                sheet.Range("B9").Text = pnmapo
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Obat Bebas Sudah Diserahkan.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Obat Bebas Sudah Diserahkan.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnProsesTab6_Click(sender As Object, e As EventArgs) Handles btnProsesTab6.Click
        tampilLaporanObatBebasBelumDiserahkan()
        txtJmlNotaTab6.DecimalValue = gridLaporanObatBebasBelumDiserahkan.Rows.Count() - 1
        txtNamaPasienTab6.Enabled = True
    End Sub

    Private Sub txtNamaPasienTab6_TextChanged(sender As Object, e As EventArgs) Handles txtNamaPasienTab6.TextChanged
        BDLaporanObatBebasBelumDiserahkan.Filter = "nama like '%" & txtNamaPasienTab6.Text & "%'"
    End Sub

    Private Sub btnExcelTab6_Click(sender As Object, e As EventArgs) Handles btnExcelTab6.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            'GridTab1.DataSource = DS.Tables("permintaanGudangPerTanggal")
            Try
                Dim dtXls As DataTable = CType(DS.Tables("LaporanObatBebasBelumDiserahkan"), DataTable)
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanObatBebasBelumDiserahkanXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab6.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab6.Text
                sheet.Range("B9").Text = pnmapo
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Obat Bebas Belum Diserahkan.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Obat Bebas Belum Diserahkan.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnBaruTab6_Click(sender As Object, e As EventArgs) Handles btnBaruTab6.Click
        KosongkanTab6()
    End Sub
End Class