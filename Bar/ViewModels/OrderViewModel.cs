using Bar.DataAcess.Repository.IRepository;
using System.ComponentModel.DataAnnotations;

namespace Bar.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public UserViewModel User { get; set; }

        public string UserId { get; set; }

        public List<OrderItemViewModel> Items { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        public decimal OrderTotal { get; set; }
    }
}
