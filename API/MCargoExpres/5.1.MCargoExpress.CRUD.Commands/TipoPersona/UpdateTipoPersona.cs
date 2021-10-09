using _2._2.MCargoExpress.Persistence.Settings;
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

namespace _5._1.MCargoExpress.CRUD.Commands._TipoPersona
{
   public class UpdateTipoPersona
    {
        public class Ejecuta :IRequest
        {
            public int Id{ get; set; }
            public string Tipo { get; set; }
            public bool? Estado { get; set; }
        }
        public class CreateValidation : AbstractValidator<Ejecuta>
        {
            public CreateValidation()
            {
                RuleFor(x => x.Tipo).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IConexion _context;

            public Manejador(IConexion conexion)
            {
                _context = conexion;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = await _context.TipoPersona.FindAsync(request.Id);
                if (query == null)
                {
                    throw new ExceptionBase(HttpStatusCode.BadRequest, new { Mensaje = "Error al editar el tipo persona" });
                }
                query.Tipo = request.Tipo ?? query.Tipo;
                query.Estado = request.Estado ?? query.Estado;
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("errror al acutalizar");
            }
        }

    }
}
