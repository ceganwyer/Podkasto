using System;

namespace Podkasto.Models
{
    public class Category : IEntity
    {
        #region Properties

        public Guid ID { get; init;  }
        public string Genre { get; init; } = string.Empty;

        #endregion
    }
}