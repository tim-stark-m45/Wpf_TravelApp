using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TravelApp.Models;
using WPF_TravelApp.Services;

namespace WPF_TravelApp.ViewModels
{
    class AddTripViewModel : ViewModelBase
    {
        private Trip trip = new Trip();
        public Trip Trip { get => trip; set => Set(ref trip, value); }

        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;
        private readonly AppDbContext db;

        public AddTripViewModel(
            INavigationService navigationService,
            IMessageService messageService,
            AppDbContext db)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
            this.db = db;
        }

        private RelayCommand addTripCommand;
        public RelayCommand AddTripCommand
        {
            get => addTripCommand ?? (addTripCommand = new RelayCommand(
              () =>
              {
                  db.Trips.Add(Trip);
                  db.SaveChanges();

                  navigationService.Navigate<HomePageViewModel>();
              }
              ));
        }

        private RelayCommand cancelAddTripCommand;
        public RelayCommand CancelAddTripCommand
        {
            get => cancelAddTripCommand ?? (cancelAddTripCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<HomePageViewModel>();
              }
              ));
        }
    }
}
