using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EntryEditor.Models;

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
}
