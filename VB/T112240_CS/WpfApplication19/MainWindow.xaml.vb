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
'INSTANT VB NOTE: The field value was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private value_Conflict As Double
'INSTANT VB NOTE: The field argument was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private argument_Conflict As DateTime

		Public ReadOnly Property Value() As Double
			Get
				Return value_Conflict
			End Get
		End Property

		Public ReadOnly Property Argument() As DateTime
			Get
				Return argument_Conflict
			End Get
		End Property

		Public Sub New(ByVal argument As DateTime, ByVal value As Double)
			Me.argument_Conflict = argument
			Me.value_Conflict = value
		End Sub
	End Class

	Public Class MyModel
'INSTANT VB NOTE: The field rate was renamed since Visual Basic does not allow fields to have the same name as other class members:
		Private rate_Conflict As New List(Of DateTimePoint)()

		Public ReadOnly Property Rate() As List(Of DateTimePoint)
			Get
				Return rate_Conflict
			End Get
		End Property


		Public Sub New()

			LoadPoints(rate_Conflict, LoadFromFile("/GbpUsdRate.xml"))
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
