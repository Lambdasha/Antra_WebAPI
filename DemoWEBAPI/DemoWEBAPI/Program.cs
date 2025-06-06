var builder = WebApplication.CreateBuilder(args);

// 1. Register Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. Enable the Swagger middleware (only in Development by default)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();                  // serves /swagger/v1/swagger.json
    app.UseSwaggerUI(c =>
    {
        // The first string is the JSON endpoint; the second is the UI title.
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Demo Todos API v1");
    });
}

// 3. Your existing endpoints (in-memory CRUD)
var todos = new List<Todo>();

app.MapGet("/api/todos", () =>
    Results.Ok(todos)
);

app.MapGet("/api/todos/{id}", (int id) =>
    todos.FirstOrDefault(t => t.Id == id) is { } t
        ? Results.Ok(t)
        : Results.NotFound()
);

app.MapPost("/api/todos", (Todo todo) =>
{
    todo.Id = todos.Count == 0 ? 1 : todos.Max(t => t.Id) + 1;
    todos.Add(todo);
    return Results.Created($"/api/todos/{todo.Id}", todo);
});

app.MapPut("/api/todos/{id}", (int id, Todo input) =>
{
    var idx = todos.FindIndex(t => t.Id == id);
    if (idx == -1) return Results.NotFound();
    input.Id = id;
    todos[idx] = input;
    return Results.NoContent();
});

app.MapDelete("/api/todos/{id}", (int id) =>
{
    var removed = todos.RemoveAll(t => t.Id == id);
    return removed == 0 ? Results.NotFound() : Results.NoContent();
});

app.Run();

record Todo
{
    public int    Id    { get; set; }
    public string Title { get; set; } = default!;
    public bool   Done  { get; set; }
}