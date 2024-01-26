using EntryEditor.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EntryEditor;

public partial class MainForm : Form
{
    private readonly IMongoDatabase _database;
    private readonly IMongoCollection<HanCharacterModel> _collection;

    private List<HanCharacterModel> _characters;

    public MainForm(IMongoDatabase database)
    {
        _database = database;
        _collection = database.GetCollection<HanCharacterModel>("All");

        _characters = null!;
        InitializeComponent();
    }

    private void btnFind_Click(object sender, EventArgs e)
    {
        string searchKeyword = txtSearch.Text;
        if (string.IsNullOrEmpty(searchKeyword))
            return;

        _characters = _collection.AsQueryable().Where(x => x.Literal.Contains(searchKeyword)).ToList();
        LoadToDgwMain();
    }

    private void btnAddOrUpdate_Click(object sender, EventArgs e)
    {
        
    }

    private void LoadToDgwMain()
    {
        dgwMain.DataSource = _characters;
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        _characters = _collection.AsQueryable().Take(10).ToList();

        LoadToDgwMain();
    }
}
