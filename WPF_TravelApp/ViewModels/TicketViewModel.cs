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
    class TicketViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly IMessageService messageService;

        public TicketViewModel(
            INavigationService navigationService,
            IMessageService messageService)
        {
            this.navigationService = navigationService;
            this.messageService = messageService;
        }


        private RelayCommand backCommand;
        public RelayCommand BackCommand
        {
            get => backCommand ?? (backCommand = new RelayCommand(
              () =>
              {
                  navigationService.Navigate<HomePageViewModel>();
              }
              ));
        }
    }
}
