namespace Conway.Core
{
    public class Life
    {
        private readonly uint _noCols;
        private readonly uint _noRows;
        private readonly uint _totalCells;

        private uint[] _neighbourCount;
        private uint[] _liveCells;
        private int _noLiveCells;

        public Life(uint noCols, uint noRows, Cell[] cells)
        {
            _noCols = noCols;
            _noRows = noRows;
            _totalCells = noCols * noRows;
            _liveCells = new uint[_totalCells];
            for (int i = 0; i < cells.Length; i++)
            {
                var cell = cells[i];
                _liveCells[i] = cell.Y * _noCols + cell.X;
            }
            _noLiveCells = cells.Length;
        }

        public Cell[] Evolve()
        {
            SetNeighbourCount();
            UpdateLiveCells();
            return GetCurrentLiveCells();
        }

        private void SetNeighbourCount()
        {
            _neighbourCount = new uint[_totalCells];

            // Iterate over live cells to find neighbour count for live cells and surrounding dead cells.
            for (int i = 0; i < _noLiveCells; i++)
            {
                var cellIndex = this._liveCells[i];

                uint x = cellIndex % _noCols;
                uint y = cellIndex / _noCols;

                uint index = cellIndex;

                // Current row.

                // Current column.
                // ... that's the cell itself.
                // Previous column?
                if (x > 0)
                {
                    _neighbourCount[index - 1]++;
                }
                // Following column?
                if (x < _noCols - 1)
                {
                    _neighbourCount[index + 1]++;
                }

                // Previous row?
                if (y > 0)
                {
                    index = cellIndex - _noCols;
                    // Current column.
                    _neighbourCount[index]++;
                    // Previous column?
                    if (x > 0)
                    {
                        _neighbourCount[index - 1]++;
                    }
                    // Following column?
                    if (x < _noCols - 1)
                    {
                        _neighbourCount[index + 1]++;
                    }
                }

                // Following row?
                if (y < _noRows - 1)
                {
                    index = cellIndex + _noCols;
                    // Current column.
                    _neighbourCount[index]++;
                    // Previous column?
                    if (x > 0)
                    {
                        _neighbourCount[index - 1]++;
                    }
                    // Following column?
                    if (x < _noCols - 1)
                    {
                        _neighbourCount[index + 1]++;
                    }
                }
            }
        }

        private void UpdateLiveCells()
        {
            var nextLiveCells = new uint[this._liveCells.Length];
            int noNextLiveCells = 0;

            int currentLiveCellIndex = 0;
            uint cell = 0;
            for (int row = 0; row < this._noRows; row++)
            {
                for (int col = 0; col < this._noCols; col++)
                {
                    bool alive = false;
                    if (this._neighbourCount[cell] == 3)
                    {
                        alive = true;
                        nextLiveCells[noNextLiveCells++] = cell;
                    }
                    if (currentLiveCellIndex < this._noLiveCells)
                    {
                        // We still got live ones!
                        if (cell == this._liveCells[currentLiveCellIndex])
                        {
                            // This cell is a live one!
                            if (!alive && this._neighbourCount[cell] == 2)
                            {
                                nextLiveCells[noNextLiveCells++] = cell;
                            }
                            ++currentLiveCellIndex;
                        }
                    }
                    ++cell;
                }
            }

            this._liveCells = nextLiveCells;
            this._noLiveCells = noNextLiveCells;
        }

        private Cell[] GetCurrentLiveCells()
        {
            var cells = new Cell[_noLiveCells];
            for (int i = 0; i < _noLiveCells; i++)
            {
                var cellIndex = this._liveCells[i];
                uint col = cellIndex % _noCols;
                uint row = cellIndex / _noCols;
                cells[i] = new Cell { X = col, Y = row };
            }
            return cells;
        }
    }
}