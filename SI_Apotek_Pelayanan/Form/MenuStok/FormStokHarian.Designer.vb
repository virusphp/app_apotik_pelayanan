<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStokHarian
    Inherits System.Windows.Forms.Form

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
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbUnit = New System.Windows.Forms.ComboBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.txtCariObat = New System.Windows.Forms.TextBox()
        Me.gridBarang = New System.Windows.Forms.DataGridView()
        Me.GroupBox11.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.Button2)
        Me.GroupBox11.Controls.Add(Me.Button1)
        Me.GroupBox11.Controls.Add(Me.Label4)
        Me.GroupBox11.Controls.Add(Me.cmbUnit)
        Me.GroupBox11.Controls.Add(Me.Label33)
        Me.GroupBox11.Controls.Add(Me.txtCariObat)
        Me.GroupBox11.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox11.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(590, 77)
        Me.GroupBox11.TabIndex = 1
        Me.GroupBox11.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(333, 19)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 23)
        Me.Button2.TabIndex = 30
        Me.Button2.Text = "Baru"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(292, 19)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 23)
        Me.Button1.TabIndex = 29
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(33, 13)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "Depo"
        '
        'cmbUnit
        '
        Me.cmbUnit.FormattingEnabled = True
        Me.cmbUnit.Location = New System.Drawing.Point(74, 20)
        Me.cmbUnit.Name = "cmbUnit"
        Me.cmbUnit.Size = New System.Drawing.Size(214, 21)
        Me.cmbUnit.TabIndex = 27
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(12, 49)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(62, 13)
        Me.Label33.TabIndex = 12
        Me.Label33.Text = "Cari Barang"
        '
        'txtCariObat
        '
        Me.txtCariObat.Location = New System.Drawing.Point(74, 46)
        Me.txtCariObat.Name = "txtCariObat"
        Me.txtCariObat.Size = New System.Drawing.Size(493, 20)
        Me.txtCariObat.TabIndex = 10
        '
        'gridBarang
        '
        Me.gridBarang.AllowUserToAddRows = False
        Me.gridBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBarang.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridBarang.Location = New System.Drawing.Point(0, 77)
        Me.gridBarang.Name = "gridBarang"
        Me.gridBarang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.gridBarang.Size = New System.Drawing.Size(590, 372)
        Me.gridBarang.TabIndex = 2
        '
        'FormStokHarian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(590, 449)
        Me.Controls.Add(Me.gridBarang)
        Me.Controls.Add(Me.GroupBox11)
        Me.Name = "FormStokHarian"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stok Harian"
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents txtCariObat As System.Windows.Forms.TextBox
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbUnit As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
