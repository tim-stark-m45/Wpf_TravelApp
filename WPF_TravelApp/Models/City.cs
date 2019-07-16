using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_TravelApp.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
    }
}
