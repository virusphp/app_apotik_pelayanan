Imports Syncfusion.Windows.Forms
Imports System.Data.SqlClient
Imports Newtonsoft.Json
Imports System.IO

Public Class FormSetApotik
    Inherits Office2010Form

    Dim kdapoS, nmapoS, kdnotaS, sts_stokS, Kunci_StokS, kd_subUnit As String

    Sub ListNamaApotek()
        CMD = New OleDb.OleDbCommand("select kdapo,nmapo from ap_seting_apotek order by kdapo", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbApotik.Items.Clear()
        cmbApotik.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbApotik.Items.Add(DT.Rows(i)("nmapo") & "|" & DT.Rows(i)("kdapo"))
        Next
        cmbApotik.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbApotik.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub CariKodeApotik(ByVal kdApotik As String)
        CMD = New OleDb.OleDbCommand("select * From ap_seting_apotek where kdapo='" & kdApotik & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Sub KetemuApotik()
        On Error Resume Next
        kdapoS = DT.Rows(0).Item(0)
        nmapoS = DT.Rows(0).Item(1)
        kdnotaS = DT.Rows(0).Item(2)
        sts_stokS = DT.Rows(0).Item(3)
        Kunci_StokS = DT.Rows(0).Item(4)
        kd_subUnit = DT.Rows(0).Item(5)
        txtKdSubUnit.Text = kd_subUnit
        txtKodeNota.Text = kdnotaS
        cmbSetStok.Text = sts_stokS
        txtKunci.Text = Kunci_StokS
        If cmbSetStok.Text = "1" Then
            TextBox3.Text = "UPDATE STOK LANGSUNG"
        Else
            TextBox3.Text = "UPDATE STOK MELALUI PENYERAHAN OBAT"
        End If
    End Sub

    Sub Kosong()
        setApo()
        cmbApotik.Text = pnmapo & "|" & pkdapo
        txtKdSubUnit.Text = pkdsubunit
        txtKodeNota.Text = pkdnota
        cmbSetStok.Text = psts_stok
        txtKunci.Text = CekKunciStokPenjualan
        If cmbSetStok.Text = "1" Then
            TextBox3.Text = "UPDATE STOK LANGSUNG"
        Else
            TextBox3.Text = "UPDATE STOK MELALUI PENYERAHAN OBAT"
        End If
    End Sub

    Private Sub FormSetApotik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Kosong()
        ListNamaApotek()
    End Sub

    Private Sub cmbApotik_Validated(sender As Object, e As EventArgs) Handles cmbApotik.Validated
        If cmbApotik.Text <> "" Then
            Dim cari As String = InStr(cmbApotik.Text, "|")
            If cari Then
                Dim ary As String() = Nothing
                ary = Strings.Split(cmbApotik.Text, "|", -1, CompareMethod.Binary)
                kdapoS = (ary(1))
                CariKodeApotik(ary(1))
                If Not DT.Rows.Count>0 Then
                    cmbApotik.Text = ""
                    MsgBox("Data tidak ada dalam database")
                    cmbApotik.Focus()
                Else
                    KetemuApotik()
                End If
            Else
                cmbApotik.Text = ""
                MsgBox("Data tidak ada dalam database")
                cmbApotik.Focus()
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim config As SettingApotik = JsonConvert.DeserializeObject(Of SettingApotik)(File.ReadAllText(".\config.json"))
        config.pkdapo = kdapoS
        config.pnmapo = nmapoS
        config.pkdnota = kdnotaS
        config.psts_stok = sts_stokS
        config.pkdsubunit = kd_subUnit
        config.CekKunciStokPenjualan = Kunci_StokS
        Dim modifiedJsonString = JsonConvert.SerializeObject(config)
        File.WriteAllText(".\config.json", modifiedJsonString)
        MenuUtama.PanelApotek.Text = nmapoS
        MenuUtama.lblDepo.Text = nmapoS.ToUpper
        MsgBox("Setting Apotik Berhasil")
    End Sub
End Class
