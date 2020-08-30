using TheServices.Models;

namespace TheServices.Services
{
    public interface IWordService
    {
        void Create(Word word);
        Word Get(string @base);
        Word[] GetAll();
    }
}