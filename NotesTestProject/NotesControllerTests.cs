using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace NotesTestProject
{
    public class NotesControllerTests
    {
        [Fact]
        public void GetAllNotes_ReturnsOkResult()
        {
            // Arrange
            var noteRepositoryMock = new Mock<INoteService>();
            noteRepositoryMock.Setup(repo => repo.GetNotes()).Returns(new List<NoteDto>());
            var controller = new NotesController(noteRepositoryMock.Object);

            // Act
            var result = controller.GetNotes();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetNoteById_WithValidId_ReturnsOkResult()
        {
            // Arrange
            int noteId = 1;
            var noteRepositoryMock = new Mock<INoteService>();
            var noteDto = new NoteDto
            {
                Title = "Test",
                Content = "Test"
            };

            noteRepositoryMock.Setup(repo => repo.GetNoteById(noteId)).Returns(noteDto);
            var controller = new NotesController(noteRepositoryMock.Object);

            // Act
            var result = controller.GetNoteById(noteId);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetNoteById_WithInvalidId_ReturnsNotFoundResult()
        {
            // Arrange
            int noteId = 1;
            var noteRepositoryMock = new Mock<INoteService>();

            noteRepositoryMock.Setup(repo => repo.GetNoteById(noteId)).Returns((NoteDto)null);
            var controller = new NotesController(noteRepositoryMock.Object);

            // Act
            var result = controller.GetNoteById(noteId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
    }
}