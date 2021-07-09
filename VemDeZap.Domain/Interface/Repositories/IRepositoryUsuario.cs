using System;
using VemDeZap.Domain.Entities;
using VemDeZap.Domain.Interface.Repositories.Base;

namespace VemDeZap.Domain.Interface.Repositories
{
    public interface IRepositoryUsuario : IRepositoryBase<Usuario, Guid>
    {
    }
}
