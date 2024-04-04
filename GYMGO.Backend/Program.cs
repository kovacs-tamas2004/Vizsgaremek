using GYMGO.Backend.Context;
using GYMGO.Backend.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuration
builder.Services.ConfigureCors();
builder.Services.ConfigureAssamblers();
builder.Services.ConfigureInMemoryContext();
builder.Services.ConfigureRepos();

var app = builder.Build();

// InMemory database data
using (var scope = app.Services.CreateAsyncScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<GymgoInMemoryContext>();

    // InMemory test data
    dbContext.Database.EnsureCreated();
}


    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Cors
app.UseCors("GYMGOCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
