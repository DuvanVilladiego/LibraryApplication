using Library.Entity;

namespace Library.DAL.Repository
{
    public interface IBooksRepository
    {
        BookTbl GetById(int id);
        List<BookTbl> GetAll();
        BookTbl Create(BookTbl entity);
        BookTbl Update(BookTbl entity);
        BookTbl Delete(BookTbl entity);
    }
}
