using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSide.BussinessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        int Save();

        //kaydettiği kolon sayısı
        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        T GetById(int Id);



    }
}
