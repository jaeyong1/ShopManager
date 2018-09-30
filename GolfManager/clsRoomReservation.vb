'타석예약 클래스
Imports GolfManager

Public Class clsRoomReservation
    Implements IComparable(Of clsRoomReservation)

    Private _index As String 'index(pk)
    Private _RoomNumber As String '타석번호
    Private _state As String '상태
    Private _customerId As String '회원ID
    Private _employee As String '담당직원ID
    Private _startTime As String '시작시간
    Private _endTime As String '종료시간

    Public Sub New(_index As String, _RoomNumber As String, _state As String, _customerId As String, _employee As String, _startTime As String, _endTime As String)
        Me._index = _index
        Me._RoomNumber = _RoomNumber
        Me._state = _state
        Me._customerId = _customerId
        Me._employee = _employee
        Me._startTime = _startTime
        Me._endTime = _endTime
    End Sub

    '새로추가하려는 예약이 valid한지 확인
    Public Function isValidNewReservation(ByVal newRoomNumber As String,
                                      ByVal newStartTime As String,
                                      ByVal newEndTime As String)
        '확인하려는 방번호가 이것의 방번호와 다름 > false
        If Not newRoomNumber.Equals(_RoomNumber) Then
            Return True
        End If

        Dim inStartTime As DateTime
        inStartTime = DateTime.Parse(newStartTime)

        Dim inEndTime As DateTime
        inEndTime = DateTime.Parse(newEndTime)

        Dim startTime As DateTime
        startTime = DateTime.Parse(_startTime)

        Dim endTime As DateTime
        endTime = DateTime.Parse(_endTime)

        ' <--입력시간--> <--내부시간-->  >> OK
        If (inStartTime < startTime) And (inEndTime <= startTime) Then
            Return True
        End If

        '<--내부시간--> <--입력시간-->
        If (endTime <= inStartTime) And (endTime < inEndTime) Then
            Return True
        End If

        Return False '겹치는 경우
    End Function

    '소팅함수
    Public Function CompareTo(other As clsRoomReservation) As Integer Implements IComparable(Of clsRoomReservation).CompareTo
        '1순위 타석번호
        If 타석번호 > other.타석번호 Then
            Return 1
        ElseIf 타석번호 < other.타석번호 Then
            Return -1
        Else
            '2순위 시작시간
            If 시작시간 > other.시작시간 Then
                Return 1
            ElseIf 시작시간 < other.시작시간 Then
                Return -1
            Else
                '3순위 입력순서
                If Index > other.Index Then
                    Return 1
                ElseIf Index < other.Index Then
                    Return -1
                Else
                    Return 0
                End If
            End If
        End If
    End Function

    Public Property Index() As String
        Get
            Return _index
        End Get
        Set(ByVal value As String)
            _index = value
        End Set
    End Property
    Public Property 타석번호() As String
        Get
            Return _RoomNumber & "" 'datagrid에 보일내용
        End Get
        Set(ByVal value As String)
            _RoomNumber = value
        End Set
    End Property

    Public Property 상태() As String
        Get
            Return _state
        End Get
        Set(ByVal value As String)
            _state = value
        End Set
    End Property

    Public Property 회원() As String
        Get
            Return _customerId
        End Get
        Set(ByVal value As String)
            _customerId = value
        End Set
    End Property

    Public Property 담당직원() As String
        Get
            Return _employee
        End Get
        Set(ByVal value As String)
            _employee = value
        End Set
    End Property

    Public Property 시작시간() As String
        Get
            Dim calctime As DateTime
            calctime = DateTime.Parse(_startTime)
            Dim showTime As String = ""
            showTime = calctime.ToString("HH:mm")
            Return showTime 'datagrid에 보일내용
        End Get
        Set(ByVal value As String)
            _startTime = value
        End Set
    End Property

    Public Property 종료시간() As String
        Get
            Dim calctime As DateTime
            calctime = DateTime.Parse(_endTime)
            Dim showTime As String = ""
            showTime = calctime.ToString("HH:mm")
            Return showTime 'datagrid에 보일내용
        End Get
        Set(ByVal value As String)
            _endTime = value
        End Set
    End Property
End Class
