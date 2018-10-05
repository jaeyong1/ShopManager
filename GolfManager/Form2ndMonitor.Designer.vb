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
        CType(Me.picboxBottomBanner, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblTopBannerText
        '
        Me.lblTopBannerText.Font = New System.Drawing.Font("Gulim", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTopBannerText.ForeColor = System.Drawing.Color.White
        Me.lblTopBannerText.Location = New System.Drawing.Point(0, 0)
        Me.lblTopBannerText.Name = "lblTopBannerText"
        Me.lblTopBannerText.Size = New System.Drawing.Size(573, 34)
        Me.lblTopBannerText.TabIndex = 0
        Me.lblTopBannerText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 5000
        '
        'picboxBottomBanner
        '
        Me.picboxBottomBanner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picboxBottomBanner.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.picboxBottomBanner.Location = New System.Drawing.Point(0, 578)
        Me.picboxBottomBanner.Margin = New System.Windows.Forms.Padding(0)
        Me.picboxBottomBanner.Name = "picboxBottomBanner"
        Me.picboxBottomBanner.Size = New System.Drawing.Size(1032, 54)
        Me.picboxBottomBanner.TabIndex = 1
        Me.picboxBottomBanner.TabStop = False
        '
        'Form2ndMonitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(46, Byte), Integer))
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
End Class
