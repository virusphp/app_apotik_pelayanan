Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class FormPermintaanGudangBPJSKeGudang
    Inherits Office2010Form
    Public rpt As New ReportDocument

    Dim BDObatGudang, BDPermintaanObat As New BindingSource
    Dim DRWPermintaanObat As DataRowView
    Dim DSPermintaanObat As New DataSet
    Dim kdJnsObat, jnsObat As String
    'Dim Trans As SqlTransaction
    Dim Trans As OleDb.OleDbTransaction

    Sub kosongkanHeader()
        TglServer()
        DTPTanggalTrans.Value = TanggalServer
        DSPermintaanObat = Table.BuatTabelPermintaanBarangGudang("PermintaanObat")
        gridDetailObat.BackgroundColor = Color.Azure
        DSPermintaanObat.Clear()
        gridDetailObat.DataSource = Nothing
        btnSimpan.Enabled = False
        btnCetakNota.Enabled = False
        btnBaru.Enabled = False
        txtGrandTotal.DecimalValue = 0
        txtGrandTotalBulat.DecimalValue = 0
        txtQty.DecimalValue = 0
        Nota()
    End Sub

    Sub kosongkanDetail()
        TglServer()
        txtKodeObat.Clear()
        lblNamaObat.Text = ""
        txtIdxBarang.Clear()
        DTPTanggalExp.Value = TanggalServer
        txtBatch.Clear()
        txtPot.DecimalValue = 0
        txtHargaJual.DecimalValue = 0
        txtHargaPPN.DecimalValue = 0
        txtSisaStok.DecimalValue = 0
        txtJmlPermintaan.DecimalValue = 0
        txtJmlHarga.DecimalValue = 0
        txtNamaSatuan.Clear()
        txtNota.Focus()
    End Sub

    Sub Nota()
        Dim mKd As String = "A6"
        Try
            CMD = New OleDb.OleDbCommand("select nota from ap_mintabrg where tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and LEFT(nota,2)='" & mKd & "' order by nota desc", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If Not DT.Rows.Count > 0 Then
                txtNota.Text = mKd + Format(DTPTanggalTrans.Value, "yyMMdd") + "0001"
            Else
                txtNota.Text = Microsoft.VisualBasic.Right(DT.Rows(0).Item("nota").ToString, 4) + 1
                If Len(txtNota.Text) = 1 Then
                    txtNota.Text = mKd + Format(DTPTanggalTrans.Value, "yyMMdd") + "000" & txtNota.Text & ""
                ElseIf Len(txtNota.Text) = 2 Then
                    txtNota.Text = mKd + Format(DTPTanggalTrans.Value, "yyMMdd") + "00" & txtNota.Text & ""
                ElseIf Len(txtNota.Text) = 3 Then
                    txtNota.Text = mKd + Format(DTPTanggalTrans.Value, "yyMMdd") + "0" & txtNota.Text & ""
                ElseIf Len(txtNota.Text) = 4 Then
                    txtNota.Text = mKd + Format(DTPTanggalTrans.Value, "yyMMdd") + "" & txtNota.Text & ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilObat()
        Try
            DA = New OleDb.OleDbDataAdapter("select b.idbarang, b.kd_barang, LTRIM(RTRIM(b.nama_barang)) as nama_barang, b.tanggal, b.tglexp, RTRIM(LTRIM(b.nobatch)), b.jmlstok, RTRIM(LTRIM(b.satuan)), b.hrgppn, RTRIM(LTRIM(m.keterangan)) from ap_belistok b, barang_farmasi m where b.kd_barang=m.kd_barang and b.jmlstok > 0 and b.stsed is null order by b.idbarang", CONN)
            DS = New DataSet
            DA.Fill(DS, "ObatGudang")
            BDObatGudang.DataSource = DS
            BDObatGudang.DataMember = "ObatGudang"
            With gridBarang
                .DataSource = Nothing
                .DataSource = BDObatGudang
                .Columns(1).HeaderText = "ID Barang"
                .Columns(2).HeaderText = "Kode Barang"
                .Columns(3).HeaderText = "Nama Barang"
                .Columns(4).HeaderText = "Tanggal Masuk/ Beli"
                .Columns(5).HeaderText = "Tanggal EXP"
                .Columns(6).HeaderText = "No Batch"
                .Columns(7).HeaderText = "Jumlah Stok"
                .Columns(7).DefaultCellStyle.Format = "N2"
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).HeaderText = "Satuan"
                .Columns(9).HeaderText = "Harga PPN"
                .Columns(9).DefaultCellStyle.Format = "N2"
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Keterangan"
                .Columns(0).Width = 30
                .Columns(1).Width = 65
                .Columns(2).Width = 75
                .Columns(3).Width = 130
                .Columns(4).Width = 75
                .Columns(5).Width = 75
                .Columns(6).Width = 70
                .Columns(7).Width = 50
                .Columns(8).Width = 75
                .Columns(9).Width = 90
                .Columns(10).Width = 120
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

    Sub tampilObatSeluruh()
        Try
            DA = New OleDb.OleDbDataAdapter("select b.idbarang, b.kd_barang, LTRIM(RTRIM(b.nama_barang)) as nama_barang, b.tanggal, b.tglexp, RTRIM(LTRIM(b.nobatch)), b.jmlstok, RTRIM(LTRIM(b.satuan)), b.hrgppn, RTRIM(LTRIM(m.keterangan)) from ap_belistok b, barang_farmasi m where b.kd_barang=m.kd_barang and b.stsed is null order by b.idbarang", CONN)
            DS = New DataSet
            DA.Fill(DS, "ObatGudang")
            BDObatGudang.DataSource = DS
            BDObatGudang.DataMember = "ObatGudang"
            With gridBarang
                .DataSource = Nothing
                .DataSource = BDObatGudang
                .Columns(1).HeaderText = "ID Barang"
                .Columns(2).HeaderText = "Kode Barang"
                .Columns(3).HeaderText = "Nama Barang"
                .Columns(4).HeaderText = "Tanggal Masuk/ Beli"
                .Columns(5).HeaderText = "Tanggal EXP"
                .Columns(6).HeaderText = "No Batch"
                .Columns(7).HeaderText = "Jumlah Stok"
                .Columns(7).DefaultCellStyle.Format = "N2"
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).HeaderText = "Satuan"
                .Columns(9).HeaderText = "Harga PPN"
                .Columns(9).DefaultCellStyle.Format = "N2"
                .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(10).HeaderText = "Keterangan"
                .Columns(0).Width = 30
                .Columns(1).Width = 65
                .Columns(2).Width = 75
                .Columns(3).Width = 130
                .Columns(4).Width = 75
                .Columns(5).Width = 75
                .Columns(6).Width = 70
                .Columns(7).Width = 50
                .Columns(8).Width = 75
                .Columns(9).Width = 90
                .Columns(10).Width = 120
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

    Sub detailObat()
        Try
            CMD = New OleDb.OleDbCommand("select * FROM ap_belistok WHERE idbarang='" & txtIdxBarang.Text & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                txtKodeObat.Text = Trim(DT.Rows(0).Item("kd_barang"))
                lblNamaObat.Text = Trim(DT.Rows(0).Item("nama_barang"))
                kdJnsObat = Trim(DT.Rows(0).Item("kd_jns_obat"))
                txtHargaJual.DecimalValue = DT.Rows(0).Item("hrgjual")
                txtHargaPPN.DecimalValue = DT.Rows(0).Item("hrgppn")
                txtNamaSatuan.Text = Trim(DT.Rows(0).Item("satuan"))
                DTPTanggalExp.Value = DT.Rows(0).Item("tglexp")
                txtBatch.Text = DT.Rows(0).Item("nobatch")
                txtSisaStok.DecimalValue = DT.Rows(0).Item("jmlstok")
                txtPot.DecimalValue = DT.Rows(0).Item("senpot")
            End If

            CMD = New OleDb.OleDbCommand("select * FROM jenis_obat WHERE kd_jns_obat='" & kdJnsObat & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                jnsObat = Trim(DT.Rows(0).Item("jns_obat"))
            End If
            txtJmlPermintaan.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AturGriddetailBarang()
        With gridDetailObat
            .Columns(0).HeaderText = "No"
            .Columns(1).HeaderText = "Kode"
            .Columns(2).HeaderText = "Nama Barang"
            .Columns(3).HeaderText = "Harga"
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Jumlah Permintaan"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "Satuan"
            .Columns(6).HeaderText = "Jumlah Harga"
            .Columns(6).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderText = "Tanggal Exp"
            .Columns(8).HeaderText = "No Batch"
            .Columns(0).Width = 40
            .Columns(1).Width = 80
            .Columns(2).Width = 275
            .Columns(3).Width = 130
            .Columns(4).Width = 75
            .Columns(5).Width = 80
            .Columns(6).Width = 130
            .Columns(7).Width = 75
            .Columns(8).Width = 80
            .Columns(0).Visible = False
            .Columns(9).Visible = False
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
            Dim str As String = Application.StartupPath & "\Report\notaPermintaanBarangKeGudang.rpt"
            rpt.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rpt.SetDatabaseLogon(dbUser, dbPassword)
            rpt.SetParameterValue("nota", txtNota.Text)
            FormCetak.CrystalReportViewer1.ReportSource = rpt
            FormCetak.CrystalReportViewer1.Show()
            FormCetak.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub TotalHarga()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("jmlharga").Value
        Next
        txtGrandTotal.DecimalValue = HitungTotal
        txtGrandTotalBulat.DecimalValue = buletin(txtGrandTotal.DecimalValue, 100)
    End Sub

    Sub addBarang()
        BDPermintaanObat.DataSource = DSPermintaanObat
        BDPermintaanObat.DataMember = "PermintaanObat"

        BDPermintaanObat.AddNew()
        DRWPermintaanObat = BDPermintaanObat.Current
        DRWPermintaanObat("tanggal") = DTPTanggalTrans.Value
        DRWPermintaanObat("nota") = Trim(txtNota.Text)
        DRWPermintaanObat("nomer") = 1
        DRWPermintaanObat("kdkasir") = Trim(FormLogin.LabelKode.Text)
        DRWPermintaanObat("nmkasir") = Trim(FormLogin.LabelNama.Text)
        DRWPermintaanObat("kdbagian") = pkdapo
        DRWPermintaanObat("nmbagian") = pnmapo
        DRWPermintaanObat("nama") = "-"
        DRWPermintaanObat("idbarang") = Trim(txtIdxBarang.Text)
        DRWPermintaanObat("kdbarang") = Trim(txtKodeObat.Text)
        DRWPermintaanObat("nmbarang") = Trim(lblNamaObat.Text)
        DRWPermintaanObat("kdjenis") = Trim(kdJnsObat)
        DRWPermintaanObat("jml") = txtJmlPermintaan.DecimalValue
        DRWPermintaanObat("nmsatuan") = Trim(txtNamaSatuan.Text)
        DRWPermintaanObat("harga") = txtHargaPPN.DecimalValue
        DRWPermintaanObat("jmlharga") = txtJmlHarga.DecimalValue
        DRWPermintaanObat("tglexp") = DTPTanggalExp.Value
        DRWPermintaanObat("nobatch") = Trim(txtBatch.Text)
        DRWPermintaanObat("jmlstok") = txtSisaStok.DecimalValue
        DRWPermintaanObat("senpot") = txtPot.DecimalValue
        DRWPermintaanObat("posting") = "1"

        BDPermintaanObat.EndEdit()

        gridDetailObat.DataSource = Nothing
        gridDetailObat.DataSource = BDPermintaanObat

        TotalHarga()
    End Sub

    Private Sub FormPermintaanKeGudang_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormPermintaanKeGudang_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnSimpan.PerformClick()
        ElseIf e.KeyCode = Keys.F1 Then
            btnCetakNota.PerformClick()
        ElseIf e.KeyCode = Keys.F10 Then
            btnBaru.PerformClick()
        End If
    End Sub

    Private Sub FormPermintaanKeGudang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Me.KeyPreview = True
        kosongkanDetail()
        kosongkanHeader()
    End Sub

    Private Sub DTPTanggalTrans_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalTrans.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DTPTanggalTrans_ValueChanged(sender As Object, e As EventArgs) Handles DTPTanggalTrans.ValueChanged
        Nota()
    End Sub

    Private Sub txtKodeObat_Click(sender As Object, e As EventArgs) Handles txtKodeObat.Click
        tampilObat()
        PanelBarang.Visible = True
        txtCariBarang.Clear()
        txtCariBarang.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelBarang.Visible = False
    End Sub

    Private Sub FormPermintaanKeGudang_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelBarang.Top = txtKodeObat.Top + 21
        PanelBarang.Left = txtKodeObat.Left
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        tampilObat()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        tampilObatSeluruh()
    End Sub

    Private Sub txtCariBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariBarang.KeyDown
        If e.KeyCode = Keys.Down Then
            gridBarang.Focus()
        End If
    End Sub

    Private Sub txtCariBarang_TextChanged(sender As Object, e As EventArgs) Handles txtCariBarang.TextChanged
        BDObatGudang.Filter = "nama_barang like '%" & txtCariBarang.Text & "%'"
    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                txtIdxBarang.Text = gridBarang.Rows(e.RowIndex).Cells(1).Value
                PanelBarang.Visible = False
                detailObat()
            End If
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                txtIdxBarang.Text = gridBarang.Rows(i).Cells(1).Value
                PanelBarang.Visible = False
                detailObat()
            End If
        End If
    End Sub

    Private Sub txtNota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNota.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlPermintaan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlPermintaan.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtKodeObat_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObat.GotFocus
        tampilObat()
        PanelBarang.Visible = True
        txtCariBarang.Clear()
        txtCariBarang.Focus()
    End Sub

    Private Sub txtJmlPermintaan_LostFocus(sender As Object, e As EventArgs) Handles txtJmlPermintaan.LostFocus
        If txtSisaStok.DecimalValue < txtJmlPermintaan.DecimalValue Then
            txtJmlPermintaan.DecimalValue = 0
            txtJmlPermintaan.Focus()
            MsgBox("Jumlah barang melebihi sisa stok", vbInformation, "Informasi")
            Exit Sub
        End If
        txtJmlHarga.DecimalValue = txtHargaPPN.DecimalValue * txtJmlPermintaan.DecimalValue
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtKodeObat.Text = "" Then
            MsgBox("Obat belum dipilih")
            txtKodeObat.Focus()
            Exit Sub
        End If
        If txtJmlPermintaan.DecimalValue = 0 Then
            MsgBox("Jumlah permintaan belum diisi")
            txtJmlPermintaan.Focus()
            Exit Sub
        End If
        For barisGrid As Integer = 0 To gridDetailObat.RowCount - 1
            If txtIdxBarang.Text = gridDetailObat.Rows(barisGrid).Cells("idbarang").Value Then
                MsgBox("Obat dengan ID : " & Trim(txtIdxBarang.Text) & " ini sudah dientry")
                kosongkanDetail()
                txtKodeObat.Focus()
                Exit Sub
            End If
        Next
        addBarang()
        AturGriddetailBarang()
        txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
        kosongkanDetail()
        btnSimpan.Enabled = True
        btnBaru.Enabled = True
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        kosongkanDetail()
        kosongkanHeader()
    End Sub

    Private Sub gridDetailObat_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObat.CellFormatting
        gridDetailObat.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If MessageBox.Show("Data tersebut sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then

            Dim sqlPermintaanKeGudang As String = ""
            Nota()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                For i = 0 To gridDetailObat.RowCount - 2
                    sqlPermintaanKeGudang = sqlPermintaanKeGudang + vbCrLf + "insert into ap_mintabrg(tanggal, nota, nomer, kdkasir, nmkasir, kdbagian, nmbagian, nama, idbarang, kdbarang, nmbarang, kdjenis, jml, nmsatuan, harga, jmlharga, tglexp, nobatch, jmlstok, senpot, posting, waktu_permintaan) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNota.Text) & "', " & i + 1 & ", '" & Trim(FormLogin.LabelKode.Text) & "','" & Trim(FormLogin.LabelNama.Text) & "','" & pkdapo & "', '" & pnmapo & "', '-', '" & gridDetailObat.Rows(i).Cells("idbarang").Value & "', '" & gridDetailObat.Rows(i).Cells("kdbarang").Value & "', '" & Rep(gridDetailObat.Rows(i).Cells("nmbarang").Value) & "', '" & gridDetailObat.Rows(i).Cells("kdjenis").Value & "', '" & Val(gridDetailObat.Rows(i).Cells("jml").Value) & "', '" & gridDetailObat.Rows(i).Cells("nmsatuan").Value & "', '" & Val(gridDetailObat.Rows(i).Cells("harga").Value) & "', '" & Val(gridDetailObat.Rows(i).Cells("jmlharga").Value) & "', '" & Format(gridDetailObat.Rows(i).Cells("tglexp").Value, "yyyy/MM/dd") & "','" & gridDetailObat.Rows(i).Cells("nobatch").Value & "', '" & Val(gridDetailObat.Rows(i).Cells("jmlstok").Value) & "', '" & Val(gridDetailObat.Rows(i).Cells("senpot").Value) & "','" & gridDetailObat.Rows(i).Cells("posting").Value & "','" & Format(DTPTanggalTrans.Value, "HH:mm:ss") & "')"
                Next

                CMD.CommandText = sqlPermintaanKeGudang
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi permintaan barang berhasil disimpan", vbInformation, "Informasi")
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

    Private Sub btnCetakNota_Click(sender As Object, e As EventArgs) Handles btnCetakNota.Click
        FormPemanggil = "FormPermintaanGudangBPJSKeGudang"
        cetakNota()
        btnCetakNota.Enabled = False
    End Sub
End Class