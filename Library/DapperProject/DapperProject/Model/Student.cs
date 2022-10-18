using System.ComponentModel.DataAnnotations.Schema;

namespace DapperProject.Model;

public class Student
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    public List<Grade> Grades { get; set; } = new List<Grade>();
}