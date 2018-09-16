Imports System.IO 'xml로 직렬화
Imports System.Runtime.Serialization.Formatters.Binary 'xml로 직렬화


Public Class Form2ndMonitor

    Public boxfont = New Font("Sans Serif", 20, FontStyle.Regular) ' BoxFontSize
    Public topicfont = New Font("Sans Serif", 18, FontStyle.Regular) 'TopicFontSize
    Public AL2 As New List(Of dynamicTextBox)



    Private Sub Form2ndMonitor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 수량만큼 생성
        Dim numOfRooms As Integer = 5
        Console.WriteLine("타석표시기 동적생성 {0}개", numOfRooms)
        For i = 1 To numOfRooms
            Dim a As New dynamicTextBox()
            Me.Controls.Add(a.getTextBoxReferece())
            Me.Controls.Add(a.getLabelReference())

            AL2.Add(a)
        Next


        '문자열 세팅
        For i = 0 To (AL2.Count - 1)
            'CType(AL.Item(i), dynamicTextBox).setTopicText("타석" & i)
            'CType(AL.Item(i), dynamicTextBox).setBoxText("타석" & i)
            '
            AL2.Item(i).setTopicText("타석" & i)
            AL2.Item(i).setBoxText("타석" & i)

        Next
        AL2.Item(1).setRoomFree()
        AL2.Item(1).setBoxText("미사용")


        AL2.Item(2).setRoomUsing()
        AL2.Item(2).setBoxText("사용중" + vbCrLf + "58:45")

        AL2.Item(3).setRoomFreeSoon()
        AL2.Item(3).setBoxText("거의끝나감" + vbCrLf + "02:23")

        '화면구성을 직렬화하여 XML로 저장
        Dim writer As New System.Xml.Serialization.XmlSerializer(GetType(List(Of dynamicTextBox)))
        Dim file As New System.IO.StreamWriter("RoomServationUISerialization.xml")
        writer.Serialize(file, AL2)
        file.Close()
    End Sub

    '드래그 가능여부 전체변경
    Public Sub changeDragEnable(en As Boolean)
        For i = 1 To AL2.Count
            AL2.Item(i).setDragEnable(en)
        Next
    End Sub


    '토픽과 텍스트박스를 하나로 묶어서 표시단위 클래스
    Public Class dynamicTextBox
        Private Off As Point

        Private WithEvents txt As New System.Windows.Forms.TextBox() 'Data
        Private lblroomnumber As New System.Windows.Forms.Label() 'Topic
        Public PosX As Integer
        Public PosY As Integer
        Public TopicFontSize As Integer = 18
        Public TopicGap As Integer = 30
        Public BoxHeight As Integer = 100
        Public BoxWidth As Integer = 150
        Public BoxFontSize As Integer = 20
        Private dragEnable As Boolean = True

        Public Sub setTopicText(str As String)
            '토픽 문자열
            lblroomnumber.Text = str

            '토픽 폰트
            'lblroomnumber.Font = topicfont
        End Sub

        Public Sub setBoxText(str As String)
            '박스 문자열
            txt.Text = str

            '박스 폰트
            ' txt.Font = boxfont
            txt.TextAlign = HorizontalAlignment.Center
        End Sub

        '드래그 가능
        Public Sub setDragEnable(en As Boolean)

            dragEnable = en
        End Sub

        '좌표 리턴
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