Imports System.Windows.Forms
Imports System.Collections.Generic
Imports System.Globalization

Imports System.Linq
Imports System.Text
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json '수동설치 > Tools > NuGet Package Manager > Console > "PM> install-package Newtonsoft.json"
Imports Newtonsoft.Json.Linq '수동설치 > Tools > NuGet Package Manager > Console > "PM> install-package Newtonsoft.json"


Public Class UserControl_RoomReservation

    Dim BindingSource1 As New BindingSource() '리스트 <-> 데이터그리드.소스

    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        Form2ndMonitor.numOfRooms = G_NumberOfRooms
        Form2ndMonitor.Show()

        '문자열 세팅 샘플코드
        For i = 0 To (Form2ndMonitor.dynamicBoxList.Count - 1)
            Form2ndMonitor.dynamicBoxList.Item(i).setTopicText((i + 1) & "번")
            Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("내용" & (i + 1))
        Next

    End Sub

    '시작할때
    Private Sub UserControl_RoomReservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.WriteLine("타석예약화면 초기화")

        '타석번호 콤보박스 초기화
        ComboRoomNumber.Items.Clear()
        For i = 1 To (G_NumberOfRooms)
            ComboRoomNumber.Items.Add(i & "") '타석번호를 문자열로 생성
        Next

        BindingSource1.DataSource = lstRoomReservation
        DataGridView1.DataSource = BindingSource1

        refreshRoomReservationWithServer()

        '시작시간/종료시간 포맷
        timepickerStartTime.Format = DateTimePickerFormat.Custom
        timepickerStartTime.CustomFormat = "tt hh:mm"
        timepickerEndTime.Format = DateTimePickerFormat.Custom
        timepickerEndTime.CustomFormat = "tt hh:mm"

    End Sub


    'UI 입력확인
    Private Function checkReservationUI() As Boolean
        If ComboRoomNumber.Text = "" Then
            MsgBox("타석번호를 확인해주세요.")
            ComboRoomNumber.Select()
            Return False
        End If

        If ComboRoomNumber.Items.Contains(ComboRoomNumber.Text & "") = False Then 'ps.타석번호를 문자열로 생성
            MsgBox("타석번호가 존재하지 않는 값입니다.")
            Return False
        End If

        If txtCustomerID.Text = "" Then
            MsgBox("회원정보를 확인해 주세요")
            txtCustomerID.Select()
            Return False
        End If

        If txtEmployeeId.Text = "" Then
            MsgBox("담당직원을 확인해 주세요")
            txtEmployeeId.Select()
            Return False
        End If
        Return True
    End Function

    'UI 초기화
    Private Sub clearRoomReservUI()
        ComboRoomNumber.Text = ""
        txtCustomerID.Text = ""
        txtEmployeeId.Text = ""
        lstStartTime.SelectedIndex = -1
        txtCustomerName.Text = ""
        txtRoomState.Text = ""
        lblRoomReservIndex.Text = ""
    End Sub

    '타석예약 추가버튼 클릭
    Private Sub btnAddReserv_Click(sender As Object, e As EventArgs) Handles btnAddReserv.Click

        'UI 채우기 확인
        If checkReservationUI() = False Then
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
        Dim endTime As DateTime
        Try
            endTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                 starthour_num + usageTime_num,  'hours 
                                                 0, 'minutes
                                                 0, 'seconds
                                                 0) 'milliseconds
        Catch ex As System.ArgumentOutOfRangeException
            endTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                 23,  'hours 
                                                 59, 'minutes
                                                 0, 'seconds
                                                 0) 'milliseconds
        End Try


        'DB Update  < 서버
        If refreshRoomReservationWithServer() = False Then
            Exit Sub
        End If

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

        '시작시간~종료시간사이에 현재시간이 존재 > "사용중"으로 변경 문의

        '예약추가 > 서버
        addRoomReservationToServer(
            New clsRoomReservation(lstRoomReservation.Count & "",
                                                       ComboRoomNumber.Text,
                                                      "대기중",
                                                      txtCustomerID.Text,
                                                      txtEmployeeId.Text,
                                   Format(startTime, "HH:mm"), Format(endTime, "HH:mm")
                                                      ))


        'DB Update  < 서버
        If refreshRoomReservationWithServer() = False Then
            Exit Sub
        End If

        MsgBox("추가되었습니다")
        clearRoomReservUI()


    End Sub

    '타석사용시작
    Private Sub btnSetRoomStart_Click(sender As Object, e As EventArgs) Handles btnSetRoomStart.Click
        'UI 채우기 확인
        If checkReservationUI() = False Then
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

        '삭제전 업데이트
        'DB Update  < 서버
        If refreshRoomReservationWithServer() = False Then
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
        Dim endTime As DateTime        '타석예약 가능한지 DB 확인
        Try
            endTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                 starthour_num + usageTime_num,  'hours 
                                                 0, 'minutes
                                                 0, 'seconds
                                                 0) 'milliseconds
        Catch ex As System.ArgumentOutOfRangeException
            endTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                 23,  'hours 
                                                 59, 'minutes
                                                 0, 'seconds
                                                 0) 'milliseconds
        End Try

        Dim isValid As Boolean = True
        For i = 0 To lstRoomReservation.Count - 1
            If lstRoomReservation.Item(i).isValidNewReservation(
                ComboRoomNumber.Text,
                startTime.ToString,
                endTime.ToString) = False Then

                If lstRoomReservation.Item(i).회원.Equals(txtCustomerID.Text) Then
                    Console.WriteLine("스케쥴겹치지만 내스케쥴이므로 무시")
                    Exit For
                End If
                isValid = False

                '예약불가할 경우 에러팝업
                MsgBox("가용한 시간이 아닙니다. 예약상태를 확인해주세요." & lstRoomReservation.Item(i).회원 & "님의 " &
                    lstRoomReservation.Item(i).타석번호 & "번방 예약과 겹칩니다.")
                Exit Sub

            End If
        Next i
        Console.WriteLine("추가정보 isValid ? " & isValid)

        Dim yn = MsgBox(txtCustomerID.Text & "님께서 " & ComboRoomNumber.Text & "번타석. " & Format(startTime, "HH:mm") & "부터 사용시작합니다.", MsgBoxStyle.YesNo)
        If yn = vbNo Then
            Exit Sub
        End If

        '대기회원에서 선택했으면 지움(옵션)
        If lblRoomReservIndex.Text <> "" Then
            For j = 0 To (lstRoomReservation.Count - 1)
                If lstRoomReservation.Item(j).상태.Equals("대기중") And
                    lstRoomReservation.Item(j).고유Index.Equals(lblRoomReservIndex.Text) Then
                    '서버에서 예약삭제
                    deleteRoomReservationToServer(
                        New clsRoomReservation(lstRoomReservation.Item(j).고유Index,
                                               lstRoomReservation.Item(j).타석번호,
                                               lstRoomReservation.Item(j).상태,
                                               lstRoomReservation.Item(j).회원,
                                               lstRoomReservation.Item(j).담당직원,
                                               lstRoomReservation.Item(j).시작시간,
                                               lstRoomReservation.Item(j).종료시간)
                                               )

                    '삭제후 업데이트
                    'DB Update  < 서버
                    If refreshRoomReservationWithServer() = False Then
                        Exit Sub
                    End If
                    lblRoomReservIndex.Text = ""
                    Exit For
                End If
            Next j
        End If


        '예약추가 > 서버
        addRoomReservationToServer(
            New clsRoomReservation(lstRoomReservation.Count & "",
                                                       ComboRoomNumber.Text,
                                                      "사용중",
                                                      txtCustomerID.Text,
                                                      txtEmployeeId.Text,
                                   Format(startTime, "HH:mm"), Format(endTime, "HH:mm")
                                                      ))


        'DB Update  < 서버
        If refreshRoomReservationWithServer() = False Then
            Exit Sub
        End If

        MsgBox("사용시작 설정완료")
        clearRoomReservUI()

    End Sub


    '(시간선택없이)대기추가 버튼 클릭
    Private Sub btnAddWaiting_Click(sender As Object, e As EventArgs) Handles btnAddWaiting.Click
        'UI 채우기 확인
        If checkReservationUI() = False Then
            Exit Sub
        End If

        '예약추가 > 서버
        addRoomReservationToServer(
            New clsRoomReservation(lstRoomReservation.Count & "",
                                   ComboRoomNumber.Text,
                                   "대기중",
                                   txtCustomerID.Text,
                                   txtEmployeeId.Text,
                                   "00:00",
                                   "00:00")
                                   )


        'DB Update  < 서버
        If refreshRoomReservationWithServer() = False Then
            Exit Sub
        End If

        MsgBox("추가되었습니다")
        clearRoomReservUI()

    End Sub

    '서버에 타석예약 추가
    Private Sub addRoomReservationToServer(rr As clsRoomReservation)

        Dim clsRoomReservationJSON1 = New clsRoomReservationJSON()
        clsRoomReservationJSON1.reservedSchduleId = 0
        clsRoomReservationJSON1.reservedRoomNumber = rr.타석번호
        clsRoomReservationJSON1.reservedState = rr.상태
        clsRoomReservationJSON1.custCode = rr.회원
        clsRoomReservationJSON1.emCode = rr.담당직원
        clsRoomReservationJSON1.reservedStartTime = rr.시작시간
        clsRoomReservationJSON1.reservedEndTime = rr.종료시간
        Dim JsonData As String = JsonConvert.SerializeObject(clsRoomReservationJSON1)
        Console.WriteLine("Request JsonData:{0}", JsonData)
        Console.WriteLine("")
        Dim myRequest As HttpWebRequest = PostJSON(G_WebServerURL & "testver_insertroomreservation", JsonData)
        Dim response As String = GetResponse(myRequest)
        Console.WriteLine("Response of Request:{0}", response)

    End Sub

    '서버에 타석예약 삭제
    Private Sub deleteRoomReservationToServer(rr As clsRoomReservation)

        Dim clsRoomReservationJSON1 = New clsRoomReservationJSON()
        clsRoomReservationJSON1.reservedSchduleId = rr.고유Index
        clsRoomReservationJSON1.reservedRoomNumber = rr.타석번호 'notuse
        clsRoomReservationJSON1.reservedState = rr.상태 'notuse
        clsRoomReservationJSON1.custCode = rr.회원 'notuse
        clsRoomReservationJSON1.emCode = rr.담당직원 'notuse
        clsRoomReservationJSON1.reservedStartTime = rr.시작시간 'notuse
        clsRoomReservationJSON1.reservedEndTime = rr.종료시간 'notuse
        Dim JsonData As String = JsonConvert.SerializeObject(clsRoomReservationJSON1)
        Console.WriteLine("Request JsonData:{0}", JsonData)
        Console.WriteLine("")
        Dim myRequest As HttpWebRequest = PostJSON(G_WebServerURL & "testver_deleteroomreservation", JsonData)
        Dim response As String = GetResponse(myRequest)
        Console.WriteLine("Response of Request:{0}", response)

    End Sub


    '서버에 타석예약 변경(PK유지)
    Private Sub updateRoomReservationToServer(rr As clsRoomReservation)

        Dim clsRoomReservationJSON1 = New clsRoomReservationJSON()
        clsRoomReservationJSON1.reservedSchduleId = rr.고유Index
        clsRoomReservationJSON1.reservedRoomNumber = rr.타석번호
        clsRoomReservationJSON1.reservedState = rr.상태
        clsRoomReservationJSON1.custCode = rr.회원
        clsRoomReservationJSON1.emCode = rr.담당직원
        clsRoomReservationJSON1.reservedStartTime = rr.시작시간
        clsRoomReservationJSON1.reservedEndTime = rr.종료시간
        Dim JsonData As String = JsonConvert.SerializeObject(clsRoomReservationJSON1)
        Console.WriteLine("Request JsonData:{0}", JsonData)
        Console.WriteLine("")
        Dim myRequest As HttpWebRequest = PostJSON(G_WebServerURL & "testver_updateroomreservation", JsonData)
        Dim response As String = GetResponse(myRequest)
        Console.WriteLine("Response of Request:{0}", response)

    End Sub



    '서버에서 타석예약현황 조회&업데이트
    Private Function refreshRoomReservationWithServer()

        Dim JsonData As String = "{""type"":""Point""}" '보낼JSON데이터(Dummy)
        Dim myRequest As HttpWebRequest = PostJSON(G_WebServerURL & "testver_getroomreservation", JsonData)
        Dim response As String = GetResponse(myRequest)
        Console.WriteLine("Response of Request:{0}", response)

        'JSON파싱->화면
        Dim jsonObject As JObject
        Try
            jsonObject = JObject.Parse(response) 'Object 만 파싱 한다.
        Catch ex As Exception
            MsgBox("서버에서 정보를 가져오는데 실패했습니다.")
            Return False

        End Try

        'Response of Request:{"success":true,"list":[{"emCode":"E00000004","reservedState":"사용중","custCode":"VIP0000001","reservedSchduleId":1,"reservedStartTime":"2018-09-29 22:37:31","reservedEndTime":"2018-09-29 22:37:31","reservedRoomNumber":"1"},{"emCode":"한프로","reservedState":"사용중","custCode":"김나다","reservedSchduleId":3,"reservedStartTime":"2018-09-29 22:43:58","reservedEndTime":"2018-09-29 22:43:58","reservedRoomNumber":"2"},{"emCode":"한프로","reservedState":"사용중","custCode":"김나다","reservedSchduleId":4,"reservedStartTime":"2018-09-29 22:44:25","reservedEndTime":"2018-09-29 22:44:25","reservedRoomNumber":"2"}],"total_count":3}

        Console.WriteLine("success:" & jsonObject.SelectToken("success").ToString)
        Dim jsonSuccess As Boolean '가져오기 성공
        If jsonObject.SelectToken("success").ToString = "True" Then
            jsonSuccess = True
        Else
            jsonSuccess = False
        End If


        If jsonSuccess Then
            Console.WriteLine("total_count:" & jsonObject.SelectToken("total_count").ToString)
            Dim jsonListstr As String = jsonObject.SelectToken("list").ToString
            'Console.WriteLine("list:" & jsonListstr)

            Dim list_deserializedRoomReservations As List(Of clsRoomReservationJSON) = JsonConvert.DeserializeObject(Of List(Of clsRoomReservationJSON))(jsonListstr)
            lstRoomReservation.Clear()
            For Each oneRRitem As clsRoomReservationJSON In list_deserializedRoomReservations
                'Console.WriteLine("id:" & oneRRitem.reservedSchduleId & ", room:" & oneRRitem.reservedRoomNumber)
                lstRoomReservation.Add(New clsRoomReservation(oneRRitem.reservedSchduleId, oneRRitem.reservedRoomNumber, oneRRitem.reservedState, oneRRitem.custCode, oneRRitem.emCode, oneRRitem.reservedStartTime, oneRRitem.reservedEndTime))
            Next
            'sort 
            lstRoomReservation.Sort()
            Me.DataGridView1.Columns("고유index").Visible = False
            BindingSource1.ResetBindings(False)
        End If
        timer_cnt = 61 'force reset cnt
        Return True
    End Function

    '새로고침 버튼클릭
    Private Sub btnRoomReservRefresh_Click(sender As Object, e As EventArgs) Handles btnRoomReservRefresh.Click
        refreshRoomReservationWithServer()
    End Sub

    '1초마다 Tick
    Private timer_cnt As Integer = 61
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        timer_cnt = timer_cnt - 1
        btnRoomReservRefresh.Text = "새로고침(" & timer_cnt & "초후)"
        If (timer_cnt = 0) Then
            refreshRoomReservationWithServer()
            timer_cnt = 61
        End If

        '주기적으로 서버로부터 테이블 업데이트
        update2ndScreen()
    End Sub

    '타석스크린 업데이트
    Private Sub update2ndScreen()
        Me.lst5min.Items.Clear()
        lstWaitingCust.Items.Clear()
        For i = 0 To (Form2ndMonitor.dynamicBoxList.Count - 1)
            '토픽
            Form2ndMonitor.dynamicBoxList.Item(i).setTopicText((i + 1) & "번")

            '내용 
            Dim contents As String = "내용" & (i + 1)
            Dim isSetted As Boolean = False
            Dim waiting As Integer = 0

            '타석상태 결정순서
            '미사용 > 사용중 > 곧끝남 > 종료지연(시간고려 추가)

            For j = 0 To (lstRoomReservation.Count - 1)
                '대기인원 카운트
                If lstRoomReservation.Item(j).타석번호 = (i + 1) And lstRoomReservation.Item(j).상태.Equals("대기중") Then
                    '시간미정인경우만 세컨드스크린 숫자표시
                    If lstRoomReservation.Item(j).시작시간 = "00:00" Then
                        waiting = waiting + 1
                    End If
                    '시간정해져있어도 관리화면에는 표시
                    lstWaitingCust.Items.Add("타석 " & lstRoomReservation.Item(j).타석번호 & " / " &
                                             lstRoomReservation.Item(j).시작시간 & " / " &
                                             lstRoomReservation.Item(j).회원 & "님 대기중")
                End If
            Next j

            For j = 0 To (lstRoomReservation.Count - 1)
                '[사용중] 남은시간 표시
                If lstRoomReservation.Item(j).타석번호 = (i + 1) And lstRoomReservation.Item(j).상태.Equals("사용중") Then
                    Dim endTime As DateTime
                    endTime = DateTime.Parse(lstRoomReservation.Item(j).종료시간)
                    Dim timediff As TimeSpan = endTime - DateTime.Now
                    contents = Format(timediff.Hours, "0").Replace("-", "") &
                        Format(timediff.Minutes, ":00").Replace("-", "") _
                    '  & Format(timediff.Seconds, ":00").Replace("-", "")  '초 표시 생략


                    '5분이하 : [끝나감] 색깔
                    If timediff.TotalMinutes >= 0 And timediff.TotalMinutes <= 5.0 Then
                        Form2ndMonitor.dynamicBoxList.Item(i).setRoomFreeSoon()
                        Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("끝나감" + vbCrLf + contents + vbCrLf + Format(waiting, "대기 0명"))
                        Me.lst5min.Items.Add("타석 " & lstRoomReservation.Item(j).타석번호 & " / " & Format(timediff.Minutes, "0") & "분남음")

                    ElseIf timediff.TotalMinutes < 0 Then '시간초과/종료지연
                        Form2ndMonitor.dynamicBoxList.Item(i).setRoomFreeSoon()
                        Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("종료지연" + vbCrLf + contents + vbCrLf + Format(waiting, "대기 0명"))
                        Me.lst5min.Items.Add("타석 " & lstRoomReservation.Item(j).타석번호 & " / " & Format(-timediff.TotalMinutes, "0") & "분 시간초과")

                    Else '[사용중]색깔
                        Form2ndMonitor.dynamicBoxList.Item(i).setRoomUsing()
                        Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("사용중" + vbCrLf + contents + vbCrLf + Format(waiting, "대기 0명"))
                    End If



                    isSetted = True '뭔가 변경함
                End If


            Next
            '[사용중] 아닌경우
            If isSetted = False Then
                Form2ndMonitor.dynamicBoxList.Item(i).setRoomFree()
                Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("미사용")
            End If
        Next
    End Sub


    '대기회원 클릭 -> 예약화면으로 복사
    Private Sub lstWaitingCust_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstWaitingCust.SelectedIndexChanged
        If lstWaitingCust.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim strWaitingInfo As String = lstWaitingCust.SelectedItem
        strWaitingInfo = strWaitingInfo.Replace("타석 ", "")
        strWaitingInfo = strWaitingInfo.Replace("님 대기중", "")

        'Console.WriteLine(strWaitingInfo)
        Dim words As String() = strWaitingInfo.Split(New Char() {" / "})
        clearRoomReservUI()
        Console.WriteLine(words.Length)
        Dim selectedRoomNum As String = words.ToList.Item(0).Trim()

        Dim selectedStartTime As String = words.ToList.Item(2).Trim()
        Dim selectedCustName As String = words.ToList.Item(4).Trim()

        For j = 0 To (lstRoomReservation.Count - 1)
            If lstRoomReservation.Item(j).타석번호 = selectedRoomNum And
                    lstRoomReservation.Item(j).시작시간 = selectedStartTime And
                    lstRoomReservation.Item(j).회원 = selectedCustName Then

                displayReservationInfo(lstRoomReservation.Item(j).고유Index)
                gridCellSelect(lstRoomReservation.Item(j).고유Index)

            End If
        Next j

    End Sub


    '대기인원 더블클릭으로 삭제
    Private Sub lstWaitingCust_DoubleClick(sender As Object, e As EventArgs) Handles lstWaitingCust.DoubleClick
        If lstWaitingCust.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim nSelectedIndex = lstWaitingCust.SelectedIndex
        Dim strWaitingInfo As String = lstWaitingCust.SelectedItem
        Dim yesno = MsgBox(strWaitingInfo & "을 취소하시겠습니까?", vbYesNo)

        strWaitingInfo = strWaitingInfo.Replace("타석 ", "")
        strWaitingInfo = strWaitingInfo.Replace("님 대기중", "")

        'Console.WriteLine(strWaitingInfo)
        Dim words As String() = strWaitingInfo.Split(New Char() {" / "})

        Console.WriteLine(words.Length)
        Dim selectedRoomNum As String = words.ToList.Item(0).Trim()
        Dim selectedStartTime As String = words.ToList.Item(2).Trim()
        Dim selectedCustName As String = words.ToList.Item(4).Trim()


        If yesno = MsgBoxResult.Yes Then
            '정보검색
            For j = 0 To (lstRoomReservation.Count - 1)
                If lstRoomReservation.Item(j).타석번호 = selectedRoomNum And
                        lstRoomReservation.Item(j).시작시간 = selectedStartTime And
                        lstRoomReservation.Item(j).회원 = selectedCustName Then


                    '서버에서 예약삭제
                    deleteRoomReservationToServer(
                        New clsRoomReservation(lstRoomReservation.Item(j).고유Index,
                                               lstRoomReservation.Item(j).타석번호,
                                               lstRoomReservation.Item(j).상태,
                                               lstRoomReservation.Item(j).회원,
                                               lstRoomReservation.Item(j).담당직원,
                                               lstRoomReservation.Item(j).시작시간,
                                               lstRoomReservation.Item(j).종료시간)
                                               )

                    '삭제후 업데이트
                    refreshRoomReservationWithServer()
                    Exit Sub
                End If
            Next j
        End If

    End Sub

    '5분전/시간초과 리스트 클릭
    Private Sub lst5min_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst5min.SelectedIndexChanged
        If lst5min.SelectedIndex = -1 Then
            Exit Sub
        End If

        '로컬변수
        Dim nSelectedIndex = lst5min.SelectedIndex
        Dim strWaitingInfo As String = lst5min.SelectedItem
        strWaitingInfo = strWaitingInfo.Replace("타석 ", "")
        Dim words As String() = strWaitingInfo.Split(New Char() {" / "})
        Dim selectedRoomNum As String = words.ToList.Item(0).Trim()

        'DB Update  < 서버
        If refreshRoomReservationWithServer() = False Then
            Exit Sub
        End If

        '정보검색
        For j = 0 To (lstRoomReservation.Count - 1)
            If lstRoomReservation.Item(j).타석번호 = selectedRoomNum And
                lstRoomReservation.Item(j).상태.Equals("사용중") Then

                displayReservationInfo(lstRoomReservation.Item(j).고유Index)
                gridCellSelect(lstRoomReservation.Item(j).고유Index)
                comboUsageTime.Text = ""
                Exit Sub
            End If
        Next j

    End Sub

    '사용종료 클릭
    Private Sub btnSetRoomEnd_Click(sender As Object, e As EventArgs) Handles btnSetRoomEnd.Click
        If lblRoomReservIndex.Text = "" Then
            MsgBox("사용종료할 회원을 다시 선택해주세요")
            clearRoomReservUI()
            Exit Sub
        End If

        Dim end고유Index As String = lblRoomReservIndex.Text
        Dim realEndTime As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                  DateTime.Now.Hour,  'hours 
                                                  DateTime.Now.Minute, 'minutes
                                                  0, 'seconds
                                                  0) 'milliseconds

        Dim strRealEndTime As String = realEndTime.ToString("HH:mm")


        '정보검색
        For j = 0 To (lstRoomReservation.Count - 1)
            If lstRoomReservation.Item(j).고유Index.Equals(end고유Index) Then
                lstRoomReservation.Item(j).종료시간 = strRealEndTime
                lstRoomReservation.Item(j).상태 = "사용완료"

                '서버에서 예약 업데이트(종료로)
                updateRoomReservationToServer(lstRoomReservation.Item(j))

                '입력화면정리
                clearRoomReservUI()

                '삭제후 업데이트
                refreshRoomReservationWithServer()
                Exit Sub
            End If
        Next j
    End Sub

    '시작시간 선택함수
    Private Sub selectStartTimeUI(startTime As String)
        Console.WriteLine("selectStartTimeUI>" & startTime)

        For k = 0 To (lstStartTime.Items.Count - 1)
            If startTime.Equals("06:00") And lstStartTime.Items(k).Equals("오전 6:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("07:00") And lstStartTime.Items(k).Equals("오전 7:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("08:00") And lstStartTime.Items(k).Equals("오전 8:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("09:00") And lstStartTime.Items(k).Equals("오전 9:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("10:00") And lstStartTime.Items(k).Equals("오전 10:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("11:00") And lstStartTime.Items(k).Equals("오전 11:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("12:00") And lstStartTime.Items(k).Equals("오전 12:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("13:00") And lstStartTime.Items(k).Equals("오후 1:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("14:00") And lstStartTime.Items(k).Equals("오후 2:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("15:00") And lstStartTime.Items(k).Equals("오후 3:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("16:00") And lstStartTime.Items(k).Equals("오후 4:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("17:00") And lstStartTime.Items(k).Equals("오후 5:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("18:00") And lstStartTime.Items(k).Equals("오후 6:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("19:00") And lstStartTime.Items(k).Equals("오후 7:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("20:00") And lstStartTime.Items(k).Equals("오후 8:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("21:00") And lstStartTime.Items(k).Equals("오후 9:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("22:00") And lstStartTime.Items(k).Equals("오후 10:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals("23:00") And lstStartTime.Items(k).Equals("오후 11:00") Then
                lstStartTime.SetSelected(k, True) : Exit Sub
            ElseIf startTime.Equals(lstStartTime.Items(k)) Then
                '입력이랑이름같으면
                lstStartTime.SetSelected(k, True) : Exit Sub
            End If


        Next

        '못찾으면
        lstStartTime.SelectedIndex = -1
    End Sub

    '화면입력초기화 버튼클릭
    Private Sub btnInitUI_Click(sender As Object, e As EventArgs) Handles btnInitUI.Click
        '입력화면정리
        clearRoomReservUI()
    End Sub

    '예약의 고유index(PK)로 예약상황 표시
    Private Sub displayReservationInfo(_예약고유index As String)
        '정보검색
        For j = 0 To (lstRoomReservation.Count - 1)
            If lstRoomReservation.Item(j).고유Index.Equals(_예약고유index) Then

                lblRoomReservIndex.Text = _예약고유index
                ComboRoomNumber.Text = lstRoomReservation.Item(j).타석번호
                txtCustomerID.Text = lstRoomReservation.Item(j).회원
                txtCustomerName.Text = "-"
                txtEmployeeId.Text = "-"


                If lstRoomReservation.Item(j).시작시간.Equals("00:00") Then
                    lstStartTime.SelectedIndex = -1
                Else
                    '시작시간
                    selectStartTimeUI(lstRoomReservation.Item(j).시작시간)

                    '사용시간
                    Dim startTime As DateTime : startTime = DateTime.Parse(lstRoomReservation.Item(j).시작시간)
                    Dim endTime As DateTime : endTime = DateTime.Parse(lstRoomReservation.Item(j).종료시간)
                    Dim timediff As TimeSpan = endTime - startTime
                    comboUsageTime.Text = timediff.Hours & " 시간"
                End If



                txtRoomState.Text = ""

                Exit Sub
            End If
        Next j

    End Sub


    '테이블클릭 -> UI로 띄움
    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If (e.RowIndex < 0 Or e.ColumnIndex < 0) Then
            '헤더나 열전체 선택시 무시
            Exit Sub
        End If

        Dim data As String = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value


        Dim data0_index As String = DataGridView1.Rows(e.RowIndex).Cells(0).Value '고유Index
        Dim data1_rnum As String = DataGridView1.Rows(e.RowIndex).Cells(1).Value '타석번호
        Dim data2_rstate As String = DataGridView1.Rows(e.RowIndex).Cells(2).Value '상태
        Dim data3_emp As String = DataGridView1.Rows(e.RowIndex).Cells(3).Value '담당직원
        Dim data4_custid As String = DataGridView1.Rows(e.RowIndex).Cells(4).Value '회원
        Dim data5_starttime As String = DataGridView1.Rows(e.RowIndex).Cells(5).Value '시작시간

        Console.WriteLine("{0}", data0_index)

        displayReservationInfo(data0_index)
    End Sub

    '예약PK -> 테이블셀이동
    Private Sub gridCellSelect(_고유Index As String)
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(0).Value.Equals(_고유Index) Then
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(1)
            End If
        Next i

    End Sub

End Class
