using System;
using System.Collections.Generic;

namespace KidsPuzzlesService.Models
{
    public partial class KidsPuzzles
    {
        public int PuzzleId { get; set; }
        public string PuzzleName { get; set; }
        public string PuzzleDescription { get; set; }
        public int PuzzlePrice { get; set; }
        public int PuzzleRating { get; set; }
    }
}
