using System;
using System.Collections.Generic;
using System.Text;

namespace BookOrder.Entities
{
    public class Member
    {
        public int Id { get; set; }

        public Guid AccountId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; }

        public string Address { get; set; }

        public string Phne { get; set; }

        public string Email { get; set; }

        public int CurrentBookId { get; set; }

        public List<Book> Book { get; set; }
    }
}