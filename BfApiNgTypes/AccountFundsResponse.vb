Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Newtonsoft.Json

Namespace Api_ng_sample_code.TO
    Public Class AccountFundsResponse
        <JsonProperty(PropertyName:="availableToBetBalance")> _
        Public Property availableToBetBalance() As Double

        <JsonProperty(PropertyName:="exposure")> _
        Public Property exposure() As Double

        <JsonProperty(PropertyName:="retainedCommission")> _
        Public Property retainedCommission() As Double

        <JsonProperty(PropertyName:="exposureLimit")> _
        Public Property exposureLimit() As Double

        Public Overrides Function ToString() As String
            Dim sb = (New StringBuilder()).AppendFormat("{0}", "AccountFundsResponse").AppendFormat(" : availableToBetBalance={0}", availableToBetBalance).AppendFormat(" : exposure={0}", exposure).AppendFormat(" : retainedCommission={0}", retainedCommission).AppendFormat(" : exposureLimit={0}", exposureLimit)

            'If InstructionReports IsNot Nothing AndAlso InstructionReports.Count > 0 Then
            '	Dim idx As Integer = 0
            '	For Each instructionReport In InstructionReports
            '		sb.AppendFormat(" : InstructionReport[{0}]={{{1}}}", idx, instructionReport)
            '		idx += 1
            '	Next instructionReport
            'End If

            Return sb.ToString()
        End Function
    End Class
End Namespace
