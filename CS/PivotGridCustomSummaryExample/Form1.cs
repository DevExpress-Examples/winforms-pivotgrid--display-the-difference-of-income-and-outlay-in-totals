using DevExpress.XtraPivotGrid;
using System;
using System.Linq;

namespace PivotGridCustomSummaryExample
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
            SelectCustomSummaryApproach(pivotGridControl1.OptionsData.DataProcessingEngine);
            pivotGridControl1.FieldValueDisplayText += PivotGridControl1_FieldValueDisplayText;
            pivotGridControl1.DataSource = TestData.GetData();
            pivotGridControl1.BestFit();
        }
        private void SelectCustomSummaryApproach(PivotDataProcessingEngine dataProcessingEngine)
        {
            switch (dataProcessingEngine)
            {
                case PivotDataProcessingEngine.Optimized:
                    UseOptimizedApproach();
                    break;
                case PivotDataProcessingEngine.LegacyOptimized:
                    UseUnboundExpressionApproach();
                    break;
                default:
                    UseLegacyApproach();
                    break;
            }
        }

        private void toggleOptimizedMode_Toggled(object sender, EventArgs e)
        {
            if (((DevExpress.XtraEditors.ToggleSwitch)sender).IsOn) {
                MigrateToOptimizedMode();
                pivotGridControl1.OptionsData.DataProcessingEngine = PivotDataProcessingEngine.Optimized;
                SelectCustomSummaryApproach(PivotDataProcessingEngine.Optimized);
            }
            else {
                pivotGridControl1.OptionsData.DataProcessingEngine = PivotDataProcessingEngine.LegacyOptimized;
                SelectCustomSummaryApproach(PivotDataProcessingEngine.LegacyOptimized);
            };
        }
        private void UseLegacyApproach()
        {
            pivotGridControl1.Fields["Value"].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Custom;
            pivotGridControl1.CustomSummary += pivotGridControl1_CustomSummary;
        }
        // The CustomSummary event is a legacy approach.
        private void pivotGridControl1_CustomSummary(object sender, PivotGridCustomSummaryEventArgs e)
        {
            if (e.DataField.Name == "fieldValue")
            {
                if (CustomSummaryHelper.ShouldCalculateCustomValue(fieldType, e))
                {
                    var groupedDataSource =
                        e.CreateDrillDownDataSource().Cast<PivotDrillDownDataRow>().GroupBy(r => r[fieldType]);
                    decimal incomeSummary = CustomSummaryHelper.GetGroupSummary(groupedDataSource, "Income", e.FieldName);
                    decimal outlaySummary = CustomSummaryHelper.GetGroupSummary(groupedDataSource, "Outlay", e.FieldName);
                    e.CustomValue = incomeSummary - outlaySummary;
                }
                else
                    e.CustomValue = e.SummaryValue.Summary;
            }
        }
        private void UseUnboundExpressionApproach()
        {
            // Hide totals for the Value field.
            pivotGridControl1.Fields["Value"].Options.ShowTotals = false;
            pivotGridControl1.Fields["Value"].Options.ShowGrandTotal = false;
            // Create a new field to display totals.
            PivotGridField fieldValueTotal = pivotGridControl1.Fields.GetFieldByName("fieldValueTotal") ?? CreateSavingsField();
            fieldValueTotal.UnboundExpression = "Sum(Iif([Type]='Income', [Value], -[Value]))";
            fieldValueTotal.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            fieldValueTotal.UnboundExpressionMode = UnboundExpressionMode.UseAggregateFunctions;
        }
        private void UseOptimizedApproach()
        {
            // Hide totals for the Value field.
            pivotGridControl1.Fields["Value"].Options.ShowTotals = false;
            pivotGridControl1.Fields["Value"].Options.ShowGrandTotal = false;
            // Create a new field to display totals.
            PivotGridField fieldValueTotal = pivotGridControl1.Fields.GetFieldByName("fieldValueTotal") ?? CreateSavingsField();
            ExpressionDataBinding savingsBinding = new ExpressionDataBinding("Sum(Iif([Type]='Income', [Value], -[Value]))");
            fieldValueTotal.DataBinding = savingsBinding;
        }

        private PivotGridField CreateSavingsField()
        {
            // Add a new field to calculate custom totals.
            PivotGridField fieldValueTotal = new PivotGridField
            {
                Area = DevExpress.XtraPivotGrid.PivotArea.DataArea,
                AreaIndex = 0,
                Caption = "Savings",
                FieldName = "Savings",
                Name = "fieldValueTotal"
            };
            fieldValueTotal.Options.ShowValues = false;
            pivotGridControl1.Fields.Add(fieldValueTotal);
            return fieldValueTotal;
        }
        private void PivotGridControl1_FieldValueDisplayText(object sender, PivotFieldDisplayTextEventArgs e)
        {
            if (e.ValueType == PivotGridValueType.GrandTotal)
            {
                if (e.IsColumn)
                    e.DisplayText = "All Savings";
            }
            if (e.ValueType == PivotGridValueType.Total)
                if (e.IsColumn)
                    e.DisplayText = e.DisplayText.Replace("Total", "Savings");

        }
        private void MigrateToOptimizedMode()
        {
            pivotGridControl1.Fields["Value"].SummaryType = DevExpress.Data.PivotGrid.PivotSummaryType.Sum;
            pivotGridControl1.CustomSummary -= pivotGridControl1_CustomSummary;
        }
    }
}