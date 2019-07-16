using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TravelApp.Models
{
    public class Trip : ObservableObject
    {
        public int Id { get; set; }
        [Required]
        public string TripName { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<City> Cities { get; set; }
    }
}
