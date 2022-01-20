Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient

Public Class FormEditEtiketModel4
    Inherits Office2010Form
    Public kdBarang, urut As String
    Dim waktuMinumPagi, waktuMinumSiang, waktuMinumSore, waktuMinumMalam, ketMinum, JenisObat As String

    Sub CariKode()
        If cbPagi.Checked = True Then
            waktuMinumPagi = "2"
        Else
            waktuMinumPagi = "1"
        End If
        If cbSiang.Checked = True Then
            waktuMinumSiang = "2"
        Else
            waktuMinumSiang = "1"
        End If
        If cbSore.Checked = True Then
            waktuMinumSore = "2"
        Else
            waktuMinumSore = "1"
        End If
        If cbMalam.Checked = True Then
            waktuMinumMalam = "2"
        Else
            waktuMinumMalam = "1"
        End If
        If rSebelum.Checked = True Then
            ketMinum = "1"
        ElseIf rBersama.Checked = True Then
            ketMinum = "2"
        ElseIf rSesudah.Checked = True Then
            ketMinum = "3"
        Else
            ketMinum = "4"
        End If
        'If cbInjeksi.Checked = True Then
        '    JenisObat = "2"
        'Else
        '    JenisObat = "1"
        'End If
    End Sub

    Private Sub FormEditEtiketModel4_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            CariKode()
            Dim edit As String = "UPDATE ap_etiketNew SET nama_barang='" & txtNamaObatEtiketModel4.Text & "', ket_waktu_pagi_model4='" & waktuMinumPagi & "', ket_waktu_siang_model4='" & waktuMinumSiang & "', ket_waktu_sore_model4='" & waktuMinumSore & "', ket_waktu_malam_model4='" & waktuMinumMalam & "', ket_minum_model4='" & ketMinum & "' where tanggal='" & Format(FormCetakEtiketPerBarang.DTPTanggalResep.Value, "yyyy/MM/dd") & "' AND notaresep='" & FormCetakEtiketPerBarang.txtNotaResep.Text & "' AND kd_barang='" & kdBarang & "' AND urut='" & urut & "'"
            CMD = New OleDb.OleDbCommand(edit, CONN)
            CMD.ExecuteNonQuery()

            MsgBox("Berhasil diedit", vbInformation, "Informasi")
            FormCetakEtiketPerBarang.tampilObat()
            FormCetakUlangEtiketModel4.ShowDialog()
            Me.Dispose()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub rInjeksi_CheckedChanged(sender As Object, e As EventArgs) Handles rInjeksi.CheckedChanged
        If rInjeksi.Checked = True Then
            cbPagi.Checked = True
            cbSiang.Checked = False
            cbSore.Checked = False
            cbMalam.Checked = False
        End If
    End Sub
End Class