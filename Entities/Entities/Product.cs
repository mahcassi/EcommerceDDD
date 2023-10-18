using Entities.Notifications;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    [Table("Product")]
    public class Product : Base
    {
        [Column("PRD_PRECO")]
        [Display(Name = "Preco")]
        public decimal Price { get; set; }

        [Column("PRD_ESTADO")]
        [Display(Name = "Estado")]
        public bool State { get; set; }
    }
}
