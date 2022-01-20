<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRincianObatPasienRI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRincianObatPasienRI))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DTPBantu = New System.Windows.Forms.DateTimePicker()
        Me.txtDokter = New System.Windows.Forms.TextBox()
        Me.txtPenjamin = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnView = New System.Windows.Forms.Button()
        Me.DTPAkhir = New System.Windows.Forms.DateTimePicker()
        Me.DTPAwal = New System.Windows.Forms.DateTimePicker()
        Me.txtRM = New System.Windows.Forms.TextBox()
        Me.txtNamaPasien = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.PanelPasien = New System.Windows.Forms.Panel()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.gridPasien = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btnEx = New System.Windows.Forms.Button()
        Me.txtCariPasien = New System.Windows.Forms.TextBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.rNama = New System.Windows.Forms.RadioButton()
        Me.rRm = New System.Windows.Forms.RadioButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.PanelPasien.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.gridPasien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.DTPBantu)
        Me.GroupBox1.Controls.Add(Me.txtDokter)
        Me.GroupBox1.Controls.Add(Me.txtPenjamin)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnView)
        Me.GroupBox1.Controls.Add(Me.DTPAkhir)
        Me.GroupBox1.Controls.Add(Me.DTPAwal)
        Me.GroupBox1.Controls.Add(Me.txtRM)
        Me.GroupBox1.Controls.Add(Me.txtNamaPasien)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(822, 99)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'DTPBantu
        '
        Me.DTPBantu.Location = New System.Drawing.Point(630, 20)
        Me.DTPBantu.Name = "DTPBantu"
        Me.DTPBantu.Size = New System.Drawing.Size(170, 20)
        Me.DTPBantu.TabIndex = 9
        Me.DTPBantu.Visible = False
        '
        'txtDokter
        '
        Me.txtDokter.BackColor = System.Drawing.SystemColors.Control
        Me.txtDokter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDokter.Location = New System.Drawing.Point(412, 65)
        Me.txtDokter.Name = "txtDokter"
        Me.txtDokter.ReadOnly = True
        Me.txtDokter.Size = New System.Drawing.Size(212, 20)
        Me.txtDokter.TabIndex = 8
        '
        'txtPenjamin
        '
        Me.txtPenjamin.BackColor = System.Drawing.SystemColors.Control
        Me.txtPenjamin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPenjamin.Location = New System.Drawing.Point(412, 43)
        Me.txtPenjamin.Name = "txtPenjamin"
        Me.txtPenjamin.ReadOnly = True
        Me.txtPenjamin.Size = New System.Drawing.Size(212, 20)
        Me.txtPenjamin.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(321, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Dokter"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(321, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Penjamin"
        '
        'btnView
        '
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnView.Location = New System.Drawing.Point(630, 43)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(53, 44)
        Me.btnView.TabIndex = 4
        Me.btnView.Text = "View"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnView.UseVisualStyleBackColor = True
        '
        'DTPAkhir
        '
        Me.DTPAkhir.Location = New System.Drawing.Point(412, 20)
        Me.DTPAkhir.Name = "DTPAkhir"
        Me.DTPAkhir.Size = New System.Drawing.Size(212, 20)
        Me.DTPAkhir.TabIndex = 1
        '
        'DTPAwal
        '
        Me.DTPAwal.Location = New System.Drawing.Point(103, 20)
        Me.DTPAwal.Name = "DTPAwal"
        Me.DTPAwal.Size = New System.Drawing.Size(212, 20)
        Me.DTPAwal.TabIndex = 0
        '
        'txtRM
        '
        Me.txtRM.BackColor = System.Drawing.SystemColors.Control
        Me.txtRM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRM.Location = New System.Drawing.Point(103, 65)
        Me.txtRM.Name = "txtRM"
        Me.txtRM.ReadOnly = True
        Me.txtRM.Size = New System.Drawing.Size(212, 20)
        Me.txtRM.TabIndex = 3
        '
        'txtNamaPasien
        '
        Me.txtNamaPasien.BackColor = System.Drawing.SystemColors.Info
        Me.txtNamaPasien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaPasien.Location = New System.Drawing.Point(103, 43)
        Me.txtNamaPasien.Name = "txtNamaPasien"
        Me.txtNamaPasien.Size = New System.Drawing.Size(212, 20)
        Me.txtNamaPasien.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(320, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Sampai Tanggal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Dari Tanggal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nomor RM"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nama Pasien"
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 99)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReuseParameterValuesOnRefresh = True
        Me.CrystalReportViewer1.ShowCloseButton = False
        Me.CrystalReportViewer1.ShowCopyButton = False
        Me.CrystalReportViewer1.ShowGroupTreeButton = False
        Me.CrystalReportViewer1.ShowLogo = False
        Me.CrystalReportViewer1.ShowParameterPanelButton = False
        Me.CrystalReportViewer1.ShowRefreshButton = False
        Me.CrystalReportViewer1.ShowTextSearchButton = False
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(822, 515)
        Me.CrystalReportViewer1.TabIndex = 1
        Me.CrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'PanelPasien
        '
        Me.PanelPasien.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.PanelPasien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PanelPasien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelPasien.Controls.Add(Me.GroupBox10)
        Me.PanelPasien.Controls.Add(Me.GroupBox8)
        Me.PanelPasien.Location = New System.Drawing.Point(103, 115)
        Me.PanelPasien.Name = "PanelPasien"
        Me.PanelPasien.Size = New System.Drawing.Size(558, 321)
        Me.PanelPasien.TabIndex = 14
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
        Me.GroupBox8.Controls.Add(Me.btnEx)
        Me.GroupBox8.Controls.Add(Me.txtCariPasien)
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox8.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(556, 74)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
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
        'txtCariPasien
        '
        Me.txtCariPasien.Location = New System.Drawing.Point(170, 33)
        Me.txtCariPasien.Name = "txtCariPasien"
        Me.txtCariPasien.Size = New System.Drawing.Size(375, 20)
        Me.txtCariPasien.TabIndex = 8
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.rNama)
        Me.GroupBox9.Controls.Add(Me.rRm)
        Me.GroupBox9.Location = New System.Drawing.Point(46, 25)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(118, 30)
        Me.GroupBox9.TabIndex = 7
        Me.GroupBox9.TabStop = False
        '
        'rNama
        '
        Me.rNama.AutoSize = True
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
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(689, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(53, 44)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Baru"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormRincianObatPasienRI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(822, 614)
        Me.Controls.Add(Me.PanelPasien)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormRincianObatPasienRI"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Rincian Obat Pasien RI"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelPasien.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.gridPasien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents DTPAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtRM As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaPasien As System.Windows.Forms.TextBox
    Friend WithEvents PanelPasien As System.Windows.Forms.Panel
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents gridPasien As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnEx As System.Windows.Forms.Button
    Friend WithEvents txtCariPasien As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents rNama As System.Windows.Forms.RadioButton
    Friend WithEvents rRm As System.Windows.Forms.RadioButton
    Friend WithEvents txtDokter As System.Windows.Forms.TextBox
    Friend WithEvents txtPenjamin As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTPBantu As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
