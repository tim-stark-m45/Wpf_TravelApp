using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TravelApp.Models;
using WPF_TravelApp.Services;

namespace WPF_TravelApp.ViewModels
{
    class TripAddViewModel : ViewModelBase
    {
        private ObservableCollection<Trip> trips = new ObservableCollection<Trip>();
        public ObservableCollection<Trip> Trips { get => trips; set => Set(ref trips, value); }

        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;
        private readonly AppDbContext db;

        public TripAddViewModel(
            INavigationService navigationService,
            IMessageService messageService,
            AppDbContext db)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
            this.db = db;

            Trips = new ObservableCollection<Trip>(db.Trips);
        }

        private RelayCommand addTripCommand;
        public RelayCommand AddTripCommand
        {
            get => addTripCommand ?? (addTripCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<TripDbAddViewModel>();
              }
              ));
        }

        private RelayCommand goHomePageCommand;
        public RelayCommand GoHomePageCommand
        {
            get => goHomePageCommand ?? (goHomePageCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<HomePageViewModel>();
              }
              ));
        }
    }
}
