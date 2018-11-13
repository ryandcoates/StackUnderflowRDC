﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StackUnderflowRDC.Business;
using StackUnderflowRDC.Data;
using StackUnderflowRDC.Entities;

namespace StackUnderflowRDC.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;
	    private readonly DataContext _dataContext;
        private readonly CommentService _svc;
        private readonly UserManager<IdentityUser> _usr;

        public CommentsController(ApplicationDbContext context, DataContext dataContext, UserManager<IdentityUser> usr, CommentService commentService)
        {
            _context = context;
	        _dataContext = dataContext;
            _usr = usr;
            _svc = commentService;

        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Comments.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _dataContext.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResponseId,Body,Author,Score,PostedAt")] Comment comment)
        {
            try
            {
                var user = _usr.GetUserAsync(HttpContext.User).Result;
                comment.Author = user.UserName;

                if (ModelState.IsValid)
                {
                    _dataContext.Add(comment);
                    await _dataContext.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return View(comment);
        }

        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _dataContext.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResponseId,Body,Author,Score,PostedAt")] Comment comment)
        {
            if (id != comment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
	                _dataContext.Update(comment);
                    await _dataContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.Id))
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
            return View(comment);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _dataContext.Comments
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/5/Up
        [HttpPost]
        public async Task<IActionResult> UpVote(int id)
        {
            var c = _dataContext.Comments.Find(id);
            _svc.UpVote(c);
            _dataContext.Update(c);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Comments/5/Down
        [HttpPost]
        public async Task<IActionResult> DownVote(int id)
        {
            var c = _dataContext.Comments.Find(id);
            _svc.DownVote(c);
            _dataContext.Update(c);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _dataContext.Comments.FindAsync(id);
	        _dataContext.Comments.Remove(comment);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _dataContext.Comments.Any(e => e.Id == id);
        }
    }
}
