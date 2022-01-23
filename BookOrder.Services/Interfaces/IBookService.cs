using BookOrder.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookOrder.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateBookAsync(BookModel model);
        Task DeleteBookByIdAsync(int? id);
        Task UpdateBookAsync(BookModel model);
        Task<BookModel> GetBookByIdAsync(int? id);
        Task<List<BookModel>> GetAllAsync();
    }
}
