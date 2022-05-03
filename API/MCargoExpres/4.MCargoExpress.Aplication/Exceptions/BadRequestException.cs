namespace _4.MCargoExpress.Aplication.Exceptions
{
    /// <summary>
    /// Clase para respuesta del middleware (Bad request)
    /// </summary>
    /// Johnny Arcia
    public abstract class BadRequestException : ApplicationException
    {
        protected BadRequestException(string message)
            : base("Bad Request", message)
        {
        }
    }
}
