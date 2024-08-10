using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.Models;

namespace URLShortener.Services
{
    public class URLShortenerService
    {
        public const int URLLength = 8;
        public const string Alphabet = "ABCDEFGHIJKLMNOQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

        private readonly Random _random = new Random();
        private readonly URLShortenerContext _context;

        public URLShortenerService(URLShortenerContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateUniqueURL()
        {
            var codeChars = new char[URLLength];

            while (true)
            {
                for (var i = 0; i < URLLength; i++)
                {
                    var randomIndex = _random.Next(Alphabet.Length - 1);
                    codeChars[i] = Alphabet[randomIndex];
                }
                var generatedCode = new string(codeChars);

                if (!await _context.URLShorter.AnyAsync(u => u.ShortCode == generatedCode).ConfigureAwait(false))
                {
                    return generatedCode;
                }
            }
        }
    }
}
