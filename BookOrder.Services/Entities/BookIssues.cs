using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrder.Services.Entities
{
    public class BookIssues
    {
        public int MemberId { get; set; }
        public int BookId { get; set; }
        [Required]
        public DateTime DateOfIssue { get; set; }
    }
}
