using MiniAccounting.Models.BaseEntities.Abstract;
using System;

namespace MiniAccounting.Models.BaseEntities.Concrete
{
    public class CreatedEntity : IBaseEntity, ICreatedEntity
    {
        public int Id { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}