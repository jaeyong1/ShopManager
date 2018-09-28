Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Globalization

Public Class UserControl_RoomReservation

    Dim BindingSource1 As New BindingSource() '리스트 <-> 데이터그리드.소스

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click, Button1.Click
        Form2ndMonitor.numOfRooms = G_NumberOfRooms
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


    Private Sub UserControl_RoomReservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.WriteLine("타석예약화면 초기화")

        '타석번호 콤보박스 초기화
        ComboRoomNumber.Items.Clear()
        For i = 1 To (G_NumberOfRooms)
            ComboRoomNumber.Items.Add(i & "") '타석번호를 문자열로 생성
        Next

        BindingSource1.DataSource = lstRoomReservation
        DataGridView1.DataSource = BindingSource1
    End Sub

    Private Sub btnAddReserv_Click(sender As Object, e As EventArgs) Handles btnAddReserv.Click
        'UI 입력확인
        Console.WriteLine("-" & ComboRoomNumber.Text & "-")

        If ComboRoomNumber.Text = "" Then
            MsgBox("타석번호를 확인해주세요.")
            ComboRoomNumber.Select()
            Exit Sub
        End If

        If ComboRoomNumber.Items.Contains(ComboRoomNumber.Text & "") = False Then 'ps.타석번호를 문자열로 생성
            MsgBox("타석번호가 존재하지 않는 값입니다.")
            Exit Sub
        End If

        If txtCustomerID.Text = "" Then
            MsgBox("회원정보를 확인해 주세요")
            txtCustomerID.Select()
            Exit Sub
        End If

        If txtEmployeeId.Text = "" Then
            MsgBox("담당직원을 확인해 주세요")
            txtEmployeeId.Select()
            Exit Sub
        End If

        If lstStartTime.SelectedIndex = -1 Then
            MsgBox("시작시간을 선택해 주세요")
            Exit Sub
        End If

        If comboUsageTime.Items.Contains(comboUsageTime.Text & "") = False Then
            MsgBox("사용시간이 존재하지 않는 값입니다.")
            comboUsageTime.Select()
            Exit Sub
        End If

        '시작시간 변환
        Dim starthour_1 As String = lstStartTime.Items(lstStartTime.SelectedIndex).replace(":00", "")
        Dim starthour_num As Integer = 0
        If lstStartTime.Items(lstStartTime.SelectedIndex).Contains("오전") Then
            starthour_1 = starthour_1.Replace("오전 ", "").Trim()
            starthour_num = Integer.Parse(starthour_1)

        Else
            starthour_1 = starthour_1.Replace("오후 ", "").Trim()
            starthour_num = Integer.Parse(starthour_1) + 12 '오후면 12시간 추가
        End If

        Dim startTime As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                 starthour_num,  'hours 
                                                 0, 'minutes
                                                 0, 'seconds
                                                 0) 'milliseconds


        '종료시간 변환
        Dim usageTime_1 As String = comboUsageTime.Text.Replace(" 시간", "").Trim()
        Dim usageTime_num As Integer = Integer.Parse(usageTime_1)
        Dim endTime As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                 starthour_num + usageTime_num,  'hours 
                                                 0, 'minutes
                                                 0, 'seconds
                                                 0) 'milliseconds




        'DB Update
        '타석예약 가능한지 DB 확인
        Dim isValid As Boolean = True

        For i = 0 To lstRoomReservation.Count - 1
            If lstRoomReservation.Item(i).isValidNewReservation(
                ComboRoomNumber.Text,
                startTime.ToString,
                endTime.ToString) = False Then
                isValid = False
                '예약불가할 경우 에러팝업

                MsgBox("가용한 시간이 아닙니다. 예약상태를 확인해주세요." & lstRoomReservation.Item(i).회원 & "님의 " &
                    lstRoomReservation.Item(i).타석번호 & "번방 예약과 겹칩니다.")
                Exit Sub
            End If
        Next i
        Console.WriteLine("추가정보 isValid ? " & isValid)



        '예약추가 
        lstRoomReservation.Add(New clsRoomReservation(lstRoomReservation.Count & "",
                                                       ComboRoomNumber.Text,
                                                      "대기중",
                                                      txtCustomerID.Text,
                                                      txtEmployeeId.Text,
                                                      startTime.ToString,
                                                      endTime.ToString))

        '리스트소팅

        'Datagrid 화면갱신
        BindingSource1.ResetBindings(False)


    End Sub
End Class
