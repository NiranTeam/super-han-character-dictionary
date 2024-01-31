using MongoDB.Bson.Serialization.Attributes;

namespace EntryEditor_WebMvc.Models;

public class KanjiModel
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
    public List<MeaningModel> Meanings { get; set; } = new List<MeaningModel>();
}

public class KanjiReading
{
    [BsonElement("kana")]
    public string Kana { get; set; } = default!;

    [BsonElement("romaji")]
    public string Romaji { get; set; } = default!;
}