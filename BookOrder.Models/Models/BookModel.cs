using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrder.Services.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        public int PageCounts { get; set; }

        public string Author { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public int InStockCount { get; set; }
    }
}
