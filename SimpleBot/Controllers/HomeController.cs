using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace SimpleEchoBot.Controllers
{
    public class HomeController : Controller
    {
        // GET api/<controller>
        public ActionResult Index()
        {
            Microsoft.ApplicationInsights.TelemetryClient client = new Microsoft.ApplicationInsights.TelemetryClient();
            client.InstrumentationKey = "40513e3d-af87-4816-8b49-147dd2e111de";
            client.TrackTrace("ZIDAN", Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Critical, new Dictionary<string, string> { { "ZI", "DAN" } });
            return View();
        }

        
    }
}