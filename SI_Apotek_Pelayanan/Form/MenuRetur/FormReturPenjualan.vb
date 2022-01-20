Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports CrystalDecisions.CrystalReports.Engine
Imports System.ComponentModel
Imports System.Data.OleDb

Public Class FormReturPenjualan
    Inherits Office2010Form
    Public rpt As New ReportDocument

    Dim tglLahirPasien As DateTime
    Dim BDDataPasien, BDObat, BDReturObat As New BindingSource
    Dim DRWReturObat As DataRowView
    Dim DSReturObat As New DataSet
    Dim kdRuangPoli, jenisRawat, NamaPenjamin, kdPenjamin, kdDokter, NamaDokter, kdPoliklinik, noidBarang, Generik, kdJnsObat, KdKelObat, kdGolObat, kdPabrik, Formularium, Rekening, JenisObat, nmSubUnit, kdSubUnit, memStok, bilang As String

    Dim Trans As OleDbTransaction

    Private Sub txtCariBarang_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariBarang.KeyDown
        If e.KeyCode = Keys.Down Then
            gridBarang.Focus()
        End If
    End Sub

    Private Sub gridBarang_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridBarang.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridBarang.Rows(e.RowIndex).Cells(1).Value) Then
                noidBarang = gridBarang.Rows(e.RowIndex).Cells(1).Value
                PanelBarang.Visible = False
                detailObat()
            End If
        End If
    End Sub

    Private Sub txtCariBarang_TextChanged(sender As Object, e As EventArgs) Handles txtCariBarang.TextChanged
        BDObat.Filter = "nama_barang like '%" & txtCariBarang.Text & "%'"
    End Sub

    Private Sub txtRetPaket_LostFocus(sender As Object, e As EventArgs) Handles txtRetPaket.LostFocus
        If txtJmlPaket.DecimalValue < txtRetPaket.DecimalValue Then
            MsgBox("Jumlah retur melebihi jumlah resep", vbCritical, "Kesalahan")
            txtRetPaket.DecimalValue = 0
            txtRetPaket.Focus()
        End If
    End Sub

    Private Sub txtRetPaket_TextChanged(sender As Object, e As EventArgs) Handles txtRetPaket.TextChanged
        txtJmlHargaPaket.DecimalValue = txtRetPaket.DecimalValue * txtHarga.DecimalValue
        txtTotalHargaRetur.DecimalValue = txtJmlHargaPaket.DecimalValue + txtJmlHargaNonPaket.DecimalValue
        txtJumlahRetur.DecimalValue = txtRetPaket.DecimalValue + txtRetNonPaket.DecimalValue
    End Sub

    Private Sub gridBarang_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridBarang.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridBarang.CurrentRow.Index - 1
            If Not IsDBNull(gridBarang.Rows(i).Cells(1).Value) Then
                noidBarang = gridBarang.Rows(i).Cells(1).Value
                PanelBarang.Visible = False
                detailObat()
            End If
        End If
    End Sub

    Private Sub txtRetPaket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRetPaket.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtRetNonPaket_LostFocus(sender As Object, e As EventArgs) Handles txtRetNonPaket.LostFocus
        If txtJmlNonPaket.DecimalValue < txtRetNonPaket.DecimalValue Then
            MsgBox("Jumlah retur melebihi jumlah resep", vbCritical, "Kesalahan")
            txtRetNonPaket.DecimalValue = 0
            txtRetNonPaket.Focus()
            Exit Sub
        End If
        If txtDijaminResepAwal.DecimalValue > 0 Then
            txtDijamin.DecimalValue = txtTotalHargaRetur.DecimalValue
        End If
    End Sub

    Private Sub txtRetNonPaket_TextChanged(sender As Object, e As EventArgs) Handles txtRetNonPaket.TextChanged
        txtJmlHargaNonPaket.DecimalValue = txtRetNonPaket.DecimalValue * txtHarga.DecimalValue
        txtTotalHargaRetur.DecimalValue = txtJmlHargaPaket.DecimalValue + txtJmlHargaNonPaket.DecimalValue
        txtJumlahRetur.DecimalValue = txtRetPaket.DecimalValue + txtRetNonPaket.DecimalValue
    End Sub

    Private Sub txtRetNonPaket_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRetNonPaket.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtDijamin_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDijamin.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub txtIurPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtIurPasien.KeyPress
        If e.KeyChar = Chr(13) Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtNoReg.Text = "" Then
            MsgBox("Pasien belum dipilih")
            txtNoReg.Focus()
            Exit Sub
        End If
        If txtKodeObat.Text = "" Then
            MsgBox("Obat belum dipilih")
            txtKodeObat.Focus()
            Exit Sub
        End If
        If txtJumlahRetur.DecimalValue = 0 Then
            MsgBox("Jumlah retur belum diisi")
            txtRetPaket.Focus()
            Exit Sub
        End If
        If txtTotalHargaRetur.DecimalValue = 0 Then
            MsgBox("Jumlah retur belum diisi")
            txtRetPaket.Focus()
            Exit Sub
        End If
        For barisGrid As Integer = 0 To gridDetailObat.RowCount - 1
            If noidBarang = gridDetailObat.Rows(barisGrid).Cells("noid").Value Then
                MsgBox("Obat ini sudah dientry")
                kosongkanDetail()
                txtKodeObat.Focus()
                Exit Sub
            End If
        Next
        addBarang()
        AturGriddetailBarang()
        kosongkanDetail()
        txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
        btnSimpan.Enabled = True
        cmbPkt.Focus()
    End Sub

    Private Sub cmbPkt_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cmbPkt.KeyPress
        If e.KeyChar = Chr(13) Then
            txtKodeObat.Focus()
        End If
    End Sub

    Private Sub gridPasien_KeyPress(sender As Object, e As KeyPressEventArgs) Handles gridPasien.KeyPress
        If e.KeyChar = Chr(13) Then
            Dim i = gridPasien.CurrentRow.Index - 1
            If Not IsDBNull(gridPasien.Rows(i).Cells(1).Value) Then
                txtNoReg.Text = gridPasien.Rows(i).Cells(2).Value
                txtRM.Text = gridPasien.Rows(i).Cells(3).Value
                txtNamaPasien.Text = gridPasien.Rows(i).Cells(4).Value
                txtJnsRawat.Text = gridPasien.Rows(i).Cells("jns_rawat").Value
                If IsDBNull(gridPasien.Rows(i).Cells(7).Value) Then
                    kdPenjamin = "UMUM"
                Else
                    kdPenjamin = gridPasien.Rows(i).Cells(7).Value
                End If
                cmbPenjamin.Text = kdPenjamin
                PanelPasien.Visible = False
                detailPasien()
                btnBaru.Enabled = True
            End If
        End If
    End Sub

    Private Sub txtCariPasien_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCariPasien.KeyDown
        If e.KeyCode = Keys.Down Then
            gridPasien.Focus()
        End If
    End Sub

    Private Sub txtCariPasien_TextChanged(sender As Object, e As EventArgs) Handles txtCariPasien.TextChanged
        If rRm.Checked = True Then
            BDDataPasien.Filter = "no_RM like '%" & txtCariPasien.Text & "%'"
        Else
            BDDataPasien.Filter = "nama_pasien like '%" & txtCariPasien.Text & "%'"
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelBarang.Visible = False
    End Sub


    Private Sub FormReturPenjualan_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelPasien.Top = txtNoReg.Top + 21
        PanelPasien.Left = txtNoReg.Left
        PanelBarang.Top = txtKodeObat.Top + 140
        PanelBarang.Left = txtKodeObat.Left
    End Sub

    Private Sub txtKodeObat_GotFocus(sender As Object, e As EventArgs) Handles txtKodeObat.GotFocus
        tampilObat()
        PanelBarang.Visible = True
        txtCariBarang.Clear()
        txtCariBarang.Focus()
    End Sub

    Private Sub txtKodeObat_Click(sender As Object, e As EventArgs) Handles txtKodeObat.Click
        tampilObat()
        PanelBarang.Visible = True
        txtCariBarang.Clear()
        txtCariBarang.Focus()
    End Sub

    Private Sub gridPasien_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridPasien.CellContentClick
        If e.ColumnIndex = 0 Then
            If Not IsDBNull(gridPasien.Rows(e.RowIndex).Cells(1).Value) Then
                txtNoReg.Text = gridPasien.Rows(e.RowIndex).Cells(2).Value
                txtRM.Text = gridPasien.Rows(e.RowIndex).Cells(3).Value
                txtNamaPasien.Text = gridPasien.Rows(e.RowIndex).Cells(4).Value
                txtJnsRawat.Text = gridPasien.Rows(e.RowIndex).Cells("jns_rawat").Value
                If IsDBNull(gridPasien.Rows(e.RowIndex).Cells(7).Value) Then
                    kdPenjamin = "UMUM"
                Else
                    kdPenjamin = gridPasien.Rows(e.RowIndex).Cells(7).Value
                End If
                cmbPenjamin.Text = kdPenjamin
                PanelPasien.Visible = False
                detailPasien()
                btnBaru.Enabled = True
            End If
        End If
    End Sub

    Private Sub gridDetailObat_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles gridDetailObat.CellFormatting
        gridDetailObat.Rows(e.RowIndex).HeaderCell.Value = CStr(e.RowIndex + 1)
    End Sub

    Private Sub txtHapusBaris_Click(sender As Object, e As EventArgs) Handles txtHapusBaris.Click
        If MessageBox.Show("Yakin Akan Dihapus?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            Try
                If gridDetailObat.CurrentRow.Index <> gridDetailObat.NewRowIndex Then
                    gridDetailObat.Rows.RemoveAt(gridDetailObat.CurrentRow.Index)
                End If
                txtQty.DecimalValue = gridDetailObat.Rows.Count() - 1
                TotalHargaRetPaket()
                TotalHargaRetNonPaket()
                TotalRetur()
                TotalDijamin()
                TotalIurPasien()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If MessageBox.Show("Data tersebut sudah benar?", "Konfirmasi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
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

            Dim sqlReturObatInap As String = ""
            NoRetur()
            TglServer()
            DTPJamAkhir.Value = TanggalServer
            Trans = CONN.BeginTransaction(IsolationLevel.ReadCommitted)
            CMD.Connection = CONN
            CMD.Transaction = Trans
            Try
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Apotek
                'konek()
                sqlReturObatInap = "insert into ap_retur_header(nota_retur, kd_kasir, nm_kasir, kd_bagian, tanggal, 
                                no_reg, no_rm, nama_pasien, umur_tahun, umur_bulan, kd_penjamin, 
                                nm_penjamin, kd_dokter, nm_dokter, jml_ret_paket, jml_ret_paket_blt, jml_ret_n_paket, 
                                jml_ret_n_paket_blt, total_retur, total_retur_blt, dijamin, dijamin_blt, iur_pasien, 
                                iur_pasien_blt, posting)
                                VALUES('" & Trim(txtNoRetur.Text) & "','" & Trim(FormLogin.LabelKode.Text) & "', 
                                '" & Trim(FormLogin.LabelNama.Text) & "', '" & pkdapo & "', 
                                '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Trim(txtNoReg.Text) & "', 
                                '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "', 
                                '" & Trim(txtUmurThn.Text) & "', '" & Trim(txtUmurBln.Text) & "', 
                                '" & Trim(kdPenjamin) & "', '" & Trim(NamaPenjamin) & "', '" & Trim(kdDokter) & "', 
                                '" & Trim(NamaDokter) & "', '" & Num_En_US(txtGrandJmlHargaRetPaket.DecimalValue) & "', 
                                '" & Num_En_US(txtGrandJmlHargaRetPaketBulat.DecimalValue) & "', 
                                '" & Num_En_US(txtGrandJmlHargaRetNonPaket.DecimalValue) & "', 
                                '" & Num_En_US(txtGrandJmlHargaRetNonPaketBulat.DecimalValue) & "', 
                                '" & Num_En_US(txtGrandTotalRetur.DecimalValue) & "', 
                                '" & Num_En_US(txtGrandTotalReturBulat.DecimalValue) & "', 
                                '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', 
                                '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "', 
                                '" & Num_En_US(txtGrandIurBayar.DecimalValue) & "', 
                                '" & Num_En_US(txtGrandIurBayarBulat.DecimalValue) & "', '1')"
                'CMD.ExecuteNonQuery()

                For i = 0 To gridDetailObat.RowCount - 2
                    'konek()
                    sqlReturObatInap = sqlReturObatInap + vbCrLf + "INSERT INTO ap_retur_detail(
                                nota_retur, kd_kasir, nm_kasir, kd_bagian, tanggal, no_reg, no_rm , nama_pasien,
                                umur_tahun, umur_bulan, kd_penjamin, nm_penjamin, urut, noid_jual_detail, kd_barang, 
                                idx_barang, nama_barang, generik, kd_jns_obat, kd_kel_obat, kd_gol_obat, 
                                kd_pabrik, rek_p, formularium, tgl_resep, nota_resep, kd_dokter, nm_dokter, 
                                hrg_ppn, jml_ret_paket, jml_ret_n_paket, total_qty, nm_satuan, jml_hrg_paket, 
                                jml_hrg_n_paket, jml_hrg_ret, dijamin, iur_pasien, posting, jns_obat) 
                                VALUES ('" & Trim(txtNoRetur.Text) & "','" & Trim(FormLogin.LabelKode.Text) & "', 
                                '" & Trim(FormLogin.LabelNama.Text) & "', '" & pkdapo & "', 
                                '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', 
                                 '" & Trim(txtNoReg.Text) & "', 
                                '" & Trim(txtRM.Text) & "', '" & Trim(txtNamaPasien.Text) & "', 
                                '" & Trim(txtUmurThn.Text) & "', '" & Trim(txtUmurBln.Text) & "', 
                                '" & Trim(kdPenjamin) & "', '" & Trim(NamaPenjamin) & "', " & i + 1 & ", 
                                '" & gridDetailObat.Rows(i).Cells("noid").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("kd_barang").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "', 
                                '" & Rep(gridDetailObat.Rows(i).Cells("nama_barang").Value) & "', 
                                '" & gridDetailObat.Rows(i).Cells("generik").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("kd_jns_obat").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("kd_kel_obat").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("kd_gol_obat").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("kdpabrik").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("rek_p").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("formularium").Value & "', 
                                '" & Format(gridDetailObat.Rows(i).Cells("tglresep").Value, "yyyy/MM/dd") & "', 
                                '" & gridDetailObat.Rows(i).Cells("notaresep").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("kddokter").Value & "', 
                                '" & gridDetailObat.Rows(i).Cells("nmdokter").Value & "', 
                                '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgppn").Value) & "', 
                                '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlretpkt").Value) & "', 
                                '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlretnpkt").Value) & "', 
                                '" & Val(gridDetailObat.Rows(i).Cells("totalqty").Value) & "', 
                                '" & gridDetailObat.Rows(i).Cells("nmsatuan").Value & "', 
                                '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgpkt").Value) & "', 
                                '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgnpkt").Value) & "', 
                                '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgret").Value) & "', 
                                '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', 
                                '" & Num_En_US(gridDetailObat.Rows(i).Cells("iurpasien").Value) & "', '1', 
                                '" & gridDetailObat.Rows(i).Cells("jns_obat").Value & "')"
                    'CMD.ExecuteNonQuery()
                Next
                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''' Trans Ke Kasir
                'konek()
                sqlReturObatInap = sqlReturObatInap + vbCrLf + "insert into resep_jual_retur(no_retur, no_rm, no_reg, jenis_rawat, tgl_retur, waktu, kd_dokter, kd_sub_unit, status_bayar, kd_kelompok_pelanggan, metode_bayar, total, user_id, user_nama, kd_sub_unit_asal, total_bulat, total_non_paket, total_non_paket_bulat, total_tunai, total_tunai_bulat, total_piutang, total_piutang_bulat)values('" & Trim(txtNoRetur.Text) & "', '" & Trim(txtRM.Text) & "', '" & Trim(txtNoReg.Text) & "', 'RI', '" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "', '" & Format(DTPJamAkhir.Value, "HH:mm:ss") & "', '" & Trim(kdDokter) & "', '" & pkdsubunit & "', 'BELUM', '0', 'KREDIT', '" & Num_En_US(txtGrandJmlHargaRetPaket.DecimalValue) & "', '" & Trim(FormLogin.LabelKode.Text) & "', '" & Trim(FormLogin.LabelNama.Text) & "','" & Trim(kdSubUnit) & "', '" & Num_En_US(txtGrandJmlHargaRetPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaket.DecimalValue) & "', '" & Num_En_US(txtGrandJmlHargaRetNonPaketBulat.DecimalValue) & "', '" & Num_En_US(txtGrandTotalRetur.DecimalValue) & "', '" & Num_En_US(txtGrandTotalReturBulat.DecimalValue) & "', '" & Num_En_US(txtGrandDijamin.DecimalValue) & "', '" & Num_En_US(txtGrandDijaminBulat.DecimalValue) & "')"
                'CMD.ExecuteNonQuery()

                For i = 0 To gridDetailObat.RowCount - 2
                    'konek()
                    sqlReturObatInap = sqlReturObatInap + vbCrLf + "INSERT INTO resep_jual_detail_retur(no_retur, idx_barang, kd_satuan_kecil, hpp, harga, jumlah, biaya_jaminan, discount_persen, discount_rupiah, tunai, piutang, tagihan, sesi_uid, nr, urutan, kd_sub_unit_asal, no_nota, status_verifikasi, status_jurnal, rek_p, kd_barang, nama_barang, status_paket)VALUES('" & Trim(txtNoRetur.Text) & "', '" & gridDetailObat.Rows(i).Cells("idx_barang").Value & "', '" & gridDetailObat.Rows(i).Cells("nmsatuan").Value & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgppn").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("hrgppn").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("totalqty").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '0', '0', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgret").Value - gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("dijamin").Value) & "', '" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlhrgret").Value) & "', '-', 'n',  " & i + 1 & ", '" & Trim(kdSubUnit) & "', '" & gridDetailObat.Rows(i).Cells("notaresep").Value & "', '0', '0', '" & gridDetailObat.Rows(i).Cells("rek_p").Value & "', '" & gridDetailObat.Rows(i).Cells("kd_barang").Value & "', '" & Rep(gridDetailObat.Rows(i).Cells("nama_barang").Value) & "', '0')"
                    'CMD.ExecuteNonQuery()
                Next

                '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''Update Stok
                If psts_stok = "1" Then
                    For i = 0 To gridDetailObat.RowCount - 2
                        sqlReturObatInap = sqlReturObatInap + vbCrLf + "UPDATE barang_farmasi SET " & memStok & "=" & memStok & "+" & Num_En_US(gridDetailObat.Rows(i).Cells("jmlretpkt").Value + gridDetailObat.Rows(i).Cells("jmlretnpkt").Value) & " WHERE kd_barang='" & Trim(gridDetailObat.Rows(i).Cells("kd_barang").Value) & "'"
                        'CMD.ExecuteNonQuery()
                    Next
                End If
                ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                CMD.CommandText = sqlReturObatInap
                CMD.ExecuteNonQuery()
                Trans.Commit()
                MsgBox("Transaksi retur berhasil disimpan", vbInformation, "Informasi")
                btnSimpan.Enabled = False
                btnCetakNota.Enabled = True
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

    Private Sub btnEx_Click(sender As Object, e As EventArgs) Handles btnEx.Click
        PanelPasien.Visible = False
    End Sub

    Private Sub txtNoRetur_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoRetur.KeyPress
        If e.KeyChar = Chr(13) Then
            txtNoReg.Focus()
        End If
    End Sub

    Private Sub txtNoReg_Click(sender As Object, e As EventArgs) Handles txtNoReg.Click
        If MenuUtama.menuPemanggil = "FormReturRawatJalan" Then
            TampilPasienRJ()
        ElseIf MenuUtama.menuPemanggil = "FormReturRawatInap" Then
            TampilPasienRI()
        End If
        PanelPasien.Visible = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub DTPTanggalTrans_KeyDown(sender As Object, e As KeyEventArgs) Handles DTPTanggalTrans.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoRetur.Focus()
        End If
    End Sub

    Private Sub FormReturPenjualan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setApo()
        Me.KeyPreview = True
        KosongkanHeader()
        NoRetur()
    End Sub

    Private Sub DTPPasienReg_KeyDown(sender As Object, e As KeyEventArgs) Handles DTPPasienReg.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCariPasien.Focus()
        End If
    End Sub

    Private Sub DTPPasienReg_ValueChanged(sender As Object, e As EventArgs) Handles DTPPasienReg.ValueChanged
        If MenuUtama.menuPemanggil = "FormReturRawatJalan" Then
            TampilPasienRJ()
        ElseIf MenuUtama.menuPemanggil = "FormReturRawatInap" Then
            TampilPasienRI()
        End If
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
        Dispose()
    End Sub

    Private Sub txtNoReg_GotFocus(sender As Object, e As EventArgs) Handles txtNoReg.GotFocus
        If MenuUtama.menuPemanggil = "FormReturRawatJalan" Then
            TampilPasienRJ()
        ElseIf MenuUtama.menuPemanggil = "FormReturRawatInap" Then
            TampilPasienRI()
        End If
        PanelPasien.Visible = True
        txtCariPasien.Clear()
        txtCariPasien.Focus()
    End Sub

    Private Sub FormReturPenjualan_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Dispose()
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

    Sub addBarang()
        cariNamaPenjamin()
        cariDokter()

        BDReturObat.DataSource = DSReturObat
        BDReturObat.DataMember = "ReturObat"

        BDReturObat.AddNew()
        DRWReturObat = BDReturObat.Current
        DRWReturObat("kdkasir") = Trim(FormLogin.LabelKode.Text)
        DRWReturObat("nmkasir") = Trim(FormLogin.LabelNama.Text)
        DRWReturObat("kdbagian") = pkdapo
        DRWReturObat("tanggal") = DTPTanggalTrans.Value
        DRWReturObat("notaretur") = Trim(txtNoRetur.Text)
        DRWReturObat("no_reg") = Trim(txtNoReg.Text)
        DRWReturObat("no_rm") = Trim(txtRM.Text)
        DRWReturObat("nmpasien") = Trim(txtNamaPasien.Text)
        DRWReturObat("umurthn") = Trim(txtUmurThn.Text)
        DRWReturObat("umurbln") = Trim(txtUmurBln.Text)
        DRWReturObat("kd_penjamin") = Trim(kdPenjamin)
        DRWReturObat("nm_penjamin") = Trim(NamaPenjamin)
        DRWReturObat("urut") = 1
        DRWReturObat("noid") = Trim(noidBarang)
        DRWReturObat("kd_barang") = Trim(txtKodeObat.Text)
        DRWReturObat("idx_barang") = Trim(txtIdxBarang.Text)
        DRWReturObat("nama_barang") = Trim(lblNamaObat.Text)
        DRWReturObat("generik") = Trim(Generik)
        DRWReturObat("kd_jns_obat") = Trim(kdJnsObat)
        DRWReturObat("kd_gol_obat") = Trim(kdGolObat)
        DRWReturObat("kd_kel_obat") = Trim(KdKelObat)
        DRWReturObat("kdpabrik") = Trim(kdPabrik)
        DRWReturObat("rek_p") = Trim(Rekening)
        DRWReturObat("formularium") = Trim(Formularium)
        DRWReturObat("tglresep") = DTPTanggalResep.Value
        DRWReturObat("notaresep") = Trim(txtNotaResep.Text)
        DRWReturObat("kddokter") = Trim(kdDokter)
        DRWReturObat("nmdokter") = Trim(NamaDokter)
        DRWReturObat("hrgppn") = txtHarga.DecimalValue
        DRWReturObat("jmlretpkt") = txtRetPaket.DecimalValue
        DRWReturObat("jmlretnpkt") = txtRetNonPaket.DecimalValue
        DRWReturObat("totalqty") = txtJumlahRetur.DecimalValue
        DRWReturObat("nmsatuan") = Trim(txtSatuan.Text)
        DRWReturObat("jmlhrgpkt") = txtJmlHargaPaket.DecimalValue
        DRWReturObat("jmlhrgnpkt") = txtJmlHargaNonPaket.DecimalValue
        DRWReturObat("jmlhrgret") = txtTotalHargaRetur.DecimalValue
        DRWReturObat("dijamin") = txtDijamin.DecimalValue
        DRWReturObat("iurpasien") = txtIurPasien.DecimalValue
        DRWReturObat("jns_obat") = Trim(JenisObat)

        BDReturObat.EndEdit()

        gridDetailObat.DataSource = Nothing
        gridDetailObat.DataSource = BDReturObat

        TotalHargaRetPaket()
        TotalHargaRetNonPaket()
        TotalRetur()
        TotalDijamin()
        TotalIurPasien()
    End Sub

    Sub AturGriddetailBarang()
        With gridDetailObat
            .Columns(0).HeaderText = "No"
            .Columns(1).HeaderText = "Nama Barang"
            .Columns(2).HeaderText = "Harga"
            .Columns(2).DefaultCellStyle.Format = "N2"
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).HeaderText = "Jumlah Retur Paket"
            .Columns(3).DefaultCellStyle.Format = "N2"
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).HeaderText = "Jumlah Retur Non Paket"
            .Columns(4).DefaultCellStyle.Format = "N2"
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).HeaderText = "Total Qty Retur"
            .Columns(5).DefaultCellStyle.Format = "N2"
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(5).DefaultCellStyle.BackColor = Color.LightYellow
            .Columns(6).HeaderText = "Satuan"
            .Columns(7).HeaderText = "Jumlah Harga Retur Paket"
            .Columns(7).DefaultCellStyle.Format = "N2"
            .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(8).HeaderText = "Jumlah Harga Retur Non Paket"
            .Columns(8).DefaultCellStyle.Format = "N2"
            .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).HeaderText = "Total Harga Retur"
            .Columns(9).DefaultCellStyle.Format = "N2"
            .Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(9).DefaultCellStyle.BackColor = Color.LightYellow
            .Columns(10).HeaderText = "Dijamin"
            .Columns(10).DefaultCellStyle.Format = "N2"
            .Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(11).HeaderText = "Iur Pasien"
            .Columns(11).DefaultCellStyle.Format = "N2"
            .Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(0).Width = 40
            .Columns(1).Width = 275
            .Columns(2).Width = 90
            .Columns(3).Width = 50
            .Columns(4).Width = 50
            .Columns(5).Width = 50
            .Columns(6).Width = 65
            .Columns(7).Width = 90
            .Columns(8).Width = 90
            .Columns(9).Width = 90
            .Columns(10).Width = 90
            .Columns(11).Width = 90
            .Columns(0).Visible = False
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

    Sub TotalIurPasien()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("iurpasien").Value
        Next
        txtGrandIurBayar.DecimalValue = HitungTotal
        txtGrandIurBayarBulat.DecimalValue = buletin(txtGrandIurBayar.DecimalValue, 100)
    End Sub

    Sub TotalDijamin()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("dijamin").Value
        Next
        txtGrandDijamin.DecimalValue = HitungTotal
        txtGrandDijaminBulat.DecimalValue = buletin(txtGrandDijamin.DecimalValue, 100)
    End Sub

    Sub TotalRetur()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("jmlhrgret").Value
        Next
        txtGrandTotalRetur.DecimalValue = HitungTotal
        txtGrandTotalReturBulat.DecimalValue = buletin(txtGrandTotalRetur.DecimalValue, 100)
        bilang = Terbilang(txtGrandTotalReturBulat.DecimalValue)
    End Sub

    Sub TotalHargaRetNonPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("jmlhrgnpkt").Value
        Next
        txtGrandJmlHargaRetNonPaket.DecimalValue = HitungTotal
        txtGrandJmlHargaRetNonPaketBulat.DecimalValue = buletin(txtGrandJmlHargaRetNonPaket.DecimalValue, 100)
    End Sub

    Sub TotalHargaRetPaket()
        Dim HitungTotal As Decimal = 0
        For baris As Integer = 0 To gridDetailObat.RowCount - 1
            HitungTotal = HitungTotal + gridDetailObat.Rows(baris).Cells("jmlhrgpkt").Value
        Next
        txtGrandJmlHargaRetPaket.DecimalValue = HitungTotal
        txtGrandJmlHargaRetPaketBulat.DecimalValue = buletin(txtGrandJmlHargaRetPaket.DecimalValue, 100)
    End Sub

    Sub cariNamaPenjamin()
        Dim cari As String = InStr(cmbPenjamin.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(cmbPenjamin.Text, "|", -1, CompareMethod.Binary)
            NamaPenjamin = (ary(0))
            'kdPenjamin = (ary(1))
        End If
    End Sub

    Sub cariDokter()
        Dim cari As String = InStr(CmbDokterResep.Text, "|")
        If cari Then
            Dim ary As String() = Nothing
            ary = Strings.Split(CmbDokterResep.Text, "|", -1, CompareMethod.Binary)
            NamaDokter = (ary(0))
            kdDokter = (ary(1))
        End If
    End Sub

    Sub detailObat()
        Try
            CMD = New OleDb.OleDbCommand("select * FROM ap_jualr2 WHERE no_reg='" & txtNoReg.Text & "' AND  noid='" & noidBarang & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                txtIdxBarang.Text = Trim(DT.Rows(0).Item("idx_barang"))
                txtKodeObat.Text = Trim(DT.Rows(0).Item("kd_barang"))
                lblNamaObat.Text = Trim(DT.Rows(0).Item("nama_barang"))
                txtHarga.DecimalValue = DT.Rows(0).Item("hrgbeli")
                DTPTanggalResep.Value = DT.Rows(0).Item("tanggal")
                txtNotaResep.Text = Trim(DT.Rows(0).Item("notaresep"))
                CmbDokterResep.Text = Trim(DT.Rows(0).Item("nmdokter")) & "|" & Trim(DT.Rows(0).Item("kddokter"))
                txtJmlPaket.DecimalValue = DT.Rows(0).Item("jmlpaket")
                txtJmlNonPaket.DecimalValue = DT.Rows(0).Item("jmlnonpaket")
                txtTotalQty.DecimalValue = DT.Rows(0).Item("jml")
                txtSatuan.Text = Trim(DT.Rows(0).Item("nmsatuan"))
                txtJmlResepAwal.DecimalValue = Trim(DT.Rows(0).Item("jmlnet"))
                txtDijaminResepAwal.DecimalValue = DT.Rows(0).Item("dijamin")
                txtIurResepAwal.DecimalValue = DT.Rows(0).Item("sisabayar")
            End If

            CMD = New OleDb.OleDbCommand("select * FROM barang_farmasi WHERE kd_barang='" & txtKodeObat.Text & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                Generik = Trim(DT.Rows(0).Item("generik"))
                kdJnsObat = Trim(DT.Rows(0).Item("kd_jns_obat"))
                KdKelObat = Trim(DT.Rows(0).Item("kd_kel_obat"))
                kdGolObat = Trim(DT.Rows(0).Item("kd_gol_obat"))
                kdPabrik = Trim(DT.Rows(0).Item("kdpabrik"))
                Formularium = Trim(DT.Rows(0).Item("formularium"))

            End If
            CMD = New OleDb.OleDbCommand("select * FROM jenis_obat WHERE kd_jns_obat='" & kdJnsObat & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If DT.Rows.Count > 0 Then
                JenisObat = Trim(DT.Rows(0).Item("jns_obat"))
                Rekening = Trim(DT.Rows(0).Item("rek_p"))
            End If
            txtRetPaket.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub tampilObat()
        Try
            DA = New OleDbDataAdapter("SELECT noid, tanggal, notaresep, LTRIM(RTRIM(nmdokter)), 
                     LTRIM(RTRIM(nama_barang)) as nama_barang, jmlpaket, jmlnonpaket, jml, 
                     LTRIM(RTRIM(nmsatuan)) FROM ap_jualr2 WHERE no_reg='" & txtNoReg.Text & "' 
                     ORDER BY tanggal, notaresep, noid", CONN)
            DS = New DataSet
            DA.Fill(DS, "ObatRJ")
            BDObat.DataSource = DS
            BDObat.DataMember = "ObatRJ"
            With gridBarang
                .DataSource = Nothing
                .DataSource = BDObat
                .Columns(1).HeaderText = "NOID"
                .Columns(2).HeaderText = "Tanggal Resep"
                .Columns(3).HeaderText = "Nota Resep"
                .Columns(4).HeaderText = "Nama Dokter"
                .Columns(5).HeaderText = "Nama Barang"
                .Columns(6).HeaderText = "Jumlah Paket"
                .Columns(6).DefaultCellStyle.Format = "N2"
                .Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(7).HeaderText = "Jumlah Non Paket"
                .Columns(7).DefaultCellStyle.Format = "N2"
                .Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(8).HeaderText = "Total Qty"
                .Columns(8).DefaultCellStyle.Format = "N2"
                .Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(9).HeaderText = "Satuan"
                .Columns(0).Width = 30
                .Columns(2).Width = 75
                .Columns(3).Width = 90
                .Columns(4).Width = 150
                .Columns(5).Width = 130
                .Columns(6).Width = 50
                .Columns(7).Width = 50
                .Columns(8).Width = 50
                .Columns(9).Width = 90
                .Columns(1).Visible = False
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            lblKetDaftar.Text = "Daftar Pasien Rawat Jalan"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub detailPasien()
        'Data Diri Pasien
        CMD = New OleDbCommand("SELECT Pasien.alamat, Pasien.RT, Pasien.RW, Kelurahan.nama_kelurahan,
                    Kecamatan.nama_kecamatan, Kabupaten.nama_kabupaten, Propinsi.nama_propinsi, 
                    pasien.nama_pasien, case pasien.jns_kel when '0' then 'P' else 'L' end as jns_kel, 
                    pasien.tgl_lahir
                    FROM Pasien 
                    INNER JOIN Kelurahan ON Pasien.kd_kelurahan = Kelurahan.kd_kelurahan 
                    INNER JOIN Kecamatan ON Kelurahan.kd_kecamatan = Kecamatan.kd_kecamatan 
                    INNER JOIN Kabupaten ON Kecamatan.kd_kabupaten = Kabupaten.kd_kabupaten 
                    INNER JOIN Propinsi ON Kabupaten.kd_propinsi = Propinsi.kd_propinsi 
                    WHERE Pasien.no_RM='" & txtRM.Text & "'", CONN)
        DA = New OleDbDataAdapter(CMD)
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

        'Penjamin
        CMD = New OleDbCommand("SELECT kd_penjamin,nama_penjamin FROM penjamin WHERE kd_penjamin='" & kdPenjamin & "'", CONN)
        DA = New OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            cmbPenjamin.Text = DT.Rows(0).Item("nama_penjamin") & "|" & DT.Rows(0).Item("kd_penjamin")
        Else
            cmbPenjamin.Text = "-|UMUM"
        End If

        If MenuUtama.menuPemanggil = "FormReturRawatInap" Then
            'Dokter
            CMD = New OleDb.OleDbCommand("SELECT no_reg, kd_dokter, kd_tempat_tidur FROM rawat_inap WHERE no_reg='" & txtNoReg.Text & "'", CONN)
            DA = New OleDb.OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            kdRuangPoli = DT.Rows(0).Item("kd_tempat_tidur")
            kdDokter = DT.Rows(0).Item("kd_dokter")
        ElseIf MenuUtama.menuPemanggil = "FormReturRawatJalan" Then
            'Dokter
            CMD = New OleDbCommand("SELECT no_reg, kd_dokter, kd_poliklinik FROM rawat_jalan WHERE no_reg='" & txtNoReg.Text & "'", CONN)
            DA = New OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            kdRuangPoli = DT.Rows(0).Item("kd_poliklinik")
            kdDokter = DT.Rows(0).Item("kd_dokter")
        End If

        CMD = New OleDbCommand("select kd_pegawai, nama_pegawai from pegawai where kd_pegawai='" & kdDokter & "'", CONN)
        DA = New OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            cmbDokter.Text = DT.Rows(0).Item("nama_pegawai") & "| " & DT.Rows(0).Item("kd_pegawai")
        End If

        CMD = New OleDbCommand("select Sub_Unit.nama_sub_unit, Sub_Unit.kd_sub_unit from sub_unit 
                            where kd_sub_unit='" & kdRuangPoli & "'", CONN)
        DA = New OleDbDataAdapter(CMD)
        DT = New DataTable
        DA.Fill(DT)
        If DT.Rows.Count > 0 Then
            cmbUnitAsal.Text = DT.Rows(0).Item("nama_sub_unit") & "| " & DT.Rows(0).Item("kd_sub_unit")
        End If
        cmbPkt.SelectedIndex = 0
        cmbPkt.Focus()
    End Sub

    Sub TampilPasienRJ()
        Try
            DA = New OleDbDataAdapter("SELECT 
                    reg.tgl_reg, 
                    reg.no_reg, 
                    reg.no_RM, 
                    LTRIM(RTRIM(pas.nama_pasien)) as nama_pasien, 
                    sub.nama_sub_unit, 
                    CASE WHEN reg.jns_rawat = 1 then 'Rawat Jalan' ELSE 'Rawat Inap' END as jns_rawat, 
                    reg.kd_penjamin 
                    FROM Registrasi as Reg
                    INNER JOIN Pasien as pas ON reg.no_RM = pas.no_RM 
                    INNER JOIN Rawat_Jalan as rj ON reg.no_reg = rj.no_reg 
                    INNER JOIN Sub_Unit as sub ON rj.kd_poliklinik = sub.kd_sub_unit
                    WHERE reg.jns_rawat='" & jenisRawat & "' AND reg.status_keluar<>2 AND reg.tgl_reg = '" & Format(DTPPasienReg.Value, "yyyy/MM/dd") & "'
                    ORDER BY reg.tgl_reg Desc", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasienRJ")
            BDDataPasien.DataSource = DS
            BDDataPasien.DataMember = "pasienRJ"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDDataPasien
                .Columns(1).HeaderText = "Tanggal Daftar"
                .Columns(2).HeaderText = "No Registrasi"
                .Columns(3).HeaderText = "No RM"
                .Columns(4).HeaderText = "Nama Pasien"
                .Columns(5).HeaderText = "Ruang"
                .Columns(0).Width = 30
                .Columns(1).Width = 75
                .Columns(2).Width = 90
                .Columns(3).Width = 50
                .Columns(4).Width = 130
                .Columns(5).Width = 120
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            lblKetDaftar.Text = "Daftar Pasien Rawat Jalan"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub TampilPasienRI()
        Try
            DA = New OleDb.OleDbDataAdapter("SELECT 
                    reg.tgl_reg, 
                    reg.no_reg, 
                    reg.no_RM, 
                    LTRIM(RTRIM(pas.nama_pasien)) as nama_pasien, 
                    su.nama_sub_unit, 
                    reg.jns_rawat, 
                    reg.kd_penjamin 
                    FROM  Registrasi as reg
                    INNER JOIN Pasien as pas ON reg.no_RM = pas.no_RM 
                    INNER JOIN Rawat_Inap ri ON reg.no_reg = ri.no_reg 
                    INNER JOIN Tempat_Tidur tt ON ri.kd_tempat_tidur = tt.kd_tempat_tidur 
                    INNER JOIN Kamar kam ON tt.kd_kamar = kam.kd_kamar 
                    INNER JOIN Sub_Unit su ON kam.kd_sub_unit = su.kd_sub_unit 
                    WHERE reg.jns_rawat='" & jenisRawat & "' AND reg.status_keluar<>2 AND reg.tgl_reg = '" & Format(DTPPasienReg.Value, "yyyy/MM/dd") & "'
                    ORDER BY reg.tgl_reg Desc", CONN)
            DS = New DataSet
            DA.Fill(DS, "pasienRI")
            BDDataPasien.DataSource = DS
            BDDataPasien.DataMember = "pasienRI"
            With gridPasien
                .DataSource = Nothing
                .DataSource = BDDataPasien
                .Columns(1).HeaderText = "Tanggal Daftar"
                .Columns(2).HeaderText = "No Registrasi"
                .Columns(3).HeaderText = "No RM"
                .Columns(4).HeaderText = "Nama Pasien"
                .Columns(5).HeaderText = "Ruang"
                .Columns(0).Width = 30
                .Columns(1).Width = 75
                .Columns(2).Width = 90
                .Columns(3).Width = 50
                .Columns(4).Width = 130
                .Columns(5).Width = 120
                .Columns(6).Visible = False
                .Columns(7).Visible = False
                .BackgroundColor = Color.Azure
                .DefaultCellStyle.SelectionBackColor = Color.LightBlue
                .DefaultCellStyle.SelectionForeColor = Color.Black
                .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
                .ColumnHeadersDefaultCellStyle.BackColor = Color.Black
                .RowHeadersDefaultCellStyle.BackColor = Color.Black
                .ReadOnly = True
            End With
            lblKetDaftar.Text = "Daftar Pasien Rawat Inap Dalam Perawatan"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub KosongkanHeader()
        TglServer()
        DSReturObat = Table.BuatTabelReturObatRJ("ReturObat")
        gridDetailObat.BackgroundColor = Color.Azure
        DSReturObat.Clear()
        gridDetailObat.DataSource = Nothing
        btnSimpan.Enabled = False
        btnCetakNota.Enabled = False
        btnBaru.Enabled = False
        DTPTanggalTrans.Value = TanggalServer
        DTPPasienReg.Value = TanggalServer
        txtNoRetur.Clear()
        txtNoReg.Clear()
        txtJnsRawat.Clear()
        txtRM.Clear()
        txtSex.Clear()
        txtUmurBln.Clear()
        txtUmurThn.Clear()
        txtNamaPasien.Clear()
        txtAlamat.Clear()
        cmbUnitAsal.Text = ""
        cmbPenjamin.Text = ""
        cmbDokter.Text = ""
        cmbPkt.SelectedIndex = 0
        txtGrandJmlHargaRetPaket.DecimalValue = 0
        txtGrandJmlHargaRetPaketBulat.DecimalValue = 0
        txtGrandJmlHargaRetNonPaket.DecimalValue = 0
        txtGrandJmlHargaRetNonPaketBulat.DecimalValue = 0
        txtGrandTotalRetur.DecimalValue = 0
        txtGrandTotalReturBulat.DecimalValue = 0
        txtGrandDijamin.DecimalValue = 0
        txtGrandDijaminBulat.DecimalValue = 0
        txtGrandIurBayar.DecimalValue = 0
        txtGrandIurBayarBulat.DecimalValue = 0
        txtQty.DecimalValue = 0
        If MenuUtama.menuPemanggil = "FormReturRawatJalan" Then
            jenisRawat = 1
            Me.Text = "Retur Obat Pasien Rawat Jalan"
        ElseIf MenuUtama.menuPemanggil = "FormReturRawatInap" Then
            Me.Text = "Retur Obat Pasien Rawat Inap"
            jenisRawat = 2
        End If
        txtNoRetur.Focus()
    End Sub

    Sub kosongkanDetail()
        TglServer()
        lblNamaObat.Text = ""
        txtKodeObat.Clear()
        txtIdxBarang.Clear()
        DTPTanggalResep.Value = TanggalServer
        txtNotaResep.Clear()
        CmbDokterResep.Text = ""
        txtJmlPaket.DecimalValue = 0
        txtJmlNonPaket.DecimalValue = 0
        txtTotalQty.DecimalValue = 0
        txtJmlResepAwal.DecimalValue = 0
        txtDijaminResepAwal.DecimalValue = 0
        txtIurResepAwal.DecimalValue = 0
        txtHarga.DecimalValue = 0
        txtRetPaket.DecimalValue = 0
        txtRetNonPaket.DecimalValue = 0
        txtJumlahRetur.DecimalValue = 0
        txtSatuan.Clear()
        txtJmlHargaPaket.DecimalValue = 0
        txtJmlHargaNonPaket.DecimalValue = 0
        txtTotalHargaRetur.DecimalValue = 0
        txtDijamin.DecimalValue = 0
        txtIurPasien.DecimalValue = 0
    End Sub

    Sub NoRetur()
        Try
            CMD = New OleDbCommand("select max(nota_retur) as nota_retur from ap_retur_header where tanggal='" & Format(DTPTanggalTrans.Value, "yyyy/MM/dd") & "' and kd_bagian='" & pkdapo & "'", CONN)
            DA = New OleDbDataAdapter(CMD)
            DT = New DataTable
            DA.Fill(DT)
            If IsDBNull(DT.Rows(0).Item("nota_retur")) Then
                txtNoRetur.Text = pkdapo + "-" + "RT" + Format(DTPTanggalTrans.Value, "ddMMyy") + "001"
            Else
                txtNoRetur.Text = Microsoft.VisualBasic.Right(DT.Rows(0).Item("nota_retur").ToString, 3) + 1
                If Len(txtNoRetur.Text) = 1 Then
                    txtNoRetur.Text = pkdapo + "-" + "RT" + Format(DTPTanggalTrans.Value, "ddMMyy") + "00" & txtNoRetur.Text & ""
                ElseIf Len(txtNoRetur.Text) = 2 Then
                    txtNoRetur.Text = pkdapo + "-" + "RT" + Format(DTPTanggalTrans.Value, "ddMMyy") + "0" & txtNoRetur.Text & ""
                ElseIf Len(txtNoRetur.Text) = 3 Then
                    txtNoRetur.Text = pkdapo + "-" + "RT" + Format(DTPTanggalTrans.Value, "ddMMyy") + "" & txtNoRetur.Text & ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormReturPenjualan_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dispose()
    End Sub
End Class