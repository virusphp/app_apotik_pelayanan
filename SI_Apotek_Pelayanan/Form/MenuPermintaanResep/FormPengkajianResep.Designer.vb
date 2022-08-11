<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPengkajianResep
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPengkajianResep))
        Me.lstPengkajianResep = New System.Windows.Forms.CheckedListBox()
        Me.GradientPanel4 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.GradientPanel1 = New Syncfusion.Windows.Forms.Tools.GradientPanel()
        Me.lblJmlIter = New System.Windows.Forms.Label()
        Me.txtJmlIter = New System.Windows.Forms.TextBox()
        Me.lblIter = New System.Windows.Forms.Label()
        Me.txtIteration = New System.Windows.Forms.TextBox()
        Me.lblTindakan = New System.Windows.Forms.Label()
        Me.rtxtKeterangan = New System.Windows.Forms.RichTextBox()
        Me.cmdBatal = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.cmdSimpan = New Syncfusion.Windows.Forms.ButtonAdv()
        Me.txtNoPermintaanResep = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtNoReg = New System.Windows.Forms.TextBox()
        Me.txtNamaPasien = New System.Windows.Forms.TextBox()
        Me.txtNo_RM = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel4.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GradientPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstPengkajianResep
        '
        Me.lstPengkajianResep.FormattingEnabled = True
        Me.lstPengkajianResep.Location = New System.Drawing.Point(6, 73)
        Me.lstPengkajianResep.Name = "lstPengkajianResep"
        Me.lstPengkajianResep.Size = New System.Drawing.Size(394, 304)
        Me.lstPengkajianResep.TabIndex = 803
        '
        'GradientPanel4
        '
        Me.GradientPanel4.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GradientPanel4.BackgroundImage = CType(resources.GetObject("GradientPanel4.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel4.Controls.Add(Me.Label3)
        Me.GradientPanel4.Controls.Add(Me.Label7)
        Me.GradientPanel4.Controls.Add(Me.PictureBox2)
        Me.GradientPanel4.IgnoreThemeBackground = True
        Me.GradientPanel4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GradientPanel4.Location = New System.Drawing.Point(5, 5)
        Me.GradientPanel4.Name = "GradientPanel4"
        Me.GradientPanel4.Size = New System.Drawing.Size(404, 64)
        Me.GradientPanel4.TabIndex = 804
        Me.GradientPanel4.ThemesEnabled = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(73, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(226, 15)
        Me.Label3.TabIndex = 97
        Me.Label3.Text = "Menu ini digunakan untuk mengkaji permintaan resep"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(71, -2)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(167, 25)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Pengkajian Resep"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Location = New System.Drawing.Point(6, 2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 57)
        Me.PictureBox2.TabIndex = 95
        Me.PictureBox2.TabStop = False
        '
        'GradientPanel1
        '
        Me.GradientPanel1.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.GradientPanel1.BackgroundImage = CType(resources.GetObject("GradientPanel1.BackgroundImage"), System.Drawing.Image)
        Me.GradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.GradientPanel1.Controls.Add(Me.lblJmlIter)
        Me.GradientPanel1.Controls.Add(Me.txtJmlIter)
        Me.GradientPanel1.Controls.Add(Me.lblIter)
        Me.GradientPanel1.Controls.Add(Me.txtIteration)
        Me.GradientPanel1.Controls.Add(Me.lblTindakan)
        Me.GradientPanel1.Controls.Add(Me.rtxtKeterangan)
        Me.GradientPanel1.Controls.Add(Me.cmdBatal)
        Me.GradientPanel1.Controls.Add(Me.cmdSimpan)
        Me.GradientPanel1.Controls.Add(Me.txtNoPermintaanResep)
        Me.GradientPanel1.Controls.Add(Me.Label1)
        Me.GradientPanel1.Controls.Add(Me.Label5)
        Me.GradientPanel1.Controls.Add(Me.txtNoReg)
        Me.GradientPanel1.Controls.Add(Me.txtNamaPasien)
        Me.GradientPanel1.Controls.Add(Me.txtNo_RM)
        Me.GradientPanel1.Controls.Add(Me.Label2)
        Me.GradientPanel1.Controls.Add(Me.Label4)
        Me.GradientPanel1.Controls.Add(Me.lstPengkajianResep)
        Me.GradientPanel1.IgnoreThemeBackground = True
        Me.GradientPanel1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GradientPanel1.Location = New System.Drawing.Point(5, 71)
        Me.GradientPanel1.Name = "GradientPanel1"
        Me.GradientPanel1.Size = New System.Drawing.Size(404, 492)
        Me.GradientPanel1.TabIndex = 805
        Me.GradientPanel1.ThemesEnabled = True
        '
        'lblJmlIter
        '
        Me.lblJmlIter.AutoSize = True
        Me.lblJmlIter.BackColor = System.Drawing.Color.Transparent
        Me.lblJmlIter.Location = New System.Drawing.Point(311, 31)
        Me.lblJmlIter.Name = "lblJmlIter"
        Me.lblJmlIter.Size = New System.Drawing.Size(22, 13)
        Me.lblJmlIter.TabIndex = 819
        Me.lblJmlIter.Text = "Jml"
        '
        'txtJmlIter
        '
        Me.txtJmlIter.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtJmlIter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtJmlIter.Location = New System.Drawing.Point(361, 29)
        Me.txtJmlIter.Name = "txtJmlIter"
        Me.txtJmlIter.ReadOnly = True
        Me.txtJmlIter.Size = New System.Drawing.Size(38, 20)
        Me.txtJmlIter.TabIndex = 818
        Me.txtJmlIter.TabStop = False
        '
        'lblIter
        '
        Me.lblIter.AutoSize = True
        Me.lblIter.BackColor = System.Drawing.Color.Transparent
        Me.lblIter.Location = New System.Drawing.Point(309, 9)
        Me.lblIter.Name = "lblIter"
        Me.lblIter.Size = New System.Drawing.Size(45, 13)
        Me.lblIter.TabIndex = 817
        Me.lblIter.Text = "Iteration"
        '
        'txtIteration
        '
        Me.txtIteration.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtIteration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtIteration.Location = New System.Drawing.Point(361, 6)
        Me.txtIteration.Name = "txtIteration"
        Me.txtIteration.ReadOnly = True
        Me.txtIteration.Size = New System.Drawing.Size(38, 20)
        Me.txtIteration.TabIndex = 816
        Me.txtIteration.TabStop = False
        '
        'lblTindakan
        '
        Me.lblTindakan.AutoSize = True
        Me.lblTindakan.Location = New System.Drawing.Point(9, 380)
        Me.lblTindakan.Name = "lblTindakan"
        Me.lblTindakan.Size = New System.Drawing.Size(132, 13)
        Me.lblTindakan.TabIndex = 815
        Me.lblTindakan.Text = "Keterangan/Tindak Lanjut"
        '
        'rtxtKeterangan
        '
        Me.rtxtKeterangan.Location = New System.Drawing.Point(6, 395)
        Me.rtxtKeterangan.Name = "rtxtKeterangan"
        Me.rtxtKeterangan.Size = New System.Drawing.Size(388, 46)
        Me.rtxtKeterangan.TabIndex = 814
        Me.rtxtKeterangan.Text = ""
        '
        'cmdBatal
        '
        Me.cmdBatal.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007
        Me.cmdBatal.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cmdBatal.BeforeTouchSize = New System.Drawing.Size(121, 37)
        Me.cmdBatal.Image = CType(resources.GetObject("cmdBatal.Image"), System.Drawing.Image)
        Me.cmdBatal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBatal.IsBackStageButton = False
        Me.cmdBatal.Location = New System.Drawing.Point(278, 445)
        Me.cmdBatal.Name = "cmdBatal"
        Me.cmdBatal.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cmdBatal.Size = New System.Drawing.Size(121, 37)
        Me.cmdBatal.TabIndex = 813
        Me.cmdBatal.Text = "Batal"
        Me.cmdBatal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdBatal.UseVisualStyle = True
        '
        'cmdSimpan
        '
        Me.cmdSimpan.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007
        Me.cmdSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(22, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.cmdSimpan.BeforeTouchSize = New System.Drawing.Size(121, 37)
        Me.cmdSimpan.Image = CType(resources.GetObject("cmdSimpan.Image"), System.Drawing.Image)
        Me.cmdSimpan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSimpan.IsBackStageButton = False
        Me.cmdSimpan.Location = New System.Drawing.Point(6, 447)
        Me.cmdSimpan.Name = "cmdSimpan"
        Me.cmdSimpan.Office2010ColorScheme = Syncfusion.Windows.Forms.Office2010Theme.Black
        Me.cmdSimpan.Size = New System.Drawing.Size(121, 37)
        Me.cmdSimpan.TabIndex = 812
        Me.cmdSimpan.Text = "Simpan"
        Me.cmdSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdSimpan.UseVisualStyle = True
        '
        'txtNoPermintaanResep
        '
        Me.txtNoPermintaanResep.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtNoPermintaanResep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoPermintaanResep.Location = New System.Drawing.Point(107, 6)
        Me.txtNoPermintaanResep.Name = "txtNoPermintaanResep"
        Me.txtNoPermintaanResep.ReadOnly = True
        Me.txtNoPermintaanResep.Size = New System.Drawing.Size(198, 20)
        Me.txtNoPermintaanResep.TabIndex = 811
        Me.txtNoPermintaanResep.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(7, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 810
        Me.Label1.Text = "No Resep"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(168, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 13)
        Me.Label5.TabIndex = 809
        Me.Label5.Text = "No Reg"
        '
        'txtNoReg
        '
        Me.txtNoReg.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtNoReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNoReg.Location = New System.Drawing.Point(214, 29)
        Me.txtNoReg.Name = "txtNoReg"
        Me.txtNoReg.ReadOnly = True
        Me.txtNoReg.Size = New System.Drawing.Size(91, 20)
        Me.txtNoReg.TabIndex = 808
        Me.txtNoReg.TabStop = False
        '
        'txtNamaPasien
        '
        Me.txtNamaPasien.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtNamaPasien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNamaPasien.Location = New System.Drawing.Point(107, 51)
        Me.txtNamaPasien.Name = "txtNamaPasien"
        Me.txtNamaPasien.ReadOnly = True
        Me.txtNamaPasien.Size = New System.Drawing.Size(293, 20)
        Me.txtNamaPasien.TabIndex = 807
        Me.txtNamaPasien.TabStop = False
        '
        'txtNo_RM
        '
        Me.txtNo_RM.BackColor = System.Drawing.Color.LemonChiffon
        Me.txtNo_RM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNo_RM.Location = New System.Drawing.Point(107, 29)
        Me.txtNo_RM.Name = "txtNo_RM"
        Me.txtNo_RM.ReadOnly = True
        Me.txtNo_RM.Size = New System.Drawing.Size(60, 20)
        Me.txtNo_RM.TabIndex = 806
        Me.txtNo_RM.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(7, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 804
        Me.Label2.Text = "No RM"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(7, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 805
        Me.Label4.Text = "Nama Pasien"
        '
        'FormPengkajianResep
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(412, 568)
        Me.Controls.Add(Me.GradientPanel4)
        Me.Controls.Add(Me.GradientPanel1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPengkajianResep"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form Pengkajian Resep"
        CType(Me.GradientPanel4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel4.ResumeLayout(False)
        Me.GradientPanel4.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GradientPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GradientPanel1.ResumeLayout(False)
        Me.GradientPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Public WithEvents lstPengkajianResep As CheckedListBox
    Friend WithEvents GradientPanel4 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents GradientPanel1 As Syncfusion.Windows.Forms.Tools.GradientPanel
    Public WithEvents txtNoPermintaanResep As TextBox
    Private WithEvents Label1 As Label
    Private WithEvents Label5 As Label
    Public WithEvents txtNoReg As TextBox
    Public WithEvents txtNamaPasien As TextBox
    Public WithEvents txtNo_RM As TextBox
    Private WithEvents Label2 As Label
    Private WithEvents Label4 As Label
    Private WithEvents cmdBatal As Syncfusion.Windows.Forms.ButtonAdv
    Private WithEvents cmdSimpan As Syncfusion.Windows.Forms.ButtonAdv
    Public WithEvents txtJmlIter As TextBox
    Private WithEvents lblIter As Label
    Public WithEvents txtIteration As TextBox
    Friend WithEvents lblTindakan As Label
    Friend WithEvents rtxtKeterangan As RichTextBox
    Private WithEvents lblJmlIter As Label
End Class
