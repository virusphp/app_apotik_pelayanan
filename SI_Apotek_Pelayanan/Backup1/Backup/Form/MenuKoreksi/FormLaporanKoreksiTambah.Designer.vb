<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLaporanKoreksiTambah
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLaporanKoreksiTambah))
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.TabPktUmum = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.GridTab1 = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtGrandTotalTab1 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBaruTab1 = New System.Windows.Forms.Button()
        Me.btnExcelTab1 = New System.Windows.Forms.Button()
        Me.btnProsesTab1 = New System.Windows.Forms.Button()
        Me.DTPTanggalAkhirTab1 = New System.Windows.Forms.DateTimePicker()
        Me.DTPTanggalAwalTab1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.GridTab2 = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtGrandTotalTab2 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtNamaBarang = New System.Windows.Forms.TextBox()
        Me.txtKodeObat = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DTPTanggalAkhirTab2 = New System.Windows.Forms.DateTimePicker()
        Me.DTPTanggalAwalTab2 = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnBaruTab2 = New System.Windows.Forms.Button()
        Me.btnExcelTab2 = New System.Windows.Forms.Button()
        Me.btnProsesTab2 = New System.Windows.Forms.Button()
        Me.PanelObat = New System.Windows.Forms.Panel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.gridBarang = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCariObat = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAdv1.SuspendLayout()
        Me.TabPktUmum.SuspendLayout()
        CType(Me.GridTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtGrandTotalTab1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.TabPageAdv1.SuspendLayout()
        CType(Me.GridTab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.txtGrandTotalTab2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.PanelObat.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.ActiveTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(1110, 636)
        Me.TabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabControlAdv1.Controls.Add(Me.TabPktUmum)
        Me.TabControlAdv1.Controls.Add(Me.TabPageAdv1)
        Me.TabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlAdv1.FocusOnTabClick = False
        Me.TabControlAdv1.Location = New System.Drawing.Point(0, 0)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.Size = New System.Drawing.Size(1110, 636)
        Me.TabControlAdv1.TabIndex = 3
        Me.TabControlAdv1.TabPanelBackColor = System.Drawing.SystemColors.ControlLight
        Me.TabControlAdv1.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererDockingWhidbey)
        '
        'TabPktUmum
        '
        Me.TabPktUmum.Controls.Add(Me.GridTab1)
        Me.TabPktUmum.Controls.Add(Me.GroupBox2)
        Me.TabPktUmum.Controls.Add(Me.GroupBox1)
        Me.TabPktUmum.Image = Nothing
        Me.TabPktUmum.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPktUmum.Location = New System.Drawing.Point(1, 26)
        Me.TabPktUmum.Name = "TabPktUmum"
        Me.TabPktUmum.ShowCloseButton = True
        Me.TabPktUmum.Size = New System.Drawing.Size(1108, 609)
        Me.TabPktUmum.TabIndex = 1
        Me.TabPktUmum.Text = "Per Tanggal"
        Me.TabPktUmum.ThemesEnabled = False
        '
        'GridTab1
        '
        Me.GridTab1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTab1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTab1.Location = New System.Drawing.Point(0, 90)
        Me.GridTab1.Name = "GridTab1"
        Me.GridTab1.Size = New System.Drawing.Size(1108, 459)
        Me.GridTab1.TabIndex = 2
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtGrandTotalTab1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 549)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1108, 60)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(882, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 20)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Total"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtGrandTotalTab1
        '
        Me.txtGrandTotalTab1.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotalTab1.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtGrandTotalTab1.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotalTab1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotalTab1.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotalTab1.CurrencySymbol = ""
        Me.txtGrandTotalTab1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotalTab1.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotalTab1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotalTab1.Location = New System.Drawing.Point(956, 21)
        Me.txtGrandTotalTab1.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotalTab1.Name = "txtGrandTotalTab1"
        Me.txtGrandTotalTab1.NullString = ""
        Me.txtGrandTotalTab1.ReadOnly = True
        Me.txtGrandTotalTab1.Size = New System.Drawing.Size(130, 20)
        Me.txtGrandTotalTab1.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotalTab1.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtGrandTotalTab1.TabIndex = 21
        Me.txtGrandTotalTab1.Text = "0.00"
        Me.txtGrandTotalTab1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBaruTab1)
        Me.GroupBox1.Controls.Add(Me.btnExcelTab1)
        Me.GroupBox1.Controls.Add(Me.btnProsesTab1)
        Me.GroupBox1.Controls.Add(Me.DTPTanggalAkhirTab1)
        Me.GroupBox1.Controls.Add(Me.DTPTanggalAwalTab1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1108, 90)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnBaruTab1
        '
        Me.btnBaruTab1.Image = CType(resources.GetObject("btnBaruTab1.Image"), System.Drawing.Image)
        Me.btnBaruTab1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaruTab1.Location = New System.Drawing.Point(842, 24)
        Me.btnBaruTab1.Name = "btnBaruTab1"
        Me.btnBaruTab1.Size = New System.Drawing.Size(85, 35)
        Me.btnBaruTab1.TabIndex = 7
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
        Me.btnExcelTab1.TabIndex = 6
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
        'DTPTanggalAkhirTab1
        '
        Me.DTPTanggalAkhirTab1.Location = New System.Drawing.Point(108, 44)
        Me.DTPTanggalAkhirTab1.Name = "DTPTanggalAkhirTab1"
        Me.DTPTanggalAkhirTab1.Size = New System.Drawing.Size(200, 20)
        Me.DTPTanggalAkhirTab1.TabIndex = 3
        '
        'DTPTanggalAwalTab1
        '
        Me.DTPTanggalAwalTab1.Location = New System.Drawing.Point(108, 20)
        Me.DTPTanggalAwalTab1.Name = "DTPTanggalAwalTab1"
        Me.DTPTanggalAwalTab1.Size = New System.Drawing.Size(200, 20)
        Me.DTPTanggalAwalTab1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sampai Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dari Tanggal"
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.Controls.Add(Me.GridTab2)
        Me.TabPageAdv1.Controls.Add(Me.GroupBox4)
        Me.TabPageAdv1.Controls.Add(Me.GroupBox3)
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv1.Location = New System.Drawing.Point(1, 26)
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.Size = New System.Drawing.Size(1108, 609)
        Me.TabPageAdv1.TabIndex = 2
        Me.TabPageAdv1.Text = "Per Barang"
        Me.TabPageAdv1.ThemesEnabled = False
        '
        'GridTab2
        '
        Me.GridTab2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridTab2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridTab2.Location = New System.Drawing.Point(0, 90)
        Me.GridTab2.Name = "GridTab2"
        Me.GridTab2.Size = New System.Drawing.Size(1108, 459)
        Me.GridTab2.TabIndex = 3
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.txtGrandTotalTab2)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 549)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1108, 60)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(882, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(75, 20)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Total"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtGrandTotalTab2
        '
        Me.txtGrandTotalTab2.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotalTab2.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtGrandTotalTab2.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotalTab2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotalTab2.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotalTab2.CurrencySymbol = ""
        Me.txtGrandTotalTab2.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotalTab2.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotalTab2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotalTab2.Location = New System.Drawing.Point(956, 21)
        Me.txtGrandTotalTab2.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotalTab2.Name = "txtGrandTotalTab2"
        Me.txtGrandTotalTab2.NullString = ""
        Me.txtGrandTotalTab2.ReadOnly = True
        Me.txtGrandTotalTab2.Size = New System.Drawing.Size(130, 20)
        Me.txtGrandTotalTab2.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotalTab2.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtGrandTotalTab2.TabIndex = 21
        Me.txtGrandTotalTab2.Text = "0.00"
        Me.txtGrandTotalTab2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtNamaBarang)
        Me.GroupBox3.Controls.Add(Me.txtKodeObat)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.DTPTanggalAkhirTab2)
        Me.GroupBox3.Controls.Add(Me.DTPTanggalAwalTab2)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.btnBaruTab2)
        Me.GroupBox3.Controls.Add(Me.btnExcelTab2)
        Me.GroupBox3.Controls.Add(Me.btnProsesTab2)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1108, 90)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'txtNamaBarang
        '
        Me.txtNamaBarang.BackColor = System.Drawing.SystemColors.Control
        Me.txtNamaBarang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaBarang.Location = New System.Drawing.Point(402, 44)
        Me.txtNamaBarang.Name = "txtNamaBarang"
        Me.txtNamaBarang.Size = New System.Drawing.Size(231, 20)
        Me.txtNamaBarang.TabIndex = 4
        '
        'txtKodeObat
        '
        Me.txtKodeObat.BackColor = System.Drawing.SystemColors.Info
        Me.txtKodeObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKodeObat.Location = New System.Drawing.Point(402, 22)
        Me.txtKodeObat.Name = "txtKodeObat"
        Me.txtKodeObat.Size = New System.Drawing.Size(231, 20)
        Me.txtKodeObat.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(318, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Nama Barang"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(318, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(69, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Kode Barang"
        '
        'DTPTanggalAkhirTab2
        '
        Me.DTPTanggalAkhirTab2.Location = New System.Drawing.Point(108, 44)
        Me.DTPTanggalAkhirTab2.Name = "DTPTanggalAkhirTab2"
        Me.DTPTanggalAkhirTab2.Size = New System.Drawing.Size(200, 20)
        Me.DTPTanggalAkhirTab2.TabIndex = 2
        '
        'DTPTanggalAwalTab2
        '
        Me.DTPTanggalAwalTab2.Location = New System.Drawing.Point(108, 20)
        Me.DTPTanggalAwalTab2.Name = "DTPTanggalAwalTab2"
        Me.DTPTanggalAwalTab2.Size = New System.Drawing.Size(200, 20)
        Me.DTPTanggalAwalTab2.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 13)
        Me.Label8.TabIndex = 26
        Me.Label8.Text = "Sampai Tanggal"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 24)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 25
        Me.Label9.Text = "Dari Tanggal"
        '
        'btnBaruTab2
        '
        Me.btnBaruTab2.Image = CType(resources.GetObject("btnBaruTab2.Image"), System.Drawing.Image)
        Me.btnBaruTab2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaruTab2.Location = New System.Drawing.Point(842, 24)
        Me.btnBaruTab2.Name = "btnBaruTab2"
        Me.btnBaruTab2.Size = New System.Drawing.Size(85, 35)
        Me.btnBaruTab2.TabIndex = 7
        Me.btnBaruTab2.Text = "Baru"
        Me.btnBaruTab2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaruTab2.UseVisualStyleBackColor = True
        '
        'btnExcelTab2
        '
        Me.btnExcelTab2.Image = CType(resources.GetObject("btnExcelTab2.Image"), System.Drawing.Image)
        Me.btnExcelTab2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelTab2.Location = New System.Drawing.Point(755, 24)
        Me.btnExcelTab2.Name = "btnExcelTab2"
        Me.btnExcelTab2.Size = New System.Drawing.Size(85, 35)
        Me.btnExcelTab2.TabIndex = 6
        Me.btnExcelTab2.Text = "Ke Excel"
        Me.btnExcelTab2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelTab2.UseVisualStyleBackColor = True
        '
        'btnProsesTab2
        '
        Me.btnProsesTab2.Image = CType(resources.GetObject("btnProsesTab2.Image"), System.Drawing.Image)
        Me.btnProsesTab2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesTab2.Location = New System.Drawing.Point(668, 24)
        Me.btnProsesTab2.Name = "btnProsesTab2"
        Me.btnProsesTab2.Size = New System.Drawing.Size(85, 35)
        Me.btnProsesTab2.TabIndex = 5
        Me.btnProsesTab2.Text = "Proses"
        Me.btnProsesTab2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesTab2.UseVisualStyleBackColor = True
        '
        'PanelObat
        '
        Me.PanelObat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelObat.Controls.Add(Me.GroupBox12)
        Me.PanelObat.Controls.Add(Me.GroupBox11)
        Me.PanelObat.Location = New System.Drawing.Point(403, 70)
        Me.PanelObat.Name = "PanelObat"
        Me.PanelObat.Size = New System.Drawing.Size(609, 321)
        Me.PanelObat.TabIndex = 111
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
        'FormLaporanKoreksiTambah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1110, 636)
        Me.Controls.Add(Me.PanelObat)
        Me.Controls.Add(Me.TabControlAdv1)
        Me.Name = "FormLaporanKoreksiTambah"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Koreksi Penambahan Barang"
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAdv1.ResumeLayout(False)
        Me.TabPktUmum.ResumeLayout(False)
        CType(Me.GridTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtGrandTotalTab1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPageAdv1.ResumeLayout(False)
        CType(Me.GridTab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.txtGrandTotalTab2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PanelObat.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControlAdv1 As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents TabPktUmum As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents GridTab1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtGrandTotalTab1 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBaruTab1 As System.Windows.Forms.Button
    Friend WithEvents btnExcelTab1 As System.Windows.Forms.Button
    Friend WithEvents btnProsesTab1 As System.Windows.Forms.Button
    Friend WithEvents DTPTanggalAkhirTab1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPTanggalAwalTab1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabPageAdv1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents GridTab2 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtGrandTotalTab2 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtNamaBarang As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeObat As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DTPTanggalAkhirTab2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPTanggalAwalTab2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnBaruTab2 As System.Windows.Forms.Button
    Friend WithEvents btnExcelTab2 As System.Windows.Forms.Button
    Friend WithEvents btnProsesTab2 As System.Windows.Forms.Button
    Friend WithEvents PanelObat As System.Windows.Forms.Panel
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCariObat As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
