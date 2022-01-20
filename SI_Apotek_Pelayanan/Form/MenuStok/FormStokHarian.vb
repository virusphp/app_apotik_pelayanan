Public Class FormStokHarian
    Dim BDDataBarang As New BindingSource
    Dim kdApotik As String

    Sub tampilBarangSemua()
        If pkdapo = "001" Then
            kdApotik = "stok001"
        ElseIf pkdapo = "002" Then
            kdApotik = "stok002"
        ElseIf pkdapo = "003" Then
            kdApotik = "stok003"
        ElseIf pkdapo = "004" Then
            kdApotik = "stok004"
        ElseIf pkdapo = "005" Then
            kdApotik = "stok005"
        ElseIf pkdapo = "006" Then
            kdApotik = "stok006"
        ElseIf pkdapo = "007" Then
            kdApotik = "stok007"
        End If
        Try
            'DA = New OleDb.OleDbDataAdapter("SELECT idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & kdApotik & ", 
            '    LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan 
            '    from Barang_Farmasi WHERE stsaktif ='1' order by nama_barang", CONN)
            DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & kdApotik & ", 
                LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan 
                from Barang_Farmasi WHERE stsaktif ='1' AND " & kdApotik & "> 0 order by nama_barang", CONN)
            DS = New DataSet
            DA.Fill(DS, "obat")
            BDDataBarang.DataSource = DS
            BDDataBarang.DataMember = "obat"

            With gridBarang
                .DataSource = Nothing
                .DataSource = BDDataBarang
                .Columns(0).HeaderText = "ID Barang"
                .Columns(1).HeaderText = "Kode Barang"
                .Columns(2).HeaderText = "Nama Barang"
                .Columns(3).HeaderText = "Stok"
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(4).HeaderText = "Satuan"
                .Columns(5).HeaderText = "Keterangan"
                .Columns(0).Width = 50
                .Columns(1).Width = 75
                .Columns(2).Width = 190
                .Columns(3).Width = 40
                .Columns(4).Width = 50
                .Columns(5).Width = 120
                .ReadOnly = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ListDepo()
        DA = New OleDb.OleDbDataAdapter("SELECT kdapo,nmapo FROM ap_seting_apotek", CONN)
        DT = New DataTable
        DA.Fill(DT)
        cmbUnit.DataSource = DT
        cmbUnit.DisplayMember = "nmapo"
        cmbUnit.ValueMember = "kdapo"
        cmbUnit.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbUnit.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbUnit.SelectedValue = pkdapo
    End Sub

    Private Sub FormStokHarian_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub

    Private Sub FormStokHarian_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        ListDepo()
        cmbUnit.Enabled = True
        Button1.PerformClick()
    End Sub

    Private Sub cmbUnit_LostFocus(sender As Object, e As EventArgs) Handles cmbUnit.LostFocus
        pkdapo = cmbUnit.SelectedValue.ToString
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tampilBarangSemua()
        cmbUnit.Enabled = False
    End Sub

    Private Sub txtCariObat_TextChanged(sender As Object, e As EventArgs) Handles txtCariObat.TextChanged
        BDDataBarang.Filter = "nama_barang like '%" & txtCariObat.Text & "%'"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        cmbUnit.Enabled = True
        txtCariObat.Clear()
        gridBarang.DataSource = Nothing
    End Sub

End Class