<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKartuStok
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKartuStok))
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.btnUpdateStok = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.txtSatuan = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNamaObat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtKodeObat = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPBulan = New System.Windows.Forms.DateTimePicker()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DTPTahun = New System.Windows.Forms.DateTimePicker()
        Me.btnBaru = New System.Windows.Forms.Button()
        Me.btnProses = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSaldoAwal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtKeluar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtMasuk = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtSaldoAkhir = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.gridSaldo = New System.Windows.Forms.DataGridView()
        Me.PanelObat = New System.Windows.Forms.Panel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.gridBarang = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCariObat = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtSaldoAwal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtKeluar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMasuk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSaldoAkhir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridSaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelObat.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btnUpdateStok)
        Me.GroupBox9.Controls.Add(Me.btnExcel)
        Me.GroupBox9.Controls.Add(Me.btnPreview)
        Me.GroupBox9.Controls.Add(Me.txtSatuan)
        Me.GroupBox9.Controls.Add(Me.Label3)
        Me.GroupBox9.Controls.Add(Me.txtNamaObat)
        Me.GroupBox9.Controls.Add(Me.Label2)
        Me.GroupBox9.Controls.Add(Me.txtKodeObat)
        Me.GroupBox9.Controls.Add(Me.Label1)
        Me.GroupBox9.Controls.Add(Me.DTPBulan)
        Me.GroupBox9.Controls.Add(Me.btnKeluar)
        Me.GroupBox9.Controls.Add(Me.Label17)
        Me.GroupBox9.Controls.Add(Me.DTPTahun)
        Me.GroupBox9.Controls.Add(Me.btnBaru)
        Me.GroupBox9.Controls.Add(Me.btnProses)
        Me.GroupBox9.Controls.Add(Me.Label19)
        Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox9.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(731, 125)
        Me.GroupBox9.TabIndex = 4
        Me.GroupBox9.TabStop = False
        '
        'btnUpdateStok
        '
        Me.btnUpdateStok.Image = CType(resources.GetObject("btnUpdateStok.Image"), System.Drawing.Image)
        Me.btnUpdateStok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateStok.Location = New System.Drawing.Point(646, 40)
        Me.btnUpdateStok.Name = "btnUpdateStok"
        Me.btnUpdateStok.Size = New System.Drawing.Size(73, 35)
        Me.btnUpdateStok.TabIndex = 34
        Me.btnUpdateStok.Text = "Update Stok"
        Me.btnUpdateStok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateStok.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(571, 75)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(73, 35)
        Me.btnExcel.TabIndex = 9
        Me.btnExcel.Text = "Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(496, 75)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(73, 35)
        Me.btnPreview.TabIndex = 8
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'txtSatuan
        '
        Me.txtSatuan.BackColor = System.Drawing.SystemColors.Info
        Me.txtSatuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSatuan.Location = New System.Drawing.Point(91, 95)
        Me.txtSatuan.Name = "txtSatuan"
        Me.txtSatuan.ReadOnly = True
        Me.txtSatuan.Size = New System.Drawing.Size(129, 20)
        Me.txtSatuan.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Satuan"
        '
        'txtNamaObat
        '
        Me.txtNamaObat.BackColor = System.Drawing.SystemColors.Info
        Me.txtNamaObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaObat.Location = New System.Drawing.Point(91, 72)
        Me.txtNamaObat.Name = "txtNamaObat"
        Me.txtNamaObat.ReadOnly = True
        Me.txtNamaObat.Size = New System.Drawing.Size(235, 20)
        Me.txtNamaObat.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Nama Barang"
        '
        'txtKodeObat
        '
        Me.txtKodeObat.BackColor = System.Drawing.SystemColors.Info
        Me.txtKodeObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKodeObat.Location = New System.Drawing.Point(91, 49)
        Me.txtKodeObat.Name = "txtKodeObat"
        Me.txtKodeObat.ReadOnly = True
        Me.txtKodeObat.Size = New System.Drawing.Size(129, 20)
        Me.txtKodeObat.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Kode Barang"
        '
        'DTPBulan
        '
        Me.DTPBulan.CustomFormat = "MMMM"
        Me.DTPBulan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPBulan.Location = New System.Drawing.Point(91, 25)
        Me.DTPBulan.Name = "DTPBulan"
        Me.DTPBulan.ShowUpDown = True
        Me.DTPBulan.Size = New System.Drawing.Size(129, 20)
        Me.DTPBulan.TabIndex = 1
        Me.DTPBulan.Value = New Date(2018, 7, 1, 9, 2, 0, 0)
        '
        'btnKeluar
        '
        Me.btnKeluar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(646, 75)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(73, 35)
        Me.btnKeluar.TabIndex = 10
        Me.btnKeluar.Text = "Keluar"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(225, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Tahun"
        '
        'DTPTahun
        '
        Me.DTPTahun.CustomFormat = "yyyy"
        Me.DTPTahun.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTahun.Location = New System.Drawing.Point(265, 25)
        Me.DTPTahun.Name = "DTPTahun"
        Me.DTPTahun.ShowUpDown = True
        Me.DTPTahun.Size = New System.Drawing.Size(61, 20)
        Me.DTPTahun.TabIndex = 2
        '
        'btnBaru
        '
        Me.btnBaru.Image = CType(resources.GetObject("btnBaru.Image"), System.Drawing.Image)
        Me.btnBaru.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaru.Location = New System.Drawing.Point(421, 75)
        Me.btnBaru.Name = "btnBaru"
        Me.btnBaru.Size = New System.Drawing.Size(73, 35)
        Me.btnBaru.TabIndex = 7
        Me.btnBaru.Text = "Baru"
        Me.btnBaru.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaru.UseVisualStyleBackColor = True
        '
        'btnProses
        '
        Me.btnProses.Image = CType(resources.GetObject("btnProses.Image"), System.Drawing.Image)
        Me.btnProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProses.Location = New System.Drawing.Point(346, 75)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(73, 35)
        Me.btnProses.TabIndex = 6
        Me.btnProses.Text = "Proses"
        Me.btnProses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProses.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 29)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Bulan"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtSaldoAwal)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 125)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(731, 42)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(526, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 20)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Saldo Awal Bulan"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtSaldoAwal
        '
        Me.txtSaldoAwal.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtSaldoAwal.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtSaldoAwal.BorderColor = System.Drawing.Color.DimGray
        Me.txtSaldoAwal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldoAwal.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtSaldoAwal.CurrencySymbol = ""
        Me.txtSaldoAwal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSaldoAwal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoAwal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoAwal.Location = New System.Drawing.Point(625, 14)
        Me.txtSaldoAwal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSaldoAwal.Name = "txtSaldoAwal"
        Me.txtSaldoAwal.NullString = ""
        Me.txtSaldoAwal.ReadOnly = True
        Me.txtSaldoAwal.Size = New System.Drawing.Size(93, 20)
        Me.txtSaldoAwal.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtSaldoAwal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSaldoAwal.TabIndex = 25
        Me.txtSaldoAwal.Text = "0.00"
        Me.txtSaldoAwal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKeluar)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtMasuk)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.txtSaldoAkhir)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 529)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(731, 42)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        '
        'txtKeluar
        '
        Me.txtKeluar.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtKeluar.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtKeluar.BorderColor = System.Drawing.Color.DimGray
        Me.txtKeluar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKeluar.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtKeluar.CurrencySymbol = ""
        Me.txtKeluar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtKeluar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtKeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKeluar.Location = New System.Drawing.Point(626, 13)
        Me.txtKeluar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtKeluar.Name = "txtKeluar"
        Me.txtKeluar.NullString = ""
        Me.txtKeluar.ReadOnly = True
        Me.txtKeluar.Size = New System.Drawing.Size(93, 20)
        Me.txtKeluar.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtKeluar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtKeluar.TabIndex = 29
        Me.txtKeluar.Text = "0.00"
        Me.txtKeluar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(393, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(143, 20)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Jumlah (Masuk dan Keluar)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtMasuk
        '
        Me.txtMasuk.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtMasuk.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtMasuk.BorderColor = System.Drawing.Color.DimGray
        Me.txtMasuk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtMasuk.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtMasuk.CurrencySymbol = ""
        Me.txtMasuk.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMasuk.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtMasuk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMasuk.Location = New System.Drawing.Point(534, 13)
        Me.txtMasuk.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtMasuk.Name = "txtMasuk"
        Me.txtMasuk.NullString = ""
        Me.txtMasuk.ReadOnly = True
        Me.txtMasuk.Size = New System.Drawing.Size(93, 20)
        Me.txtMasuk.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtMasuk.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtMasuk.TabIndex = 27
        Me.txtMasuk.Text = "0.00"
        Me.txtMasuk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(195, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 20)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Saldo Akhir"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtSaldoAkhir
        '
        Me.txtSaldoAkhir.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtSaldoAkhir.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtSaldoAkhir.BorderColor = System.Drawing.Color.DimGray
        Me.txtSaldoAkhir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSaldoAkhir.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtSaldoAkhir.CurrencySymbol = ""
        Me.txtSaldoAkhir.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSaldoAkhir.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSaldoAkhir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSaldoAkhir.Location = New System.Drawing.Point(265, 13)
        Me.txtSaldoAkhir.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSaldoAkhir.Name = "txtSaldoAkhir"
        Me.txtSaldoAkhir.NullString = ""
        Me.txtSaldoAkhir.ReadOnly = True
        Me.txtSaldoAkhir.Size = New System.Drawing.Size(93, 20)
        Me.txtSaldoAkhir.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtSaldoAkhir.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtSaldoAkhir.TabIndex = 25
        Me.txtSaldoAkhir.Text = "0.00"
        Me.txtSaldoAkhir.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gridSaldo
        '
        Me.gridSaldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridSaldo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridSaldo.Location = New System.Drawing.Point(0, 167)
        Me.gridSaldo.Name = "gridSaldo"
        Me.gridSaldo.Size = New System.Drawing.Size(731, 362)
        Me.gridSaldo.TabIndex = 7
        '
        'PanelObat
        '
        Me.PanelObat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelObat.Controls.Add(Me.GroupBox12)
        Me.PanelObat.Controls.Add(Me.GroupBox11)
        Me.PanelObat.Location = New System.Drawing.Point(61, 125)
        Me.PanelObat.Name = "PanelObat"
        Me.PanelObat.Size = New System.Drawing.Size(609, 321)
        Me.PanelObat.TabIndex = 19
        Me.PanelObat.Visible = False
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
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label33)
        Me.GroupBox11.Controls.Add(Me.txtCariObat)
        Me.GroupBox11.Controls.Add(Me.Button3)
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
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(3, 16)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(38, 55)
        Me.Button3.TabIndex = 7
        Me.Button3.UseVisualStyleBackColor = True
        '
        'FormKartuStok
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(731, 571)
        Me.Controls.Add(Me.PanelObat)
        Me.Controls.Add(Me.gridSaldo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox9)
        Me.Name = "FormKartuStok"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kartu Stok"
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtSaldoAwal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtKeluar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMasuk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSaldoAkhir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridSaldo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelObat.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPBulan As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnKeluar As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DTPTahun As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBaru As System.Windows.Forms.Button
    Friend WithEvents btnProses As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents txtSatuan As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNamaObat As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtKodeObat As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gridSaldo As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoAwal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSaldoAkhir As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtKeluar As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtMasuk As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents PanelObat As System.Windows.Forms.Panel
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCariObat As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnUpdateStok As System.Windows.Forms.Button
End Class
