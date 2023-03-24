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
  public class TreatsController : Controller
  {
    private readonly TreatsContext _db;
    private readonly UserManager<AppUser> _userManager;
    public TreatsController(UserManager<AppUser> userManager, TreatsContext db)
    {
      _userManager = userManager;
      _db = db;
    }
    [AllowAnonymous]
    public async Task<ActionResult> Index()
    {
      string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      AppUser currentUser = await _userManager.FindByIdAsync(userId);
      ViewBag.PageTitle = "Treats";
      if (currentUser != null)
      {
        List<Treat> userTreats = _db.Treats
          .Where(entry => entry.User.Id == currentUser.Id)
          .OrderByDescending(treat => treat.Name)
          .Include(treat => treat.Join)
          .ThenInclude(join => join.Flavor)
          .ToList();
        List<Treat> allTreats = _db.Treats
          .OrderByDescending(treat => treat.Name)
          .Include(treat => treat.Join)
          .ThenInclude(join => join.Flavor)
          .ToList();
        ViewBag.AllTreats = allTreats;
        ViewBag.Nickname = currentUser.Nickname;
        return View(userTreats);
      }
      else
      {
        List<Treat> allTreats = _db.Treats
          .OrderByDescending(treat => treat.Name)
          .Include(treat => treat.Join)
          .ThenInclude(join => join.Flavor)
          .ToList();
        return View(allTreats);
      }
    }
    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add Treat";
      return View();
    }
    [HttpPost]
    public async Task<ActionResult> Create(Treat treat)
    {
      if (!ModelState.IsValid)
      {
        return View(treat);
      }
      else
      {
        string userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        AppUser currentUser = await _userManager.FindByIdAsync(userId);
        treat.User = currentUser;
        _db.Treats.Add(treat);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }
    public ActionResult Details(int id)
    {
      ViewBag.PageTitle = "Treat Details";
      Treat thisTreat = _db.Treats
        .Include(treat => treat.Join)
        .ThenInclude(join => join.Flavor)
        .FirstOrDefault(treat => treat.TreatId == id);
      return View(thisTreat);
    }
    [HttpPost]
    public ActionResult Edit(Treat updatedTreat)
    {
      _db.Treats.Update(updatedTreat);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = updatedTreat.TreatId });
    }
  }
}