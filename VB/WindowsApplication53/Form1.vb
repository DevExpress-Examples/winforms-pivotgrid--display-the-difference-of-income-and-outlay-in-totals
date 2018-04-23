Imports System
Imports System.Collections.Generic
Imports System.Data
Imports System.Linq
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid

Namespace WindowsApplication53
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            PopulateTable()
            pivotGridControl1.RefreshData()
            pivotGridControl1.BestFit()
        End Sub
        Private Sub PopulateTable()
            Dim myTable As DataTable = dataSet1.Tables("Data")
            myTable.Rows.Add(New Object() { "Aaa", Date.Today, 7, "Income" })
            myTable.Rows.Add(New Object() { "Aaa", Date.Today.AddDays(1), 4, "Outlay" })
            myTable.Rows.Add(New Object() { "Bbb", Date.Today, 12, "Outlay" })
            myTable.Rows.Add(New Object() { "Bbb", Date.Today.AddDays(1), 14, "Outlay" })
            myTable.Rows.Add(New Object() { "Ccc", Date.Today, 11, "Income" })
            myTable.Rows.Add(New Object() { "Ccc", Date.Today.AddDays(1), 10, "Income" })

            myTable.Rows.Add(New Object() { "Aaa", Date.Today.AddYears(1), 4, "Income" })
            myTable.Rows.Add(New Object() { "Aaa", Date.Today.AddYears(1).AddDays(1), 2, "Income" })
            myTable.Rows.Add(New Object() { "Bbb", Date.Today.AddYears(1), 3, "Income" })
            myTable.Rows.Add(New Object() { "Bbb", Date.Today.AddDays(1).AddYears(1), 1, "Outlay" })
            myTable.Rows.Add(New Object() { "Ccc", Date.Today.AddYears(1), 8, "Income" })
            myTable.Rows.Add(New Object() { "Ccc", Date.Today.AddDays(1).AddYears(1), 22, "Outlay" })
        End Sub

        Private Sub pivotGridControl1_CustomSummary(ByVal sender As Object,
                                    ByVal e As PivotGridCustomSummaryEventArgs) Handles pivotGridControl1.CustomSummary
            If e.DataField.Name = "fieldValue" Then
                If ShouldCalculateCustomValue(fieldType, e) Then
                    Dim groupedDataSource =
                        e.CreateDrillDownDataSource().Cast(Of PivotDrillDownDataRow)().GroupBy(Function(r) r(fieldType))
                    Dim incomeSummary As Decimal = GetGroupSummary(groupedDataSource, "Income", e.FieldName)
                    Dim outlaySummary As Decimal = GetGroupSummary(groupedDataSource, "Outlay", e.FieldName)
                    e.CustomValue = incomeSummary - outlaySummary
                Else
                    e.CustomValue = e.SummaryValue.Summary
                End If
            End If
        End Sub

        Private Function GetGroupSummary(ByVal groupedDataSource As IEnumerable(Of IGrouping(Of Object, PivotDrillDownDataRow)),
                                         ByVal target As Object, ByVal dataFieldName As String) As Decimal
            Dim targetGroup = groupedDataSource.FirstOrDefault(Function(g) Object.Equals(g.Key, target))
            If targetGroup Is Nothing Then
                Return 0
            End If
            Return targetGroup.Sum(Function(r) Convert.ToDecimal(r(dataFieldName)))
        End Function

        Private Function ShouldCalculateCustomValue(ByVal groupField As PivotGridField,
                                                    ByVal e As PivotGridCustomSummaryEventArgs) As Boolean
            If (Not groupField.Visible) OrElse groupField.Area = PivotArea.FilterArea OrElse
                groupField.Area = PivotArea.DataArea Then
                Return True
            End If
            If groupField.Area = PivotArea.RowArea AndAlso
                (e.RowField Is Nothing OrElse e.RowField.AreaIndex < groupField.AreaIndex) Then
                Return True
            End If
            If groupField.Area = PivotArea.ColumnArea AndAlso
                (e.ColumnField Is Nothing OrElse e.ColumnField.AreaIndex < groupField.AreaIndex) Then
                Return True
            End If
            Return False
        End Function

    End Class
End Namespace