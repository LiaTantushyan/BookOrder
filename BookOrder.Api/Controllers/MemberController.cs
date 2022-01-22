using BookOrder.Services.Interfaces;
using BookOrder.Services.Models;
using BookOrder.Services.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOrder.Api.Controllers
{
    [ApiController]
    public class MemberController : Controller
    {
        private readonly IMemberService _member;

        public MemberController(IMemberService member)
        {
            _member = member;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _member.CreateMemberAsync(model);
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberById(int? id)
        {
            if (!id.HasValue)
            {
                return Json(new { Success = false, Message = "Id is null" });
            }
            var mem = await _member.GetMemberByIdAsync(id);
            return Json(mem);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMemberById(int? id)
        {
            if (!id.HasValue)
            {
                return Json(new { Success = false, Message = "Id is null" });
            }
            await _member.DeleteMemberByIdAsync(id);
            return Json(new { message="Selected member was deleted"});
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMember()
        {
            var members = await _member.GetAllAsync();
            return Json(members);
        }
    }
}
