using Library.DAL.DBContext;
using Library.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace Library.DAL.Repository.Implementation
{
    public class AuthorsRepository : IAuthorsRepository
    {
        private readonly DbContextOptions<LibrarydbContext> options;
        private readonly LibrarydbContext _dbContext;

        public AuthorsRepository()
        {
            options = new DbContextOptionsBuilder<LibrarydbContext>().UseSqlServer("Server=localhost;Database=LIBRARYDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False").Options;
            _dbContext = new LibrarydbContext(options);
        }

        public List<AuthorTbl> GetAll()
        {
            try
            {
                return _dbContext.AuthorTbls.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AuthorTbl Create(AuthorTbl entity)
        {
            try
            {
                AuthorTbl response = _dbContext.Set<AuthorTbl>().Add(entity).Entity;
                _dbContext.SaveChangesAsync();
                return response;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public AuthorTbl GetById(int id)
        {
            try
            {
                return _dbContext.Set<AuthorTbl>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AuthorTbl Update(AuthorTbl entity)
        {
            try
            {
                AuthorTbl update = _dbContext.Set<AuthorTbl>().Update(entity).Entity;
                _dbContext.SaveChanges();
                return update;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AuthorTbl Delete(AuthorTbl entity)
        {
            try
            {
                AuthorTbl deleted = _dbContext.Set<AuthorTbl>().Remove(entity).Entity;
                _dbContext.SaveChanges();
                return deleted;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
