using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace WebApplication1.Model
{

    public interface IstudentRepository
    {
        public Task Add(Student student);
        public Task<Student?> Get(Guid id);

    }
    public class StudentRepository : IstudentRepository
    {


        private readonly IMongoCollection<Student> _students;
        public StudentRepository(IOptions<WebApplication1Settings> WebApplication1Settings)
        {
            //_students = new List<Student>();
            // Tbd static tests
            //Guid guid = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            //_students.Add(new Student { Id = guid, Name = "Linus", Major = "Programming" });

            var mongoClient = new MongoClient(WebApplication1Settings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(WebApplication1Settings.Value.DatabaseName);
            _students = mongoDatabase.GetCollection<Student>(WebApplication1Settings.Value.StudentsCollectionName);

            
        }

        public async Task Add(Student std)
        {
            //_students.Add(std);
            await _students.InsertOneAsync(std);
        }

        public async Task<Student?> Get(Guid id)
        {
            //return _students.FirstOrDefault(s => s.Id == id);
            return await _students.Find(s => s.Id == id).FirstOrDefaultAsync();

        }



    }
}
