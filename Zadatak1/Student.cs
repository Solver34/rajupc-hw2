using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    public class Student
    {
        public string Name { get; set; }
        public string Jmbag { get; set; }
        public Gender Gender { get; set; }
        public Student(string name, string jmbag)
        {
            Name = name;
            Jmbag = jmbag;
        }

        public override bool Equals(object value)
        {
            Student student = value as Student;

            return !Object.ReferenceEquals(null, student)
                && String.Equals(Name, student.Name)
                && String.Equals(Jmbag, student.Jmbag)
                && Gender.Equals(Gender, student.Gender);
        }

        public static bool operator ==(Student student1, Student student2)
        {
            if (Object.ReferenceEquals(student1, student2))
            {
                return true;
            }

            if (Object.ReferenceEquals(null, student1))
            {
                return false;
            }

            return (student1.Equals(student2));
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(student1 == student2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                // Choose large primes to avoid hashing collisions
                const int HashingBase = (int)2166136261;
                const int HashingMultiplier = 16777619;

                int hash = HashingBase;
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Name) ? Name.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Jmbag) ? Jmbag.GetHashCode() : 0);
                hash = (hash * HashingMultiplier) ^ (!Object.ReferenceEquals(null, Gender) ? Gender.GetHashCode() : 0);
                return hash;
            }
        }
    }

    public enum Gender
    {
        Male, Female
    }
}
