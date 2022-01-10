using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET
{
    public class CRUDGameRepository : ICRUDGameRepository
    {
        private ApplicationDbContext _context;

        public CRUDGameRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public GameModel FindGameById(int id)
        {
            return _context.Games.Find(id);
        }

        public GameModel AddGame(GameModel game)
        {
            var entity = _context.Games.Add(game).Entity;
            _context.SaveChanges();
            return entity;
        }

        public GameModel UpdateGame(GameModel game)
        {
            GameModel original = _context.Games.Find(game.GameId);
            original.Availability = game.Availability;
            original.Borrowed = game.Borrowed;
            EntityEntry<GameModel> entityEntry = _context.Games.Update(original);
            _context.SaveChanges();
            return entityEntry.Entity;
        }

        public void DeleteGame(int id)
        {
            _context.Games.Remove(_context.Games.Find(id));
            _context.SaveChanges();
        }

        public List<GameModel> FindAllGames()
        {
            return _context.Games.ToList();
        }
    }
}
