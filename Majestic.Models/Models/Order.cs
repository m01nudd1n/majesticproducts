using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Majestic.Models.Models
{
   public class Order
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string CustomerId { get; set; }
       

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public virtual Address Address { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Amount { get; set; }


    }
}
