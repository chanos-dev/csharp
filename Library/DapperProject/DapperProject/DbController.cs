using System.Data;
using System.Text.Json;
using Dapper;
using DapperProject.Model;
using MySql.Data.MySqlClient;

namespace DapperProject;

public class DbController
{
    private readonly IDbConnection _dbConnection;

    public DbController()
    {
        this._dbConnection = new MySqlConnection("Server=127.0.0.1;Database=test;Uid=test;Pwd=test;");
        this._dbConnection.Open();
    }

    public int InsertStudent()
    {
        Student student1 = new()
        {
            Name  = "hello~~",
        };

        return this._dbConnection.Execute(@"
INSERT INTO student (name) VALUES(@Name); 
", student1);
    }

    public int DeleteStudent(Student student)
    {
        if (student is null ||
            student.Id < 0)
            return -1;
        return this._dbConnection.Execute(@"
DELETE FROM student
WHERE id = @Id
", student);
    }
    
    public int UpdateStudent(Student student)
    {
        return this._dbConnection.Execute(@"
UPDATE student
SET name = @Name
WHERE id = @Id
", student);
    }
    
    public IEnumerable<Student> SelectStudents()
    {
        var students = this._dbConnection.Query<Student>(@"
SELECT * FROM student
");
        Console.WriteLine(ConvertJson(students));
        return students;
    }

    public void SelectRelationship()
    {
        var studentQuery = "select * from student s inner join grade g on s.id = g.student_id";
        var students = this._dbConnection.Query<Student, Grade, Student>(studentQuery, (student, grade) =>
        {
            student.Grades.Add(grade);
            return student;
        }, splitOn: "student_id");

        var result = students.GroupBy(p => p.Id).Select(g =>
        {
            var groupedStudents = g.First();
            groupedStudents.Grades = g.Select(p => p.Grades.Single()).ToList();
            return groupedStudents;
        });

        Console.WriteLine(ConvertJson(result));
    }

    private string ConvertJson(object obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions()
        {
            WriteIndented = true,
        });
    }
}