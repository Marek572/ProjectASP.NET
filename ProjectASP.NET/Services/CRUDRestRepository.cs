using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectASP.NET.Interfaces;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET
{
    public class CRUDRestRepository : ICRUDRestRepository
    {
        private ApplicationDbContext _context;

        public CRUDRestRepository(ApplicationDbContext context)
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
            original.Title = game.Title;
            original.genre = game.genre;
            original.Platform = game.Platform;
            original.Developer = game.Developer;
            original.Publisher = game.Publisher;

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
