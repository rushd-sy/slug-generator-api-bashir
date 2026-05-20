namespace SlugGeneratorApp.Net.DTOs
{
    public class GenerateSlugResponse
    {
        public string Slug { get; set; } = string.Empty;
        public string OriginalText { get; set; } = string.Empty;
        public string GeneratedAt { get; set; } = string.Empty;
    }
}
