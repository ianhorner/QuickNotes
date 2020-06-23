using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickNotes.Models;

namespace QuickNotes.Controllers
{
    public class QuickNotesController : Controller
    {
        private readonly NoteDataContext _db;
        public QuickNotesController(NoteDataContext db)
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
                if (note.Id == 0) // If note is new
                {
                    _db.Notes.Add(note);
                }
                else // else if note is existing
                {
                    _db.Notes.Update(note);
                }
                
                _db.SaveChanges();
            }
            else
            {
                // TODO display error saying you gotta input values
            }

            return RedirectToAction("Index", "QuickNotes");
        }

        public IActionResult LoadNewNote(Note note)
        {
            return View("Notepad");
        }

        public IActionResult LoadExistingNote()
        {
            Note note = _db.Notes.OrderByDescending(x => x.LastUpdated).First();

            return View("Notepad", note);
        }
    }
}