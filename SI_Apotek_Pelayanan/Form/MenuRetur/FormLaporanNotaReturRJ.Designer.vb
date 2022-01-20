<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLaporanNotaReturRJ
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLaporanNotaReturRJ))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbBagian = New System.Windows.Forms.ComboBox()
        Me.lblPilihanTab1 = New System.Windows.Forms.Label()
        Me.txtCariPasien = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rNama = New System.Windows.Forms.RadioButton()
        Me.DTPTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.DTPTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBaruTab1 = New System.Windows.Forms.Button()
        Me.btnExcelTab1 = New System.Windows.Forms.Button()
        Me.btnProsesTab1 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtTotalIurPasienBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalDijaminBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalReturBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalNonPaketBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalPaketBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTotalIurPasien = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalDijamin = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalRetur = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalNonPaket = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTotalPaket = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GridObat = New System.Windows.Forms.DataGridView()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtTotalIurPasienBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDijaminBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalReturBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNonPaketBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPaketBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIurPasien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDijamin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalRetur, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNonPaket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPaket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridObat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbBagian)
        Me.GroupBox4.Controls.Add(Me.lblPilihanTab1)
        Me.GroupBox4.Controls.Add(Me.txtCariPasien)
        Me.GroupBox4.Controls.Add(Me.RadioButton1)
        Me.GroupBox4.Controls.Add(Me.rNama)
        Me.GroupBox4.Controls.Add(Me.DTPTanggalAkhir)
        Me.GroupBox4.Controls.Add(Me.DTPTanggalAwal)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.btnBaruTab1)
        Me.GroupBox4.Controls.Add(Me.btnExcelTab1)
        Me.GroupBox4.Controls.Add(Me.btnProsesTab1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1110, 120)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'cmbBagian
        '
        Me.cmbBagian.FormattingEnabled = True
        Me.cmbBagian.Items.AddRange(New Object() {"", "Semua", "Dijamin", "Iur Pasien"})
        Me.cmbBagian.Location = New System.Drawing.Point(117, 14)
        Me.cmbBagian.Name = "cmbBagian"
        Me.cmbBagian.Size = New System.Drawing.Size(194, 21)
        Me.cmbBagian.TabIndex = 3
        '
        'lblPilihanTab1
        '
        Me.lblPilihanTab1.AutoSize = True
        Me.lblPilihanTab1.Location = New System.Drawing.Point(12, 17)
        Me.lblPilihanTab1.Name = "lblPilihanTab1"
        Me.lblPilihanTab1.Size = New System.Drawing.Size(38, 13)
        Me.lblPilihanTab1.TabIndex = 23
        Me.lblPilihanTab1.Text = "Pilihan"
        '
        'txtCariPasien
        '
        Me.txtCariPasien.Location = New System.Drawing.Point(117, 86)
        Me.txtCariPasien.Name = "txtCariPasien"
        Me.txtCariPasien.Size = New System.Drawing.Size(194, 20)
        Me.txtCariPasien.TabIndex = 19
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(69, 88)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(42, 17)
        Me.RadioButton1.TabIndex = 21
        Me.RadioButton1.Text = "RM"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rNama
        '
        Me.rNama.AutoSize = True
        Me.rNama.Checked = True
        Me.rNama.Location = New System.Drawing.Point(15, 88)
        Me.rNama.Name = "rNama"
        Me.rNama.Size = New System.Drawing.Size(53, 17)
        Me.rNama.TabIndex = 20
        Me.rNama.TabStop = True
        Me.rNama.Text = "Nama"
        Me.rNama.UseVisualStyleBackColor = True
        '
        'DTPTanggalAkhir
        '
        Me.DTPTanggalAkhir.Location = New System.Drawing.Point(117, 62)
        Me.DTPTanggalAkhir.Name = "DTPTanggalAkhir"
        Me.DTPTanggalAkhir.Size = New System.Drawing.Size(194, 20)
        Me.DTPTanggalAkhir.TabIndex = 2
        '
        'DTPTanggalAwal
        '
        Me.DTPTanggalAwal.Location = New System.Drawing.Point(117, 39)
        Me.DTPTanggalAwal.Name = "DTPTanggalAwal"
        Me.DTPTanggalAwal.Size = New System.Drawing.Size(194, 20)
        Me.DTPTanggalAwal.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Sampai Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Dari Tanggal"
        '
        'btnBaruTab1
        '
        Me.btnBaruTab1.Image = CType(resources.GetObject("btnBaruTab1.Image"), System.Drawing.Image)
        Me.btnBaruTab1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaruTab1.Location = New System.Drawing.Point(842, 24)
        Me.btnBaruTab1.Name = "btnBaruTab1"
        Me.btnBaruTab1.Size = New System.Drawing.Size(85, 35)
        Me.btnBaruTab1.TabIndex = 6
        Me.btnBaruTab1.Text = "Baru"
        Me.btnBaruTab1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaruTab1.UseVisualStyleBackColor = True
        '
        'btnExcelTab1
        '
        Me.btnExcelTab1.Image = CType(resources.GetObject("btnExcelTab1.Image"), System.Drawing.Image)
        Me.btnExcelTab1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelTab1.Location = New System.Drawing.Point(755, 24)
        Me.btnExcelTab1.Name = "btnExcelTab1"
        Me.btnExcelTab1.Size = New System.Drawing.Size(85, 35)
        Me.btnExcelTab1.TabIndex = 5
        Me.btnExcelTab1.Text = "Ke Excel"
        Me.btnExcelTab1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelTab1.UseVisualStyleBackColor = True
        '
        'btnProsesTab1
        '
        Me.btnProsesTab1.Image = CType(resources.GetObject("btnProsesTab1.Image"), System.Drawing.Image)
        Me.btnProsesTab1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesTab1.Location = New System.Drawing.Point(668, 24)
        Me.btnProsesTab1.Name = "btnProsesTab1"
        Me.btnProsesTab1.Size = New System.Drawing.Size(85, 35)
        Me.btnProsesTab1.TabIndex = 4
        Me.btnProsesTab1.Text = "Proses"
        Me.btnProsesTab1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesTab1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtTotalIurPasienBulat)
        Me.GroupBox3.Controls.Add(Me.txtTotalDijaminBulat)
        Me.GroupBox3.Controls.Add(Me.txtTotalReturBulat)
        Me.GroupBox3.Controls.Add(Me.txtTotalNonPaketBulat)
        Me.GroupBox3.Controls.Add(Me.txtTotalPaketBulat)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtTotalIurPasien)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtTotalDijamin)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtTotalRetur)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtTotalNonPaket)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtTotalPaket)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 556)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1110, 80)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        '
        'txtTotalIurPasienBulat
        '
        Me.txtTotalIurPasienBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalIurPasienBulat.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalIurPasienBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalIurPasienBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalIurPasienBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalIurPasienBulat.CurrencySymbol = ""
        Me.txtTotalIurPasienBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalIurPasienBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIurPasienBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIurPasienBulat.Location = New System.Drawing.Point(957, 53)
        Me.txtTotalIurPasienBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalIurPasienBulat.Name = "txtTotalIurPasienBulat"
        Me.txtTotalIurPasienBulat.NullString = ""
        Me.txtTotalIurPasienBulat.ReadOnly = True
        Me.txtTotalIurPasienBulat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalIurPasienBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalIurPasienBulat.TabIndex = 43
        Me.txtTotalIurPasienBulat.Text = "0.00"
        Me.txtTotalIurPasienBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalDijaminBulat
        '
        Me.txtTotalDijaminBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalDijaminBulat.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalDijaminBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalDijaminBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDijaminBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalDijaminBulat.CurrencySymbol = ""
        Me.txtTotalDijaminBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalDijaminBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDijaminBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDijaminBulat.Location = New System.Drawing.Point(817, 53)
        Me.txtTotalDijaminBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalDijaminBulat.Name = "txtTotalDijaminBulat"
        Me.txtTotalDijaminBulat.NullString = ""
        Me.txtTotalDijaminBulat.ReadOnly = True
        Me.txtTotalDijaminBulat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalDijaminBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalDijaminBulat.TabIndex = 42
        Me.txtTotalDijaminBulat.Text = "0.00"
        Me.txtTotalDijaminBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalReturBulat
        '
        Me.txtTotalReturBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalReturBulat.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalReturBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalReturBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalReturBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalReturBulat.CurrencySymbol = ""
        Me.txtTotalReturBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalReturBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalReturBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalReturBulat.Location = New System.Drawing.Point(659, 53)
        Me.txtTotalReturBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalReturBulat.Name = "txtTotalReturBulat"
        Me.txtTotalReturBulat.NullString = ""
        Me.txtTotalReturBulat.ReadOnly = True
        Me.txtTotalReturBulat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalReturBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalReturBulat.TabIndex = 41
        Me.txtTotalReturBulat.Text = "0.00"
        Me.txtTotalReturBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalNonPaketBulat
        '
        Me.txtTotalNonPaketBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalNonPaketBulat.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalNonPaketBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalNonPaketBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalNonPaketBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalNonPaketBulat.CurrencySymbol = ""
        Me.txtTotalNonPaketBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalNonPaketBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNonPaketBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNonPaketBulat.Location = New System.Drawing.Point(519, 53)
        Me.txtTotalNonPaketBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalNonPaketBulat.Name = "txtTotalNonPaketBulat"
        Me.txtTotalNonPaketBulat.NullString = ""
        Me.txtTotalNonPaketBulat.ReadOnly = True
        Me.txtTotalNonPaketBulat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalNonPaketBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalNonPaketBulat.TabIndex = 40
        Me.txtTotalNonPaketBulat.Text = "0.00"
        Me.txtTotalNonPaketBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPaketBulat
        '
        Me.txtTotalPaketBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalPaketBulat.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalPaketBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalPaketBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPaketBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalPaketBulat.CurrencySymbol = ""
        Me.txtTotalPaketBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalPaketBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPaketBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPaketBulat.Location = New System.Drawing.Point(379, 53)
        Me.txtTotalPaketBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalPaketBulat.Name = "txtTotalPaketBulat"
        Me.txtTotalPaketBulat.NullString = ""
        Me.txtTotalPaketBulat.ReadOnly = True
        Me.txtTotalPaketBulat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalPaketBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalPaketBulat.TabIndex = 39
        Me.txtTotalPaketBulat.Text = "0.00"
        Me.txtTotalPaketBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(957, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(141, 20)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "Total Iur Pasien"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalIurPasien
        '
        Me.txtTotalIurPasien.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalIurPasien.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalIurPasien.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalIurPasien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalIurPasien.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalIurPasien.CurrencySymbol = ""
        Me.txtTotalIurPasien.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalIurPasien.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIurPasien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIurPasien.Location = New System.Drawing.Point(957, 34)
        Me.txtTotalIurPasien.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalIurPasien.Name = "txtTotalIurPasien"
        Me.txtTotalIurPasien.NullString = ""
        Me.txtTotalIurPasien.ReadOnly = True
        Me.txtTotalIurPasien.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalIurPasien.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalIurPasien.TabIndex = 37
        Me.txtTotalIurPasien.Text = "0.00"
        Me.txtTotalIurPasien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(817, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 20)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Total Dijamin"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalDijamin
        '
        Me.txtTotalDijamin.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalDijamin.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalDijamin.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalDijamin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalDijamin.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalDijamin.CurrencySymbol = ""
        Me.txtTotalDijamin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalDijamin.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalDijamin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalDijamin.Location = New System.Drawing.Point(817, 34)
        Me.txtTotalDijamin.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalDijamin.Name = "txtTotalDijamin"
        Me.txtTotalDijamin.NullString = ""
        Me.txtTotalDijamin.ReadOnly = True
        Me.txtTotalDijamin.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalDijamin.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalDijamin.TabIndex = 35
        Me.txtTotalDijamin.Text = "0.00"
        Me.txtTotalDijamin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(659, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(141, 20)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Total Retur"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalRetur
        '
        Me.txtTotalRetur.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalRetur.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalRetur.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalRetur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalRetur.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalRetur.CurrencySymbol = ""
        Me.txtTotalRetur.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalRetur.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalRetur.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalRetur.Location = New System.Drawing.Point(659, 34)
        Me.txtTotalRetur.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalRetur.Name = "txtTotalRetur"
        Me.txtTotalRetur.NullString = ""
        Me.txtTotalRetur.ReadOnly = True
        Me.txtTotalRetur.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalRetur.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalRetur.TabIndex = 29
        Me.txtTotalRetur.Text = "0.00"
        Me.txtTotalRetur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(519, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(141, 20)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Total Non Paket"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalNonPaket
        '
        Me.txtTotalNonPaket.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalNonPaket.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalNonPaket.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalNonPaket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalNonPaket.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalNonPaket.CurrencySymbol = ""
        Me.txtTotalNonPaket.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalNonPaket.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalNonPaket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalNonPaket.Location = New System.Drawing.Point(519, 34)
        Me.txtTotalNonPaket.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalNonPaket.Name = "txtTotalNonPaket"
        Me.txtTotalNonPaket.NullString = ""
        Me.txtTotalNonPaket.ReadOnly = True
        Me.txtTotalNonPaket.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalNonPaket.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalNonPaket.TabIndex = 27
        Me.txtTotalNonPaket.Text = "0.00"
        Me.txtTotalNonPaket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(379, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 20)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Total Paket"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalPaket
        '
        Me.txtTotalPaket.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalPaket.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalPaket.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalPaket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPaket.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalPaket.CurrencySymbol = ""
        Me.txtTotalPaket.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalPaket.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPaket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPaket.Location = New System.Drawing.Point(379, 34)
        Me.txtTotalPaket.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalPaket.Name = "txtTotalPaket"
        Me.txtTotalPaket.NullString = ""
        Me.txtTotalPaket.ReadOnly = True
        Me.txtTotalPaket.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalPaket.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalPaket.TabIndex = 25
        Me.txtTotalPaket.Text = "0.00"
        Me.txtTotalPaket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GridObat
        '
        Me.GridObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridObat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridObat.Location = New System.Drawing.Point(0, 120)
        Me.GridObat.Name = "GridObat"
        Me.GridObat.Size = New System.Drawing.Size(1110, 436)
        Me.GridObat.TabIndex = 10
        '
        'FormLaporanNotaReturRJ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1110, 636)
        Me.Controls.Add(Me.GridObat)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "FormLaporanNotaReturRJ"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Nota Retur Rawat Jalan"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtTotalIurPasienBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDijaminBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalReturBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNonPaketBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPaketBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIurPasien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDijamin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalRetur, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNonPaket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPaket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridObat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents cmbBagian As ComboBox
    Friend WithEvents lblPilihanTab1 As Label
    Friend WithEvents txtCariPasien As TextBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents rNama As RadioButton
    Friend WithEvents DTPTanggalAkhir As DateTimePicker
    Friend WithEvents DTPTanggalAwal As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnBaruTab1 As Button
    Friend WithEvents btnExcelTab1 As Button
    Friend WithEvents btnProsesTab1 As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents txtTotalIurPasienBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalDijaminBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalReturBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalNonPaketBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalPaketBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTotalIurPasien As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtTotalDijamin As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtTotalRetur As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTotalNonPaket As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTotalPaket As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GridObat As DataGridView
End Class
