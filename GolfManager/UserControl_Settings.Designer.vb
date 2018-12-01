<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl_Settings
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.btn2ndScrDragEnable = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbtnTopbannerColorWhite = New System.Windows.Forms.RadioButton()
        Me.rbtnTopbannerColorBlack = New System.Windows.Forms.RadioButton()
        Me.btnApplyUISetting = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBoxHeight = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbtnTopicWhite = New System.Windows.Forms.RadioButton()
        Me.rbtnTopicBlack = New System.Windows.Forms.RadioButton()
        Me.chkbottomimg = New System.Windows.Forms.CheckBox()
        Me.chkBgimg = New System.Windows.Forms.CheckBox()
        Me.btnBottomBannerPath = New System.Windows.Forms.Button()
        Me.txtBottomImgPath = New System.Windows.Forms.TextBox()
        Me.btnBgimgPath = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBackgroundimgPath = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtTopbanner = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTopbannerFontsize = New System.Windows.Forms.TextBox()
        Me.btnBoxDefaultPosition = New System.Windows.Forms.Button()
        Me.btnUISettingLoad = New System.Windows.Forms.Button()
        Me.btnUISettingSave = New System.Windows.Forms.Button()
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
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnEnableLockScreenFeature = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnLocscreenPreview = New System.Windows.Forms.Button()
        Me.TxtLockScreenComment = New System.Windows.Forms.TextBox()
        Me.btnLockScrnSettingSave = New System.Windows.Forms.Button()
        Me.TxtLockscrMyRoomNumber = New System.Windows.Forms.TextBox()
        Me.CheckBoxEnableLockScreen = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn2ndScrDragEnable
        '
        Me.btn2ndScrDragEnable.BackColor = System.Drawing.Color.Silver
        Me.btn2ndScrDragEnable.FlatAppearance.BorderSize = 0
        Me.btn2ndScrDragEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2ndScrDragEnable.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn2ndScrDragEnable.ForeColor = System.Drawing.Color.White
        Me.btn2ndScrDragEnable.Location = New System.Drawing.Point(34, 38)
        Me.btn2ndScrDragEnable.Name = "btn2ndScrDragEnable"
        Me.btn2ndScrDragEnable.Size = New System.Drawing.Size(142, 130)
        Me.btn2ndScrDragEnable.TabIndex = 0
        Me.btn2ndScrDragEnable.Text = "타석정보화면설정"
        Me.btn2ndScrDragEnable.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.btnApplyUISetting)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtBoxHeight)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.chkbottomimg)
        Me.GroupBox1.Controls.Add(Me.chkBgimg)
        Me.GroupBox1.Controls.Add(Me.btnBottomBannerPath)
        Me.GroupBox1.Controls.Add(Me.txtBottomImgPath)
        Me.GroupBox1.Controls.Add(Me.btnBgimgPath)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtBackgroundimgPath)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtTopbanner)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtTopbannerFontsize)
        Me.GroupBox1.Controls.Add(Me.btnBoxDefaultPosition)
        Me.GroupBox1.Controls.Add(Me.btnUISettingLoad)
        Me.GroupBox1.Controls.Add(Me.btnUISettingSave)
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
        Me.GroupBox1.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(182, 38)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(477, 312)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " 타석표시 화면설정 "
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbtnTopbannerColorWhite)
        Me.Panel2.Controls.Add(Me.rbtnTopbannerColorBlack)
        Me.Panel2.Location = New System.Drawing.Point(181, 229)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(200, 23)
        Me.Panel2.TabIndex = 32
        '
        'rbtnTopbannerColorWhite
        '
        Me.rbtnTopbannerColorWhite.AutoSize = True
        Me.rbtnTopbannerColorWhite.Location = New System.Drawing.Point(5, 3)
        Me.rbtnTopbannerColorWhite.Name = "rbtnTopbannerColorWhite"
        Me.rbtnTopbannerColorWhite.Size = New System.Drawing.Size(53, 16)
        Me.rbtnTopbannerColorWhite.TabIndex = 28
        Me.rbtnTopbannerColorWhite.TabStop = True
        Me.rbtnTopbannerColorWhite.Text = "White"
        Me.rbtnTopbannerColorWhite.UseVisualStyleBackColor = True
        '
        'rbtnTopbannerColorBlack
        '
        Me.rbtnTopbannerColorBlack.AutoSize = True
        Me.rbtnTopbannerColorBlack.Location = New System.Drawing.Point(72, 3)
        Me.rbtnTopbannerColorBlack.Name = "rbtnTopbannerColorBlack"
        Me.rbtnTopbannerColorBlack.Size = New System.Drawing.Size(54, 16)
        Me.rbtnTopbannerColorBlack.TabIndex = 28
        Me.rbtnTopbannerColorBlack.TabStop = True
        Me.rbtnTopbannerColorBlack.Text = "Black"
        Me.rbtnTopbannerColorBlack.UseVisualStyleBackColor = True
        '
        'btnApplyUISetting
        '
        Me.btnApplyUISetting.Location = New System.Drawing.Point(207, 120)
        Me.btnApplyUISetting.Name = "btnApplyUISetting"
        Me.btnApplyUISetting.Size = New System.Drawing.Size(170, 23)
        Me.btnApplyUISetting.TabIndex = 19
        Me.btnApplyUISetting.Text = "설정적용하여 미리보기"
        Me.btnApplyUISetting.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(317, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(89, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "박스세로크기 : "
        '
        'txtBoxHeight
        '
        Me.txtBoxHeight.Location = New System.Drawing.Point(407, 92)
        Me.txtBoxHeight.Name = "txtBoxHeight"
        Me.txtBoxHeight.Size = New System.Drawing.Size(48, 21)
        Me.txtBoxHeight.TabIndex = 10
        Me.txtBoxHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtnTopicWhite)
        Me.Panel1.Controls.Add(Me.rbtnTopicBlack)
        Me.Panel1.Location = New System.Drawing.Point(310, 65)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(154, 29)
        Me.Panel1.TabIndex = 31
        '
        'rbtnTopicWhite
        '
        Me.rbtnTopicWhite.AutoSize = True
        Me.rbtnTopicWhite.Location = New System.Drawing.Point(9, 3)
        Me.rbtnTopicWhite.Name = "rbtnTopicWhite"
        Me.rbtnTopicWhite.Size = New System.Drawing.Size(53, 16)
        Me.rbtnTopicWhite.TabIndex = 29
        Me.rbtnTopicWhite.TabStop = True
        Me.rbtnTopicWhite.Text = "White"
        Me.rbtnTopicWhite.UseVisualStyleBackColor = True
        '
        'rbtnTopicBlack
        '
        Me.rbtnTopicBlack.AutoSize = True
        Me.rbtnTopicBlack.Location = New System.Drawing.Point(76, 3)
        Me.rbtnTopicBlack.Name = "rbtnTopicBlack"
        Me.rbtnTopicBlack.Size = New System.Drawing.Size(54, 16)
        Me.rbtnTopicBlack.TabIndex = 30
        Me.rbtnTopicBlack.TabStop = True
        Me.rbtnTopicBlack.Text = "Black"
        Me.rbtnTopicBlack.UseVisualStyleBackColor = True
        '
        'chkbottomimg
        '
        Me.chkbottomimg.AutoSize = True
        Me.chkbottomimg.Location = New System.Drawing.Point(416, 290)
        Me.chkbottomimg.Name = "chkbottomimg"
        Me.chkbottomimg.Size = New System.Drawing.Size(48, 16)
        Me.chkbottomimg.TabIndex = 27
        Me.chkbottomimg.Text = "사용"
        Me.chkbottomimg.UseVisualStyleBackColor = True
        '
        'chkBgimg
        '
        Me.chkBgimg.AutoSize = True
        Me.chkBgimg.Location = New System.Drawing.Point(416, 258)
        Me.chkBgimg.Name = "chkBgimg"
        Me.chkBgimg.Size = New System.Drawing.Size(48, 16)
        Me.chkBgimg.TabIndex = 26
        Me.chkBgimg.Text = "사용"
        Me.chkBgimg.UseVisualStyleBackColor = True
        '
        'btnBottomBannerPath
        '
        Me.btnBottomBannerPath.Location = New System.Drawing.Point(371, 286)
        Me.btnBottomBannerPath.Name = "btnBottomBannerPath"
        Me.btnBottomBannerPath.Size = New System.Drawing.Size(39, 23)
        Me.btnBottomBannerPath.TabIndex = 25
        Me.btnBottomBannerPath.Text = "..."
        Me.btnBottomBannerPath.UseVisualStyleBackColor = True
        '
        'txtBottomImgPath
        '
        Me.txtBottomImgPath.Enabled = False
        Me.txtBottomImgPath.Location = New System.Drawing.Point(105, 287)
        Me.txtBottomImgPath.Name = "txtBottomImgPath"
        Me.txtBottomImgPath.Size = New System.Drawing.Size(260, 21)
        Me.txtBottomImgPath.TabIndex = 24
        '
        'btnBgimgPath
        '
        Me.btnBgimgPath.Location = New System.Drawing.Point(371, 257)
        Me.btnBgimgPath.Name = "btnBgimgPath"
        Me.btnBgimgPath.Size = New System.Drawing.Size(39, 23)
        Me.btnBgimgPath.TabIndex = 25
        Me.btnBgimgPath.Text = "..."
        Me.btnBgimgPath.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 290)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(89, 12)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "하단배너경로 : "
        '
        'txtBackgroundimgPath
        '
        Me.txtBackgroundimgPath.Enabled = False
        Me.txtBackgroundimgPath.Location = New System.Drawing.Point(105, 258)
        Me.txtBackgroundimgPath.Name = "txtBackgroundimgPath"
        Me.txtBackgroundimgPath.Size = New System.Drawing.Size(260, 21)
        Me.txtBackgroundimgPath.TabIndex = 24
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(10, 261)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 12)
        Me.Label13.TabIndex = 23
        Me.Label13.Text = "배경그림경로 : "
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 161)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 12)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "상단알림문자 : "
        '
        'txtTopbanner
        '
        Me.txtTopbanner.Location = New System.Drawing.Point(105, 158)
        Me.txtTopbanner.Multiline = True
        Me.txtTopbanner.Name = "txtTopbanner"
        Me.txtTopbanner.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTopbanner.Size = New System.Drawing.Size(350, 66)
        Me.txtTopbanner.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 233)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 12)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "상단알림글자크기 : "
        '
        'txtTopbannerFontsize
        '
        Me.txtTopbannerFontsize.Location = New System.Drawing.Point(127, 229)
        Me.txtTopbannerFontsize.Name = "txtTopbannerFontsize"
        Me.txtTopbannerFontsize.Size = New System.Drawing.Size(48, 21)
        Me.txtTopbannerFontsize.TabIndex = 20
        Me.txtTopbannerFontsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnBoxDefaultPosition
        '
        Me.btnBoxDefaultPosition.Location = New System.Drawing.Point(107, 120)
        Me.btnBoxDefaultPosition.Name = "btnBoxDefaultPosition"
        Me.btnBoxDefaultPosition.Size = New System.Drawing.Size(94, 23)
        Me.btnBoxDefaultPosition.TabIndex = 18
        Me.btnBoxDefaultPosition.Text = "임의배치"
        Me.btnBoxDefaultPosition.UseVisualStyleBackColor = True
        '
        'btnUISettingLoad
        '
        Me.btnUISettingLoad.Location = New System.Drawing.Point(260, 20)
        Me.btnUISettingLoad.Name = "btnUISettingLoad"
        Me.btnUISettingLoad.Size = New System.Drawing.Size(94, 23)
        Me.btnUISettingLoad.TabIndex = 15
        Me.btnUISettingLoad.Text = "불러오기"
        Me.btnUISettingLoad.UseVisualStyleBackColor = True
        '
        'btnUISettingSave
        '
        Me.btnUISettingSave.Location = New System.Drawing.Point(160, 20)
        Me.btnUISettingSave.Name = "btnUISettingSave"
        Me.btnUISettingSave.Size = New System.Drawing.Size(94, 23)
        Me.btnUISettingSave.TabIndex = 14
        Me.btnUISettingSave.Text = "현재설정 저장"
        Me.btnUISettingSave.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(165, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 12)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "박스가로크기 : "
        '
        'txtBoxWidth
        '
        Me.txtBoxWidth.Location = New System.Drawing.Point(256, 92)
        Me.txtBoxWidth.Name = "txtBoxWidth"
        Me.txtBoxWidth.Size = New System.Drawing.Size(48, 21)
        Me.txtBoxWidth.TabIndex = 8
        Me.txtBoxWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(123, 25)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(17, 12)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "개"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(165, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 12)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "제목박스간격 : "
        '
        'txtTopicBoxGap
        '
        Me.txtTopicBoxGap.Location = New System.Drawing.Point(256, 65)
        Me.txtTopicBoxGap.Name = "txtTopicBoxGap"
        Me.txtTopicBoxGap.Size = New System.Drawing.Size(48, 21)
        Me.txtTopicBoxGap.TabIndex = 6
        Me.txtTopicBoxGap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(415, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "* 설정창이 활성화 되면 타석관리창에서 드래그로 위치를 바꿀 수 있습니다. "
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "박스글자크기 : "
        '
        'txtContentFontSize
        '
        Me.txtContentFontSize.Location = New System.Drawing.Point(109, 93)
        Me.txtContentFontSize.Name = "txtContentFontSize"
        Me.txtContentFontSize.Size = New System.Drawing.Size(48, 21)
        Me.txtContentFontSize.TabIndex = 4
        Me.txtContentFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 69)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 12)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "제목글자크기 : "
        '
        'txtTitleFontSize
        '
        Me.txtTitleFontSize.Location = New System.Drawing.Point(109, 65)
        Me.txtTitleFontSize.Name = "txtTitleFontSize"
        Me.txtTitleFontSize.Size = New System.Drawing.Size(48, 21)
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
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "타석개수 : "
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnEnableLockScreenFeature
        '
        Me.btnEnableLockScreenFeature.BackColor = System.Drawing.Color.Silver
        Me.btnEnableLockScreenFeature.FlatAppearance.BorderSize = 0
        Me.btnEnableLockScreenFeature.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEnableLockScreenFeature.Font = New System.Drawing.Font("Gulim", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnEnableLockScreenFeature.ForeColor = System.Drawing.Color.White
        Me.btnEnableLockScreenFeature.Location = New System.Drawing.Point(34, 363)
        Me.btnEnableLockScreenFeature.Name = "btnEnableLockScreenFeature"
        Me.btnEnableLockScreenFeature.Size = New System.Drawing.Size(142, 52)
        Me.btnEnableLockScreenFeature.TabIndex = 2
        Me.btnEnableLockScreenFeature.Text = "타석용컴퓨터전환"
        Me.btnEnableLockScreenFeature.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLocscreenPreview)
        Me.GroupBox2.Controls.Add(Me.TxtLockScreenComment)
        Me.GroupBox2.Controls.Add(Me.btnLockScrnSettingSave)
        Me.GroupBox2.Controls.Add(Me.TxtLockscrMyRoomNumber)
        Me.GroupBox2.Controls.Add(Me.CheckBoxEnableLockScreen)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Enabled = False
        Me.GroupBox2.Font = New System.Drawing.Font("Gulim", 9.0!)
        Me.GroupBox2.Location = New System.Drawing.Point(182, 363)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(477, 176)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "타석용 컴퓨터 설정"
        '
        'btnLocscreenPreview
        '
        Me.btnLocscreenPreview.Location = New System.Drawing.Point(362, 94)
        Me.btnLocscreenPreview.Name = "btnLocscreenPreview"
        Me.btnLocscreenPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnLocscreenPreview.TabIndex = 26
        Me.btnLocscreenPreview.Text = "미리보기"
        Me.btnLocscreenPreview.UseVisualStyleBackColor = True
        '
        'TxtLockScreenComment
        '
        Me.TxtLockScreenComment.Location = New System.Drawing.Point(105, 96)
        Me.TxtLockScreenComment.Name = "TxtLockScreenComment"
        Me.TxtLockScreenComment.Size = New System.Drawing.Size(246, 21)
        Me.TxtLockScreenComment.TabIndex = 25
        '
        'btnLockScrnSettingSave
        '
        Me.btnLockScrnSettingSave.Location = New System.Drawing.Point(306, 123)
        Me.btnLockScrnSettingSave.Name = "btnLockScrnSettingSave"
        Me.btnLockScrnSettingSave.Size = New System.Drawing.Size(94, 23)
        Me.btnLockScrnSettingSave.TabIndex = 15
        Me.btnLockScrnSettingSave.Text = "설정저장"
        Me.btnLockScrnSettingSave.UseVisualStyleBackColor = True
        '
        'TxtLockscrMyRoomNumber
        '
        Me.TxtLockscrMyRoomNumber.Location = New System.Drawing.Point(250, 125)
        Me.TxtLockscrMyRoomNumber.Name = "TxtLockscrMyRoomNumber"
        Me.TxtLockscrMyRoomNumber.Size = New System.Drawing.Size(48, 21)
        Me.TxtLockscrMyRoomNumber.TabIndex = 5
        Me.TxtLockscrMyRoomNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBoxEnableLockScreen
        '
        Me.CheckBoxEnableLockScreen.AutoSize = True
        Me.CheckBoxEnableLockScreen.Location = New System.Drawing.Point(8, 128)
        Me.CheckBoxEnableLockScreen.Name = "CheckBoxEnableLockScreen"
        Me.CheckBoxEnableLockScreen.Size = New System.Drawing.Size(136, 16)
        Me.CheckBoxEnableLockScreen.TabIndex = 3
        Me.CheckBoxEnableLockScreen.Text = "타석용컴퓨터로 변경"
        Me.CheckBoxEnableLockScreen.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(7, 20)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(448, 70)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Text = "카운터에서 설정한 사용시간에 따라 현재 컴퓨터의 화면잠금 기능을 제공합니다. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "기능활성화 후 프로그램 재시작시부터 적용됩니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "기능 비활성화는" &
    " 프로그램 시작시 취소할 수 있습니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "미리보기 종료키는 Alt + F4 입니다." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(155, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 12)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "타석번호(숫자) : "
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 99)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 12)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "종료안내문구 : "
        '
        'UserControl_Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnEnableLockScreenFeature)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btn2ndScrDragEnable)
        Me.Font = New System.Drawing.Font("NanumGothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "UserControl_Settings"
        Me.Size = New System.Drawing.Size(1276, 692)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn2ndScrDragEnable As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnBoxDefaultPosition As Button
    Friend WithEvents btnUISettingLoad As Button
    Friend WithEvents btnUISettingSave As Button
    Friend WithEvents Label6 As Label
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
    Friend WithEvents Label12 As Label
    Friend WithEvents txtTopbanner As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtTopbannerFontsize As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnBgimgPath As Button
    Friend WithEvents txtBackgroundimgPath As TextBox
    Friend WithEvents btnBottomBannerPath As Button
    Friend WithEvents txtBottomImgPath As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents chkbottomimg As CheckBox
    Friend WithEvents chkBgimg As CheckBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents rbtnTopbannerColorBlack As RadioButton
    Friend WithEvents rbtnTopbannerColorWhite As RadioButton
    Friend WithEvents rbtnTopicBlack As RadioButton
    Friend WithEvents rbtnTopicWhite As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnEnableLockScreenFeature As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents btnLockScrnSettingSave As Button
    Friend WithEvents TxtLockscrMyRoomNumber As TextBox
    Friend WithEvents CheckBoxEnableLockScreen As CheckBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents TxtLockScreenComment As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents btnLocscreenPreview As Button
End Class
