using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Sale
    {

        [Key]
        public int SaleId { get; set; }

        [Column(TypeName = "date")]
        public DateTime PurchaseDate { get; set; }

        [ForeignKey("FoodPackageId")]
        public FoodPackage FoodPackage { get; set; }

        public User User { get; set; }
    }
}
