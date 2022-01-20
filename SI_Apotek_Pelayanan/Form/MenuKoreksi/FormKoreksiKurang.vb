Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient

Public Class FormKoreksiKurang
    Inherits Office2010Form
    Dim Bulan, Tahun As Integer
    Dim jmlStok As Decimal
    Dim Stok As String
    Dim BDDataBarang As New BindingSource
    'Dim Trans As SqlTransaction
    Dim Trans As OleDb.OleDbTransaction

    Sub kosongkan()
        TglServer()
        DTPTanggalTrans.Value = TanggalServer
        NomorKoreksi()
        DTPBantu.Value = TanggalServer
        DTPTanggalTrans.Enabled = True
        txtKodeObat.Clear()
        txtIdObat.Clear()
        txtKeterangan.Clear()
        lblNamaObat.Text = ""
        txtHarga.DecimalValue = 0
        txtJumlahKoreksi.DecimalValue = 0
        txtKdSatuan.Clear()
        txtTotalHarga.DecimalValue = 0
        DTPTanggalTrans.Focus()
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
            'DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from barang_farmasi WHERE stsaktif ='1' order by kd_barang", CONN)
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

    Sub NomorKoreksi()
        Try
            konek()
            CMD = New OleDb.OleDbCommand("SELECT max(nokoreksi) as nokoreksi FROM ap_koreksiapo_kurang WHERE YEAR(tanggal)='" & Year(DTPTanggalTrans.Value) & "'", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            If IsDBNull(DR.Item("nokoreksi")) Then
                txtNoKoreksi.Text = "KK" + Format(DTPTanggalTrans.Value, "yy") + "00001"
            Else
                txtNoKoreksi.Text = Microsoft.VisualBasic.Right(DR.Item("nokoreksi").ToString, 5) + 1
                If Len(txtNoKoreksi.Text) = 1 Then
                    txtNoKoreksi.Text = "KK" + Format(DTPTanggalTrans.Value, "yy") + "0000" & txtNoKoreksi.Text & ""
                ElseIf Len(txtNoKoreksi.Text) = 2 Then
                    txtNoKoreksi.Text = "KK" + Format(DTPTanggalTrans.Value, "yy") + "000" & txtNoKoreksi.Text & ""
                ElseIf Len(txtNoKoreksi.Text) = 3 Then
                    txtNoKoreksi.Text = "KK" + Format(DTPTanggalTrans.Value, "yy") + "00" & txtNoKoreksi.Text & ""
                ElseIf Len(txtNoKoreksi.Text) = 4 Then
                    txtNoKoreksi.Text = "KK" + Format(DTPTanggalTrans.Value, "yy") + "0" & txtNoKoreksi.Text & ""
                ElseIf Len(txtNoKoreksi.Text) = 5 Then
                    txtNoKoreksi.Text = "KK" + Format(DTPTanggalTrans.Value, "yy") + "" & txtNoKoreksi.Text & ""
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub detailObat()
        konek()
        CMD = New OleDb.OleDbCommand("SELECT * FROM barang_farmasi WHERE kd_barang='" & Trim(txtKodeObat.Text) & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            txtIdObat.Text = Trim(DR.Item("idx_barang"))
            lblNamaObat.Text = Trim(DR.Item("nama_barang"))
            txtHarga.DecimalValue = Math.Ceiling(DR.Item("harga_satuan_netto"))
            txtKdSatuan.Text = Trim(DR.Item("kd_satuan_kecil"))
            DTPTanggalTrans.Enabled = False
            txtJumlahKoreksi.Focus()
        End If
    End Sub

    Sub cekTutupStok()
        konek()
        CMD = New OleDb.OleDbCommand("select kdbagian, bulan, tahun FROM ap_stok_awalapo WHERE kdbagian=" & pkdapo & " and bulan='" & Bulan & "' and tahun='" & Tahun & "'", CONN)
        DR = CMD.ExecuteReader
        DR.Read()
    End Sub

    Private Sub FormKoreksiKurang_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormKoreksiKurang_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F12 Then
            btnSimpan.PerformClick()
        ElseIf e.KeyCode = Keys.F10 Then
            btnBaru.PerformClick()
        End If
    End Sub

    Private Sub FormKoreksiKurang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Me.KeyPreview = True
        kosongkan()
        NomorKoreksi()
    End Sub

    Private Sub txtCariObat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariObat.KeyDown
        If e.KeyCode = Keys.Down Then
            gridBarang.Focus()
        End If
    End Sub

    Private Sub txtCariObat_TextChanged(sender As Object, e As EventArgs) Handles txtCariObat.TextChanged
        BDDataBarang.Filter = "nama_barang like '%" & txtCariObat.Text & "%'"
    End Sub

    Private Sub txtKodeObat_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObat.GotFocus
        DTPBantu.Value = DateAdd("m", 1, DTPTanggalTrans.Value)
        Bulan = Month(DTPBantu.Value)
        Tahun = Year(DTPBantu.Value)
        cekTutupStok()
        If DR.HasRows Then
            DTPTanggalTrans.Focus()
            MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut sudah tutup stok", vbInformation, "Informasi")
            Exit Sub
        Else
            tampilBarang()
            PanelObat.Visible = True
            txtCariObat.Clear()
            txtCariObat.Focus()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelObat.Visible = False
    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                txtKodeObat.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                jmlStok = gridBarang.Rows(e.RowIndex).Cells(4).Value
                PanelObat.Visible = False
                detailObat()
            End If
        End If
    End Sub

    Private Sub txtJumlahKoreksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahKoreksi.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKeterangan.Focus()
        End If
    End Sub

    Private Sub txtJumlahKoreksi_TextChanged(sender As Object, e As EventArgs) Handles txtJumlahKoreksi.TextChanged
        txtTotalHarga.DecimalValue = txtHarga.DecimalValue * txtJumlahKoreksi.DecimalValue
    End Sub

    Private Sub DTPTanggalTrans_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPTanggalTrans.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNoKoreksi.Focus()
        End If
    End Sub

    Private Sub txtNoKoreksi_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoKoreksi.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKodeObat.Focus()
        End If
    End Sub


    Private Sub txtKeterangan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKeterangan.KeyPress
        If e.KeyChar = Chr(13) Then
            btnSimpan.Focus()
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                txtKodeObat.Text = gridBarang.Rows(i).Cells(2).Value
                jmlStok = gridBarang.Rows(i).Cells(4).Value
                PanelObat.Visible = False
                detailObat()
            End If
        End If
    End Sub

    Private Sub txtKeterangan_LostFocus(sender As Object, e As EventArgs) Handles txtKeterangan.LostFocus
        If txtKeterangan.Text = "" Then
            txtKeterangan.Clear()
            txtKeterangan.Text = "Non Data"
        End If
    End Sub

    Private Sub txtKeterangan_TextChanged(sender As Object, e As EventArgs) Handles txtKeterangan.TextChanged

    End Sub

    Private Sub txtKodeObat_TextChanged(sender As Object, e As EventArgs) Handles txtKodeObat.TextChanged

    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        kosongkan()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtKodeObat.Text = "" Then
            MsgBox("Obat belum dipilih", vbInformation, "Informasi")
            txtKodeObat.Focus()
            Exit Sub
        End If
        If txtJumlahKoreksi.DecimalValue = 0 Then
            MsgBox("Jumlah obat belum diisi", vbInformation, "Informasi")
            txtJumlahKoreksi.Focus()
            Exit Sub
        End If
        If jmlStok < txtJumlahKoreksi.DecimalValue Then
            MsgBox("Jumlah koreksi melebihi jumlah stok. " & vbCrLf & "Jumlah stok " & Trim(lblNamaObat.Text) & " hanya = " & jmlStok & "", vbInformation, "Informasi")
            Exit Sub
        End If

        If MessageBox.Show("Data koreksi stok sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlKoreksiStok As String = ""
            TglServer()
            NomorKoreksi()
            konek()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                sqlKoreksiStok = "insert into ap_koreksiapo_kurang(kdbagian, nmbagian, kdkasir, nmkasir, tanggal, nokoreksi, kd_barang, idx_barang, nama_barang, harga, jml, nmsatuan, jmlharga, keterangan, posting) values ('" & pkdapo & "', '" & pnmapo & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoKoreksi.Text) & "', '" & Trim(txtKodeObat.Text) & "', '" & Trim(txtIdObat.Text) & "', '" & Trim(Rep(lblNamaObat.Text)) & "', '" & Val(txtHarga.DecimalValue) & "', '" & Val(txtJumlahKoreksi.DecimalValue) & "', '" & Trim(txtKdSatuan.Text) & "', '" & Val(txtTotalHarga.DecimalValue) & "', '" & Trim(txtKeterangan.Text) & "', '1')"

                sqlKoreksiStok = sqlKoreksiStok + vbCrLf + "update barang_farmasi SET " & Stok & "=" & Stok & "-" & Val(txtJumlahKoreksi.DecimalValue) & " where kd_barang='" & Trim(txtKodeObat.Text) & "'"

                CMD.CommandText = sqlKoreksiStok
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Data sudah disimpan", vbInformation, "Informasi")
                btnBaru.PerformClick()

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
End Class