<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581913/14.1.13%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T413352)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/WindowsApplication53/Form1.cs) (VB: [Form1.vb](./VB/WindowsApplication53/Form1.vb))
<!-- default file list end -->
#  How to display the difference of Income and Outlay in totals


<p>The following example demonstrates how to calculate and display the difference of Income and Outlay in totals. <br>In this example, a custom Grand Total is implemented for the <strong>Value</strong> data field.<br>To show additional <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument1900">Grand Total</a> rows or columns, add a field to the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument1711">Data Area</a>. Then, set the field's <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridFieldBase_SummaryTypetopic">PivotGridFieldBase.SummaryType</a> property to <strong>Custom</strong>. To provide values for this field, use the<a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomSummarytopic">PivotGridControl.CustomSummary</a> event. You can use <br>the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridDataPivotGridCustomSummaryEventArgsBase_CreateDrillDownDataSourcetopic">PivotGridCustomSummaryEventArgsBase.CreateDrillDownDataSource</a> method to get a list of all corresponding underlying data source rows, and then you will be able to calculate summary values. <br>To learn more about custom summaries, see the <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument9391">Custom summaries</a> topic.</p>

<br/>


