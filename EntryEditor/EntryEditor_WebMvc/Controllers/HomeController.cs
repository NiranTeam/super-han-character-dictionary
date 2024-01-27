using EntryEditor_WebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Diagnostics;

namespace EntryEditor_WebMvc.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IMongoDatabase database)
    {
        _logger = logger;
    }

    public ActionResult Index()
    {
        return RedirectToAction(nameof(HanCharacterDictionaryController.Index), "HanCharacterDictionary");
    }
}