Imports OddCompBotApiNg.Api_ng_sample_code.TO

Public Class CreateApiCalls

    Dim client As ApiClientInterface = Nothing

    Public Sub New()
        client = New JsonRpcClient(Constants.url, Constants.appId, Constants.sessionToken)
    End Sub

    Public Function returnTodaysHorseRaces(ByVal ukMarketsOnly As Boolean, ByVal ausMarketsOnly As Boolean, ByVal winMarketsOnly As Boolean, ByVal placeMarketsOnly As Boolean, ByVal allMarketsFlag As Boolean, ByVal noOfMarketsToDisplay As Integer, ByVal displayMarketsFrom As Date, ByVal displayMarketsTo As Date) As List(Of MarketCatalogue)
        Try '~~>Use Json Now to create a Race String and Mkt ID
            Dim ukMarketList As List(Of MarketCatalogue)
            Dim ausMarketList As List(Of MarketCatalogue)
            Dim finalMarketList As List(Of MarketCatalogue) = New List(Of MarketCatalogue)

            Dim maxNoOfResults As Integer = 1000
            Dim locale As String = ""

            Dim marketFilter As MarketFilter = New MarketFilter()
            Dim marketProjections As ISet(Of MarketProjection) = New HashSet(Of MarketProjection)
            Dim marketSort As MarketSort = New MarketSort()

            marketFilter.EventTypeIds = New HashSet(Of String)
            marketFilter.MarketCountries = New HashSet(Of String)
            marketFilter.MarketTypeCodes = New HashSet(Of String)
            marketFilter.MarketStartTime = New TimeRange

            marketFilter.EventTypeIds.Add("7")
            'marketFilter.MarketCountries.Add("GB")
            If winMarketsOnly = True Then
                marketFilter.MarketTypeCodes.Add("WIN")
            End If
            If placeMarketsOnly = True Then
                marketFilter.MarketTypeCodes.Add("PLACE")
            End If

            marketFilter.MarketStartTime.From = displayMarketsFrom
            marketFilter.MarketStartTime.To = displayMarketsTo


            marketSort = Api_ng_sample_code.TO.MarketSort.FIRST_TO_START

            marketProjections.Add(MarketProjection.RUNNER_DESCRIPTION)
            marketProjections.Add(MarketProjection.EVENT)
            marketProjections.Add(MarketProjection.MARKET_START_TIME)

            If allMarketsFlag = False Then
                maxNoOfResults = noOfMarketsToDisplay
            End If



            If (ukMarketsOnly = True) Then
                ukMarketList = client.listMarketCatalogueUk(marketFilter, marketProjections, marketSort, maxNoOfResults, locale) '~~>Use Directly
                finalMarketList.AddRange(ukMarketList)
            End If

            If (ausMarketsOnly = True) Then
                ausMarketList = client.listMarketCatalogueAus(marketFilter, marketProjections, marketSort, maxNoOfResults, locale) '~~>Use Directly
                finalMarketList.AddRange(ausMarketList)
            End If
            Return finalMarketList
        Catch ex As System.Exception
            Logger.writeErrorLogEntry("Error in returnTodaysHorseRaces method" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function


    Public Function returnMarketPrices(ByVal marketId As String, ByVal exchangeId As Integer) As MarketBook
        Try '~~>Use Json Now to create a Race String and Mkt ID
            Dim marketBook As List(Of MarketBook) = Nothing
            Dim marketIds As New List(Of String)
            marketIds.Add(marketId)

            Dim priceProjection As New PriceProjection()
            priceProjection.PriceData = New HashSet(Of PriceData)
            priceProjection.PriceData.Add(PriceData.EX_BEST_OFFERS)

            Dim orderProjection As New OrderProjection()
            orderProjection = Api_ng_sample_code.TO.OrderProjection.ALL

            Dim locale As String = ""

            If exchangeId = 1 Then
                marketBook = client.listMarketBookUk(marketIds, priceProjection, orderProjection) '~~>Use Directly
            Else
                marketBook = client.listMarketBookAus(marketIds, priceProjection, orderProjection) '~~>Use Directly
            End If


            If marketBook.Count > 0 Then
                Return marketBook.Item(0)
            Else
                Return Nothing
            End If
        Catch ex As System.Exception
            Logger.writeErrorLogEntry("Error in returnTodaysHorseRaces method" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

    Function returnAccountFunds() As Dictionary(Of Integer, AccountFundsResponse)
        Try '~~>Use Json Now to create a Race String and Mkt ID
            Dim accountFundsDic As New Dictionary(Of Integer, AccountFundsResponse)

            Dim accountFundsUk As AccountFundsResponse = client.getAccountFundsUk() '~~>Use Directly
            accountFundsDic.Add(1, accountFundsUk)

            Dim accountFundsAus As AccountFundsResponse = client.getAccountFundsAus() '~~>Use Directly
            accountFundsDic.Add(2, accountFundsAus)

            If accountFundsDic IsNot Nothing Then
                Return accountFundsDic
            Else
                Return Nothing
            End If
        Catch ex As System.Exception
            Logger.writeErrorLogEntry("Error in returnAccountFunds method" & vbCrLf & ex.Message)
            Return Nothing
        End Try
    End Function

End Class
