using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class User
    {

        [Key]
        public int UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegisteredAt { get; set; }

        public ICollection<Sale> Sales { get; set; }

        public Restaurant Restaurant { get; set; }   

        public UserPrivateInfo UserPrivateInfo { get; set; }
    }
}
