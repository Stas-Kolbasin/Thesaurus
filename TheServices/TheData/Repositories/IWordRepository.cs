using TheData.Entities;

namespace TheData.Repositories
{
    public interface IWordRepository
    {
        void Create(Word word);

        Word Get(string @base);

        Word[] GetAll();
    }
}