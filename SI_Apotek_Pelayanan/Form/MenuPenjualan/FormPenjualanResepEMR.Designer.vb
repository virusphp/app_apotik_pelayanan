<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPenjualanResepEMR
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
        Me.components = New System.ComponentModel.Container()
        Dim btnTelaah As System.Windows.Forms.Button
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPenjualanResepEMR))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TabControlAdv1 = New Syncfusion.Windows.Forms.Tools.TabControlAdv()
        Me.TabPktUmum = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.gridDetailObat = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.txtQty = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.txtHapusBaris = New System.Windows.Forms.Button()
        Me.txtGrandIurBayarBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtGrandDijaminBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtGrandTotalBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtGrandIurBayar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtGrandDijamin = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtGrandTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.gridEtiket = New System.Windows.Forms.DataGridView()
        Me.btnUpdateDijamin = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnUpdateIurPasien = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnKeluar = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnInfoResep = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnBaru = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCetakEtiket = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCetakNota = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnSimpan = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GROU = New System.Windows.Forms.GroupBox()
        Me.txtJmlBungkus = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.gridPelayananObat = New System.Windows.Forms.DataGridView()
        Me.DTPCekObat = New System.Windows.Forms.DateTimePicker()
        Me.DTPTanggalExp = New System.Windows.Forms.DateTimePicker()
        Me.btnAdd = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtIuranSisaBayar = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtDijamin = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtJumlahHarga = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtDosisResep = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtJumlahJual = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtHargaJual = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtDosis = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtSenPotBeli = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.cmbEtiket = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DTPTglAkhir = New System.Windows.Forms.DateTimePicker()
        Me.txtJmlHari = New Syncfusion.Windows.Forms.Tools.IntegerTextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.cmbDijamin = New System.Windows.Forms.ComboBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.DoubleTextBox7 = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.lblNamaObat = New System.Windows.Forms.Label()
        Me.txtKdSatuan = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtSatDosis = New System.Windows.Forms.TextBox()
        Me.txtIdObat = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtKodeObat = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cmbRacikNon = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtJam = New System.Windows.Forms.TextBox()
        Me.TabPktKhusus = New Syncfusion.Windows.Forms.Tools.TabPageAdv()
        Me.gridDetailObatKh = New System.Windows.Forms.DataGridView()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.txtQtyKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.txtGrandTotalNonPaketBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtGrandTotalPaketBulat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtGrandTotalNonPaket = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtGrandTotalPaket = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btnKeluarKh = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnInfoResepKh = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnBaruKh = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCetakEtiketKh = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCetakLain = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnCetakBPJS = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.btnSimpanKh = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.txtTotalPaketLainKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtTotalPaketBPJSKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtJmlCapBPJSKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.txtPaketLainKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtSatPaketLainKh = New System.Windows.Forms.TextBox()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.btnAddKh = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtJmlCapLainKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtJmlObatKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtDosisResepKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtPaketBPJSKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtHargaJualKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtDosisKh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.cmbEtiketKh = New System.Windows.Forms.ComboBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.DTPTglAkhirKh = New System.Windows.Forms.DateTimePicker()
        Me.txtJmlHariKh = New Syncfusion.Windows.Forms.Tools.IntegerTextBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lblNamaObatKh = New System.Windows.Forms.Label()
        Me.txtSatPaketBPJSKh = New System.Windows.Forms.TextBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.txtSatDosisKh = New System.Windows.Forms.TextBox()
        Me.txtIdObatKh = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.txtKodeObatKh = New System.Windows.Forms.TextBox()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.cmbRacikNonKh = New System.Windows.Forms.ComboBox()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.PanelEtiketModel4 = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.cbMalam = New System.Windows.Forms.CheckBox()
        Me.cbSore = New System.Windows.Forms.CheckBox()
        Me.rInjeksi = New System.Windows.Forms.RadioButton()
        Me.cbInjeksi = New System.Windows.Forms.CheckBox()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.rSesudah = New System.Windows.Forms.RadioButton()
        Me.rBersama = New System.Windows.Forms.RadioButton()
        Me.rSebelum = New System.Windows.Forms.RadioButton()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.cbSiang = New System.Windows.Forms.CheckBox()
        Me.cbPagi = New System.Windows.Forms.CheckBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.txtNamaObatEtiketModel4 = New System.Windows.Forms.TextBox()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.PanelEtiketModel3 = New System.Windows.Forms.Panel()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.txtJarakEDModel3 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.txtJumlahObatEtiketModel3 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.cmbKeteranganModel3 = New System.Windows.Forms.ComboBox()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.txtNamaObatEtiketModel3 = New System.Windows.Forms.TextBox()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.PanelPasien = New System.Windows.Forms.Panel()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.gridPasien = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.lblKetDaftar = New System.Windows.Forms.Label()
        Me.btnEx = New System.Windows.Forms.Button()
        Me.DTPPasienReg = New System.Windows.Forms.DateTimePicker()
        Me.txtCariPasien = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rNama = New System.Windows.Forms.RadioButton()
        Me.rRm = New System.Windows.Forms.RadioButton()
        Me.PanelEtiketInfus = New System.Windows.Forms.Panel()
        Me.txtTetesInfus = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtObatInfus = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.btnModel1 = New System.Windows.Forms.Button()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.txtJumlahObatEtiketInfus = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtNamaObatEtiketInfus = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.PanelEtiket = New System.Windows.Forms.Panel()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnModel2 = New System.Windows.Forms.Button()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.txtJarakED = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.txtJumlahObatEtiket = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtSigna2 = New System.Windows.Forms.TextBox()
        Me.txtSigna1 = New System.Windows.Forms.TextBox()
        Me.txtNamaObatEtiket = New System.Windows.Forms.TextBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.cmbKeterangan = New System.Windows.Forms.ComboBox()
        Me.cmbWaktu = New System.Windows.Forms.ComboBox()
        Me.cmbTakaran = New System.Windows.Forms.ComboBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtQty3 = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCariObat = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PanelObat = New System.Windows.Forms.Panel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.gridBarang = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPTanggalTrans = New System.Windows.Forms.DateTimePicker()
        Me.txtNoResep = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNoReg = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNoKartu = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNoUrut = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtRM = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtSex = New System.Windows.Forms.TextBox()
        Me.txtUmurThn = New System.Windows.Forms.TextBox()
        Me.txtUmurBln = New System.Windows.Forms.TextBox()
        Me.txtNamaPasien = New System.Windows.Forms.TextBox()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbUnitAsal = New System.Windows.Forms.ComboBox()
        Me.cmbPenjamin = New System.Windows.Forms.ComboBox()
        Me.cmbDokter = New System.Windows.Forms.ComboBox()
        Me.txtNota = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.txtNoSEP = New System.Windows.Forms.TextBox()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.cmbPkt = New System.Windows.Forms.ComboBox()
        Me.PanelResepDokter = New System.Windows.Forms.Panel()
        Me.gridPermintaanObat = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.txtPPN = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.txtLaba = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.lblKamarBed = New System.Windows.Forms.Label()
        Me.DTPJamAkhir = New System.Windows.Forms.DateTimePicker()
        Me.DTPJamAwal = New System.Windows.Forms.DateTimePicker()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmbJenisRawat = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblIteration = New System.Windows.Forms.Label()
        Me.GBObatRacikan = New System.Windows.Forms.GroupBox()
        Me.gridObatRacikan = New System.Windows.Forms.DataGridView()
        Me.Pilih = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GBObatJadi = New System.Windows.Forms.GroupBox()
        Me.gridObatJadi = New System.Windows.Forms.DataGridView()
        Me.ButtonOk = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnPrinResep = New System.Windows.Forms.Button()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.btnObatRacik = New System.Windows.Forms.Button()
        Me.btnObtJadi = New System.Windows.Forms.Button()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        btnTelaah = New System.Windows.Forms.Button()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlAdv1.SuspendLayout()
        Me.TabPktUmum.SuspendLayout()
        CType(Me.gridDetailObat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandIurBayarBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandDijaminBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotalBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandIurBayar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandDijamin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.gridEtiket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GROU.SuspendLayout()
        CType(Me.txtJmlBungkus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridPelayananObat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtIuranSisaBayar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDijamin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlahHarga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDosisResep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlahJual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHargaJual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDosis, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSenPotBeli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJmlHari, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DoubleTextBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPktKhusus.SuspendLayout()
        CType(Me.gridDetailObatKh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.txtQtyKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotalNonPaketBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotalPaketBulat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotalNonPaket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGrandTotalPaket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.txtTotalPaketLainKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalPaketBPJSKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJmlCapBPJSKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaketLainKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJmlCapLainKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJmlObatKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDosisResepKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPaketBPJSKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtHargaJualKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDosisKh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJmlHariKh, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEtiketModel4.SuspendLayout()
        Me.PanelEtiketModel3.SuspendLayout()
        CType(Me.txtJarakEDModel3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlahObatEtiketModel3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPasien.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.gridPasien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.PanelEtiketInfus.SuspendLayout()
        CType(Me.txtJumlahObatEtiketInfus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelEtiket.SuspendLayout()
        CType(Me.txtJarakED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlahObatEtiket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQty3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.PanelObat.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.PanelResepDokter.SuspendLayout()
        CType(Me.gridPermintaanObat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLaba, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GBObatRacikan.SuspendLayout()
        CType(Me.gridObatRacikan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBObatJadi.SuspendLayout()
        CType(Me.gridObatJadi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnTelaah
        '
        btnTelaah.BackColor = System.Drawing.Color.DarkOrange
        btnTelaah.Dock = System.Windows.Forms.DockStyle.Top
        btnTelaah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        btnTelaah.ForeColor = System.Drawing.Color.Linen
        btnTelaah.Location = New System.Drawing.Point(0, 190)
        btnTelaah.Name = "btnTelaah"
        btnTelaah.Size = New System.Drawing.Size(26, 27)
        btnTelaah.TabIndex = 4
        btnTelaah.Text = "T"
        btnTelaah.UseVisualStyleBackColor = False
        AddHandler btnTelaah.Click, AddressOf Me.btnTelaah_Click
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TabControlAdv1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.Location = New System.Drawing.Point(307, 235)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1042, 401)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'TabControlAdv1
        '
        Me.TabControlAdv1.ActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.BeforeTouchSize = New System.Drawing.Size(1036, 382)
        Me.TabControlAdv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabControlAdv1.CloseButtonForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonHoverForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.CloseButtonPressedForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.Controls.Add(Me.TabPktUmum)
        Me.TabControlAdv1.Controls.Add(Me.TabPktKhusus)
        Me.TabControlAdv1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlAdv1.FocusOnTabClick = False
        Me.TabControlAdv1.InActiveTabForeColor = System.Drawing.Color.Empty
        Me.TabControlAdv1.Location = New System.Drawing.Point(3, 16)
        Me.TabControlAdv1.Name = "TabControlAdv1"
        Me.TabControlAdv1.SeparatorColor = System.Drawing.SystemColors.ControlDark
        Me.TabControlAdv1.ShowSeparator = False
        Me.TabControlAdv1.Size = New System.Drawing.Size(1036, 382)
        Me.TabControlAdv1.TabIndex = 0
        Me.TabControlAdv1.TabStyle = GetType(Syncfusion.Windows.Forms.Tools.TabRendererMetro)
        '
        'TabPktUmum
        '
        Me.TabPktUmum.Controls.Add(Me.gridDetailObat)
        Me.TabPktUmum.Controls.Add(Me.GroupBox5)
        Me.TabPktUmum.Controls.Add(Me.GROU)
        Me.TabPktUmum.Image = Nothing
        Me.TabPktUmum.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPktUmum.Location = New System.Drawing.Point(1, 22)
        Me.TabPktUmum.Name = "TabPktUmum"
        Me.TabPktUmum.ShowCloseButton = True
        Me.TabPktUmum.Size = New System.Drawing.Size(1034, 359)
        Me.TabPktUmum.TabIndex = 1
        Me.TabPktUmum.TabVisible = False
        Me.TabPktUmum.Text = "Paket Umum"
        Me.TabPktUmum.ThemesEnabled = False
        '
        'gridDetailObat
        '
        Me.gridDetailObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDetailObat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDetailObat.Location = New System.Drawing.Point(0, 138)
        Me.gridDetailObat.Name = "gridDetailObat"
        Me.gridDetailObat.RowHeadersWidth = 60
        Me.gridDetailObat.Size = New System.Drawing.Size(1034, 115)
        Me.gridDetailObat.TabIndex = 2
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.txtQty)
        Me.GroupBox5.Controls.Add(Me.Label43)
        Me.GroupBox5.Controls.Add(Me.txtHapusBaris)
        Me.GroupBox5.Controls.Add(Me.txtGrandIurBayarBulat)
        Me.GroupBox5.Controls.Add(Me.txtGrandDijaminBulat)
        Me.GroupBox5.Controls.Add(Me.txtGrandTotalBulat)
        Me.GroupBox5.Controls.Add(Me.txtGrandIurBayar)
        Me.GroupBox5.Controls.Add(Me.txtGrandDijamin)
        Me.GroupBox5.Controls.Add(Me.txtGrandTotal)
        Me.GroupBox5.Controls.Add(Me.Label40)
        Me.GroupBox5.Controls.Add(Me.Label39)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox5.Location = New System.Drawing.Point(0, 253)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1034, 106)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        '
        'txtQty
        '
        Me.txtQty.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtQty.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtQty.BorderColor = System.Drawing.Color.DimGray
        Me.txtQty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtQty.CurrencySymbol = ""
        Me.txtQty.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQty.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQty.Location = New System.Drawing.Point(706, 12)
        Me.txtQty.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtQty.Name = "txtQty"
        Me.txtQty.NullString = ""
        Me.txtQty.ReadOnly = True
        Me.txtQty.Size = New System.Drawing.Size(46, 20)
        Me.txtQty.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtQty.TabIndex = 19
        Me.txtQty.Text = "0.00"
        Me.txtQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label43
        '
        Me.Label43.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label43.Location = New System.Drawing.Point(647, 12)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(60, 20)
        Me.Label43.TabIndex = 18
        Me.Label43.Text = "Qty"
        '
        'txtHapusBaris
        '
        Me.txtHapusBaris.Dock = System.Windows.Forms.DockStyle.Right
        Me.txtHapusBaris.Location = New System.Drawing.Point(956, 16)
        Me.txtHapusBaris.Name = "txtHapusBaris"
        Me.txtHapusBaris.Size = New System.Drawing.Size(75, 35)
        Me.txtHapusBaris.TabIndex = 17
        Me.txtHapusBaris.Text = "Hapus Baris"
        Me.txtHapusBaris.UseVisualStyleBackColor = True
        '
        'txtGrandIurBayarBulat
        '
        Me.txtGrandIurBayarBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandIurBayarBulat.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandIurBayarBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandIurBayarBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandIurBayarBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandIurBayarBulat.CurrencySymbol = ""
        Me.txtGrandIurBayarBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandIurBayarBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandIurBayarBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandIurBayarBulat.Location = New System.Drawing.Point(492, 31)
        Me.txtGrandIurBayarBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandIurBayarBulat.Name = "txtGrandIurBayarBulat"
        Me.txtGrandIurBayarBulat.NullString = ""
        Me.txtGrandIurBayarBulat.ReadOnly = True
        Me.txtGrandIurBayarBulat.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandIurBayarBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandIurBayarBulat.TabIndex = 16
        Me.txtGrandIurBayarBulat.Text = "0.00"
        Me.txtGrandIurBayarBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandDijaminBulat
        '
        Me.txtGrandDijaminBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandDijaminBulat.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandDijaminBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandDijaminBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandDijaminBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandDijaminBulat.CurrencySymbol = ""
        Me.txtGrandDijaminBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandDijaminBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandDijaminBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandDijaminBulat.Location = New System.Drawing.Point(277, 31)
        Me.txtGrandDijaminBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandDijaminBulat.Name = "txtGrandDijaminBulat"
        Me.txtGrandDijaminBulat.NullString = ""
        Me.txtGrandDijaminBulat.ReadOnly = True
        Me.txtGrandDijaminBulat.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandDijaminBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandDijaminBulat.TabIndex = 15
        Me.txtGrandDijaminBulat.Text = "0.00"
        Me.txtGrandDijaminBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotalBulat
        '
        Me.txtGrandTotalBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotalBulat.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandTotalBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotalBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotalBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotalBulat.CurrencySymbol = ""
        Me.txtGrandTotalBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotalBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotalBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotalBulat.Location = New System.Drawing.Point(62, 31)
        Me.txtGrandTotalBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotalBulat.Name = "txtGrandTotalBulat"
        Me.txtGrandTotalBulat.NullString = ""
        Me.txtGrandTotalBulat.ReadOnly = True
        Me.txtGrandTotalBulat.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandTotalBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotalBulat.TabIndex = 14
        Me.txtGrandTotalBulat.Text = "0.00"
        Me.txtGrandTotalBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandIurBayar
        '
        Me.txtGrandIurBayar.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandIurBayar.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandIurBayar.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandIurBayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandIurBayar.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandIurBayar.CurrencySymbol = ""
        Me.txtGrandIurBayar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandIurBayar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandIurBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandIurBayar.Location = New System.Drawing.Point(492, 12)
        Me.txtGrandIurBayar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandIurBayar.Name = "txtGrandIurBayar"
        Me.txtGrandIurBayar.NullString = ""
        Me.txtGrandIurBayar.ReadOnly = True
        Me.txtGrandIurBayar.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandIurBayar.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandIurBayar.TabIndex = 13
        Me.txtGrandIurBayar.Text = "0.00"
        Me.txtGrandIurBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandDijamin
        '
        Me.txtGrandDijamin.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandDijamin.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandDijamin.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandDijamin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandDijamin.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandDijamin.CurrencySymbol = ""
        Me.txtGrandDijamin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandDijamin.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandDijamin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandDijamin.Location = New System.Drawing.Point(277, 12)
        Me.txtGrandDijamin.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandDijamin.Name = "txtGrandDijamin"
        Me.txtGrandDijamin.NullString = ""
        Me.txtGrandDijamin.ReadOnly = True
        Me.txtGrandDijamin.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandDijamin.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandDijamin.TabIndex = 12
        Me.txtGrandDijamin.Text = "0.00"
        Me.txtGrandDijamin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotal
        '
        Me.txtGrandTotal.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotal.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandTotal.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotal.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotal.CurrencySymbol = ""
        Me.txtGrandTotal.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotal.Location = New System.Drawing.Point(62, 12)
        Me.txtGrandTotal.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotal.Name = "txtGrandTotal"
        Me.txtGrandTotal.NullString = ""
        Me.txtGrandTotal.ReadOnly = True
        Me.txtGrandTotal.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandTotal.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotal.TabIndex = 11
        Me.txtGrandTotal.Text = "0.00"
        Me.txtGrandTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label40
        '
        Me.Label40.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label40.Location = New System.Drawing.Point(433, 12)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(60, 20)
        Me.Label40.TabIndex = 10
        Me.Label40.Text = "Iur Bayar"
        '
        'Label39
        '
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.Location = New System.Drawing.Point(218, 12)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(60, 20)
        Me.Label39.TabIndex = 9
        Me.Label39.Text = "Dijamin"
        '
        'Label38
        '
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.Location = New System.Drawing.Point(4, 12)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(60, 20)
        Me.Label38.TabIndex = 8
        Me.Label38.Text = "Total"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.gridEtiket)
        Me.GroupBox7.Controls.Add(Me.btnUpdateDijamin)
        Me.GroupBox7.Controls.Add(Me.btnUpdateIurPasien)
        Me.GroupBox7.Controls.Add(Me.btnKeluar)
        Me.GroupBox7.Controls.Add(Me.btnInfoResep)
        Me.GroupBox7.Controls.Add(Me.btnBaru)
        Me.GroupBox7.Controls.Add(Me.btnCetakEtiket)
        Me.GroupBox7.Controls.Add(Me.btnCetakNota)
        Me.GroupBox7.Controls.Add(Me.btnSimpan)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox7.Location = New System.Drawing.Point(3, 51)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(1028, 52)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        '
        'gridEtiket
        '
        Me.gridEtiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridEtiket.Location = New System.Drawing.Point(877, 18)
        Me.gridEtiket.Name = "gridEtiket"
        Me.gridEtiket.Size = New System.Drawing.Size(10, 29)
        Me.gridEtiket.TabIndex = 31
        Me.gridEtiket.Visible = False
        '
        'btnUpdateDijamin
        '
        Me.btnUpdateDijamin.BeforeTouchSize = New System.Drawing.Size(100, 33)
        Me.btnUpdateDijamin.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnUpdateDijamin.Image = CType(resources.GetObject("btnUpdateDijamin.Image"), System.Drawing.Image)
        Me.btnUpdateDijamin.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpdateDijamin.IsBackStageButton = False
        Me.btnUpdateDijamin.Location = New System.Drawing.Point(825, 16)
        Me.btnUpdateDijamin.Name = "btnUpdateDijamin"
        Me.btnUpdateDijamin.Size = New System.Drawing.Size(100, 33)
        Me.btnUpdateDijamin.TabIndex = 22
        Me.btnUpdateDijamin.Text = "Update Dijamin"
        Me.btnUpdateDijamin.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpdateDijamin.UseVisualStyleBackColor = False
        '
        'btnUpdateIurPasien
        '
        Me.btnUpdateIurPasien.BeforeTouchSize = New System.Drawing.Size(100, 33)
        Me.btnUpdateIurPasien.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnUpdateIurPasien.Image = CType(resources.GetObject("btnUpdateIurPasien.Image"), System.Drawing.Image)
        Me.btnUpdateIurPasien.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUpdateIurPasien.IsBackStageButton = False
        Me.btnUpdateIurPasien.Location = New System.Drawing.Point(925, 16)
        Me.btnUpdateIurPasien.Name = "btnUpdateIurPasien"
        Me.btnUpdateIurPasien.Size = New System.Drawing.Size(100, 33)
        Me.btnUpdateIurPasien.TabIndex = 23
        Me.btnUpdateIurPasien.Text = "Update Iur Paien"
        Me.btnUpdateIurPasien.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpdateIurPasien.UseVisualStyleBackColor = False
        '
        'btnKeluar
        '
        Me.btnKeluar.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnKeluar.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.IsBackStageButton = False
        Me.btnKeluar.Location = New System.Drawing.Point(603, 16)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(120, 33)
        Me.btnKeluar.TabIndex = 6
        Me.btnKeluar.Text = "Keluar"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnInfoResep
        '
        Me.btnInfoResep.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnInfoResep.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnInfoResep.Image = CType(resources.GetObject("btnInfoResep.Image"), System.Drawing.Image)
        Me.btnInfoResep.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInfoResep.IsBackStageButton = False
        Me.btnInfoResep.Location = New System.Drawing.Point(483, 16)
        Me.btnInfoResep.Name = "btnInfoResep"
        Me.btnInfoResep.Size = New System.Drawing.Size(120, 33)
        Me.btnInfoResep.TabIndex = 5
        Me.btnInfoResep.Text = "Info Resep [F4]"
        Me.btnInfoResep.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBaru
        '
        Me.btnBaru.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnBaru.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBaru.Image = CType(resources.GetObject("btnBaru.Image"), System.Drawing.Image)
        Me.btnBaru.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaru.IsBackStageButton = False
        Me.btnBaru.Location = New System.Drawing.Point(363, 16)
        Me.btnBaru.Name = "btnBaru"
        Me.btnBaru.Size = New System.Drawing.Size(120, 33)
        Me.btnBaru.TabIndex = 4
        Me.btnBaru.Text = "Baru [F10]"
        Me.btnBaru.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCetakEtiket
        '
        Me.btnCetakEtiket.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnCetakEtiket.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCetakEtiket.Image = CType(resources.GetObject("btnCetakEtiket.Image"), System.Drawing.Image)
        Me.btnCetakEtiket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakEtiket.IsBackStageButton = False
        Me.btnCetakEtiket.Location = New System.Drawing.Point(243, 16)
        Me.btnCetakEtiket.Name = "btnCetakEtiket"
        Me.btnCetakEtiket.Size = New System.Drawing.Size(120, 33)
        Me.btnCetakEtiket.TabIndex = 3
        Me.btnCetakEtiket.Text = "Etiket [F5]"
        Me.btnCetakEtiket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.btnCetakNota.Text = "Nota Resep [F1]"
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
        'GROU
        '
        Me.GROU.Controls.Add(Me.txtJmlBungkus)
        Me.GROU.Controls.Add(Me.gridPelayananObat)
        Me.GROU.Controls.Add(Me.DTPCekObat)
        Me.GROU.Controls.Add(Me.DTPTanggalExp)
        Me.GROU.Controls.Add(Me.btnAdd)
        Me.GROU.Controls.Add(Me.txtIuranSisaBayar)
        Me.GROU.Controls.Add(Me.txtDijamin)
        Me.GROU.Controls.Add(Me.txtJumlahHarga)
        Me.GROU.Controls.Add(Me.txtDosisResep)
        Me.GROU.Controls.Add(Me.txtJumlahJual)
        Me.GROU.Controls.Add(Me.txtHargaJual)
        Me.GROU.Controls.Add(Me.txtDosis)
        Me.GROU.Controls.Add(Me.txtSenPotBeli)
        Me.GROU.Controls.Add(Me.cmbEtiket)
        Me.GROU.Controls.Add(Me.Label31)
        Me.GROU.Controls.Add(Me.DTPTglAkhir)
        Me.GROU.Controls.Add(Me.txtJmlHari)
        Me.GROU.Controls.Add(Me.Label30)
        Me.GROU.Controls.Add(Me.Label29)
        Me.GROU.Controls.Add(Me.cmbDijamin)
        Me.GROU.Controls.Add(Me.Label28)
        Me.GROU.Controls.Add(Me.Label27)
        Me.GROU.Controls.Add(Me.DoubleTextBox7)
        Me.GROU.Controls.Add(Me.Label26)
        Me.GROU.Controls.Add(Me.Label25)
        Me.GROU.Controls.Add(Me.Label24)
        Me.GROU.Controls.Add(Me.Label23)
        Me.GROU.Controls.Add(Me.lblNamaObat)
        Me.GROU.Controls.Add(Me.txtKdSatuan)
        Me.GROU.Controls.Add(Me.Label21)
        Me.GROU.Controls.Add(Me.Label20)
        Me.GROU.Controls.Add(Me.txtSatDosis)
        Me.GROU.Controls.Add(Me.txtIdObat)
        Me.GROU.Controls.Add(Me.Label19)
        Me.GROU.Controls.Add(Me.txtKodeObat)
        Me.GROU.Controls.Add(Me.Label18)
        Me.GROU.Controls.Add(Me.cmbRacikNon)
        Me.GROU.Controls.Add(Me.Label17)
        Me.GROU.Controls.Add(Me.txtJam)
        Me.GROU.Dock = System.Windows.Forms.DockStyle.Top
        Me.GROU.Location = New System.Drawing.Point(0, 0)
        Me.GROU.Name = "GROU"
        Me.GROU.Size = New System.Drawing.Size(1034, 138)
        Me.GROU.TabIndex = 0
        Me.GROU.TabStop = False
        '
        'txtJmlBungkus
        '
        Me.txtJmlBungkus.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJmlBungkus.BorderColor = System.Drawing.Color.DimGray
        Me.txtJmlBungkus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJmlBungkus.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJmlBungkus.CurrencySymbol = ""
        Me.txtJmlBungkus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJmlBungkus.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJmlBungkus.Location = New System.Drawing.Point(532, 64)
        Me.txtJmlBungkus.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJmlBungkus.Name = "txtJmlBungkus"
        Me.txtJmlBungkus.NullString = ""
        Me.txtJmlBungkus.Size = New System.Drawing.Size(97, 20)
        Me.txtJmlBungkus.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJmlBungkus.TabIndex = 112
        Me.txtJmlBungkus.Text = "0.00"
        Me.txtJmlBungkus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gridPelayananObat
        '
        Me.gridPelayananObat.AllowUserToAddRows = False
        Me.gridPelayananObat.AllowUserToDeleteRows = False
        Me.gridPelayananObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPelayananObat.Location = New System.Drawing.Point(642, 354)
        Me.gridPelayananObat.Name = "gridPelayananObat"
        Me.gridPelayananObat.ReadOnly = True
        Me.gridPelayananObat.Size = New System.Drawing.Size(240, 150)
        Me.gridPelayananObat.TabIndex = 100
        Me.gridPelayananObat.Visible = False
        '
        'DTPCekObat
        '
        Me.DTPCekObat.Enabled = False
        Me.DTPCekObat.Location = New System.Drawing.Point(662, 16)
        Me.DTPCekObat.Name = "DTPCekObat"
        Me.DTPCekObat.Size = New System.Drawing.Size(131, 20)
        Me.DTPCekObat.TabIndex = 99
        Me.DTPCekObat.Visible = False
        '
        'DTPTanggalExp
        '
        Me.DTPTanggalExp.Enabled = False
        Me.DTPTanggalExp.Location = New System.Drawing.Point(799, 16)
        Me.DTPTanggalExp.Name = "DTPTanggalExp"
        Me.DTPTanggalExp.Size = New System.Drawing.Size(131, 20)
        Me.DTPTanggalExp.TabIndex = 98
        Me.DTPTanggalExp.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.BeforeTouchSize = New System.Drawing.Size(43, 65)
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAdd.IsBackStageButton = False
        Me.btnAdd.Location = New System.Drawing.Point(882, 61)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(43, 65)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtIuranSisaBayar
        '
        Me.txtIuranSisaBayar.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtIuranSisaBayar.BorderColor = System.Drawing.Color.DimGray
        Me.txtIuranSisaBayar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIuranSisaBayar.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtIuranSisaBayar.CurrencySymbol = ""
        Me.txtIuranSisaBayar.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtIuranSisaBayar.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtIuranSisaBayar.Enabled = False
        Me.txtIuranSisaBayar.Location = New System.Drawing.Point(681, 107)
        Me.txtIuranSisaBayar.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtIuranSisaBayar.Name = "txtIuranSisaBayar"
        Me.txtIuranSisaBayar.NullString = ""
        Me.txtIuranSisaBayar.Size = New System.Drawing.Size(108, 20)
        Me.txtIuranSisaBayar.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtIuranSisaBayar.TabIndex = 97
        Me.txtIuranSisaBayar.Text = "0.00"
        Me.txtIuranSisaBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDijamin
        '
        Me.txtDijamin.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtDijamin.BorderColor = System.Drawing.Color.DimGray
        Me.txtDijamin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDijamin.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtDijamin.CurrencySymbol = ""
        Me.txtDijamin.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDijamin.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDijamin.Location = New System.Drawing.Point(532, 108)
        Me.txtDijamin.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDijamin.Name = "txtDijamin"
        Me.txtDijamin.NullString = ""
        Me.txtDijamin.Size = New System.Drawing.Size(97, 20)
        Me.txtDijamin.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtDijamin.TabIndex = 96
        Me.txtDijamin.Text = "0.00"
        Me.txtDijamin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtJumlahHarga
        '
        Me.txtJumlahHarga.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJumlahHarga.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahHarga.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahHarga.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahHarga.CurrencySymbol = ""
        Me.txtJumlahHarga.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahHarga.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahHarga.Enabled = False
        Me.txtJumlahHarga.Location = New System.Drawing.Point(344, 108)
        Me.txtJumlahHarga.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahHarga.Name = "txtJumlahHarga"
        Me.txtJumlahHarga.NullString = ""
        Me.txtJumlahHarga.Size = New System.Drawing.Size(91, 20)
        Me.txtJumlahHarga.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahHarga.TabIndex = 95
        Me.txtJumlahHarga.Text = "0.00"
        Me.txtJumlahHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDosisResep
        '
        Me.txtDosisResep.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtDosisResep.BorderColor = System.Drawing.Color.DimGray
        Me.txtDosisResep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDosisResep.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtDosisResep.CurrencySymbol = ""
        Me.txtDosisResep.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDosisResep.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDosisResep.Enabled = False
        Me.txtDosisResep.Location = New System.Drawing.Point(344, 63)
        Me.txtDosisResep.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDosisResep.Name = "txtDosisResep"
        Me.txtDosisResep.NullString = ""
        Me.txtDosisResep.Size = New System.Drawing.Size(91, 20)
        Me.txtDosisResep.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtDosisResep.TabIndex = 94
        Me.txtDosisResep.Text = "0.00"
        Me.txtDosisResep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtJumlahJual
        '
        Me.txtJumlahJual.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJumlahJual.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJumlahJual.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahJual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahJual.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahJual.CurrencySymbol = ""
        Me.txtJumlahJual.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahJual.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahJual.Location = New System.Drawing.Point(100, 108)
        Me.txtJumlahJual.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahJual.Name = "txtJumlahJual"
        Me.txtJumlahJual.NullString = ""
        Me.txtJumlahJual.Size = New System.Drawing.Size(88, 20)
        Me.txtJumlahJual.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahJual.TabIndex = 4
        Me.txtJumlahJual.Text = "0.00"
        Me.txtJumlahJual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHargaJual
        '
        Me.txtHargaJual.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtHargaJual.BorderColor = System.Drawing.Color.DimGray
        Me.txtHargaJual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHargaJual.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtHargaJual.CurrencySymbol = ""
        Me.txtHargaJual.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHargaJual.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHargaJual.Location = New System.Drawing.Point(100, 86)
        Me.txtHargaJual.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHargaJual.Name = "txtHargaJual"
        Me.txtHargaJual.NullString = ""
        Me.txtHargaJual.Size = New System.Drawing.Size(163, 20)
        Me.txtHargaJual.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtHargaJual.TabIndex = 92
        Me.txtHargaJual.Text = "0.00"
        Me.txtHargaJual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDosis
        '
        Me.txtDosis.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtDosis.BorderColor = System.Drawing.Color.DimGray
        Me.txtDosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDosis.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtDosis.CurrencySymbol = ""
        Me.txtDosis.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDosis.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDosis.Location = New System.Drawing.Point(100, 64)
        Me.txtDosis.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDosis.Name = "txtDosis"
        Me.txtDosis.NullString = ""
        Me.txtDosis.Size = New System.Drawing.Size(88, 20)
        Me.txtDosis.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtDosis.TabIndex = 91
        Me.txtDosis.Text = "0.00"
        Me.txtDosis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSenPotBeli
        '
        Me.txtSenPotBeli.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtSenPotBeli.BorderColor = System.Drawing.Color.DimGray
        Me.txtSenPotBeli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSenPotBeli.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtSenPotBeli.CurrencySymbol = ""
        Me.txtSenPotBeli.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtSenPotBeli.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSenPotBeli.Location = New System.Drawing.Point(344, 86)
        Me.txtSenPotBeli.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtSenPotBeli.Name = "txtSenPotBeli"
        Me.txtSenPotBeli.NullString = ""
        Me.txtSenPotBeli.Size = New System.Drawing.Size(91, 20)
        Me.txtSenPotBeli.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtSenPotBeli.TabIndex = 90
        Me.txtSenPotBeli.Text = "0.00"
        Me.txtSenPotBeli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbEtiket
        '
        Me.cmbEtiket.BackColor = System.Drawing.SystemColors.Info
        Me.cmbEtiket.FormattingEnabled = True
        Me.cmbEtiket.Items.AddRange(New Object() {"N", "Y"})
        Me.cmbEtiket.Location = New System.Drawing.Point(841, 106)
        Me.cmbEtiket.Name = "cmbEtiket"
        Me.cmbEtiket.Size = New System.Drawing.Size(37, 21)
        Me.cmbEtiket.TabIndex = 6
        Me.cmbEtiket.Text = "N"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(791, 111)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(34, 13)
        Me.Label31.TabIndex = 88
        Me.Label31.Text = "Etiket"
        '
        'DTPTglAkhir
        '
        Me.DTPTglAkhir.Enabled = False
        Me.DTPTglAkhir.Location = New System.Drawing.Point(747, 85)
        Me.DTPTglAkhir.Name = "DTPTglAkhir"
        Me.DTPTglAkhir.Size = New System.Drawing.Size(131, 20)
        Me.DTPTglAkhir.TabIndex = 87
        '
        'txtJmlHari
        '
        Me.txtJmlHari.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJmlHari.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJmlHari.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJmlHari.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtJmlHari.IntegerValue = CType(0, Long)
        Me.txtJmlHari.Location = New System.Drawing.Point(841, 62)
        Me.txtJmlHari.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJmlHari.Name = "txtJmlHari"
        Me.txtJmlHari.NullString = ""
        Me.txtJmlHari.Size = New System.Drawing.Size(37, 20)
        Me.txtJmlHari.TabIndex = 5
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(791, 65)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(44, 13)
        Me.Label30.TabIndex = 85
        Me.Label30.Text = "Jml Hari"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(633, 111)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(31, 13)
        Me.Label29.TabIndex = 83
        Me.Label29.Text = "Iuran"
        '
        'cmbDijamin
        '
        Me.cmbDijamin.BackColor = System.Drawing.SystemColors.Info
        Me.cmbDijamin.FormattingEnabled = True
        Me.cmbDijamin.Items.AddRange(New Object() {"N", "Y"})
        Me.cmbDijamin.Location = New System.Drawing.Point(681, 62)
        Me.cmbDijamin.Name = "cmbDijamin"
        Me.cmbDijamin.Size = New System.Drawing.Size(107, 21)
        Me.cmbDijamin.TabIndex = 3
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(633, 66)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(41, 13)
        Me.Label28.TabIndex = 81
        Me.Label28.Text = "Dijamin"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(441, 112)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(41, 13)
        Me.Label27.TabIndex = 80
        Me.Label27.Text = "Dijamin"
        '
        'DoubleTextBox7
        '
        Me.DoubleTextBox7.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.DoubleTextBox7.BorderColor = System.Drawing.Color.DimGray
        Me.DoubleTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DoubleTextBox7.Culture = New System.Globalization.CultureInfo("en-US")
        Me.DoubleTextBox7.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.DoubleTextBox7.DoubleValue = 0R
        Me.DoubleTextBox7.Location = New System.Drawing.Point(532, 86)
        Me.DoubleTextBox7.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.DoubleTextBox7.Name = "DoubleTextBox7"
        Me.DoubleTextBox7.NullString = ""
        Me.DoubleTextBox7.Size = New System.Drawing.Size(96, 20)
        Me.DoubleTextBox7.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.DoubleTextBox7.TabIndex = 78
        Me.DoubleTextBox7.Text = "0.00"
        Me.DoubleTextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(441, 66)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(85, 13)
        Me.Label26.TabIndex = 76
        Me.Label26.Text = "Jumlah Bungkus"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(271, 110)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 13)
        Me.Label25.TabIndex = 73
        Me.Label25.Text = "Jumlah Harga"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(271, 89)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(29, 13)
        Me.Label24.TabIndex = 72
        Me.Label24.Text = "HPP"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(271, 66)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(67, 13)
        Me.Label23.TabIndex = 71
        Me.Label23.Text = "Dosis Resep"
        '
        'lblNamaObat
        '
        Me.lblNamaObat.AutoSize = True
        Me.lblNamaObat.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaObat.Location = New System.Drawing.Point(270, 20)
        Me.lblNamaObat.Name = "lblNamaObat"
        Me.lblNamaObat.Size = New System.Drawing.Size(0, 18)
        Me.lblNamaObat.TabIndex = 70
        '
        'txtKdSatuan
        '
        Me.txtKdSatuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKdSatuan.Enabled = False
        Me.txtKdSatuan.Location = New System.Drawing.Point(194, 108)
        Me.txtKdSatuan.Name = "txtKdSatuan"
        Me.txtKdSatuan.Size = New System.Drawing.Size(69, 20)
        Me.txtKdSatuan.TabIndex = 69
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(8, 112)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 13)
        Me.Label21.TabIndex = 65
        Me.Label21.Text = "Jumlah Jual"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(8, 89)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(58, 13)
        Me.Label20.TabIndex = 64
        Me.Label20.Text = "Harga Jual"
        '
        'txtSatDosis
        '
        Me.txtSatDosis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSatDosis.Enabled = False
        Me.txtSatDosis.Location = New System.Drawing.Point(194, 64)
        Me.txtSatDosis.Name = "txtSatDosis"
        Me.txtSatDosis.Size = New System.Drawing.Size(69, 20)
        Me.txtSatDosis.TabIndex = 63
        '
        'txtIdObat
        '
        Me.txtIdObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdObat.Enabled = False
        Me.txtIdObat.Location = New System.Drawing.Point(194, 42)
        Me.txtIdObat.Name = "txtIdObat"
        Me.txtIdObat.Size = New System.Drawing.Size(69, 20)
        Me.txtIdObat.TabIndex = 62
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(8, 67)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(58, 13)
        Me.Label19.TabIndex = 61
        Me.Label19.Text = "Dosis Stok"
        '
        'txtKodeObat
        '
        Me.txtKodeObat.BackColor = System.Drawing.SystemColors.Info
        Me.txtKodeObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKodeObat.Location = New System.Drawing.Point(100, 42)
        Me.txtKodeObat.Name = "txtKodeObat"
        Me.txtKodeObat.Size = New System.Drawing.Size(88, 20)
        Me.txtKodeObat.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(8, 45)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(48, 13)
        Me.Label18.TabIndex = 59
        Me.Label18.Text = "Kode/ID"
        '
        'cmbRacikNon
        '
        Me.cmbRacikNon.BackColor = System.Drawing.SystemColors.Info
        Me.cmbRacikNon.FormattingEnabled = True
        Me.cmbRacikNon.Items.AddRange(New Object() {"R", "N"})
        Me.cmbRacikNon.Location = New System.Drawing.Point(100, 19)
        Me.cmbRacikNon.Name = "cmbRacikNon"
        Me.cmbRacikNon.Size = New System.Drawing.Size(163, 21)
        Me.cmbRacikNon.TabIndex = 1
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 13)
        Me.Label17.TabIndex = 57
        Me.Label17.Text = "Racik/Non"
        '
        'txtJam
        '
        Me.txtJam.Location = New System.Drawing.Point(313, 22)
        Me.txtJam.Name = "txtJam"
        Me.txtJam.Size = New System.Drawing.Size(100, 20)
        Me.txtJam.TabIndex = 113
        Me.txtJam.Visible = False
        '
        'TabPktKhusus
        '
        Me.TabPktKhusus.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.TabPktKhusus.Controls.Add(Me.gridDetailObatKh)
        Me.TabPktKhusus.Controls.Add(Me.GroupBox6)
        Me.TabPktKhusus.Controls.Add(Me.GroupBox4)
        Me.TabPktKhusus.Image = Nothing
        Me.TabPktKhusus.ImageSize = New System.Drawing.Size(16, 16)
        Me.TabPktKhusus.Location = New System.Drawing.Point(1, 22)
        Me.TabPktKhusus.Name = "TabPktKhusus"
        Me.TabPktKhusus.ShowCloseButton = True
        Me.TabPktKhusus.Size = New System.Drawing.Size(1034, 359)
        Me.TabPktKhusus.TabIndex = 2
        Me.TabPktKhusus.TabVisible = False
        Me.TabPktKhusus.Text = "Paket Khusus"
        Me.TabPktKhusus.ThemesEnabled = False
        '
        'gridDetailObatKh
        '
        Me.gridDetailObatKh.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridDetailObatKh.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridDetailObatKh.Location = New System.Drawing.Point(0, 138)
        Me.gridDetailObatKh.Name = "gridDetailObatKh"
        Me.gridDetailObatKh.RowHeadersWidth = 60
        Me.gridDetailObatKh.Size = New System.Drawing.Size(1034, 116)
        Me.gridDetailObatKh.TabIndex = 3
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox6.Controls.Add(Me.txtQtyKh)
        Me.GroupBox6.Controls.Add(Me.Label50)
        Me.GroupBox6.Controls.Add(Me.Button2)
        Me.GroupBox6.Controls.Add(Me.txtGrandTotalNonPaketBulat)
        Me.GroupBox6.Controls.Add(Me.txtGrandTotalPaketBulat)
        Me.GroupBox6.Controls.Add(Me.txtGrandTotalNonPaket)
        Me.GroupBox6.Controls.Add(Me.txtGrandTotalPaket)
        Me.GroupBox6.Controls.Add(Me.Label57)
        Me.GroupBox6.Controls.Add(Me.Label58)
        Me.GroupBox6.Controls.Add(Me.GroupBox13)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox6.Location = New System.Drawing.Point(0, 254)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1034, 105)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        '
        'txtQtyKh
        '
        Me.txtQtyKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtQtyKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtQtyKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtQtyKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQtyKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtQtyKh.CurrencySymbol = ""
        Me.txtQtyKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQtyKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtQtyKh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyKh.Location = New System.Drawing.Point(553, 12)
        Me.txtQtyKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtQtyKh.Name = "txtQtyKh"
        Me.txtQtyKh.NullString = ""
        Me.txtQtyKh.ReadOnly = True
        Me.txtQtyKh.Size = New System.Drawing.Size(46, 20)
        Me.txtQtyKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtQtyKh.TabIndex = 21
        Me.txtQtyKh.Text = "0.00"
        Me.txtQtyKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label50
        '
        Me.Label50.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label50.Location = New System.Drawing.Point(494, 12)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(60, 20)
        Me.Label50.TabIndex = 20
        Me.Label50.Text = "Qty"
        '
        'Button2
        '
        Me.Button2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Button2.Location = New System.Drawing.Point(956, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 34)
        Me.Button2.TabIndex = 16
        Me.Button2.Text = "Hapus Baris"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'txtGrandTotalNonPaketBulat
        '
        Me.txtGrandTotalNonPaketBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotalNonPaketBulat.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandTotalNonPaketBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotalNonPaketBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotalNonPaketBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotalNonPaketBulat.CurrencySymbol = ""
        Me.txtGrandTotalNonPaketBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotalNonPaketBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotalNonPaketBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotalNonPaketBulat.Location = New System.Drawing.Point(338, 31)
        Me.txtGrandTotalNonPaketBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotalNonPaketBulat.Name = "txtGrandTotalNonPaketBulat"
        Me.txtGrandTotalNonPaketBulat.NullString = ""
        Me.txtGrandTotalNonPaketBulat.ReadOnly = True
        Me.txtGrandTotalNonPaketBulat.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandTotalNonPaketBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotalNonPaketBulat.TabIndex = 15
        Me.txtGrandTotalNonPaketBulat.Text = "0.00"
        Me.txtGrandTotalNonPaketBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotalPaketBulat
        '
        Me.txtGrandTotalPaketBulat.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotalPaketBulat.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandTotalPaketBulat.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotalPaketBulat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotalPaketBulat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotalPaketBulat.CurrencySymbol = ""
        Me.txtGrandTotalPaketBulat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotalPaketBulat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotalPaketBulat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotalPaketBulat.Location = New System.Drawing.Point(93, 31)
        Me.txtGrandTotalPaketBulat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotalPaketBulat.Name = "txtGrandTotalPaketBulat"
        Me.txtGrandTotalPaketBulat.NullString = ""
        Me.txtGrandTotalPaketBulat.ReadOnly = True
        Me.txtGrandTotalPaketBulat.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandTotalPaketBulat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotalPaketBulat.TabIndex = 14
        Me.txtGrandTotalPaketBulat.Text = "0.00"
        Me.txtGrandTotalPaketBulat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotalNonPaket
        '
        Me.txtGrandTotalNonPaket.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotalNonPaket.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandTotalNonPaket.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotalNonPaket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotalNonPaket.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotalNonPaket.CurrencySymbol = ""
        Me.txtGrandTotalNonPaket.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotalNonPaket.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotalNonPaket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotalNonPaket.Location = New System.Drawing.Point(338, 12)
        Me.txtGrandTotalNonPaket.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotalNonPaket.Name = "txtGrandTotalNonPaket"
        Me.txtGrandTotalNonPaket.NullString = ""
        Me.txtGrandTotalNonPaket.ReadOnly = True
        Me.txtGrandTotalNonPaket.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandTotalNonPaket.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotalNonPaket.TabIndex = 12
        Me.txtGrandTotalNonPaket.Text = "0.00"
        Me.txtGrandTotalNonPaket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtGrandTotalPaket
        '
        Me.txtGrandTotalPaket.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtGrandTotalPaket.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtGrandTotalPaket.BorderColor = System.Drawing.Color.DimGray
        Me.txtGrandTotalPaket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGrandTotalPaket.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtGrandTotalPaket.CurrencySymbol = ""
        Me.txtGrandTotalPaket.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtGrandTotalPaket.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrandTotalPaket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGrandTotalPaket.Location = New System.Drawing.Point(93, 12)
        Me.txtGrandTotalPaket.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtGrandTotalPaket.Name = "txtGrandTotalPaket"
        Me.txtGrandTotalPaket.NullString = ""
        Me.txtGrandTotalPaket.ReadOnly = True
        Me.txtGrandTotalPaket.Size = New System.Drawing.Size(150, 20)
        Me.txtGrandTotalPaket.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtGrandTotalPaket.TabIndex = 11
        Me.txtGrandTotalPaket.Text = "0.00"
        Me.txtGrandTotalPaket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label57
        '
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label57.Location = New System.Drawing.Point(249, 12)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(90, 20)
        Me.Label57.TabIndex = 9
        Me.Label57.Text = "Total Non Paket"
        '
        'Label58
        '
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label58.Location = New System.Drawing.Point(4, 12)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(90, 20)
        Me.Label58.TabIndex = 8
        Me.Label58.Text = "Total Paket"
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox13.Controls.Add(Me.btnKeluarKh)
        Me.GroupBox13.Controls.Add(Me.btnInfoResepKh)
        Me.GroupBox13.Controls.Add(Me.btnBaruKh)
        Me.GroupBox13.Controls.Add(Me.btnCetakEtiketKh)
        Me.GroupBox13.Controls.Add(Me.btnCetakLain)
        Me.GroupBox13.Controls.Add(Me.btnCetakBPJS)
        Me.GroupBox13.Controls.Add(Me.btnSimpanKh)
        Me.GroupBox13.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox13.Location = New System.Drawing.Point(3, 50)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(1028, 52)
        Me.GroupBox13.TabIndex = 1
        Me.GroupBox13.TabStop = False
        '
        'btnKeluarKh
        '
        Me.btnKeluarKh.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnKeluarKh.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnKeluarKh.Image = CType(resources.GetObject("btnKeluarKh.Image"), System.Drawing.Image)
        Me.btnKeluarKh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluarKh.IsBackStageButton = False
        Me.btnKeluarKh.Location = New System.Drawing.Point(723, 16)
        Me.btnKeluarKh.Name = "btnKeluarKh"
        Me.btnKeluarKh.Size = New System.Drawing.Size(120, 33)
        Me.btnKeluarKh.TabIndex = 5
        Me.btnKeluarKh.Text = "Keluar"
        Me.btnKeluarKh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnInfoResepKh
        '
        Me.btnInfoResepKh.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnInfoResepKh.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnInfoResepKh.Image = CType(resources.GetObject("btnInfoResepKh.Image"), System.Drawing.Image)
        Me.btnInfoResepKh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInfoResepKh.IsBackStageButton = False
        Me.btnInfoResepKh.Location = New System.Drawing.Point(603, 16)
        Me.btnInfoResepKh.Name = "btnInfoResepKh"
        Me.btnInfoResepKh.Size = New System.Drawing.Size(120, 33)
        Me.btnInfoResepKh.TabIndex = 4
        Me.btnInfoResepKh.Text = "Info Resep [F4]"
        Me.btnInfoResepKh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBaruKh
        '
        Me.btnBaruKh.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnBaruKh.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnBaruKh.Image = CType(resources.GetObject("btnBaruKh.Image"), System.Drawing.Image)
        Me.btnBaruKh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaruKh.IsBackStageButton = False
        Me.btnBaruKh.Location = New System.Drawing.Point(483, 16)
        Me.btnBaruKh.Name = "btnBaruKh"
        Me.btnBaruKh.Size = New System.Drawing.Size(120, 33)
        Me.btnBaruKh.TabIndex = 3
        Me.btnBaruKh.Text = "Baru [F10]"
        Me.btnBaruKh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCetakEtiketKh
        '
        Me.btnCetakEtiketKh.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnCetakEtiketKh.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCetakEtiketKh.Image = CType(resources.GetObject("btnCetakEtiketKh.Image"), System.Drawing.Image)
        Me.btnCetakEtiketKh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakEtiketKh.IsBackStageButton = False
        Me.btnCetakEtiketKh.Location = New System.Drawing.Point(363, 16)
        Me.btnCetakEtiketKh.Name = "btnCetakEtiketKh"
        Me.btnCetakEtiketKh.Size = New System.Drawing.Size(120, 33)
        Me.btnCetakEtiketKh.TabIndex = 2
        Me.btnCetakEtiketKh.Text = "Cetak Etiket [F5]"
        Me.btnCetakEtiketKh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCetakLain
        '
        Me.btnCetakLain.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnCetakLain.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCetakLain.Image = CType(resources.GetObject("btnCetakLain.Image"), System.Drawing.Image)
        Me.btnCetakLain.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakLain.IsBackStageButton = False
        Me.btnCetakLain.Location = New System.Drawing.Point(243, 16)
        Me.btnCetakLain.Name = "btnCetakLain"
        Me.btnCetakLain.Size = New System.Drawing.Size(120, 33)
        Me.btnCetakLain.TabIndex = 6
        Me.btnCetakLain.Text = "Cetak Paket Lain [F3]"
        Me.btnCetakLain.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCetakBPJS
        '
        Me.btnCetakBPJS.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnCetakBPJS.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnCetakBPJS.Image = CType(resources.GetObject("btnCetakBPJS.Image"), System.Drawing.Image)
        Me.btnCetakBPJS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCetakBPJS.IsBackStageButton = False
        Me.btnCetakBPJS.Location = New System.Drawing.Point(123, 16)
        Me.btnCetakBPJS.Name = "btnCetakBPJS"
        Me.btnCetakBPJS.Size = New System.Drawing.Size(120, 33)
        Me.btnCetakBPJS.TabIndex = 1
        Me.btnCetakBPJS.Text = "Cetak Pkt BPJS [F2]"
        Me.btnCetakBPJS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSimpanKh
        '
        Me.btnSimpanKh.BeforeTouchSize = New System.Drawing.Size(120, 33)
        Me.btnSimpanKh.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSimpanKh.Image = CType(resources.GetObject("btnSimpanKh.Image"), System.Drawing.Image)
        Me.btnSimpanKh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpanKh.IsBackStageButton = False
        Me.btnSimpanKh.Location = New System.Drawing.Point(3, 16)
        Me.btnSimpanKh.Name = "btnSimpanKh"
        Me.btnSimpanKh.Size = New System.Drawing.Size(120, 33)
        Me.btnSimpanKh.TabIndex = 0
        Me.btnSimpanKh.Text = "Simpan [F12]"
        Me.btnSimpanKh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.White
        Me.GroupBox4.Controls.Add(Me.txtTotalPaketLainKh)
        Me.GroupBox4.Controls.Add(Me.txtTotalPaketBPJSKh)
        Me.GroupBox4.Controls.Add(Me.txtJmlCapBPJSKh)
        Me.GroupBox4.Controls.Add(Me.Label44)
        Me.GroupBox4.Controls.Add(Me.txtPaketLainKh)
        Me.GroupBox4.Controls.Add(Me.txtSatPaketLainKh)
        Me.GroupBox4.Controls.Add(Me.Label59)
        Me.GroupBox4.Controls.Add(Me.btnAddKh)
        Me.GroupBox4.Controls.Add(Me.txtJmlCapLainKh)
        Me.GroupBox4.Controls.Add(Me.txtJmlObatKh)
        Me.GroupBox4.Controls.Add(Me.txtDosisResepKh)
        Me.GroupBox4.Controls.Add(Me.txtPaketBPJSKh)
        Me.GroupBox4.Controls.Add(Me.txtHargaJualKh)
        Me.GroupBox4.Controls.Add(Me.txtDosisKh)
        Me.GroupBox4.Controls.Add(Me.cmbEtiketKh)
        Me.GroupBox4.Controls.Add(Me.Label41)
        Me.GroupBox4.Controls.Add(Me.DTPTglAkhirKh)
        Me.GroupBox4.Controls.Add(Me.txtJmlHariKh)
        Me.GroupBox4.Controls.Add(Me.Label42)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.Label46)
        Me.GroupBox4.Controls.Add(Me.Label47)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.lblNamaObatKh)
        Me.GroupBox4.Controls.Add(Me.txtSatPaketBPJSKh)
        Me.GroupBox4.Controls.Add(Me.Label51)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.txtSatDosisKh)
        Me.GroupBox4.Controls.Add(Me.txtIdObatKh)
        Me.GroupBox4.Controls.Add(Me.Label53)
        Me.GroupBox4.Controls.Add(Me.txtKodeObatKh)
        Me.GroupBox4.Controls.Add(Me.Label54)
        Me.GroupBox4.Controls.Add(Me.cmbRacikNonKh)
        Me.GroupBox4.Controls.Add(Me.Label55)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1034, 138)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'txtTotalPaketLainKh
        '
        Me.txtTotalPaketLainKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalPaketLainKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtTotalPaketLainKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalPaketLainKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPaketLainKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalPaketLainKh.CurrencySymbol = ""
        Me.txtTotalPaketLainKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalPaketLainKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPaketLainKh.Enabled = False
        Me.txtTotalPaketLainKh.Location = New System.Drawing.Point(560, 108)
        Me.txtTotalPaketLainKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalPaketLainKh.Name = "txtTotalPaketLainKh"
        Me.txtTotalPaketLainKh.NullString = ""
        Me.txtTotalPaketLainKh.Size = New System.Drawing.Size(162, 20)
        Me.txtTotalPaketLainKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalPaketLainKh.TabIndex = 9
        Me.txtTotalPaketLainKh.Text = "0.00"
        Me.txtTotalPaketLainKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalPaketBPJSKh
        '
        Me.txtTotalPaketBPJSKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtTotalPaketBPJSKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtTotalPaketBPJSKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtTotalPaketBPJSKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalPaketBPJSKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtTotalPaketBPJSKh.CurrencySymbol = ""
        Me.txtTotalPaketBPJSKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTotalPaketBPJSKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalPaketBPJSKh.Enabled = False
        Me.txtTotalPaketBPJSKh.Location = New System.Drawing.Point(560, 86)
        Me.txtTotalPaketBPJSKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalPaketBPJSKh.Name = "txtTotalPaketBPJSKh"
        Me.txtTotalPaketBPJSKh.NullString = ""
        Me.txtTotalPaketBPJSKh.Size = New System.Drawing.Size(162, 20)
        Me.txtTotalPaketBPJSKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalPaketBPJSKh.TabIndex = 8
        Me.txtTotalPaketBPJSKh.Text = "0.00"
        Me.txtTotalPaketBPJSKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtJmlCapBPJSKh
        '
        Me.txtJmlCapBPJSKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJmlCapBPJSKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJmlCapBPJSKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtJmlCapBPJSKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJmlCapBPJSKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJmlCapBPJSKh.CurrencySymbol = ""
        Me.txtJmlCapBPJSKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJmlCapBPJSKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJmlCapBPJSKh.Enabled = False
        Me.txtJmlCapBPJSKh.Location = New System.Drawing.Point(366, 64)
        Me.txtJmlCapBPJSKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJmlCapBPJSKh.Name = "txtJmlCapBPJSKh"
        Me.txtJmlCapBPJSKh.NullString = ""
        Me.txtJmlCapBPJSKh.Size = New System.Drawing.Size(85, 20)
        Me.txtJmlCapBPJSKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJmlCapBPJSKh.TabIndex = 4
        Me.txtJmlCapBPJSKh.Text = "0.00"
        Me.txtJmlCapBPJSKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(470, 111)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(73, 13)
        Me.Label44.TabIndex = 102
        Me.Label44.Text = "Total Pkt Lain"
        '
        'txtPaketLainKh
        '
        Me.txtPaketLainKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtPaketLainKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtPaketLainKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtPaketLainKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaketLainKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtPaketLainKh.CurrencySymbol = ""
        Me.txtPaketLainKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaketLainKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPaketLainKh.Location = New System.Drawing.Point(560, 64)
        Me.txtPaketLainKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPaketLainKh.Name = "txtPaketLainKh"
        Me.txtPaketLainKh.NullString = ""
        Me.txtPaketLainKh.Size = New System.Drawing.Size(88, 20)
        Me.txtPaketLainKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtPaketLainKh.TabIndex = 8
        Me.txtPaketLainKh.Text = "0.00"
        Me.txtPaketLainKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSatPaketLainKh
        '
        Me.txtSatPaketLainKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSatPaketLainKh.Enabled = False
        Me.txtSatPaketLainKh.Location = New System.Drawing.Point(653, 64)
        Me.txtSatPaketLainKh.Name = "txtSatPaketLainKh"
        Me.txtSatPaketLainKh.Size = New System.Drawing.Size(69, 20)
        Me.txtSatPaketLainKh.TabIndex = 100
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(469, 67)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(58, 13)
        Me.Label59.TabIndex = 99
        Me.Label59.Text = "Paket Lain"
        '
        'btnAddKh
        '
        Me.btnAddKh.BeforeTouchSize = New System.Drawing.Size(43, 65)
        Me.btnAddKh.Image = CType(resources.GetObject("btnAddKh.Image"), System.Drawing.Image)
        Me.btnAddKh.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnAddKh.IsBackStageButton = False
        Me.btnAddKh.Location = New System.Drawing.Point(882, 61)
        Me.btnAddKh.Name = "btnAddKh"
        Me.btnAddKh.Size = New System.Drawing.Size(43, 65)
        Me.btnAddKh.TabIndex = 11
        Me.btnAddKh.Text = "Add"
        Me.btnAddKh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'txtJmlCapLainKh
        '
        Me.txtJmlCapLainKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJmlCapLainKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJmlCapLainKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtJmlCapLainKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJmlCapLainKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJmlCapLainKh.CurrencySymbol = ""
        Me.txtJmlCapLainKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJmlCapLainKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJmlCapLainKh.Enabled = False
        Me.txtJmlCapLainKh.Location = New System.Drawing.Point(366, 86)
        Me.txtJmlCapLainKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJmlCapLainKh.Name = "txtJmlCapLainKh"
        Me.txtJmlCapLainKh.NullString = ""
        Me.txtJmlCapLainKh.Size = New System.Drawing.Size(85, 20)
        Me.txtJmlCapLainKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJmlCapLainKh.TabIndex = 5
        Me.txtJmlCapLainKh.Text = "0.00"
        Me.txtJmlCapLainKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtJmlObatKh
        '
        Me.txtJmlObatKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJmlObatKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJmlObatKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtJmlObatKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJmlObatKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJmlObatKh.CurrencySymbol = ""
        Me.txtJmlObatKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJmlObatKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJmlObatKh.Enabled = False
        Me.txtJmlObatKh.Location = New System.Drawing.Point(366, 108)
        Me.txtJmlObatKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJmlObatKh.Name = "txtJmlObatKh"
        Me.txtJmlObatKh.NullString = ""
        Me.txtJmlObatKh.Size = New System.Drawing.Size(85, 20)
        Me.txtJmlObatKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJmlObatKh.TabIndex = 6
        Me.txtJmlObatKh.Text = "0.00"
        Me.txtJmlObatKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDosisResepKh
        '
        Me.txtDosisResepKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtDosisResepKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtDosisResepKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtDosisResepKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDosisResepKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtDosisResepKh.CurrencySymbol = ""
        Me.txtDosisResepKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDosisResepKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDosisResepKh.Enabled = False
        Me.txtDosisResepKh.Location = New System.Drawing.Point(366, 42)
        Me.txtDosisResepKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDosisResepKh.Name = "txtDosisResepKh"
        Me.txtDosisResepKh.NullString = ""
        Me.txtDosisResepKh.Size = New System.Drawing.Size(85, 20)
        Me.txtDosisResepKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtDosisResepKh.TabIndex = 3
        Me.txtDosisResepKh.Text = "0.00"
        Me.txtDosisResepKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtPaketBPJSKh
        '
        Me.txtPaketBPJSKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtPaketBPJSKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtPaketBPJSKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtPaketBPJSKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPaketBPJSKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtPaketBPJSKh.CurrencySymbol = ""
        Me.txtPaketBPJSKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPaketBPJSKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPaketBPJSKh.Location = New System.Drawing.Point(560, 42)
        Me.txtPaketBPJSKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPaketBPJSKh.Name = "txtPaketBPJSKh"
        Me.txtPaketBPJSKh.NullString = ""
        Me.txtPaketBPJSKh.Size = New System.Drawing.Size(88, 20)
        Me.txtPaketBPJSKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtPaketBPJSKh.TabIndex = 7
        Me.txtPaketBPJSKh.Text = "0.00"
        Me.txtPaketBPJSKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtHargaJualKh
        '
        Me.txtHargaJualKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtHargaJualKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtHargaJualKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHargaJualKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtHargaJualKh.CurrencySymbol = ""
        Me.txtHargaJualKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtHargaJualKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHargaJualKh.Location = New System.Drawing.Point(100, 86)
        Me.txtHargaJualKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtHargaJualKh.Name = "txtHargaJualKh"
        Me.txtHargaJualKh.NullString = ""
        Me.txtHargaJualKh.Size = New System.Drawing.Size(163, 20)
        Me.txtHargaJualKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtHargaJualKh.TabIndex = 92
        Me.txtHargaJualKh.Text = "0.00"
        Me.txtHargaJualKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDosisKh
        '
        Me.txtDosisKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtDosisKh.BorderColor = System.Drawing.Color.DimGray
        Me.txtDosisKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDosisKh.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtDosisKh.CurrencySymbol = ""
        Me.txtDosisKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDosisKh.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDosisKh.Location = New System.Drawing.Point(100, 64)
        Me.txtDosisKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtDosisKh.Name = "txtDosisKh"
        Me.txtDosisKh.NullString = ""
        Me.txtDosisKh.Size = New System.Drawing.Size(88, 20)
        Me.txtDosisKh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtDosisKh.TabIndex = 91
        Me.txtDosisKh.Text = "0.00"
        Me.txtDosisKh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbEtiketKh
        '
        Me.cmbEtiketKh.BackColor = System.Drawing.SystemColors.Info
        Me.cmbEtiketKh.FormattingEnabled = True
        Me.cmbEtiketKh.Items.AddRange(New Object() {"N", "Y"})
        Me.cmbEtiketKh.Location = New System.Drawing.Point(841, 106)
        Me.cmbEtiketKh.Name = "cmbEtiketKh"
        Me.cmbEtiketKh.Size = New System.Drawing.Size(37, 21)
        Me.cmbEtiketKh.TabIndex = 10
        Me.cmbEtiketKh.Text = "N"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(790, 108)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(34, 13)
        Me.Label41.TabIndex = 88
        Me.Label41.Text = "Etiket"
        '
        'DTPTglAkhirKh
        '
        Me.DTPTglAkhirKh.Enabled = False
        Me.DTPTglAkhirKh.Location = New System.Drawing.Point(747, 83)
        Me.DTPTglAkhirKh.Name = "DTPTglAkhirKh"
        Me.DTPTglAkhirKh.Size = New System.Drawing.Size(131, 20)
        Me.DTPTglAkhirKh.TabIndex = 87
        '
        'txtJmlHariKh
        '
        Me.txtJmlHariKh.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJmlHariKh.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJmlHariKh.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJmlHariKh.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtJmlHariKh.IntegerValue = CType(0, Long)
        Me.txtJmlHariKh.Location = New System.Drawing.Point(841, 60)
        Me.txtJmlHariKh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJmlHariKh.Name = "txtJmlHariKh"
        Me.txtJmlHariKh.NullString = ""
        Me.txtJmlHariKh.Size = New System.Drawing.Size(37, 20)
        Me.txtJmlHariKh.TabIndex = 9
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(791, 63)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(44, 13)
        Me.Label42.TabIndex = 85
        Me.Label42.Text = "Jml Hari"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(470, 89)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(79, 13)
        Me.Label45.TabIndex = 80
        Me.Label45.Text = "Total Pkt BPJS"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(275, 67)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(78, 13)
        Me.Label46.TabIndex = 76
        Me.Label46.Text = "Jml Caps BPJS"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Location = New System.Drawing.Point(275, 110)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(48, 13)
        Me.Label47.TabIndex = 73
        Me.Label47.Text = "Jml Obat"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(275, 89)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(72, 13)
        Me.Label48.TabIndex = 72
        Me.Label48.Text = "Jml Caps Lain"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(275, 45)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(67, 13)
        Me.Label49.TabIndex = 71
        Me.Label49.Text = "Dosis Resep"
        '
        'lblNamaObatKh
        '
        Me.lblNamaObatKh.AutoSize = True
        Me.lblNamaObatKh.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaObatKh.Location = New System.Drawing.Point(269, 21)
        Me.lblNamaObatKh.Name = "lblNamaObatKh"
        Me.lblNamaObatKh.Size = New System.Drawing.Size(0, 18)
        Me.lblNamaObatKh.TabIndex = 70
        '
        'txtSatPaketBPJSKh
        '
        Me.txtSatPaketBPJSKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSatPaketBPJSKh.Enabled = False
        Me.txtSatPaketBPJSKh.Location = New System.Drawing.Point(653, 42)
        Me.txtSatPaketBPJSKh.Name = "txtSatPaketBPJSKh"
        Me.txtSatPaketBPJSKh.Size = New System.Drawing.Size(69, 20)
        Me.txtSatPaketBPJSKh.TabIndex = 69
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(469, 45)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(64, 13)
        Me.Label51.TabIndex = 65
        Me.Label51.Text = "Paket BPJS"
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(8, 89)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(58, 13)
        Me.Label52.TabIndex = 64
        Me.Label52.Text = "Harga Jual"
        '
        'txtSatDosisKh
        '
        Me.txtSatDosisKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSatDosisKh.Enabled = False
        Me.txtSatDosisKh.Location = New System.Drawing.Point(194, 64)
        Me.txtSatDosisKh.Name = "txtSatDosisKh"
        Me.txtSatDosisKh.Size = New System.Drawing.Size(69, 20)
        Me.txtSatDosisKh.TabIndex = 63
        '
        'txtIdObatKh
        '
        Me.txtIdObatKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIdObatKh.Enabled = False
        Me.txtIdObatKh.Location = New System.Drawing.Point(194, 42)
        Me.txtIdObatKh.Name = "txtIdObatKh"
        Me.txtIdObatKh.Size = New System.Drawing.Size(69, 20)
        Me.txtIdObatKh.TabIndex = 62
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(8, 67)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(58, 13)
        Me.Label53.TabIndex = 61
        Me.Label53.Text = "Dosis Stok"
        '
        'txtKodeObatKh
        '
        Me.txtKodeObatKh.BackColor = System.Drawing.SystemColors.Info
        Me.txtKodeObatKh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKodeObatKh.Location = New System.Drawing.Point(100, 42)
        Me.txtKodeObatKh.Name = "txtKodeObatKh"
        Me.txtKodeObatKh.Size = New System.Drawing.Size(88, 20)
        Me.txtKodeObatKh.TabIndex = 2
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(8, 45)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(48, 13)
        Me.Label54.TabIndex = 59
        Me.Label54.Text = "Kode/ID"
        '
        'cmbRacikNonKh
        '
        Me.cmbRacikNonKh.BackColor = System.Drawing.SystemColors.Info
        Me.cmbRacikNonKh.FormattingEnabled = True
        Me.cmbRacikNonKh.Items.AddRange(New Object() {"R", "N"})
        Me.cmbRacikNonKh.Location = New System.Drawing.Point(100, 19)
        Me.cmbRacikNonKh.Name = "cmbRacikNonKh"
        Me.cmbRacikNonKh.Size = New System.Drawing.Size(163, 21)
        Me.cmbRacikNonKh.TabIndex = 1
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(8, 22)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(60, 13)
        Me.Label55.TabIndex = 57
        Me.Label55.Text = "Racik/Non"
        '
        'PanelEtiketModel4
        '
        Me.PanelEtiketModel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEtiketModel4.Controls.Add(Me.Button7)
        Me.PanelEtiketModel4.Controls.Add(Me.Button8)
        Me.PanelEtiketModel4.Controls.Add(Me.cbMalam)
        Me.PanelEtiketModel4.Controls.Add(Me.cbSore)
        Me.PanelEtiketModel4.Controls.Add(Me.rInjeksi)
        Me.PanelEtiketModel4.Controls.Add(Me.cbInjeksi)
        Me.PanelEtiketModel4.Controls.Add(Me.Label74)
        Me.PanelEtiketModel4.Controls.Add(Me.rSesudah)
        Me.PanelEtiketModel4.Controls.Add(Me.rBersama)
        Me.PanelEtiketModel4.Controls.Add(Me.rSebelum)
        Me.PanelEtiketModel4.Controls.Add(Me.Label73)
        Me.PanelEtiketModel4.Controls.Add(Me.cbSiang)
        Me.PanelEtiketModel4.Controls.Add(Me.cbPagi)
        Me.PanelEtiketModel4.Controls.Add(Me.Button6)
        Me.PanelEtiketModel4.Controls.Add(Me.txtNamaObatEtiketModel4)
        Me.PanelEtiketModel4.Controls.Add(Me.Label77)
        Me.PanelEtiketModel4.Location = New System.Drawing.Point(1253, 111)
        Me.PanelEtiketModel4.Name = "PanelEtiketModel4"
        Me.PanelEtiketModel4.Size = New System.Drawing.Size(285, 171)
        Me.PanelEtiketModel4.TabIndex = 18
        Me.PanelEtiketModel4.Visible = False
        '
        'Button7
        '
        Me.Button7.Image = CType(resources.GetObject("Button7.Image"), System.Drawing.Image)
        Me.Button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button7.Location = New System.Drawing.Point(9, 6)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(86, 23)
        Me.Button7.TabIndex = 118
        Me.Button7.Text = "Ke Model 3"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Image = CType(resources.GetObject("Button8.Image"), System.Drawing.Image)
        Me.Button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button8.Location = New System.Drawing.Point(95, 6)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(86, 23)
        Me.Button8.TabIndex = 117
        Me.Button8.Text = "Ke Model 2"
        Me.Button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button8.UseVisualStyleBackColor = True
        '
        'cbMalam
        '
        Me.cbMalam.AutoSize = True
        Me.cbMalam.Location = New System.Drawing.Point(222, 59)
        Me.cbMalam.Name = "cbMalam"
        Me.cbMalam.Size = New System.Drawing.Size(57, 17)
        Me.cbMalam.TabIndex = 107
        Me.cbMalam.Text = "Malam"
        Me.cbMalam.UseVisualStyleBackColor = True
        '
        'cbSore
        '
        Me.cbSore.AutoSize = True
        Me.cbSore.Location = New System.Drawing.Point(179, 59)
        Me.cbSore.Name = "cbSore"
        Me.cbSore.Size = New System.Drawing.Size(48, 17)
        Me.cbSore.TabIndex = 116
        Me.cbSore.Text = "Sore"
        Me.cbSore.UseVisualStyleBackColor = True
        '
        'rInjeksi
        '
        Me.rInjeksi.AutoSize = True
        Me.rInjeksi.Location = New System.Drawing.Point(88, 139)
        Me.rInjeksi.Name = "rInjeksi"
        Me.rInjeksi.Size = New System.Drawing.Size(55, 17)
        Me.rInjeksi.TabIndex = 115
        Me.rInjeksi.TabStop = True
        Me.rInjeksi.Text = "Injeksi"
        Me.rInjeksi.UseVisualStyleBackColor = True
        '
        'cbInjeksi
        '
        Me.cbInjeksi.AutoSize = True
        Me.cbInjeksi.Location = New System.Drawing.Point(16, 102)
        Me.cbInjeksi.Name = "cbInjeksi"
        Me.cbInjeksi.Size = New System.Drawing.Size(56, 17)
        Me.cbInjeksi.TabIndex = 113
        Me.cbInjeksi.Text = "Injeksi"
        Me.cbInjeksi.UseVisualStyleBackColor = True
        Me.cbInjeksi.Visible = False
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(15, 80)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(44, 13)
        Me.Label74.TabIndex = 112
        Me.Label74.Text = "Catatan"
        '
        'rSesudah
        '
        Me.rSesudah.AutoSize = True
        Me.rSesudah.Location = New System.Drawing.Point(88, 119)
        Me.rSesudah.Name = "rSesudah"
        Me.rSesudah.Size = New System.Drawing.Size(103, 17)
        Me.rSesudah.TabIndex = 111
        Me.rSesudah.TabStop = True
        Me.rSesudah.Text = "Sesudah Makan"
        Me.rSesudah.UseVisualStyleBackColor = True
        '
        'rBersama
        '
        Me.rBersama.AutoSize = True
        Me.rBersama.Location = New System.Drawing.Point(88, 99)
        Me.rBersama.Name = "rBersama"
        Me.rBersama.Size = New System.Drawing.Size(127, 17)
        Me.rBersama.TabIndex = 110
        Me.rBersama.TabStop = True
        Me.rBersama.Text = "Bersama Saat Makan"
        Me.rBersama.UseVisualStyleBackColor = True
        '
        'rSebelum
        '
        Me.rSebelum.AutoSize = True
        Me.rSebelum.Location = New System.Drawing.Point(88, 80)
        Me.rSebelum.Name = "rSebelum"
        Me.rSebelum.Size = New System.Drawing.Size(102, 17)
        Me.rSebelum.TabIndex = 109
        Me.rSebelum.TabStop = True
        Me.rSebelum.Text = "Sebelum Makan"
        Me.rSebelum.UseVisualStyleBackColor = True
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(13, 60)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(73, 13)
        Me.Label73.TabIndex = 108
        Me.Label73.Text = "Waktu Minum"
        '
        'cbSiang
        '
        Me.cbSiang.AutoSize = True
        Me.cbSiang.Location = New System.Drawing.Point(130, 59)
        Me.cbSiang.Name = "cbSiang"
        Me.cbSiang.Size = New System.Drawing.Size(53, 17)
        Me.cbSiang.TabIndex = 106
        Me.cbSiang.Text = "Siang"
        Me.cbSiang.UseVisualStyleBackColor = True
        '
        'cbPagi
        '
        Me.cbPagi.AutoSize = True
        Me.cbPagi.Location = New System.Drawing.Point(88, 59)
        Me.cbPagi.Name = "cbPagi"
        Me.cbPagi.Size = New System.Drawing.Size(47, 17)
        Me.cbPagi.TabIndex = 105
        Me.cbPagi.Text = "Pagi"
        Me.cbPagi.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(181, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(86, 23)
        Me.Button6.TabIndex = 104
        Me.Button6.Text = "Ke Model 1"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button6.UseVisualStyleBackColor = True
        '
        'txtNamaObatEtiketModel4
        '
        Me.txtNamaObatEtiketModel4.Location = New System.Drawing.Point(88, 35)
        Me.txtNamaObatEtiketModel4.Name = "txtNamaObatEtiketModel4"
        Me.txtNamaObatEtiketModel4.Size = New System.Drawing.Size(179, 20)
        Me.txtNamaObatEtiketModel4.TabIndex = 1
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(13, 38)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(61, 13)
        Me.Label77.TabIndex = 97
        Me.Label77.Text = "Nama Obat"
        '
        'PanelEtiketModel3
        '
        Me.PanelEtiketModel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEtiketModel3.Controls.Add(Me.Label69)
        Me.PanelEtiketModel3.Controls.Add(Me.Label70)
        Me.PanelEtiketModel3.Controls.Add(Me.txtJarakEDModel3)
        Me.PanelEtiketModel3.Controls.Add(Me.Label68)
        Me.PanelEtiketModel3.Controls.Add(Me.txtJumlahObatEtiketModel3)
        Me.PanelEtiketModel3.Controls.Add(Me.cmbKeteranganModel3)
        Me.PanelEtiketModel3.Controls.Add(Me.Label67)
        Me.PanelEtiketModel3.Controls.Add(Me.Button4)
        Me.PanelEtiketModel3.Controls.Add(Me.txtNamaObatEtiketModel3)
        Me.PanelEtiketModel3.Controls.Add(Me.Label71)
        Me.PanelEtiketModel3.Location = New System.Drawing.Point(1253, 117)
        Me.PanelEtiketModel3.Name = "PanelEtiketModel3"
        Me.PanelEtiketModel3.Size = New System.Drawing.Size(285, 142)
        Me.PanelEtiketModel3.TabIndex = 17
        Me.PanelEtiketModel3.Visible = False
        '
        'Label69
        '
        Me.Label69.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label69.Location = New System.Drawing.Point(216, 105)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(51, 20)
        Me.Label69.TabIndex = 110
        Me.Label69.Text = "Hari"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(13, 108)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(51, 13)
        Me.Label70.TabIndex = 109
        Me.Label70.Text = "Jarak ED"
        '
        'txtJarakEDModel3
        '
        Me.txtJarakEDModel3.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJarakEDModel3.BorderColor = System.Drawing.Color.DimGray
        Me.txtJarakEDModel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJarakEDModel3.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJarakEDModel3.CurrencySymbol = ""
        Me.txtJarakEDModel3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJarakEDModel3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJarakEDModel3.Location = New System.Drawing.Point(84, 105)
        Me.txtJarakEDModel3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJarakEDModel3.Name = "txtJarakEDModel3"
        Me.txtJarakEDModel3.NullString = ""
        Me.txtJarakEDModel3.Size = New System.Drawing.Size(137, 20)
        Me.txtJarakEDModel3.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJarakEDModel3.TabIndex = 10
        Me.txtJarakEDModel3.Text = "0.00"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(13, 61)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(66, 13)
        Me.Label68.TabIndex = 107
        Me.Label68.Text = "Jumlah Obat"
        '
        'txtJumlahObatEtiketModel3
        '
        Me.txtJumlahObatEtiketModel3.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJumlahObatEtiketModel3.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahObatEtiketModel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahObatEtiketModel3.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahObatEtiketModel3.CurrencySymbol = ""
        Me.txtJumlahObatEtiketModel3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahObatEtiketModel3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahObatEtiketModel3.Location = New System.Drawing.Point(84, 58)
        Me.txtJumlahObatEtiketModel3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahObatEtiketModel3.Name = "txtJumlahObatEtiketModel3"
        Me.txtJumlahObatEtiketModel3.NullString = ""
        Me.txtJumlahObatEtiketModel3.Size = New System.Drawing.Size(183, 20)
        Me.txtJumlahObatEtiketModel3.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahObatEtiketModel3.TabIndex = 8
        Me.txtJumlahObatEtiketModel3.Text = "0.00"
        '
        'cmbKeteranganModel3
        '
        Me.cmbKeteranganModel3.FormattingEnabled = True
        Me.cmbKeteranganModel3.Location = New System.Drawing.Point(84, 81)
        Me.cmbKeteranganModel3.Name = "cmbKeteranganModel3"
        Me.cmbKeteranganModel3.Size = New System.Drawing.Size(183, 21)
        Me.cmbKeteranganModel3.TabIndex = 9
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(13, 84)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(62, 13)
        Me.Label67.TabIndex = 105
        Me.Label67.Text = "Keterangan"
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.Location = New System.Drawing.Point(181, 6)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(86, 23)
        Me.Button4.TabIndex = 104
        Me.Button4.Text = "Ke Model 1"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = True
        '
        'txtNamaObatEtiketModel3
        '
        Me.txtNamaObatEtiketModel3.Location = New System.Drawing.Point(84, 35)
        Me.txtNamaObatEtiketModel3.Name = "txtNamaObatEtiketModel3"
        Me.txtNamaObatEtiketModel3.Size = New System.Drawing.Size(183, 20)
        Me.txtNamaObatEtiketModel3.TabIndex = 7
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(13, 38)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(61, 13)
        Me.Label71.TabIndex = 97
        Me.Label71.Text = "Nama Obat"
        '
        'PanelPasien
        '
        Me.PanelPasien.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelPasien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelPasien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelPasien.Controls.Add(Me.GroupBox10)
        Me.PanelPasien.Controls.Add(Me.GroupBox8)
        Me.PanelPasien.Location = New System.Drawing.Point(1058, -1)
        Me.PanelPasien.Name = "PanelPasien"
        Me.PanelPasien.Size = New System.Drawing.Size(558, 321)
        Me.PanelPasien.TabIndex = 13
        Me.PanelPasien.Visible = False
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox10.Controls.Add(Me.gridPasien)
        Me.GroupBox10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox10.Location = New System.Drawing.Point(0, 74)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(556, 245)
        Me.GroupBox10.TabIndex = 1
        Me.GroupBox10.TabStop = False
        '
        'gridPasien
        '
        Me.gridPasien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPasien.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1})
        Me.gridPasien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPasien.Location = New System.Drawing.Point(3, 16)
        Me.gridPasien.Name = "gridPasien"
        Me.gridPasien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridPasien.Size = New System.Drawing.Size(550, 226)
        Me.gridPasien.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.HeaderText = "Pilih"
        Me.Column1.Image = CType(resources.GetObject("Column1.Image"), System.Drawing.Image)
        Me.Column1.Name = "Column1"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.btnExcel)
        Me.GroupBox8.Controls.Add(Me.lblKetDaftar)
        Me.GroupBox8.Controls.Add(Me.btnEx)
        Me.GroupBox8.Controls.Add(Me.DTPPasienReg)
        Me.GroupBox8.Controls.Add(Me.txtCariPasien)
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox8.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(556, 74)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        '
        'btnExcel
        '
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(474, 17)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(71, 23)
        Me.btnExcel.TabIndex = 11
        Me.btnExcel.Text = "Ke Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'lblKetDaftar
        '
        Me.lblKetDaftar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblKetDaftar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKetDaftar.Location = New System.Drawing.Point(171, 19)
        Me.lblKetDaftar.Name = "lblKetDaftar"
        Me.lblKetDaftar.Size = New System.Drawing.Size(299, 19)
        Me.lblKetDaftar.TabIndex = 10
        Me.lblKetDaftar.Text = "Daftar Pasien Rawat Inap Dalam Perawatan"
        '
        'btnEx
        '
        Me.btnEx.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnEx.Image = CType(resources.GetObject("btnEx.Image"), System.Drawing.Image)
        Me.btnEx.Location = New System.Drawing.Point(3, 16)
        Me.btnEx.Name = "btnEx"
        Me.btnEx.Size = New System.Drawing.Size(38, 55)
        Me.btnEx.TabIndex = 6
        Me.btnEx.UseVisualStyleBackColor = True
        '
        'DTPPasienReg
        '
        Me.DTPPasienReg.CustomFormat = "dd/MM/yyyy"
        Me.DTPPasienReg.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPPasienReg.Location = New System.Drawing.Point(45, 18)
        Me.DTPPasienReg.Name = "DTPPasienReg"
        Me.DTPPasienReg.Size = New System.Drawing.Size(119, 20)
        Me.DTPPasienReg.TabIndex = 5
        '
        'txtCariPasien
        '
        Me.txtCariPasien.Location = New System.Drawing.Point(170, 44)
        Me.txtCariPasien.Name = "txtCariPasien"
        Me.txtCariPasien.Size = New System.Drawing.Size(375, 20)
        Me.txtCariPasien.TabIndex = 8
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rNama)
        Me.GroupBox9.Controls.Add(Me.rRm)
        Me.GroupBox9.Location = New System.Drawing.Point(46, 36)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(118, 30)
        Me.GroupBox9.TabIndex = 7
        Me.GroupBox9.TabStop = False
        '
        'rNama
        '
        Me.rNama.AutoSize = True
        Me.rNama.Checked = True
        Me.rNama.Location = New System.Drawing.Point(58, 9)
        Me.rNama.Name = "rNama"
        Me.rNama.Size = New System.Drawing.Size(53, 17)
        Me.rNama.TabIndex = 1
        Me.rNama.TabStop = True
        Me.rNama.Text = "Nama"
        Me.rNama.UseVisualStyleBackColor = True
        '
        'rRm
        '
        Me.rRm.AutoSize = True
        Me.rRm.Location = New System.Drawing.Point(10, 9)
        Me.rRm.Name = "rRm"
        Me.rRm.Size = New System.Drawing.Size(42, 17)
        Me.rRm.TabIndex = 0
        Me.rRm.TabStop = True
        Me.rRm.Text = "RM"
        Me.rRm.UseVisualStyleBackColor = True
        '
        'PanelEtiketInfus
        '
        Me.PanelEtiketInfus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEtiketInfus.Controls.Add(Me.txtTetesInfus)
        Me.PanelEtiketInfus.Controls.Add(Me.Label64)
        Me.PanelEtiketInfus.Controls.Add(Me.txtObatInfus)
        Me.PanelEtiketInfus.Controls.Add(Me.Label63)
        Me.PanelEtiketInfus.Controls.Add(Me.Label72)
        Me.PanelEtiketInfus.Controls.Add(Me.btnModel1)
        Me.PanelEtiketInfus.Controls.Add(Me.Label65)
        Me.PanelEtiketInfus.Controls.Add(Me.txtJumlahObatEtiketInfus)
        Me.PanelEtiketInfus.Controls.Add(Me.txtNamaObatEtiketInfus)
        Me.PanelEtiketInfus.Controls.Add(Me.Label66)
        Me.PanelEtiketInfus.Location = New System.Drawing.Point(369, 44)
        Me.PanelEtiketInfus.Name = "PanelEtiketInfus"
        Me.PanelEtiketInfus.Size = New System.Drawing.Size(285, 142)
        Me.PanelEtiketInfus.TabIndex = 16
        Me.PanelEtiketInfus.Visible = False
        '
        'txtTetesInfus
        '
        Me.txtTetesInfus.Location = New System.Drawing.Point(84, 104)
        Me.txtTetesInfus.Name = "txtTetesInfus"
        Me.txtTetesInfus.Size = New System.Drawing.Size(183, 20)
        Me.txtTetesInfus.TabIndex = 108
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(13, 107)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(65, 13)
        Me.Label64.TabIndex = 109
        Me.Label64.Text = "Tetes/Menit"
        '
        'txtObatInfus
        '
        Me.txtObatInfus.Location = New System.Drawing.Point(84, 81)
        Me.txtObatInfus.Name = "txtObatInfus"
        Me.txtObatInfus.Size = New System.Drawing.Size(183, 20)
        Me.txtObatInfus.TabIndex = 106
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(13, 84)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(30, 13)
        Me.Label63.TabIndex = 107
        Me.Label63.Text = "Obat"
        '
        'Label72
        '
        Me.Label72.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label72.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(13, 7)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(162, 20)
        Me.Label72.TabIndex = 105
        Me.Label72.Text = "Etiket Infus"
        '
        'btnModel1
        '
        Me.btnModel1.Image = CType(resources.GetObject("btnModel1.Image"), System.Drawing.Image)
        Me.btnModel1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModel1.Location = New System.Drawing.Point(181, 6)
        Me.btnModel1.Name = "btnModel1"
        Me.btnModel1.Size = New System.Drawing.Size(86, 23)
        Me.btnModel1.TabIndex = 104
        Me.btnModel1.Text = "Ke Model 1"
        Me.btnModel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModel1.UseVisualStyleBackColor = True
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(13, 61)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(66, 13)
        Me.Label65.TabIndex = 100
        Me.Label65.Text = "Jumlah Obat"
        '
        'txtJumlahObatEtiketInfus
        '
        Me.txtJumlahObatEtiketInfus.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJumlahObatEtiketInfus.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahObatEtiketInfus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahObatEtiketInfus.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahObatEtiketInfus.CurrencySymbol = ""
        Me.txtJumlahObatEtiketInfus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahObatEtiketInfus.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahObatEtiketInfus.Location = New System.Drawing.Point(84, 58)
        Me.txtJumlahObatEtiketInfus.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahObatEtiketInfus.Name = "txtJumlahObatEtiketInfus"
        Me.txtJumlahObatEtiketInfus.NullString = ""
        Me.txtJumlahObatEtiketInfus.Size = New System.Drawing.Size(183, 20)
        Me.txtJumlahObatEtiketInfus.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahObatEtiketInfus.TabIndex = 8
        Me.txtJumlahObatEtiketInfus.Text = "0.00"
        '
        'txtNamaObatEtiketInfus
        '
        Me.txtNamaObatEtiketInfus.Location = New System.Drawing.Point(84, 35)
        Me.txtNamaObatEtiketInfus.Name = "txtNamaObatEtiketInfus"
        Me.txtNamaObatEtiketInfus.Size = New System.Drawing.Size(183, 20)
        Me.txtNamaObatEtiketInfus.TabIndex = 7
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(13, 38)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(61, 13)
        Me.Label66.TabIndex = 97
        Me.Label66.Text = "Nama Infus"
        '
        'PanelEtiket
        '
        Me.PanelEtiket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEtiket.Controls.Add(Me.Button5)
        Me.PanelEtiket.Controls.Add(Me.Button3)
        Me.PanelEtiket.Controls.Add(Me.btnModel2)
        Me.PanelEtiket.Controls.Add(Me.Label62)
        Me.PanelEtiket.Controls.Add(Me.Label61)
        Me.PanelEtiket.Controls.Add(Me.txtJarakED)
        Me.PanelEtiket.Controls.Add(Me.Label60)
        Me.PanelEtiket.Controls.Add(Me.txtJumlahObatEtiket)
        Me.PanelEtiket.Controls.Add(Me.txtSigna2)
        Me.PanelEtiket.Controls.Add(Me.txtSigna1)
        Me.PanelEtiket.Controls.Add(Me.txtNamaObatEtiket)
        Me.PanelEtiket.Controls.Add(Me.Label56)
        Me.PanelEtiket.Controls.Add(Me.cmbKeterangan)
        Me.PanelEtiket.Controls.Add(Me.cmbWaktu)
        Me.PanelEtiket.Controls.Add(Me.cmbTakaran)
        Me.PanelEtiket.Controls.Add(Me.Label37)
        Me.PanelEtiket.Controls.Add(Me.txtQty3)
        Me.PanelEtiket.Controls.Add(Me.Label36)
        Me.PanelEtiket.Controls.Add(Me.Label35)
        Me.PanelEtiket.Controls.Add(Me.Label34)
        Me.PanelEtiket.Controls.Add(Me.Label22)
        Me.PanelEtiket.Location = New System.Drawing.Point(0, 0)
        Me.PanelEtiket.Name = "PanelEtiket"
        Me.PanelEtiket.Size = New System.Drawing.Size(285, 213)
        Me.PanelEtiket.TabIndex = 15
        Me.PanelEtiket.Visible = False
        '
        'Button5
        '
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(13, 6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(86, 23)
        Me.Button5.TabIndex = 106
        Me.Button5.Text = "Ke Model 4"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(99, 6)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(86, 23)
        Me.Button3.TabIndex = 105
        Me.Button3.Text = "Ke Model 3"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnModel2
        '
        Me.btnModel2.Image = CType(resources.GetObject("btnModel2.Image"), System.Drawing.Image)
        Me.btnModel2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModel2.Location = New System.Drawing.Point(185, 6)
        Me.btnModel2.Name = "btnModel2"
        Me.btnModel2.Size = New System.Drawing.Size(86, 23)
        Me.btnModel2.TabIndex = 104
        Me.btnModel2.Text = "Ke Model 2"
        Me.btnModel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnModel2.UseVisualStyleBackColor = True
        '
        'Label62
        '
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label62.Location = New System.Drawing.Point(216, 176)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(51, 20)
        Me.Label62.TabIndex = 103
        Me.Label62.Text = "Hari"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(13, 179)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(51, 13)
        Me.Label61.TabIndex = 102
        Me.Label61.Text = "Jarak ED"
        '
        'txtJarakED
        '
        Me.txtJarakED.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJarakED.BorderColor = System.Drawing.Color.DimGray
        Me.txtJarakED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJarakED.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJarakED.CurrencySymbol = ""
        Me.txtJarakED.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJarakED.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJarakED.Location = New System.Drawing.Point(84, 176)
        Me.txtJarakED.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJarakED.Name = "txtJarakED"
        Me.txtJarakED.NullString = ""
        Me.txtJarakED.Size = New System.Drawing.Size(137, 20)
        Me.txtJarakED.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJarakED.TabIndex = 13
        Me.txtJarakED.Text = "0.00"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(13, 61)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(66, 13)
        Me.Label60.TabIndex = 100
        Me.Label60.Text = "Jumlah Obat"
        '
        'txtJumlahObatEtiket
        '
        Me.txtJumlahObatEtiket.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtJumlahObatEtiket.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahObatEtiket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahObatEtiket.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahObatEtiket.CurrencySymbol = ""
        Me.txtJumlahObatEtiket.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahObatEtiket.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahObatEtiket.Location = New System.Drawing.Point(84, 58)
        Me.txtJumlahObatEtiket.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahObatEtiket.Name = "txtJumlahObatEtiket"
        Me.txtJumlahObatEtiket.NullString = ""
        Me.txtJumlahObatEtiket.Size = New System.Drawing.Size(183, 20)
        Me.txtJumlahObatEtiket.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahObatEtiket.TabIndex = 8
        Me.txtJumlahObatEtiket.Text = "0.00"
        '
        'txtSigna2
        '
        Me.txtSigna2.Location = New System.Drawing.Point(186, 81)
        Me.txtSigna2.Name = "txtSigna2"
        Me.txtSigna2.Size = New System.Drawing.Size(81, 20)
        Me.txtSigna2.TabIndex = 9
        '
        'txtSigna1
        '
        Me.txtSigna1.Location = New System.Drawing.Point(84, 81)
        Me.txtSigna1.Name = "txtSigna1"
        Me.txtSigna1.Size = New System.Drawing.Size(81, 20)
        Me.txtSigna1.TabIndex = 8
        '
        'txtNamaObatEtiket
        '
        Me.txtNamaObatEtiket.Location = New System.Drawing.Point(84, 35)
        Me.txtNamaObatEtiket.Name = "txtNamaObatEtiket"
        Me.txtNamaObatEtiket.Size = New System.Drawing.Size(183, 20)
        Me.txtNamaObatEtiket.TabIndex = 7
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(13, 38)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(61, 13)
        Me.Label56.TabIndex = 97
        Me.Label56.Text = "Nama Obat"
        '
        'cmbKeterangan
        '
        Me.cmbKeterangan.FormattingEnabled = True
        Me.cmbKeterangan.Location = New System.Drawing.Point(84, 152)
        Me.cmbKeterangan.Name = "cmbKeterangan"
        Me.cmbKeterangan.Size = New System.Drawing.Size(183, 21)
        Me.cmbKeterangan.TabIndex = 12
        '
        'cmbWaktu
        '
        Me.cmbWaktu.FormattingEnabled = True
        Me.cmbWaktu.Location = New System.Drawing.Point(84, 128)
        Me.cmbWaktu.Name = "cmbWaktu"
        Me.cmbWaktu.Size = New System.Drawing.Size(183, 21)
        Me.cmbWaktu.TabIndex = 11
        '
        'cmbTakaran
        '
        Me.cmbTakaran.FormattingEnabled = True
        Me.cmbTakaran.Location = New System.Drawing.Point(84, 104)
        Me.cmbTakaran.Name = "cmbTakaran"
        Me.cmbTakaran.Size = New System.Drawing.Size(183, 21)
        Me.cmbTakaran.TabIndex = 10
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(168, 85)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(14, 13)
        Me.Label37.TabIndex = 95
        Me.Label37.Text = "X"
        '
        'txtQty3
        '
        Me.txtQty3.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtQty3.BorderColor = System.Drawing.Color.DimGray
        Me.txtQty3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty3.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtQty3.CurrencySymbol = ""
        Me.txtQty3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQty3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtQty3.Enabled = False
        Me.txtQty3.Location = New System.Drawing.Point(216, 81)
        Me.txtQty3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtQty3.Name = "txtQty3"
        Me.txtQty3.NullString = ""
        Me.txtQty3.Size = New System.Drawing.Size(51, 20)
        Me.txtQty3.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtQty3.TabIndex = 94
        Me.txtQty3.Text = "0.00"
        Me.txtQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQty3.Visible = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(13, 155)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(62, 13)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "Keterangan"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(13, 128)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(39, 13)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Waktu"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(13, 104)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 13)
        Me.Label34.TabIndex = 1
        Me.Label34.Text = "Takaran"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(13, 84)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Signa 1 Hari"
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Label33)
        Me.GroupBox11.Controls.Add(Me.txtCariObat)
        Me.GroupBox11.Controls.Add(Me.Button1)
        Me.GroupBox11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox11.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(594, 74)
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
        'PanelObat
        '
        Me.PanelObat.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelObat.Controls.Add(Me.GroupBox12)
        Me.PanelObat.Controls.Add(Me.GroupBox11)
        Me.PanelObat.Location = New System.Drawing.Point(1255, 3)
        Me.PanelObat.Name = "PanelObat"
        Me.PanelObat.Size = New System.Drawing.Size(596, 321)
        Me.PanelObat.TabIndex = 14
        Me.PanelObat.Visible = False
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.gridBarang)
        Me.GroupBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox12.Location = New System.Drawing.Point(0, 74)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(594, 245)
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
        Me.gridBarang.Size = New System.Drawing.Size(588, 226)
        Me.gridBarang.TabIndex = 0
        '
        'Column2
        '
        Me.Column2.HeaderText = "Pilih"
        Me.Column2.Image = CType(resources.GetObject("Column2.Image"), System.Drawing.Image)
        Me.Column2.Name = "Column2"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Tanggal"
        '
        'DTPTanggalTrans
        '
        Me.DTPTanggalTrans.CustomFormat = "dd MMMM yyyy"
        Me.DTPTanggalTrans.Enabled = False
        Me.DTPTanggalTrans.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTanggalTrans.Location = New System.Drawing.Point(86, 35)
        Me.DTPTanggalTrans.Name = "DTPTanggalTrans"
        Me.DTPTanggalTrans.Size = New System.Drawing.Size(211, 20)
        Me.DTPTanggalTrans.TabIndex = 15
        '
        'txtNoResep
        '
        Me.txtNoResep.BackColor = System.Drawing.SystemColors.Window
        Me.txtNoResep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoResep.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoResep.Location = New System.Drawing.Point(86, 57)
        Me.txtNoResep.Name = "txtNoResep"
        Me.txtNoResep.ReadOnly = True
        Me.txtNoResep.Size = New System.Drawing.Size(211, 20)
        Me.txtNoResep.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "No. Resep"
        '
        'txtNoReg
        '
        Me.txtNoReg.BackColor = System.Drawing.SystemColors.Info
        Me.txtNoReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoReg.Location = New System.Drawing.Point(86, 79)
        Me.txtNoReg.Name = "txtNoReg"
        Me.txtNoReg.ReadOnly = True
        Me.txtNoReg.Size = New System.Drawing.Size(211, 20)
        Me.txtNoReg.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "No. Registrasi"
        '
        'txtNoKartu
        '
        Me.txtNoKartu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoKartu.Location = New System.Drawing.Point(86, 102)
        Me.txtNoKartu.Name = "txtNoKartu"
        Me.txtNoKartu.ReadOnly = True
        Me.txtNoKartu.Size = New System.Drawing.Size(129, 20)
        Me.txtNoKartu.TabIndex = 20
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "No Kartu"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(221, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "No"
        '
        'txtNoUrut
        '
        Me.txtNoUrut.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoUrut.Enabled = False
        Me.txtNoUrut.Location = New System.Drawing.Point(249, 102)
        Me.txtNoUrut.Name = "txtNoUrut"
        Me.txtNoUrut.Size = New System.Drawing.Size(47, 20)
        Me.txtNoUrut.TabIndex = 23
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(1, 147)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(24, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "RM"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1, 194)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Nama"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(1, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Alamat"
        '
        'txtRM
        '
        Me.txtRM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRM.Location = New System.Drawing.Point(86, 146)
        Me.txtRM.Name = "txtRM"
        Me.txtRM.ReadOnly = True
        Me.txtRM.Size = New System.Drawing.Size(99, 20)
        Me.txtRM.TabIndex = 29
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(1, 170)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 30
        Me.Label9.Text = "Jenis Kelamin"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(125, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(32, 13)
        Me.Label10.TabIndex = 31
        Me.Label10.Text = "Umur"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(202, 172)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 32
        Me.Label11.Text = "Thn"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(275, 169)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Bln"
        '
        'txtSex
        '
        Me.txtSex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSex.Location = New System.Drawing.Point(86, 169)
        Me.txtSex.Name = "txtSex"
        Me.txtSex.ReadOnly = True
        Me.txtSex.Size = New System.Drawing.Size(33, 20)
        Me.txtSex.TabIndex = 34
        '
        'txtUmurThn
        '
        Me.txtUmurThn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUmurThn.Location = New System.Drawing.Point(163, 169)
        Me.txtUmurThn.Name = "txtUmurThn"
        Me.txtUmurThn.ReadOnly = True
        Me.txtUmurThn.Size = New System.Drawing.Size(33, 20)
        Me.txtUmurThn.TabIndex = 35
        '
        'txtUmurBln
        '
        Me.txtUmurBln.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUmurBln.Location = New System.Drawing.Point(234, 170)
        Me.txtUmurBln.Name = "txtUmurBln"
        Me.txtUmurBln.ReadOnly = True
        Me.txtUmurBln.Size = New System.Drawing.Size(33, 20)
        Me.txtUmurBln.TabIndex = 36
        '
        'txtNamaPasien
        '
        Me.txtNamaPasien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaPasien.Location = New System.Drawing.Point(86, 192)
        Me.txtNamaPasien.Name = "txtNamaPasien"
        Me.txtNamaPasien.ReadOnly = True
        Me.txtNamaPasien.Size = New System.Drawing.Size(211, 20)
        Me.txtNamaPasien.TabIndex = 37
        '
        'txtAlamat
        '
        Me.txtAlamat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlamat.Location = New System.Drawing.Point(86, 215)
        Me.txtAlamat.Multiline = True
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.ReadOnly = True
        Me.txtAlamat.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAlamat.Size = New System.Drawing.Size(211, 88)
        Me.txtAlamat.TabIndex = 38
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(1, 331)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Penjamin"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(1, 354)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(39, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Dokter"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(1, 377)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 13)
        Me.Label15.TabIndex = 41
        Me.Label15.Text = "Nota/Jns Trans"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(1, 309)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(49, 13)
        Me.Label16.TabIndex = 42
        Me.Label16.Text = "Unit Asal"
        '
        'cmbUnitAsal
        '
        Me.cmbUnitAsal.Enabled = False
        Me.cmbUnitAsal.FormattingEnabled = True
        Me.cmbUnitAsal.Location = New System.Drawing.Point(86, 306)
        Me.cmbUnitAsal.Name = "cmbUnitAsal"
        Me.cmbUnitAsal.Size = New System.Drawing.Size(211, 21)
        Me.cmbUnitAsal.TabIndex = 43
        '
        'cmbPenjamin
        '
        Me.cmbPenjamin.Enabled = False
        Me.cmbPenjamin.FormattingEnabled = True
        Me.cmbPenjamin.Location = New System.Drawing.Point(86, 328)
        Me.cmbPenjamin.Name = "cmbPenjamin"
        Me.cmbPenjamin.Size = New System.Drawing.Size(211, 21)
        Me.cmbPenjamin.TabIndex = 44
        '
        'cmbDokter
        '
        Me.cmbDokter.FormattingEnabled = True
        Me.cmbDokter.Location = New System.Drawing.Point(86, 351)
        Me.cmbDokter.Name = "cmbDokter"
        Me.cmbDokter.Size = New System.Drawing.Size(211, 21)
        Me.cmbDokter.TabIndex = 45
        '
        'txtNota
        '
        Me.txtNota.Location = New System.Drawing.Point(86, 374)
        Me.txtNota.Name = "txtNota"
        Me.txtNota.Size = New System.Drawing.Size(67, 20)
        Me.txtNota.TabIndex = 46
        Me.txtNota.Text = "-"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.GroupBox2.Controls.Add(Me.Label79)
        Me.GroupBox2.Controls.Add(Me.txtNoSEP)
        Me.GroupBox2.Controls.Add(Me.Label75)
        Me.GroupBox2.Controls.Add(Me.Label78)
        Me.GroupBox2.Controls.Add(Me.cmbPkt)
        Me.GroupBox2.Controls.Add(Me.txtNota)
        Me.GroupBox2.Controls.Add(Me.PanelResepDokter)
        Me.GroupBox2.Controls.Add(Me.txtPPN)
        Me.GroupBox2.Controls.Add(Me.Label76)
        Me.GroupBox2.Controls.Add(Me.cmbDokter)
        Me.GroupBox2.Controls.Add(Me.cmbPenjamin)
        Me.GroupBox2.Controls.Add(Me.txtLaba)
        Me.GroupBox2.Controls.Add(Me.lblKamarBed)
        Me.GroupBox2.Controls.Add(Me.cmbUnitAsal)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.DTPJamAkhir)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.DTPJamAwal)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.cmbJenisRawat)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtAlamat)
        Me.GroupBox2.Controls.Add(Me.txtNamaPasien)
        Me.GroupBox2.Controls.Add(Me.txtUmurBln)
        Me.GroupBox2.Controls.Add(Me.txtUmurThn)
        Me.GroupBox2.Controls.Add(Me.txtSex)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtRM)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtNoUrut)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtNoKartu)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtNoReg)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtNoResep)
        Me.GroupBox2.Controls.Add(Me.DTPTanggalTrans)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(307, 636)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(1, 125)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(48, 13)
        Me.Label79.TabIndex = 104
        Me.Label79.Text = "No. SEP"
        '
        'txtNoSEP
        '
        Me.txtNoSEP.BackColor = System.Drawing.SystemColors.Info
        Me.txtNoSEP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoSEP.Location = New System.Drawing.Point(86, 124)
        Me.txtNoSEP.Name = "txtNoSEP"
        Me.txtNoSEP.ReadOnly = True
        Me.txtNoSEP.Size = New System.Drawing.Size(211, 20)
        Me.txtNoSEP.TabIndex = 103
        '
        'Label75
        '
        Me.Label75.BackColor = System.Drawing.Color.DodgerBlue
        Me.Label75.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label75.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label75.Location = New System.Drawing.Point(4, 409)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(297, 23)
        Me.Label75.TabIndex = 102
        Me.Label75.Text = "PILIH RESEP"
        Me.Label75.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label78
        '
        Me.Label78.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label78.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label78.Location = New System.Drawing.Point(3, 553)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(301, 20)
        Me.Label78.TabIndex = 101
        Me.Label78.Text = "PPN ( % )"
        '
        'cmbPkt
        '
        Me.cmbPkt.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbPkt.FormattingEnabled = True
        Me.cmbPkt.Items.AddRange(New Object() {"Paket Umum", "Paket Khusus"})
        Me.cmbPkt.Location = New System.Drawing.Point(158, 374)
        Me.cmbPkt.Name = "cmbPkt"
        Me.cmbPkt.Size = New System.Drawing.Size(137, 21)
        Me.cmbPkt.TabIndex = 47
        '
        'PanelResepDokter
        '
        Me.PanelResepDokter.Controls.Add(Me.gridPermintaanObat)
        Me.PanelResepDokter.Location = New System.Drawing.Point(4, 431)
        Me.PanelResepDokter.Name = "PanelResepDokter"
        Me.PanelResepDokter.Size = New System.Drawing.Size(297, 119)
        Me.PanelResepDokter.TabIndex = 0
        '
        'gridPermintaanObat
        '
        Me.gridPermintaanObat.AllowUserToAddRows = False
        Me.gridPermintaanObat.AllowUserToDeleteRows = False
        Me.gridPermintaanObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPermintaanObat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3})
        Me.gridPermintaanObat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPermintaanObat.Location = New System.Drawing.Point(0, 0)
        Me.gridPermintaanObat.Name = "gridPermintaanObat"
        Me.gridPermintaanObat.RowHeadersWidth = 5
        Me.gridPermintaanObat.Size = New System.Drawing.Size(297, 119)
        Me.gridPermintaanObat.TabIndex = 0
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "Pilih"
        Me.Column3.HeaderText = "Pilih"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Text = "Pilih"
        Me.Column3.ToolTipText = "Pilih"
        '
        'txtPPN
        '
        Me.txtPPN.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtPPN.BorderColor = System.Drawing.Color.DimGray
        Me.txtPPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPPN.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtPPN.CurrencySymbol = ""
        Me.txtPPN.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPPN.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPPN.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtPPN.Enabled = False
        Me.txtPPN.Location = New System.Drawing.Point(3, 573)
        Me.txtPPN.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPPN.Name = "txtPPN"
        Me.txtPPN.NullString = ""
        Me.txtPPN.Size = New System.Drawing.Size(301, 20)
        Me.txtPPN.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtPPN.TabIndex = 100
        Me.txtPPN.Text = "0.00"
        Me.txtPPN.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label76
        '
        Me.Label76.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label76.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Label76.Location = New System.Drawing.Point(3, 593)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(301, 20)
        Me.Label76.TabIndex = 99
        Me.Label76.Text = "Laba ( % )"
        '
        'txtLaba
        '
        Me.txtLaba.BeforeTouchSize = New System.Drawing.Size(301, 20)
        Me.txtLaba.BorderColor = System.Drawing.Color.DimGray
        Me.txtLaba.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLaba.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtLaba.CurrencySymbol = ""
        Me.txtLaba.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtLaba.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtLaba.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.txtLaba.Enabled = False
        Me.txtLaba.Location = New System.Drawing.Point(3, 613)
        Me.txtLaba.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtLaba.Name = "txtLaba"
        Me.txtLaba.NullString = ""
        Me.txtLaba.Size = New System.Drawing.Size(301, 20)
        Me.txtLaba.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtLaba.TabIndex = 98
        Me.txtLaba.Text = "0.00"
        Me.txtLaba.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblKamarBed
        '
        Me.lblKamarBed.AutoSize = True
        Me.lblKamarBed.Location = New System.Drawing.Point(51, 465)
        Me.lblKamarBed.Name = "lblKamarBed"
        Me.lblKamarBed.Size = New System.Drawing.Size(52, 13)
        Me.lblKamarBed.TabIndex = 29
        Me.lblKamarBed.Text = "LabelBed"
        Me.lblKamarBed.Visible = False
        '
        'DTPJamAkhir
        '
        Me.DTPJamAkhir.CustomFormat = "HH:mm:ss"
        Me.DTPJamAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPJamAkhir.Location = New System.Drawing.Point(118, 463)
        Me.DTPJamAkhir.Name = "DTPJamAkhir"
        Me.DTPJamAkhir.Size = New System.Drawing.Size(80, 20)
        Me.DTPJamAkhir.TabIndex = 14
        Me.DTPJamAkhir.Visible = False
        '
        'DTPJamAwal
        '
        Me.DTPJamAwal.CustomFormat = "HH:mm:ss"
        Me.DTPJamAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPJamAwal.Location = New System.Drawing.Point(204, 463)
        Me.DTPJamAwal.Name = "DTPJamAwal"
        Me.DTPJamAwal.Size = New System.Drawing.Size(80, 20)
        Me.DTPJamAwal.TabIndex = 13
        Me.DTPJamAwal.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(1, 14)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(65, 13)
        Me.Label32.TabIndex = 12
        Me.Label32.Text = "Jenis Rawat"
        '
        'cmbJenisRawat
        '
        Me.cmbJenisRawat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJenisRawat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJenisRawat.FormattingEnabled = True
        Me.cmbJenisRawat.Items.AddRange(New Object() {"Rawat Jalan", "Rawat Inap", "Rawat IGD"})
        Me.cmbJenisRawat.Location = New System.Drawing.Point(86, 11)
        Me.cmbJenisRawat.Name = "cmbJenisRawat"
        Me.cmbJenisRawat.Size = New System.Drawing.Size(211, 21)
        Me.cmbJenisRawat.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblIteration)
        Me.GroupBox1.Controls.Add(Me.GBObatRacikan)
        Me.GroupBox1.Controls.Add(Me.GBObatJadi)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(307, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1042, 235)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Resep Dokter"
        '
        'lblIteration
        '
        Me.lblIteration.AutoSize = True
        Me.lblIteration.Location = New System.Drawing.Point(462, 4)
        Me.lblIteration.Name = "lblIteration"
        Me.lblIteration.Size = New System.Drawing.Size(0, 13)
        Me.lblIteration.TabIndex = 105
        '
        'GBObatRacikan
        '
        Me.GBObatRacikan.Controls.Add(Me.gridObatRacikan)
        Me.GBObatRacikan.Dock = System.Windows.Forms.DockStyle.Top
        Me.GBObatRacikan.Location = New System.Drawing.Point(29, 116)
        Me.GBObatRacikan.Name = "GBObatRacikan"
        Me.GBObatRacikan.Size = New System.Drawing.Size(1010, 100)
        Me.GBObatRacikan.TabIndex = 3
        Me.GBObatRacikan.TabStop = False
        Me.GBObatRacikan.Text = "Obat Racikan"
        '
        'gridObatRacikan
        '
        Me.gridObatRacikan.AllowUserToAddRows = False
        Me.gridObatRacikan.AllowUserToDeleteRows = False
        Me.gridObatRacikan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridObatRacikan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Pilih})
        Me.gridObatRacikan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridObatRacikan.Location = New System.Drawing.Point(3, 16)
        Me.gridObatRacikan.Name = "gridObatRacikan"
        Me.gridObatRacikan.RowHeadersWidth = 5
        Me.gridObatRacikan.Size = New System.Drawing.Size(1004, 81)
        Me.gridObatRacikan.TabIndex = 1
        '
        'Pilih
        '
        Me.Pilih.HeaderText = "Pilih"
        Me.Pilih.Name = "Pilih"
        Me.Pilih.Text = "Pilih"
        '
        'GBObatJadi
        '
        Me.GBObatJadi.Controls.Add(Me.gridObatJadi)
        Me.GBObatJadi.Dock = System.Windows.Forms.DockStyle.Top
        Me.GBObatJadi.Location = New System.Drawing.Point(29, 16)
        Me.GBObatJadi.Name = "GBObatJadi"
        Me.GBObatJadi.Size = New System.Drawing.Size(1010, 100)
        Me.GBObatJadi.TabIndex = 2
        Me.GBObatJadi.TabStop = False
        Me.GBObatJadi.Text = "Obat Jadi"
        '
        'gridObatJadi
        '
        Me.gridObatJadi.AllowUserToAddRows = False
        Me.gridObatJadi.AllowUserToDeleteRows = False
        Me.gridObatJadi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridObatJadi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ButtonOk})
        Me.gridObatJadi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridObatJadi.Location = New System.Drawing.Point(3, 16)
        Me.gridObatJadi.Name = "gridObatJadi"
        Me.gridObatJadi.RowHeadersWidth = 5
        Me.gridObatJadi.Size = New System.Drawing.Size(1004, 81)
        Me.gridObatJadi.TabIndex = 0
        '
        'ButtonOk
        '
        Me.ButtonOk.HeaderText = "Pilih"
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ButtonOk.Text = "Pilih"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(btnTelaah)
        Me.Panel2.Controls.Add(Me.btnPrinResep)
        Me.Panel2.Controls.Add(Me.Button11)
        Me.Panel2.Controls.Add(Me.btnObatRacik)
        Me.Panel2.Controls.Add(Me.btnObtJadi)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(3, 16)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(26, 216)
        Me.Panel2.TabIndex = 1
        '
        'btnPrinResep
        '
        Me.btnPrinResep.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnPrinResep.Location = New System.Drawing.Point(0, 167)
        Me.btnPrinResep.Name = "btnPrinResep"
        Me.btnPrinResep.Size = New System.Drawing.Size(26, 23)
        Me.btnPrinResep.TabIndex = 3
        Me.btnPrinResep.Text = "P"
        Me.btnPrinResep.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Button11.Location = New System.Drawing.Point(0, 144)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(26, 23)
        Me.Button11.TabIndex = 2
        Me.Button11.Text = "..."
        Me.Button11.UseVisualStyleBackColor = True
        '
        'btnObatRacik
        '
        Me.btnObatRacik.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnObatRacik.Location = New System.Drawing.Point(0, 63)
        Me.btnObatRacik.Name = "btnObatRacik"
        Me.btnObatRacik.Size = New System.Drawing.Size(26, 81)
        Me.btnObatRacik.TabIndex = 1
        Me.btnObatRacik.Text = "RAC I K"
        Me.btnObatRacik.UseVisualStyleBackColor = True
        '
        'btnObtJadi
        '
        Me.btnObtJadi.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnObtJadi.Location = New System.Drawing.Point(0, 0)
        Me.btnObtJadi.Name = "btnObtJadi"
        Me.btnObtJadi.Size = New System.Drawing.Size(26, 63)
        Me.btnObtJadi.TabIndex = 0
        Me.btnObtJadi.Text = "JAD I"
        Me.btnObtJadi.UseVisualStyleBackColor = True
        '
        'FormPenjualanResepEMR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1349, 636)
        Me.Controls.Add(Me.PanelEtiket)
        Me.Controls.Add(Me.PanelObat)
        Me.Controls.Add(Me.PanelEtiketInfus)
        Me.Controls.Add(Me.PanelPasien)
        Me.Controls.Add(Me.PanelEtiketModel4)
        Me.Controls.Add(Me.PanelEtiketModel3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FormPenjualanResepEMR"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Penjualan Resep Obat EMR"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.TabControlAdv1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlAdv1.ResumeLayout(False)
        Me.TabPktUmum.ResumeLayout(False)
        CType(Me.gridDetailObat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.txtQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandIurBayarBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandDijaminBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotalBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandIurBayar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandDijamin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.gridEtiket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GROU.ResumeLayout(False)
        Me.GROU.PerformLayout()
        CType(Me.txtJmlBungkus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridPelayananObat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtIuranSisaBayar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDijamin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlahHarga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDosisResep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlahJual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHargaJual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDosis, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSenPotBeli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJmlHari, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DoubleTextBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPktKhusus.ResumeLayout(False)
        CType(Me.gridDetailObatKh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.txtQtyKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotalNonPaketBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotalPaketBulat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotalNonPaket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGrandTotalPaket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.txtTotalPaketLainKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTotalPaketBPJSKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJmlCapBPJSKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaketLainKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJmlCapLainKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJmlObatKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDosisResepKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPaketBPJSKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtHargaJualKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDosisKh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJmlHariKh, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEtiketModel4.ResumeLayout(False)
        Me.PanelEtiketModel4.PerformLayout()
        Me.PanelEtiketModel3.ResumeLayout(False)
        Me.PanelEtiketModel3.PerformLayout()
        CType(Me.txtJarakEDModel3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlahObatEtiketModel3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPasien.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.gridPasien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.PanelEtiketInfus.ResumeLayout(False)
        Me.PanelEtiketInfus.PerformLayout()
        CType(Me.txtJumlahObatEtiketInfus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelEtiket.ResumeLayout(False)
        Me.PanelEtiket.PerformLayout()
        CType(Me.txtJarakED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlahObatEtiket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQty3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.PanelObat.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.PanelResepDokter.ResumeLayout(False)
        CType(Me.gridPermintaanObat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPPN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLaba, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GBObatRacikan.ResumeLayout(False)
        CType(Me.gridObatRacikan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBObatJadi.ResumeLayout(False)
        CType(Me.gridObatJadi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents PanelPasien As System.Windows.Forms.Panel
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents gridPasien As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEx As System.Windows.Forms.Button
    Friend WithEvents DTPPasienReg As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtCariPasien As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents rNama As System.Windows.Forms.RadioButton
    Friend WithEvents rRm As System.Windows.Forms.RadioButton
    Friend WithEvents lblKetDaftar As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents TabControlAdv1 As Syncfusion.Windows.Forms.Tools.TabControlAdv
    Friend WithEvents TabPktUmum As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents gridDetailObat As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TabPktKhusus As Syncfusion.Windows.Forms.Tools.TabPageAdv
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents PanelObat As System.Windows.Forms.Panel
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCariObat As System.Windows.Forms.TextBox
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents PanelEtiket As System.Windows.Forms.Panel
    Friend WithEvents cmbKeterangan As System.Windows.Forms.ComboBox
    Friend WithEvents cmbWaktu As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTakaran As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtQty3 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTPTanggalTrans As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtNoResep As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNoReg As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNoKartu As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtNoUrut As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtRM As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSex As System.Windows.Forms.TextBox
    Friend WithEvents txtUmurThn As System.Windows.Forms.TextBox
    Friend WithEvents txtUmurBln As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaPasien As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbUnitAsal As System.Windows.Forms.ComboBox
    Friend WithEvents cmbPenjamin As System.Windows.Forms.ComboBox
    Friend WithEvents cmbDokter As System.Windows.Forms.ComboBox
    Friend WithEvents txtNota As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtGrandIurBayar As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtGrandDijamin As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtGrandTotal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents GROU As System.Windows.Forms.GroupBox
    Friend WithEvents txtIuranSisaBayar As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtDijamin As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtJumlahHarga As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtDosisResep As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtJumlahJual As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtHargaJual As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtDosis As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtSenPotBeli As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents cmbEtiket As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents DTPTglAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtJmlHari As Syncfusion.Windows.Forms.Tools.IntegerTextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmbDijamin As System.Windows.Forms.ComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents DoubleTextBox7 As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblNamaObat As System.Windows.Forms.Label
    Friend WithEvents txtKdSatuan As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtSatDosis As System.Windows.Forms.TextBox
    Friend WithEvents txtIdObat As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtKodeObat As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbRacikNon As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtGrandIurBayarBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtGrandDijaminBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtGrandTotalBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents btnKeluar As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnInfoResep As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnBaru As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnCetakEtiket As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnCetakNota As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnSimpan As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cmbJenisRawat As System.Windows.Forms.ComboBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents DTPJamAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnAdd As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents cmbPkt As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnAddKh As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtJmlCapLainKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtJmlObatKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtDosisResepKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtPaketBPJSKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtHargaJualKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtDosisKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents cmbEtiketKh As System.Windows.Forms.ComboBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents DTPTglAkhirKh As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtJmlHariKh As Syncfusion.Windows.Forms.Tools.IntegerTextBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lblNamaObatKh As System.Windows.Forms.Label
    Friend WithEvents txtSatPaketBPJSKh As System.Windows.Forms.TextBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents txtSatDosisKh As System.Windows.Forms.TextBox
    Friend WithEvents txtIdObatKh As System.Windows.Forms.TextBox
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txtKodeObatKh As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents cmbRacikNonKh As System.Windows.Forms.ComboBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents gridDetailObatKh As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents txtGrandTotalNonPaketBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtGrandTotalPaketBulat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtGrandTotalNonPaket As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtGrandTotalPaket As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents btnKeluarKh As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnInfoResepKh As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnBaruKh As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnCetakEtiketKh As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnCetakBPJS As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnSimpanKh As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents txtPaketLainKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtSatPaketLainKh As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents txtJmlCapBPJSKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalPaketLainKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtTotalPaketBPJSKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents btnCetakLain As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtHapusBaris As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txtQty As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents txtQtyKh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents DTPJamAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents txtNamaObatEtiket As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents DTPTanggalExp As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtSigna2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSigna1 As System.Windows.Forms.TextBox
    Friend WithEvents txtJumlahObatEtiket As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtJarakED As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents DTPCekObat As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnUpdateDijamin As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnUpdateIurPasien As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents btnModel2 As System.Windows.Forms.Button
    Friend WithEvents PanelEtiketInfus As System.Windows.Forms.Panel
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents btnModel1 As System.Windows.Forms.Button
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents txtJumlahObatEtiketInfus As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtNamaObatEtiketInfus As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents txtTetesInfus As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtObatInfus As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents lblKamarBed As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents PanelEtiketModel3 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents txtNamaObatEtiketModel3 As System.Windows.Forms.TextBox
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents cmbKeteranganModel3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents txtJumlahObatEtiketModel3 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents txtJarakEDModel3 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents PanelEtiketModel4 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents txtNamaObatEtiketModel4 As System.Windows.Forms.TextBox
    Friend WithEvents Label77 As System.Windows.Forms.Label
    Friend WithEvents rSesudah As System.Windows.Forms.RadioButton
    Friend WithEvents rBersama As System.Windows.Forms.RadioButton
    Friend WithEvents rSebelum As System.Windows.Forms.RadioButton
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents cbMalam As System.Windows.Forms.CheckBox
    Friend WithEvents cbSiang As System.Windows.Forms.CheckBox
    Friend WithEvents cbPagi As System.Windows.Forms.CheckBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents cbInjeksi As System.Windows.Forms.CheckBox
    Friend WithEvents gridEtiket As System.Windows.Forms.DataGridView
    Friend WithEvents rInjeksi As System.Windows.Forms.RadioButton
    Friend WithEvents txtLaba As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label76 As System.Windows.Forms.Label
    Friend WithEvents Label78 As System.Windows.Forms.Label
    Friend WithEvents txtPPN As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents cbSore As System.Windows.Forms.CheckBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PanelResepDokter As System.Windows.Forms.Panel
    Friend WithEvents gridPermintaanObat As System.Windows.Forms.DataGridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnObatRacik As System.Windows.Forms.Button
    Friend WithEvents btnObtJadi As System.Windows.Forms.Button
    Friend WithEvents GBObatJadi As System.Windows.Forms.GroupBox
    Friend WithEvents GBObatRacikan As System.Windows.Forms.GroupBox
    Friend WithEvents gridObatJadi As System.Windows.Forms.DataGridView
    Friend WithEvents gridObatRacikan As System.Windows.Forms.DataGridView
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents gridPelayananObat As DataGridView
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Pilih As DataGridViewButtonColumn
    Friend WithEvents ButtonOk As DataGridViewButtonColumn
    Friend WithEvents txtJmlBungkus As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label79 As Label
    Friend WithEvents txtNoSEP As TextBox
    Friend WithEvents lblIteration As Label
    Friend WithEvents btnPrinResep As Button
    Friend WithEvents txtJam As TextBox
    Friend WithEvents Column3 As DataGridViewButtonColumn
End Class
