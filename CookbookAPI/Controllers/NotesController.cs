using System.Collections.Generic;
using CookbookAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CookbookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly NoteRepository noteRepository;
        public NotesController()
        {
            noteRepository = new NoteRepository();
        }

        [HttpGet]
        public IEnumerable<Note> Get()
        {
            return noteRepository.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Note note)
        {
            if (ModelState.IsValid)
                noteRepository.Add(note);
        }
    }
}