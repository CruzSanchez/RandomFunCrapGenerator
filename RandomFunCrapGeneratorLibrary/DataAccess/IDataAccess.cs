using RandomFunCrapGeneratorLibrary.Models;

namespace RandomFunCrapGeneratorLibrary.DataAccess
{
    public interface IDataAccess
    {
        public IEnumerable<T> LoadData<T>(string filePath) where T : Activity;
        public void SaveData<T>(IEnumerable<T> values, string filePath) where T : Activity;
    }
}
