using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Majestic.Models.Models
{
    public class Cart
    {
        [Key]
        [Required]
        public int CartId { get; set; }

        public DateTime DateofOrder { get; set; }
 
        [Column(TypeName = "nvarchar(max)")]
        public string ProductImage { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string ProductName { get; set; }


        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        [ForeignKey("AspNetUsers")]
        [Required]
        public string CustomerId { get; set; }
        public virtual ApplicationUser Application { get; set; }




        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Amount { get; set; }

    





    }
}
