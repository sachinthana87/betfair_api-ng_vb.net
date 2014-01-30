Imports System.Net

Public Class BfLogin

    Dim loginUrl As String = Nothing

    Public Sub New()
        loginUrl = "https://identitysso.betfair.com/api/login?username={0}&password={1}&login=true&redirectMethod=POST&product=home.betfair.int&url=https://www.betfair.com/"
    End Sub


    Public Function LoginSession(username As String, password As String) As String
        Dim ssoid As String = [String].Empty
        Dim info As String()
        Dim sessToken As String = ""
        Try
            Dim uri As String = String.Format(loginUrl, username, password)
            Dim myRequest As HttpWebRequest = DirectCast(WebRequest.Create(uri), HttpWebRequest)
            myRequest.Method = "POST"
            myRequest.Timeout = 5000
            Dim thePage As WebResponse = myRequest.GetResponse()
            info = thePage.Headers.GetValues("Set-Cookie")
            Dim i As Integer = 0
            While ssoid = [String].Empty AndAlso i < info.Length
                If info(i).Contains("ssoid=") Then
                    ssoid = info(i)
                End If
                i += 1
            End While
            'This returns
            '           ssoid=KY8FBhBU26jP3M9EDE4NogOm9XfH5xJDR49BlJI0lac=; Domain=.betfair.com; Path=/
            sessToken = ssoid.Replace("ssoid=", "") 'Dump front string
            sessToken = sessToken.Replace("; Domain=.betfair.com; Path=/", "") 'dump rear string
        Catch ex As System.Exception
            Logger.writeErrorLogEntry("Exception at LoginForm.LoginSession: " & ex.ToString())
        End Try
        Return sessToken '~~> Should work ok if Login a success
    End Function 'Session Token and Login
End Class
