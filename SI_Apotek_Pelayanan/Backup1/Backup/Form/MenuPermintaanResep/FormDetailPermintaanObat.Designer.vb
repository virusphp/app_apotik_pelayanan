<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDetailPermintaanObat
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.gridObatJadi = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.gridObatRacikan = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNoPermintaan = New System.Windows.Forms.TextBox()
        Me.txtRM = New System.Windows.Forms.TextBox()
        Me.txtNamaPasien = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridObatJadi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.gridObatRacikan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtNamaPasien)
        Me.GroupBox1.Controls.Add(Me.txtRM)
        Me.GroupBox1.Controls.Add(Me.txtNoPermintaan)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1200, 93)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(1200, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "OBAT JADI"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridObatJadi)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 114)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1200, 204)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'gridObatJadi
        '
        Me.gridObatJadi.AllowUserToAddRows = False
        Me.gridObatJadi.AllowUserToDeleteRows = False
        Me.gridObatJadi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridObatJadi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridObatJadi.Location = New System.Drawing.Point(3, 16)
        Me.gridObatJadi.Name = "gridObatJadi"
        Me.gridObatJadi.Size = New System.Drawing.Size(1194, 185)
        Me.gridObatJadi.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 318)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(1200, 21)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "OBAT RACIKAN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gridObatRacikan)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 339)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1200, 227)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'gridObatRacikan
        '
        Me.gridObatRacikan.AllowUserToAddRows = False
        Me.gridObatRacikan.AllowUserToDeleteRows = False
        Me.gridObatRacikan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridObatRacikan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridObatRacikan.Location = New System.Drawing.Point(3, 16)
        Me.gridObatRacikan.Name = "gridObatRacikan"
        Me.gridObatRacikan.Size = New System.Drawing.Size(1194, 208)
        Me.gridObatRacikan.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "No Permintaan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "No RM"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Nama Pasien"
        '
        'txtNoPermintaan
        '
        Me.txtNoPermintaan.Enabled = False
        Me.txtNoPermintaan.Location = New System.Drawing.Point(100, 12)
        Me.txtNoPermintaan.Name = "txtNoPermintaan"
        Me.txtNoPermintaan.Size = New System.Drawing.Size(218, 20)
        Me.txtNoPermintaan.TabIndex = 3
        '
        'txtRM
        '
        Me.txtRM.Enabled = False
        Me.txtRM.Location = New System.Drawing.Point(100, 35)
        Me.txtRM.Name = "txtRM"
        Me.txtRM.Size = New System.Drawing.Size(218, 20)
        Me.txtRM.TabIndex = 4
        '
        'txtNamaPasien
        '
        Me.txtNamaPasien.Enabled = False
        Me.txtNamaPasien.Location = New System.Drawing.Point(100, 58)
        Me.txtNamaPasien.Name = "txtNamaPasien"
        Me.txtNamaPasien.Size = New System.Drawing.Size(218, 20)
        Me.txtNamaPasien.TabIndex = 5
        '
        'FormDetailPermintaanObat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(1200, 566)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormDetailPermintaanObat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detail Permintaan Obat"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gridObatJadi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.gridObatRacikan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents gridObatJadi As System.Windows.Forms.DataGridView
    Friend WithEvents gridObatRacikan As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNamaPasien As System.Windows.Forms.TextBox
    Friend WithEvents txtRM As System.Windows.Forms.TextBox
    Friend WithEvents txtNoPermintaan As System.Windows.Forms.TextBox
End Class
