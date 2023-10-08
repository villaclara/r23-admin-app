using AdminApp.WASM;
using AdminApp.WASM.Interfaces;
using AdminApp.WASM.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddScoped(delegate (IServiceProvider sp) {
//	return new HttpClient
//	{
//		//BaseAddress = new Uri("http://localhost:5117/")
//		BaseAddress = new Uri("https://testwasmblazor.bsite.net/")
//	};
//});

builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("https://testwasmblazor.bsite.net/") });

//builder.Services.AddScoped<IHttpCheckerService, HttpCheckerService>(sp =>
//{
//	var myservice = sp.GetService<HttpClient>();
//	return new HttpCheckerService("api/candle?view=full", "api/order", myservice);
//});

//builder.Services.AddScoped<IHttpCheckerService, HttpCheckerService>();

builder.Services.AddScoped<IHttpCheckerService, HttpCheckerService>(sp => new HttpCheckerService(sp.GetRequiredService<HttpClient>()));

await builder.Build().RunAsync();
