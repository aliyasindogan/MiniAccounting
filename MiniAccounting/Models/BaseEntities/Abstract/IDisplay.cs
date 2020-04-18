namespace MiniAccounting.Models.BaseEntities.Abstract
{
    public interface IDisplay
    {
        bool IsDisplay { get; set; }
        int DisplayOrder { get; set; }
    }
}