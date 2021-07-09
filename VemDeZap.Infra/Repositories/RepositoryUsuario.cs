using System;
using VemDeZap.Domain.Entities;
using VemDeZap.Domain.Interface.Repositories;
using VemDeZap.Infra.Repositories.Base;

namespace VemDeZap.Infra.Repositories
{
    public class RespositoryUsuario : RepositoryBase<Usuario, Guid>, IRepositoryUsuario
    {
        private readonly VemDeZapContext _context;
        public RespositoryUsuario(VemDeZapContext context) : base(context)
        {
            _context = context;
        }
    }
}
