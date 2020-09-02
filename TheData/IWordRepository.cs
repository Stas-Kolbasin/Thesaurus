using System.Threading.Tasks;

namespace TheData
{
    public interface IWordRepository
    {
        Task Save(WordEntity word);

        Task<WordEntity> Get(string @base);

        Task<string[]> GetAll();

        Task Delete(string @base);
    }
}