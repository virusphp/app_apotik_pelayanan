Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports Syncfusion.XlsIO

Public Class FormLaporanDetailPenjualanObatBebas
    Inherits Office2010Form
    Dim nmBagianTab2, nmBagianTab1, kdBagianTab2, kdBagianTab1, Stok, kdBagianTab3, nmBagianTab3, kdDokter, namaDokter As String
    Dim BDPertanggal, BDDataBarang, BDPerbarang, BDPerDokter As New BindingSource

    Sub Kosongkan1()
        TglServer()
        cmbBagianTab1.Text = ""
        DTPTanggalAwalTab1.Value = TanggalServer
        DTPTanggalAkhirTab1.Value = TanggalServer
        GridTab1.BackgroundColor = Color.Azure
        GridTab1.DataSource = Nothing
        txtJumlahHarga1Tab1.DecimalValue = 0
        txtPotonganTab1.DecimalValue = 0
        txtJumlahHarga2Tab1.DecimalValue = 0
        txtPembulatanTab1.DecimalValue = 0
        txtJumlahHargaJualTab1.DecimalValue = 0
        txtNamaPasien.Enabled = False
        txtNamaPasien.Clear()
        cmbDiserahkan.Enabled = False
        cmbDiserahkan.Text = ""
        cmbBagianTab1.Focus()
    End Sub

    Sub Kosongkan2()
        TglServer()
        cmbBagianTab2.Text = ""
        DTPTanggalAwalTab2.Value = TanggalServer
        DTPTanggalAkhirTab2.Value = TanggalServer
        GridTab2.BackgroundColor = Color.Azure
        GridTab2.DataSource = Nothing
        txtJumlahHarga1Tab2.DecimalValue = 0
        txtPotonganTab2.DecimalValue = 0
        txtJumlahHarga2Tab2.DecimalValue = 0
        txtPembulatanTab2.DecimalValue = 0
        txtJumlahHargaJualTab2.DecimalValue = 0
        txtKodeBarangTab2.Clear()
        txtNamaBarangTab2.Clear()
        cmbBagianTab2.Focus()
    End Sub

    Sub Kosongkan3()
        TglServer()
        cmbBagianTab3.Text = ""
        DTPTanggalAwalTab3.Value = TanggalServer
        DTPTanggalAkhirTab3.Value = TanggalServer
        gridTab3.BackgroundColor = Color.Azure
        gridTab3.DataSource = Nothing
        txtJumlahHarga1Tab3.DecimalValue = 0
        txtPotonganTab3.DecimalValue = 0
        txtJumlahHarga2Tab3.DecimalValue = 0
        txtPembulatanTab3.DecimalValue = 0
        txtJumlahHargaJualTab3.DecimalValue = 0
        cmbDokter.Text = ""
        cmbBagianTab3.Focus()
    End Sub

    Sub ListBagian()
        'konek()
        CMD = New OleDb.OleDbCommand("select kdbagian, nmbagian from ap_bagian where Status_Apotik=1 order by kdbagian", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbBagianTab1.Items.Clear()
        cmbBagianTab1.Items.Add("")
        cmbBagianTab2.Items.Clear()
        cmbBagianTab2.Items.Add("")
        cmbBagianTab3.Items.Clear()
        cmbBagianTab3.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbBagianTab1.Items.Add(DT.Rows(i)("nmbagian") & "|" & DT.Rows(i)("kdbagian"))
            cmbBagianTab2.Items.Add(DT.Rows(i)("nmbagian") & "|" & DT.Rows(i)("kdbagian"))
            cmbBagianTab3.Items.Add(DT.Rows(i)("nmbagian") & "|" & DT.Rows(i)("kdbagian"))
        Next
        cmbBagianTab1.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbBagianTab1.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbBagianTab2.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbBagianTab2.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbBagianTab3.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbBagianTab3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListDokter()
        'konek()
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

    Sub cariDokter()
        Dim cari As String = InStr(cmbDokter.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbDokter.Text, "|", -1, CompareMethod.Binary)
            namaDokter = (ary(0))
            kdDokter = (ary(1))
        End If
    End Sub

    Sub cariBagianTab1()
        Dim cari As String = InStr(cmbBagianTab1.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbBagianTab1.Text, "|", -1, CompareMethod.Binary)
            kdBagianTab1 = Trim((ary(1)))
            nmBagianTab1 = Trim((ary(0)))
        End If
    End Sub

    Sub cariBagianTab2()
        Dim cari As String = InStr(cmbBagianTab2.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbBagianTab2.Text, "|", -1, CompareMethod.Binary)
            kdBagianTab2 = Trim((ary(1)))
            nmBagianTab2 = Trim((ary(0)))
        End If
    End Sub

    Sub cariBagianTab3()
        Dim cari As String = InStr(cmbBagianTab3.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbBagianTab3.Text, "|", -1, CompareMethod.Binary)
            kdBagianTab3 = Trim((ary(1)))
            nmBagianTab3 = Trim((ary(0)))
        End If
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
            'konek()
            DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from barang_farmasi WHERE stsaktif ='1' order by kd_barang", CONN)
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
        cariBagianTab1()
        Try
            'konek()
            DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, RTRIM(LTRIM(nmbagian)) as nmbagian, RTRIM(LTRIM(nmkasir)) as nmkasir, tanggal, nota, RTRIM(LTRIM(nmkons)) as nmkons, RTRIM(LTRIM(nama)) as nama, RTRIM(LTRIM(nmdokter)) as nmdokter, kd_barang, RTRIM(LTRIM(nama_barang)) as nama_barang, harga, jml, RTRIM(LTRIM(nmsatuan)) nmsatuan, jmltotal, tuslah, jmlharga, potongan, jmlnet, diserahkan FROM ap_jualbbs2 where tanggal >= '" & Format(DTPTanggalAwalTab1.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab1.Value, "yyyy/MM/dd") & "' AND kdbagian='" & kdBagianTab1 & "' ORDER BY tanggal,nota,urut", CONN)
            DS = New DataSet
            DA.Fill(DS, "notaPerTanggal")
            BDPertanggal.DataSource = DS
            BDPertanggal.DataMember = "notaPerTanggal"
            With GridTab1
                .DataSource = Nothing
                .DataSource = BDPertanggal
                .Columns(0).HeaderText = "Kode Depo"
                .Columns(1).HeaderText = "Nama Bagian"
                .Columns(2).HeaderText = "Petugas"
                .Columns(3).HeaderText = "Tanggal"
                .Columns(4).HeaderText = "Nota"
                .Columns(5).HeaderText = "Jenis Konsumen"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(7).HeaderText = "Nama Dokter"
                .Columns(8).HeaderText = "Kode Barang"
                .Columns(9).HeaderText = "Nama Barang"
                .Columns(10).HeaderText = "Harga"
                .Columns(10).DefaultCellStyle.Format = "N2"
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).HeaderText = "Jumlah"
                .Columns(11).DefaultCellStyle.Format = "N2"
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).HeaderText = "Satuan"
                .Columns(12).DefaultCellStyle.Format = "N2"
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).HeaderText = "Jumlah Total"
                .Columns(13).DefaultCellStyle.Format = "N2"
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).HeaderText = "Tuslah"
                .Columns(14).DefaultCellStyle.Format = "N2"
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).HeaderText = "Jumlah Harga"
                .Columns(15).DefaultCellStyle.Format = "N2"
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).HeaderText = "Potongan"
                .Columns(16).DefaultCellStyle.Format = "N2"
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(17).HeaderText = "Jumlah Net"
                .Columns(17).DefaultCellStyle.Format = "N2"
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(18).HeaderText = "Diserahkan"
                .Columns(0).Width = 40
                .Columns(1).Width = 120
                .Columns(2).Width = 100
                .Columns(3).Width = 75
                .Columns(4).Width = 100
                .Columns(5).Width = 80
                .Columns(6).Width = 150
                .Columns(7).Width = 150
                .Columns(8).Width = 75
                .Columns(9).Width = 150
                .Columns(10).Width = 75
                .Columns(11).Width = 75
                .Columns(12).Width = 75
                .Columns(13).Width = 75
                .Columns(14).Width = 75
                .Columns(15).Width = 75
                .Columns(16).Width = 75
                .Columns(17).Width = 75
                .Columns(18).Width = 70
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            JumlahHarga1Tab1()
            JumlahPotonganTab1()
            JumlahHarga2Tab1()
            JumlahPembulatanTab1()
            JumlahHargaJualTab1()
            txtNamaPasien.Enabled = True
            cmbDiserahkan.Enabled = True
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilPerBarang()
        cariBagianTab2()
        Try
            'konek()
            DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, RTRIM(LTRIM(nmbagian)) as nmbagian, RTRIM(LTRIM(nmkasir)) as nmkasir, tanggal, nota, RTRIM(LTRIM(nmkons)) as nmkons, RTRIM(LTRIM(nama)) as nama, RTRIM(LTRIM(nmdokter)) as nmdokter, kd_barang, RTRIM(LTRIM(nama_barang)) as nama_barang, harga, jml, RTRIM(LTRIM(nmsatuan)) as nmsatuan, jmltotal, tuslah, jmlharga, potongan, jmlnet, diserahkan FROM ap_jualbbs2 where tanggal >= '" & Format(DTPTanggalAwalTab2.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab2.Value, "yyyy/MM/dd") & "' AND kdbagian='" & kdBagianTab2 & "' and kd_barang='" & Trim(txtKodeBarangTab2.Text) & "' ORDER BY tanggal,nota,urut", CONN)
            DS = New DataSet
            DA.Fill(DS, "notaPerBarang")
            BDPerbarang.DataSource = DS
            BDPerbarang.DataMember = "notaPerBarang"
            With GridTab2
                .DataSource = Nothing
                .DataSource = BDPerbarang
                .Columns(0).HeaderText = "Kode Depo"
                .Columns(1).HeaderText = "Nama Bagian"
                .Columns(2).HeaderText = "Petugas"
                .Columns(3).HeaderText = "Tanggal"
                .Columns(4).HeaderText = "Nota"
                .Columns(5).HeaderText = "Jenis Konsumen"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(7).HeaderText = "Nama Dokter"
                .Columns(8).HeaderText = "Kode Barang"
                .Columns(9).HeaderText = "Nama Barang"
                .Columns(10).HeaderText = "Harga"
                .Columns(10).DefaultCellStyle.Format = "N2"
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).HeaderText = "Jumlah"
                .Columns(11).DefaultCellStyle.Format = "N2"
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).HeaderText = "Satuan"
                .Columns(12).DefaultCellStyle.Format = "N2"
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).HeaderText = "Jumlah Total"
                .Columns(13).DefaultCellStyle.Format = "N2"
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).HeaderText = "Tuslah"
                .Columns(14).DefaultCellStyle.Format = "N2"
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).HeaderText = "Jumlah Harga"
                .Columns(15).DefaultCellStyle.Format = "N2"
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).HeaderText = "Potongan"
                .Columns(16).DefaultCellStyle.Format = "N2"
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(17).HeaderText = "Jumlah Net"
                .Columns(17).DefaultCellStyle.Format = "N2"
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(18).HeaderText = "Diserahkan"
                .Columns(0).Width = 40
                .Columns(1).Width = 120
                .Columns(2).Width = 100
                .Columns(3).Width = 75
                .Columns(4).Width = 100
                .Columns(5).Width = 80
                .Columns(6).Width = 150
                .Columns(7).Width = 150
                .Columns(8).Width = 75
                .Columns(9).Width = 150
                .Columns(10).Width = 75
                .Columns(11).Width = 75
                .Columns(12).Width = 75
                .Columns(13).Width = 75
                .Columns(14).Width = 75
                .Columns(15).Width = 75
                .Columns(16).Width = 75
                .Columns(17).Width = 75
                .Columns(18).Width = 70
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            JumlahHarga1Tab2()
            JumlahPotonganTab2()
            JumlahHarga2Tab2()
            JumlahPembulatanTab2()
            JumlahHargaJualTab2()
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilPerDokter()
        cariBagianTab3()
        cariDokter()
        Try
            'konek()
            DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, RTRIM(LTRIM(nmbagian)) as nmbagian, RTRIM(LTRIM(nmkasir)) as nmkasir, tanggal, nota, RTRIM(LTRIM(nmkons)) as nmkons, RTRIM(LTRIM(nama)) as nama, RTRIM(LTRIM(nmdokter)) as nmdokter, kd_barang, RTRIM(LTRIM(nama_barang)) as nama_barang, harga, jml, RTRIM(LTRIM(nmsatuan)) nmsatuan, jmltotal, tuslah, jmlharga, potongan, jmlnet, diserahkan FROM ap_jualbbs2 where tanggal >= '" & Format(DTPTanggalAwalTab3.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhirTab3.Value, "yyyy/MM/dd") & "' AND kdbagian='" & kdBagianTab3 & "' and kddokter='" & kdDokter & "' ORDER BY tanggal,nota,urut", CONN)
            DS = New DataSet
            DA.Fill(DS, "notaPerDokter")
            BDPerDokter.DataSource = DS
            BDPerDokter.DataMember = "notaPerDokter"
            With gridTab3
                .DataSource = Nothing
                .DataSource = BDPerDokter
                .Columns(0).HeaderText = "Kode Depo"
                .Columns(1).HeaderText = "Nama Bagian"
                .Columns(2).HeaderText = "Petugas"
                .Columns(3).HeaderText = "Tanggal"
                .Columns(4).HeaderText = "Nota"
                .Columns(5).HeaderText = "Jenis Konsumen"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(7).HeaderText = "Nama Dokter"
                .Columns(8).HeaderText = "Kode Barang"
                .Columns(9).HeaderText = "Nama Barang"
                .Columns(10).HeaderText = "Harga"
                .Columns(10).DefaultCellStyle.Format = "N2"
                .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(11).HeaderText = "Jumlah"
                .Columns(11).DefaultCellStyle.Format = "N2"
                .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(12).HeaderText = "Satuan"
                .Columns(12).DefaultCellStyle.Format = "N2"
                .Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(13).HeaderText = "Jumlah Total"
                .Columns(13).DefaultCellStyle.Format = "N2"
                .Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(14).HeaderText = "Tuslah"
                .Columns(14).DefaultCellStyle.Format = "N2"
                .Columns(14).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(15).HeaderText = "Jumlah Harga"
                .Columns(15).DefaultCellStyle.Format = "N2"
                .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(16).HeaderText = "Potongan"
                .Columns(16).DefaultCellStyle.Format = "N2"
                .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(17).HeaderText = "Jumlah Net"
                .Columns(17).DefaultCellStyle.Format = "N2"
                .Columns(17).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(18).HeaderText = "Diserahkan"
                .Columns(0).Width = 40
                .Columns(1).Width = 120
                .Columns(2).Width = 100
                .Columns(3).Width = 75
                .Columns(4).Width = 100
                .Columns(5).Width = 80
                .Columns(6).Width = 150
                .Columns(7).Width = 150
                .Columns(8).Width = 75
                .Columns(9).Width = 150
                .Columns(10).Width = 75
                .Columns(11).Width = 75
                .Columns(12).Width = 75
                .Columns(13).Width = 75
                .Columns(14).Width = 75
                .Columns(15).Width = 75
                .Columns(16).Width = 75
                .Columns(17).Width = 75
                .Columns(18).Width = 70
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            JumlahHarga1Tab3()
            JumlahPotonganTab3()
            JumlahHarga2Tab3()
            JumlahPembulatanTab3()
            JumlahHargaJualTab3()
            txtNamaPasien.Enabled = True
            cmbDiserahkan.Enabled = True
            MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub JumlahHarga1Tab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("jmltotal").Value
        Next
        txtJumlahHarga1Tab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHarga1Tab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("jmltotal").Value
        Next
        txtJumlahHarga1Tab2.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHarga1Tab3()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridTab3.RowCount - 1
            HitungTotal = HitungTotal + gridTab3.Rows(baris).Cells("jmltotal").Value
        Next
        txtJumlahHarga1Tab3.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPotonganTab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("tuslah").Value
        Next
        txtPotonganTab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPotonganTab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("tuslah").Value
        Next
        txtPotonganTab2.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPotonganTab3()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridTab3.RowCount - 1
            HitungTotal = HitungTotal + gridTab3.Rows(baris).Cells("tuslah").Value
        Next
        txtPotonganTab3.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHarga2Tab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("jmlharga").Value
        Next
        txtJumlahHarga2Tab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHarga2Tab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("jmlharga").Value
        Next
        txtJumlahHarga2Tab2.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHarga2Tab3()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridTab3.RowCount - 1
            HitungTotal = HitungTotal + gridTab3.Rows(baris).Cells("jmlharga").Value
        Next
        txtJumlahHarga2Tab3.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPembulatanTab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("potongan").Value
        Next
        txtPembulatanTab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPembulatanTab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("potongan").Value
        Next
        txtPembulatanTab2.DecimalValue = HitungTotal
    End Sub

    Sub JumlahPembulatanTab3()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridTab3.RowCount - 1
            HitungTotal = HitungTotal + gridTab3.Rows(baris).Cells("potongan").Value
        Next
        txtPembulatanTab3.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHargaJualTab1()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab1.RowCount - 1
            HitungTotal = HitungTotal + GridTab1.Rows(baris).Cells("jmlnet").Value
        Next
        txtJumlahHargaJualTab1.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHargaJualTab2()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridTab2.RowCount - 1
            HitungTotal = HitungTotal + GridTab2.Rows(baris).Cells("jmlnet").Value
        Next
        txtJumlahHargaJualTab2.DecimalValue = HitungTotal
    End Sub

    Sub JumlahHargaJualTab3()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridTab3.RowCount - 1
            HitungTotal = HitungTotal + gridTab3.Rows(baris).Cells("jmlnet").Value
        Next
        txtJumlahHargaJualTab3.DecimalValue = HitungTotal
    End Sub

    Private Sub FormLaporanDetailPenjualanObatBebas_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub FormLaporanDetailPenjualanObatBebas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Kosongkan1()
        Kosongkan2()
        Kosongkan3()
        ListBagian()
        ListDokter()
    End Sub

    Private Sub btnProsesTab1_Click(sender As Object, e As EventArgs) Handles btnProsesTab1.Click
        tampilPerTanggal()
    End Sub

    Private Sub txtNamaPasien_TextChanged(sender As Object, e As EventArgs) Handles txtNamaPasien.TextChanged
        BDPertanggal.Filter = "nama like '%" & txtNamaPasien.Text & "%'"
        JumlahHarga1Tab1()
        JumlahPotonganTab1()
        JumlahHarga2Tab1()
        JumlahPembulatanTab1()
        JumlahHargaJualTab1()
    End Sub

    Private Sub cmbDiserahkan_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDiserahkan.SelectedIndexChanged
        If cmbDiserahkan.SelectedIndex = 0 Then
            BDPertanggal.RemoveFilter()
        ElseIf cmbDiserahkan.SelectedIndex = 1 Then
            BDPertanggal.RemoveFilter()
            BDPertanggal.Filter = "diserahkan = 'S'"
        ElseIf cmbDiserahkan.SelectedIndex = 2 Then
            BDPertanggal.RemoveFilter()
            BDPertanggal.Filter = "diserahkan = 'B'"
        End If
        JumlahHarga1Tab1()
        JumlahPotonganTab1()
        JumlahHarga2Tab1()
        JumlahPembulatanTab1()
        JumlahHargaJualTab1()
    End Sub

    Private Sub txtCariObat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariObat.KeyDown
        If e.KeyCode = Keys.Down Then
            gridBarang.Focus()
        End If
    End Sub

    Private Sub txtCariObat_TextChanged(sender As Object, e As EventArgs) Handles txtCariObat.TextChanged
        BDDataBarang.Filter = "nama_barang like '%" & txtCariObat.Text & "%'"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelObat.Visible = False
    End Sub

    Private Sub txtKodeBarangTab3_GotFocus(sender As Object, e As EventArgs) Handles txtKodeBarangTab2.GotFocus
        tampilBarang()
        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub txtKodeBarangTab3_TextChanged(sender As Object, e As EventArgs) Handles txtKodeBarangTab2.TextChanged

    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                txtKodeBarangTab2.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                txtNamaBarangTab2.Text = gridBarang.Rows(e.RowIndex).Cells(3).Value
                PanelObat.Visible = False
                DTPTanggalAwalTab2.Focus()
            End If
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                txtKodeBarangTab2.Text = gridBarang.Rows(i).Cells(2).Value
                txtNamaBarangTab2.Text = gridBarang.Rows(i).Cells(3).Value
                PanelObat.Visible = False
                DTPTanggalAwalTab2.Focus()
            End If
        End If
    End Sub

    Private Sub btnProsesTab2_Click(sender As Object, e As EventArgs) Handles btnProsesTab2.Click
        tampilPerBarang()
    End Sub

    Private Sub btnProsesTab3_Click(sender As Object, e As EventArgs) Handles btnProsesTab3.Click
        tampilPerDokter()
    End Sub

    Private Sub btnBaruTab1_Click(sender As Object, e As EventArgs) Handles btnBaruTab1.Click
        Kosongkan1()
    End Sub

    Private Sub btnBaruTab2_Click(sender As Object, e As EventArgs) Handles btnBaruTab2.Click
        Kosongkan2()
    End Sub

    Private Sub btnBaruTab3_Click(sender As Object, e As EventArgs) Handles btnBaruTab3.Click
        Kosongkan3()
    End Sub

    Private Sub btnExcelTab3_Click(sender As Object, e As EventArgs) Handles btnExcelTab3.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            cariBagianTab3()
            Try
                Dim dtXls As New DataTable
                With dtXls
                    .Columns.Add("tanggal")
                    .Columns.Add("nmkasir")
                    .Columns.Add("nota")
                    .Columns.Add("nmkons")
                    .Columns.Add("nama")
                    .Columns.Add("nmdokter")
                    .Columns.Add("kd_barang")
                    .Columns.Add("nama_barang")
                    .Columns.Add("harga")
                    .Columns.Add("jml")
                    .Columns.Add("nmsatuan")
                    .Columns.Add("jmltotal")
                    .Columns.Add("tuslah")
                    .Columns.Add("jmlharga")
                    .Columns.Add("potongan")
                    .Columns.Add("jmlnet")
                    .Columns.Add("diserahkan")
                End With

                For i = 0 To gridTab3.RowCount - 2
                    If Not IsDBNull(gridTab3.Rows(i).Cells(0).Value) Then
                        dtXls.Rows.Add(gridTab3.Rows(i).Cells("tanggal").Value, gridTab3.Rows(i).Cells("nmkasir").Value, gridTab3.Rows(i).Cells("nota").Value, gridTab3.Rows(i).Cells("nmkons").Value, gridTab3.Rows(i).Cells("nama").Value, gridTab3.Rows(i).Cells("nmdokter").Value, gridTab3.Rows(i).Cells("kd_barang").Value, gridTab3.Rows(i).Cells("nama_barang").Value, gridTab3.Rows(i).Cells("harga").Value, gridTab3.Rows(i).Cells("jml").Value, gridTab3.Rows(i).Cells("nmsatuan").Value, gridTab3.Rows(i).Cells("jmltotal").Value, gridTab3.Rows(i).Cells("tuslah").Value, gridTab3.Rows(i).Cells("jmlharga").Value, gridTab3.Rows(i).Cells("potongan").Value, gridTab3.Rows(i).Cells("jmlnet").Value, gridTab3.Rows(i).Cells("diserahkan").Value)
                    End If
                Next
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanDetailPenjualanBebasXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab3.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab3.Text
                sheet.Range("B9").Text = nmBagianTab3
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Detail Penjualan Bebas Per Dokter.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Detail Penjualan Bebas Per Dokter.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnExcelTab2_Click(sender As Object, e As EventArgs) Handles btnExcelTab2.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            cariBagianTab2()
            Try
                Dim dtXls As New DataTable
                With dtXls
                    .Columns.Add("tanggal")
                    .Columns.Add("nmkasir")
                    .Columns.Add("nota")
                    .Columns.Add("nmkons")
                    .Columns.Add("nama")
                    .Columns.Add("nmdokter")
                    .Columns.Add("kd_barang")
                    .Columns.Add("nama_barang")
                    .Columns.Add("harga")
                    .Columns.Add("jml")
                    .Columns.Add("nmsatuan")
                    .Columns.Add("jmltotal")
                    .Columns.Add("tuslah")
                    .Columns.Add("jmlharga")
                    .Columns.Add("potongan")
                    .Columns.Add("jmlnet")
                    .Columns.Add("diserahkan")
                End With

                For i = 0 To GridTab2.RowCount - 2
                    If Not IsDBNull(GridTab2.Rows(i).Cells(0).Value) Then
                        dtXls.Rows.Add(GridTab2.Rows(i).Cells("tanggal").Value, GridTab2.Rows(i).Cells("nmkasir").Value, GridTab2.Rows(i).Cells("nota").Value, GridTab2.Rows(i).Cells("nmkons").Value, GridTab2.Rows(i).Cells("nama").Value, GridTab2.Rows(i).Cells("nmdokter").Value, GridTab2.Rows(i).Cells("kd_barang").Value, GridTab2.Rows(i).Cells("nama_barang").Value, GridTab2.Rows(i).Cells("harga").Value, GridTab2.Rows(i).Cells("jml").Value, GridTab2.Rows(i).Cells("nmsatuan").Value, GridTab2.Rows(i).Cells("jmltotal").Value, GridTab2.Rows(i).Cells("tuslah").Value, GridTab2.Rows(i).Cells("jmlharga").Value, GridTab2.Rows(i).Cells("potongan").Value, GridTab2.Rows(i).Cells("jmlnet").Value, GridTab2.Rows(i).Cells("diserahkan").Value)
                    End If
                Next
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanDetailPenjualanBebasXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab2.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab2.Text
                sheet.Range("B9").Text = nmBagianTab2
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Detail Penjualan Bebas Per Barang.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Detail Penjualan Bebas Per Barang.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnExcelTab1_Click(sender As Object, e As EventArgs) Handles btnExcelTab1.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            cariBagianTab1()
            Try
                Dim dtXls As New DataTable
                With dtXls
                    .Columns.Add("tanggal")
                    .Columns.Add("nmkasir")
                    .Columns.Add("nota")
                    .Columns.Add("nmkons")
                    .Columns.Add("nama")
                    .Columns.Add("nmdokter")
                    .Columns.Add("kd_barang")
                    .Columns.Add("nama_barang")
                    .Columns.Add("harga")
                    .Columns.Add("jml")
                    .Columns.Add("nmsatuan")
                    .Columns.Add("jmltotal")
                    .Columns.Add("tuslah")
                    .Columns.Add("jmlharga")
                    .Columns.Add("potongan")
                    .Columns.Add("jmlnet")
                    .Columns.Add("diserahkan")
                End With

                For i = 0 To GridTab1.RowCount - 2
                    If Not IsDBNull(GridTab1.Rows(i).Cells(0).Value) Then
                        dtXls.Rows.Add(GridTab1.Rows(i).Cells("tanggal").Value, GridTab1.Rows(i).Cells("nmkasir").Value, GridTab1.Rows(i).Cells("nota").Value, GridTab1.Rows(i).Cells("nmkons").Value, GridTab1.Rows(i).Cells("nama").Value, GridTab1.Rows(i).Cells("nmdokter").Value, GridTab1.Rows(i).Cells("kd_barang").Value, GridTab1.Rows(i).Cells("nama_barang").Value, GridTab1.Rows(i).Cells("harga").Value, GridTab1.Rows(i).Cells("jml").Value, GridTab1.Rows(i).Cells("nmsatuan").Value, GridTab1.Rows(i).Cells("jmltotal").Value, GridTab1.Rows(i).Cells("tuslah").Value, GridTab1.Rows(i).Cells("jmlharga").Value, GridTab1.Rows(i).Cells("potongan").Value, GridTab1.Rows(i).Cells("jmlnet").Value, GridTab1.Rows(i).Cells("diserahkan").Value)
                    End If
                Next
                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanDetailPenjualanBebasXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("B7").Text = DTPTanggalAwalTab1.Text
                sheet.Range("B8").Text = DTPTanggalAkhirTab1.Text
                sheet.Range("B9").Text = nmBagianTab1
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Detail Penjualan Bebas Per Barang.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Detail Penjualan Bebas Per Barang.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbBagianTab1_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBagianTab1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTPTanggalAwalTab1.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAwalTab1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAwalTab1.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPTanggalAkhirTab1.Focus()
        End If
    End Sub


    Private Sub DTPTanggalAkhirTab1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAkhirTab1.KeyPress
        If e.KeyChar = Chr(13) Then
            btnProsesTab1.Focus()
        End If
    End Sub

    Private Sub cmbBagianTab2_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBagianTab2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtKodeBarangTab2.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAwalTab2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAwalTab2.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPTanggalAkhirTab2.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAkhirTab2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAkhirTab2.KeyPress
        If e.KeyChar = Chr(13) Then
            btnProsesTab2.Focus()
        End If
    End Sub

    Private Sub cmbBagianTab3_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbBagianTab3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbDokter.Focus()
        End If
    End Sub

    Private Sub cmbDokter_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDokter.KeyDown
        If e.KeyCode = Keys.Enter Then
            DTPTanggalAwalTab3.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAwalTab3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAwalTab3.KeyPress
        If e.KeyChar = Chr(13) Then
            DTPTanggalAkhirTab3.Focus()
        End If
    End Sub

    Private Sub DTPTanggalAkhirTab3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalAkhirTab3.KeyPress
        If e.KeyChar = Chr(13) Then
            btnProsesTab3.Focus()
        End If
    End Sub

End Class