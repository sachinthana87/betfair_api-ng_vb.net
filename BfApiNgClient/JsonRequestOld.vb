Imports System.IO
Imports System.Net
Imports System.Text

Public Class JsonRequestOld
    Function CreateRequest(AppKey As String, SessToken As String, postData As String)
        Dim Url As String = "https://api.betfair.com/exchange/betting/json-rpc/v1/"
        Dim request As WebRequest = Nothing
        Dim dataStream As Stream = Nothing
        Dim response As WebResponse = Nothing
        Dim strResponseStatus As String = ""
        Dim reader As StreamReader = Nothing
        Dim responseFromServer As String = ""
        Try
            request = WebRequest.Create(New Uri(Url))
            request.Method = "POST"
            request.ContentType = "application/json-rpc"
            request.Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1,utf-8")
            request.Headers.Add("X-Application", AppKey)
            request.Headers.Add("X-Authentication", SessToken)
            '~~> Data to post such as ListEvents, ListMarketCatalogue etc
            Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)
            '~~> Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length
            '~~> Get the request stream.
            dataStream = request.GetRequestStream()
            '~~> Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length)
            '~~> Close the Stream object.
            dataStream.Close()
            '~~> Get the response.
            response = request.GetResponse()
            '~~> Display the status below if required
            '~~> Dim strStatus as String = CType(response, HttpWebResponse).StatusDescription
            strResponseStatus = CType(response, HttpWebResponse).StatusDescription
            '~~> Get the stream containing content returned by the server.
            dataStream = response.GetResponseStream()
            '~~> Open the stream using a StreamReader for easy access.
            reader = New StreamReader(dataStream)
            '~~> Read the content.
            responseFromServer = reader.ReadToEnd()
            '~~> Display the content below if required
            '~~>Dim strShowResponse as String = responseFromServer  '~~>If required
        Catch ex As Exception
            '~~> Show any errors in this method for an error log etc Just use a messagebox for now
            MsgBox("CreateRequest Error" & vbCrLf & ex.Message)
        End Try
        Return responseFromServer   '~~> Function Output
        '~~> Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()
    End Function '~~>Creates the requst for Data to be loaded


End Class
