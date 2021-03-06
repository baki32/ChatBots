using System.Threading.Tasks;
using System.Web.Http;

using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Web.Http.Description;
using System.Net.Http;
using System;
using Microsoft.Bot.Builder.Luis;
using System.Linq;

namespace SimpleBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// receive a message from a user and send replies
        /// </summary>
        /// <param name="activity"></param>
        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {
            try
            {
                var act = activity.CreateReply();
                act.Type = ActivityTypes.Typing;
                act.Text = null;
                ConnectorClient clnt = new ConnectorClient(new Uri(activity.ServiceUrl));
                await clnt.Conversations.ReplyToActivityAsync(act);
                // check if activity is of type message
                if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
                {

                    await Conversation.SendAsync(activity, () => new LuisDialog(new LuisService(typeof(LuisDialog).GetCustomAttributes(true).OfType<LuisModelAttribute>().SingleOrDefault())));
                }
                //send welcome message
                else if (activity != null && activity.GetActivityType() == ActivityTypes.Event)
                {
                    var reply = activity.CreateReply();
                    reply.Text = "What's up friend?";
                    await clnt.Conversations.ReplyToActivityAsync(reply);
                }
                else
                {
                    HandleSystemMessage(activity);
                }
                return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return null;
        }
    }
}