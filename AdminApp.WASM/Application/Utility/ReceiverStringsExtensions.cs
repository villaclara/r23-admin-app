namespace AdminApp.WASM.Application.Utility
{
	public static class ReceiverStringsExtensions
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


		public static string DisplayPhoneNumberWithDashes(this string phonenumber)
		{
			var str = phonenumber.Insert(3, "-");
			str = str.Insert(7, "-");
			str = str.Insert(10, "-");

			return str;
		}
	}
}
