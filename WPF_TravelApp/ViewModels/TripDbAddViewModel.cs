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
    class TripDbAddViewModel : ViewModelBase
    {
        private Trip trip = new Trip();
        public Trip Trip { get => trip; set => Set(ref trip, value); }

        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;
        private readonly AppDbContext db;

        public TripDbAddViewModel(
            INavigationService navigationService,
            IMessageService messageService,
            AppDbContext db)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
            this.db = db;
        }

        private RelayCommand addTripDbCommand;
        public RelayCommand AddTripDbCommand
        {
            get => addTripDbCommand ?? (addTripDbCommand = new RelayCommand(
              () =>
              {
                  db.Trips.Add(Trip);
                  db.SaveChanges();

                  navigationService.Navigate<TripAddViewModel>();
              }
              ));
        }
    }
}
