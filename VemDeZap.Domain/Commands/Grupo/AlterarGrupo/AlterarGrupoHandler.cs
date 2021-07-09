using MediatR;
using prmToolkit.NotificationPattern;
using System.Threading;
using System.Threading.Tasks;
using VemDeZap.Domain.Commands.Grupo.AdicionarGrupo;
using VemDeZap.Domain.Interface.Repositories;

namespace VemDeZap.Domain.Commands.Grupo.AlterarGrupo
{
    public class AlterarGrupoHandler : Notifiable, IRequestHandler<AlterarGrupoRequest, Response>
    {
        private readonly IMediator _mediator;
        private readonly IRepositoryGrupo _repositoryGrupo;
        private readonly IRepositoryUsuario _repositoryUsuario;

        public AlterarGrupoHandler(IMediator mediator, IRepositoryGrupo repositoryGrupo, IRepositoryUsuario repositoryUsuario)
        {
            _mediator = mediator;
            _repositoryGrupo = repositoryGrupo;
            _repositoryUsuario = repositoryUsuario;
        }

        public async Task<Response> Handle(AlterarGrupoRequest request, CancellationToken cancellationToken)
        {
            //Validar se o requeste veio preenchido
            if (request == null)
            {
                AddNotification("Resquest", "Informe os dados do Grupo.");

                return new Response(this);
            }

            var usuario = _repositoryUsuario.ObterPorId(request.IdUsuario.Value);


            if (usuario == null)
            {
                AddNotification("Usuario", "Informe o Usuario.");
                return new Response(this);
            }


            Entities.Grupo grupo = _repositoryGrupo.ObterPorId(request.Id);

            grupo.AlterarGrupo(request.Nome, request.Nicho);

            if (grupo == null)
            {
                AddNotification("Grupo", "Informe o grupo.");
                return new Response(this);
            }

            grupo = _repositoryGrupo.Editar(grupo);

            var result = new { Id = grupo.Id, Nome = grupo.Nome, Nicho = grupo.Nicho };

            //Criar meu objeto de resposta
            var response = new Response(this, result);

            return await Task.FromResult(response);
        }
    }
}
