using System.Collections.Generic;
using TheData.Entities;
using TheData.Exceptions;

namespace TheData.Repositories
{
    public class FakeWordRepository : IWordRepository
    {
        private readonly Dictionary<string, Word> _words = new Dictionary<string, Word>();
        
        public void Create(Word word)
        {
            if (_words.TryGetValue(word.Base, out var existingWord))
            {
                throw new RecordAlreadyExistsException<Word>
                {
                    ExistingRecord = existingWord
                };
            }
            _words.Add(word.Base, word);
        }

        public Word Get(string @base)
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

        public Word[] GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}