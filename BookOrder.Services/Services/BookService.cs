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
    public class BookService : IBookService
    {
        public readonly ApplicationContext _context;
        public BookService(ApplicationContext context)
        {
            _context = context;
        }
        public async Task CreateBookAsync(BookModel model)
        {
            var book = new Book
            {
                Name = model.Name,
                GenreId = model.GenreId,
                PageCounts = model.PageCounts,
                Author = model.Author,
                IsAvailable = model.IsAvailable,
                InStockCount = model.InStockCount
            };
            await _context.Books.AddAsync(book);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookByIdAsync(int? id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(i => i.Id == id);

            if (book != null)
            {
                _context.Books.Remove(book);

                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<BookModel>> GetAllAsync()
        {
            return await _context.Books.Select(book => new BookModel
            {
                Name = book.Name,
                GenreId = book.GenreId,
                PageCounts = book.PageCounts,
                Author = book.Author,
                IsAvailable = book.IsAvailable,
                InStockCount = book.InStockCount
            }).ToListAsync();
        }

        public async Task<BookModel> GetBookByIdAsync(int? id)
        {
            var book = await _context.Books.FirstOrDefaultAsync(i => i.Id == id);
            if (book == null)
            {
                return null;
            }
            return new BookModel
            {
                Name = book.Name,
                GenreId = book.GenreId,
                PageCounts = book.PageCounts,
                Author = book.Author,
                IsAvailable = book.IsAvailable,
                InStockCount = book.InStockCount
            };
        }

        public async Task UpdateBookAsync(BookModel model)
        {
            var book = await _context.Books.FirstOrDefaultAsync(i => i.Id == model.Id);
            if (book == null)
            {
                throw new Exception("Not found any book");
            }
            book.Name = model.Name;
            book.GenreId = model.GenreId;
            book.PageCounts = model.PageCounts;
            book.Author = model.Author;
            book.InStockCount = model.InStockCount;
            book.IsAvailable = model.IsAvailable;

            await _context.SaveChangesAsync();
        }
    }
}
