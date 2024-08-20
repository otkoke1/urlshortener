using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using URLShortener.Data;
using URLShortener.Models;

namespace URLShortener.Services
{
    public class URLShortenerService
    {
        public const int URLLength = 8; // The length of the generated code

        // The characters that can be used in the short URL code
        public const string Alphabet = "ABCDEFGHIJKLMNOQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";

        private readonly Random _random = new Random(); // Instance of Random class to generate random numbers

        private readonly URLShortenerContext _context;  // The context to interact with the database

        // Constructor to initialize URLShortenerContext
        public URLShortenerService(URLShortenerContext context)
        {
            _context = context;
        }

        // Method to generate a unique short URL code
        public async Task<string> GenerateUniqueURL()
        {
            // Array to hold the generated short URL code characters
            var codeChars = new char[URLLength];

            while (true)
            {
                // Generate a random short URL code
                for (var i = 0; i < URLLength; i++)
                {
                    // Get a random index to pick a character from the Alphabet
                    var randomIndex = _random.Next(Alphabet.Length);
                    codeChars[i] = Alphabet[randomIndex];
                }

                var generatedCode = new string(codeChars);  // Convert the character array to a string

                // Check if the generated code already exists in the database
                if (!await _context.URLShorter.AnyAsync(u => u.ShortCode == generatedCode).ConfigureAwait(false))
                {
                    return generatedCode;
                }
            }
        }
    }
}
