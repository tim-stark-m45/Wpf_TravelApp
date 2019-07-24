using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WPF_TravelApp.Messages;
using WPF_TravelApp.Models;
using WPF_TravelApp.Services;

namespace WPF_TravelApp.ViewModels
{
    class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;

        private ObservableCollection<Trip> trips;
        public ObservableCollection<Trip> Trips { get => trips; set => Set(ref trips, value); }

        public HomePageViewModel(
            INavigationService navigationService,
            IMessageService messageService,
            AppDbContext db)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
            Messenger.Default.Register<FirstMessage>(this, param => Message = param.Message);

            Trips = new ObservableCollection<Trip>(db.Trips);
        }

        private string message;
        public string Message { get => message; set => Set(ref message, value); }

        private RelayCommand loginCommand;
        public RelayCommand LoginCommand
        {
            get => loginCommand ?? (loginCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<LoginViewModel>();
              }
              ));
        }

        private RelayCommand signUpCommand;
        public RelayCommand SignUpCommand
        {
            get => signUpCommand ?? (signUpCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<SignUpViewModel>();
              }
              ));
        }

        private RelayCommand addTripCommand;
        public RelayCommand AddTripCommand
        {
            get => addTripCommand ?? (addTripCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<AddTripViewModel>();
              }
              ));
        }

        private RelayCommand checkListCommand;
        public RelayCommand CheckListCommand
        {
            get => checkListCommand ?? (checkListCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<CheckBoxViewModel>();
              }
              ));
        }

        private RelayCommand ticketsViewCommand;
        public RelayCommand TicketsViewCommand
        {
            get => ticketsViewCommand ?? (ticketsViewCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<TicketViewModel>();
              }
              ));
        }
    }
}
