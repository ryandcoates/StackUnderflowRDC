using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflowRDC.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
        public DateTimeOffset PostedAt { get; set; }
    }
}
