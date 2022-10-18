using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using Dapper;
using DapperProject;
using DapperProject.Model;

SetEntityMapper<Student>();
SetEntityMapper<Grade>();

DbController dbController = new();
dbController.SelectRelationship();

if (dbController.InsertStudent() == -1)
    Console.WriteLine("insert error");

var updateStudent = dbController.SelectStudents().OrderBy(o => Guid.NewGuid()).FirstOrDefault();
if (updateStudent is not null)
{
    updateStudent.Name = "update name!";
    if (dbController.UpdateStudent(updateStudent) == -1)
        Console.WriteLine("update error");
}

var deleteStudent = dbController.SelectStudents().OrderBy(o => Guid.NewGuid()).FirstOrDefault();
if (deleteStudent is not null)
{
    if (dbController.DeleteStudent(deleteStudent) == -1)
        Console.WriteLine("delete error");
}

dbController.SelectStudents();

void SetEntityMapper<TEntity>()
{
    SqlMapper.SetTypeMap(typeof(TEntity), new CustomPropertyTypeMap(typeof(TEntity), (type, columnName) =>
    {
        return type.GetProperties().FirstOrDefault(prop =>
        {
            if (prop.GetCustomAttribute<ColumnAttribute>() is not ColumnAttribute attr)
                return false;

            return string.Compare(attr.Name, columnName, true) == 0;
        });
    }));
}