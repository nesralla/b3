using cdbapi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAngularApp",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200") // Adjust this to your Angular app URL
                       .AllowAnyHeader()
                       .AllowAnyMethod();
            });
    });
builder.Services.AddScoped<ICdbService, CdbService>();
builder.Services.AddScoped<IImpostoService, ImpostoService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("AllowAngularApp");

app.UseAuthorization();

app.MapControllerRoute(name: "default",
    pattern: "{controller=Cdb}/{action=Simulador}/{id?}");



app.Run();
