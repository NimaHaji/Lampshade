using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _0_Freamwork.Domain
{
    public interface IRepository<TKey, T> where T : class
    {
        T Get(TKey Id);
        List<T> Get();
        void Create(T Entity);
        bool IsExist(Expression<Func<T, bool>> expression);
        void SaveChanges();
    }
}
