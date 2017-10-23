using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Conway.Models
{
    public static class LoadSaveState
    {
        public const int LoadSaveSlots = 10;
        private static Cell[][,] Grid { get; }

        static LoadSaveState()
        {
            Grid = new Cell[LoadSaveSlots + 1][,];
        }

        public static bool IsEmpty(int slot)
        {
            return Grid[slot] == null;
        }

        public static Cell[,] Load(int slot)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, Grid[slot]);
                memoryStream.Seek(0, SeekOrigin.Begin);
                return (Cell[,])binaryFormatter.Deserialize(memoryStream);
            }
        }

        public static void Save(int slot, Cell[,] grid)
        {
            using (var memoryStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, grid);
                memoryStream.Seek(0, SeekOrigin.Begin);
                Grid[slot] = (Cell[,])binaryFormatter.Deserialize(memoryStream);
            }
        }
    }
}
