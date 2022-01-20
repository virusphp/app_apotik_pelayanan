<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInfoResepObat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInfoResepObat))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtJmlObat = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtNamaObat = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtNamaPasien = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtRM = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gridResep = New System.Windows.Forms.DataGridView()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txtJmlObat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaObat, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaPasien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtRM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridResep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtJmlObat)
        Me.GroupBox1.Controls.Add(Me.Label4)
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
        Me.GroupBox1.Size = New System.Drawing.Size(690, 91)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'txtJmlObat
        '
        Me.txtJmlObat.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtJmlObat.BeforeTouchSize = New System.Drawing.Size(55, 20)
        Me.txtJmlObat.BorderColor = System.Drawing.Color.DimGray
        Me.txtJmlObat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJmlObat.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJmlObat.CurrencySymbol = ""
        Me.txtJmlObat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJmlObat.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJmlObat.Location = New System.Drawing.Point(627, 58)
        Me.txtJmlObat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJmlObat.Name = "txtJmlObat"
        Me.txtJmlObat.NullString = ""
        Me.txtJmlObat.Size = New System.Drawing.Size(55, 20)
        Me.txtJmlObat.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJmlObat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJmlObat.TabIndex = 92
        Me.txtJmlObat.Text = "0.00"
        Me.txtJmlObat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(554, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 20)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Jumlah Obat"
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(33, 23)
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(651, 12)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(33, 23)
        Me.ButtonAdv1.TabIndex = 7
        '
        'txtNamaObat
        '
        Me.txtNamaObat.BackColor = System.Drawing.SystemColors.Info
        Me.txtNamaObat.BeforeTouchSize = New System.Drawing.Size(55, 20)
        Me.txtNamaObat.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNamaObat.Location = New System.Drawing.Point(114, 58)
        Me.txtNamaObat.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNamaObat.Name = "txtNamaObat"
        Me.txtNamaObat.Size = New System.Drawing.Size(259, 20)
        Me.txtNamaObat.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNamaObat.TabIndex = 5
        '
        'txtNamaPasien
        '
        Me.txtNamaPasien.BeforeTouchSize = New System.Drawing.Size(55, 20)
        Me.txtNamaPasien.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtNamaPasien.Enabled = False
        Me.txtNamaPasien.Location = New System.Drawing.Point(114, 37)
        Me.txtNamaPasien.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtNamaPasien.Name = "txtNamaPasien"
        Me.txtNamaPasien.Size = New System.Drawing.Size(259, 20)
        Me.txtNamaPasien.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtNamaPasien.TabIndex = 4
        '
        'txtRM
        '
        Me.txtRM.BeforeTouchSize = New System.Drawing.Size(55, 20)
        Me.txtRM.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtRM.Enabled = False
        Me.txtRM.Location = New System.Drawing.Point(114, 16)
        Me.txtRM.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtRM.Name = "txtRM"
        Me.txtRM.Size = New System.Drawing.Size(100, 20)
        Me.txtRM.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtRM.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(12, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 20)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Cari Obat"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 20)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Pasien"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No RM"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridResep)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 91)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(690, 295)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'gridResep
        '
        Me.gridResep.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridResep.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridResep.Location = New System.Drawing.Point(3, 16)
        Me.gridResep.Name = "gridResep"
        Me.gridResep.Size = New System.Drawing.Size(684, 276)
        Me.gridResep.TabIndex = 0
        '
        'FormInfoResepObat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(690, 386)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormInfoResepObat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Info Obat"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txtJmlObat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaObat, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaPasien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtRM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gridResep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtNamaObat As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtNamaPasien As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtRM As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gridResep As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtJmlObat As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class
