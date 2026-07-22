using System.ComponentModel.DataAnnotations;

namespace Minimal_API
{
    public class Product
    {
        [Required]
        public int id { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"name: {name},  id: {id}";
        }
    }
}
