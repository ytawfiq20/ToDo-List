using System.Text.Json.Serialization;

using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

using ToDoList.Api.Data;
using ToDoList.Api.Repository;
using ToDoList.Api.Repository.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection"))
);

builder.Services.AddScoped<IDayLists, DayListsRepository>();
builder.Services.AddScoped<IListTasks, ListTasksRepository>();
builder.Services.AddScoped<INotes, NotesRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy=>
    policy.WithOrigins("https://localhost:7260")
    .AllowAnyMethod()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
