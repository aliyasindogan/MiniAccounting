using MiniAccounting.Models.BaseEntities.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace MiniAccounting.Models.BaseEntities.Concrete
{
    public class AuditEntity : IBaseEntity, ICreatedEntity, IModifiableEntity, IDisplay
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Kaydeden Kullanıcı")]
        public int CreatedUserID { get; set; }

        [Display(Name = "Kayıt Tarihi")]
        public DateTime CreatedDate { get; set; }

        [Display(Name = "Düzenleme Kullanıcı")]
        public int? ModifiedUserID { get; set; }

        [Display(Name = "Düzenleme Tarihi")]
        public DateTime? ModifiedDate { get; set; }

        [Display(Name = "Görünsün Mü?")]
        public bool IsDisplay { get; set; }

        [Display(Name = "Sıra No")]
        public int DisplayOrder { get; set; }
    }
}