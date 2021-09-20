using _1.MCargoExpress.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3.MCargoExpress.Interfaces
{
    /// <summary>
    /// Interfaz para el patron Unit of Work
    /// </summary>
    /// Johnny Arcia
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Aplica el repositorio generico
        /// </summary>
        /// <typeparam name="TEntity">Entidad</typeparam>
        /// <returns>Patron repositorio orientado a la entidad</returns>
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : ClaseBase;
        /// <summary>
        /// Completa todas las transacciones con un saveChanges
        /// </summary>
        /// <returns></returns>
        Task<int> Complete();
    }
}
