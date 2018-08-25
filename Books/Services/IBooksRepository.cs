using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Services
{
    public interface IBooksRepository
    {
        Task<IEnumerable<Entities.Book>> GetBooksAsync();

        Task<Entities.Book> GetBookAsync(Guid id);
    }
}
