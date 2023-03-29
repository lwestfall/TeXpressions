using TeXpressions.Api.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/", (TeXpressionRequest request) => Results.Ok(new TeXpressionResponse(request.InputLatex)));

app.Run();
