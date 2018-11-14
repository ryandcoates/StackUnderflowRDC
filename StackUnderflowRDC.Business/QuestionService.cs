using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StackUnderflowRDC.Entities.DTO;

namespace StackUnderflowRDC.Business
{
    public class QuestionService
    {
        private readonly ApplicationDbContext _ctx;
	    private readonly DataContext _dataContext;

        public QuestionService(ApplicationDbContext ctx, DataContext dataContext)
        {
            _ctx = ctx;
	        _dataContext = dataContext;
		}

        public List<Question> GetAllQuestions()
        {
            return _dataContext.Questions.ToList();
        }

        public QuestionDto GetQuestionById(int id)
        {
	        var taco = _dataContext.Questions.Where(x => x.Id == id)
		        .GroupJoin(_dataContext.Responses, x => x.Id, response => response.QuestionId, (question, responses) => new QuestionDto
		        {
			        Question = question,
			        Responses = responses.GroupJoin(_dataContext.Comments, response => response.Id, comment => comment.ResponseId, (response, comments) => new ResponseDto
			        {
				        Response = response,
				        Comments = comments.ToList()
			        }).ToList()
		        }).FirstOrDefault();

	        return taco;
        }

        public Question GetQuestionByResponseId(int id)
        {
            return _dataContext.Questions.First(q => q.AnswerId == id);
        }

        public Question NewQuestion(Question data)
        {
	        Question q = new Question
	        {
		        PostedAt = DateTimeOffset.Now,
		        Score = 0,
		        Answered = false,
		        Author = data.Author,
		        Body = data.Body,
		        Responses = new HashSet<Response>(),
	        };


	        _dataContext.Questions.Add(q);
	        _dataContext.SaveChanges();

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
