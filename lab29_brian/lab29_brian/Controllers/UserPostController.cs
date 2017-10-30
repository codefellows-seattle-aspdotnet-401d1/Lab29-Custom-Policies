using lab29_brian.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace lab29_brian.Controllers
{
    [Authorize]
    public class UserPostController : Controller
    {
        private readonly lab29_brianContext _context;

        public UserPostController(lab29_brianContext context)
        {
            _context = context;
        }

        // GET: UserPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.UserPost.ToListAsync());
        }

        // GET: UserPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPost = await _context.UserPost
                .SingleOrDefaultAsync(m => m.UserPostID == id);
            if (userPost == null)
            {
                return NotFound();
            }

            return View(userPost);
        }

        // GET: UserPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: UserPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserPostID,PostContent,Picture,GeoLocation")] UserPost userPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(userPost);
        }

        // GET: UserPosts/Edit/5
        [Authorize(Policy = "Admin Only")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPost = await _context.UserPost.SingleOrDefaultAsync(m => m.UserPostID == id);
            if (userPost == null)
            {
                return NotFound();
            }
            return View(userPost);
        }

        // POST: UserPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Admin Only")]
        public async Task<IActionResult> Edit(int id, [Bind("UserPostID,PostContent,Picture,GeoLocation")] UserPost userPost)
        {
            if (id != userPost.UserPostID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserPostExists(userPost.UserPostID))
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
            return View(userPost);
        }

        // GET: UserPosts/Delete/5
        [Authorize(Policy = "Brians Only")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userPost = await _context.UserPost
                .SingleOrDefaultAsync(m => m.UserPostID == id);
            if (userPost == null)
            {
                return NotFound();
            }

            return View(userPost);
        }

        // POST: UserPosts/Delete/5
        [Authorize(Policy = "Brians Only")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userPost = await _context.UserPost.SingleOrDefaultAsync(m => m.UserPostID == id);
            _context.UserPost.Remove(userPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserPostExists(int id)
        {
            return _context.UserPost.Any(e => e.UserPostID == id);
        }
    }
}
