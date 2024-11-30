using System.Collections;

namespace Conway.Core.Configs
{
    public class BeaconConfig : Config
    {
        public BeaconConfig() : this(0) { }

        public BeaconConfig(int gen)
            : base(6, 6, 40, GetBeaconCells(gen))
        {
        }

        private static Cell[] GetBeaconCells(int gen)
        {
            if (gen == 1)
            {
                return GetBeaconCellsGen1();
            }

            return GetBeaconCells();
        }

        private static Cell[] GetBeaconCells()
        {
            var list = new ArrayList
                {
                    new Cell { Y = 1, X = 1 },
                    new Cell { Y = 1, X = 2 },
                    new Cell { Y = 2, X = 1 },
                    new Cell { Y = 2, X = 2 },
                    new Cell { Y = 3, X = 3 },
                    new Cell { Y = 3, X = 4 },
                    new Cell { Y = 4, X = 3 },
                    new Cell { Y = 4, X = 4 }
                };
            return (Cell[])list.ToArray(typeof(Cell));
        }

        private static Cell[] GetBeaconCellsGen1()
        {
            var list = new ArrayList
                {
                    new Cell { Y = 1, X = 1 },
                    new Cell { Y = 1, X = 2 },
                    new Cell { Y = 2, X = 1 },
                    new Cell { Y = 3, X = 4 },
                    new Cell { Y = 4, X = 3 },
                    new Cell { Y = 4, X = 4 }
                };
            return (Cell[])list.ToArray(typeof(Cell));
        }

    }
}
