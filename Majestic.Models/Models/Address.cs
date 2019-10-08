using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Majestic.Models.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("AspNetUsers")]
        public string CustomerId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FullName { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string AddressType { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public string StreetAddress { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string City { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string State { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string PinCode { get; set; }
    }
}