using TheData.Entities;

namespace TheData.Repositories
{
    public class FakeMeaningRepository : IMeaningRepository
    {
        public void Create(Meaning meaning)
        {
            throw new System.NotImplementedException();
        }

        public Meaning[] GetByWord(long wordId)
        {
            throw new System.NotImplementedException();
        }
    }
}