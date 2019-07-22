using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.ObjectModel;
using System.Linq;
using WPF_TravelApp.Models;
using WPF_TravelApp.Services;

namespace WPF_TravelApp.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> Users { get => users; set => Set(ref users, value); }

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
                  var result = user.UserName;

                  var result2 = Users.FirstOrDefault(x => x.UserName == result);

                  if (result2 != null)
                  {
                      navigationService.Navigate<TripObserveUCViewModel>();
                  }
                  else
                  {
                      messageService.ShowError("Login is not correct");
                  }
              }
              ));
        }

    }
}
