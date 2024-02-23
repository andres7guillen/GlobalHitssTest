using GreekLettersDomain.DTO;
using GreekLettersDomain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreekLettersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreekLettersAPIController : ControllerBase
    {
        private readonly IProblemService _problemService;
        private readonly IQuestionService _questionService;

        public GreekLettersAPIController(IProblemService problemService, IQuestionService questionService)
        {
            _problemService = problemService;
            _questionService = questionService;
        }

        [HttpPost("question")]
        public async Task<IActionResult> question([FromBody] QuestionRequestDTO model) 
        { 
            var result = await _questionService.question(model);
            return Ok(result);
        }

        [HttpPost("problem")]
        public async Task<IActionResult> problem(Dictionary<string, List<int>> dictionary) 
        { 
            var result = await _problemService.problem(dictionary);
            return Ok(result);
        }

    }
}
