using System.ComponentModel.DataAnnotations;

namespace StackUnderflowRDC.Entities
{
    public class QuestionForCreation
    {

        [Required]
        [MinLength(50)]
        public string Body { get; set; }
        public string Author { get; set; }
        public bool Answered { get; set; }
        public string UserId { get; set; }

    }
}
