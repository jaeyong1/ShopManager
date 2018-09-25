﻿Public Class UserControl_RoomReservation
    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click, Button1.Click
        Form2ndMonitor.numOfRooms = 10
        Form2ndMonitor.Show()

        '문자열 세팅 샘플코드
        For i = 0 To (Form2ndMonitor.dynamicBoxList.Count - 1)
            Form2ndMonitor.dynamicBoxList.Item(i).setTopicText((i + 1) & "번")
            Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("내용" & (i + 1))
        Next

        '배경색변경 샘플코드
        Form2ndMonitor.dynamicBoxList.Item(1).setRoomFree()
        Form2ndMonitor.dynamicBoxList.Item(1).setBoxText("미사용")


        Form2ndMonitor.dynamicBoxList.Item(2).setRoomUsing()
        Form2ndMonitor.dynamicBoxList.Item(2).setBoxText("사용중" + vbCrLf + "58:45")

        Form2ndMonitor.dynamicBoxList.Item(3).setRoomFreeSoon()
        Form2ndMonitor.dynamicBoxList.Item(3).setBoxText("거의끝나감" + vbCrLf + "02:23")

    End Sub
End Class
