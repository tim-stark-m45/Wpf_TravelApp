using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TravelApp.Services
{
    public interface INavigationService
    {
        //void Navigate(string viewName);
        //void Register(string viewName, ViewModelBase viewModel);
        void Navigate<T>();
        void Navigate(Type type);
        void Register<T>(ViewModelBase viewModel);
    }
}
