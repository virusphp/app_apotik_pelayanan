Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormRincianObatPasienRI
    Inherits Office2010Form
    Dim BDRincianPasien As New BindingSource
    Dim totalHarga As Decimal
    Dim kdPenjamin, Noreg As String
    Dim rpt = New ReportDocument

    Sub Kosongkan()
        TglServer()
        DTPAwal.Value = TanggalServer
        DTPAkhir.Value = TanggalServer
        DTPBantu.Value = TanggalServer
        CrystalReportViewer1.ReportSource = Nothing
        txtNamaPasien.Clear()
        txtRM.Clear()
        txtPenjamin.Clear()
        txtDokter.Clear()
        DTPAwal.Focus()
    End Sub

    Sub tampilRincianPasien()
        Try
            konek()
            DA = New SqlDataAdapter("SELECT top(1000) Registrasi.tgl_reg, Registrasi.no_reg, Registrasi.no_RM, LTRIM(RTRIM(pasien.nama_pasien)) as nama_pasien, Sub_Unit.nama_sub_unit, Registrasi.jns_rawat, Registrasi.kd_penjamin FROM  Registrasi INNER JOIN Pasien ON Registrasi.no_RM = Pasien.no_RM INNER JOIN Rawat_Inap ON Registrasi.no_reg = Rawat_Inap.no_reg INNER JOIN Tempat_Tidur ON Rawat_Inap.kd_tempat_tidur = Tempat_Tidur.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit where Registrasi.jns_rawat='2' and Registrasi.tgl_reg >='" & Format(DTPBantu.Value, "yyyy/MM/dd") & "' order by registrasi.tgl_reg Asc ", CONN)
            DS = New DataSet
            DA.Fill(DS, "rincianPasien")
            BDRincianPasien.DataSource = DS
            BDRincianPasien.DataMember = "rincianPasien"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDRincianPasien
                .Columns(1).HeaderText = "Tanggal Daftar"
                .Columns(2).HeaderText = "No Registrasi"
                .Columns(3).HeaderText = "No RM"
                .Columns(4).HeaderText = "Nama Pasien"
                .Columns(5).HeaderText = "Ruang"
                .Columns(0).Width = 30
                .Columns(1).Width = 75
                .Columns(2).Width = 90
                .Columns(3).Width = 50
                .Columns(4).Width = 130
                .Columns(5).Width = 120
                .Columns(6).Visible = False
                .Columns(7).Visible = False
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

    Sub cetakRincian()
        rpt = New ReportDocument
        Try
            Dim str As String = Application.StartupPath & "\Report\rincianPasienRI.rpt"
            rpt.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rpt.SetDatabaseLogon(dbUser, dbPassword)
            rpt.SetParameterValue("noRM", txtRM.Text)
            rpt.SetParameterValue("tanggalAkhir", Format(DTPAkhir.Value, "yyyy-MM-dd"))
            rpt.SetParameterValue("tanggalAwal", Format(DTPAwal.Value, "yyyy-MM-dd"))
            rpt.SetParameterValue("tglAwal", Format(DTPAwal.Value, "dd-MM-yyyy"))
            rpt.SetParameterValue("tglAkhir", Format(DTPAkhir.Value, "dd-MM-yyyy"))
            rpt.SetParameterValue("Penjamin", txtPenjamin.Text)
            rpt.SetParameterValue("Dokter", txtDokter.Text)
            rpt.SetParameterValue("petugas", MenuUtama.PanelNama.Text)
            rpt.SetParameterValue("totalHarga", totalHarga)
            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnEx_Click(sender As Object, e As EventArgs) Handles btnEx.Click
        PanelPasien.Visible = False
    End Sub

    Private Sub txtNamaPasien_Click(sender As Object, e As EventArgs) Handles txtNamaPasien.Click
        tampilRincianPasien()
        PanelPasien.Visible = True
        rNama.Checked = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub FormRincianObatPasienRI_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelPasien.Top = txtNamaPasien.Top + 20
        PanelPasien.Left = txtNamaPasien.Left
    End Sub

    Private Sub FormRincianObatPasienRI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosongkan()
    End Sub

    Private Sub txtNamaPasien_GotFocus(sender As Object, e As EventArgs) Handles txtNamaPasien.GotFocus
        tampilRincianPasien()
        PanelPasien.Visible = True
        rNama.Checked = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub DTPAwal_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPAwal.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DTPAkhir_KeyPress(sender As Object, e As KeyPressEventArgs) Handles DTPAkhir.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtNamaPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamaPasien.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub


    Private Sub txtRM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRM.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtCariPasien_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPasien.KeyDown
        If e.KeyCode = Keys.Down Then
            gridPasien.Focus()
        End If
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
        If rRm.Checked = True Then
            BDRincianPasien.Filter = "no_RM like '%" & txtCariPasien.Text & "%'"
        Else
            BDRincianPasien.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
        End If
    End Sub

    Private Sub gridPasien_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPasien.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridPasien.Rows(e.RowIndex).Cells(1).Value) Then
                Noreg = gridPasien.Rows(e.RowIndex).Cells(2).Value
                txtNamaPasien.Text = gridPasien.Rows(e.RowIndex).Cells(4).Value
                txtRM.Text = gridPasien.Rows(e.RowIndex).Cells(3).Value
                If IsDBNull(gridPasien.Rows(e.RowIndex).Cells(7).Value) Then
                    txtPenjamin.Text = "UMUM"
                Else
                    kdPenjamin = gridPasien.Rows(e.RowIndex).Cells(7).Value
                    konek()
                    CMD = New SqlCommand("SELECT kd_penjamin,nama_penjamin FROM penjamin WHERE kd_penjamin='" & kdPenjamin & "'", CONN)
                    DR = CMD.ExecuteReader
                    DR.Read()
                    txtPenjamin.Text = DR.Item(1)
                End If
                konek()
                CMD = New SqlCommand("SELECT Rawat_Inap.no_reg, Rawat_Inap.kd_dokter, CASE Pegawai.gelar_depan WHEN '-' THEN '' ELSE Pegawai.gelar_depan + '. ' END + Pegawai.nama_pegawai + CASE Pegawai.gelar_belakang WHEN '-' THEN '' ELSE ', ' + Pegawai.gelar_belakang END AS Nama_Gelar FROM Rawat_Inap INNER JOIN Pegawai ON Rawat_Inap.kd_dokter = Pegawai.kd_pegawai WHERE Rawat_Inap.no_reg='" & Noreg & "'", CONN)
                DR = CMD.ExecuteReader
                DR.Read()
                txtDokter.Text = DR.Item(2)
                PanelPasien.Visible = False
                btnView.Focus()
            End If
        End If
    End Sub

    Private Sub gridPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridPasien.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridPasien.CurrentRow.Index - 1
            If Not IsDBNull(gridPasien.Rows(i).Cells(1).Value) Then
                Noreg = gridPasien.Rows(i).Cells(2).Value
                txtNamaPasien.Text = gridPasien.Rows(i).Cells(4).Value
                txtRM.Text = gridPasien.Rows(i).Cells(3).Value
                If IsDBNull(gridPasien.Rows(i).Cells(7).Value) Then
                    txtPenjamin.Text = "UMUM"
                Else
                    kdPenjamin = gridPasien.Rows(i).Cells(7).Value
                    konek()
                    CMD = New SqlCommand("SELECT kd_penjamin,nama_penjamin FROM penjamin WHERE kd_penjamin='" & kdPenjamin & "'", CONN)
                    DR = CMD.ExecuteReader
                    DR.Read()
                    txtPenjamin.Text = DR.Item(1)
                End If
                konek()
                CMD = New SqlCommand("SELECT Rawat_Inap.no_reg, Rawat_Inap.kd_dokter, CASE Pegawai.gelar_depan WHEN '-' THEN '' ELSE Pegawai.gelar_depan + '. ' END + Pegawai.nama_pegawai + CASE Pegawai.gelar_belakang WHEN '-' THEN '' ELSE ', ' + Pegawai.gelar_belakang END AS Nama_Gelar FROM Rawat_Inap INNER JOIN Pegawai ON Rawat_Inap.kd_dokter = Pegawai.kd_pegawai WHERE Rawat_Inap.no_reg='" & Noreg & "'", CONN)
                DR = CMD.ExecuteReader
                DR.Read()
                txtDokter.Text = DR.Item(2)
                PanelPasien.Visible = False
                btnView.Focus()
            End If
        End If
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Try
            konek()
            CMD = New SqlCommand("select SUM(totalharga) from ap_jualr2 where no_rm='" & txtRM.Text & "' and (tanggal BETWEEN '" & Format(DTPAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(DTPAkhir.Value, "yyyy-MM-dd") & "')", CONN)
            DR = CMD.ExecuteReader
            DR.Read()
            totalHarga = DR.Item(0)
            totalHarga = buletin(totalHarga, 100)
            cetakRincian()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DTPAwal_ValueChanged(sender As Object, e As EventArgs) Handles DTPAwal.ValueChanged
        DTPBantu.Value = DateAdd("d", -2, DTPAwal.Value)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Kosongkan()
    End Sub
End Class