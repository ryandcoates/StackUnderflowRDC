using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflowRDC.Entities
{
    public class QuestionForCreation
    {

        [Required]
        [MinLength(50)]
        public string Body { get; set; }
        public string Author { get; set; }
        public bool Answered { get; set; }

    }
}
