using CafeEmpApi.Data;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000", "https://Venkatesan.azurestaticapps.net");
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.MapGet("/get-all-Employees", async () => await Employees.GetEmployeesAsync())
    .WithTags("Employees Endpoints");

app.MapGet("/get-Employee-by-id/{EmployeeId}", async (int EmployeeId) =>
{
    Employee EmployeeToReturn = await Employees.GetEmployeeByIdAsync(EmployeeId);

    if (EmployeeToReturn != null)
    {
        return Results.Ok(EmployeeToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Employees Endpoints");

app.MapPost("/create-Employee", async (Employee EmployeeToCreate) =>
{
    bool createSuccessful = await Employees.CreateEmployeeAsync(EmployeeToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Employees Endpoints");

app.MapPut("/update-Employee", async (Employee EmployeeToUpdate) =>
{
    bool updateSuccessful = await Employees.UpdateEmployeeAsync(EmployeeToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Employees Endpoints");

app.MapDelete("/delete-Employee-by-id/{EmployeeId}", async (int EmployeeId) =>
{
    bool deleteSuccessful = await Employees.DeleteEmployeeAsync(EmployeeId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Employees Endpoints");


app.MapGet("/get-all-Cafes", async () => await Cafes.GetCafesAsync())
    .WithTags("Cafes Endpoints");

app.MapGet("/get-Cafe-by-id/{CafeId}", async (int CafeId) =>
{
    Cafe CafeToReturn = await Cafes.GetCafeByIdAsync(CafeId);

    if (CafeToReturn != null)
    {
        return Results.Ok(CafeToReturn);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Cafes Endpoints");

app.MapPost("/create-Cafe", async (Cafe CafeToCreate) =>
{
    bool createSuccessful = await Cafes.CreateCafeAsync(CafeToCreate);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Cafes Endpoints");

app.MapPut("/update-Cafe", async (Cafe CafeToUpdate) =>
{
    bool updateSuccessful = await Cafes.UpdateCafeAsync(CafeToUpdate);

    if (updateSuccessful)
    {
        return Results.Ok("Update successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Cafes Endpoints");

app.MapDelete("/delete-Cafe-by-id/{CafeId}", async (int CafeId) =>
{
    bool deleteSuccessful = await Cafes.DeleteCafeAsync(CafeId);

    if (deleteSuccessful)
    {
        return Results.Ok("Delete successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Cafes Endpoints");

app.Run();