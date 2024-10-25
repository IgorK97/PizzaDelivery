using Interfaces.Repository;
using Ninject.Modules;
using System;
using DAL.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4POWinForms.Util
{
    public class ReposModule : NinjectModule
    {
        private string connectionString;
        public ReposModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {

            Bind<IDbRepos>().To<DbReposPgs>().InSingletonScope().WithConstructorArgument(connectionString);
            
        }
    }
}
