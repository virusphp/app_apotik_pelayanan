<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDaftarPermintaanResep
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDaftarPermintaanResep))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gpSearch = New System.Windows.Forms.GroupBox()
        Me.txtPencarian = New System.Windows.Forms.TextBox()
        Me.groupTanggal = New System.Windows.Forms.GroupBox()
        Me.DTPTanggal1 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTPTanggal2 = New System.Windows.Forms.DateTimePicker()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.DTPTanggal1x = New System.Windows.Forms.DateTimePicker()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.DTPTanggal2x = New System.Windows.Forms.DateTimePicker()
        Me.btnBaruTab5 = New System.Windows.Forms.Button()
        Me.btnProsesTab5 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.gridPermintaanObat = New System.Windows.Forms.DataGridView()
        Me.Column3 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.GroupBox1.SuspendLayout()
        Me.gpSearch.SuspendLayout()
        Me.groupTanggal.SuspendLayout()
        CType(Me.gridPermintaanObat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gpSearch)
        Me.GroupBox1.Controls.Add(Me.groupTanggal)
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.DTPTanggal1x)
        Me.GroupBox1.Controls.Add(Me.btnKeluar)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.DTPTanggal2x)
        Me.GroupBox1.Controls.Add(Me.btnBaruTab5)
        Me.GroupBox1.Controls.Add(Me.btnProsesTab5)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1169, 67)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'gpSearch
        '
        Me.gpSearch.Controls.Add(Me.txtPencarian)
        Me.gpSearch.Location = New System.Drawing.Point(304, 9)
        Me.gpSearch.Name = "gpSearch"
        Me.gpSearch.Size = New System.Drawing.Size(165, 47)
        Me.gpSearch.TabIndex = 35
        Me.gpSearch.TabStop = False
        Me.gpSearch.Text = "Pencarian"
        '
        'txtPencarian
        '
        Me.txtPencarian.Location = New System.Drawing.Point(6, 19)
        Me.txtPencarian.Name = "txtPencarian"
        Me.txtPencarian.Size = New System.Drawing.Size(150, 20)
        Me.txtPencarian.TabIndex = 34
        '
        'groupTanggal
        '
        Me.groupTanggal.Controls.Add(Me.DTPTanggal1)
        Me.groupTanggal.Controls.Add(Me.Label1)
        Me.groupTanggal.Controls.Add(Me.DTPTanggal2)
        Me.groupTanggal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.groupTanggal.Location = New System.Drawing.Point(12, 9)
        Me.groupTanggal.Name = "groupTanggal"
        Me.groupTanggal.Size = New System.Drawing.Size(286, 49)
        Me.groupTanggal.TabIndex = 34
        Me.groupTanggal.TabStop = False
        Me.groupTanggal.Text = "Tanggal"
        '
        'DTPTanggal1
        '
        Me.DTPTanggal1.CustomFormat = ""
        Me.DTPTanggal1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPTanggal1.Location = New System.Drawing.Point(6, 20)
        Me.DTPTanggal1.Name = "DTPTanggal1"
        Me.DTPTanggal1.Size = New System.Drawing.Size(116, 20)
        Me.DTPTanggal1.TabIndex = 33
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(127, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "S/D"
        '
        'DTPTanggal2
        '
        Me.DTPTanggal2.CustomFormat = "yyyy"
        Me.DTPTanggal2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPTanggal2.Location = New System.Drawing.Point(160, 19)
        Me.DTPTanggal2.Name = "DTPTanggal2"
        Me.DTPTanggal2.Size = New System.Drawing.Size(117, 20)
        Me.DTPTanggal2.TabIndex = 34
        '
        'btnExcel
        '
        Me.btnExcel.Image = CType(resources.GetObject("btnExcel.Image"), System.Drawing.Image)
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(570, 19)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(85, 35)
        Me.btnExcel.TabIndex = 3
        Me.btnExcel.Text = "Ke Excel"
        Me.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'DTPTanggal1x
        '
        Me.DTPTanggal1x.CustomFormat = ""
        Me.DTPTanggal1x.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPTanggal1x.Location = New System.Drawing.Point(15, 29)
        Me.DTPTanggal1x.Name = "DTPTanggal1x"
        Me.DTPTanggal1x.Size = New System.Drawing.Size(116, 20)
        Me.DTPTanggal1x.TabIndex = 0
        '
        'btnKeluar
        '
        Me.btnKeluar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnKeluar.Image = CType(resources.GetObject("btnKeluar.Image"), System.Drawing.Image)
        Me.btnKeluar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnKeluar.Location = New System.Drawing.Point(752, 19)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(85, 35)
        Me.btnKeluar.TabIndex = 5
        Me.btnKeluar.Text = "Keluar"
        Me.btnKeluar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(137, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 13)
        Me.Label17.TabIndex = 32
        Me.Label17.Text = "S/D"
        '
        'DTPTanggal2x
        '
        Me.DTPTanggal2x.CustomFormat = "yyyy"
        Me.DTPTanggal2x.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPTanggal2x.Location = New System.Drawing.Point(170, 29)
        Me.DTPTanggal2x.Name = "DTPTanggal2x"
        Me.DTPTanggal2x.Size = New System.Drawing.Size(117, 20)
        Me.DTPTanggal2x.TabIndex = 1
        '
        'btnBaruTab5
        '
        Me.btnBaruTab5.Image = CType(resources.GetObject("btnBaruTab5.Image"), System.Drawing.Image)
        Me.btnBaruTab5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBaruTab5.Location = New System.Drawing.Point(661, 19)
        Me.btnBaruTab5.Name = "btnBaruTab5"
        Me.btnBaruTab5.Size = New System.Drawing.Size(85, 35)
        Me.btnBaruTab5.TabIndex = 4
        Me.btnBaruTab5.Text = "Baru"
        Me.btnBaruTab5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBaruTab5.UseVisualStyleBackColor = True
        '
        'btnProsesTab5
        '
        Me.btnProsesTab5.Image = CType(resources.GetObject("btnProsesTab5.Image"), System.Drawing.Image)
        Me.btnProsesTab5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnProsesTab5.Location = New System.Drawing.Point(479, 19)
        Me.btnProsesTab5.Name = "btnProsesTab5"
        Me.btnProsesTab5.Size = New System.Drawing.Size(85, 35)
        Me.btnProsesTab5.TabIndex = 2
        Me.btnProsesTab5.Text = "Proses"
        Me.btnProsesTab5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnProsesTab5.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 9)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(46, 13)
        Me.Label19.TabIndex = 27
        Me.Label19.Text = "Tanggal"
        '
        'gridPermintaanObat
        '
        Me.gridPermintaanObat.AllowUserToAddRows = False
        Me.gridPermintaanObat.AllowUserToDeleteRows = False
        Me.gridPermintaanObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridPermintaanObat.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column3})
        Me.gridPermintaanObat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridPermintaanObat.Location = New System.Drawing.Point(0, 67)
        Me.gridPermintaanObat.Name = "gridPermintaanObat"
        Me.gridPermintaanObat.Size = New System.Drawing.Size(1169, 556)
        Me.gridPermintaanObat.TabIndex = 1
        '
        'Column3
        '
        Me.Column3.HeaderText = "Detail"
        Me.Column3.Name = "Column3"
        '
        'FormDaftarPermintaanResep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1169, 623)
        Me.Controls.Add(Me.gridPermintaanObat)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormDaftarPermintaanResep"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daftar Permintaan Resep"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpSearch.ResumeLayout(False)
        Me.gpSearch.PerformLayout()
        Me.groupTanggal.ResumeLayout(False)
        Me.groupTanggal.PerformLayout()
        CType(Me.gridPermintaanObat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gridPermintaanObat As System.Windows.Forms.DataGridView
    Friend WithEvents DTPTanggal1x As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnKeluar As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents DTPTanggal2x As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBaruTab5 As System.Windows.Forms.Button
    Friend WithEvents btnProsesTab5 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents groupTanggal As GroupBox
    Friend WithEvents DTPTanggal1 As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents DTPTanggal2 As DateTimePicker
    Friend WithEvents gpSearch As GroupBox
    Friend WithEvents txtPencarian As TextBox
End Class
