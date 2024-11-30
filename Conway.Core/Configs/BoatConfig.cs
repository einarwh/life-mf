using System.Collections;

namespace Conway.Core.Configs
{
    public class BoatConfig : Config
    {
        public BoatConfig()
            : base(5, 5, 48, GetBoatCells())
        {
        }

        private static Cell[] GetBoatCells()
        {
            var list = new ArrayList
                {
                    new Cell { Y = 1, X = 1 },
                    new Cell { Y = 1, X = 2 },
                    new Cell { Y = 2, X = 1 },
                    new Cell { Y = 2, X = 3 },
                    new Cell { Y = 3, X = 2 }
                };
            return (Cell[])list.ToArray(typeof(Cell));
        }
    }
}
