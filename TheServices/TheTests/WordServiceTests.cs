using System.Linq;
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
        private readonly FakeWordRepository _repository;

        public WordServiceTests()
        {
            _repository = new FakeWordRepository();
            _wordService = new WordService(_repository);
        }
        
        [Fact]
        public void CanCreateWord()
        {
            var word = GetNewWord();
            _wordService.Create(word);

            var entity = _repository.Get(word.Base);
            Assert.Equal(word.Base, entity.Base);
        }

        [Fact]
        public void CannotCreateExistingWord()
        {
            string @base = "duplicate";
            ArrangeWord(@base);
            
            Word duplicate = new Word()
            {
                Base = @base
            };

            Assert.Throws<RecordAlreadyExistsException<Word>>(
                () => _wordService.Create(duplicate)
            );
        }

        [Fact]
        public void CanGetExistingWord()
        {
            string @base = "stash";

            ArrangeWord(@base);

            var word = _wordService.Get(@base);
            Assert.Equal(@base, word.Base);
        }

        [Fact]
        public void IfWordNotExistsThrowException()
        {
            Assert.Throws<RecordNotFoundException>(
                () => _wordService.Get("tnetennba")
            );
        }

        [Fact]
        public void IfNoWordsReturnEmptyArray()
        {
            var words = _wordService.GetAll();
            Assert.Empty(words);
        }
        
        [Fact]
        public void CanGetAllWords()
        {
            ArrangeWord("first");
            ArrangeWord("second");

            var actualWords = _wordService.GetAll().OrderBy(w => w.Base);

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

        private void ArrangeWord(string @base = "word")
        {
            var word = GetNewWord(@base);
            _repository.Create(word.ToEntity());
        }
    }
}