namespace RedForums.Data.Common.Models
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }

        DateTime? LastModifiedOn { get; set; }
    }
}
