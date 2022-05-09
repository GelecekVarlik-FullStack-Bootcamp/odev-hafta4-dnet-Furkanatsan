using IsYonetimPro.Data.Abstract;
using IsYonetimPro.Data.Concrete;
using IsYonetimPro.Entities.Concrete;
using IsYonetimPro.Services.Abstract;
using IsYonetimPro.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsYonetimPro.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)//serviceCollection sınıfı ile servisleri, yaşam döngülerine göre ekleyebiliyoruz.
        {
            //extension metod kullandığımız için loadMyServices startupta services. elementlerinde gözükecek.
            //mvc katmanımız direkt data katmanımıza erişmemesi için startupa direkt yazmaktansa bu şekilde yaptık.
            serviceCollection.AddDbContext<IsYonetimSistemiDBContext>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ITaskService, TaskManager>();
            serviceCollection.AddScoped<IEmployeeService, EmployeeManager>();

            return serviceCollection;
        }
        //AddScoped: ServiceCollection’nın kapsamına göre nesnenin yaratılmasını sağlar.yapılan her istekte nesne tekrar oluşur ve bir istekte sadeve bir nesne kullanılır.

    }
}
