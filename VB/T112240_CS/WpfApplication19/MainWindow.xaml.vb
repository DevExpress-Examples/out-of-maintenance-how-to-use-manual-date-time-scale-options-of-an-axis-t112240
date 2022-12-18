Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Resources
Imports System.Xml.Linq

Namespace WpfApplication19

    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            DataContext = New MyModel()
        End Sub
    End Class

    Public Class DateTimePoint

        Private valueField As Double

        Private argumentField As Date

        Public ReadOnly Property Value As Double
            Get
                Return valueField
            End Get
        End Property

        Public ReadOnly Property Argument As Date
            Get
                Return argumentField
            End Get
        End Property

        Public Sub New(ByVal argument As Date, ByVal value As Double)
            argumentField = argument
            valueField = value
        End Sub
    End Class

    Public Class MyModel

        Private rateField As List(Of DateTimePoint) = New List(Of DateTimePoint)()

        Public ReadOnly Property Rate As List(Of DateTimePoint)
            Get
                Return rateField
            End Get
        End Property

        Public Sub New()
            LoadPoints(rateField, LoadFromFile("/GbpUsdRate.xml"))
        End Sub

        Private Function LoadFromFile(ByVal xmlFile As String) As XDocument
            Return LoadXmlFromResources(xmlFile)
        End Function

        Public Shared Function LoadXmlFromResources(ByVal fileName As String) As XDocument
            Try
                fileName = "/WpfApplication19;component" & fileName
                Dim uri As Uri = New Uri(fileName, UriKind.RelativeOrAbsolute)
                Dim info As StreamResourceInfo = Application.GetResourceStream(uri)
                Return XDocument.Load(info.Stream)
            Catch
                Return Nothing
            End Try
        End Function

        Private Sub LoadPoints(ByVal rate As List(Of DateTimePoint), ByVal document As XDocument)
            If rate IsNot Nothing AndAlso document IsNot Nothing Then
                For Each element As XElement In document.Descendants("CurrencyRate")
                    Dim argument As Date = Date.Parse(element.Element("DateTime").Value)
                    Dim value As Double = Double.Parse(element.Element("Rate").Value, CultureInfo.InvariantCulture)
                    rate.Add(New DateTimePoint(argument, value))
                Next
            End If
        End Sub
    End Class
End Namespace
