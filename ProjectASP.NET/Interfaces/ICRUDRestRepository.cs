using Microsoft.AspNetCore.Mvc;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Interfaces
{
    public interface ICRUDRestRepository
    {
        GameModel FindGameById(int id);

        GameModel AddGame([FromBody] GameModel game);

        void DeleteGame(int id);

        GameModel UpdateGame([FromBody] GameModel game);

        List<GameModel> FindAllGames();
    }
}
