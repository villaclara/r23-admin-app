using AdminApp.WASM;
using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Application.Services;
using AdminApp.WASM.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped(delegate (IServiceProvider sp)
{
	return new HttpClient
	{
		//BaseAddress = new Uri("http://localhost:5117/")
		BaseAddress = new Uri("https://testwasmblazor.bsite.net/")
	};
});

//builder.Services.AddScoped<HttpClient>(sp => new HttpClient { BaseAddress = new Uri("https://testwasmblazor.bsite.net/") });

//builder.Services.AddScoped<IHttpCheckerService, HttpCheckerService>(sp =>
//{
//	var myservice = sp.GetService<HttpClient>();
//	return new HttpCheckerService("api/candle?view=full", "api/order", myservice);
//});



//builder.Services.AddScoped<IGetItem<CandleFullVM>, GetItemService<CandleFullVM>>();
//builder.Services.AddScoped<IPostItem<CandleFullVM>, PostItemService<CandleFullVM>>();
//builder.Services.AddScoped<IPutItem<CandleFullVM>, PutItemService<CandleFullVM>>();
//builder.Services.AddScoped<IDeleteItem<CandleFullVM>, DeleteItemService<CandleFullVM>>();

builder.Services.AddScoped<ICRUDService<CandleFullVM>, CRUDService<CandleFullVM>>();
builder.Services.AddScoped<CandleHandlerService>();

builder.Services.AddScoped<ICRUDService<OrderVM>, CRUDService<OrderVM>>();
builder.Services.AddScoped<OrderHandlerService>();

await builder.Build().RunAsync();
