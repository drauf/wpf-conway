using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Conway.Models;

namespace Conway.Service
{
    public static class LoadSaveService
    {
        private const int LoadSaveSlots = 10;

        private static Cell[][,] Grid { get; }
        public static List<LoadSaveSlot> LoadSlots { get; }
        public static List<LoadSaveSlot> SaveSlots { get; }

        static LoadSaveService()
        {
            LoadSlots = new List<LoadSaveSlot>();
            SaveSlots = new List<LoadSaveSlot>();
            for (var id = 1; id <= LoadSaveSlots; id++)
            {
                LoadSlots.Add(new LoadSaveSlot { Id = id, Name = $"Load {id}" });
                SaveSlots.Add(new LoadSaveSlot { Id = id, Name = $"Save {id}" });
            }
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
