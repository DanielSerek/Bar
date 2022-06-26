using Bar.Models;
using System.ComponentModel.DataAnnotations;

namespace Bar.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }
    }
}
