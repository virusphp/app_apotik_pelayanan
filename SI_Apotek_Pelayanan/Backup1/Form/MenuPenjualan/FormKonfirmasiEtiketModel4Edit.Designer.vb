<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKonfirmasiEtiketModel4Edit
    Inherits Syncfusion.Windows.Forms.MetroForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKonfirmasiEtiketModel4Edit))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtJumlahHari = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.Panel1.SuspendLayout()
        CType(Me.txtJumlahHari, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 87)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(362, 42)
        Me.Panel1.TabIndex = 10
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(263, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Ok"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Etiket Model 4 Akan Dicetak Untuk Berapa Hari?"
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Location = New System.Drawing.Point(118, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 20)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Jumlah Hari"
        '
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Location = New System.Drawing.Point(13, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(65, 59)
        Me.Panel2.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(226, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Hari"
        '
        'txtJumlahHari
        '
        Me.txtJumlahHari.BackGroundColor = System.Drawing.SystemColors.Info
        Me.txtJumlahHari.BeforeTouchSize = New System.Drawing.Size(34, 20)
        Me.txtJumlahHari.BorderColor = System.Drawing.Color.DimGray
        Me.txtJumlahHari.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJumlahHari.Culture = New System.Globalization.CultureInfo("en-US")
        Me.txtJumlahHari.CurrencyDecimalDigits = 0
        Me.txtJumlahHari.CurrencySymbol = ""
        Me.txtJumlahHari.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtJumlahHari.DecimalValue = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtJumlahHari.Location = New System.Drawing.Point(193, 42)
        Me.txtJumlahHari.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtJumlahHari.Name = "txtJumlahHari"
        Me.txtJumlahHari.NullString = ""
        Me.txtJumlahHari.Size = New System.Drawing.Size(34, 20)
        Me.txtJumlahHari.SpecialCultureValue = Syncfusion.Windows.Forms.Tools.SpecialCultureValues.None
        Me.txtJumlahHari.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtJumlahHari.TabIndex = 0
        Me.txtJumlahHari.Text = "1"
        Me.txtJumlahHari.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FormKonfirmasiEtiketModel4Edit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 129)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtJumlahHari)
        Me.Name = "FormKonfirmasiEtiketModel4Edit"
        Me.ShowInTaskbar = False
        Me.ShowMaximizeBox = False
        Me.ShowMinimizeBox = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Konfirmasi"
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtJumlahHari, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtJumlahHari As Syncfusion.Windows.Forms.Tools.CurrencyTextBox

End Class
