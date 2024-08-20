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
            // Check if the provided URL is valid
            if (string.IsNullOrEmpty(request.Url))
            {
                return BadRequest("URL cannot be null or empty.");
            }

            var existingUrlShortener = await _context.URLShorter.FirstOrDefaultAsync(u => u.URLName == request.Url);

            if (existingUrlShortener != null)
            {
                // Return the existing shortened URL
                return Ok(existingUrlShortener.URLShorterName);
            }

            // Generate a unique short code using the service
            var shortCode = await _urlShortenerService.GenerateUniqueURL();

            // Create the short URL model
            var urlShorter = new URLShorter
            {
                URLName = request.Url, // Original URL
                URLShorterName = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/api/{shortCode}", // Full short URL
                ShortCode = shortCode // Unique short code
            };

            // Add the new short URL to the database
            _context.URLShorter.Add(urlShorter);
            await _context.SaveChangesAsync();

            return Ok(urlShorter.URLShorterName);
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