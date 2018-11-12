using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackUnderflowRDC.Business
{
    class ResponseService
    {
        private readonly ApplicationDbContext _ctx;

        public ResponseService(ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Response> GetAllResponses()
        {
            return _ctx.Responses.ToList();
        }

        public Response GetResponseById(int id)
        {
            return _ctx.Responses.Find(id);
        }

        public Response NewResponse(Response data)
        {
            Response r = new Response
            {
                PostedAt = new DateTimeOffset(),
                Score = 0,
                Author = data.Author,
                Body = data.Body,
            };


            _ctx.Responses.Add(r);
            _ctx.SaveChanges();

            return r;
        }

        public void UpVote(Response r)
        {
            r.Score++;
            _ctx.Responses.Update(c);
            _ctx.SaveChanges();
        }
        public void DownVote(Response r)
        {
            r.Score--;
            _ctx.Responses.Update(r);
            _ctx.SaveChanges();
        }

    }
}
