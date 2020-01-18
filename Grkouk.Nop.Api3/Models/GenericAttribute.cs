namespace Grkouk.Nop.Api3.Models
{
    public partial class GenericAttribute
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string KeyGroup { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int StoreId { get; set; }
    }
}
