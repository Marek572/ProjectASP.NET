using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectASP.NET.Models
{
    public class GameModel
    {
        [HiddenInput]
        [Key]
        public int GameId { get; set; }
        public bool Availability { get; set; }

        [Required(ErrorMessage = "Enter game title!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Enter game genre!")]
        public Genre genre { get; set; }

        [Required(ErrorMessage = "Enter game platform!")]
        public string Platform { get; set; }

        [Required(ErrorMessage = "Enter game developer!")]
        public string Developer { get; set; }

        [Required(ErrorMessage = "Enter game publisher!")]
        public string Publisher { get; set; }

        public string Borrowed { get; set; }

        public enum Genre //TODO: choosing 2 or more genres feature
        {
            Action,
            Indie,
            Adventure,
            RPG,
            Simulator,
            FPS,
            Racing,
            Puzzle,
            Fighting,
            Music
        }
    }
}
