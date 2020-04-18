using MiniAccounting.Models.BaseEntities.Abstract;
using System;

namespace MiniAccounting.Models.BaseEntities.Concrete
{
    public class ModifiableEntity : IBaseEntity, IModifiableEntity
    {
        public int Id { get; set; }

        public int? ModifiedUserID { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}