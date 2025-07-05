using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Domain.Entities
{
    public class Lot
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Price { get; set; }

        public int AuctionId { get; set; }

        [MaxLength(255)]
        public string LotNo { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string URL { get; set; }

        [Required]
        public int SourceId { get; set; }

        public Auction Auction { get; set; }
    }
}
