using RandomFunCrapGeneratorLibrary.Models;
using System.Text.Json;

namespace RandomFunCrapGeneratorLibrary.DataAccess
{
    public class DataAccess : IDataAccess
    {
        public IEnumerable<T> LoadData<T>(string filePath) where T : Activity
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The data file could not be found. Please ensure the data file exists and try again");
            }

            string fileData = File.ReadAllText(filePath);

            try
            {
                List<T> data = JsonSerializer.Deserialize<List<T>>(fileData) ?? new List<T>();

                return data;
            }
            catch (JsonException)
            {
                throw;
            }

        }

        public void SaveData<T>(IEnumerable<T> values, string filePath) where T : Activity
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            var saveData = JsonSerializer.Serialize(values, new JsonSerializerOptions() { WriteIndented = true });

            File.WriteAllText(filePath, saveData);
        }
    }
}
