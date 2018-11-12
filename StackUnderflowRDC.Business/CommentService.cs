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
	    private readonly DataContext _dataContext;

		public CommentService(ApplicationDbContext ctx, DataContext dataContext)
        {
            _ctx = ctx;
	        _dataContext = dataContext;

        }

        public List<Comment> GetAllComments()
        {
            return _dataContext.Comments.ToList();
        }

        public Comment GetCommentById(int id)
        {
            return _dataContext.Comments.Find(id);
        }

        public Comment GetCommentByResponseId(int id)
        {
            return _dataContext.Comments.First(q => q.ResponseId == id);
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


	        _dataContext.Comments.Add(q);
	        _dataContext.SaveChanges();

            return q;
        }

        public void UpVote(Comment c)
        {
            c.Score++;
            __dataContext.Comments.Update(c);
            __dataContext.SaveChanges();
        }
        public void DownVote(Comment c)
        {
            c.Score--;
            __dataContext.Comments.Update(c);
            __dataContext.SaveChanges();
        }

    }
}
