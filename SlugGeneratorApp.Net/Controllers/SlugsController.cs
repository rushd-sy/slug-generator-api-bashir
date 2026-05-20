using Microsoft.AspNetCore.Mvc;
using SlugGeneratorApp.Net.DTOs;
using SlugGenerator;
namespace SlugGeneratorApp.Net.Controllers
{
    [ApiController]
    [Route("api/v1/slugs")]
    public class SlugsController: ControllerBase
    {
        [HttpPost]
        public ActionResult<string> GenerateSlug([FromBody] GenerateSlugRequest request)
        {
            var slug = SlugGenerator.SlugGenerator.GenerateSlug(request.Text, request.Separator='-');
            var response = new GenerateSlugResponse
            {
                Slug = slug,
                OriginalText = request.Text,
                GeneratedAt = DateTime.UtcNow.ToString("o")
            };


            return Ok(response);
        }

    }
}
