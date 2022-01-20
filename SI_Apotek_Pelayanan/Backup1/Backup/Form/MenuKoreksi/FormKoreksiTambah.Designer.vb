<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKoreksiTambah
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKoreksiTambah))
        Me.GROU = New System.Windows.Forms.GroupBox()
        Me.DTPBantu = New System.Windows.Forms.DateTimePicker()
        Me.txtNoKoreksi = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTotalHarga = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtKeterangan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPTanggalTrans = New System.Windows.Forms.DateTimePicker()
        Me.txtJumlahKoreksi = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtHarga = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.lblNamaObat = New System.Windows.Forms.Label()
        Me.txtKdSatuan = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtIdObat = New System.Windows.Forms.TextBox()
        Me.txtKodeObat = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnKeluar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnBaru = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnSimpan = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCariObat = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.gridBarang = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.PanelObat = New System.Windows.Forms.Panel()
        Me.GROU.SuspendLayout()
        CType(Me.txtTotalHarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlahKoreksi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelObat.SuspendLayout()
        Me.SuspendLayout()
        '
        'GROU
        '
        Me.GROU.Controls.Add(Me.DTPBantu)
        Me.GROU.Controls.Add(Me.txtNoKoreksi)
        Me.GROU.Controls.Add(Me.Label3)
        Me.GROU.Controls.Add(Me.Label2)
        Me.GROU.Controls.Add(Me.txtTotalHarga)
        Me.GROU.Controls.Add(Me.txtKeterangan)
        Me.GROU.Controls.Add(Me.Label1)
        Me.GROU.Controls.Add(Me.DTPTanggalTrans)
        Me.GROU.Controls.Add(Me.txtJumlahKoreksi)
        Me.GROU.Controls.Add(Me.txtHarga)
        Me.GROU.Controls.Add(Me.lblNamaObat)
        Me.GROU.Controls.Add(Me.txtKdSatuan)
        Me.GROU.Controls.Add(Me.Label21)
        Me.GROU.Controls.Add(Me.Label20)
        Me.GROU.Controls.Add(Me.txtIdObat)
        Me.GROU.Controls.Add(Me.txtKodeObat)
        Me.GROU.Controls.Add(Me.Label18)
        Me.GROU.Controls.Add(Me.Label17)
        Me.GROU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GROU.Location = New System.Drawing.Point(0, 0)
        Me.GROU.Name = "GROU"
        Me.GROU.Size = New System.Drawing.Size(779, 393)
        Me.GROU.TabIndex = 1
        Me.GROU.TabStop = False
        '
        'DTPBantu
        '
        Me.DTPBantu.Location = New System.Drawing.Point(604, 19)
        Me.DTPBantu.Name = "DTPBantu"
        Me.DTPBantu.Size = New System.Drawing.Size(163, 20)
        Me.DTPBantu.TabIndex = 108
        Me.DTPBantu.Visible = False
        '
        'txtNoKoreksi
        '
        Me.txtNoKoreksi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoKoreksi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoKoreksi.Location = New System.Drawing.Point(100, 41)
        Me.txtNoKoreksi.Name = "txtNoKoreksi"
        Me.txtNoKoreksi.ReadOnly = True
        Me.txtNoKoreksi.Size = New System.Drawing.Size(163, 20)
        Me.txtNoKoreksi.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 107
        Me.Label3.Text = "Nomor"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Keterangan"
        '
        'txtTotalHarga
        '
        Me.txtTotalHarga.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtTotalHarga.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtTotalHarga.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalHarga.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalHarga.CurrencySymbol = ""
        Me.txtTotalHarga.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalHarga.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalHarga.Location = New System.Drawing.Point(100, 129)
        Me.txtTotalHarga.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalHarga.Name = "txtTotalHarga"
        Me.txtTotalHarga.NullString = ""
        Me.txtTotalHarga.ReadOnly = True
        Me.txtTotalHarga.Size = New System.Drawing.Size(163, 20)
        Me.txtTotalHarga.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalHarga.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalHarga.TabIndex = 6
        Me.txtTotalHarga.Text = "0.00"
        Me.txtTotalHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtKeterangan
        '
        Me.txtKeterangan.BackColor = System.Drawing.SystemColors.Info
        Me.txtKeterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKeterangan.Location = New System.Drawing.Point(100, 151)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(609, 20)
        Me.txtKeterangan.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "Total Harga"
        '
        'DTPTanggalTrans
        '
        Me.DTPTanggalTrans.Location = New System.Drawing.Point(100, 19)
        Me.DTPTanggalTrans.Name = "DTPTanggalTrans"
        Me.DTPTanggalTrans.Size = New System.Drawing.Size(163, 20)
        Me.DTPTanggalTrans.TabIndex = 1
        '
        'txtJumlahKoreksi
        '
        Me.txtJumlahKoreksi.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJumlahKoreksi.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtJumlahKoreksi.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahKoreksi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahKoreksi.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahKoreksi.CurrencySymbol = ""
        Me.txtJumlahKoreksi.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahKoreksi.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahKoreksi.Location = New System.Drawing.Point(100, 107)
        Me.txtJumlahKoreksi.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahKoreksi.Name = "txtJumlahKoreksi"
        Me.txtJumlahKoreksi.NullString = ""
        Me.txtJumlahKoreksi.Size = New System.Drawing.Size(88, 20)
        Me.txtJumlahKoreksi.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahKoreksi.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJumlahKoreksi.TabIndex = 5
        Me.txtJumlahKoreksi.Text = "0.00"
        Me.txtJumlahKoreksi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHarga
        '
        Me.txtHarga.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtHarga.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtHarga.BorderColor = System.Drawing.Color.DimGray
        Me.txtHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHarga.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtHarga.CurrencySymbol = ""
        Me.txtHarga.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHarga.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHarga.Location = New System.Drawing.Point(100, 85)
        Me.txtHarga.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.NullString = ""
        Me.txtHarga.ReadOnly = True
        Me.txtHarga.Size = New System.Drawing.Size(163, 20)
        Me.txtHarga.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtHarga.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtHarga.TabIndex = 4
        Me.txtHarga.Text = "0.00"
        Me.txtHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblNamaObat
        '
        Me.lblNamaObat.AutoSize = True
        Me.lblNamaObat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaObat.Location = New System.Drawing.Point(269, 39)
        Me.lblNamaObat.Name = "lblNamaObat"
        Me.lblNamaObat.Size = New System.Drawing.Size(93, 18)
        Me.lblNamaObat.TabIndex = 70
        Me.lblNamaObat.Text = "Nama Obat"
        '
        'txtKdSatuan
        '
        Me.txtKdSatuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKdSatuan.Location = New System.Drawing.Point(194, 107)
        Me.txtKdSatuan.Name = "txtKdSatuan"
        Me.txtKdSatuan.ReadOnly = True
        Me.txtKdSatuan.Size = New System.Drawing.Size(69, 20)
        Me.txtKdSatuan.TabIndex = 69
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 110)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(78, 13)
        Me.Label21.TabIndex = 65
        Me.Label21.Text = "Jumlah Koreksi"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 88)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(36, 13)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "Harga"
        '
        'txtIdObat
        '
        Me.txtIdObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdObat.Enabled = False
        Me.txtIdObat.Location = New System.Drawing.Point(194, 63)
        Me.txtIdObat.Name = "txtIdObat"
        Me.txtIdObat.ReadOnly = True
        Me.txtIdObat.Size = New System.Drawing.Size(69, 20)
        Me.txtIdObat.TabIndex = 62
        '
        'txtKodeObat
        '
        Me.txtKodeObat.BackColor = System.Drawing.SystemColors.Info
        Me.txtKodeObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKodeObat.Location = New System.Drawing.Point(100, 63)
        Me.txtKodeObat.Name = "txtKodeObat"
        Me.txtKodeObat.Size = New System.Drawing.Size(88, 20)
        Me.txtKodeObat.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 66)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Kode/ID"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(46, 13)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "Tanggal"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnKeluar)
        Me.GroupBox7.Controls.Add(Me.btnBaru)
        Me.GroupBox7.Controls.Add(Me.btnSimpan)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox7.Location = New System.Drawing.Point(0, 393)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(779, 52)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        '
        'btnKeluar
        '
        Me.btnKeluar.BeforeTouchSize = New System.Drawing.Size(99, 33)
        Me.btnKeluar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.IsBackStageButton = False
        Me.btnKeluar.Location = New System.Drawing.Point(201, 16)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(99, 33)
        Me.btnKeluar.TabIndex = 6
        Me.btnKeluar.Text = "Keluar"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBaru
        '
        Me.btnBaru.BeforeTouchSize = New System.Drawing.Size(99, 33)
        Me.btnBaru.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBaru.Image = CType(resources.GetObject("btnBaru.Image"), System.Drawing.Image)
        Me.btnBaru.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaru.IsBackStageButton = False
        Me.btnBaru.Location = New System.Drawing.Point(102, 16)
        Me.btnBaru.Name = "btnBaru"
        Me.btnBaru.Size = New System.Drawing.Size(99, 33)
        Me.btnBaru.TabIndex = 4
        Me.btnBaru.Text = "Baru [F10]"
        Me.btnBaru.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSimpan
        '
        Me.btnSimpan.BeforeTouchSize = New System.Drawing.Size(99, 33)
        Me.btnSimpan.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.IsBackStageButton = False
        Me.btnSimpan.Location = New System.Drawing.Point(3, 16)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(99, 33)
        Me.btnSimpan.TabIndex = 1
        Me.btnSimpan.Text = "Simpan [F12]"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label33)
        Me.GroupBox11.Controls.Add(Me.txtCariObat)
        Me.GroupBox11.Controls.Add(Me.Button1)
        Me.GroupBox11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox11.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(607, 74)
        Me.GroupBox11.TabIndex = 0
        Me.GroupBox11.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(49, 35)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(72, 13)
        Me.Label33.TabIndex = 12
        Me.Label33.Text = "Nama Barang"
        '
        'txtCariObat
        '
        Me.txtCariObat.Location = New System.Drawing.Point(127, 33)
        Me.txtCariObat.Name = "txtCariObat"
        Me.txtCariObat.Size = New System.Drawing.Size(457, 20)
        Me.txtCariObat.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(3, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(38, 55)
        Me.Button1.TabIndex = 7
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.gridBarang)
        Me.GroupBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox12.Location = New System.Drawing.Point(0, 74)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(607, 245)
        Me.GroupBox12.TabIndex = 1
        Me.GroupBox12.TabStop = False
        '
        'gridBarang
        '
        Me.gridBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2})
        Me.gridBarang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridBarang.Location = New System.Drawing.Point(3, 16)
        Me.gridBarang.Name = "gridBarang"
        Me.gridBarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridBarang.Size = New System.Drawing.Size(601, 226)
        Me.gridBarang.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.HeaderText = "Pilih"
        Me.Column2.Image = CType(resources.GetObject("Column2.Image"), System.Drawing.Image)
        Me.Column2.Name = "Column2"
        '
        'PanelObat
        '
        Me.PanelObat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelObat.Controls.Add(Me.GroupBox12)
        Me.PanelObat.Controls.Add(Me.GroupBox11)
        Me.PanelObat.Location = New System.Drawing.Point(100, 85)
        Me.PanelObat.Name = "PanelObat"
        Me.PanelObat.Size = New System.Drawing.Size(609, 321)
        Me.PanelObat.TabIndex = 15
        Me.PanelObat.Visible = False
        '
        'FormKoreksiTambah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(779, 445)
        Me.Controls.Add(Me.PanelObat)
        Me.Controls.Add(Me.GROU)
        Me.Controls.Add(Me.GroupBox7)
        Me.Name = "FormKoreksiTambah"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Koreksi Penambahan"
        Me.GROU.ResumeLayout(False)
        Me.GROU.PerformLayout()
        CType(Me.txtTotalHarga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlahKoreksi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelObat.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GROU As System.Windows.Forms.GroupBox
    Friend WithEvents txtJumlahKoreksi As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtHarga As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents lblNamaObat As System.Windows.Forms.Label
    Friend WithEvents txtKdSatuan As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtIdObat As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeObat As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DTPTanggalTrans As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNoKoreksi As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalHarga As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnKeluar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnBaru As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnSimpan As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCariObat As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PanelObat As System.Windows.Forms.Panel
    Friend WithEvents DTPBantu As System.Windows.Forms.DateTimePicker
End Class
