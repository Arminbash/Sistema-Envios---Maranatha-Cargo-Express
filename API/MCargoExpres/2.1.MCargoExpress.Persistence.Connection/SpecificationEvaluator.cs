using _1.MCargoExpress.Domain;
using _3._3.MCargoExpress.Interfaces.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.MCargoExpress.Persistence.Connection
{
    /// <summary>
    /// Clase encargada de manejar las expresiones linq
    /// </summary>
    /// <typeparam name="T">Entidad</typeparam>
    /// Johnny Arcia
    public class SpecificationEvaluator<T> where T : ClaseBase
    {
        /// <summary>
        /// Se obtiene la Query con todas las especificaciones
        /// </summary>
        /// <param name="inputQuery">Query inicial</param>
        /// <param name="spec">Se agrega un nuevo query que se agrega al query inicial</param>
        /// <returns>Query compuesta</returns>
        /// Johnny Arcia
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            //Aplica filtros al query
            if (spec.Criteria != null)
            {
                inputQuery = inputQuery.Where(spec.Criteria);
            }
            //Aplica ordenamiento al query
            if (spec.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(spec.OrderBy);
            }
            //Aplica ordenamiento descendente al query
            if (spec.OrderByDescending != null)
            {
                inputQuery = inputQuery.OrderByDescending(spec.OrderByDescending);
            }
            //Aplica paginado al query
            if (spec.IsPagingEnabled)
            {
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
            }
            //se encarga de agregar objetos propiedad de mapeo a la query
            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

            return inputQuery;
        }
    }
}
