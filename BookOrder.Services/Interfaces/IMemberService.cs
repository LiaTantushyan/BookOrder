using BookOrder.Services.Entities;
using BookOrder.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrder.Services.Interfaces
{
    public interface IMemberService
    {
        Task CreateMemberAsync(MemberModel model);
        Task DeleteMemberByIdAsync(int? id);
        Task UpdateMemberAsync(MemberModel model);
        Task<MemberModel> GetMemberByIdAsync(int id);
        Task<List<MemberModel>> GetAllAsync();
        Task<List<Book>> GetMemberBooksHistoryAsync(int memberid);
        Task<Book> GetMembersCurrentBook(int memberid);
    }
}
