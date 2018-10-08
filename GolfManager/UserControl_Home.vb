Public Class UserControl_Home


    Private Sub UserControl_Home_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim nowinfo As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                          DateTime.Now.Hour,  'hours 
                                          DateTime.Now.Minute, 'minutes
                                          0, 'seconds
                                          0) 'milliseconds

        lblHellowithToday.Text = "안녕하세요. 오늘은 " + nowinfo.ToString("yyyy년 MM월 dd일 입니다.")
    End Sub
End Class
