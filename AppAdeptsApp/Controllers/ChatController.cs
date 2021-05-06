using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using SlackNet;
using AppAdeptsApp.Models;
using AppAdeptsApp.Shared;
using AppAdeptsApp.Shared.Interfaces;
using SlackNet.WebApi;

namespace AppAdeptsApp.Controllers
{
    /// <summary>
    /// The Chat Controller handles receiving Slack messages, sending messages to Slack, and file upload - through cloudinary 
    /// </summary>
    public class ChatController : BasePageController
    {
        private readonly IUserInfo _user;
        private Chat.Messages messageHistory;
        private readonly string channel;
        private readonly string token;
        private SlackApiClient api;


        /// <summary>
        /// Retrieves the user info from UserInfo Model
        /// Initiates both Slack API and Cloudinary API
        /// </summary>
        public ChatController(IUserInfo user) : base(user)
        {
            _user = user;
            messageHistory = new Chat.Messages();
            channel = user.chatChannel;
            token = "";//Omitted
            api = new SlackApiClient(token);
        }

        /// <summary>
        /// Retrieves the Chat History from the Slack Channel specified by UserInfo
        /// </summary>
        /// <returns> if user is logged in, returns to the ChatView with updated messages, else returns to Login Screen</returns>
        public async Task<ActionResult> Index()
        {
            if (_user.loggedIn) {
                var history = await api.Conversations.History(channel);
                return View(UpdateMessageHistory(history));
            }
            else {
                return RedirectToRoute("Home");
            }
        }

        /// <summary>
        /// Retrieves message history from Slack. Note: for use with client-side code.
        /// </summary>
        /// <returns>The message history</returns>
        public async Task<Chat.Messages> RefreshChatHistory()
        {
            return UpdateMessageHistory(await api.Conversations.History(channel));
        }

        /// <summary>
        /// Updates the message history after sending a message
        /// </summary>
        /// <param name="history"></param>
        /// <returns>the list of messages from message history</returns>
        public Chat.Messages UpdateMessageHistory(ConversationHistoryResponse history)
        {
            //Gets the UserID from UserInfo
            var userIdMessage = $"@{_user.UserID}";

            //Determines if the messages are from User or the AppPros
            bool IsUserMessage(string msg) => msg.Contains($"{_user.firstName}:");
            bool IsAgencyMessage(string msg) => msg.Contains($"{userIdMessage} ");

            // messages come from SlackNet api as oldest-first, but recent-first feels more natural to the user.
            var messageTexts = history.Messages.Select(msg => msg.Text).Reverse().ToList();

            // goal: remove $"{_user.userID}"
            // if userID is followed by a "-", get rid of that too, and the space that comes after it.
            // else prepend "AppPros:"
            messageHistory.messages = messageTexts.Select(msg =>
            {
                if (!msg.Contains(userIdMessage)) return string.Empty;
                
                // get rid of "@{userID}-"
                var newMessage = msg.Replace(userIdMessage, "");

                if (IsUserMessage(msg))
                {
                    // message now starts with -_user.firstName
                    return newMessage.Replace("-", "");
                }
                if (IsAgencyMessage(msg))
                {
                    // message now starts with - AppPros:
                    return "AppPros:" + newMessage;
                }
                return string.Empty;
            }).Where(msg => !string.IsNullOrEmpty(msg)).ToArray();

            return messageHistory;
        }
        
       /// <summary>
        /// Handles posting the user's message to the specified Slack Channel
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Back to View with the updated message history</returns>
        [HttpPost]
        public async Task<IActionResult> SendChat(Chat.Messages model)
        {
            await api.Chat.PostMessage(new Message
            {
                Channel = channel,
                Text = "@" + _user.UserID + "-" + _user.firstName + ": " + model.TextField
            });
            return RedirectToRoute("Chat");
        }
    }
}
