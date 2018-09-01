using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Contexts;
using Books.Entities;
using Microsoft.EntityFrameworkCore;

namespace Books.Services
{
    /// <summary>
    /// The Books Repository.
    /// </summary>
    public class BooksRepository : IBooksRepository, IDisposable
    {
        private BooksContext _context;

        public BooksRepository(BooksContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        /// <summary>
        /// Get one book by id in an async fashion.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        /// <summary>
        /// Get a list of books in an async fashion.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            _context.Database.ExecuteSqlCommand("WAITFOR DELAY '00:00:02';");
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }

        /// <summary>
        /// Get a list of books.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Book> GetBooks()
        {
            _context.Database.ExecuteSqlCommand("WAITFOR DELAY '00:00:02';");
            return _context.Books.Include(b => b.Author).ToList();
        }

        /// <summary>
        /// Add a book.
        /// </summary>
        /// <param name="bookToAdd"></param>
        /// <returns></returns>
        public void AddBook(Book bookToAdd)
        {
            if (bookToAdd == null)
            {
                throw new ArgumentNullException(nameof(bookToAdd));
            }

            _context.Add(bookToAdd);
        }

        /// <summary>
        /// Save changes in an async fashion.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed.
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            // tell the GC that we are all cleaned up.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
