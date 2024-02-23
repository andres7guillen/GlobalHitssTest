using GreekLettersDomain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekLettersDomain.Services
{
    public interface IQuestionService
    {
        Task<int> question(QuestionRequestDTO model);
    }
}
