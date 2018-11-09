using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace StackUnderflowRDC.Business
{
    public class CommentService
    {
        private readonly ApplicationDbContext _ctx;

        public CommentService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Comment> GetAllComments()
        {
            return _ctx.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _ctx.Comments.Find(id);
        }

        public Comment GetCommentByResponseId(int id)
        {
            return _ctx.Comments.First(q => q.ResponseId == id);
        }

        public Comment NewComment(Comment data)
        {
	        Comment q = new Comment
	        {
		        PostedAt = new DateTimeOffset(),
		        Score = 0,
		        Author = data.Author,
		        Body = data.Body,
		        ResponseId = data.ResponseId
	        };


	        _ctx.Comments.Add(q);
            _ctx.SaveChanges();

            return q;
        }

    }
}
