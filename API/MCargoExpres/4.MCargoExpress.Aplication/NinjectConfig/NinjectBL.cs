using _2._1.MCargoExpress.Persistence.Connection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MCargoExpress.Aplication.NinjectConfig
{
    public class NinjectBL
    {
        IContextos objIContextos;

        public NinjectBL(IContextos _objIContexto)
        {
            objIContextos = _objIContexto;
        }
    }
}
