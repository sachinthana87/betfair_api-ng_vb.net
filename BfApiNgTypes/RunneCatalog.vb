﻿Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Newtonsoft.Json

'This class is written by Sachinthana and seems not working properly. 

Namespace Api_ng_sample_code.TO
    Public Class RunnerCatalog
        <JsonProperty(PropertyName:="selectionId")> _
        Public Property SelectionId() As Long

        <JsonProperty(PropertyName:="runnerName")> _
        Public Property RunnerName() As String

        <JsonProperty(PropertyName:="handicap")> _
        Public Property Handicap() As Double

        <JsonProperty(PropertyName:="sortPriority")> _
        Public Property SortPriority() As Integer

        <JsonProperty(PropertyName:="metadata")> _
        Public Property Metadata() As Dictionary(Of String, String)

        Public Overrides Function ToString() As String
            Return (New StringBuilder()).AppendFormat("{0}", "RunnerCatalog").AppendFormat(" : SelectionId={0}", SelectionId).AppendFormat(" : runnerName={0}", RunnerName).AppendFormat(" : Handicap={0}", Handicap).AppendFormat(" : sortPriority={0}", SortPriority).AppendFormat(" : Metadata={0}", Metadata).ToString()
        End Function
    End Class
End Namespace
