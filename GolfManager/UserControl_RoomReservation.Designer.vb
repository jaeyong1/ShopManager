<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UserControl_RoomReservation
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnShow = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.groupNewRoomReserv = New System.Windows.Forms.GroupBox()
        Me.timepickerEndTime = New System.Windows.Forms.DateTimePicker()
        Me.timepickerStartTime = New System.Windows.Forms.DateTimePicker()
        Me.btn_SetStartTime12oclock = New System.Windows.Forms.Button()
        Me.btn_SetStartTimeAfter5Min = New System.Windows.Forms.Button()
        Me.btn_EndTimeIncrease70min = New System.Windows.Forms.Button()
        Me.btn_EndTimeIncrease60min = New System.Windows.Forms.Button()
        Me.btn_EndTimeIncrease10min = New System.Windows.Forms.Button()
        Me.btnInitUI = New System.Windows.Forms.Button()
        Me.btn_EndTimeIncrease30min = New System.Windows.Forms.Button()
        Me.btn_SetStartTimeNow = New System.Windows.Forms.Button()
        Me.btnAddReserv = New System.Windows.Forms.Button()
        Me.btnSetRoomEnd = New System.Windows.Forms.Button()
        Me.btnSetRoomStart = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRoomState = New System.Windows.Forms.TextBox()
        Me.btnAddWaiting = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmployeeId = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboRoomNumber = New System.Windows.Forms.ComboBox()
        Me.lblRoomReservIndex = New System.Windows.Forms.Label()
        Me.groupWaitings = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lstWaitingCust = New System.Windows.Forms.ListBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lst5min = New System.Windows.Forms.ListBox()
        Me.btnRoomReservRefresh = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbl2ndopennotify = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupNewRoomReserv.SuspendLayout()
        Me.groupWaitings.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.Green
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShow.Font = New System.Drawing.Font("New Gulim", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnShow.ForeColor = System.Drawing.Color.White
        Me.btnShow.Location = New System.Drawing.Point(30, 23)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(179, 49)
        Me.btnShow.TabIndex = 0
        Me.btnShow.Text = "타석모니터표시"
        Me.btnShow.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(30, 357)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        DataGridViewCellStyle4.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(1098, 292)
        Me.DataGridView1.TabIndex = 1
        '
        'groupNewRoomReserv
        '
        Me.groupNewRoomReserv.Controls.Add(Me.timepickerEndTime)
        Me.groupNewRoomReserv.Controls.Add(Me.timepickerStartTime)
        Me.groupNewRoomReserv.Controls.Add(Me.btn_SetStartTime12oclock)
        Me.groupNewRoomReserv.Controls.Add(Me.btn_SetStartTimeAfter5Min)
        Me.groupNewRoomReserv.Controls.Add(Me.btn_EndTimeIncrease70min)
        Me.groupNewRoomReserv.Controls.Add(Me.btn_EndTimeIncrease60min)
        Me.groupNewRoomReserv.Controls.Add(Me.btn_EndTimeIncrease10min)
        Me.groupNewRoomReserv.Controls.Add(Me.btnInitUI)
        Me.groupNewRoomReserv.Controls.Add(Me.btn_EndTimeIncrease30min)
        Me.groupNewRoomReserv.Controls.Add(Me.btn_SetStartTimeNow)
        Me.groupNewRoomReserv.Controls.Add(Me.btnAddReserv)
        Me.groupNewRoomReserv.Controls.Add(Me.btnSetRoomEnd)
        Me.groupNewRoomReserv.Controls.Add(Me.btnSetRoomStart)
        Me.groupNewRoomReserv.Controls.Add(Me.Label7)
        Me.groupNewRoomReserv.Controls.Add(Me.txtRoomState)
        Me.groupNewRoomReserv.Controls.Add(Me.btnAddWaiting)
        Me.groupNewRoomReserv.Controls.Add(Me.Label1)
        Me.groupNewRoomReserv.Controls.Add(Me.txtCustomerID)
        Me.groupNewRoomReserv.Controls.Add(Me.Label6)
        Me.groupNewRoomReserv.Controls.Add(Me.txtEmployeeId)
        Me.groupNewRoomReserv.Controls.Add(Me.Label5)
        Me.groupNewRoomReserv.Controls.Add(Me.txtCustomerName)
        Me.groupNewRoomReserv.Controls.Add(Me.Label4)
        Me.groupNewRoomReserv.Controls.Add(Me.Label3)
        Me.groupNewRoomReserv.Controls.Add(Me.Label2)
        Me.groupNewRoomReserv.Controls.Add(Me.ComboRoomNumber)
        Me.groupNewRoomReserv.Font = New System.Drawing.Font("GulimChe", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.groupNewRoomReserv.Location = New System.Drawing.Point(232, 14)
        Me.groupNewRoomReserv.Name = "groupNewRoomReserv"
        Me.groupNewRoomReserv.Size = New System.Drawing.Size(446, 315)
        Me.groupNewRoomReserv.TabIndex = 2
        Me.groupNewRoomReserv.TabStop = False
        Me.groupNewRoomReserv.Text = "타석예약"
        '
        'timepickerEndTime
        '
        Me.timepickerEndTime.Font = New System.Drawing.Font("New Gulim", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.timepickerEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.timepickerEndTime.Location = New System.Drawing.Point(94, 163)
        Me.timepickerEndTime.Name = "timepickerEndTime"
        Me.timepickerEndTime.ShowUpDown = True
        Me.timepickerEndTime.Size = New System.Drawing.Size(120, 26)
        Me.timepickerEndTime.TabIndex = 8
        '
        'timepickerStartTime
        '
        Me.timepickerStartTime.Font = New System.Drawing.Font("New Gulim", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.timepickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.timepickerStartTime.Location = New System.Drawing.Point(94, 122)
        Me.timepickerStartTime.Name = "timepickerStartTime"
        Me.timepickerStartTime.ShowUpDown = True
        Me.timepickerStartTime.Size = New System.Drawing.Size(120, 26)
        Me.timepickerStartTime.TabIndex = 4
        '
        'btn_SetStartTime12oclock
        '
        Me.btn_SetStartTime12oclock.BackColor = System.Drawing.Color.Gray
        Me.btn_SetStartTime12oclock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SetStartTime12oclock.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_SetStartTime12oclock.ForeColor = System.Drawing.Color.White
        Me.btn_SetStartTime12oclock.Location = New System.Drawing.Point(364, 122)
        Me.btn_SetStartTime12oclock.Name = "btn_SetStartTime12oclock"
        Me.btn_SetStartTime12oclock.Size = New System.Drawing.Size(64, 26)
        Me.btn_SetStartTime12oclock.TabIndex = 7
        Me.btn_SetStartTime12oclock.Text = "낮12시"
        Me.btn_SetStartTime12oclock.UseVisualStyleBackColor = False
        '
        'btn_SetStartTimeAfter5Min
        '
        Me.btn_SetStartTimeAfter5Min.BackColor = System.Drawing.Color.Gray
        Me.btn_SetStartTimeAfter5Min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SetStartTimeAfter5Min.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_SetStartTimeAfter5Min.ForeColor = System.Drawing.Color.White
        Me.btn_SetStartTimeAfter5Min.Location = New System.Drawing.Point(292, 122)
        Me.btn_SetStartTimeAfter5Min.Name = "btn_SetStartTimeAfter5Min"
        Me.btn_SetStartTimeAfter5Min.Size = New System.Drawing.Size(64, 26)
        Me.btn_SetStartTimeAfter5Min.TabIndex = 6
        Me.btn_SetStartTimeAfter5Min.Text = "5분후"
        Me.btn_SetStartTimeAfter5Min.UseVisualStyleBackColor = False
        '
        'btn_EndTimeIncrease70min
        '
        Me.btn_EndTimeIncrease70min.BackColor = System.Drawing.Color.Gray
        Me.btn_EndTimeIncrease70min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EndTimeIncrease70min.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_EndTimeIncrease70min.ForeColor = System.Drawing.Color.White
        Me.btn_EndTimeIncrease70min.Location = New System.Drawing.Point(382, 163)
        Me.btn_EndTimeIncrease70min.Name = "btn_EndTimeIncrease70min"
        Me.btn_EndTimeIncrease70min.Size = New System.Drawing.Size(47, 26)
        Me.btn_EndTimeIncrease70min.TabIndex = 12
        Me.btn_EndTimeIncrease70min.Text = "+70'"
        Me.btn_EndTimeIncrease70min.UseVisualStyleBackColor = False
        '
        'btn_EndTimeIncrease60min
        '
        Me.btn_EndTimeIncrease60min.BackColor = System.Drawing.Color.Gray
        Me.btn_EndTimeIncrease60min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EndTimeIncrease60min.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_EndTimeIncrease60min.ForeColor = System.Drawing.Color.White
        Me.btn_EndTimeIncrease60min.Location = New System.Drawing.Point(328, 163)
        Me.btn_EndTimeIncrease60min.Name = "btn_EndTimeIncrease60min"
        Me.btn_EndTimeIncrease60min.Size = New System.Drawing.Size(47, 26)
        Me.btn_EndTimeIncrease60min.TabIndex = 11
        Me.btn_EndTimeIncrease60min.Text = "+60'"
        Me.btn_EndTimeIncrease60min.UseVisualStyleBackColor = False
        '
        'btn_EndTimeIncrease10min
        '
        Me.btn_EndTimeIncrease10min.BackColor = System.Drawing.Color.Gray
        Me.btn_EndTimeIncrease10min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EndTimeIncrease10min.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_EndTimeIncrease10min.ForeColor = System.Drawing.Color.White
        Me.btn_EndTimeIncrease10min.Location = New System.Drawing.Point(220, 163)
        Me.btn_EndTimeIncrease10min.Name = "btn_EndTimeIncrease10min"
        Me.btn_EndTimeIncrease10min.Size = New System.Drawing.Size(47, 26)
        Me.btn_EndTimeIncrease10min.TabIndex = 9
        Me.btn_EndTimeIncrease10min.Text = "+10'"
        Me.btn_EndTimeIncrease10min.UseVisualStyleBackColor = False
        '
        'btnInitUI
        '
        Me.btnInitUI.BackColor = System.Drawing.Color.Gray
        Me.btnInitUI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInitUI.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnInitUI.ForeColor = System.Drawing.Color.White
        Me.btnInitUI.Location = New System.Drawing.Point(237, 251)
        Me.btnInitUI.Name = "btnInitUI"
        Me.btnInitUI.Size = New System.Drawing.Size(191, 37)
        Me.btnInitUI.TabIndex = 17
        Me.btnInitUI.Text = "입력화면초기화"
        Me.btnInitUI.UseVisualStyleBackColor = False
        '
        'btn_EndTimeIncrease30min
        '
        Me.btn_EndTimeIncrease30min.BackColor = System.Drawing.Color.Gray
        Me.btn_EndTimeIncrease30min.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_EndTimeIncrease30min.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_EndTimeIncrease30min.ForeColor = System.Drawing.Color.White
        Me.btn_EndTimeIncrease30min.Location = New System.Drawing.Point(274, 163)
        Me.btn_EndTimeIncrease30min.Name = "btn_EndTimeIncrease30min"
        Me.btn_EndTimeIncrease30min.Size = New System.Drawing.Size(47, 26)
        Me.btn_EndTimeIncrease30min.TabIndex = 10
        Me.btn_EndTimeIncrease30min.Text = "+30'"
        Me.btn_EndTimeIncrease30min.UseVisualStyleBackColor = False
        '
        'btn_SetStartTimeNow
        '
        Me.btn_SetStartTimeNow.BackColor = System.Drawing.Color.Gray
        Me.btn_SetStartTimeNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_SetStartTimeNow.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btn_SetStartTimeNow.ForeColor = System.Drawing.Color.White
        Me.btn_SetStartTimeNow.Location = New System.Drawing.Point(220, 122)
        Me.btn_SetStartTimeNow.Name = "btn_SetStartTimeNow"
        Me.btn_SetStartTimeNow.Size = New System.Drawing.Size(64, 26)
        Me.btn_SetStartTimeNow.TabIndex = 5
        Me.btn_SetStartTimeNow.Text = "지금"
        Me.btn_SetStartTimeNow.UseVisualStyleBackColor = False
        '
        'btnAddReserv
        '
        Me.btnAddReserv.BackColor = System.Drawing.Color.Gray
        Me.btnAddReserv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddReserv.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAddReserv.ForeColor = System.Drawing.Color.White
        Me.btnAddReserv.Location = New System.Drawing.Point(23, 208)
        Me.btnAddReserv.Name = "btnAddReserv"
        Me.btnAddReserv.Size = New System.Drawing.Size(204, 37)
        Me.btnAddReserv.TabIndex = 13
        Me.btnAddReserv.Text = "타석예약추가"
        Me.btnAddReserv.UseVisualStyleBackColor = False
        '
        'btnSetRoomEnd
        '
        Me.btnSetRoomEnd.BackColor = System.Drawing.Color.Gray
        Me.btnSetRoomEnd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetRoomEnd.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSetRoomEnd.ForeColor = System.Drawing.Color.White
        Me.btnSetRoomEnd.Location = New System.Drawing.Point(132, 251)
        Me.btnSetRoomEnd.Name = "btnSetRoomEnd"
        Me.btnSetRoomEnd.Size = New System.Drawing.Size(95, 37)
        Me.btnSetRoomEnd.TabIndex = 16
        Me.btnSetRoomEnd.Text = "사용종료"
        Me.btnSetRoomEnd.UseVisualStyleBackColor = False
        '
        'btnSetRoomStart
        '
        Me.btnSetRoomStart.BackColor = System.Drawing.Color.Gray
        Me.btnSetRoomStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetRoomStart.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnSetRoomStart.ForeColor = System.Drawing.Color.White
        Me.btnSetRoomStart.Location = New System.Drawing.Point(23, 251)
        Me.btnSetRoomStart.Name = "btnSetRoomStart"
        Me.btnSetRoomStart.Size = New System.Drawing.Size(99, 37)
        Me.btnSetRoomStart.TabIndex = 15
        Me.btnSetRoomStart.Text = "사용시작"
        Me.btnSetRoomStart.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label7.Location = New System.Drawing.Point(236, 26)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "현재상태"
        '
        'txtRoomState
        '
        Me.txtRoomState.Enabled = False
        Me.txtRoomState.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtRoomState.Location = New System.Drawing.Point(309, 23)
        Me.txtRoomState.Name = "txtRoomState"
        Me.txtRoomState.Size = New System.Drawing.Size(120, 25)
        Me.txtRoomState.TabIndex = 16
        Me.txtRoomState.TabStop = False
        '
        'btnAddWaiting
        '
        Me.btnAddWaiting.BackColor = System.Drawing.Color.Gray
        Me.btnAddWaiting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddWaiting.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAddWaiting.ForeColor = System.Drawing.Color.White
        Me.btnAddWaiting.Location = New System.Drawing.Point(238, 208)
        Me.btnAddWaiting.Name = "btnAddWaiting"
        Me.btnAddWaiting.Size = New System.Drawing.Size(191, 37)
        Me.btnAddWaiting.TabIndex = 14
        Me.btnAddWaiting.Text = "(시간선택없이)대기추가"
        Me.btnAddWaiting.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "회원ID"
        '
        'txtCustomerID
        '
        Me.txtCustomerID.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtCustomerID.Location = New System.Drawing.Point(94, 51)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.Size = New System.Drawing.Size(120, 25)
        Me.txtCustomerID.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "담당코치"
        '
        'txtEmployeeId
        '
        Me.txtEmployeeId.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtEmployeeId.Location = New System.Drawing.Point(94, 85)
        Me.txtEmployeeId.Name = "txtEmployeeId"
        Me.txtEmployeeId.Size = New System.Drawing.Size(120, 25)
        Me.txtEmployeeId.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label5.Location = New System.Drawing.Point(236, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "회원이름"
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Enabled = False
        Me.txtCustomerName.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(309, 55)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(120, 25)
        Me.txtCustomerName.TabIndex = 9
        Me.txtCustomerName.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(6, 171)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "종료시간"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "시작시간"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "타석번호"
        '
        'ComboRoomNumber
        '
        Me.ComboRoomNumber.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.ComboRoomNumber.FormattingEnabled = True
        Me.ComboRoomNumber.Location = New System.Drawing.Point(94, 21)
        Me.ComboRoomNumber.Name = "ComboRoomNumber"
        Me.ComboRoomNumber.Size = New System.Drawing.Size(120, 23)
        Me.ComboRoomNumber.TabIndex = 1
        '
        'lblRoomReservIndex
        '
        Me.lblRoomReservIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRoomReservIndex.Location = New System.Drawing.Point(30, 186)
        Me.lblRoomReservIndex.Name = "lblRoomReservIndex"
        Me.lblRoomReservIndex.Size = New System.Drawing.Size(65, 23)
        Me.lblRoomReservIndex.TabIndex = 19
        Me.lblRoomReservIndex.Visible = False
        '
        'groupWaitings
        '
        Me.groupWaitings.Controls.Add(Me.Label8)
        Me.groupWaitings.Controls.Add(Me.lstWaitingCust)
        Me.groupWaitings.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupWaitings.Location = New System.Drawing.Point(702, 14)
        Me.groupWaitings.Name = "groupWaitings"
        Me.groupWaitings.Size = New System.Drawing.Size(215, 315)
        Me.groupWaitings.TabIndex = 3
        Me.groupWaitings.TabStop = False
        Me.groupWaitings.Text = "대기중"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(32, 285)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(151, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "(더블클릭으로 예약취소)"
        '
        'lstWaitingCust
        '
        Me.lstWaitingCust.Enabled = False
        Me.lstWaitingCust.FormattingEnabled = True
        Me.lstWaitingCust.Location = New System.Drawing.Point(6, 18)
        Me.lstWaitingCust.Name = "lstWaitingCust"
        Me.lstWaitingCust.Size = New System.Drawing.Size(203, 264)
        Me.lstWaitingCust.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lst5min)
        Me.GroupBox1.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(944, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 315)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "사용종료 5분전 / 종료지연"
        '
        'lst5min
        '
        Me.lst5min.Enabled = False
        Me.lst5min.FormattingEnabled = True
        Me.lst5min.Location = New System.Drawing.Point(6, 18)
        Me.lst5min.Name = "lst5min"
        Me.lst5min.Size = New System.Drawing.Size(172, 290)
        Me.lst5min.TabIndex = 0
        '
        'btnRoomReservRefresh
        '
        Me.btnRoomReservRefresh.BackColor = System.Drawing.Color.Gray
        Me.btnRoomReservRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRoomReservRefresh.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnRoomReservRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRoomReservRefresh.Location = New System.Drawing.Point(30, 314)
        Me.btnRoomReservRefresh.Name = "btnRoomReservRefresh"
        Me.btnRoomReservRefresh.Size = New System.Drawing.Size(162, 37)
        Me.btnRoomReservRefresh.TabIndex = 18
        Me.btnRoomReservRefresh.Text = "새로고침"
        Me.btnRoomReservRefresh.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'lbl2ndopennotify
        '
        Me.lbl2ndopennotify.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbl2ndopennotify.Location = New System.Drawing.Point(780, 99)
        Me.lbl2ndopennotify.Name = "lbl2ndopennotify"
        Me.lbl2ndopennotify.Size = New System.Drawing.Size(300, 93)
        Me.lbl2ndopennotify.TabIndex = 18
        Me.lbl2ndopennotify.Text = "<타석모니터 활성화 필요>"
        Me.lbl2ndopennotify.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'UserControl_RoomReservation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Controls.Add(Me.lbl2ndopennotify)
        Me.Controls.Add(Me.btnRoomReservRefresh)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupWaitings)
        Me.Controls.Add(Me.groupNewRoomReserv)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.lblRoomReservIndex)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "UserControl_RoomReservation"
        Me.Size = New System.Drawing.Size(1823, 1096)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupNewRoomReserv.ResumeLayout(False)
        Me.groupNewRoomReserv.PerformLayout()
        Me.groupWaitings.ResumeLayout(False)
        Me.groupWaitings.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnShow As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents groupNewRoomReserv As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboRoomNumber As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents txtEmployeeId As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtCustomerID As TextBox
    Friend WithEvents btnAddReserv As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents txtRoomState As TextBox
    Friend WithEvents groupWaitings As GroupBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnRoomReservRefresh As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents lst5min As ListBox
    Friend WithEvents lstWaitingCust As ListBox
    Friend WithEvents btnAddWaiting As Button
    Friend WithEvents Label8 As Label
    Friend WithEvents btnSetRoomEnd As Button
    Friend WithEvents btnSetRoomStart As Button
    Friend WithEvents lblRoomReservIndex As Label
    Friend WithEvents btnInitUI As Button
    Friend WithEvents btn_SetStartTimeAfter5Min As Button
    Friend WithEvents btn_EndTimeIncrease70min As Button
    Friend WithEvents btn_EndTimeIncrease60min As Button
    Friend WithEvents btn_EndTimeIncrease10min As Button
    Friend WithEvents btn_EndTimeIncrease30min As Button
    Friend WithEvents btn_SetStartTimeNow As Button
    Friend WithEvents timepickerStartTime As DateTimePicker
    Friend WithEvents timepickerEndTime As DateTimePicker
    Friend WithEvents btn_SetStartTime12oclock As Button
    Friend WithEvents lbl2ndopennotify As Label
End Class
