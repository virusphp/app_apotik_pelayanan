Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports Syncfusion.XlsIO
Imports System.Data.SqlClient

Public Class FormInfoResepObat
    Inherits Office2010Form

    Dim BDInfoObat As New BindingSource
    Public sqlCommand As String

    Sub tampilObat()
        Try
            If FormPemanggil = "FormPenjualanNonResep" Or FormPemanggil = "FormEditPenjualanNonResep" Then
                sqlCommand = "SELECT ap_jualbbs2.tanggal, ap_jualbbs2.nota as notaresep, 
                            LTRIM(RTRIM(ap_jualbbs2.nama_barang)) As nama_barang, 0 as jmlpaket, 
                            ap_jualbbs2.jml as jmlnonpaket, 0 as jmljatah, ap_jualbbs2.tanggal as tglakhir, 
                            'UMUM' as nama_penjamin 
                            FROM ap_jualbbs2 INNER JOIN jual_header on ap_jualbbs2.nota = jual_header.no_nota 
                            WHERE jual_header.kd_pelanggan = '" & Trim(txtRM.Text) & "' ORDER BY ap_jualbbs2.tanggal, ap_jualbbs2.nota, ap_jualbbs2.noid desc"
            Else
                sqlCommand = "SELECT ap_jualr2.tanggal, ap_jualr2.notaresep, 
                            LTRIM(RTRIM(ap_jualr2.nama_barang)) as nama_barang, ap_jualr2.jmlpaket, 
                            ap_jualr2.jmlnonpaket, ap_jualr2.jmljatah, ap_jualr2.tglakhir, 
                            case Penjamin.nama_penjamin when '' then 'UMUM' else Penjamin.nama_penjamin end as nama_penjamin 
                            FROM ap_jualr2 
                            LEFT OUTER JOIN Penjamin ON ap_jualr2.kd_penjamin = Penjamin.kd_penjamin 
                            where ap_jualr2.no_rm = '" & Trim(txtRM.Text) & "' ORDER BY ap_jualr2.tanggal, ap_jualr2.notaresep, ap_jualr2.noid desc"
            End If
            DA = New OleDb.OleDbDataAdapter(sqlCommand, CONN)
            DS = New DataSet
            DA.Fill(DS, "infoObat")
            BDInfoObat.DataSource = DS
            BDInfoObat.DataMember = "infoObat"
            With gridResep
                .DataSource = Nothing
                .DataSource = BDInfoObat
                .Columns(0).HeaderText = "Tanggal"
                .Columns(1).HeaderText = "Nota Resep"
                .Columns(2).HeaderText = "Nama Obat"
                .Columns(3).HeaderText = "Jml Paket"
                .Columns(3).DefaultCellStyle.Format = "N2"
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(4).HeaderText = "Jml Non Paket"
                .Columns(4).DefaultCellStyle.Format = "N2"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).HeaderText = "Utk Jml Hari"
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(6).HeaderText = "Tgl Akhir"
                .Columns(7).HeaderText = "Penjamin"
                .Columns(0).Width = 70
                .Columns(1).Width = 85
                .Columns(2).Width = 170
                .Columns(3).Width = 50
                .Columns(4).Width = 50
                .Columns(5).Width = 50
                .Columns(6).Width = 70
                .Columns(7).Width = 160
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
        Catch ex As Exception
            MsgBox("Time Out")
        End Try

    End Sub

    Sub TotalObat()
        Dim Hitung As Decimal = 0
        For baris As Integer = 0 To gridResep.RowCount - 1
            If FormPemanggil = "FormPenjualanNonResep" Or FormPemanggil = "FormEditPenjualanNonResep" Then
                Hitung = Hitung + gridResep.Rows(baris).Cells("jmlnonpaket").Value
            Else
                Hitung = Hitung + gridResep.Rows(baris).Cells("jmlpaket").Value
            End If
        Next
        txtJmlObat.DecimalValue = Hitung
    End Sub

    Private Sub FormInfoResepObat_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub

    Private Sub FormInfoResepObat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        If FormPemanggil = "FormPenjualanResep" Then
            txtRM.Text = FormPenjualanResep.txtRM.Text
            txtNamaPasien.Text = FormPenjualanResep.txtNamaPasien.Text
        ElseIf FormPemanggil = "FormPenjualanResepEMR" Then
            txtRM.Text = FormPenjualanResepEMR.txtRM.Text
            txtNamaPasien.Text = FormPenjualanResepEMR.txtNamaPasien.Text
        ElseIf FormPemanggil = "FormEditPenjualanResepEMR" Then
            txtRM.Text = FormEditPenjualanResepEMR.txtRM.Text
            txtNamaPasien.Text = FormEditPenjualanResepEMR.txtNamaPasien.Text
        ElseIf FormPemanggil = "FormPenjualanNonResep" Then
            txtRM.Text = FormPenjualanNonResep.txtKdPelanggan.Text
            txtNamaPasien.Text = FormPenjualanNonResep.txtNamaPasien.Text
        ElseIf FormPemanggil = "FormEditPenjualanNonResep" Then
            txtRM.Text = FormEditPenjualanNonResep.txtKdPelanggan.Text
            txtNamaPasien.Text = FormEditPenjualanNonResep.txtNamaPasien.Text
        Else
            txtRM.Text = FormEditPenjualanResep.txtRM.Text
            txtNamaPasien.Text = FormEditPenjualanResep.txtNamaPasien.Text
        End If
        tampilObat()
        TotalObat()
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub

    Private Sub txtNamaObat_TextChanged(sender As Object, e As EventArgs) Handles txtNamaObat.TextChanged
        BDInfoObat.Filter = "nama_barang like '%" & txtNamaObat.Text & "%'"
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        If txtJmlObat.DecimalValue = 0 Then
            MsgBox("Belum ada data, silahkan proses terlebih dulu", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        If MessageBox.Show("Apakah akan dieksport ke excel?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            Try
                Dim dtXls As New DataTable
                With dtXls
                    .Columns.Add("tanggal")
                    .Columns.Add("notaresep")
                    .Columns.Add("nama_barang")
                    .Columns.Add("jmlpaket")
                    .Columns.Add("jmlnonpaket")
                    .Columns.Add("jmljatah")
                    .Columns.Add("tglakhir")
                    .Columns.Add("nama_penjamin")
                End With

                For i = 0 To gridResep.RowCount - 1
                    If Not IsDBNull(gridResep.Rows(i).Cells(0).Value) Then
                        dtXls.Rows.Add(gridResep.Rows(i).Cells("tanggal").Value,
                                       gridResep.Rows(i).Cells("notaresep").Value,
                                       gridResep.Rows(i).Cells("nama_barang").Value,
                                       gridResep.Rows(i).Cells("jmlpaket").Value,
                                       gridResep.Rows(i).Cells("jmlnonpaket").Value,
                                       gridResep.Rows(i).Cells("jmljatah").Value,
                                       gridResep.Rows(i).Cells("tglakhir").Value,
                                       gridResep.Rows(i).Cells("nama_penjamin").Value
                                      )
                    End If
                Next

                dtXls.Columns.Add("noUrut", GetType(Integer))
                Dim jumlahrow As Integer = dtXls.Rows.Count
                Dim j As Integer = 0
                While j < jumlahrow
                    dtXls.Rows(j)("noUrut") = j + 1
                    j += 1
                End While

                Dim excelEngine As New ExcelEngine
                excelEngine.Excel.DefaultVersion = ExcelVersion.Excel2007
                Dim workbook As IWorkbook = excelEngine.Excel.Workbooks.Open(Application.StartupPath & "\Report\InfoResepXLSIO.xlsx")
                Dim sheet As IWorksheet = workbook.Worksheets(0)
                sheet.Range("A7").Text = "NAMA PASIEN "
                sheet.Range("A8").Text = "NO PELANGGAN "
                sheet.Range("C7").Text = ": " & txtNamaPasien.Text
                sheet.Range("C8").Text = ": " & txtRM.Text
                Dim marker As ITemplateMarkersProcessor = workbook.CreateTemplateMarkersProcessor
                marker.AddVariable("Data", dtXls)
                marker.ApplyMarkers()
                workbook.Version = ExcelVersion.Excel2007
                workbook.SaveAs("InfoResep_.xlsx")
                dtXls.Columns.Remove("noUrut")
                workbook.Close()
                excelEngine.Dispose()
                System.Diagnostics.Process.Start("InfoResep_.xlsx")
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End If
    End Sub
End Class