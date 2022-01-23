using BookOrder.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrder.Services.Interfaces
{
    public interface IBookIssueService
    {
        Task IssueBookToMemberAsync(int memberid, int bookid);
        Task ReturnBookAsync(int memberid, int bookid);
    }
}
