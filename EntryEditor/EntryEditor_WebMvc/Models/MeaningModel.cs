using MongoDB.Bson.Serialization.Attributes;

namespace EntryEditor_WebMvc.Models;

public class MeaningModel
{
    [BsonElement("lang")]
    public string Lang { get; set; } = default!;

    [BsonElement("value")]
    public string Value { get; set; } = default!;
}