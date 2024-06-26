<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581913/19.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T413352)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->

#  Pivot Grid for WinForms - Calculate and Display Custom Summaries

This example calculates and displays the difference of Income and Outlay in totals.

![](/images/screenshot.png)

It demostrates the following approaches:

* **Legacy** approach that is based on a [CustomSummary](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.PivotGridControl.CustomSummary) event. This approach does not work in [Optimized mode](https://docs.devexpress.com/CoreLibraries/401367).
* **Unbound field**. This approach uses a summary expression in an additional unbound field.
* **Data Binding API**. This approach works only in [Optimized mode](https://docs.devexpress.com/CoreLibraries/401367). An additional field uses the [ExpressionDataBinding](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPivotGrid.ExpressionDataBinding) instance to specify an expression to calculate.

## Files to Review

* [Form1.cs](./CS/PivotGridCustomSummaryExample/Form1.cs) (VB: [Form1.vb](./VB/PivotGridCustomSummaryExample/Form1.vb))

## Documentation

[Custom Summaries](https://docs.devexpress.com/WindowsForms/9391)

## More Examples 

[Pivot Grid for WinForms - How to Aggregate Data by the Field's First Value](https://github.com/DevExpress-Examples/winforms-pivot-grid-custom-aggregates)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-pivotgrid--display-the-difference-of-income-and-outlay-in-totals&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-pivotgrid--display-the-difference-of-income-and-outlay-in-totals&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
