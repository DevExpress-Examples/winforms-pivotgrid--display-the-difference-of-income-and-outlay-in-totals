using DevExpress.XtraPivotGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PivotGridCustomSummaryExample
{
    static class CustomSummaryHelper
    {
        public static decimal GetGroupSummary(IEnumerable<IGrouping<object, PivotDrillDownDataRow>> groupedDataSource,
    object target, string dataFieldName)
        {
            var targetGroup = groupedDataSource.FirstOrDefault(g => object.Equals(g.Key, target));
            if (targetGroup == null)
                return 0;
            return targetGroup.Sum(r => Convert.ToDecimal(r[dataFieldName]));
        }

        public static bool ShouldCalculateCustomValue(PivotGridField groupField, PivotGridCustomSummaryEventArgs e)
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
