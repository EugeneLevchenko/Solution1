using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain.Entities
{
    public class DeletedAuctionData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int OriginalId { get; set; } // Оригинальный Id аукциона

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public int SourceId { get; set; }

        [Required]
        public DateTime DeletedAt { get; set; }

        public bool IsRecovered { get; set; } // Флаг для отслеживания восстановления
    }
}
