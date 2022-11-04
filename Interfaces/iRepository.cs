using System.Collections.Generic;

namespace DIO.Series.Interfaces
{
    public interface iRepository<T>
    {
        List<T> List();
        T ReturnById(int id);

        void Insert(T entidy);
        void Delete(int id);
        void Refresh(int id, T entidy);
        int NextId();
    }
}