Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports Newtonsoft.Json

Namespace Api_ng_sample_code.TO
    Public Class AccountDetailsResponse
        <JsonProperty(PropertyName:="currencyCode")> _
        Public Property currencyCode() As String

        <JsonProperty(PropertyName:="firstName")> _
        Public Property firstName() As String

        <JsonProperty(PropertyName:="lastName")> _
        Public Property lastName() As String

        <JsonProperty(PropertyName:="localeCode")> _
        Public Property localeCode() As String

        <JsonProperty(PropertyName:="region")> _
        Public Property region() As String

        <JsonProperty(PropertyName:="timezone")> _
        Public Property timezone() As String

        <JsonProperty(PropertyName:="discountRate")> _
        Public Property discountRate() As String

        <JsonProperty(PropertyName:="pointsBalance")> _
        Public Property pointsBalance() As Integer

        Public Overrides Function ToString() As String
            Dim sb = (New StringBuilder()).AppendFormat("{0}", "AccountDetailsResponse").AppendFormat(" : currencyCode={0}", currencyCode).AppendFormat(" : firstName={0}", firstName).AppendFormat(" : lastName={0}", lastName).AppendFormat(" : localeCode={0}", localeCode).AppendFormat(" : region={0}", region).AppendFormat(" : timezone={0}", timezone).AppendFormat(" : discountRate={0}", discountRate).AppendFormat(" : pointsBalance={0}", pointsBalance)

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
