using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreekLettersDomain.DTO
{
    public class QuestionRequestDTO
    {
        [Required(ErrorMessage = "Letters is required")]
        public List<string> Letters { get; set; }

        [Required(ErrorMessage = "Range is required")]
        [MaxLength(2, ErrorMessage = "Range must have 2 numbers only !!")]
        public List<int> Range { get; set; }
    }
}
