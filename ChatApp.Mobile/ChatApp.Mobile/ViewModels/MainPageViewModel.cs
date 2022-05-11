using ChatApp.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ChatApp.Mobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private string email;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        private string userName;
        public string UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }
        private string pwd;
        //private readonly IAuthenticationService authenticationService;

        public string Pwd
        {
            get => pwd;
            set => SetProperty(ref pwd, value);
        }

        public ICommand SignInCommand { get; private set; }

        public ICommand NavigateToChatPageCommand { get; private set; }
        public MainPageViewModel()
        {
            NavigateToChatPageCommand = new Command(NavigateToChatPage);
        }

        //public MainPageViewModel(INavigationService navigationService,
        //     IAuthenticationService authenticationService,
        //     ISessionService sessionService)
        //    : base(navigationService, sessionService)
        //{
        //    NavigateToChatPageCommand = new DelegateCommand(NavigateToChatPage);
        //    SignInCommand = new DelegateCommand(SignIn);
        //    this.authenticationService = authenticationService;
        //}

        //private async void SignIn()
        //{
        //    var user = await authenticationService.Login(new LoginModel { Email = Email, Password = Pwd });
        //    if (user != null)
        //    {
        //        await SessionService.SetConnectedUser(user);
        //        await SessionService.SetToken(new TokenModel
        //        {
        //            Token = user.Token,
        //            RefreshToken = user.RefreshToken,
        //            TokenExpireTime = user.TokenExpireTimes
        //        });

        //        await NavigationService.NavigateAsync("../FriendsPage");
        //    }
        //    else
        //    {
        //        // TODO Show login error.
        //    }
        //}

        private async void NavigateToChatPage()
        {
            //var param = new NavigationParameters { { "UserNameId", Email } };
            //NavigationService.NavigateAsync($"NavigationPage/{nameof(ChatRoomPage)}", param);
            await Application.Current.MainPage.Navigation.PushAsync(new ChatRoomPage("UserNameId", UserName));
        }
    }
}
