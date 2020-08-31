using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheData.Exceptions;

namespace TheData
{
    public class MemoryWordRepository : IWordRepository
    {
        private readonly Dictionary<string, WordEntity> _words = new Dictionary<string, WordEntity>();

        public Task Create(WordEntity word)
        {
            if (_words.TryGetValue(word.Base, out _))
            {
                throw new WordAlreadyExistsException
                {
                    WordBase = word.Base
                };
            }
            _words.Add(word.Base, word);
            return Task.CompletedTask;
        }

        public Task<WordEntity> Get(string @base)
        {
            if(_words.TryGetValue(@base, out var result))
            {
                return Task.FromResult(result);
            }
            
            throw new WordNotFoundException
            {
                WordBase = @base
            };
        }

        public Task<WordEntity[]> GetAll()
        {
            return Task.FromResult(
                _words.Values.ToArray()
            );
        }

        public Task Edit(WordEntity wordEntity)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string @base)
        {
            throw new System.NotImplementedException();
        }
    }
}