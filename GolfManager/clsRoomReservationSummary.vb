Imports GolfManager

Public Class clsRoomReservationSummary
    Inherits clsRoomReservationRawinfo

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

End Class
