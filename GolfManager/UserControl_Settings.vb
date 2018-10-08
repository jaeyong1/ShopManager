Public Class UserControl_Settings
    Public secondScrDragEnable As Boolean = False

    '화면 로딩
    Private Sub UserControl_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn2ndScrDragEnable.BackColor = Color.Gray

    End Sub

    '설정버튼으로 세부항목 활성화/비활성화
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

            displayInternalSettings()



        End If
    End Sub

    '2nd스크린 -> 여기form에 표시
    Private Sub displayInternalSettings()
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

        '타석스크린 상단 문자배너 설정
        txtTopbanner.Text = My.Settings.Text2ndScreenTopBanner '내용
        txtTopbannerFontsize.Text = My.Settings.Text2ndScreenTopBannerFontSize '글자크기
        If My.Settings.Text2ndScreenTopBannerFontColor = "White" Then '색깔
            rbtnTopbannerColorWhite.Checked = True
        ElseIf My.Settings.Text2ndScreenTopBannerFontColor = "Black" Then
            rbtnTopbannerColorBlack.Checked = True
        End If

        '타석스크린 배경화면설정
        txtBackgroundimgPath.Text = My.Settings.BackgroundimgPath
        If Not txtBackgroundimgPath.Text.Equals("") Then
            chkBgimg.Checked = True
        End If

        '타석스크린 하단 이미지배너 경로
        txtBottomImgPath.Text = My.Settings.BottomImgPath
        If Not txtBottomImgPath.Text.Equals("") Then
            chkbottomimg.Checked = True
        End If
    End Sub

    '[타석화면에 적용] 버튼클릭
    Private Sub btnApplyUISetting_Click(sender As Object, e As EventArgs) Handles btnApplyUISetting.Click

        For i = 0 To (Form2ndMonitor.numOfRooms - 1)
            Form2ndMonitor.dynamicBoxList.Item(i).setStyle(
                 txtTitleFontSize.Text,
                 txtTopicBoxGap.Text,
                txtBoxHeight.Text,
                 txtBoxWidth.Text,
                 txtContentFontSize.Text)
        Next

        Form2ndMonitor.setTopbanner(txtTopbanner.Text, txtTopbannerFontsize.Text)
    End Sub

    '[임의배치] 버튼클릭
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

    '[현재설정 저장] 버튼클릭
    Private Sub btnUISettingSave_Click(sender As Object, e As EventArgs) Handles btnUISettingSave.Click
        Call Form2ndMonitor.save2ndMonitorSettings()
        My.Settings.Text2ndScreenTopBannerFontSize = txtTopbannerFontsize.Text
        My.Settings.Text2ndScreenTopBanner = txtTopbanner.Text
        My.Settings.Save()
    End Sub

    '[불러오기] 버튼클릭
    Private Sub btnUISettingLoad_Click(sender As Object, e As EventArgs) Handles btnUISettingLoad.Click
        Call Form2ndMonitor.load2ndMonitorSettings()

        '화면 업데이트
        displayInternalSettings()


    End Sub

    '타석스크린 배경화면 파일선택
    Private Sub btnBgimgPath_Click(sender As Object, e As EventArgs) Handles btnBgimgPath.Click
        If OpenFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtBackgroundimgPath.Text = OpenFileDialog1.FileName
            chkBgimg.Checked = True
            My.Settings.BackgroundimgPath = txtBackgroundimgPath.Text
        End If
    End Sub

    '타석스크린 배경화면 체크박스 변경
    Private Sub chkBgimg_CheckedChanged(sender As Object, e As EventArgs) Handles chkBgimg.CheckedChanged
        '체크해제
        If chkBgimg.Checked = False Then
            txtBackgroundimgPath.Text = ""
            My.Settings.BackgroundimgPath = ""
            My.Settings.Save()
            MsgBox("타석모니터창 재시작시 적용됩니다.")
        Else '체크
            If txtBackgroundimgPath.Text.Equals("") Then
                MsgBox("좌측 ...버튼을 사용하여 지정해주세요")
                chkBgimg.Checked = False
            End If
        End If
    End Sub


    '타석스크린 하단배너 경로 설정
    Private Sub btnBottomBannerPath_Click(sender As Object, e As EventArgs) Handles btnBottomBannerPath.Click
        Dim yn = MsgBox("기본경로 '" + G_BottomBannerImgDir + "'로 설정할까요?", MsgBoxStyle.YesNo)
        If yn = vbYes Then
            txtBottomImgPath.Text = G_BottomBannerImgDir
            chkbottomimg.Checked = True
            My.Settings.BottomImgPath = G_BottomBannerImgDir
            MsgBox("타석모니터창 재시작시 적용됩니다.")
        Else
            FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer
            FolderBrowserDialog1.SelectedPath = G_BottomBannerImgDir
            If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
                txtBottomImgPath.Text = FolderBrowserDialog1.SelectedPath
                chkbottomimg.Checked = True
                My.Settings.BottomImgPath = FolderBrowserDialog1.SelectedPath
                MsgBox("타석모니터창 재시작시 적용됩니다.")
            End If
        End If

    End Sub

    '타석스크린 하단배너 체크박스 변경
    Private Sub chkbottomimg_CheckedChanged(sender As Object, e As EventArgs) Handles chkbottomimg.CheckedChanged
        '체크해제
        If chkbottomimg.Checked = False Then
            txtBottomImgPath.Text = ""
            My.Settings.BottomImgPath = ""
            My.Settings.Save()
            MsgBox("타석모니터창 재시작시 적용됩니다.")
        Else '체크
            If txtBottomImgPath.Text.Equals("") Then
                MsgBox("좌측 ...버튼을 사용하여 지정해주세요")
                chkbottomimg.Checked = False
            End If
        End If
    End Sub

    '숫자 텍스트박스는 숫자만 입력
    Private Sub txtTopbannerFontsize_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTopbannerFontsize.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtTitleFontSize_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTitleFontSize.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtContentFontSize_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContentFontSize.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtTopicBoxGap_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTopicBoxGap.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtBoxWidth_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBoxWidth.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub txtBoxHeight_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBoxHeight.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub rbtnTopbannerColorBlack_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTopbannerColorBlack.CheckedChanged
        If rbtnTopbannerColorBlack.Checked = True Then
            rbtnTopbannerColorWhite.Checked = False
            My.Settings.Text2ndScreenTopBannerFontColor = "Black"
        End If
    End Sub

    Private Sub rbtnTopbannerColorWhite_CheckedChanged(sender As Object, e As EventArgs) Handles rbtnTopbannerColorWhite.CheckedChanged
        If rbtnTopbannerColorWhite.Checked = True Then
            rbtnTopbannerColorBlack.Checked = False
            My.Settings.Text2ndScreenTopBannerFontColor = "White"
        End If

    End Sub
End Class
