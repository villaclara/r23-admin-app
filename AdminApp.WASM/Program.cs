using AdminApp.WASM;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(delegate (IServiceProvider sp) {
	return new HttpClient
	{
		//BaseAddress = new Uri("http://localhost:5117/")
		BaseAddress = new Uri("https://testwasmblazor.bsite.net/")
	};
});

await builder.Build().RunAsync();
