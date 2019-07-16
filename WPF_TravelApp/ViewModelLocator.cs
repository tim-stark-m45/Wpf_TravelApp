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
        private MainViewModel mainViewModel;
        private HelloViewModel helloViewModel;
        private SignUpViewModel signUpViewModel;
        private TripAddViewModel tripAddViewModel;
        private TripDbAddViewModel tripDbAddViewModel;
        private HomePageViewModel homePageViewModel;


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
                mainViewModel = Container.Resolve<MainViewModel>();
                helloViewModel = Container.Resolve<HelloViewModel>();
                signUpViewModel = Container.Resolve<SignUpViewModel>();
                tripAddViewModel = Container.Resolve<TripAddViewModel>();
                tripDbAddViewModel = Container.Resolve<TripDbAddViewModel>();
                homePageViewModel = Container.Resolve<HomePageViewModel>();

                navigationService.Register<HelloViewModel>(helloViewModel);
                navigationService.Register<SignUpViewModel>(signUpViewModel);
                navigationService.Register<TripAddViewModel>(tripAddViewModel);
                navigationService.Register<TripDbAddViewModel>(tripDbAddViewModel);
                navigationService.Register<HomePageViewModel>(homePageViewModel);

                navigationService.Navigate<HelloViewModel>();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        public ViewModelBase GetMainViewModel()
        {
            return mainViewModel;
        }
    }
}
