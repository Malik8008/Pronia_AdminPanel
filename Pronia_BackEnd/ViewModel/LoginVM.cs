using System.ComponentModel.DataAnnotations;

namespace Pronia_BackEnd.ViewModel
{
    public class LoginVM
    {
        [Required,StringLength(maximumLength:20)]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
