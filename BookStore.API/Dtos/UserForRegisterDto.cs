using System.ComponentModel.DataAnnotations;

namespace BookStore.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string  Username { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 8, ErrorMessage = "Password must be 8 to 12 characters long.")]
        public string Password { get; set; }
    }
}