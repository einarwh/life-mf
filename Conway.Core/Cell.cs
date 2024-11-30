namespace Conway.Core
{
    public struct Cell
    {
        public uint X;
        public uint Y;

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }
    }
}
