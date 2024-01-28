using System.ComponentModel.DataAnnotations;
using System.Composition;

namespace EntryEditor_WebMvc.Models;
public class HanCharacterViewModel
{
    public HanCharacterModel HanCharacter { get; set; } = new HanCharacterModel();

    public string Action { get; set; } = "Create";
    public int IncreaseRadicalTextBoxValue { get; set; }

    public int IncreaseOnReadingTextBoxValue { get; set; }
    public int IncreaseKunReadingTextBoxValue { get; set; }
    public int IncreaseHanjaReadingTextBoxValue { get; set; }
}
