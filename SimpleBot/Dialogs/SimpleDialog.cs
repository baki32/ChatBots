using System;
using System.Threading.Tasks;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;
using AdaptiveCards;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SimpleBot
{
    [Serializable]
    public class SimpleDialog : IDialog<object>
    {
        protected int count = 1;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Text.ToLower().Contains("best coder"))
            {
                await context.PostAsync("Of course you are! ;)");
            }
            else
            {
                await context.PostAsync($"Not sure what you wanted so I'll just reply with what you wrote: {message.Text}");
            }
            context.Done(true);
            //context.Wait(MessageReceivedAsync);            
        }
    }
}