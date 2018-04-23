Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Windows
Imports System.Windows.Resources
Imports System.Xml.Linq

Namespace WpfApplication19

	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
			DataContext = New MyModel()
		End Sub
	End Class

	Public Class DateTimePoint
		Private value_Renamed As Double
		Private argument_Renamed As DateTime

		Public ReadOnly Property Value() As Double
			Get
				Return value_Renamed
			End Get
		End Property

		Public ReadOnly Property Argument() As DateTime
			Get
				Return argument_Renamed
			End Get
		End Property

		Public Sub New(ByVal argument As DateTime, ByVal value As Double)
			Me.argument_Renamed = argument
			Me.value_Renamed = value
		End Sub
	End Class

	Public Class MyModel
		Private rate_Renamed As New List(Of DateTimePoint)()

		Public ReadOnly Property Rate() As List(Of DateTimePoint)
			Get
				Return rate_Renamed
			End Get
		End Property


		Public Sub New()

			LoadPoints(rate_Renamed, LoadFromFile("/GbpUsdRate.xml"))
		End Sub

		Private Function LoadFromFile(ByVal xmlFile As String) As XDocument
			Return LoadXmlFromResources(xmlFile)
		End Function

		Public Shared Function LoadXmlFromResources(ByVal fileName As String) As XDocument

			Try
				fileName = "/WpfApplication19;component" & fileName
				Dim uri As New Uri(fileName, UriKind.RelativeOrAbsolute)
				Dim info As StreamResourceInfo = Application.GetResourceStream(uri)
				Return XDocument.Load(info.Stream)
			Catch
				Return Nothing
			End Try
		End Function

		Private Sub LoadPoints(ByVal rate As List(Of DateTimePoint), ByVal document As XDocument)
			If rate IsNot Nothing AndAlso document IsNot Nothing Then
				For Each element As XElement In document.Descendants("CurrencyRate")
					Dim argument As DateTime = DateTime.Parse(element.Element("DateTime").Value)
					Dim value As Double = Double.Parse(element.Element("Rate").Value, CultureInfo.InvariantCulture)
					rate.Add(New DateTimePoint(argument, value))
				Next element
			End If
		End Sub
	End Class
End Namespace
