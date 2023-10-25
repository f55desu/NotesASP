using Microsoft.AspNetCore.Mvc;

public interface INoteRepository
{
    IEnumerable<NoteDto> GetNotes();
    NoteDto GetNoteById(int id);
    NoteDto CreateNote(NoteDto noteDto);
    NoteDto UpdateNote(int id, NoteDto noteDto);
    bool DeleteNote(int id);
}