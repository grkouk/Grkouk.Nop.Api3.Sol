namespace Grkouk.Nop.Api3.Models
{
    public partial class PermissionRecordRoleMapping
    {
        public int PermissionRecordId { get; set; }
        public int CustomerRoleId { get; set; }

        public virtual CustomerRole CustomerRole { get; set; }
        public virtual PermissionRecord PermissionRecord { get; set; }
    }
}
