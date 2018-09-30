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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

End Class
