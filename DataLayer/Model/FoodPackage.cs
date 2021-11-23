using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class FoodPackage
    {

        [Key]
        public int FoodPackageId { get; set; }

        [Required]
        [MaxLength(20)]
        public string MealName { get; set; }

        [Required]
        [Column(TypeName = "smallmoney")]
        public double PackagePrice { get; set; }
        [Required]
        [MaxLength(20)]
        public string FoodCategory { get; set; }
        [MaxLength(20)]
        public string MealType { get; set; }
        [MaxLength(20)]
        public string Allergen { get; set; }
        [MaxLength(20)]
        public string? Unsold { get; set; }
        [Column(TypeName = "date")]
        public DateTime PackagingDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime ExpirationDate { get; set; }
        public Restaurant Restaurant { get; set; }
        public Sale Sale { get; set; }
    }
}
