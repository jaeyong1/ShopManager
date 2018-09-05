Public Class UserControl_Settings
    Public secondScrDragEnable As Boolean = False

    Private Sub UserControl_Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        btn2ndScrDragEnable.BackColor = Color.Gray
        btn2ndScrDragEnable.BackColor = Color.LightGreen



    End Sub

    Private Sub btn2ndScrDragEnable_Click(sender As Object, e As EventArgs) Handles btn2ndScrDragEnable.Click
        If (secondScrDragEnable) Then
            'Enable -> Disable
            btn2ndScrDragEnable.BackColor = Color.LightGreen
            Form2ndMonitor.changeDragEnable(False)
            secondScrDragEnable = Not secondScrDragEnable
        Else
            'Disable -> Enable
            Form2ndMonitor.changeDragEnable(True)
            btn2ndScrDragEnable.BackColor = Color.LightPink
            secondScrDragEnable = Not secondScrDragEnable
        End If
    End Sub
End Class
