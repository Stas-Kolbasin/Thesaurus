using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheData.Exceptions;

namespace TheData
{
    public class MemoryWordRepository : IWordRepository
    {
        private readonly Dictionary<string, WordEntity> _words = new Dictionary<string, WordEntity>();

        public Task Save(WordEntity word)
        {
            _words[word.Base] = word;
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

        public Task<string[]> GetAll()
        {
            return Task.FromResult(
                _words.Keys
                    .OrderBy(key => key)
                    .ToArray()
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