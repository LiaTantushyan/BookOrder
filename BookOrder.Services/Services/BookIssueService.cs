using BookOrder.Services.Connection;
using BookOrder.Services.Entities;
using BookOrder.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrder.Services.Services
{
    public class BookIssueService : IBookIssueService
    {
        private readonly ApplicationContext _context;
        private readonly IBookService _book;
        private readonly IMemberService _member;

        public BookIssueService(ApplicationContext context, IBookService book, IMemberService member)
        {
            _context = context;
            _book = book;
            _member = member;
        }

        public async Task BookToMember(int memberid, int bookid)
        {
            var member = await _member.GetMemberByIdAsync(memberid);
            var book = await _book.GetBookByIdAsync(bookid);

            if (member != null && book != null)
            {
                var bookIssue = new BookIssue
                {
                    MemberId = memberid,
                    BookId = bookid,
                    DateOfIssue = DateTime.Now,
                };
                await _context.BookIssues.AddAsync(bookIssue);

                await _context.SaveChangesAsync();
            }
        }
    }
}
