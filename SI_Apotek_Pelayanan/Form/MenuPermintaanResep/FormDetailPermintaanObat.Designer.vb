<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDetailPermintaanObat
    Inherits Syncfusion.Windows.Forms.Office2010Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBanyakIterasi = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtIterasi = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtPoliklinik = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNamaDokter = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNamaPasien = New System.Windows.Forms.TextBox()
        Me.txtRM = New System.Windows.Forms.TextBox()
        Me.txtNoPermintaan = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gridObatJadi = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.gridObatRacikan = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnBatalTelaah = New System.Windows.Forms.Button()
        Me.lstPengkajianResep = New System.Windows.Forms.CheckedListBox()
        Me.btnSimpanTelaah = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtKeteranganTindakan = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridObatJadi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.gridObatRacikan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.txtBanyakIterasi)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtIterasi)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtPoliklinik)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtNamaDokter)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtNamaPasien)
        Me.GroupBox1.Controls.Add(Me.txtRM)
        Me.GroupBox1.Controls.Add(Me.txtNoPermintaan)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1200, 85)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtBanyakIterasi
        '
        Me.txtBanyakIterasi.Enabled = False
        Me.txtBanyakIterasi.Location = New System.Drawing.Point(560, 58)
        Me.txtBanyakIterasi.Name = "txtBanyakIterasi"
        Me.txtBanyakIterasi.Size = New System.Drawing.Size(85, 20)
        Me.txtBanyakIterasi.TabIndex = 13
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(482, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = "Jumlah Iterasi"
        '
        'txtIterasi
        '
        Me.txtIterasi.Enabled = False
        Me.txtIterasi.Location = New System.Drawing.Point(427, 58)
        Me.txtIterasi.Name = "txtIterasi"
        Me.txtIterasi.Size = New System.Drawing.Size(44, 20)
        Me.txtIterasi.TabIndex = 11
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(334, 61)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Iterasi"
        '
        'txtPoliklinik
        '
        Me.txtPoliklinik.Enabled = False
        Me.txtPoliklinik.Location = New System.Drawing.Point(427, 35)
        Me.txtPoliklinik.Name = "txtPoliklinik"
        Me.txtPoliklinik.Size = New System.Drawing.Size(218, 20)
        Me.txtPoliklinik.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(334, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Poliklinik"
        '
        'txtNamaDokter
        '
        Me.txtNamaDokter.Enabled = False
        Me.txtNamaDokter.Location = New System.Drawing.Point(427, 12)
        Me.txtNamaDokter.Name = "txtNamaDokter"
        Me.txtNamaDokter.Size = New System.Drawing.Size(218, 20)
        Me.txtNamaDokter.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(334, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Nama Dokter"
        '
        'txtNamaPasien
        '
        Me.txtNamaPasien.Enabled = False
        Me.txtNamaPasien.Location = New System.Drawing.Point(100, 58)
        Me.txtNamaPasien.Name = "txtNamaPasien"
        Me.txtNamaPasien.Size = New System.Drawing.Size(218, 20)
        Me.txtNamaPasien.TabIndex = 5
        '
        'txtRM
        '
        Me.txtRM.Enabled = False
        Me.txtRM.Location = New System.Drawing.Point(100, 35)
        Me.txtRM.Name = "txtRM"
        Me.txtRM.Size = New System.Drawing.Size(218, 20)
        Me.txtRM.TabIndex = 4
        '
        'txtNoPermintaan
        '
        Me.txtNoPermintaan.Enabled = False
        Me.txtNoPermintaan.Location = New System.Drawing.Point(100, 12)
        Me.txtNoPermintaan.Name = "txtNoPermintaan"
        Me.txtNoPermintaan.Size = New System.Drawing.Size(218, 20)
        Me.txtNoPermintaan.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Nama Pasien"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "No RM"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "No Permintaan"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Controls.Add(Me.gridObatJadi)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(1, 88)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(828, 223)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        Me.GroupBox2.Text = "OBAT NON RACIK"
        '
        'gridObatJadi
        '
        Me.gridObatJadi.AllowUserToAddRows = False
        Me.gridObatJadi.AllowUserToDeleteRows = False
        Me.gridObatJadi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridObatJadi.Location = New System.Drawing.Point(6, 15)
        Me.gridObatJadi.Name = "gridObatJadi"
        Me.gridObatJadi.Size = New System.Drawing.Size(816, 202)
        Me.gridObatJadi.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox3.Controls.Add(Me.gridObatRacikan)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(0, 317)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(829, 244)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "OBAT RACIK"
        '
        'gridObatRacikan
        '
        Me.gridObatRacikan.AllowUserToAddRows = False
        Me.gridObatRacikan.AllowUserToDeleteRows = False
        Me.gridObatRacikan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridObatRacikan.Location = New System.Drawing.Point(4, 19)
        Me.gridObatRacikan.Name = "gridObatRacikan"
        Me.gridObatRacikan.Size = New System.Drawing.Size(819, 222)
        Me.gridObatRacikan.TabIndex = 2
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox4.Controls.Add(Me.lstPengkajianResep)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(835, 87)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(365, 297)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "TELAAH RESEP"
        '
        'btnBatalTelaah
        '
        Me.btnBatalTelaah.Location = New System.Drawing.Point(1027, 494)
        Me.btnBatalTelaah.Name = "btnBatalTelaah"
        Me.btnBatalTelaah.Size = New System.Drawing.Size(172, 68)
        Me.btnBatalTelaah.TabIndex = 4
        Me.btnBatalTelaah.Text = "BATAL"
        Me.btnBatalTelaah.UseVisualStyleBackColor = True
        '
        'lstPengkajianResep
        '
        Me.lstPengkajianResep.FormattingEnabled = True
        Me.lstPengkajianResep.Location = New System.Drawing.Point(8, 16)
        Me.lstPengkajianResep.Name = "lstPengkajianResep"
        Me.lstPengkajianResep.Size = New System.Drawing.Size(351, 274)
        Me.lstPengkajianResep.TabIndex = 804
        '
        'btnSimpanTelaah
        '
        Me.btnSimpanTelaah.Location = New System.Drawing.Point(836, 494)
        Me.btnSimpanTelaah.Name = "btnSimpanTelaah"
        Me.btnSimpanTelaah.Size = New System.Drawing.Size(172, 68)
        Me.btnSimpanTelaah.TabIndex = 4
        Me.btnSimpanTelaah.Text = "SIMPAN"
        Me.btnSimpanTelaah.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox5.Controls.Add(Me.txtKeteranganTindakan)
        Me.GroupBox5.Controls.Add(Me.Button1)
        Me.GroupBox5.Controls.Add(Me.Button2)
        Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox5.Location = New System.Drawing.Point(835, 390)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(365, 98)
        Me.GroupBox5.TabIndex = 806
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "KETERANGAN"
        '
        'txtKeteranganTindakan
        '
        Me.txtKeteranganTindakan.Location = New System.Drawing.Point(6, 19)
        Me.txtKeteranganTindakan.Name = "txtKeteranganTindakan"
        Me.txtKeteranganTindakan.Size = New System.Drawing.Size(353, 73)
        Me.txtKeteranganTindakan.TabIndex = 5
        Me.txtKeteranganTindakan.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(190, 400)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(172, 68)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "BATAL"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(6, 400)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(172, 68)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "SIMPAN"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'FormDetailPermintaanObat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1200, 566)
        Me.Controls.Add(Me.btnBatalTelaah)
        Me.Controls.Add(Me.btnSimpanTelaah)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormDetailPermintaanObat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Permintaan Obat"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gridObatJadi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.gridObatRacikan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents gridObatJadi As System.Windows.Forms.DataGridView
    Friend WithEvents gridObatRacikan As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNamaPasien As System.Windows.Forms.TextBox
    Friend WithEvents txtRM As System.Windows.Forms.TextBox
    Friend WithEvents txtNoPermintaan As System.Windows.Forms.TextBox
    Friend WithEvents txtBanyakIterasi As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtIterasi As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtPoliklinik As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtNamaDokter As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents btnBatalTelaah As Button
    Public WithEvents lstPengkajianResep As CheckedListBox
    Friend WithEvents btnSimpanTelaah As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents txtKeteranganTindakan As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
End Class
