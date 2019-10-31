Imports DevExpress.XtraPivotGrid
Imports System
Imports System.Linq

Namespace PivotGridCustomSummaryExample
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()
			SelectCustomSummaryApproach(pivotGridControl1.OptionsData.DataProcessingEngine)
			AddHandler pivotGridControl1.FieldValueDisplayText, AddressOf PivotGridControl1_FieldValueDisplayText
			pivotGridControl1.DataSource = TestData.GetData()
			pivotGridControl1.BestFit()
		End Sub
		Private Sub SelectCustomSummaryApproach(ByVal dataProcessingEngine As PivotDataProcessingEngine)
			Select Case dataProcessingEngine
				Case PivotDataProcessingEngine.Optimized
					UseOptimizedApproach()
				Case PivotDataProcessingEngine.LegacyOptimized
					UseUnboundExpressionApproach()
				Case Else
					UseLegacyApproach()
			End Select
		End Sub

		Private Sub toggleOptimizedMode_Toggled(ByVal sender As Object, ByVal e As EventArgs) Handles toggleOptimizedMode.Toggled
			If DirectCast(sender, DevExpress.XtraEditors.ToggleSwitch).IsOn Then
				MigrateToOptimizedMode()
				pivotGridControl1.OptionsData.DataProcessingEngine = PivotDataProcessingEngine.Optimized
				SelectCustomSummaryApproach(PivotDataProcessingEngine.Optimized)
			Else
				pivotGridControl1.OptionsData.DataProcessingEngine = PivotDataProcessingEngine.LegacyOptimized
				SelectCustomSummaryApproach(PivotDataProcessingEngine.LegacyOptimized)
			End If
		End Sub
		Private Sub UseLegacyApproach()
			pivotGridControl1.Fields("Value").SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom
			AddHandler pivotGridControl1.CustomSummary, AddressOf pivotGridControl1_CustomSummary
		End Sub
		' The CustomSummary event is a legacy approach.
		Private Sub pivotGridControl1_CustomSummary(ByVal sender As Object, ByVal e As PivotGridCustomSummaryEventArgs)
			If e.DataField.Name = "fieldValue" Then
				If CustomSummaryHelper.ShouldCalculateCustomValue(fieldType, e) Then
					Dim groupedDataSource = e.CreateDrillDownDataSource().Cast(Of PivotDrillDownDataRow)().GroupBy(Function(r) r(fieldType))
					Dim incomeSummary As Decimal = CustomSummaryHelper.GetGroupSummary(groupedDataSource, "Income", e.FieldName)
					Dim outlaySummary As Decimal = CustomSummaryHelper.GetGroupSummary(groupedDataSource, "Outlay", e.FieldName)
					e.CustomValue = incomeSummary - outlaySummary
				Else
					e.CustomValue = e.SummaryValue.Summary
				End If
			End If
		End Sub
		Private Sub UseUnboundExpressionApproach()
			' Hide totals for the Value field.
			pivotGridControl1.Fields("Value").Options.ShowTotals = False
			pivotGridControl1.Fields("Value").Options.ShowGrandTotal = False
			' Create a new field to display totals.
			Dim fieldValueTotal As PivotGridField = If(pivotGridControl1.Fields.GetFieldByName("fieldValueTotal"), CreateSavingsField())
			fieldValueTotal.UnboundExpression = "Sum(Iif([Type]='Income', [Value], -[Value]))"
			fieldValueTotal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
			fieldValueTotal.UnboundExpressionMode = UnboundExpressionMode.UseAggregateFunctions
		End Sub
		Private Sub UseOptimizedApproach()
			' Hide totals for the Value field.
			pivotGridControl1.Fields("Value").Options.ShowTotals = False
			pivotGridControl1.Fields("Value").Options.ShowGrandTotal = False
			' Create a new field to display totals.
			Dim fieldValueTotal As PivotGridField = If(pivotGridControl1.Fields.GetFieldByName("fieldValueTotal"), CreateSavingsField())
			Dim savingsBinding As New ExpressionDataBinding("Sum(Iif([Type]='Income', [Value], -[Value]))")
			fieldValueTotal.DataBinding = savingsBinding
		End Sub

		Private Function CreateSavingsField() As PivotGridField
			' Add a new field to calculate custom totals.
			Dim fieldValueTotal As PivotGridField = New PivotGridField With {.Area = DevExpress.XtraPivotGrid.PivotArea.DataArea, .AreaIndex = 0, .Caption = "Savings", .FieldName = "Savings", .Name = "fieldValueTotal"}
			fieldValueTotal.Options.ShowValues = False
			pivotGridControl1.Fields.Add(fieldValueTotal)
			Return fieldValueTotal
		End Function
		Private Sub PivotGridControl1_FieldValueDisplayText(ByVal sender As Object, ByVal e As PivotFieldDisplayTextEventArgs)
			If e.ValueType = PivotGridValueType.GrandTotal Then
				If e.IsColumn Then
					e.DisplayText = "All Savings"
				End If
			End If
			If e.ValueType = PivotGridValueType.Total Then
				If e.IsColumn Then
					e.DisplayText = e.DisplayText.Replace("Total", "Savings")
				End If
			End If

		End Sub
		Private Sub MigrateToOptimizedMode()
			pivotGridControl1.Fields("Value").SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum
			RemoveHandler pivotGridControl1.CustomSummary, AddressOf pivotGridControl1_CustomSummary
		End Sub
	End Class
End Namespace