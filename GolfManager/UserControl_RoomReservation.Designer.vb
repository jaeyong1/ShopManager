﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
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
        Me.btnShow = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.groupNewRoomReserv = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRoomState = New System.Windows.Forms.TextBox()
        Me.btnAddReserv = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmployeeId = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.comboUsageTime = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lstStartTime = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboRoomNumber = New System.Windows.Forms.ComboBox()
        Me.groupWaitings = New System.Windows.Forms.GroupBox()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnRoomReservRefresh = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupNewRoomReserv.SuspendLayout()
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
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(30, 357)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(1029, 340)
        Me.DataGridView1.TabIndex = 1
        '
        'groupNewRoomReserv
        '
        Me.groupNewRoomReserv.Controls.Add(Me.Label7)
        Me.groupNewRoomReserv.Controls.Add(Me.txtRoomState)
        Me.groupNewRoomReserv.Controls.Add(Me.btnAddReserv)
        Me.groupNewRoomReserv.Controls.Add(Me.Label1)
        Me.groupNewRoomReserv.Controls.Add(Me.txtCustomerID)
        Me.groupNewRoomReserv.Controls.Add(Me.Label6)
        Me.groupNewRoomReserv.Controls.Add(Me.txtEmployeeId)
        Me.groupNewRoomReserv.Controls.Add(Me.Label5)
        Me.groupNewRoomReserv.Controls.Add(Me.txtCustomerName)
        Me.groupNewRoomReserv.Controls.Add(Me.comboUsageTime)
        Me.groupNewRoomReserv.Controls.Add(Me.Label4)
        Me.groupNewRoomReserv.Controls.Add(Me.Button1)
        Me.groupNewRoomReserv.Controls.Add(Me.Label3)
        Me.groupNewRoomReserv.Controls.Add(Me.lstStartTime)
        Me.groupNewRoomReserv.Controls.Add(Me.Label2)
        Me.groupNewRoomReserv.Controls.Add(Me.ComboRoomNumber)
        Me.groupNewRoomReserv.Font = New System.Drawing.Font("GulimChe", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.groupNewRoomReserv.Location = New System.Drawing.Point(232, 14)
        Me.groupNewRoomReserv.Name = "groupNewRoomReserv"
        Me.groupNewRoomReserv.Size = New System.Drawing.Size(463, 315)
        Me.groupNewRoomReserv.TabIndex = 2
        Me.groupNewRoomReserv.TabStop = False
        Me.groupNewRoomReserv.Text = "타석예약"
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
        Me.txtRoomState.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtRoomState.Location = New System.Drawing.Point(309, 23)
        Me.txtRoomState.Name = "txtRoomState"
        Me.txtRoomState.Size = New System.Drawing.Size(120, 25)
        Me.txtRoomState.TabIndex = 16
        Me.txtRoomState.TabStop = False
        '
        'btnAddReserv
        '
        Me.btnAddReserv.BackColor = System.Drawing.Color.Gray
        Me.btnAddReserv.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddReserv.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.btnAddReserv.ForeColor = System.Drawing.Color.White
        Me.btnAddReserv.Location = New System.Drawing.Point(238, 146)
        Me.btnAddReserv.Name = "btnAddReserv"
        Me.btnAddReserv.Size = New System.Drawing.Size(191, 37)
        Me.btnAddReserv.TabIndex = 6
        Me.btnAddReserv.Text = "예약추가"
        Me.btnAddReserv.UseVisualStyleBackColor = False
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
        Me.txtCustomerName.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.txtCustomerName.Location = New System.Drawing.Point(309, 55)
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(120, 25)
        Me.txtCustomerName.TabIndex = 9
        Me.txtCustomerName.TabStop = False
        '
        'comboUsageTime
        '
        Me.comboUsageTime.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.comboUsageTime.FormattingEnabled = True
        Me.comboUsageTime.Items.AddRange(New Object() {"1 시간", "2 시간", "3 시간", "4 시간"})
        Me.comboUsageTime.Location = New System.Drawing.Point(309, 88)
        Me.comboUsageTime.Name = "comboUsageTime"
        Me.comboUsageTime.Size = New System.Drawing.Size(120, 23)
        Me.comboUsageTime.TabIndex = 5
        Me.comboUsageTime.Text = "1 시간"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label4.Location = New System.Drawing.Point(236, 90)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "사용시간"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(238, 201)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(191, 37)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "(시작시간없이)대기추가"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "시작시간"
        '
        'lstStartTime
        '
        Me.lstStartTime.Font = New System.Drawing.Font("New Gulim", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lstStartTime.FormattingEnabled = True
        Me.lstStartTime.ItemHeight = 15
        Me.lstStartTime.Items.AddRange(New Object() {"오전 7:00", "오전 8:00", "오전 9:00", "오전 10:00", "오전 11:00", "오전 12:00", "오후 1:00", "오후 2:00", "오후 3:00", "오후 4:00", "오후 5:00", "오후 6:00", "오후 7:00", "오후 8:00", "오후 9:00"})
        Me.lstStartTime.Location = New System.Drawing.Point(94, 119)
        Me.lstStartTime.Name = "lstStartTime"
        Me.lstStartTime.ScrollAlwaysVisible = True
        Me.lstStartTime.Size = New System.Drawing.Size(120, 169)
        Me.lstStartTime.TabIndex = 4
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
        'groupWaitings
        '
        Me.groupWaitings.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupWaitings.Location = New System.Drawing.Point(712, 14)
        Me.groupWaitings.Name = "groupWaitings"
        Me.groupWaitings.Size = New System.Drawing.Size(347, 209)
        Me.groupWaitings.TabIndex = 3
        Me.groupWaitings.TabStop = False
        Me.groupWaitings.Text = "대기중"
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("New Gulim", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(712, 229)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(347, 100)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "사용종료 5분전"
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
        Me.btnRoomReservRefresh.TabIndex = 7
        Me.btnRoomReservRefresh.Text = "새로고침"
        Me.btnRoomReservRefresh.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'UserControl_RoomReservation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Controls.Add(Me.btnRoomReservRefresh)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupWaitings)
        Me.Controls.Add(Me.groupNewRoomReserv)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnShow)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "UserControl_RoomReservation"
        Me.Size = New System.Drawing.Size(1823, 1096)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupNewRoomReserv.ResumeLayout(False)
        Me.groupNewRoomReserv.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnShow As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents groupNewRoomReserv As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboRoomNumber As ComboBox
    Friend WithEvents lstStartTime As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents comboUsageTime As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
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
End Class
