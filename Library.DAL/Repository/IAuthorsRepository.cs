using Library.Entity;

namespace Library.DAL.Repository
{
    public interface IAuthorsRepository
    {
        AuthorTbl GetById(int id);
        List<AuthorTbl> GetAll();
        AuthorTbl Create(AuthorTbl entity);
        AuthorTbl Update(AuthorTbl entity);
        AuthorTbl Delete(AuthorTbl entity);
    }
}
