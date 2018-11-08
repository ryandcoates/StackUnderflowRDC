using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;
using System;

namespace StackUnderflowRDC.Business
{
    public class QuestionService
    {
        private readonly DataContext _ctx;

        public QuestionService(DataContext ctx)
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
