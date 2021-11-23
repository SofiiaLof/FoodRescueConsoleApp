using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Restaurant
    {
        [MaxLength(30)]
        public string RestaurantName { get; set; }
        [MaxLength(20)]
        public string RestaurantAddress { get; set; }
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(30)]
        public string EmailAddress { get; set; }

        public ICollection<FoodPackage> FoodPackages { get; set; }
    }
}
