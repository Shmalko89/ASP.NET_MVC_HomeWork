using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Students_Adapter.Serialiser;

internal class StudentBinarySerialiser : StudentSerialiser
{
    private static readonly BinaryFormatter serializer = new();
    public override List<Student> Deserialise(Stream stream)
    {
        return (List<Student>?)serializer.Deserialize(stream) ?? throw new InvalidOperationException("Попытка не удалась");
    }

    public override void Serialise(Stream stream, List<Student> students)
    {
        serializer.Serialize(stream, students);
    }
}
