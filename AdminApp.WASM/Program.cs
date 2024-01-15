using AdminApp.WASM;
using AdminApp.WASM.Application.Interfaces;
using AdminApp.WASM.Application.Services;
using AdminApp.WASM.Models.ViewModels;
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
		BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAdress")!)
		//BaseAddress = new Uri("https://testroad.bsite.net/")
		//BaseAddress = new Uri("https://2eb9-217-196-161-189.ngrok-free.app")
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

builder.Services.AddScoped<ICRUDService<CategoryVM>, CRUDService<CategoryVM>>();
builder.Services.AddScoped<CategoryHandlerService>();

builder.Services.AddScoped<ICRUDService<NoteVM>, CRUDService<NoteVM>>();
builder.Services.AddScoped<NoteHandlerService>();

builder.Services.AddScoped<ICRUDService<ExpenseVM>, CRUDService<ExpenseVM>>();
builder.Services.AddScoped<ExpenseHandlerService>();

builder.Services.AddScoped<IImageUploader, MultipartDataContent_ImageUploader>();

// navigation
builder.Services.AddScoped<INavigation, NavManagerNavigationService>();

// candle image cache
builder.Services.AddSingleton<CandleImageCacheService>();


var app = builder.Build();


await app.RunAsync();
