using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace WindowsApplication53
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateTable();
            pivotGridControl1.RefreshData();
            pivotGridControl1.BestFit();
        }
        private void PopulateTable()
        {
            DataTable myTable = dataSet1.Tables["Data"];
            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today, 7, "Income" });
            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddDays(1), 4, "Outlay" });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today, 12, "Outlay" });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddDays(1), 14, "Outlay" });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today, 11, "Income" });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddDays(1), 10, "Income" });

            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddYears(1), 4, "Income" });
            myTable.Rows.Add(new object[] { "Aaa", DateTime.Today.AddYears(1).AddDays(1), 2, "Income" });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddYears(1), 3, "Income" });
            myTable.Rows.Add(new object[] { "Bbb", DateTime.Today.AddDays(1).AddYears(1), 1, "Outlay" });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddYears(1), 8, "Income" });
            myTable.Rows.Add(new object[] { "Ccc", DateTime.Today.AddDays(1).AddYears(1), 22, "Outlay" });
        }

        private void pivotGridControl1_CustomSummary(object sender, PivotGridCustomSummaryEventArgs e)
        {
            if (e.DataField.Name == "fieldValue" )
            {
                if (ShouldCalculateCustomValue(fieldType, e))
                {
                    var groupedDataSource = 
                        e.CreateDrillDownDataSource().Cast<PivotDrillDownDataRow>().GroupBy(r => r[fieldType]);
                    decimal incomeSummary = GetGroupSummary(groupedDataSource, "Income", e.FieldName);
                    decimal outlaySummary = GetGroupSummary(groupedDataSource, "Outlay", e.FieldName);
                    e.CustomValue = incomeSummary - outlaySummary;
                }
                else
                    e.CustomValue = e.SummaryValue.Summary;
            }
        }

        private decimal GetGroupSummary(IEnumerable<IGrouping<object, PivotDrillDownDataRow>> groupedDataSource, 
            object target, string dataFieldName)
        {
            var targetGroup = groupedDataSource.FirstOrDefault(g => object.Equals(g.Key, target));
            if (targetGroup == null)
                return 0;
            return targetGroup.Sum(r => Convert.ToDecimal(r[dataFieldName]));
        }

        private bool ShouldCalculateCustomValue(PivotGridField groupField, PivotGridCustomSummaryEventArgs e)
        {
            if (!groupField.Visible || groupField.Area == PivotArea.FilterArea || groupField.Area == PivotArea.DataArea)
                return true;
            if (groupField.Area == PivotArea.RowArea && 
                (e.RowField == null || e.RowField.AreaIndex < groupField.AreaIndex))
                return true;
            if (groupField.Area == PivotArea.ColumnArea && 
                (e.ColumnField == null || e.ColumnField.AreaIndex < groupField.AreaIndex))
                return true;
            return false;
        }

    }
}