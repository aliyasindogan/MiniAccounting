namespace MiniAccounting.Models.BaseEntities.Abstract
{
    public interface IDisplayEntity
    {
        int DisplayOrder { get; set; }
        bool IsDisplay { get; set; }
    }
}