using Library.DAL.DBContext;
using Library.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repository.Implementation
{
    internal class BooksRepository : IBooksRepository
    {
        public BooksRepository(LibrarydbContext dbContext)
        {
            options = new DbContextOptionsBuilder<LibrarydbContext>().UseSqlServer("Server=localhost;Database=LIBRARYDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False").Options;
            _dbContext = new LibrarydbContext(options);
        }
        private readonly DbContextOptions<LibrarydbContext> options;
        private readonly LibrarydbContext _dbContext;

        public List<BookTbl> GetAll()
        {
            try
            {
                return _dbContext.BookTbls.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BookTbl Create(BookTbl entity)
        {
            try
            {
                BookTbl response = _dbContext.Set<BookTbl>().Add(entity).Entity;
                _dbContext.SaveChangesAsync();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public BookTbl GetById(int id)
        {
            try
            {
                return _dbContext.Set<BookTbl>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BookTbl Update(BookTbl entity)
        {
            try
            {
                return _dbContext.Set<BookTbl>().Update(entity).Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public BookTbl Delete(BookTbl entity)
        {
            try
            {
                return _dbContext.Set<BookTbl>().Remove(entity).Entity;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
