using AnimalClinicAPI.Controller;
using AnimalClinicAPI.Service;
using AnimalClinicAPI.Service.Procedure_Animal;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddScoped<DBAnimalInterface, DbAnimalAnimalService>();
builder.Services.AddScoped<DBOwnerInterface, DBOwnerService>();
builder.Services.AddScoped<DBProcedureInterface, DBProcedureService>();
builder.Services.AddScoped<DBProcedureAnimalInterface, DBProcedureAnimalService>();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
