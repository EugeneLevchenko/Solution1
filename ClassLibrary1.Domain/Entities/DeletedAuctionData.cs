using System.ComponentModel.DataAnnotations;

namespace ClassLibrary1.Domain.Entities
{
    public class DeletedAuctionData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OriginalId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int SourceId { get; set; }

        [Required]
        public DateTime DeletedAt { get; set; }

        public bool IsRecovered { get; set; }
    }
}
