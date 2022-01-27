using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest_Api_Tester
{
    class GameMemoryRepository
    {
        private Dictionary<int, GameModel> Games = new();
        private int Index = 1;


        public GameModel AddGame([FromBody] GameModel game)
        {
            Games.Add(Index, game);
            Index = (Index + 1);
            return game;
        }

        public void DeleteUser(int id)
        {
            Games.Remove(id);
        }

        public void UpdateGame(int id, [FromBody] GameModel game)
        {
            Games[id].Availability = game.Availability;
            Games[id].Title = game.Title;
            Games[id].genre = game.genre;
            Games[id].Platform = game.Platform;
            Games[id].Developer = game.Developer;
            Games[id].Publisher = game.Publisher;
        }

        public List<GameModel> FindAllGames()
        {
            return Games.Values.ToList();
        }

        public GameModel FindGameById(int id)
        {
            return Games[id];
        }
    }
}