<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2ndMonitor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblTopBannerText = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.picboxBottomBanner = New System.Windows.Forms.PictureBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.picboxBottomBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTopBannerText
        '
        Me.lblTopBannerText.BackColor = System.Drawing.Color.Transparent
        Me.lblTopBannerText.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTopBannerText.Font = New System.Drawing.Font("Gulim", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTopBannerText.ForeColor = System.Drawing.Color.White
        Me.lblTopBannerText.Location = New System.Drawing.Point(0, 0)
        Me.lblTopBannerText.Name = "lblTopBannerText"
        Me.lblTopBannerText.Size = New System.Drawing.Size(1032, 192)
        Me.lblTopBannerText.TabIndex = 0
        Me.lblTopBannerText.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'picboxBottomBanner
        '
        Me.picboxBottomBanner.BackColor = System.Drawing.Color.Transparent
        Me.picboxBottomBanner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.picboxBottomBanner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.picboxBottomBanner.Location = New System.Drawing.Point(0, 528)
        Me.picboxBottomBanner.Margin = New System.Windows.Forms.Padding(0)
        Me.picboxBottomBanner.Name = "picboxBottomBanner"
        Me.picboxBottomBanner.Size = New System.Drawing.Size(1032, 104)
        Me.picboxBottomBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picboxBottomBanner.TabIndex = 1
        Me.picboxBottomBanner.TabStop = False
        '
        'Timer2
        '
        Me.Timer2.Interval = 7000
        '
        'Form2ndMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1032, 632)
        Me.Controls.Add(Me.picboxBottomBanner)
        Me.Controls.Add(Me.lblTopBannerText)
        Me.Name = "Form2ndMonitor"
        Me.ShowIcon = False
        CType(Me.picboxBottomBanner, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTopBannerText As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents picboxBottomBanner As PictureBox
    Friend WithEvents Timer2 As Timer
End Class
