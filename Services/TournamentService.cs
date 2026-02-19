using GameTournamentAPI.Data;
using GameTournamentAPI.DTOs;
using GameTournamentAPI.Models;
using Microsoft.EntityFrameworkCore;

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

    }
}
