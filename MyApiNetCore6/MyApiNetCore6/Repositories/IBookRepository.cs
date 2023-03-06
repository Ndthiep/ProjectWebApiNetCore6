using MyApiNetCore6.Data;
using MyApiNetCore6.Models;

namespace MyApiNetCore6.Repositories
{
    public interface IBookRepository
    {
        public Task<List<BookModels>> getAllBookAsync();

        public Task<BookModels> getBookByIdAsync(int id);

        public Task<int> AddBookAsync(BookModels model);

        public Task UpdateBookAsync(int id, BookModels model);

        public Task DeleteBookAsync(int id);

    }
}
