using System;

namespace MiniAccounting.Models.BaseEntities.Abstract
{
    public interface IModifiableEntity
    {
        int? ModifiedUserID { get; set; }
        DateTime? ModifiedDate { get; set; }
    }
}