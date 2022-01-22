using BookOrder.Services.Connection;
using BookOrder.Services.Entities;
using BookOrder.Services.Interfaces;
using BookOrder.Services.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrder.Services.Services
{
    public class MemberService : IMemberService
    {
        private readonly ApplicationContext _context;

        public MemberService()
        {

        } 

        public MemberService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateMemberAsync(MemberModel model)
        {
            var member = new Member
            {
                Name = model.Name,
                Surname = model.Surname,
                Address = model.Address,
                Birthdate = model.Birthdate,
                Email = model.Email,
                Phone = model.Phone,
                Gender = model.Gender,
            };
            await _context.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMemberByIdAsync(int? id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(i => i.Id == id);

            if (member != null)
            {
                _context.Members.Remove(member);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<MemberModel>> GetAllAsync()
        {
            return await _context.Members.Select(member => new MemberModel
            {
                Name = member.Name,
                Surname = member.Surname,
                Address = member.Address,
                Birthdate = member.Birthdate,
                Email = member.Email,
                Phone = member.Phone,
                Gender = member.Gender,
            }).ToListAsync();
        }
        public async Task<MemberModel> GetMemberByIdAsync(int? id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(i => i.Id == id);
            if (member == null)
            {
                return null;
            }
            return new MemberModel
            {
                Name = member.Name,
                Surname = member.Surname,
                Address = member.Address,
                Birthdate = member.Birthdate,
                Email = member.Email,
                Phone = member.Phone,
                Gender = member.Gender,
            };
        }

        public async Task UpdateMemberAsync(MemberModel model)
        {
            var member = await _context.Members.FirstOrDefaultAsync(i => i.Id == model.Id);
            if (member == null)
            {
                throw new Exception("Member not found");
            }
            member.Name = model.Name;
            member.Surname = model.Surname;
            member.Address = model.Address;
            member.Birthdate = model.Birthdate;
            member.Email = model.Email;
            member.Phone = model.Phone;
            member.Gender = model.Gender;

            await _context.SaveChangesAsync();
        }
    }
}
