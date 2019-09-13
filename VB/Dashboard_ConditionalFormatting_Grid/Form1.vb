Imports DevExpress.DashboardCommon
Imports System.Drawing

Namespace Grid_TopAverageCondition
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

		Public Sub New()
			InitializeComponent()
			Dim dashboard As New Dashboard()
			dashboard.LoadFromXml("..\..\Data\Dashboard.xml")
			dashboardViewer1.Dashboard = dashboard
			Dim grid As GridDashboardItem = CType(dashboard.Items("gridDashboardItem1"), GridDashboardItem)
			Dim salesPerson As GridDimensionColumn = CType(grid.Columns(0), GridDimensionColumn)
			Dim extendedPrice As GridMeasureColumn = CType(grid.Columns(1), GridMeasureColumn)

			Dim topRule As New GridItemFormatRule(extendedPrice, salesPerson)
			Dim topCondition As New FormatConditionTopBottom()
			topCondition.TopBottom = DashboardFormatConditionTopBottomType.Top
			topCondition.RankType = DashboardFormatConditionValueType.Number
			topCondition.Rank = 3
			topCondition.StyleSettings = New IconSettings(FormatConditionIconType.IndicatorGreenCheck)
			topRule.Condition = topCondition

			Dim bottomRule As New GridItemFormatRule(extendedPrice, salesPerson)
			Dim bottomCondition As New FormatConditionTopBottom()
			bottomCondition.TopBottom = DashboardFormatConditionTopBottomType.Bottom
			bottomCondition.RankType = DashboardFormatConditionValueType.Percent
			bottomCondition.Rank = 40
			bottomCondition.StyleSettings = New IconSettings(FormatConditionIconType.IndicatorRedFlag)
			bottomRule.Condition = bottomCondition

			Dim aboveAverageRule As New GridItemFormatRule(extendedPrice)
			Dim aboveAverageCondition As New FormatConditionAverage()
			aboveAverageCondition.AverageType = DashboardFormatConditionAboveBelowType.Above
			aboveAverageCondition.StyleSettings = New AppearanceSettings(Color.Green, FontStyle.Underline)
			aboveAverageRule.Condition = aboveAverageCondition

			Dim belowAverageRule As New GridItemFormatRule(extendedPrice)
			Dim belowAverageCondition As New FormatConditionAverage()
			belowAverageCondition.AverageType = DashboardFormatConditionAboveBelowType.Below
			belowAverageCondition.StyleSettings = New AppearanceSettings(Color.Orange, FontStyle.Underline)
			belowAverageRule.Condition = belowAverageCondition

			grid.FormatRules.AddRange(topRule, bottomRule, aboveAverageRule, belowAverageRule)
		End Sub
	End Class
End Namespace
