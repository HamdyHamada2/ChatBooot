using AI_ChatBot.Services;
using Microsoft.EntityFrameworkCore;
using AI_ChatBot.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ChatBotService>();

// Database
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Services
builder.Services.AddScoped<ChatBotService>();

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// لتفعيل عرض صفحة index.html عند الدخول على /
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapControllers();

app.UseStaticFiles();

// Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// API Routes
app.MapControllers();

// Optional: root message
app.MapGet("/", () => "AI ChatBot API is running...");

app.Run();
