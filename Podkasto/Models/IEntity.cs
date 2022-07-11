using System;

namespace Podkasto.Models
{
    public interface IEntity
    {
        Guid ID { get; init; }
    }
}