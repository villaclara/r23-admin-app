namespace AdminApp.WASM.Application.Utility
{
	public static class PriceFormatExtensions
	{
		public static string ToZeroNumbersAfterComma(this decimal value) => value.ToString("N0");
	}
}
