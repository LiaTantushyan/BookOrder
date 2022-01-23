using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrder.Services.Entities
{
    public class BookIssue
    {
        [Key]
		public int Id { get; set; }

        [Required]
		public int MemberId { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public DateTime DateOfIssue { get; set; }

        public DateTime? DateOfReturn { get; set; }

        public bool? IsReturned { get; set; }
    }
}
