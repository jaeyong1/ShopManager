<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl_Settings
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.btn2ndScrDragEnable = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn2ndScrDragEnable
        '
        Me.btn2ndScrDragEnable.BackColor = System.Drawing.Color.Silver
        Me.btn2ndScrDragEnable.FlatAppearance.BorderSize = 0
        Me.btn2ndScrDragEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2ndScrDragEnable.ForeColor = System.Drawing.Color.White
        Me.btn2ndScrDragEnable.Location = New System.Drawing.Point(34, 38)
        Me.btn2ndScrDragEnable.Name = "btn2ndScrDragEnable"
        Me.btn2ndScrDragEnable.Size = New System.Drawing.Size(142, 130)
        Me.btn2ndScrDragEnable.TabIndex = 0
        Me.btn2ndScrDragEnable.Text = "타석포지션변경"
        Me.btn2ndScrDragEnable.UseVisualStyleBackColor = False
        '
        'UserControl_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Controls.Add(Me.btn2ndScrDragEnable)
        Me.Font = New System.Drawing.Font("NanumGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "UserControl_Settings"
        Me.Size = New System.Drawing.Size(1276, 692)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn2ndScrDragEnable As Button
End Class
