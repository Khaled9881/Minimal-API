using System.ComponentModel.DataAnnotations;

namespace Minimal_API
{
    public class Product
    {
        [Required(ErrorMessage = "u have to provide product id")]
        public int id { get; set; }
        [Required(ErrorMessage = "product name is required")]
        public string name { get; set; }

        public override string ToString()
        {
            return $"name: {name},  id: {id}";
        }
    }
}
