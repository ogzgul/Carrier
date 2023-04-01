using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Order:IEntity
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("Carriers")]

        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public int CarrierId { get; set; }
        public int OrderDesi { get; set; }
        [DisplayName("Sipariş Tarihi")]
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        public decimal OrderCarrierCost { get; set; }
       
    }
}
