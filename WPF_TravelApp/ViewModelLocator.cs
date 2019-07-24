using Autofac;
using Autofac.Configuration;
using GalaSoft.MvvmLight;
using Microsoft.Extensions.Configuration;
using System;
using System.Windows;
using WPF_TravelApp.Services;
using WPF_TravelApp.ViewModels;

namespace WPF_TravelApp
{
    class ViewModelLocator
    {
        private AppViewModel appViewModel;
        private LoginViewModel loginViewModel;
        private SignUpViewModel signUpViewModel;
        private MainViewModel mainViewModel;
        private HomePageViewModel homePageViewModel;
        private AddTripViewModel addTripViewModel;
        private CheckBoxViewModel checkBoxViewModel;
        private TicketViewModel ticketViewModel;


        private INavigationService navigationService;
        public static IContainer Container;

        public ViewModelLocator()
        {
            try
            {
                var config = new ConfigurationBuilder();
                config.AddJsonFile("autofac.json");
                var module = new ConfigurationModule(config.Build());
                var builder = new ContainerBuilder();
                builder.RegisterModule(module);
                Container = builder.Build();

                navigationService = Container.Resolve<INavigationService>();
                appViewModel = Container.Resolve<AppViewModel>();
                loginViewModel = Container.Resolve<LoginViewModel>();
                signUpViewModel = Container.Resolve<SignUpViewModel>();
                mainViewModel = Container.Resolve<MainViewModel>();
                homePageViewModel = Container.Resolve<HomePageViewModel>();
                addTripViewModel = Container.Resolve<AddTripViewModel>();
                checkBoxViewModel = Container.Resolve<CheckBoxViewModel>();
                ticketViewModel = Container.Resolve<TicketViewModel>();

                navigationService.Register<LoginViewModel>(loginViewModel);
                navigationService.Register<SignUpViewModel>(signUpViewModel);
                navigationService.Register<MainViewModel>(mainViewModel);
                navigationService.Register<HomePageViewModel>(homePageViewModel);
                navigationService.Register<AddTripViewModel>(addTripViewModel);
                navigationService.Register<CheckBoxViewModel>(checkBoxViewModel);
                navigationService.Register<TicketViewModel>(ticketViewModel);

                navigationService.Navigate<HomePageViewModel>();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public ViewModelBase GetAppViewModel()
        {
            return appViewModel;
        }
    }
}
