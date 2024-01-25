using Library.BLL.Books.Dtos;

namespace Library.BLL.Books
{
    public interface IBooksServices
    {
        public BaseResponse<List<BookDto>> GetBooks();
        public BaseResponse<BookDto> GetABook(int id);
        public BaseResponse<BookDto> AddBook(BookDto author);
        public BaseResponse<BookDto> UpdateBook(BookDto author);
        public BaseResponse<BookDto> DeleteBook(BookDto author);
    }
}
