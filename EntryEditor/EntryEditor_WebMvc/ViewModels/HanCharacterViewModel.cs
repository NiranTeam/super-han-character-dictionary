using System.ComponentModel.DataAnnotations;
using System.Composition;
using EntryEditor_WebMvc.Models;

namespace EntryEditor_WebMvc.ViewModels;
public class HanCharacterViewModel
{
    public HanCharacterModel HanCharacter { get; set; } = new HanCharacterModel();

    public string Action { get; set; } = "Create";
    public int IncreaseRadicalTextBoxValue { get; set; }

    public int IncreaseOnReadingTextBoxValue { get; set; }
    public int IncreaseKunReadingTextBoxValue { get; set; }
    public int IncreaseHanjaReadingTextBoxValue { get; set; }
}
