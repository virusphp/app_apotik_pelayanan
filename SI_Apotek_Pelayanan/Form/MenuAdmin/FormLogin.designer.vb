﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLogin))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.LabelNama = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.LabelKode = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.txtUserID = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.txtPassword = New Syncfusion.Windows.Forms.Tools.TextBoxExt()
        Me.ButtonAdv1 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.ButtonAdv2 = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.AutoLabel1 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.AutoLabel3 = New Syncfusion.Windows.Forms.Tools.AutoLabel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblNama = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblDeveloper = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNip = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.LabelNama)
        Me.Panel1.Controls.Add(Me.LabelKode)
        Me.Panel1.Location = New System.Drawing.Point(235, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(114, 129)
        Me.Panel1.TabIndex = 8
        '
        'PictureBox2
        '
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(112, 127)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 10
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(112, 127)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 9
        Me.PictureBox1.TabStop = False
        '
        'LabelNama
        '
        Me.LabelNama.Location = New System.Drawing.Point(-1, 114)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(61, 13)
        Me.LabelNama.TabIndex = 23
        Me.LabelNama.Text = "LabelNama"
        Me.LabelNama.Visible = False
        '
        'LabelKode
        '
        Me.LabelKode.Location = New System.Drawing.Point(3, 82)
        Me.LabelKode.Name = "LabelKode"
        Me.LabelKode.Size = New System.Drawing.Size(58, 13)
        Me.LabelKode.TabIndex = 22
        Me.LabelKode.Text = "LabelKode"
        Me.LabelKode.Visible = False
        '
        'txtUserID
        '
        Me.txtUserID.BeforeTouchSize = New System.Drawing.Size(205, 20)
        Me.txtUserID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUserID.Location = New System.Drawing.Point(94, 14)
        Me.txtUserID.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(205, 20)
        Me.txtUserID.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtUserID.TabIndex = 9
        '
        'txtPassword
        '
        Me.txtPassword.BeforeTouchSize = New System.Drawing.Size(205, 20)
        Me.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtPassword.Location = New System.Drawing.Point(94, 40)
        Me.txtPassword.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(205, 20)
        Me.txtPassword.Style = Syncfusion.Windows.Forms.Tools.TextBoxExt.theme.[Default]
        Me.txtPassword.TabIndex = 11
        '
        'ButtonAdv1
        '
        Me.ButtonAdv1.BeforeTouchSize = New System.Drawing.Size(75, 31)
        Me.ButtonAdv1.Image = CType(resources.GetObject("ButtonAdv1.Image"), System.Drawing.Image)
        Me.ButtonAdv1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv1.IsBackStageButton = False
        Me.ButtonAdv1.Location = New System.Drawing.Point(94, 71)
        Me.ButtonAdv1.Name = "ButtonAdv1"
        Me.ButtonAdv1.Size = New System.Drawing.Size(75, 31)
        Me.ButtonAdv1.TabIndex = 12
        Me.ButtonAdv1.Text = "Ok"
        '
        'ButtonAdv2
        '
        Me.ButtonAdv2.BeforeTouchSize = New System.Drawing.Size(75, 31)
        Me.ButtonAdv2.Image = CType(resources.GetObject("ButtonAdv2.Image"), System.Drawing.Image)
        Me.ButtonAdv2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonAdv2.IsBackStageButton = False
        Me.ButtonAdv2.Location = New System.Drawing.Point(175, 71)
        Me.ButtonAdv2.Name = "ButtonAdv2"
        Me.ButtonAdv2.Size = New System.Drawing.Size(75, 31)
        Me.ButtonAdv2.TabIndex = 13
        Me.ButtonAdv2.Text = "Batal"
        '
        'AutoLabel1
        '
        Me.AutoLabel1.Location = New System.Drawing.Point(18, 16)
        Me.AutoLabel1.Name = "AutoLabel1"
        Me.AutoLabel1.Size = New System.Drawing.Size(43, 13)
        Me.AutoLabel1.TabIndex = 14
        Me.AutoLabel1.Text = "User ID"
        '
        'AutoLabel3
        '
        Me.AutoLabel3.Location = New System.Drawing.Point(18, 42)
        Me.AutoLabel3.Name = "AutoLabel3"
        Me.AutoLabel3.Size = New System.Drawing.Size(53, 13)
        Me.AutoLabel3.TabIndex = 16
        Me.AutoLabel3.Text = "Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 239)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 12)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Versi SI-Apotek1.3/ISN.2021"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.AutoLabel1)
        Me.Panel2.Controls.Add(Me.txtUserID)
        Me.Panel2.Controls.Add(Me.txtPassword)
        Me.Panel2.Controls.Add(Me.ButtonAdv1)
        Me.Panel2.Controls.Add(Me.AutoLabel3)
        Me.Panel2.Controls.Add(Me.ButtonAdv2)
        Me.Panel2.Location = New System.Drawing.Point(235, 147)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(317, 114)
        Me.Panel2.TabIndex = 24
        '
        'lblNama
        '
        Me.lblNama.AutoSize = True
        Me.lblNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNama.Location = New System.Drawing.Point(355, 89)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(13, 16)
        Me.lblNama.TabIndex = 25
        Me.lblNama.Text = "-"
        '
        'Panel3
        '
        Me.Panel3.BackgroundImage = CType(resources.GetObject("Panel3.BackgroundImage"), System.Drawing.Image)
        Me.Panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel3.Location = New System.Drawing.Point(10, 12)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(187, 196)
        Me.Panel3.TabIndex = 26
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 208)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(126, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "SI Apotek Pelayanan"
        '
        'lblDeveloper
        '
        Me.lblDeveloper.AutoSize = True
        Me.lblDeveloper.Location = New System.Drawing.Point(8, 221)
        Me.lblDeveloper.Name = "lblDeveloper"
        Me.lblDeveloper.Size = New System.Drawing.Size(112, 13)
        Me.lblDeveloper.TabIndex = 41
        Me.lblDeveloper.Text = "Smart Solution System"
        Me.lblDeveloper.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(9, 252)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(134, 12)
        Me.Label4.TabIndex = 42
        Me.Label4.Text = "Copyright © 2016 RSUD Kraton"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNip
        '
        Me.lblNip.AutoSize = True
        Me.lblNip.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNip.Location = New System.Drawing.Point(355, 108)
        Me.lblNip.Name = "lblNip"
        Me.lblNip.Size = New System.Drawing.Size(11, 13)
        Me.lblNip.TabIndex = 43
        Me.lblNip.Text = "-"
        '
        'FormLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(574, 276)
        Me.Controls.Add(Me.lblNip)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblDeveloper)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.lblNama)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FormLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Sistem Informasi Pelayanan Apotek"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPassword, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents txtUserID As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents txtPassword As Syncfusion.Windows.Forms.Tools.TextBoxExt
    Friend WithEvents ButtonAdv1 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents ButtonAdv2 As Syncfusion.Windows.Forms.ButtonAdv
    Friend WithEvents AutoLabel1 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents AutoLabel3 As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LabelKode As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents LabelNama As Syncfusion.Windows.Forms.Tools.AutoLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblNama As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblDeveloper As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblNip As System.Windows.Forms.Label

End Class
