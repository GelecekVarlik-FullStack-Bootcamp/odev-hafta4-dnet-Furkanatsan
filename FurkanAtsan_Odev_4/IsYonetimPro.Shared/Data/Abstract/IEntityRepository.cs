using IsYonetimPro.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Shared.Data.Abstract
{
    public interface IEntityRepository<T>where T:class,IEntity,new()//tüm entityler için kullanabileceğimiz ortak methodlar.
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);// işi oluşturan kişiyi getirmek isteyebiliriz.İşi oluşturran kişi ile birlikte işleride getirmek isteyebiliriz. predicate ile çalışanı seçebiliyoruz, includeProperty ile de çalışanın işlerini çalıştığı departmanı vs getirebiliyoruz.
        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties);  //tüm işleri getir.tüm çalışanları getir.
                                                                                                                                         //departmana göre işleri getir.
        Task<T> AddAsync(T entity);//bir iş eklemiş isek geriye bir iş dönücek.
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);//örn:Böyle bir iş,çalışan var mı kontrolu
        Task<int> CountAsync(Expression<Func<T, bool>> predicate = null);//total kaç iş çalışan var.
    }
}
