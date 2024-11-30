namespace Conway.Core
{
    public class Config
    {
        private readonly int _columns;
        private readonly int _rows;
        private readonly int _pixels;
        private readonly Cell[] _cells;

        public Config(int columns, int rows, int pixels, Cell[] cells)
        {
            _columns = columns;
            _rows = rows;
            _pixels = pixels;
            _cells = cells;
        }

        public int Columns
        {
            get
            {
                return _columns;
            }
        }

        public int Rows
        {
            get
            {
                return _rows;
            }
        }

        public int Pixels
        {
            get
            {
                return _pixels;
            }
        }

        public Cell[] Cells
        {
            get
            {
                return _cells;
            }
        }
    }
}
