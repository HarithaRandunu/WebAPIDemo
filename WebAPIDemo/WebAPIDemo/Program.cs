using DocumentFormat.OpenXml.Office2010.Excel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseAuthentication();

// Routing

// "/shirts"
/*app.MapGet("/shirts", () =>
{
    return "Reading all the shirts";
});

app.MapGet("/shirts/{id}", (int id) =>
{
    return $"Reading shirt with ID : {id}";
});

app.MapPost("/shirts", () =>
{
    return $"Creating a shirt.";
});

app.MapPut("/shirts/{id}", (int id) =>
{
    return $"Updating shirt with ID: {id}";
});

app.MapDelete("/shirts/{id}", (int id) =>
{
    return $"Deleting shirt with ID: {id}";
});
*/

app.MapControllers();

app.Run();


