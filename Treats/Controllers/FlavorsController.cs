using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Treats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace Treats.Controllers
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly TreatsContext _db;
    private readonly UserManager<AppUser> _userManager;
    public FlavorsController(UserManager<AppUser> userManager, TreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    [AllowAnonymous]
    public async Task<ActionResult> Index()
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      AppUser currentUser = await _userManager.FindByIdAsync(userId);
      ViewBag.PageTitle = "Flavors";
      if (currentUser != null)
      {
        List<Flavor> userFlavors = _db.Flavors
          .Where(entry => entry.User.Id == currentUser.Id)
          .OrderBy(flavor => flavor.Description)
          .Include(flavor => flavor.Join)
          .ThenInclude(join => join.Treat)
          .ToList();
        List<Flavor> allFlavors = _db.Flavors
          .OrderBy(flavor => flavor.Description)
          .Include(flavor => flavor.Join)
          .ThenInclude(join => join.Treat)
          .ToList();
        ViewBag.AllFlavors = allFlavors;
        ViewBag.Nickname = currentUser.Nickname;
        return View(userFlavors);
      }
      else
      {
        List<Flavor> allFlavors = _db.Flavors
          .OrderBy(flavor => flavor.Description)
          .Include(flavor => flavor.Join)
          .ThenInclude(join => join.Treat)
          .ToList();
        return View(allFlavors);
      }
    }
    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add Flavor";
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor)
    {
      if (!ModelState.IsValid)
      {
        return View(flavor);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        AppUser currentUser = await _userManager.FindByIdAsync(userId);
        flavor.User = currentUser;
        _db.Flavors.Add(flavor);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      ViewBag.PageTitle = "Flavor Details";
      Flavor thisFlavor = _db.Flavors
        .Include(flavor => flavor.Join)
        .ThenInclude(join => join.Treat)
        .FirstOrDefault(flavor => flavor.FlavorId == id);
      return View(thisFlavor);
    }
  }
}