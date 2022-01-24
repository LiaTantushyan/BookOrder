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
            var mem = await _member.GetMemberByIdAsync(id.Value);
            return Json(mem);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMemberById(int? id)
        {
            if (!id.HasValue)
            {
                return Json(new { Success = false, Message = "Id is null" });
            }
            await _member.DeleteMemberByIdAsync(id.Value);
            return Json(new { message = "Selected member was deleted" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMember()
        {
            var members = await _member.GetAllAsync();
            return Json(members);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMember([FromBody] MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _member.UpdateMemberAsync(model);
                return Json(new { Success = true });
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Data = model, Message = e.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetMembersCurrentBook(int? id)
        {
            if (!id.HasValue)
            {
                return Json(new { Success = false, Message = "Id is null" });
            }
            var book = await _member.GetMembersCurrentBookAsync(id.Value);
            return Json(book);
        }

        [HttpGet]
        public async Task<IActionResult> GetMemberBooksHistory(int? id)
        {
            if (!id.HasValue)
            {
                return Json(new { Success = false, Message = "Id is null" });
            }
            var book = await _member.GetMemberBooksHistoryAsync(id.Value);
            return Json(book);
        }
    }
}
