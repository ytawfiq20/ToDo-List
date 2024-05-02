using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using ToDoList.Client;
using ToDoList.Client.Service;
using ToDoList.Client.Service.IService;
using ToDoList.Shared.Entities;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7243/api/") });
//builder.Services.AddScoped(sp => new HttpClient {BaseAddress = new Uri("https://localhost:7243/api/") });

builder.Services.AddScoped<IDayLists, DayListsService>();
builder.Services.AddScoped<IListTasks, ListTasksService>();
builder.Services.AddScoped<ITaskNotes, TaskNotesService>();

await builder.Build().RunAsync();
