Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormMutasiAntarUnit
    Inherits Office2010Form

    Public rpt As New ReportDocument
    Dim BDDataBarang, BDMutasi As New BindingSource
    Dim kdunitAsal, nmUnitAsal, Stok, kdUnit, nmUnit, memStok, memStok2 As String
    Dim Bulan, Tahun As Integer
    Dim DSMutasi As New DataSet
    Dim DRWMutasi As DataRowView

    'Dim Trans As SqlTransaction

    Dim Trans As OleDb.OleDbTransaction

    Sub kosongkanHeader()
        DSMutasi = Table.BuatTabelMutasiUnit("Mutasi")
        gridDetailObat.BackgroundColor = Color.Azure
        DSMutasi.Clear()
        gridDetailObat.DataSource = Nothing
        TglServer()
        DTPTanggalTrans.Value = TanggalServer
        cmbMode.SelectedIndex = 0
        Nota()
        cmbDariUnit.Text = pnmapo & "|" & pkdapo
        cmbKeUnit.Text = ""
        btnSimpan.Enabled = False
        btnCetakNota.Enabled = False
        btnBaru.Enabled = False
        cmbKeUnit.Enabled = True
        txtGrandTotal.DecimalValue = 0
        txtGrandTotalBulat.DecimalValue = 0
        txtQty.DecimalValue = 0
        DTPTanggalTrans.Focus()
    End Sub

    Sub kosongkanDetail()
        txtKodeObat.Clear()
        lblNamaObat.Text = ""
        txtIdxBarang.Clear()
        txtHarga.DecimalValue = 0
        txtJmlMutasi.DecimalValue = 0
        lblSatuan.Text = ""
        txtJmlHarga.DecimalValue = 0
        txtStok.DecimalValue = 0
    End Sub

    Sub Nota()
        Try
            CMD = New OleDb.OleDbCommand("select nota from ap_ambilunit where Month(tanggal)='" & Month(DTPTanggalTrans.Value) & "' and Year(tanggal)='" & Year(DTPTanggalTrans.Value) & "' and LEFT(nota,1)='" & pkdnota & "' order by nota desc", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If Not DT.Rows.Count > 0 Then
                txtNota.Text = pkdnota + "-" + "00001"
            Else
                txtNota.Text = Microsoft.VisualBasic.Right(DT.Rows(0).Item("nota").ToString, 5) + 1
                If Len(txtNota.Text) = 1 Then
                    txtNota.Text = pkdnota + "-" + "0000" & txtNota.Text & ""
                ElseIf Len(txtNota.Text) = 2 Then
                    txtNota.Text = pkdnota + "-" + "000" & txtNota.Text & ""
                ElseIf Len(txtNota.Text) = 3 Then
                    txtNota.Text = pkdnota + "-" + "00" & txtNota.Text & ""
                ElseIf Len(txtNota.Text) = 4 Then
                    txtNota.Text = pkdnota + "-" + "0" & txtNota.Text & ""
                ElseIf Len(txtNota.Text) = 5 Then
                    txtNota.Text = pkdnota + "-" + "" & txtNota.Text & ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ListBagian()
        CMD = New OleDb.OleDbCommand("select kdbagian, nmbagian from ap_bagian order by kdbagian", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbKeUnit.Items.Clear()
        cmbKeUnit.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbKeUnit.Items.Add(DT.Rows(i)("nmbagian") & "|" & DT.Rows(i)("kdbagian"))
        Next
        cmbKeUnit.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKeUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub cariUnitAsal()
        Dim cari As String = InStr(cmbDariUnit.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbDariUnit.Text, "|", -1, CompareMethod.Binary)
            kdunitAsal = Trim((ary(1)))
            nmUnitAsal = Trim((ary(0)))
        End If
    End Sub

    Sub cariUnitTujuan()
        Dim cari As String = InStr(cmbKeUnit.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbKeUnit.Text, "|", -1, CompareMethod.Binary)
            kdUnit = Trim((ary(1)))
            nmUnit = Trim((ary(0)))
        End If
    End Sub

    Sub tampilBarang()
        cariUnitAsal()
        If kdunitAsal = "001" Then
            Stok = "stok001"
        ElseIf kdunitAsal = "002" Then
            Stok = "stok002"
        ElseIf kdunitAsal = "003" Then
            Stok = "stok003"
        ElseIf kdunitAsal = "004" Then
            Stok = "stok004"
        ElseIf kdunitAsal = "005" Then
            Stok = "stok005"
        ElseIf kdunitAsal = "006" Then
            Stok = "stok006"
        ElseIf kdunitAsal = "007" Then
            Stok = "stok007"
        End If
        Try
            'DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from barang_farmasi WHERE stsaktif ='1' order by nama_barang", CONN)
            DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", 
                LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan 
                from Barang_Farmasi WHERE stsaktif ='1' AND " & Stok & "> 0 order by nama_barang", CONN)
            DS = New DataSet
            DA.Fill(DS, "obat")
            BDDataBarang.DataSource = DS
            BDDataBarang.DataMember = "obat"

            With gridBarang
                .DataSource = Nothing
                .DataSource = BDDataBarang
            End With
            aturGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilBarangStokLebih()
        cariUnitAsal()
        If kdunitAsal = "001" Then
            Stok = "stok001"
        ElseIf kdunitAsal = "002" Then
            Stok = "stok002"
        ElseIf kdunitAsal = "003" Then
            Stok = "stok003"
        ElseIf kdunitAsal = "004" Then
            Stok = "stok004"
        ElseIf kdunitAsal = "005" Then
            Stok = "stok005"
        ElseIf kdunitAsal = "006" Then
            Stok = "stok006"
        ElseIf kdunitAsal = "007" Then
            Stok = "stok007"
        End If
        Try
            DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from barang_farmasi WHERE stsaktif ='1' AND " & Stok & ">0 order by nama_barang", CONN)
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
            End With
            aturGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub aturGrid()
        With gridBarang
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
    End Sub

    Sub detailObat()
        CMD = New OleDb.OleDbCommand("SELECT * FROM barang_farmasi WHERE kd_barang='" & Trim(txtKodeObat.Text) & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            lblNamaObat.Text = Trim(DT.Rows(0).Item("nama_barang"))
            lblSatuan.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
            txtIdxBarang.Text = Trim(DT.Rows(0).Item("idx_barang"))
            txtHarga.DecimalValue = DT.Rows(0).Item("harga_satuan")
        End If
    End Sub

    Sub cekTutupStokUnitAsal()
        CMD = New OleDb.OleDbCommand("select kdbagian, bulan, tahun FROM ap_stok_awalapo WHERE kdbagian=" & pkdapo & " and bulan='" & Bulan & "' and tahun='" & Tahun & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Sub cekTutupStokUnitTujuan()
        CMD = New OleDb.OleDbCommand("select kdbagian, bulan, tahun FROM ap_stok_awalapo WHERE kdbagian=" & kdUnit & " and bulan='" & Bulan & "' and tahun='" & Tahun & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Sub cekAlarmKoreksi()
        CMD = New OleDb.OleDbCommand("select * FROM ap_alarmkoreksi WHERE kodeunit=" & kdUnit & " and bulan='" & Month(DTPTanggalTrans.Value) & "' and tahun='" & Year(DTPTanggalTrans.Value) & "' and alarm='2'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Sub TotalHarga()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("jmlharga").Value
        Next
        txtGrandTotal.DecimalValue = HitungTotal
        txtGrandTotalBulat.DecimalValue = buletin(txtGrandTotal.DecimalValue)
    End Sub

    Sub addBarang()
        BDMutasi.DataSource = DSMutasi
        BDMutasi.DataMember = "Mutasi"

        BDMutasi.AddNew()
        DRWMutasi = BDMutasi.Current
        DRWMutasi("kdbagian") = pkdapo
        DRWMutasi("kdkasir") = FormLogin.LabelKode.Text
        DRWMutasi("nmkasir") = FormLogin.LabelNama.Text
        DRWMutasi("tanggal") = DTPTanggalTrans.Value
        DRWMutasi("nota") = txtNota.Text
        DRWMutasi("kdbagian1") = pkdapo
        DRWMutasi("nmbagian1") = pnmapo
        DRWMutasi("kdbagian2") = kdUnit
        DRWMutasi("nmbagian2") = nmUnit
        DRWMutasi("kd_barang") = Trim(txtKodeObat.Text)
        DRWMutasi("idx_barang") = Trim(txtIdxBarang.Text)
        DRWMutasi("nama_barang") = Trim(lblNamaObat.Text)
        DRWMutasi("harga") = txtHarga.DecimalValue
        DRWMutasi("jml") = txtJmlMutasi.DecimalValue
        DRWMutasi("nmsatuan") = Trim(lblSatuan.Text)
        DRWMutasi("jmlharga") = txtJmlHarga.DecimalValue
        DRWMutasi("posting") = "1"

        BDMutasi.EndEdit()

        gridDetailObat.DataSource = Nothing
        gridDetailObat.DataSource = BDMutasi

        TotalHarga()

    End Sub

    Sub AturGriddetailBarang()
        With gridDetailObat
            .Columns(0).HeaderText = "No"
            .Columns(1).HeaderText = "Kode Barang"
            .Columns(2).HeaderText = "Nama Barang"
            .Columns(3).HeaderText = "Harga"
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Jumlah"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "Satuan"
            .Columns(6).HeaderText = "Jumlah Harga"
            .Columns(6).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).Width = 40
            .Columns(1).Width = 80
            .Columns(2).Width = 300
            .Columns(3).Width = 100
            .Columns(4).Width = 80
            .Columns(5).Width = 80
            .Columns(6).Width = 120
            .Columns(0).Visible = False
            .Columns(7).Visible = False
            .Columns(8).Visible = False
            .Columns(9).Visible = False
            .Columns(10).Visible = False
            .Columns(11).Visible = False
            .Columns(12).Visible = False
            .Columns(13).Visible = False
            .Columns(14).Visible = False
            .Columns(15).Visible = False
            .Columns(16).Visible = False
            .Columns(17).Visible = False
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

    Sub cetakNota()
        rpt = New ReportDocument
        Try
            Dim str As String = Application.StartupPath & "\Report\notaMutasi.rpt"
            rpt.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rpt.SetDatabaseLogon(dbUser, dbPassword)
            rpt.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
            rpt.SetParameterValue("nota", Trim(txtNota.Text))
            rpt.SetParameterValue("kdbagian", kdunitAsal)
            FormCetak.CrystalReportViewer1.ReportSource = rpt
            FormCetak.CrystalReportViewer1.Show()
            FormCetak.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FormMutasiAntarUnit_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormMutasiAntarUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnSimpan.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then
            btnCetakNota.PerformClick()
        ElseIf e.KeyCode = Keys.F10 Then
            btnBaru.PerformClick()
        End If
    End Sub

    Private Sub FormMutasiAntarUnit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Me.KeyPreview = True
        kosongkanDetail()
        kosongkanHeader()
        ListBagian()
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub FormMutasiAntarUnit_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelObat.Top = txtKodeObat.Top + 143
        PanelObat.Left = txtKodeObat.Left
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelObat.Visible = False
    End Sub

    Private Sub txtKodeObat_Click(sender As Object, e As EventArgs) Handles txtKodeObat.Click
        'tampilBarang()
        'PanelObat.Visible = True
        'txtCariObat.Clear()
        'txtCariObat.Focus()
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
                txtStok.DecimalValue = gridBarang.Rows(e.RowIndex).Cells(4).Value
                PanelObat.Visible = False
                detailObat()
                txtJmlMutasi.Focus()
            End If
        End If
    End Sub

    Private Sub txtKodeObat_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObat.GotFocus
        If stok0 = "1" Then
            tampilBarangStokLebih()
        Else
            tampilBarang()
        End If

        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub DTPTanggalTrans_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalTrans.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNota.Focus()
        End If
    End Sub


    Private Sub DTPTanggalTrans_ValueChanged(sender As Object, e As EventArgs) Handles DTPTanggalTrans.ValueChanged
        DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
        Bulan = Month(DTPBantu.Value)
        Tahun = Year(DTPBantu.Value)
        cekTutupStokUnitAsal()
        If DT.Rows.Count > 0 Then
            DTPTanggalTrans.Focus()
            MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut sudah tutup stok", vbInformation, "Informasi")
            TglServer()
            DTPTanggalTrans.Value = TanggalServer
            Exit Sub
        End If
        Nota()
    End Sub

    Private Sub txtJmlMutasi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlMutasi.KeyPress
        If e.KeyChar = Chr(13) Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub txtJmlMutasi_TextChanged(sender As Object, e As EventArgs) Handles txtJmlMutasi.TextChanged
        txtJmlHarga.DecimalValue = txtHarga.DecimalValue * txtJmlMutasi.DecimalValue
    End Sub

    Private Sub txtNota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNota.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbKeUnit.Focus()
        End If
    End Sub

    Private Sub cmbKeUnit_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbKeUnit.KeyDown
        If e.KeyCode = Keys.Enter Then
            'cariUnitTujuan()
            'If kdUnit =  pkdapo Then
            '    MsgBox("Unit tidak boleh sama", vbCritical, "Kesalahan")
            '    cmbKeUnit.Focus()
            'Else
            txtKodeObat.Focus()
            'End If

            'DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
            'Bulan = Month(DTPBantu.Value)
            'Tahun = Year(DTPBantu.Value)
            'cekTutupStokUnitTujuan()
            'If DR.HasRows Then
            '    DTPTanggalTrans.Focus()
            '    MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut unit tujuan sudah tutup stok", vbInformation, "Informasi")
            '    TglServer()
            '    DTPTanggalTrans.Value = TanggalServer
            'End If
        End If
    End Sub

    Private Sub cmbKeUnit_Validated(sender As Object, e As EventArgs) Handles cmbKeUnit.Validated
        cariUnitAsal()
        cariUnitTujuan()
        TglServer()
        If kdUnit = kdunitAsal Then
            MsgBox("Unit tidak boleh sama", vbCritical, "Kesalahan")
            PanelObat.Visible = False
            cmbKeUnit.Focus()
            Exit Sub
        End If
        DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
        Bulan = Month(DTPBantu.Value)
        Tahun = Year(DTPBantu.Value)
        cekTutupStokUnitTujuan()
        If DT.Rows.Count > 0 Then
            MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut unit tujuan sudah tutup stok", vbInformation, "Informasi")
            DTPTanggalTrans.Value = TanggalServer
            PanelObat.Visible = False
            DTPTanggalTrans.Focus()
            Exit Sub
        End If
        cekAlarmKoreksi()
        If DT.Rows.Count > 0 Then
            MsgBox("Mutasi tidak bisa dilakukan karena unit tersebut sedang melakukan koreksi stok. " & vbCrLf & "Hubungi unit tersebut untuk melakukan mutasi", vbInformation, "Informasi")
            PanelObat.Visible = False
            DTPTanggalTrans.Focus()
            Exit Sub
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                txtKodeObat.Text = gridBarang.Rows(i).Cells(2).Value
                txtStok.DecimalValue = gridBarang.Rows(i).Cells(4).Value
                PanelObat.Visible = False
                detailObat()
                txtJmlMutasi.Focus()
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If cmbKeUnit.Text = "" Then
            MsgBox("Unit tujuan belum dipilih")
            Exit Sub
        End If
        If txtKodeObat.Text = "" Then
            MsgBox("Obat belum dipilih")
            txtKodeObat.Focus()
            Exit Sub
        End If
        If txtJmlMutasi.DecimalValue <= 0 Then
            MsgBox("Jumlah belum diisi")
            txtJmlMutasi.Focus()
            Exit Sub
        End If
        If txtJmlMutasi.DecimalValue > txtStok.DecimalValue Then
            MsgBox("Jumlah mutasi melebihi jumlah stok", vbInformation, "Informasi")
            txtJmlMutasi.Focus()
            Exit Sub
        End If
        For barisGrid As Integer = 0 To gridDetailObat.RowCount - 1
            If Trim(txtKodeObat.Text) = gridDetailObat.Rows(barisGrid).Cells("kd_barang").Value Then
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
        cmbKeUnit.Enabled = False
        btnSimpan.Enabled = True
        btnBaru.Enabled = True
        txtIdxBarang.Focus()
    End Sub

    Private Sub btnHapusBaris_Click(sender As Object, e As EventArgs) Handles btnHapusBaris.Click
        If MessageBox.Show("Yakin Akan Dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If gridDetailObat.CurrentRow.Index <> gridDetailObat.NewRowIndex Then
                    gridDetailObat.Rows.RemoveAt(gridDetailObat.CurrentRow.Index)
                End If
                txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
                TotalHarga()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub cmbMode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMode.SelectedIndexChanged
        If cmbMode.SelectedIndex = 0 Then
            cmbDariUnit.Text = pnmapo & "|" & pkdapo
            cmbKeUnit.Text = ""
            cmbKeUnit.Enabled = True
        Else
            cmbDariUnit.Text = "Apotik Gudang Rawat Jalan BPJS|006"
            cmbKeUnit.Text = "Apotik Rawat Jalan|001"
            cmbKeUnit.Enabled = False
        End If

    End Sub

    Private Sub cmbKeUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbKeUnit.SelectedIndexChanged

    End Sub

    Private Sub gridDetailObat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridDetailObat.CellContentClick

    End Sub

    Private Sub gridDetailObat_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObat.CellFormatting
        gridDetailObat.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub txtIdxBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIdxBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKodeObat.Focus()
        End If
    End Sub

    Private Sub txtIdxBarang_TextChanged(sender As Object, e As EventArgs) Handles txtIdxBarang.TextChanged

    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        kosongkanDetail()
        kosongkanHeader()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        cariUnitAsal()
        If kdunitAsal = "001" Then
            memStok = "stok001"
        ElseIf kdunitAsal = "002" Then
            memStok = "stok002"
        ElseIf kdunitAsal = "003" Then
            memStok = "stok003"
        ElseIf kdunitAsal = "004" Then
            memStok = "stok004"
        ElseIf kdunitAsal = "005" Then
            memStok = "stok005"
        ElseIf kdunitAsal = "006" Then
            memStok = "stok006"
        ElseIf kdunitAsal = "007" Then
            memStok = "stok007"
        Else
            MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
        End If

        cariUnitTujuan()
        If kdUnit = "001" Then
            memStok2 = "stok001"
        ElseIf kdUnit = "002" Then
            memStok2 = "stok002"
        ElseIf kdUnit = "003" Then
            memStok2 = "stok003"
        ElseIf kdUnit = "004" Then
            memStok2 = "stok004"
        ElseIf kdUnit = "005" Then
            memStok2 = "stok005"
        ElseIf kdUnit = "006" Then
            memStok2 = "stok006"
        ElseIf kdUnit = "007" Then
            memStok2 = "stok007"
        Else
            MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
        End If
        DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
        Bulan = Month(DTPBantu.Value)
        Tahun = Year(DTPBantu.Value)
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
        cekTutupStokUnitTujuan()
        If DT.Rows.Count > 0 Then
            MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut unit tujuan sudah tutup stok", vbInformation, "Informasi")
            DTPTanggalTrans.Value = TanggalServer
            PanelObat.Visible = False
            DTPTanggalTrans.Focus()
            Exit Sub
        End If
        cekAlarmKoreksi()
        If DT.Rows.Count > 0 Then
            MsgBox("Mutasi tidak bisa dilakukan karena unit tersebut sedang melakukan koreksi stok. " & vbCrLf & "Hubungi unit tersebut untuk melakukan mutasi", vbInformation, "Informasi")
            PanelObat.Visible = False
            DTPTanggalTrans.Focus()
            Exit Sub
        End If
        If MessageBox.Show("Data Penjualan sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlMutasi As String = ""
            TglServer()
            Nota()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Simpan ke ap_ambilunit
                For i = 0 To gridDetailObat.RowCount - 2
                    sqlMutasi = sqlMutasi + vbCrLf + "insert into ap_ambilunit(kdbagian,kdkasir,nmkasir,tanggal,nota,nomer,kdbagian1,nmbagian1, kdbagian2,nmbagian2,kd_barang,idx_barang,nama_barang,harga,jml,nmsatuan,jmlharga,posting) values('" & pkdapo & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNota.Text) & "', " & i + 1 & ", '" & kdunitAsal & "', '" & nmUnitAsal & "', '" & kdUnit & "', '" & nmUnit & "', '" & gridDetailObat.Rows(i).Cells("kd_barang").Value & "', '" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "','" & Rep(gridDetailObat.Rows(i).Cells("nama_barang").Value) & "','" & Val(gridDetailObat.Rows(i).Cells("harga").Value) & "','" & Val(gridDetailObat.Rows(i).Cells("jml").Value) & "','" & gridDetailObat.Rows(i).Cells("nmsatuan").Value & "','" & Val(gridDetailObat.Rows(i).Cells("jmlharga").Value) & "','1')"
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' update stok unit asal
                For i = 0 To gridDetailObat.RowCount - 2
                    sqlMutasi = sqlMutasi + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "-" & Val(gridDetailObat.Rows(i).Cells("jml").Value) & " WHERE kd_barang='" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "'"
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' update stok unit tujuan
                For i = 0 To gridDetailObat.RowCount - 2
                    sqlMutasi = sqlMutasi + vbCrLf + "UPDATE barang_farmasi SET " & memStok2 & "=" & memStok2 & "+" & Val(gridDetailObat.Rows(i).Cells("jml").Value) & " WHERE kd_barang='" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "'"
                Next

                CMD.CommandText = sqlMutasi
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi mutasi berhasil tersimpan", vbInformation, "Informasi")
                btnSimpan.Enabled = False
                btnCetakNota.Enabled = True
                btnCetakNota.Focus()
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

    Private Sub cmbMode_Validated(sender As Object, e As EventArgs) Handles cmbMode.Validated
        If cmbMode.SelectedIndex = 1 Then
            cariUnitAsal()
            cariUnitTujuan()
            TglServer()
            DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
            Bulan = Month(DTPBantu.Value)
            Tahun = Year(DTPBantu.Value)
            cekTutupStokUnitTujuan()
            If DT.Rows.Count > 0 Then
                MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut unit tujuan sudah tutup stok", vbInformation, "Informasi")
                DTPTanggalTrans.Value = TanggalServer
                PanelObat.Visible = False
                DTPTanggalTrans.Focus()
                cmbMode.Focus()
                Exit Sub
            End If
            cekAlarmKoreksi()
            If DT.Rows.Count > 0 Then
                MsgBox("Mutasi tidak bisa dilakukan karena unit tersebut sedang melakukan koreksi stok. " & vbCrLf & "Hubungi unit tersebut untuk melakukan mutasi", vbInformation, "Informasi")
                PanelObat.Visible = False
                DTPTanggalTrans.Focus()
                cmbMode.Focus()
                Exit Sub
            End If
        End If
    End Sub

    Private Sub btnCetakNota_Click(sender As Object, e As EventArgs) Handles btnCetakNota.Click
        FormPemanggil = "FormMutasiAntarUnit"
        cetakNota()
        btnCetakNota.Enabled = False
    End Sub

End Class