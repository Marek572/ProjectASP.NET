using Xunit;
using ProjectASP.NET.Controllers;
using ProjectASP.NET.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Rest_Api_Tester
{
    public class GameTest
    {
        [Fact]
        public void AddUser()
        {
            GameMemoryRepository gameRepository = new();

            gameRepository.AddGame(new GameModel()
            {
                Availability = true,
                Title = "God of War",
                genre = 0/*GameModel.genre(1)*/,
                Platform = "PS5",
                Developer = "SIE Santa Monica Studio",
                Publisher = "PlayStation"

            });
            gameRepository.AddGame(new GameModel()
            {
                Availability = true,
                Title = "Star Wars Jedi: Fallen Order",
                genre = 0/*GameModel.genre(1)*/,
                Platform = "PC",
                Developer = "Respawn Entertainment",
                Publisher = "Electronic Arts Inc."

            });
            var repo = gameRepository.FindAllGames();
            Assert.Equal(2, repo.Count);
            Assert.IsType<List<GameModel>>(repo);
        }
        [Fact]
        public void FindGameById()
        {
            GameMemoryRepository gameRepository = new();

            gameRepository.AddGame(new GameModel()
            {
                Availability = true,
                Title = "God of War",
                genre = 0/*GameModel.genre(1)*/,
                Platform = "PS5",
                Developer = "SIE Santa Monica Studio",
                Publisher = "PlayStation"

            });
            var repo = gameRepository.FindGameById(1);
            Assert.Equal("God of War", repo.Title);
        }
        [Fact]
        public void DeleteUser()
        {
            GameMemoryRepository gameRepository = new();

            gameRepository.AddGame(new GameModel()
            {
                Availability = true,
                Title = "Star Wars Jedi: Fallen Order",
                genre = 0/*GameModel.genre(1)*/,
                Platform = "PC",
                Developer = "Respawn Entertainment",
                Publisher = "Electronic Arts Inc."

            });
            Assert.NotEmpty(gameRepository.FindAllGames());
            gameRepository.DeleteUser(1);
            Assert.Empty(gameRepository.FindAllGames());
        }

        [Fact]
        public void EditUser()
        {
            GameMemoryRepository gameRepository = new();

            gameRepository.AddGame(new GameModel()
            {
                Availability = true,
                Title = "God of War",
                genre = 0/*GameModel.genre(1)*/,
                Platform = "PS5",
                Developer = "SIE Santa Monica Studio",
                Publisher = "PlayStation"

            });
            gameRepository.UpdateGame(1, new GameModel { Availability = true, Title = "Star Wars Jedi: Fallen Order", genre = 0/*GameModel.genre(1)*/, Platform = "PC", Developer = "Respawn Entertainment", Publisher = "Electronic Arts Inc."});

            Assert.Equal("Star Wars Jedi: Fallen Order", gameRepository.FindGameById(1).Title);
            Assert.Equal("PC", gameRepository.FindGameById(1).Platform);
            Assert.Equal("Respawn Entertainment", gameRepository.FindGameById(1).Developer);
            Assert.Equal("Electronic Arts Inc.", gameRepository.FindGameById(1).Publisher);
        }
    }

}