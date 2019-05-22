using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Configuration.Core;

namespace AutoFacIOC
{
    class Program
    {
        static void Main(string[] args)
        {
            //直接指定实例类型
            var builder = new ContainerBuilder();
            builder.RegisterType<DBBase>();
            builder.RegisterType<SqlRepository>().As<IRepository>();
            using (var container = builder.Build())
            {
                var manager = container.Resolve<DBBase>();
                manager.Search("SELECT * FORM USER");
            }


            Type objType = Type.GetType("AutoFacIOC.IRepository, AutoFacIOC");
            Type objTypeSql = Type.GetType("AutoFacIOC.SqlRepository, AutoFacIOC");
            Type objTypeRedis = Type.GetType("AutoFacIOC.RedisRepository, AutoFacIOC");
            //通过配置文件实现对象的创建
            var builder2 = new ContainerBuilder();
            builder2.RegisterType<DBBase>();


            //builder.RegisterType<TestDao>().As<ITestDao>();

            builder2.RegisterType(objTypeSql).As(objType);

            //builder.RegisterType<OracleDatabase>().Named<IDatabase>("AutofacDemo.Lib.Oracle.OracleDatabase");
            //builder2.RegisterModule(new ConfigurationSettingsReader("autofac"));
            using (var container = builder2.Build())
            {
                var manager = container.Resolve<DBBase>();
                manager.Search("SELECT * FORM USER");
            }

            //通过配置文件，配合Register方法来创建对象
            var builder3 = new ContainerBuilder();
            builder3.RegisterType<DBBase>();
            //builder3.RegisterModule(new ConfigurationSettingsReader("autofac"));
            //builder3.RegisterType<RedisRepository>().Named<IRepository>("AutoFacIOC.SqlRepository");
            //builder3.Register(c => new DBBase(c.Resolve<IRepository>()));
            //builder3.RegisterType(objTypeRedis).Named("AutofacDemo.Lib.Sql.SqlDatabase", objType);

            //builder3.RegisterType(objType).Named("AutoFacIOC.DBBase", objType);
            builder3.RegisterType(objTypeRedis).As(objType);
            using (var container = builder3.Build())
            {
                var manager = container.Resolve<DBBase>();
                manager.Search("SELECT * FORM USER");
            }

            Console.ReadKey();
        }
    }
}
