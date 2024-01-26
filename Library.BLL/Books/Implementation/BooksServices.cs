using Library.BLL.Books.Dtos;
using Library.DAL.Repository;
using Library.Entity;

namespace Library.BLL.Books.Implementation
{
    public class BooksServices : IBooksServices
    {
        private readonly IBooksRepository repository;

        public BooksServices(IBooksRepository repository)
        {
            this.repository = repository;
        }

        public BaseResponse<BookDto> AddBook(BookDto book)
        {
            BaseResponse<BookDto> response = new BaseResponse<BookDto>();
            try
            {
                BookTbl newBook = repository.Create(transformToEntity(book));
                if (newBook != null)
                {
                    response.Status = true;
                    response.Message = Constants.Messages.SuccessMessage;
                }
                else
                {
                    response.Status = false;
                    response.Message = Constants.Messages.ErrorMessage;
                }
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = Constants.Messages.ErrorMessage;
            }
            return response;
        }

        public BaseResponse<List<BookDto>> GetBooks()
        {
            BaseResponse<List<BookDto>> response = new BaseResponse<List<BookDto>>();
            try
            {
                List<BookTbl> booksEntity = repository.GetAll();
                if (booksEntity.Count > 0)
                {
                    List<BookDto> booksDTOs = new List<BookDto>();
                    foreach (var bookEntity in booksEntity)
                    {
                        BookDto authorDTO = transformToDto(bookEntity);
                        booksDTOs.Add(authorDTO);
                    }
                    response.Data = booksDTOs;
                }
                else
                {
                    response.Data = new List<BookDto>();
                }
                response.Status = true;
                response.Message = Constants.Messages.SuccessMessage;
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = Constants.Messages.ErrorMessage;
            }
            return response;
        }

        public BaseResponse<BookDto> GetABook(int id)
        {
            BaseResponse<BookDto> response = new BaseResponse<BookDto>();
            try
            {
                BookTbl book = repository.GetById(id);
                if (book != null)
                {
                    response.Status = true;
                    response.Message = Constants.Messages.SuccessMessage;
                    response.Data = transformToDto(book); ;
                }
                else
                {
                    response.Status = false;
                    response.Message = Constants.Messages.NoFoundBookItems;
                }
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = Constants.Messages.ErrorMessage;
            }
            return response;
        }

        public BaseResponse<BookDto> UpdateBook(BookDto book)
        {
            BaseResponse<BookDto> response = new BaseResponse<BookDto>();
            try
            {
                BookTbl updateBook = repository.Update(transformToEntity(book));
                response.Status = true;
                response.Message = Constants.Messages.SuccessMessage;
                response.Data = transformToDto(updateBook);
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = Constants.Messages.ErrorMessage;
            }
            return response;
        }

        public BaseResponse<BookDto> DeleteBook(BookDto book)
        {
            BaseResponse<BookDto> response = new BaseResponse<BookDto>();
            try
            {
                BookTbl deletedBook = repository.Delete(transformToEntity(book));
                response.Status = true;
                response.Message = Constants.Messages.SuccessMessage;
                response.Data = transformToDto(deletedBook);
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = Constants.Messages.ErrorMessage;
            }
            return response;
        }

        private BookDto transformToDto(BookTbl entity)
        {
            BookDto dto = new BookDto();
            dto.BookId = entity.BookId;
            dto.Title = entity.Title;
            dto.YearPublished = entity.YearPublished;
            dto.Genre = entity.Genre;
            dto.NumPages = entity.NumPages;
            dto.AuthorId = entity.AuthorId;
            dto.FrontPage = entity.FrontPage;
            return dto;
        }

        private BookTbl transformToEntity(BookDto dto)
        {
            BookTbl entity = new BookTbl();
            entity.BookId = dto.BookId;
            entity.Title = dto.Title;
            entity.YearPublished = dto.YearPublished;
            entity.Genre = dto.Genre;
            entity.NumPages = dto.NumPages;
            entity.AuthorId = dto.AuthorId;
            entity.FrontPage = dto.FrontPage;
            return entity;
        }

    }
}
