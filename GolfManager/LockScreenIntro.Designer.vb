﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LockScreenIntro
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(25, 227)
        Me.ProgressBar1.Maximum = 30
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(338, 22)
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.Value = 30
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Gulim", 20.0!)
        Me.Button1.Location = New System.Drawing.Point(25, 132)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(338, 89)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "타석용 프로그램 취소"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Label1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(120, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 12)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Label1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Label3"
        '
        'LockScreenIntro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(397, 261)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "LockScreenIntro"
        Me.Text = "타석용 프로그램으로 자동전환"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
