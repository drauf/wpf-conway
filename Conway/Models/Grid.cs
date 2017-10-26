using System;
using System.Collections.ObjectModel;
using Conway.Enums;

namespace Conway.Models
{
    public class Grid
    {
        private const int IndexCodingValue = 42000;

        public Cell[,] State { get; set; }

        public Grid(int width, int length)
        {
            GenerateNewGrid(width, length);
        }

        public void GenerateNewGrid(int width, int length)
        {
            State = new Cell[length, width];
            for (var x = 0; x < length; x++)
            {
                for (var y = 0; y < width; y++)
                {
                    State[x, y] = new Cell(CellType.Dead);
                }
            }
        }

        public void ChangeCell(int index)
        {
            var cell = State[index / IndexCodingValue, index % IndexCodingValue];

            switch (cell.Type)
            {
                case CellType.NewAlive:
                    cell.Type = CellType.Alive;
                    break;
                case CellType.Alive:
                    cell.Type = CellType.NewDead;
                    break;
                case CellType.NewDead:
                    cell.Type = CellType.Dead;
                    break;
                case CellType.Dead:
                    cell.Type = CellType.NewAlive;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public ObservableCollection<ObservableCollection<CellDisplay>> GetAsObservableCollection()
        {
            var list = new ObservableCollection<ObservableCollection<CellDisplay>>();
            for (var x = 0; x <= State.GetUpperBound(0); x++)
            {
                list.Add(new ObservableCollection<CellDisplay>());
                for (var y = 0; y <= State.GetUpperBound(1); y++)
                {
                    list[x].Add(new CellDisplay
                    {
                        Index = x * IndexCodingValue + y,
                        Type = CellType.Dead
                    });
                }
            }
            return list;
        }

        public void UpdateObservableCollection(ObservableCollection<ObservableCollection<CellDisplay>> list)
        {
            for (var x = 0; x <= State.GetUpperBound(0); x++)
            {
                for (var y = 0; y <= State.GetUpperBound(1); y++)
                {
                    if (list[x][y].Type != State[x, y].Type)
                    {
                        list[x][y].Type = State[x, y].Type;
                    }
                }
            }
        }

        public void GenerateNextPopulation()
        {
            CountNeighbours();
            UpdatePopulation();
        }

        private void CountNeighbours()
        {
            var maxI = State.GetUpperBound(0);
            var maxJ = State.GetUpperBound(1);

            for (var x = 0; x <= maxI; x++)
            {
                for (var y = 0; y <= maxJ; y++)
                {
                    var cell = State[x, y];
                    cell.NumberOfNeighbours = 0;

                    int previousX = x > 0 ? x - 1 : maxI;
                    int nextX = x < maxI ? x + 1 : 0;
                    int previousY = y > 0 ? y - 1 : maxJ;
                    int nextY = y < maxJ ? y + 1 : 0;

                    // check all neighbours, clock-wise
                    if (State[previousX, previousY].IsAlive()) cell.NumberOfNeighbours++;
                    if (State[previousX, y].IsAlive()) cell.NumberOfNeighbours++;
                    if (State[previousX, nextY].IsAlive()) cell.NumberOfNeighbours++;
                    if (State[x, nextY].IsAlive()) cell.NumberOfNeighbours++;
                    if (State[nextX, nextY].IsAlive()) cell.NumberOfNeighbours++;
                    if (State[nextX, y].IsAlive()) cell.NumberOfNeighbours++;
                    if (State[nextX, previousY].IsAlive()) cell.NumberOfNeighbours++;
                    if (State[x, previousY].IsAlive()) cell.NumberOfNeighbours++;
                }
            }
        }

        private void UpdatePopulation()
        {
            foreach (var cell in State)
            {
                switch (cell.Type)
                {
                    case CellType.NewAlive:
                    case CellType.Alive:
                        if (cell.NumberOfNeighbours < 2) cell.Type = CellType.NewDead;
                        else if (cell.NumberOfNeighbours > 3) cell.Type = CellType.NewDead;
                        else cell.Type = CellType.Alive;
                        break;
                    case CellType.NewDead:
                    case CellType.Dead:
                        cell.Type = cell.NumberOfNeighbours == 3 ? CellType.NewAlive : CellType.Dead;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
