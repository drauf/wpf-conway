using Conway.Enums;

namespace Conway.Models
{
    public class Cell
    {
        public CellType Type { get; set; }
        public int NumberOfNeighbours { get; set; }

        public Cell(CellType type) : this(type, 0) { }

        private Cell(CellType type, int numberOfNeighbours)
        {
            Type = type;
            NumberOfNeighbours = numberOfNeighbours;
        }

        public bool IsAlive()
        {
            return Type == CellType.Alive || Type == CellType.NewAlive;
        }
    }
}
