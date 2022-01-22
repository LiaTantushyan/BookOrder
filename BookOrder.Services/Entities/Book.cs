using System;
using System.Collections.Generic;
using System.Text;

namespace BookOrder.Entities
{
    public class Book
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public int GenreId { get; set; }

        public Genre Genre { get; set; }

        public int PageCounts { get; set; }

        public string Author { get; set; }

        public bool IsAvailable { get; set; }
    }
}
