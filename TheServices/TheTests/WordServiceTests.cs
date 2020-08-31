using System.Linq;
using System.Threading.Tasks;
using TheData;
using TheData.Exceptions;
using TheServices.Enums;
using TheServices.Models;
using TheServices.Services;
using TheServices.Utils;
using Xunit;

namespace TheTests
{
    public class WordServiceTests
    {
        private readonly IWordService _wordService;
        private readonly MemoryWordRepository _repository;

        public WordServiceTests()
        {
            _repository = new MemoryWordRepository();
            _wordService = new WordService(_repository);
        }
        
        [Fact]
        public async Task CanCreateWord()
        {
            var word = GetNewWord();
            await _wordService.Create(word);

            var entity = await _repository.Get(word.Base);
            Assert.Equal(word.Base, entity.Base);
        }

        [Fact]
        public async Task CannotCreateExistingWord()
        {
            string @base = "duplicate";
            await ArrangeWord(@base);
            
            Word duplicate = new Word()
            {
                Base = @base
            };

            await Assert.ThrowsAsync<WordAlreadyExistsException>(
                () => _wordService.Create(duplicate)
            );
        }

        [Fact]
        public async Task CanGetExistingWord()
        {
            string @base = "stash";

            await ArrangeWord(@base);

            var word = await _wordService.Get(@base);
            Assert.Equal(@base, word.Base);
        }

        [Fact]
        public async Task IfWordNotExistsThrowException()
        {
            await Assert.ThrowsAsync<WordNotFoundException>(
                () => _wordService.Get("tnetennba")
            );
        }

        [Fact]
        public async Task IfNoWordsReturnEmptyArray()
        {
            var words = await _wordService.GetAll();
            Assert.Empty(words);
        }
        
        [Fact]
        public async Task CanGetAllWords()
        {
            Task.WaitAll(
                ArrangeWord("first"),
                ArrangeWord("second")
            );

            var actualWords = (await _wordService.GetAll())
                .OrderBy(w => w.Base);

            Assert.Collection(
                actualWords,
                first => Assert.Equal("first", first.Base),
                second => Assert.Equal("second", second.Base)
            );
        }

        private Word GetNewWord(string @base = "word")
        {
            return new Word
            {
                Base = @base,
                Meanings = new []
                {
                    new Meaning
                    {
                        Description = "A pronounceable series of letters having a distinct meaning especially in a particular field",
                        PartOfSpeech = PartOfSpeech.Noun,
                        Synonyms = new []
                        {
                            new Synonym { Base = "expression"},
                            new Synonym { Base = "term"}
                        }
                    },
                    new Meaning
                    {
                        Description = "To convey in appropriate or telling terms",
                        PartOfSpeech = PartOfSpeech.Verb,
                        Synonyms = new []
                        {
                            new Synonym { Base = "articulate"},
                            new Synonym { Base = "express"},
                            new Synonym { Base = "formulate"}
                        }
                    }
                }
            };
        }

        private async Task ArrangeWord(string @base = "word")
        {
            var word = GetNewWord(@base);
            await _repository.Create(word.ToEntity());
        }
    }
}