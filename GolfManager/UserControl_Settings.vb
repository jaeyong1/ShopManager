Public Class UserControl_Settings
    Public secondScrDragEnable As Boolean = False

    Private Sub UserControl_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btn2ndScrDragEnable.BackColor = Color.Gray
        'btn2ndScrDragEnable.BackColor = Color.LightGreen



    End Sub

    Private Sub btn2ndScrDragEnable_Click(sender As Object, e As EventArgs) Handles btn2ndScrDragEnable.Click
        If Not Application.OpenForms().OfType(Of Form2ndMonitor).Any Then
            MessageBox.Show("타석모니터를 먼저 열어주세요")
            Exit Sub
        End If

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


    Private Sub btnBoxDefaultPosition_Click(sender As Object, e As EventArgs) Handles btnBoxDefaultPosition.Click
        Dim tempWidthGap As Integer
        Dim tempHeightGap As Integer
        Dim tempCnt As Integer = 0

        tempWidthGap = Form2ndMonitor.CommonBoxWidth + (Form2ndMonitor.CommonBoxWidth * 0.3)
        tempHeightGap = 100


        For i = 0 To (Form2ndMonitor.numOfRooms - 1)
            If ((i Mod 5) = 0 And (i <> 0)) Then
                tempHeightGap = tempHeightGap + Form2ndMonitor.CommonBoxHeight + (Form2ndMonitor.CommonBoxHeight * 0.6)
            End If

            Form2ndMonitor.dynamicBoxList.Item(i).setPosXY(tempWidthGap * (i Mod 5) + 100, tempHeightGap)
        Next
    End Sub

    Private Sub btnUISettingSave_Click(sender As Object, e As EventArgs) Handles btnUISettingSave.Click
        Call Form2ndMonitor.save2ndMonitorSettings()
    End Sub

    Private Sub btnUISettingLoad_Click(sender As Object, e As EventArgs) Handles btnUISettingLoad.Click
        Call Form2ndMonitor.load2ndMonitorSettings()

        '화면 업데이트
        If Form2ndMonitor.numOfRooms > 0 Then
            lblRooms.Text = Form2ndMonitor.numOfRooms
            txtTitleFontSize.Text = Form2ndMonitor.CommonTopicFontSize '토픽 폰트크기
            txtTopicBoxGap.Text = Form2ndMonitor.CommonTopicGap '토픽~박스상단 간격
            txtBoxHeight.Text = Form2ndMonitor.CommonBoxHeight '박스높이
            txtBoxWidth.Text = Form2ndMonitor.CommonBoxWidth '박스넓이
            txtContentFontSize.Text = Form2ndMonitor.CommonBoxFontSize '박스글자 폰트크기
        End If
    End Sub
End Class
