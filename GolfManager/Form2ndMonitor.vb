Imports System.IO 'xml로 직렬화
Imports System.Runtime.Serialization.Formatters.Binary 'xml로 직렬화




Public Class Form2ndMonitor
    Public SecondScreenDesignXMLFileName As String = "RoomServationUISerialization.xml"  '파일명

    Public dynamicBoxList As New List(Of dynamicTextBox) '타석UI 동적생성 리스트

    Public numOfRooms As Integer = 0 '이 계정에 허용된 타석개수

    Public CommonTopicFontSize As Integer = 18 '토픽 폰트크기
    Public CommonTopicGap As Integer = 30 '토픽~박스상단 간격
    Public CommonBoxHeight As Integer = 100 '박스높이
    Public CommonBoxWidth As Integer = 150 '박스넓이
    Public CommonBoxFontSize As Integer = 20 '박스글자 폰트크기


    Private Sub Form2ndMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 수량만큼 생성

        Console.WriteLine("타석표시기 동적생성 {0}개", numOfRooms)
        For i = 0 To numOfRooms - 1
            Dim a As New dynamicTextBox()
            Me.Controls.Add(a.getLabelReference()) '토픽
            Me.Controls.Add(a.getTextBoxReferece()) '박스
            a.setStyle(CommonTopicFontSize, CommonTopicGap, CommonBoxHeight, CommonBoxWidth, CommonBoxFontSize) '기본모양설정
            dynamicBoxList.Add(a) '향후관리를위해 객체리스트 만듬
        Next



        '화면구성을 직렬화하여 XML로 저장
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(List(Of dynamicTextBox)))
        Dim file As New System.IO.StreamWriter(SecondScreenDesignXMLFileName)
        writer.Serialize(file, dynamicBoxList)
        file.Close()
        file.Close()

        '화면구성을 XML에서 읽기
        Console.WriteLine("화면UI구성을 XML파일에서 읽기")
        Try
            Dim reader As New System.Xml.Serialization.XmlSerializer(GetType(List(Of dynamicTextBox)))
            Dim overview As List(Of dynamicTextBox)
            Dim file2 As New System.IO.StreamReader(SecondScreenDesignXMLFileName)

            overview = CType(reader.Deserialize(file2), List(Of dynamicTextBox))
            Console.WriteLine("File의 XML의 리스트아이템개수 :" & overview.Count)


            Console.WriteLine(overview.Item(1).PosX)
        Catch ex As Exception
            Console.WriteLine("################################################")
            Console.WriteLine(" 화면UI를 구성하는 XML파일을 읽는도중 오류가 발생.")
            Console.WriteLine("################################################")
        End Try




    End Sub

    '드래그 가능여부 전체변경
    Public Sub changeDragEnable(en As Boolean)
        For i = 0 To (dynamicBoxList.Count - 1)
            dynamicBoxList.Item(i).setDragEnable(en)
        Next
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

            '박스사이즈 
            txt.Height = BoxHeight
            txt.Width = BoxWidth
            txt.Multiline = True
        End Sub

        '마우스 드래그 이벤트 & 드레그가능Flag
        Private Sub Obj_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txt.MouseMove
            If e.Button = MouseButtons.Left And dragEnable Then
                moveTo(sender)
                Console.WriteLine("New Position : {0},{1}", sender.left, sender.top)

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

        '초기위치:(100,100)
        Private Sub txt_Invalidated(sender As Object, e As InvalidateEventArgs) Handles txt.Invalidated
            moveTo(sender)
            txt.Top = 100
            txt.Left = 100

            lblroomnumber.Left = sender.Left
            lblroomnumber.Top = sender.Top - TopicGap
            lblroomnumber.BackColor = Color.Transparent
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