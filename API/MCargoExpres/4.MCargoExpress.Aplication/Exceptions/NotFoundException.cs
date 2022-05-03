namespace _4.MCargoExpress.Aplication.Exceptions
{
    /// <summary>
    /// Clase para respuesta del middleware (Not found)
    /// </summary>
    /// Johnny Arcia
    public abstract class NotFoundException : ApplicationException
    {
        protected NotFoundException(string message)
            : base("Not Found", message)
        {
        }
    }
}
