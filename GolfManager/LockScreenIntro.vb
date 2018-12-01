Imports GolfManager

Public Class LockScreenIntro
    Public Shared Property fom1pointer As Form1
    Public Shared hasPointer As Boolean = False

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim yn = MsgBox("설정취소로 저장합니까?", vbYesNo)
        If yn = vbYes Then
            My.Settings.IsRoomComputer = False
            My.Settings.Save()
            Timer1.Enabled = False
            MsgBox("프로그램을 재시작 해주세요.")
            fom1pointer.Close()
            Me.Close()
        End If
    End Sub

    Private Sub LockScreenIntro_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Label2.Text = My.Settings.MyRoomNumber
        Me.TopMost = True
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Value = ProgressBar1.Value - 1

        If ProgressBar1.Value = 0 Then
            Timer1.Enabled = False
            Local_WaitingCompleteByUser_AsRoomComputer = True
            Me.Close()
        End If

    End Sub


    Friend Shared Sub setMainFormPointer(form1 As Form1)
        fom1pointer = form1
        hasPointer = True
    End Sub
End Class