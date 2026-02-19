using GameTournamentAPI.Data;
using GameTournamentAPI.DTOs;
using GameTournamentAPI.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GameTournamentAPI.Services
{
    // Handles business logic and database operations for Tournament
    public class TournamentService
    {
        private readonly AppDbContext _context;
        // Injects DbContext for database access
        public TournamentService(AppDbContext context)
        {
            _context = context;
        }

        // Returns all tournaments with optional title search
        public async Task<List<TournamentResponseDTO>> GetAllAsync(string? search)
        {
            var query = _context.Tournaments.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(t => t.Title.Contains(search));
            }

            return await query

            .Select(t=> new TournamentResponseDTO 
            { Id = t.Id})
            .ToListAsync();
        }

        // Creates a new tournament and saves it to the database
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

        // Updates an existing tournament by id
        public async Task<bool> UpdateAsync(int id, TournamentUpdateDTO dto)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
                return false;

            tournament.Title = dto.Title;
            tournament.Description = dto.Description;
            tournament.MaxPlayers = dto.MaxPlayers;
            tournament.Date = dto.Date;

            await _context.SaveChangesAsync();

            return true;
        }

        // Returns a specific tournament by id
        public async Task<TournamentResponseDTO?> GetByIdAsync(int id)
        {
            var tournament = await _context.Tournaments
                .FirstOrDefaultAsync(t => t.Id == id);

            if (tournament == null)
                return null;

            return new TournamentResponseDTO
            {
                Id = tournament.Id
            };
        }

        // Deletes a tournament by id
        public async Task<bool> DeleteAsync(int id)
        {
            var tournament = await _context.Tournaments.FindAsync(id);

            if (tournament == null)
                return false;

            _context.Tournaments.Remove(tournament);
            await _context.SaveChangesAsync();

            return true;
        }



    }
}
