using Supabase;
using Uplifted.DataAccessAPI.Contracts;
using Uplifted.DataAccessAPI.Controllers;
using Uplifted.DataAccessAPI.Extensions;
using Uplifted.DataAccessAPI.Models;

var builder = WebApplication.CreateBuilder(args);

//Add Service Dependencies
builder.AddDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

//endpoint registration
app.AddUserEndpoints();
app.AddUserToRoleEndpoints();

//app configuration
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
