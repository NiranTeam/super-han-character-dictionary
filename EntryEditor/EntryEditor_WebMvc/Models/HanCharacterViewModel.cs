using System.ComponentModel.DataAnnotations;
using System.Composition;

namespace EntryEditor_WebMvc.Models;
public class HanCharacterViewModel
{
    public HanCharacterModel HanCharacter { get; set; } = default!;

    public bool IncreaseRadicalTextBox { get; set; }
    public int IncreaseRadicalTextBoxValue { get; set; }
}
