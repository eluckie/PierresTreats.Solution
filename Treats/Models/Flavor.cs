using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Treats.Models
{
  public class Flavor
  {
    public int FlavorId { get; set; }
    [Required(ErrorMessage = "Please add a flavor name!")]
    public string Description { get; set; }
    public List<TreatFlavor> Join { get; set; }
    public AppUser User { get; set; }
  }
}