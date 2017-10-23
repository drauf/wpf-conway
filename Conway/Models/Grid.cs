using System;
using System.Collections.ObjectModel;
using Conway.Enums;

namespace Conway.Models
{
    public class Grid
    {
        private readonly Cell[,] _grid;
        private const int IndexCodingValue = 42000;

        public Grid(int n, int m)
        {
            _grid = new Cell[n, m];
            for (var x = 0; x < n; x++)
            {
                for (var y = 0; y < m; y++)
                {
                    _grid[x, y] = new Cell(CellType.Dead);
                }
            }
        }

        public void ChangeCell(int index)
        {
            var cell = _grid[index / IndexCodingValue, index % IndexCodingValue];

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

            for (var x = 0; x <= _grid.GetUpperBound(0); x++)
            {
                list.Add(new ObservableCollection<CellDisplay>());

                for (var y = 0; y <= _grid.GetUpperBound(1); y++)
                {
                    list[x].Add(new CellDisplay
                    {
                        Index = x * IndexCodingValue + y,
                        Type = _grid[x, y].Type
                    });
                }
            }
            return list;
        }

        public void GenerateNextPopulation()
        {
            CountNeighbours();
            UpdatePopulation();
        }

        private void CountNeighbours()
        {
            var maxI = _grid.GetUpperBound(0);
            var maxJ = _grid.GetUpperBound(1);

            for (var x = 0; x <= maxI; x++)
            {
                for (var y = 0; y <= maxJ; y++)
                {
                    var cell = _grid[x, y];
                    cell.NumberOfNeighbours = 0;

                    int previousX = x > 0 ? x - 1 : maxI;
                    int nextX = x < maxI ? x + 1 : 0;
                    int previousY = y > 0 ? y - 1 : maxJ;
                    int nextY = y < maxJ ? y + 1 : 0;

                    // check all neighbours, clock-wise
                    if (_grid[previousX, previousY].IsAlive()) cell.NumberOfNeighbours++;
                    if (_grid[previousX, y].IsAlive()) cell.NumberOfNeighbours++;
                    if (_grid[previousX, nextY].IsAlive()) cell.NumberOfNeighbours++;
                    if (_grid[x, nextY].IsAlive()) cell.NumberOfNeighbours++;
                    if (_grid[nextX, nextY].IsAlive()) cell.NumberOfNeighbours++;
                    if (_grid[nextX, y].IsAlive()) cell.NumberOfNeighbours++;
                    if (_grid[nextX, previousY].IsAlive()) cell.NumberOfNeighbours++;
                    if (_grid[x, previousY].IsAlive()) cell.NumberOfNeighbours++;
                }
            }
        }

        private void UpdatePopulation()
        {
            foreach (var cell in _grid)
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
