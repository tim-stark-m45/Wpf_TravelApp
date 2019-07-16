using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPF_TravelApp.Views;

namespace WPF_TravelApp
{

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var locator = new ViewModelLocator();

            var window = new MainView();
            window.DataContext = locator.GetMainViewModel();
            window.ShowDialog();
        }
    }
}
