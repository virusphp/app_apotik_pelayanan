Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports CrystalDecisions.CrystalReports.Engine
Imports Syncfusion.XlsIO
Imports CrystalDecisions.Shared
Imports System.Web.UI.WebControls

Public Class FormEditPenjualanResepEMR
    Inherits Office2010Form

    Dim Trans As OleDb.OleDbTransaction
    Dim tglLahirPasien As DateTime
    Dim HargaBeli, DiskonDinkes As Double

    Dim Bulan, Tahun As Integer

    Dim DSPenjualanResep, DSPenjualanResepKh, DSEtiket,
        DSPermintaanObat, DSPermintaanObatDetail, DSPermintaanObatRacikDetail,
        DSPelayananResep, DSEtiketModel4 As New DataSet

    Dim BDPenjualanResep, BDPenjualanResepKh, BDDataBarang,
        BDDataPasien, BDEtiket, BDPermintaanObat,
        BDPermintaanObatDetail, BDPermintaanObatRacikDetail,
        BDPelayananResep, BDEtiketModel4 As New BindingSource

    Dim DRWPenjualanResep, DRWPenjualanResepKh, DRWEtiket,
        DRWPermintaanObat, DRWPermintaanObatDetail, DRWPermintaanObatRacikDetail,
        DRWPelayananResep, DRWEtiketModel4 As DataRowView

    'Dim Trans As SqlTransaction
    Public rptNota, rptBPJS, rptLain As New ReportDocument
    Dim StatusRawat, JenisRawat, KdPenjamin, kdDokter, kdPoliklinik, kdTempatTidur, Stok, Generik, KdJenisObat, kdPabrik,
        kdKelompokObat, kdGolonganObat, NamaPenjamin, NamaDokter, kdTakaran, kdWaktu, kdKeterangan, JenisObat, memStok,
        kdSubUnit, nmPaket, kDRekening, modelEtiket, kdKeteranganModel3, nmKeteranganModel3, Posting,
        kdICDSKU, kdICDRM, noPermintaanObat, nmObatPermintaan, status_iteration, iteration_banyak,
        iteration_terlayani, kdObatPermintaan, jmlObatPermintaan, noKartu, noSep, nama_barang, status As String


    Sub KosongkanHeader()
        DSPenjualanResep = Table.BuatTabelPenjualanResep("PenjualanResep")
        DSPermintaanObat = Table.BuatTabelPermintaanObat("PermintaanObat")
        DSPermintaanObatDetail = Table.BuatTabelPermintaanObatDetail("PermintaanObatDetail")
        DSPermintaanObatRacikDetail = Table.BuatTabelPermintaanObatRacikDetail("PermintaanObatRacikDetail")
        DSPelayananResep = Table.BuatTablePelayananResep("PelayananResep")
        DSPenjualanResepKh = Table.BuatTabelPenjualanResepKh("PenjualanResepKh")
        DSEtiketModel4 = Table.BuatTabelEtiketModel4("EtiketModel4")
        gridDetailObat.BackgroundColor = Color.Azure
        DSPenjualanResep.Clear()
        gridDetailObat.DataSource = Nothing
        gridDetailObat.DataSource = Nothing
        gridDetailObatKh.BackgroundColor = Color.Azure
        DSPenjualanResepKh.Clear()
        gridDetailObatKh.DataSource = Nothing
        DSEtiketModel4.Clear()
        gridEtiket.DataSource = Nothing
        TglServer()
        DTPTanggalTrans.Value = TanggalServer
        DTPJamAwal.Value = TanggalServer
        DTPTanggalExp.Value = DateAdd("d", 30, DTPTanggalTrans.Value)
        lblKamarBed.Text = ""
        txtNoResep.Clear()
        txtNoReg.Clear()
        txtNoKartu.Clear()
        txtNoUrut.Clear()
        txtRM.Clear()
        txtSex.Clear()
        txtUmurBln.Clear()
        txtUmurThn.Clear()
        txtNamaPasien.Clear()
        txtAlamat.Clear()
        txtGrandTotal.Clear()
        txtGrandTotalBulat.Clear()
        txtGrandDijamin.Clear()
        txtGrandDijaminBulat.Clear()
        txtGrandIurBayar.Clear()
        txtGrandIurBayarBulat.Clear()
        txtGrandTotalPaket.Clear()
        txtGrandTotalPaketBulat.Clear()
        txtGrandTotalNonPaket.Clear()
        txtGrandTotalNonPaketBulat.Clear()
        txtQty.Clear()
        txtQtyKh.Clear()
        cmbUnitAsal.Text = ""
        cmbPenjamin.Text = ""
        cmbDokter.Text = ""
        txtNota.Text = "-"
        btnSimpan.Enabled = False
        btnCetakNota.Enabled = False
        btnCetakEtiket.Enabled = False
        btnInfoResep.Enabled = False
        btnBaru.Enabled = False
        btnSimpanKh.Enabled = False
        btnCetakBPJS.Enabled = False
        'btnCetakLain.Enabled = False
        btnInfoResepKh.Enabled = False
        btnCetakEtiketKh.Enabled = False
        btnBaruKh.Enabled = False
        TabPktUmum.TabVisible = True
        TabPktKhusus.TabVisible = False
        cmbPkt.SelectedIndex = 0
        NoUrut()
        'If  pkdapo = "002" Or  pkdapo = "005" Then
        '    btnModel2.Enabled = True
        'Else
        '    btnModel2.Enabled = False
        'End If
        CariLaba()
        gridPermintaanObat.DataSource = Nothing
        gridObatJadi.DataSource = Nothing
        gridObatRacikan.DataSource = Nothing
        PanelResepDokter.Visible = True
        GBObatJadi.Visible = True
        GBObatRacikan.Visible = True
        GBObatJadi.Dock = DockStyle.Top
        GBObatRacikan.Dock = DockStyle.Fill
        txtNoResep.Focus()
    End Sub

    Sub KosongkanDetailPaketUmum()
        cmbRacikNon.Text = "N"
        lblNamaObat.Text = ""
        txtKodeObat.Clear()
        txtIdObat.Clear()
        txtDosis.Clear()
        txtDosisResep.Clear()
        txtJmlBungkus.Clear()
        txtSatDosis.Clear()
        txtHargaJual.Clear()
        txtJumlahJual.Clear()
        txtKdSatuan.Clear()
        txtSenPotBeli.Clear()
        txtJumlahHarga.Clear()
        txtDijamin.Clear()
        cmbDijamin.Text = ""
        txtIuranSisaBayar.Clear()
        txtJmlHari.IntegerValue = 0
        cmbEtiket.Text = "N"
        txtNamaObatEtiket.Clear()
        cmbTakaran.SelectedIndex = 1
        cmbWaktu.SelectedIndex = 1
        cmbKeterangan.SelectedIndex = 1
        cmbKeteranganModel3.SelectedIndex = 1
        txtSigna1.Text = "0"
        txtSigna2.Text = "0"
        txtQty3.DecimalValue = 0
        txtJumlahObatEtiket.DecimalValue = 0
        txtJarakED.DecimalValue = 0
        modelEtiket = "1"
        txtNamaObatEtiketInfus.Clear()
        txtJumlahObatEtiketInfus.Clear()
        txtNamaObatEtiketModel3.Clear()
        txtJumlahObatEtiketModel3.Clear()
        txtJarakEDModel3.Clear()
        txtObatInfus.Clear()
        txtTetesInfus.Clear()
        txtNamaObatEtiketModel4.Clear()
        cbMalam.Checked = False
        cbSore.Checked = False
        cbSiang.Checked = False
        cbPagi.Checked = False
        rSesudah.Checked = True
        cbInjeksi.Checked = False
    End Sub

    Sub KosongkanDetailPaketKhusus()
        cmbRacikNonKh.Text = "N"
        lblNamaObatKh.Text = ""
        txtKodeObatKh.Clear()
        txtIdObatKh.Clear()
        txtDosisKh.Clear()
        txtSatDosisKh.Clear()
        txtHargaJualKh.Clear()
        txtDosisResepKh.Clear()
        txtJmlCapBPJSKh.Clear()
        txtJmlCapLainKh.Clear()
        txtJmlObatKh.Clear()
        txtPaketBPJSKh.Clear()
        txtSatPaketBPJSKh.Clear()
        txtPaketLainKh.Clear()
        txtSatPaketLainKh.Clear()
        txtTotalPaketBPJSKh.Clear()
        txtTotalPaketLainKh.Clear()
        txtJmlHariKh.IntegerValue = 0
        cmbEtiketKh.Text = "N"
        txtNamaObatEtiket.Clear()
        cmbTakaran.SelectedIndex = 1
        cmbWaktu.SelectedIndex = 1
        cmbKeterangan.SelectedIndex = 1
        cmbKeteranganModel3.SelectedIndex = 1
        txtSigna1.Text = "0"
        txtSigna2.Text = "0"
        txtQty3.DecimalValue = 0
        txtJumlahObatEtiket.DecimalValue = 0
        txtJarakED.DecimalValue = 0
        modelEtiket = "1"
        txtNamaObatEtiketInfus.Clear()
        txtJumlahObatEtiketInfus.Clear()
        txtJumlahObatEtiketModel3.Clear()
        txtNamaObatEtiketModel3.Clear()
        txtJarakEDModel3.Clear()
        txtObatInfus.Clear()
        txtTetesInfus.Clear()
        txtNamaObatEtiketModel4.Clear()
        cbMalam.Checked = False
        cbSore.Checked = False
        cbSiang.Checked = False
        cbPagi.Checked = False
        rSesudah.Checked = True
        cbInjeksi.Checked = False
    End Sub

    Private Sub gridObatJadi_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridObatJadi.CellContentClick
        Try
            If e.ColumnIndex = 0 Then
                'MsgBox(IsDBNull(gridObatJadi.Rows(e.RowIndex).Cells("kode_Barang").Value))
                'MsgBox(String.Empty(gridObatJadi.Rows(e.RowIndex).Cells("kode_Barang").Value))
                idx_permintaan_obat = gridObatJadi.Rows(e.RowIndex).Cells("idx_permintaan_obat").Value
                cekStatusTerlayani("idx_permintaan_obat", idx_permintaan_obat)
                If statusTerlayani = 0 Then
                    If Not gridObatJadi.Rows(e.RowIndex).Cells("kode_Barang").Value = "" Or Not gridObatJadi.Rows(e.RowIndex).Cells("kode_Barang").Value.ToString = String.Empty Then
                        If cmbPkt.Text = "Paket Umum" Then
                            txtKodeObat.Text = gridObatJadi.Rows(e.RowIndex).Cells(1).Value
                            kd_barang_permintaan = gridObatJadi.Rows(e.RowIndex).Cells("kode_barang").Value
                            cekJumlah(gridObatJadi.Rows(e.RowIndex).Cells(3).Value, gridObatJadi.Rows(e.RowIndex).Cells("kode_barang").Value)
                            'txtJumlahJual.DecimalValue = gridObatJadi.Rows(e.RowIndex).Cells(3).Value
                            PanelObat.Visible = False
                            cekJangkaPemberianObatBPJS(Trim(txtKodeObat.Text))
                            If DT.Rows.Count > 0 Then
                                DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                                If DTPCekObat.Value > DTPTanggalTrans.Value Then
                                    MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                                    'Exit Sub
                                End If
                            End If
                            detailObatJadi(gridObatJadi.Rows(e.RowIndex).Cells("kode_barang").Value)
                            detailObatDilayani(gridObatJadi, e.RowIndex, 0)
                            JumlahHargaUmum()
                            jenisPelayanan = "obat-jadi"
                        ElseIf cmbPkt.Text = "Paket Khusus" Then
                            txtKodeObatKh.Text = gridObatJadi.Rows(e.RowIndex).Cells(1).Value
                            kd_barang_permintaan = gridObatJadi.Rows(e.RowIndex).Cells("kode_barang").Value
                            cekJumlah(gridObatJadi.Rows(e.RowIndex).Cells(3).Value, gridObatJadi.Rows(e.RowIndex).Cells("kode_barang").Value)
                            'txtJumlahJual.Text = gridObatJadi.Rows(e.RowIndex).Cells(3).Value
                            PanelObat.Visible = False
                            cekJangkaPemberianObatBPJS(Trim(txtKodeObatKh.Text))
                            If DT.Rows.Count > 0 Then
                                DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                                If DTPCekObat.Value > DTPTanggalTrans.Value Then
                                    MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                                    'Exit Sub
                                End If
                            End If
                            detailObatJadi(gridObatJadi.Rows(e.RowIndex).Cells("kode_Barang").Value)
                            detailObatDilayani(gridObatJadi, e.RowIndex, 0)
                            jenisPelayanan = "obat-jadi"
                        End If

                    Else
                        MsgBox("Barang tidak terdapat di database silahkan pilih obat pengganti")
                        detailObatDilayani(gridObatJadi, e.RowIndex, 0)
                        idx_permintaan_obat = gridObatJadi.Rows(e.RowIndex).Cells("idx_permintaan_obat").Value
                        cekStatusTerlayani("idx_permintaan_obat", idx_permintaan_obat)
                        'If cmbRacikNon.SelectedItem = "N" Then
                        '    jenisPelayanan = "obat-jadi"
                        'Else
                        '    jenisPelayanan = "obat-racik"
                        'End If
                        If cmbPkt.Text = "Paket Umum" Then
                            txtKodeObat.Focus()
                        Else
                            txtKodeObatKh.Focus()
                        End If
                        jenisPelayanan = "obat-jadi"
                    End If
                Else
                    MsgBox("Barang yang di pilih sudah terlayani", vbInformation, "Informasi")
                End If
            End If
            RefreshGridObatJadi()
        Catch ex As Exception
            MsgBox("Dilarang Klik pada Header Tabel terimakasih!!!")
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnExPnlObat.Click
        PanelObat.Visible = False
    End Sub

    Private Sub gridObatRacikan_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridObatRacikan.CellContentClick
        Try
            If e.ColumnIndex = 0 Then
                'MsgBox(IsDBNull(gridObatRacikan.Rows(e.RowIndex).Cells("kd_Barang").Value))
                idx_permintaan_obat = gridObatRacikan.Rows(e.RowIndex).Cells("idx_no_racikan").Value
                cekStatusTerlayani("idx_no_racikan", idx_permintaan_obat)
                If statusTerlayani = 0 Then
                    If Not gridObatRacikan.Rows(e.RowIndex).Cells("kode_Barang").Value = "" Then
                        If cmbPkt.Text = "Paket Umum" Then
                            cmbRacikNon.SelectedItem = "R"
                            txtKodeObat.Text = gridObatRacikan.Rows(e.RowIndex).Cells("kode_barang").Value
                            txtDosis.Text = Num_En_US(gridObatRacikan.Rows(e.RowIndex).Cells("kekuatan").Value)
                            txtDosisResep.Text = Num_En_US(gridObatRacikan.Rows(e.RowIndex).Cells("dosis").Value)
                            txtJmlBungkus.Text = Num_En_US(gridObatRacikan.Rows(e.RowIndex).Cells("jumlah_bungkus").Value)
                            kd_barang_permintaan = gridObatRacikan.Rows(e.RowIndex).Cells("kode_barang").Value
                            cekJumlah(gridObatRacikan.Rows(e.RowIndex).Cells("jumlah_permintaan").Value, Trim(gridObatRacikan.Rows(e.RowIndex).Cells("kode_barang").Value))
                            'txtJumlahJual.DecimalValue = gridObatJadi.Rows(e.RowIndex).Cells(3).Value
                            PanelObat.Visible = False
                            cekJangkaPemberianObatBPJS(Trim(txtKodeObat.Text))
                            If DT.Rows.Count > 0 Then
                                DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                                If DTPCekObat.Value > DTPTanggalTrans.Value Then
                                    MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                                    'Exit Sub
                                End If
                            End If
                            detailObatJadi(Trim(txtKodeObat.Text))
                            detailObatDilayani(gridObatRacikan, e.RowIndex, 1)
                            JumlahHargaUmum()
                            jenisPelayanan = "obat-racik"
                        ElseIf cmbPkt.Text = "Paket Khusus" Then
                            cmbRacikNonKh.SelectedItem = "R"
                            kd_barang_permintaan = gridObatRacikan.Rows(e.RowIndex).Cells("kode_barang").Value
                            txtKodeObatKh.Text = gridObatRacikan.Rows(e.RowIndex).Cells("kode_barang").Value
                            txtDosisKh.Text = Num_En_US(gridObatRacikan.Rows(e.RowIndex).Cells("kekuatan").Value)
                            txtDosisResepKh.Text = Num_En_US(gridObatRacikan.Rows(e.RowIndex).Cells("dosis").Value)
                            txtJmlCapBPJSKh.Text = gridObatRacikan.Rows(e.RowIndex).Cells("jumlah_bungkus").Value
                            cekJumlah(gridObatRacikan.Rows(e.RowIndex).Cells(4).Value, Trim(gridObatRacikan.Rows(e.RowIndex).Cells("kode_barang").Value))
                            'txtJumlahJual.Text = gridObatRacikan.Rows(e.RowIndex).Cells(4).Value
                            PanelObat.Visible = False
                            cekJangkaPemberianObatBPJS(Trim(txtKodeObatKh.Text))
                            If DT.Rows.Count > 0 Then
                                DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                                If DTPCekObat.Value > DTPTanggalTrans.Value Then
                                    MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                                    'Exit Sub
                                End If
                            End If
                            detailObatJadi(Trim(txtKodeObatKh.Text))
                            detailObatDilayani(gridObatRacikan, e.RowIndex, 1)
                            jenisPelayanan = "obat-racik"
                        End If
                    Else
                        cmbRacikNonKh.SelectedItem = "R"
                        MsgBox("Barang tidak terdapat di database silahkan pilih obat pengganti")
                        detailObatDilayani(gridObatRacikan, e.RowIndex, 1)
                        idx_permintaan_obat = gridObatRacikan.Rows(e.RowIndex).Cells("idx_no_racikan").Value
                        txtDosisKh.Text = Num_En_US(gridObatRacikan.Rows(e.RowIndex).Cells("kekuatan").Value)
                        txtDosisResepKh.Text = Num_En_US(gridObatRacikan.Rows(e.RowIndex).Cells("dosis").Value)
                        txtJmlCapBPJSKh.Text = gridObatRacikan.Rows(e.RowIndex).Cells("jumlah_bungkus").Value
                        cekStatusTerlayani("idx_permintaan_obat", idx_permintaan_obat)
                        txtKodeObat.Focus()
                        If cmbPkt.Text = "Paket Umum" Then
                            txtKodeObat.Focus()
                        Else
                            txtKodeObatKh.Focus()
                        End If
                        jenisPelayanan = "obat-racik"
                    End If
                Else
                    MsgBox("Barang yang di pilih sudah terlayani", vbInformation, "Informasi")
                End If
            End If
            RefreshGridObatRacikan()
        Catch ex As Exception
            MsgBox("Dilarang Klik pada Header Tabel terimakasih!!!")
        End Try
    End Sub

    Private Sub btnCetakNota_Click(sender As Object, e As EventArgs) Handles btnCetakNota.Click
        FormPemanggil = "FormEditPenjualanResepEMR_Nota"
        bilang = Terbilang(txtGrandTotalBulat.DecimalValue)
        cetakNota()
        'btnCetakNota.Enabled = False
        btnCetakEtiket.Focus()
    End Sub

    Sub deleteStatusObatJadiTerlayani(ByVal kd_barang As String)
        If BDPermintaanObatDetail.Count > 0 Then
            BDPermintaanObatDetail.Filter = "kd_barang_terlayani = '" & kd_barang & "'"
            If BDPermintaanObatDetail.Count > 0 Then
                BDPermintaanObatDetail.MoveFirst()
                DRWPermintaanObatDetail = BDPermintaanObatDetail.Current

                DRWPermintaanObatDetail("status_terlayani") = 0
                DRWPermintaanObatDetail("jumlah_terlayani") = 0
                DRWPermintaanObatDetail("kd_barang_terlayani") = ""
                DRWPermintaanObatDetail("barang_terlayani") = ""
                DRWPermintaanObatDetail.EndEdit()
            ElseIf BDPermintaanObatRacikDetail.Count > 0 Then
                BDPermintaanObatRacikDetail.Filter = "kd_barang_terlayani = '" & kd_barang & "'"
                If BDPermintaanObatRacikDetail.Count > 0 Then
                    BDPermintaanObatRacikDetail.MoveFirst()
                    DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current

                    DRWPermintaanObatRacikDetail("status_terlayani") = 0
                    DRWPermintaanObatRacikDetail("jumlah_terlayani") = 0
                    DRWPermintaanObatRacikDetail("kd_barang_terlayani") = ""
                    DRWPermintaanObatRacikDetail("barang_terlayani") = ""
                    DRWPermintaanObatRacikDetail.EndEdit()
                End If
            End If
        ElseIf BDPermintaanObatRacikDetail.Count > 0 Then
            BDPermintaanObatRacikDetail.Filter = "kd_barang_terlayani = '" & kd_barang & "'"
            If BDPermintaanObatRacikDetail.Count > 0 Then
                BDPermintaanObatRacikDetail.MoveFirst()
                DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current

                DRWPermintaanObatRacikDetail("status_terlayani") = 0
                DRWPermintaanObatRacikDetail("jumlah_terlayani") = 0
                DRWPermintaanObatRacikDetail("kd_barang_terlayani") = ""
                DRWPermintaanObatRacikDetail("barang_terlayani") = ""
                DRWPermintaanObatRacikDetail.EndEdit()
            End If
        End If
        BDPermintaanObatDetail.RemoveFilter()
        BDPermintaanObatRacikDetail.RemoveFilter()
        RefreshGridObatJadi()
        RefreshGridObatRacikan()
    End Sub

    Private Sub btnHapusBarisKh_Click(sender As Object, e As EventArgs) Handles btnHapusBarisKh.Click
        If MessageBox.Show("Yakin Akan Dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If gridDetailObatKh.CurrentRow.Index <> gridDetailObatKh.NewRowIndex Then
                    Dim kode_barang As String
                    kode_barang = gridDetailObatKh.Rows(gridDetailObatKh.CurrentRow.Index).Cells("kd_barang").Value
                    deleteStatusObatJadiTerlayani(kode_barang)
                    gridDetailObatKh.Rows.RemoveAt(gridDetailObatKh.CurrentRow.Index)
                End If
                txtQtyKh.DecimalValue = gridDetailObatKh.Rows.Count() - 1
                TotalPaket()
                TotalNonPaket()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnHapusBaris_Click(sender As Object, e As EventArgs) Handles btnHapusBaris.Click
        If MessageBox.Show("Yakin Akan Dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If gridDetailObat.CurrentRow.Index <> gridDetailObat.NewRowIndex Then
                    Dim kode_barang As String
                    kode_barang = gridDetailObat.Rows(gridDetailObat.CurrentRow.Index).Cells("kd_barang").Value
                    deleteStatusObatJadiTerlayani(kode_barang)
                    gridDetailObat.Rows.RemoveAt(gridDetailObat.CurrentRow.Index)
                End If
                txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
                TotalHarga()
                TotalDijamin()
                TotalIurBayar()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnChangeBack_Click(sender As Object, e As EventArgs) Handles btnChangeBack.Click
        GBObatJadi.Visible = True
        GBObatRacikan.Visible = True
        GBObatJadi.Dock = DockStyle.Top
        GBObatRacikan.Dock = DockStyle.Fill
    End Sub

    Private Sub btnChangeObatRacik_Click(sender As Object, e As EventArgs) Handles btnChangeObatRacik.Click
        GBObatJadi.Visible = False
        GBObatRacikan.Visible = True
        GBObatRacikan.Dock = DockStyle.Fill
    End Sub

    Private Sub btnChangeObatJadi_Click(sender As Object, e As EventArgs) Handles btnChangeObatJadi.Click
        GBObatRacikan.Visible = False
        GBObatJadi.Visible = True
        GBObatJadi.Dock = DockStyle.Fill
    End Sub

    Sub cariDokter()
        Dim cari As String = InStr(cmbDokter.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbDokter.Text, "|", -1, CompareMethod.Binary)
            NamaDokter = (ary(0))
            kdDokter = (ary(1))
        End If
    End Sub

    Sub cariSubUnitAsal()
        Dim cari As String = InStr(cmbUnitAsal.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbUnitAsal.Text, "|", -1, CompareMethod.Binary)
            nmSubUnit = (ary(0))
            kdSubUnit = (ary(1))
        End If
    End Sub

    Private Sub cmbDijamin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDijamin.SelectedIndexChanged
        If cmbDijamin.Text = "Y" Then
            txtDijamin.Enabled = False
        Else
            txtDijamin.Enabled = True
        End If
    End Sub

    Private Sub cmbDijamin_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbDijamin.KeyDown
        If e.KeyCode = Keys.Left Then
            txtKodeObat.Focus()
        End If
    End Sub

    Private Sub cmbDijamin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbDijamin.KeyPress
        If e.KeyChar = Chr(13) Then
            If e.KeyChar = Chr(13) Then
                If cmbDijamin.Text = "Y" Or cmbDijamin.Text = "y" Or cmbDijamin.Text = "N" Or cmbDijamin.Text = "n" Then
                    SendKeys.Send("{TAB}")
                Else
                    MsgBox("Pilih yang benar", vbCritical, "Kesalahan")
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub txtJumlahJual_TextChanged(sender As Object, e As EventArgs) Handles txtJumlahJual.TextChanged
        txtJumlahHarga.DecimalValue = txtHargaJual.DecimalValue * txtJumlahJual.DecimalValue
        If cmbDijamin.Text = "N" Then
            txtDijamin.DecimalValue = 0
            txtIuranSisaBayar.DecimalValue = txtJumlahHarga.DecimalValue
        ElseIf cmbDijamin.Text = "Y" Then
            txtIuranSisaBayar.DecimalValue = 0
            txtDijamin.DecimalValue = txtJumlahHarga.DecimalValue
        End If
    End Sub

    Private Sub txtJmlHari_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlHari.KeyDown
        If e.KeyCode = Keys.Up Then
            txtJumlahJual.Focus()
        End If
    End Sub

    Private Sub txtJumlahJual_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahJual.KeyPress
        If e.KeyChar = Chr(13) Then
            If cmbDijamin.Text = "Y" Then
                SendKeys.Send("{TAB}")
            Else
                txtDijamin.Focus()
            End If

        End If
    End Sub

    Private Sub txtJumlahJual_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJumlahJual.KeyDown
        If e.KeyCode = Keys.Up Then
            cmbDijamin.Focus()
        End If
    End Sub

    Private Sub txtJmlHari_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlHari.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Sub addStatusObatJadiTerlayani(ByVal idx_permintaan_obat As String, ByVal kd_permintaan_obat As String, ByVal jml_terlayani As Decimal, ByVal kode_barang As String, ByVal nama_barang As String)
        Dim status As String
        BDPermintaanObatDetail.Filter = "idx_permintaan_obat = '" & idx_permintaan_obat & "'"
        If kd_barang_permintaan = kode_barang Then
            status = "1"
        ElseIf kode_barang <> kd_barang_permintaan Then
            status = "2"
        Else
            status = "0"
        End If
        If BDPermintaanObatDetail.Count > 0 Then
            BDPermintaanObatDetail.MoveFirst()
            DRWPermintaanObatDetail = BDPermintaanObatDetail.Current
            ' Tambahan di layani
            DRWPermintaanObatDetail("jumlah_terlayani") = jml_terlayani
            DRWPermintaanObatDetail("kd_barang_terlayani") = kode_barang
            DRWPermintaanObatDetail("status_terlayani") = status
            DRWPermintaanObatDetail("barang_terlayani") = nama_barang
            DRWPermintaanObatDetail.EndEdit()
        End If
        BDPermintaanObatDetail.RemoveFilter()
        gridObatJadi.Focus()
    End Sub

    Sub addStatusObatRacikTerlayani(ByVal idx_permintaan_obat As String, ByVal kd_permintaan_obat As String, ByVal jml_terlayani As Decimal, ByVal kode_barang As String, ByVal nama_barang As String)
        Dim status As String
        BDPermintaanObatRacikDetail.Filter = "idx_no_racikan = '" & idx_permintaan_obat & "'"
        If kd_barang_permintaan = kode_barang Then
            status = "1"
        ElseIf kode_barang <> kd_barang_permintaan Then
            status = "2"
        Else
            status = "0"
        End If
        If BDPermintaanObatRacikDetail.Count > 0 Then
            BDPermintaanObatRacikDetail.MoveFirst()
            DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current
            ' Tambahan di layani
            DRWPermintaanObatRacikDetail("jumlah_terlayani") = jml_terlayani
            DRWPermintaanObatRacikDetail("kd_barang_terlayani") = kode_barang
            DRWPermintaanObatRacikDetail("status_terlayani") = status
            DRWPermintaanObatRacikDetail("barang_terlayani") = nama_barang
            DRWPermintaanObatRacikDetail.EndEdit()
        End If
        BDPermintaanObatRacikDetail.RemoveFilter()
        gridObatRacikan.Focus()
    End Sub

    Sub carikdEtiketTakaran()
        Dim cari As String = InStr(cmbTakaran.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbTakaran.Text, "|", -1, CompareMethod.Binary)
            kdTakaran = (ary(1))
            nmTakaran = (ary(0))
        End If
    End Sub

    Sub carikdEtiketWaktu()
        Dim cari As String = InStr(cmbWaktu.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbWaktu.Text, "|", -1, CompareMethod.Binary)
            kdWaktu = (ary(1))
            nmWaktu = (ary(0))
        End If
    End Sub

    Sub carikdEtiketKeterangan()
        Dim cari As String = InStr(cmbKeterangan.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbKeterangan.Text, "|", -1, CompareMethod.Binary)
            kdKeterangan = (ary(1))
            nmKeterangan = (ary(0))
        End If
    End Sub

    Sub carikdEtiketKeteranganModel3()
        Dim cari As String = InStr(cmbKeteranganModel3.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbKeteranganModel3.Text, "|", -1, CompareMethod.Binary)
            kdKeteranganModel3 = (ary(1))
            nmKeteranganModel3 = (ary(0))
        End If
    End Sub

    Sub addBarang()
        'cekBarang()
        cariNamaPenjamin()
        cariDokter()
        carikdEtiketTakaran()
        carikdEtiketWaktu()
        carikdEtiketKeterangan()
        carikdEtiketKeteranganModel3()

        BDPenjualanResep.DataSource = DSPenjualanResep
        BDPenjualanResep.DataMember = "PenjualanResep"

        BDPenjualanResep.AddNew()
        DRWPenjualanResep = BDPenjualanResep.Current
        DRWPenjualanResep("stsrawat") = StatusRawat
        DRWPenjualanResep("kdkasir") = Trim(FormLogin.LabelKode.Text)
        DRWPenjualanResep("nmkasir") = Trim(FormLogin.LabelNama.Text)
        DRWPenjualanResep("tanggal") = DTPTanggalTrans.Value
        DRWPenjualanResep("notaresep") = Trim(txtNoResep.Text)
        DRWPenjualanResep("no_reg") = Trim(txtNoReg.Text)
        DRWPenjualanResep("no_rm") = Trim(txtRM.Text)
        DRWPenjualanResep("nmpasien") = Trim(txtNamaPasien.Text)
        DRWPenjualanResep("umurthn") = txtUmurThn.Text
        DRWPenjualanResep("umurbln") = txtUmurBln.Text
        DRWPenjualanResep("kd_penjamin") = KdPenjamin
        DRWPenjualanResep("nm_penjamin") = NamaPenjamin
        DRWPenjualanResep("kddokter") = kdDokter
        DRWPenjualanResep("nmdokter") = NamaDokter
        DRWPenjualanResep("nonota") = Trim(txtNota.Text)
        DRWPenjualanResep("urut") = txtNoUrut.Text
        DRWPenjualanResep("kd_barang") = Trim(txtKodeObat.Text)
        DRWPenjualanResep("idx_barang") = Trim(txtIdObat.Text)
        DRWPenjualanResep("nama_barang") = Trim(lblNamaObat.Text)
        DRWPenjualanResep("kd_jns_obat") = KdJenisObat
        DRWPenjualanResep("kd_gol_obat") = kdGolonganObat
        DRWPenjualanResep("kd_kel_obat") = kdKelompokObat
        DRWPenjualanResep("kdpabrik") = kdPabrik
        DRWPenjualanResep("generik") = Generik
        DRWPenjualanResep("formularium") = "FORMULARIUM"
        DRWPenjualanResep("racik") = Trim(cmbRacikNon.Text)
        DRWPenjualanResep("harga") = txtHargaJual.DecimalValue
        DRWPenjualanResep("jmlp") = txtJumlahJual.DecimalValue
        DRWPenjualanResep("totalp") = txtJumlahHarga.DecimalValue
        DRWPenjualanResep("jmln") = 0
        DRWPenjualanResep("totaln") = 0
        DRWPenjualanResep("jml") = txtJumlahJual.DecimalValue
        DRWPenjualanResep("nmsatuan") = Trim(txtKdSatuan.Text)
        DRWPenjualanResep("totalharga") = txtJumlahHarga.DecimalValue
        DRWPenjualanResep("senpot") = 0
        DRWPenjualanResep("potongan") = 0
        DRWPenjualanResep("jmlnet") = txtJumlahHarga.DecimalValue
        DRWPenjualanResep("dijamin") = txtDijamin.DecimalValue
        DRWPenjualanResep("sisabayar") = txtIuranSisaBayar.DecimalValue
        DRWPenjualanResep("hrgbeli") = HargaBeli
        DRWPenjualanResep("jamawal") = Format(DTPJamAwal.Value, "HH:mm:ss").ToString
        DRWPenjualanResep("kdbagian") = pkdapo
        DRWPenjualanResep("stsresep") = "PKTUMUM"
        DRWPenjualanResep("rek_p") = kDRekening
        DRWPenjualanResep("stsetiket") = cmbEtiket.Text
        DRWPenjualanResep("qty1") = txtSigna1.Text
        DRWPenjualanResep("qty2") = txtSigna2.Text
        DRWPenjualanResep("qty3") = txtQty3.DecimalValue
        DRWPenjualanResep("jmlhari") = 0
        DRWPenjualanResep("takaran") = kdTakaran
        DRWPenjualanResep("waktu") = kdWaktu
        DRWPenjualanResep("takaran_s") = nmTakaran
        DRWPenjualanResep("waktu_s") = nmWaktu
        DRWPenjualanResep("ketminum_s") = nmKeterangan
        If modelEtiket = "1" Then
            DRWPenjualanResep("ketminum") = kdKeterangan
            DRWPenjualanResep("nmobat_etiket") = txtNamaObatEtiket.Text
            DRWPenjualanResep("jmlobat_etiket") = txtJumlahObatEtiket.DecimalValue
        ElseIf modelEtiket = "3" Then
            DRWPenjualanResep("ketminum") = kdKeteranganModel3
            DRWPenjualanResep("nmobat_etiket") = txtNamaObatEtiketModel3.Text
            DRWPenjualanResep("jmlobat_etiket") = txtJumlahObatEtiketModel3.DecimalValue
            DRWPenjualanResep("ketminum_s") = nmKeteranganModel3
        ElseIf modelEtiket = "4" Then
            DRWPenjualanResep("nmobat_etiket") = txtNamaObatEtiketModel4.Text
        End If
        DRWPenjualanResep("posting") = "1"
        DRWPenjualanResep("diserahkan") = "B"
        DRWPenjualanResep("jns_obat") = JenisObat
        DRWPenjualanResep("jmljatah") = txtJmlHari.IntegerValue
        DRWPenjualanResep("tglakhir") = DTPTglAkhir.Value
        DRWPenjualanResep("jml_awal") = 0
        DRWPenjualanResep("tgl_exp") = DTPTanggalExp.Value
        DRWPenjualanResep("model_etiket") = modelEtiket
        DRWPenjualanResep("nmobat_etiket_infus") = txtNamaObatEtiketInfus.Text
        DRWPenjualanResep("jmlobat_etiket_infus") = txtJumlahObatEtiketInfus.DecimalValue
        DRWPenjualanResep("obat_infus") = txtObatInfus.Text
        DRWPenjualanResep("tetes_infus") = txtTetesInfus.Text

        If cbPagi.Checked = True Then
            DRWPenjualanResep("ket_waktu_pagi_model4") = "2"
        Else
            DRWPenjualanResep("ket_waktu_pagi_model4") = "1"
        End If
        If cbSiang.Checked = True Then
            DRWPenjualanResep("ket_waktu_siang_model4") = "2"
        Else
            DRWPenjualanResep("ket_waktu_siang_model4") = "1"
        End If
        If cbMalam.Checked = True Then
            DRWPenjualanResep("ket_waktu_malam_model4") = "2"
        Else
            DRWPenjualanResep("ket_waktu_malam_model4") = "1"
        End If
        If cbSore.Checked = True Then
            DRWPenjualanResep("ket_waktu_sore_model4") = "2"
        Else
            DRWPenjualanResep("ket_waktu_sore_model4") = "1"
        End If
        If rSebelum.Checked = True Then
            DRWPenjualanResep("ket_minum_model4") = "1"
        ElseIf rBersama.Checked = True Then
            DRWPenjualanResep("ket_minum_model4") = "2"
        ElseIf rSesudah.Checked = True Then
            DRWPenjualanResep("ket_minum_model4") = "3"
        ElseIf rInjeksi.Checked = True Then
            DRWPenjualanResep("ket_minum_model4") = "4"
        End If


        BDPenjualanResep.EndEdit()

        gridDetailObat.DataSource = Nothing
        gridDetailObat.DataSource = BDPenjualanResep

        TotalHarga()
        TotalDijamin()
        TotalIurBayar()
    End Sub

    Sub cekStatusProses(ByVal no_permintaan_obat As String)
        BDPermintaanObat.Filter = "status = 1 and no_permintaan_obat ='" & no_permintaan_obat & "'"
        If BDPermintaanObat.Count > 0 Then
            statusProses = 1
        Else
            BDPermintaanObat.RemoveFilter()
            statusProses = 0
        End If
    End Sub

    Sub TampilResepObatJadi(ByVal noPermintaan As String)
        DA = New OleDb.OleDbDataAdapter("SELECT 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_Barang, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Nama_Obat, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Obat, 
            Pegawai.nama_pegawai, 
            Sub_Unit.nama_sub_unit, 
            ap_seting_apotek.nmapo, 
            (DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Signa1 + ' x ' + DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Signa2) AS signa, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_takaran,
            DBSIMRM.dbo.etiket_takaran.Nama_takaran,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_waktu,
            DBSIMRM.dbo.etiket_waktu.nama_waktu,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_ketminum,
            DBSIMRM.dbo.etiket_ketminum.nama_ketminum,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Keterangan, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Status_Obat,
            DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_obat,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Status_Terlayani,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Terlayani,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_barang_terlayani,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Idx_Permintaan_Obat
            FROM DBSIMRM.dbo.RJ_Permintaan_Obat 
            INNER JOIN DBSIMRM.dbo.RJ_Permintaan_Obat_Detail ON DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat = DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.No_Permintaan_Obat 
            INNER JOIN DBSIMRS.dbo.Sub_Unit ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Sub_Unit = Sub_Unit.kd_sub_unit 
            INNER JOIN DBSIMRS.dbo.Pegawai ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Dokter = Pegawai.kd_pegawai 
            INNER JOIN DBSIMRS.dbo.ap_seting_apotek ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi = ap_seting_apotek.kdapo 
            INNER JOIN DBSIMRM.dbo.etiket_takaran ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_takaran = DBSIMRM.dbo.etiket_takaran.kd_takaran 
            INNER JOIN DBSIMRM.dbo.etiket_waktu ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_waktu = DBSIMRM.dbo.etiket_waktu.kd_waktu 
            INNER JOIN DBSIMRM.dbo.etiket_ketminum ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_ketminum = DBSIMRM.dbo.etiket_ketminum.kd_ketminum 
            WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & noPermintaan & "'", CONN)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then

            BDPermintaanObatDetail.DataSource = DSPermintaanObatDetail
            BDPermintaanObatDetail.DataMember = "PermintaanObatDetail"
            For i = 0 To DT.Rows.Count - 1
                '''''''''''''''''''''''
                BDPermintaanObatDetail.AddNew()
                DRWPermintaanObatDetail = BDPermintaanObatDetail.Current
                ' Tambahan di Temporari Permintaan
                DRWPermintaanObatDetail("kode_barang") = Trim(DT.Rows(i).Item("kd_barang"))
                DRWPermintaanObatDetail("nama_barang") = Trim(DT.Rows(i).Item("nama_obat"))
                DRWPermintaanObatDetail("jumlah_permintaan") = DT.Rows(i).Item("jumlah_obat")
                DRWPermintaanObatDetail("signa") = Trim(DT.Rows(i).Item("signa"))
                DRWPermintaanObatDetail("takaran") = DT.Rows(i).Item("nama_takaran")
                DRWPermintaanObatDetail("waktu") = DT.Rows(i).Item("nama_waktu")
                DRWPermintaanObatDetail("ket_minum") = Trim(DT.Rows(i).Item("nama_ketminum"))
                DRWPermintaanObatDetail("keterangan") = Trim(DT.Rows(i).Item("keterangan"))
                DRWPermintaanObatDetail("status_terlayani") = Trim(DT.Rows(i).Item("status_terlayani"))
                DRWPermintaanObatDetail("jumlah_terlayani") = DT.Rows(i).Item("jumlah_terlayani")
                DRWPermintaanObatDetail("kd_barang_terlayani") = Trim(DT.Rows(i).Item("kd_barang_terlayani"))
                DRWPermintaanObatDetail("no_permintaan_obat") = Trim(DT.Rows(i).Item("no_permintaan_obat"))
                DRWPermintaanObatDetail("idx_permintaan_obat") = Trim(DT.Rows(i).Item("idx_permintaan_obat"))
                BDPermintaanObatDetail.EndEdit()
            Next

            gridObatJadi.DataSource = Nothing
            With gridObatJadi
                .DataSource = BDPermintaanObatDetail
                .Columns(0).Width = 30
                .Columns(1).HeaderText = "Kode Obat"
                .Columns(1).Width = 80
                .Columns(2).HeaderText = "Nama Obat"
                .Columns(2).Width = 200
                .Columns(3).HeaderText = "Jumlah Obat"
                .Columns(3).Width = 50
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(3).DefaultCellStyle.Format = "N2"
                .Columns(4).HeaderText = "Signa"
                .Columns(4).Width = 40
                .Columns(5).HeaderText = "Takaran"
                .Columns(5).Width = 50
                .Columns(6).HeaderText = "Waktu"
                .Columns(6).Width = 120
                .Columns(7).HeaderText = "Keterangan Minum"
                .Columns(7).Width = 100
                .Columns(8).HeaderText = "Keterangan"
                .Columns(8).Width = 150
                .Columns(9).HeaderText = "Status Terlayanin"
                .Columns(9).Width = 50
                .Columns(10).HeaderText = "Jumlah Terlayani"
                .Columns(10).Width = 70
                .Columns(11).HeaderText = "KD Obat Terlayani"
                .Columns(11).Width = 90
                .Columns(12).Visible = False
                .Columns(13).Visible = False
                .ReadOnly = True
                For i As Integer = 0 To .RowCount - 1
                    If .Rows(i).Cells("status_terlayani").Value = 1 Or .Rows(i).Cells("status_terlayani").Value = 2 Then
                        .AlternatingRowsDefaultCellStyle.BackColor = Color.Green
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                        .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                    End If
                Next
            End With
        End If
    End Sub

    Sub TampilResepObatRacikan(ByVal noPermintaan As String)
        DA = New OleDb.OleDbDataAdapter("Select 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Nama_Racikan, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_Barang, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Nama_Obat, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Obat, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Bungkus, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Kekuatan_Obat, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Dosis_Obat, 

            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_waktu, 
            DBSIMRM.dbo.etiket_waktu.nama_waktu, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_takaran, 
            DBSIMRM.dbo.Jenis_Racikan_Obat.Nama_Jenis_Racikan, 
            (DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Signa1 + ' x ' + DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Signa2) AS signa, 
            DBSIMRM.dbo.etiket_ketminum.nama_ketminum, 

            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Keterangan, 
            DBSIMRM.dbo.etiket_takaran.Nama_takaran, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_ketminum, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Urut_Racikan, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Permintaan_Obat,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.status_terlayani, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.jumlah_terlayani, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_barang_terlayani,

            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.idx_no_racikan
            From DBSIMRM.dbo.RJ_Permintaan_Obat 
            INNER Join Sub_Unit ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Sub_Unit = Sub_Unit.kd_sub_unit 
            INNER Join Pegawai ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Dokter = Pegawai.kd_pegawai 
            INNER Join ap_seting_apotek ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi = ap_seting_apotek.kdapo 
            INNER Join DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan On DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat = DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Permintaan_Obat INNER Join DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Racikan = DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.No_Racikan INNER Join DBSIMRM.dbo.Jenis_Racikan_Obat On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Kd_Jenis_Racikan = DBSIMRM.dbo.Jenis_Racikan_Obat.Kd_Jenis_Racikan INNER Join DBSIMRM.dbo.etiket_takaran On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_takaran = DBSIMRM.dbo.etiket_takaran.kd_takaran INNER Join DBSIMRM.dbo.etiket_waktu On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_waktu = DBSIMRM.dbo.etiket_waktu.kd_waktu INNER Join DBSIMRM.dbo.etiket_ketminum On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_ketminum = DBSIMRM.dbo.etiket_ketminum.kd_ketminum WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & noPermintaan & "' ORDER BY DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Nama_Racikan", CONN)
        DT = New DataTable
        DA.Fill(DT)

        If DT.Rows.Count > 0 Then
            'DSPermintaanObatRacikDetail = Table.BuatTabelPermintaanObatRacik("PermintaanObatRacik")
            BDPermintaanObatRacikDetail.DataSource = DSPermintaanObatRacikDetail
            BDPermintaanObatRacikDetail.DataMember = "PermintaanObatRacikDetail"
            For i = 0 To DT.Rows.Count - 1
                '''''''''''''''''''''''
                BDPermintaanObatRacikDetail.AddNew()
                DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current
                ' Tambahan di Temporari Permintaan Obat Racikan
                DRWPermintaanObatRacikDetail("nama_racikan") = Trim(DT.Rows(i).Item("nama_racikan"))
                DRWPermintaanObatRacikDetail("kode_barang") = Trim(DT.Rows(i).Item("kd_barang"))
                DRWPermintaanObatRacikDetail("nama_barang") = Trim(DT.Rows(i).Item("nama_obat"))
                DRWPermintaanObatRacikDetail("jumlah_permintaan") = DT.Rows(i).Item("jumlah_obat")
                DRWPermintaanObatRacikDetail("jumlah_bungkus") = DT.Rows(i).Item("jumlah_bungkus")
                DRWPermintaanObatRacikDetail("kekuatan") = DT.Rows(i).Item("kekuatan_obat")
                DRWPermintaanObatRacikDetail("dosis") = DT.Rows(i).Item("dosis_obat")
                DRWPermintaanObatRacikDetail("waktu") = Trim(DT.Rows(i).Item("nama_waktu"))
                DRWPermintaanObatRacikDetail("jenis_racikan") = Trim(DT.Rows(i).Item("nama_jenis_racikan"))
                DRWPermintaanObatRacikDetail("signa") = Trim(DT.Rows(i).Item("signa"))
                DRWPermintaanObatRacikDetail("ket_minum") = DT.Rows(i).Item("nama_ketminum")
                DRWPermintaanObatRacikDetail("keterangan") = Trim(DT.Rows(i).Item("keterangan"))
                DRWPermintaanObatRacikDetail("status_terlayani") = DT.Rows(i).Item("status_terlayani")
                DRWPermintaanObatRacikDetail("jumlah_terlayani") = DT.Rows(i).Item("jumlah_terlayani")
                DRWPermintaanObatRacikDetail("kd_barang_Terlayani") = Trim(DT.Rows(i).Item("kd_barang_terlayani"))
                DRWPermintaanObatRacikDetail("no_permintaan_obat") = Trim(DT.Rows(i).Item("no_permintaan_obat"))
                DRWPermintaanObatRacikDetail("idx_no_racikan") = Trim(DT.Rows(i).Item("idx_no_racikan"))
                DRWPermintaanObatRacikDetail("no_urut_racikan") = DT.Rows(i).Item("no_urut_racikan")
                BDPermintaanObatRacikDetail.EndEdit()
            Next

            gridObatRacikan.DataSource = Nothing
            With gridObatRacikan
                .DataSource = BDPermintaanObatRacikDetail
                .Columns(0).Width = 30
                .Columns(1).HeaderText = "Nama Racikan"
                .Columns(1).Width = 80
                .Columns(2).HeaderText = "Kode Obat"
                .Columns(2).Width = 80
                .Columns(3).HeaderText = "Nama Obat"
                .Columns(3).Width = 200

                .Columns(4).HeaderText = "Jumlah Obat"
                .Columns(4).Width = 40
                .Columns(4).DefaultCellStyle.Format = "N2"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).HeaderText = "Jumlah Bungkus"
                .Columns(5).Width = 40
                .Columns(5).DefaultCellStyle.Format = "N2"
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(6).HeaderText = "Kekuatan"
                .Columns(6).Width = 40
                .Columns(6).DefaultCellStyle.Format = "N2"
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).HeaderText = "Dosis"
                .Columns(7).Width = 40
                .Columns(7).DefaultCellStyle.Format = "N2"
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).HeaderText = "Waktu"
                .Columns(8).Width = 100
                .Columns(9).HeaderText = "Jenis Racikan"
                .Columns(9).Width = 60
                .Columns(10).HeaderText = "Signa"
                .Columns(10).Width = 40
                .Columns(11).HeaderText = "Keterangan Minum"
                .Columns(11).Width = 140
                .Columns(12).HeaderText = "Keterangan"
                .Columns(12).Width = 140
                .Columns(13).HeaderText = "Status Terlayanin"
                .Columns(13).Width = 50
                .Columns(14).HeaderText = "Jumlah Terlayani"
                .Columns(14).Width = 70
                .Columns(15).HeaderText = "KD Obat Terlayani"
                .Columns(15).Width = 90
                .Columns(16).Visible = False
                .Columns(17).Visible = False
                .Columns(18).Visible = False
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .ReadOnly = True
                For i As Integer = 0 To .RowCount - 1
                    If .Rows(i).Cells("status_terlayani").Value = 1 Or .Rows(i).Cells("status_terlayani").Value = 2 Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    End If
                Next
            End With
        End If
    End Sub

    Sub addStatusPermintaan(ByVal no_permintaan_obat As String)
        BDPermintaanObat.Filter = "no_permintaan_obat = '" & no_permintaan_obat & "'"
        If BDPermintaanObat.Count > 0 Then
            BDPermintaanObat.MoveFirst()
            DRWPermintaanObat = BDPermintaanObat.Current
            'add status proses pelayanan
            DRWPermintaanObat("status") = 1
            DRWPermintaanObat.EndEdit()
        End If
    End Sub


    Sub addPelayananObat()

        BDPelayananResep.DataSource = DSPelayananResep
        BDPelayananResep.DataMember = "PelayananResep"

        BDPelayananResep.AddNew()
        DRWPelayananResep = BDPelayananResep.Current
        ' Tambahan di layani
        DRWPelayananResep("no_permintaan_obat") = Trim(noPermintaanObat)
        DRWPelayananResep("nama_obat_permintaan") = nmObatPermintaan
        DRWPelayananResep("jml_obat_permintaan") = jmlObatPermintaan
        DRWPelayananResep("status_obat") = statusObat
        BDPelayananResep.EndEdit()

        gridPelayananObat.DataSource = Nothing
        gridPelayananObat.DataSource = BDPelayananResep
    End Sub

    Sub detailObat(ByVal KodeObat As String)
        CMD = New OleDb.OleDbCommand("SELECT * FROM Barang_Farmasi WHERE kd_barang='" & KodeObat & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            If cmbPkt.Text = "Paket Umum" Then
                txtIdObat.Text = Trim(DT.Rows(0).Item("idx_barang"))
                lblNamaObat.Text = Trim(DT.Rows(0).Item("nama_barang"))
                nama_barang = lblNamaObat.Text

                If DT.Rows(0).Item("kd_jns_obat") = 17 Then
                    DiskonDinkes = 0
                Else
                    DiskonDinkes = DT.Rows(0).Item("harga_jual")
                End If
                HargaBeli = DiskonDinkes
                txtHargaJual.DecimalValue = DiskonDinkes

                txtKdSatuan.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
                txtDosis.DecimalValue = DT.Rows(0).Item("dosis")
                txtSatDosis.Text = Trim(DT.Rows(0).Item("satdosis"))
                HargaJual()
                If cmbPenjamin.Text = "-|UMUM" Then
                    cmbDijamin.Text = "N"
                Else
                    cmbDijamin.Text = "Y"
                End If
                If cmbRacikNon.Text = "R" Then
                    txtDosisResep.Focus()
                Else
                    cmbDijamin.Focus()
                End If
            ElseIf cmbPkt.Text = "Paket Khusus" Then
                txtIdObatKh.Text = Trim(DT.Rows(0).Item("idx_barang"))
                lblNamaObatKh.Text = Trim(DT.Rows(0).Item("nama_barang"))
                nama_barang = lblNamaObatKh.Text
                If DT.Rows(0).Item("kd_jns_obat") = 17 Then
                    DiskonDinkes = 0
                Else
                    DiskonDinkes = DT.Rows(0).Item("harga_jual")
                End If
                HargaBeli = DiskonDinkes
                txtHargaJualKh.DecimalValue = DiskonDinkes

                txtSatPaketBPJSKh.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
                txtSatPaketLainKh.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
                txtDosisKh.DecimalValue = DT.Rows(0).Item("dosis")
                txtSatDosisKh.Text = Trim(DT.Rows(0).Item("satdosis"))
                HargaJualKh()
                If cmbRacikNonKh.Text = "N" Then
                    txtPaketBPJSKh.Focus()
                Else
                    txtDosisResepKh.Focus()
                End If
            End If

            Generik = Trim(DT.Rows(0).Item("generik"))
            KdJenisObat = Trim(DT.Rows(0).Item("kd_jns_obat"))
            kdPabrik = Trim(DT.Rows(0).Item("kdpabrik"))
            kdKelompokObat = Trim(DT.Rows(0).Item("kd_kel_obat"))
            kdGolonganObat = Trim(DT.Rows(0).Item("kd_gol_obat"))
            txtSenPotBeli.DecimalValue = DT.Rows(0).Item("senpotbeli")
        End If

        CMD = New OleDb.OleDbCommand("SELECT * FROM jenis_obat WHERE kd_jns_obat='" & Trim(KdJenisObat) & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            JenisObat = Trim(DT.Rows(0).Item("jns_obat"))
            kDRekening = Trim(DT.Rows(0).Item("rek_p"))
        End If
    End Sub

    Sub cariNamaPenjamin()
        Dim cari As String = InStr(cmbPenjamin.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbPenjamin.Text, "|", -1, CompareMethod.Binary)
            NamaPenjamin = (ary(0))
            KdPenjamin = (ary(1))
        End If
    End Sub

    Private Sub txtCariObat_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariObat.KeyDown
        If e.KeyCode = Keys.Down Then
            gridBarang.Focus()
        End If
    End Sub

    Private Sub txtCariObat_TextChanged(sender As Object, e As EventArgs) Handles txtCariObat.TextChanged
        BDDataBarang.Filter = "nama_barang like '%" & txtCariObat.Text & "%'"
    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                If cmbPkt.Text = "Paket Umum" Then
                    txtKodeObat.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                    PanelObat.Visible = False
                    cekJangkaPemberianObatBPJS(Trim(txtKodeObat.Text))
                    If DT.Rows.Count > 0 Then
                        DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                        If DTPCekObat.Value > DTPTanggalTrans.Value Then
                            MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                            'Exit Sub
                        End If
                    End If
                    detailObat(Trim(txtKodeObat.Text))
                ElseIf cmbPkt.Text = "Paket Khusus" Then
                    txtKodeObatKh.Text = gridBarang.Rows(e.RowIndex).Cells(2).Value
                    PanelObat.Visible = False
                    cekJangkaPemberianObatBPJS(Trim(txtKodeObatKh.Text))
                    If DT.Rows.Count > 0 Then
                        DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                        If DTPCekObat.Value > DTPTanggalTrans.Value Then
                            MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                            'Exit Sub
                        End If
                    End If
                    detailObat(Trim(txtKodeObatKh.Text))
                End If
            End If
        End If
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                If cmbPkt.Text = "Paket Umum" Then
                    txtKodeObat.Text = gridBarang.Rows(i).Cells(2).Value
                    PanelObat.Visible = False
                    cekJangkaPemberianObatBPJS(Trim(txtKodeObat.Text))
                    If DT.Rows.Count > 0 Then
                        DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                        If DTPCekObat.Value > DTPTanggalTrans.Value Then
                            MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                            'Exit Sub
                        End If
                    End If
                    detailObat(Trim(txtKodeObat.Text))
                ElseIf cmbPkt.Text = "Paket Khusus" Then
                    txtKodeObatKh.Text = gridBarang.Rows(i).Cells(2).Value
                    PanelObat.Visible = False
                    cekJangkaPemberianObatBPJS(Trim(txtKodeObatKh.Text))
                    If DT.Rows.Count > 0 Then
                        DTPCekObat.Value = DT.Rows(0).Item("tglakhir")
                        If DTPCekObat.Value > DTPTanggalTrans.Value Then
                            MsgBox("Pasien tersebut dan nama obat belum habis", vbInformation, "Informasi")
                            'Exit Sub
                        End If
                    End If
                    detailObat(Trim(txtKodeObatKh.Text))
                End If
            End If
        End If
    End Sub

    Sub cetakEtiketModel4()
        'Try
        Dim dtReport As New DataTable
        With dtReport
            .Columns.Add("namaObat")
            .Columns.Add("waktuMinum")
            .Columns.Add("ketMinum")
            '.Columns.Add("jenisObat")
        End With
        For i = 0 To gridEtiket.RowCount - 2
            If Not IsDBNull(gridEtiket.Rows(i).Cells(0).Value) Then
                dtReport.Rows.Add(gridEtiket.Rows(i).Cells("namaObat").Value, gridEtiket.Rows(i).Cells("waktuMinum").Value, gridEtiket.Rows(i).Cells("ketMinum").Value)
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
        rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
        rpt.SetParameterValue("noRM", Trim(txtRM.Text))
        rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
        rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
        'rpt.Refresh()
        rpt.SetParameterValue("ruang", Trim(nmSubUnit))
        rpt.SetParameterValue("bed", Trim(lblKamarBed.Text))


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

    Sub cetakNota()
        rptNota = New ReportDocument
        Try
            Dim str As String = Application.StartupPath & "\Report\notaResepEMR.rpt"
            rptNota.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rptNota.SetDatabaseLogon(dbUser, dbPassword)
            rptNota.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
            rptNota.SetParameterValue("notaresep", txtNoResep.Text)
            rptNota.SetParameterValue("alamat", txtAlamat.Text)
            rptNota.SetParameterValue("unit", nmSubUnit)
            rptNota.SetParameterValue("totalHarga", txtGrandTotalBulat.DecimalValue)
            rptNota.SetParameterValue("totalDijamin", txtGrandDijaminBulat.DecimalValue)
            rptNota.SetParameterValue("totalIurBayar", txtGrandIurBayarBulat.DecimalValue)
            rptNota.SetParameterValue("terbilang", bilang)
            rptNota.SetParameterValue("nmdepo", pnmapo)
            rptNota.SetParameterValue("umur", txtUmurThn.Text)
            FormCetak.CrystalReportViewer1.ReportSource = rptNota
            FormCetak.CrystalReportViewer1.Show()
            FormCetak.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Sub tampilBarangSemua()
        If pkdapo = "001" Then
            Stok = "stok001"
        ElseIf pkdapo = "002" Then
            Stok = "stok002"
        ElseIf pkdapo = "003" Then
            Stok = "stok003"
        ElseIf pkdapo = "004" Then
            Stok = "stok004"
        ElseIf pkdapo = "005" Then
            Stok = "stok005"
        ElseIf pkdapo = "006" Then
            Stok = "stok006"
        ElseIf pkdapo = "007" Then
            Stok = "stok007"
        End If
        Try
            DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from Barang_Farmasi WHERE stsaktif ='1' AND " & Stok & ">0  order by nama_barang", CONN)
            DS = New DataSet
            DA.Fill(DS, "obat")
            BDDataBarang.DataSource = DS
            BDDataBarang.DataMember = "obat"

            With gridBarang
                .DataSource = Nothing
                .DataSource = BDDataBarang
                .Columns(1).HeaderText = "ID Barang"
                .Columns(2).HeaderText = "Kode Barang"
                .Columns(3).HeaderText = "Nama Barang"
                .Columns(4).HeaderText = "Stok"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).HeaderText = "Satuan"
                .Columns(6).HeaderText = "Keterangan"
                .Columns(0).Width = 30
                .Columns(1).Width = 50
                .Columns(2).Width = 75
                .Columns(3).Width = 190
                .Columns(4).Width = 40
                .Columns(5).Width = 50
                .Columns(6).Width = 120
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

    Sub tampilBarang()
        If pkdapo = "001" Then
            Stok = "stok001"
        ElseIf pkdapo = "002" Then
            Stok = "stok002"
        ElseIf pkdapo = "003" Then
            Stok = "stok003"
        ElseIf pkdapo = "004" Then
            Stok = "stok004"
        ElseIf pkdapo = "005" Then
            Stok = "stok005"
        ElseIf pkdapo = "006" Then
            Stok = "stok006"
        ElseIf pkdapo = "007" Then
            Stok = "stok007"
        End If
        Try
            DA = New OleDb.OleDbDataAdapter("select idx_barang, kd_barang, LTRIM(RTRIM(nama_barang)) as nama_barang," & Stok & ", LTRIM(RTRIM(kd_satuan_kecil)) as kd_satuan_kecil, LTRIM(RTRIM(keterangan)) as keterangan from Barang_Farmasi WHERE stsaktif ='1' and " & Stok & ">0 order by nama_barang", CONN)
            DS = New DataSet
            DA.Fill(DS, "obat")
            BDDataBarang.DataSource = DS
            BDDataBarang.DataMember = "obat"

            With gridBarang
                .DataSource = Nothing
                .DataSource = BDDataBarang
                .Columns(1).HeaderText = "ID Barang"
                .Columns(2).HeaderText = "Kode Barang"
                .Columns(3).HeaderText = "Nama Barang"
                .Columns(4).HeaderText = "Stok"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).HeaderText = "Satuan"
                .Columns(6).HeaderText = "Keterangan"
                .Columns(0).Width = 30
                .Columns(1).Width = 50
                .Columns(2).Width = 75
                .Columns(3).Width = 190
                .Columns(4).Width = 40
                .Columns(5).Width = 50
                .Columns(6).Width = 120
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

    Private Sub btnDaftarTiket_Click(sender As Object, e As EventArgs) Handles btnDaftarTiket.Click
        FormPemanggil = "FormEditPenjualanResepEMR"
        FormCetakEtiketPerBarang.ShowDialog()
    End Sub

    Private Sub btnDaftarEtiketKh_Click(sender As Object, e As EventArgs) Handles btnDaftarEtiketKh.Click
        FormPemanggil = "FormEditPenjualanResepEMR"
        FormCetakEtiketPerBarang.ShowDialog()
    End Sub

    Private Sub gridPermintaanObat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPermintaanObat.CellContentClick
        Try
            If e.ColumnIndex = 0 Then
                noPermintaanObat = gridPermintaanObat.Rows(e.RowIndex).Cells("no_Permintaan_Obat").Value
                status_iteration = gridPermintaanObat.Rows(e.RowIndex).Cells("status_iteration").Value
                iteration_banyak = gridPermintaanObat.Rows(e.RowIndex).Cells("iteration_total").Value
                iteration_terlayani = gridPermintaanObat.Rows(e.RowIndex).Cells("iteration_terlayani").Value
                If status_iteration = "1" And iteration_terlayani < 3 Then
                    cekStatusProses(noPermintaanObat)
                    If statusProses = 0 Then
                        TampilResepObatJadi(gridPermintaanObat.Rows(e.RowIndex).Cells("no_Permintaan_Obat").Value)
                        TampilResepObatRacikan(gridPermintaanObat.Rows(e.RowIndex).Cells("no_Permintaan_Obat").Value)
                        addStatusPermintaan(noPermintaanObat)
                    Else
                        MsgBox("Barang yang di pilih sedang di proses", vbInformation, "Informasi")
                    End If
                Else
                    cekStatusProses(noPermintaanObat)
                    If statusProses = 0 Then
                        TampilResepObatJadi(gridPermintaanObat.Rows(e.RowIndex).Cells("no_Permintaan_Obat").Value)
                        TampilResepObatRacikan(gridPermintaanObat.Rows(e.RowIndex).Cells("no_Permintaan_Obat").Value)
                        addStatusPermintaan(noPermintaanObat)
                    Else
                        MsgBox("Barang yang di pilih sedang di proses", vbInformation, "Informasi")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Dilarang Klik pada Header Tabel terimakasih!!!")
        End Try
    End Sub

    Sub detailObatDilayani(ByRef gridObatJadi As DataGridView, ByVal row As Integer, ByVal status As Integer)
        noPermintaanObat = gridObatJadi.Rows(row).Cells("no_permintaan_obat").Value
        nmObatPermintaan = gridObatJadi.Rows(row).Cells("nama_barang").Value
        kdObatPermintaan = If(IsDBNull(gridObatJadi.Rows(row).Cells("kode_barang").Value), "-", gridObatJadi.Rows(row).Cells("kode_barang").Value)
        jmlObatPermintaan = gridObatJadi.Rows(row).Cells("jumlah_permintaan").Value
        statusObat = status
    End Sub

    Private Sub txtJarakED_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJarakED.KeyDown
        If e.KeyCode = Keys.Up Then
            cmbKeterangan.Focus()
        End If
    End Sub

    Private Sub txtJarakED_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJarakED.KeyPress
        If e.KeyChar = Chr(13) Then
            PanelEtiket.Visible = False
            If nmPaket = "PKTUMUM" Then
                btnAdd.Focus()
            Else
                btnAddKh.Focus()
            End If
        End If
    End Sub

    Sub cekJumlah(ByVal jmlAwal As Decimal, ByVal kdBarang As String)
        If pkdapo = "001" Then
            memStok = "stok001"
        ElseIf pkdapo = "002" Then
            memStok = "stok002"
        ElseIf pkdapo = "003" Then
            memStok = "stok003"
        ElseIf pkdapo = "004" Then
            memStok = "stok004"
        ElseIf pkdapo = "005" Then
            memStok = "stok005"
        ElseIf pkdapo = "006" Then
            memStok = "stok006"
        ElseIf pkdapo = "007" Then
            memStok = "stok007"
        Else
            MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
        End If

        CMD = New OleDb.OleDbCommand("select idx_barang,kd_barang,nama_barang, " & memStok & " as stok, kd_satuan_kecil from Barang_Farmasi where kd_barang='" & kdBarang & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            If DT.Rows(0).Item("stok") < jmlAwal Then
                Dim jawaban As Integer
                jawaban = MsgBox("Stok " + Trim(DT.Rows(0).Item("nama_barang")) + " hanya " + DT.Rows(0).Item("stok").ToString + ", Apa anda ingin memasukannya", vbQuestion + vbYesNo + vbDefaultButton2, "Informasi")
                If jawaban = vbYes And cmbPkt.Text = "Paket Umum" Then
                    txtJumlahJual.DecimalValue = DT.Rows(0).Item("stok")
                ElseIf jawaban = vbYes And cmbPkt.Text = "Paket Khusus" Then
                    txtJmlObatKh.DecimalValue = DT.Rows(0).Item("stok")
                ElseIf jawaban = vbNo And cmbPkt.Text = "Paket Umum" Then
                    txtJumlahJual.DecimalValue = 0
                ElseIf jawaban = vbNo And cmbPkt.Text = "Paket Khusus" Then
                    txtJmlObatKh.DecimalValue = 0
                End If
            Else
                If cmbPkt.Text = "Paket Umum" Then
                    txtJumlahJual.DecimalValue = jmlAwal
                Else
                    txtJmlObatKh.DecimalValue = jmlAwal
                End If
            End If
        End If
    End Sub

    Sub JumlahHargaUmum()
        txtJumlahHarga.DecimalValue = txtHargaJual.DecimalValue * txtJumlahJual.DecimalValue
        If cmbDijamin.Text = "N" Then
            txtDijamin.DecimalValue = 0
            txtIuranSisaBayar.DecimalValue = txtJumlahHarga.DecimalValue
        ElseIf cmbDijamin.Text = "Y" Then
            txtIuranSisaBayar.DecimalValue = 0
            txtDijamin.DecimalValue = txtJumlahHarga.DecimalValue
        End If
    End Sub

    Sub detailObatJadi(ByVal kdBarang As String)
        CMD = New OleDb.OleDbCommand("SELECT * FROM Barang_Farmasi WHERE kd_barang='" & kdBarang & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            If cmbPkt.Text = "Paket Umum" Then
                txtIdObat.Text = Trim(DT.Rows(0).Item("idx_barang"))
                lblNamaObat.Text = Trim(DT.Rows(0).Item("nama_barang"))
                nama_barang = lblNamaObat.Text
                If DT.Rows(0).Item("kd_jns_obat") = 17 Then
                    DiskonDinkes = 0
                Else
                    DiskonDinkes = DT.Rows(0).Item("harga_jual")
                End If
                HargaBeli = DiskonDinkes
                txtHargaJual.DecimalValue = DiskonDinkes
                txtKdSatuan.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
                'txtDosis.DecimalValue = DT.Rows(0).Item("dosis")
                txtSatDosis.Text = Trim(DT.Rows(0).Item("satdosis"))
                HargaJual()
                If cmbPenjamin.Text = "-|UMUM" Then
                    cmbDijamin.Text = "N"
                Else
                    cmbDijamin.Text = "Y"
                End If
                If cmbRacikNon.Text = "R" Then
                    txtDosisResep.Focus()
                Else
                    cmbDijamin.Focus()
                End If
            ElseIf cmbPkt.Text = "Paket Khusus" Then
                txtIdObatKh.Text = Trim(DT.Rows(0).Item("idx_barang"))
                lblNamaObatKh.Text = Trim(DT.Rows(0).Item("nama_barang"))
                nama_barang = lblNamaObatKh.Text
                If DT.Rows(0).Item("kd_jns_obat") = 17 Then
                    DiskonDinkes = 0
                Else
                    DiskonDinkes = DT.Rows(0).Item("harga_jual")
                End If
                HargaBeli = DiskonDinkes
                txtHargaJualKh.DecimalValue = DiskonDinkes
                txtSatPaketBPJSKh.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
                txtSatPaketLainKh.Text = Trim(DT.Rows(0).Item("kd_satuan_kecil"))
                'txtDosisKh.DecimalValue = DT.Rows(0).Item("dosis")
                txtSatDosisKh.Text = Trim(DT.Rows(0).Item("satdosis"))
                HargaJualKh()
                If cmbRacikNonKh.Text = "N" Then
                    txtPaketBPJSKh.Focus()
                Else
                    txtDosisResepKh.Focus()
                End If
            End If

            Generik = Trim(DT.Rows(0).Item("generik"))
            KdJenisObat = Trim(DT.Rows(0).Item("kd_jns_obat"))
            kdPabrik = Trim(DT.Rows(0).Item("kdpabrik"))
            kdKelompokObat = Trim(DT.Rows(0).Item("kd_kel_obat"))
            kdGolonganObat = Trim(DT.Rows(0).Item("kd_gol_obat"))
            txtSenPotBeli.DecimalValue = DT.Rows(0).Item("senpotbeli")
        End If

        CMD = New OleDb.OleDbCommand("SELECT * FROM jenis_obat WHERE kd_jns_obat='" & Trim(KdJenisObat) & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            JenisObat = Trim(DT.Rows(0).Item("jns_obat"))
            kDRekening = Trim(DT.Rows(0).Item("rek_p"))
        End If
    End Sub

    Sub HargaJual()
        txtHargaJual.DecimalValue = (txtHargaJual.DecimalValue + (txtHargaJual.DecimalValue * txtPPN.DecimalValue / 100)) + (txtHargaJual.DecimalValue * txtLaba.DecimalValue / 100)
    End Sub

    Sub HargaJualKh()
        txtHargaJualKh.DecimalValue = (txtHargaJualKh.DecimalValue + (txtHargaJualKh.DecimalValue * txtPPN.DecimalValue / 100)) + (txtHargaJualKh.DecimalValue * txtLaba.DecimalValue / 100)
    End Sub

    Sub cekJangkaPemberianObatBPJS(ByVal KodeObat As String)
        CMD = New OleDb.OleDbCommand("SELECT top(1) no_rm, kd_barang, tglakhir FROM ap_jualr2_bpjs WHERE no_rm='" & Trim(txtRM.Text) & "' AND kd_barang='" & KodeObat & "' AND kdbagian='" & pkdapo & "' order by tglakhir desc", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Sub cekStatusTerlayani(ByVal filter As String, idx_permintaan_obat As String)
        Dim bindingPermintaan As New BindingSource
        If filter = "idx_permintaan_obat" Then
            bindingPermintaan = BDPermintaanObatDetail
        Else
            bindingPermintaan = BDPermintaanObatRacikDetail
        End If

        bindingPermintaan.Filter = "status_terlayani = 1 and " & filter & "= '" & idx_permintaan_obat & "'"
        If bindingPermintaan.Count > 0 Then
            statusTerlayani = 1
            bindingPermintaan.RemoveFilter()
        Else
            bindingPermintaan.RemoveFilter()
            bindingPermintaan.Filter = "status_terlayani = 2 and " & filter & "= '" & idx_permintaan_obat & "'"
            If bindingPermintaan.Count > 0 Then
                statusTerlayani = 2
                bindingPermintaan.RemoveFilter()
            Else
                bindingPermintaan.RemoveFilter()
                statusTerlayani = 0
            End If
        End If
    End Sub

    Sub CariKamarBed()
        CMD = New OleDb.OleDbCommand("SELECT Tempat_Tidur.keterangan FROM Registrasi INNER JOIN Pasien ON Registrasi.no_RM = Pasien.no_RM INNER JOIN Rawat_Inap ON Registrasi.no_reg = Rawat_Inap.no_reg INNER JOIN Tempat_Tidur ON Rawat_Inap.kd_tempat_tidur = Tempat_Tidur.kd_tempat_tidur INNER JOIN Kamar ON Tempat_Tidur.kd_kamar = Kamar.kd_kamar INNER JOIN Sub_Unit ON Kamar.kd_sub_unit = Sub_Unit.kd_sub_unit where Registrasi.no_reg='" & noRegister & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Sub tampilDetailObatPaketUmum()
        Try
            DA = New OleDb.OleDbDataAdapter("select urut, racik, nama_barang, harga, jml, nmsatuan, totalharga, dijamin, sisabayar, jmljatah, 
                    stsrawat, kdkasir, nmkasir, tanggal, notaresep, no_reg, no_rm, nmpasien, umurthn, umurbln, kd_penjamin, nm_penjamin, kddokter, 
                    nmdokter, nonota,  kd_barang, idx_barang,  kd_jns_obat, kd_gol_obat, kd_kel_obat, kdpabrik, generik, formularium, jmlpaket as jmlp, 
                    totalpaket as totalp, jmlnonpaket as jmln, totalnonpaket as totaln, senpot, potongan, jmlnet, dijamin, sisabayar, hrgbeli, 
                    jamawal, kdbagian, stsresep, stsetiket, 'signa1' as qty1, 'signa2' as qty2, qty3, jmlhari, EtiketTakaran as takaran, 
                    EtiketWaktu as waktu, EtiketKetminum as ketminum, rek_p, posting, diserahkan, jns_obat, tglakhir, jml as jml_awal, 
                    CAST(REPLACE('2012-08-17', '-', '') AS DATETIME) as tgl_exp, nama_barang as nmobat_etiket, 0 as jmlobat_etiket, '' as model_etiket,
                    '' as nmobat_etiket_infus, 0 as jmlobat_etiket_infus, '' as obat_infus, '' as tetes_infus, '' as ket_waktu_pagi_model4, 
                    '' as ket_waktu_siang_model4, '' as ket_waktu_sore_model4, '' as ket_waktu_malam_model4, '' as ket_minum_model4 ,'' as takaran_s,'' as waktu_s,  '' as ketminum_s
                    from ap_jualr2 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "' order by urut", CONN)

            DSPenjualanResep = New DataSet

            DA.Fill(DSPenjualanResep, "PenjualanResep")
            BDPenjualanResep.DataSource = DSPenjualanResep
            BDPenjualanResep.DataMember = "PenjualanResep"

            DS = New DataSet '''''''''''''''' Bantu Tambahan
            DA.Fill(DS) ''''''''''''''''''''' Bantu Tambahan
            With gridStokKembali
                .DataSource = Nothing
                .DataSource = DS.Tables(0)
            End With

            DA = New OleDb.OleDbDataAdapter("select * from ap_etiketNew where tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'", CONN)
            DSEtiket = New DataSet
            DA.Fill(DSEtiket, "Etiket")
            BDEtiket.DataSource = DSEtiket
            BDEtiket.DataMember = "Etiket"

            If BDEtiket.Count > 0 Then
                BDEtiket.MoveFirst()
                For i = 1 To BDEtiket.Count
                    DRWEtiket = BDEtiket.Current
                    BDPenjualanResep.Filter = "kd_barang = '" & Trim(DRWEtiket.Item("kd_barang").ToString) & "' AND urut = '" & Trim(DRWEtiket.Item("urut")) & "'"
                    DRWPenjualanResep = BDPenjualanResep.Current
                    DRWPenjualanResep("qty1") = DRWEtiket.Item("signa1")
                    DRWPenjualanResep("qty2") = DRWEtiket.Item("signa2")
                    DRWPenjualanResep("takaran") = DRWEtiket.Item("kd_takaran")
                    DRWPenjualanResep("waktu") = DRWEtiket.Item("kd_waktu")
                    DRWPenjualanResep("ketminum") = DRWEtiket.Item("kd_ketminum")
                    DRWPenjualanResep("tgl_exp") = DRWEtiket.Item("tgl_exp")
                    DRWPenjualanResep("nmobat_etiket") = DRWEtiket.Item("nama_barang")
                    DRWPenjualanResep("jmlobat_etiket") = DRWEtiket.Item("jml_obat")
                    DRWPenjualanResep("model_etiket") = DRWEtiket.Item("model")
                    DRWPenjualanResep("nmobat_etiket_infus") = DRWEtiket.Item("nama_barang")
                    DRWPenjualanResep("jmlobat_etiket_infus") = DRWEtiket.Item("jml_obat")
                    DRWPenjualanResep("obat_infus") = DRWEtiket.Item("obat")
                    DRWPenjualanResep("tetes_infus") = DRWEtiket.Item("tetes")
                    DRWPenjualanResep("ket_waktu_pagi_model4") = DRWEtiket.Item("ket_waktu_pagi_model4")
                    DRWPenjualanResep("ket_waktu_siang_model4") = DRWEtiket.Item("ket_waktu_siang_model4")
                    DRWPenjualanResep("ket_waktu_sore_model4") = DRWEtiket.Item("ket_waktu_sore_model4")
                    DRWPenjualanResep("ket_waktu_malam_model4") = DRWEtiket.Item("ket_waktu_malam_model4")
                    DRWPenjualanResep("ket_minum_model4") = DRWEtiket.Item("ket_minum_model4")
                    BDPenjualanResep.EndEdit()
                    BDEtiket.MoveNext()
                Next
            End If
            BDPenjualanResep.RemoveFilter()
            With gridDetailObat
                .DataSource = Nothing
                .DataSource = BDPenjualanResep
            End With

            AturGriddetailBarang()
            TotalHarga()
            TotalDijamin()
            TotalIurBayar()
            txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub totalJualResep()
        Dim HitungJumlah As Decimal = 0
        HitungJumlah = (txtDosisResep.DecimalValue * txtJmlBungkus.DecimalValue) / txtDosis.DecimalValue
        txtJumlahJual.DecimalValue = HitungJumlah
    End Sub

    Sub TotalHarga()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("totalharga").Value
        Next
        txtGrandTotal.DecimalValue = HitungTotal
        txtGrandTotalBulat.DecimalValue = buletin(txtGrandTotal.DecimalValue, 100)
    End Sub

    Sub TotalDijamin()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("dijamin").Value
        Next
        txtGrandDijamin.DecimalValue = HitungTotal
        txtGrandDijaminBulat.DecimalValue = buletin(txtGrandDijamin.DecimalValue, 100)
    End Sub

    Sub TotalIurBayar()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("sisabayar").Value
        Next
        txtGrandIurBayar.DecimalValue = HitungTotal
        txtGrandIurBayarBulat.DecimalValue = buletin(txtGrandIurBayar.DecimalValue, 100)
    End Sub

    Sub TotalPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObatKh.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObatKh.Rows(baris).Cells("totalp").Value
        Next
        txtGrandTotalPaket.DecimalValue = HitungTotal
        txtGrandTotalPaketBulat.DecimalValue = buletin(txtGrandTotalPaket.DecimalValue, 100)
    End Sub

    Sub TotalNonPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObatKh.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObatKh.Rows(baris).Cells("totaln").Value
        Next
        txtGrandTotalNonPaket.DecimalValue = HitungTotal
        txtGrandTotalNonPaketBulat.DecimalValue = buletin(txtGrandTotalNonPaket.DecimalValue, 100)
    End Sub

    Sub AturGriddetailBarang()
        With gridDetailObat
            .Columns(0).HeaderText = "No"
            .Columns(0).ReadOnly = True
            .Columns(1).HeaderText = "R/N"
            .Columns(1).ReadOnly = True
            .Columns(2).HeaderText = "Nama Barang"
            .Columns(2).ReadOnly = True
            .Columns(3).HeaderText = "Harga"
            .Columns(3).ReadOnly = True
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Jumlah"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).DefaultCellStyle.BackColor = Color.LightYellow
            .Columns(5).HeaderText = "Satuan"
            .Columns(5).ReadOnly = True
            .Columns(6).HeaderText = "Jumlah Harga"
            .Columns(6).ReadOnly = True
            .Columns(6).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderText = "Dijamin"
            .Columns(7).ReadOnly = True
            .Columns(7).DefaultCellStyle.Format = "N2"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).HeaderText = "Iur Pasien"
            .Columns(8).ReadOnly = True
            .Columns(8).DefaultCellStyle.Format = "N2"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).HeaderText = "Jml Hari"
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).ReadOnly = True
            .Columns(0).Width = 40
            .Columns(1).Width = 40
            .Columns(2).Width = 320
            .Columns(3).Width = 100
            .Columns(4).Width = 100
            .Columns(5).Width = 80
            .Columns(6).Width = 120
            .Columns(7).Width = 100
            .Columns(8).Width = 100
            .Columns(9).Width = 40
            .Columns(0).Visible = False
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
            .Columns(21).Visible = False
            .Columns(22).Visible = False
            .Columns(23).Visible = False
            .Columns(24).Visible = False
            .Columns(25).Visible = False
            .Columns(26).Visible = False
            .Columns(27).Visible = False
            .Columns(28).Visible = False
            .Columns(29).Visible = False
            .Columns(30).Visible = False
            .Columns(31).Visible = False
            .Columns(32).Visible = False
            .Columns(33).Visible = False
            .Columns(34).Visible = False
            .Columns(35).Visible = False
            .Columns(36).Visible = False
            .Columns(37).Visible = False
            .Columns(38).Visible = False
            .Columns(39).Visible = False
            .Columns(40).Visible = False
            .Columns(41).Visible = False
            .Columns(42).Visible = False
            .Columns(43).Visible = False
            .Columns(44).Visible = False
            .Columns(45).Visible = False
            .Columns(46).Visible = False
            .Columns(47).Visible = False
            .Columns(48).Visible = False
            .Columns(49).Visible = False
            .Columns(50).Visible = False
            .Columns(51).Visible = False
            .Columns(52).Visible = False
            .Columns(53).Visible = False
            .Columns(54).Visible = False
            .Columns(55).Visible = False
            .Columns(56).Visible = False
            .Columns(57).Visible = False
            .Columns(58).Visible = False
            .Columns(59).Visible = False
            .Columns(60).Visible = False
            .Columns(61).Visible = False
            .Columns(62).Visible = False
            .Columns(63).Visible = False
            .Columns(64).Visible = False
            .Columns(65).Visible = False
            .Columns(66).Visible = False
            .Columns(67).Visible = False
            .Columns(68).Visible = False
            .Columns(69).Visible = False
            .Columns(70).Visible = False
            .Columns(71).Visible = False
            .Columns(72).Visible = False
            .Columns(73).Visible = False
            .Columns(74).Visible = False
            .Columns(75).Visible = False
            .BackgroundColor = Color.Azure
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .RowHeadersDefaultCellStyle.SelectionBackColor = Color.Empty
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
            .RowHeadersDefaultCellStyle.BackColor = Color.Black
        End With
    End Sub

    Sub AturGriddetailBarangKh()
        With gridDetailObatKh
            .Columns(0).HeaderText = "No"
            .Columns(1).HeaderText = "R/N"
            .Columns(2).HeaderText = "Nama Barang"
            .Columns(3).HeaderText = "Harga"
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Jumlah Paket BPJS"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "Total Paket BPJS"
            .Columns(5).DefaultCellStyle.Format = "N2"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(6).HeaderText = "Jumlah Paket Lain"
            .Columns(6).DefaultCellStyle.Format = "N2"
            .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(7).HeaderText = "Total Paket Lain"
            .Columns(7).DefaultCellStyle.Format = "N2"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).HeaderText = "Jumlah Obat"
            .Columns(8).DefaultCellStyle.Format = "N2"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).HeaderText = "Satuan"
            .Columns(10).HeaderText = "Jml Hari"
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).Width = 40
            .Columns(1).Width = 40
            .Columns(2).Width = 320
            .Columns(3).Width = 100
            .Columns(4).Width = 70
            .Columns(5).Width = 80
            .Columns(6).Width = 70
            .Columns(7).Width = 100
            .Columns(8).Width = 70
            .Columns(9).Width = 100
            .Columns(10).Width = 40
            .Columns(0).Visible = False
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
            .Columns(21).Visible = False
            .Columns(22).Visible = False
            .Columns(23).Visible = False
            .Columns(24).Visible = False
            .Columns(25).Visible = False
            .Columns(26).Visible = False
            .Columns(27).Visible = False
            .Columns(28).Visible = False
            .Columns(29).Visible = False
            .Columns(30).Visible = False
            .Columns(31).Visible = False
            .Columns(32).Visible = False
            .Columns(33).Visible = False
            .Columns(34).Visible = False
            .Columns(35).Visible = False
            .Columns(36).Visible = False
            .Columns(37).Visible = False
            .Columns(38).Visible = False
            .Columns(39).Visible = False
            .Columns(40).Visible = False
            .Columns(41).Visible = False
            .Columns(42).Visible = False
            .Columns(43).Visible = False
            .Columns(44).Visible = False
            .Columns(45).Visible = False
            .Columns(46).Visible = False
            .Columns(47).Visible = False
            .Columns(48).Visible = False
            .Columns(49).Visible = False
            .Columns(50).Visible = False
            .Columns(51).Visible = False
            .Columns(52).Visible = False
            .Columns(53).Visible = False
            .Columns(54).Visible = False
            .Columns(55).Visible = False
            .Columns(56).Visible = False
            .Columns(57).Visible = False
            .Columns(58).Visible = False
            .Columns(59).Visible = False
            .Columns(60).Visible = False
            .Columns(61).Visible = False
            .Columns(62).Visible = False
            .Columns(63).Visible = False
            .Columns(64).Visible = False
            .Columns(65).Visible = False
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

    Sub tampilDetailObatPaketKhusus()
        Try
            DA = New OleDb.OleDbDataAdapter("select urut, racik, nama_barang, harga, jmlpaket as jmlp, 
                        totalpaket as totalp, jmlnonpaket as jmln, totalnonpaket as totaln, jml,  
                        nmsatuan, jmljatah, stsrawat, kdkasir, nmkasir, tanggal, notaresep, no_reg, 
                        no_rm, nmpasien, umurthn, umurbln, kd_penjamin, nm_penjamin, kddokter, nmdokter, 
                        nonota,  kd_barang, idx_barang,  kd_jns_obat, kd_gol_obat, kd_kel_obat, kdpabrik, 
                        generik, formularium,totalharga, senpot, potongan, jmlnet, dijamin, sisabayar, hrgbeli, 
                        jamawal, kdbagian, stsresep, stsetiket, 'signa1' as qty1, 'signa2' as qty2, qty3, 
                        jmlhari, EtiketTakaran as takaran, EtiketWaktu as waktu, EtiketKetminum as ketminum, 
                        rek_p,posting, diserahkan, jns_obat, tglakhir, (jmlpaket + jmlnonpaket) as jml_awal,
                        CAST(REPLACE('2012-08-17', '-', '') AS DATETIME) as tgl_exp, nama_barang as nmobat_etiket, 
                        0 as jmlobat_etiket, '' as model_etiket, '' as nmobat_etiket_infus, 
                        0 as jmlobat_etiket_infus, '' as obat_infus, '' as tetes_infus 
                        from ap_jualr2 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' 
                        and notaresep='" & Trim(txtNoResep.Text) & "'  order by urut", CONN)
            DSPenjualanResepKh = New DataSet

            DA.Fill(DSPenjualanResepKh, "PenjualanResepKh")
            BDPenjualanResepKh.DataSource = DSPenjualanResepKh
            BDPenjualanResepKh.DataMember = "PenjualanResepKh"

            DS = New DataSet '''''''''''''''' Bantu Tambahan
            DA.Fill(DS) ''''''''''''''''''''' Bantu Tambahan
            With gridStokKembali
                .DataSource = Nothing
                .DataSource = DS.Tables(0)
            End With

            DA = New OleDb.OleDbDataAdapter("select * from ap_etiketNew where tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'", CONN)
            DSEtiket = New DataSet
            DA.Fill(DSEtiket, "Etiket")
            BDEtiket.DataSource = DSEtiket
            BDEtiket.DataMember = "Etiket"

            If BDEtiket.Count > 0 Then
                BDEtiket.MoveFirst()
                For i = 1 To BDEtiket.Count
                    DRWEtiket = BDEtiket.Current
                    BDPenjualanResepKh.Filter = "kd_barang = '" & Trim(DRWEtiket.Item("kd_barang").ToString) & "' AND urut = '" & Trim(DRWEtiket.Item("urut")) & "'"
                    DRWPenjualanResepKh = BDPenjualanResepKh.Current
                    DRWPenjualanResepKh("qty1") = DRWEtiket.Item("signa1")
                    DRWPenjualanResepKh("qty2") = DRWEtiket.Item("signa2")
                    DRWPenjualanResepKh("takaran") = DRWEtiket.Item("kd_takaran")
                    DRWPenjualanResepKh("waktu") = DRWEtiket.Item("kd_waktu")
                    DRWPenjualanResepKh("ketminum") = DRWEtiket.Item("kd_ketminum")
                    DRWPenjualanResepKh("tgl_exp") = DRWEtiket.Item("tgl_exp")
                    DRWPenjualanResepKh("nmobat_etiket") = DRWEtiket.Item("nama_barang")
                    DRWPenjualanResepKh("jmlobat_etiket") = DRWEtiket.Item("jml_obat")
                    DRWPenjualanResepKh("model_etiket") = DRWEtiket.Item("model")
                    DRWPenjualanResepKh("nmobat_etiket_infus") = DRWEtiket.Item("nama_barang")
                    DRWPenjualanResepKh("jmlobat_etiket_infus") = DRWEtiket.Item("jml_obat")
                    DRWPenjualanResepKh("obat_infus") = DRWEtiket.Item("obat")
                    DRWPenjualanResepKh("tetes_infus") = DRWEtiket.Item("tetes")
                    BDPenjualanResepKh.EndEdit()
                    BDEtiket.MoveNext()
                Next
            End If
            BDPenjualanResepKh.RemoveFilter()
            With gridDetailObatKh
                .DataSource = Nothing
                .DataSource = BDPenjualanResepKh
            End With

            AturGriddetailBarangKh()
            TotalPaket()
            TotalNonPaket()
            txtQtyKh.DecimalValue = gridDetailObatKh.Rows.Count() - 1

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilPermintaanObatDetail(ByVal no_permintaan_obat As String)
        DA = New OleDb.OleDbDataAdapter("SELECT 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_Barang, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Nama_Obat, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Obat, 
            Pegawai.nama_pegawai, 
            Sub_Unit.nama_sub_unit, 
            ap_seting_apotek.nmapo, 
            (DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Signa1 + ' x ' + DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Signa2) AS signa, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_takaran,
            DBSIMRM.dbo.etiket_takaran.Nama_takaran,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_waktu,
            DBSIMRM.dbo.etiket_waktu.nama_waktu,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_ketminum,
            DBSIMRM.dbo.etiket_ketminum.nama_ketminum,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Keterangan, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Status_Obat,
            DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_obat,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Status_Terlayani,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Terlayani,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_barang_terlayani,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Idx_Permintaan_Obat,
            DBSIMRS.dbo.Barang_Farmasi.nama_barang as barang_terlayani

            FROM DBSIMRM.dbo.RJ_Permintaan_Obat 
            INNER JOIN DBSIMRM.dbo.RJ_Permintaan_Obat_Detail ON DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat = DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.No_Permintaan_Obat 
            LEFT JOIN DBSIMRS.dbo.Barang_Farmasi ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_barang_terlayani = DBSIMRS.dbo.Barang_Farmasi.kd_barang 
            INNER JOIN DBSIMRS.dbo.Sub_Unit ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Sub_Unit = Sub_Unit.kd_sub_unit 
            INNER JOIN DBSIMRS.dbo.Pegawai ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Dokter = Pegawai.kd_pegawai 
            INNER JOIN DBSIMRS.dbo.ap_seting_apotek ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi = ap_seting_apotek.kdapo 
            INNER JOIN DBSIMRM.dbo.etiket_takaran ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_takaran = DBSIMRM.dbo.etiket_takaran.kd_takaran 
            INNER JOIN DBSIMRM.dbo.etiket_waktu ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_waktu = DBSIMRM.dbo.etiket_waktu.kd_waktu 
            INNER JOIN DBSIMRM.dbo.etiket_ketminum ON DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_ketminum = DBSIMRM.dbo.etiket_ketminum.kd_ketminum 
            WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & no_permintaan_obat & "'", CONN)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            BDPermintaanObatDetail.DataSource = DSPermintaanObatDetail
            BDPermintaanObatDetail.DataMember = "PermintaanObatDetail"
            For i = 0 To DT.Rows.Count - 1
                BDPermintaanObatDetail.AddNew()
                DRWPermintaanObatDetail = BDPermintaanObatDetail.Current

                Dim jumlah_terlayani = If(IsDBNull(DT.Rows(i).Item("jumlah_terlayani")), 0, DT.Rows(i).Item("jumlah_terlayani"))
                Dim barang_terlayani = If(IsDBNull(DT.Rows(i).Item("barang_terlayani")), "", DT.Rows(i).Item("barang_terlayani"))

                DRWPermintaanObatDetail("kode_barang") = Trim(DT.Rows(i).Item("kd_barang"))
                DRWPermintaanObatDetail("nama_barang") = Trim(DT.Rows(i).Item("nama_obat"))
                DRWPermintaanObatDetail("jumlah_permintaan") = DT.Rows(i).Item("jumlah_obat")
                DRWPermintaanObatDetail("signa") = Trim(DT.Rows(i).Item("signa"))
                DRWPermintaanObatDetail("takaran") = DT.Rows(i).Item("nama_takaran")
                DRWPermintaanObatDetail("waktu") = DT.Rows(i).Item("nama_waktu")
                DRWPermintaanObatDetail("ket_minum") = Trim(DT.Rows(i).Item("nama_ketminum"))
                DRWPermintaanObatDetail("keterangan") = Trim(DT.Rows(i).Item("keterangan"))
                DRWPermintaanObatDetail("status_terlayani") = Trim(DT.Rows(i).Item("status_terlayani"))
                DRWPermintaanObatDetail("jumlah_terlayani") = DT.Rows(i).Item("jumlah_terlayani")
                DRWPermintaanObatDetail("kd_barang_terlayani") = Trim(DT.Rows(i).Item("kd_barang_terlayani"))
                DRWPermintaanObatDetail("barang_terlayani") = Trim(barang_terlayani)
                DRWPermintaanObatDetail("no_permintaan_obat") = Trim(DT.Rows(i).Item("no_permintaan_obat"))
                DRWPermintaanObatDetail("idx_permintaan_obat") = Trim(DT.Rows(i).Item("idx_permintaan_obat"))
                BDPermintaanObatDetail.EndEdit()
            Next

            gridObatJadi.DataSource = Nothing
            With gridObatJadi
                .DataSource = BDPermintaanObatDetail
                .Columns(0).Width = 30
                .Columns(1).HeaderText = "Kode Obat"
                .Columns(1).Width = 80
                .Columns(2).HeaderText = "Nama Obat"
                .Columns(2).Width = 150
                .Columns(3).HeaderText = "Jumlah Obat"
                .Columns(3).Width = 50
                .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(3).DefaultCellStyle.Format = "N2"
                .Columns(4).HeaderText = "Signa"
                .Columns(4).Width = 40
                .Columns(5).HeaderText = "Takaran"
                .Columns(5).Width = 50
                .Columns(6).HeaderText = "Waktu"
                .Columns(6).Width = 120
                .Columns(7).HeaderText = "Keterangan Minum"
                .Columns(7).Width = 100
                .Columns(8).HeaderText = "Keterangan"
                .Columns(8).Width = 150
                .Columns(9).Visible = False
                .Columns(10).HeaderText = "Jumlah Terlayani"
                .Columns(10).Width = 70
                .Columns(11).Visible = False
                .Columns(12).HeaderText = "Obat Terlayani"
                .Columns(12).Width = 120
                .Columns(13).Visible = False
                .Columns(14).Visible = False
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .ReadOnly = True
                For i As Integer = 0 To .RowCount - 1
                    If .Rows(i).Cells("status_terlayani").Value = 1 Or .Rows(i).Cells("status_terlayani").Value = 2 Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    End If
                Next
            End With
        End If
    End Sub

    Sub cetakNotaBPJS()
        rptBPJS = New ReportDocument
        Try
            Dim str As String = Application.StartupPath & "\Report\notaResepBPJSKhusus.rpt"
            rptBPJS.Load(str)
            FormCetak.CrystalReportViewer1.Refresh()
            rptBPJS.SetDatabaseLogon(dbUser, dbPassword)
            rptBPJS.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
            rptBPJS.SetParameterValue("notaresep", txtNoResep.Text)
            rptBPJS.SetParameterValue("alamat", txtAlamat.Text)
            rptBPJS.SetParameterValue("unit", nmSubUnit)
            rptBPJS.SetParameterValue("totalNonPaketBulat", txtGrandTotalNonPaketBulat.DecimalValue)
            rptBPJS.SetParameterValue("totalPaketBulat", txtGrandTotalPaketBulat.DecimalValue)
            rptBPJS.SetParameterValue("terbilang", bilang)
            rptBPJS.SetParameterValue("nmdepo", pnmapo)
            rptBPJS.SetParameterValue("umur", txtUmurThn.Text)
            FormCetak.CrystalReportViewer1.ReportSource = rptBPJS
            FormCetak.CrystalReportViewer1.Show()
            FormCetak.ShowDialog()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCetakBPJS_Click(sender As Object, e As EventArgs) Handles btnCetakBPJS.Click
        FormPemanggil = "FormEditPenjualanResepEMR_BPJS"
        bilang = Terbilang(txtGrandTotalBulat.DecimalValue)
        cetakNotaBPJS()
        'btnCetakNota.Enabled = False
        btnCetakEtiket.Focus()
    End Sub

    Sub RefreshGridObatJadi()
        With gridObatJadi
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .ReadOnly = True
            For i As Integer = 0 To .RowCount - 1
                If (.Rows(i).Cells("status_terlayani").Value = 1 Or .Rows(i).Cells("status_terlayani").Value = 2) And status_iteration = "1" Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.LightBlue
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                ElseIf .Rows(i).Cells("status_terlayani").Value = 3 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                ElseIf .Rows(i).Cells("status_terlayani").Value = 1 Or .Rows(i).Cells("status_terlayani").Value = 2 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                End If
            Next
        End With
    End Sub

    Sub tampilPermintaanObatRacikanDetail(ByVal no_permintaan_obat As String)
        DA = New OleDb.OleDbDataAdapter("Select 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Nama_Racikan, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_Barang, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Nama_Obat, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Obat, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Bungkus, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Kekuatan_Obat, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Dosis_Obat, 

            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_waktu, 
            DBSIMRM.dbo.etiket_waktu.nama_waktu, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_takaran, 
            DBSIMRM.dbo.Jenis_Racikan_Obat.Nama_Jenis_Racikan, 
            (DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Signa1 + ' x ' + DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Signa2) AS signa, 
            DBSIMRM.dbo.etiket_ketminum.nama_ketminum, 

            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Keterangan, 
            DBSIMRM.dbo.etiket_takaran.Nama_takaran, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_ketminum, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Urut_Racikan, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Permintaan_Obat,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.status_terlayani, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.jumlah_terlayani, 
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_barang_terlayani,
            DBSIMRS.dbo.Barang_Farmasi.nama_barang as barang_terlayani,
            DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.idx_no_racikan
            From DBSIMRM.dbo.RJ_Permintaan_Obat 
            INNER Join Sub_Unit ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Sub_Unit = Sub_Unit.kd_sub_unit 
            INNER Join Pegawai ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Dokter = Pegawai.kd_pegawai 
            INNER Join ap_seting_apotek ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi = ap_seting_apotek.kdapo 
            INNER Join DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan On DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat = DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Permintaan_Obat 
            INNER Join DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.No_Racikan = DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.No_Racikan 
            LEFT Join DBSIMRS.dbo.Barang_Farmasi On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_barang_terlayani = DBSIMRS.dbo.Barang_Farmasi.kd_barang 
            INNER Join DBSIMRM.dbo.Jenis_Racikan_Obat On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Kd_Jenis_Racikan = DBSIMRM.dbo.Jenis_Racikan_Obat.Kd_Jenis_Racikan 
            INNER Join DBSIMRM.dbo.etiket_takaran On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_takaran = DBSIMRM.dbo.etiket_takaran.kd_takaran 
            INNER Join DBSIMRM.dbo.etiket_waktu On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_waktu = DBSIMRM.dbo.etiket_waktu.kd_waktu 
            INNER Join DBSIMRM.dbo.etiket_ketminum On DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.kd_ketminum = DBSIMRM.dbo.etiket_ketminum.kd_ketminum 
            WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & no_permintaan_obat & "' ORDER BY DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan.Nama_Racikan", CONN)
        DT = New DataTable
        BDPermintaanObatRacikDetail.DataSource = DSPermintaanObat
        BDPermintaanObatRacikDetail.DataMember = "PermintaanObat"
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            BDPermintaanObatRacikDetail.DataSource = DSPermintaanObatRacikDetail
            BDPermintaanObatRacikDetail.DataMember = "PermintaanObatRacikDetail"
            For i = 0 To DT.Rows.Count - 1
                BDPermintaanObatRacikDetail.AddNew()
                DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current

                Dim jumlah_terlayani = If(IsDBNull(DT.Rows(i).Item("jumlah_terlayani")), 0, DT.Rows(i).Item("jumlah_terlayani"))
                Dim barang_terlayani = If(IsDBNull(DT.Rows(i).Item("barang_terlayani")), "", DT.Rows(i).Item("barang_terlayani"))

                DRWPermintaanObatRacikDetail("nama_racikan") = Trim(DT.Rows(i).Item("nama_racikan"))
                DRWPermintaanObatRacikDetail("kode_barang") = Trim(DT.Rows(i).Item("kd_barang"))
                DRWPermintaanObatRacikDetail("nama_barang") = Trim(DT.Rows(i).Item("nama_obat"))
                DRWPermintaanObatRacikDetail("jumlah_permintaan") = DT.Rows(i).Item("jumlah_obat")
                DRWPermintaanObatRacikDetail("jumlah_bungkus") = DT.Rows(i).Item("jumlah_bungkus")
                DRWPermintaanObatRacikDetail("kekuatan") = DT.Rows(i).Item("kekuatan_obat")
                DRWPermintaanObatRacikDetail("dosis") = DT.Rows(i).Item("dosis_obat")
                DRWPermintaanObatRacikDetail("waktu") = Trim(DT.Rows(i).Item("nama_waktu"))
                DRWPermintaanObatRacikDetail("jenis_racikan") = Trim(DT.Rows(i).Item("nama_jenis_racikan"))
                DRWPermintaanObatRacikDetail("signa") = Trim(DT.Rows(i).Item("signa"))
                DRWPermintaanObatRacikDetail("ket_minum") = DT.Rows(i).Item("nama_ketminum")
                DRWPermintaanObatRacikDetail("keterangan") = Trim(DT.Rows(i).Item("keterangan"))
                DRWPermintaanObatRacikDetail("status_terlayani") = DT.Rows(i).Item("status_terlayani")
                DRWPermintaanObatRacikDetail("jumlah_terlayani") = DT.Rows(i).Item("jumlah_terlayani")
                DRWPermintaanObatRacikDetail("kd_barang_Terlayani") = Trim(DT.Rows(i).Item("kd_barang_terlayani"))
                DRWPermintaanObatRacikDetail("barang_terlayani") = Trim(barang_terlayani)
                DRWPermintaanObatRacikDetail("no_permintaan_obat") = Trim(DT.Rows(i).Item("no_permintaan_obat"))
                DRWPermintaanObatRacikDetail("idx_no_racikan") = Trim(DT.Rows(i).Item("idx_no_racikan"))
                DRWPermintaanObatRacikDetail("no_urut_racikan") = DT.Rows(i).Item("no_urut_racikan")
                BDPermintaanObatRacikDetail.EndEdit()
            Next

            gridObatRacikan.DataSource = Nothing
            With gridObatRacikan
                .DataSource = BDPermintaanObatRacikDetail
                .Columns(0).Width = 30
                .Columns(1).HeaderText = "Nama Racikan"
                .Columns(1).Width = 80
                .Columns(2).HeaderText = "Kode Obat"
                .Columns(2).Width = 80
                .Columns(3).HeaderText = "Nama Obat"
                .Columns(3).Width = 150
                .Columns(4).HeaderText = "Jumlah Obat"
                .Columns(4).Width = 40
                .Columns(4).DefaultCellStyle.Format = "N2"
                .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(5).HeaderText = "Jumlah Bungkus"
                .Columns(5).Width = 40
                .Columns(5).DefaultCellStyle.Format = "N2"
                .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(6).HeaderText = "Kekuatan"
                .Columns(6).Width = 40
                .Columns(6).DefaultCellStyle.Format = "N2"
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).HeaderText = "Dosis"
                .Columns(7).Width = 40
                .Columns(7).DefaultCellStyle.Format = "N2"
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).HeaderText = "Waktu"
                .Columns(8).Width = 100
                .Columns(9).HeaderText = "Jenis Racikan"
                .Columns(9).Width = 60
                .Columns(10).HeaderText = "Signa"
                .Columns(10).Width = 40
                .Columns(11).HeaderText = "Keterangan Minum"
                .Columns(11).Width = 140
                .Columns(12).HeaderText = "Keterangan"
                .Columns(12).Width = 140
                .Columns(13).Visible = False
                .Columns(14).HeaderText = "Jumlah Terlayani"
                .Columns(14).Width = 70
                .Columns(15).Visible = False
                .Columns(16).HeaderText = "Obat Terlayani"
                .Columns(16).Width = 120
                .Columns(17).Visible = False
                .Columns(18).Visible = False
                .Columns(19).Visible = False
                .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
                .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                .ReadOnly = True
                For i As Integer = 0 To .RowCount - 1
                    If .Rows(i).Cells("status_terlayani").Value = 1 Or .Rows(i).Cells("status_terlayani").Value = 2 Then
                        .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                        .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                    End If
                Next
            End With
        End If
    End Sub

    Sub RefreshGridObatRacikan()
        With gridObatRacikan
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightYellow
            .AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
            .ReadOnly = True
            For i As Integer = 0 To .RowCount - 1
                If .Rows(i).Cells("status_terlayani").Value = 1 Or .Rows(i).Cells("status_terlayani").Value = 2 Then
                    .Rows(i).DefaultCellStyle.BackColor = Color.LightGreen
                    .DefaultCellStyle.WrapMode = DataGridViewTriState.True
                End If
            Next
        End With
    End Sub

    Sub tampilPermintaanObat(ByVal no_permintaan_obat As String)
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT 
                    DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat, 
                    DBSIMRM.dbo.RJ_Permintaan_Obat.No_Reg, 
                    DBSIMRM.dbo.RJ_Permintaan_Obat.Tgl_Permintaan, 
                    DBSIMRS.dbo.Pegawai.nama_pegawai, 
                    CASE DBSIMRS.dbo.Pegawai.gelar_depan WHEN '-' THEN '' ELSE DBSIMRS.dbo.Pegawai.gelar_depan + '.' END + DBSIMRS.dbo.Pegawai.nama_pegawai + 
                    CASE DBSIMRS.dbo.Pegawai.gelar_belakang WHEN '-' THEN '' ELSE ', ' + DBSIMRS.dbo.Pegawai.gelar_belakang END AS Nama_Gelar, 
                    DBSIMRS.dbo.Pasien.nama_pasien, 
                    DBSIMRM.dbo.RJ_Permintaan_Obat.Status,
                    DBSIMRM.dbo.RJ_Permintaan_Obat.iteration,
                    DBSIMRM.dbo.RJ_Permintaan_Obat.iteration_banyak,
                    DBSIMRM.dbo.RJ_Permintaan_Obat.iteration_terlayani
                    FROM DBSIMRM.dbo.RJ_Permintaan_Obat 
                    INNER JOIN DBSIMRS.dbo.Sub_Unit ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Sub_Unit = DBSIMRS.dbo.Sub_Unit.kd_sub_unit 
                    INNER JOIN DBSIMRS.dbo.Pegawai ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Dokter = DBSIMRS.dbo.Pegawai.kd_pegawai 
                    INNER JOIN DBSIMRS.dbo.ap_seting_apotek ON DBSIMRM.dbo.RJ_Permintaan_Obat.Kd_Farmasi = DBSIMRS.dbo.ap_seting_apotek.kdapo 
                    INNER JOIN DBSIMRS.dbo.Pasien ON DBSIMRM.dbo.RJ_Permintaan_Obat.No_RM = DBSIMRS.dbo.Pasien.no_RM 
                    WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.no_permintaan_obat='" & no_permintaan_obat & "'", CONN)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                BDPermintaanObat.DataSource = DSPermintaanObat
                BDPermintaanObat.DataMember = "PermintaanObat"
                For i = 0 To DT.Rows.Count - 1
                    BDPermintaanObat.AddNew()
                    DRWPermintaanObat = BDPermintaanObat.Current

                    status = DT.Rows(i).Item("status")
                    status_iteration = If(IsDBNull(DT.Rows(i).Item("iteration")), "0", DT.Rows(i).Item("iteration"))
                    iteration_banyak = If(IsDBNull(DT.Rows(i).Item("iteration_banyak")), 0, DT.Rows(i).Item("iteration_banyak"))
                    iteration_terlayani = If(IsDBNull(DT.Rows(i).Item("iteration_banyak")), 0, DT.Rows(i).Item("iteration_terlayani"))

                    DRWPermintaanObat("no_permintaan_obat") = Trim(DT.Rows(i).Item("no_permintaan_obat"))
                    DRWPermintaanObat("no_reg") = Trim(DT.Rows(i).Item("no_reg"))
                    DRWPermintaanObat("tanggal_permintaan") = Trim(DT.Rows(i).Item("tgl_permintaan"))
                    DRWPermintaanObat("nama_dokter") = Trim(DT.Rows(i).Item("nama_gelar"))
                    DRWPermintaanObat("nama_pasien") = Trim(DT.Rows(i).Item("nama_pasien"))
                    DRWPermintaanObat("status") = Trim(DT.Rows(i).Item("status"))
                    DRWPermintaanObat("status_iteration") = Trim(status_iteration)
                    DRWPermintaanObat("iteration_total") = Trim(iteration_banyak)
                    DRWPermintaanObat("iteration_terlayani") = Trim(iteration_terlayani)
                Next

                With gridPermintaanObat
                    .DataSource = Nothing
                    .DataSource = BDPermintaanObat
                    .Columns(0).Width = 30
                    .Columns(1).HeaderText = "No Permintaan"
                    .Columns(1).Width = 100
                    .Columns(2).HeaderText = "No Registrasi"
                    .Columns(2).Width = 80
                    .Columns(3).HeaderText = "Tanggal Permintaan"
                    .Columns(3).Width = 75
                    .Columns(4).HeaderText = "Dokter"
                    .Columns(4).Width = 120
                    .Columns(5).HeaderText = "Pasien"
                    .Columns(5).Width = 120
                    .Columns(6).Visible = False
                    .Columns(7).Visible = False
                    .Columns(8).Visible = False
                    .Columns(9).Visible = False
                    .ReadOnly = True
                End With
                noPermintaanObat = no_permintaan_obat
                tampilPermintaanObatDetail(no_permintaan_obat)
                tampilPermintaanObatRacikanDetail(no_permintaan_obat)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilPaket()
        CMD = New OleDb.OleDbCommand("SELECT * 
				FROM ap_jualr1
				WHERE notaresep='" & Trim(txtNoResep.Text) & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)

        If DT.Rows.Count > 0 Then
            txtNoReg.Text = Trim(DT.Rows(0).Item("no_reg"))
            txtRM.Text = Trim(DT.Rows(0).Item("no_rm"))
            StatusRawat = Trim(DT.Rows(0).Item("stsrawat"))
            txtNamaPasien.Text = Trim(DT.Rows(0).Item("nama_pasien"))
            kdSubUnit = Trim(DT.Rows(0).Item("kd_sub_unit_asal"))
            nmSubUnit = Trim(DT.Rows(0).Item("nama_sub_unit"))
            KdPenjamin = Trim(DT.Rows(0).Item("kd_penjamin"))
            NamaPenjamin = Trim(DT.Rows(0).Item("nm_penjamin"))
            kdDokter = Trim(DT.Rows(0).Item("kddokter"))
            NamaDokter = Trim(DT.Rows(0).Item("nmdokter"))
            Posting = Trim(DT.Rows(0).Item("posting"))
            If NamaPenjamin = "-" Then
                cmbPenjamin.Text = "-|UMUM"
            Else
                cmbPenjamin.Text = NamaPenjamin + "|" + KdPenjamin
            End If
            cmbUnitAsal.Text = nmSubUnit + "|" + kdSubUnit
            cmbDokter.Text = NamaDokter + "|" + kdDokter
            'txtJnsRawat.Text = JenisRawat

            If IsDBNull(DT.Rows(0).Item("no_permintaan_obat")) Then
                MsgBox("Pasien tersebut pembuatan obat tidak melalui EMR", vbInformation, "Informasi")
                Exit Sub
            End If

            tampilPermintaanObat(Trim(DT.Rows(0).Item("no_permintaan_obat")))

        End If

        'Memunculkan NO KARtU dan SEP
        If JenisRawat = 2 Then
            CMD = New OleDb.OleDbCommand("SELECT pp.no_kartu, r.no_SJP
				FROM Registrasi as r
				LEFT OUTER JOIN Penjamin_Pasien as pp ON r.no_RM = pp.no_RM and r.kd_penjamin = pp.kd_penjamin
				WHERE r.no_reg='" & txtNoReg.Text & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                If IsDBNull(DT.Rows(0).Item("no_kartu")) And IsDBNull(DT.Rows(0).Item("no_SJP")) Then
                    noKartu = "-"
                    noSep = "-"
                Else
                    noKartu = DT.Rows(0).Item("no_kartu")
                    noSep = DT.Rows(0).Item("no_SJP")
                End If

            Else
                noKartu = "-"
                noSep = "-"
            End If
            kdICDSKU = "-"
            kdICDRM = "-"
        Else
            CMD = New OleDb.OleDbCommand("SELECT pp.no_kartu, r.no_SJP, sri.Kd_ICD as kd_icd_sku, dg.Kd_ICD as kd_icd_rm
				FROM Registrasi as r
				LEFT OUTER JOIN Penjamin_Pasien as pp ON r.no_RM = pp.no_RM AND r.kd_penjamin = pp.kd_penjamin 
				LEFT OUTER JOIN Diagnosa as dg ON r.no_reg = dg.no_reg 
				LEFT OUTER JOIN Surat_Rujukan_Internal as sri ON r.no_reg = sri.no_reg
				WHERE r.no_reg ='" & txtNoReg.Text & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)

            If DT.Rows.Count > 0 Then
                If IsDBNull(DT.Rows(0).Item("no_kartu")) And IsDBNull(DT.Rows(0).Item("kd_icd_sku")) And IsDBNull(DT.Rows(0).Item("kd_icd_rm")) And IsDBNull(DT.Rows(0).Item("no_SJP")) Then
                    noKartu = "-"
                    noSep = "-"
                    kdICDSKU = "-"
                    kdICDRM = "-"
                ElseIf IsDBNull(DT.Rows(0).Item("no_kartu")) And IsDBNull(DT.Rows(0).Item("kd_icd_sku")) Then
                    noKartu = "-"
                    noSep = "-"
                    kdICDSKU = "-"
                    kdICDRM = "-"
                ElseIf IsDBNull(DT.Rows(0).Item("no_kartu")) And IsDBNull(DT.Rows(0).Item("kd_icd_sku")) Then
                    noKartu = "-"
                    noSep = "-"
                    kdICDSKU = "-"
                    kdICDRM = DT.Rows(0).Item("kd_icd_rm")
                ElseIf IsDBNull(DT.Rows(0).Item("no_SJP")) And IsDBNull(DT.Rows(0).Item("kd_icd_sku")) Then
                    noKartu = "-"
                    noSep = "-"
                    kdICDSKU = "-"
                    kdICDRM = DT.Rows(0).Item("kd_icd_rm")
                ElseIf IsDBNull(DT.Rows(0).Item("no_kartu")) And IsDBNull(DT.Rows(0).Item("kd_icd_rm")) Then
                    noKartu = "-"
                    noSep = "-"
                    kdICDSKU = DT.Rows(0).Item("kd_icd_sku")
                    kdICDRM = "-"
                ElseIf IsDBNull(DT.Rows(0).Item("no_SJP")) And IsDBNull(DT.Rows(0).Item("kd_icd_rm")) Then
                    noKartu = "-"
                    noSep = "-"
                    kdICDSKU = DT.Rows(0).Item("kd_icd_sku")
                    kdICDRM = "-"
                ElseIf IsDBNull(DT.Rows(0).Item("no_SJP")) And IsDBNull(DT.Rows(0).Item("kd_icd_sku")) Then
                    noKartu = "-"
                    noSep = "-"
                    kdICDSKU = "-"
                    kdICDRM = DT.Rows(0).Item("kd_icd_rm")
                ElseIf IsDBNull(DT.Rows(0).Item("kd_icd_sku")) And IsDBNull(DT.Rows(0).Item("kd_icd_rm")) Then
                    noKartu = DT.Rows(0).Item("no_kartu")
                    noSep = DT.Rows(0).Item("no_SJP")
                    kdICDSKU = "-"
                    kdICDRM = "-"
                ElseIf IsDBNull(DT.Rows(0).Item("kd_icd_sku")) Then
                    noKartu = DT.Rows(0).Item("no_kartu")
                    noSep = DT.Rows(0).Item("no_SJP")
                    kdICDSKU = "-"
                    kdICDRM = DT.Rows(0).Item("kd_icd_rm")
                ElseIf IsDBNull(DT.Rows(0).Item("kd_icd_rm")) Then
                    noKartu = DT.Rows(0).Item("no_kartu")
                    noSep = DT.Rows(0).Item("no_SJP")
                    kdICDSKU = DT.Rows(0).Item("kd_icd_sku")
                    kdICDRM = "-"
                ElseIf IsDBNull(DT.Rows(0).Item("no_kartu")) Then
                    noKartu = "-"
                    noSep = "-"
                    kdICDSKU = DT.Rows(0).Item("kd_icd_sku")
                    kdICDRM = DT.Rows(0).Item("kd_icd_rm")
                Else
                    noKartu = DT.Rows(0).Item("no_kartu")
                    noSep = DT.Rows(0).Item("no_SJP")
                    kdICDSKU = DT.Rows(0).Item("kd_icd_sku")
                    kdICDRM = DT.Rows(0).Item("kd_icd_rm")
                End If

            Else
                noKartu = "-"
                noSep = "-"
                kdICDSKU = "-"
                kdICDRM = "-"
            End If
        End If

        txtNoKartu.Text = noKartu
        txtSEP.Text = noSep
        'txtIcdSKU.Text = kdICDSKU
        'txtIcdRM.Text = kdICDRM
        CMD = New OleDb.OleDbCommand("SELECT Pasien.no_RM, Pasien.alamat, Pasien.RT, Pasien.RW, Kelurahan.nama_kelurahan, Kecamatan.nama_kecamatan,Kabupaten.nama_kabupaten, Propinsi.nama_propinsi, pasien.nama_pasien, case pasien.jns_kel when '0' then 'P' else 'L' end as jns_kel, pasien.tgl_lahir FROM Pasien INNER JOIN Kelurahan ON Pasien.kd_kelurahan = Kelurahan.kd_kelurahan INNER JOIN Kecamatan ON Kelurahan.kd_kecamatan = Kecamatan.kd_kecamatan INNER JOIN Kabupaten ON Kecamatan.kd_kabupaten = Kabupaten.kd_kabupaten INNER JOIN Propinsi ON Kabupaten.kd_propinsi = Propinsi.kd_propinsi where Pasien.no_RM='" & txtRM.Text & "'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        txtAlamat.Text = DT.Rows(0).Item("alamat") + " RT " + DT.Rows(0).Item("rt") + " RW " + DT.Rows(0).Item("rw") + " Kel : " + DT.Rows(0).Item("nama_kelurahan") + " Kec : " + DT.Rows(0).Item("nama_kecamatan") + " Kab : " + DT.Rows(0).Item("nama_kabupaten") + " Prov : " + DT.Rows(0).Item("nama_propinsi")
        tglLahirPasien = DT.Rows(0).Item("tgl_lahir")
        txtSex.Text = DT.Rows(0).Item("jns_kel")
        TglServer()
        'txtUmurThn.Text = DateDiff(DateInterval.Year, tglLahirPasien, TanggalServer)
        'txtUmurBln.Text = DateDiff(DateInterval.Month, tglLahirPasien, TanggalServer) Mod 12
        txtUmurThn.Text = TanggalServer.Year - tglLahirPasien.Year
        txtUmurBln.Text = TanggalServer.Month - tglLahirPasien.Month
        If Val(txtUmurBln.Text) < 0 Then
            txtUmurThn.Text = Val(txtUmurThn.Text) - 1
            txtUmurBln.Text = 12 + Val(txtUmurBln.Text)
        End If

        If cmbPkt.Text = "Paket Umum" Then
            tampilDetailObatPaketKhusus()
            gridDetailObatKh.DataSource = Nothing
            DSPenjualanResepKh.Clear()
            tampilDetailObatPaketUmum()
        Else
            tampilDetailObatPaketUmum()
            gridDetailObat.DataSource = Nothing
            DSPenjualanResep.Clear()
            tampilDetailObatPaketKhusus()
        End If

    End Sub

    Private Sub gridPasien_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPasien.CellContentClick
        If cmbJenisRawat.SelectedIndex = 1 Then
            noRegister = Trim(gridPasien.Rows(e.RowIndex).Cells("no_reg").Value)
            CariKamarBed()
            If DT.Rows.Count > 0 Then
                lblKamarBed.Text = DT.Rows(0).Item("keterangan")
            End If
        End If
        Dim Paket As String
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridPasien.Rows(e.RowIndex).Cells(1).Value) Then
                txtNoResep.Text = Trim(gridPasien.Rows(e.RowIndex).Cells(4).Value)
                Paket = Trim(gridPasien.Rows(e.RowIndex).Cells(8).Value)
                If Paket = "PKTUMUM" Then
                    cmbPkt.SelectedIndex = 0
                Else
                    cmbPkt.SelectedIndex = 1
                End If
                PanelPasien.Visible = False
                tampilPaket()
                If cmbPenjamin.Text = "-|UMUM" Then
                    cmbDijamin.Text = "N"
                Else
                    cmbDijamin.Text = "Y"
                End If
            End If
            btnInfoResep.Enabled = True
            btnInfoResepKh.Enabled = True
            btnBaru.Enabled = True
            btnSimpan.Enabled = True
            btnBaruKh.Enabled = True
            btnSimpanKh.Enabled = True
            btnCetakBPJS.Enabled = True
            'btnCetakLain.Enabled = True
            btnCetakEtiketKh.Enabled = True
            btnCetakNota.Enabled = True
            btnCetakEtiket.Enabled = True
            btnHapusNota.Enabled = True
            btnHapusNotaKh.Enabled = True
            btnUpdateDijamin.Enabled = True
            btnUpdateIurPasien.Enabled = True
        End If
    End Sub

    Private Sub cmbPkt_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbPkt.SelectedIndexChanged
        If cmbPkt.SelectedIndex = 0 Then
            TabPktUmum.TabVisible = True
            TabPktKhusus.TabVisible = False
            cmbRacikNon.Focus()
        ElseIf cmbPkt.SelectedIndex = 1 Then
            TabPktUmum.TabVisible = False
            TabPktKhusus.TabVisible = True
            cmbRacikNonKh.Focus()
        Else
            TabPktUmum.TabVisible = False
            TabPktKhusus.TabVisible = False
        End If
    End Sub

    Private Sub gridPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridPasien.KeyPress
        Dim i As Integer
        If gridPasien.Rows.Count() > 1 Then
            i = gridPasien.CurrentRow.Index - 1
        Else
            i = gridPasien.CurrentRow.Index
        End If
        If cmbJenisRawat.SelectedIndex = 1 Then
            noRegister = Trim(gridPasien.Rows(i).Cells("no_reg").Value)
            CariKamarBed()
            If DT.Rows.Count > 0 Then
                lblKamarBed.Text = DT.Rows(0).Item("keterangan")
            End If
        End If
        Dim Paket As String
        If e.KeyChar = Chr(13) Then
            If Not IsDBNull(gridPasien.Rows(i).Cells(1).Value) Then
                txtNoResep.Text = Trim(gridPasien.Rows(i).Cells(4).Value)
                Paket = Trim(gridPasien.Rows(i).Cells(8).Value)
                If Paket = "PKTUMUM" Then
                    cmbPkt.SelectedIndex = 0
                Else
                    cmbPkt.SelectedIndex = 1
                End If
                PanelPasien.Visible = False
                tampilPaket()
                If cmbPenjamin.Text = "-|UMUM" Then
                    cmbDijamin.Text = "N"
                Else
                    cmbDijamin.Text = "Y"
                End If
            End If
            btnInfoResep.Enabled = True
            btnInfoResepKh.Enabled = True
            btnBaru.Enabled = True
            btnSimpan.Enabled = True
            btnBaruKh.Enabled = True
            btnSimpanKh.Enabled = True
            btnCetakBPJS.Enabled = True
            'btnCetakLain.Enabled = True
            btnCetakEtiketKh.Enabled = True
            btnCetakNota.Enabled = True
            btnCetakEtiket.Enabled = True
            'btnHapusNota.Enabled = True
            'btnHapusNotaKh.Enabled = True
            btnUpdateDijamin.Enabled = True
            btnUpdateIurPasien.Enabled = True
        End If
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
        If rRm.Checked = True Then
            BDDataPasien.Filter = "no_RM like '%" & txtCariPasien.Text & "%'"
        Else
            BDDataPasien.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
        End If
    End Sub

    Private Sub txtCariPasien_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPasien.KeyDown
        If e.KeyCode = Keys.Down Then
            gridPasien.Focus()
        End If
    End Sub

    Private Sub btnEx_Click(sender As Object, e As EventArgs) Handles btnEx.Click
        PanelPasien.Visible = False
    End Sub

    Public jmlHariEtiketModel4, statusObat, statusProses, statusTerlayani As Integer

    Public nmSubUnit, noRegister, bilang, nmTakaran, nmWaktu, nmKeterangan, kd_barang_permintaan, idx_permintaan_obat, jenisPelayanan As String

    Private Sub txtNoResep_Click(sender As Object, e As EventArgs) Handles txtNoResep.Click
        Bulan = Month(DTPBantu.Value)
        Tahun = Year(DTPBantu.Value)
        'cekTutupStok()
        'If DT.Rows.Count > 0 Then
        '    DTPTanggalTrans.Focus()
        '    MsgBox("Tidak bisa melakukan transaksi!!! " & vbCrLf & "Bulan dan tahun tersebut sudah tutup stok", vbInformation, "Informasi")
        '    Exit Sub
        'Else
        tampilPasien()
        PanelPasien.Visible = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
        'End If
    End Sub

    Sub tampilPasien()
        Try
            DA = New OleDb.OleDbDataAdapter("select kdbagian,stsrawat,tanggal,notaresep,no_rm,
					LTRIM(RTRIM(nama_pasien)) as nama_pasien,LTRIM(RTRIM(nmdokter)),stsresep,no_reg 
					FROM ap_jualr1 
					where kdbagian='" & pkdapo & "' 
					AND stsrawat='" & StatusRawat & "' 
					AND tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' 
                    AND no_permintaan_obat <> null 
                    OR stsrawat='" & StatusRawat & "' 
					AND tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' 
                    AND no_permintaan_obat <> ' '
					ORDER BY tanggal, notaresep", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasien")
            BDDataPasien.DataSource = DS
            BDDataPasien.DataMember = "pasien"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDDataPasien
                .Columns(1).HeaderText = "Unit Depo"
                .Columns(2).HeaderText = "Status Rawat"
                .Columns(3).HeaderText = "Tanggal Resep"
                .Columns(4).HeaderText = "Nota Resep"
                .Columns(5).HeaderText = "No RM"
                .Columns(6).HeaderText = "Nama Pasien"
                .Columns(7).HeaderText = "Nama Dokter"
                .Columns(8).HeaderText = "Status Resep"
                .Columns(0).Width = 30
                .Columns(1).Width = 40
                .Columns(2).Width = 45
                .Columns(3).Width = 75
                .Columns(4).Width = 100
                .Columns(5).Width = 60
                .Columns(6).Width = 130
                .Columns(7).Width = 130
                .Columns(8).Width = 75
                .Columns(9).Visible = False
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

    Sub cekTutupStok()
        CMD = New OleDb.OleDbCommand("select kdbagian, bulan, tahun FROM ap_stok_awalapo WHERE kdbagian=" & pkdapo & " and bulan='" & Bulan & "' and tahun='" & Tahun & "'", CONN)
        'CMD = New OleDb.OleDbCommand("select kdbagian, bulan, tahun FROM ap_stok_awalapo WHERE kdbagian=" & pkdapo & " and bulan='12' and tahun='2018'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
    End Sub

    Private Sub btnSimpanKh_Click(sender As Object, e As EventArgs) Handles btnSimpanKh.Click
        If Posting = "2" Then
            MsgBox("Transaksi tidak bisa diedit, sudah diposting oleh kasir", vbInformation, "Informasi")
            Exit Sub
        End If
        cariDokter()
        cariSubUnitAsal()
        cariNamaPenjamin()
        If pkdapo = "001" Then
            memStok = "stok001"
        ElseIf pkdapo = "002" Then
            memStok = "stok002"
        ElseIf pkdapo = "003" Then
            memStok = "stok003"
        ElseIf pkdapo = "004" Then
            memStok = "stok004"
        ElseIf pkdapo = "005" Then
            memStok = "stok005"
        ElseIf pkdapo = "006" Then
            memStok = "stok006"
        ElseIf pkdapo = "007" Then
            memStok = "stok007"
        Else
            MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Cek Stok
        If CekKunciStokPenjualan = "Y" Then
            For i = 0 To gridDetailObat.RowCount - 2
                CMD = New OleDb.OleDbCommand("select idx_barang,kd_barang,nama_barang, " & memStok & " as stok, kd_satuan_kecil from Barang_Farmasi where idx_barang='" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "'", CONN)
                DA = New OleDb.OleDbDataAdapter(CMD)
                DT = New DataTable
                DA.Fill(DT)
                If DT.Rows.Count > 0 Then
                    If (DT.Rows(0).Item("stok") + gridDetailObat.Rows(i).Cells("jml_awal").Value) < gridDetailObat.Rows(i).Cells("jml").Value Then
                        MsgBox("Stok " + Trim(DT.Rows(0).Item("nama_barang")) + " hanya " + (DT.Rows(0).Item("stok") + gridDetailObat.Rows(i).Cells("jml_awal").Value).ToString + " masukan ulang jumlah barang", vbInformation, "Informasi")
                        Exit Sub
                    End If
                End If
            Next
        End If

        If MessageBox.Show("Data Penjualan sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlEditPenjualanObatKh As String = ""
            TglServer()
            DTPJamAkhir.Value = TanggalServer
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS APOTEK''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr1
                sqlEditPenjualanObatKh = "Delete from ap_jualr1 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr2
                sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "Delete from ap_jualr2 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr2_bpjs
                sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "Delete from ap_jualr2_bpjs WHERE tglresep='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_etiketNew
                sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "Delete from ap_etiketNew WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS KASIR'''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual
                sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "Delete from resep_jual WHERE no_nota='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual_detail
                sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "Delete from resep_jual_detail WHERE no_nota='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''Stok Kembali Asal'''''''''''''''''''''''''''''''''''''''''''''
                If psts_stok = "1" Then
                    For i = 0 To gridStokKembali.RowCount - 2
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "UPDATE Barang_Farmasi SET " & memStok & "=(" & memStok & "+" & Num_En_US(gridStokKembali.Rows(i).Cells("jml").Value) & ") WHERE kd_barang='" & Trim(gridStokKembali.Rows(i).Cells("kd_barang").Value) & "'"
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''TRANS KE APOTEK'''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 'Simpan ap_jualr1
                sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "insert into ap_jualr1 (stsrawat,kdkasir,nmkasir,tanggal,
                            notaresep,no_reg,no_rm,nama_pasien,kd_penjamin,nm_penjamin,kddokter,
                            nmdokter,kdbagian,stsresep,totalpaket,totalpaket_bulat,totalnonpaket,
                            totalnonpaket_bulat,totaldijamin,totaldijamin_bulat,totalselisih_bayar,
                            totalselisih_bayar_bulat,kd_sub_unit,kd_sub_unit_asal,nama_sub_unit,jam,
                            rsp_pulang,posting,diserahkan,no_permintaan_obat) 
                        values ('" & StatusRawat & "', '" & Trim(FormLogin.LabelKode.Text) & "', 
                            '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', 
                            '" & Trim(txtNoResep.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', 
                            '" & Trim(txtNamaPasien.Text) & "', '" & KdPenjamin & "', '" & NamaPenjamin & "', '" & kdDokter & "', 
                            '" & NamaDokter & "', '" & pkdapo & "', 'PKTKHUSUS', '" & Num_En_US(txtGrandTotalPaket.DecimalValue) & "', 
                            '" & Num_En_US(txtGrandTotalPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalNonPaket.DecimalValue) & "', 
                            '" & Num_En_US(txtGrandTotalNonPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalPaket.DecimalValue) & "', 
                            '" & Num_En_US(txtGrandTotalPaketBulat.DecimalValue) & "', '0', '0', '" & kdSubUnit & "', '" & kdSubUnit & "', 
                            '" & nmSubUnit & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', 'N', '1', 'B', '" & noPermintaanObat & "')"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 'Simpan ap_jualr2
                For i = 0 To gridDetailObatKh.RowCount - 2
                    sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "INSERT INTO ap_jualr2(stsrawat,kdkasir,nmkasir,tanggal,notaresep,no_reg,no_rm,nmpasien,umurthn,umurbln,kd_penjamin,nm_penjamin,kddokter,nmdokter,nonota,urut,kd_barang,idx_barang,nama_barang,kd_jns_obat,kd_gol_obat,kd_kel_obat,kdpabrik,generik,formularium,racik,harga,jmlpaket,totalpaket,jmlnonpaket,totalnonpaket,jml,nmsatuan,totalharga,senpot,potongan,jmlnet,dijamin,sisabayar,hrgbeli,jamawal,kdbagian,stsresep,rek_p,stsetiket,jmlhari,posting,diserahkan,jam,rsp_pulang,jns_obat,jmljatah,tglakhir) VALUES ('" & StatusRawat & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "','" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "','" & Trim(txtUmurThn.Text) & "', '" & Trim(txtUmurBln.Text) & "', '" & KdPenjamin & "', '" & NamaPenjamin & "', '" & kdDokter & "', '" & NamaDokter & "', '" & Trim(txtNota.Text) & "', " & i + 1 & ", '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("idx_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nama_barang").Value)) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_jns_obat").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_gol_obat").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_kel_obat").Value) & "','" & Trim(gridDetailObatKh.Rows(i).Cells("kdpabrik").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("generik").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("formularium").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("racik").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlp").Value) & "','" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalp").Value) & "','" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmln").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totaln").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jml").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalharga").Value) & "', '" & gridDetailObatKh.Rows(i).Cells("senpot").Value & "','" & Num_En_US(gridDetailObatKh.Rows(i).Cells("potongan").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlnet").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("sisabayar").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("hrgbeli").Value) & "', '" & Format(DTPJamAwal.Value, "HH:mm:ss") & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kdbagian").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("stsresep").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("rek_p").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("stsetiket").Value) & "', '" & gridDetailObatKh.Rows(i).Cells("jmlhari").Value & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("posting").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("diserahkan").Value) & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', 'N', '" & Trim(gridDetailObatKh.Rows(i).Cells("jns_obat").Value) & "', '" & gridDetailObatKh.Rows(i).Cells("jmljatah").Value & "', '" & Format(gridDetailObatKh.Rows(i).Cells("tglakhir").Value, "yyyy/MM/dd") & "')"
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Jatah Paket
                For i = 0 To gridDetailObatKh.RowCount - 2
                    If gridDetailObatKh.Rows(i).Cells("jmljatah").Value > 0 Then
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "INSERT INTO ap_jualr2_bpjs(stsrawat,tglresep,notaresep,no_rm,kd_penjamin,kd_barang,nama_barang,jmlpaket,jmlnonpaket,jmljatah,tglakhir,kdbagian) VALUES ('" & StatusRawat & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & KdPenjamin & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nama_barang").Value)) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlp").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmln").Value) & "', '" & gridDetailObatKh.Rows(i).Cells("jmljatah").Value & "', '" & Format(gridDetailObatKh.Rows(i).Cells("tglakhir").Value, "yyyy/MM/dd") & "',  '" & Trim(gridDetailObatKh.Rows(i).Cells("kdbagian").Value) & "')"
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Simpan etiketNew
                'If  pkdapo = "002" Or  pkdapo = "005" Then
                For i = 0 To gridDetailObatKh.RowCount - 2
                    'Dim a = gridDetailObatKh.CurrentRow.Index - 1
                    If gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "1" Then
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, signa1, signa2, tgl_exp, jml_obat, urut, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value)) & "', '" & gridDetailObatKh.Rows(i).Cells("takaran").Value & "', '" & gridDetailObatKh.Rows(i).Cells("waktu").Value & "', '" & gridDetailObatKh.Rows(i).Cells("ketminum").Value & "','" & Trim(gridDetailObatKh.Rows(i).Cells("qty1").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("qty2").Value) & "',  '" & Format(gridDetailObatKh.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ",'1')"
                    ElseIf gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "2" Then
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, jml_obat, urut, obat, tetes, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nmobat_etiket_infus").Value)) & "',  '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlobat_etiket_infus").Value) & "', " & i + 1 & ", '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("obat_infus").Value)) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("tetes_infus").Value)) & "','2')"

                    ElseIf gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObatKh.Rows(i).Cells("model_etiket").Value = "3" Then
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, jml_obat, urut, kd_ketminum, tgl_exp, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value)) & "',  '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ", '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("ketminum").Value)) & "', '" & Format(gridDetailObatKh.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '3')"
                    End If
                Next
                ' End If

                'Else

                'For i = 0 To gridDetailObatKh.RowCount - 2
                '    If gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" Then
                '        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh + vbCrLf + "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, signa1, signa2, tgl_exp, jml_obat, urut) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nmobat_etiket").Value)) & "', '" & gridDetailObatKh.Rows(i).Cells("takaran").Value & "', '" & gridDetailObatKh.Rows(i).Cells("waktu").Value & "', '" & gridDetailObatKh.Rows(i).Cells("ketminum").Value & "','" & Trim(gridDetailObatKh.Rows(i).Cells("qty1").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("qty2").Value) & "', '" & Format(gridDetailObatKh.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ")"
                '    End If
                'Next
                'End If
                ''''''''''''''''''''''''''''''''''''''TRANS KE KASIR'''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 'Simpan resep_jual
                sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "insert into resep_jual(no_nota, no_rm, no_reg, jenis_rawat, tgl_jual, waktu, kd_dokter, kd_sub_unit, status_bayar, kd_kelompok_pelanggan, metode_bayar, total, user_id, user_nama, waktu_in, waktu_out, kd_sub_unit_asal, total_bulat, total_non_paket, total_non_paket_bulat, total_tunai, total_tunai_bulat, total_piutang, total_piutang_bulat) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNoReg.Text) & "',  '" & StatusRawat & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss").ToString & "', '" & kdDokter & "', '" & pkdsubunit & "', 'BELUM', '0', 'KREDIT', '" & Num_En_US(txtGrandTotalPaket.DecimalValue) & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', '-', '" & kdSubUnit & "', '" & Num_En_US(txtGrandTotalPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalNonPaket.DecimalValue) & "', '" & Num_En_US(txtGrandTotalNonPaketBulat.DecimalValue) & "','0', '0', '" & Num_En_US(txtGrandTotalPaket.DecimalValue) & "', '" & Num_En_US(txtGrandTotalPaketBulat.DecimalValue) & "')"
                'CMD.ExecuteNonQuery()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' 'Simpan resep_jual_detail
                For i = 0 To gridDetailObatKh.RowCount - 2
                    If gridDetailObatKh.Rows(i).Cells("jmlp").Value > 0 Then
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "INSERT INTO resep_jual_detail(no_nota, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, nr, urutan, kd_sub_unit_asal, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("idx_barang").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("hrgbeli").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmlp").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalp").Value) & "', '0', '0', '0',  '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalp").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totalp").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("racik").Value) & "', " & i + 1 & ", '" & kdSubUnit & "', '0', '0', '" & Trim(gridDetailObatKh.Rows(i).Cells("rek_p").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nama_barang").Value)) & "', '0')"
                        'CMD.ExecuteNonQuery()
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                For i = 0 To gridDetailObatKh.RowCount - 2
                    If gridDetailObatKh.Rows(i).Cells("totaln").Value > 0 Then
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "INSERT INTO resep_jual_detail(no_nota, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, nr, urutan, kd_sub_unit_asal, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("idx_barang").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("hrgbeli").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jmln").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totaln").Value) & "', '0', '0', '0',  '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totaln").Value) & "', '" & Num_En_US(gridDetailObatKh.Rows(i).Cells("totaln").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("racik").Value) & "', " & i + 1 & ", '" & kdSubUnit & "', '0', '0', '" & Trim(gridDetailObatKh.Rows(i).Cells("rek_p").Value) & "', '" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObatKh.Rows(i).Cells("nama_barang").Value)) & "', '1')"
                    End If
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Update Stok
                If psts_stok = "1" Then
                    For i = 0 To gridDetailObatKh.RowCount - 2
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "UPDATE Barang_Farmasi SET " & memStok & "=(" & memStok & "-" & Num_En_US(gridDetailObatKh.Rows(i).Cells("jml").Value) & ") WHERE kd_barang='" & Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value) & "'"
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''''''''''''''''''''' UPDATE STATUS PELAYANAN OBAT JADI ''''''''''''''''''''''''''''''
                If BDPermintaanObatDetail.Count > 0 Then
                    BDPermintaanObatDetail.MoveFirst()
                    For i = 1 To BDPermintaanObatDetail.Count
                        Dim jumlahTerlayani As Decimal
                        DRWPermintaanObatDetail = BDPermintaanObatDetail.Current
                        If IsDBNull(DRWPermintaanObatDetail.Item("jumlah_terlayani")) Then
                            jumlahTerlayani = 0
                        Else
                            jumlahTerlayani = DRWPermintaanObatDetail.Item("jumlah_terlayani")
                        End If
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail 
                                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.status_terlayani= '" & Trim(DRWPermintaanObatDetail.Item("status_terlayani")) & "',
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Terlayani= " & Num_En_US(jumlahTerlayani) & ",
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_barang_terlayani= '" & Trim(DRWPermintaanObatDetail.Item("kd_barang_terlayani")) & "'
                                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.idx_Permintaan_Obat= '" & DRWPermintaanObatDetail.Item("idx_permintaan_obat") & "'"
                        BDPermintaanObatDetail.MoveNext()
                    Next
                End If

                '''''''''''''''''''''''''''''''' UPDATE STATUS PELAYANAN OBAT RACIKAN
                If BDPermintaanObatRacikDetail.Count > 0 Then
                    '  menempatkan data binding pada posisi pertama
                    BDPermintaanObatRacikDetail.MoveFirst()
                    'melakukan perhitungan data pada data binding
                    For i = 1 To BDPermintaanObatRacikDetail.Count
                        Dim jumlahRacikTerlayani As Decimal
                        'menempatkan data row view pada posisi databinding sekarang
                        DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current
                        If IsDBNull(DRWPermintaanObatRacikDetail.Item("jumlah_terlayani")) Then
                            jumlahRacikTerlayani = 0
                        Else
                            jumlahRacikTerlayani = DRWPermintaanObatRacikDetail.Item("jumlah_terlayani")
                        End If
                        sqlEditPenjualanObatKh = sqlEditPenjualanObatKh & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail 
                                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.status_terlayani= '" & Trim(DRWPermintaanObatRacikDetail.Item("status_terlayani")) & "',
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Terlayani= " & Num_En_US(jumlahRacikTerlayani) & ",
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_barang_terlayani= '" & Trim(DRWPermintaanObatRacikDetail.Item("kd_barang_terlayani")) & "'
                                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.idx_No_Racikan= '" & DRWPermintaanObatRacikDetail.Item("idx_no_racikan") & "'"
                        BDPermintaanObatRacikDetail.MoveNext()
                    Next
                End If

                CMD.CommandText = sqlEditPenjualanObatKh
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi penjualan berhasil diedit", vbInformation, "Informasi")
                btnSimpanKh.Enabled = False
                btnCetakBPJS.Enabled = True
                'btnCetakLain.Enabled = True
                btnCetakEtiketKh.Enabled = True
            Catch ex As Exception
                MsgBox(" Commit Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                Try
                    Trans.Rollback()
                Catch ex2 As Exception
                    MsgBox(" Rollback Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                    MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                End Try
            End Try
        End If
    End Sub

    Private Sub cmbEtiketKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbEtiketKh.KeyPress
        If e.KeyChar = Chr(13) Then
            If cmbEtiketKh.Text = "Y" Or cmbEtiketKh.Text = "y" Or cmbEtiketKh.Text = "N" Or cmbEtiketKh.Text = "n" Then
                If cmbEtiketKh.Text = "N" Then
                    PanelEtiket.Visible = False
                    PanelEtiketModel4.Visible = False
                    SendKeys.Send("{TAB}")
                Else
                    If pkdapo = "002" Then
                        PanelEtiketModel4.Visible = True
                        modelEtiket = "4"
                        txtNamaObatEtiketModel4.Focus()
                    Else
                        PanelEtiket.Visible = True
                        txtNamaObatEtiket.Text = lblNamaObatKh.Text
                        txtJumlahObatEtiket.DecimalValue = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
                        txtNamaObatEtiket.Focus()
                    End If
                End If
            Else
                MsgBox("Pilih yang benar", vbCritical, "Kesalahan")
                Exit Sub
            End If
        End If
    End Sub

    Sub addBarangKh()
        cariNamaPenjamin()
        cariDokter()
        carikdEtiketTakaran()
        carikdEtiketWaktu()
        carikdEtiketKeterangan()
        carikdEtiketKeteranganModel3()

        BDPenjualanResepKh.DataSource = DSPenjualanResepKh
        BDPenjualanResepKh.DataMember = "PenjualanResepKh"

        BDPenjualanResepKh.AddNew()
        DRWPenjualanResepKh = BDPenjualanResepKh.Current
        DRWPenjualanResepKh("stsrawat") = StatusRawat
        DRWPenjualanResepKh("kdkasir") = Trim(FormLogin.LabelKode.Text)
        DRWPenjualanResepKh("nmkasir") = Trim(FormLogin.LabelNama.Text)
        DRWPenjualanResepKh("tanggal") = DTPTanggalTrans.Value
        DRWPenjualanResepKh("notaresep") = Trim(txtNoResep.Text)
        DRWPenjualanResepKh("no_reg") = Trim(txtNoReg.Text)
        DRWPenjualanResepKh("no_rm") = Trim(txtRM.Text)
        DRWPenjualanResepKh("nmpasien") = Trim(txtNamaPasien.Text)
        DRWPenjualanResepKh("umurthn") = txtUmurThn.Text
        DRWPenjualanResepKh("umurbln") = txtUmurBln.Text
        DRWPenjualanResepKh("kd_penjamin") = KdPenjamin
        DRWPenjualanResepKh("nm_penjamin") = NamaPenjamin
        DRWPenjualanResepKh("kddokter") = kdDokter
        DRWPenjualanResepKh("nmdokter") = NamaDokter
        DRWPenjualanResepKh("nonota") = Trim(txtNota.Text)
        DRWPenjualanResepKh("urut") = txtNoUrut.Text
        DRWPenjualanResepKh("kd_barang") = Trim(txtKodeObatKh.Text)
        DRWPenjualanResepKh("idx_barang") = Trim(txtIdObatKh.Text)
        DRWPenjualanResepKh("nama_barang") = Trim(lblNamaObatKh.Text)
        DRWPenjualanResepKh("kd_jns_obat") = KdJenisObat
        DRWPenjualanResepKh("kd_gol_obat") = kdGolonganObat
        DRWPenjualanResepKh("kd_kel_obat") = kdKelompokObat
        DRWPenjualanResepKh("kdpabrik") = kdPabrik
        DRWPenjualanResepKh("generik") = Generik
        DRWPenjualanResepKh("formularium") = "FORMULARIUM"
        DRWPenjualanResepKh("racik") = Trim(cmbRacikNonKh.Text)
        DRWPenjualanResepKh("harga") = txtHargaJualKh.DecimalValue
        DRWPenjualanResepKh("jmlp") = txtPaketBPJSKh.DecimalValue
        DRWPenjualanResepKh("totalp") = txtTotalPaketBPJSKh.DecimalValue
        DRWPenjualanResepKh("jmln") = txtPaketLainKh.DecimalValue
        DRWPenjualanResepKh("totaln") = txtTotalPaketLainKh.DecimalValue
        DRWPenjualanResepKh("jml") = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
        DRWPenjualanResepKh("nmsatuan") = Trim(txtSatPaketBPJSKh.Text)
        DRWPenjualanResepKh("totalharga") = txtTotalPaketBPJSKh.DecimalValue + txtTotalPaketLainKh.DecimalValue
        DRWPenjualanResepKh("senpot") = 0
        DRWPenjualanResepKh("potongan") = 0
        DRWPenjualanResepKh("jmlnet") = txtPaketBPJSKh.DecimalValue
        DRWPenjualanResepKh("dijamin") = txtTotalPaketBPJSKh.DecimalValue
        DRWPenjualanResepKh("sisabayar") = 0
        DRWPenjualanResepKh("hrgbeli") = HargaBeli
        DRWPenjualanResepKh("jamawal") = Format(DTPJamAwal.Value, "HH:mm:ss")
        DRWPenjualanResepKh("kdbagian") = pkdapo
        DRWPenjualanResepKh("stsresep") = "PKTKHUSUS"
        DRWPenjualanResepKh("rek_p") = kDRekening
        DRWPenjualanResepKh("stsetiket") = cmbEtiketKh.Text
        DRWPenjualanResepKh("qty1") = txtSigna1.Text
        DRWPenjualanResepKh("qty2") = txtSigna2.Text
        DRWPenjualanResepKh("qty3") = txtQty3.DecimalValue
        DRWPenjualanResepKh("jmlhari") = 0
        DRWPenjualanResepKh("takaran") = kdTakaran
        DRWPenjualanResepKh("waktu") = kdWaktu
        If modelEtiket = "1" Then
            DRWPenjualanResepKh("ketminum") = kdKeterangan
            DRWPenjualanResepKh("nmobat_etiket") = txtNamaObatEtiket.Text
            DRWPenjualanResepKh("jmlobat_etiket") = txtJumlahObatEtiket.DecimalValue
        ElseIf modelEtiket = "3" Then
            DRWPenjualanResepKh("ketminum") = kdKeteranganModel3
            DRWPenjualanResepKh("nmobat_etiket") = txtNamaObatEtiketModel3.Text
            DRWPenjualanResepKh("jmlobat_etiket") = txtJumlahObatEtiketModel3.DecimalValue
            DRWPenjualanResepKh("ketminum_s") = nmKeteranganModel3
        ElseIf modelEtiket = "4" Then
            DRWPenjualanResepKh("nmobat_etiket") = txtNamaObatEtiketModel4.Text
        End If
        DRWPenjualanResepKh("posting") = "1"
        DRWPenjualanResepKh("diserahkan") = "B"
        DRWPenjualanResepKh("jns_obat") = JenisObat
        DRWPenjualanResepKh("jmljatah") = txtJmlHariKh.IntegerValue
        DRWPenjualanResepKh("tglakhir") = DTPTglAkhirKh.Value
        DRWPenjualanResepKh("jml_awal") = 0

        DRWPenjualanResepKh("tgl_exp") = DTPTanggalExp.Value

        DRWPenjualanResepKh("model_etiket") = modelEtiket
        DRWPenjualanResepKh("nmobat_etiket_infus") = txtNamaObatEtiketInfus.Text
        DRWPenjualanResepKh("jmlobat_etiket_infus") = txtJumlahObatEtiketInfus.DecimalValue
        DRWPenjualanResepKh("obat_infus") = txtObatInfus.Text
        DRWPenjualanResepKh("tetes_infus") = txtTetesInfus.Text

        'If cbPagi.Checked = True Then
        '    DRWPenjualanResepKh("ket_waktu_pagi_model4") = "2"
        'Else
        '    DRWPenjualanResepKh("ket_waktu_pagi_model4") = "1"
        'End If
        'If cbSiang.Checked = True Then
        '    DRWPenjualanResepKh("ket_waktu_siang_model4") = "2"
        'Else
        '    DRWPenjualanResepKh("ket_waktu_siang_model4") = "1"
        'End If
        'If cbMalam.Checked = True Then
        '    DRWPenjualanResepKh("ket_waktu_malam_model4") = "2"
        'Else
        '    DRWPenjualanResepKh("ket_waktu_malam_model4") = "1"
        'End If
        'If cbSore.Checked = True Then
        '    DRWPenjualanResepKh("ket_waktu_sore_model4") = "2"
        'Else
        '    DRWPenjualanResepKh("ket_waktu_sore_model4") = "1"
        'End If
        'If rSebelum.Checked = True Then
        '    DRWPenjualanResepKh("ket_minum_model4") = "1"
        'ElseIf rBersama.Checked = True Then
        '    DRWPenjualanResepKh("ket_minum_model4") = "2"
        'ElseIf rSesudah.Checked = True Then
        '    DRWPenjualanResepKh("ket_minum_model4") = "3"
        'End If

        BDPenjualanResepKh.EndEdit()

        gridDetailObatKh.DataSource = Nothing
        gridDetailObatKh.DataSource = BDPenjualanResepKh

        TotalPaket()
        TotalNonPaket()
    End Sub

    Private Sub btnAddKh_Click(sender As Object, e As EventArgs) Handles btnAddKh.Click
        If txtNoReg.Text = "" Then
            MsgBox("Pilih pasien terlebih dahulu")
            Exit Sub
        End If
        If txtKodeObatKh.Text = "" Then
            MsgBox("Obat belum dipilih")
            Exit Sub
        End If
        If txtJmlObatKh.DecimalValue <= 0 Then
            MsgBox("Jumlah belum diisi")
            txtPaketBPJSKh.Focus()
        Else
            PanelEtiketModel4.Visible = False
            ' status obat jadi atau obat racik
            If idx_permintaan_obat <> Nothing Then
                If jenisPelayanan = "obat-jadi" Then
                    addStatusObatJadiTerlayani(idx_permintaan_obat, kd_barang_permintaan, txtJmlObatKh.DecimalValue, txtKodeObatKh.Text, nama_barang)
                Else
                    addStatusObatRacikTerlayani(idx_permintaan_obat, kd_barang_permintaan, txtJmlObatKh.DecimalValue, txtKodeObatKh.Text, nama_barang)
                End If
            End If
            'addPelayananObat()
            addBarangKh()
            AturGriddetailBarangKh()
            NoUrut()
            KosongkanDetailPaketKhusus()
            txtQtyKh.DecimalValue = gridDetailObatKh.Rows.Count() - 1
            idx_permintaan_obat = Nothing
            cmbRacikNonKh.Focus()
            RefreshGridObatJadi()
            RefreshGridObatRacikan()
            btnSimpanKh.Enabled = True
        End If
    End Sub

    Sub NoResep()
        Try
            CMD = New OleDb.OleDbCommand("select max(notaresep) as notaresep from ap_jualr1 where tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and kdbagian='" & pkdapo & "' and stsrawat='" & StatusRawat & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If IsDBNull(DT.Rows(0).Item("notaresep")) Then
                txtNoResep.Text = StatusRawat + Format(DTPTanggalTrans.Value, "ddMMyy") + pkdnota + "001"
            Else
                txtNoResep.Text = Microsoft.VisualBasic.Right(DT.Rows(0).Item("notaresep").ToString, 3) + 1
                If Len(txtNoResep.Text) = 1 Then
                    txtNoResep.Text = StatusRawat + Format(DTPTanggalTrans.Value, "ddMMyy") + pkdnota + "00" & txtNoResep.Text & ""
                ElseIf Len(txtNoResep.Text) = 2 Then
                    txtNoResep.Text = StatusRawat + Format(DTPTanggalTrans.Value, "ddMMyy") + pkdnota + "0" & txtNoResep.Text & ""
                ElseIf Len(txtNoResep.Text) = 3 Then
                    txtNoResep.Text = StatusRawat + Format(DTPTanggalTrans.Value, "ddMMyy") + pkdnota + "" & txtNoResep.Text & ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtJmlBungkus_TextChanged(sender As Object, e As EventArgs) Handles txtJmlBungkus.TextChanged
        If txtJmlBungkus.DecimalValue <> 0 Then
            If txtDosis.DecimalValue = 0 Then
                MsgBox("Jumlah Dosis masih 0 silahkan di isi!!", vbInformation)
                txtDosis.Focus()
                Exit Sub
            End If
            totalJualResep()
        End If
    End Sub

    Sub NoUrut()
        If BDPenjualanResep.Count > 0 Then
            txtNoUrut.Text = Val(txtNoUrut.Text) + 1
        Else
            txtNoUrut.Text = "1"
        End If
    End Sub

    Private Sub btnBaruKh_Click(sender As Object, e As EventArgs) Handles btnBaruKh.Click
        KosongkanHeader()
        KosongkanDetailPaketUmum()
        DTPTanggalTrans.Focus()
    End Sub

    Private Sub btnKeluarKh_Click(sender As Object, e As EventArgs) Handles btnKeluarKh.Click
        Dispose()
    End Sub

    Private Sub btnHapusNotaKh_Click(sender As Object, e As EventArgs) Handles btnHapusNotaKh.Click
        If MessageBox.Show("Yakin transaksi ini akan dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If Posting = "2" Then
                MsgBox("Transaksi tidak bisa diedit, sudah diposting oleh kasir", vbInformation, "Informasi")
                Exit Sub
            End If
            cariSubUnitAsal()
            If pkdapo = "001" Then
                memStok = "stok001"
            ElseIf pkdapo = "002" Then
                memStok = "stok002"
            ElseIf pkdapo = "003" Then
                memStok = "stok003"
            ElseIf pkdapo = "004" Then
                memStok = "stok004"
            ElseIf pkdapo = "005" Then
                memStok = "stok005"
            ElseIf pkdapo = "006" Then
                memStok = "stok006"
            ElseIf pkdapo = "007" Then
                memStok = "stok007"
            Else
                MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
            End If

            Dim sqlHapusPenjualanObatKh As String = ""
            'CONN.Open()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS APOTEK'''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr1
                sqlHapusPenjualanObatKh = "Delete from ap_jualr1 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr2
                sqlHapusPenjualanObatKh = sqlHapusPenjualanObatKh & vbCrLf & "Delete from ap_jualr2 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr2_bpjs
                sqlHapusPenjualanObatKh = sqlHapusPenjualanObatKh & vbCrLf & "Delete from ap_jualr2_bpjs WHERE tglresep='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus etiket
                sqlHapusPenjualanObatKh = sqlHapusPenjualanObatKh & vbCrLf & "Delete from ap_etiketNew WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS KASIR'''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual
                sqlHapusPenjualanObatKh = sqlHapusPenjualanObatKh & vbCrLf & "Delete from resep_jual WHERE no_nota='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual_detail
                sqlHapusPenjualanObatKh = sqlHapusPenjualanObatKh & vbCrLf & "Delete from resep_jual_detail WHERE no_nota='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''Stok Kembali Asal'''''''''''''''''''''''''''''''''''''''''''''

                If psts_stok = "1" Then
                    For i = 0 To gridStokKembali.RowCount - 2
                        sqlHapusPenjualanObatKh = sqlHapusPenjualanObatKh & vbCrLf & "UPDATE Barang_Farmasi SET " & memStok & "=(" & memStok & "+" & Num_En_US(gridStokKembali.Rows(i).Cells("jml").Value) & ") WHERE kd_barang='" & Trim(gridStokKembali.Rows(i).Cells("kd_barang").Value) & "'"
                        'CMD.ExecuteNonQuery()
                    Next
                End If


                sqlHapusPenjualanObatKh = sqlHapusPenjualanObatKh & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat
                                        Set DBSIMRM.dbo.RJ_Permintaan_Obat.status= 0,
                                        DBSIMRM.dbo.RJ_Permintaan_Obat.notaresep= ' '
                                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "'"

                ''''''''''''''''''''''''''''''''' UPDATE STATUS OBAT JADI TERLAYANI
                If BDPermintaanObatDetail.Count > 0 Then
                    BDPermintaanObatDetail.MoveFirst()
                    For i = 1 To BDPermintaanObatDetail.Count
                        DRWPermintaanObatDetail = BDPermintaanObatDetail.Current
                        sqlHapusPenjualanObatKh = sqlHapusPenjualanObatKh & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail 
                                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.status_terlayani= 0,
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Terlayani= 0,
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_barang_terlayani= ' '
                                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.idx_Permintaan_Obat= '" & DRWPermintaanObatDetail.Item("idx_permintaan_obat") & "'"
                        BDPermintaanObatDetail.MoveNext()
                    Next
                End If

                '''''''''''''''''''''''''''''''' UPDATE STATUS PELAYANAN OBAT RACIKAN
                If BDPermintaanObatRacikDetail.Count > 0 Then
                    BDPermintaanObatRacikDetail.MoveFirst()
                    For i = 1 To BDPermintaanObatRacikDetail.Count
                        DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current
                        sqlHapusPenjualanObatKh = sqlHapusPenjualanObatKh & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail 
                                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.status_terlayani= 0,
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Terlayani= 0, 
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_barang_terlayani= ' '
                                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.idx_No_Racikan= '" & DRWPermintaanObatRacikDetail.Item("idx_no_racikan") & "'"
                        BDPermintaanObatRacikDetail.MoveNext()
                    Next
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CMD.CommandText = sqlHapusPenjualanObatKh
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi penjualan berhasil dihapus", vbInformation, "Informasi")
                KosongkanHeader()
                KosongkanDetailPaketKhusus()
                KosongkanDetailPaketUmum()
            Catch ex As Exception
                MsgBox(" Commit Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                Try
                    Trans.Rollback()
                Catch ex2 As Exception
                    MsgBox(" Rollback Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                    MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                End Try
            End Try
        End If
    End Sub

    Private Sub btnCetakEtiketKh_Click(sender As Object, e As EventArgs) Handles btnCetakEtiketKh.Click
        If MessageBox.Show("Apakah akan cetak etiket ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If pkdapo = "002" Or pkdapo = "005" Then
                Try
                    Dim BDEtiket As New BindingSource
                    Dim DRWEtiket As DataRowView
                    DA = New OleDb.OleDbDataAdapter("SELECT * FROM ap_etiketNew where notaresep='" & Trim(txtNoResep.Text) & "' and tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "'", CONN)
                    DS = New DataSet
                    DA.Fill(DS, "cetakEtiket")
                    BDEtiket.DataSource = DS
                    BDEtiket.DataMember = "cetakEtiket"
                    If BDEtiket.Count > 0 Then
                        BDEtiket.MoveFirst()
                        For i = 1 To BDEtiket.Count
                            DRWEtiket = BDEtiket.Current
                            If DRWEtiket.Item("model") = "2" Then
                                For a = 1 To DRWEtiket.Item("jml_obat")
                                    Dim rpt As New ReportDocument
                                    Try
                                        Dim str As String = Application.StartupPath & "\Report\etiketInfus.rpt"
                                        rpt.Load(str)
                                        'FormCetak.CrystalReportViewer1.Refresh()
                                        rpt.SetDatabaseLogon(dbUser, dbPassword)
                                        rpt.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
                                        rpt.SetParameterValue("notaresep", Trim(txtNoResep.Text))
                                        rpt.SetParameterValue("kdbarang", Trim(DRWEtiket.Item("kd_barang")))
                                        rpt.SetParameterValue("urut", DRWEtiket.Item("urut"))
                                        rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                                        rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                                        rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
                                        rpt.SetParameterValue("user", Trim(FormLogin.LabelNama.Text))
                                        rpt.SetParameterValue("ruang", Trim(nmSubUnit))
                                        rpt.SetParameterValue("kamar", lblKamarBed.Text)
                                        rpt.PrintToPrinter(1, False, 0, 0)
                                        rpt.Close()
                                        rpt.Dispose()
                                        'FormCetak.CrystalReportViewer1.ReportSource = rpt
                                        'FormCetak.CrystalReportViewer1.Show()
                                        'FormCetak.ShowDialog()
                                    Catch ex As Exception
                                        MsgBox(ex.Message)
                                    End Try
                                Next
                            Else
                                Dim rpt As New ReportDocument
                                Try
                                    Dim str As String = Application.StartupPath & "\Report\etiket.rpt"
                                    rpt.Load(str)
                                    'FormCetak.CrystalReportViewer1.Refresh()
                                    rpt.SetDatabaseLogon(dbUser, dbPassword)
                                    rpt.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
                                    rpt.SetParameterValue("notaresep", Trim(txtNoResep.Text))
                                    rpt.SetParameterValue("kdbarang", Trim(DRWEtiket.Item("kd_barang")))
                                    rpt.SetParameterValue("urut", DRWEtiket.Item("urut"))
                                    rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                                    rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                                    rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
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
                            BDEtiket.MoveNext()
                        Next
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                For i = 0 To gridDetailObatKh.RowCount - 2
                    If gridDetailObatKh.Rows(i).Cells("stsetiket").Value = "Y" Then
                        Dim rpt As New ReportDocument
                        Try
                            Dim str As String = Application.StartupPath & "\Report\etiket.rpt"
                            rpt.Load(str)
                            'FormCetak.CrystalReportViewer1.Refresh()
                            rpt.SetDatabaseLogon(dbUser, dbPassword)
                            rpt.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
                            rpt.SetParameterValue("notaresep", Trim(txtNoResep.Text))
                            rpt.SetParameterValue("kdbarang", Trim(gridDetailObatKh.Rows(i).Cells("kd_barang").Value))
                            rpt.SetParameterValue("urut", (i + 1))
                            rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                            rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                            rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
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
                Next
            End If
            btnCetakEtiketKh.Enabled = False
        End If
    End Sub

    Sub totalJualResepKhusus()
        Dim HitungJumlah As Decimal = 0
        HitungJumlah = (txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue)
        txtJmlObatKh.DecimalValue = HitungJumlah
    End Sub

    Private Sub txtPaketBPJSKh_TextChanged(sender As Object, e As EventArgs) Handles txtPaketBPJSKh.TextChanged
        txtTotalPaketBPJSKh.DecimalValue = txtPaketBPJSKh.DecimalValue * txtHargaJualKh.DecimalValue
        totalJualResepKhusus()
    End Sub

    Private Sub txtPaketLainKh_TextChanged(sender As Object, e As EventArgs) Handles txtPaketLainKh.TextChanged
        txtTotalPaketLainKh.DecimalValue = txtPaketLainKh.DecimalValue * txtHargaJualKh.DecimalValue
        totalJualResepKhusus()
    End Sub

    Private Sub btnInfoResepKh_Click(sender As Object, e As EventArgs) Handles btnInfoResepKh.Click
        FormPemanggil = "FormEditPenjualanResepEMR"
        If txtNoReg.Text = "" Then
            MsgBox("Pilih pasien terlebih dahulu")
            txtNoReg.Focus()
        Else
            FormInfoResepObat.ShowDialog()
        End If
    End Sub

    Sub totalJualResepKhususRacikan()
        Dim HitungJumlah As Decimal = 0
        Dim PaketBpjs As Decimal = 0
        Dim PaketLain As Decimal = 0

        HitungJumlah = (txtDosisResepKh.DecimalValue * (txtJmlCapBPJSKh.DecimalValue + txtJmlCapLainKh.DecimalValue)) / txtDosisKh.DecimalValue
        txtJmlObatKh.DecimalValue = HitungJumlah
        PaketBpjs = (txtJmlCapBPJSKh.DecimalValue * txtJmlObatKh.DecimalValue) / (txtJmlCapBPJSKh.DecimalValue + txtJmlCapLainKh.DecimalValue)
        PaketLain = (txtJmlCapLainKh.DecimalValue * txtJmlObatKh.DecimalValue) / (txtJmlCapBPJSKh.DecimalValue + txtJmlCapLainKh.DecimalValue)
        txtPaketBPJSKh.DecimalValue = PaketBpjs
        txtPaketLainKh.DecimalValue = PaketLain
    End Sub

    Private Sub txtJmlCapBPJSKh_TextChanged(sender As Object, e As EventArgs) Handles txtJmlCapBPJSKh.TextChanged
        If txtJmlCapBPJSKh.DecimalValue <> 0 Then
            If txtDosisKh.DecimalValue = 0 Then
                MsgBox("Jumlah Dosis Farmasi 0 silahkan di isi!!!", vbInformation)
                txtDosisKh.Focus()
                Exit Sub
            End If
            txtPaketBPJSKh.DecimalValue = txtJmlCapBPJSKh.DecimalValue
            totalJualResepKhususRacikan()
        End If
    End Sub

    Private Sub cmbEtiketKh_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEtiketKh.KeyDown
        If e.KeyCode = Keys.Left Then
            txtJmlHariKh.Focus()
        End If
    End Sub

    Private Sub txtJmlCapLainKh_TextChanged(sender As Object, e As EventArgs) Handles txtJmlCapLainKh.TextChanged
        If txtJmlCapLainKh.DecimalValue <> 0 Then
            If txtDosisKh.DecimalValue = 0 Then
                MsgBox("Jumlah Dosis Farmasi 0 silahkan di isi!!!", vbInformation)
                txtDosisKh.Focus()
                Exit Sub
            End If
            txtPaketLainKh.DecimalValue = txtJmlCapLainKh.DecimalValue
            totalJualResepKhususRacikan()
        End If
    End Sub

    Private Sub txtJmlObatKh_TextChanged(sender As Object, e As EventArgs) Handles txtJmlObatKh.TextChanged

    End Sub

    Private Sub txtDosisKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDosisKh.KeyPress
        If e.KeyChar = Chr(13) Then
            txtDosisResepKh.Focus()
        End If
    End Sub

    Private Sub cmbEtiket_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEtiket.SelectedIndexChanged
        If cmbEtiket.Text = "Y" Then
            PanelEtiket.Visible = True
            txtNamaObatEtiket.Text = lblNamaObat.Text
            txtNamaObatEtiketInfus.Text = lblNamaObat.Text
            txtNamaObatEtiketModel3.Text = lblNamaObat.Text
            txtNamaObatEtiketModel4.Text = lblNamaObat.Text
            txtJumlahObatEtiket.DecimalValue = txtJumlahJual.DecimalValue
            txtJumlahObatEtiketInfus.DecimalValue = txtJumlahJual.DecimalValue
            txtJumlahObatEtiketModel3.DecimalValue = txtJumlahJual.DecimalValue
            txtNamaObatEtiket.Focus()
        Else
            PanelEtiket.Visible = False
            PanelEtiketInfus.Visible = False
            PanelEtiketModel3.Visible = False
        End If
    End Sub

    Private Sub cmbEtiketKh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbEtiketKh.SelectedIndexChanged
        If cmbEtiketKh.Text = "N" Then
            PanelEtiket.Visible = False
            PanelEtiketInfus.Visible = False
            PanelEtiketModel3.Visible = False
            PanelEtiketModel4.Visible = False
        Else
            PanelEtiket.Visible = True
            txtNamaObatEtiket.Text = lblNamaObatKh.Text
            txtNamaObatEtiketInfus.Text = lblNamaObatKh.Text
            txtNamaObatEtiketModel3.Text = lblNamaObatKh.Text
            txtNamaObatEtiketModel4.Text = lblNamaObatKh.Text
            txtJumlahObatEtiket.DecimalValue = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
            txtJumlahObatEtiketInfus.DecimalValue = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
            txtJumlahObatEtiketModel3.DecimalValue = txtPaketBPJSKh.DecimalValue + txtPaketLainKh.DecimalValue
            txtNamaObatEtiket.Focus()
        End If
    End Sub

    Sub CariLaba()
        CMD = New OleDb.OleDbCommand("select laba,ppn from ap_labafarmasi where kode='rj'", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            txtLaba.DecimalValue = DT.Rows(0).Item("laba")
            txtPPN.DecimalValue = DT.Rows(0).Item("ppn")
        Else
            MsgBox("Setting Laba belum benar", vbInformation, "Informasi")
            Return
        End If
    End Sub

    Sub ListDokter()
        CMD = New OleDb.OleDbCommand("select kd_pegawai,nama_pegawai,gelar_depan from pegawai where kd_jns_pegawai=1 order by nama_pegawai", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbDokter.Items.Clear()
        cmbDokter.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbDokter.Items.Add(DT.Rows(i)("nama_pegawai") & "|" & DT.Rows(i)("kd_pegawai"))
        Next
        cmbDokter.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbDokter.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListEtiketTakaran()
        CMD = New OleDb.OleDbCommand("select * from ap_etiket_takaran order by noid", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbTakaran.Items.Clear()
        cmbTakaran.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbTakaran.Items.Add(DT.Rows(i)("takaran") & "|" & DT.Rows(i)("noid"))
        Next
        cmbTakaran.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbTakaran.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListEtiketWaktu()
        CMD = New OleDb.OleDbCommand("select * from ap_etiket_waktu order by noid", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbWaktu.Items.Clear()
        cmbWaktu.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbWaktu.Items.Add(DT.Rows(i)("waktu") & "|" & DT.Rows(i)("noid"))
        Next
        cmbWaktu.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbWaktu.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Sub ListEtiketKeterangan()
        CMD = New OleDb.OleDbCommand("select * from ap_etiket_ketminum order by noid", CONN)
        DA = New OleDb.OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        cmbKeterangan.Items.Clear()
        cmbKeterangan.Items.Add("")
        cmbKeteranganModel3.Items.Clear()
        cmbKeteranganModel3.Items.Add("")
        For i As Integer = 0 To DT.Rows.Count - 1
            cmbKeterangan.Items.Add(DT.Rows(i)("ketminum") & "|" & DT.Rows(i)("noid"))
            cmbKeteranganModel3.Items.Add(DT.Rows(i)("ketminum") & "|" & DT.Rows(i)("noid"))
        Next
        cmbKeterangan.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKeterangan.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        cmbKeteranganModel3.AutoCompleteSource = AutoCompleteSource.ListItems
        cmbKeteranganModel3.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    End Sub

    Private Sub FormEditPenjulanResepEMR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Me.KeyPreview = True
        FormPemanggil = "FormEditPenjualanResepEMR"
        cmbJenisRawat.SelectedIndex = 0
        ListDokter()
        ListEtiketTakaran()
        ListEtiketWaktu()
        ListEtiketKeterangan()
        KosongkanHeader()
        KosongkanDetailPaketUmum()
        KosongkanDetailPaketKhusus()
        cmbJenisRawat.Focus()
    End Sub

    Private Sub txtNoResep_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoResep.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoReg.Focus()
        End If
    End Sub

    Private Sub FormEditPenjulanResepEMR_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        'PanelPasien.Location = New Point(86, 79)
        PanelPasien.Location = New Point(86, 79)
        PanelObat.Location = New Point(407, 336)
        PanelEtiket.Location = New Point(900, 403)
        PanelEtiketInfus.Location = New Point(900, 403)
        PanelEtiketModel3.Location = New Point(900, 403)
        PanelEtiketModel4.Location = New Point(900, 403)
    End Sub

    Private Sub cmbJenisRawat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbJenisRawat.SelectedIndexChanged
        If cmbJenisRawat.SelectedIndex = 0 Then
            StatusRawat = "RJ"
            JenisRawat = "1"
            cmbPkt.SelectedIndex = 0
            cmbPkt.Enabled = True
        ElseIf cmbJenisRawat.SelectedIndex = 1 Then
            StatusRawat = "RI"
            JenisRawat = "2"
            cmbPkt.SelectedIndex = 0
            cmbPkt.Enabled = False
        ElseIf cmbJenisRawat.SelectedIndex = 2 Then
            StatusRawat = "RD"
            JenisRawat = "3"
            cmbPkt.SelectedIndex = 0
            cmbPkt.Enabled = True
        Else
            MsgBox("Coba Lagi")
        End If
        DTPTanggalTrans.Focus()
    End Sub

    Private Sub txtKodeObat_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObat.GotFocus
        If stok0 = "1" Then
            tampilBarangSemua()
        Else
            tampilBarang()
        End If

        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        KosongkanHeader()
        KosongkanDetailPaketUmum()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If Posting = "2" Then
            MsgBox("Transaksi tidak bisa diedit, sudah diposting oleh kasir", vbInformation, "Informasi")
            Exit Sub
        End If
        cariDokter()
        cariSubUnitAsal()
        cariNamaPenjamin()
        If pkdapo = "001" Then
            memStok = "stok001"
        ElseIf pkdapo = "002" Then
            memStok = "stok002"
        ElseIf pkdapo = "003" Then
            memStok = "stok003"
        ElseIf pkdapo = "004" Then
            memStok = "stok004"
        ElseIf pkdapo = "005" Then
            memStok = "stok005"
        ElseIf pkdapo = "006" Then
            memStok = "stok006"
        ElseIf pkdapo = "007" Then
            memStok = "stok007"
        Else
            MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
        End If

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Cek Stok
        If CekKunciStokPenjualan = "Y" Then
            For i = 0 To gridDetailObat.RowCount - 2
                CMD = New OleDb.OleDbCommand("select idx_barang,kd_barang,nama_barang, " & memStok & " as stok, kd_satuan_kecil from Barang_Farmasi where idx_barang='" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "'", CONN)
                DA = New OleDb.OleDbDataAdapter(CMD)
                DT = New DataTable
                DA.Fill(DT)
                If DT.Rows.Count > 0 Then
                    If (DT.Rows(0).Item("stok") + gridDetailObat.Rows(i).Cells("jml_awal").Value) < gridDetailObat.Rows(i).Cells("jml").Value Then
                        MsgBox("Stok " + Trim(DT.Rows(0).Item("nama_barang")) + " hanya " + (DT.Rows(0).Item("stok") + gridDetailObat.Rows(i).Cells("jml_awal").Value).ToString + " masukan ulang jumlah barang", vbInformation, "Informasi")
                        Exit Sub
                    End If
                End If
            Next
        End If

        If MessageBox.Show("Data Penjualan sudah benar ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Dim sqlEditPenjualanObat As String = ""
            TglServer()
            DTPJamAkhir.Value = TanggalServer
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS APOTEK'''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr1
                sqlEditPenjualanObat = "Delete from ap_jualr1 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr2
                sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "Delete from ap_jualr2 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr2_bpjs
                sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "Delete from ap_jualr2_bpjs WHERE tglresep='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_etiketNew
                sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "Delete from ap_etiketNew WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS KASIR'''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual
                sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "Delete from resep_jual WHERE no_nota='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual_detail
                sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "Delete from resep_jual_detail WHERE no_nota='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''''''''Stok Kembali Asal'''''''''''''''''''''''''''''''''''''''''''''
                If psts_stok = "1" Then
                    For i = 0 To gridStokKembali.RowCount - 2
                        sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "UPDATE Barang_Farmasi SET " & memStok & "=(" & memStok & "+" & Num_En_US(gridStokKembali.Rows(i).Cells("jml").Value) & ") WHERE kd_barang='" & Trim(gridStokKembali.Rows(i).Cells("kd_barang").Value) & "'"
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''''''''TRANS KE APOTEK''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Simpan ap_jualr1
                sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "insert into ap_jualr1 (stsrawat, kdkasir, 
                                    nmkasir, tanggal, notaresep, no_reg, no_rm, nama_pasien, kd_penjamin, nm_penjamin, 
                                    kddokter, nmdokter, kdbagian, stsresep, totalpaket, totalpaket_bulat, totalnonpaket, 
                                    totalnonpaket_bulat, totaldijamin, totaldijamin_bulat, totalselisih_bayar, 
                                    totalselisih_bayar_bulat, kd_sub_unit, kd_sub_unit_asal, nama_sub_unit, jam, 
                                    rsp_pulang, posting, diserahkan, no_permintaan_obat) 
                                    values ('" & StatusRawat & "', '" & Trim(FormLogin.LabelKode.Text) & "', 
                                    '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', 
                                    '" & Trim(txtNoResep.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "', 
                                    '" & Trim(txtNamaPasien.Text) & "', '" & Trim(KdPenjamin) & "', '" & Trim(NamaPenjamin) & "', 
                                    '" & Trim(kdDokter) & "', '" & Trim(NamaDokter) & "', '" & pkdapo & "', 'PKTUMUM', 
                                    '" & Num_En_US(txtGrandTotal.DecimalValue) & "', '" & Num_En_US(txtGrandTotalBulat.DecimalValue) & "', 
                                    '0', '0', '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "', 
                                    '" & Num_En_US(txtGrandIurBayar.DecimalValue) & "', '" & Num_En_US(txtGrandIurBayarBulat.DecimalValue) & "', 
                                    '" & kdSubUnit & "', '" & kdSubUnit & "', '" & nmSubUnit & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', 'N', 
                                    '1', 'B','" & noPermintaanObat & "')"
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Simpan ap_jualr2
                For i = 0 To gridDetailObat.RowCount - 2
                    sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "INSERT INTO ap_jualr2(stsrawat, kdkasir, nmkasir, tanggal, notaresep, no_reg, no_rm, nmpasien, umurthn, umurbln, kd_penjamin, nm_penjamin, kddokter, nmdokter, nonota, urut, kd_barang, idx_barang, nama_barang, kd_jns_obat, kd_gol_obat, kd_kel_obat, kdpabrik, generik, formularium, racik, harga, jmlpaket, totalpaket, jmlnonpaket, totalnonpaket, jml, nmsatuan, totalharga, senpot, potongan, jmlnet, dijamin, sisabayar, hrgbeli, jamawal, kdbagian, stsresep, rek_p, stsetiket, jmlhari, posting, diserahkan, jam, rsp_pulang, jns_obat, jmljatah, tglakhir)  VALUES ('" & StatusRawat & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtNoReg.Text) & "', '" & Trim(txtRM.Text) & "','" & Trim(txtNamaPasien.Text) & "','" & Trim(txtUmurThn.Text) & "', '" & Trim(txtUmurBln.Text) & "', '" & KdPenjamin & "', '" & NamaPenjamin & "', '" & kdDokter & "', '" & NamaDokter & "', '" & Trim(txtNota.Text) & "', " & i + 1 & ", '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("idx_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nama_barang").Value)) & "','" & Trim(gridDetailObat.Rows(i).Cells("kd_jns_obat").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_gol_obat").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_kel_obat").Value) & "','" & Trim(gridDetailObat.Rows(i).Cells("kdpabrik").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("generik").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("formularium").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("racik").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalharga").Value) & "','" & Num_En_US(gridDetailObat.Rows(i).Cells("jmln").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totaln").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "',  '" & Trim(gridDetailObat.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalharga").Value) & "', '" & gridDetailObat.Rows(i).Cells("senpot").Value & "','" & Num_En_US(gridDetailObat.Rows(i).Cells("potongan").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalharga").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("sisabayar").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgbeli").Value) & "', '" & Format(DTPJamAwal.Value, "HH:mm:ss") & "', '" & Trim(gridDetailObat.Rows(i).Cells("kdbagian").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("stsresep").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("rek_p").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("stsetiket").Value) & "', '" & gridDetailObat.Rows(i).Cells("jmlhari").Value & "', '" & Trim(gridDetailObat.Rows(i).Cells("posting").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("diserahkan").Value) & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', 'N', '" & Trim(gridDetailObat.Rows(i).Cells("jns_obat").Value) & "', '" & gridDetailObat.Rows(i).Cells("jmljatah").Value & "', '" & Format(gridDetailObat.Rows(i).Cells("tglakhir").Value, "yyyy/MM/dd") & "')"
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Cek Jatah Paket
                For i = 0 To gridDetailObat.RowCount - 2
                    If gridDetailObat.Rows(i).Cells("jmljatah").Value > 0 Then
                        sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "INSERT INTO ap_jualr2_bpjs(stsrawat,tglresep,notaresep,no_rm,kd_penjamin,kd_barang,nama_barang,jmlpaket,jmlnonpaket,jmljatah,tglakhir,kdbagian) VALUES ('" & StatusRawat & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & KdPenjamin & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nama_barang").Value)) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmln").Value) & "', '" & gridDetailObat.Rows(i).Cells("jmljatah").Value & "', '" & Format(gridDetailObat.Rows(i).Cells("tglakhir").Value, "yyyy/MM/dd") & "',  '" & Trim(gridDetailObat.Rows(i).Cells("kdbagian").Value) & "')"
                    End If
                Next
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Simpan etiketNew
                'If  pkdapo = "002" Or  pkdapo = "005" Then
                For i = 0 To gridDetailObat.RowCount - 2
                    'Dim a = gridDetailObat.CurrentRow.Index - 1
                    If gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObat.Rows(i).Cells("model_etiket").Value = "1" Then
                        sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, signa1, signa2, tgl_exp, jml_obat, urut, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket").Value)) & "', '" & gridDetailObat.Rows(i).Cells("takaran").Value & "', '" & gridDetailObat.Rows(i).Cells("waktu").Value & "', '" & gridDetailObat.Rows(i).Cells("ketminum").Value & "','" & Trim(gridDetailObat.Rows(i).Cells("qty1").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("qty2").Value) & "',  '" & Format(gridDetailObat.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ",'1')"
                    ElseIf gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObat.Rows(i).Cells("model_etiket").Value = "2" Then
                        sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, jml_obat, urut, obat, tetes, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket_infus").Value)) & "',  '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlobat_etiket_infus").Value) & "', " & i + 1 & ", '" & Rep(Trim(gridDetailObat.Rows(i).Cells("obat_infus").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("tetes_infus").Value)) & "','2')"
                    ElseIf gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObat.Rows(i).Cells("model_etiket").Value = "3" Then
                        sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, jml_obat, urut, kd_ketminum, tgl_exp, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket").Value)) & "',  '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ", '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ketminum").Value)) & "', '" & Format(gridDetailObat.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '3')"
                    ElseIf gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" And gridDetailObat.Rows(i).Cells("model_etiket").Value = "4" Then
                        sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, urut, ket_waktu_pagi_model4, ket_waktu_siang_model4, ket_waktu_sore_model4, ket_waktu_malam_model4, ket_minum_model4, model) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket").Value)) & "',  " & i + 1 & ", '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_waktu_pagi_model4").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_waktu_siang_model4").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_waktu_sore_model4").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_waktu_malam_model4").Value)) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("ket_minum_model4").Value)) & "', '4')"
                    End If
                Next
                'Else
                'For i = 0 To gridDetailObat.RowCount - 2
                '    'Dim a = gridDetailObat.CurrentRow.Index - 1
                '    If gridDetailObat.Rows(i).Cells("stsetiket").Value = "Y" Then
                '        sqlEditPenjualanObat = sqlEditPenjualanObat + vbCrLf + "insert into ap_etiketNew(tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, signa1, signa2, tgl_exp, jml_obat, urut) values ('" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nmobat_etiket").Value)) & "', '" & gridDetailObat.Rows(i).Cells("takaran").Value & "', '" & gridDetailObat.Rows(i).Cells("waktu").Value & "', '" & gridDetailObat.Rows(i).Cells("ketminum").Value & "','" & Trim(gridDetailObat.Rows(i).Cells("qty1").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("qty2").Value) & "',  '" & Format(gridDetailObat.Rows(i).Cells("tgl_exp").Value, "yyyy/MM/dd") & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlobat_etiket").Value) & "', " & i + 1 & ")"
                '    End If
                'Next
                'End If
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''TRANS KE KASIR''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Simpan resep_jual
                sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "insert into resep_jual(no_nota, no_rm, no_reg, jenis_rawat, tgl_jual, waktu, kd_dokter, kd_sub_unit, status_bayar, kd_kelompok_pelanggan, metode_bayar, total, user_id, user_nama, waktu_in, waktu_out, kd_sub_unit_asal, total_bulat, total_non_paket, total_non_paket_bulat, total_tunai, total_tunai_bulat, total_piutang, total_piutang_bulat) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNoReg.Text) & "',  '" & StatusRawat & "', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss").ToString & "', '" & kdDokter & "', '" & pkdsubunit & "', 'BELUM', '0', 'KREDIT', '" & Num_En_US(txtGrandTotal.DecimalValue) & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', '-', '" & kdSubUnit & "', '" & Num_En_US(txtGrandTotalBulat.DecimalValue) & "', '0', '0','" & Num_En_US(txtGrandIurBayar.DecimalValue) & "', '" & Num_En_US(txtGrandIurBayarBulat.DecimalValue) & "', '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "')"
                'CMD.ExecuteNonQuery()
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Simpan resep_jual_detail
                For i = 0 To gridDetailObat.RowCount - 2
                    sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "INSERT INTO resep_jual_detail(no_nota, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, nr, urutan, kd_sub_unit_asal, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket) values ('" & Trim(txtNoResep.Text) & "', '" & Trim(gridDetailObat.Rows(i).Cells("idx_barang").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("nmsatuan").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgbeli").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("harga").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '0', '0', '" & Num_En_US((gridDetailObat.Rows(i).Cells("totalharga").Value) - (gridDetailObat.Rows(i).Cells("dijamin").Value)) & "',  '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalharga").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("racik").Value) & "', " & i + 1 & ", '" & kdSubUnit & "', '0', '0', '" & Trim(gridDetailObat.Rows(i).Cells("rek_p").Value) & "', '" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "', '" & Rep(Trim(gridDetailObat.Rows(i).Cells("nama_barang").Value)) & "', '0')"
                    'CMD.ExecuteNonQuery()
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Update Stok
                If psts_stok = "1" Then
                    For i = 0 To gridDetailObat.RowCount - 2
                        sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "UPDATE Barang_Farmasi SET " & memStok & "=(" & memStok & "-" & Num_En_US(gridDetailObat.Rows(i).Cells("jml").Value) & ") WHERE kd_barang='" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "'"
                        'CMD.ExecuteNonQuery()
                    Next
                End If
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''' jika iteration maka ayang di update cuma status
                If status_iteration <> "1" Then
                    ''''''''''''''''''''''''''''''''''''''''''''''' UPDATE STATUS PELAYANAN OBAT JADI ''''''''''''''''''''''''''''''
                    If BDPermintaanObatDetail.Count > 0 Then
                        BDPermintaanObatDetail.MoveFirst()
                        For i = 1 To BDPermintaanObatDetail.Count
                            Dim jumlahTerlayani As Decimal
                            DRWPermintaanObatDetail = BDPermintaanObatDetail.Current
                            If IsDBNull(DRWPermintaanObatDetail.Item("jumlah_terlayani")) Then
                                jumlahTerlayani = 0
                            Else
                                jumlahTerlayani = DRWPermintaanObatDetail.Item("jumlah_terlayani")
                            End If
                            sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail 
                                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.status_terlayani= '" & Trim(DRWPermintaanObatDetail.Item("status_terlayani")) & "',
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Terlayani= " & Num_En_US(jumlahTerlayani) & ",
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_barang_terlayani= '" & Trim(DRWPermintaanObatDetail.Item("kd_barang_terlayani")) & "'
                                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.idx_Permintaan_Obat= '" & DRWPermintaanObatDetail.Item("idx_permintaan_obat") & "'"
                            BDPermintaanObatDetail.MoveNext()
                        Next
                    End If

                    '''''''''''''''''''''''''''''''' UPDATE STATUS PELAYANAN OBAT RACIKAN
                    If BDPermintaanObatRacikDetail.Count > 0 Then
                        '  menempatkan data binding pada posisi pertama
                        BDPermintaanObatRacikDetail.MoveFirst()
                        'melakukan perhitungan data pada data binding
                        For i = 1 To BDPermintaanObatRacikDetail.Count
                            Dim jumlahRacikTerlayani As Decimal
                            'menempatkan data row view pada posisi databinding sekarang
                            DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current
                            If IsDBNull(DRWPermintaanObatRacikDetail.Item("jumlah_terlayani")) Then
                                jumlahRacikTerlayani = 0
                            Else
                                jumlahRacikTerlayani = DRWPermintaanObatRacikDetail.Item("jumlah_terlayani")
                            End If
                            sqlEditPenjualanObat = sqlEditPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail 
                                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.status_terlayani= '" & Trim(DRWPermintaanObatRacikDetail.Item("status_terlayani")) & "',
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Terlayani= " & Num_En_US(jumlahRacikTerlayani) & ",
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_barang_terlayani= '" & Trim(DRWPermintaanObatRacikDetail.Item("kd_barang_terlayani")) & "'
                                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.idx_No_Racikan= '" & DRWPermintaanObatRacikDetail.Item("idx_no_racikan") & "'"
                            BDPermintaanObatRacikDetail.MoveNext()
                        Next
                    End If

                End If

                CMD.CommandText = sqlEditPenjualanObat
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi penjualan berhasil diedit", vbInformation, "Informasi")
                btnSimpan.Enabled = False
                btnCetakNota.Enabled = True
                btnCetakEtiket.Enabled = True
                btnCetakNota.Focus()
            Catch ex As Exception
                MsgBox(" Commit Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                Try
                    Trans.Rollback()
                Catch ex2 As Exception
                    MsgBox(" Rollback Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                    MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                End Try
            End Try
        End If
    End Sub

    Private Sub btnHapusNota_Click(sender As Object, e As EventArgs) Handles btnHapusNota.Click
        If MessageBox.Show("Yakin transaksi ini akan dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            If Posting = "2" Then
                MsgBox("Transaksi tidak bisa diedit, sudah diposting oleh kasir", vbInformation, "Informasi")
                Exit Sub
            End If
            cariSubUnitAsal()
            If pkdapo = "001" Then
                memStok = "stok001"
            ElseIf pkdapo = "002" Then
                memStok = "stok002"
            ElseIf pkdapo = "003" Then
                memStok = "stok003"
            ElseIf pkdapo = "004" Then
                memStok = "stok004"
            ElseIf pkdapo = "005" Then
                memStok = "stok005"
            ElseIf pkdapo = "006" Then
                memStok = "stok006"
            ElseIf pkdapo = "007" Then
                memStok = "stok007"
            Else
                MsgBox("Setting apotik belum benar, silahkan hubungi administrator")
            End If

            Dim sqlHapusPenjualanObat As String = ""
            'CONN.Open()
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS APOTEK'''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr1
                sqlHapusPenjualanObat = "Delete from ap_jualr1 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr2
                sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "Delete from ap_jualr2 WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus ap_jualr2_bpjs
                sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "Delete from ap_jualr2_bpjs WHERE tglresep='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus etiket
                sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "Delete from ap_etiketNew WHERE tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and notaresep='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                ''''''''''''''''''''''''''''''''''''''HAPUS TRANS KASIR'''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual
                sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "Delete from resep_jual WHERE no_nota='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Hapus resep_jual_detail
                sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "Delete from resep_jual_detail WHERE no_nota='" & Trim(txtNoResep.Text) & "'"
                'CMD.ExecuteNonQuery()
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''Stok Kembali Asal'''''''''''''''''''''''''''''''''''''''''''''

                If psts_stok = "1" Then
                    For i = 0 To gridStokKembali.RowCount - 2
                        sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE Barang_Farmasi SET " & memStok & "=(" & memStok & "+" & Num_En_US(gridStokKembali.Rows(i).Cells("jml").Value) & ") WHERE kd_barang='" & Trim(gridStokKembali.Rows(i).Cells("kd_barang").Value) & "'"
                        'CMD.ExecuteNonQuery()
                    Next
                End If


                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

                '''''''''''''''''''''''''''''''''''''''''''''''' SAVE TO SIMRM'''''''''''''''''''''''''
                If status_iteration = "1" And iteration_terlayani = 1 Then
                    sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat 
                            SET DBSIMRM.dbo.RJ_Permintaan_Obat.status='1',
                            DBSIMRM.dbo.RJ_Permintaan_Obat.notaresep_iteration_pertama='" & Trim(txtNoResep.Text) & "',
                            DBSIMRM.dbo.RJ_Permintaan_Obat.iteration_terlayani+=1
                            WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & noPermintaanObat & "'"
                ElseIf status_iteration = "1" And iteration_terlayani = 2 Then
                    sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat 
                            SET DBSIMRM.dbo.RJ_Permintaan_Obat.status='1',
                            DBSIMRM.dbo.RJ_Permintaan_Obat.notaresep_iteration_kedua='" & Trim(txtNoResep.Text) & "',
                            DBSIMRM.dbo.RJ_Permintaan_Obat.iteration_terlayani+=1
                            WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & noPermintaanObat & "'"
                ElseIf status_iteration = "1" And iteration_terlayani = 3 Then
                    sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat 
                            SET DBSIMRM.dbo.RJ_Permintaan_Obat.status='1',
                            DBSIMRM.dbo.RJ_Permintaan_Obat.notaresep_iteration_ketiga='" & Trim(txtNoResep.Text) & "',
                            DBSIMRM.dbo.RJ_Permintaan_Obat.iteration_terlayani+=1
                            WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & noPermintaanObat & "'"
                Else
                    sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat 
                            SET DBSIMRM.dbo.RJ_Permintaan_Obat.status='0',
                            DBSIMRM.dbo.RJ_Permintaan_Obat.notaresep='' 
                            WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat='" & noPermintaanObat & "'"

                    '''''''''''''''''''''''''''''''' UPDATE STATUS PELAYANAN OBAT JADI TIDAK DI LAYANI
                    If BDPermintaanObatDetail.Count > 0 Then
                        BDPermintaanObatDetail.MoveFirst()
                        For i = 1 To BDPermintaanObatDetail.Count
                            Dim jumlahTerlayani As Decimal
                            DRWPermintaanObatDetail = BDPermintaanObatDetail.Current
                            If IsDBNull(DRWPermintaanObatDetail.Item("jumlah_terlayani")) Then
                                jumlahTerlayani = 0
                            Else
                                jumlahTerlayani = DRWPermintaanObatDetail.Item("jumlah_terlayani")
                            End If
                            sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail 
                                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.status_terlayani= 0,
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Terlayani= 0 ,
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_barang_terlayani= ' '
                                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.idx_Permintaan_Obat= '" & DRWPermintaanObatDetail.Item("idx_permintaan_obat") & "'"
                            BDPermintaanObatDetail.MoveNext()
                        Next
                    End If

                    '''''''''''''''''''''''''''''''' UPDATE STATUS PELAYANAN OBAT RACIKAN
                    If BDPermintaanObatRacikDetail.Count > 0 Then
                        '  menempatkan data binding pada posisi pertama
                        BDPermintaanObatRacikDetail.MoveFirst()
                        'melakukan perhitungan data pada data binding
                        For i = 1 To BDPermintaanObatRacikDetail.Count
                            Dim jumlahRacikTerlayani As Decimal
                            'menempatkan data row view pada posisi databinding sekarang
                            DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current
                            If IsDBNull(DRWPermintaanObatRacikDetail.Item("jumlah_terlayani")) Then
                                jumlahRacikTerlayani = 0
                            Else
                                jumlahRacikTerlayani = DRWPermintaanObatRacikDetail.Item("jumlah_terlayani")
                            End If
                            sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail 
                                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.status_terlayani= 0,
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Terlayani= 0,
                                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_barang_terlayani= ' '
                                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.idx_No_Racikan= '" & DRWPermintaanObatRacikDetail.Item("idx_no_racikan") & "'"
                            BDPermintaanObatRacikDetail.MoveNext()
                        Next
                    End If

                End If


                'sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat
                '                        Set DBSIMRM.dbo.RJ_Permintaan_Obat.status= 0,
                '                        DBSIMRM.dbo.RJ_Permintaan_Obat.notaresep= ' '
                '                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "'"

                '''''''''''''''''''''''''''''''''' UPDATE STATUS OBAT JADI TERLAYANI
                'If BDPermintaanObatDetail.Count > 0 Then
                '    BDPermintaanObatDetail.MoveFirst()
                '    For i = 1 To BDPermintaanObatDetail.Count
                '        DRWPermintaanObatDetail = BDPermintaanObatDetail.Current
                '        sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail 
                '                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.status_terlayani= 0,
                '                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.Jumlah_Terlayani= 0,
                '                        DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.kd_barang_terlayani= ' '
                '                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                '                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Detail.idx_Permintaan_Obat= '" & DRWPermintaanObatDetail.Item("idx_permintaan_obat") & "'"
                '        BDPermintaanObatDetail.MoveNext()
                '    Next
                'End If

                ''''''''''''''''''''''''''''''''' UPDATE STATUS PELAYANAN OBAT RACIKAN
                'If BDPermintaanObatRacikDetail.Count > 0 Then
                '    BDPermintaanObatRacikDetail.MoveFirst()
                '    For i = 1 To BDPermintaanObatRacikDetail.Count
                '        DRWPermintaanObatRacikDetail = BDPermintaanObatRacikDetail.Current
                '        sqlHapusPenjualanObat = sqlHapusPenjualanObat & vbCrLf & "UPDATE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail 
                '                        Set DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.status_terlayani= 0,
                '                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.Jumlah_Terlayani= 0, 
                '                        DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.kd_barang_terlayani= ' '
                '                        WHERE DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.No_Permintaan_Obat= '" & Trim(noPermintaanObat) & "' 
                '                        AND DBSIMRM.dbo.RJ_Permintaan_Obat_Racikan_Detail.idx_No_Racikan= '" & DRWPermintaanObatRacikDetail.Item("idx_no_racikan") & "'"
                '        BDPermintaanObatRacikDetail.MoveNext()
                '    Next
                'End If

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CMD.CommandText = sqlHapusPenjualanObat
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi penjualan berhasil dihapus", vbInformation, "Informasi")
                KosongkanHeader()
                KosongkanDetailPaketKhusus()
                KosongkanDetailPaketUmum()
            Catch ex As Exception
                MsgBox(" Commit Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                Try
                    Trans.Rollback()
                Catch ex2 As Exception
                    MsgBox(" Rollback Exception Type: {0}" & ex.GetType.ToString, vbCritical, "Kesalahan")
                    MsgBox(" Message: {0}" & ex.Message, vbCritical, "Kesalahan")
                End Try
            End Try
        End If
    End Sub

    Private Sub cmbEtiket_LostFocus(sender As Object, e As EventArgs) Handles cmbEtiket.LostFocus
        cmbEtiket.Text = (cmbEtiket.Text.ToUpper)
        nmPaket = "PKTUMUM"
        If cmbEtiket.Text = "Y" Then
            If pkdapo = "002" Then
                PanelEtiketModel4.Visible = True
                modelEtiket = "4"
                txtNamaObatEtiketModel4.Focus()
            Else
                PanelEtiket.Visible = True
                txtNamaObatEtiket.Focus()
            End If
        Else
            PanelEtiket.Visible = False
            PanelEtiketModel4.Visible = False
        End If
    End Sub

    Private Sub cmbEtiket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbEtiket.KeyPress
        If e.KeyChar = Chr(13) Then
            If cmbEtiket.Text = "Y" Or cmbEtiket.Text = "y" Or cmbEtiket.Text = "N" Or cmbEtiket.Text = "n" Then
                If cmbEtiket.Text = "N" Then
                    PanelEtiket.Visible = False
                    PanelEtiketModel4.Visible = False
                    SendKeys.Send("{TAB}")
                Else
                    If pkdapo = "002" Then
                        PanelEtiketModel4.Visible = True
                        modelEtiket = "4"
                        txtNamaObatEtiketModel4.Focus()
                    Else
                        PanelEtiket.Visible = True
                        txtNamaObatEtiket.Text = lblNamaObat.Text
                        txtJumlahObatEtiket.DecimalValue = txtJumlahJual.DecimalValue
                        txtNamaObatEtiket.Focus()
                    End If
                End If
            Else
                MsgBox("Pilih yang benar", vbCritical, "Kesalahan")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub SubcmbEtiket_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbEtiket.KeyDown
        If e.KeyCode = Keys.Left Then
            txtJmlHari.Focus()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtNoReg.Text = "" Then
            MsgBox("Pilih pasien terlebih dahulu")
            Exit Sub
        End If
        If txtKodeObat.Text = "" Then
            MsgBox("Obat belum dipilih")
            Exit Sub
        End If
        If txtJumlahJual.DecimalValue <= 0 Then
            MsgBox("Jumlah belum diisi")
            txtJumlahJual.Focus()
        Else
            'For barisGrid As Integer = 0 To gridDetailObat.RowCount - 1
            '    If Trim(txtKodeObat.Text) = gridDetailObat.Rows(barisGrid).Cells("kd_barang").Value Then
            '        MsgBox("Obat ini sudah dientry")
            '        KosongkanDetailPaketUmum()
            '        txtKodeObat.Focus()
            '        Exit Sub
            '    End If
            'Next
            txtJumlahHarga.DecimalValue = txtHargaJual.DecimalValue * txtJumlahJual.DecimalValue
            If cmbDijamin.Text = "N" Then
                'txtDijamin.DecimalValue = 0
                txtIuranSisaBayar.DecimalValue = txtJumlahHarga.DecimalValue - txtDijamin.DecimalValue
            ElseIf cmbDijamin.Text = "Y" Then
                txtIuranSisaBayar.DecimalValue = 0
                txtDijamin.DecimalValue = txtJumlahHarga.DecimalValue
                txtIuranSisaBayar.DecimalValue = txtJumlahHarga.DecimalValue - txtDijamin.DecimalValue
            End If
            PanelEtiketModel4.Visible = False
            ' status obat jadi atau obatracik
            If idx_permintaan_obat <> Nothing Then
                If jenisPelayanan = "obat-jadi" Then
                    addStatusObatJadiTerlayani(idx_permintaan_obat, kd_barang_permintaan, txtJumlahJual.DecimalValue, txtKodeObat.Text, nama_barang)
                Else
                    addStatusObatRacikTerlayani(idx_permintaan_obat, kd_barang_permintaan, txtJumlahJual.DecimalValue, txtKodeObat.Text, nama_barang)
                End If
                'addPelayananObat()
            End If
            addBarang()
            AturGriddetailBarang()
            NoUrut()
            KosongkanDetailPaketUmum()
            btnSimpan.Enabled = True
            txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
            idx_permintaan_obat = Nothing
            'cmbRacikNon.Focus()
            'gridObatJadi.Focus()
            RefreshGridObatJadi()
            RefreshGridObatRacikan()
        End If
    End Sub

    Private Sub btnCetakEtiket_Click(sender As Object, e As EventArgs) Handles btnCetakEtiket.Click
        If MessageBox.Show("Apakah akan cetak etiket ...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                DA = New OleDb.OleDbDataAdapter("SELECT tanggal, notaresep, no_rm, kd_barang, nama_barang, kd_takaran, kd_waktu, kd_ketminum, qty1, qty2, tgl_exp, signa1, signa2, jml_obat, urut, model, obat, tetes, CASE ket_waktu_pagi_model4 WHEN '1' THEN '' ELSE 'Pagi' END AS ket_waktu_pagi_model4, CASE ket_waktu_siang_model4 WHEN '1' THEN '' ELSE 'Siang' END AS ket_waktu_siang_model4, CASE ket_waktu_sore_model4 WHEN '1' THEN '' ELSE 'Sore' END AS ket_waktu_sore_model4, CASE ket_waktu_malam_model4 WHEN '1' THEN '' ELSE 'Malam' END AS ket_waktu_malam_model4, CASE ket_minum_model4 WHEN '1' THEN 'Sebelum Makan' WHEN '2' THEN 'Bersama Makan' WHEN '3' THEN 'Sesudah Makan' ELSE 'Injeksi' END AS ket_minum_model4 FROM ap_etiketNew WHERE notaresep='" & Trim(txtNoResep.Text) & "' and tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "'", CONN)
                DS = New DataSet
                DA.Fill(DS, "cetakEtiket")
                BDEtiket.DataSource = DS
                BDEtiket.DataMember = "cetakEtiket"
                BDEtiketModel4.DataSource = DSEtiketModel4
                BDEtiketModel4.DataMember = "EtiketModel4"
                If BDEtiket.Count > 0 Then
                    BDEtiket.MoveFirst()
                    For i = 1 To BDEtiket.Count
                        DRWEtiket = BDEtiket.Current
                        If DRWEtiket.Item("model") = "1" Then
                            Dim rpt As New ReportDocument
                            Try
                                Dim str As String = Application.StartupPath & "\Report\etiket.rpt"
                                rpt.Load(str)
                                'FormCetak.CrystalReportViewer1.Refresh()
                                rpt.SetDatabaseLogon(dbUser, dbPassword)
                                rpt.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
                                rpt.SetParameterValue("notaresep", Trim(txtNoResep.Text))
                                rpt.SetParameterValue("kdbarang", Trim(DRWEtiket.Item("kd_barang")))
                                rpt.SetParameterValue("urut", DRWEtiket.Item("urut"))
                                rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                                rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                                rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
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

                        ElseIf DRWEtiket.Item("model") = "2" Then
                            For a = 1 To DRWEtiket.Item("jml_obat")
                                Dim rpt As New ReportDocument
                                Try
                                    Dim str As String = Application.StartupPath & "\Report\etiketInfus.rpt"
                                    rpt.Load(str)
                                    'FormCetak.CrystalReportViewer1.Refresh()
                                    rpt.SetDatabaseLogon(dbUser, dbPassword)
                                    rpt.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
                                    rpt.SetParameterValue("notaresep", Trim(txtNoResep.Text))
                                    rpt.SetParameterValue("kdbarang", Trim(DRWEtiket.Item("kd_barang")))
                                    rpt.SetParameterValue("urut", DRWEtiket.Item("urut"))
                                    rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                                    rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                                    rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
                                    rpt.SetParameterValue("user", Trim(FormLogin.LabelNama.Text))
                                    rpt.SetParameterValue("ruang", Trim(nmSubUnit))
                                    rpt.SetParameterValue("kamar", lblKamarBed.Text)
                                    rpt.PrintToPrinter(1, False, 0, 0)
                                    rpt.Close()
                                    rpt.Dispose()
                                    'FormCetak.CrystalReportViewer1.ReportSource = rpt
                                    'FormCetak.CrystalReportViewer1.Show()
                                    'FormCetak.ShowDialog()
                                Catch ex As Exception
                                    MsgBox(ex.Message)
                                End Try
                            Next
                        ElseIf DRWEtiket.Item("model") = "3" Then
                            Dim rpt As New ReportDocument
                            Try
                                Dim str As String = Application.StartupPath & "\Report\etiketModel3.rpt"
                                rpt.Load(str)
                                'FormCetak.CrystalReportViewer1.Refresh()
                                rpt.SetDatabaseLogon(dbUser, dbPassword)
                                rpt.SetParameterValue("tanggal", Format(DTPTanggalTrans.Value, "yyyy/MM/dd"))
                                rpt.SetParameterValue("notaresep", Trim(txtNoResep.Text))
                                rpt.SetParameterValue("kdbarang", Trim(DRWEtiket.Item("kd_barang")))
                                rpt.SetParameterValue("urut", DRWEtiket.Item("urut"))
                                rpt.SetParameterValue("nmPasien", Trim(txtNamaPasien.Text))
                                rpt.SetParameterValue("bulan", Trim(txtUmurBln.Text))
                                rpt.SetParameterValue("tahun", Trim(txtUmurThn.Text))
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
                        ElseIf DRWEtiket.Item("model") = "4" Then
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Injeksi" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_sore_model4") = "Sore" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_sore_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_sore_model4") = "Sore" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_sore_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_sore_model4") = "Sore" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_sore_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                                BDEtiketModel4.AddNew()
                                DRWEtiketModel4 = BDEtiketModel4.Current
                                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                                BDEtiketModel4.EndEdit()
                            End If
                        End If
                        BDEtiket.MoveNext()
                    Next
                End If
                'If  pkdapo = "002" Then
                '    BDEtiket.Filter = "model='4'"
                '    If BDEtiket.Count > 0 Then
                '        BDEtiketModel4.DataSource = DSEtiketModel4
                '        BDEtiketModel4.DataMember = "EtiketModel4"
                '        BDEtiket.MoveFirst()
                '        For i = 1 To BDEtiket.Count
                '            DRWEtiket = BDEtiket.Current
                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If

                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If

                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If

                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_pagi_model4") = "Pagi" And DRWEtiket.Item("ket_minum_model4") = "Injeksi" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_pagi_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If

                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If
                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If
                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_siang_model4") = "Siang" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_siang_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If

                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Sebelum Makan" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If
                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Bersama Makan" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If
                '            If DRWEtiket.Item("model") = "4" And DRWEtiket.Item("ket_waktu_malam_model4") = "Malam" And DRWEtiket.Item("ket_minum_model4") = "Sesudah Makan" Then
                '                BDEtiketModel4.AddNew()
                '                DRWEtiketModel4 = BDEtiketModel4.Current
                '                DRWEtiketModel4("namaObat") = DRWEtiket.Item("nama_barang")
                '                DRWEtiketModel4("waktuMinum") = DRWEtiket.Item("ket_waktu_malam_model4")
                '                DRWEtiketModel4("ketMinum") = DRWEtiket.Item("ket_minum_model4")
                '                BDEtiketModel4.EndEdit()
                '            End If

                '            BDEtiket.MoveNext()
                '        Next
                If pkdapo = "002" Or pkdapo = "005" Then
                    gridEtiket.DataSource = Nothing
                    gridEtiket.DataSource = BDEtiketModel4

                    BDEtiketModel4.RemoveFilter()
                    ' ''''''''''' Kondisi 1 pagi, sebelum
                    If (gridEtiket.Rows.Count() - 1) > 0 Then
                        FormKonfirmasiEtiketModel4Edit.ShowDialog()
                        For i = 0 To jmlHariEtiketModel4 - 1
                            BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Sebelum Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ''''''''''' Kondisi 2 pagi, bersama
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Bersama Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ''''''''''' Kondisi 3 pagi, sesudah
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Sesudah Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ' ''''''''''' Kondisi 4 pagi, injeksi
                            'BDEtiketModel4.RemoveFilter()
                            'BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Injeksi'"
                            'If (gridEtiket.Rows.Count() - 1) > 0 Then
                            '    cetakEtiketModel4()
                            'End If

                            ''''''''''' Kondisi 5 siang, sebelum
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Siang' AND ketMinum='Sebelum Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ''''''''''' Kondisi 6 siang, bersama
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Siang' AND ketMinum='Bersama Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ''''''''''' Kondisi 7 siang, sesudah
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Siang' AND ketMinum='Sesudah Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ''''''''''' Kondisi 8 malam, sebelum
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Sore' AND ketMinum='Sebelum Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ''''''''''' Kondisi 9 malam, bersama
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Sore' AND ketMinum='Bersama Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ''''''''''' Kondisi 10 malam, sesudah
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Sore' AND ketMinum='Sesudah Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If
                            ''''''''''' Kondisi 11 malam, sebelum
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Malam' AND ketMinum='Sebelum Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ''''''''''' Kondisi 12 malam, bersama
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Malam' AND ketMinum='Bersama Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If

                            ''''''''''' Kondisi 13 malam, sesudah
                            BDEtiketModel4.RemoveFilter()
                            BDEtiketModel4.Filter = "waktuMinum='Malam' AND ketMinum='Sesudah Makan'"
                            If (gridEtiket.Rows.Count() - 1) > 0 Then
                                cetakEtiketModel4()
                            End If
                        Next
                        ''''''''''' Kondisi 4 pagi, injeksi
                        BDEtiketModel4.RemoveFilter()
                        BDEtiketModel4.Filter = "waktuMinum='Pagi' AND ketMinum='Injeksi'"
                        If (gridEtiket.Rows.Count() - 1) > 0 Then
                            cetakEtiketModel4()
                        End If
                        BDEtiketModel4.RemoveFilter()
                    End If
                End If
                ' End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            btnCetakEtiket.Enabled = False
        End If
    End Sub

    Private Sub btnInfoResep_Click(sender As Object, e As EventArgs) Handles btnInfoResep.Click
        FormPemanggil = "FormEditPenjualanResepEMR"
        If txtNoReg.Text = "" Then
            MsgBox("Pilih pasien terlebih dahulu")
            txtNoReg.Focus()
        Else
            FormInfoResepObat.ShowDialog()
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Dispose()
    End Sub

    Private Sub btnUpdateDijamin_Click(sender As Object, e As EventArgs) Handles btnUpdateDijamin.Click
        For i = 0 To gridDetailObat.RowCount - 2
            gridDetailObat.Rows(i).Cells("dijamin").Value = gridDetailObat.Rows(i).Cells("jmlnet").Value
            gridDetailObat.Rows(i).Cells("sisabayar").Value = 0
        Next
        cmbDijamin.Text = "Y"
        TotalHarga()
        TotalDijamin()
        TotalIurBayar()
    End Sub

    Private Sub btnUpdateIurPasien_Click(sender As Object, e As EventArgs) Handles btnUpdateIurPasien.Click
        For i = 0 To gridDetailObat.RowCount - 2
            gridDetailObat.Rows(i).Cells("dijamin").Value = 0
            gridDetailObat.Rows(i).Cells("sisabayar").Value = gridDetailObat.Rows(i).Cells("jmlnet").Value
        Next
        cmbDijamin.Text = "N"
        TotalHarga()
        TotalDijamin()
        TotalIurBayar()
    End Sub

    Private Sub txtSigna1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSigna1.KeyDown
        If e.KeyCode = Keys.Up Then
            txtJumlahObatEtiket.Focus()
        End If
    End Sub

    Private Sub txtSigna1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSigna1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtSigna2.Focus()
        End If
    End Sub

    Private Sub txtSigna2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSigna2.KeyDown
        If e.KeyCode = Keys.Up Then
            txtSigna1.Focus()
        End If
    End Sub

    Private Sub txtSigna2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSigna2.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbTakaran.Focus()
        End If
    End Sub

    Private Sub txtJumlahObatEtiket_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJumlahObatEtiket.KeyDown
        If e.KeyCode = Keys.Up Then
            txtNamaObatEtiket.Focus()
        End If
    End Sub

    Private Sub txtJumlahObatEtiket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJumlahObatEtiket.KeyPress
        If e.KeyChar = Chr(13) Then
            txtSigna1.Focus()
        End If
    End Sub

    Private Sub txtNamaObatEtiket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamaObatEtiket.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJumlahObatEtiket.Focus()
        End If
    End Sub

    Private Sub cmbWaktu_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbWaktu.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbKeterangan.Focus()
        End If
        If e.KeyCode = Keys.Left Then
            cmbTakaran.Focus()
        End If
    End Sub

    Private Sub cmbTakaran_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbTakaran.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbWaktu.Focus()
        End If
        If e.KeyCode = Keys.Left Then
            txtSigna2.Focus()
        End If
    End Sub

    Private Sub txtQty_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtQty3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQty3.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbKeterangan_KeyDown(sender As Object, e As KeyEventArgs) Handles cmbKeterangan.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtJarakED.Focus()
        End If
        If e.KeyCode = Keys.Left Then
            cmbWaktu.Focus()
        End If
    End Sub

    Private Sub cmbRacikNon_LostFocus(sender As Object, e As EventArgs) Handles cmbRacikNon.LostFocus
        cmbRacikNon.Text = (cmbRacikNon.Text.ToUpper)
    End Sub

    Private Sub cmbDijamin_LostFocus(sender As Object, e As EventArgs) Handles cmbDijamin.LostFocus
        cmbDijamin.Text = (cmbDijamin.Text.ToUpper)
    End Sub

    Private Sub txtDijamin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDijamin.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJmlHari.Focus()
        End If
    End Sub

    Private Sub txtDijamin_TextChanged(sender As Object, e As EventArgs) Handles txtDijamin.TextChanged
        txtIuranSisaBayar.DecimalValue = txtJumlahHarga.DecimalValue - txtDijamin.DecimalValue
    End Sub

    Private Sub gridDetailObat_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles gridDetailObat.CellEndEdit
        gridDetailObat.Rows(e.RowIndex).Cells("totalharga").Value = gridDetailObat.Rows(e.RowIndex).Cells("harga").Value * gridDetailObat.Rows(e.RowIndex).Cells("jml").Value
        If cmbPenjamin.Text = "-|UMUM" Then
            gridDetailObat.Rows(e.RowIndex).Cells(8).Value = gridDetailObat.Rows(e.RowIndex).Cells(6).Value
        Else
            gridDetailObat.Rows(e.RowIndex).Cells(7).Value = gridDetailObat.Rows(e.RowIndex).Cells(6).Value
        End If
        TotalHarga()
        TotalDijamin()
        TotalIurBayar()
    End Sub

    Private Sub cmbRacikNon_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRacikNon.SelectedIndexChanged
        If cmbRacikNon.Text = "R" Then
            txtDosisResep.Enabled = True
            txtJmlBungkus.Enabled = True
        Else
            txtDosisResep.Enabled = False
            txtJmlBungkus.Enabled = False
        End If
    End Sub

    Private Sub txtDosisResepKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDosisResepKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtKodeObatKh.Focus()
        End If
    End Sub

    Private Sub txtDosisResepKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDosisResepKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlCapBPJSKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlCapBPJSKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtDosisResepKh.Focus()
        End If
    End Sub

    Private Sub txtJmlCapBPJSKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlCapBPJSKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlCapLainKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlCapLainKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtJmlCapBPJSKh.Focus()
        End If
    End Sub

    Private Sub txtJmlCapLainKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlCapLainKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlObatKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlObatKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtJmlCapLainKh.Focus()
        End If
    End Sub

    Private Sub txtJmlObatKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlObatKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtPaketBPJSKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPaketBPJSKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtJmlCapLainKh.Focus()
        End If
    End Sub

    Private Sub txtPaketBPJSKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaketBPJSKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtJmlHariKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlHariKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtPaketLainKh.Focus()
        End If
    End Sub

    Private Sub txtJmlHariKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlHariKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub rInjeksi_CheckedChanged(sender As Object, e As EventArgs) Handles rInjeksi.CheckedChanged
        If rInjeksi.Checked = True Then
            cbPagi.Checked = True
            cbSiang.Checked = False
            cbSore.Checked = False
            cbMalam.Checked = False
        End If
    End Sub

    Private Sub txtTetesInfus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTetesInfus.KeyDown
        If e.KeyCode = Keys.Enter Then
            PanelEtiketInfus.Visible = False
            If nmPaket = "PKTUMUM" Then
                btnAdd.Focus()
            Else
                btnAddKh.Focus()
            End If
        End If
    End Sub

    Private Sub txtJarakEDModel3_TextChanged(sender As Object, e As EventArgs) Handles txtJarakEDModel3.TextChanged
        DTPTanggalExp.Value = DateAdd("d", Val(txtJarakED.DecimalValue), DTPTanggalTrans.Value)
    End Sub

    Private Sub txtJarakEDModel3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJarakEDModel3.KeyDown
        If e.KeyCode = Keys.Enter Then
            PanelEtiketModel3.Visible = False
            If nmPaket = "PKTUMUM" Then
                btnAdd.Focus()
            Else
                btnAddKh.Focus()
            End If
        End If
    End Sub

    Private Sub txtJarakED_TextChanged(sender As Object, e As EventArgs) Handles txtJarakED.TextChanged
        DTPTanggalExp.Value = DateAdd("d", Val(txtJarakED.DecimalValue), DTPTanggalTrans.Value)
    End Sub

    Private Sub cmbRacikNon_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRacikNon.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKodeObatKh.Focus()
        End If
    End Sub

    Private Sub cmbRacikNonKh_LostFocus(sender As Object, e As EventArgs) Handles cmbRacikNonKh.LostFocus
        cmbRacikNonKh.Text = (cmbRacikNonKh.Text.ToUpper)
    End Sub

    Private Sub cmbRacikNonKh_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRacikNonKh.SelectedIndexChanged
        If cmbRacikNonKh.Text = "R" Then
            txtDosisResepKh.Enabled = True
            txtJmlCapBPJSKh.Enabled = True
            txtJmlCapLainKh.Enabled = True
            txtJmlObatKh.Enabled = True
        Else
            txtDosisResepKh.Enabled = False
            txtJmlCapBPJSKh.Enabled = False
            txtJmlCapLainKh.Enabled = False
            txtJmlObatKh.Enabled = False
        End If
    End Sub

    Private Sub txtKodeObatKh_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObatKh.GotFocus
        If Stok = "1" Then
            tampilBarangSemua()
        Else
            tampilBarang()
        End If
        PanelObat.Visible = True
        txtCariObat.Clear()
        txtCariObat.Focus()
    End Sub

    Private Sub txtPaketLainKh_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPaketLainKh.KeyDown
        If e.KeyCode = Keys.Up Then
            txtPaketBPJSKh.Focus()
        End If
    End Sub

    Private Sub txtPaketLainKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPaketLainKh.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub cmbRacikNonKh_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbRacikNonKh.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKodeObatKh.Focus()
        End If
    End Sub

    Private Sub cmbJenisRawat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbJenisRawat.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNoReg.Focus()
        End If
    End Sub

    Private Sub txtDosisResep_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDosisResep.KeyDown
        If e.KeyCode = Keys.Up Then
            txtKodeObat.Focus()
        End If
    End Sub

    Private Sub txtDosisResep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDosisResep.KeyPress
        If e.KeyChar = Chr(13) Then
            txtJmlBungkus.Focus()
        End If
    End Sub

    Private Sub txtJmlBungkus_KeyDown(sender As Object, e As KeyEventArgs) Handles txtJmlBungkus.KeyDown
        If e.KeyCode = Keys.Up Then
            txtDosisResep.Focus()
        End If
    End Sub

    Private Sub txtJmlBungkus_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtJmlBungkus.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbDijamin.Focus()
        End If
    End Sub

    Private Sub txtDosis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDosis.KeyPress
        If e.KeyChar = Chr(13) Then
            txtDosisResep.Focus()
        End If
    End Sub
End Class