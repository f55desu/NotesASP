using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class NoteService : INoteService
{
    private List<NoteDto> _notes = new List<NoteDto>();
    private int _nextNoteId = 1;

    public NoteService()
    {
    }

    public IEnumerable<NoteDto> GetNotes()
    {
        return _notes;
    }

    public NoteDto GetNoteById(int id)
    {
        return _notes.FirstOrDefault(n => n.Id == id);
    }

    public NoteDto CreateNote(NoteDto noteDto)
    {
        var note = new NoteDto
        {
            Id = _nextNoteId++,
            Title = noteDto.Title,
            Content = noteDto.Content,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _notes.Add(note);
        return note;
    }

    public NoteDto UpdateNote(int id, NoteDto noteDto)
    {
        var existingNote = _notes.FirstOrDefault(n => n.Id == id);

        if (existingNote != null)
        {
            existingNote.Title = noteDto.Title;
            existingNote.Content = noteDto.Content;
            existingNote.UpdatedAt = DateTime.UtcNow;
        }

        return existingNote;
    }

    public bool DeleteNote(int id)
    {
        var noteToDelete = _notes.FirstOrDefault(n => n.Id == id);

        if (noteToDelete != null)
        {
            _notes.Remove(noteToDelete);
            return true;
        }

        return false;
    }
}
