Imports GolfManager
Imports GolfManager.UserControl_RoomReservation

Public Class clsRoomReservationSummary
    Inherits clsRoomReservationRawinfo
    Implements IComparable(Of clsRoomReservationSummary)

    Private _remainTime As String '남은시간
    Private _waitingCustomers As String '대기회원 

    Public Sub New(_index As String, _RoomNumber As String, _state As String, _customerId As String, _employee As String, _startTime As String, _endTime As String, _waitingCustomers As String)
        MyBase.New(_index, _RoomNumber, _state, _customerId, _employee, _startTime, _endTime)
        Me._waitingCustomers = _waitingCustomers
    End Sub

    Public Sub New(_RoomNumber As String)
        MyBase.New("0", _RoomNumber, "", "", "", "00:00", "00:00")
        Me._waitingCustomers = "0"
    End Sub

    Public Property 남은시간() As String
        Get
            Return _remainTime
        End Get
        Set(ByVal value As String)
            _remainTime = value
        End Set
    End Property

    Public Property 대기회원 As String
        Get
            Return _waitingCustomers
        End Get
        Set(value As String)
            _waitingCustomers = value
        End Set
    End Property

    '(부모개념)에서 값 복사
    Public Sub BaseCopy(clsRoomReservationRawinfo As clsRoomReservationRawinfo)

        고유Index = clsRoomReservationRawinfo.고유Index
        타석번호 = clsRoomReservationRawinfo.타석번호
        상태 = clsRoomReservationRawinfo.상태
        회원 = clsRoomReservationRawinfo.회원
        담당직원 = clsRoomReservationRawinfo.담당직원
        시작시간 = clsRoomReservationRawinfo.시작시간
        종료시간 = clsRoomReservationRawinfo.종료시간
    End Sub

    '빈타석으로 요약표시
    Public Sub SetFree(설정타석번호 As Integer)
        고유Index = ""
        타석번호 = (설정타석번호 + 1) & ""
        상태 = "미사용"
        회원 = ""
        담당직원 = ""
        시작시간 = "00:00"
        종료시간 = "00:00"
        남은시간 = "00:00"
        대기회원 = "0 명"
    End Sub


    '아래 소팅용함수 CompareTo1()의 지원용 함수
    Public Function sortby타석번호(other As clsRoomReservationSummary)
        Dim ret As Integer = 0

        '1순위 타석번호의 문자열길이(3은 20보다 앞)
        If 타석번호.Length > other.타석번호.Length Then
            ret = 1
        ElseIf 타석번호.Length < other.타석번호.Length Then
            ret = -1
        Else
            '2순위 타석번호
            If 타석번호 > other.타석번호 Then
                ret = 1
            ElseIf 타석번호 < other.타석번호 Then
                ret = -1
            Else
                ret = 0
            End If
        End If
        Return ret
    End Function

    '소팅함수
    Public Function CompareTo1(other As clsRoomReservationSummary) As Integer Implements IComparable(Of clsRoomReservationSummary).CompareTo
        Dim ret As Integer = 0

        Select Case Local_RoomReservation_SummaryTable_Sort_by
            Case "타석번호"
                ret = sortby타석번호(other)

            Case "상태"
                If 상태 > other.상태 Then : ret = 1
                ElseIf 상태 < other.상태 Then : ret = -1
                Else : ret = sortby타석번호(other)
                End If

            Case "회원"
                If 회원 > other.회원 Then : ret = 1
                ElseIf 회원 < other.회원 Then : ret = -1
                Else : ret = sortby타석번호(other)
                End If

            Case "담당직원"
                If 담당직원 > other.담당직원 Then : ret = 1
                ElseIf 담당직원 < other.담당직원 Then : ret = -1
                Else : ret = sortby타석번호(other)
                End If

            Case "시작시간"
                If 시작시간 > other.시작시간 Then : ret = 1
                ElseIf 시작시간 < other.시작시간 Then : ret = -1
                Else : ret = sortby타석번호(other)
                End If

            Case "종료시간"
                If 종료시간 > other.종료시간 Then : ret = 1
                ElseIf 종료시간 < other.종료시간 Then : ret = -1
                Else : ret = sortby타석번호(other)
                End If

            Case "대기회원"
                If 대기회원 > other.대기회원 Then : ret = 1
                ElseIf 대기회원 < other.대기회원 Then : ret = -1
                Else : ret = sortby타석번호(other)
                End If


        End Select


        '역순정렬이면 -1 곱함
        If Local_RoomReservation_SummaryTable_Sort_ASC = False Then
            ret = ret * (-1)
        End If

        Return ret
    End Function

End Class
