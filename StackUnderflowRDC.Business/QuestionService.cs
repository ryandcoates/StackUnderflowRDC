using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace StackUnderflowRDC.Business
{
    public class QuestionService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly UserManager<IdentityUser> _um;

        public QuestionService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Question> GetAllQuestions()
        {
            return _ctx.Questions.ToList();
        }

        public Question GetQuestionById(int id)
        {
            return _ctx.Questions.Find(id);
        }

        public Question GetQuestionByResponseId(int id)
        {
            return _ctx.Questions.First(q => q.AnswerId == id);
        }

        public Question NewQuestion(QuestionForCreation data)
        {
            Question q = new Question
            {
                PostedAt = new DateTimeOffset(),
                Score = 0,
                UserId = data.UserId,
		        Answered = false,
		        Author = data.Author,
		        Body = data.Body,
		        Comments = new HashSet<Comment>(),
		        Responses = new HashSet<Response>()
	        };


	        _ctx.Questions.Add(q);
            _ctx.SaveChanges();

            return q;
        }

        public void CloseQuestion(Response r)
        {
            var q = GetQuestionByResponseId(r.Id);
            q.Answered = true;
            q.AnswerId = r.Id;
            r.isAnswer = true;


        }
    }
}
