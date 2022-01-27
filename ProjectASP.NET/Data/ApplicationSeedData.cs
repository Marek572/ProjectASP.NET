using Microsoft.AspNetCore.Builder;
using ProjectASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Data
{
    public class ApplicationSeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            ICollection<UserModel> users = new List<UserModel>()
            {
                    new UserModel()
                    {
                        UserId = "1",
                        Name = "Callie",
                        Surname = "Noris",
                        /*BirthDate = "12/04/1989",*/
                        Username = "callie.noris",
                        Email = "callie.noris@gmail.com",
                        Phone = "401503862"
                    },
                    new UserModel()
                    {
                        UserId = "2",
                        Name = "Lillie",
                        Surname = "Bruce",
                        Username = "lillie.bruce",
                        Email = "lillie.bruce@gmail.com",
                        Phone = "509735217"
                    },
                    new UserModel()
                    {
                        UserId = "3",
                        Name = "Daisy",
                        Surname = "Diaz",
                        Username = "daisy.diaz",
                        Email = "daisy.diaz@gmail.com",
                        Phone = "369510437"
                    },
                    new UserModel()
                    {
                        UserId = "4",
                        Name = "Murphy",
                        Surname = "Blender",
                        Username = "murphy.blender",
                        Email = "murphy.blender@gmail.com",
                        Phone = "674395291"
                    },
                    new UserModel()
                    {
                        UserId = "5",
                        Name = "Antoni",
                        Surname = "Gunn",
                        Username = "antoni.gunn",
                        Email = "antoni.gunn@gmail.com",
                        Phone = "248975123"
                    }
                };

            ICollection<GameModel> games = new List<GameModel>()
            {
                new GameModel()
                {
                    Availability = true,
                    Title = "God of War",
                    genre = GameModel.Genre.Adventure,
                    Platform = "PS5",
                    Developer = "SIE Santa Monica Studio",
                    Publisher = "Sony Interactive Entertainment",
                    Username = null
                },
                new GameModel()
                {
                    Availability = false,
                    Title = "Star Wars Jedi Fallen Order",
                    genre = GameModel.Genre.Action,
                    Platform = "PC",
                    Developer = "Respawn Entertainment",
                    Publisher = "Electronic Arts Inc.",
                    Username = "daisy.diaz"
                },
                new GameModel()
                {
                    Availability = true,
                    Title = "Assassin's Creed Valhalla",
                    genre = GameModel.Genre.Adventure,
                    Platform = "PC",
                    Developer = "Ubisoft Studios",
                    Publisher = "Ubisoft",
                    Username = null
                },
            };


            foreach (UserModel user in users)
            {
                context.Users.Add(user);
            }

            foreach (GameModel game in games)
            {
                context.Games.Add(game);
            }

            context.SaveChanges();
        }
    }
}
