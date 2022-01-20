<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLaporanHarianJualBebas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLaporanHarianJualBebas))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbBagianTab1 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBaruTab1 = New System.Windows.Forms.Button()
        Me.btnExcelTab1 = New System.Windows.Forms.Button()
        Me.btnProsesTab1 = New System.Windows.Forms.Button()
        Me.DTPTanggalAkhirTab1 = New System.Windows.Forms.DateTimePicker()
        Me.DTPTanggalAwalTab1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalSeluruh = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTotalObat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtNota = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.GridObat = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtTotalSeluruh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTotalObat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNota, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridObat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbBagianTab1)
        Me.GroupBox1.Controls.Add(Me.Label5)
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
        Me.GroupBox1.Size = New System.Drawing.Size(1110, 90)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cmbBagianTab1
        '
        Me.cmbBagianTab1.FormattingEnabled = True
        Me.cmbBagianTab1.Location = New System.Drawing.Point(108, 15)
        Me.cmbBagianTab1.Name = "cmbBagianTab1"
        Me.cmbBagianTab1.Size = New System.Drawing.Size(200, 21)
        Me.cmbBagianTab1.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Bagian"
        '
        'btnBaruTab1
        '
        Me.btnBaruTab1.Image = CType(resources.GetObject("btnBaruTab1.Image"), System.Drawing.Image)
        Me.btnBaruTab1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaruTab1.Location = New System.Drawing.Point(842, 24)
        Me.btnBaruTab1.Name = "btnBaruTab1"
        Me.btnBaruTab1.Size = New System.Drawing.Size(85, 35)
        Me.btnBaruTab1.TabIndex = 8
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
        Me.btnExcelTab1.TabIndex = 7
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
        Me.btnProsesTab1.TabIndex = 6
        Me.btnProsesTab1.Text = "Proses"
        Me.btnProsesTab1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesTab1.UseVisualStyleBackColor = True
        '
        'DTPTanggalAkhirTab1
        '
        Me.DTPTanggalAkhirTab1.Location = New System.Drawing.Point(108, 61)
        Me.DTPTanggalAkhirTab1.Name = "DTPTanggalAkhirTab1"
        Me.DTPTanggalAkhirTab1.Size = New System.Drawing.Size(200, 20)
        Me.DTPTanggalAkhirTab1.TabIndex = 3
        '
        'DTPTanggalAwalTab1
        '
        Me.DTPTanggalAwalTab1.Location = New System.Drawing.Point(108, 38)
        Me.DTPTanggalAwalTab1.Name = "DTPTanggalAwalTab1"
        Me.DTPTanggalAwalTab1.Size = New System.Drawing.Size(200, 20)
        Me.DTPTanggalAwalTab1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(84, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sampai Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Dari Tanggal"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtTotalSeluruh)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtTotalObat)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txtNota)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 576)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1110, 60)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.Location = New System.Drawing.Point(953, 15)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(141, 20)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "Total Seluruh"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.txtTotalSeluruh.Location = New System.Drawing.Point(953, 33)
        Me.txtTotalSeluruh.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalSeluruh.Name = "txtTotalSeluruh"
        Me.txtTotalSeluruh.NullString = ""
        Me.txtTotalSeluruh.ReadOnly = True
        Me.txtTotalSeluruh.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalSeluruh.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalSeluruh.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalSeluruh.TabIndex = 29
        Me.txtTotalSeluruh.Text = "0.00"
        Me.txtTotalSeluruh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.Location = New System.Drawing.Point(813, 15)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(141, 20)
        Me.Label12.TabIndex = 28
        Me.Label12.Text = "Total Obat"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
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
        Me.txtTotalObat.Location = New System.Drawing.Point(813, 33)
        Me.txtTotalObat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtTotalObat.Name = "txtTotalObat"
        Me.txtTotalObat.NullString = ""
        Me.txtTotalObat.ReadOnly = True
        Me.txtTotalObat.Size = New System.Drawing.Size(141, 20)
        Me.txtTotalObat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtTotalObat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtTotalObat.TabIndex = 27
        Me.txtTotalObat.Text = "0.00"
        Me.txtTotalObat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.Location = New System.Drawing.Point(673, 15)
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
        Me.txtNota.Location = New System.Drawing.Point(673, 33)
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
        Me.GridObat.Size = New System.Drawing.Size(1110, 486)
        Me.GridObat.TabIndex = 3
        '
        'FormLaporanHarianJualBebas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1110, 636)
        Me.Controls.Add(Me.GridObat)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormLaporanHarianJualBebas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Laporan Harian Penjualan Obat Bebas"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        Me.GroupBox2.ResumeLayout(false)
        Me.GroupBox2.PerformLayout
        CType(Me.txtTotalSeluruh,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTotalObat,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtNota,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.GridObat,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbBagianTab1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBaruTab1 As System.Windows.Forms.Button
    Friend WithEvents btnExcelTab1 As System.Windows.Forms.Button
    Friend WithEvents btnProsesTab1 As System.Windows.Forms.Button
    Friend WithEvents DTPTanggalAkhirTab1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPTanggalAwalTab1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTotalSeluruh As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtTotalObat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtNota As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents GridObat As System.Windows.Forms.DataGridView
End Class
