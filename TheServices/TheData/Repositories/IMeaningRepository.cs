using TheData.Entities;

namespace TheData.Repositories
{
    public interface IMeaningRepository
    {
        void Create(Meaning meaning);

        Meaning[] GetByWord(long wordId);
    }
}