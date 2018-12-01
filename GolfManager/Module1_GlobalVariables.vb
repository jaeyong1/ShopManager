Module Module1_GlobalVariables
    Public G_NumberOfRooms As Integer = 20 '타석개수 
    Public G_ShopName As String ' 지점이름
    Public G_LoginID As String '앱로그인 아이디
    Public G_LoginName As String '앱로그인 이름

    Public lstRoomReservationRaw As New List(Of clsRoomReservationRawinfo) '타석예약 리스트 Raw데이터 (=데이터그리드 화면과 동기화)
    Public lstRoomReservationSummary As New List(Of clsRoomReservationSummary) '타석예약 리스트 요약데이터 (=데이터그리드 화면과 동기화)


    Public G_WebServerURL As String = "http://puttingone.cafe24.com/"
    Public JYP_G_WebServerURL As String = "http://192.168.0.50:8080/putting/"
    Public G_RootDir As String = "C:\매장관리\"
    Public G_SettingsDir As String = "C:\매장관리\Settings\"
    Public G_BottomBannerImgDir As String = "C:\매장관리\BottomBanner\"

    '''''''''''''''''''''
    Public Local_RoomReservation_SummaryTable_Sort_ASC As Boolean = True
    Public Local_RoomReservation_SummaryTable_Sort_by As String = "타석번호"
    Public timer_cnt As Integer = 61 ' 예약현황 잔여시간 타이머
    Public Local_WaitingCompleteByUser_AsRoomComputer As Boolean = False '프로그램시작후 시간적으로 동의얻음(타임아웃)

End Module
