using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Models.ViewModels;

namespace AdminApp.WASM.Application.Services
{
    public class NoteHandlerService
    {
        private readonly ICRUDService<NoteVM> _noteService;
        public NoteHandlerService(ICRUDService<NoteVM> noteService)
        { 
            _noteService = noteService; 
        }

        public async Task<ICollection<NoteVM>> GetAllNotesAsync(string url)
        {
            return (ICollection<NoteVM>)await _noteService.GetItemsAsListAsync(url) ?? new List<NoteVM>();
        }

        public async Task<ICollection<NoteVM>> GetAllNotesByDateAsync(DateOnly dateOnly, string url)
        {
            var allNotes = await _noteService.GetItemsAsListAsync(url);
            var notes = allNotes.Where(n => n.NoteDate == dateOnly).ToList() ?? new List<NoteVM>();
            return notes;
        }

        public async Task<bool> AddNewNoteAsync(string url, NoteVM newNote)
        {
            return await _noteService.PostItemAsync(url, newNote);
        }

        public async Task<bool> UpdateNoteAsync(string url, NoteVM noteVM)
        {
            return await _noteService.PutItemAsync(url, noteVM);
        }
       
        public async Task<bool> DeleteNoteAsync(string url)
        {
            return await _noteService.DeleteItemFromURLAsync(url);
        }
    }
}
