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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnApplyUISetting = New System.Windows.Forms.Button()
        Me.btnBoxDefaultPosition = New System.Windows.Forms.Button()
        Me.btnUISettingLoad = New System.Windows.Forms.Button()
        Me.btnUISettingSave = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtBoxHeight = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtBoxWidth = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTopicBoxGap = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtContentFontSize = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtTitleFontSize = New System.Windows.Forms.TextBox()
        Me.lblRooms = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
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
        Me.btn2ndScrDragEnable.Text = "타석화면설정"
        Me.btn2ndScrDragEnable.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnApplyUISetting)
        Me.GroupBox1.Controls.Add(Me.btnBoxDefaultPosition)
        Me.GroupBox1.Controls.Add(Me.btnUISettingLoad)
        Me.GroupBox1.Controls.Add(Me.btnUISettingSave)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.txtBoxHeight)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtBoxWidth)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtTopicBoxGap)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtContentFontSize)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtTitleFontSize)
        Me.GroupBox1.Controls.Add(Me.lblRooms)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Font = New System.Drawing.Font("NanumGothic", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(182, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(510, 130)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " 타석표시 화면설정 "
        '
        'btnApplyUISetting
        '
        Me.btnApplyUISetting.Location = New System.Drawing.Point(326, 52)
        Me.btnApplyUISetting.Name = "btnApplyUISetting"
        Me.btnApplyUISetting.Size = New System.Drawing.Size(137, 23)
        Me.btnApplyUISetting.TabIndex = 19
        Me.btnApplyUISetting.Text = "타석화면에 적용"
        Me.btnApplyUISetting.UseVisualStyleBackColor = True
        '
        'btnBoxDefaultPosition
        '
        Me.btnBoxDefaultPosition.Location = New System.Drawing.Point(162, 21)
        Me.btnBoxDefaultPosition.Name = "btnBoxDefaultPosition"
        Me.btnBoxDefaultPosition.Size = New System.Drawing.Size(94, 23)
        Me.btnBoxDefaultPosition.TabIndex = 18
        Me.btnBoxDefaultPosition.Text = "임의배치"
        Me.btnBoxDefaultPosition.UseVisualStyleBackColor = True
        '
        'btnUISettingLoad
        '
        Me.btnUISettingLoad.Location = New System.Drawing.Point(369, 21)
        Me.btnUISettingLoad.Name = "btnUISettingLoad"
        Me.btnUISettingLoad.Size = New System.Drawing.Size(94, 23)
        Me.btnUISettingLoad.TabIndex = 15
        Me.btnUISettingLoad.Text = "불러오기"
        Me.btnUISettingLoad.UseVisualStyleBackColor = True
        '
        'btnUISettingSave
        '
        Me.btnUISettingSave.Location = New System.Drawing.Point(269, 21)
        Me.btnUISettingSave.Name = "btnUISettingSave"
        Me.btnUISettingSave.Size = New System.Drawing.Size(94, 23)
        Me.btnUISettingSave.TabIndex = 14
        Me.btnUISettingSave.Text = "현재화면 저장"
        Me.btnUISettingSave.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(432, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(22, 15)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "px"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(311, 84)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "박스세로 : "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(280, 84)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(22, 15)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "px"
        '
        'txtBoxHeight
        '
        Me.txtBoxHeight.Location = New System.Drawing.Point(382, 80)
        Me.txtBoxHeight.Name = "txtBoxHeight"
        Me.txtBoxHeight.Size = New System.Drawing.Size(48, 22)
        Me.txtBoxHeight.TabIndex = 10
        Me.txtBoxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(159, 84)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "박스가로 : "
        '
        'txtBoxWidth
        '
        Me.txtBoxWidth.Location = New System.Drawing.Point(230, 80)
        Me.txtBoxWidth.Name = "txtBoxWidth"
        Me.txtBoxWidth.Size = New System.Drawing.Size(48, 22)
        Me.txtBoxWidth.TabIndex = 8
        Me.txtBoxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(123, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(19, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "개"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(159, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "제목박스간격 : "
        '
        'txtTopicBoxGap
        '
        Me.txtTopicBoxGap.Location = New System.Drawing.Point(254, 53)
        Me.txtTopicBoxGap.Name = "txtTopicBoxGap"
        Me.txtTopicBoxGap.Size = New System.Drawing.Size(48, 22)
        Me.txtTopicBoxGap.TabIndex = 6
        Me.txtTopicBoxGap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(419, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "* 설정창이 활성화 되면 타석관리창에서 드래그로 위치를 바꿀 수 있습니다. "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 15)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "내용글씨크기 : "
        '
        'txtContentFontSize
        '
        Me.txtContentFontSize.Location = New System.Drawing.Point(103, 80)
        Me.txtContentFontSize.Name = "txtContentFontSize"
        Me.txtContentFontSize.Size = New System.Drawing.Size(48, 22)
        Me.txtContentFontSize.TabIndex = 4
        Me.txtContentFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "제목글씨크기 : "
        '
        'txtTitleFontSize
        '
        Me.txtTitleFontSize.Location = New System.Drawing.Point(103, 52)
        Me.txtTitleFontSize.Name = "txtTitleFontSize"
        Me.txtTitleFontSize.Size = New System.Drawing.Size(48, 22)
        Me.txtTitleFontSize.TabIndex = 2
        Me.txtTitleFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblRooms
        '
        Me.lblRooms.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRooms.Location = New System.Drawing.Point(83, 21)
        Me.lblRooms.Name = "lblRooms"
        Me.lblRooms.Size = New System.Drawing.Size(38, 23)
        Me.lblRooms.TabIndex = 1
        Me.lblRooms.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "타석개수 : "
        '
        'UserControl_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn2ndScrDragEnable)
        Me.Font = New System.Drawing.Font("NanumGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "UserControl_Settings"
        Me.Size = New System.Drawing.Size(1276, 692)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn2ndScrDragEnable As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBoxDefaultPosition As Button
    Friend WithEvents btnUISettingLoad As Button
    Friend WithEvents btnUISettingSave As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtBoxHeight As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtBoxWidth As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtTopicBoxGap As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtContentFontSize As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtTitleFontSize As TextBox
    Friend WithEvents lblRooms As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnApplyUISetting As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents Label2 As Label
End Class
