using System.ComponentModel.DataAnnotations;

namespace URLShortener.Models
{
    public class URLShorter
    {
        public int Id { get; set; }
        public string? URLName { get; set; }
        [MaxLength(255)] 
        public string? URLShorterName { get; set; }
        public string? ShortCode { get; set; }
    }

    public class CreateShortURLRequest
    {
        public string? Url { get; set; }
    }
}
