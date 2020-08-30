using System;
using System.Linq;
using TheData;
using TheData.Exceptions;
using TheServices.Models;
using TheServices.Utils;

namespace TheServices.Services
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _repository;

        public WordService(IWordRepository repository) =>
            _repository = repository;

        public void Create(Word word)
        {
            var wordEntity = word.ToEntity();
            try
            {
                _repository.Create(wordEntity);
            }
            catch (RecordAlreadyExistsException<WordEntity> e)
            {
                throw new RecordAlreadyExistsException<Word>(e)
                {
                    ExistingRecord = e.ExistingRecord.ToModel()
                };
            }
        }

        public Word Get(string @base)
        {
            return _repository.Get(@base).ToModel();
        }

        public Word[] GetAll()
        {
            return _repository.GetAll()
                .Select(entity => entity.ToModel())
                .ToArray();
        }
    }
}