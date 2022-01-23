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

        public async Task IssueBookToMemberAsync(int memberid, int bookid)
        {
            var member = await _member.GetMemberByIdAsync(memberid);

            if (member == null)
            {
                return;
            }

            var book = await _book.GetBookByIdAsync(bookid);

            if (book == null)
            {
                return;
            }
            var bookIssue = new BookIssue
            {
                MemberId = memberid,
                BookId = bookid,
                DateOfIssue = DateTime.Now,
            };
            await _context.BookIssues.AddAsync(bookIssue);

            await _context.SaveChangesAsync();
        }

        public async Task ReturnBookAsync(int memberid, int bookid)
        {
            var bookIssue = await _context.BookIssues.FirstOrDefaultAsync(i => i.MemberId == memberid && i.BookId == bookid);

            if (bookIssue == null)
            {
                return;
            }

            bookIssue.IsReturned = true;
            bookIssue.DateOfReturn = DateTime.Now;

            await _context.SaveChangesAsync();
        }
    }
}
