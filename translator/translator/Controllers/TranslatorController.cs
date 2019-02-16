using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using translator.Contracts;
using translator.DTOs;
using translator.Models;
using translator.Services;

namespace translator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly TranslatorApiService TranslatorService;

        public TranslatorController(IUnitOfWork uow, TranslatorApiService service)
        {
            _uow = uow;
            TranslatorService = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WordDto dto)
        {
            var word = await _uow.Words.GetByFrom(dto.Word);
            if (word != null)
            {
                var serializeAsXml = _uow.TranslationResults.Create(word);
                _uow.Complete();
                return Ok(word);
            }
            else
            {
                var result = await TranslatorService.CallTranslatorApi(dto.Word);
                if (result != "word not in the dictionary yet")
                {
                    var newWord = new Word
                    {
                        From = dto.Word,
                        To = result,
                        TimeStamp = DateTime.UtcNow
                    };
                    var createdWord = await _uow.Words.Create(newWord);
                    _uow.Complete();
                    var serializeAsXml = _uow.TranslationResults.Create(createdWord.Entity);
                    _uow.Complete();
                    return Ok(createdWord.Entity);
                }
                else
                {
                    return BadRequest("word not in the dictionary yet");
                }
                
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string from)
        {
            var word = await _uow.Words.GetByFrom(from);
            if (word != null)
            {
                return Ok(word);
            }
            else
            {
                var result = await TranslatorService.CallTranslatorApi(from);
                return Ok(result);

            }
        }
    }
}