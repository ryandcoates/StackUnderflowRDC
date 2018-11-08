using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;
using System;

namespace StackUnderflowRDC.Business
{
    public class QuestionService
    {
        private readonly ApplicationDbContext _ctx;

        public QuestionService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public Question NewQuestion()
        {
         
        }

        public Question CloseQuestion(Question q, Response r)
        {
      
        }
    }
}
