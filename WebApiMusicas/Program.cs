using WebApiMusicas.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar HttpClient e MusicasServices
builder.Services.AddHttpClient<MusicasServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Músicas v1");
        c.RoutePrefix = string.Empty; // Swagger na raiz
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();