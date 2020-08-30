namespace TheData
{
    public interface IWordRepository
    {
        void Create(WordEntity word);

        WordEntity Get(string @base);

        WordEntity[] GetAll();

        void Edit(WordEntity wordEntity);

        void Delete(string @base);
    }
}