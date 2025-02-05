using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    //Diğer Interfacelerime gidip bu interface'den miras aldırıp buradaki imzaları
    //otomatik olarak taşımış olacak
    //burada temel crud işlemlerini yapacağımız metodların imzalarını (iskeletini)
    //oluşturmuş oldum
    public interface IGenericDal<T> where T :class
    {
        void Insert(T t);//tabloya ekle
        void Delete(T t);//tablodan sil
        void Update(T t);//tabloyu güncelle
        List<T> GetListAll();//Tümünü getir
        List<T> GetListAll(Expression<Func<T,bool>>Filter);//Şarta göre listele
        T GetById(int id);//ilgili Id'ye göre veriyi getir
        T GetValue(Expression<Func<T,bool>>Filter);//şarta göre bir veri getir.
    }
}
