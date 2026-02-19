using System.ComponentModel.DataAnnotations;

namespace GameTournamentAPI.DTOs
{
    public class TournamentCreateDTO
    {
        [Required]
        [MinLength(3)]
        public string Title { get; set; }
        public string Description { get; set; }
        public int MaxPlayers { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
