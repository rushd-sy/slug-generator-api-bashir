using System.ComponentModel.DataAnnotations;

namespace SlugGeneratorApp.Net.DTOs
{
    public class GenerateSlugRequest
    {
        [Required(ErrorMessage ="Text is required")]
        public string Text { get; set; } = string.Empty;
        public char? Separator { get; set; } = '-';
    }
}
