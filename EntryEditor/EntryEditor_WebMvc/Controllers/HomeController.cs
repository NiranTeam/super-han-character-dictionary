using EntryEditor_WebMvc.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Diagnostics;

namespace EntryEditor_WebMvc.Controllers
{
    [Route("han-character")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<HanCharacterModel> _collection;

        public HomeController(ILogger<HomeController> logger, IMongoDatabase database)
        {
            _logger = logger;
            _database = database;
            _collection = database.GetCollection<HanCharacterModel>("All");
        }

        [Route("list")]
        public async Task<IActionResult> Index()
        {
            return View(await _collection.AsQueryable().Take(20).ToListAsync());
        }

        [Route("create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View(new HanCharacterModel());
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(HanCharacterModel model)
        {
            HanCharacterModel hanCharacterModel = await _collection.AsQueryable()
                .SingleOrDefaultAsync(x => x.Literal == model.Literal);

            if (hanCharacterModel is not null)
                return View(nameof(Index));

            if (!ModelState.IsValid)
                return View(model);

            await _collection.InsertOneAsync(model);

            return View(model);
        }

        [Route("edit/{literal}")]
        [HttpGet]
        public async Task<IActionResult> Edit(string literal)
        {
            HanCharacterModel hanCharacterModel = await _collection.AsQueryable()
                .SingleAsync(x => x.Literal == literal);

            if (hanCharacterModel is null)
                return View(nameof(Index));

            return View(hanCharacterModel);
        }

        [Route("edit/{literal}")]
        [HttpPost]
        public async Task<IActionResult> Edit(string literal, HanCharacterModel model)
        {
            if (ModelState.IsValid)
                return View(model);

            FilterDefinition<HanCharacterModel> filter = Builders<HanCharacterModel>.Filter.Eq(x => x.Literal, literal);
            UpdateDefinition<HanCharacterModel> update = Builders<HanCharacterModel>.Update.Set(x => x, model);
            await _collection.UpdateOneAsync(filter, update);

            return View(model);
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
}
