using System.Text.Json;

namespace EntryEditor_WebMvc.ExtensionMethods;

public static class StringListExtensions
{
    public static string ToJson(this List<string> items)
    {
        return JsonSerializer.Serialize(items);
    }
}