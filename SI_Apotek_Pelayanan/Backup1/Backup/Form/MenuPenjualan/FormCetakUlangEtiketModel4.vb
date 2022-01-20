Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormCetakUlangEtiketModel4
    Inherits Office2010Form
    Dim waktuMinum, ketMinum, jenisObat As String
    Dim DSEtiket, DSEtiketModel4 As New DataSet
    Dim BDEtiket, BDEtiketModel4 As New BindingSource
    Dim DRWEtiketModel4, DRWEtiket As DataRowView

    Sub Kosongkan()
        DSEtiketModel4 = Table.BuatTabelEtiketModel4("EtiketModel4")
        gridEtiket.DataSource = Nothing
        DSEtiketModel4.Clear()
        rPagi.Checked = True
        rSiang.Checked = False
        rSore.Checked = False
        rMalam.Checked = False
        rSebelum.Checked = False
        rSesudah.Checked = True
        rBersama.Checked = False
        cbInjeksi.Checked = False
    End Sub

    Sub IdentifikasiKode()
        If rPagi.Checked = True Then
            waktuMinum = "Pagi"
        ElseIf rSiang.Checked = True Then
            waktuMinum = "Siang"
        ElseIf rSore.Checked = True Then
            waktuMinum = "Sore"
        Else
            waktuMinum = "Malam"
        End If
        If rSebelum.Checked = True Then
            ketMinum = "Sebelum Makan"
        ElseIf rBersama.Checked = True Then
            ketMinum = "Bersama Makan"
        ElseIf rSesudah.Checked = True Then
            ketMinum = "Sesudah Makan"
        Else
            ketMinum = "Injeksi"
        End If
        'If cbInjeksi.Checked = True Then
        '    jenisObat = "Injeksi"
        'Else
        '    jenisObat = "Non Injeksi"
        'End If
    End Sub

    Sub cetakEtiketModel4()
        'Try
        Dim dtReport As New DataTable
        With dtReport
            .Columns.Add("namaObat")
            .Columns.Add("waktuMinum")
            .Columns.Add("ketMinum")
            .Columns.Add("tglExp")
            '.Columns.Add("jenisObat")
        End With
        For i = 0 To gridEtiket.RowCount - 2
            If Not IsDBNull(gridEtiket.Rows(i).Cells(0).Value) Then
                dtReport.Rows.Add(gridEtiket.Rows(i).Cells("namaObat").Value, gridEtiket.Rows(i).Cells("waktuMinum").Value, gridEtiket.Rows(i).Cells("ketMinum").Value, gridEtiket.Rows(i).Cells("tglExp").Value)
            End If
        Next
        Dim rpt As New ReportDocument
        'Dim param As New ParameterFields
        'Dim paramdesc As New ParameterDiscreteValue
        'Dim paramfield As New ParameterField
        'paramfield.Name = "nmPasien"
        'paramfield.Name = "noRM"
        'paramfield.Name = "bulan"
        'paramfield.Name = "tahun"

        Dim str As String = Application.StartupPath & "\report\etiketModel4.rpt"

        'param = rpt.ParameterFields
        'rpt.ParameterFields.Add(paramfield)
        'param("nmPasien").CurrentValues.Clear()
        'paramdesc.Value = txtNamaPasien.Text
        'param("nmPasien").CurrentValues.Add(paramdesc)
        rpt.Load(str)
        rpt.SetDataSource(dtReport)
        rpt.SetParameterValue("nmPasien", Trim(FormCetakEtiketPerBarang.txtNamaPasien.Text))
        rpt.SetParameterValue("noRM", Trim(FormCetakEtiketPerBarang.txtRM.Text))
        rpt.SetParameterValue("bulan", Trim(FormEditPenjualanResep.txtUmurBln.Text))
        rpt.SetParameterValue("tahun", Trim(FormEditPenjualanResep.txtUmurThn.Text))
        'rpt.Refresh()
        rpt.SetParameterValue("ruang", Trim(FormEditPenjualanResep.nmSubUnit))
        rpt.SetParameterValue("bed", Trim(FormEditPenjualanResep.lblKamarBed.Text))


        'FormCetak.CrystalReportViewer1.ReportSource = rpt
        'FormCetak.CrystalReportViewer1.Refresh()
        'FormCetak.ShowDialog()
        'FormCetak.ShowIcon = False
        rpt.PrintToPrinter(1, False, 0, 0)
        rpt.Close()
        rpt.Dispose()
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
    End Sub

    Sub cariEtiketModel4()
        DA = New OleDb.OleDbDataAdapter("SELECT ae.tanggal, ae.notaresep, ae.no_rm, ae.kd_barang, ae.nama_barang, ae.kd_takaran, ae.kd_waktu, ae.kd_ketminum, 
                        ae.qty1, ae.qty2, ae.tgl_exp, ae.signa1, ae.signa2, ae.jml_obat, ae.urut, ae.model, ae.obat, ae.tetes, max(ambl.tglexp) as tglexp,
                        CASE ae.ket_waktu_pagi_model4 WHEN '1' THEN '' ELSE 'Pagi' END AS ket_waktu_pagi_model4, 
                        CASE ae.ket_waktu_siang_model4 WHEN '1' THEN '' ELSE 'Siang' END AS ket_waktu_siang_model4, 
                        CASE ae.ket_waktu_sore_model4 WHEN '1' THEN '' ELSE 'Sore' END AS ket_waktu_sore_model4,
                        CASE ae.ket_waktu_malam_model4 WHEN '1' THEN '' ELSE 'Malam' END AS ket_waktu_malam_model4,
                        CASE ae.ket_minum_model4 WHEN '1' THEN 'Sebelum Makan' WHEN '2' THEN 'Bersama Makan' 
                                              WHEN '3' THEN 'Sesudah Makan' ELSE 'Injeksi' END AS ket_minum_model4 
                        FROM ap_etiketNew as ae INNER JOIN ap_ambil as ambl on ae.kd_barang=ambl.kd_barang
                        WHERE ae.notaresep='" & Trim(FormCetakEtiketPerBarang.txtNotaResep.Text) & "' 
                        AND ae.tanggal='" & Format(FormCetakEtiketPerBarang.DTPTanggalResep.Value, "yyyy/MM/dd") & "'
                        GROUP BY ae.tanggal, ae.notaresep, ae.no_rm, ae.kd_barang, ae.nama_barang, ae.kd_takaran, ae.kd_waktu, ae.kd_ketminum, 
                        ae.qty1, ae.qty2, ae.tgl_exp, ae.signa1, ae.signa2, ae.jml_obat, ae.urut, ae.model, ae.obat, ae.tetes, ae.ket_waktu_pagi_model4,
                        ae.ket_waktu_siang_model4, ae.ket_waktu_sore_model4, ae.ket_waktu_malam_model4, ae.ket_minum_model4 
                        ", CONN)
        'DA = New OleDb.OleDbDataAdapter("SELECT tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, 
        '                qty1, qty2, tgl_exp, signa1, signa2, jml_obat, urut, model, obat, tetes, CASE ket_waktu_pagi_model4
        '                WHEN '1' THEN '' ELSE 'Pagi' END AS ket_waktu_pagi_model4, CASE ket_waktu_siang_model4 
        '                WHEN '1' THEN '' ELSE 'Siang' END AS ket_waktu_siang_model4, CASE ket_waktu_sore_model4 
        '                WHEN '1' THEN '' ELSE 'Sore' END AS ket_waktu_sore_model4, CASE ket_waktu_malam_model4 
        '                WHEN '1' THEN '' ELSE 'Malam' END AS ket_waktu_malam_model4, CASE ket_minum_model4 
        '                WHEN '1' THEN 'Sebelum Makan' WHEN '2' THEN 'Bersama Makan' 
        '                WHEN '3' THEN 'Sesudah Makan' ELSE 'Injeksi' END AS ket_minum_model4 
        '                FROM ap_etiketNew 
        '                WHERE notaresep='" & Trim(FormCetakEtiketPerBarang.txtNotaResep.Text) & "' 
        '                AND tanggal='" & Format(FormCetakEtiketPerBarang.DTPTanggalResep.Value, "yyyy/MM/dd") & "'", CONN)
        DSEtiket = New DataSet
        DA.Fill(DSEtiket, "cetakEtiket")
        BDEtiket.DataSource = DSEtiket
        BDEtiket.DataMember = "cetakEtiket"
        If BDEtiket.Count > 0 Then
            If pkdapo = "002" Then
                BDEtiket.Filter = "model='4'"
                If BDEtiket.Count > 0 Then
                    BDEtiketModel4.DataSource = DSEtiketModel4
                    BDEtiketModel4.DataMember = "EtiketModel4"
                    BDEtiket.MoveFirst()
                    For i = 1 To BDEtiket.Count
                        DRWEtiket = BDEtiket.Current
                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Injeksi" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_sore_model4") = "Sore" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_sore_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yyyy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_sore_model4") = "Sore" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_sore_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_sore_model4") = "Sore" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_sore_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                            BDEtiketModel4.AddNew()
                            DRWEtiketModel4 = BDEtiketModel4.Current
                            DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                            DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                            DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                            DRWEtiketModel4("tglExp") = Format(DRWEtiket.Item("tglexp"), "MM-yy").ToString
                            'DRWEtiketModel4("jenisObat") = "Exp |"
                            BDEtiketModel4.EndEdit()
                        End If

                        BDEtiket.MoveNext()
                    Next
                    gridEtiket.DataSource = Nothing
                    gridEtiket.DataSource = BDEtiketModel4

                    BDEtiketModel4.RemoveFilter()


                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                        IdentifikasiKode()
                        BDEtiketModel4.Filter = "waktuMinum='" & waktuMinum & "' AND ketMinum='" & ketMinum & "'"
                        If (gridEtiket.Rows.Count() - 1) > 0 Then
                            cetakEtiketModel4()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FormCetakUlangEtiketModel4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Kosongkan()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DSEtiketModel4.Clear()
        cariEtiketModel4()
    End Sub

    Private Sub rInjeksi_CheckedChanged(sender As Object, e As EventArgs) Handles rInjeksi.CheckedChanged
        If rInjeksi.Checked = True Then
            rPagi.Checked = True
        End If
    End Sub
End Class