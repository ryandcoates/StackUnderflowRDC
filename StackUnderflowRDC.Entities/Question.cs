using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StackUnderflowRDC.Entities
{
    public class Question
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(50)]
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTimeOffset PostedAt { get; set; }
        public int AnswerId { get; set; }
        public int Score { get; set; }
        public bool Answered { get; set; }
        public ICollection<Response> Responses { get; set; }

    }
}
