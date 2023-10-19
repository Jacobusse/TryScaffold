using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TryScaffold.Data;
using TryScaffold.Models;

namespace TryScaffold.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDbContextFactory<ChinookContext> _factory;

    public HomeController(ILogger<HomeController> logger, IDbContextFactory<ChinookContext> factory)
    {
        _logger = logger;
        _factory = factory;
    }

    public IActionResult Index()
    {
        using var db = _factory.CreateDbContext();

        var list = db.Albums.Include(a => a.Tracks).ToList();

        return View(list);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
