using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak1;

namespace Zadatak4
{
    public class University
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }
    }

    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            return intArray.OrderBy(i => i).GroupBy(i => i).Select(a => "broj " + a.Key + " ponavlja se " + a.Count() + " puta").ToArray();
        }

        public static University[] Linq2_1(University[] universityArray)
        {
            return universityArray.Where(u => u.Students.Where(s => s.Gender == Gender.Female).Count() == 0).ToArray();
        }
        public static University[] Linq2_2(University[] universityArray)
        {
            int numUni = universityArray.Count();
            int numStu = universityArray.SelectMany(u => u.Students).Count();
            double avg = numStu / numUni;
            return universityArray.Where(u => u.Students.Count() < avg).ToArray();
        }
        public static Student[] Linq2_3(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students.Select(s => s)).Distinct().ToArray();
        }
        public static Student[] Linq2_4(University[] universityArray)
        {
            return universityArray.Where(u => (u.Students.Where(s => s.Gender == Gender.Female).Count() == 0
                                           | u.Students.Where(s => s.Gender == Gender.Male).Count() == 0))
                                        .SelectMany(u => u.Students).Distinct().ToArray();
        }
        public static Student[] Linq2_5(University[] universityArray)
        {
            return universityArray.SelectMany(u => u.Students).GroupBy(x => x).Where(s => s.Count() > 1).Select(s => s.Key).ToArray();
        }

    }
}
