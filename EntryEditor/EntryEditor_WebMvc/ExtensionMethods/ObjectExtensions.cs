using System.Text.Json;

namespace EntryEditor_WebMvc.ExtensionMethods;

public static class ObjectExtensions
{
    public static string ToJson(this object obj)
    {
        return JsonSerializer.Serialize(obj);
    }
}