using System.ComponentModel.DataAnnotations;

namespace Bar.ViewModels
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int Amount { get; set; }
    }
}
