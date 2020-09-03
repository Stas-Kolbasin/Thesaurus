using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheData.Exceptions;
using TheServices.Models;
using TheServices.Services;

namespace TheApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {
        private readonly IWordService _wordService;

        public WordController(IWordService wordService) =>
            _wordService = wordService;
        
        [HttpGet]
        public async Task<string[]> GetAll()
        {
            return await _wordService.GetAll();
        }

        [HttpGet]
        [Route("{base}")]
        public async Task<ActionResult<Word>> Get(string @base)
        {
            try
            {
                return await _wordService.Get(@base);
            }
            catch (WordNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Upsert(Word word)
        {
            if (string.IsNullOrWhiteSpace(word.Base))
                return BadRequest("Nonono, please enter a word.");
                
            await _wordService.Save(word);
            return Ok();
        }
    }
}