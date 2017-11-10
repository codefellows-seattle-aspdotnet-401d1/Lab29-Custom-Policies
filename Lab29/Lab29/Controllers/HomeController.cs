using Lab29.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab29.Controllers
{
    public class HomeController : Controller
    {

        private readonly Lab29Context _context;

        public HomeController(Lab29Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.VideoGames.Where(c => c.ID > 0);
            return View(result.ToList());
        }
    }
        
}
