using TheData.Entities;

namespace TheData.Repositories
{
    public class FakeSynonymRepository : ISynonymRepository
    {
        public void Create(Synonym synonym)
        {
            throw new System.NotImplementedException();
        }

        public Synonym[] GetByMeaning(long meaningId)
        {
            throw new System.NotImplementedException();
        }
    }
}