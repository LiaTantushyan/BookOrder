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
        public MemberModel CreateMember();
        public Task DeleteMember(int id);
        public Task UpdateMember(int id);
        public MemberModel GetMemberById(int id);
        public Task<List<MemberModel>> GetAllAsync();
    }
}
