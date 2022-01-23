using BookOrder.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookOrder.Api.Controllers
{
    public class BookIssueController : Controller
    {
        private readonly IBookIssueService _issue;
        public BookIssueController(IBookIssueService issue)
        {
            _issue = issue;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookIssue(int? memberid, int? bookid)
        {
            if (!memberid.HasValue || !bookid.HasValue)
            {
                return Json("Invalid Id");
            }
            await _issue.IssueBookToMemberAsync((int)memberid, (int)bookid);

            return Json(new { success = true });
        }

        [HttpPost]
        public async Task<IActionResult> ReturnBook(int? memberid, int? bookid)
        {
            if (!memberid.HasValue || !bookid.HasValue)
            {
                return Json("Invalid Id");
            }
            await _issue.ReturnBookAsync((int)memberid, (int)bookid);

            return Json(new { success = true });
        }
    }
}
