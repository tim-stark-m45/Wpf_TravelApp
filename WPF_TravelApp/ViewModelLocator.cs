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
        private TripObserveUCViewModel tripObserveUCViewModel;
        private TestWindowViewModel testWindowViewModel;
        private MainViewModel mainViewModel;


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
                tripObserveUCViewModel = Container.Resolve<TripObserveUCViewModel>();
                testWindowViewModel = Container.Resolve<TestWindowViewModel>();
                mainViewModel = Container.Resolve<MainViewModel>();

                navigationService.Register<LoginViewModel>(loginViewModel);
                navigationService.Register<SignUpViewModel>(signUpViewModel);
                navigationService.Register<TripObserveUCViewModel>(tripObserveUCViewModel);
                navigationService.Register<TestWindowViewModel>(testWindowViewModel);
                navigationService.Register<MainViewModel>(mainViewModel);

                navigationService.Navigate<MainViewModel>();
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
