using EntryEditor_WebMvc.Models;
using EntryEditor_WebMvc.ViewModels;
using Kanjidic2;
using Kanjidic2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Text;

namespace EntryEditor_WebMvc.Controllers;

[Route("han-character")]
public class HanCharacterDictionaryController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<HanCharacterModel> _collection;
    private readonly Kanjidic2DataAccess _kanjidic2DataAccess;

    public HanCharacterDictionaryController(ILogger<HomeController> logger, IMongoDatabase database, Kanjidic2DataAccess kanjidic2DataAccess)
    {
        _logger = logger;
        _database = database;
        _collection = database.GetCollection<HanCharacterModel>("All");
        _kanjidic2DataAccess = kanjidic2DataAccess;
    }

    [NonAction]
    public IActionResult AddFormField(HanCharacterViewModel viewModel)
    {
        if (viewModel.IncreaseRadicalTextBoxValue > 0)
        {
            for (int i = 0; i < viewModel.IncreaseRadicalTextBoxValue; i++)
                viewModel.HanCharacter.Radicals.Add(string.Empty);

            viewModel.IncreaseRadicalTextBoxValue = 0;

            return View("CreateOrEdit", viewModel);
        }

        if (viewModel.IncreaseOnReadingTextBoxValue > 0)
        {
            for (int i = 0; i < viewModel.IncreaseOnReadingTextBoxValue; i++)
                viewModel.HanCharacter.Kanji.Readings_On.Add(new KanjiReading { });

            viewModel.IncreaseOnReadingTextBoxValue = 0;

            return View("CreateOrEdit", viewModel);
        }

        if (viewModel.IncreaseKunReadingTextBoxValue > 0)
        {
            for (int i = 0; i < viewModel.IncreaseKunReadingTextBoxValue; i++)
                viewModel.HanCharacter.Kanji.Readings_Kun.Add(new KanjiReading { });

            viewModel.IncreaseKunReadingTextBoxValue = 0;

            return View("CreateOrEdit", viewModel);
        }

        if (viewModel.IncreaseHanjaReadingTextBoxValue > 0)
        {
            for (int i = 0; i < viewModel.IncreaseHanjaReadingTextBoxValue; i++)
                viewModel.HanCharacter.Hanja.Readings.Add(new HanjaReading { });

            viewModel.IncreaseHanjaReadingTextBoxValue = 0;

            return View("CreateOrEdit", viewModel);
        }

        return View("CreateOrEdit", viewModel);
    }

    [NonAction]
    public IActionResult FillDataFromKanjidic2(HanCharacterViewModel viewModel)
    {
        Kanjidic2Model? kanjidic2Model = _kanjidic2DataAccess.Get(viewModel.HanCharacter.Literal);
        return View("CreateOrEdit", viewModel);
    }

    [Route("list")]
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        return View(await _collection.AsQueryable().Take(20).ToListAsync());
    }

    [Route("create")]
    [HttpGet]
    public IActionResult Create()
    {
        string jsonString = Encoding.UTF8.GetString(MainResource.The_six_types_of_han_characters)
            .TrimStart('\uFEFF', '\u200B');
        List<TraditionalClassificationModel> classificationModels = System.Text.Json.JsonSerializer
           .Deserialize<List<TraditionalClassificationModel>>(jsonString)!;

        ViewData["TraditionalClassificationSelectList"] = new SelectList(
            classificationModels,
            nameof(TraditionalClassificationModel.TypeName),
            nameof(TraditionalClassificationModel.English)
        );

        return View("CreateOrEdit", new HanCharacterViewModel() { Action = nameof(Create) });
    }

    [Route("create")]
    [HttpPost]
    public async Task<IActionResult> Create(HanCharacterViewModel viewModel)
    {
        bool isExists = await _collection.AsQueryable()
            .AnyAsync(x => x.Literal == viewModel.HanCharacter.Literal);

        if (isExists)
            return RedirectToAction(nameof(Index));

        string jsonString = Encoding.UTF8.GetString(MainResource.The_six_types_of_han_characters)
            .TrimStart('\uFEFF', '\u200B');
        List<TraditionalClassificationModel> classificationModels = System.Text.Json.JsonSerializer
           .Deserialize<List<TraditionalClassificationModel>>(jsonString)!;

        ViewData["TraditionalClassificationSelectList"] = new SelectList(
            classificationModels,
            nameof(TraditionalClassificationModel.TypeName),
            nameof(TraditionalClassificationModel.English),
            viewModel.HanCharacter.TraditionalClassification
        );

        //AddFormField(viewModel);
        FillDataFromKanjidic2(viewModel);

        await _collection.InsertOneAsync(viewModel.HanCharacter);

        return View("CreateOrEdit", viewModel);
    }

    [Route("edit/{literal}")]
    [HttpGet]
    public async Task<IActionResult> Edit(string literal)
    {
        HanCharacterModel hanCharacterModel = await _collection.AsQueryable()
            .SingleAsync(x => x.Literal == literal);

        if (hanCharacterModel is null)
            return View(nameof(Index));

        string jsonString = Encoding.UTF8.GetString(MainResource.The_six_types_of_han_characters)
            .TrimStart('\uFEFF', '\u200B');
         List<TraditionalClassificationModel> classificationModels = System.Text.Json.JsonSerializer
            .Deserialize<List<TraditionalClassificationModel>>(jsonString)!;

        ViewData["TraditionalClassificationSelectList"] = new SelectList(
            classificationModels,
            nameof(TraditionalClassificationModel.TypeName),
            nameof(TraditionalClassificationModel.English),
            hanCharacterModel.TraditionalClassification
        );

        return View("CreateOrEdit", new HanCharacterViewModel { Action = nameof(Edit), HanCharacter = hanCharacterModel });
    }

    [Route("edit/{literal}")]
    [HttpPost]
    public async Task<IActionResult> Edit(string literal, HanCharacterViewModel viewModel)
    {
        string jsonString = Encoding.UTF8.GetString(MainResource.The_six_types_of_han_characters)
            .TrimStart('\uFEFF', '\u200B');
        List<TraditionalClassificationModel> classificationModels = System.Text.Json.JsonSerializer
           .Deserialize<List<TraditionalClassificationModel>>(jsonString)!;

        ViewData["TraditionalClassificationSelectList"] = new SelectList(
            classificationModels,
            nameof(TraditionalClassificationModel.TypeName),
            nameof(TraditionalClassificationModel.English),
            viewModel.HanCharacter.TraditionalClassification
        );

        //AddFormField(viewModel);

        FilterDefinition<HanCharacterModel> filter = Builders<HanCharacterModel>.Filter.Eq(x => x.Literal, literal);
        UpdateDefinition<HanCharacterModel> update = Builders<HanCharacterModel>.Update.Set(x => x, viewModel.HanCharacter);
        await _collection.UpdateOneAsync(filter, update);

        return View("CreateOrEdit", viewModel);
    }
}