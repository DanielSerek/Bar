using Bar.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bar.Models
{
    public class Order
    {
        public int Id { get; set; }

        [MaxLength(10)]
        [Required]
        public string Number { get; set; }

        [Required]
        [Display(Name ="Order Date")]
        public DateTime OrderDate{ get; set; }

        [Column(TypeName = "decimal(7, 2)")]
        public decimal OrderTotal { get; set; }

        public AppUser User { get; set; }

        public string UserId { get; set; }

        [Required]
        public List<OrderItem> Items { get; set; }

        public Order()
        {
        }
    }
}
