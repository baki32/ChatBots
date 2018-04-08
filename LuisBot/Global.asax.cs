using Autofac;
using System.Web.Http;
using System.Configuration;
using System.Reflection;
using Microsoft.Bot.Builder.Azure;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Dialogs.Internals;
using Microsoft.Bot.Connector;
using System.Web.Mvc;
using WebApplication1;
using System.Web.Routing;
using System.Web.Optimization;
using System.Collections.Generic;

namespace LuisBot
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Bot Storage: This is a great spot to register the private state storage for your bot. 
            // We provide adapters for Azure Table, CosmosDb, SQL Azure, or you can implement your own!
            // For samples and documentation, see: https://github.com/Microsoft/BotBuilder-Azure
            //Microsoft.ApplicationInsights.TelemetryClient client = new Microsoft.ApplicationInsights.TelemetryClient();
            //client.InstrumentationKey = "40513e3d-af87-4816-8b49-147dd2e111de";
            //client.TrackTrace("ZIDAN", Microsoft.ApplicationInsights.DataContracts.SeverityLevel.Critical, new Dictionary<string, string> { { "ZI", "DAN"} });


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Conversation.UpdateContainer(
                builder =>
                {
                    //builder.RegisterModule(new AzureModule(Assembly.GetExecutingAssembly()));

                    //// Using Azure Table Storage
                    //var store = new TableBotDataStore(ConfigurationManager.AppSettings["AzureWebJobsStorage"]); // requires Microsoft.BotBuilder.Azure Nuget package 

                    //// To use CosmosDb or InMemory storage instead of the default table storage, uncomment the corresponding line below
                    //// var store = new DocumentDbBotDataStore("cosmos db uri", "cosmos db key"); // requires Microsoft.BotBuilder.Azure Nuget package 
                    //// var store = new InMemoryDataStore(); // volatile in-memory store

                    //builder.Register(c => store)
                    //    .Keyed<IBotDataStore<BotData>>(AzureModule.Key_DataStore)
                    //    .AsSelf()
                    //    .SingleInstance();

                });
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
