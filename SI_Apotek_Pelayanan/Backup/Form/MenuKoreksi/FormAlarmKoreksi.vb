Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient

Public Class FormAlarmKoreksi
    Inherits Office2010Form
    Dim status As String

    Sub tampilKoreksi()
        CMD = New OleDb.OleDbCommand("select * from ap_alarmkoreksi where kodeunit='" & pkdapo & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            DTPBulan.Value = Year(Now) & "-" & DT.Rows(0).Item("bulan") & "-" & "01"
            DTPTahun.Value = DT.Rows(0).Item("tahun") & "-" & Month(Now) & "-" & "01"
            status = DT.Rows(0).Item("alarm")
            If status = "2" Then
                Button1.Enabled = False
                Button2.Enabled = True
                TextBox2.Text = "Alarm Aktif"
                PictureBox1.Dock = DockStyle.Fill
                PictureBox1.Visible = True
                PictureBox2.Visible = False
            Else
                Button1.Enabled = True
                Button2.Enabled = False
                TextBox2.Text = "Alarm Non Aktif"
                PictureBox2.Dock = DockStyle.Fill
                PictureBox2.Visible = True
                PictureBox1.Visible = False
            End If
        End If
    End Sub

    Private Sub FormAlarmKoreksi_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Me.Dispose()
    End Sub

    Private Sub FormAlarmKoreksi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        tampilKoreksi()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim edit As String = "UPDATE ap_alarmkoreksi SET bulan='" & Month(DTPBulan.Value) & "', tahun='" & Year(DTPTahun.Value) & "', alarm=2 where kodeunit='" & pkdapo & "'"
            CMD = New OleDb.OleDbCommand(edit, CONN)
            CMD.ExecuteNonQuery()
            TextBox2.Text = "Alarm Aktif"
            Button1.Enabled = False
            Button2.Enabled = True
            PictureBox1.Dock = DockStyle.Fill
            PictureBox1.Visible = True
            PictureBox2.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim edit As String = "UPDATE ap_alarmkoreksi SET bulan='" & Month(DTPBulan.Value) & "', tahun='" & Year(DTPTahun.Value) & "', alarm=1 where kodeunit='" & pkdapo & "'"
            CMD = New OleDb.OleDbCommand(edit, CONN)
            CMD.ExecuteNonQuery()
            TextBox2.Text = "Alarm Non Aktif"
            Button1.Enabled = True
            Button2.Enabled = False
            PictureBox2.Dock = DockStyle.Fill
            PictureBox2.Visible = True
            PictureBox1.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class