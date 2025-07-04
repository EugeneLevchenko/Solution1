using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain.Entities
{
    public class Lot
    {
        public int Id { get; set; }
        public int AuctionId { get; set; }
        public string LotNo { get; set; }
        public decimal? Price { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
        public Auction Auction { get; set; }
    }
}
