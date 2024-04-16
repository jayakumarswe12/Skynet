using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region Configure CORS
builder.Services.AddCors(Options=>Options.AddPolicy("SkyNet",X=>
X.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
#endregion
#region  Configure DBMS
var ConnectionStrings=builder.Configuration.GetConnectionString("Skynet");
builder.Services.AddDbContext<ApplicationDbContext>(Options=>Options.UseSqlServer(ConnectionStrings));
#endregion
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();


