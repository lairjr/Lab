using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogDAL
{
    public class NinjectConfig : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbEntities>().To<DbEntities>().InSingletonScope();
        }
    }
}
