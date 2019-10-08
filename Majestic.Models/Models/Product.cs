using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Majestic.Models.Models
{
    public class Product
    {
        [Key]
        [Required]
        public int Id { get; set; }

        
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string ProductName { get; set; }

       
        [Required]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }

        

        [ForeignKey("CategoryId")]
        [Required]

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string CategoryName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string ProductImage { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string ProductDescription { get; set; }

    }
}
