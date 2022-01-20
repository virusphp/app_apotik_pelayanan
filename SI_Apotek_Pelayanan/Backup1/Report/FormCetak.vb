Imports Syncfusion.Windows.Forms
Imports Syncfusion.Windows.Forms.Tools
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormCetak
    Inherits Office2010Form

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If FormPemanggil = "FormEditPenjualanNonResep" Then
            Try
                FormEditPenjualanNonResep.rpt.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormPenjualanNonResep" Then
            Try
                FormPenjualanNonResep.rpt.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormPenjualanResepEMR_Nota" Then
            Try
                FormPenjualanResepEMR.rptNota.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormPenjualanResepEMR_BPJS" Then
            Try
                FormPenjualanResepEMR.rptBPJS.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormEditPenjualanResepEMR_Nota" Then
            Try
                FormEditPenjualanResepEMR.rptNota.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormEditPenjualanResepEMR_BPJS" Then
            Try
                FormEditPenjualanResepEMR.rptBPJS.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormPenjualanResep_Nota" Then
            Try
                FormPenjualanResep.rptNota.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormPenjualanResep_Lain" Then
            Try
                FormPenjualanResep.rptLain.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormEditPenjualanResep_Nota" Then
            Try
                FormEditPenjualanResep.rptNota.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormEditStatusPenjualanResep_Nota" Then
            Try
                FormEditStatusBayar.rptNota.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormEditPenjualanResep_BPJS" Then
            Try
                FormEditPenjualanResep.rptBPJS.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormEditPenjualanResep_Lain" Then
            Try
                FormEditPenjualanResep.rptLain.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormEditStatusBayar" Then
            Try
                FormEditStatusBayar.rptNota.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormEditStatusBayar_BPJS" Then
            Try
                FormEditStatusBayar.rptBPJS.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormEditStatusBayar_Lain" Then
            Try
                FormEditStatusBayar.rptLain.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        ElseIf FormPemanggil = "FormEditReturRI" Then
            Try
                FormEditReturRI.rpt.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormReturRI" Then
            Try
                FormReturRI.rpt.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormPermintaanKeGudang" Then
            Try
                FormPermintaanKeGudang.rpt.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormLaporanPermintaanBarangKeGudang_PerTanggal" Then
            Try
                FormLaporanPermintaanBarangKeGudang.rptPerTanggal.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormLaporanPermintaanBarangKeGudang_PerUnit" Then
            Try
                FormLaporanPermintaanBarangKeGudang.rptPerUnit.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormLaporanPermintaanBarangKeGudang_PerBarang" Then
            Try
                FormLaporanPermintaanBarangKeGudang.rptPerBarang.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormLaporanPermintaanBarangKeGudang_PerTanggalUnit" Then
            Try
                FormLaporanPermintaanBarangKeGudang.rptPerUnitTanggal.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormLaporanRealisasi_PerTanggal" Then
            Try
                FormLaporanRealisasiPermintaan.rptPerTanggal.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormLaporanRealisasiPermintaan_PerUnit" Then
            Try
                FormLaporanRealisasiPermintaan.rptPerUnit.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormLaporanRealisasiPermintaan_PerBarang" Then
            Try
                FormLaporanRealisasiPermintaan.rptPerBarang.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormLaporanRealisasiPermintaan_PerNoPermintaan" Then
            Try
                FormLaporanRealisasiPermintaan.rptPerNoPermintaan.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormLaporanRealisasiPermintaan_PerBulan" Then
            Try
                FormLaporanRealisasiPermintaan.rptPerBulan.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormPermintaanGudangBPJSKeGudang" Then
            Try
                FormPermintaanGudangBPJSKeGudang.rpt.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormMutasiAntarUnit" Then
            Try
                FormMutasiAntarUnit.rpt.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormStokPerbulan_StokBarang1" Then
            Try
                FormStokPerbulan.rptdok.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormStokPerbulan_StokBarang2" Then
            Try
                FormStokPerbulan.rpt.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormKartuStok" Then
            Try
                FormKartuStok.rpt.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        ElseIf FormPemanggil = "FormResep_Permintaan_Dokter" Then
            Try
                FormPenjualanResepEMR.rptResepDokter.PrintToPrinter(1, False, 0, 0)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Else
            MsgBox("Belum disetting", vbInformation, "Informasi")
        End If
        btnPrint.Enabled = False
    End Sub

    Private Sub FormCetak_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F9 Then
            btnPrint.PerformClick()
        End If
    End Sub

    Private Sub FormCetak_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.KeyPreview = True
        btnPrint.Enabled = True
    End Sub
End Class