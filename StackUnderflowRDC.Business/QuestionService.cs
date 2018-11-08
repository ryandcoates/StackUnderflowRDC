using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StackUnderflowRDC.Business
{
    public class QuestionService
    {
        private readonly DataContext _ctx;

        public QuestionService(DataContext ctx)
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
            return _ctx.Questions.Where(q => q.AnswerId == id).First();
        }

        public Question NewQuestion(QuestionForCreation data)
        {
            Question q = new Question();
            q.PostedAt = new DateTimeOffset();
            q.Score = 0;
            q.Answered = false;
            q.Author = data.Author;
            q.Body = data.Body;
            q.Comments = new HashSet<Comment>();
            q.Responses = new HashSet<Response>();


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
