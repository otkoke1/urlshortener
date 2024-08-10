using System.Configuration;
using System.Net;
using System.Threading.Tasks;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.Models;
using URLShortener.Services;
using static System.Net.WebRequestMethods;

namespace URLShortener.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class URLShortenersController : ControllerBase
    {
        private readonly URLShortenerService _urlShortenerService;
        private readonly URLShortenerContext _context;

        public URLShortenersController(URLShortenerService urlShortenerService, URLShortenerContext context)
        {
            _urlShortenerService = urlShortenerService;
            _context = context;
        }

        [HttpGet("shorturl/{id}")]
        public async Task<ActionResult<URLShorter>> GetShortURL(int id)
        {
            var urlShortener = await _context.URLShorter.FirstOrDefaultAsync(u => u.Id == id);

            if (urlShortener == null)
            {
                return NotFound();
            }

            return urlShortener;
        }

        [HttpPost("api/shorten")]
        public async Task<ActionResult<string>> CreateShortURL([FromBody] CreateShortURLRequest request)
        {
            if (string.IsNullOrEmpty(request.Url))
            {
                return BadRequest("URL cannot be null or empty.");
            }
            var ShortCodeURL = await _urlShortenerService.GenerateUniqueURL();

            var uRLShorter = new URLShorter
            {
                URLName = request.Url,
                URLShorterName = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/{ShortCodeURL}",
                ShortCode = ShortCodeURL
            };

            if (uRLShorter == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while creating the short URL.");
            }

            _context.URLShorter.Add(uRLShorter);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetShortURL", new { id = uRLShorter.Id }, uRLShorter);
            return Ok(uRLShorter.URLShorterName);
        }

        [HttpGet("api/{shortCode}")]
        public async Task<IActionResult> RedirectToOriginalUrl(string shortCode)
        {
            var shortenedUrl = await _context.URLShorter.FirstOrDefaultAsync(u => u.ShortCode == shortCode);

            if (shortenedUrl == null)
            {
                return NotFound("Shortened URL not found.");
            }

            if (string.IsNullOrEmpty(shortenedUrl.URLName))
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Shortened URL does not have a valid destination.");
            }

            return Redirect(shortenedUrl.URLName);
        }
    }
}