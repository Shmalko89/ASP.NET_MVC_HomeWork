using Students_Adapter.Serialiser;
namespace Students_Adapter;

public abstract class StudentSerialiser : IStudentSerialiser
{
    public static StudentSerialiser XML() => new StudentXMLSerialiser();
    public static StudentSerialiser BIN() => new StudentBinarySerialiser();
    public static StudentSerialiser Json() => new StudentJsonSerialiser();

    public static StudentSerialiser Create(StudentSerialiserType type = StudentSerialiserType.Json) => type switch
    {
        StudentSerialiserType.XML => XML(),
        StudentSerialiserType.Bin => BIN(),
        StudentSerialiserType.Json => Json(),
        _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
    };
    public abstract List<Student> Deserialise(Stream stream);
    public abstract void Serialise(Stream stream, List<Student> students);
}
