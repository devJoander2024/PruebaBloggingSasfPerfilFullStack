using PruebaWaltherOlivoEventos.Dtos;
using System.Text.Json.Serialization;

namespace PruebaWaltherOlivoEventos.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePublished { get; set; }

        // Relaciones
        public int CreadorId { get; set; }

        [JsonIgnore]
        public User Creador { get; set; }

        [JsonIgnore]
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
