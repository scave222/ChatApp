using ChatApp.Mobile.Models;
using ChatApp.Mobile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatApp.Mobile.ViewModels
{
    public class ChatRoomPageViewModel : BaseViewModel
    {
        private readonly IChatService chatService;

        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }
        private string userId;
        public string UserId
        {
            get => userId;
            set => SetProperty(ref userId, value);
        }
        private string message;
        public string Message
        {
            get => message;
            set => SetProperty(ref message, value);
        }


        private IEnumerable<MessageModel> messageList;
        public IEnumerable<MessageModel> MessagesList
        {
            get => messageList;
            set => SetProperty(ref messageList, value);
        }
        public ICommand SendMsgCommand { get; private set; }

        public ChatRoomPageViewModel(IChatService chat, string userId, string userName)
        {
            chatService = chat;
            UserName = userId;
            UserId = userId;
            Initialize();
            SendMsgCommand = new Command(SendMsg);
        }

        public async void Initialize()
        {
            try
            {
                chatService.ReceiveMessage(GetMessage);
                await chatService.Connect();
            }
            catch (Exception ex)
            {

            }
            
        }

        private void SendMsg()
        {
            chatService.SendMessage(UserName, Message);
            AddMessage(UserName, Message, true);
        }

        private void GetMessage(string userName, string message)
        {
            AddMessage(userName, message, false);
        }


        private void AddMessage(string userName, string message, bool isOwner)
        {
            var tempList = MessagesList.ToList();
            tempList.Add(new MessageModel { IsOwnerMessage = isOwner, Message = message, UseName = userName });
            MessagesList = new List<MessageModel>(tempList);
            Message = string.Empty;
        }
    }
}
