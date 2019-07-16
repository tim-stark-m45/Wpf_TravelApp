using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TravelApp.Extensions;
using WPF_TravelApp.Models;
using WPF_TravelApp.Services;

namespace WPF_TravelApp.ViewModels
{
    class HelloViewModel : ViewModelBase
    {
        //private ObservableCollection<User> users = new ObservableCollection<User>();
        //public ObservableCollection<User> Users { get => users; set => Set(ref users, value); }

        private User user = new User();
        public User User { get => user; set => Set(ref user, value); }

        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;
        private readonly AppDbContext db;

        public HelloViewModel(
            INavigationService navigationService,
            IMessageService messageService,
            AppDbContext db)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
            this.db = db;

            //Users = new ObservableCollection<User>(db.Users);
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
                  var result2 = from p in db.Users
                                where p.UserName == result
                                select p;
                  if (result!=result2.ToString())
                  {
                      messageService.ShowError("Login is not correct");
                  }
                  else
                  {
                      navigationService.Navigate<TripAddViewModel>();
                  }

                  //db.Users.Contains(result.ToString());
                  //messageService.ShowInfo(result2);
                  //if (result!=result2.ToString())
                  //{
                  //    messageService.ShowError("Login is not correct");
                  //}
                  //db.Users.Where(x=>x.UserName==user.UserName);
              }
              ));
        }
    }
}
