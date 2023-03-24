using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Treats.Models
{
  public class Treat
  {
    public int TreatId { get; set; }
    [Required(ErrorMessage = "Please add a name for your treat!")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Please add the ingredients for allergen visibility!")]
    public string Ingredients { get; set; }
    public List<TreatFlavor> Join { get; set; }
    public AppUser User { get; set; }
  }
}