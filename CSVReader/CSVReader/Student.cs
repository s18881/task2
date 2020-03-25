using System;
using System.Xml.Serialization;

namespace CSVReader
{
    public class Student
    {
        [XmlAttribute(AttributeName = "IndexNumber")]
        public string Id { get; set; }
         
         private string _firstName;
         public string FirstName
         {
             get { return _firstName; }
             set
             {
                 if((value == "") || (value == null)) throw new  AggregateException();
                 _firstName = value;
             }
         }

         private string _lastName;
         public string LastName
         {
             get { return _lastName; }
             set
             {
                 if((value == "") || (value == null)) throw new ArgumentException();
                 _lastName = value;
             }
         }

         private string _faculty;
         public string Faculty
         {
             get { return _faculty; }
             set
             {
                 if((value == "") || (value == null)) throw new ArgumentException();
                 _faculty = value;
             }
         }

         private string _typeOfStudying;
         public string TypeOfStudying { 
            get { return _typeOfStudying; }
            set
            {
                if((value == "") || (value == null)) throw new ArgumentException();
                _typeOfStudying = value;
            }
         }

         private string _dateOfBirth;
         public string DateOfBirth { 
            get { return _dateOfBirth; }
            set
            {
                if((value == "") || (value == null)) throw new ArgumentException();
                _dateOfBirth = value;
            }
         }

         private string _email;
         public string Email
         {
            get { return _email; }
            set
            {
                if((value == "") || (value == null)) throw new ArgumentException();
                _email = value;
            }
         }

         private string _nameOfMother;
         public string NameOfMother { get { return _nameOfMother; }
            set
            {
                if((value == "") || (value == null)) throw new ArgumentException();
                _nameOfMother= value;
            }
            
         }

         private string _nameOfFather;
         public string NameOfFather { get { return _nameOfFather; }
            set
            {
                if((value == "") || (value == null)) throw new ArgumentException();
                _nameOfFather = value;
            } 
         }
        
         [XmlElement(elementName: "Studies")]
         public StudiesData StudiesInformation { get; set; }
         
         public Student() { }

         public override string ToString()
         {
             return $"{nameof(Id)}: {Id}, {nameof(FirstName)}: {FirstName}, {nameof(LastName)}: {LastName}," +
                    $" {nameof(Faculty)}: {Faculty}, {nameof(TypeOfStudying)}: {TypeOfStudying}," +
                    $" {nameof(DateOfBirth)}: {DateOfBirth}, {nameof(Email)}: {Email}, {nameof(NameOfMother)}: {NameOfMother}," +
                    $" {nameof(NameOfFather)}: {NameOfFather}, {nameof(StudiesInformation)}: {StudiesInformation}";
         }

         public struct StudiesData
        {
            public StudiesData(string faculty, string mode)
            {
                Faculty = faculty;
                Mode = mode;
            }

            [XmlElement(elementName: "Name")]
            public string Faculty { get; set; }
            [XmlElement(elementName: "Mode")]
            public string Mode { get; set; }
        }
    }
}