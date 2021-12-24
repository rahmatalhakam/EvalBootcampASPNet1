using System;
using System.Linq;
using EvalBootcampASPNet1.Models;

namespace EvalBootcampASPNet1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Authors.Any()) return;
            var authors = new Author[] {
                new Author{FirstName="Erick", LastName="Kurniawan", DateOfBirth=DateTime.Parse("1990-11-01"), MainCategory="Technology"},
                new Author{FirstName="Agus", LastName="Kurniawan", DateOfBirth=DateTime.Parse("1989-09-21"), MainCategory="Technology"},
                new Author{FirstName="Tere", LastName="Liye", DateOfBirth=DateTime.Parse("1979-05-21"), MainCategory="Novel"},
                new Author{FirstName="Ahmad Mansyur", LastName="Suryanegara", DateOfBirth=DateTime.Parse("1985-03-27"), MainCategory="Sejarah"},
                new Author{FirstName="Test", LastName="Doang", DateOfBirth=DateTime.Now, MainCategory="Test"},
                new Author{FirstName="Test2", LastName="Doang2", DateOfBirth=DateTime.Now, MainCategory="Test"},
            };
            foreach (var author in authors)
            {
                context.Authors.Add(author);
            }

            context.SaveChanges();
            var courses = new Course[]
            {
                new Course{Title="Cloud Fundamentals", Descriprion="Learning cloud fundamental with azure and how to do the best practoces", AuthorId=1},
                new Course{Title="Microservices Architecture", Descriprion="Microservices are like how to build bee hive, should be integrated from each other.", AuthorId=1},
                new Course{Title="Frontend Programming", Descriprion="Learning frontend web development with react js", AuthorId=2},
                new Course{Title="Backend RESTful API", Descriprion="Restfull API BE with Go gin sooo fassttt.", AuthorId=2},
                new Course{Title="Writing Workshop", Descriprion="How to make a great novel without pain.", AuthorId=3},
                new Course{Title="Test title1", Descriprion="Test Desctiption1", AuthorId=4},
                new Course{Title="Test title2", Descriprion="Test Desctiption2", AuthorId=5},
            };

            foreach (var course in courses)
            {
                context.Courses.Add(course);
            }

            context.SaveChanges();
        }
    }
}
