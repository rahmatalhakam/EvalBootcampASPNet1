using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EvalBootcampASPNet1.Models;

namespace EvalBootcampASPNet1.Data
{
    public interface IAuthor : ICrud<Author>
    {
        Task<IEnumerable<Author>> GetByName(string name);
        Task<IEnumerable<Course>> GetByIDCourse(int id);
    }
}
