var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IstudentRepository, StudentRepository>();

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

public interface IstudentRepository
{
    public void Add(Student student);
    public Student Get(Guid id);

}
public class StudentRepository : IstudentRepository
{
    private List<Student> _students;
    public StudentRepository()
    {
        _students = new List<Student>();
    }

    public void Add(Student std)
    {
        throw new NotImplementedException();
    }

    public Student Get(Guid id)
    {
        throw new NotImplementedException();
    }
}
public class Student
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Major { get; set; }



}
