using Marks.Core.Models;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System;
using System.Reflection;

namespace Marks.Database.SeedData
{
    public static class DataSeeder
    {
        public static void SeedPeople(AppDbContext context)
        {
            if (!context.Peoples.Any())
            {
                var peoples = AddRandomMarks(ReadPeolple());

                context.Peoples.AddRange(peoples);

                context.SaveChanges();
            }
        }

        public static List<People> ReadPeolple()
        {
            var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var peopleArray = File.ReadAllLines($"{rootPath}\\SeedData\\PeopleArray.txt");

            var result = peopleArray.Select(p =>
            {
                var fullName = p.Split(' ');

                return new People
                {
                    FirstName = fullName.First(),
                    LastName = fullName.Last()
                };
            }).ToList();

            return result;
        }

        public static List<People> AddRandomMarks(List<People> peoples)
        {
            peoples.ForEach(p =>
            {
                var rand = new Random();
                p.Mark = new Mark
                {
                    Value = rand.Next(0, 5),
                    People = p
                };
            });

            return peoples;
        }
    }
}
