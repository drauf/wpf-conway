using Conway.Enums;
using Conway.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Conway.Test
{
    [TestClass]
    public class GridTest
    {
        [TestMethod]
        public void Grid_OnCreate_InitializesGridWithDeadCellsWithIndexes()
        {
            var grid = new Grid(4, 2).State;
            const int magicIndexMultiplier = 42000;

            Assert.AreEqual(1, grid.GetUpperBound(0));
            Assert.AreEqual(3, grid.GetUpperBound(1));
            Assert.AreEqual(CellType.Dead, grid[0, 1].Type);
            Assert.AreEqual(CellType.Dead, grid[1, 0].Type);
            Assert.AreEqual(CellType.Dead, grid[1, 3].Type);
            Assert.AreEqual(0 * magicIndexMultiplier + 1, grid[0, 1].Index);
            Assert.AreEqual(1 * magicIndexMultiplier + 0, grid[1, 0].Index);
            Assert.AreEqual(magicIndexMultiplier * 1 + 3, grid[1, 3].Index);
        }

        // test GenerateNewGrid method for some trivial case
        // test ChangeCell method for all possible CellTypes
        // test GetAsObservableCollection method for some trivial case
        // test UpdateObservableCollection method for differing CellTypes
        // test GenerateNextPopulation:
        // check if cell with fewer than two live neighbours dies
        // check if cell with two or three live neighbours lives
        // check if cell with four or more live neighbours dies
        // check if dead cell with exactly three live neighbours becomes a live cell
        // check if the world is "looping" around the corners
    }
}
