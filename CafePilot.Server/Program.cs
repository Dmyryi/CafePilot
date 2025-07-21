using CafePilot.Server.Interface;
using CafePilot.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Название политики CORS
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Добавляем сервисы в контейнер
builder.Services.AddControllers();
builder.Services.AddScoped<ICafeService, CafeService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IMenuService, MenuService>();
builder.Services.AddOpenApi();

// Конфигурируем CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:65382") // фронтенд адрес, разрешенный для запросов
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Настройка middleware
app.UseDefaultFiles();
app.MapStaticAssets();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Важно: используем CORS перед авторизацией и контроллерами
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
