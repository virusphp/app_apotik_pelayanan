<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLaporanRekapHarianPenjualanResep
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLaporanRekapHarianPenjualanResep))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.cmbKriteria = New System.Windows.Forms.ComboBox()
        Me.rSemua = New System.Windows.Forms.RadioButton()
        Me.rKasir = New System.Windows.Forms.RadioButton()
        Me.rDokter = New System.Windows.Forms.RadioButton()
        Me.rPoli = New System.Windows.Forms.RadioButton()
        Me.btnBaruTab1 = New System.Windows.Forms.Button()
        Me.btnExcelTab1 = New System.Windows.Forms.Button()
        Me.btnProsesTab1 = New System.Windows.Forms.Button()
        Me.cmbPilihan = New System.Windows.Forms.ComboBox()
        Me.lblPilihan = New System.Windows.Forms.Label()
        Me.DTPTanggalAkhir = New System.Windows.Forms.DateTimePicker()
        Me.DTPTanggalAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbJenisPasien = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbBagian = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbPenjamin = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtTotalSeluruh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalObat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtJumlahRacik = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtJumlahNota = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GridObat = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtJumlahItem = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtTotalSeluruh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalObat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlahRacik, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlahNota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridObat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlahItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.btnBaruTab1)
        Me.GroupBox1.Controls.Add(Me.btnExcelTab1)
        Me.GroupBox1.Controls.Add(Me.btnProsesTab1)
        Me.GroupBox1.Controls.Add(Me.cmbPilihan)
        Me.GroupBox1.Controls.Add(Me.lblPilihan)
        Me.GroupBox1.Controls.Add(Me.DTPTanggalAkhir)
        Me.GroupBox1.Controls.Add(Me.DTPTanggalAwal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbJenisPasien)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cmbBagian)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cmbPenjamin)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1110, 117)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnOk)
        Me.GroupBox2.Controls.Add(Me.cmbKriteria)
        Me.GroupBox2.Controls.Add(Me.rSemua)
        Me.GroupBox2.Controls.Add(Me.rKasir)
        Me.GroupBox2.Controls.Add(Me.rDokter)
        Me.GroupBox2.Controls.Add(Me.rPoli)
        Me.GroupBox2.Location = New System.Drawing.Point(619, 10)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(293, 96)
        Me.GroupBox2.TabIndex = 26
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Filter"
        '
        'btnOk
        '
        Me.btnOk.Image = CType(resources.GetObject("btnOk.Image"), System.Drawing.Image)
        Me.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnOk.Location = New System.Drawing.Point(216, 66)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(59, 25)
        Me.btnOk.TabIndex = 6
        Me.btnOk.Text = "Ok"
        Me.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'cmbKriteria
        '
        Me.cmbKriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbKriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbKriteria.Enabled = False
        Me.cmbKriteria.FormattingEnabled = True
        Me.cmbKriteria.Location = New System.Drawing.Point(11, 42)
        Me.cmbKriteria.Name = "cmbKriteria"
        Me.cmbKriteria.Size = New System.Drawing.Size(266, 21)
        Me.cmbKriteria.TabIndex = 5
        '
        'rSemua
        '
        Me.rSemua.AutoSize = True
        Me.rSemua.Checked = True
        Me.rSemua.Location = New System.Drawing.Point(11, 19)
        Me.rSemua.Name = "rSemua"
        Me.rSemua.Size = New System.Drawing.Size(58, 17)
        Me.rSemua.TabIndex = 1
        Me.rSemua.TabStop = True
        Me.rSemua.Text = "Semua"
        Me.rSemua.UseVisualStyleBackColor = True
        '
        'rKasir
        '
        Me.rKasir.AutoSize = True
        Me.rKasir.Location = New System.Drawing.Point(215, 20)
        Me.rKasir.Name = "rKasir"
        Me.rKasir.Size = New System.Drawing.Size(67, 17)
        Me.rKasir.TabIndex = 4
        Me.rKasir.Text = "Per Kasir"
        Me.rKasir.UseVisualStyleBackColor = True
        '
        'rDokter
        '
        Me.rDokter.AutoSize = True
        Me.rDokter.Location = New System.Drawing.Point(135, 20)
        Me.rDokter.Name = "rDokter"
        Me.rDokter.Size = New System.Drawing.Size(76, 17)
        Me.rDokter.TabIndex = 3
        Me.rDokter.Text = "Per Dokter"
        Me.rDokter.UseVisualStyleBackColor = True
        '
        'rPoli
        '
        Me.rPoli.AutoSize = True
        Me.rPoli.Location = New System.Drawing.Point(70, 19)
        Me.rPoli.Name = "rPoli"
        Me.rPoli.Size = New System.Drawing.Size(61, 17)
        Me.rPoli.TabIndex = 2
        Me.rPoli.Text = "Per Poli"
        Me.rPoli.UseVisualStyleBackColor = True
        '
        'btnBaruTab1
        '
        Me.btnBaruTab1.Image = CType(resources.GetObject("btnBaruTab1.Image"), System.Drawing.Image)
        Me.btnBaruTab1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaruTab1.Location = New System.Drawing.Point(482, 68)
        Me.btnBaruTab1.Name = "btnBaruTab1"
        Me.btnBaruTab1.Size = New System.Drawing.Size(85, 35)
        Me.btnBaruTab1.TabIndex = 10
        Me.btnBaruTab1.Text = "Baru"
        Me.btnBaruTab1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaruTab1.UseVisualStyleBackColor = True
        '
        'btnExcelTab1
        '
        Me.btnExcelTab1.Image = CType(resources.GetObject("btnExcelTab1.Image"), System.Drawing.Image)
        Me.btnExcelTab1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcelTab1.Location = New System.Drawing.Point(391, 68)
        Me.btnExcelTab1.Name = "btnExcelTab1"
        Me.btnExcelTab1.Size = New System.Drawing.Size(85, 35)
        Me.btnExcelTab1.TabIndex = 9
        Me.btnExcelTab1.Text = "Ke Excel"
        Me.btnExcelTab1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcelTab1.UseVisualStyleBackColor = True
        '
        'btnProsesTab1
        '
        Me.btnProsesTab1.Image = CType(resources.GetObject("btnProsesTab1.Image"), System.Drawing.Image)
        Me.btnProsesTab1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesTab1.Location = New System.Drawing.Point(300, 68)
        Me.btnProsesTab1.Name = "btnProsesTab1"
        Me.btnProsesTab1.Size = New System.Drawing.Size(85, 35)
        Me.btnProsesTab1.TabIndex = 8
        Me.btnProsesTab1.Text = "Proses"
        Me.btnProsesTab1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesTab1.UseVisualStyleBackColor = True
        '
        'cmbPilihan
        '
        Me.cmbPilihan.FormattingEnabled = True
        Me.cmbPilihan.Items.AddRange(New Object() {"", "Semua", "Dijamin", "Iur Pasien"})
        Me.cmbPilihan.Location = New System.Drawing.Point(82, 87)
        Me.cmbPilihan.Name = "cmbPilihan"
        Me.cmbPilihan.Size = New System.Drawing.Size(200, 21)
        Me.cmbPilihan.TabIndex = 4
        Me.cmbPilihan.Visible = False
        '
        'lblPilihan
        '
        Me.lblPilihan.AutoSize = True
        Me.lblPilihan.Location = New System.Drawing.Point(13, 90)
        Me.lblPilihan.Name = "lblPilihan"
        Me.lblPilihan.Size = New System.Drawing.Size(38, 13)
        Me.lblPilihan.TabIndex = 25
        Me.lblPilihan.Text = "Pilihan"
        Me.lblPilihan.Visible = False
        '
        'DTPTanggalAkhir
        '
        Me.DTPTanggalAkhir.Location = New System.Drawing.Point(402, 39)
        Me.DTPTanggalAkhir.Name = "DTPTanggalAkhir"
        Me.DTPTanggalAkhir.Size = New System.Drawing.Size(164, 20)
        Me.DTPTanggalAkhir.TabIndex = 6
        '
        'DTPTanggalAwal
        '
        Me.DTPTanggalAwal.Location = New System.Drawing.Point(402, 16)
        Me.DTPTanggalAwal.Name = "DTPTanggalAwal"
        Me.DTPTanggalAwal.Size = New System.Drawing.Size(164, 20)
        Me.DTPTanggalAwal.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(297, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Sampai Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(297, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Dari Tanggal"
        '
        'cmbJenisPasien
        '
        Me.cmbJenisPasien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbJenisPasien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbJenisPasien.FormattingEnabled = True
        Me.cmbJenisPasien.Location = New System.Drawing.Point(82, 63)
        Me.cmbJenisPasien.Name = "cmbJenisPasien"
        Me.cmbJenisPasien.Size = New System.Drawing.Size(200, 21)
        Me.cmbJenisPasien.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Jenis Pasien"
        '
        'cmbBagian
        '
        Me.cmbBagian.FormattingEnabled = True
        Me.cmbBagian.Location = New System.Drawing.Point(82, 39)
        Me.cmbBagian.Name = "cmbBagian"
        Me.cmbBagian.Size = New System.Drawing.Size(200, 21)
        Me.cmbBagian.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Bagian"
        '
        'cmbPenjamin
        '
        Me.cmbPenjamin.FormattingEnabled = True
        Me.cmbPenjamin.Location = New System.Drawing.Point(82, 16)
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
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txtJumlahItem)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtTotalSeluruh)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txtTotalObat)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtJumlahRacik)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txtJumlahNota)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 574)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1110, 62)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.Location = New System.Drawing.Point(955, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 20)
        Me.Label10.TabIndex = 36
        Me.Label10.Text = "Total Seluruh"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalSeluruh
        '
        Me.txtTotalSeluruh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalSeluruh.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalSeluruh.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalSeluruh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalSeluruh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalSeluruh.CurrencySymbol = ""
        Me.txtTotalSeluruh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalSeluruh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalSeluruh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalSeluruh.Location = New System.Drawing.Point(955, 34)
        Me.txtTotalSeluruh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalSeluruh.Name = "txtTotalSeluruh"
        Me.txtTotalSeluruh.NullString = ""
        Me.txtTotalSeluruh.ReadOnly = True
        Me.txtTotalSeluruh.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalSeluruh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalSeluruh.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalSeluruh.TabIndex = 35
        Me.txtTotalSeluruh.Text = "0.00"
        Me.txtTotalSeluruh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(815, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(141, 20)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Total Obat"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtTotalObat
        '
        Me.txtTotalObat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalObat.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtTotalObat.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalObat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalObat.CurrencySymbol = ""
        Me.txtTotalObat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalObat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalObat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalObat.Location = New System.Drawing.Point(815, 34)
        Me.txtTotalObat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalObat.Name = "txtTotalObat"
        Me.txtTotalObat.NullString = ""
        Me.txtTotalObat.ReadOnly = True
        Me.txtTotalObat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalObat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalObat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalObat.TabIndex = 29
        Me.txtTotalObat.Text = "0.00"
        Me.txtTotalObat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(535, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(141, 20)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Jumlah R"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtJumlahRacik
        '
        Me.txtJumlahRacik.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJumlahRacik.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtJumlahRacik.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahRacik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahRacik.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahRacik.CurrencySymbol = ""
        Me.txtJumlahRacik.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahRacik.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahRacik.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJumlahRacik.Location = New System.Drawing.Point(535, 34)
        Me.txtJumlahRacik.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahRacik.Name = "txtJumlahRacik"
        Me.txtJumlahRacik.NullString = ""
        Me.txtJumlahRacik.ReadOnly = True
        Me.txtJumlahRacik.Size = New System.Drawing.Size(141, 20)
        Me.txtJumlahRacik.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahRacik.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJumlahRacik.TabIndex = 27
        Me.txtJumlahRacik.Text = "0.00"
        Me.txtJumlahRacik.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(395, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(141, 20)
        Me.Label11.TabIndex = 26
        Me.Label11.Text = "Jumlah Nota"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtJumlahNota
        '
        Me.txtJumlahNota.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJumlahNota.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtJumlahNota.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahNota.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahNota.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahNota.CurrencySymbol = ""
        Me.txtJumlahNota.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahNota.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJumlahNota.Location = New System.Drawing.Point(395, 34)
        Me.txtJumlahNota.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahNota.Name = "txtJumlahNota"
        Me.txtJumlahNota.NullString = ""
        Me.txtJumlahNota.ReadOnly = True
        Me.txtJumlahNota.Size = New System.Drawing.Size(141, 20)
        Me.txtJumlahNota.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahNota.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJumlahNota.TabIndex = 25
        Me.txtJumlahNota.Text = "0.00"
        Me.txtJumlahNota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GridObat
        '
        Me.GridObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridObat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridObat.Location = New System.Drawing.Point(0, 117)
        Me.GridObat.Name = "GridObat"
        Me.GridObat.Size = New System.Drawing.Size(1110, 457)
        Me.GridObat.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(675, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(141, 20)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Jumlah Item"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtJumlahItem
        '
        Me.txtJumlahItem.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJumlahItem.BeforeTouchSize = New System.Drawing.Size(141, 20)
        Me.txtJumlahItem.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahItem.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahItem.CurrencySymbol = ""
        Me.txtJumlahItem.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahItem.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJumlahItem.Location = New System.Drawing.Point(675, 34)
        Me.txtJumlahItem.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahItem.Name = "txtJumlahItem"
        Me.txtJumlahItem.NullString = ""
        Me.txtJumlahItem.ReadOnly = True
        Me.txtJumlahItem.Size = New System.Drawing.Size(141, 20)
        Me.txtJumlahItem.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahItem.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJumlahItem.TabIndex = 37
        Me.txtJumlahItem.Text = "0.00"
        Me.txtJumlahItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FormLaporanRekapHarianPenjualanResep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1110, 636)
        Me.Controls.Add(Me.GridObat)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormLaporanRekapHarianPenjualanResep"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Rekap Harian Penjualan Resep"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtTotalSeluruh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalObat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlahRacik, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlahNota, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridObat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlahItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbJenisPasien As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbBagian As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPenjamin As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTPTanggalAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPTanggalAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbPilihan As System.Windows.Forms.ComboBox
    Friend WithEvents lblPilihan As System.Windows.Forms.Label
    Friend WithEvents btnBaruTab1 As System.Windows.Forms.Button
    Friend WithEvents btnExcelTab1 As System.Windows.Forms.Button
    Friend WithEvents btnProsesTab1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbKriteria As System.Windows.Forms.ComboBox
    Friend WithEvents rSemua As System.Windows.Forms.RadioButton
    Friend WithEvents rKasir As System.Windows.Forms.RadioButton
    Friend WithEvents rDokter As System.Windows.Forms.RadioButton
    Friend WithEvents rPoli As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSeluruh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalObat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtJumlahRacik As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtJumlahNota As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GridObat As System.Windows.Forms.DataGridView
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtJumlahItem As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class
