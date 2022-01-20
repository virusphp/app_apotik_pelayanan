Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.OleDb

Public Class FormPelanggan
    Inherits Office2010Form

    Dim queryString, kodePelanggan As String
    Dim BDDataPegawai As New BindingSource

    Private Sub FormPelanggan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        kosongkanHeader()
        ListKonsumen()
        'NoPelanggan()
    End Sub

    Private Sub btnCloseKaryawan_Click(sender As Object, e As EventArgs) Handles btnCloseKaryawan.Click
        PanelPegawai.Visible = False
    End Sub

    Private Sub FormPelanggan_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelPegawai.Top = 0
        PanelPegawai.Left = 0
    End Sub

    Private Sub txtNamaPelanggan_GotFocus(sender As Object, e As EventArgs) Handles txtNamaPelanggan.GotFocus
        If kodePelanggan = "K" Then
            showKaryawan()
            PanelPegawai.Visible = True
            txtCariPegawai.Clear()
            txtCariPegawai.Focus()
        End If
    End Sub

    Private Sub cmbKonsumen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisPelanggan.SelectedIndexChanged
        GenerateKode(cmbJenisPelanggan.Text)
    End Sub

    Private Sub FormPelanggan_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        kosongkanHeader()
    End Sub

    Private Sub txtKodePelanggan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodePelanggan.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbJenisPelanggan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbJenisPelanggan.KeyPress
        If e.KeyChar = Chr(13) Then
            If e.KeyChar = Chr(13) Then
                If cmbJenisPelanggan.Text = "UMUM" Or cmbJenisPelanggan.Text = "umum" Or cmbJenisPelanggan.Text = "KARYAWAN" Or cmbJenisPelanggan.Text = "karyawan" Then
                    txtKodePelanggan.Focus()
                Else
                    MsgBox("Pilih yang benar", vbCritical, "Kesalahan")
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub FormPelanggan_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        kosongkanHeader()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' mendefinisikan semua teks box
        Dim textBoxes = Me.GroupBox2.Controls.OfType(Of TextBox)
        For Each t In textBoxes
            If String.IsNullOrEmpty(t.Text) Then
                MsgBox(Replace(t.Name, "txt", "Kolom ") + " Tidak boleh kosong!!")
                Exit Sub
            End If
        Next t
        Try
            queryString = "INSERT INTO ap_pelanggan_apotik(
                    kode_pelanggan,nama_pelanggan,alamat_pelanggan,jenis_pelanggan,telepon_pelanggan,unit,created_at
                )
                VALUES(
                    '" & txtKodePelanggan.Text & "',
                    '" & txtNamaPelanggan.Text & "',
                    '" & txtAlamat.Text & "',
                    '" & cmbJenisPelanggan.Text & "',
                    '" & txtNoTelepon.Text & "',
                    '" & txtUnit.Text & "',
                    '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd HH:mm:ss") & "'
                )"
            CMD = New OleDbCommand(queryString, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil di simpan", vbInformation, "Simpan")
            Me.Close()
        Catch ex As Exception
            MsgBox("Terdapat kesalhan!!" & ex.Message)
        End Try
    End Sub

    Private Sub txtNamaPelanggan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamaPelanggan.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtUnit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnit.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtAlamat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAlamat.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNoTelepon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoTelepon.KeyPress
        If e.KeyChar = Chr(13) Then
            btnSimpan.Focus()
        End If
    End Sub

    Private Sub cmbJenisPelanggan_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbJenisPelanggan.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtKodePelanggan.Focus()
        End If
    End Sub

    Private Sub txtCariPegawai_TextChanged(sender As Object, e As EventArgs) Handles txtCariPegawai.TextChanged
        BDDataPegawai.Filter = "nama_pegawai like '%" & txtCariPegawai.Text & "%'"
    End Sub

    Private Sub txtCariPegawai_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPegawai.KeyDown
        If e.KeyCode = Keys.Down Then
            gridPegawai.Focus()
        End If
    End Sub

    Private Sub gridPegawai_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPegawai.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridPegawai.Rows(e.RowIndex).Cells("nama_pegawai").Value) Then
                txtNamaPelanggan.Text = gridPegawai.Rows(e.RowIndex).Cells("nama_pegawai").Value
                txtUnit.Text = gridPegawai.Rows(e.RowIndex).Cells("unit_kerja").Value
                txtAlamat.Text = gridPegawai.Rows(e.RowIndex).Cells("alamat").Value
                PanelPegawai.Visible = False
                txtNoTelepon.Focus()
            End If
        End If
    End Sub

    Private Sub gridPegawai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridPegawai.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridPegawai.CurrentRow.Index - 1
            If Not IsDBNull(gridPegawai.Rows(i).Cells(1).Value) Then
                txtNamaPelanggan.Text = gridPegawai.Rows(i).Cells("nama_pegawai").Value
                txtUnit.Text = gridPegawai.Rows(i).Cells("unit_kerja").Value
                txtAlamat.Text = gridPegawai.Rows(i).Cells("alamat").Value
                PanelPegawai.Visible = False
                txtNoTelepon.Focus()
            End If
        End If
    End Sub

    Sub ListKonsumen()
        CMD = New OleDbCommand("select kdkonsumen, nmkonsumen from ap_konsumen order by kdkonsumen", CONN)
        DA = New OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)

        cmbJenisPelanggan.Items.Clear()
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbJenisPelanggan.Items.Add(DT.Rows(i)("nmkonsumen"))
        Next
        cmbJenisPelanggan.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbJenisPelanggan.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub NoPelanggan()
        Try
            'generateKode(cmbKonsumen.SelectedText)
            CMD = New OleDbCommand("select max(kode_pelanggan) as kode_pelanggan from ap_pelanggan_apotik", CONN)
            DA = New OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If IsDBNull(DT.Rows(0).Item("kode_pelanggan")) Then
                txtKodePelanggan.Text = kodePelanggan + Format(DTPTanggalTrans.Value, "yyMMdd") + "001"
            Else
                txtKodePelanggan.Text = Microsoft.VisualBasic.Right(DT.Rows(0).Item("kode_pelanggan").ToString, 3) + 1
                If Len(txtKodePelanggan.Text) = 1 Then
                    txtKodePelanggan.Text = kodePelanggan + Format(DTPTanggalTrans.Value, "yyMMdd") + "00" & txtKodePelanggan.Text & ""
                ElseIf Len(txtKodePelanggan.Text) = 2 Then
                    txtKodePelanggan.Text = kodePelanggan + Format(DTPTanggalTrans.Value, "yyMMdd") + "0" & txtKodePelanggan.Text & ""
                ElseIf Len(txtKodePelanggan.Text) = 3 Then
                    txtKodePelanggan.Text = kodePelanggan + Format(DTPTanggalTrans.Value, "yyMMdd") + "" & txtKodePelanggan.Text & ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub GenerateKode(ByVal kode As String)
        kodePelanggan = Strings.Left(kode, 1)
        SetUnit(kodePelanggan)
        If kodePelanggan <> " " Then
            NoPelanggan()
        End If
    End Sub

    Sub SetUnit(ByVal kode As String)
        If kode = "U" Then
            txtUnit.Text = "UMUM"
        Else
            txtUnit.Text = ""
        End If
    End Sub

    Sub kosongkanHeader()
        cmbJenisPelanggan.Text = ""
        txtKodePelanggan.Text = ""
        txtNamaPelanggan.Text = ""
        txtAlamat.Text = ""
        txtNoTelepon.Text = ""
        cmbJenisPelanggan.Focus()
    End Sub

    Sub showKaryawan()
        Try
            DA = New OleDbDataAdapter("SELECT nama_pegawai, unit_kerja, alamat FROM pegawai
                        WHERE status_pegawai = 1 AND LEN(NIP) > 10 ", CONN)
            DS = New DataSet
            DA.Fill(DS, "pegawai")
            BDDataPegawai.DataSource = DS
            BDDataPegawai.DataMember = "pegawai"

            With gridPegawai
                .DataSource = Nothing
                .DataSource = BDDataPegawai
                .Columns(1).HeaderText = "Nama Pegawai"
                .Columns(2).HeaderText = "Unit Kerja"
                .Columns(3).HeaderText = "Alamat"
                .Columns(0).Width = 20
                .Columns(1).Width = 180
                .Columns(2).Width = 130
                .Columns(3).Width = 280
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

End Class