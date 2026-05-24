using Microsoft.AspNetCore.Mvc;
using SlugGeneratorApp.Net.DTOs;
using SlugGenerator;
using Asp.Versioning.Routing;
using Asp.Versioning;
namespace SlugGeneratorApp.Net.Controllers
{
    
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/slugs")]
    public class SlugsController: ControllerBase
    {
        [HttpPost]
        public ActionResult<GenerateSlugResponse> GenerateSlug([FromBody] GenerateSlugRequest request)
        {
            if(request == null)
            {
                return BadRequest("Request body is required.");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var slug = SlugGenerator.SlugGenerator.GenerateSlug(request.Text, request.Separator);
            var response = new GenerateSlugResponse
            {
                Slug = slug,
                OriginalText = request.Text,
            };


            return Ok(response);
        }

    }
}
