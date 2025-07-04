using ClassLibrary1.Core.Enums;

namespace ClassLibrary1.Domain.Entities
{
    public class Auction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SourceId { get; set; }
        public Status Status { get; set; }
    }
}