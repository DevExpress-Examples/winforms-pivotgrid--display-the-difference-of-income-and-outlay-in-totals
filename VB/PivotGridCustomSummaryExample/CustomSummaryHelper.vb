Imports DevExpress.XtraPivotGrid
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace PivotGridCustomSummaryExample
	Friend NotInheritable Class CustomSummaryHelper

		Private Sub New()
		End Sub

		Public Shared Function GetGroupSummary(ByVal groupedDataSource As IEnumerable(Of IGrouping(Of Object, PivotDrillDownDataRow)), ByVal target As Object, ByVal dataFieldName As String) As Decimal
			Dim targetGroup = groupedDataSource.FirstOrDefault(Function(g) Object.Equals(g.Key, target))
			If targetGroup Is Nothing Then
				Return 0
			End If
			Return targetGroup.Sum(Function(r) Convert.ToDecimal(r(dataFieldName)))
		End Function

		Public Shared Function ShouldCalculateCustomValue(ByVal groupField As PivotGridField, ByVal e As PivotGridCustomSummaryEventArgs) As Boolean
			If Not groupField.Visible OrElse groupField.Area = PivotArea.FilterArea OrElse groupField.Area = PivotArea.DataArea Then
				Return True
			End If
			If groupField.Area = PivotArea.RowArea AndAlso (e.RowField Is Nothing OrElse e.RowField.AreaIndex < groupField.AreaIndex) Then
				Return True
			End If
			If groupField.Area = PivotArea.ColumnArea AndAlso (e.ColumnField Is Nothing OrElse e.ColumnField.AreaIndex < groupField.AreaIndex) Then
				Return True
			End If
			Return False
		End Function
	End Class
End Namespace
