using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize]
[Route("api/notes")]
[ApiController]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteRepository;

    public NotesController(INoteService noteRepository)
    {
        _noteRepository = noteRepository;
    }

    [HttpGet]
    public IActionResult GetNotes()
    {
        var notes = _noteRepository.GetNotes();
        return Ok(notes);
    }

    [HttpGet("{id}")]
    public IActionResult GetNoteById(int id)
    {
        var note = _noteRepository.GetNoteById(id);
        if (note == null)
        {
            return NotFound();
        }
        return Ok(note);
    }

    [HttpPost]
    public IActionResult CreateNote([FromBody] NoteDto noteDto)
    {
        if (noteDto == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var note = _noteRepository.CreateNote(noteDto);
        return CreatedAtAction(nameof(GetNoteById), new { id = note.Id }, note);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateNote(int id, [FromBody] NoteDto noteDto)
    {
        if (noteDto == null)
        {
            return BadRequest();
        }

        var updatedNote = _noteRepository.UpdateNote(id, noteDto);
        if (updatedNote == null)
        {
            return NotFound();
        }
        return Ok(updatedNote);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteNote(int id)
    {
        var deleted = _noteRepository.DeleteNote(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
