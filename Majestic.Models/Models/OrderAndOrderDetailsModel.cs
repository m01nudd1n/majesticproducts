using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Majestic.Models.Models
{
    public class OrderAndOrderDetailsModel
    {
        [Required]
        public int Id { get; set; }

        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }


        [Column(TypeName = "decimal(8, 2)")]
        public decimal Amount { get; set; }


        public string CustomerId { get; set; }


       
        public int AddressId { get; set; }
       

        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }


     

    }
}
