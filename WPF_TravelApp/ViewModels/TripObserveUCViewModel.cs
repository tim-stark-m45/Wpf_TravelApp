using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TravelApp.Services;

namespace WPF_TravelApp.ViewModels
{
    class TripObserveUCViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;

        public TripObserveUCViewModel(
            INavigationService navigationService,
            IMessageService messageService)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
        }


        private RelayCommand<string> testWindowCommand;
        public RelayCommand<string> TestWindowCommand
        {
            get => testWindowCommand ?? (testWindowCommand = new RelayCommand<string>(
              param =>
              {
                  if (param == "1")
                  {
                      navigationService.Navigate<TestWindowViewModel>();
                  }
              }
              ));
        }
    }
}
