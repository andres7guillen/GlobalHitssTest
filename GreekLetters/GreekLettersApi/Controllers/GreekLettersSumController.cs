using GreekLettersApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreekLettersApi.Controllers
{
    [Route("ws/[action]")]
    [ApiController]
    public class GreekLettersSumController : ControllerBase
    {
        private readonly Dictionary<string, List<int>> _dictionary;

        public GreekLettersSumController(Dictionary<string, List<int>> dictionary)
        {
            _dictionary = dictionary;
        }

        [HttpPost("question")]
        public async Task<IActionResult> question([FromBody] QuestionRequestModel model)
        {
            /*
            {
              "letters": [
                "Alpha","Beta","Omega"
              ],
              "range": [
                1,15
              ]
            }
             */
            int firstNumberRange = model.Range.First();
            int lastNumberRange = model.Range.Last();
            if (firstNumberRange >= lastNumberRange)
            {
                return BadRequest("Second number must be greater than first number");
            }
            //Dentro del endpoint 'question' se le suministrará un rango de números y
            //una lista de letras griegas.
            int totalSumLettersInDictionary = 0;
            foreach (var letter in model.Letters)
            {
                if (_dictionary.ContainsKey(letter))
                {
                    var numbers = _dictionary[letter];
                    int firstNumber = numbers.First();
                    int lastNumber = numbers.Last();
                    numbers.RemoveAt(0);
                    numbers.RemoveAt(numbers.Count - 1);
                    foreach (int num in numbers)
                    {
                        if (num >= firstNumberRange && num <= lastNumberRange)
                        {
                            totalSumLettersInDictionary = totalSumLettersInDictionary + num;
                        }
                    }

                }
            }

            return Ok(totalSumLettersInDictionary);
        }

        [HttpPost("problem")]
        public async Task<IActionResult> problem(Dictionary<string, List<int>> dictionary)
        {
            /* 
            {
                "Alpha": [1, 2, 3, 4, 5],
                "Beta": [6, 7, 8, 9, 10],
                "Omega": [11, 12, 13, 14, 15]
            }
             */

            //Al llamar al endpoint 'problem' se le suministrará un diccionario de letras griegas,
            //en el cual cada una va a tener asignada una lista de números enteros.
            foreach (var (key, value) in dictionary)
            {
                _dictionary[key] = value;
            }
            return Ok(_dictionary);
        }
    }
}
