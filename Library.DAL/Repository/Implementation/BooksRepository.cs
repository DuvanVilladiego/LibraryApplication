using Library.DAL.DBContext;
using Library.Entity;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Repository.Implementation
{
    public class BooksRepository : IBooksRepository
    {
        private readonly DbContextOptions<LibrarydbContext> options;
        private readonly LibrarydbContext _dbContext;
        public BooksRepository()
        {
            options = new DbContextOptionsBuilder<LibrarydbContext>().UseSqlServer("Server=localhost;Database=LIBRARYDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False").Options;
            _dbContext = new LibrarydbContext(options);
        }

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
            BookTbl response = _dbContext.Set<BookTbl>().Add(entity).Entity;
            _dbContext.SaveChangesAsync();
            return response;

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
                BookTbl update = _dbContext.Set<BookTbl>().Update(entity).Entity;
                _dbContext.SaveChangesAsync();
                return update;
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
                BookTbl deleted = _dbContext.Set<BookTbl>().Remove(entity).Entity;
                _dbContext.SaveChangesAsync();
                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
