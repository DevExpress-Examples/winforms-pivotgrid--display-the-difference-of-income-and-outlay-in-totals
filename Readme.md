#  How to display the difference of Income and Outlay in totals


<p>The following example demonstrates how to calculate and display the difference of Income and Outlay in totals. <br>In this example, a custom Grand Total is implemented for the <strong>Value</strong> data field.<br>To show additional <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument1900">Grand Total</a> rows or columns, add a field to the <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument1711">Data Area</a>. Then, set the field's <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotGridFieldBase_SummaryTypetopic">PivotGridFieldBase.SummaryType</a> property to <strong>Custom</strong>. To provide values for this field, use the<a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomSummarytopic">PivotGridControl.CustomSummary</a> event. You can use <br>the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridDataPivotGridCustomSummaryEventArgsBase_CreateDrillDownDataSourcetopic">PivotGridCustomSummaryEventArgsBase.CreateDrillDownDataSource</a> method to get a list of all corresponding underlying data source rows, and then you will be able to calculate summary values. <br>To learn more about custom summaries, see the <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument9391">Custom summaries</a> topic.</p>

<br/>


