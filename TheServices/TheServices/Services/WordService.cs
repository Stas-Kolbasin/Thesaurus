using System;
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
            throw new System.NotImplementedException();
        }

        public Word[] GetAll()
        {
            throw new System.NotImplementedException();
        }
    }
}