﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackUnderflowRDC.Business;
using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;

namespace StackUnderflowRDC.Web.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;
	    private readonly UserManager<IdentityUser> _usr;
	    private readonly DataContext _dataContext;
	    private readonly QuestionService _questionService;
	    private readonly ResponseService _responseService;

		public QuestionsController(ApplicationDbContext context, UserManager<IdentityUser> usr, DataContext dataContext, QuestionService questionService, ResponseService responseService)
        {
            _context = context;
	        _dataContext = dataContext;
	        _usr = usr;
	        _questionService = questionService;
	        _responseService = responseService;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Questions.ToListAsync());
        }

        // GET: Questions/Details/5
        public IActionResult Details(int id)
        {
            //var question = await _dataContext.Questions
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (question == null)
            //{
            //    return NotFound();
            //}

            return View(_questionService.GetQuestionById(id));
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Body,Author,PostedAt,AnswerId,Score,Answered")] Question question)
        {
	        _questionService.NewQuestion(question);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _dataContext.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return View(question);
        }

	    public IActionResult ResponseCreate(int id)
	    {
		    return View();
	    }

	    [HttpPost]
	    [ValidateAntiForgeryToken]
	    public async Task<IActionResult> ResponseCreate([Bind("Id,QuestionId,Body,Author,PostedAt,Score,isAnswer")] Response response)
	    {
		    _responseService.NewResponse(response);
		    return View(response);

	    }

		// POST: Questions/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Body,Author,PostedAt,AnswerId,Score,Answered")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
	                _dataContext.Update(question);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _dataContext.Questions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _dataContext.Questions.FindAsync(id);
	        _dataContext.Questions.Remove(question);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _dataContext.Questions.Any(e => e.Id == id);
        }
    }
}
