using System.ComponentModel.DataAnnotations;

namespace LocationFood.Web.Models
{
    public class RecoverPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
