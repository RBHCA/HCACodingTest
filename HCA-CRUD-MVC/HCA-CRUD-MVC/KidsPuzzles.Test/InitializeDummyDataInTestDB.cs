using System;
using System.Collections.Generic;
using System.Text;
using KidsPuzzles.Models;

namespace KidsPuzzles.Test
{
    public class InitializeDummyDataInTestDB
    {
        public InitializeDummyDataInTestDB()
        {
        }

        public void LoadTestData(BlogDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.KidsPuzzle.AddRange(
                new KidsPuzzleViewModel() { PuzzleName = "Test Puzzle 1", PuzzleDescription = "Test Puzzle Description 1", PuzzlePrice =10, PuzzleRating =1},
                new KidsPuzzleViewModel() { PuzzleName = "Test Puzzle 2", PuzzleDescription = "Test Puzzle Description 2", PuzzlePrice = 20, PuzzleRating = 2 },
                new KidsPuzzleViewModel() { PuzzleName = "Test Puzzle 3", PuzzleDescription = "Test Puzzle Description 3", PuzzlePrice = 30, PuzzleRating = 3 },
                new KidsPuzzleViewModel() { PuzzleName = "Test Puzzle 4", PuzzleDescription = "Test Puzzle Description 4", PuzzlePrice = 40, PuzzleRating = 4 }
            );

            context.SaveChanges();
        }
    }
}
