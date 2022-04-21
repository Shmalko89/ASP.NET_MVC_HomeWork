using System.Text.Json;


namespace Students_Adapter.Serialiser;

internal class StudentJsonSerialiser : StudentSerialiser
{

    public override List<Student> Deserialise(Stream stream)
    {
        return JsonSerializer.Deserialize<List<Student>>(stream) ?? throw new InvalidOperationException("Попытка не удалась");
    }

    public override void Serialise(Stream stream, List<Student> students)
    {
        JsonSerializer.Serialize(stream, students);
    }
}
