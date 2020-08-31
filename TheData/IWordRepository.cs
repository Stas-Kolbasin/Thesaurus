using System.Threading.Tasks;

namespace TheData
{
    public interface IWordRepository
    {
        Task Create(WordEntity word);

        Task<WordEntity> Get(string @base);

        Task<WordEntity[]> GetAll();

        Task Edit(WordEntity wordEntity);

        Task Delete(string @base);
    }
}