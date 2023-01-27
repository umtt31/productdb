using Microsoft.CodeAnalysis.Options;

namespace AspNetCoreMvc003.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        public string? Color { get; set; }
    }
}
