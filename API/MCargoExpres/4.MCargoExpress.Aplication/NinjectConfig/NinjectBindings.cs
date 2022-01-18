using _2._1.MCargoExpress.Persistence.Connection;
using _3._3.MCargoExpress.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MCargoExpress.Aplication.NinjectConfig
{
    public class NinjectBindings : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IContextos>().To<Contextos>();
        }
    }
}
