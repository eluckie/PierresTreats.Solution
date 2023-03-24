using Microsoft.AspNetCore.Identity;

namespace Treats.Models
{
  public class AppUser : IdentityUser
  {
    public string Nickname { get; set; }
    public string AccountName { get; set; }
  }
}