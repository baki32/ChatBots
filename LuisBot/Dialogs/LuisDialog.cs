using System;
using System.Threading.Tasks;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;
using AdaptiveCards;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using System.Linq;

namespace SimpleBot
{
    [Serializable]
    [TukeDemoModel]
    public class LuisDialog : LuisDialog<object>
    {
        public LuisDialog(params ILuisService[] services) : base(services)
        {

        }

        protected int count = 1;

        [LuisIntent("")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Sorry mate I don't understand what you want");
        }

        [LuisIntent("Taxi.Book")]
        public async Task BookTaxi(IDialogContext context, LuisResult result)
        {
            await ParseLuisResult(context, result);
        }


        [LuisIntent("Taxi.Track")]
        public async Task TrackTaxi(IDialogContext context, LuisResult result)
        {
            await ParseLuisResult(context, result);
        }

        [LuisIntent("Taxi.Cancel")]
        public async Task CancelTaxi(IDialogContext context, LuisResult result)
        {
            await ParseLuisResult(context, result);
        }

        private static async Task ParseLuisResult(IDialogContext context, LuisResult result)
        {
            var entitiesParsed = result.Entities.ToList().Select(a => $"\t {a.Type} : {a.Entity} \n");
            await context.PostAsync($"This is what I've recognized: \n" +
                $"**Your intent:** {result.TopScoringIntent.Intent} \n" +
                $"**Recognized enitities:**\n {string.Join("", entitiesParsed)}");
        }
    }

    [Serializable]
    public class TukeDemoModelAttribute : LuisModelAttribute
    {
        //todo: replace with app settings
        public TukeDemoModelAttribute() : base("218afcbd-2d50-408d-b9d8-2969554253ac", "81a1fda25bb0462dbbec415c82b7813b", LuisApiVersion.V2)
        {
            //todo: replace with app settings
            Verbose = true;
            Staging = true;
            SpellCheck = true;
        }
    }

}