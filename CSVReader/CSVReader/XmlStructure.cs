using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace CSVReader
{
    public class XmlStructure
    {
        [XmlAttribute(attributeName: "CreatedAt")]
        public string CreatedAt { get; set; }

        [XmlAttribute(attributeName: "Author")]
        public string Author { get; set; }

        [XmlArray(elementName: "Students")]
        public HashSet<Student> Students { get; set; }

        [XmlArray(elementName: "ActiveStudies")]
        public List<Study> ActiveStudies { get; set; }
        
        public XmlStructure() { }

        public XmlStructure(HashSet<Student> students, List<Study> activeStudies)
        {
            Students = students;
            ActiveStudies = activeStudies;
            DateTime dateTime = DateTime.UtcNow.Date;
            CreatedAt = dateTime.ToString("dd.MM.yyyy");
            Author = "Bohdan Shkamarida";
        }
    }
}