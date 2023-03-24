using Microsoft.AspNetCore.Mvc;
using Treats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Treats.Controllers
{
  public class TreatsController : Controller
  {
    private readonly TreatsContext _db;
    private readonly UserManager<AppUser> _userManager;
    public TreatsController(UserManager<AppUser> userManager, TreatsContext db)
      {
        userManager = _userManager;
        db = _db;
      }
    public ActionResult Index()
    {
      return View();
    }
  }
}