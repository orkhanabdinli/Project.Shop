namespace Shop.Core.Abstract;

public abstract class BaseEntities
{
    public DateTime CreatedDate { get; set; }
    public DateTime LastModifiedDate { get; set;}
    public bool? IsActive { get; set; } 
}
