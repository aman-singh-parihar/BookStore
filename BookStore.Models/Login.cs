using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Login
    {
        [DisplayName("Username")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Username.")]
        public string? Username  { get; set; }

        [DisplayName("Password")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Password.")]
        public string? Password  { get; set; }
    }
}
