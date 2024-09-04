namespace PruebaWaltherOlivoEventos.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Text { get; set; }
        public DateTime DateSent { get; set; }

        // Relaciones
        public int UserId { get; set; }  // Usuario destinatario
        public User User { get; set; }

        public int? RelatedPostId { get; set; }  // Publicación relacionada (opcional)
        public Post RelatedPost { get; set; }

    }
}
