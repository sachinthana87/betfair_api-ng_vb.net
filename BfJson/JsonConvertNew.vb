Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.IO
Imports Newtonsoft.Json

Namespace Api_ng_sample_code.Json
    Public Class JsonConvertNew
        Public Shared Function Import(Of T)(ByVal reader As String) As JsonResponse(Of T)
            Dim jsonResponse = reader
            Return Deserialize(Of JsonResponse(Of T))(jsonResponse)
        End Function

        Public Shared Function Deserialize(Of T)(ByVal json As String) As T
            Dim obj As Object = Newtonsoft.Json.JsonConvert.DeserializeObject(Of T)(json)
            Return obj
        End Function

        'Used for json rpc calls to create a body
        Public Shared Sub Export(ByVal request As JsonRequest, ByVal writer As TextWriter)
            Dim json = Serialize(Of JsonRequest)(request)
            writer.Write(json)
        End Sub

        Public Shared Function Serialize(Of T)(ByVal value As T) As String

            Dim settings = New JsonSerializerSettings With {.NullValueHandling = NullValueHandling.Ignore}

            Return Newtonsoft.Json.JsonConvert.SerializeObject(value, settings)
        End Function
    End Class
End Namespace