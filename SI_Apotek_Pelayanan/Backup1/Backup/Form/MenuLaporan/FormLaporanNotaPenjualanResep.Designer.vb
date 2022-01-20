<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLaporanNotaPenjualanResep
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLaporanNotaPenjualanResep))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCariPasien = New System.Windows.Forms.TextBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.rNama = New System.Windows.Forms.RadioButton()
        Me.cmbJenisPasien = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbBagian = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPenjamin = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBaru = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnProses = New System.Windows.Forms.Button()
        Me.DTPTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.DTPTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTotalIurBayarBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalDijaminBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalNonPaketBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalPaketBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTotalIurBayar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtTotalDijamin = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalNonPaket = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalPaket = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNota = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GridObat = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtTotalIurBayarBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDijaminBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNonPaketBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPaketBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalIurBayar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalDijamin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalNonPaket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPaket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridObat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtCariPasien)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.rNama)
        Me.GroupBox1.Controls.Add(Me.cmbJenisPasien)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbBagian)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbPenjamin)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnBaru)
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.btnProses)
        Me.GroupBox1.Controls.Add(Me.DTPTanggalAkhir)
        Me.GroupBox1.Controls.Add(Me.DTPTanggalAwal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1110, 90)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'txtCariPasien
        '
        Me.txtCariPasien.Location = New System.Drawing.Point(423, 63)
        Me.txtCariPasien.Name = "txtCariPasien"
        Me.txtCariPasien.Size = New System.Drawing.Size(164, 20)
        Me.txtCariPasien.TabIndex = 6
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Location = New System.Drawing.Point(375, 65)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(42, 17)
        Me.RadioButton1.TabIndex = 14
        Me.RadioButton1.Text = "RM"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'rNama
        '
        Me.rNama.AutoSize = True
        Me.rNama.Checked = True
        Me.rNama.Location = New System.Drawing.Point(321, 65)
        Me.rNama.Name = "rNama"
        Me.rNama.Size = New System.Drawing.Size(53, 17)
        Me.rNama.TabIndex = 13
        Me.rNama.TabStop = True
        Me.rNama.Text = "Nama"
        Me.rNama.UseVisualStyleBackColor = True
        '
        'cmbJenisPasien
        '
        Me.cmbJenisPasien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbJenisPasien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbJenisPasien.FormattingEnabled = True
        Me.cmbJenisPasien.Location = New System.Drawing.Point(108, 63)
        Me.cmbJenisPasien.Name = "cmbJenisPasien"
        Me.cmbJenisPasien.Size = New System.Drawing.Size(200, 21)
        Me.cmbJenisPasien.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Jenis Pasien"
        '
        'cmbBagian
        '
        Me.cmbBagian.FormattingEnabled = True
        Me.cmbBagian.Location = New System.Drawing.Point(108, 39)
        Me.cmbBagian.Name = "cmbBagian"
        Me.cmbBagian.Size = New System.Drawing.Size(200, 21)
        Me.cmbBagian.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Bagian"
        '
        'cmbPenjamin
        '
        Me.cmbPenjamin.FormattingEnabled = True
        Me.cmbPenjamin.Location = New System.Drawing.Point(108, 15)
        Me.cmbPenjamin.Name = "cmbPenjamin"
        Me.cmbPenjamin.Size = New System.Drawing.Size(200, 21)
        Me.cmbPenjamin.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Penjamin"
        '
        'btnBaru
        '
        Me.btnBaru.Image = CType(resources.GetObject("btnBaru.Image"), System.Drawing.Image)
        Me.btnBaru.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaru.Location = New System.Drawing.Point(1002, 25)
        Me.btnBaru.Name = "btnBaru"
        Me.btnBaru.Size = New System.Drawing.Size(85, 35)
        Me.btnBaru.TabIndex = 9
        Me.btnBaru.Text = "Baru"
        Me.btnBaru.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaru.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(915, 25)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(85, 35)
        Me.btnExcel.TabIndex = 8
        Me.btnExcel.Text = "Ke Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnProses
        '
        Me.btnProses.Image = CType(resources.GetObject("btnProses.Image"), System.Drawing.Image)
        Me.btnProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProses.Location = New System.Drawing.Point(828, 25)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(85, 35)
        Me.btnProses.TabIndex = 7
        Me.btnProses.Text = "Proses"
        Me.btnProses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProses.UseVisualStyleBackColor = True
        '
        'DTPTanggalAkhir
        '
        Me.DTPTanggalAkhir.Location = New System.Drawing.Point(423, 39)
        Me.DTPTanggalAkhir.Name = "DTPTanggalAkhir"
        Me.DTPTanggalAkhir.Size = New System.Drawing.Size(164, 20)
        Me.DTPTanggalAkhir.TabIndex = 5
        '
        'DTPTanggalAwal
        '
        Me.DTPTanggalAwal.Location = New System.Drawing.Point(423, 16)
        Me.DTPTanggalAwal.Name = "DTPTanggalAwal"
        Me.DTPTanggalAwal.Size = New System.Drawing.Size(164, 20)
        Me.DTPTanggalAwal.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(318, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sampai Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(318, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dari Tanggal"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtTotalIurBayarBulat)
        Me.GroupBox2.Controls.Add(Me.txtTotalDijaminBulat)
        Me.GroupBox2.Controls.Add(Me.txtTotalNonPaketBulat)
        Me.GroupBox2.Controls.Add(Me.txtTotalPaketBulat)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtTotalIurBayar)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtTotalDijamin)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtTotalNonPaket)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtTotalPaket)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtNota)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 553)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1110, 83)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'txtTotalIurBayarBulat
        '
        Me.txtTotalIurBayarBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalIurBayarBulat.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalIurBayarBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalIurBayarBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalIurBayarBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalIurBayarBulat.CurrencySymbol = ""
        Me.txtTotalIurBayarBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalIurBayarBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIurBayarBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIurBayarBulat.Location = New System.Drawing.Point(963, 53)
        Me.txtTotalIurBayarBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalIurBayarBulat.Name = "txtTotalIurBayarBulat"
        Me.txtTotalIurBayarBulat.NullString = ""
        Me.txtTotalIurBayarBulat.ReadOnly = True
        Me.txtTotalIurBayarBulat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalIurBayarBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalIurBayarBulat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalIurBayarBulat.TabIndex = 35
        Me.txtTotalIurBayarBulat.Text = "0.00"
        Me.txtTotalIurBayarBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtTotalDijaminBulat.Location = New System.Drawing.Point(823, 53)
        Me.txtTotalDijaminBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalDijaminBulat.Name = "txtTotalDijaminBulat"
        Me.txtTotalDijaminBulat.NullString = ""
        Me.txtTotalDijaminBulat.ReadOnly = True
        Me.txtTotalDijaminBulat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalDijaminBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalDijaminBulat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalDijaminBulat.TabIndex = 35
        Me.txtTotalDijaminBulat.Text = "0.00"
        Me.txtTotalDijaminBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        Me.txtTotalNonPaketBulat.Location = New System.Drawing.Point(683, 53)
        Me.txtTotalNonPaketBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalNonPaketBulat.Name = "txtTotalNonPaketBulat"
        Me.txtTotalNonPaketBulat.NullString = ""
        Me.txtTotalNonPaketBulat.ReadOnly = True
        Me.txtTotalNonPaketBulat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalNonPaketBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalNonPaketBulat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalNonPaketBulat.TabIndex = 35
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
        Me.txtTotalPaketBulat.Location = New System.Drawing.Point(543, 53)
        Me.txtTotalPaketBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalPaketBulat.Name = "txtTotalPaketBulat"
        Me.txtTotalPaketBulat.NullString = ""
        Me.txtTotalPaketBulat.ReadOnly = True
        Me.txtTotalPaketBulat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalPaketBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalPaketBulat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalPaketBulat.TabIndex = 35
        Me.txtTotalPaketBulat.Text = "0.00"
        Me.txtTotalPaketBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(963, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 20)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Total Iur Bayar"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalIurBayar
        '
        Me.txtTotalIurBayar.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalIurBayar.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalIurBayar.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalIurBayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalIurBayar.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalIurBayar.CurrencySymbol = ""
        Me.txtTotalIurBayar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalIurBayar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalIurBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalIurBayar.Location = New System.Drawing.Point(963, 34)
        Me.txtTotalIurBayar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalIurBayar.Name = "txtTotalIurBayar"
        Me.txtTotalIurBayar.NullString = ""
        Me.txtTotalIurBayar.ReadOnly = True
        Me.txtTotalIurBayar.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalIurBayar.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalIurBayar.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalIurBayar.TabIndex = 33
        Me.txtTotalIurBayar.Text = "0.00"
        Me.txtTotalIurBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.Location = New System.Drawing.Point(823, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 20)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Total Dijamin"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.txtTotalDijamin.Location = New System.Drawing.Point(823, 34)
        Me.txtTotalDijamin.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalDijamin.Name = "txtTotalDijamin"
        Me.txtTotalDijamin.NullString = ""
        Me.txtTotalDijamin.ReadOnly = True
        Me.txtTotalDijamin.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalDijamin.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalDijamin.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalDijamin.TabIndex = 31
        Me.txtTotalDijamin.Text = "0.00"
        Me.txtTotalDijamin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(683, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(141, 20)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Total Non Paket"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.txtTotalNonPaket.Location = New System.Drawing.Point(683, 34)
        Me.txtTotalNonPaket.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalNonPaket.Name = "txtTotalNonPaket"
        Me.txtTotalNonPaket.NullString = ""
        Me.txtTotalNonPaket.ReadOnly = True
        Me.txtTotalNonPaket.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalNonPaket.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalNonPaket.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalNonPaket.TabIndex = 29
        Me.txtTotalNonPaket.Text = "0.00"
        Me.txtTotalNonPaket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(543, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(141, 20)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Total Paket"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.txtTotalPaket.Location = New System.Drawing.Point(543, 34)
        Me.txtTotalPaket.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalPaket.Name = "txtTotalPaket"
        Me.txtTotalPaket.NullString = ""
        Me.txtTotalPaket.ReadOnly = True
        Me.txtTotalPaket.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalPaket.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalPaket.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalPaket.TabIndex = 27
        Me.txtTotalPaket.Text = "0.00"
        Me.txtTotalPaket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(403, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 20)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Jumlah Nota"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtNota
        '
        Me.txtNota.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtNota.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtNota.BorderColor = System.Drawing.Color.DimGray
        Me.txtNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNota.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtNota.CurrencySymbol = ""
        Me.txtNota.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNota.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNota.Location = New System.Drawing.Point(403, 34)
        Me.txtNota.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNota.Name = "txtNota"
        Me.txtNota.NullString = ""
        Me.txtNota.ReadOnly = True
        Me.txtNota.Size = New System.Drawing.Size(141, 20)
        Me.txtNota.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtNota.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNota.TabIndex = 25
        Me.txtNota.Text = "0.00"
        Me.txtNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GridObat
        '
        Me.GridObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridObat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridObat.Location = New System.Drawing.Point(0, 90)
        Me.GridObat.Name = "GridObat"
        Me.GridObat.Size = New System.Drawing.Size(1110, 463)
        Me.GridObat.TabIndex = 4
        '
        'FormLaporanNotaPenjualanResep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1110, 636)
        Me.Controls.Add(Me.GridObat)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormLaporanNotaPenjualanResep"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Nota Penjualan Resep"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtTotalIurBayarBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDijaminBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNonPaketBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPaketBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalIurBayar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalDijamin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalNonPaket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPaket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridObat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbPenjamin As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBaru As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnProses As System.Windows.Forms.Button
    Friend WithEvents DTPTanggalAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalNonPaket As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPaket As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNota As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GridObat As System.Windows.Forms.DataGridView
    Friend WithEvents cmbJenisPasien As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbBagian As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCariPasien As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents rNama As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTotalIurBayar As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtTotalDijamin As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalPaketBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalNonPaketBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalDijaminBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalIurBayarBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class
