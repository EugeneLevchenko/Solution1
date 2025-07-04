using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Domain.Entities
{
   

    public class Auction
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The name field is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Source field is required.")]
        public int SourceId { get; set; }
        public Status Status { get; set; }
    }
    public enum Status
    {
        Pending,
        Deleted
    }
}
