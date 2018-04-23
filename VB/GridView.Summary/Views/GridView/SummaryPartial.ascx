<%@ Control Language="vb" Inherits="System.Web.Mvc.ViewUserControl<dynamic>" %>

<%
	Html.DevExpress().GridView(Function(settings) AnonymousMethod1(settings)).Bind(Model).Render()
%>



private bool AnonymousMethod1(object settings)
{
	settings.Name = "dxGridView";
	settings.CallbackRouteValues = New { Controller = "GridView", Action = "SummaryPartial" };
	settings.Columns.Add("ShipName").GroupIndex = 0;
	settings.Columns.Add("CustomerName");
	settings.Columns.Add("UnitPrice").PropertiesEdit.DisplayFormatString = "c";
	settings.Settings.ShowFooter = True;
	settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "ShipName");
	settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "UnitPrice").DisplayFormat = "c";
	settings.SummaryDisplayText = (sender, e) =>
	{
		if(e.Item.FieldName == "UnitPrice")
			e.Text = string.Format("Sum of unit price: ${0}", Convert.ToDouble(e.Value));
			if(e.Item.FieldName == "ShipName")
				e.Text = string.Format("Count of records: {0}", Convert.ToDouble(e.Value));
	};
	Return True;
}