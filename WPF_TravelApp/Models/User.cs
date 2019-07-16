using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_TravelApp.Extensions;

namespace WPF_TravelApp.Models
{
    public class User : ObservableObject, IDataErrorInfo
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public int? TripId { get; set; }
        public Trip Trip { get; set; }

        public string Error => throw new NotImplementedException();
        public string this[string columnName] => this.Validate(columnName);
    }
}
