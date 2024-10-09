var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => @"<!DOCTYPE html>
<html>
<head>
    <title>My First HTML Page</title>
</head>
<body>
    <h1>Hello, World!</h1>
    <p>This is my first HTML page.</p>
</body>
</html>");

app.Run();
