using Students_Adapter;
using System.Xml.Serialization;


var serialiser_type = StudentSerialiserType.Json;
var student_manager = new StudentManager(StudentSerialiser.Create(serialiser_type));

student_manager.Add("Иванов", "Иван", "Иванович", DateTime.Now.AddYears(-33));
student_manager.Add("Петров", "Петр", "Петрович", DateTime.Now.AddYears(-25));
student_manager.Add("Дмитриев", "Дмитрий", "Дмитриевич", DateTime.Now.AddYears(-20));

var file_name = $"students.{serialiser_type}";
student_manager.SaveTo(file_name);

Console.ReadLine();


