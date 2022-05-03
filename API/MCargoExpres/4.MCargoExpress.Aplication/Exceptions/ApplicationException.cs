using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.MCargoExpress.Aplication.Exceptions
{
    /// <summary>
    /// Extension de la clase Exception que maneja el titulo de la excepcion
    /// </summary>
    /// Johnny Arcia
    public abstract class ApplicationException : Exception
    {
        protected ApplicationException(string title, string message)
            : base(message) =>
            Title = title;

        public string Title { get; }
    }
}
