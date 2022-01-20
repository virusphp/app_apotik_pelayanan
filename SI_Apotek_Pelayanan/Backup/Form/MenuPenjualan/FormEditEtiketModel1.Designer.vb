<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditEtiketModel1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEditEtiketModel1))
        Me.PanelEtiket = New System.Windows.Forms.Panel()
        Me.DTPTanggalExp = New System.Windows.Forms.DateTimePicker()
        Me.Button1 = New System.Windows.Forms.Button()
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
        Me.PanelEtiket.SuspendLayout()
        CType(Me.txtJarakED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJumlahObatEtiket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtQty3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEtiket
        '
        Me.PanelEtiket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEtiket.Controls.Add(Me.DTPTanggalExp)
        Me.PanelEtiket.Controls.Add(Me.Button1)
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
        Me.PanelEtiket.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEtiket.Location = New System.Drawing.Point(0, 0)
        Me.PanelEtiket.Name = "PanelEtiket"
        Me.PanelEtiket.Size = New System.Drawing.Size(282, 210)
        Me.PanelEtiket.TabIndex = 17
        '
        'DTPTanggalExp
        '
        Me.DTPTanggalExp.CustomFormat = "dd/MM/yyyy"
        Me.DTPTanggalExp.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTanggalExp.Location = New System.Drawing.Point(82, 174)
        Me.DTPTanggalExp.Name = "DTPTanggalExp"
        Me.DTPTanggalExp.Size = New System.Drawing.Size(94, 20)
        Me.DTPTanggalExp.TabIndex = 110
        Me.DTPTanggalExp.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(190, 175)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 109
        Me.Button1.Text = "Simpan"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label62
        '
        Me.Label62.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label62.Location = New System.Drawing.Point(214, 149)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(51, 20)
        Me.Label62.TabIndex = 108
        Me.Label62.Text = "Hari"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(11, 151)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(51, 13)
        Me.Label61.TabIndex = 107
        Me.Label61.Text = "Jarak ED"
        '
        'txtJarakED
        '
        Me.txtJarakED.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtJarakED.BeforeTouchSize = New System.Drawing.Size(51, 20)
        Me.txtJarakED.BorderColor = System.Drawing.Color.DimGray
        Me.txtJarakED.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJarakED.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJarakED.CurrencySymbol = ""
        Me.txtJarakED.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJarakED.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJarakED.Location = New System.Drawing.Point(82, 149)
        Me.txtJarakED.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJarakED.Name = "txtJarakED"
        Me.txtJarakED.NullString = ""
        Me.txtJarakED.Size = New System.Drawing.Size(137, 20)
        Me.txtJarakED.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJarakED.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJarakED.TabIndex = 12
        Me.txtJarakED.Text = "0.00"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Location = New System.Drawing.Point(11, 35)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(66, 13)
        Me.Label60.TabIndex = 106
        Me.Label60.Text = "Jumlah Obat"
        '
        'txtJumlahObatEtiket
        '
        Me.txtJumlahObatEtiket.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtJumlahObatEtiket.BeforeTouchSize = New System.Drawing.Size(51, 20)
        Me.txtJumlahObatEtiket.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahObatEtiket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahObatEtiket.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahObatEtiket.CurrencySymbol = ""
        Me.txtJumlahObatEtiket.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahObatEtiket.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahObatEtiket.Location = New System.Drawing.Point(82, 32)
        Me.txtJumlahObatEtiket.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahObatEtiket.Name = "txtJumlahObatEtiket"
        Me.txtJumlahObatEtiket.NullString = ""
        Me.txtJumlahObatEtiket.Size = New System.Drawing.Size(183, 20)
        Me.txtJumlahObatEtiket.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahObatEtiket.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJumlahObatEtiket.TabIndex = 8
        Me.txtJumlahObatEtiket.Text = "0.00"
        '
        'txtSigna2
        '
        Me.txtSigna2.Location = New System.Drawing.Point(184, 55)
        Me.txtSigna2.Name = "txtSigna2"
        Me.txtSigna2.Size = New System.Drawing.Size(81, 20)
        Me.txtSigna2.TabIndex = 102
        '
        'txtSigna1
        '
        Me.txtSigna1.Location = New System.Drawing.Point(82, 55)
        Me.txtSigna1.Name = "txtSigna1"
        Me.txtSigna1.Size = New System.Drawing.Size(81, 20)
        Me.txtSigna1.TabIndex = 101
        '
        'txtNamaObatEtiket
        '
        Me.txtNamaObatEtiket.Location = New System.Drawing.Point(82, 9)
        Me.txtNamaObatEtiket.Name = "txtNamaObatEtiket"
        Me.txtNamaObatEtiket.Size = New System.Drawing.Size(183, 20)
        Me.txtNamaObatEtiket.TabIndex = 7
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(11, 12)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(61, 13)
        Me.Label56.TabIndex = 99
        Me.Label56.Text = "Nama Obat"
        '
        'cmbKeterangan
        '
        Me.cmbKeterangan.FormattingEnabled = True
        Me.cmbKeterangan.Location = New System.Drawing.Point(82, 125)
        Me.cmbKeterangan.Name = "cmbKeterangan"
        Me.cmbKeterangan.Size = New System.Drawing.Size(183, 21)
        Me.cmbKeterangan.TabIndex = 11
        Me.cmbKeterangan.Text = "-"
        '
        'cmbWaktu
        '
        Me.cmbWaktu.FormattingEnabled = True
        Me.cmbWaktu.Location = New System.Drawing.Point(82, 101)
        Me.cmbWaktu.Name = "cmbWaktu"
        Me.cmbWaktu.Size = New System.Drawing.Size(183, 21)
        Me.cmbWaktu.TabIndex = 10
        Me.cmbWaktu.Text = "-"
        '
        'cmbTakaran
        '
        Me.cmbTakaran.FormattingEnabled = True
        Me.cmbTakaran.Location = New System.Drawing.Point(82, 77)
        Me.cmbTakaran.Name = "cmbTakaran"
        Me.cmbTakaran.Size = New System.Drawing.Size(183, 21)
        Me.cmbTakaran.TabIndex = 9
        Me.cmbTakaran.Text = "-"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(165, 56)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(14, 13)
        Me.Label37.TabIndex = 95
        Me.Label37.Text = "X"
        '
        'txtQty3
        '
        Me.txtQty3.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtQty3.BeforeTouchSize = New System.Drawing.Size(51, 20)
        Me.txtQty3.BorderColor = System.Drawing.Color.DimGray
        Me.txtQty3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQty3.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtQty3.CurrencySymbol = ""
        Me.txtQty3.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtQty3.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtQty3.Enabled = False
        Me.txtQty3.Location = New System.Drawing.Point(214, 55)
        Me.txtQty3.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtQty3.Name = "txtQty3"
        Me.txtQty3.NullString = ""
        Me.txtQty3.Size = New System.Drawing.Size(51, 20)
        Me.txtQty3.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtQty3.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtQty3.TabIndex = 94
        Me.txtQty3.Text = "0.00"
        Me.txtQty3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtQty3.Visible = False
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(11, 128)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(62, 13)
        Me.Label36.TabIndex = 3
        Me.Label36.Text = "Keterangan"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(11, 104)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(39, 13)
        Me.Label35.TabIndex = 2
        Me.Label35.Text = "Waktu"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(11, 80)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 13)
        Me.Label34.TabIndex = 1
        Me.Label34.Text = "Takaran"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(11, 57)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(65, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Signa 1 Hari"
        '
        'FormEditEtiketMode1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 210)
        Me.Controls.Add(Me.PanelEtiket)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEditEtiketMode1"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Etiket Model 1"
        Me.PanelEtiket.ResumeLayout(False)
        Me.PanelEtiket.PerformLayout()
        CType(Me.txtJarakED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJumlahObatEtiket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtQty3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEtiket As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents txtJarakED As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents txtJumlahObatEtiket As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtSigna2 As System.Windows.Forms.TextBox
    Friend WithEvents txtSigna1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaObatEtiket As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents cmbKeterangan As System.Windows.Forms.ComboBox
    Friend WithEvents cmbWaktu As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTakaran As System.Windows.Forms.ComboBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents txtQty3 As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DTPTanggalExp As System.Windows.Forms.DateTimePicker
End Class
