using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvalBootcampASPNet1.Data
{
    public interface ICrud<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Insert(T obj);
        Task<T> Update(int id, T obj);
        Task Delete(int id);
    }

}
