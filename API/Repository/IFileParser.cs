using API.Models;

namespace API.Repository
{
    public interface IFileParser<T>
    {
        public IEnumerable<T> ParseFile(string filepath);
    }
}