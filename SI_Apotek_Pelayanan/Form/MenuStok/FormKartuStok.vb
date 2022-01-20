Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports Syncfusion.XlsIO

Public Class FormKartuStok
    Inherits Office2010Form

    Public rpt As New ReportDocument
    Dim Trans As OleDb.OleDbTransaction
    Dim saldoAwal As Decimal
    Dim Stok, memStok As String
    Dim BDKartuStok, BDDataBarang, BDTerimaGudang, BDJualBebas, BDJualResep, BDKoreksiTambah, BDKoreksiKurang, BDReturJual, BDReturRawatInap, BDMutasi, BDTerimaUnit, BDReturGudang As New BindingSource
    Dim DSKartuStok, DSTerimaGudang, DSJualBebas, DSJualResep, DSKoreksiTambah, DSKoreksiKurang, DSReturJual, DSReturRawatInap, DSMutasi, DSTerimaUnit, DSReturGudang As New DataSet
    Dim DRWKartuStok, DRWTerimaGudang, DRWJualBebas, DRWJualResep, DRWKoreksiTambah, DRWKoreksiKurang, DRWReturJual, DRWReturRawatInap, DRWMutasi, DRWTerimaUnit, DRWReturGudang As DataRowView

    Sub Kosongkan()
        TglServer()
        DTPBulan.Value = Format(TanggalServer, "1-MMMM-yyyy")
        DTPTahun.Value = TanggalServer
        DSKartuStok = Table.BuatTabelKartuStok("KartuStok")
        gridSaldo.BackgroundColor = Color.Azure
        gridSaldo.DataSource = Nothing
        DSKartuStok.Clear()
        txtKodeObat.Clear()
        txtNamaObat.Clear()
        txtSatuan.Clear()
        txtSaldoAwal.DecimalValue = 0
        txtSaldoAkhir.DecimalValue = 0
        txtMasuk.DecimalValue = 0
        txtKeluar.DecimalValue = 0
        btnProses.Enabled = True
        btnBaru.Enabled = False
        btnExcel.Enabled = False
        btnPreview.Enabled = False
        btnUpdateStok.Enabled = False
        DTPBulan.Focus()
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
            DA = New OleDb.OleDbDataAdapter("select idx_barang,kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from barang_farmasi WHERE stsaktif ='1' order by kd_barang", CONN)
            'DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", 
            '    LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan 
            '    from Barang_Farmasi WHERE stsaktif ='1' AND " & Stok & "> 0 order by nama_barang", CONN)
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

    Sub TotalMasuk()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridSaldo.RowCount - 1
            HitungTotal = HitungTotal + gridSaldo.Rows(baris).Cells("masukqty").Value
        Next
        txtMasuk.DecimalValue = HitungTotal
    End Sub

    Sub TotalKeluar()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridSaldo.RowCount - 1
            HitungTotal = HitungTotal + gridSaldo.Rows(baris).Cells("keluarqty").Value
        Next
        txtKeluar.DecimalValue = HitungTotal
    End Sub

    Sub tampilKartu1()
        btnProses.Enabled = False
        Try
            BDKartuStok.DataSource = DSKartuStok
            BDKartuStok.DataMember = "KartuStok"
            '''''''''''terima dari gudang
            DA = New OleDb.OleDbDataAdapter("select nota, tanggal, kd_barang, kdbagian, nmbagian, jml from ap_ambil where kdbagian='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal", CONN)
            DSTerimaGudang = New DataSet
            DA.Fill(DSTerimaGudang, "TerimaGudang")
            BDTerimaGudang.DataSource = DSTerimaGudang
            BDTerimaGudang.DataMember = "TerimaGudang"

            If BDTerimaGudang.Count > 0 Then
                BDTerimaGudang.MoveFirst()
                For i = 1 To BDTerimaGudang.Count
                    DRWTerimaGudang = BDTerimaGudang.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWTerimaGudang.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWTerimaGudang.Item("tanggal")
                    DRWKartuStok("nonota") = "NOTA : " & Trim(DRWTerimaGudang.Item("nota"))
                    DRWKartuStok("keterangan") = "Penerimaan dari gudang ke " & Trim(DRWTerimaGudang.Item("nmbagian"))
                    DRWKartuStok("masukqty") = DRWTerimaGudang.Item("jml")
                    DRWKartuStok("keluarqty") = 0
                    BDKartuStok.EndEdit()
                    BDTerimaGudang.MoveNext()
                Next
            End If

            '''''''''''Jual Bebas
            DA = New OleDb.OleDbDataAdapter("select nota,tanggal,kd_barang,kdbagian,nmbagian,jml,nama from ap_jualbbs2 where kdbagian='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "'  order by tanggal", CONN)
            DSJualBebas = New DataSet
            DA.Fill(DSJualBebas, "JualBebas")
            BDJualBebas.DataSource = DSJualBebas
            BDJualBebas.DataMember = "JualBebas"

            If BDJualBebas.Count > 0 Then
                BDJualBebas.MoveFirst()
                For i = 1 To BDJualBebas.Count
                    DRWJualBebas = BDJualBebas.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWJualBebas.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWJualBebas.Item("tanggal")
                    DRWKartuStok("nonota") = "NOTA : " & Trim(DRWJualBebas.Item("nota"))
                    DRWKartuStok("keterangan") = "Jual Bebas/ Non Resep " & Trim(DRWJualBebas.Item("nama"))
                    DRWKartuStok("masukqty") = 0
                    DRWKartuStok("keluarqty") = DRWJualBebas.Item("jml")
                    BDKartuStok.EndEdit()
                    BDJualBebas.MoveNext()
                Next
            End If

            '''''''''''Jual Resep
            DA = New OleDb.OleDbDataAdapter("select notaresep,tanggal,kd_barang,kdbagian,jml,nmpasien from ap_jualr2 where kdbagian='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal", CONN)
            DSJualResep = New DataSet
            DA.Fill(DSJualResep, "JualResep")
            BDJualResep.DataSource = DSJualResep
            BDJualResep.DataMember = "JualResep"

            If BDJualResep.Count > 0 Then
                BDJualResep.MoveFirst()
                For i = 1 To BDJualResep.Count
                    DRWJualResep = BDJualResep.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWJualResep.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWJualResep.Item("tanggal")
                    DRWKartuStok("nonota") = "NOTA : " & Trim(DRWJualResep.Item("notaresep"))
                    DRWKartuStok("keterangan") = "Jual Resep " & Trim(DRWJualResep.Item("nmpasien"))
                    DRWKartuStok("masukqty") = 0
                    DRWKartuStok("keluarqty") = DRWJualResep.Item("jml")
                    BDKartuStok.EndEdit()
                    BDJualResep.MoveNext()
                Next
            End If

            '''''''''''Koreksi Tambah
            DA = New OleDb.OleDbDataAdapter("select kdbagian,nokoreksi,tanggal,kd_barang,jml,keterangan from ap_koreksiapo_tambah where kdbagian='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal", CONN)
            DSKoreksiTambah = New DataSet
            DA.Fill(DSKoreksiTambah, "KoreksiTambah")
            BDKoreksiTambah.DataSource = DSKoreksiTambah
            BDKoreksiTambah.DataMember = "KoreksiTambah"

            If BDKoreksiTambah.Count > 0 Then
                BDKoreksiTambah.MoveFirst()
                For i = 1 To BDKoreksiTambah.Count
                    DRWKoreksiTambah = BDKoreksiTambah.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWKoreksiTambah.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWKoreksiTambah.Item("tanggal")
                    DRWKartuStok("nonota") = "NOTA : " & Trim(DRWKoreksiTambah.Item("nokoreksi"))
                    DRWKartuStok("keterangan") = "Koreksi Tambah " & Trim(DRWKoreksiTambah.Item("keterangan"))
                    DRWKartuStok("masukqty") = DRWKoreksiTambah.Item("jml")
                    DRWKartuStok("keluarqty") = 0
                    BDKartuStok.EndEdit()
                    BDKoreksiTambah.MoveNext()
                Next
            End If

            '''''''''''Koreksi Pengurangan
            DA = New OleDb.OleDbDataAdapter("select kdbagian,nokoreksi,tanggal,kd_barang,jml,keterangan from ap_koreksiapo_kurang where kdbagian='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal", CONN)
            DSKoreksiKurang = New DataSet
            DA.Fill(DSKoreksiKurang, "KoreksiKurang")
            BDKoreksiKurang.DataSource = DSKoreksiKurang
            BDKoreksiKurang.DataMember = "KoreksiKurang"

            If BDKoreksiKurang.Count > 0 Then
                BDKoreksiKurang.MoveFirst()
                For i = 1 To BDKoreksiKurang.Count
                    DRWKoreksiKurang = BDKoreksiKurang.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWKoreksiKurang.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWKoreksiKurang.Item("tanggal")
                    DRWKartuStok("nonota") = "NOTA : " & Trim(DRWKoreksiKurang.Item("nokoreksi"))
                    DRWKartuStok("keterangan") = "Koreksi Kurang " & Trim(DRWKoreksiKurang.Item("keterangan"))
                    DRWKartuStok("masukqty") = 0
                    DRWKartuStok("keluarqty") = DRWKoreksiKurang.Item("jml")
                    BDKartuStok.EndEdit()
                    BDKoreksiKurang.MoveNext()
                Next
            End If

            '''''''''''Retur Jual
            DA = New OleDb.OleDbDataAdapter("select kd_bagian,no_reg,tanggal,kd_barang,total_qty, nama_pasien from ap_retur_detail where kd_bagian='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal", CONN)
            DSReturJual = New DataSet
            DA.Fill(DSReturJual, "ReturJual")
            BDReturJual.DataSource = DSReturJual
            BDReturJual.DataMember = "ReturJual"

            If BDReturJual.Count > 0 Then
                BDReturJual.MoveFirst()
                For i = 1 To BDReturJual.Count
                    DRWReturJual = BDReturJual.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWReturJual.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWReturJual.Item("tanggal")
                    DRWKartuStok("nonota") = "NOREG : " & Trim(DRWReturJual.Item("no_reg"))
                    DRWKartuStok("keterangan") = "Retur Rawat Jalan | " & DRWReturJual.Item("nama_pasien")
                    DRWKartuStok("masukqty") = DRWReturJual.Item("total_qty")
                    DRWKartuStok("keluarqty") = 0
                    BDKartuStok.EndEdit()
                    BDReturJual.MoveNext()
                Next
            End If

            '''''''''''Retur Rawat Inap
            DA = New OleDb.OleDbDataAdapter("select kdbagian,no_reg,tanggal,kd_barang,totalqty from ap_returinap2 where kdbagian='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal", CONN)
            DSReturRawatInap = New DataSet
            DA.Fill(DSReturRawatInap, "ReturRawatInap")
            BDReturRawatInap.DataSource = DSReturRawatInap
            BDReturRawatInap.DataMember = "ReturRawatInap"

            If BDReturRawatInap.Count > 0 Then
                BDReturRawatInap.MoveFirst()
                For i = 1 To BDReturRawatInap.Count
                    DRWReturRawatInap = BDReturRawatInap.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWReturRawatInap.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWReturRawatInap.Item("tanggal")
                    DRWKartuStok("nonota") = "NOREG : " & Trim(DRWReturRawatInap.Item("no_reg"))
                    DRWKartuStok("keterangan") = "Retur Rawat Inap"
                    DRWKartuStok("masukqty") = DRWReturRawatInap.Item("totalqty")
                    DRWKartuStok("keluarqty") = 0
                    BDKartuStok.EndEdit()
                    BDReturRawatInap.MoveNext()
                Next
            End If

            '''''''''''Mutasi ke Unit
            DA = New OleDb.OleDbDataAdapter("select kdbagian,kdbagian1,nmbagian1, kdbagian2, nmbagian2,tanggal,kd_barang,jml from ap_ambilunit where kdbagian1='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal", CONN)
            DSMutasi = New DataSet
            DA.Fill(DSMutasi, "Mutasi")
            BDMutasi.DataSource = DSMutasi
            BDMutasi.DataMember = "Mutasi"

            If BDMutasi.Count > 0 Then
                BDMutasi.MoveFirst()
                For i = 1 To BDMutasi.Count
                    DRWMutasi = BDMutasi.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWMutasi.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWMutasi.Item("tanggal")
                    DRWKartuStok("nonota") = "Mutasi dari " & Trim(DRWMutasi.Item("nmbagian1"))
                    DRWKartuStok("keterangan") = "Mutasi ke " & Trim(DRWMutasi.Item("nmbagian2"))
                    DRWKartuStok("masukqty") = 0
                    DRWKartuStok("keluarqty") = DRWMutasi.Item("jml")
                    BDKartuStok.EndEdit()
                    BDMutasi.MoveNext()
                Next
            End If

            '''''''''''Terima Unit
            DA = New OleDb.OleDbDataAdapter("select kdbagian,kdbagian1,nmbagian1, kdbagian2, nmbagian2,tanggal,kd_barang,jml from ap_ambilunit where kdbagian2='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal", CONN)
            DSTerimaUnit = New DataSet
            DA.Fill(DSTerimaUnit, "TerimaUnit")
            BDTerimaUnit.DataSource = DSTerimaUnit
            BDTerimaUnit.DataMember = "TerimaUnit"

            If BDTerimaUnit.Count > 0 Then
                BDTerimaUnit.MoveFirst()
                For i = 1 To BDTerimaUnit.Count
                    DRWTerimaUnit = BDTerimaUnit.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWTerimaUnit.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWTerimaUnit.Item("tanggal")
                    DRWKartuStok("nonota") = "Mutasi dari " & Trim(DRWTerimaUnit.Item("nmbagian1"))
                    DRWKartuStok("keterangan") = "Mutasi ke " & Trim(DRWTerimaUnit.Item("nmbagian2"))
                    DRWKartuStok("masukqty") = DRWTerimaUnit.Item("jml")
                    DRWKartuStok("keluarqty") = 0
                    BDKartuStok.EndEdit()
                    BDTerimaUnit.MoveNext()
                Next
            End If

            '''''''''''Retur Ke Gudang
            DA = New OleDb.OleDbDataAdapter("select nota,tanggal,kd_barang,jml from ap_ret_farmasi where kdbagian='" & pkdapo & "' and MONTH(tanggal)='" & Month(DTPBulan.Value) & "' and YEAR(tanggal)='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "' order by tanggal", CONN)
            DSReturGudang = New DataSet
            DA.Fill(DSReturGudang, "ReturGudang")
            BDReturGudang.DataSource = DSReturGudang
            BDReturGudang.DataMember = "ReturGudang"

            If BDReturGudang.Count > 0 Then
                BDReturGudang.MoveFirst()
                For i = 1 To BDReturGudang.Count
                    DRWReturGudang = BDReturGudang.Current
                    BDKartuStok.AddNew()
                    DRWKartuStok = BDKartuStok.Current
                    DRWKartuStok("kdbarang") = DRWReturGudang.Item("kd_barang")
                    DRWKartuStok("tanggal") = DRWReturGudang.Item("tanggal")
                    DRWKartuStok("nonota") = "Nota " & Trim(DRWReturGudang.Item("nota"))
                    DRWKartuStok("keterangan") = "Retur ke Gudang Farmasi"
                    DRWKartuStok("masukqty") = 0
                    DRWKartuStok("keluarqty") = DRWReturGudang.Item("jml")
                    BDKartuStok.EndEdit()
                    BDReturGudang.MoveNext()
                Next
            End If

            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            CMD = New OleDb.OleDbCommand("select jml from ap_stok_awalapo where kdbagian='" & pkdapo & "' and bulan='" & Month(DTPBulan.Value) & "' and tahun='" & Year(DTPTahun.Value) & "' and kd_barang='" & Trim(txtKodeObat.Text) & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                saldoAwal = DT.Rows(0).Item("jml")
            Else
                saldoAwal = 0
            End If
            txtSaldoAwal.DecimalValue = saldoAwal

            BDKartuStok.RemoveFilter()
            BDKartuStok.Sort = "tanggal"
            If BDKartuStok.Count > 0 Then
                BDKartuStok.MoveFirst()
                For i = 1 To BDKartuStok.Count
                    DRWKartuStok = BDKartuStok.Current
                    saldoAwal = Val(saldoAwal) + Val(DRWKartuStok.Item("masukqty")) - Val(DRWKartuStok.Item("keluarqty"))
                    DRWKartuStok("saldo") = saldoAwal
                    BDKartuStok.EndEdit()
                    BDKartuStok.MoveNext()
                Next
            End If

            gridSaldo.DataSource = Nothing
            gridSaldo.DataSource = BDKartuStok
            TotalKeluar()
            TotalMasuk()
            txtSaldoAkhir.DecimalValue = txtSaldoAwal.DecimalValue + (txtMasuk.DecimalValue - txtKeluar.DecimalValue)
            AturGrid()
            MsgBox("Proses selesai", vbInformation, "Informasi")
            btnBaru.Enabled = True
            btnExcel.Enabled = True
            btnUpdateStok.Enabled = True
            btnPreview.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Proses gagal, silahkan ulangi lagi", vbInformation, "Informasi")
            btnProses.Enabled = True
            btnProses.Focus()
        End Try
    End Sub

    Sub AturGrid()
        With gridSaldo
            .Columns(0).HeaderText = "Kode Barang"
            .Columns(1).HeaderText = "Tanggal"
            .Columns(2).HeaderText = "Nomor Faktur - Nota"
            .Columns(3).HeaderText = "Nama Unit / Nama Transaksi"
            .Columns(4).HeaderText = "Masuk Qty"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "Keluar Qty"
            .Columns(5).DefaultCellStyle.Format = "N2"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).HeaderText = "Saldo"
            .Columns(6).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).DefaultCellStyle.BackColor = Color.LightYellow
            .Columns(0).Width = 120
            .Columns(1).Width = 75
            .Columns(2).Width = 150
            .Columns(3).Width = 250
            .Columns(4).Width = 65
            .Columns(5).Width = 65
            .Columns(6).Width = 65
            .Columns(0).Visible = False
            .ReadOnly = True

            For i As Integer = 0 To gridSaldo.RowCount - 1
                If Val(gridSaldo.Rows(i).Cells("masukqty").Value) > 0 Then
                    gridSaldo.Rows(i).Cells("tanggal").Style.ForeColor = Color.Red
                    gridSaldo.Rows(i).Cells("nonota").Style.ForeColor = Color.Red
                    gridSaldo.Rows(i).Cells("keterangan").Style.ForeColor = Color.Red
                    gridSaldo.Rows(i).Cells("masukqty").Style.ForeColor = Color.Red
                    gridSaldo.Rows(i).Cells("keluarqty").Style.ForeColor = Color.Red
                    'gridSaldo.Rows(i).Cells("saldo").Style.ForeColor = Color.Red
                End If
            Next

        End With
    End Sub


    Private Sub FormKartuStok_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormKartuStok_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Kosongkan()
    End Sub

    Private Sub FormKartuStok_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelObat.Top = txtKodeObat.Top + 22
        PanelObat.Left = txtKodeObat.Left + 0
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
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

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                txtKodeObat.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                txtNamaObat.Text = gridBarang.Rows(e.RowIndex).Cells(3).Value
                txtSatuan.Text = gridBarang.Rows(e.RowIndex).Cells(5).Value
                PanelObat.Visible = False
                btnProses.Focus()
            End If
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                txtKodeObat.Text = gridBarang.Rows(i).Cells(2).Value
                txtNamaObat.Text = gridBarang.Rows(i).Cells(3).Value
                txtSatuan.Text = gridBarang.Rows(i).Cells(5).Value
                PanelObat.Visible = False
                btnProses.Focus()
            End If
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        If txtKodeObat.Text = "" Then
            MsgBox("Obat belum dipilih", vbCritical, "Kesalahan")
            txtKodeObat.Focus()
            Exit Sub
        End If
        tampilKartu1()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Kosongkan()
    End Sub

    Private Sub DTPBulan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPBulan.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPTahun.Focus()
        End If
    End Sub

    Private Sub DTPTahun_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTahun.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKodeObat.Focus()
        End If
    End Sub

    Private Sub btnPreview_Click(sender As Object, e As EventArgs) Handles btnPreview.Click
        FormPemanggil = "FormKartuStok"
        Dim dtReport As New DataTable
        With dtReport
            .Columns.Add("kdbarang")
            .Columns.Add("tanggal")
            .Columns.Add("nonota")
            .Columns.Add("keterangan")
            .Columns.Add("masukqty")
            .Columns.Add("keluarqty")
            .Columns.Add("saldo")
        End With

        For i = 0 To gridSaldo.RowCount - 2
            If Not IsDBNull(gridSaldo.Rows(i).Cells(0).Value) Then
                dtReport.Rows.Add(gridSaldo.Rows(i).Cells("kdbarang").Value, Format(gridSaldo.Rows(i).Cells("tanggal").Value, "dd/MM/yyyy"), gridSaldo.Rows(i).Cells("nonota").Value, gridSaldo.Rows(i).Cells("keterangan").Value, gridSaldo.Rows(i).Cells("masukqty").Value, gridSaldo.Rows(i).Cells("keluarqty").Value, gridSaldo.Rows(i).Cells("saldo").Value)
            End If
        Next

        Dim str As String = Application.StartupPath & "\Report\KartuStokBarang.rpt"
        rpt.Load(str)
        'rptdok = New StokBarang
        rpt.SetDataSource(dtReport)
        rpt.SetParameterValue("pnmapo", pnmapo)
        rpt.SetParameterValue("bulan", DTPBulan.Text)
        rpt.SetParameterValue("tahun", DTPTahun.Text)
        rpt.SetParameterValue("namabarang", Trim(txtNamaObat.Text))
        rpt.SetParameterValue("satuan", Trim(txtSatuan.Text))
        rpt.SetParameterValue("stokawal", txtSaldoAwal.DecimalValue)
        rpt.SetParameterValue("stokakhir", txtSaldoAkhir.DecimalValue)
        FormCetak.CrystalReportViewer1.ReportSource = rpt
        FormCetak.CrystalReportViewer1.Refresh()
        FormCetak.ShowDialog()
        FormCetak.ShowIcon = False
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtExcel As New DataTable
                With dtExcel
                    .Columns.Add("kdbarang")
                    .Columns.Add("tanggal")
                    .Columns.Add("nonota")
                    .Columns.Add("keterangan")
                    .Columns.Add("masukqty")
                    .Columns.Add("keluarqty")
                    .Columns.Add("saldo")
                End With

                For i = 0 To gridSaldo.RowCount - 2
                    If Not IsDBNull(gridSaldo.Rows(i).Cells(0).Value) Then
                        dtExcel.Rows.Add(gridSaldo.Rows(i).Cells("kdbarang").Value, Format(gridSaldo.Rows(i).Cells("tanggal").Value, "dd/MM/yyyy"), gridSaldo.Rows(i).Cells("nonota").Value, gridSaldo.Rows(i).Cells("keterangan").Value, gridSaldo.Rows(i).Cells("masukqty").Value, gridSaldo.Rows(i).Cells("keluarqty").Value, gridSaldo.Rows(i).Cells("saldo").Value)
                    End If
                Next

                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\KartuStokBarangXLSIO.xlsx")
                Dim sheet1 As IWorksheet = workbook.Worksheets(0)
                sheet1.Range("B7").Text = pnmapo
                sheet1.Range("B8").Text = DTPBulan.Text
                sheet1.Range("B9").Text = DTPTahun.Text
                sheet1.Range("B10").Text = Trim(txtKodeObat.Text)
                sheet1.Range("B11").Text = Trim(txtNamaObat.Text)
                sheet1.Range("B12").Text = Trim(txtSatuan.Text)
                sheet1.Range("F12").Text = txtSaldoAwal.DecimalValue
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtExcel)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Kartu Stok Barang.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Kartu Stok Barang.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnUpdateStok_Click(sender As Object, e As EventArgs) Handles btnUpdateStok.Click
        If MessageBox.Show("Apakah " & Trim(txtNamaObat.Text) & " akan diupdate stok menjadi " & txtSaldoAkhir.Text & "?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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
                Exit Sub
            End If
            Dim sqlUpdateStokBarang As String = ""
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                'sqlUpdateStokBarang = Month(DTPBulan.Value) + 1
                sqlUpdateStokBarang = sqlUpdateStokBarang + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & Num_En_US(txtSaldoAkhir.DecimalValue) & " WHERE kd_barang='" & Trim(txtKodeObat.Text) & "'"
                sqlUpdateStokBarang = sqlUpdateStokBarang + vbCrLf + "UPDATE ap_stok_awalapo SET jml=" & Num_En_US(txtSaldoAkhir.DecimalValue) & " WHERE kd_barang='" & Trim(txtKodeObat.Text) & "' AND kdbagian='" & pkdapo & "' AND bulan='" & Month(DTPBulan.Value) + 1 & "' AND tahun='" & Year(DTPTahun.Value) & "'"
                'CMD = New OleDb.OleDbCommand(sqlUpdateStokBarang, CONN)
                CMD.CommandText = sqlUpdateStokBarang
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Berhasil diupdate", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If
    End Sub

    Private Sub DTPBantu_ValueChanged(sender As Object, e As EventArgs)

    End Sub
End Class