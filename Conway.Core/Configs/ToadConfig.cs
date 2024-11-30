using System.Collections;

namespace Conway.Core.Configs
{
    public class ToadConfig : Config
    {
        public ToadConfig() : this(0) {}

        public ToadConfig(int gen)
            : base(6, 6, 40, GetToadCells(gen))
        {
        }

        private static Cell[] GetToadCells(int gen)
        {
            if (gen == 1)
            {
                return GetToadCellsGen1();
            }

            return GetToadCells();
        }

        private static Cell[] GetToadCells()
        {
            var list = new ArrayList
                {
                    new Cell { Y = 2, X = 2 },
                    new Cell { Y = 2, X = 3 },
                    new Cell { Y = 2, X = 4 },
                    new Cell { Y = 3, X = 1 },
                    new Cell { Y = 3, X = 2 },
                    new Cell { Y = 3, X = 3 }
                };
            return (Cell[])list.ToArray(typeof(Cell));
        }

        private static Cell[] GetToadCellsGen1()
        {
            var list = new ArrayList
                {
                    new Cell { Y = 1, X = 3 },
                    new Cell { Y = 2, X = 1 },
                    new Cell { Y = 2, X = 4 },
                    new Cell { Y = 3, X = 1 },
                    new Cell { Y = 3, X = 4 },
                    new Cell { Y = 4, X = 2 }
                };
            return (Cell[])list.ToArray(typeof(Cell));
        }

    }
}
