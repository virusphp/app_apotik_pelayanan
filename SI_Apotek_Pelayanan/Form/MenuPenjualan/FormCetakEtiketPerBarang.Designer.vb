<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCetakEtiketPerBarang
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCetakEtiketPerBarang))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtNotaResep = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.DTPTanggalResep = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtNamaObat = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNamaPasien = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtRM = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gridEtiket = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtNotaResep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaObat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaPasien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridEtiket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNotaResep)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.DTPTanggalResep)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ButtonAdv1)
        Me.GroupBox1.Controls.Add(Me.txtNamaObat)
        Me.GroupBox1.Controls.Add(Me.txtNamaPasien)
        Me.GroupBox1.Controls.Add(Me.txtRM)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(509, 134)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txtNotaResep
        '
        Me.txtNotaResep.BeforeTouchSize = New System.Drawing.Size(200, 20)
        Me.txtNotaResep.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNotaResep.Enabled = False
        Me.txtNotaResep.Location = New System.Drawing.Point(114, 34)
        Me.txtNotaResep.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNotaResep.Name = "txtNotaResep"
        Me.txtNotaResep.Size = New System.Drawing.Size(200, 20)
        Me.txtNotaResep.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNotaResep.TabIndex = 96
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(12, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 20)
        Me.Label6.TabIndex = 95
        Me.Label6.Text = "Nota Resep"
        '
        'DTPTanggalResep
        '
        Me.DTPTanggalResep.Enabled = False
        Me.DTPTanggalResep.Location = New System.Drawing.Point(114, 12)
        Me.DTPTanggalResep.Name = "DTPTanggalResep"
        Me.DTPTanggalResep.Size = New System.Drawing.Size(200, 20)
        Me.DTPTanggalResep.TabIndex = 94
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(12, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 20)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Tanggal"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(33, 23)
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(467, 9)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(33, 23)
        Me.ButtonAdv1.TabIndex = 7
        '
        'txtNamaObat
        '
        Me.txtNamaObat.BackColor = System.Drawing.SystemColors.Info
        Me.txtNamaObat.BeforeTouchSize = New System.Drawing.Size(200, 20)
        Me.txtNamaObat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNamaObat.Location = New System.Drawing.Point(114, 100)
        Me.txtNamaObat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNamaObat.Name = "txtNamaObat"
        Me.txtNamaObat.Size = New System.Drawing.Size(200, 20)
        Me.txtNamaObat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNamaObat.TabIndex = 5
        '
        'txtNamaPasien
        '
        Me.txtNamaPasien.BeforeTouchSize = New System.Drawing.Size(200, 20)
        Me.txtNamaPasien.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNamaPasien.Enabled = False
        Me.txtNamaPasien.Location = New System.Drawing.Point(114, 78)
        Me.txtNamaPasien.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNamaPasien.Name = "txtNamaPasien"
        Me.txtNamaPasien.Size = New System.Drawing.Size(200, 20)
        Me.txtNamaPasien.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNamaPasien.TabIndex = 4
        '
        'txtRM
        '
        Me.txtRM.BeforeTouchSize = New System.Drawing.Size(200, 20)
        Me.txtRM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRM.Enabled = False
        Me.txtRM.Location = New System.Drawing.Point(114, 56)
        Me.txtRM.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRM.Name = "txtRM"
        Me.txtRM.Size = New System.Drawing.Size(200, 20)
        Me.txtRM.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtRM.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(12, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cari Obat"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(12, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Pasien"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(12, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No RM"
        '
        'gridEtiket
        '
        Me.gridEtiket.AllowUserToAddRows = False
        Me.gridEtiket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridEtiket.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        Me.gridEtiket.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridEtiket.Location = New System.Drawing.Point(0, 134)
        Me.gridEtiket.Name = "gridEtiket"
        Me.gridEtiket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridEtiket.Size = New System.Drawing.Size(509, 252)
        Me.gridEtiket.TabIndex = 2
        '
        'Column1
        '
        Me.Column1.HeaderText = "Cetak"
        Me.Column1.Image = CType(resources.GetObject("Column1.Image"), System.Drawing.Image)
        Me.Column1.Name = "Column1"
        '
        'Column2
        '
        Me.Column2.HeaderText = "Edit"
        Me.Column2.Image = CType(resources.GetObject("Column2.Image"), System.Drawing.Image)
        Me.Column2.Name = "Column2"
        '
        'FormCetakEtiketPerBarang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(509, 386)
        Me.Controls.Add(Me.gridEtiket)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormCetakEtiketPerBarang"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cetak Etiket Perbarang"
        Me.GroupBox1.ResumeLayout(false)
        Me.GroupBox1.PerformLayout
        CType(Me.txtNotaResep,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtNamaObat,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtNamaPasien,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtRM,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.gridEtiket,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents txtNamaObat As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNamaPasien As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtRM As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gridEtiket As System.Windows.Forms.DataGridView
    Friend WithEvents DTPTanggalResep As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtNotaResep As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewImageColumn
End Class
