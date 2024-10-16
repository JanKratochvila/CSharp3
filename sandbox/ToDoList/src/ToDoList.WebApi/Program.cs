var builder = WebApplication.CreateBuilder(args);
{
    //Configure DI
    builder.Services.AddControllers();
}
var app = builder.Build();
{
    //Configure middleware (HTTP request pipeline)
    app.MapControllers();
}

app.Run();
