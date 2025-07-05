namespace ClassLibrary1.Core.DTO
{
    public class Lot
    {
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public int SourceId { get; set; }
        public string LotNo { get; set; }
        public decimal Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public int? PrevLotId { get; set; }
        public int? NextLotId { get; set; }
    }
}
