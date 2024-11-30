using Conway.Core;
using Conway.Core.Configs;

using Mjunit;

namespace Conway.Tests
{
    public class ConwayFixture : Fixture
    {
        protected void Verify(Config startConfig, Config endConfig)
        {
            var life = new Life((uint)startConfig.Rows, (uint)startConfig.Rows, startConfig.Cells);
            var cells = life.Evolve();
            var expectedCells = endConfig.Cells;
            AssertSameCells(expectedCells, cells);
        }

        protected void AssertSameCells(Cell[] expectedCells, Cell[] actualCells)
        {
            Assert.AreEqual(expectedCells.Length, actualCells.Length);
            for (int i = 0; i < actualCells.Length; i++)
            {
                var cell = actualCells[i];
                bool foundCell = false;
                for (int j = 0; j < expectedCells.Length; j++)
                {
                    var c = expectedCells[j];
                    if (cell.X == c.X && cell.Y == c.Y)
                    {
                        foundCell = true;
                        break;
                    }
                }

                Assert.IsTrue(foundCell);
            }
        }
    }
}