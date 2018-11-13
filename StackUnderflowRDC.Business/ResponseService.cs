using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackUnderflowRDC.Business
{
    public class ResponseService
    {
        private readonly ApplicationDbContext _ctx;
        private readonly DataContext _dataContext;

        public ResponseService(ApplicationDbContext ctx, DataContext dataContext)
        {
            _ctx = ctx;
            _dataContext = dataContext;
        }

        public List<Response> GetAllResponses()
        {
            return _dataContext.Responses.ToList();
        }

        public Response GetResponseById(int id)
        {
            return _dataContext.Responses.Find(id);
        }

        public Response NewResponse(Response data)
        {
            Response r = new Response
            {
                PostedAt = DateTimeOffset.Now,
                Score = 0,
				QuestionId = 1,
                Author = data.Author,
                Body = data.Body,
                QuestionId = data.QuestionId,
            };


            _dataContext.Responses.Add(r);
            _dataContext.SaveChanges();

            return r;
        }

        public void UpVote(Response r)
        {
            r.Score++;
            _dataContext.Responses.Update(r);
            _dataContext.SaveChanges();
        }
        public void DownVote(Response r)
        {
            r.Score--;
            _dataContext.Responses.Update(r);
            _dataContext.SaveChanges();
        }

    }
}
