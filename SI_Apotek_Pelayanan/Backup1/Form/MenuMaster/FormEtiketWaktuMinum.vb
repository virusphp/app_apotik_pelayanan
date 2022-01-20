Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient

Public Class FormEtiketWaktuMinum
    Inherits Office2010Form
    Sub Kosongkan()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox2.Focus()
    End Sub

    Sub Ketemu()
        On Error Resume Next
        TextBox2.Text = DT.Rows(0).Item(1)
        TextBox2.Focus()
    End Sub

    Sub TampilGrid()
        DA = New OleDb.OleDbDataAdapter("select * from ap_etiket_waktu order by noid", CONN)
        DS = New DataSet
        DA.Fill(DS)
        With gridWaktu
            .DataSource = DS.Tables(0)
            .Columns(0).HeaderText = "Kode"
            .Columns(1).HeaderText = "Waktu Minum"
            .Columns(1).Width = 350
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

    Sub CariKode()
        CMD = New OleDb.OleDbCommand("select * from ap_etiket_waktu where noid='" & TextBox1.Text & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Private Sub FormEtiketWaktuMinum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If FormLogin.txtPassword.Text <> "1111" Then
            Button3.Enabled = False
        Else
            Button3.Enabled = True
        End If
        Kosongkan()
        TampilGrid()
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            CariKode()
            TextBox2.Focus()
            If DT.Rows.Count > 0 Then
                Ketemu()
            Else
                Kosongkan()
            End If
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MsgBox("Data Belum Lengkap")
            Exit Sub
        Else
            CariKode()
            If Not DT.Rows.Count > 0 Then
                Dim simpan As String = "insert into ap_etiket_waktu values ('" & TextBox2.Text & "')"
                CMD = New OleDb.OleDbCommand(simpan, CONN)
                CMD.ExecuteNonQuery()
            Else
                Dim edit As String = "update ap_etiket_waktu set waktu='" & TextBox2.Text & "' where noid='" & TextBox1.Text & "'"
                CMD = New OleDb.OleDbCommand(edit, CONN)
                CMD.ExecuteNonQuery()
            End If
            Kosongkan()
            TampilGrid()
            MsgBox("Data Telah Tersimpan")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Kosongkan()
        TampilGrid()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Then
            MsgBox("Kode harus diisi")
            TextBox1.Focus()
            Exit Sub
        End If

        CariKode()
        If Not DT.Rows.Count > 0 Then
            MsgBox("Kode Waktu Minum tidak Ada")
            TextBox1.Focus()
            Exit Sub
        End If

        If MessageBox.Show("Yakin Akan Dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim hapus As String = "delete from ap_etiket_waktu where noid='" & TextBox1.Text & "'"
            CMD = New OleDb.OleDbCommand(hapus, CONN)
            CMD.ExecuteNonQuery()
            Kosongkan()
            TampilGrid()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dispose()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Button1.Focus()
        End If
    End Sub

    Private Sub gridWaktu_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles gridWaktu.CellMouseClick
        On Error Resume Next
        TextBox1.Text = gridWaktu.Rows(e.RowIndex).Cells(0).Value
        CariKode()
        If DT.Rows.Count > 0 Then
            Ketemu()
        End If
    End Sub
End Class