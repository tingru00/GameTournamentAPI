namespace GameTournamentAPI.Models
{
    // Entity model representing a Tournament stored in the database
    public class Tournament
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxPlayers { get; set; }
        public DateTime Date { get; set; }
    }
}
