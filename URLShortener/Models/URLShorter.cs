using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    // A URL shortening entity with properties.
    public class URLShorter
    {
        public int Id { get; set; }
        public string? URLName { get; set; }
        public string? URLShorterName { get; set; }
        public string? ShortCode { get; set; }
    }
    // Request payload for creating a shortened URL.
    public class CreateShortURLRequest
    {
        public string? Url { get; set; }
    }
}
