using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab29.Models;
using Microsoft.AspNetCore.Authorization;

namespace Lab29.Controllers
{
    
    public class VideoGamesController : Controller
    {
        private readonly Lab29Context _context;

        public VideoGamesController(Lab29Context context)
        {
            _context = context;
        }

        // GET: VideoGames
        public async Task<IActionResult> Index()
        {
            return View(await _context.VideoGames.ToListAsync());
        }

        // GET: VideoGames/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGames = await _context.VideoGames
                .SingleOrDefaultAsync(m => m.ID == id);
            if (videoGames == null)
            {
                return NotFound();
            }

            return View(videoGames);
        }

        // GET: VideoGames/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VideoGames/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Rating,Description,IsReleased")] VideoGames videoGames)
        {
            if (ModelState.IsValid)
            {
                _context.Add(videoGames);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(videoGames);
        }

        // GET: VideoGames/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGames = await _context.VideoGames.SingleOrDefaultAsync(m => m.ID == id);
            if (videoGames == null)
            {
                return NotFound();
            }
            return View(videoGames);
        }

        // POST: VideoGames/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Rating,Description,IsReleased")] VideoGames videoGames)
        {
            if (id != videoGames.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(videoGames);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoGamesExists(videoGames.ID))
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
            return View(videoGames);
        }

        // GET: VideoGames/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var videoGames = await _context.VideoGames
                .SingleOrDefaultAsync(m => m.ID == id);
            if (videoGames == null)
            {
                return NotFound();
            }

            return View(videoGames);
        }

        // POST: VideoGames/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var videoGames = await _context.VideoGames.SingleOrDefaultAsync(m => m.ID == id);
            _context.VideoGames.Remove(videoGames);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoGamesExists(int id)
        {
            return _context.VideoGames.Any(e => e.ID == id);
        }
    }
}
