using Treats.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Treats.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System;

namespace Treats.Controllers
{
  public class AccountController : Controller
  {
    private readonly TreatsContext _db;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TreatsContext db)
    {
      _userManager = userManager;
      _signInManager = signInManager;
      _db = db;
    }
    public IActionResult Register()
    {
      ViewBag.PageTitle = "Create an account";
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
      ViewBag.PageTitle = "Create an account";
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        AppUser user = new AppUser { Email = model.Email, UserName = model.UserName, Nickname = model.Nickname };
        IdentityResult result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
          return RedirectToAction("Login");
        }
        else
        {
          foreach (IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
          return View(model);
        }
      }
    }
    public ActionResult Login()
    {
      ViewBag.PageTitle = "Account Login";
      return View();
    }
    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
      ViewBag.PageTitle = "Account Login";
      if (!ModelState.IsValid)
      {
        return View(model);
      }
      else
      {
        AppUser user = await _userManager.FindByEmailAsync(model.Email);
        if (user != null)
        {
          Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(user, model.Password, isPersistent: true, lockoutOnFailure: false);
          if (result.Succeeded)
          {
            return RedirectToAction("Index");
          }
          else
          {
          ModelState.AddModelError("", "Whoopsies! There is something wrong with your email or username. Please try again.");
          return View(model);
          }
        }
        else
        {
          Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(userName: model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
          if (result.Succeeded)
          {
            return RedirectToAction("Index");
          }
          else
          {
            ModelState.AddModelError("", "Whoops! There is something wrong with your email or username. Please try again.");
            return View(model);
          }
        }
      }
    }
    [HttpPost]
    public async Task<IActionResult> LogOut()
    {
      await _signInManager.SignOutAsync();
      return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> Index()
    {
      ViewBag.PageTitle = "Account Details";
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      AppUser currentUser = await _userManager.FindByIdAsync(userId);
      if (currentUser != null)
      {
        return View(currentUser);
      }
      return View(currentUser);
    }
    [HttpPost]
    public async Task<IActionResult> Edit(string Nickname, string UserName)
    {
      string userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      AppUser userToUpdate = await _userManager.FindByIdAsync(userId);
      userToUpdate.UserName = UserName;
      userToUpdate.Nickname = Nickname;
      IdentityResult result = await _userManager.UpdateAsync(userToUpdate);
      return RedirectToAction("Index");
    }
  }
}