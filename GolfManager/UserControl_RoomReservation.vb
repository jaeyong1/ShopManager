Imports System.Net
Imports Newtonsoft.Json '수동설치 > Tools > NuGet Package Manager > Console > "PM> install-package Newtonsoft.json"
Imports Newtonsoft.Json.Linq '수동설치 > Tools > NuGet Package Manager > Console > "PM> install-package Newtonsoft.json"


Public Class UserControl_RoomReservation

    Dim BindingSource1 As New BindingSource() '리스트 <-> 데이터그리드.소스
    Dim BindingSource2 As New BindingSource() '리스트 <-> 데이터그리드.소스

    Public asdf As Integer


    Private Sub btnShow_Click(sender As Object, e As EventArgs) Handles btnShow.Click
        '화면막고있는 안내문구 삭제
        lbl2ndopennotify.Visible = False
        lbl2ndopennotify2.Visible = False
        lstWaitingCust.Enabled = True
        lst5min.Enabled = True

        '타석모니터 그리기시작
        Form2ndMonitor.numOfRooms = G_NumberOfRooms
        Form2ndMonitor.Show()

        '문자열 세팅 샘플코드
        For i = 0 To (Form2ndMonitor.dynamicBoxList.Count - 1)
            Form2ndMonitor.dynamicBoxList.Item(i).setTopicText((i + 1) & "번")
            Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("내용" & (i + 1))
        Next

    End Sub

    '요약테이블 표시순서 지정
    Private Sub AdjustSummaryTableColumnOrder()
        With DataGridViewSummary
            .Columns("고유Index").DisplayIndex = 0
            .Columns("고유Index").Visible = False
            .Columns("타석번호").DisplayIndex = 1
            .Columns("상태").DisplayIndex = 2
            .Columns("회원").DisplayIndex = 3
            .Columns("담당직원").DisplayIndex = 4
            .Columns("시작시간").DisplayIndex = 5
            .Columns("종료시간").DisplayIndex = 6
            .Columns("남은시간").DisplayIndex = 7
            .Columns("대기회원").DisplayIndex = 8
        End With

    End Sub
    '시작할때
    Private Sub UserControl_RoomReservation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Console.WriteLine("타석예약화면 초기화")

        '타석번호 콤보박스 초기화
        ComboRoomNumber.Items.Clear()
        For i = 1 To (G_NumberOfRooms)
            ComboRoomNumber.Items.Add(i & "") '타석번호를 문자열로 생성
        Next

        '예약요약리스트 초기화
        lstRoomReservationSummary = New List(Of clsRoomReservationSummary)
        For i = 1 To (G_NumberOfRooms)
            lstRoomReservationSummary.Add(New clsRoomReservationSummary(i & ""))
        Next

        '예약Raw테이블-리스트연결
        BindingSource1.DataSource = lstRoomReservationRaw
        DataGridView1.DataSource = BindingSource1

        '예약요약테이블-리스트연결
        BindingSource2.DataSource = lstRoomReservationSummary
        DataGridViewSummary.DataSource = BindingSource2
        AdjustSummaryTableColumnOrder() '요약테이블 표시순서

        '시작시간/종료시간 포맷
        timepickerStartTime.Format = DateTimePickerFormat.Custom
        timepickerStartTime.CustomFormat = "tt hh:mm"
        timepickerEndTime.Format = DateTimePickerFormat.Custom
        timepickerEndTime.CustomFormat = "tt hh:mm"

        If My.Settings.IsRoomComputer = False Then
            '일반 카운터용 프로그램
            Console.WriteLine("[일반 카운터용 프로그램]")
            Timer1.Enabled = True
        Else
            '타석화면락스크린용 프로그램
            Console.WriteLine("[타석화면락스크린용 프로그램]")
            Timer2.Enabled = True
        End If

        '곧 서버로부터 DB정보 업데이트
        timer_cnt = 5

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
            'MsgBox("회원정보를 확인해 주세요")
            'txtCustomerID.Select()
            'Return False
            '[요구사항 변경] -> Geust자동입력
            txtCustomerID.Text = "Guest"
        End If

        If txtEmployeeId.Text = "" Then
            'MsgBox("담당직원을 확인해 주세요")
            'txtEmployeeId.Select()
            'Return False
            '[요구사항 변경] -> Geust자동입력
            txtEmployeeId.Text = "Guest"
        End If
        Return True
    End Function

    'UI 초기화
    Private Sub clearRoomReservUI()
        ComboRoomNumber.Text = ""
        txtCustomerID.Text = ""
        txtEmployeeId.Text = ""
        timepickerStartTime.Value = Date.Now
        timepickerEndTime.Value = Date.Now
        txtCustomerName.Text = ""
        txtRoomState.Text = ""
        lblRoomReservIndex.Text = ""

        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '타석예약 추가버튼 클릭
    Private Sub btnAddReserv_Click(sender As Object, e As EventArgs) Handles btnAddReserv.Click

        'UI 채우기 확인
        If checkReservationUI() = False Then
            Exit Sub
        End If

        '시작시간 < 종료시간
        Dim startTime As DateTime = timepickerStartTime.Value '시작시간
        Dim endTime As DateTime = timepickerEndTime.Value '종료시간
        Console.WriteLine("starttime:" + startTime + ", endtime:" + endTime)
        If startTime >= endTime Then
            MsgBox("종료시간은 시작시간 이후여야 합니다.")
            Exit Sub
        End If
        If (startTime.Hour = endTime.Hour) And (startTime.Minute = endTime.Minute) Then
            MsgBox("종료시간은 시작시간 이후여야 합니다.")
            Exit Sub
        End If

        'DB Update  < 서버
        If refreshRoomReservationWithServer() = False Then
            Exit Sub
        End If

        '타석예약 가능한지 DB 확인
        Dim isValid As Boolean = True
        For i = 0 To lstRoomReservationRaw.Count - 1
            If lstRoomReservationRaw.Item(i).isValidNewReservation(
                ComboRoomNumber.Text,
                startTime.ToString,
                endTime.ToString) = False Then
                isValid = False

                '예약불가할 경우 에러팝업
                MsgBox("가용한 시간이 아닙니다. 예약상태를 확인해주세요." & lstRoomReservationRaw.Item(i).회원 & "님의 " &
                    lstRoomReservationRaw.Item(i).타석번호 & "번방 예약과 겹칩니다.")
                Exit Sub

            End If
        Next i
        Console.WriteLine("추가정보 isValid ? " & isValid)

        '시작시간~종료시간사이에 현재시간이 존재 > "사용중"으로 변경 문의

        '예약추가 > 서버
        addRoomReservationToServer(
            New clsRoomReservationRawinfo(lstRoomReservationRaw.Count & "",
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

        '시작시간 < 종료시간
        Dim startTime As DateTime = timepickerStartTime.Value '시작시간
        Dim endTime As DateTime = timepickerEndTime.Value '종료시간
        Console.WriteLine("starttime:" + startTime + ", endtime:" + endTime)
        If startTime >= endTime Then
            MsgBox("종료시간은 시작시간 이후여야 합니다.")
            Exit Sub
        End If
        If (startTime.Hour = endTime.Hour) And (startTime.Minute = endTime.Minute) Then
            MsgBox("종료시간은 시작시간 이후여야 합니다.")
            Exit Sub
        End If

        '삭제전 업데이트
        'DB Update  < 서버
        If refreshRoomReservationWithServer() = False Then
            Exit Sub
        End If

        Dim isValid As Boolean = True
        For i = 0 To lstRoomReservationRaw.Count - 1
            If lstRoomReservationRaw.Item(i).isValidNewReservation(
                ComboRoomNumber.Text,
                startTime.ToString,
                endTime.ToString) = False Then

                If lstRoomReservationRaw.Item(i).회원.Equals(txtCustomerID.Text) Then

                    Dim edityn = MsgBox("예약수정이 맞습니까? [예]예약변경, [아니요]신규추가, [취소]작업취소:", MsgBoxStyle.YesNoCancel)
                    If edityn = vbYes Then
                        '[예약변경] =현재예약건지움, 추가
                        deleteRoomReservationToServer(
                        New clsRoomReservationRawinfo(lstRoomReservationRaw.Item(i).고유Index,
                                               lstRoomReservationRaw.Item(i).타석번호,
                                               lstRoomReservationRaw.Item(i).상태,
                                               lstRoomReservationRaw.Item(i).회원,
                                               lstRoomReservationRaw.Item(i).담당직원,
                                               lstRoomReservationRaw.Item(i).시작시간,
                                               lstRoomReservationRaw.Item(i).종료시간)
                                               )
                        Exit For
                    ElseIf edityn = vbNo Then
                        '[신규추가]
                        Console.WriteLine("스케쥴겹치지만 (내스케쥴이므로) 무시")
                        Exit For
                    Else 'cancel
                        '[작업취소]
                        Exit Sub
                    End If

                End If
                isValid = False

                '예약불가할 경우 에러팝업
                MsgBox("가용한 시간이 아닙니다. 예약상태를 확인해주세요." & lstRoomReservationRaw.Item(i).회원 & "님의 " &
                    lstRoomReservationRaw.Item(i).타석번호 & "번방 예약과 겹칩니다.")
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
            For j = 0 To (lstRoomReservationRaw.Count - 1)
                If lstRoomReservationRaw.Item(j).상태.Equals("대기중") And
                    lstRoomReservationRaw.Item(j).고유Index.Equals(lblRoomReservIndex.Text) Then
                    '서버에서 예약삭제
                    deleteRoomReservationToServer(
                        New clsRoomReservationRawinfo(lstRoomReservationRaw.Item(j).고유Index,
                                               lstRoomReservationRaw.Item(j).타석번호,
                                               lstRoomReservationRaw.Item(j).상태,
                                               lstRoomReservationRaw.Item(j).회원,
                                               lstRoomReservationRaw.Item(j).담당직원,
                                               lstRoomReservationRaw.Item(j).시작시간,
                                               lstRoomReservationRaw.Item(j).종료시간)
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
            New clsRoomReservationRawinfo(lstRoomReservationRaw.Count & "",
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
            New clsRoomReservationRawinfo(lstRoomReservationRaw.Count & "",
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
    Private Sub addRoomReservationToServer(rr As clsRoomReservationRawinfo)

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
    Private Sub deleteRoomReservationToServer(rr As clsRoomReservationRawinfo)

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
    Private Sub updateRoomReservationToServer(rr As clsRoomReservationRawinfo)

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


    '서버에서 특정타석 조회(타석제어용)
    Private Function refreshSingleRoomReservationWithServer()
        If My.Settings.IsRoomComputer = False Then
            MsgBox("타석용 컴퓨터가 아닌데 잘못된 코드가 실행됐습니다. 재시작해주세요.", vbOK)
            Return False
        End If

        If My.Settings.MyRoomNumber = 0 Then
            MsgBox("타석 번호가 잘못설정되었습니다. 재설정해주세요.", vbOK)
            Return False
        End If

        Dim clsRoomReservationJSON1 = New clsRoomReservationJSON()
        clsRoomReservationJSON1.reservedSchduleId = ""
        clsRoomReservationJSON1.reservedRoomNumber = (My.Settings.MyRoomNumber & "")
        clsRoomReservationJSON1.reservedState = ""
        clsRoomReservationJSON1.custCode = ""
        clsRoomReservationJSON1.emCode = ""
        clsRoomReservationJSON1.reservedStartTime = ""
        clsRoomReservationJSON1.reservedEndTime = ""
        Dim JsonData As String = JsonConvert.SerializeObject(clsRoomReservationJSON1)
        Console.WriteLine("Request JsonData:{0}", JsonData)
        Console.WriteLine("")
        Dim myRequest As HttpWebRequest = PostJSON(G_WebServerURL & "testver_getmyroomreservation", JsonData)
        Dim response As String = GetResponse(myRequest)
        Console.WriteLine("Response of Request:{0}", response)
        Return updatelstRoomReservationRaw(response)
    End Function



    '서버에서 타석예약현황 조회&업데이트
    Private Function refreshRoomReservationWithServer()

        Dim JsonData As String = "{""type"":""Point""}" '보낼JSON데이터(Dummy)
        Console.WriteLine("Update [" & G_WebServerURL & "]")
        Dim myRequest As HttpWebRequest = PostJSON(G_WebServerURL & "testver_getroomreservation", JsonData)
        Dim response As String = GetResponse(myRequest)
        Console.WriteLine("Response of Request:{0}", response)
        Return updatelstRoomReservationRaw(response)

    End Function

    '타석예약 업데이트
    Private Function updatelstRoomReservationRaw(response As String)

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
            lstRoomReservationRaw.Clear()
            For Each oneRRitem As clsRoomReservationJSON In list_deserializedRoomReservations
                'Console.WriteLine("id:" & oneRRitem.reservedSchduleId & ", room:" & oneRRitem.reservedRoomNumber)
                lstRoomReservationRaw.Add(New clsRoomReservationRawinfo(oneRRitem.reservedSchduleId, oneRRitem.reservedRoomNumber, oneRRitem.reservedState, oneRRitem.custCode, oneRRitem.emCode, oneRRitem.reservedStartTime, oneRRitem.reservedEndTime))
            Next
            'sort 
            lstRoomReservationRaw.Sort()
            Me.DataGridView1.Columns("고유index").Visible = False
            BindingSource1.ResetBindings(False)

            lstRoomReservationSummary.Sort()
            BindingSource2.ResetBindings(False)

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
        If (updateSummaryTable() = True) Then
            Console.WriteLine("Retry updateSummaryTable")
            updateSummaryTable() ' 한번더 실행
        End If

        update2ndScreen()
    End Sub

    '타석별 요약정보 업데이트 
    Private Function updateSummaryTable()
        Dim requestRetry As Boolean = False '다시 실행필요?를 리턴

        Me.lst5min.Items.Clear()
        lstWaitingCust.Items.Clear()
        For i = 0 To G_NumberOfRooms - 1 '(Form2ndMonitor.dynamicBoxList.Count - 1)
            '토픽
            'Form2ndMonitor.dynamicBoxList.Item(i).setTopicText((i + 1) & "번")

            '내용 
            Dim contents As String = "내용" & (i + 1)
            Dim isSetted As Boolean = False
            Dim waiting As Integer = 0

            '타석상태 결정순서
            '미사용 > 사용중 > 곧끝남 > 정리중(시간고려 추가)

            For j = 0 To (lstRoomReservationRaw.Count - 1)
                '대기인원 카운트
                If lstRoomReservationRaw.Item(j).타석번호 = (i + 1) And lstRoomReservationRaw.Item(j).상태.Equals("대기중") Then
                    '시간미정인경우만 세컨드스크린 숫자표시
                    If lstRoomReservationRaw.Item(j).시작시간 = "00:00" Then
                        waiting = waiting + 1
                    End If
                    '시간정해져있어도 관리화면에는 표시
                    lstWaitingCust.Items.Add("타석 " & lstRoomReservationRaw.Item(j).타석번호 & " / " &
                                             lstRoomReservationRaw.Item(j).시작시간 & " / " &
                                             lstRoomReservationRaw.Item(j).회원 & "님 대기중")
                End If
            Next j

            For j = 0 To (lstRoomReservationRaw.Count - 1)
                '[사용중] 남은시간 표시
                If lstRoomReservationRaw.Item(j).타석번호 = (i + 1) And lstRoomReservationRaw.Item(j).상태.Equals("사용중") Then
                    Dim endTime As DateTime
                    endTime = DateTime.Parse(lstRoomReservationRaw.Item(j).종료시간)
                    Dim timediff As TimeSpan = endTime - DateTime.Now
                    contents = Format(timediff.Hours, "0").Replace("-", "") &
                        Format(timediff.Minutes, ":00").Replace("-", "") _
                    '  & Format(timediff.Seconds, ":00").Replace("-", "")  '초 표시 생략


                    '5분이하 : [끝나감] 색깔
                    If timediff.TotalMinutes >= 0 And timediff.TotalMinutes <= 5.0 Then
                        'Form2ndMonitor.dynamicBoxList.Item(i).setRoomFreeSoon()
                        'Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("끝나감" + vbCrLf + contents + vbCrLf + Format(waiting, "대기 0명"))
                        Me.lst5min.Items.Add("타석 " & lstRoomReservationRaw.Item(j).타석번호 & " / " & Format(timediff.Minutes, "0") & "분남음")
                        lstRoomReservationSummary.Item(i).BaseCopy(lstRoomReservationRaw.Item(j))
                        lstRoomReservationSummary.Item(i).상태 = "끝나감"
                        lstRoomReservationSummary.Item(i).남은시간 = contents
                        lstRoomReservationSummary.Item(i).대기회원 = Format(waiting, "0 명")


                    ElseIf timediff.TotalMinutes < 0 Then '시간초과/정리중
                        'Form2ndMonitor.dynamicBoxList.Item(i).setRoomFreeSoon()
                        'Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("정리중" + vbCrLf + contents + vbCrLf + Format(waiting, "대기 0명"))
                        Me.lst5min.Items.Add("타석 " & lstRoomReservationRaw.Item(j).타석번호 & " / " & Format(-timediff.TotalMinutes, "0") & "분 시간초과")
                        lstRoomReservationSummary.Item(i).BaseCopy(lstRoomReservationRaw.Item(j))
                        lstRoomReservationSummary.Item(i).상태 = "정리중"
                        lstRoomReservationSummary.Item(i).남은시간 = contents
                        lstRoomReservationSummary.Item(i).대기회원 = Format(waiting, "0 명")

                        '10분이상 초과
                        If ((-timediff.TotalMinutes) >= 10) Then
                            requestRetry = True
                            Dim realEndTime As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                  DateTime.Now.Hour,  'hours 
                                                  DateTime.Now.Minute, 'minutes
                                                  0, 'seconds
                                                  0) 'milliseconds
                            Dim strRealEndTime As String = realEndTime.ToString("HH:mm")
                            lstRoomReservationRaw.Item(j).종료시간 = strRealEndTime
                            lstRoomReservationRaw.Item(j).상태 = "사용완료"
                            updateRoomReservationToServer(lstRoomReservationRaw.Item(j))
                        End If

                    Else '[사용중]색깔
                        'Form2ndMonitor.dynamicBoxList.Item(i).setRoomUsing()
                        'Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("사용중" + vbCrLf + contents + vbCrLf + Format(waiting, "대기 0명"))
                        lstRoomReservationSummary.Item(i).BaseCopy(lstRoomReservationRaw.Item(j))
                        lstRoomReservationSummary.Item(i).상태 = "사용중"
                        lstRoomReservationSummary.Item(i).남은시간 = contents
                        lstRoomReservationSummary.Item(i).대기회원 = Format(waiting, "0 명")
                    End If

                    isSetted = True '위에서 무엇인가 업데이트함
                End If


            Next
            '[사용중] 아닌경우
            If isSetted = False Then
                'Form2ndMonitor.dynamicBoxList.Item(i).setRoomFree()
                'Form2ndMonitor.dynamicBoxList.Item(i).setBoxText("미사용")
                lstRoomReservationSummary.Item(i).SetFree(i)
            End If
        Next

        lstRoomReservationSummary.Sort()
        Return requestRetry
    End Function

    '요약테이블 --> 실제2nd스크린으로 뿌리기
    Private Sub update2ndScreen()

        For i = 0 To (Form2ndMonitor.dynamicBoxList.Count - 1)
            '토픽
            Form2ndMonitor.dynamicBoxList.Item(i).setTopicText((i + 1) & "번")
            '내용 
            Dim contents As String = "내용" & (i + 1)
            Dim isSetted As Boolean = False
            Dim waiting As Integer = 0

            '타석상태 결정순서
            '미사용 > 사용중 > 곧끝남 > 정리중(시간고려 추가)

            For j = 0 To (lstRoomReservationRaw.Count - 1)
                If lstRoomReservationRaw.Item(j).타석번호 = (i + 1) Then
                    If lstRoomReservationSummary.Item(i).상태 = "끝나감" Then
                        Form2ndMonitor.dynamicBoxList.Item(i).setRoomFreeSoon()
                    ElseIf lstRoomReservationSummary.Item(i).상태 = "정리중" Then
                        Form2ndMonitor.dynamicBoxList.Item(i).setRoomFreeSoon()
                    ElseIf lstRoomReservationSummary.Item(i).상태 = "사용중" Then
                        Form2ndMonitor.dynamicBoxList.Item(i).setRoomUsing()
                    Else '미사용
                        Form2ndMonitor.dynamicBoxList.Item(i).setRoomFree()
                    End If
                    Form2ndMonitor.dynamicBoxList.Item(i).setBoxText(lstRoomReservationSummary.Item(i).상태 + '"끝나감
                         vbCrLf +
                          lstRoomReservationSummary.Item(i).남은시간 + '잔여시간
                         vbCrLf +
                         lstRoomReservationSummary.Item(i).대기회원 '"0 명"
                         )
                    isSetted = True '위에서 무엇인가 업데이트함
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

        For j = 0 To (lstRoomReservationRaw.Count - 1)
            If lstRoomReservationRaw.Item(j).타석번호 = selectedRoomNum And
                    lstRoomReservationRaw.Item(j).시작시간 = selectedStartTime And
                    lstRoomReservationRaw.Item(j).회원 = selectedCustName Then

                displayReservationInfo(lstRoomReservationRaw.Item(j).고유Index)
                gridCellSelect(lstRoomReservationRaw.Item(j).고유Index)

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
            For j = 0 To (lstRoomReservationRaw.Count - 1)
                If lstRoomReservationRaw.Item(j).타석번호 = selectedRoomNum And
                        lstRoomReservationRaw.Item(j).시작시간 = selectedStartTime And
                        lstRoomReservationRaw.Item(j).회원 = selectedCustName Then


                    '서버에서 예약삭제
                    deleteRoomReservationToServer(
                        New clsRoomReservationRawinfo(lstRoomReservationRaw.Item(j).고유Index,
                                               lstRoomReservationRaw.Item(j).타석번호,
                                               lstRoomReservationRaw.Item(j).상태,
                                               lstRoomReservationRaw.Item(j).회원,
                                               lstRoomReservationRaw.Item(j).담당직원,
                                               lstRoomReservationRaw.Item(j).시작시간,
                                               lstRoomReservationRaw.Item(j).종료시간)
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
        For j = 0 To (lstRoomReservationRaw.Count - 1)
            If lstRoomReservationRaw.Item(j).타석번호 = selectedRoomNum And
                lstRoomReservationRaw.Item(j).상태.Equals("사용중") Then

                displayReservationInfo(lstRoomReservationRaw.Item(j).고유Index)
                gridCellSelect(lstRoomReservationRaw.Item(j).고유Index)
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
        For j = 0 To (lstRoomReservationRaw.Count - 1)
            If lstRoomReservationRaw.Item(j).고유Index.Equals(end고유Index) Then
                lstRoomReservationRaw.Item(j).종료시간 = strRealEndTime
                lstRoomReservationRaw.Item(j).상태 = "사용완료"

                '서버에서 예약 업데이트(종료로)
                updateRoomReservationToServer(lstRoomReservationRaw.Item(j))

                '입력화면정리
                clearRoomReservUI()

                '삭제후 업데이트
                refreshRoomReservationWithServer()
                Exit Sub
            End If
        Next j

        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '화면입력초기화 버튼클릭
    Private Sub btnInitUI_Click(sender As Object, e As EventArgs) Handles btnInitUI.Click
        '입력화면정리
        clearRoomReservUI()
    End Sub

    '예약의 고유index(PK)로 예약상황 표시
    Private Sub displayReservationInfo(_예약고유index As String)
        '정보검색
        For j = 0 To (lstRoomReservationRaw.Count - 1)
            If lstRoomReservationRaw.Item(j).고유Index.Equals(_예약고유index) Then

                lblRoomReservIndex.Text = _예약고유index
                ComboRoomNumber.Text = lstRoomReservationRaw.Item(j).타석번호
                txtCustomerID.Text = lstRoomReservationRaw.Item(j).회원
                txtCustomerName.Text = "-"
                txtEmployeeId.Text = lstRoomReservationRaw.Item(j).담당직원


                If lstRoomReservationRaw.Item(j).시작시간.Equals("00:00") Then
                    Dim zeroTime As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                              0,  'hours 
                                                              0, 'minutes
                                                              0, 'seconds
                                                              0) 'milliseconds
                    timepickerStartTime.Value = zeroTime
                    timepickerEndTime.Value = zeroTime
                Else
                    '시작시간
                    Dim startTime As DateTime : startTime = DateTime.Parse(lstRoomReservationRaw.Item(j).시작시간)
                    timepickerStartTime.Value = startTime

                    '종료시간
                    Dim endTime As DateTime : endTime = DateTime.Parse(lstRoomReservationRaw.Item(j).종료시간)
                    timepickerEndTime.Value = endTime
                End If

                txtRoomState.Text = ""
                Exit Sub
            End If
        Next j

    End Sub


    '로그테이블클릭 -> UI로 띄움
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

    '요약테이블클릭 -> UI로 띄움
    Private Sub DataGridViewSummary_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridViewSummary.CellClick
        If lbl2ndopennotify2.Visible = True Then
            '차단 레이블 표시 중. 무시.
            Exit Sub
        End If

        Console.WriteLine("summary table click. " & e.RowIndex & "," & e.ColumnIndex)

        If (e.ColumnIndex < 0) Then
            '열전체 선택. 무시.
            '좌측상단모서리선택시(-1, -1) 입력됨. 무시.
            Exit Sub
        End If

        If (e.RowIndex < 0) Then
            '헤더선택시 정렬기준
            If e.ColumnIndex = 3 Then 'e.ColumnIndex = 3 (타석소팅)
                If Local_RoomReservation_SummaryTable_Sort_by = "타석번호" Then : Local_RoomReservation_SummaryTable_Sort_ASC = Not Local_RoomReservation_SummaryTable_Sort_ASC
                Else : Local_RoomReservation_SummaryTable_Sort_by = "타석번호"
                End If
            ElseIf e.ColumnIndex = 4 Then 'e.ColumnIndex = 4 (상태소팅)
                If Local_RoomReservation_SummaryTable_Sort_by = "상태" Then : Local_RoomReservation_SummaryTable_Sort_ASC = Not Local_RoomReservation_SummaryTable_Sort_ASC
                Else : Local_RoomReservation_SummaryTable_Sort_by = "상태"
                End If
            ElseIf e.ColumnIndex = 5 Then 'e.ColumnIndex = 5 (회원소팅)
                If Local_RoomReservation_SummaryTable_Sort_by = "회원" Then : Local_RoomReservation_SummaryTable_Sort_ASC = Not Local_RoomReservation_SummaryTable_Sort_ASC
                Else : Local_RoomReservation_SummaryTable_Sort_by = "회원"
                End If
            ElseIf e.ColumnIndex = 6 Then 'e.ColumnIndex = 6 (담당직원소팅)
                If Local_RoomReservation_SummaryTable_Sort_by = "담당직원" Then : Local_RoomReservation_SummaryTable_Sort_ASC = Not Local_RoomReservation_SummaryTable_Sort_ASC
                Else : Local_RoomReservation_SummaryTable_Sort_by = "담당직원"
                End If
            ElseIf e.ColumnIndex = 7 Then 'e.ColumnIndex = 7 (시작시간소팅)
                If Local_RoomReservation_SummaryTable_Sort_by = "시작시간" Then : Local_RoomReservation_SummaryTable_Sort_ASC = Not Local_RoomReservation_SummaryTable_Sort_ASC
                Else : Local_RoomReservation_SummaryTable_Sort_by = "시작시간"
                End If
            ElseIf (e.ColumnIndex = 8) Or (e.ColumnIndex = 0) Then 'e.ColumnIndex = 8 (종료시간소팅), 'e.ColumnIndex = 0 (남은시간소팅)
                If Local_RoomReservation_SummaryTable_Sort_by = "종료시간" Then : Local_RoomReservation_SummaryTable_Sort_ASC = Not Local_RoomReservation_SummaryTable_Sort_ASC
                Else : Local_RoomReservation_SummaryTable_Sort_by = "종료시간"
                End If
            ElseIf e.ColumnIndex = 1 Then 'e.ColumnIndex = 1 (대기회원소팅)
                If Local_RoomReservation_SummaryTable_Sort_by = "대기회원" Then : Local_RoomReservation_SummaryTable_Sort_ASC = Not Local_RoomReservation_SummaryTable_Sort_ASC
                Else : Local_RoomReservation_SummaryTable_Sort_by = "대기회원"
                End If
            End If
            lstRoomReservationSummary.Sort()
            BindingSource2.ResetBindings(False)
            Exit Sub
        End If


        Dim data As String = DataGridViewSummary.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

        Dim data0_remaintime As String = DataGridViewSummary.Rows(e.RowIndex).Cells(0).Value '남은시간
        Dim data1_waitings As String = DataGridViewSummary.Rows(e.RowIndex).Cells(1).Value '대기인원
        Dim data2_index As String = DataGridViewSummary.Rows(e.RowIndex).Cells(2).Value '고유Index
        Dim data3_roomnum As String = DataGridViewSummary.Rows(e.RowIndex).Cells(3).Value '타석번호
        Dim data4_roomstate As String = DataGridViewSummary.Rows(e.RowIndex).Cells(4).Value '상태

        Console.WriteLine("summary table click. pk : {0}", data2_index)

        displayReservationInfo(data2_index)

        If data2_index = "" Then
            '입력화면정리
            clearRoomReservUI()
            ComboRoomNumber.Text = data3_roomnum
        End If
    End Sub

    '예약PK -> 테이블셀이동
    Private Sub gridCellSelect(_고유Index As String)
        For i = 0 To DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(0).Value.Equals(_고유Index) Then
                DataGridView1.CurrentCell = DataGridView1.Rows(i).Cells(1)
            End If
        Next i

    End Sub

    '시작시간 지금 버튼
    Private Sub btn_SetStartTimeNow_Click(sender As Object, e As EventArgs) Handles btn_SetStartTimeNow.Click
        timepickerStartTime.Value = Date.Now
        timepickerEndTime.Value = Date.Now
    End Sub

    '시작시간 5분후 버튼
    Private Sub btn_SetStartTimeAfter5Min_Click(sender As Object, e As EventArgs) Handles btn_SetStartTimeAfter5Min.Click
        Dim newDate As Date = Date.Now.AddMinutes(5)
        timepickerStartTime.Value = newDate
        timepickerEndTime.Value = newDate
    End Sub

    '시작시간 낮 12시(오전오후헷갈림)
    Private Sub btn_SetStartTime12oclock_Click(sender As Object, e As EventArgs) Handles btn_SetStartTime12oclock.Click
        Dim lunchTime As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                  12,  'hours 
                                                  00, 'minutes
                                                  0, 'seconds
                                                  0) 'milliseconds

        timepickerStartTime.Value = lunchTime
        timepickerEndTime.Value = lunchTime
    End Sub

    '시작시간 변경 -> 종료시간 업데이트
    Private Sub timepickerStartTime_ValueChanged(sender As Object, e As EventArgs) Handles timepickerStartTime.ValueChanged
        timepickerEndTime.Value = timepickerStartTime.Value

    End Sub

    Private Sub increaseEndTimeMinutes(_min As Integer)
        Dim newtime As DateTime = timepickerEndTime.Value
        newtime = newtime.AddMinutes(_min)
        timepickerEndTime.Value = newtime
    End Sub
    '종료시간 10분추가
    Private Sub btn_EndTimeIncrease10min_Click(sender As Object, e As EventArgs) Handles btn_EndTimeIncrease10min.Click
        increaseEndTimeMinutes(10)
    End Sub
    '종료시간 30분추가
    Private Sub btn_EndTimeIncrease30min_Click(sender As Object, e As EventArgs) Handles btn_EndTimeIncrease30min.Click
        increaseEndTimeMinutes(30)
    End Sub
    '종료시간 60분추가
    Private Sub btn_EndTimeIncrease60min_Click(sender As Object, e As EventArgs) Handles btn_EndTimeIncrease60min.Click
        increaseEndTimeMinutes(60)
    End Sub
    '종료시간 70분추가
    Private Sub btn_EndTimeIncrease70min_Click(sender As Object, e As EventArgs) Handles btn_EndTimeIncrease70min.Click
        increaseEndTimeMinutes(70)
    End Sub

    '종료시간 변경됨
    Private Sub timepickerEndTime_ValueChanged(sender As Object, e As EventArgs) Handles timepickerEndTime.ValueChanged
        If (timepickerStartTime.Value.Hour = 0) And (timepickerStartTime.Value.Minute = 0) And
                (timepickerEndTime.Value.Hour = 0) And (timepickerEndTime.Value.Minute = 0) Then
            Console.WriteLine("시간 미설정 상태. 에러SKIP")
            Exit Sub
        End If

        If (timepickerEndTime.Value.Hour >= 0) And (timepickerEndTime.Value.Hour < 6) Then
            Dim closeTime As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,
                                                              23,  'hours 
                                                              59, 'minutes
                                                              0, 'seconds
                                                              0) 'milliseconds

            timepickerEndTime.Value = closeTime
            MsgBox("종료시간을 재 설정 바랍니다. (~23시59분)")
        End If


        If (timepickerStartTime.Value.Year <> timepickerEndTime.Value.Year) Or
            (timepickerStartTime.Value.Month <> timepickerEndTime.Value.Month) Or
            (timepickerStartTime.Value.Day <> timepickerEndTime.Value.Day) Then
            MsgBox("종료시간을 재 설정 바랍니다.")
            timepickerEndTime.Value = timepickerStartTime.Value
        End If
    End Sub


    '오름/내림차순 변경. 클래스에서 소팅할때 가져갈 수 있도록 전역변수에 넣어줌
    Private Sub ChkboxSummaryTableAscDesc_CheckedChanged(sender As Object, e As EventArgs) Handles ChkboxSummaryTableAscDesc.CheckedChanged
        Local_RoomReservation_SummaryTable_Sort_ASC = ChkboxSummaryTableAscDesc.Checked
        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '정렬기준 변경
    Private Sub radio소팅타석번호_CheckedChanged(sender As Object, e As EventArgs) Handles radio소팅타석번호.CheckedChanged
        Local_RoomReservation_SummaryTable_Sort_by = "타석번호"
        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '정렬기준 변경
    Private Sub radio소팅상태_CheckedChanged(sender As Object, e As EventArgs) Handles radio소팅상태.CheckedChanged
        Local_RoomReservation_SummaryTable_Sort_by = "상태"
        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '정렬기준 변경
    Private Sub radio소팅회원_CheckedChanged(sender As Object, e As EventArgs) Handles radio소팅회원.CheckedChanged
        Local_RoomReservation_SummaryTable_Sort_by = "회원"
        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '정렬기준 변경
    Private Sub radio소팅담당직원_CheckedChanged(sender As Object, e As EventArgs) Handles radio소팅담당직원.CheckedChanged
        Local_RoomReservation_SummaryTable_Sort_by = "담당직원"
        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '정렬기준 변경
    Private Sub radio소팅시작시간_CheckedChanged(sender As Object, e As EventArgs) Handles radio소팅시작시간.CheckedChanged
        Local_RoomReservation_SummaryTable_Sort_by = "시작시간"
        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '정렬기준 변경
    Private Sub radio소팅종료시간_CheckedChanged(sender As Object, e As EventArgs) Handles radio소팅종료시간.CheckedChanged
        Local_RoomReservation_SummaryTable_Sort_by = "종료시간"
        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '정렬기준 변경
    Private Sub radio소팅대기회원_CheckedChanged(sender As Object, e As EventArgs) Handles radio소팅대기회원.CheckedChanged
        Local_RoomReservation_SummaryTable_Sort_by = "대기회원"
        lstRoomReservationSummary.Sort()
        BindingSource2.ResetBindings(False)
    End Sub

    '타석용컴퓨터 업데이트
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        timer_cnt = timer_cnt - 1
        btnRoomReservRefresh.Text = "새로고침(" & timer_cnt & "초후)"
        If (timer_cnt = 0) Then
            refreshSingleRoomReservationWithServer()
            timer_cnt = 61
        End If

        '주기적으로 서버로부터 테이블 업데이트
        If (updateSummaryTable() = True) Then
            Console.WriteLine("Retry updateSummaryTable")
            updateSummaryTable() ' 한번더 실행
        End If

        'update2ndScreen()
    End Sub
End Class
