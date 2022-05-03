namespace _4.MCargoExpress.Aplication.Exceptions
{
    /// <summary>
    /// Clase para respuesta del middleware (usuario no encontrado)
    /// </summary>
    /// Johnny Arcia
    public sealed class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int userId)
            : base($"El usuario id {userId} no se encontro.")
        {
        }
    }
}
