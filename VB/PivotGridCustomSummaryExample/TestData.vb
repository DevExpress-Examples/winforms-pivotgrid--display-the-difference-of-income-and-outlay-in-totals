Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace PivotGridCustomSummaryExample
	Friend Class TestData
		Public Sub New(ByVal name As String, ByVal [date] As Date, ByVal value As Decimal, ByVal type As String)
			Me.Name = name
			Me.Date = [date]
			Me.Value = value
			Me.Type = type
		End Sub

		Public Property Name() As String
		Public Property [Date]() As Date
		Public Property Value() As Decimal
		Public Property Type() As String


		Public Shared Function GetData() As List(Of TestData)
			Dim startDate As New Date(2019, 10, 15)
			Dim dataList As New List(Of TestData) From {
				New TestData("Aaa", startDate, 7, "Income"),
				New TestData("Aaa", startDate.AddDays(1), 4, "Outlay"),
				New TestData("Bbb", startDate, 12, "Outlay"),
				New TestData("Bbb", startDate.AddDays(1), 14, "Outlay"),
				New TestData("Ccc", startDate, 11, "Income"),
				New TestData("Ccc", startDate.AddDays(1), 10, "Income"),
				New TestData("Aaa", startDate.AddYears(1), 4, "Income"),
				New TestData("Aaa", startDate.AddYears(1).AddDays(1), 2, "Income"),
				New TestData("Bbb", startDate.AddYears(1), 3, "Income"),
				New TestData("Bbb", startDate.AddDays(1).AddYears(1), 1, "Outlay"),
				New TestData("Ccc", startDate.AddYears(1), 8, "Income"),
				New TestData("Ccc", startDate.AddDays(1).AddYears(1), 22, "Outlay")
			}
			Return dataList
		End Function
	End Class
End Namespace
