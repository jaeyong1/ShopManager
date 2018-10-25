Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click, Button2.Click, Button3.Click, Button4.Click, Button5.Click, Button6.Click, Button7.Click, Button8.Click, Button9.Click, Button10.Click, Button11.Click
        menubar.Top = sender.Top
        Dim clickedbutton As Button = CType(sender, Button)
        Console.WriteLine(Trim(clickedbutton.Text))

        Select Case Trim(clickedbutton.Text)
            Case "Home"
                UserControl_Home1.BringToFront()

            Case "타석예약관리"
                UserControl_RoomReservation1.BringToFront()

            Case "고객정보관리"
                UserControl_customer_main1.BringToFront()


        End Select




    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim h As System.Net.IPHostEntry = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName)

        For i = 0 To (h.AddressList.Length - 1)
            If "192.168.0.50".Equals(h.AddressList.GetValue(i).ToString()) Then
                Console.WriteLine("---------------------------------------")
                Console.WriteLine("박재용 PC에서 실행중. 웹URL을 로컬로 변경")
                Console.WriteLine("---------------------------------------")
                btnLocalWebserverIP.Visible = True
                G_WebServerURL = JYP_G_WebServerURL

            End If
        Next i


        '데이터파일 폴더생성
        Try
            My.Computer.FileSystem.CreateDirectory(G_RootDir) '기존폴더있어도 throw안함
            My.Computer.FileSystem.CreateDirectory(G_SettingsDir) '기존폴더있어도 throw안함
            My.Computer.FileSystem.CreateDirectory(G_BottomBannerImgDir) '기존폴더있어도 throw안함

        Catch ex As Exception
            MsgBox(G_RootDir & " 또는 하위폴더를 정상적으로 생성할 수 없습니다. 프로그램의 정상동작에 문제가 발생할 수 있습니다.")
        End Try

    End Sub

    '웹서버 주소를 로컬 -> cafe24로 변경
    Private Sub btnLocalWebserverIP_Click(sender As Object, e As EventArgs) Handles btnLocalWebserverIP.Click
        G_WebServerURL = "http://puttingone.cafe24.com/"
        btnLocalWebserverIP.Text = "puttingone.cafe24로 변경됨"
    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click

        Dim result As Integer = MessageBox.Show("프로그램을 종료하시겠습니까?", "종료", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            Me.Close()
        End If

    End Sub

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        UserControl_Settings1.BringToFront()

    End Sub


    '전체Form 마우스드래그로 이동
    Public MoveForm As Boolean
    Public MoveForm_MousePosition As Point

    '전체Form 마우스드래그로 이동
    Public Sub MoveForm_MouseDown(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseDown ' Add more handles here (Example: PictureBox1.MouseDown)

        If e.Button = MouseButtons.Left Then
            MoveForm = True
            Me.Cursor = Cursors.NoMove2D
            MoveForm_MousePosition = e.Location
        End If

    End Sub
    '전체Form 마우스드래그로 이동
    Public Sub MoveForm_MouseMove(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseMove ' Add more handles here (Example: PictureBox1.MouseMove)

        If MoveForm Then
            Me.Location = Me.Location + (e.Location - MoveForm_MousePosition)
        End If

    End Sub
    '전체Form 마우스드래그로 이동
    Public Sub MoveForm_MouseUp(sender As Object, e As MouseEventArgs) Handles _
    MyBase.MouseUp ' Add more handles here (Example: PictureBox1.MouseUp)

        If e.Button = MouseButtons.Left Then
            MoveForm = False
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

        Dim frmLoginDialogue As New FormLogin1

        frmLoginDialogue.ShowDialog()

    End Sub
End Class
