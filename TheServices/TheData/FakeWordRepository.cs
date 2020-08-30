using System.Collections.Generic;
using System.Linq;
using TheData.Exceptions;

namespace TheData
{
    public class FakeWordRepository : IWordRepository
    {
        private readonly Dictionary<string, WordEntity> _words = new Dictionary<string, WordEntity>();
        
        public void Create(WordEntity word)
        {
            if (_words.TryGetValue(word.Base, out var existingWord))
            {
                throw new RecordAlreadyExistsException<WordEntity>
                {
                    ExistingRecord = existingWord
                };
            }
            _words.Add(word.Base, word);
        }

        public WordEntity Get(string @base)
        {
            if(_words.TryGetValue(@base, out var result))
            {
                return result;
            }
            
            throw new RecordNotFoundException
            {
                RecordKey = @base
            };
        }

        public WordEntity[] GetAll()
        {
            return _words.Values.ToArray();
        }

        public void Edit(WordEntity wordEntity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(string @base)
        {
            throw new System.NotImplementedException();
        }
    }
}