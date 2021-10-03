using _2._2.MCargoExpress.Persistence.Settings;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using _1.MCargoExpress.Domain;

namespace _5._1.MCargoExpress.CRUD.Commands.TipoPersonaM
{
    public class CreateTipoPersona
    {
        public class Ejecuta : IRequest
        {
            public string Tipo { get; set; }
            public bool Estatus { get; set; }
        }
        public class CreateValidacion : AbstractValidator<Ejecuta>
        {
            public CreateValidacion()
            {
                RuleFor(x => x.Tipo).NotEmpty();
            }
        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly IConexion _context;

            public Manejador(IConexion context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var query = new TipoPersona

                {
                    Tipo = request.Tipo,
                    Estado = request.Estatus

                };
                _context.TipoPersona.Add(query);
                var valor = await _context.SaveChangesAsync();
                if (valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No crear el tipo persona");
            }
        }
    }
}
