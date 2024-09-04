namespace PruebaWaltherOlivoEventos.Models
{
    public class Follower
    {
        public int FollowerId { get; set; }

        // Relaciones
        public int UserId { get; set; }  // Usuario que sigue a otro
        public User User { get; set; }

        public int FollowedUserId { get; set; }  // Usuario seguido
        public User FollowedUser { get; set; }
    }
}
