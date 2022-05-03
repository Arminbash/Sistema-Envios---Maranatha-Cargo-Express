using _3._1.MCargoExpress.Dtos;
using _3._3.MCargoExpress.Interfaces.IRepositoryModels;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _5._1.MCargoExpress.CRUD.Commands.TipoPersona.Empleado
{
    /// <summary>
    /// Mediador para Crear Empleado
    /// </summary>
    /// Francisco Rios
    public class CreateEmpleado 
    {
        /// <summary>
        /// Parametros para el contrato
        /// </summary>
        public class Ejecuta : IRequest<EmpleadoDto>
        {
            public int PersonaId { get; set; }
         
            public DateTime? FechaIngreso { get; set; }
         
            public string Cargo { get; set; }
        
            public string NumeroLicencia { get; set; }
          
            public byte Foto { get; set; }
        }
        /// <summary>
        /// Fluent Validation
        /// </summary>
        public class CreateValidation : AbstractValidator<Ejecuta>
        {
            public CreateValidation()
            {
                RuleFor(x => x.PersonaId).NotEmpty();
                RuleFor(x => x.FechaIngreso).NotEmpty();
                RuleFor(x => x.Cargo).NotEmpty();
                RuleFor(x => x.NumeroLicencia).NotEmpty();
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
            /// <param name="_IempleadoService">Service de empleado</param>
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
            /// <returns></returns>
            /// Franciso Rios
            public async Task<EmpleadoDto> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = new EmpleadoDto
                {
                    PersonaId = request.PersonaId,
                    FechaIngreso = request.FechaIngreso,
                    Cargo = request.Cargo,
                    NumeroLicencia = request.NumeroLicencia,
                    Foto = request.Foto,
                    Estado = true
                };
                var valor = await empleadoService.AddEmpledoAsync(query);
                if (valor != null)
                {
                    return valor;
                }
                throw new Exception("No se logro ingresar el empleado");
            }
        }
    }
}
