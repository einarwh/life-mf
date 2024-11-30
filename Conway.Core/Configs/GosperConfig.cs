using System;
using System.Collections;

namespace Conway.Core.Configs
{
    public class GosperConfig : Config
    {
        public GosperConfig()
            : base(40, 30, 8, GetGosperCells())
        {
        }

        private static Cell[] GetGosperCells()
        {
            var list = new ArrayList
                {
                    new Cell { Y = 1, X = 25 },
                    
                    new Cell { Y = 2, X = 23 },
                    new Cell { Y = 2, X = 25 },
                    
                    new Cell { Y = 3, X = 13 },
                    new Cell { Y = 3, X = 14 },
                    new Cell { Y = 3, X = 21 },
                    new Cell { Y = 3, X = 22 },
                    new Cell { Y = 3, X = 35 },
                    new Cell { Y = 3, X = 36 },

                    new Cell { Y = 4, X = 12 },
                    new Cell { Y = 4, X = 16 },
                    new Cell { Y = 4, X = 21 },
                    new Cell { Y = 4, X = 22 },
                    new Cell { Y = 4, X = 35 },
                    new Cell { Y = 4, X = 36 },

                    new Cell { Y = 5, X = 1 },
                    new Cell { Y = 5, X = 2 },
                    new Cell { Y = 5, X = 11 },
                    new Cell { Y = 5, X = 17 },
                    new Cell { Y = 5, X = 21 },
                    new Cell { Y = 5, X = 22 },

                    new Cell { Y = 6, X = 1 },
                    new Cell { Y = 6, X = 2 },
                    new Cell { Y = 6, X = 11 },
                    new Cell { Y = 6, X = 15 },
                    new Cell { Y = 6, X = 17 },
                    new Cell { Y = 6, X = 18 },
                    new Cell { Y = 6, X = 23 },
                    new Cell { Y = 6, X = 25 },

                    new Cell { Y = 7, X = 11 },
                    new Cell { Y = 7, X = 17 },
                    new Cell { Y = 7, X = 25 },
                    
                    new Cell { Y = 8, X = 12 },
                    new Cell { Y = 8, X = 16 },

                    new Cell { Y = 9, X = 13 },
                    new Cell { Y = 9, X = 14 }
                };
            return (Cell[]) list.ToArray(typeof(Cell));
        }
    }
}
