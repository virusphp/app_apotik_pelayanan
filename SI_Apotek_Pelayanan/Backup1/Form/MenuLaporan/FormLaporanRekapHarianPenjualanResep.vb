Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports Syncfusion.XlsIO

Public Class FormLaporanRekapHarianPenjualanResep
    Inherits Office2010Form
    Dim nmPenjamin, nmBagian, kdPenjamin, kdBagian, JenisPasien, kdKriteria, nmKriteria, XopStatus, XopPenjamin, XopBagian As String
    Dim BDLaporanHarianPenjualanResep, BDRacik, BDTotalObat As New BindingSource
    Dim DSLaporanHarianPenjualanResep, DSRacik, DSTotalObat As New DataSet
    Dim DRWLaporanHarianPenjualanResep, DRWRacik, DRWTotalObat As DataRowView

    Sub kosongkan()
        DSLaporanHarianPenjualanResep = Table.BuatTabelLaporanHarianJualResep("LaporanHarianPenjualanResep")
        DSLaporanHarianPenjualanResep.Clear()
        GridObat.BackgroundColor = Color.Azure
        GridObat.DataSource = Nothing
        cmbPenjamin.Text = ""
        cmbBagian.Text = ""
        cmbJenisPasien.Text = ""
        cmbPilihan.Text = ""
        TglServer()
        DTPTanggalAwal.Value = TanggalServer
        DTPTanggalAkhir.Value = TanggalServer
        rSemua.Checked = True
        cmbKriteria.Text = ""
        cmbKriteria.Enabled = False
        cmbPenjamin.Focus()
        txtJumlahNota.DecimalValue = 0
        txtJumlahRacik.DecimalValue = 0
        txtTotalObat.DecimalValue = 0
        txtTotalSeluruh.DecimalValue = 0
        txtJumlahItem.DecimalValue = 0
    End Sub

    Sub ListBagian()
        konek()
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
        konek()
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

    Sub ListPoli()
        konek()
        CMD = New OleDb.OleDbCommand("select kd_sub_unit, nama_sub_unit from Sub_Unit order by kd_sub_unit", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbKriteria.Items.Clear()
        cmbKriteria.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbKriteria.Items.Add(DT.Rows(i)("nama_sub_unit") & "|" & DT.Rows(i)("kd_sub_unit"))
        Next
        cmbKriteria.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKriteria.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListDokter()
        konek()
        CMD = New OleDb.OleDbCommand("select kd_pegawai,nama_pegawai,gelar_depan from pegawai where kd_jns_pegawai=1 order by nama_pegawai", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbKriteria.Items.Clear()
        cmbKriteria.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbKriteria.Items.Add(DT.Rows(i)("nama_pegawai") & "|" & DT.Rows(i)("kd_pegawai"))
        Next
        cmbKriteria.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKriteria.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListKasir()
        konek()
        CMD = New OleDb.OleDbCommand("select kdkasir,nmkasir from ap_pas_farmasi order by nmkasir", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbKriteria.Items.Clear()
        cmbKriteria.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbKriteria.Items.Add(DT.Rows(i)("nmkasir") & "|" & DT.Rows(i)("kdkasir"))
        Next
        cmbKriteria.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKriteria.AutoCompleteMode = AutoCompleteMode.SuggestAppend
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

    Sub cariKriteria()
        Dim cari As String = InStr(cmbKriteria.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbKriteria.Text, "|", -1, CompareMethod.Binary)
            kdKriteria = Trim((ary(1)))
            nmKriteria = Trim((ary(0)))
        End If
    End Sub

    Sub JumlahRacik()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("racik").Value
        Next
        txtJumlahRacik.DecimalValue = HitungTotal
    End Sub

    Sub JumlahItem()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("item").Value
        Next
        txtJumlahItem.DecimalValue = HitungTotal
    End Sub

    Sub JumlahTotalObat()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalobt").Value
        Next
        txtTotalObat.DecimalValue = HitungTotal
    End Sub

    Sub JumlahSeluruh()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To GridObat.RowCount - 1
            HitungTotal = HitungTotal + GridObat.Rows(baris).Cells("totalhrg").Value
        Next
        txtTotalSeluruh.DecimalValue = HitungTotal
    End Sub

    Sub aturgrid()
        With GridObat
            .Columns(0).HeaderText = "Unit Far"
            .Columns(1).HeaderText = "Status Rawat"
            .Columns(2).HeaderText = " KD Petugas"
            .Columns(3).HeaderText = "Petugas"
            .Columns(4).HeaderText = "Tanggal"
            .Columns(5).HeaderText = "Nota Resep"
            .Columns(6).HeaderText = "No RM"
            .Columns(7).HeaderText = "Nama Pasien"
            .Columns(8).HeaderText = "KD Dokter"
            .Columns(9).HeaderText = "Nama Dokter"
            .Columns(10).HeaderText = "Kd Unit Asal"
            .Columns(11).HeaderText = "Poli"
            .Columns(12).HeaderText = "L"
            .Columns(13).HeaderText = "R (Jml Obat)"
            .Columns(14).HeaderText = "Jml Item"
            .Columns(15).HeaderText = "Obat"
            .Columns(15).DefaultCellStyle.Format = "N2"
            .Columns(15).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(16).HeaderText = "Total Item"
            .Columns(16).DefaultCellStyle.Format = "N2"
            .Columns(16).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(17).HeaderText = "Kode Penjamin"
            .Columns(18).HeaderText = "Nama Penjamin"
            .Columns(0).Width = 40
            .Columns(1).Width = 50
            .Columns(2).Visible = False
            .Columns(3).Width = 100
            .Columns(4).Width = 75
            .Columns(5).Width = 100
            .Columns(6).Width = 60
            .Columns(7).Width = 150
            .Columns(8).Visible = False
            .Columns(9).Width = 150
            .Columns(10).Visible = False
            .Columns(11).Width = 150
            .Columns(12).Width = 30
            .Columns(13).Width = 40
            .Columns(14).Width = 40
            .Columns(15).Width = 70
            .Columns(16).Width = 70
            .Columns(17).Visible = False
            .Columns(18).Width = 150
            .BackgroundColor = Color.Azure
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            .RowHeadersDefaultCellStyle.BackColor = Color.Black
            .ReadOnly = True
        End With
    End Sub

    Sub TampilGrid1()
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
                DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, stsrawat, kdkasir as kdpetugas, RTRIM(LTRIM(nmkasir)) as petugas, tanggal, notaresep, no_rm, RTRIM(LTRIM(nama_pasien)) as nmpasien, kddokter, RTRIM(LTRIM(nmdokter)) as nmdokter, kd_sub_unit_asal as kdsubunit, RTRIM(LTRIM(nama_sub_unit)) as nmsubunit, 1 as lembar, 0 as racik, 0 as item, 0 as totalobt, totalpaket_bulat as totalhrg, kd_penjamin as kdpenjamin, RTRIM(LTRIM(nm_penjamin)) as nmpenjamin FROM ap_jualr1 where kdbagian" + XopBagian + "'" & kdBagian & "' AND stsrawat " + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND kd_penjamin" + XopPenjamin + "'" & kdPenjamin & "' ORDER BY tanggal,notaresep", CONN)
                DSLaporanHarianPenjualanResep = New DataSet
                DA.Fill(DSLaporanHarianPenjualanResep, "LaporanHarianPenjualanResep")
                BDLaporanHarianPenjualanResep.DataSource = DSLaporanHarianPenjualanResep
                BDLaporanHarianPenjualanResep.DataMember = "LaporanHarianPenjualanResep"

                ''''''''''''''data stok racik
                DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,racik,jmlhari from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND kd_penjamin " + XopPenjamin + "'" & kdPenjamin & "' AND kd_jns_obat='1'", CONN)
                DSRacik = New DataSet
                DA.Fill(DSRacik, "Racik")
                BDRacik.DataSource = DSRacik
                BDRacik.DataMember = "Racik"
                If BDLaporanHarianPenjualanResep.Count > 0 Then
                    BDLaporanHarianPenjualanResep.MoveFirst()
                    For i = 1 To BDLaporanHarianPenjualanResep.Count
                        DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                        DRWRacik = BDRacik.Current
                        DRWLaporanHarianPenjualanResep("racik") = DSRacik.Tables("Racik").Compute("count(notaresep)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                        If IsDBNull(DRWLaporanHarianPenjualanResep("racik")) Then
                            DRWLaporanHarianPenjualanResep("racik") = 0
                        End If
                        BDLaporanHarianPenjualanResep.MoveNext()
                    Next
                End If

                ''''''''''''''data jumlah semua item
                DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,racik,jmlhari from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND kd_penjamin " + XopPenjamin + "'" & kdPenjamin & "'", CONN)
                DSRacik = New DataSet
                DA.Fill(DSRacik, "Item")
                BDRacik.DataSource = DSRacik
                BDRacik.DataMember = "Item"
                If BDLaporanHarianPenjualanResep.Count > 0 Then
                    BDLaporanHarianPenjualanResep.MoveFirst()
                    For i = 1 To BDLaporanHarianPenjualanResep.Count
                        DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                        DRWRacik = BDRacik.Current
                        DRWLaporanHarianPenjualanResep("item") = DSRacik.Tables("item").Compute("count(notaresep)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                        If IsDBNull(DRWLaporanHarianPenjualanResep("item")) Then
                            DRWLaporanHarianPenjualanResep("item") = 0
                        End If
                        BDLaporanHarianPenjualanResep.MoveNext()
                    Next
                End If

                ''''''''''''''data stok total obat
                DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,kd_jns_obat,totalpaket from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND kd_penjamin " + XopPenjamin + "'" & kdPenjamin & "' AND kd_jns_obat=1", CONN)
                DSTotalObat = New DataSet
                DA.Fill(DSTotalObat, "TotalObat")
                BDTotalObat.DataSource = DSTotalObat
                BDTotalObat.DataMember = "TotalObat"
                If BDLaporanHarianPenjualanResep.Count > 0 Then
                    BDLaporanHarianPenjualanResep.MoveFirst()
                    For i = 1 To BDLaporanHarianPenjualanResep.Count
                        DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                        DRWTotalObat = BDTotalObat.Current
                        DRWLaporanHarianPenjualanResep("totalobt") = DSTotalObat.Tables("TotalObat").Compute("sum(totalpaket)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                        If IsDBNull(DRWLaporanHarianPenjualanResep("totalobt")) Then
                            DRWLaporanHarianPenjualanResep("totalobt") = 0
                        Else
                            Dim a As Decimal
                            a = DSTotalObat.Tables("TotalObat").Compute("sum(totalpaket)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            a = a.ToString("0.00")
                            If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                                DRWLaporanHarianPenjualanResep("totalobt") = Math.Ceiling(a)
                            Else
                                DRWLaporanHarianPenjualanResep("totalobt") = a
                            End If
                        End If
                        BDLaporanHarianPenjualanResep.MoveNext()
                    Next
                End If

                GridObat.DataSource = Nothing
                GridObat.DataSource = BDLaporanHarianPenjualanResep
                txtJumlahNota.DecimalValue = GridObat.Rows.Count() - 1
                JumlahRacik()
                JumlahTotalObat()
                JumlahSeluruh()
                JumlahItem()
                aturgrid()
                MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
            Catch ex As Exception
                MsgBox(ex.Message)
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

            Try
                If cmbPilihan.Text = "Semua" Then
                    DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, stsrawat, kdkasir as kdpetugas, RTRIM(LTRIM(nmkasir)) as petugas, tanggal, notaresep, no_rm, RTRIM(LTRIM(nama_pasien)) as nmpasien, kddokter, RTRIM(LTRIM(nmdokter)) as nmdokter, kd_sub_unit_asal as kdsubunit, RTRIM(LTRIM(nama_sub_unit)) as nmsubunit, 1 as lembar, 0 as racik, 0 as item, 0 as totalobt, totalpaket_bulat as totalhrg, kd_penjamin as kdpenjamin, RTRIM(LTRIM(nm_penjamin)) as nmpenjamin FROM ap_jualr1 where kdbagian" + XopBagian + "'" & kdBagian & "' AND stsrawat " + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') ORDER BY tanggal,notaresep", CONN)
                    DSLaporanHarianPenjualanResep = New DataSet
                    DA.Fill(DSLaporanHarianPenjualanResep, "LaporanHarianPenjualanResep")
                    BDLaporanHarianPenjualanResep.DataSource = DSLaporanHarianPenjualanResep
                    BDLaporanHarianPenjualanResep.DataMember = "LaporanHarianPenjualanResep"

                    ''''''''''''''data stok racik
                    DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,racik,jmlhari from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') AND kd_jns_obat='1'", CONN)
                    DSRacik = New DataSet
                    DA.Fill(DSRacik, "Racik")
                    BDRacik.DataSource = DSRacik
                    BDRacik.DataMember = "Racik"
                    If BDLaporanHarianPenjualanResep.Count > 0 Then
                        BDLaporanHarianPenjualanResep.MoveFirst()
                        For i = 1 To BDLaporanHarianPenjualanResep.Count
                            DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                            DRWRacik = BDRacik.Current
                            DRWLaporanHarianPenjualanResep("racik") = DSRacik.Tables("Racik").Compute("count(notaresep)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            If IsDBNull(DRWLaporanHarianPenjualanResep("racik")) Then
                                DRWLaporanHarianPenjualanResep("racik") = 0
                            End If
                            BDLaporanHarianPenjualanResep.MoveNext()
                        Next
                    End If

                    ''''''''''''''data jumlah semua item
                    DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,racik,jmlhari from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24')", CONN)
                    DSRacik = New DataSet
                    DA.Fill(DSRacik, "Item")
                    BDRacik.DataSource = DSRacik
                    BDRacik.DataMember = "Item"
                    If BDLaporanHarianPenjualanResep.Count > 0 Then
                        BDLaporanHarianPenjualanResep.MoveFirst()
                        For i = 1 To BDLaporanHarianPenjualanResep.Count
                            DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                            DRWRacik = BDRacik.Current
                            DRWLaporanHarianPenjualanResep("item") = DSRacik.Tables("item").Compute("count(notaresep)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            If IsDBNull(DRWLaporanHarianPenjualanResep("item")) Then
                                DRWLaporanHarianPenjualanResep("item") = 0
                            End If
                            BDLaporanHarianPenjualanResep.MoveNext()
                        Next
                    End If

                    ''''''''''''''data stok totalobat
                    DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,kd_jns_obat,totalpaket from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') AND kd_jns_obat=1", CONN)
                    DSTotalObat = New DataSet
                    DA.Fill(DSTotalObat, "TotalObat")
                    BDTotalObat.DataSource = DSTotalObat
                    BDTotalObat.DataMember = "TotalObat"
                    If BDLaporanHarianPenjualanResep.Count > 0 Then
                        BDLaporanHarianPenjualanResep.MoveFirst()
                        For i = 1 To BDLaporanHarianPenjualanResep.Count
                            DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                            DRWTotalObat = BDTotalObat.Current
                            DRWLaporanHarianPenjualanResep("totalobt") = DSTotalObat.Tables("TotalObat").Compute("sum(totalpaket)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            If IsDBNull(DRWLaporanHarianPenjualanResep("totalobt")) Then
                                DRWLaporanHarianPenjualanResep("totalobt") = 0
                            Else
                                Dim a As Decimal
                                a = DSTotalObat.Tables("TotalObat").Compute("sum(totalpaket)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                                a = a.ToString("0.00")
                                If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                                    DRWLaporanHarianPenjualanResep("totalobt") = Math.Ceiling(a)
                                Else
                                    DRWLaporanHarianPenjualanResep("totalobt") = a
                                End If
                            End If
                            BDLaporanHarianPenjualanResep.MoveNext()
                        Next
                    End If

                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanHarianPenjualanResep
                    txtJumlahNota.DecimalValue = GridObat.Rows.Count() - 1
                    JumlahRacik()
                    JumlahTotalObat()
                    JumlahSeluruh()
                    JumlahItem()
                    aturgrid()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                End If

                If cmbPilihan.Text = "Dijamin" Then
                    DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, stsrawat, kdkasir as kdpetugas, RTRIM(LTRIM(nmkasir)) as petugas, tanggal, notaresep, no_rm, RTRIM(LTRIM(nama_pasien)) as nmpasien, kddokter, RTRIM(LTRIM(nmdokter)) as nmdokter, kd_sub_unit_asal as kdsubunit, RTRIM(LTRIM(nama_sub_unit)) as nmsubunit, 1 as lembar, 0 as racik, 0 as Item, 0 as totalobt, totalpaket_bulat as totalhrg, kd_penjamin as kdpenjamin, RTRIM(LTRIM(nm_penjamin)) as nmpenjamin FROM ap_jualr1 where kdbagian" + XopBagian + "'" & kdBagian & "' AND stsrawat " + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') and totaldijamin>'0' ORDER BY tanggal,notaresep", CONN)
                    DSLaporanHarianPenjualanResep = New DataSet
                    DA.Fill(DSLaporanHarianPenjualanResep, "LaporanHarianPenjualanResep")
                    BDLaporanHarianPenjualanResep.DataSource = DSLaporanHarianPenjualanResep
                    BDLaporanHarianPenjualanResep.DataMember = "LaporanHarianPenjualanResep"

                    ''''''''''''''data stok racik
                    DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,racik,jmlhari from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') and dijamin>'0'  AND kd_jns_obat='1'", CONN)
                    DSRacik = New DataSet
                    DA.Fill(DSRacik, "Racik")
                    BDRacik.DataSource = DSRacik
                    BDRacik.DataMember = "Racik"
                    If BDLaporanHarianPenjualanResep.Count > 0 Then
                        BDLaporanHarianPenjualanResep.MoveFirst()
                        For i = 1 To BDLaporanHarianPenjualanResep.Count
                            DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                            DRWRacik = BDRacik.Current
                            DRWLaporanHarianPenjualanResep("racik") = DSRacik.Tables("Racik").Compute("count(notaresep)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            If IsDBNull(DRWLaporanHarianPenjualanResep("racik")) Then
                                DRWLaporanHarianPenjualanResep("racik") = 0
                            End If
                            BDLaporanHarianPenjualanResep.MoveNext()
                        Next
                    End If

                    ''''''''''''''data jumlah semua item
                    DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,racik,jmlhari from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') and dijamin>'0'", CONN)
                    DSRacik = New DataSet
                    DA.Fill(DSRacik, "Item")
                    BDRacik.DataSource = DSRacik
                    BDRacik.DataMember = "Item"
                    If BDLaporanHarianPenjualanResep.Count > 0 Then
                        BDLaporanHarianPenjualanResep.MoveFirst()
                        For i = 1 To BDLaporanHarianPenjualanResep.Count
                            DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                            DRWRacik = BDRacik.Current
                            DRWLaporanHarianPenjualanResep("item") = DSRacik.Tables("item").Compute("count(notaresep)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            If IsDBNull(DRWLaporanHarianPenjualanResep("item")) Then
                                DRWLaporanHarianPenjualanResep("item") = 0
                            End If
                            BDLaporanHarianPenjualanResep.MoveNext()
                        Next
                    End If


                    ''''''''''''''data stok totalobat
                    DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,kd_jns_obat,totalpaket from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') and dijamin>'0' AND kd_jns_obat=1", CONN)
                    DSTotalObat = New DataSet
                    DA.Fill(DSTotalObat, "TotalObat")
                    BDTotalObat.DataSource = DSTotalObat
                    BDTotalObat.DataMember = "TotalObat"
                    If BDLaporanHarianPenjualanResep.Count > 0 Then
                        BDLaporanHarianPenjualanResep.MoveFirst()
                        For i = 1 To BDLaporanHarianPenjualanResep.Count
                            DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                            DRWTotalObat = BDTotalObat.Current
                            DRWLaporanHarianPenjualanResep("totalobt") = DSTotalObat.Tables("TotalObat").Compute("sum(totalpaket)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            If IsDBNull(DRWLaporanHarianPenjualanResep("totalobt")) Then
                                DRWLaporanHarianPenjualanResep("totalobt") = 0
                            Else
                                Dim a As Decimal
                                a = DSTotalObat.Tables("TotalObat").Compute("sum(totalpaket)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                                a = a.ToString("0.00")
                                If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                                    DRWLaporanHarianPenjualanResep("totalobt") = Math.Ceiling(a)
                                Else
                                    DRWLaporanHarianPenjualanResep("totalobt") = a
                                End If
                            End If
                            BDLaporanHarianPenjualanResep.MoveNext()
                        Next
                    End If

                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanHarianPenjualanResep
                    txtJumlahNota.DecimalValue = GridObat.Rows.Count() - 1
                    JumlahRacik()
                    JumlahTotalObat()
                    JumlahSeluruh()
                    JumlahItem()
                    aturgrid()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                End If

                If cmbPilihan.Text = "Iur Pasien" Then
                    DA = New OleDb.OleDbDataAdapter("SELECT kdbagian, stsrawat, kdkasir as kdpetugas, RTRIM(LTRIM(nmkasir)) as petugas, tanggal, notaresep, no_rm, RTRIM(LTRIM(nama_pasien)) as nmpasien, kddokter, RTRIM(LTRIM(nmdokter)) as nmdokter, kd_sub_unit_asal as kdsubunit, RTRIM(LTRIM(nama_sub_unit)) as nmsubunit, 1 as lembar, 0 as racik, 0 as item, 0 as totalobt, totalpaket_bulat as totalhrg, kd_penjamin as kdpenjamin, RTRIM(LTRIM(nm_penjamin)) as nmpenjamin FROM ap_jualr1 where kdbagian" + XopBagian + "'" & kdBagian & "' AND stsrawat " + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') and totalselisih_bayar>'0' ORDER BY tanggal,notaresep", CONN)
                    DSLaporanHarianPenjualanResep = New DataSet
                    DA.Fill(DSLaporanHarianPenjualanResep, "LaporanHarianPenjualanResep")
                    BDLaporanHarianPenjualanResep.DataSource = DSLaporanHarianPenjualanResep
                    BDLaporanHarianPenjualanResep.DataMember = "LaporanHarianPenjualanResep"

                    ''''''''''''''data stok racik
                    DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,racik,jmlhari from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') and sisabayar>'0'  AND kd_jns_obat='1'", CONN)
                    DSRacik = New DataSet
                    DA.Fill(DSRacik, "Racik")
                    BDRacik.DataSource = DSRacik
                    BDRacik.DataMember = "Racik"
                    If BDLaporanHarianPenjualanResep.Count > 0 Then
                        BDLaporanHarianPenjualanResep.MoveFirst()
                        For i = 1 To BDLaporanHarianPenjualanResep.Count
                            DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                            DRWRacik = BDRacik.Current
                            DRWLaporanHarianPenjualanResep("racik") = DSRacik.Tables("Racik").Compute("count(notaresep)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            If IsDBNull(DRWLaporanHarianPenjualanResep("racik")) Then
                                DRWLaporanHarianPenjualanResep("racik") = 0
                            End If
                            BDLaporanHarianPenjualanResep.MoveNext()
                        Next
                    End If

                    ''''''''''''''data jumlah semua item
                    DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,racik,jmlhari from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') and sisabayar>'0'", CONN)
                    DSRacik = New DataSet
                    DA.Fill(DSRacik, "Item")
                    BDRacik.DataSource = DSRacik
                    BDRacik.DataMember = "Item"
                    If BDLaporanHarianPenjualanResep.Count > 0 Then
                        BDLaporanHarianPenjualanResep.MoveFirst()
                        For i = 1 To BDLaporanHarianPenjualanResep.Count
                            DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                            DRWRacik = BDRacik.Current
                            DRWLaporanHarianPenjualanResep("item") = DSRacik.Tables("item").Compute("count(notaresep)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            If IsDBNull(DRWLaporanHarianPenjualanResep("item")) Then
                                DRWLaporanHarianPenjualanResep("item") = 0
                            End If
                            BDLaporanHarianPenjualanResep.MoveNext()
                        Next
                    End If

                    ''''''''''''''data stok totalobat
                    konek()
                    DA = New OleDb.OleDbDataAdapter("select tanggal,notaresep,kd_jns_obat,totalpaket from ap_jualr2 where kdbagian" + XopBagian + "'" & kdBagian & "' and stsrawat" + XopStatus + "'" & JenisPasien & "' and tanggal >= '" & Format(DTPTanggalAwal.Value, "yyyy/MM/dd") & "' AND tanggal <= '" & Format(DTPTanggalAkhir.Value, "yyyy/MM/dd") & "' AND (kd_penjamin='23' or kd_penjamin='24') and sisabayar>'0' AND kd_jns_obat=1", CONN)
                    DSTotalObat = New DataSet
                    DA.Fill(DSTotalObat, "TotalObat")
                    BDTotalObat.DataSource = DSTotalObat
                    BDTotalObat.DataMember = "TotalObat"
                    If BDLaporanHarianPenjualanResep.Count > 0 Then
                        BDLaporanHarianPenjualanResep.MoveFirst()
                        For i = 1 To BDLaporanHarianPenjualanResep.Count
                            DRWLaporanHarianPenjualanResep = BDLaporanHarianPenjualanResep.Current
                            DRWTotalObat = BDTotalObat.Current
                            DRWLaporanHarianPenjualanResep("totalobt") = DSTotalObat.Tables("TotalObat").Compute("sum(totalpaket)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                            If IsDBNull(DRWLaporanHarianPenjualanResep("totalobt")) Then
                                DRWLaporanHarianPenjualanResep("totalobt") = 0
                            Else
                                Dim a As Decimal
                                a = DSTotalObat.Tables("TotalObat").Compute("sum(totalpaket)", "notaresep = '" & Trim(DRWLaporanHarianPenjualanResep.Item("notaresep").ToString) & "'")
                                a = a.ToString("0.00")
                                If Microsoft.VisualBasic.Right(a.ToString, 2) >= 50 Then
                                    DRWLaporanHarianPenjualanResep("totalobt") = Math.Ceiling(a)
                                Else
                                    DRWLaporanHarianPenjualanResep("totalobt") = a
                                End If
                            End If
                            BDLaporanHarianPenjualanResep.MoveNext()
                        Next
                    End If

                    GridObat.DataSource = Nothing
                    GridObat.DataSource = BDLaporanHarianPenjualanResep
                    txtJumlahNota.DecimalValue = GridObat.Rows.Count() - 1
                    JumlahRacik()
                    JumlahTotalObat()
                    JumlahSeluruh()
                    JumlahItem()
                    aturgrid()
                    MsgBox("Data sudah ditampilkan", vbInformation, "Informasi")
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
                MsgBox("Data gagal ditampilkan, coba ulangi lagi", vbInformation, "Informasi")
            End Try

        End If
    End Sub

    Private Sub FormLaporanRekapHarianPenjualanResep_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        kosongkan()
        ListBagian()
        ListPenjamin()
        ListJenisPasien()
    End Sub

    Private Sub rSemua_CheckedChanged(sender As Object, e As EventArgs) Handles rSemua.CheckedChanged
        If rSemua.Checked = True Then
            cmbKriteria.Items.Clear()
            cmbKriteria.Text = ""
        End If
    End Sub

    Private Sub rPoli_CheckedChanged(sender As Object, e As EventArgs) Handles rPoli.CheckedChanged
        If rPoli.Checked = True Then
            cmbKriteria.Text = ""
            ListPoli()
            cmbKriteria.Focus()
        End If
    End Sub

    Private Sub rDokter_CheckedChanged(sender As Object, e As EventArgs) Handles rDokter.CheckedChanged
        If rDokter.Checked = True Then
            cmbKriteria.Text = ""
            ListDokter()
            cmbKriteria.Focus()
        End If
    End Sub

    Private Sub rKasir_CheckedChanged(sender As Object, e As EventArgs) Handles rKasir.CheckedChanged
        If rKasir.Checked = True Then
            cmbKriteria.Text = ""
            ListKasir()
            cmbKriteria.Focus()
        End If
    End Sub

    Private Sub btnProsesTab1_Click(sender As Object, e As EventArgs) Handles btnProsesTab1.Click
        TampilGrid1()
        cmbKriteria.Enabled = True
    End Sub

    Private Sub cmbPenjamin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPenjamin.SelectedIndexChanged
        If cmbPenjamin.Text <> "BPJS" Then
            lblPilihan.Visible = False
            cmbPilihan.Visible = False
        Else
            lblPilihan.Visible = True
            cmbPilihan.Visible = True
        End If
    End Sub

    Private Sub btnBaruTab1_Click(sender As Object, e As EventArgs) Handles btnBaruTab1.Click
        kosongkan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        If rSemua.Checked = False Then
            If cmbKriteria.Text = "" Then
                MsgBox("Pilih dulu", vbInformation, "Informasi")
                cmbKriteria.Focus()
                Exit Sub
            End If
        End If
        cariKriteria()
        If rSemua.Checked = True Then
            BDLaporanHarianPenjualanResep.RemoveFilter()
        ElseIf rPoli.Checked = True Then
            BDLaporanHarianPenjualanResep.Filter = "kdsubunit='" & kdKriteria & "'"
        ElseIf rDokter.Checked = True Then
            BDLaporanHarianPenjualanResep.Filter = "kddokter='" & kdKriteria & "'"
        ElseIf rKasir.Checked = True Then
            BDLaporanHarianPenjualanResep.Filter = "kdpetugas='" & kdKriteria & "'"
        End If
        txtJumlahNota.DecimalValue = GridObat.Rows.Count() - 1
        JumlahRacik()
        JumlahTotalObat()
        JumlahSeluruh()
        JumlahItem()
        aturgrid()
    End Sub

    Private Sub cmbKriteria_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbKriteria.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOk.Focus()
        End If
    End Sub

    Private Sub btnExcelTab1_Click(sender As Object, e As EventArgs) Handles btnExcelTab1.Click
        If MessageBox.Show("Apakah data akan di eksport ke excel?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtXls As New DataTable
                With dtXls
                    .Columns.Add("kdbagian")
                    .Columns.Add("stsrawat")
                    .Columns.Add("petugas")
                    .Columns.Add("tanggal")
                    .Columns.Add("notaresep")
                    .Columns.Add("no_rm")
                    .Columns.Add("nmpasien")
                    .Columns.Add("nmdokter")
                    .Columns.Add("nmsubunit")
                    .Columns.Add("lembar")
                    .Columns.Add("racik")
                    .Columns.Add("item")
                    .Columns.Add("totalobt")
                    .Columns.Add("totalhrg")
                    .Columns.Add("nmpenjamin")
                End With

                For i = 0 To GridObat.RowCount - 2
                    If Not IsDBNull(GridObat.Rows(i).Cells(0).Value) Then
                        dtXls.Rows.Add(GridObat.Rows(i).Cells("kdbagian").Value, GridObat.Rows(i).Cells("stsrawat").Value, GridObat.Rows(i).Cells("petugas").Value, GridObat.Rows(i).Cells("tanggal").Value, GridObat.Rows(i).Cells("notaresep").Value, GridObat.Rows(i).Cells("no_rm").Value, GridObat.Rows(i).Cells("nmpasien").Value, GridObat.Rows(i).Cells("nmdokter").Value, GridObat.Rows(i).Cells("nmsubunit").Value, GridObat.Rows(i).Cells("lembar").Value, GridObat.Rows(i).Cells("racik").Value, GridObat.Rows(i).Cells("item").Value, GridObat.Rows(i).Cells("totalobt").Value, GridObat.Rows(i).Cells("totalhrg").Value, GridObat.Rows(i).Cells("nmpenjamin").Value)
                    End If
                Next

                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\LaporanRekapHarianPenjualanResepXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("E7").Text = DTPTanggalAwal.Text
                sheet.Range("E8").Text = DTPTanggalAkhir.Text
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
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("Laporan Rekap Harian Penjualan Resep.xlsx")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("Laporan Rekap Harian Penjualan Resep.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbJenisPasien_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisPasien.SelectedIndexChanged

    End Sub
End Class