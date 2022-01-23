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
        Task BookToMember(int memberid, int bookid);
    }
}
