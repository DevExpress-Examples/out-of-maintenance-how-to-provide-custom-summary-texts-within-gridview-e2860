@Html.DevExpress().GridView(
            Sub(settings)
                settings.Name = "dxGridView"
                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "SummaryPartial"}

                settings.Columns.Add("ShipName").GroupIndex = 0
                settings.Columns.Add("CustomerName")
                settings.Columns.Add("UnitPrice").PropertiesEdit.DisplayFormatString = "c"

                settings.Settings.ShowFooter = True
                settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "ShipName")
                settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "UnitPrice").DisplayFormat = "c"

                settings.SummaryDisplayText = Function(sender, e)
                                                  If (e.Item.FieldName = "UnitPrice") Then
                                                      e.Text = String.Format("Sum of unit price: ${0}", Convert.ToDouble(e.Value))
                                                  End If
                                                  If (e.Item.FieldName = "ShipName") Then
                                                      e.Text = String.Format("Count of records: {0}", Convert.ToDouble(e.Value))
                                                  End If
                                              End Function
            End Sub).Bind(Model).GetHtml()


