using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjektASP.NET_Tests.Controllers
{
    public class RestGameControllerTest
    {
        [Fact]
        public void TestGet()
        {
            //Given
            RestGameController controller = new RestGameController();
            Game expected = new Game()
            { 
                Title = "Gothic 3",
                genre = 0, 
                Platform = "PC", 
                Developer = "Piranha Bytes",
                Publisher = "THQ Nordic"
            };
            //WhenBook
            actual = controller.Get(1).Value;
            controller.Get(1).Value;
            //Then
            Assert.Equal(expected.Title, actual.Title);            
            Assert.Equal(expected.genre, actual.genre);            
            Assert.Equal(expected.Platform, actual.Platform);            
            Assert.Equal(expected.Developer, actual.Developer);            
            Assert.Equal(expected.Publisher, actual.Publisher);            
        }
    }
}