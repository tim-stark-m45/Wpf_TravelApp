using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TravelApp.Extensions;
using WPF_TravelApp.Models;
using WPF_TravelApp.Services;

namespace WPF_TravelApp.ViewModels
{
    class SignUpViewModel : ViewModelBase, IDataErrorInfo
    {
        private User user = new User();
        public User User { get => user; set => Set(ref user, value); }

        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;
        private readonly AppDbContext db;

        public SignUpViewModel(
            INavigationService navigationService,
            IMessageService messageService,
            AppDbContext db)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
            this.db = db;
        }

        private RelayCommand signUpCommand;
        public RelayCommand SignUpCommand
        {
            get => signUpCommand ?? (signUpCommand = new RelayCommand(
              () =>
              {
                  db.Users.Add(User);
                  db.SaveChanges();

                  navigationService.Navigate<LoginViewModel>();
              }
              ));
        }

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get => cancelCommand ?? (cancelCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<LoginViewModel>();
              }
              ));
        }

        public string Error => throw new NotImplementedException();
        public string this[string columnName] => this.Validate(columnName);
    }
}
