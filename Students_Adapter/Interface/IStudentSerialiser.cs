using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Students_Adapter;

public interface IStudentSerialiser
{
    void Serialise(Stream stream, List<Student> students);

    List<Student> Deserialise(Stream stream);
}








