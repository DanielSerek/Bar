using Bar.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bar.ViewModels
{
    [NotMapped]
    public class UserViewModel 
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Credit { get; set; }
    }
}
