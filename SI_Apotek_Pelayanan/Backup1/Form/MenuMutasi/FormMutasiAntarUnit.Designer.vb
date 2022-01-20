<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMutasiAntarUnit
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMutasiAntarUnit))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbMode = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DTPBantu = New System.Windows.Forms.DateTimePicker()
        Me.cmbKeUnit = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbDariUnit = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DTPTanggalTrans = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtJmlHarga = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtStok = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtJmlMutasi = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblSatuan = New System.Windows.Forms.Label()
        Me.lblNamaObat = New System.Windows.Forms.Label()
        Me.txtHarga = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.txtIdxBarang = New System.Windows.Forms.TextBox()
        Me.txtKodeObat = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtQty = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtGrandTotalBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtGrandTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.btnHapusBaris = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btnKeluar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnBaru = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCetakNota = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnSimpan = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.gridDetailObat = New System.Windows.Forms.DataGridView()
        Me.PanelObat = New System.Windows.Forms.Panel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.gridBarang = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCariObat = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtJmlHarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtStok, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJmlMutasi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHarga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotalBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.gridDetailObat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelObat.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbMode)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DTPBantu)
        Me.GroupBox1.Controls.Add(Me.cmbKeUnit)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbDariUnit)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.DTPTanggalTrans)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtNota)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(838, 122)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbMode
        '
        Me.cmbMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMode.FormattingEnabled = True
        Me.cmbMode.Items.AddRange(New Object() {"Mutasi Antar Unit", "Mutasi Dari Gudang BPJS Ke Farmasi BPJS"})
        Me.cmbMode.Location = New System.Drawing.Point(598, 19)
        Me.cmbMode.Name = "cmbMode"
        Me.cmbMode.Size = New System.Drawing.Size(234, 21)
        Me.cmbMode.TabIndex = 55
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.SystemColors.Info
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(526, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 21)
        Me.Label5.TabIndex = 54
        Me.Label5.Text = "Jenis Mutasi"
        '
        'DTPBantu
        '
        Me.DTPBantu.Location = New System.Drawing.Point(701, 61)
        Me.DTPBantu.Name = "DTPBantu"
        Me.DTPBantu.Size = New System.Drawing.Size(125, 20)
        Me.DTPBantu.TabIndex = 53
        Me.DTPBantu.Visible = False
        '
        'cmbKeUnit
        '
        Me.cmbKeUnit.FormattingEnabled = True
        Me.cmbKeUnit.Location = New System.Drawing.Point(107, 89)
        Me.cmbKeUnit.Name = "cmbKeUnit"
        Me.cmbKeUnit.Size = New System.Drawing.Size(234, 21)
        Me.cmbKeUnit.TabIndex = 26
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "Ke Unit"
        '
        'cmbDariUnit
        '
        Me.cmbDariUnit.Enabled = False
        Me.cmbDariUnit.FormattingEnabled = True
        Me.cmbDariUnit.Location = New System.Drawing.Point(107, 65)
        Me.cmbDariUnit.Name = "cmbDariUnit"
        Me.cmbDariUnit.Size = New System.Drawing.Size(234, 21)
        Me.cmbDariUnit.TabIndex = 24
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Dari Unit"
        '
        'DTPTanggalTrans
        '
        Me.DTPTanggalTrans.Location = New System.Drawing.Point(107, 19)
        Me.DTPTanggalTrans.Name = "DTPTanggalTrans"
        Me.DTPTanggalTrans.Size = New System.Drawing.Size(234, 20)
        Me.DTPTanggalTrans.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Tanggal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Nota"
        '
        'txtNota
        '
        Me.txtNota.BackColor = System.Drawing.SystemColors.Control
        Me.txtNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNota.Location = New System.Drawing.Point(107, 42)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.ReadOnly = True
        Me.txtNota.Size = New System.Drawing.Size(234, 20)
        Me.txtNota.TabIndex = 18
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.txtJmlHarga)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtStok)
        Me.GroupBox2.Controls.Add(Me.txtJmlMutasi)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblSatuan)
        Me.GroupBox2.Controls.Add(Me.lblNamaObat)
        Me.GroupBox2.Controls.Add(Me.txtHarga)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.txtIdxBarang)
        Me.GroupBox2.Controls.Add(Me.txtKodeObat)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 122)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(838, 108)
        Me.GroupBox2.TabIndex = 15
        Me.GroupBox2.TabStop = False
        '
        'btnAdd
        '
        Me.btnAdd.BeforeTouchSize = New System.Drawing.Size(43, 65)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.IsBackStageButton = False
        Me.btnAdd.Location = New System.Drawing.Point(773, 22)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(43, 65)
        Me.btnAdd.TabIndex = 125
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtJmlHarga
        '
        Me.txtJmlHarga.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtJmlHarga.BeforeTouchSize = New System.Drawing.Size(150, 20)
        Me.txtJmlHarga.BorderColor = System.Drawing.Color.DimGray
        Me.txtJmlHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJmlHarga.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJmlHarga.CurrencySymbol = ""
        Me.txtJmlHarga.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJmlHarga.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJmlHarga.Location = New System.Drawing.Point(386, 45)
        Me.txtJmlHarga.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJmlHarga.Name = "txtJmlHarga"
        Me.txtJmlHarga.NullString = ""
        Me.txtJmlHarga.ReadOnly = True
        Me.txtJmlHarga.Size = New System.Drawing.Size(163, 20)
        Me.txtJmlHarga.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJmlHarga.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJmlHarga.TabIndex = 124
        Me.txtJmlHarga.Text = "0.00"
        Me.txtJmlHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(294, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(72, 13)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "Jumlah Harga"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 13)
        Me.Label9.TabIndex = 119
        Me.Label9.Text = "Jumlah Mutasi"
        '
        'txtStok
        '
        Me.txtStok.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtStok.BeforeTouchSize = New System.Drawing.Size(150, 20)
        Me.txtStok.BorderColor = System.Drawing.Color.DimGray
        Me.txtStok.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStok.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtStok.CurrencySymbol = ""
        Me.txtStok.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtStok.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtStok.Location = New System.Drawing.Point(386, 68)
        Me.txtStok.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtStok.Name = "txtStok"
        Me.txtStok.NullString = ""
        Me.txtStok.ReadOnly = True
        Me.txtStok.Size = New System.Drawing.Size(163, 20)
        Me.txtStok.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtStok.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtStok.TabIndex = 118
        Me.txtStok.Text = "0.00"
        Me.txtStok.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtJmlMutasi
        '
        Me.txtJmlMutasi.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtJmlMutasi.BeforeTouchSize = New System.Drawing.Size(150, 20)
        Me.txtJmlMutasi.BorderColor = System.Drawing.Color.DimGray
        Me.txtJmlMutasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJmlMutasi.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJmlMutasi.CurrencySymbol = ""
        Me.txtJmlMutasi.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJmlMutasi.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJmlMutasi.Location = New System.Drawing.Point(105, 68)
        Me.txtJmlMutasi.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJmlMutasi.Name = "txtJmlMutasi"
        Me.txtJmlMutasi.NullString = ""
        Me.txtJmlMutasi.Size = New System.Drawing.Size(92, 20)
        Me.txtJmlMutasi.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJmlMutasi.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJmlMutasi.TabIndex = 4
        Me.txtJmlMutasi.Text = "0.00"
        Me.txtJmlMutasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(294, 72)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(65, 13)
        Me.Label8.TabIndex = 117
        Me.Label8.Text = "Jumlah Stok"
        '
        'lblSatuan
        '
        Me.lblSatuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSatuan.Location = New System.Drawing.Point(203, 68)
        Me.lblSatuan.Name = "lblSatuan"
        Me.lblSatuan.Size = New System.Drawing.Size(65, 20)
        Me.lblSatuan.TabIndex = 115
        Me.lblSatuan.Text = "Satuan"
        '
        'lblNamaObat
        '
        Me.lblNamaObat.AutoSize = True
        Me.lblNamaObat.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaObat.Location = New System.Drawing.Point(293, 19)
        Me.lblNamaObat.Name = "lblNamaObat"
        Me.lblNamaObat.Size = New System.Drawing.Size(114, 24)
        Me.lblNamaObat.TabIndex = 114
        Me.lblNamaObat.Text = "Nama Obat"
        '
        'txtHarga
        '
        Me.txtHarga.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtHarga.BeforeTouchSize = New System.Drawing.Size(150, 20)
        Me.txtHarga.BorderColor = System.Drawing.Color.DimGray
        Me.txtHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHarga.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtHarga.CurrencySymbol = ""
        Me.txtHarga.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHarga.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHarga.Location = New System.Drawing.Point(105, 45)
        Me.txtHarga.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.NullString = ""
        Me.txtHarga.ReadOnly = True
        Me.txtHarga.Size = New System.Drawing.Size(163, 20)
        Me.txtHarga.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtHarga.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtHarga.TabIndex = 113
        Me.txtHarga.Text = "0.00"
        Me.txtHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(13, 49)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 13)
        Me.Label34.TabIndex = 112
        Me.Label34.Text = "Harga"
        '
        'txtIdxBarang
        '
        Me.txtIdxBarang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdxBarang.Location = New System.Drawing.Point(203, 22)
        Me.txtIdxBarang.Name = "txtIdxBarang"
        Me.txtIdxBarang.ReadOnly = True
        Me.txtIdxBarang.Size = New System.Drawing.Size(65, 20)
        Me.txtIdxBarang.TabIndex = 65
        '
        'txtKodeObat
        '
        Me.txtKodeObat.BackColor = System.Drawing.SystemColors.Info
        Me.txtKodeObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKodeObat.Location = New System.Drawing.Point(105, 22)
        Me.txtKodeObat.Name = "txtKodeObat"
        Me.txtKodeObat.Size = New System.Drawing.Size(92, 20)
        Me.txtKodeObat.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 19
        Me.Label11.Text = "Kode Barang"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtQty)
        Me.GroupBox5.Controls.Add(Me.Label43)
        Me.GroupBox5.Controls.Add(Me.txtGrandTotalBulat)
        Me.GroupBox5.Controls.Add(Me.txtGrandTotal)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.btnHapusBaris)
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox5.Location = New System.Drawing.Point(0, 465)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(838, 106)
        Me.GroupBox5.TabIndex = 20
        Me.GroupBox5.TabStop = False
        '
        'txtQty
        '
        Me.txtQty.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtQty.BeforeTouchSize = New System.Drawing.Size(150, 20)
        Me.txtQty.BorderColor = System.Drawing.Color.DimGray
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtQty.CurrencySymbol = ""
        Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQty.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(285, 12)
        Me.txtQty.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtQty.Name = "txtQty"
        Me.txtQty.NullString = ""
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(46, 20)
        Me.txtQty.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtQty.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtQty.TabIndex = 24
        Me.txtQty.Text = "0.00"
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Location = New System.Drawing.Point(226, 12)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(60, 20)
        Me.Label43.TabIndex = 23
        Me.Label43.Text = "Qty"
        '
        'txtGrandTotalBulat
        '
        Me.txtGrandTotalBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotalBulat.BeforeTouchSize = New System.Drawing.Size(150, 20)
        Me.txtGrandTotalBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotalBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotalBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotalBulat.CurrencySymbol = ""
        Me.txtGrandTotalBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotalBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotalBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotalBulat.Location = New System.Drawing.Point(70, 35)
        Me.txtGrandTotalBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotalBulat.Name = "txtGrandTotalBulat"
        Me.txtGrandTotalBulat.NullString = ""
        Me.txtGrandTotalBulat.ReadOnly = True
        Me.txtGrandTotalBulat.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandTotalBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotalBulat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtGrandTotalBulat.TabIndex = 22
        Me.txtGrandTotalBulat.Text = "0.00"
        Me.txtGrandTotalBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotal.BeforeTouchSize = New System.Drawing.Size(150, 20)
        Me.txtGrandTotal.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotal.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotal.CurrencySymbol = ""
        Me.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(70, 12)
        Me.txtGrandTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.NullString = ""
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandTotal.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotal.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtGrandTotal.TabIndex = 21
        Me.txtGrandTotal.Text = "0.00"
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label38
        '
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Location = New System.Drawing.Point(12, 12)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(60, 20)
        Me.Label38.TabIndex = 20
        Me.Label38.Text = "Total"
        '
        'btnHapusBaris
        '
        Me.btnHapusBaris.Location = New System.Drawing.Point(741, 12)
        Me.btnHapusBaris.Name = "btnHapusBaris"
        Me.btnHapusBaris.Size = New System.Drawing.Size(75, 23)
        Me.btnHapusBaris.TabIndex = 17
        Me.btnHapusBaris.Text = "Hapus Baris"
        Me.btnHapusBaris.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btnKeluar)
        Me.GroupBox7.Controls.Add(Me.btnBaru)
        Me.GroupBox7.Controls.Add(Me.btnCetakNota)
        Me.GroupBox7.Controls.Add(Me.btnSimpan)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox7.Location = New System.Drawing.Point(3, 51)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(832, 52)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        '
        'btnKeluar
        '
        Me.btnKeluar.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnKeluar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.IsBackStageButton = False
        Me.btnKeluar.Location = New System.Drawing.Point(363, 16)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 33)
        Me.btnKeluar.TabIndex = 6
        Me.btnKeluar.Text = "Keluar"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBaru
        '
        Me.btnBaru.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnBaru.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBaru.Image = CType(resources.GetObject("btnBaru.Image"), System.Drawing.Image)
        Me.btnBaru.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaru.IsBackStageButton = False
        Me.btnBaru.Location = New System.Drawing.Point(243, 16)
        Me.btnBaru.Name = "btnBaru"
        Me.btnBaru.Size = New System.Drawing.Size(120, 33)
        Me.btnBaru.TabIndex = 4
        Me.btnBaru.Text = "Baru [F10]"
        Me.btnBaru.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCetakNota
        '
        Me.btnCetakNota.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnCetakNota.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCetakNota.Image = CType(resources.GetObject("btnCetakNota.Image"), System.Drawing.Image)
        Me.btnCetakNota.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakNota.IsBackStageButton = False
        Me.btnCetakNota.Location = New System.Drawing.Point(123, 16)
        Me.btnCetakNota.Name = "btnCetakNota"
        Me.btnCetakNota.Size = New System.Drawing.Size(120, 33)
        Me.btnCetakNota.TabIndex = 2
        Me.btnCetakNota.Text = "Cetak Nota [F1]"
        Me.btnCetakNota.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSimpan
        '
        Me.btnSimpan.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnSimpan.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.IsBackStageButton = False
        Me.btnSimpan.Location = New System.Drawing.Point(3, 16)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 33)
        Me.btnSimpan.TabIndex = 1
        Me.btnSimpan.Text = "Simpan [F12]"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gridDetailObat
        '
        Me.gridDetailObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDetailObat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDetailObat.Location = New System.Drawing.Point(0, 230)
        Me.gridDetailObat.Name = "gridDetailObat"
        Me.gridDetailObat.RowHeadersWidth = 60
        Me.gridDetailObat.Size = New System.Drawing.Size(838, 235)
        Me.gridDetailObat.TabIndex = 21
        '
        'PanelObat
        '
        Me.PanelObat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelObat.Controls.Add(Me.GroupBox12)
        Me.PanelObat.Controls.Add(Me.GroupBox11)
        Me.PanelObat.Location = New System.Drawing.Point(96, 230)
        Me.PanelObat.Name = "PanelObat"
        Me.PanelObat.Size = New System.Drawing.Size(609, 321)
        Me.PanelObat.TabIndex = 22
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
        'FormMutasiAntarUnit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(838, 571)
        Me.Controls.Add(Me.PanelObat)
        Me.Controls.Add(Me.gridDetailObat)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormMutasiAntarUnit"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mutasi Barang Ke Unit"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtJmlHarga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtStok, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJmlMutasi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHarga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotalBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.gridDetailObat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelObat.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents DTPTanggalTrans As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbKeUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbDariUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtJmlHarga As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtStok As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtJmlMutasi As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblSatuan As System.Windows.Forms.Label
    Friend WithEvents lblNamaObat As System.Windows.Forms.Label
    Friend WithEvents txtHarga As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents txtIdxBarang As System.Windows.Forms.TextBox
    Friend WithEvents txtKodeObat As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents txtQty As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtGrandTotalBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtGrandTotal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents btnHapusBaris As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnKeluar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnBaru As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnCetakNota As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnSimpan As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents gridDetailObat As System.Windows.Forms.DataGridView
    Friend WithEvents btnAdd As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents PanelObat As System.Windows.Forms.Panel
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCariObat As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents DTPBantu As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbMode As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
