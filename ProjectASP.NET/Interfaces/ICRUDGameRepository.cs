using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectASP.NET.Models;

namespace ProjectASP.NET
{
    public interface ICRUDGameRepository
    {
        GameModel FindGameById(int id);

        GameModel AddGame(GameModel game);

        void DeleteGame(int id);

        GameModel UpdateGame(GameModel game);

        List<GameModel> FindAllGames();

    }
}
