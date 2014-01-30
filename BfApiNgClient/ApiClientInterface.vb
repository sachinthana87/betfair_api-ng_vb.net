Imports OddCompBotApiNg.Api_ng_sample_code.TO

Public Interface ApiClientInterface
    ' '''        
    ' '''         * calls api-ng to get a list of events
    ' '''         * 
    ' '''         * 
    'Function listEventTypes(ByVal marketFilter As MarketFilter, Optional ByVal locale As String = Nothing) As IList(Of EventTypeResult)

    ' '''        
    ' '''         * calls api-ng to get a list of market catalogues
    ' '''         * 
    'Function listMarketCatalogue(ByVal marketFilter As MarketFilter, ByVal marketProjections As ISet(Of MarketProjection), ByVal marketSort As MarketSort, Optional ByVal maxResult As String = "1", Optional ByVal locale As String = Nothing) As IList(Of MarketCatalogue)

    ' '''        
    ' '''         * calls api-ng to get more detailed info about the specified markets
    ' '''         * 
    'Function listMarketBook(ByVal marketIds As IList(Of String), ByVal priceProjection As PriceProjection, Optional ByVal orderProjection? As OrderProjection = Nothing, Optional ByVal matchProjection? As MatchProjection = Nothing, Optional ByVal currencyCode As String = Nothing, Optional ByVal locale As String = Nothing) As IList(Of MarketBook)

    ' '''        
    ' '''         * places a bet
    ' '''         * 
    'Function placeOrders(ByVal marketId As String, ByVal customerRef As String, ByVal placeInstructions As IList(Of PlaceInstruction), Optional ByVal locale As String = Nothing) As PlaceExecutionReport

    ' '''        
    ' '''         * get account funds
    ' '''         * 
    'Function getAccountFunds() As AccountFundsResponse





    '~~~> UK exchange

    '''        
    '''         * calls api-ng to get a list of events
    '''         * 
    '''         * 
    Function listEventTypesUk(ByVal marketFilter As MarketFilter, Optional ByVal locale As String = Nothing) As IList(Of EventTypeResult)

    '''        
    '''         * calls api-ng to get a list of market catalogues
    '''         * 
    Function listMarketCatalogueUk(ByVal marketFilter As MarketFilter, ByVal marketProjections As ISet(Of MarketProjection), ByVal marketSort As MarketSort, Optional ByVal maxResult As String = "1", Optional ByVal locale As String = Nothing) As IList(Of MarketCatalogue)

    '''        
    '''         * calls api-ng to get more detailed info about the specified markets
    '''         * 
    Function listMarketBookUk(ByVal marketIds As IList(Of String), ByVal priceProjection As PriceProjection, Optional ByVal orderProjection? As OrderProjection = Nothing, Optional ByVal matchProjection? As MatchProjection = Nothing, Optional ByVal currencyCode As String = Nothing, Optional ByVal locale As String = Nothing) As IList(Of MarketBook)

    '''        
    '''         * places a bet
    '''         * 
    Function placeOrdersUk(ByVal marketId As String, ByVal customerRef As String, ByVal placeInstructions As IList(Of PlaceInstruction), Optional ByVal locale As String = Nothing) As PlaceExecutionReport

    '''        
    '''         * get account funds
    '''         * 
    Function getAccountFundsUk() As AccountFundsResponse








    '~~~> Aus exchange

    '''        
    '''         * calls api-ng to get a list of events
    '''         * 
    '''         * 
    Function listEventTypesAus(ByVal marketFilter As MarketFilter, Optional ByVal locale As String = Nothing) As IList(Of EventTypeResult)

    '''        
    '''         * calls api-ng to get a list of market catalogues
    '''         * 
    Function listMarketCatalogueAus(ByVal marketFilter As MarketFilter, ByVal marketProjections As ISet(Of MarketProjection), ByVal marketSort As MarketSort, Optional ByVal maxResult As String = "1", Optional ByVal locale As String = Nothing) As IList(Of MarketCatalogue)

    '''        
    '''         * calls api-ng to get more detailed info about the specified markets
    '''         * 
    Function listMarketBookAus(ByVal marketIds As IList(Of String), ByVal priceProjection As PriceProjection, Optional ByVal orderProjection? As OrderProjection = Nothing, Optional ByVal matchProjection? As MatchProjection = Nothing, Optional ByVal currencyCode As String = Nothing, Optional ByVal locale As String = Nothing) As IList(Of MarketBook)

    '''        
    '''         * places a bet
    '''         * 
    Function placeOrdersAus(ByVal marketId As String, ByVal customerRef As String, ByVal placeInstructions As IList(Of PlaceInstruction), Optional ByVal locale As String = Nothing) As PlaceExecutionReport

    '''        
    '''         * get account funds
    '''         * 
    Function getAccountFundsAus() As AccountFundsResponse

End Interface

