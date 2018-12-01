<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3Lockscreen
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
        Me.lblTopLockScreenText = New System.Windows.Forms.Label()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblTopLockScreenText
        '
        Me.lblTopLockScreenText.BackColor = System.Drawing.Color.Transparent
        Me.lblTopLockScreenText.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblTopLockScreenText.Font = New System.Drawing.Font("Gulim", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lblTopLockScreenText.ForeColor = System.Drawing.Color.White
        Me.lblTopLockScreenText.Location = New System.Drawing.Point(0, 0)
        Me.lblTopLockScreenText.Name = "lblTopLockScreenText"
        Me.lblTopLockScreenText.Size = New System.Drawing.Size(1123, 362)
        Me.lblTopLockScreenText.TabIndex = 1
        Me.lblTopLockScreenText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRefresh
        '
        Me.btnRefresh.Location = New System.Drawing.Point(6, 12)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(63, 30)
        Me.btnRefresh.TabIndex = 2
        Me.btnRefresh.Text = "재확인"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(6, 0)
        Me.ProgressBar1.Maximum = 62
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(258, 10)
        Me.ProgressBar1.TabIndex = 3
        Me.ProgressBar1.Value = 30
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form3Lockscreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(46, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1123, 514)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.lblTopLockScreenText)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form3Lockscreen"
        Me.Opacity = 0.9R
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lblTopLockScreenText As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Timer1 As Timer
End Class
