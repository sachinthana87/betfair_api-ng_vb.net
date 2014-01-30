Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Collections.Specialized
Imports System.Web.Services.Protocols
Imports OddCompBotApiNg.Api_ng_sample_code.TO
Imports OddCompBotApiNg.Api_ng_sample_code.Json


Public Class JsonRpcClient
    'Implements ApiClientInterface

    'Dim client As JsonRequest = Nothing
    'Dim appId As String = Nothing
    'Dim sessionToken As String = Nothing

    'Public Sub New()
    '    client = New JsonRequest()
    '    appId = Constants.appId
    '    sessionToken = Constants.sessionToken
    'End Sub


    'Function listMarketCatalogue() As String
    '    Dim ListMarketCatalogueResponse As Object = Nothing
    '    Dim strRequest As String = ""
    '    Try  '~~>https://api.developer.betfair.com/services/webapps/docs/display/1smk3cen4v3lu3yomq5qye0ni/Betting+Enums
    '        '~~> Sample CatalogFull As String = "{""jsonrpc"": ""2.0"", ""method"":""SportsAPING/v1.0/listMarketCatalogue"",""params"": " & "{""filter"":{""eventTypeIds"":[""7""],""marketCountries"":[""GB""] ,""marketTypeCodes"":[""WIN""]},""marketStartTime"":[],""venues"":"""",""sort"":""FIRST_TO_START"",""maxResults"":" & NOR & ",""marketProjection"":[""RUNNER_DESCRIPTION"",""EVENT"",""MARKET_START_TIME"",""RUNNER_METADATA"",""EVENT_TYPE"",""COMPETITION""], ""marketStatus"":""OPEN"" }" & ", ""id"": 1}"  '~~>Edit,""EVENT"",""MARKET_START_TIME""
    '        Dim NOR As Integer = Constants.noOfRaces 'Use this in the only argument I will probably require
    '        strRequest = "{""jsonrpc"": ""2.0"", ""method"":""SportsAPING/v1.0/listMarketCatalogue"",""params"": " & "{""filter"":{""eventTypeIds"":[""7""],""marketCountries"":[""GB""] ,""marketTypeCodes"":[""WIN""]},""marketStartTime"":[],""venues"":[],""sort"":""FIRST_TO_START"",""maxResults"":" & NOR & ",""marketProjection"":[""RUNNER_DESCRIPTION"",""MARKET_START_TIME"",""EVENT""], ""marketStatus"":""OPEN"" }" & ", ""id"": 1}"  '~~>Edit,""EVENT"",""MARKET_START_TIME"",""RUNNER_METADATA"",""EVENT_TYPE"",""COMPETITION"",""MARKET_DESCRIPTION""
    '        '~~> Send the catalogue request string with the CreateRequest Function
    '        ListMarketCatalogueResponse = client.CreateRequest(appId, sessionToken, strRequest)
    '    Catch ex As System.Exception
    '        MsgBox("GetMarketCatalog Prob" & vbCrLf & ex.Message)
    '    End Try
    '    Return ListMarketCatalogueResponse.ToString  '~~>~~> Show all the required Response Text
    'End Function  '~~> GetListMarketCatalog()


    'Public Function listMarketCatalogue(ByVal marketFilter As MarketFilter, ByVal marketProjections As ISet(Of MarketProjection), ByVal marketSort As MarketSort, Optional ByVal maxResult As String = "1", Optional ByVal locale As String = Nothing) As IList(Of MarketCatalogue)
    '    Dim ListMarketCatalogueResponse As Object = Nothing
    '    Dim strRequest As String = ""
    '    Try  '~~>https://api.developer.betfair.com/services/webapps/docs/display/1smk3cen4v3lu3yomq5qye0ni/Betting+Enums
    '        '~~> Sample CatalogFull As String = "{""jsonrpc"": ""2.0"", ""method"":""SportsAPING/v1.0/listMarketCatalogue"",""params"": " & "{""filter"":{""eventTypeIds"":[""7""],""marketCountries"":[""GB""] ,""marketTypeCodes"":[""WIN""]},""marketStartTime"":[],""venues"":"""",""sort"":""FIRST_TO_START"",""maxResults"":" & NOR & ",""marketProjection"":[""RUNNER_DESCRIPTION"",""EVENT"",""MARKET_START_TIME"",""RUNNER_METADATA"",""EVENT_TYPE"",""COMPETITION""], ""marketStatus"":""OPEN"" }" & ", ""id"": 1}"  '~~>Edit,""EVENT"",""MARKET_START_TIME""
    '        Dim NOR As Integer = Constants.noOfRaces 'Use this in the only argument I will probably require
    '        strRequest = "{""jsonrpc"": ""2.0"", ""method"":""SportsAPING/v1.0/listMarketCatalogue"",""params"": " & "{""filter"":{""eventTypeIds"":[""7""],""marketCountries"":[""GB""] ,""marketTypeCodes"":[""WIN""]},""marketStartTime"":[],""venues"":[],""sort"":""FIRST_TO_START"",""maxResults"":"10",""marketProjection"":[""RUNNER_DESCRIPTION"",""MARKET_START_TIME"",""EVENT""], ""marketStatus"":""OPEN"" }" & ", ""id"": 1}"  '~~>Edit,""EVENT"",""MARKET_START_TIME"",""RUNNER_METADATA"",""EVENT_TYPE"",""COMPETITION"",""MARKET_DESCRIPTION""
    '        '~~> Send the catalogue request string with the CreateRequest Function
    '        ListMarketCatalogueResponse = client.CreateRequest(appId, sessionToken, strRequest)
    '    Catch ex As System.Exception
    '        MsgBox("GetMarketCatalog Prob" & vbCrLf & ex.Message)
    '    End Try
    '    Return Nothing  '~~>~~> Show all the required Response Text
    'End Function

    Inherits HttpWebClientProtocol
    Implements ApiClientInterface

    Private privateEndPoint As String
    Public Property EndPoint() As String
        Get
            Return privateEndPoint
        End Get
        Private Set(ByVal value As String)
            privateEndPoint = value
        End Set
    End Property
    Private Shared ReadOnly operationReturnTypeMap As IDictionary(Of String, Type) = New Dictionary(Of String, Type)()
    Public Const APPKEY_HEADER As String = "X-Application"
    Public Const SESSION_TOKEN_HEADER As String = "X-Authentication"
    Public Property CustomHeaders() As NameValueCollection
    'Private Shared ReadOnly LIST_EVENT_TYPES_METHOD As String = "SportsAPING/v1.0/listEventTypes"
    'Private Shared ReadOnly LIST_MARKET_CATALOGUE_METHOD As String = "SportsAPING/v1.0/listMarketCatalogue"
    'Private Shared ReadOnly LIST_MARKET_BOOK_METHOD As String = "SportsAPING/v1.0/listMarketBook"
    'Private Shared ReadOnly PLACE_ORDERS_METHOD As String = "SportsAPING/v1.0/placeOrders"
    'Private Shared ReadOnly GET_ACCOUNT_FUNDS_METHOD As String = "SportsAPING/v1.0/placeOrders"

    Private Shared ReadOnly LIST_EVENT_TYPES_METHOD As String = "SportsAPING/v1.2/listEventTypes"
    Private Shared ReadOnly LIST_MARKET_CATALOGUE_METHOD As String = "SportsAPING/v1.2/listMarketCatalogue"
    Private Shared ReadOnly LIST_MARKET_BOOK_METHOD As String = "SportsAPING/v1.2/listMarketBook"
    Private Shared ReadOnly PLACE_ORDERS_METHOD As String = "SportsAPING/v1.2/placeOrders"
    Private Shared ReadOnly GET_ACCOUNT_FUNDS_METHOD As String = "AccountAPING/v1.0/getAccountFunds"

    Private Shared ReadOnly FILTER As String = "filter"
    Private Shared ReadOnly LOCALE As String = "locale"
    Private Shared ReadOnly CURRENCY_CODE As String = "currencyCode"
    Private Shared ReadOnly MARKET_PROJECTION As String = "marketProjection"
    Private Shared ReadOnly MATCH_PROJECTION As String = "matchProjection"
    Private Shared ReadOnly ORDER_PROJECTION As String = "orderProjection"
    Private Shared ReadOnly PRICE_PROJECTION As String = "priceProjection"
    Private Shared ReadOnly SORT As String = "sort"
    Private Shared ReadOnly MAX_RESULTS As String = "maxResults"
    Private Shared ReadOnly MARKET_IDS As String = "marketIds"
    Private Shared ReadOnly MARKET_ID As String = "marketId"
    Private Shared ReadOnly INSTRUCTIONS As String = "instructions"
    Private Shared ReadOnly CUSTOMER_REFERENCE As String = "customerRef"

    Public Sub New(ByVal endPoint As String, ByVal appKey As String, ByVal sessionToken As String)
        Me.EndPoint = endPoint & "/json-rpc/v1"
        CustomHeaders = New NameValueCollection()
        If appKey IsNot Nothing Then
            CustomHeaders(APPKEY_HEADER) = appKey
        End If
        If sessionToken IsNot Nothing Then
            CustomHeaders(SESSION_TOKEN_HEADER) = sessionToken
        End If
    End Sub


    'Public Function listEventTypes(ByVal marketFilter As MarketFilter, Optional ByVal locale As String = Nothing) As IList(Of EventTypeResult) Implements ApiClientInterface.listEventTypes
    '    Dim args = New Dictionary(Of String, Object)()
    '    args(FILTER) = marketFilter
    '    args(JsonRpcClient.LOCALE) = locale
    '    Return Invoke(Of List(Of EventTypeResult))(LIST_EVENT_TYPES_METHOD, args)

    'End Function

    Public Function listEventTypesUk(ByVal marketFilter As MarketFilter, Optional ByVal locale As String = Nothing) As IList(Of EventTypeResult) Implements ApiClientInterface.listEventTypesUk
        Dim args = New Dictionary(Of String, Object)()
        args(FILTER) = marketFilter
        args(JsonRpcClient.LOCALE) = locale
        Return InvokeBettingUk(Of List(Of EventTypeResult))(LIST_EVENT_TYPES_METHOD, args)

    End Function

    Public Function listEventTypesAus(ByVal marketFilter As MarketFilter, Optional ByVal locale As String = Nothing) As IList(Of EventTypeResult) Implements ApiClientInterface.listEventTypesAus
        Dim args = New Dictionary(Of String, Object)()
        args(FILTER) = marketFilter
        args(JsonRpcClient.LOCALE) = locale
        Return InvokeBettingAus(Of List(Of EventTypeResult))(LIST_EVENT_TYPES_METHOD, args)

    End Function

    'Public Function listMarketCatalogue(ByVal marketFilter As MarketFilter, ByVal marketProjections As ISet(Of MarketProjection), ByVal marketSort As MarketSort, Optional ByVal maxResult As String = "1", Optional ByVal locale As String = Nothing) As IList(Of MarketCatalogue) Implements ApiClientInterface.listMarketCatalogue
    '    Dim args = New Dictionary(Of String, Object)()
    '    args(FILTER) = marketFilter
    '    args(MARKET_PROJECTION) = marketProjections
    '    args(SORT) = marketSort
    '    args(MAX_RESULTS) = maxResult
    '    args(JsonRpcClient.LOCALE) = locale
    '    Return Invoke(Of List(Of MarketCatalogue))(LIST_MARKET_CATALOGUE_METHOD, args)
    'End Function

    Public Function listMarketCatalogueUk(ByVal marketFilter As MarketFilter, ByVal marketProjections As ISet(Of MarketProjection), ByVal marketSort As MarketSort, Optional ByVal maxResult As String = "1", Optional ByVal locale As String = Nothing) As IList(Of MarketCatalogue) Implements ApiClientInterface.listMarketCatalogueUk
        Dim args = New Dictionary(Of String, Object)()
        args(FILTER) = marketFilter
        args(MARKET_PROJECTION) = marketProjections
        args(SORT) = marketSort
        args(MAX_RESULTS) = maxResult
        args(JsonRpcClient.LOCALE) = locale
        Return InvokeBettingUk(Of List(Of MarketCatalogue))(LIST_MARKET_CATALOGUE_METHOD, args)
    End Function

    Public Function listMarketCatalogueAus(ByVal marketFilter As MarketFilter, ByVal marketProjections As ISet(Of MarketProjection), ByVal marketSort As MarketSort, Optional ByVal maxResult As String = "1", Optional ByVal locale As String = Nothing) As IList(Of MarketCatalogue) Implements ApiClientInterface.listMarketCatalogueAus
        Dim args = New Dictionary(Of String, Object)()
        args(FILTER) = marketFilter
        args(MARKET_PROJECTION) = marketProjections
        args(SORT) = marketSort
        args(MAX_RESULTS) = maxResult
        args(JsonRpcClient.LOCALE) = locale
        Return InvokeBettingAus(Of List(Of MarketCatalogue))(LIST_MARKET_CATALOGUE_METHOD, args)
    End Function


    'Public Function listMarketBook(ByVal marketIds As IList(Of String), ByVal priceProjection As PriceProjection, Optional ByVal orderProjection? As OrderProjection = Nothing, Optional ByVal matchProjection? As MatchProjection = Nothing, Optional ByVal currencyCode As String = Nothing, Optional ByVal locale As String = Nothing) As IList(Of MarketBook) Implements ApiClientInterface.listMarketBook
    '    Dim args = New Dictionary(Of String, Object)()
    '    args(MARKET_IDS) = marketIds
    '    args(PRICE_PROJECTION) = priceProjection
    '    args(ORDER_PROJECTION) = orderProjection
    '    args(MATCH_PROJECTION) = matchProjection
    '    args(JsonRpcClient.LOCALE) = locale
    '    args(CURRENCY_CODE) = currencyCode
    '    Return Invoke(Of List(Of MarketBook))(LIST_MARKET_BOOK_METHOD, args)
    'End Function

    Public Function listMarketBookUk(ByVal marketIds As IList(Of String), ByVal priceProjection As PriceProjection, Optional ByVal orderProjection? As OrderProjection = Nothing, Optional ByVal matchProjection? As MatchProjection = Nothing, Optional ByVal currencyCode As String = Nothing, Optional ByVal locale As String = Nothing) As IList(Of MarketBook) Implements ApiClientInterface.listMarketBookUk
        Dim args = New Dictionary(Of String, Object)()
        args(MARKET_IDS) = marketIds
        args(PRICE_PROJECTION) = priceProjection
        args(ORDER_PROJECTION) = orderProjection
        args(MATCH_PROJECTION) = matchProjection
        args(JsonRpcClient.LOCALE) = locale
        args(CURRENCY_CODE) = currencyCode
        Return InvokeBettingUk(Of List(Of MarketBook))(LIST_MARKET_BOOK_METHOD, args)
    End Function


    Public Function listMarketBookAus(ByVal marketIds As IList(Of String), ByVal priceProjection As PriceProjection, Optional ByVal orderProjection? As OrderProjection = Nothing, Optional ByVal matchProjection? As MatchProjection = Nothing, Optional ByVal currencyCode As String = Nothing, Optional ByVal locale As String = Nothing) As IList(Of MarketBook) Implements ApiClientInterface.listMarketBookAus
        Dim args = New Dictionary(Of String, Object)()
        args(MARKET_IDS) = marketIds
        args(PRICE_PROJECTION) = priceProjection
        args(ORDER_PROJECTION) = orderProjection
        args(MATCH_PROJECTION) = matchProjection
        args(JsonRpcClient.LOCALE) = locale
        args(CURRENCY_CODE) = currencyCode
        Return InvokeBettingAus(Of List(Of MarketBook))(LIST_MARKET_BOOK_METHOD, args)
    End Function

    'Public Function placeOrders(ByVal marketId As String, ByVal customerRef As String, ByVal placeInstructions As IList(Of PlaceInstruction), Optional ByVal locale As String = Nothing) As PlaceExecutionReport Implements ApiClientInterface.placeOrders
    '    Dim args = New Dictionary(Of String, Object)()
    '    args(MARKET_ID) = marketId
    '    args(INSTRUCTIONS) = placeInstructions
    '    args(CUSTOMER_REFERENCE) = customerRef
    '    args(JsonRpcClient.LOCALE) = locale
    '    Return Invoke(Of PlaceExecutionReport)(PLACE_ORDERS_METHOD, args)
    'End Function

    Public Function placeOrdersUk(ByVal marketId As String, ByVal customerRef As String, ByVal placeInstructions As IList(Of PlaceInstruction), Optional ByVal locale As String = Nothing) As PlaceExecutionReport Implements ApiClientInterface.placeOrdersUk
        Dim args = New Dictionary(Of String, Object)()
        args(MARKET_ID) = marketId
        args(INSTRUCTIONS) = placeInstructions
        args(CUSTOMER_REFERENCE) = customerRef
        args(JsonRpcClient.LOCALE) = locale
        Return InvokeBettingUk(Of PlaceExecutionReport)(PLACE_ORDERS_METHOD, args)
    End Function

    Public Function placeOrdersAus(ByVal marketId As String, ByVal customerRef As String, ByVal placeInstructions As IList(Of PlaceInstruction), Optional ByVal locale As String = Nothing) As PlaceExecutionReport Implements ApiClientInterface.placeOrdersAus
        Dim args = New Dictionary(Of String, Object)()
        args(MARKET_ID) = marketId
        args(INSTRUCTIONS) = placeInstructions
        args(CUSTOMER_REFERENCE) = customerRef
        args(JsonRpcClient.LOCALE) = locale
        Return InvokeBettingAus(Of PlaceExecutionReport)(PLACE_ORDERS_METHOD, args)
    End Function

    'Public Function getAccountFunds() As AccountFundsResponse Implements ApiClientInterface.getAccountFunds
    '    Dim args = New Dictionary(Of String, Object)()
    '    Return Invoke(Of AccountFundsResponse)(GET_ACCOUNT_FUNDS_METHOD, Nothing)
    'End Function

    Public Function getAccountFundsUk() As AccountFundsResponse Implements ApiClientInterface.getAccountFundsUk
        Dim args = New Dictionary(Of String, Object)()
        Return InvokeAccountUk(Of AccountFundsResponse)(GET_ACCOUNT_FUNDS_METHOD, Nothing)
    End Function

    Public Function getAccountFundsAus() As AccountFundsResponse Implements ApiClientInterface.getAccountFundsAus
        Dim args = New Dictionary(Of String, Object)()
        Return InvokeAccountAus(Of AccountFundsResponse)(GET_ACCOUNT_FUNDS_METHOD, Nothing)
    End Function



    Protected Function CreateWebRequest(ByVal uri As Uri) As WebRequest
        Dim request As WebRequest = WebRequest.Create(New Uri(EndPoint))
        request.Method = "POST"
        request.ContentType = "application/json-rpc"
        request.Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1,utf-8")
        request.Headers.Add(CustomHeaders)
        Return request
    End Function


    Public Function Invoke(Of T)(ByVal method As String, Optional ByVal args As IDictionary(Of String, Object) = Nothing) As T
        If method Is Nothing Then
            Throw New ArgumentNullException("method")
        End If
        If method.Length = 0 Then
            Throw New ArgumentException(Nothing, "method")
        End If

        Dim postDataStr As String = Nothing
        postDataStr = "{""jsonrpc"": ""2.0"", ""method"":" & Chr(34) & method & Chr(34) & ",""params"": " & JsonConvert.Serialize(Of IDictionary(Of String, Object))(args) & ", ""id"": 1}"
        Dim Response = CreateRequest(Constants.appId, Constants.sessionToken, postDataStr)


        Dim jsonResponse = JsonConvertNew.Import(Of T)(Response)

        Logger.writeErrorLogEntry(vbLf & "Got Response: " & JsonConvertNew.Serialize(Of JsonResponse(Of T))(jsonResponse))

        If jsonResponse.HasError Then
            Throw ReconstituteException(jsonResponse.Error)
        Else
            Return jsonResponse.Result
        End If

        If True Then

        End If
    End Function


    Public Function InvokeBettingUk(Of T)(ByVal method As String, Optional ByVal args As IDictionary(Of String, Object) = Nothing) As T
        If method Is Nothing Then
            Throw New ArgumentNullException("method")
        End If
        If method.Length = 0 Then
            Throw New ArgumentException(Nothing, "method")
        End If

        Dim postDataStr As String = Nothing
        postDataStr = "{""jsonrpc"": ""2.0"", ""method"":" & Chr(34) & method & Chr(34) & ",""params"": " & JsonConvert.Serialize(Of IDictionary(Of String, Object))(args) & ", ""id"": 1}"
        Dim Response = CreateRequestBettingUk(Constants.appId, Constants.sessionToken, postDataStr)


        Dim jsonResponse = JsonConvertNew.Import(Of T)(Response)

        Logger.writeErrorLogEntry(vbLf & "Got Response: " & JsonConvertNew.Serialize(Of JsonResponse(Of T))(jsonResponse))

        If jsonResponse.HasError Then
            Throw ReconstituteException(jsonResponse.Error)
        Else
            Return jsonResponse.Result
        End If
    End Function

    Public Function InvokeBettingAus(Of T)(ByVal method As String, Optional ByVal args As IDictionary(Of String, Object) = Nothing) As T
        If method Is Nothing Then
            Throw New ArgumentNullException("method")
        End If
        If method.Length = 0 Then
            Throw New ArgumentException(Nothing, "method")
        End If

        Dim postDataStr As String = Nothing
        postDataStr = "{""jsonrpc"": ""2.0"", ""method"":" & Chr(34) & method & Chr(34) & ",""params"": " & JsonConvert.Serialize(Of IDictionary(Of String, Object))(args) & ", ""id"": 1}"
        Dim Response = CreateRequestBettingAus(Constants.appId, Constants.sessionToken, postDataStr)


        Dim jsonResponse = JsonConvertNew.Import(Of T)(Response)

        Logger.writeErrorLogEntry(vbLf & "Got Response: " & JsonConvertNew.Serialize(Of JsonResponse(Of T))(jsonResponse))

        If jsonResponse.HasError Then
            Throw ReconstituteException(jsonResponse.Error)
        Else
            Return jsonResponse.Result
        End If
    End Function

    Public Function InvokeAccountUk(Of T)(ByVal method As String, Optional ByVal args As IDictionary(Of String, Object) = Nothing) As T
        If method Is Nothing Then
            Throw New ArgumentNullException("method")
        End If
        If method.Length = 0 Then
            Throw New ArgumentException(Nothing, "method")
        End If

        Dim postDataStr As String = Nothing
        postDataStr = "{""jsonrpc"": ""2.0"", ""method"":" & Chr(34) & method & Chr(34) & ",""params"": " & JsonConvert.Serialize(Of IDictionary(Of String, Object))(args) & ", ""id"": 1}"
        Dim Response = CreateRequestAccountUk(Constants.appId, Constants.sessionToken, postDataStr)


        Dim jsonResponse = JsonConvertNew.Import(Of T)(Response)

        Logger.writeErrorLogEntry(vbLf & "Got Response: " & JsonConvertNew.Serialize(Of JsonResponse(Of T))(jsonResponse))

        If jsonResponse.HasError Then
            Throw ReconstituteException(jsonResponse.Error)
        Else
            Return jsonResponse.Result
        End If
    End Function


    Public Function InvokeAccountAus(Of T)(ByVal method As String, Optional ByVal args As IDictionary(Of String, Object) = Nothing) As T
        If method Is Nothing Then
            Throw New ArgumentNullException("method")
        End If
        If method.Length = 0 Then
            Throw New ArgumentException(Nothing, "method")
        End If

        Dim postDataStr As String = Nothing
        postDataStr = "{""jsonrpc"": ""2.0"", ""method"":" & Chr(34) & method & Chr(34) & ",""params"": " & JsonConvert.Serialize(Of IDictionary(Of String, Object))(args) & ", ""id"": 1}"
        Dim Response = CreateRequestAccountAus(Constants.appId, Constants.sessionToken, postDataStr)


        Dim jsonResponse = JsonConvertNew.Import(Of T)(Response)

        Logger.writeErrorLogEntry(vbLf & "Got Response: " & JsonConvertNew.Serialize(Of JsonResponse(Of T))(jsonResponse))

        If jsonResponse.HasError Then
            Throw ReconstituteException(jsonResponse.Error)
        Else
            Return jsonResponse.Result
        End If
    End Function

    Private Shared Function ReconstituteException(ByVal ex As Api_ng_sample_code.TO.Exception) As System.Exception
        Dim data = ex.Data

        ' API-NG exception -- it must have "data" element to tell us which exception
        Dim exceptionName = data.Property("exceptionname").Value.ToString()
        Dim exceptionData = data.Property(exceptionName).Value.ToString()
        Return JsonConvert.Deserialize(Of APINGException)(exceptionData)
    End Function


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
        Catch ex As APINGException
            '~~> Show any errors in this method for an error log etc Just use a messagebox for now
            MsgBox("CreateRequest APINGException Error" & vbCrLf & ex.Message)
        Catch ex As System.Exception
            MsgBox("CreateRequest Error" & vbCrLf & ex.Message)
        End Try
        Return responseFromServer   '~~> Function Output
        '~~> Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()
    End Function '~~>Creates the requst for Data to be loaded


    Function CreateRequestBettingUk(AppKey As String, SessToken As String, postData As String)
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
        Catch ex As APINGException
            '~~> Show any errors in this method for an error log etc Just use a messagebox for now
            MsgBox("CreateRequest APINGException Error" & vbCrLf & ex.Message)
        Catch ex As System.Exception
            MsgBox("CreateRequest Error" & vbCrLf & ex.Message)
        End Try
        Return responseFromServer   '~~> Function Output
        '~~> Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()
    End Function '~~>Creates the requst for Data to be loaded


    Function CreateRequestBettingAus(AppKey As String, SessToken As String, postData As String)
        Dim Url As String = "https://api-au.betfair.com/exchange/betting/json-rpc/v1/"
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
        Catch ex As APINGException
            '~~> Show any errors in this method for an error log etc Just use a messagebox for now
            MsgBox("CreateRequest APINGException Error" & vbCrLf & ex.Message)
        Catch ex As System.Exception
            MsgBox("CreateRequest Error" & vbCrLf & ex.Message)
        End Try
        Return responseFromServer   '~~> Function Output
        '~~> Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()
    End Function '~~>Creates the requst for Data to be loaded


    Function CreateRequestAccountUk(AppKey As String, SessToken As String, postData As String)
        Dim Url As String = "https://api.betfair.com/exchange/account/json-rpc/v1/"
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
        Catch ex As APINGException
            '~~> Show any errors in this method for an error log etc Just use a messagebox for now
            MsgBox("CreateRequest APINGException Error" & vbCrLf & ex.Message)
        Catch ex As System.Exception
            MsgBox("CreateRequest Error" & vbCrLf & ex.Message)
        End Try
        Return responseFromServer   '~~> Function Output
        '~~> Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()
    End Function '~~>Creates the requst for Data to be loaded


    Function CreateRequestAccountAus(AppKey As String, SessToken As String, postData As String)
        Dim Url As String = "https://api-au.betfair.com/exchange/account/json-rpc/v1/"
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
        Catch ex As APINGException
            '~~> Show any errors in this method for an error log etc Just use a messagebox for now
            MsgBox("CreateRequest APINGException Error" & vbCrLf & ex.Message)
        Catch ex As System.Exception
            MsgBox("CreateRequest Error" & vbCrLf & ex.Message)
        End Try
        Return responseFromServer   '~~> Function Output
        '~~> Clean up the streams.
        reader.Close()
        dataStream.Close()
        response.Close()
    End Function '~~>Creates the requst for Data to be loaded
End Class



