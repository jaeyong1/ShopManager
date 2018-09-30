
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Net
Imports System.IO

'JSON을 Web에 Post하고 Response를 리턴받는 함수

Module Module2_JSONPostGetResponse
    Public Sub jsontest()
        Dim JsonData As String = "{""type"":""Point"",""coordinates"":[-105.01628,39.57422]}"
        Dim myRequest As HttpWebRequest = PostJSON("http://192.168.0.50:8080/putting/testver_getroomreservation", JsonData)
        Console.WriteLine("--------------------------------------")
        Console.WriteLine("Response of Request:{0}", GetResponse(myRequest))
        Console.WriteLine("--------------------------------------")

    End Sub
    Public Function PostJSON(ByVal URL As String, ByVal JsonData As String) As HttpWebRequest
        Dim objhttpWebRequest As HttpWebRequest


        Console.WriteLine("+ PostJSON URL:{0}", URL)
        Console.WriteLine("+ PostJSON JsonData:{0}", JsonData)

        Try
            Dim httpWebRequest = DirectCast(WebRequest.Create(URL), HttpWebRequest)
            httpWebRequest.ContentType = "application/json" '"text/json"
            httpWebRequest.Method = "POST"

            Using streamWriter = New StreamWriter(httpWebRequest.GetRequestStream())
                streamWriter.Write(JsonData)
                streamWriter.Flush()
                streamWriter.Close()
            End Using

            objhttpWebRequest = httpWebRequest

        Catch ex As Exception
            Console.WriteLine("Send Request Error[{0}]", ex.Message)
            Return Nothing
        End Try

        Return objhttpWebRequest
    End Function

    Public Function GetResponse(ByVal httpWebRequest As HttpWebRequest) As String
        Dim strResponse As String = "Bad Request:400"
        Try
            Dim httpResponse = DirectCast(httpWebRequest.GetResponse(), HttpWebResponse)
            Using streamReader = New StreamReader(httpResponse.GetResponseStream())
                Dim result = streamReader.ReadToEnd()

                strResponse = result.ToString()
            End Using
        Catch ex As Exception
            Console.WriteLine("GetResponse Error[{0}]", ex.Message)

            Return ex.Message
        End Try

        Return strResponse

    End Function

End Module
