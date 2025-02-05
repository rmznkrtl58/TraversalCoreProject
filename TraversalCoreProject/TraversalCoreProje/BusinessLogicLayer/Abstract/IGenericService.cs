using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Abstract
{   //Dal'daki crud işlemlerinin olduğu metodları
    //Bu metodlara çağırarak yaptırıyoruz.
    public interface IGenericService<T>where T:class
    {
        void AddToTable(T t);//tabloya ekle
        void DeleteFromTable(T t);//tablodan sil
        void UpdateTheTable(T t);//tabloyu güncelle
        List<T> TGetListAll();//Tümünü getir
        //List<T> TGetListbyCondition();//Şarta göre listele
        T TGetById(int id);//ilgili Id'ye göre veriyi getir
        //T TGetValuebyCondition();//şarta göre bir veri getir.
    }
}
