using Microsoft.AspNetCore.Mvc;
using Treats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Treats.Controllers
{
  public class HomeController : Controller
  {
    private readonly TreatsContext _db;
    private readonly UserManager<AppUser> _userManager;
    public HomeController(UserManager<AppUser> userManager, TreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    [HttpGet("/")]
    public async Task<ActionResult> Index()
    {
      // string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      // AppUser currentUser = await _userManager.FindByIdAsync(userId);
      // ViewBag.PageTitle = "Pierre's Sweet and Savory Treats";
      // if (currentUser != null)
      // {
      //   ViewBag.Nickname = currentUser.Nickname;
      //   List<Treat> treats = _db.Treats
      //     .Where(entry => entry.User.Id == currentUser.Id)
      //     .ToList();
      //   return View(treats);
      // }
      return View();
    }
  }
}