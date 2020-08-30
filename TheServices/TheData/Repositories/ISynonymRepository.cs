using TheData.Entities;

namespace TheData.Repositories
{
    public interface ISynonymRepository
    {
        void Create(Synonym synonym);

        Synonym[] GetByMeaning(long meaningId);
    }
}