namespace AdminApp.WASM.Application.Utility
{
	public static class ReceiverNameExtensions
	{
		public static string ToOnlyFirstLastName(this string fullname)
		{
			var names = fullname.TrimEnd().Split(' ');
			if (names.Length == 3)
			{
				return names[0] + " " + names[1];
			}

			return fullname;
		}
	}
}
