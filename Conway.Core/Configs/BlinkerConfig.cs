using System.Collections;

namespace Conway.Core.Configs
{
    public class BlinkerConfig : Config
    {
        public BlinkerConfig()
            : this(0)
        {
        }

        public BlinkerConfig(int gen)
            : base(5, 5, 48, GetBlinkerCells(gen))
        {
        }

        private static Cell[] GetBlinkerCells(int gen)
        {
            if (gen == 1)
            {
                return GetBlinkerCellsGen1();
            }

            return GetBlinkerCells();
        }

        private static Cell[] GetBlinkerCells()
        {
            var list = new ArrayList
                {
                    new Cell { Y = 2, X = 1 },
                    new Cell { Y = 2, X = 2 },
                    new Cell { Y = 2, X = 3 }
                };
            return (Cell[])list.ToArray(typeof(Cell));
        }

        private static Cell[] GetBlinkerCellsGen1()
        {
            var list = new ArrayList
                {
                    new Cell { Y = 1, X = 2 },
                    new Cell { Y = 2, X = 2 },
                    new Cell { Y = 3, X = 2 }
                };
            return (Cell[])list.ToArray(typeof(Cell));
        }
    }
}
