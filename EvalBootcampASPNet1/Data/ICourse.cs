using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EvalBootcampASPNet1.Models;

namespace EvalBootcampASPNet1.Data
{
    public interface ICourse:ICrud<Course>
    {
        Task<IEnumerable<Course>> GetByName(string name);
        Task<IEnumerable<Course>> GetByAuthor(string name);
    }
}
