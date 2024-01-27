using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using Microsoft.Build.Framework;

namespace EntryEditor_WebMvc.Models;

public class HanCharacterModel
{
    [BsonId]
    public ObjectId ObjectId { get; set; }

    [BsonElement("literal")]
    public string Literal { get; set; } = default!;

    [BsonElement("traditional_classification")]
    public TraditionalClassificationModel TraditionalClassification { get; set; } = default!;

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
    [BsonElement("gradles")]
    public int Gradles { get; set; }

    [BsonElement("jlpt_level")]
    public int JlptLevel { get; set; }

    [BsonElement("kanken_level")]
    public int KankenLevel { get; set; }

    [BsonElement("is_jouyou_kanji")]
    public bool IsJouyouKanji { get; set; }

    [BsonElement("is_jinmeiyou_kanji")]
    public bool IsJinmeiyouKanji { get; set; }

    [BsonElement("readings_on")]
    public List<string> Readings_On { get; set; } = new List<string>();

    [BsonElement("readings_kun")]
    public List<string> Readings_Kun { get; set; } = new List<string>();
}

public class Hanja
{

}

public class HanTu
{

}