using WebApplication1;
using WebApplication1.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IstudentRepository, StudentRepository>();
builder.Services.Configure<WebApplication1Settings>(builder.Configuration.GetSection("WebApplication1Settings"));

var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//endpoints
app.MapPost("/student", (Student std, IstudentRepository sr) =>
{ sr.Add(std); });

app.MapGet("/student/{id}", (Guid id, IstudentRepository sr) => { sr.Get(id); });



app.Run();




