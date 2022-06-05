using System.Xml.Serialization;

namespace Students_Adapter;

internal class StudentManager
{
    private readonly IStudentSerialiser _serialiser;
    private int studCounter = 1;
    private List<Student> students = new();
    public StudentManager(IStudentSerialiser serialiser)
    {
        _serialiser = serialiser;
    }

    public Student Add(string LastName, string Name, string Patronimyc, DateTime Birthday)
    {
        var student = new Student
        {
            Id = studCounter++, 
            LastName = LastName,
            Name = Name,
            Patronymic = Patronimyc,
            Birthday = Birthday
        };
        students.Add(student);
        return student;
    }

    public FileInfo SaveTo(string FilePath)
    {
        var file = new FileInfo(FilePath);
        var xml_serializer = new XmlSerializer(typeof(List<Student>));

        using (var xml = file.Create())
            _serialiser.Serialise(xml, students);

        return file;
    }

    public void LoadFrom (string FilePath)
    {
        using var xml = File.OpenRead(FilePath);
        var Students = _serialiser.Deserialise(xml);
        if (Students.Count == 0) return;
        studCounter = Students.Max(student => student.Id) + 1;
    }
}
