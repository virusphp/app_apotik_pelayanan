Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormCetakEtiketPerBarang
    Inherits Office2010Form
    Dim kdBarang, urut As String
    Dim BDEtiket As New BindingSource

    Sub Kosongkan()
        If FormPemanggil = "FormEditPenjualanResep_Nota" Or FormPemanggil = "FormEditPenjualanResep" Then
            DTPTanggalResep.Value = FormEditPenjualanResep.DTPTanggalTrans.Value
            txtNotaResep.Text = FormEditPenjualanResep.txtNoResep.Text
            txtRM.Text = FormEditPenjualanResep.txtRM.Text
            txtNamaPasien.Text = FormEditPenjualanResep.txtNamaPasien.Text
        ElseIf FormPemanggil = "FormEditPenjualanNonResep" Then
            DTPTanggalResep.Value = FormEditPenjualanNonResep.DTPTanggalTrans.Value
            txtNotaResep.Text = FormEditPenjualanNonResep.txtNota.Text
            txtRM.Text = "-"
            txtNamaPasien.Text = FormEditPenjualanNonResep.txtNamaPasien.Text
        ElseIf FormPemanggil = "FormEditPenjualanResepEMR" Then
            DTPTanggalResep.Value = FormEditPenjualanResepEMR.DTPTanggalTrans.Value
            txtNotaResep.Text = FormEditPenjualanResepEMR.txtNoResep.Text
            txtRM.Text = FormEditPenjualanResepEMR.txtRM.Text
            txtNamaPasien.Text = FormEditPenjualanResepEMR.txtNamaPasien.Text
        End If
        txtNamaObat.Clear()
        txtNamaObat.Focus()
    End Sub

    Sub tampilObat()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT ap_etiketNew.kd_barang, ap_etiketNew.nama_barang, ap_etiketNew.urut, 
                        ap_etiketNew.model, ap_etiketNew.tgl_exp, ap_etiketNew.signa1, ap_etiketNew.signa2, ap_etiketNew.jml_obat, 
                        ap_etiketNew.obat, ap_etiketNew.tetes, ap_etiket_takaran.takaran, ap_etiket_waktu.waktu, 
                        ap_etiket_ketminum.ketminum, DateDiff(Day, ap_etiketNew.tanggal, ap_etiketNew.tgl_exp) AS jarak_ed, 
                        CASE ket_waktu_pagi_model4 WHEN '1' THEN '' ELSE 'Pagi' END AS ket_waktu_pagi_model4, 
                        CASE ket_waktu_siang_model4 WHEN '1' THEN '' ELSE 'Siang' END AS ket_waktu_siang_model4, 
                        CASE ket_waktu_sore_model4 WHEN '1' THEN '' ELSE 'Sore' END AS ket_waktu_sore_model4, 
                        CASE ket_waktu_malam_model4 WHEN '1' THEN '' ELSE 'Malam' END AS ket_waktu_malam_model4, 
                        CASE ket_minum_model4 WHEN '1' THEN 'Sebelum Makan' WHEN '2' THEN 'Bersama Makan' 
                            WHEN '3' THEN 'Sesudah Makan' ELSE 'Injeksi' END AS ket_minum_model4 
                        FROM ap_etiketNew LEFT OUTER JOIN ap_etiket_ketminum ON ap_etiketNew.kd_ketminum = ap_etiket_ketminum.noid 
                        LEFT OUTER JOIN ap_etiket_waktu ON ap_etiketNew.kd_waktu = ap_etiket_waktu.noid 
                        LEFT OUTER JOIN ap_etiket_takaran ON ap_etiketNew.kd_takaran = ap_etiket_takaran.noid 
                        where ap_etiketNew.notaresep='" & txtNotaResep.Text & "' and ap_etiketNew.tanggal='" & Format(DTPTanggalResep.Value, "yyyy/MM/dd") & "'", CONN)
            DS = New DataSet
            DA.Fill(DS, "cetakEtiket")
            BDEtiket.DataSource = DS
            BDEtiket.DataMember = "cetakEtiket"
            With gridEtiket
                .DataSource = Nothing
                .DataSource = BDEtiket
                .Columns(0).HeaderText = "Cetak"
                .Columns(1).HeaderText = "Edit"
                .Columns(2).HeaderText = "Kode Barang"
                .Columns(3).HeaderText = "Nama Barang"
                .Columns(4).HeaderText = "urut"
                .Columns(0).Width = 40
                .Columns(1).Width = 40
                .Columns(2).Width = 85
                .Columns(3).Width = 300
                .Columns(4).Visible = False
                .Columns(5).Visible = False
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .Columns(8).Visible = False
                .Columns(9).Visible = False
                .Columns(10).Visible = False
                .Columns(11).Visible = False
                .Columns(12).Visible = False
                .Columns(13).Visible = False
                .Columns(14).Visible = False
                .Columns(15).Visible = False
                .Columns(16).Visible = False
                .Columns(17).Visible = False
                .Columns(18).Visible = False
                .Columns(19).Visible = False
                .Columns(20).Visible = False
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

    Sub cetakEtiket()
        If MessageBox.Show("Apakah akan cetak etiket ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim rpt As New ReportDocument
            Try
                Dim str As String = Application.StartupPath & "\Report\etiket.rpt"
                rpt.Load(str)
                rpt.SetDatabaseLogon(dbUser, dbPassword)
                rpt.SetParameterValue("tanggal", Format(DTPTanggalResep.Value, "yyyy/MM/dd"))
                rpt.SetParameterValue("notaresep", Trim(txtNotaResep.Text))
                rpt.SetParameterValue("kdbarang", Trim(kdBarang))
                rpt.SetParameterValue("urut", Trim(urut))
                rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                rpt.SetParameterValue("bulan", Trim(FormEditPenjualanResep.txtUmurBln.Text))
                rpt.SetParameterValue("tahun", Trim(FormEditPenjualanResep.txtUmurThn.Text))
                rpt.SetParameterValue("user", Trim(FormLogin.LabelNama.Text))
                rpt.PrintToPrinter(1, False, 0, 0)
                rpt.Close()
                rpt.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
        End Try
        End If
    End Sub

    Sub cetakEtiketNonResep()
        If MessageBox.Show("Apakah akan cetak etiket ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim rpt As New ReportDocument
            Try
                Dim str As String = Application.StartupPath & "\Report\etiketNonResep.rpt"
                rpt.Load(str)
                rpt.SetDatabaseLogon(dbUser, dbPassword)
                rpt.SetParameterValue("tanggal", Format(DTPTanggalResep.Value, "yyyy/MM/dd"))
                rpt.SetParameterValue("notaresep", Trim(txtNotaResep.Text))
                rpt.SetParameterValue("kdbarang", Trim(kdBarang))
                rpt.SetParameterValue("urut", Trim(urut))
                rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                rpt.SetParameterValue("user", Trim(FormLogin.LabelNama.Text))
                rpt.PrintToPrinter(1, False, 0, 0)
                rpt.Close()
                rpt.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub cetakEtiketModel3()
        If MessageBox.Show("Apakah akan cetak etiket ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim rpt As New ReportDocument
            Try
                Dim str As String = Application.StartupPath & "\Report\etiketModel3.rpt"
                rpt.Load(str)
                'FormCetak.CrystalReportViewer1.Refresh()
                rpt.SetDatabaseLogon(dbUser, dbPassword)
                rpt.SetParameterValue("tanggal", Format(DTPTanggalResep.Value, "yyyy/MM/dd"))
                rpt.SetParameterValue("notaresep", Trim(txtNotaResep.Text))
                rpt.SetParameterValue("kdbarang", Trim(kdBarang))
                rpt.SetParameterValue("urut", Trim(urut))
                rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                rpt.SetParameterValue("bulan", Trim(FormEditPenjualanResep.txtUmurBln.Text))
                rpt.SetParameterValue("tahun", Trim(FormEditPenjualanResep.txtUmurThn.Text))
                rpt.SetParameterValue("user", Trim(FormLogin.LabelNama.Text))
                rpt.PrintToPrinter(1, False, 0, 0)
                rpt.Close()
                rpt.Dispose()
                'FormCetak.CrystalReportViewer1.ReportSource = rpt
                'FormCetak.CrystalReportViewer1.Show()
                'FormCetak.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub cetakEtiketInfus()
        If MessageBox.Show("Apakah akan cetak etiket ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim rpt As New ReportDocument
            Try
                Dim str As String = Application.StartupPath & "\Report\etiketInfus.rpt"
                rpt.Load(str)
                'FormCetak.CrystalReportViewer1.Refresh()
                rpt.SetDatabaseLogon(dbUser, dbPassword)
                rpt.SetParameterValue("tanggal", Format(DTPTanggalResep.Value, "yyyy/MM/dd"))
                rpt.SetParameterValue("notaresep", Trim(txtNotaResep.Text))
                rpt.SetParameterValue("kdbarang", Trim(kdBarang))
                rpt.SetParameterValue("urut", Trim(urut))
                rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                rpt.SetParameterValue("bulan", Trim(FormEditPenjualanResep.txtUmurBln.Text))
                rpt.SetParameterValue("tahun", Trim(FormEditPenjualanResep.txtUmurThn.Text))
                rpt.SetParameterValue("user", Trim(FormLogin.LabelNama.Text))
                rpt.SetParameterValue("ruang", Trim(FormEditPenjualanResep.nmSubUnit))
                rpt.SetParameterValue("kamar", Trim(FormEditPenjualanResep.lblKamarBed.Text))
                rpt.PrintToPrinter(1, False, 0, 0)
                rpt.Close()
                rpt.Dispose()
                'FormCetak.CrystalReportViewer1.ReportSource = rpt
                'FormCetak.CrystalReportViewer1.Show()
                'FormCetak.ShowDialog()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub FormCetakEtiketPerBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Dispose()
        End If
    End Sub

    Private Sub FormCetakEtiketPerBarang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        Kosongkan()
        tampilObat()
    End Sub

    Private Sub txtNamaObat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNamaObat.KeyDown
        If e.KeyCode = Keys.Down Then
            gridEtiket.Focus()
        End If
    End Sub

    Private Sub txtNamaObat_TextChanged(sender As Object, e As EventArgs) Handles txtNamaObat.TextChanged
        BDEtiket.Filter = "nama_barang like '%" & txtNamaObat.Text & "%'"
    End Sub

    Private Sub gridEtiket_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridEtiket.CellContentClick
        If e.ColumnIndex = 0 Then
            kdBarang = gridEtiket.Rows(e.RowIndex).Cells("kd_barang").Value
            urut = gridEtiket.Rows(e.RowIndex).Cells("urut").Value
            If gridEtiket.Rows(e.RowIndex).Cells("model").Value = "1" Then
                If FormPemanggil = "FormEditPenjualanResep_Nota" Or FormPemanggil = "FormEditPenjualanResep" Or FormPemanggil = "FormEditPenjualanResepEMR" Then
                    cetakEtiket()
                ElseIf FormPemanggil = "FormEditPenjualanNonResep" Then
                    cetakEtiketNonResep()
                End If
            ElseIf gridEtiket.Rows(e.RowIndex).Cells("model").Value = "2" Then
                cetakEtiketInfus()
            ElseIf gridEtiket.Rows(e.RowIndex).Cells("model").Value = "3" Then
                cetakEtiketModel3()
            Else
                FormCetakUlangEtiketModel4.ShowDialog()
            End If
        End If
        If e.ColumnIndex = 1 Then
            kdBarang = gridEtiket.Rows(e.RowIndex).Cells("kd_barang").Value
            urut = gridEtiket.Rows(e.RowIndex).Cells("urut").Value
            If gridEtiket.Rows(e.RowIndex).Cells("model").Value = "1" Then
                FormEditEtiketModel1.ListEtiketWaktu()
                FormEditEtiketModel1.ListEtiketKeterangan()
                FormEditEtiketModel1.ListEtiketTakaran()
                FormEditEtiketModel1.txtNamaObatEtiket.Text = gridEtiket.Rows(e.RowIndex).Cells("nama_barang").Value
                FormEditEtiketModel1.txtJumlahObatEtiket.DecimalValue = gridEtiket.Rows(e.RowIndex).Cells("jml_obat").Value
                FormEditEtiketModel1.txtSigna1.Text = gridEtiket.Rows(e.RowIndex).Cells("signa1").Value
                FormEditEtiketModel1.txtSigna2.Text = gridEtiket.Rows(e.RowIndex).Cells("signa2").Value
                FormEditEtiketModel1.cmbTakaran.Text = gridEtiket.Rows(e.RowIndex).Cells("takaran").Value
                FormEditEtiketModel1.cmbWaktu.Text = gridEtiket.Rows(e.RowIndex).Cells("waktu").Value
                FormEditEtiketModel1.cmbKeterangan.Text = gridEtiket.Rows(e.RowIndex).Cells("ketminum").Value
                FormEditEtiketModel1.txtJarakED.DecimalValue = gridEtiket.Rows(e.RowIndex).Cells("jarak_ed").Value
                FormEditEtiketModel1.kdBarang = kdBarang
                FormEditEtiketModel1.urut = urut
                FormEditEtiketModel1.ShowDialog()
            ElseIf gridEtiket.Rows(e.RowIndex).Cells("model").Value = "2" Then
                FormEditEtiketModel2.txtNamaObatEtiketInfus.Text = gridEtiket.Rows(e.RowIndex).Cells("nama_barang").Value
                FormEditEtiketModel2.txtJumlahObatEtiketInfus.DecimalValue = gridEtiket.Rows(e.RowIndex).Cells("jml_obat").Value
                FormEditEtiketModel2.txtObatInfus.Text = gridEtiket.Rows(e.RowIndex).Cells("obat").Value
                FormEditEtiketModel2.txtTetesInfus.Text = gridEtiket.Rows(e.RowIndex).Cells("tetes").Value
                FormEditEtiketModel2.kdBarang = kdBarang
                FormEditEtiketModel2.urut = urut
                FormEditEtiketModel2.ShowDialog()
            ElseIf gridEtiket.Rows(e.RowIndex).Cells("model").Value = "3" Then
                FormEditEtiketModel3.ListEtiketKeterangan()
                FormEditEtiketModel3.txtNamaObatEtiketModel3.Text = gridEtiket.Rows(e.RowIndex).Cells("nama_barang").Value
                FormEditEtiketModel3.txtJumlahObatEtiketModel3.DecimalValue = gridEtiket.Rows(e.RowIndex).Cells("jml_obat").Value
                FormEditEtiketModel3.cmbKeteranganModel3.Text = gridEtiket.Rows(e.RowIndex).Cells("ketminum").Value
                FormEditEtiketModel3.txtJarakEDModel3.DecimalValue = gridEtiket.Rows(e.RowIndex).Cells("jarak_ed").Value
                FormEditEtiketModel3.kdBarang = kdBarang
                FormEditEtiketModel3.urut = urut
                FormEditEtiketModel3.ShowDialog()
            Else
                FormEditEtiketModel4.txtNamaObatEtiketModel4.Text = gridEtiket.Rows(e.RowIndex).Cells("nama_barang").Value
                If gridEtiket.Rows(e.RowIndex).Cells("ket_waktu_pagi_model4").Value <> "" Then
                    FormEditEtiketModel4.cbPagi.Checked = True
                Else
                    FormEditEtiketModel4.cbPagi.Checked = False
                End If
                If gridEtiket.Rows(e.RowIndex).Cells("ket_waktu_siang_model4").Value <> "" Then
                    FormEditEtiketModel4.cbSiang.Checked = True
                Else
                    FormEditEtiketModel4.cbSiang.Checked = False
                End If
                If gridEtiket.Rows(e.RowIndex).Cells("ket_waktu_sore_model4").Value <> "" Then
                    FormEditEtiketModel4.cbSore.Checked = True
                Else
                    FormEditEtiketModel4.cbSore.Checked = False
                End If
                If gridEtiket.Rows(e.RowIndex).Cells("ket_waktu_malam_model4").Value <> "" Then
                    FormEditEtiketModel4.cbMalam.Checked = True
                Else
                    FormEditEtiketModel4.cbMalam.Checked = False
                End If
                If gridEtiket.Rows(e.RowIndex).Cells("ket_minum_model4").Value = "Sebelum Makan" Then
                    FormEditEtiketModel4.rSebelum.Checked = True
                ElseIf gridEtiket.Rows(e.RowIndex).Cells("ket_minum_model4").Value = "Bersama Makan" Then
                    FormEditEtiketModel4.rBersama.Checked = True
                ElseIf gridEtiket.Rows(e.RowIndex).Cells("ket_minum_model4").Value = "Sesudah Makan" Then
                    FormEditEtiketModel4.rSesudah.Checked = True
                Else
                    FormEditEtiketModel4.rInjeksi.Checked = True
                End If
                FormEditEtiketModel4.kdBarang = kdBarang
                FormEditEtiketModel4.urut = urut
                FormEditEtiketModel4.ShowDialog()
            End If
        End If
    End Sub

    Private Sub ButtonAdv1_Click(sender As Object, e As EventArgs) Handles ButtonAdv1.Click
        Dispose()
    End Sub
End Class