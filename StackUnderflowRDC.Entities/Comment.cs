using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StackUnderflowRDC.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        [ForeignKey("Response")]
        public int ResponseId { get; set; }

        [Required]
        [MinLength(50)]
        public string Body { get; set; }
        public string Author { get; set; }
	    public int Score { get; set; }
		public DateTimeOffset PostedAt { get; set; }
    }
}
