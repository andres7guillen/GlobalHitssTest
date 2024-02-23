using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekLettersDomain.Services
{
    public interface IProblemService
    {
        Task<bool> problem(Dictionary<string, List<int>> dictionary);
    }
}
