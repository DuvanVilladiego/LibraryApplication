using Library.BLL.Books.Dtos;

namespace Library.BLL.Books
{
    public interface IBooksServices
    {
        public BaseResponse<List<BooksDto>> GetBooks();
        public BaseResponse<BooksDto> GetABook(int id);
        public BaseResponse<BooksDto> AddBook(BooksDto author);
        public BaseResponse<BooksDto> UpdateBook(BooksDto author);
        public BaseResponse<BooksDto> DeleteBook(BooksDto author);
    }
}
