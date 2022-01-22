using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookOrder.Entities
{
    public class Member
    {
        [Key]
        public int Id { get; set; }
        public Guid AccountId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public Genders Gender { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }

        public string Email { get; set; }

        public List<Book> Book { get; set; }
    }
}