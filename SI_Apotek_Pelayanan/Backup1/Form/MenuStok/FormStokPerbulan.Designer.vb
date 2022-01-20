<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormStokPerbulan
    Inherits Syncfusion.Windows.Forms.Office2010Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStokPerbulan))
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.DTPBulan = New System.Windows.Forms.DateTimePicker()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DTPTahun = New System.Windows.Forms.DateTimePicker()
        Me.btnBaruTab5 = New System.Windows.Forms.Button()
        Me.btnProsesTab5 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtQty = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtGrandTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.gridObat = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TabControlStok = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.Tab1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.txtNamaBarang = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Tab2 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.btnStok1 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.cmbJenisObat = New System.Windows.Forms.ComboBox()
        Me.btnTdkBergerak = New System.Windows.Forms.Button()
        Me.btnGerak = New System.Windows.Forms.Button()
        Me.btnStok0 = New System.Windows.Forms.Button()
        Me.btnUrutNama = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPageAdv1 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.btnUpdateStok = New System.Windows.Forms.Button()
        Me.TabPageAdv2 = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.btnTutupStok = New System.Windows.Forms.Button()
        Me.DTPBulanTutup = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DTPTahunTutup = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DTPBulanAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DTPTahunAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridObat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TabControlStok, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlStok.SuspendLayout()
        Me.Tab1.SuspendLayout()
        Me.Tab2.SuspendLayout()
        Me.TabPageAdv1.SuspendLayout()
        Me.TabPageAdv2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.DTPBulan)
        Me.GroupBox9.Controls.Add(Me.btnKeluar)
        Me.GroupBox9.Controls.Add(Me.Label17)
        Me.GroupBox9.Controls.Add(Me.DTPTahun)
        Me.GroupBox9.Controls.Add(Me.btnBaruTab5)
        Me.GroupBox9.Controls.Add(Me.btnProsesTab5)
        Me.GroupBox9.Controls.Add(Me.Label19)
        Me.GroupBox9.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox9.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(1110, 67)
        Me.GroupBox9.TabIndex = 3
        Me.GroupBox9.TabStop = False
        '
        'DTPBulan
        '
        Me.DTPBulan.AllowDrop = True
        Me.DTPBulan.CustomFormat = "MMMM"
        Me.DTPBulan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPBulan.Location = New System.Drawing.Point(78, 25)
        Me.DTPBulan.Name = "DTPBulan"
        Me.DTPBulan.ShowUpDown = True
        Me.DTPBulan.Size = New System.Drawing.Size(129, 20)
        Me.DTPBulan.TabIndex = 26
        Me.DTPBulan.Value = New Date(2019, 1, 1, 0, 0, 0, 0)
        '
        'btnKeluar
        '
        Me.btnKeluar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(715, 17)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(85, 35)
        Me.btnKeluar.TabIndex = 24
        Me.btnKeluar.Text = "Keluar"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(218, 29)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(38, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Tahun"
        '
        'DTPTahun
        '
        Me.DTPTahun.CustomFormat = "yyyy"
        Me.DTPTahun.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTahun.Location = New System.Drawing.Point(262, 25)
        Me.DTPTahun.Name = "DTPTahun"
        Me.DTPTahun.ShowUpDown = True
        Me.DTPTahun.Size = New System.Drawing.Size(61, 20)
        Me.DTPTahun.TabIndex = 22
        '
        'btnBaruTab5
        '
        Me.btnBaruTab5.Image = CType(resources.GetObject("btnBaruTab5.Image"), System.Drawing.Image)
        Me.btnBaruTab5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaruTab5.Location = New System.Drawing.Point(629, 17)
        Me.btnBaruTab5.Name = "btnBaruTab5"
        Me.btnBaruTab5.Size = New System.Drawing.Size(85, 35)
        Me.btnBaruTab5.TabIndex = 7
        Me.btnBaruTab5.Text = "Baru"
        Me.btnBaruTab5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaruTab5.UseVisualStyleBackColor = True
        '
        'btnProsesTab5
        '
        Me.btnProsesTab5.Image = CType(resources.GetObject("btnProsesTab5.Image"), System.Drawing.Image)
        Me.btnProsesTab5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesTab5.Location = New System.Drawing.Point(543, 17)
        Me.btnProsesTab5.Name = "btnProsesTab5"
        Me.btnProsesTab5.Size = New System.Drawing.Size(85, 35)
        Me.btnProsesTab5.TabIndex = 4
        Me.btnProsesTab5.Text = "Proses"
        Me.btnProsesTab5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesTab5.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 29)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(59, 13)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Stok Bulan"
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.Label2)
        Me.GroupBox10.Controls.Add(Me.txtQty)
        Me.GroupBox10.Controls.Add(Me.Label20)
        Me.GroupBox10.Controls.Add(Me.txtGrandTotal)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox10.Location = New System.Drawing.Point(0, 576)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(1110, 60)
        Me.GroupBox10.TabIndex = 8
        Me.GroupBox10.TabStop = False
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(20, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 20)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Jumlah Barang"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtQty
        '
        Me.txtQty.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtQty.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtQty.BorderColor = System.Drawing.Color.DimGray
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtQty.CurrencySymbol = ""
        Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQty.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(134, 21)
        Me.txtQty.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtQty.Name = "txtQty"
        Me.txtQty.NullString = ""
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(93, 20)
        Me.txtQty.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtQty.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtQty.TabIndex = 23
        Me.txtQty.Text = "0.00"
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label20
        '
        Me.Label20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label20.Location = New System.Drawing.Point(833, 21)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(124, 20)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Total Harga"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotal.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.txtGrandTotal.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotal.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotal.CurrencySymbol = ""
        Me.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(956, 21)
        Me.txtGrandTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.NullString = ""
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(130, 20)
        Me.txtGrandTotal.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtGrandTotal.TabIndex = 21
        Me.txtGrandTotal.Text = "0.00"
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gridObat
        '
        Me.gridObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridObat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridObat.Location = New System.Drawing.Point(0, 173)
        Me.gridObat.Name = "gridObat"
        Me.gridObat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridObat.Size = New System.Drawing.Size(1110, 403)
        Me.gridObat.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TabControlStok)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 67)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1110, 106)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'TabControlStok
        '
        Me.TabControlStok.BeforeTouchSize = New System.Drawing.Size(1104, 87)
        Me.TabControlStok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabControlStok.BorderWidth = 3
        Me.TabControlStok.Controls.Add(Me.Tab1)
        Me.TabControlStok.Controls.Add(Me.Tab2)
        Me.TabControlStok.Controls.Add(Me.TabPageAdv1)
        Me.TabControlStok.Controls.Add(Me.TabPageAdv2)
        Me.TabControlStok.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlStok.FocusOnTabClick = False
        Me.TabControlStok.Location = New System.Drawing.Point(3, 16)
        Me.TabControlStok.Name = "TabControlStok"
        Me.TabControlStok.Size = New System.Drawing.Size(1104, 87)
        Me.TabControlStok.TabIndex = 5
        Me.TabControlStok.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererMetro)
        '
        'Tab1
        '
        Me.Tab1.Controls.Add(Me.Button6)
        Me.Tab1.Controls.Add(Me.txtNamaBarang)
        Me.Tab1.Controls.Add(Me.Label1)
        Me.Tab1.Image = Nothing
        Me.Tab1.ImageSize = New System.Drawing.Size(16, 16)
        Me.Tab1.Location = New System.Drawing.Point(1, 22)
        Me.Tab1.Name = "Tab1"
        Me.Tab1.ShowCloseButton = True
        Me.Tab1.Size = New System.Drawing.Size(1102, 64)
        Me.Tab1.TabIndex = 1
        Me.Tab1.Text = "Per Nama Barang"
        Me.Tab1.ThemesEnabled = False
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(952, 14)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(142, 32)
        Me.Button6.TabIndex = 4
        Me.Button6.Text = "Rapatkan Tabel"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'txtNamaBarang
        '
        Me.txtNamaBarang.Location = New System.Drawing.Point(93, 21)
        Me.txtNamaBarang.Name = "txtNamaBarang"
        Me.txtNamaBarang.Size = New System.Drawing.Size(247, 20)
        Me.txtNamaBarang.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Nama Barang"
        '
        'Tab2
        '
        Me.Tab2.Controls.Add(Me.btnStok1)
        Me.Tab2.Controls.Add(Me.Button1)
        Me.Tab2.Controls.Add(Me.Button5)
        Me.Tab2.Controls.Add(Me.btnExcel)
        Me.Tab2.Controls.Add(Me.btnPreview)
        Me.Tab2.Controls.Add(Me.cmbJenisObat)
        Me.Tab2.Controls.Add(Me.btnTdkBergerak)
        Me.Tab2.Controls.Add(Me.btnGerak)
        Me.Tab2.Controls.Add(Me.btnStok0)
        Me.Tab2.Controls.Add(Me.btnUrutNama)
        Me.Tab2.Controls.Add(Me.Label3)
        Me.Tab2.Image = Nothing
        Me.Tab2.ImageSize = New System.Drawing.Size(16, 16)
        Me.Tab2.Location = New System.Drawing.Point(1, 22)
        Me.Tab2.Name = "Tab2"
        Me.Tab2.ShowCloseButton = True
        Me.Tab2.Size = New System.Drawing.Size(1102, 64)
        Me.Tab2.TabIndex = 2
        Me.Tab2.Text = "Per Semua Barang"
        Me.Tab2.ThemesEnabled = False
        '
        'btnStok1
        '
        Me.btnStok1.Image = CType(resources.GetObject("btnStok1.Image"), System.Drawing.Image)
        Me.btnStok1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStok1.Location = New System.Drawing.Point(375, 7)
        Me.btnStok1.Name = "btnStok1"
        Me.btnStok1.Size = New System.Drawing.Size(89, 50)
        Me.btnStok1.TabIndex = 35
        Me.btnStok1.Text = "Stok > 0"
        Me.btnStok1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStok1.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(1005, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 50)
        Me.Button1.TabIndex = 34
        Me.Button1.Text = "Ke Excel 2"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(914, 7)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(89, 50)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "Cetak Stok Opname"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'btnExcel
        '
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(740, 7)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(89, 50)
        Me.btnExcel.TabIndex = 32
        Me.btnExcel.Text = "Ke Excel 1"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnPreview
        '
        Me.btnPreview.Image = CType(resources.GetObject("btnPreview.Image"), System.Drawing.Image)
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(649, 7)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(89, 50)
        Me.btnPreview.TabIndex = 31
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'cmbJenisObat
        '
        Me.cmbJenisObat.FormattingEnabled = True
        Me.cmbJenisObat.Location = New System.Drawing.Point(15, 32)
        Me.cmbJenisObat.Name = "cmbJenisObat"
        Me.cmbJenisObat.Size = New System.Drawing.Size(173, 21)
        Me.cmbJenisObat.TabIndex = 30
        '
        'btnTdkBergerak
        '
        Me.btnTdkBergerak.Image = CType(resources.GetObject("btnTdkBergerak.Image"), System.Drawing.Image)
        Me.btnTdkBergerak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTdkBergerak.Location = New System.Drawing.Point(558, 7)
        Me.btnTdkBergerak.Name = "btnTdkBergerak"
        Me.btnTdkBergerak.Size = New System.Drawing.Size(89, 50)
        Me.btnTdkBergerak.TabIndex = 29
        Me.btnTdkBergerak.Text = "Yg Tidak Ada Pergerakan Mutasi"
        Me.btnTdkBergerak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTdkBergerak.UseVisualStyleBackColor = True
        '
        'btnGerak
        '
        Me.btnGerak.Image = CType(resources.GetObject("btnGerak.Image"), System.Drawing.Image)
        Me.btnGerak.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGerak.Location = New System.Drawing.Point(467, 7)
        Me.btnGerak.Name = "btnGerak"
        Me.btnGerak.Size = New System.Drawing.Size(89, 50)
        Me.btnGerak.TabIndex = 28
        Me.btnGerak.Text = "Yang Ada Pergerakan Mutasi"
        Me.btnGerak.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGerak.UseVisualStyleBackColor = True
        '
        'btnStok0
        '
        Me.btnStok0.Image = CType(resources.GetObject("btnStok0.Image"), System.Drawing.Image)
        Me.btnStok0.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStok0.Location = New System.Drawing.Point(283, 7)
        Me.btnStok0.Name = "btnStok0"
        Me.btnStok0.Size = New System.Drawing.Size(89, 50)
        Me.btnStok0.TabIndex = 27
        Me.btnStok0.Text = "Stok < 0"
        Me.btnStok0.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnStok0.UseVisualStyleBackColor = True
        '
        'btnUrutNama
        '
        Me.btnUrutNama.Image = CType(resources.GetObject("btnUrutNama.Image"), System.Drawing.Image)
        Me.btnUrutNama.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUrutNama.Location = New System.Drawing.Point(192, 7)
        Me.btnUrutNama.Name = "btnUrutNama"
        Me.btnUrutNama.Size = New System.Drawing.Size(89, 50)
        Me.btnUrutNama.TabIndex = 26
        Me.btnUrutNama.Text = "Semua Urut Nama"
        Me.btnUrutNama.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUrutNama.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(15, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(173, 20)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Jenis"
        '
        'TabPageAdv1
        '
        Me.TabPageAdv1.Controls.Add(Me.btnUpdateStok)
        Me.TabPageAdv1.Image = Nothing
        Me.TabPageAdv1.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv1.Location = New System.Drawing.Point(1, 22)
        Me.TabPageAdv1.Name = "TabPageAdv1"
        Me.TabPageAdv1.ShowCloseButton = True
        Me.TabPageAdv1.Size = New System.Drawing.Size(1102, 64)
        Me.TabPageAdv1.TabIndex = 3
        Me.TabPageAdv1.Text = "Update Stok Barang"
        Me.TabPageAdv1.ThemesEnabled = False
        '
        'btnUpdateStok
        '
        Me.btnUpdateStok.Image = CType(resources.GetObject("btnUpdateStok.Image"), System.Drawing.Image)
        Me.btnUpdateStok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUpdateStok.Location = New System.Drawing.Point(8, 6)
        Me.btnUpdateStok.Name = "btnUpdateStok"
        Me.btnUpdateStok.Size = New System.Drawing.Size(103, 50)
        Me.btnUpdateStok.TabIndex = 32
        Me.btnUpdateStok.Text = "Update Stok"
        Me.btnUpdateStok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpdateStok.UseVisualStyleBackColor = True
        '
        'TabPageAdv2
        '
        Me.TabPageAdv2.Controls.Add(Me.btnTutupStok)
        Me.TabPageAdv2.Controls.Add(Me.DTPBulanTutup)
        Me.TabPageAdv2.Controls.Add(Me.Label7)
        Me.TabPageAdv2.Controls.Add(Me.DTPTahunTutup)
        Me.TabPageAdv2.Controls.Add(Me.Label6)
        Me.TabPageAdv2.Controls.Add(Me.DTPBulanAwal)
        Me.TabPageAdv2.Controls.Add(Me.Label4)
        Me.TabPageAdv2.Controls.Add(Me.DTPTahunAwal)
        Me.TabPageAdv2.Controls.Add(Me.Label5)
        Me.TabPageAdv2.Image = Nothing
        Me.TabPageAdv2.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPageAdv2.Location = New System.Drawing.Point(1, 22)
        Me.TabPageAdv2.Name = "TabPageAdv2"
        Me.TabPageAdv2.ShowCloseButton = True
        Me.TabPageAdv2.Size = New System.Drawing.Size(1102, 64)
        Me.TabPageAdv2.TabIndex = 4
        Me.TabPageAdv2.Text = "Tutup Stok Perbulan"
        Me.TabPageAdv2.ThemesEnabled = False
        '
        'btnTutupStok
        '
        Me.btnTutupStok.Image = CType(resources.GetObject("btnTutupStok.Image"), System.Drawing.Image)
        Me.btnTutupStok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTutupStok.Location = New System.Drawing.Point(355, 8)
        Me.btnTutupStok.Name = "btnTutupStok"
        Me.btnTutupStok.Size = New System.Drawing.Size(128, 50)
        Me.btnTutupStok.TabIndex = 34
        Me.btnTutupStok.Text = "Proses Tutup Stok"
        Me.btnTutupStok.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTutupStok.UseVisualStyleBackColor = True
        '
        'DTPBulanTutup
        '
        Me.DTPBulanTutup.CustomFormat = "MMMM"
        Me.DTPBulanTutup.Enabled = False
        Me.DTPBulanTutup.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPBulanTutup.Location = New System.Drawing.Point(100, 34)
        Me.DTPBulanTutup.Name = "DTPBulanTutup"
        Me.DTPBulanTutup.ShowUpDown = True
        Me.DTPBulanTutup.Size = New System.Drawing.Size(129, 20)
        Me.DTPBulanTutup.TabIndex = 33
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(231, 38)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Tahun"
        '
        'DTPTahunTutup
        '
        Me.DTPTahunTutup.CustomFormat = "yyyy"
        Me.DTPTahunTutup.Enabled = False
        Me.DTPTahunTutup.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTahunTutup.Location = New System.Drawing.Point(275, 34)
        Me.DTPTahunTutup.Name = "DTPTahunTutup"
        Me.DTPTahunTutup.ShowUpDown = True
        Me.DTPTahunTutup.Size = New System.Drawing.Size(61, 20)
        Me.DTPTahunTutup.TabIndex = 31
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "Ditutup Ke Bulan"
        '
        'DTPBulanAwal
        '
        Me.DTPBulanAwal.CustomFormat = "MMMM"
        Me.DTPBulanAwal.Enabled = False
        Me.DTPBulanAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPBulanAwal.Location = New System.Drawing.Point(100, 11)
        Me.DTPBulanAwal.Name = "DTPBulanAwal"
        Me.DTPBulanAwal.ShowUpDown = True
        Me.DTPBulanAwal.Size = New System.Drawing.Size(129, 20)
        Me.DTPBulanAwal.TabIndex = 29
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(231, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Tahun"
        '
        'DTPTahunAwal
        '
        Me.DTPTahunAwal.CustomFormat = "yyyy"
        Me.DTPTahunAwal.Enabled = False
        Me.DTPTahunAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTahunAwal.Location = New System.Drawing.Point(275, 11)
        Me.DTPTahunAwal.Name = "DTPTahunAwal"
        Me.DTPTahunAwal.ShowUpDown = True
        Me.DTPTahunAwal.Size = New System.Drawing.Size(61, 20)
        Me.DTPTahunAwal.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Stok Bulan"
        '
        'FormStokPerbulan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1110, 636)
        Me.Controls.Add(Me.gridObat)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox10)
        Me.Controls.Add(Me.GroupBox9)
        Me.Name = "FormStokPerbulan"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stok Perbulan"
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridObat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.TabControlStok, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlStok.ResumeLayout(False)
        Me.Tab1.ResumeLayout(False)
        Me.Tab1.PerformLayout()
        Me.Tab2.ResumeLayout(False)
        Me.TabPageAdv1.ResumeLayout(False)
        Me.TabPageAdv2.ResumeLayout(False)
        Me.TabPageAdv2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DTPTahun As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBaruTab5 As System.Windows.Forms.Button
    Friend WithEvents btnProsesTab5 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnKeluar As System.Windows.Forms.Button
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtGrandTotal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents gridObat As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControlStok As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents Tab1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents Tab2 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents txtNamaBarang As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbJenisObat As System.Windows.Forms.ComboBox
    Friend WithEvents btnTdkBergerak As System.Windows.Forms.Button
    Friend WithEvents btnGerak As System.Windows.Forms.Button
    Friend WithEvents btnStok0 As System.Windows.Forms.Button
    Friend WithEvents btnUrutNama As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtQty As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TabPageAdv1 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents btnUpdateStok As System.Windows.Forms.Button
    Friend WithEvents TabPageAdv2 As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents DTPBulanTutup As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DTPTahunTutup As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DTPBulanAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTPTahunAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnTutupStok As System.Windows.Forms.Button
    Friend WithEvents btnStok1 As System.Windows.Forms.Button
    Friend WithEvents DTPBulan As DateTimePicker
End Class
