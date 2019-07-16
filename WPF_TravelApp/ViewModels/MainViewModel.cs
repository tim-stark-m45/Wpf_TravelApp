﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TravelApp.Services;

namespace WPF_TravelApp.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase currentPage;
        public ViewModelBase CurrentPage { get => currentPage; set => Set(ref currentPage, value); }

        private readonly INavigationService navigation;

        public MainViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
            Messenger.Default.Register<ViewModelBase>(this, viewModel => CurrentPage = viewModel);
        }

        private RelayCommand<Type> navigateCommand;
        public RelayCommand<Type> NavigateCommand
        {
            get => navigateCommand ?? (navigateCommand = new RelayCommand<Type>(
              param =>
              {
                  navigation.Navigate(param);
              }
              ));
        }
    }
}