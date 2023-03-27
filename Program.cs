using System;
using System.Collections.Generic;
using System.Linq;

namespace ProbB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nM = Console.ReadLine().Split(' ');
            var king = Console.ReadLine();
            List<Person> familyRelation = new List<Person>();
            List<Person> claims = new List<Person>();

            for (int i = 0; i < int.Parse(nM[0]); i++)
            {
                var family = Console.ReadLine().Split(' ');
                foreach (string s in family)
                {
                    familyRelation.Add(new Person(s));
                }
            }

            for (int j = 0; j < int.Parse(nM[1]); j++)
            {
                var name = Console.ReadLine();

                var result = familyRelation.FirstOrDefault(c => c.Name.Equals(name));
                if (result != null)
                    claims.Add(result);
            }

            Program.setFamilyBond(familyRelation, king);
            foreach (var item in familyRelation)
            {
                Console.WriteLine(" -- " + item.Name + " ---- " + item.RoyalBlood);
            }

            Console.WriteLine(claims.OrderBy(i => i.RoyalBlood).Last().Name);
           
        }
        
        static void setFamilyBond(List<Person> familyRelation, string king)
        {
            foreach (var item in familyRelation)
            {
                if (item.Name.Equals(king))
                    item.RoyalBlood = 1;
            }

            for (int j = 0; j < familyRelation.Count(); j += 3)
            {
                for (int i = 0; i < familyRelation.Count(); i += 3)
                {
                    foreach (Person p in familyRelation)
                    {
                        if (p.RoyalBlood == 0 && p.Name == familyRelation[i].Name)
                            p.RoyalBlood = (familyRelation[i + 1].RoyalBlood / 2) + (familyRelation[i + 2].RoyalBlood / 2);
                    }
                }
            }       
        }
    }

    class Person
    {
        public string Name { get; set; }
        public double RoyalBlood { get; set; }

        public Person(string _name)
        {
            Name = _name;
        }
    }
}
