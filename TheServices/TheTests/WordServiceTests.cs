using TheServices.Models;
using TheServices.Services;
using Xunit;

namespace TheTests
{
    public class WordServiceTests
    {
        private readonly IWordService _wordService;

        public WordServiceTests()
        {
            _wordService = new WordService();
        }
        
        [Fact]
        public void CanCreateWord()
        {
            Word word = new Word()
            {
                Base = "word"
            };
            _wordService.Create(word);
            // Assert
        }

        [Fact]
        public void CannotCreateExistingWord()
        {
            string @base = "duplicate";
            
            // Setup existing word
            
            Word duplicate = new Word()
            {
                Base = @base
            };
            _wordService.Create(duplicate);
            // Assert error.
        }

        [Fact]
        public void CanGetExistingWord()
        {
            string @base = "stash";

            // Setup existing word

            var word = _wordService.Get(@base);
            Assert.Equal(@base, word.Base);
        }

        [Fact]
        public void IfWordNotExistsReturnNull()
        {
            var word = _wordService.Get("tnetennba");
            Assert.Null(word);
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
            // Setup some words

            var actualWords = _wordService.GetAll();
            
            // Assert collections are the same
        }
    }
}