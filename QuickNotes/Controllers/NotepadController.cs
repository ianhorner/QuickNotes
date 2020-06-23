using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickNotes.Models;

namespace QuickNotes.Controllers
{
    public class NotepadController : Controller
    {
        private readonly NoteDataContext _db;
        public NotepadController(NoteDataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, Route("Save")]
        public IActionResult Save(Note note)
        {
            note.LastUpdated = DateTime.Now;

            if (!String.IsNullOrWhiteSpace(note.Title) && !String.IsNullOrWhiteSpace(note.Body))
            {
                _db.Notes.Add(note);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Notepad");
        }

        [HttpPost, Route("LoadNewNote")]
        public IActionResult LoadNewNote(Note note)
        {
            return RedirectToAction("Index", "QuickNotes");
        }

        public IActionResult LoadExistingNote()
        {
            return RedirectToAction("Index", "Notepad");
        }
    }
}