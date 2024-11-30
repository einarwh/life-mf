using System.Collections;

namespace Conway.Core.Configs
{
    public class PulsarConfig : Config
    {
        public PulsarConfig()
            : this(0)
        {
        }

        public PulsarConfig(int gen)
            : base(17, 17, 14, GetPulsarCells(gen))
        {
        }

        private static Cell[] GetPulsarCells(int gen)
        {
            if (gen == 1)
            {
                return GetPulsarCellsGen1();
            }

            if (gen == 2)
            {
                return GetPulsarCellsGen2();
            }

            return GetPulsarCells();
        }

        private static Cell[] GetPulsarCellsGen1()
        {
            throw new System.NotImplementedException();
        }

        private static Cell[] GetPulsarCellsGen2()
        {
            throw new System.NotImplementedException();
        }

        private static Cell[] GetPulsarCells()
        {
            var list = new ArrayList
                {
                    new Cell { Y = 2, X = 4 },
                    new Cell { Y = 2, X = 5 },
                    new Cell { Y = 2, X = 6 },

                    new Cell { Y = 2, X = 10 },
                    new Cell { Y = 2, X = 11 },
                    new Cell { Y = 2, X = 12 },

                    new Cell { Y = 4, X = 2 },
                    new Cell { Y = 4, X = 7 },
                    new Cell { Y = 4, X = 9 },
                    new Cell { Y = 4, X = 14 },
                    
                    new Cell { Y = 5, X = 2 },
                    new Cell { Y = 5, X = 7 },
                    new Cell { Y = 5, X = 9 },
                    new Cell { Y = 5, X = 14 },

                    new Cell { Y = 6, X = 2 },
                    new Cell { Y = 6, X = 7 },
                    new Cell { Y = 6, X = 9 },
                    new Cell { Y = 6, X = 14 },

                    new Cell { Y = 7, X = 4 },
                    new Cell { Y = 7, X = 5 },
                    new Cell { Y = 7, X = 6 },

                    new Cell { Y = 7, X = 10 },
                    new Cell { Y = 7, X = 11 },
                    new Cell { Y = 7, X = 12 },

                    new Cell { Y = 9, X = 4 },
                    new Cell { Y = 9, X = 5 },
                    new Cell { Y = 9, X = 6 },

                    new Cell { Y = 9, X = 10 },
                    new Cell { Y = 9, X = 11 },
                    new Cell { Y = 9, X = 12 },

                    new Cell { Y = 10, X = 2 },
                    new Cell { Y = 10, X = 7 },
                    new Cell { Y = 10, X = 9 },
                    new Cell { Y = 10, X = 14 },
                    
                    new Cell { Y = 11, X = 2 },
                    new Cell { Y = 11, X = 7 },
                    new Cell { Y = 11, X = 9 },
                    new Cell { Y = 11, X = 14 },

                    new Cell { Y = 12, X = 2 },
                    new Cell { Y = 12, X = 7 },
                    new Cell { Y = 12, X = 9 },
                    new Cell { Y = 12, X = 14 },

                    new Cell { Y = 14, X = 4 },
                    new Cell { Y = 14, X = 5 },
                    new Cell { Y = 14, X = 6 },

                    new Cell { Y = 14, X = 10 },
                    new Cell { Y = 14, X = 11 },
                    new Cell { Y = 14, X = 12 }
                };
            return (Cell[])list.ToArray(typeof(Cell));
        }
    }
}
