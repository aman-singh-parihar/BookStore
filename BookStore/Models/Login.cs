using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Login
    {
        [DisplayName("Username")]
        public string Username  { get; set; }

        [DisplayName("Password")]
        public string Password  { get; set; }
    }
}
