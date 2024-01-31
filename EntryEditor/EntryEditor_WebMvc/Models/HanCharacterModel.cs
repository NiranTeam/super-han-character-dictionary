using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

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
    public KanjiModel Kanji { get; set; } = new KanjiModel();
    public Hanja Hanja { get; set; } = new Hanja();
    public HanTu HanTu { get; set; } = new HanTu();
}

public class Kangxi
{
    [BsonElement("pinyin")]
    public string Pinyin { get; set; } = default!;
}

public class Hanja
{
    [BsonElement("readings")]
    public List<HanjaReading> Readings { get; set; } = new List<HanjaReading>();

    [BsonElement("meanings")]
    public List<MeaningModel> Meanings { get; set; } = new List<MeaningModel>();
}

public class HanjaReading
{
    [BsonElement("hangul")]
    public string Hangul { get; set; } = default!;

    [BsonElement("romaja")]
    public string Romaja { get; set; } = default!;
}



public class HanTu
{

}