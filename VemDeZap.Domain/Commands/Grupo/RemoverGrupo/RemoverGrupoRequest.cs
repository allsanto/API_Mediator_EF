using MediatR;
using System;

namespace VemDeZap.Domain.Commands.Grupo.RemoverGrupo
{
    public class RemoverGrupoRequest : IRequest<Response>
    {
        public Guid Id { get; set; }

        public RemoverGrupoRequest(Guid id)
        {
            Id = id;
        }
    }
}
