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
