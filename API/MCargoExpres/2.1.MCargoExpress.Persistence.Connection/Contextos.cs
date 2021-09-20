using _2._2.MCargoExpress.Persistence.Settings;
using _3._2.MCargoExpress.Enums;
using _3._3.MCargoExpress.Interfaces;
using MCargoExpress.Persistence.Mysql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1.MCargoExpress.Persistence.Connection
{
    /// <summary>
    /// Clase Factory de Contextos
    /// </summary>
    /// Johnny Arcia
    public class Contextos : IDisposable
    {
        private IConexion conMCE; //Conexion con la base de datos Maranatha Cargo Express
        private IDapperConnection conDapper; //Conexion con la base de datos por medio de Dapper
        private UnitOfWork unitOfWork; //Unit of work
        //Constructor vacio
        public Contextos()
        {
        }
        /// <summary>
        /// Constructor de contextos
        /// </summary>
        /// <param name="_conexion">Conexion Bd Maranatha cargo express</param>
        /// <param name="_dapperConnection">Conexion Dapper</param>
        public Contextos(IConexion _conexion, IDapperConnection _dapperConnection)
        {
            conMCE = _conexion;
            conDapper = _dapperConnection;
        }
        /// <summary>
        /// Metodo que obtiene el contexto de Maranatha Cargo Express
        /// </summary>
        /// <returns>Contexto DB Maranatha Cargo Express</returns>
        /// Johnny Arcia
        private IConexion getContextMCE()
        {
            return conMCE;
        }
        /// <summary>
        /// Metodo que cierra la conexion con BD Maranatha Cargo Express
        /// </summary>
        /// Johnny Arcia
        private void closeContextMCE()
        {
            conMCE.Dispose();
        }
        /// <summary>
        /// Obtiene el unit of work para el contexto IConexion
        /// </summary>
        /// <returns></returns>
        /// Johnny Arcia
        public UnitOfWork GetUnitOfWork()
        {
            if (unitOfWork == null) unitOfWork = new UnitOfWork(getContextMCE());
            return unitOfWork;
        }
        /// <summary>
        /// Cierra la conexion del unit of work
        /// </summary>
        public void closeUnitOfWork()
        {
            unitOfWork.Dispose();
        }
        /// <summary>
        /// Metodo que obtiene una conexion con Dapper BD Maranatha Cargo Express
        /// </summary>
        /// <returns>Conexion con Dapper</returns>
        /// Johnny Arcia
        public IDbConnection getContextDapper()
        {
            return conDapper.GetConnection();
        }
        /// <summary>
        /// Metodo que cierra la conexion con Dapper
        /// </summary>
        /// Johnny Arcia
        public void closeContexDapper()
        {
            conDapper.CloseConnection();
        }
        /// <summary>
        /// Dispose de la clase Contextos que sirve para cerrar conexiones de todos los contextos
        /// </summary>
        /// Johnny Arcia
        public void Dispose()
        {
            closeUnitOfWork();
            closeContexDapper();
        }
    }
}
