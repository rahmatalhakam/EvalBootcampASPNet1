using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EvalBootcampASPNet1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EvalBootcampASPNet1.Data
{
    public class AuthorDAL : IAuthor
    {
        private AppDbContext _db;
        public AuthorDAL(AppDbContext db)
        {
            _db = db;
        }

        public async Task Delete(int id)
        {
            try
            {
                var author = await GetById(id);
                if (author == null)
                    throw new Exception("Data not found");
                _db.Authors.Remove(author);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            var results = await(from author in _db.Authors orderby author.FirstName ascending select author).ToListAsync();
            if (results != null)
                return results;
            else
                throw new Exception("Data not found.");
        }

        public async Task<Author> GetById(int id)
        {
            var result = await (from author in _db.Authors where author.Id == id select author).SingleAsync();
            if (result != null)
                return result;
            else
                throw new Exception("Data not found.");

        }

        public async Task<IEnumerable<Author>> GetByName(string name)
        {
            IEnumerable<Author> results = await (from author in _db.Authors
                                where
                                author.FirstName.ToLower().Contains(name.ToLower())
                                ||
                                author.LastName.ToLower().Contains(name.ToLower())
                                select author).ToListAsync();
            if (results != null)
                return  results;
            else
                throw new Exception("Data not found.");
        }

        public async Task<IEnumerable<Course>> GetByIDCourse(int id)
        {
            var results = await (from course in _db.Courses
                                 join author in _db.Authors on course.AuthorId equals author.Id
                                 where course.AuthorId == id
                                 orderby course.Title ascending
                                 select course).ToListAsync();
            if (results == null) throw new Exception("Data not found.");
            return results;
        }

        public async Task<Author> Insert(Author author)
        {
            try
            {
                _db.Add(author);
                await _db.SaveChangesAsync();
                return author;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Author> Update(int id, Author obj)
        {
            try
            {
                var author = await GetById(id);
                if (author == null) throw new Exception("Data not found.");
                author.FirstName = obj.FirstName;
                author.LastName = obj.LastName;
                author.DateOfBirth = obj.DateOfBirth;
                author.MainCategory = obj.MainCategory;
                await _db.SaveChangesAsync();
                return author;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
