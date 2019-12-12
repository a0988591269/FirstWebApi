using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstWebApi.Models
{
    public class PaymentDetail
    {
        //MyProperty
        [Key]
        public int PMId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string CardOwnerName { get; set; }
        [Required]
        [Column(TypeName = "varchar(10)")]
        public string CardNumber { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string ExpirationDate { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string CVV { get; set; }
    }
}
