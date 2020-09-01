﻿using System.Linq;
using System.Threading.Tasks;
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

        public async Task Create(Word word)
        {
            var wordEntity = word.ToEntity();
            await _repository.Create(wordEntity);
        }

        public async Task<Word> Get(string @base)
        {
            return (await _repository.Get(@base)).ToModel();
        }

        public async Task<Word[]> GetAll()
        {
            return (await _repository.GetAll())
                .Select(entity => entity.ToModel())
                .ToArray();
        }
    }
}