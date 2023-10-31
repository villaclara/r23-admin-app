using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Models.ViewModels;

namespace AdminApp.WASM.Application.Services
{
    public class NoteHandlerService : ICRUDService<NoteVM>
    {
        public Task<bool> DeleteItemFromURLAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task<NoteVM?> GetItemAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NoteVM>> GetItemsAsListAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostItemAsync(string url, NoteVM item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PutItemAsync(string url, NoteVM item)
        {
            throw new NotImplementedException();
        }
    }
}
