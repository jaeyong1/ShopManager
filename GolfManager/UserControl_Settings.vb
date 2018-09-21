﻿Public Class UserControl_Settings
    Public secondScrDragEnable As Boolean = False

    Private Sub UserControl_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btn2ndScrDragEnable.BackColor = Color.Gray
        'btn2ndScrDragEnable.BackColor = Color.LightGreen



    End Sub

    Private Sub btn2ndScrDragEnable_Click(sender As Object, e As EventArgs) Handles btn2ndScrDragEnable.Click
        If (secondScrDragEnable) Then
            'Enable -> Disable
            btn2ndScrDragEnable.BackColor = Color.Gray
            GroupBox1.Enabled = False
            Form2ndMonitor.changeDragEnable(False)
            secondScrDragEnable = Not secondScrDragEnable
        Else
            'Disable -> Enable
            btn2ndScrDragEnable.BackColor = Color.LightPink
            GroupBox1.Enabled = True
            Form2ndMonitor.changeDragEnable(True)
            secondScrDragEnable = Not secondScrDragEnable

            'Form2 공통설정 화면에 표시
            Console.WriteLine("Boxes : " & Form2ndMonitor.numOfRooms)
            If Form2ndMonitor.numOfRooms > 0 Then
                lblRooms.Text = Form2ndMonitor.numOfRooms
                txtTitleFontSize.Text = Form2ndMonitor.CommonTopicFontSize '토픽 폰트크기
                txtTopicBoxGap.Text = Form2ndMonitor.CommonTopicGap '토픽~박스상단 간격
                txtBoxHeight.Text = Form2ndMonitor.CommonBoxHeight '박스높이
                txtBoxWidth.Text = Form2ndMonitor.CommonBoxWidth '박스넓이
                txtContentFontSize.Text = Form2ndMonitor.CommonBoxFontSize '박스글자 폰트크기
            End If
        End If
    End Sub

    Private Sub btnApplyUISetting_Click(sender As Object, e As EventArgs) Handles btnApplyUISetting.Click

        For i = 0 To (Form2ndMonitor.numOfRooms - 1)
            Form2ndMonitor.dynamicBoxList.Item(i).setStyle(
                 txtTitleFontSize.Text,
                 txtTopicBoxGap.Text,
                txtBoxHeight.Text,
                 txtBoxWidth.Text,
                 txtContentFontSize.Text)
        Next
    End Sub
End Class
