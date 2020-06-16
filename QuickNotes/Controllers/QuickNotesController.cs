using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuickNotes.Controllers
{
    public class QuickNotesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("save")]
        public IActionResult Save()
        {
            return View();
        }
    }
}