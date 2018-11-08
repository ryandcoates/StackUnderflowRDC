using StackUnderflowRDC.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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
            _ctx.Comment.Add(newComment);
            _ctx.SaveChanges();
            return newComment;
        }
    }
}
