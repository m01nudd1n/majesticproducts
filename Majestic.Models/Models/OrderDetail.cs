using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Majestic.Models.Models
{
   public class OrderDetail
    {
        [Key]
        [Required]
        public int Id { get; set; }

      
        public int? OrderId { get; set; }


        [Column(TypeName = "datetime")]
        public DateTime OrderDate { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
      

      
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

        [ForeignKey("AspNetUsers")]
        public string CustomerId { get; set; }
        

      


        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }


    }
}
