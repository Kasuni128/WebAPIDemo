var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection(); //Middle Ware

app.UseRouting();//Middle Ware

app.UseAuthentication();//Middle Ware

app.UseAuthorization(); //Middle Ware

app.MapControllers();

//Minimal API Endpoints

/*app.MapGet("/laptop", () =>
{
    return $"Reading all the laptop";
});

app.MapGet("/laptop/{id}", (int id) =>
{
    return $"Reading the laptop with id {id}";
});

app.MapPost("/laptop", () =>
{
    return $"Creating a new laptop";
});

app.MapPut("/laptop/{id}", (int id) =>
{
    return $"Updating the laptop with id {id}";
});

app.MapDelete("/laptop/{id}", (int id) =>
{
    return $"Deleting the laptop with id {id}";
});*/

app.Run();
