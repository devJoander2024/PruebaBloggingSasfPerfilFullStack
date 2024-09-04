using System.Text.Json.Serialization;

namespace PruebaWaltherOlivoEventos.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        //[JsonIgnore]
        //public ICollection<Book> Books { get; set; }
    }
}
