using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using _4.MCargoExpress.Aplication.Exceptions;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._1.MCargoExpress.CRUD.Commands.TipoPersona.Empleado
{
    /// <summary>
    /// Mediador para actualizar el Empleado
    /// </summary>
    /// Francisco Rios
    public class UpdateEmpleado
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<EmpleadoDto>
        {
            public int Id { get; set; }
           
            public int PersonaId { get; set; }
           
            public DateTime? FechaIngreso { get; set; }
          
            public string Cargo { get; set; }
          
            public string NumeroLicencia { get; set; }
         
            public byte Foto { get; set; }
         
            public bool Estado { get; set; }
        }
        public class CreateValidation : AbstractValidator<Ejecuta>
        {
            /// <summary>
            /// Fluent Validation
            /// </summary>
            public CreateValidation()
            {
                RuleFor(x => x.Id).NotEmpty();
                RuleFor(x => x.PersonaId).NotEmpty();
                RuleFor(x => x.FechaIngreso).NotEmpty();
                RuleFor(x => x.Cargo).NotEmpty();
                RuleFor(x => x.NumeroLicencia).NotEmpty();
                RuleFor(x => x.Estado).NotEmpty();
            }
        }
        /// <summary>
        /// Clase que se encarga de ejecutar el contrato
        /// </summary>
        public class Manejador : IRequestHandler<Ejecuta,EmpleadoDto>
        {
            private readonly IEmpleadoService empleadoService;
            /// <summary>
            /// constructor para injectar las dependencias
            /// </summary>
            /// <param name="_IempleadoService">Service de Empleado</param>
            /// Francisco Rios
            public Manejador(IEmpleadoService _IempleadoService)
             {
                empleadoService = _IempleadoService;
             }
            /// <summary>
            /// Metodo que ejecuta el contrato y devuelve la promesa
            /// </summary>
            /// <param name="request">Clase modelo</param>
            /// <param name="cancellationToken">Hilo de cancelacion de contrato</param>
            /// <returns>Promesa Empleado</returns>
            /// Franciso Rios
            public async Task<EmpleadoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await empleadoService.GetEmpeladoPorIdAsync(request.Id);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Empleado no encontrado" });
                }
                var queryEmpleado = new EmpleadoDto
                {
                    Id = request.Id,
                    PersonaId = request.PersonaId,
                    FechaIngreso = request.FechaIngreso ?? query.FechaIngreso,
                    Cargo = request.Cargo ?? query.Cargo,
                    NumeroLicencia = request.NumeroLicencia ?? query.NumeroLicencia,
                    Foto = request.Foto,
                    Estado = request.Estado
                };
                var valor = await empleadoService.UpdateEmpleadoAsync(queryEmpleado);
                if (valor != null)
                {
                    return valor;
                }
                throw new Exception("error al actualizar");
            }
        }
    }
}
