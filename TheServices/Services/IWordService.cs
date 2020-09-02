using System.Threading.Tasks;
using TheServices.Models;

namespace TheServices.Services
{
    public interface IWordService
    {
        Task Save(Word word);
        Task<Word> Get(string @base);
        Task<string[]> GetAll();
    }
}