using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KidsPuzzles.Models
{
    public class KidsPuzzleViewModel
    {
        [Key]
        public int PuzzleID { get; set; }
        [Required]
        public string PuzzleName { get; set; }
        [Required]
        public string PuzzleDescription { get; set; }
        [Range(1,50, ErrorMessage ="Should be greater than 1$ and < 50$")]
        public int PuzzlePrice { get; set; }

        [Range(1, 5, ErrorMessage = "Please select a rating between 1 and 5")]
        public int PuzzleRating { get; set; }
    }
}
