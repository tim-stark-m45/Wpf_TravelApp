using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System.Collections.ObjectModel;
using System.Linq;
using WPF_TravelApp.Messages;
using WPF_TravelApp.Models;
using WPF_TravelApp.Services;

namespace WPF_TravelApp.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> Users { get => users; set => Set(ref users, value); }

        private string text;
        public string Text { get => text; set => Set(ref text, value); }

        private User user = new User();
        public User User { get => user; set => Set(ref user, value); }

        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;
        private readonly AppDbContext db;

        public LoginViewModel(
            INavigationService navigationService,
            IMessageService messageService,
            AppDbContext db)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
            this.db = db;

            Users = new ObservableCollection<User>(db.Users);
        }

        private RelayCommand userSignUpCommand;
        public RelayCommand UserSignUpCommand
        {
            get => userSignUpCommand ?? (userSignUpCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<SignUpViewModel>();
              }
              ));
        }

        private RelayCommand<User> userLoginCommand;
        public RelayCommand<User> UserLoginCommand
        {
            get => userLoginCommand ?? (userLoginCommand = new RelayCommand<User>(
              param =>
              {
                  var result = Text;

                  var result2 = Users.FirstOrDefault(x => x.UserName == result);

                  if (result2 != null)
                  {
                      Messenger.Default.Send(new FirstMessage { Message = Text });
                      navigationService.Navigate<HomePageViewModel>();
                  }
                  else
                  {
                      messageService.ShowError("Login is not correct");
                  }
                  Text = "";
              }
              ));
        }

    }
}
