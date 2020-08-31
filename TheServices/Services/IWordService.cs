using System.Threading.Tasks;
using TheServices.Models;

namespace TheServices.Services
{
    public interface IWordService
    {
        Task Create(Word word);
        Task<Word> Get(string @base);
        Task<Word[]> GetAll();
    }
}