using GameTournamentAPI.Data;
using GameTournamentAPI.DTOs;
using GameTournamentAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameTournamentAPI.Services
{
    public class TournamentService
    {
        private readonly AppDbContext _context;

        public TournamentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TournamentResponseDTO>> GetAllAsync()
        {
            return await _context.Tournaments
            .Select(t=> new TournamentResponseDTO 
            { Id = t.Id})
            .ToListAsync();
        }
        public async Task<TournamentResponseDTO> CreateAsync(TournamentCreateDTO dto)
        {
            var tournament = new Tournament
            {
                Title = dto.Title,
                Description = dto.Description,
                MaxPlayers = dto.MaxPlayers,
                Date = dto.Date
            };

            _context.Tournaments.Add(tournament);
            await _context.SaveChangesAsync();

            return new TournamentResponseDTO
            {
                Id = tournament.Id
            };
        }



    }
}
