using System.ComponentModel.DataAnnotations.Schema;

namespace DapperProject.Model;

public class Grade
{
    [Column("sequence")]
    public int Sequence { get; set; }
    [Column("student_id")]
    public int StudentID { get; set; }
    [Column("subject")]
    public string Subject { get; set; }
    [Column("score")]
    public int Score { get; set; }
    
    public Student Student { get; set; }
}