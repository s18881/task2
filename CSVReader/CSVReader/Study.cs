using System.Xml.Serialization;

namespace CSVReader
{
    [XmlType("studies")]
    public class Study
    {
        [XmlAttribute(attributeName: "Name")]
        public string Name { get; set; }
        [XmlAttribute(attributeName: "NumberOfStudents")]
        public int StudiesCounter { get; set; }
        
        public Study() { }
        
        public Study(string name)
        {
            Name = name;
            StudiesCounter = 1;
        }

        public static Study operator++(Study study)
        {
            study.StudiesCounter++;
            return study;
        }
    }
}