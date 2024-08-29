using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate.Cfg;



namespace CashflowModelling.Persistence.IRR
{
    public class FluentMapperConfigurer
    {
      
        public void Config(Configuration nhCfg)
        {
            //var mySqlConfiguration = MsSqlConfiguration.MsSql2012.ConnectionString("DbConnectionString");
            //Fluently.Configure(nhCfg)
                //.Database(mySqlConfiguration)
                //.Mappings(m => m.FluentMappings.AddFromAssemblyOf<Domain>())
               // .BuildConfiguration();
            
        }

    }
}
