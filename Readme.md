<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/PivotGridCustomSummaryExample/Form1.cs) (VB: [Form1.vb](./VB/PivotGridCustomSummaryExample/Form1.vb))
<!-- default file list end -->
#  How to Calculate and Display Custom Summaries


This example calculates and displays the difference of Income and Outlay in totals.

It demostrates the following approaches:

* **Legacy** approach that is based on a [CustomSummary](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.PivotGridControl.CustomSummary) event. This approach does not work in [Optimized mode](https://docs.devexpress.com/CoreLibraries/401367).
* **Unbound field**. This approach uses a summary expression in an additional unbound field.
* **Data Binding API**. This approach works only in [Optimized mode](https://docs.devexpress.com/CoreLibraries/401367). An additional field uses the [ExpressionDataBinding](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.ExpressionDataBinding) instance to specify an expression to calculate.


![](/images/screenshot.png)

See also:
* [Custom Summaries](https://docs.devexpress.com/WindowsForms/9391)