using System.Threading.Tasks;

namespace TheData
{
    public interface IWordRepository
    {
        Task Save(WordEntity word);

        Task<WordEntity> Get(string @base);

        Task<WordEntity[]> GetAll();

        Task Delete(string @base);
    }
}