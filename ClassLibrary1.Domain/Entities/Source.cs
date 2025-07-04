namespace ClassLibrary1.Domain.Entities
{
    public class Source
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
        public List<Auction> Auctions { get; set; } = new List<Auction>();
    }
}
