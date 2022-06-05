using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Students_Adapter.Serialiser;

internal class StudentXMLSerialiser : StudentSerialiser
{
    private static readonly XmlSerializer serializer = new(typeof(List<Student>));
    public override List<Student> Deserialise(Stream stream)
    {
        return (List<Student>?)serializer.Deserialize(stream) ?? throw new InvalidOperationException("Попытка не удалась");
    }

    public override void Serialise(Stream stream, List<Student> students)
    {
        serializer.Serialize(stream, students);
    }
}
