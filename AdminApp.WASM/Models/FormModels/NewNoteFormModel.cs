namespace AdminApp.WASM.Models.FormModels
{
	public class NewNoteFormModel
	{
		public bool IsDone { get; set; } = false;
		public DateTime NoteDate {  get; set; } = DateTime.Now;
		public string NoteText { get; set; } = "";
	}
}
