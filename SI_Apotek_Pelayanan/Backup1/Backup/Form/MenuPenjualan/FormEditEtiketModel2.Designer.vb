<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEditEtiketModel2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormEditEtiketModel2))
        Me.PanelEtiketInfus = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTetesInfus = New System.Windows.Forms.TextBox()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.txtObatInfus = New System.Windows.Forms.TextBox()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.txtJumlahObatEtiketInfus = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.txtNamaObatEtiketInfus = New System.Windows.Forms.TextBox()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.PanelEtiketInfus.SuspendLayout()
        CType(Me.txtJumlahObatEtiketInfus, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelEtiketInfus
        '
        Me.PanelEtiketInfus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelEtiketInfus.Controls.Add(Me.Button1)
        Me.PanelEtiketInfus.Controls.Add(Me.Label1)
        Me.PanelEtiketInfus.Controls.Add(Me.txtTetesInfus)
        Me.PanelEtiketInfus.Controls.Add(Me.Label64)
        Me.PanelEtiketInfus.Controls.Add(Me.txtObatInfus)
        Me.PanelEtiketInfus.Controls.Add(Me.Label63)
        Me.PanelEtiketInfus.Controls.Add(Me.Label65)
        Me.PanelEtiketInfus.Controls.Add(Me.txtJumlahObatEtiketInfus)
        Me.PanelEtiketInfus.Controls.Add(Me.txtNamaObatEtiketInfus)
        Me.PanelEtiketInfus.Controls.Add(Me.Label66)
        Me.PanelEtiketInfus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelEtiketInfus.Location = New System.Drawing.Point(0, 0)
        Me.PanelEtiketInfus.Name = "PanelEtiketInfus"
        Me.PanelEtiketInfus.Size = New System.Drawing.Size(282, 143)
        Me.PanelEtiketInfus.TabIndex = 19
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(192, 106)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 111
        Me.Button1.Text = "Simpan"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "Obat"
        '
        'txtTetesInfus
        '
        Me.txtTetesInfus.Location = New System.Drawing.Point(84, 80)
        Me.txtTetesInfus.Name = "txtTetesInfus"
        Me.txtTetesInfus.Size = New System.Drawing.Size(183, 20)
        Me.txtTetesInfus.TabIndex = 108
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(13, 83)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(65, 13)
        Me.Label64.TabIndex = 109
        Me.Label64.Text = "Tetes/Menit"
        '
        'txtObatInfus
        '
        Me.txtObatInfus.Location = New System.Drawing.Point(84, 57)
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
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(13, 37)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(66, 13)
        Me.Label65.TabIndex = 100
        Me.Label65.Text = "Jumlah Obat"
        '
        'txtJumlahObatEtiketInfus
        '
        Me.txtJumlahObatEtiketInfus.BackGroundColor = System.Drawing.SystemColors.Window
        Me.txtJumlahObatEtiketInfus.BeforeTouchSize = New System.Drawing.Size(55, 20)
        Me.txtJumlahObatEtiketInfus.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahObatEtiketInfus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahObatEtiketInfus.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahObatEtiketInfus.CurrencySymbol = ""
        Me.txtJumlahObatEtiketInfus.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahObatEtiketInfus.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtJumlahObatEtiketInfus.Location = New System.Drawing.Point(84, 34)
        Me.txtJumlahObatEtiketInfus.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahObatEtiketInfus.Name = "txtJumlahObatEtiketInfus"
        Me.txtJumlahObatEtiketInfus.NullString = ""
        Me.txtJumlahObatEtiketInfus.Size = New System.Drawing.Size(183, 20)
        Me.txtJumlahObatEtiketInfus.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahObatEtiketInfus.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJumlahObatEtiketInfus.TabIndex = 8
        Me.txtJumlahObatEtiketInfus.Text = "0.00"
        '
        'txtNamaObatEtiketInfus
        '
        Me.txtNamaObatEtiketInfus.Location = New System.Drawing.Point(84, 11)
        Me.txtNamaObatEtiketInfus.Name = "txtNamaObatEtiketInfus"
        Me.txtNamaObatEtiketInfus.Size = New System.Drawing.Size(183, 20)
        Me.txtNamaObatEtiketInfus.TabIndex = 7
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(13, 14)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(61, 13)
        Me.Label66.TabIndex = 97
        Me.Label66.Text = "Nama Infus"
        '
        'FormEditEtiketModel2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 143)
        Me.Controls.Add(Me.PanelEtiketInfus)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEditEtiketModel2"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Edit Etiket Model 2"
        Me.PanelEtiketInfus.ResumeLayout(False)
        Me.PanelEtiketInfus.PerformLayout()
        CType(Me.txtJumlahObatEtiketInfus, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelEtiketInfus As System.Windows.Forms.Panel
    Friend WithEvents txtTetesInfus As System.Windows.Forms.TextBox
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents txtObatInfus As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents txtJumlahObatEtiketInfus As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents txtNamaObatEtiketInfus As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
