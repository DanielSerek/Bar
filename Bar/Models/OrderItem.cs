using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bar.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        
        public int ProductId { get; set; }

        public int OrderId { get; set; }
        
        [Required]
        public int Amount { get; set; }
    }
}
