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

    public Kangxi Kangxi { get; set; } = new Kangxi();
    public Kanji Kanji { get; set; } = new Kanji();
    public Hanja Hanja { get; set; } = new Hanja();
    public HanTu HanTu { get; set; } = new HanTu();
}

public class Kangxi
{
    [BsonElement("pinyin")]
    public string Pinyin { get; set; } = default!;
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
    public List<KanjiReading> Readings_On { get; set; } = new List<KanjiReading>();

    [BsonElement("readings_kun")]
    public List<KanjiReading> Readings_Kun { get; set; } = new List<KanjiReading>();

    [BsonElement("readings_nanori")]
    public List<KanjiReading> KanjiReadings_Nanori { get; set; } = new List<KanjiReading>();

    [BsonElement("meanings")]
    public List<KanjiMeaning> Meanings { get; set; } = new List<KanjiMeaning>();
}

public class KanjiReading
{
    [BsonElement("kana")]
    public string Kana { get; set; } = default!;

    [BsonElement("romaji")]
    public string Romaji { get; set; } = default!;
}

public class KanjiMeaning
{

}

public class Hanja
{
    [BsonElement("readings")]
    public List<HanjaReading> Readings { get; set; } = new List<HanjaReading>();

    [BsonElement("meanings")]
    public List<HanjaMeaning> Meanings { get; set; } = new List<HanjaMeaning>();
}

public class HanjaReading
{
    [BsonElement("hangul")]
    public string Hangul { get; set; } = default!;

    [BsonElement("romaja")]
    public string Romaja { get; set; } = default!;
}

public class HanjaMeaning
{

}

public class HanTu
{

}