using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace EntryEditor_WebMvc.Models;

public class HanCharacterModel
{
    [BsonId]
    public ObjectId ObjectId { get; set; }

    [BsonElement("literal")]
    public string Literal { get; set; } = default!;

    [BsonElement("radicals")]
    public List<string> Radicals { get; set; } = new List<string>();

    [BsonElement("stroke_count")]
    public int StrokeCount { get; set; }

    public Kangxi Kangxi { get; set; } = default!;
    public Kanji Kanji { get; set; } = default!;
    public Hanja Hanja { get; set; } = default!;
    public HanTu HanTu { get; set; } = default!;
}

public class Kangxi
{

}

public class Kanji
{
    public int Gradles { get; set; }
    public int JlptLevel { get; set; }
    public int KankenLevel { get; set; }
    public bool IsJouyouKanji { get; set; }
    public bool IsJinmeiyouKanji { get; set; }
}

public class Hanja
{

}

public class HanTu
{

}