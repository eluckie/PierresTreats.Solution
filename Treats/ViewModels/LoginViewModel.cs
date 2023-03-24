using System.ComponentModel.DataAnnotations;

namespace Treats.ViewModels
{
  public class LoginViewModel
  {
    [Required]
    [Display(Name = "Email or Username")]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}