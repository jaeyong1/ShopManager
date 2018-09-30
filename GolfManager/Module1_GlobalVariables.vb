Module Module1_GlobalVariables
    Public G_NumberOfRooms As Integer = 9 '타석개수 
    Public G_ShopName As String ' 지점이름
    Public G_LoginID As String '앱로그인 아이디
    Public G_LoginName As String '앱로그인 이름

    Public lstRoomReservation As New List(Of clsRoomReservation) '타석예약 리스트 (=데이터그리드 화면과 동기화)


    Public G_WebServerURL As String = "http://puttingone.cafe24.com/"
    Public JYP_G_WebServerURL As String = "http://192.168.0.50:8080/putting/"

End Module
