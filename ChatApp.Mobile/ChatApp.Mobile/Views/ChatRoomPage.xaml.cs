using ChatApp.Mobile.Services.Core;
using ChatApp.Mobile.Services.Interfaces;
using ChatApp.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChatApp.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatRoomPage : ContentPage
    {
        ChatRoomPageViewModel vm;
        public ChatRoomPage(string userId, string userName)
        {
            InitializeComponent();
            ChatService chatService = new ChatService();
            vm = new ChatRoomPageViewModel(chatService , userId, userName);
            this.BindingContext = vm;
        }
    }
}