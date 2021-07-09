using prmToolkit.NotificationPattern;
using System;

namespace VemDeZap.Domain.Entities.Base
{
    // Cria um ID para todas a classes, dessa forma não fica repetindo ID
    public abstract class EntityBase : Notifiable
    {
        protected EntityBase()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
    }
}
