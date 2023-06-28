using NerdysoftWebAPI.Configurations;
using NerdysoftWebAPI.Database.Interfaces;
using NerdysoftWebAPI.Database.Repositories;
using NerdysoftWebAPI.MapperProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(AnnouncementProfile).Assembly);

builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();

builder.Services.AddDataAccess(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MigrateDatabase();

app.UseHttpsRedirection();

app.UseCrossOriginResourceSharing();

app.UseAuthorization();

app.MapControllers();

app.Run();
