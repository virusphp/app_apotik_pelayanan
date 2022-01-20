Imports System.Data.SqlClient
Imports Syncfusion.Windows.Forms
Imports System.IO
Imports Newtonsoft.Json

Public Class FormLogin
    Inherits Office2010Form
    Dim hakAkses As String

    Function PrevInstance() As Boolean
        If UBound(Diagnostics.Process.GetProcessesByName(Diagnostics.Process.GetCurrentProcess.ProcessName)) > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub CariKode()
        CMD = New OleDb.OleDbCommand("SELECT * FROM ap_pas_farmasi WHERE pasword='" & txtPassword.Text & "' AND uid='" & txtUserID.Text & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Private Sub ButtonAdv2_Click(sender As Object, e As EventArgs) Handles ButtonAdv2.Click
        Close()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Up Then
            txtUserID.Focus()
        End If
    End Sub

    Private Sub TextBoxExt3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            ButtonAdv1.PerformClick()
        End If
    End Sub

    Private Sub FLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub TextBoxExt1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUserID.KeyPress
        If e.KeyChar = Chr(13) Then
            txtPassword.Focus()
            'pass()
        End If
    End Sub

    Private Sub TextBoxExt1_LostFocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus
        If txtUserID.Text <> "" Then
            Dim myMs As New IO.MemoryStream
            Dim arrimage As Byte()
            Try
                CMD = New OleDb.OleDbCommand("SELECT foto,nama_pegawai,nip FROM Pegawai where kd_pegawai = '" & txtUserID.Text & "'", CONN)
                DA = New OleDb.OleDbDataAdapter(CMD)
                DT = New DataTable
                DA.Fill(DT)
                If DT.Rows.Count > 0 Then
                    If IsDBNull(DT.Rows(0).Item("foto")) Then
                        Me.lblNama.Text = DT.Rows(0).Item("nama_pegawai")
                        Me.lblNip.Text = DT.Rows(0).Item("nip")
                    Else
                        arrimage = DT.Rows(0).Item("foto")
                        For Each ar As Byte In arrimage
                            myMs.WriteByte(ar)
                        Next
                        Me.PictureBox1.Image = System.Drawing.Image.FromStream(myMs)
                        Me.lblNama.Text = DT.Rows(0).Item("nama_pegawai")
                        Me.lblNip.Text = DT.Rows(0).Item("nip")
                        PictureBox1.Visible = True
                        PictureBox2.Visible = False

                    End If
                Else
                    MsgBox("User ID tidak ditemukan", vbCritical, "Kesalahan")
                    txtUserID.Clear()
                    Exit Sub
                End If

                With PictureBox1
                    .SizeMode = PictureBoxSizeMode.StretchImage
                End With

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            txtPassword.Focus()
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        CariKode()
        If DT.Rows.Count > 0 Then
            Dim config As SettingApotik = JsonConvert.DeserializeObject(Of SettingApotik)(File.ReadAllText(".\config.json"))
            MenuUtama.MenuMaster.Enabled = True
            MenuUtama.MenuPenjualan.Enabled = True
            MenuUtama.MenuRetur.Enabled = True
            MenuUtama.MenuStok.Enabled = True
            MenuUtama.MenuMutasi.Enabled = True
            MenuUtama.MenuKoreksi.Enabled = True
            MenuUtama.MenuLaporan.Enabled = True
            MenuUtama.MenuAdmin.Enabled = True
            MenuUtama.MenuVerifikasi.Enabled = True
            MenuUtama.btnLogin.Enabled = False
            MenuUtama.btnLogout.Enabled = True
            MenuUtama.PictureBox1.Image = PictureBox1.Image
            LabelNama.Text = Trim(DT.Rows(0).Item("nmkasir"))
            LabelKode.Text = Trim(DT.Rows(0).Item("kdkasir"))
            MenuUtama.PanelKode.Text = txtUserID.Text
            MenuUtama.PanelNama.Text = lblNama.Text
            TglServer()
            MenuUtama.PanelTanggal.Text = Format(TanggalServer, "dddd, dd MMMM yyyy")
            MenuUtama.UserPic.Image = PictureBox1.Image
            MenuUtama.PanelApotek.Text = config.pnmapo
            MenuUtama.lblDepo.Text = config.pnmapo.ToUpper
            'If My.Settings.pkdapo = "002" Then
            MenuUtama.btnEditStatusBayar.Enabled = True
            'ElseIf Trim(txtPassword.Text) = "1137" Then
            '    MenuUtama.btnEditStatusBayar.Enabled = True
            'Else
            '    MenuUtama.btnEditStatusBayar.Enabled = False
            'End If
            If Trim(txtPassword.Text) = "1111" Then
                MenuUtama.btnFormLaba.Visible = True
            Else
                MenuUtama.btnFormLaba.Visible = False
            End If
            CariKode()
            hakAkses = DT.Rows(0).Item(5)
            If hakAkses = "2" Then
                MenuUtama.btnSetFarmasi.Enabled = True
            Else
                MenuUtama.btnSetFarmasi.Enabled = False
            End If
            Me.Visible = False
            FormPertamaBuka.Label2.Text = config.pnmapo
            FormPertamaBuka.ShowDialog()
        Else
            MsgBox("Password atau User ID salah", vbCritical, "Kesalahan")
            Exit Sub
        End If

    End Sub

End Class
