using System;
using System.Collections;
using System.Collections.Generic;

namespace CSVReader.Properties
{
    public class MyComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return StringComparer
                .InvariantCultureIgnoreCase
                .Equals($"{x.Id} {x.Email}",$"{y.Id} {y.Email}");
        }

        public int GetHashCode(Student obj)
        {
            return StringComparer.CurrentCultureIgnoreCase
                .GetHashCode($"{obj.Id} {obj.Email}");
        }
    }
}