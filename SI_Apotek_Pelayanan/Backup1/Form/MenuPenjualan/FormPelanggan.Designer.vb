<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPelanggan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPelanggan))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtUnit = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKodePelanggan = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTPTanggalTrans = New System.Windows.Forms.DateTimePicker()
        Me.txtNoTelepon = New System.Windows.Forms.TextBox()
        Me.cmbJenisPelanggan = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNamaPelanggan = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSimpan = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.PanelPegawai = New System.Windows.Forms.Panel()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.gridPegawai = New System.Windows.Forms.DataGridView()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCariPegawai = New System.Windows.Forms.TextBox()
        Me.btnCloseKaryawan = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.PanelPegawai.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.gridPegawai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtUnit)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtKodePelanggan)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.DTPTanggalTrans)
        Me.GroupBox2.Controls.Add(Me.txtNoTelepon)
        Me.GroupBox2.Controls.Add(Me.cmbJenisPelanggan)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtAlamat)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtNamaPelanggan)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(650, 158)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        '
        'txtUnit
        '
        Me.txtUnit.BackColor = System.Drawing.SystemColors.Window
        Me.txtUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUnit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUnit.Location = New System.Drawing.Point(104, 84)
        Me.txtUnit.Name = "txtUnit"
        Me.txtUnit.ReadOnly = True
        Me.txtUnit.Size = New System.Drawing.Size(242, 20)
        Me.txtUnit.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 13)
        Me.Label3.TabIndex = 50
        Me.Label3.Text = "Unit"
        '
        'txtKodePelanggan
        '
        Me.txtKodePelanggan.BackColor = System.Drawing.SystemColors.Window
        Me.txtKodePelanggan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKodePelanggan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKodePelanggan.Location = New System.Drawing.Point(104, 39)
        Me.txtKodePelanggan.Name = "txtKodePelanggan"
        Me.txtKodePelanggan.ReadOnly = True
        Me.txtKodePelanggan.Size = New System.Drawing.Size(242, 20)
        Me.txtKodePelanggan.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 13)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Kode Pelanggan"
        '
        'DTPTanggalTrans
        '
        Me.DTPTanggalTrans.CustomFormat = "dd MMMM yyyy"
        Me.DTPTanggalTrans.Enabled = False
        Me.DTPTanggalTrans.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPTanggalTrans.Location = New System.Drawing.Point(373, 17)
        Me.DTPTanggalTrans.Name = "DTPTanggalTrans"
        Me.DTPTanggalTrans.Size = New System.Drawing.Size(215, 20)
        Me.DTPTanggalTrans.TabIndex = 16
        Me.DTPTanggalTrans.Visible = False
        '
        'txtNoTelepon
        '
        Me.txtNoTelepon.BackColor = System.Drawing.SystemColors.Window
        Me.txtNoTelepon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoTelepon.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNoTelepon.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoTelepon.Location = New System.Drawing.Point(104, 130)
        Me.txtNoTelepon.Name = "txtNoTelepon"
        Me.txtNoTelepon.Size = New System.Drawing.Size(242, 20)
        Me.txtNoTelepon.TabIndex = 5
        '
        'cmbJenisPelanggan
        '
        Me.cmbJenisPelanggan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJenisPelanggan.FormattingEnabled = True
        Me.cmbJenisPelanggan.Location = New System.Drawing.Point(104, 16)
        Me.cmbJenisPelanggan.Name = "cmbJenisPelanggan"
        Me.cmbJenisPelanggan.Size = New System.Drawing.Size(242, 21)
        Me.cmbJenisPelanggan.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 132)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(57, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "No Telpon"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(85, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Jenis Pelanggan"
        '
        'txtAlamat
        '
        Me.txtAlamat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAlamat.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Location = New System.Drawing.Point(104, 106)
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(474, 20)
        Me.txtAlamat.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 27
        Me.Label7.Text = "Alamat"
        '
        'txtNamaPelanggan
        '
        Me.txtNamaPelanggan.BackColor = System.Drawing.SystemColors.Window
        Me.txtNamaPelanggan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaPelanggan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNamaPelanggan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaPelanggan.Location = New System.Drawing.Point(104, 61)
        Me.txtNamaPelanggan.Name = "txtNamaPelanggan"
        Me.txtNamaPelanggan.Size = New System.Drawing.Size(242, 20)
        Me.txtNamaPelanggan.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Nama"
        '
        'btnSimpan
        '
        Me.btnSimpan.BeforeTouchSize = New System.Drawing.Size(120, 37)
        Me.btnSimpan.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSimpan.Image = CType(resources.GetObject("btnSimpan.Image"), System.Drawing.Image)
        Me.btnSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSimpan.IsBackStageButton = False
        Me.btnSimpan.Location = New System.Drawing.Point(530, 158)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(120, 37)
        Me.btnSimpan.TabIndex = 6
        Me.btnSimpan.Text = "Simpan [F12]"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PanelPegawai
        '
        Me.PanelPegawai.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelPegawai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelPegawai.Controls.Add(Me.GroupBox12)
        Me.PanelPegawai.Controls.Add(Me.GroupBox11)
        Me.PanelPegawai.Location = New System.Drawing.Point(-1, 164)
        Me.PanelPegawai.Name = "PanelPegawai"
        Me.PanelPegawai.Size = New System.Drawing.Size(646, 185)
        Me.PanelPegawai.TabIndex = 15
        Me.PanelPegawai.Visible = False
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.gridPegawai)
        Me.GroupBox12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox12.Location = New System.Drawing.Point(0, 45)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(644, 138)
        Me.GroupBox12.TabIndex = 1
        Me.GroupBox12.TabStop = False
        '
        'gridPegawai
        '
        Me.gridPegawai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPegawai.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column2})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Tai Le", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.gridPegawai.DefaultCellStyle = DataGridViewCellStyle1
        Me.gridPegawai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPegawai.Location = New System.Drawing.Point(3, 16)
        Me.gridPegawai.Name = "gridPegawai"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Tai Le", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.gridPegawai.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.gridPegawai.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridPegawai.Size = New System.Drawing.Size(638, 119)
        Me.gridPegawai.TabIndex = 0
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
        Me.GroupBox11.Controls.Add(Me.txtCariPegawai)
        Me.GroupBox11.Controls.Add(Me.btnCloseKaryawan)
        Me.GroupBox11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox11.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(644, 45)
        Me.GroupBox11.TabIndex = 0
        Me.GroupBox11.TabStop = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(49, 14)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(85, 13)
        Me.Label33.TabIndex = 12
        Me.Label33.Text = "Nama Karyawan"
        '
        'txtCariPegawai
        '
        Me.txtCariPegawai.Location = New System.Drawing.Point(140, 11)
        Me.txtCariPegawai.Name = "txtCariPegawai"
        Me.txtCariPegawai.Size = New System.Drawing.Size(498, 20)
        Me.txtCariPegawai.TabIndex = 10
        '
        'btnCloseKaryawan
        '
        Me.btnCloseKaryawan.Image = CType(resources.GetObject("btnCloseKaryawan.Image"), System.Drawing.Image)
        Me.btnCloseKaryawan.Location = New System.Drawing.Point(6, 7)
        Me.btnCloseKaryawan.Name = "btnCloseKaryawan"
        Me.btnCloseKaryawan.Size = New System.Drawing.Size(35, 30)
        Me.btnCloseKaryawan.TabIndex = 7
        Me.btnCloseKaryawan.UseVisualStyleBackColor = True
        '
        'FormPelanggan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(650, 195)
        Me.Controls.Add(Me.PanelPegawai)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "FormPelanggan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tambah Pelanggan"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.PanelPegawai.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.gridPegawai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbJenisPelanggan As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents txtAlamat As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtNamaPelanggan As TextBox
    Friend WithEvents txtNoTelepon As TextBox
    Friend WithEvents btnSimpan As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents DTPTanggalTrans As DateTimePicker
    Friend WithEvents txtKodePelanggan As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtUnit As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PanelPegawai As Panel
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents gridPegawai As DataGridView
    Friend WithEvents Column2 As DataGridViewImageColumn
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents Label33 As Label
    Friend WithEvents txtCariPegawai As TextBox
    Friend WithEvents btnCloseKaryawan As Button
End Class
