Imports System.ComponentModel
Imports System.IO 'xml로 직렬화
Imports System.Runtime.Serialization.Formatters.Binary 'xml로 직렬화




Public Class Form2ndMonitor
    Public SecondScreenDesignXMLFileName As String = G_SettingsDir + "RoomServationUISerialization.xml"  '파일명

    Public dynamicBoxList As New List(Of dynamicTextBox) '타석UI 동적생성 리스트

    Public numOfRooms As Integer = 0 '이 계정에 허용된 타석개수

    Public CommonTopicFontSize As Integer = 18 '토픽 폰트크기(디폴트)
    Public CommonTopicGap As Integer = 30 '토픽~박스상단 간격(디폴트)
    Public CommonBoxHeight As Integer = 100 '박스높이(디폴트)
    Public CommonBoxWidth As Integer = 150 '박스넓이(디폴트)
    Public CommonBoxFontSize As Integer = 20 '박스글자 폰트크기(디폴트)

    Private Sub deleteXYSettingFile()
        MsgBox(SecondScreenDesignXMLFileName + "파일을 삭제합니다.")
        My.Computer.FileSystem.DeleteFile(SecondScreenDesignXMLFileName)
    End Sub

    Private Sub Form2ndMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ''XML 파일로딩
        dynamicBoxList = load2ndMonitorSettings()
        load2ndMonitorOtherSettings()

        If dynamicBoxList.Count = 0 Then
            '파일 불러온것 없음(파일이 없거나 XML 파싱중 exception)
            Console.WriteLine("타석표시기 신규박스생성 {0}개", numOfRooms)

            ' 타석수만큼 박스 생성
            For i = 0 To numOfRooms - 1
                Dim a As New dynamicTextBox()
                Me.Controls.Add(a.getLabelReference()) '토픽
                Me.Controls.Add(a.getTextBoxReferece()) '박스
                a.setStyle(CommonTopicFontSize, CommonTopicGap, CommonBoxHeight, CommonBoxWidth, CommonBoxFontSize) '기본모양설정
                dynamicBoxList.Add(a) '향후관리를위해 객체리스트 만듬
                dynamicBoxList.Item(i).setPosXY(100, 100) '임의위치(100,100)
            Next
            MessageBox.Show("화면구성파일이 없습니다. 설정에서 위치와 모양을 변경하세요.")

        Else
            '파일에서 화면구성 불러옴
            Console.WriteLine("타석표시기 파일에서 불러옴. 설정:{0}개, 파일로딩{1}개", numOfRooms, dynamicBoxList.Count)
            If (numOfRooms <= dynamicBoxList.Count) Then
                For i = 0 To numOfRooms - 1
                    Console.WriteLine("Loaded (" & i & ") " &
                dynamicBoxList.Item(i).PosX & ", " &
                dynamicBoxList.Item(i).PosY)
                    Me.Controls.Add(dynamicBoxList.Item(i).getLabelReference()) '토픽
                    Me.Controls.Add(dynamicBoxList.Item(i).getTextBoxReferece()) '박스
                    dynamicBoxList.Item(i).setPosXY(dynamicBoxList.Item(i).PosX, dynamicBoxList.Item(i).PosY)
                    dynamicBoxList.Item(i).refreshWithLocalVal() 'XML -> UI 적용

                Next

                If numOfRooms > 0 Then
                    'Public변수 업데이트
                    CommonTopicFontSize = dynamicBoxList.Item(0).TopicFontSize '토픽 폰트크기(디폴트)
                    CommonTopicGap = dynamicBoxList.Item(0).TopicGap '토픽~박스상단 간격(디폴트)
                    CommonBoxHeight = dynamicBoxList.Item(0).BoxHeight '박스높이(디폴트)
                    CommonBoxWidth = dynamicBoxList.Item(0).BoxWidth '박스넓이(디폴트)
                    CommonBoxFontSize = dynamicBoxList.Item(0).BoxFontSize '박스글자 폰트크기(디폴트)
                End If
            Else
                MessageBox.Show("타석개수가 변경되어서 기존설정으로 모두 표시할 수 없습니다. 설정메뉴에서 위치와 모양을 변경하세요. 현재설정은 삭제합니다.")
                Call deleteXYSettingFile()
                Exit Sub
            End If

        End If

        '상단배너 뒤로 보냄
        lblTopBannerText.SendToBack()

        '하단 이미지 배너 사용유무
        If My.Settings.BottomImgPath.Equals("") Or My.Settings.BottomImgPath = Nothing Then
            Console.WriteLine("하단 이미지 배너 사용안함")
            picboxBottomBanner.Visible = False
        Else
            picboxBottomBanner.Visible = True
            '하단배너 이미지 파일리스트업
            txtBottomBannerImageFiles.Clear()
            Try
                For Each foundFile As String In My.Computer.FileSystem.GetFiles(My.Settings.BottomImgPath)
                    Console.WriteLine("Banner image file: {0}", foundFile)
                    txtBottomBannerImageFiles.Add(foundFile)
                Next
                Console.WriteLine("found " & txtBottomBannerImageFiles.Count & " files.")
                Timer2.Enabled = True '하단배너이미지 변경타이머

            Catch ex As Exception
                MsgBox("하단배너이미지경로'" + My.Settings.BottomImgPath + "'에서 파일을 읽는 중 에러발생.")
                picboxBottomBanner.Visible = False
            End Try
        End If

        '배경화면 설정
        If My.Settings.BackgroundimgPath.Equals("") Or My.Settings.BackgroundimgPath = Nothing Then
            Console.WriteLine("배경이미지 사용안함")
            Me.BackgroundImage = Nothing
        Else
            Try
                Me.BackgroundImage = System.Drawing.Image.FromFile(My.Settings.BackgroundimgPath)
            Catch ex As Exception
                MsgBox("배경그림을 읽어오는중에 에러가 발생했습니다.")
                Console.WriteLine("배경그림을 읽어오는 과정에서 에러가 발생했습니다.")
            End Try

        End If


        '주기적으로 배너 변경(1초)
        Timer1.Enabled = True


    End Sub

    '화면배치를 파일로 저장
    Public Sub save2ndMonitorSettings()
        Console.WriteLine(" 화면UI를 XML파일로 저장.")

        '화면구성을 직렬화하여 XML로 저장
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(List(Of dynamicTextBox)))
        Dim file As New System.IO.StreamWriter(SecondScreenDesignXMLFileName)
        writer.Serialize(file, dynamicBoxList)
        file.Close()
        MsgBox("저장되었습니다")
    End Sub

    '파일에서 화면배치 불러옴
    Public Function load2ndMonitorSettings() As List(Of dynamicTextBox)
        Dim overview As List(Of dynamicTextBox) = New List(Of dynamicTextBox)
        Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(List(Of dynamicTextBox)))

        Console.WriteLine("화면UI구성을 XML파일에서 읽기")

        '화면구성을 XML에서 읽기
        Try
            Dim file2 As New System.IO.StreamReader(SecondScreenDesignXMLFileName)

            overview = CType(reader.Deserialize(file2), List(Of dynamicTextBox))
            Console.WriteLine("File의 XML의 리스트아이템개수 :" & overview.Count)
            file2.Close()

        Catch ex As Exception
            Console.WriteLine("################################################")
            Console.WriteLine(" 화면UI를 구성하는 XML파일을 읽는도중 오류가 발생.")
            Console.WriteLine("################################################")
        End Try
        Return overview
    End Function

    '파일에서 화면배치외 "기타설정" 불러옴
    Public Sub load2ndMonitorOtherSettings()
        Console.WriteLine(My.Settings.Text2ndScreenTopBanner)
        '상단배너내용
        Call setTopbanner(My.Settings.Text2ndScreenTopBanner, My.Settings.Text2ndScreenTopBannerFontSize)

    End Sub


    Private txtTopBanners() As String '상단배너문자열 리스트
    Private cursorTopBanners As Integer = 0 '상단배너문자열 로테이션 인덱스
    Private txtBottomBannerImageFiles As New List(Of String) '하단배너 이미지파일 리스트
    Private cursorBottomBanners As Integer = 0 '하단배너문자열 로테이션 인덱스
    '탑배너 설정
    Public Sub setTopbanner(_contents As String, _fontsize As Integer)
        cursorTopBanners = 0
        txtTopBanners = Split(_contents, vbCrLf, , vbTextCompare)
        Console.WriteLine("lines : " & txtTopBanners.Count)
    End Sub

    '타이머에 따라 상단 텍스트배너 바뀜
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        '탑배너 설정없으면 종료
        If txtTopBanners.Count = 0 Then
            Exit Sub
        End If

        lblTopBannerText.Text = txtTopBanners(cursorTopBanners) '내용
        lblTopBannerText.Font = New Font("Sans Serif", My.Settings.Text2ndScreenTopBannerFontSize, FontStyle.Regular) '폰트/크기
        lblTopBannerText.SendToBack()
        If My.Settings.Text2ndScreenTopBannerFontColor.Equals("Black") Then
            lblTopBannerText.ForeColor = Color.Black
        ElseIf My.Settings.Text2ndScreenTopBannerFontColor.Equals("White") Then
            lblTopBannerText.ForeColor = Color.White
        End If

        cursorTopBanners = cursorTopBanners + 1
        If (cursorTopBanners >= txtTopBanners.Count) Then
            cursorTopBanners = 0
        End If
    End Sub

    '타이머에 따라 하단 배너이미지 바뀜
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        '배너이미지 없으면 종료
        If txtBottomBannerImageFiles.Count = 0 Then
            Exit Sub
        End If

        Try
            picboxBottomBanner.Image = System.Drawing.Image.FromFile(txtBottomBannerImageFiles.Item(cursorBottomBanners))
            picboxBottomBanner.BringToFront()

        Catch ex As Exception
            Console.WriteLine("하단 배너이미지 읽어오는 과정에서 에러가 발생했습니다.")
        End Try



        cursorBottomBanners = cursorBottomBanners + 1
        If (cursorBottomBanners >= txtBottomBannerImageFiles.Count) Then
            cursorBottomBanners = 0
        End If

    End Sub

    '드래그 가능여부 전체변경(외부인터페이스)
    Public Sub changeDragEnable(en As Boolean)
        For i = 0 To (dynamicBoxList.Count - 1)
            dynamicBoxList.Item(i).setDragEnable(en)
        Next
    End Sub

    Private Sub Form2ndMonitor_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Console.WriteLine("form resized. picboxBottomBanner:{0}x{1}", picboxBottomBanner.Size.Width, picboxBottomBanner.Size.Height)
        lblTopBannerText.Width = Me.Size.Width

    End Sub

    '창 닫을때
    Private Sub Form2ndMonitor_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        '주기적으로 배너 변경(1초)
        Timer1.Enabled = False
    End Sub


    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''' <summary>
    ''' 토픽과 텍스트박스를 하나로 묶어서 표시단위 클래스
    ''' </summary>
    Public Class dynamicTextBox
        Private Off As Point

        Private WithEvents txt As New System.Windows.Forms.TextBox() 'Data
        Private lblroomnumber As New System.Windows.Forms.Label() 'Topic
        Public PosX As Integer
        Public PosY As Integer
        Public TopicFontSize As Integer
        Public TopicGap As Integer
        Public BoxHeight As Integer
        Public BoxWidth As Integer
        Public BoxFontSize As Integer
        Private dragEnable As Boolean = False

        Public Sub refreshWithLocalVal()

            '박스위치 업데이트
            setPosXY(PosX, PosY)
            Console.WriteLine("refresh - set:" & PosX & "," & PosY)

            '박스사이즈 
            txt.Height = BoxHeight
            txt.Width = BoxWidth


            '토픽폰트 생성
            Dim topicfont1 = New Font("Sans Serif", TopicFontSize, FontStyle.Regular)

            '토픽폰트 적용
            lblroomnumber.Font = topicfont1
            If My.Settings.Text2ndScreenTopicFontColor.Equals("White") Then
                lblroomnumber.ForeColor = Color.White
            ElseIf My.Settings.Text2ndScreenTopicFontColor.Equals("Black") Then
                lblroomnumber.ForeColor = Color.Black
            Else
                lblroomnumber.ForeColor = Color.White
            End If



            '박스폰트 생성
            Dim boxfont1 = New Font("Sans Serif", BoxFontSize, FontStyle.Regular)

            '박스폰트 적용
            txt.Font = boxfont1

        End Sub

        Public Sub setStyle(in_TopicFontSize As Integer,
                            in_TopicGap As Integer,
                            in_BoxHeight As Integer,
                            in_BoxWidth As Integer,
                            in_BoxFontSize As Integer)
            TopicFontSize = in_TopicFontSize
            TopicGap = in_TopicGap
            BoxHeight = in_BoxHeight
            BoxWidth = in_BoxWidth
            BoxFontSize = in_BoxFontSize

            '토픽폰트 생성
            Dim topicfont1 = New Font("Sans Serif", TopicFontSize, FontStyle.Regular)
            '토픽폰트 적용
            lblroomnumber.Font = topicfont1
            '토픽폰트 색깔
            If My.Settings.Text2ndScreenTopicFontColor.Equals("White") Then
                lblroomnumber.ForeColor = Color.White
            ElseIf My.Settings.Text2ndScreenTopicFontColor.Equals("Black") Then
                lblroomnumber.ForeColor = Color.Black
            Else
                lblroomnumber.ForeColor = Color.White
            End If

            '토픽-박스 간격적용
            lblroomnumber.Top = txt.Top - TopicGap

            '박스사이즈 
            txt.Height = BoxHeight
            txt.Width = BoxWidth

            '박스폰트 생성
            Dim boxfont1 = New Font("Sans Serif", BoxFontSize, FontStyle.Regular)
            '박스폰트 적용
            txt.Font = boxfont1

        End Sub

        Public Sub setTopicText(str As String)
            '토픽 문자열
            lblroomnumber.Text = str
        End Sub


        Public Sub setBoxText(str As String)
            '박스 문자열
            txt.Text = str
            txt.TextAlign = HorizontalAlignment.Center
        End Sub

        '드래그 가능 반전
        Public Sub setDragEnable(en As Boolean)
            dragEnable = en
        End Sub

        '박스좌표 리턴
        Public Function getOffset() As Point
            Return Off
        End Function

        '마우스 클릭 다운
        Private Sub Obj_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt.MouseDown
            Off.X = MousePosition.X - sender.Left
            Off.Y = MousePosition.Y - sender.Top
        End Sub

        '토픽과 박스의 상대위치
        Private Sub moveTo(ByVal sender As Object)
            '토픽위치
            lblroomnumber.Left = sender.Left
            lblroomnumber.Top = sender.Top - TopicGap
            lblroomnumber.AutoSize = True

            '박스위치
            sender.Left = MousePosition.X - Off.X
            sender.Top = MousePosition.Y - Off.Y

            PosX = sender.Left
            PosY = sender.Top

            '박스사이즈 
            txt.Height = BoxHeight
            txt.Width = BoxWidth
            txt.Multiline = True
        End Sub

        '마우스 드래그 이벤트 & 드레그가능Flag
        Private Sub Obj_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt.MouseMove
            If e.Button = MouseButtons.Left And dragEnable Then
                moveTo(sender)
                Console.WriteLine("New Position :  {0},{1}", sender.left, sender.top)

            End If
        End Sub

        '화면출력을 위해서 포인터 리턴가능
        Public Function getTextBoxReferece() As System.Windows.Forms.TextBox
            Return txt
        End Function

        '화면출력을 위해서 포인터 리턴가능
        Public Function getLabelReference() As System.Windows.Forms.Label
            Return lblroomnumber
        End Function

        '토픽과 박스 새로운 위치로 이동
        Public Sub setPosXY(_posx As Integer, _posy As Integer)
            Console.WriteLine("setposxy" & _posx & ", " & _posy)

            txt.Left = _posx
            txt.Top = _posy
            lblroomnumber.Left = txt.Left
            lblroomnumber.Top = txt.Top - TopicGap
            lblroomnumber.BackColor = Color.Transparent
            txt.Multiline = True


            PosX = _posx
            PosY = _posy
        End Sub

        '사용가능 색깔
        Public Sub setRoomFree()
            txt.BackColor = Color.LightGreen
        End Sub

        '사용중 색깔
        Public Sub setRoomUsing()
            txt.BackColor = Color.LightPink
        End Sub

        '거의 사용만료
        Public Sub setRoomFreeSoon()
            txt.BackColor = Color.LightYellow
        End Sub
    End Class

End Class