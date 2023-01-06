using DotNetChallenge.Application;
using DotNetChallenge.Application.Features.Commands.CreateProduct;
using DotNetChallenge.Persistence;
using DotNetChallenge.Persistence.Middlewares;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddFluentValidation(opt =>
{
    opt.RegisterValidatorsFromAssemblyContaining<CreateProductCommandValidator>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// cors
builder.Services.AddCors();


// service registiration 
builder.Services.AddPersistenceRegistiration(builder.Configuration.GetConnectionString("MsSqlServer"));
builder.Services.AddApplicationRegistiration();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// cors
app.UseCors(x => x
    .SetIsOriginAllowed(origin => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());

app.UseHttpsRedirection();
app.UseRouting();
app.UseCustomException();
app.UseAuthorization();

app.MapControllers();

app.Run();
