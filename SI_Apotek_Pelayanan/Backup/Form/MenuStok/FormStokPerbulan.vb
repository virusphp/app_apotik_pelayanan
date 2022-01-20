Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports Syncfusion.XlsIO

Public Class FormStokPerbulan
    Inherits Office2010Form
    Public rptdok, rpt As New ReportDocument
    Dim nmJenisObat, kdJenisObat, memStok As String
    Dim BDStokPerbulan, BDStokAwal, BDTerimaGudang, BDJualResep, BDJualBebas, BDKoreksiTambah, BDKoreksiKurang, BDReturJual, BDReturInap, BDMutasiUnit, BDTerimaUnit, BDTerimaFar1, BDTerimaFar2, BDTerimaFar3, BDTerimaFar4, BDTerimaFar5, BDTerimaFar6, BDTerimaFar7, BDReturGudang, BDDataBarang As New BindingSource
    Dim DSStokPerbulan, DSStokAwal, DSTerimaGudang, DSJualResep, DSJualBebas, DSKoreksiTambah, DSKoreksiKurang, DSReturJual, DSReturInap, DSMutasiUnit, DSTerimaUnit, DSTerimaFar1, DSTerimaFar2, DSTerimaFar3, DSTerimaFar4, DSTerimaFar5, DSTerimaFar6, DSTerimaFar7, DSReturGudang As New DataSet

    Private Sub DTPBulan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPBulan.KeyPress
        MessageBox.Show(DTPBulan.ToString())
        If e.KeyChar = Chr(13) Then
            DTPTahun.Focus()
        End If
    End Sub

    Dim DRWStokPerbulan, DRWStokAwal, DRWTerimaGudang, DRWJualResep, DRWJualBebas, DRWKoreksiTambah, DRWKoreksiKurang, DRWReturJual, DRWReturInap, DRWMutasiUnit, DRWTerimaUnit, DRWTerimaFar1, DRWTerimaFar2, DRWTerimaFar3, DRWTerimaFar4, DRWTerimaFar5, DRWTerimaFar6, DRWTerimaFar7, DRWReturGudang, DRWDataBarang As DataRowView

    'Dim Trans As SqlTransaction
    Dim Trans As OleDb.OleDbTransaction

    Sub Kosongkan()
        TglServer()
        DTPBulan.Value = New DateTime(TanggalServer.Year, TanggalServer.Month, 1)
        DTPTahun.Value = TanggalServer
        DSStokPerbulan = Table.BuatTabelStokPerbulan("StokPerbulan")
        gridObat.BackgroundColor = Color.Azure
        gridObat.DataSource = Nothing
        DSStokPerbulan.Clear()
        txtNamaBarang.Clear()
        txtQty.DecimalValue = 0
        txtGrandTotal.DecimalValue = 0
        TabControlStok.Enabled = False
        btnProsesTab5.Enabled = True
        btnUpdateStok.Enabled = True
        btnTutupStok.Enabled = True
        DTPBulan.Focus()
    End Sub

    Sub cariJenisObat()
        Dim cari As String = InStr(cmbJenisObat.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbJenisObat.Text, "|", -1, CompareMethod.Binary)
            kdJenisObat = Trim((ary(1)))
            nmJenisObat = Trim((ary(0)))
        End If
    End Sub

    Sub TampilStok1()
        'MsgBox(Month(DTPBulan.Value))
        btnProsesTab5.Enabled = False
        Try
            BDStokPerbulan.RemoveFilter()
            'gridObat.DataSource = Nothing
            ''''''' rekap semua barang
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(jenis_obat.jns_obat)) as nmjenis, RTRIM(LTRIM(barang_farmasi.nama_barang)) as nmbarang,  0 as stokawal, 0 as terimagdg, 0 as terima1, 0 as terima2, 0 as terima3, 0 as terima4, 0 as terima5, 0 as terima6, 0 as terima7, 0 as terimaunt, 0 as retcekout, 0 as retinap, 0 as kormasuk, 0 as ttlmasuk, 0 as jualresep, 0 as jualbebas, 0 as mutasi, 0 as retgudang, 0 as korkel, 0 as ttlkeluar, 0 as jmlstok, RTRIM(LTRIM(barang_farmasi.kd_satuan_kecil)) as nmsatuan, Round(barang_farmasi.harga_satuan,0) as harga, 0 as jmlharga,RTRIM(LTRIM(barang_farmasi.kd_barang)) as kdbarang, RTRIM(LTRIM(barang_farmasi.kd_jns_obat)) as kdjenis from barang_farmasi INNER JOIN jenis_obat ON barang_farmasi.kd_jns_obat=jenis_obat.kd_jns_obat where LEFT(kd_barang,2)='NW' order by jenis_obat.jns_obat,barang_farmasi.nama_barang", CONN)
            DSStokPerbulan = New DataSet
            DA.Fill(DSStokPerbulan, "StokPerbulan")
            BDStokPerbulan.DataSource = DSStokPerbulan
            BDStokPerbulan.DataMember = "StokPerbulan"

            '''''''''''stok awal
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_stok_awalapo where kdbagian='" & pkdapo & "' and bulan='" & Month(DTPBulan.Value) & "' and tahun='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSStokAwal = New DataSet
            DA.Fill(DSStokAwal, "StokAwal")
            BDStokAwal.DataSource = DSStokAwal
            BDStokAwal.DataMember = "StokAwal"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWStokAwal = BDStokAwal.Current
                    DRWStokPerbulan("stokawal") = DSStokAwal.Tables("StokAwal").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("stokawal")) Then
                        DRWStokPerbulan("stokawal") = 0
                    End If
                    'BDStokAwal.RemoveFilter()
                    BDStokPerbulan.MoveNext()
                Next
            End If


            '''''''''''penerimaan dari gudang
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambil where kdbagian='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSTerimaGudang = New DataSet
            DA.Fill(DSTerimaGudang, "TerimaGudang")
            BDTerimaGudang.DataSource = DSTerimaGudang
            BDTerimaGudang.DataMember = "TerimaGudang"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWTerimaGudang = BDTerimaGudang.Current
                    DRWStokPerbulan("terimagdg") = DSTerimaGudang.Tables("TerimaGudang").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("terimagdg")) Then
                        DRWStokPerbulan("terimagdg") = 0
                    Else
                        Dim a As Decimal
                        a = DSTerimaGudang.Tables("TerimaGudang").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("terimagdg") = a
                        Else
                            DRWStokPerbulan("terimagdg") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next

            End If


            '''''''''''jual resep 
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml  from ap_jualr2 where kdbagian='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "'", CONN)
            DSJualResep = New DataSet
            DA.Fill(DSJualResep, "JualResep")
            BDJualResep.DataSource = DSJualResep
            BDJualResep.DataMember = "JualResep"
            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWJualResep = BDJualResep.Current
                    DRWStokPerbulan("jualresep") = DSJualResep.Tables("JualResep").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("jualresep")) Then
                        DRWStokPerbulan("jualresep") = 0
                    Else
                        Dim a As Decimal
                        a = DSJualResep.Tables("JualResep").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("jualresep") = a
                        Else
                            DRWStokPerbulan("jualresep") = a
                            End If
                            'If DRWStokPerbulan("kdbarang") = "NW00002330" Then
                            '    MsgBox(a)
                            'End If
                        End If

                        BDStokPerbulan.MoveNext()
                Next
            End If


            '''''''''''jual bebas
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_jualbbs2 where kdbagian='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSJualBebas = New DataSet
            DA.Fill(DSJualBebas, "JualBebas")
            BDJualBebas.DataSource = DSJualBebas
            BDJualBebas.DataMember = "JualBebas"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWJualBebas = BDJualBebas.Current
                    DRWStokPerbulan("jualbebas") = DSJualBebas.Tables("JualBebas").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")

                    If IsDBNull(DRWStokPerbulan("jualbebas")) Then
                        DRWStokPerbulan("jualbebas") = 0
                    Else
                        Dim a As Decimal
                        a = DSJualBebas.Tables("JualBebas").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("jualbebas") = a
                        Else
                            DRWStokPerbulan("jualbebas") = a
                        End If
                        'If DRWStokPerbulan("kdbarang") = "NW00002365" Then
                        '    MsgBox(a)
                        'End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If


            '''''''''''Koreksi tambah / koreksi masuk
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_koreksiapo_tambah where kdbagian='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSKoreksiTambah = New DataSet
            DA.Fill(DSKoreksiTambah, "KoreksiTambah")
            BDKoreksiTambah.DataSource = DSKoreksiTambah
            BDKoreksiTambah.DataMember = "KoreksiTambah"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWKoreksiTambah = BDKoreksiTambah.Current
                    DRWStokPerbulan("kormasuk") = DSKoreksiTambah.Tables("KoreksiTambah").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("kormasuk")) Then
                        DRWStokPerbulan("kormasuk") = 0
                    Else
                        Dim a As Decimal
                        a = DSKoreksiTambah.Tables("KoreksiTambah").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("kormasuk") = a
                        Else
                            DRWStokPerbulan("kormasuk") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If


            '''''''''''Koreksi kurang / koreksi keluar
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_koreksiapo_kurang where kdbagian='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSKoreksiKurang = New DataSet
            DA.Fill(DSKoreksiKurang, "KoreksiKurang")
            BDKoreksiKurang.DataSource = DSKoreksiKurang
            BDKoreksiKurang.DataMember = "KoreksiKurang"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWKoreksiKurang = BDKoreksiKurang.Current
                    DRWStokPerbulan("korkel") = DSKoreksiKurang.Tables("KoreksiKurang").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("korkel")) Then
                        DRWStokPerbulan("korkel") = 0
                    Else
                        Dim a As Decimal
                        a = DSKoreksiKurang.Tables("KoreksiKurang").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("korkel") = a
                        Else
                            DRWStokPerbulan("korkel") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If


            '''''''''''Retur Sudah Check Out
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jmlretur as jml from ap_returjual where kdbagian='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSReturJual = New DataSet
            DA.Fill(DSReturJual, "ReturJual")
            BDReturJual.DataSource = DSReturJual
            BDReturJual.DataMember = "ReturJual"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWReturJual = BDReturJual.Current
                    DRWStokPerbulan("retcekout") = DSReturJual.Tables("ReturJual").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("retcekout")) Then
                        DRWStokPerbulan("retcekout") = 0
                    Else
                        Dim a As Decimal
                        a = DSReturJual.Tables("ReturJual").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("retcekout") = a
                        Else
                            DRWStokPerbulan("retcekout") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If


            '''''''''''Retur Rawat Inap
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, totalqty as jml from ap_returinap2 where kdbagian='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSReturInap = New DataSet
            DA.Fill(DSReturInap, "ReturInap")
            BDReturInap.DataSource = DSReturInap
            BDReturInap.DataMember = "ReturInap"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWReturInap = BDReturInap.Current
                    DRWStokPerbulan("retinap") = DSReturInap.Tables("ReturInap").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("retinap")) Then
                        DRWStokPerbulan("retinap") = 0
                    Else
                        Dim a As Decimal
                        a = DSReturInap.Tables("ReturInap").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("retinap") = a
                        Else
                            DRWStokPerbulan("retinap") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If


            '''''''''''Mutasi Ke Unit
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambilunit where kdbagian1='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSMutasiUnit = New DataSet
            DA.Fill(DSMutasiUnit, "MutasiUnit")
            BDMutasiUnit.DataSource = DSMutasiUnit
            BDMutasiUnit.DataMember = "MutasiUnit"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWMutasiUnit = BDMutasiUnit.Current
                    DRWStokPerbulan("mutasi") = DSMutasiUnit.Tables("MutasiUnit").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("mutasi")) Then
                        DRWStokPerbulan("mutasi") = 0
                    Else
                        Dim a As Decimal
                        a = DSMutasiUnit.Tables("MutasiUnit").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("mutasi") = a
                        Else
                            DRWStokPerbulan("mutasi") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If


            '''''''''''Terima Dari Unit
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambilunit where kdbagian2='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSTerimaUnit = New DataSet
            DA.Fill(DSTerimaUnit, "TerimaUnit")
            BDTerimaUnit.DataSource = DSTerimaUnit
            BDTerimaUnit.DataMember = "TerimaUnit"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWTerimaUnit = BDTerimaUnit.Current
                    DRWStokPerbulan("terimaunt") = DSTerimaUnit.Tables("TerimaUnit").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("terimaunt")) Then
                        DRWStokPerbulan("terimaunt") = 0
                    Else
                        Dim a As Decimal
                        a = DSTerimaUnit.Tables("TerimaUnit").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("terimaunt") = a
                        Else
                            DRWStokPerbulan("terimaunt") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If


            '''''''''''Terima Dari Unit Farmasi 1
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambilunit where kdbagian2='" & pkdapo & "' and kdbagian1='001' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSTerimaFar1 = New DataSet
            DA.Fill(DSTerimaFar1, "TerimaFar1")
            BDTerimaFar1.DataSource = DSTerimaFar1
            BDTerimaFar1.DataMember = "TerimaFar1"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWTerimaFar1 = BDTerimaFar1.Current
                    DRWStokPerbulan("terima1") = DSTerimaFar1.Tables("TerimaFar1").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("terima1")) Then
                        DRWStokPerbulan("terima1") = 0
                    Else
                        Dim a As Decimal
                        a = DSTerimaFar1.Tables("TerimaFar1").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("terima1") = a
                        Else
                            DRWStokPerbulan("terima1") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If

            '''''''''''Terima Dari Unit Farmasi 2
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambilunit where kdbagian2='" & pkdapo & "' and kdbagian1='002' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSTerimaFar2 = New DataSet
            DA.Fill(DSTerimaFar2, "TerimaFar2")
            BDTerimaFar2.DataSource = DSTerimaFar2
            BDTerimaFar2.DataMember = "TerimaFar2"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWTerimaFar2 = BDTerimaFar2.Current
                    DRWStokPerbulan("terima2") = DSTerimaFar2.Tables("TerimaFar2").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("terima2")) Then
                        DRWStokPerbulan("terima2") = 0
                    Else
                        Dim a As Decimal
                        a = DSTerimaFar2.Tables("TerimaFar2").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("terima2") = a
                        Else
                            DRWStokPerbulan("terima2") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If

            '''''''''''Terima Dari Unit Farmasi 3
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambilunit where kdbagian2='" & pkdapo & "' and kdbagian1='003' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSTerimaFar3 = New DataSet
            DA.Fill(DSTerimaFar3, "TerimaFar3")
            BDTerimaFar3.DataSource = DSTerimaFar3
            BDTerimaFar3.DataMember = "TerimaFar3"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWTerimaFar3 = BDTerimaFar3.Current
                    DRWStokPerbulan("terima3") = DSTerimaFar3.Tables("TerimaFar3").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("terima3")) Then
                        DRWStokPerbulan("terima3") = 0
                    Else
                        Dim a As Decimal
                        a = DSTerimaFar3.Tables("TerimaFar3").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("terima3") = a
                        Else
                            DRWStokPerbulan("terima3") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If

            '''''''''''Terima Dari Unit Farmasi 4
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambilunit where kdbagian2='" & pkdapo & "' and kdbagian1='004' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSTerimaFar4 = New DataSet
            DA.Fill(DSTerimaFar4, "TerimaFar4")
            BDTerimaFar4.DataSource = DSTerimaFar4
            BDTerimaFar4.DataMember = "TerimaFar4"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWTerimaFar4 = BDTerimaFar4.Current
                    DRWStokPerbulan("terima4") = DSTerimaFar4.Tables("TerimaFar4").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("terima4")) Then
                        DRWStokPerbulan("terima4") = 0
                    Else
                        Dim a As Decimal
                        a = DSTerimaFar4.Tables("TerimaFar4").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("terima4") = a
                        Else
                            DRWStokPerbulan("terima4") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If

            '''''''''''Terima Dari Unit Farmasi 5
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambilunit where kdbagian2='" & pkdapo & "' and kdbagian1='005' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSTerimaFar5 = New DataSet
            DA.Fill(DSTerimaFar5, "TerimaFar5")
            BDTerimaFar5.DataSource = DSTerimaFar5
            BDTerimaFar5.DataMember = "TerimaFar5"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWTerimaFar5 = BDTerimaFar5.Current
                    DRWStokPerbulan("terima5") = DSTerimaFar5.Tables("TerimaFar5").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("terima5")) Then
                        DRWStokPerbulan("terima5") = 0
                    Else
                        Dim a As Decimal
                        a = DSTerimaFar5.Tables("TerimaFar5").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("terima5") = a
                        Else
                            DRWStokPerbulan("terima5") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If

            '''''''''''Terima Dari Unit Farmasi 6
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambilunit where kdbagian2='" & pkdapo & "' and kdbagian1='006' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSTerimaFar6 = New DataSet
            DA.Fill(DSTerimaFar6, "TerimaFar6")
            BDTerimaFar6.DataSource = DSTerimaFar6
            BDTerimaFar6.DataMember = "TerimaFar6"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWTerimaFar6 = BDTerimaFar6.Current
                    DRWStokPerbulan("terima6") = DSTerimaFar6.Tables("TerimaFar6").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("terima6")) Then
                        DRWStokPerbulan("terima6") = 0
                    Else
                        Dim a As Decimal
                        a = DSTerimaFar6.Tables("TerimaFar6").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("terima6") = a
                        Else
                            DRWStokPerbulan("terima6") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If

            '''''''''''Terima Dari Unit Farmasi 7
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ambilunit where kdbagian2='" & pkdapo & "' and kdbagian1='007' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSTerimaFar7 = New DataSet
            DA.Fill(DSTerimaFar7, "TerimaFar7")
            BDTerimaFar7.DataSource = DSTerimaFar7
            BDTerimaFar7.DataMember = "TerimaFar7"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWTerimaFar7 = BDTerimaFar7.Current
                    DRWStokPerbulan("terima7") = DSTerimaFar7.Tables("TerimaFar7").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("terima7")) Then
                        DRWStokPerbulan("terima7") = 0
                    Else
                        Dim a As Decimal
                        a = DSTerimaFar7.Tables("TerimaFar7").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("terima7") = a
                        Else
                            DRWStokPerbulan("terima7") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If

            '''''''''''Retur Ke Gudang
            DA = New OleDb.OleDbDataAdapter("select RTRIM(LTRIM(kd_barang)) as kdbarang, jml from ap_ret_farmasi where kdbagian='" & pkdapo & "' and Month(tanggal)='" & Month(DTPBulan.Value) & "' and Year(tanggal)='" & Year(DTPTahun.Value) & "' order by kd_barang", CONN)
            DSReturGudang = New DataSet
            DA.Fill(DSReturGudang, "ReturGudang")
            BDReturGudang.DataSource = DSReturGudang
            BDReturGudang.DataMember = "ReturGudang"

            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWReturGudang = BDReturGudang.Current
                    DRWStokPerbulan("retgudang") = DSReturGudang.Tables("ReturGudang").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                    If IsDBNull(DRWStokPerbulan("retgudang")) Then
                        DRWStokPerbulan("retgudang") = 0
                    Else
                        Dim a As Decimal
                        a = DSReturGudang.Tables("ReturGudang").Compute("Sum(jml)", "kdbarang = '" & Trim(DRWStokPerbulan.Item("kdbarang").ToString) & "'")
                        a = a.ToString("0.00")
                        If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                            DRWStokPerbulan("retgudang") = a
                        Else
                            DRWStokPerbulan("retgudang") = a
                        End If
                    End If
                    BDStokPerbulan.MoveNext()
                Next
            End If

            ''''''''''Update Stok Barang Akhir
            BDStokPerbulan.Filter = ""
            If BDStokPerbulan.Count > 0 Then
                BDStokPerbulan.MoveFirst()
                For i = 1 To BDStokPerbulan.Count
                    DRWStokPerbulan = BDStokPerbulan.Current
                    DRWStokPerbulan("jmlstok") = Val(DRWStokPerbulan.Item("stokawal")) + Val(DRWStokPerbulan.Item("terimagdg")) + Val(DRWStokPerbulan.Item("terimaunt")) + Val(DRWStokPerbulan.Item("retcekout")) + Val(DRWStokPerbulan.Item("retinap")) + Val(DRWStokPerbulan.Item("kormasuk")) - Val(DRWStokPerbulan.Item("jualresep")) - Val(DRWStokPerbulan.Item("jualbebas")) - Val(DRWStokPerbulan.Item("mutasi")) - Val(DRWStokPerbulan.Item("korkel")) - Val(DRWStokPerbulan.Item("retgudang"))
                    DRWStokPerbulan("ttlmasuk") = Val(DRWStokPerbulan.Item("stokawal")) + Val(DRWStokPerbulan.Item("terimagdg")) + Val(DRWStokPerbulan.Item("terimaunt")) + Val(DRWStokPerbulan.Item("retcekout")) + Val(DRWStokPerbulan.Item("retinap")) + Val(DRWStokPerbulan.Item("kormasuk"))
                    DRWStokPerbulan("ttlkeluar") = Val(DRWStokPerbulan.Item("jualresep")) + Val(DRWStokPerbulan.Item("jualbebas")) + Val(DRWStokPerbulan.Item("mutasi")) + Val(DRWStokPerbulan.Item("korkel")) + Val(DRWStokPerbulan.Item("retgudang"))
                    DRWStokPerbulan("jmlharga") = Val(DRWStokPerbulan.Item("harga")) * Val(DRWStokPerbulan.Item("jmlstok"))
                    BDStokPerbulan.MoveNext()
                Next
            End If

            TabControlStok.Enabled = True
            BDStokPerbulan.Filter = ""
            gridObat.DataSource = Nothing
            gridObat.DataSource = BDStokPerbulan
            AturGriddetailBarang()
            MsgBox("Proses perhitungan selesai", vbInformation, "Informasi")
        Catch ex As Exception
            LoadingForm.Dispose()
            MsgBox(ex.Message)
            MsgBox("Proses perhitungan gagal. Silahkan ulangi lagi", vbInformation, "Informasi")
            btnProsesTab5.Enabled = True
            btnProsesTab5.Focus()
        End Try
    End Sub

    Sub ListJenisObat()
        CMD = New OleDb.OleDbCommand("select jns_obat, kd_jns_obat from Jenis_Obat where stsaktif='1' order by kd_jns_obat", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbJenisObat.Items.Clear()
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbJenisObat.Items.Add(DT.Rows(i)("jns_obat") & "|" & DT.Rows(i)("kd_jns_obat"))
        Next
        cmbJenisObat.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbJenisObat.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub


    Sub AturGriddetailBarang()
        With gridObat
            .Columns(0).HeaderText = "Jenis Barang"
            .Columns(1).HeaderText = "Nama Barang"
            .Columns(2).HeaderText = "Stok Awal"
            .Columns(2).DefaultCellStyle.Format = "N0"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).HeaderText = "Terima Dari GDG"
            .Columns(3).DefaultCellStyle.Format = "N0"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Terima Dari Far1"
            .Columns(4).DefaultCellStyle.Format = "N0"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "Terima Dari Far2"
            .Columns(5).DefaultCellStyle.Format = "N0"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).HeaderText = "Terima Dari Far3"
            .Columns(6).DefaultCellStyle.Format = "N0"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderText = "Terima Dari Far4"
            .Columns(7).DefaultCellStyle.Format = "N0"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).HeaderText = "Terima Dari Far5"
            .Columns(8).DefaultCellStyle.Format = "N0"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).HeaderText = "Terima Dari Far6"
            .Columns(9).DefaultCellStyle.Format = "N0"
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(10).HeaderText = "Terima Dari Far7"
            .Columns(10).DefaultCellStyle.Format = "N0"
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).HeaderText = "Total Terima Unit"
            .Columns(11).DefaultCellStyle.Format = "N0"
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(12).HeaderText = "Retur Dari Pasien"
            .Columns(12).DefaultCellStyle.Format = "N0"
            .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(13).HeaderText = "Retur Rwt Inap"
            .Columns(13).DefaultCellStyle.Format = "N0"
            .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(14).HeaderText = "Koreksi Masuk"
            .Columns(14).DefaultCellStyle.Format = "N0"
            .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(15).HeaderText = "Total Masuk"
            .Columns(15).DefaultCellStyle.Format = "N0"
            .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(16).HeaderText = "Jual Resep"
            .Columns(16).DefaultCellStyle.Format = "N0"
            .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(17).HeaderText = "Jual Bebas"
            .Columns(17).DefaultCellStyle.Format = "N0"
            .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(18).HeaderText = "Mutasi Ke Unit"
            .Columns(18).DefaultCellStyle.Format = "N0"
            .Columns(18).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(19).HeaderText = "Retur Ke Gudang"
            .Columns(19).DefaultCellStyle.Format = "N0"
            .Columns(19).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(20).HeaderText = "Koreksi Keluar"
            .Columns(20).DefaultCellStyle.Format = "N0"
            .Columns(20).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(21).HeaderText = "Total Keluar"
            .Columns(21).DefaultCellStyle.Format = "N0"
            .Columns(21).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(22).HeaderText = "Jumlah Stok"
            .Columns(22).DefaultCellStyle.Format = "N0"
            .Columns(22).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(23).HeaderText = "Nama Satuan"
            .Columns(24).HeaderText = "Harga Satuan"
            .Columns(24).DefaultCellStyle.Format = "N0"
            .Columns(24).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(25).HeaderText = "Jumlah Harga"
            .Columns(25).DefaultCellStyle.Format = "N0"
            .Columns(25).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(26).HeaderText = "Kode Barang"
            .Columns(0).Width = 120
            .Columns(1).Width = 200
            .Columns(2).Width = 50
            .Columns(3).Width = 50
            .Columns(4).Width = 50
            .Columns(5).Width = 50
            .Columns(6).Width = 50
            .Columns(7).Width = 50
            .Columns(8).Width = 50
            .Columns(9).Width = 50
            .Columns(10).Width = 50
            .Columns(11).Width = 50
            .Columns(12).Width = 50
            .Columns(13).Width = 50
            .Columns(14).Width = 50
            .Columns(15).Width = 50
            .Columns(16).Width = 50
            .Columns(17).Width = 50
            .Columns(18).Width = 50
            .Columns(19).Width = 50
            .Columns(20).Width = 50
            .Columns(21).Width = 50
            .Columns(22).Width = 50
            .Columns(23).Width = 75
            .Columns(24).Width = 80
            .Columns(25).Width = 100
            .Columns(27).Visible = False
            .ReadOnly = True
            GridWarna()
        End With
    End Sub

    Sub AturGridKecil()
        With gridObat
            .Columns(0).Width = 100
            .Columns(1).Width = 170
            .Columns(2).Width = 35
            .Columns(3).Width = 35
            .Columns(4).Width = 25
            .Columns(5).Width = 25
            .Columns(6).Width = 25
            .Columns(7).Width = 25
            .Columns(8).Width = 25
            .Columns(9).Width = 35
            .Columns(10).Width = 35
            .Columns(11).Width = 25
            .Columns(12).Width = 25
            .Columns(13).Width = 25
            .Columns(14).Width = 35
            .Columns(15).Width = 35
            .Columns(16).Width = 25
            .Columns(17).Width = 25
            .Columns(18).Width = 25
            .Columns(19).Width = 25
            .Columns(20).Width = 25
            .Columns(21).Width = 35
            .Columns(22).Width = 50
            .Columns(23).Width = 75
            .Columns(24).Width = 60
            .Columns(25).Width = 100
            .Columns(27).Visible = False
            .ReadOnly = True
            GridWarna()
        End With
    End Sub

    Sub GridWarna()
        For i As Integer = 0 To gridObat.RowCount - 1
            If Val(gridObat.Rows(i).Cells("jmlstok").Value) < 0 Then
                gridObat.Rows(i).Cells("nmbarang").Style.BackColor = Color.Aquamarine
            End If
        Next
    End Sub

    Sub TotalHarga()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridObat.RowCount - 1
            HitungTotal = HitungTotal + gridObat.Rows(baris).Cells("jmlharga").Value
        Next
        txtGrandTotal.DecimalValue = HitungTotal
    End Sub

    Private Sub FormStokPerbulan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormStokPerbulan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Kosongkan()
        ListJenisObat()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub btnProsesTab5_Click(sender As Object, e As EventArgs) Handles btnProsesTab5.Click
        'MsgBox(DTPBulan.Value)
        TampilStok1()
        TotalHarga()
        txtQty.DecimalValue = gridObat.Rows.Count() - 1
        DTPBulanAwal.Value = DTPBulan.Value
        DTPTahunAwal.Value = DTPTahun.Value
        DTPBulanTutup.Value = DateAdd("m", 1, DTPBulanAwal.Value)
        If Month(DTPBulanAwal.Value) = "12" Then
            DTPTahunTutup.Value = DateAdd("yyyy", 1, DTPTahunAwal.Value)
        Else
            DTPTahunTutup.Value = DTPTahunAwal.Value
        End If
    End Sub

    Private Sub txtNamaBarang_TextChanged(sender As Object, e As EventArgs) Handles txtNamaBarang.TextChanged
        BDStokPerbulan.Filter = "nmbarang like '%" & txtNamaBarang.Text & "%'"
        GridWarna()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If Button6.Text = "Rapatkan Tabel" Then
            AturGridKecil()
            Button6.Text = "Lebarkan Tabel"
        Else
            AturGriddetailBarang()
            Button6.Text = "Rapatkan Tabel"
        End If
    End Sub

    Private Sub btnUrutNama_Click(sender As Object, e As EventArgs) Handles btnUrutNama.Click
        cmbJenisObat.Text = ""
        BDStokPerbulan.RemoveFilter()
        BDStokPerbulan.Sort = "nmjenis, nmbarang"
        TotalHarga()
        GridWarna()
        txtQty.DecimalValue = gridObat.Rows.Count() - 1
    End Sub

    Private Sub btnStok0_Click(sender As Object, e As EventArgs) Handles btnStok0.Click
        cmbJenisObat.Text = ""
        BDStokPerbulan.RemoveFilter()
        BDStokPerbulan.Filter = "jmlstok < 0"
        TotalHarga()
        GridWarna()
        txtQty.DecimalValue = gridObat.Rows.Count() - 1
    End Sub

    Private Sub btnGerak_Click(sender As Object, e As EventArgs) Handles btnGerak.Click
        cmbJenisObat.Text = ""
        BDStokPerbulan.RemoveFilter()
        BDStokPerbulan.Filter = "stokawal > 0 OR terimagdg > 0 OR terimaunt > 0 OR retcekout > 0 OR retinap > 0 OR kormasuk > 0 OR  jualresep > 0 OR jualbebas > 0 OR mutasi > 0 OR retgudang > 0 OR korkel > 0 OR ttlkeluar > 0 OR jmlstok > 0"
        TotalHarga()
        GridWarna()
        txtQty.DecimalValue = gridObat.Rows.Count() - 1
    End Sub

    Private Sub btnTdkBergerak_Click(sender As Object, e As EventArgs) Handles btnTdkBergerak.Click
        cmbJenisObat.Text = ""
        BDStokPerbulan.RemoveFilter()
        BDStokPerbulan.Filter = "stokawal=0 AND terimagdg=0 AND terimaunt=0 AND retcekout=0 AND retinap=0 AND kormasuk=0 AND jualresep=0 AND jualbebas=0 AND mutasi=0 AND retgudang=0 AND korkel=0 AND ttlkeluar=0 AND jmlstok=0"
        TotalHarga()
        GridWarna()
        txtQty.DecimalValue = gridObat.Rows.Count() - 1
    End Sub

    Private Sub cmbJenisObat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisObat.SelectedIndexChanged
        cariJenisObat()
        BDStokPerbulan.RemoveFilter()
        BDStokPerbulan.Filter = "kdjenis = '" & kdJenisObat & "'"
        TotalHarga()
        GridWarna()
        txtQty.DecimalValue = gridObat.Rows.Count() - 1
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        FormPemanggil = "FormStokPerbulan_StokBarang1"
        Dim dtReport As New DataTable
        With dtReport
            .Columns.Add("nmjenis")
            .Columns.Add("nmbarang")
            .Columns.Add("stokawal")
            .Columns.Add("terimagdg")
            .Columns.Add("terimaunt")
            .Columns.Add("retcekout")
            .Columns.Add("retinap")
            .Columns.Add("kormasuk")
            .Columns.Add("jualresep")
            .Columns.Add("jualbebas")
            .Columns.Add("mutasi")
            .Columns.Add("retgudang")
            .Columns.Add("korkel")
            .Columns.Add("jmlstok")
            .Columns.Add("nmsatuan")
            .Columns.Add("harga")
            .Columns.Add("jmlharga")
        End With

        For i = 0 To gridObat.RowCount - 2
            If Not IsDBNull(gridObat.Rows(i).Cells(0).Value) Then
                dtReport.Rows.Add(gridObat.Rows(i).Cells("nmjenis").Value, gridObat.Rows(i).Cells("nmbarang").Value, gridObat.Rows(i).Cells("stokawal").Value, gridObat.Rows(i).Cells("terimagdg").Value, gridObat.Rows(i).Cells("terimaunt").Value, gridObat.Rows(i).Cells("retcekout").Value, gridObat.Rows(i).Cells("retinap").Value, gridObat.Rows(i).Cells("kormasuk").Value, gridObat.Rows(i).Cells("jualresep").Value, gridObat.Rows(i).Cells("jualbebas").Value, gridObat.Rows(i).Cells("mutasi").Value, gridObat.Rows(i).Cells("retgudang").Value, gridObat.Rows(i).Cells("korkel").Value, gridObat.Rows(i).Cells("jmlstok").Value, gridObat.Rows(i).Cells("nmsatuan").Value, gridObat.Rows(i).Cells("harga").Value, gridObat.Rows(i).Cells("jmlharga").Value)
            End If
        Next
        'For Each row As DataGridViewRow In gridObat.Rows
        '    Dim i = gridObat.CurrentRow.Index - 1
        '    If Not IsDBNull(gridObat.Rows(i).Cells(0).Value) Then
        '        dtReport.Rows.Add(row.Cells("nmjenis").Value, row.Cells("nmbarang").Value, row.Cells("stokawal").Value, row.Cells("terimagdg").Value, row.Cells("terimaunt").Value, row.Cells("retcekout").Value, row.Cells("retinap").Value, row.Cells("kormasuk").Value, row.Cells("jualresep").Value, row.Cells("jualbebas").Value, row.Cells("mutasi").Value, row.Cells("retgudang").Value, row.Cells("korkel").Value, row.Cells("jmlstok").Value, row.Cells("nmsatuan").Value, row.Cells("harga").Value, row.Cells("jmlharga").Value)
        '    End If
        'Next

        Dim str As String = Application.StartupPath & "\Report\StokBarang.rpt"
        rptdok.Load(str)
        'rptdok = New StokBarang
        rptdok.SetDataSource(dtReport)
        rptdok.SetParameterValue("pnmapo", pnmapo)
        rptdok.SetParameterValue("bulan", DTPBulan.Text)
        rptdok.SetParameterValue("tahun", DTPTahun.Text)
        FormCetak.CrystalReportViewer1.ReportSource = rptdok
        FormCetak.CrystalReportViewer1.Refresh()
        FormCetak.ShowDialog()
        FormCetak.ShowIcon = False
        'FormCetak.Dispose()
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtExcel As New DataTable
                With dtExcel
                    .Columns.Add("nmjenis")
                    .Columns.Add("nmbarang")
                    .Columns.Add("stokawal")
                    .Columns.Add("terimagdg")
                    .Columns.Add("terima1")
                    .Columns.Add("terima2")
                    .Columns.Add("terima3")
                    .Columns.Add("terima4")
                    .Columns.Add("terima5")
                    .Columns.Add("terima6")
                    .Columns.Add("terima7")
                    .Columns.Add("terimaunt")
                    .Columns.Add("retcekout")
                    .Columns.Add("retinap")
                    .Columns.Add("kormasuk")
                    .Columns.Add("ttlmasuk")
                    .Columns.Add("jualresep")
                    .Columns.Add("jualbebas")
                    .Columns.Add("mutasi")
                    .Columns.Add("retgudang")
                    .Columns.Add("korkel")
                    .Columns.Add("ttlkeluar")
                    .Columns.Add("jmlstok")
                    .Columns.Add("nmsatuan")
                    .Columns.Add("harga")
                    .Columns.Add("jmlharga")
                End With

                For i = 0 To gridObat.RowCount - 2
                    If Not IsDBNull(gridObat.Rows(i).Cells(0).Value) Then
                        dtExcel.Rows.Add(gridObat.Rows(i).Cells("nmjenis").Value, gridObat.Rows(i).Cells("nmbarang").Value, gridObat.Rows(i).Cells("stokawal").Value, gridObat.Rows(i).Cells("terimagdg").Value, gridObat.Rows(i).Cells("terima1").Value, gridObat.Rows(i).Cells("terima2").Value, gridObat.Rows(i).Cells("terima3").Value, gridObat.Rows(i).Cells("terima4").Value, gridObat.Rows(i).Cells("terima5").Value, gridObat.Rows(i).Cells("terima6").Value, gridObat.Rows(i).Cells("terima7").Value, gridObat.Rows(i).Cells("terimaunt").Value, gridObat.Rows(i).Cells("retcekout").Value, gridObat.Rows(i).Cells("retinap").Value, gridObat.Rows(i).Cells("kormasuk").Value, gridObat.Rows(i).Cells("ttlmasuk").Value, gridObat.Rows(i).Cells("jualresep").Value, gridObat.Rows(i).Cells("jualbebas").Value, gridObat.Rows(i).Cells("mutasi").Value, gridObat.Rows(i).Cells("retgudang").Value, gridObat.Rows(i).Cells("korkel").Value, gridObat.Rows(i).Cells("ttlkeluar").Value, gridObat.Rows(i).Cells("jmlstok").Value, gridObat.Rows(i).Cells("nmsatuan").Value, gridObat.Rows(i).Cells("harga").Value, gridObat.Rows(i).Cells("jmlharga").Value)
                    End If
                Next
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanStokOpnameXLSIO.xlsx")
                Dim sheet1 As IWorksheet = workbook.Worksheets(0)
                sheet1.Range("B7").Text = pnmapo
                sheet1.Range("B8").Text = DTPBulan.Text
                sheet1.Range("B9").Text = DTPTahun.Text
                Dim sheet2 As IWorksheet = workbook.Worksheets(1)
                sheet2.Range("B7").Text = pnmapo
                sheet2.Range("B8").Text = DTPBulan.Text
                sheet2.Range("B9").Text = DTPTahun.Text
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtExcel)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Stok Opname Unit.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Stok Opname Unit.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub Button5_Click_1(sender As Object, e As EventArgs) Handles Button5.Click
        FormPemanggil = "FormStokPerbulan_StokBarang2"
        Dim dtReport As New DataTable
        With dtReport
            .Columns.Add("nmjenis")
            .Columns.Add("nmbarang")
            .Columns.Add("jmlstok")
            .Columns.Add("nmsatuan")
            .Columns.Add("harga")
            .Columns.Add("jmlharga")
            .Columns.Add("kdbarang")
        End With

        For i = 0 To gridObat.RowCount - 2
            If Not IsDBNull(gridObat.Rows(i).Cells(0).Value) Then
                dtReport.Rows.Add(gridObat.Rows(i).Cells("nmjenis").Value, gridObat.Rows(i).Cells("nmbarang").Value, gridObat.Rows(i).Cells("jmlstok").Value, gridObat.Rows(i).Cells("nmsatuan").Value, gridObat.Rows(i).Cells("harga").Value, gridObat.Rows(i).Cells("jmlharga").Value, gridObat.Rows(i).Cells("kdbarang").Value)
            End If
        Next

        Dim str As String = Application.StartupPath & "\Report\CekStokBarang.rpt"
        rpt.Load(str)
        'rptdok = New StokBarang
        rpt.SetDataSource(dtReport)
        rpt.SetParameterValue("pnmapo", pnmapo)
        rpt.SetParameterValue("bulan", DTPBulan.Text)
        rpt.SetParameterValue("tahun", DTPTahun.Text)
        FormCetak.CrystalReportViewer1.ReportSource = rpt
        FormCetak.CrystalReportViewer1.Refresh()
        FormCetak.ShowDialog()
        FormCetak.ShowIcon = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtExcel As New DataTable
                With dtExcel
                    .Columns.Add("nmjenis")
                    .Columns.Add("nmbarang")
                    .Columns.Add("jmlstok")
                    .Columns.Add("nmsatuan")
                    .Columns.Add("harga")
                    .Columns.Add("jmlharga")
                    .Columns.Add("kdbarang")
                End With

                For i = 0 To gridObat.RowCount - 2
                    If Not IsDBNull(gridObat.Rows(i).Cells(0).Value) Then
                        dtExcel.Rows.Add(gridObat.Rows(i).Cells("nmjenis").Value, gridObat.Rows(i).Cells("nmbarang").Value, gridObat.Rows(i).Cells("jmlstok").Value, gridObat.Rows(i).Cells("nmsatuan").Value, gridObat.Rows(i).Cells("harga").Value, gridObat.Rows(i).Cells("jmlharga").Value, gridObat.Rows(i).Cells("kdbarang").Value)
                    End If
                Next
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanCekStokOpnameXLSIO.xlsx")
                Dim sheet1 As IWorksheet = workbook.Worksheets(0)
                sheet1.Range("B7").Text = pnmapo
                sheet1.Range("B8").Text = DTPBulan.Text
                sheet1.Range("B9").Text = DTPTahun.Text
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtExcel)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Cek Stok Opname Unit.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Cek Stok Opname Unit.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub DTPTahun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTahun.KeyPress
        If e.KeyChar = Chr(13) Then
            btnProsesTab5.Focus()
        End If
    End Sub

    Private Sub btnBaruTab5_Click(sender As Object, e As EventArgs) Handles btnBaruTab5.Click
        Kosongkan()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnUpdateStok.Click
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
        If MessageBox.Show("Apakah stok barang akan diupdate?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            TampilStok1()
            Dim sqlUpdateStokBarang As String = ""
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            btnUpdateStok.Enabled = False
            Try
                BDStokPerbulan.RemoveFilter()
                GridWarna()
                For i = 0 To gridObat.RowCount - 2
                    sqlUpdateStokBarang = sqlUpdateStokBarang + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & Val(gridObat.Rows(i).Cells("jmlstok").Value) & " WHERE kd_barang='" & Trim(gridObat.Rows(i).Cells("kdbarang").Value) & "'"
                Next
                'CMD = New OleDb.OleDbCommand(sqlUpdateStokBarang, CONN)
                'CMD.ExecuteNonQuery()
                CMD.CommandText = sqlUpdateStokBarang
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Proses update stok berhasil", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox(" Commit Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                MsgBox("Proses update stok gagal, silahkan ulangi lagi")
                btnUpdateStok.Enabled = True
                Try
                    Trans.Rollback()
                Catch ex2 As Exception
                    MsgBox(" Rollback Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                    MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                    MsgBox("Proses update stok gagal, silahkan ulangi lagi")
                    btnUpdateStok.Enabled = True
                End Try
            End Try
        End If
    End Sub

    Private Sub btnTutupStok_Click(sender As Object, e As EventArgs) Handles btnTutupStok.Click
        CMD = New OleDb.OleDbCommand("SELECT kdbagian,bulan,tahun FROM ap_stok_awalapo WHERE kdbagian='" & pkdapo & "' and bulan='" & Month(DTPBulanTutup.Value) & "' and tahun='" & Year(DTPTahunTutup.Value) & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            MsgBox("Tutup stok tidak bisa dilakukan" & vbCrLf & "Bulan dan tahun tersebut sudah ada dalam file stok awal", vbCritical, "Kesalahan")
            Exit Sub
        End If
        BDStokPerbulan.RemoveFilter()
        BDStokPerbulan.Filter = "jmlstok < 0"
        GridWarna()

        Try
            If BDStokPerbulan.Count > 0 Then
                MsgBox("Proses tutup stok tidak dapat dilakukan" & vbCrLf & "Masih ada stok yang minus", vbCritical, "Kesalahan")
                Exit Sub
            End If

            If MessageBox.Show("Apakah data sudah benar untuk tutup stok?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim sqlTutupStokBarang As String = ""
                Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
                CMD.Connection = CONN
                CMD.Transaction = Trans
                btnTutupStok.Enabled = False
                BDStokPerbulan.RemoveFilter()
                BDStokPerbulan.Filter = "jmlstok > 0"
                For i = 0 To gridObat.RowCount - 2
                    sqlTutupStokBarang = sqlTutupStokBarang + vbCrLf + "insert into ap_stok_awalapo(kdbagian,nmbagian,bulan,tahun,kd_barang,idx_barang,nama_barang,harga,jml,nmsatuan,jmlharga)values('" & pkdapo & "', '" & pnmapo & "','" & Month(DTPBulanTutup.Value) & "', '" & Year(DTPTahunTutup.Value) & "', '" & gridObat.Rows(i).Cells("kdbarang").Value & "','0', '" & Rep(gridObat.Rows(i).Cells("nmbarang").Value) & "', '" & Val(gridObat.Rows(i).Cells("harga").Value) & "', '" & Val(gridObat.Rows(i).Cells("jmlstok").Value) & "', '" & gridObat.Rows(i).Cells("nmsatuan").Value & "', '" & Val(gridObat.Rows(i).Cells("jmlharga").Value) & "')"
                Next
                CMD.CommandText = sqlTutupStokBarang
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Tutup stok berhasil dilakukan", vbInformation, "Informasi")
            End If
        Catch ex As Exception
            MsgBox(" Commit Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
            MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
            Try
                Trans.Rollback()
            Catch ex2 As Exception
                MsgBox(" Rollback Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                MsgBox("Proses tutup stok gagal, silahkan ulangi lagi")
                btnTutupStok.Enabled = True
            End Try
        End Try
    End Sub

    Private Sub btnStok1_Click(sender As Object, e As EventArgs) Handles btnStok1.Click
        cmbJenisObat.Text = ""
        BDStokPerbulan.RemoveFilter()
        BDStokPerbulan.Filter = "jmlstok > 0"
        TotalHarga()
        GridWarna()
        txtQty.DecimalValue = gridObat.Rows.Count() - 1
    End Sub
End Class