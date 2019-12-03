using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GridView.Summary.Models;

namespace GridView.Summary.Controllers {
    [HandleError]
    public class HomeController : Controller {
        public ActionResult Index() {
            return Summary();
        }
        public ActionResult Summary() {
            return View("Summary", NorthwindDataProvider.GetInvoices());
        }
        public ActionResult SummaryPartial() {
            return PartialView("SummaryPartial", NorthwindDataProvider.GetInvoices());
        }
    }
}
