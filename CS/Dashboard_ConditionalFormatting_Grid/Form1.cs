using DevExpress.DashboardCommon;
using System.Drawing;

namespace Grid_TopAverageCondition {
    public partial class Form1 : DevExpress.XtraEditors.XtraForm {
        public Form1() {
            InitializeComponent();
            Dashboard dashboard = new Dashboard(); dashboard.LoadFromXml(@"..\..\Data\Dashboard.xml");
            dashboardViewer1.Dashboard = dashboard;
            GridDashboardItem grid = (GridDashboardItem)dashboard.Items["gridDashboardItem1"];
            GridDimensionColumn salesPerson = (GridDimensionColumn)grid.Columns[0];
            GridMeasureColumn extendedPrice = (GridMeasureColumn)grid.Columns[1];

            GridItemFormatRule topRule = new GridItemFormatRule(extendedPrice, salesPerson);
            FormatConditionTopBottom topCondition = new FormatConditionTopBottom();
            topCondition.TopBottom = DashboardFormatConditionTopBottomType.Top;
            topCondition.RankType = DashboardFormatConditionValueType.Number;
            topCondition.Rank = 3;
            topCondition.StyleSettings = new IconSettings(FormatConditionIconType.IndicatorGreenCheck);
            topRule.Condition = topCondition;

            GridItemFormatRule bottomRule = new GridItemFormatRule(extendedPrice, salesPerson);
            FormatConditionTopBottom bottomCondition = new FormatConditionTopBottom();
            bottomCondition.TopBottom = DashboardFormatConditionTopBottomType.Bottom;
            bottomCondition.RankType = DashboardFormatConditionValueType.Percent;
            bottomCondition.Rank = 40;
            bottomCondition.StyleSettings = new IconSettings(FormatConditionIconType.IndicatorRedFlag);
            bottomRule.Condition = bottomCondition;

            GridItemFormatRule aboveAverageRule = new GridItemFormatRule(extendedPrice);
            FormatConditionAverage aboveAverageCondition = new FormatConditionAverage();
            aboveAverageCondition.AverageType = DashboardFormatConditionAboveBelowType.Above;
            aboveAverageCondition.StyleSettings = 
                new AppearanceSettings(Color.Green, FontStyle.Underline);
            aboveAverageRule.Condition = aboveAverageCondition;

            GridItemFormatRule belowAverageRule = new GridItemFormatRule(extendedPrice);
            FormatConditionAverage belowAverageCondition = new FormatConditionAverage();
            belowAverageCondition.AverageType = DashboardFormatConditionAboveBelowType.Below;
            belowAverageCondition.StyleSettings = 
                new AppearanceSettings(Color.Orange, FontStyle.Underline);
            belowAverageRule.Condition = belowAverageCondition;

            grid.FormatRules.AddRange(topRule, bottomRule, aboveAverageRule, belowAverageRule);
        }
    }
}
