using StackUnderflowRDC.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using StackUnderflowRDC.Data;

namespace StackUnderflowRDC.Business
{
    class CommentService
    {
        private readonly DataContext _ctx;

        public CommentService(DataContext ctx)
        {
            _ctx = ctx;
        }
        public Comment CreateComment(Comment newComment)
        {
            _ctx.Comments.Add(newComment);
            _ctx.SaveChanges();
            return newComment;
        }
    }
}
