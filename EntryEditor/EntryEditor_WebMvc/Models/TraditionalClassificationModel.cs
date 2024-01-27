using System.Text.Json.Serialization;

namespace EntryEditor_WebMvc.Models;

public class TraditionalClassificationModel
{
    [JsonPropertyName("type_name")]
    public string TypeName { get; set; } = default!;

    [JsonPropertyName("english")]
    public string English { get; set; } = default!;

    [JsonPropertyName("vietnamese")]
    public string Vietnamese { get; set; } = default!;

    [JsonPropertyName("japanese")]
    public string Japanese { get; set; } = default!;

    [JsonPropertyName("korean")]
    public string Korean { get; set; } = default!;

    [JsonPropertyName("chinese")]
    public string Chinese { get; set; } = default!;
}