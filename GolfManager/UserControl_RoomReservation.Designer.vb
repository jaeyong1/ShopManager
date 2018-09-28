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
        Me.btnShow = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.groupNewRoomReserv = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboRoomNumber = New System.Windows.Forms.ComboBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Idx = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.state = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.starttime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpectedEndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupNewRoomReserv.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnShow
        '
        Me.btnShow.BackColor = System.Drawing.Color.Green
        Me.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Idx, Me.Column8, Me.state, Me.Column9, Me.Column10, Me.starttime, Me.ExpectedEndTime})
        Me.DataGridView1.Location = New System.Drawing.Point(30, 357)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(955, 212)
        Me.DataGridView1.TabIndex = 1
        '
        'groupNewRoomReserv
        '
        Me.groupNewRoomReserv.Controls.Add(Me.Button2)
        Me.groupNewRoomReserv.Controls.Add(Me.Label1)
        Me.groupNewRoomReserv.Controls.Add(Me.TextBox1)
        Me.groupNewRoomReserv.Controls.Add(Me.Label6)
        Me.groupNewRoomReserv.Controls.Add(Me.TextBox3)
        Me.groupNewRoomReserv.Controls.Add(Me.Label5)
        Me.groupNewRoomReserv.Controls.Add(Me.TextBox2)
        Me.groupNewRoomReserv.Controls.Add(Me.ComboBox2)
        Me.groupNewRoomReserv.Controls.Add(Me.Label4)
        Me.groupNewRoomReserv.Controls.Add(Me.Button1)
        Me.groupNewRoomReserv.Controls.Add(Me.Label3)
        Me.groupNewRoomReserv.Controls.Add(Me.ListBox1)
        Me.groupNewRoomReserv.Controls.Add(Me.Label2)
        Me.groupNewRoomReserv.Controls.Add(Me.ComboRoomNumber)
        Me.groupNewRoomReserv.Location = New System.Drawing.Point(232, 14)
        Me.groupNewRoomReserv.Name = "groupNewRoomReserv"
        Me.groupNewRoomReserv.Size = New System.Drawing.Size(406, 315)
        Me.groupNewRoomReserv.TabIndex = 2
        Me.groupNewRoomReserv.TabStop = False
        Me.groupNewRoomReserv.Text = "타석예약"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Gray
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(224, 155)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(162, 37)
        Me.Button2.TabIndex = 15
        Me.Button2.Text = "예약추가"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 20)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "회원ID"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(87, 51)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(120, 26)
        Me.TextBox1.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(21, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 20)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "담당코치"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(87, 83)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(120, 26)
        Me.TextBox3.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(214, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "회원이름"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(280, 51)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(120, 26)
        Me.TextBox2.TabIndex = 9
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"1 시간", "2 시간", "3 시간", "4 시간"})
        Me.ComboBox2.Location = New System.Drawing.Point(280, 115)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(80, 28)
        Me.ComboBox2.TabIndex = 8
        Me.ComboBox2.Text = "1 시간"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(217, 121)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "사용시간"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Gray
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(224, 202)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(162, 37)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "(시작시간없이)대기추가"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 20)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "시작시간"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 20
        Me.ListBox1.Items.AddRange(New Object() {"오전 7:00", "오전 8:00", "오전 9:00", "오전 10:00", "오전 11:00", "오전 12:00", "오후 1:00", "오후 2:00", "오후 3:00", "오후 4:00", "오후 5:00", "오후 6:00", "오후 7:00", "오후 8:00", "오후 9:00"})
        Me.ListBox1.Location = New System.Drawing.Point(87, 118)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(120, 144)
        Me.ListBox1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "타석번호"
        '
        'ComboRoomNumber
        '
        Me.ComboRoomNumber.FormattingEnabled = True
        Me.ComboRoomNumber.Location = New System.Drawing.Point(87, 20)
        Me.ComboRoomNumber.Name = "ComboRoomNumber"
        Me.ComboRoomNumber.Size = New System.Drawing.Size(121, 28)
        Me.ComboRoomNumber.TabIndex = 2
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(30, 327)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(116, 24)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "사용완료 숨기기"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Idx
        '
        Me.Idx.HeaderText = "index"
        Me.Idx.Name = "Idx"
        '
        'Column8
        '
        Me.Column8.HeaderText = "타석번호"
        Me.Column8.Name = "Column8"
        '
        'state
        '
        Me.state.HeaderText = "상태"
        Me.state.Name = "state"
        '
        'Column9
        '
        Me.Column9.HeaderText = "회원ID(이름)"
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        Me.Column10.HeaderText = "담당직원"
        Me.Column10.Name = "Column10"
        '
        'starttime
        '
        Me.starttime.HeaderText = "시작시간"
        Me.starttime.Name = "starttime"
        '
        'ExpectedEndTime
        '
        Me.ExpectedEndTime.HeaderText = "종료시간"
        Me.ExpectedEndTime.Name = "ExpectedEndTime"
        '
        'UserControl_RoomReservation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Controls.Add(Me.CheckBox1)
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
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnShow As Button
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents groupNewRoomReserv As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ComboRoomNumber As ComboBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Idx As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents state As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents starttime As DataGridViewTextBoxColumn
    Friend WithEvents ExpectedEndTime As DataGridViewTextBoxColumn
End Class
