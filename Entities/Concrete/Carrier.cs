using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Runtime.Serialization;

namespace Entities.Concrete
{
    public class Carrier:IEntity
    {
        [Key]
        public int CarrierId { get; set; }
        [StringLength(30, MinimumLength = 2, ErrorMessage = "En az 2,en fazla 30 karakter")]
        [Required(ErrorMessage = "Bu alan zorunludur")]
        [DisplayName("Kargo Adı")]
        public string CarrierName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Kargo Aktif")]
        public bool CarrierIsActive { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [DisplayName("Desi Ücreti")]
        public int CarrierPlusDesiCost { get; set; }
        [Required(ErrorMessage = "Bu alan zorunludur.")]
        [ForeignKey("CarrierConfiguration")]
        public int CarrierConfigurationId { get; set; }
    }
}
