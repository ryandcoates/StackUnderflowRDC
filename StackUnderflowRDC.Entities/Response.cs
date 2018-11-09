using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackUnderflowRDC.Entities
{
    public class Response
    {
        public int Id { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        [Required]
        [MinLength(25)]
        public string Body { get; set; }

        public string Author { get; set; }
        public DateTimeOffset PostedAt { get; set; }
        public int Score { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        public bool isAnswer { get; set; }
    }
}
