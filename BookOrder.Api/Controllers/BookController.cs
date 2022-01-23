using BookOrder.Services.Interfaces;
using BookOrder.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOrder.Api.Controllers
{
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _book;

        public BookController(IBookService book)
        {
            _book = book;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            await _book.CreateBookAsync(model);
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> GetBookById(int? id)
        {
            if (!id.HasValue)
            {
                return Json(new { Success = false, Message = "Id is null" });
            }
            var mem = await _book.GetBookByIdAsync(id);
            return Json(mem);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMemberById(int? id)
        {
            if (!id.HasValue)
            {
                return Json(new { Success = false, Message = "Id is null" });
            }
            await _book.DeleteBookByIdAsync(id);
            return Json(new { message = "Selected member was deleted" });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMember()
        {
            var members = await _book.GetAllAsync();
            return Json(members);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateMember([FromBody] BookModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _book.UpdateBookAsync(model);
                return Json(new { Success = true });
            }
            catch (Exception e)
            {
                return Json(new { Success = false, Data = model, Message = e.Message });
            }
        }
    }
}
