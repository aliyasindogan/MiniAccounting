using System;

namespace MiniAccounting.Models.BaseEntities.Abstract
{
    public interface ICreatedEntity
    {
        int CreatedUserID { get; set; }
        DateTime CreatedDate { get; set; }
    }
}