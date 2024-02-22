using System.ComponentModel.DataAnnotations;

namespace GreekLettersApi.Models
{
    public class QuestionRequestModel
    {
        [Required(ErrorMessage = "Letters is required")]
        public List<string> Letters { get; set; }

        [Required(ErrorMessage = "Range is required")]
        [MaxLength(2, ErrorMessage = "Range must have 2 numbers only !!")]
        public List<int> Range { get; set; }
    }
}
