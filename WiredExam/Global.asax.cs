using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WiredExamDomain;

namespace WiredExam
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Burada veritabanı sınıfımızdan, bir nesne oluşturuyoruz. using kullanmamızın sebebi,
            //db nesnesinin işi bittiğinde, silinmesini ve hafızada yer tutmamasını sağlamak.
            using (BaseClassContext db = new BaseClassContext())
            {
                //Bu metod, eğer veritabanımız oluşturulmamış ise, oluşturulmasını sağlıyor.
                db.Database.CreateIfNotExists();
            }
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
     
    }
}
