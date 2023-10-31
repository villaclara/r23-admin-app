namespace AdminApp.WASM.Models.ViewModels
{
    public class NoteVM
    {
        public int Id { get; set; }
        public bool IsDone { get; set; }
        public string NoteText { get; set; } = null!;
        public DateOnly NoteDate { get; set; }
    }
}
