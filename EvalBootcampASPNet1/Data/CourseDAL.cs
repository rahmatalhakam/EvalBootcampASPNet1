using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EvalBootcampASPNet1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EvalBootcampASPNet1.Data
{
    public class CourseDAL : ICourse
    {
        private AppDbContext _db;
        public CourseDAL(AppDbContext db)
        {
            _db = db;
        }

        public async Task Delete(int id)
        {
            try
            {
                var course = await GetById(id);
                if (course == null)
                    throw new Exception("Data not found");
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Course>> GetAll()
        {
            var results = await (from course in _db.Courses orderby course.Title ascending select course).ToListAsync();
            if (results == null) throw new Exception("Data not found.");
            return results;


        }

        public async Task<IEnumerable<Course>> GetByAuthor(string name)
        {
            var results = await(from course in _db.Courses
                                join author in _db.Authors on course.AuthorId equals author.Id
                                where
                                author.FirstName.ToLower().Contains(name.ToLower())
                                ||
                                author.LastName.ToLower().Contains(name.ToLower())
                                orderby course.Title ascending select course).ToListAsync();
            if (results == null) throw new Exception("Data not found.");
            return results;
        }

        public async Task<Course> GetById(int id)
        {
            try
            {
                var result = await (from course in _db.Courses where course.Id == id select course).SingleAsync();
                if (result == null) throw new Exception("Data not found.");
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            

        }

        public async Task<IEnumerable<Course>> GetByName(string name)
        {
            var results = await (from course in _db.Courses
                                 where
                                 course.Title.ToLower().Contains(name.ToLower())
                                 select course).ToListAsync();
            if (results == null) throw new Exception("Data not found.");
            return results;
        }

        public async Task<Course> Insert(Course obj)
        {
            try
            {
                _db.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<Course> Update(int id, Course obj)
        {
            try
            {
                var course = await GetById(id);
                if (course == null) throw new Exception("Data not found.");
                course.AuthorId = obj.AuthorId;
                course.Title = obj.Title;
                course.Descriprion = obj.Descriprion;
                await _db.SaveChangesAsync();
                return course;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}
