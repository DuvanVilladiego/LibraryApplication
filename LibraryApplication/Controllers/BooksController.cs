using Microsoft.AspNetCore.Mvc;
using Library.BLL;
using Library.BLL.Books;
using Library.BLL.Books.Dtos;
using Library.BLL.Books.Implementation;
using Library.BLL.Authors.Dtos;
using Library.BLL.Authors.Implementation;
using Library.BLL.Authors;
using Azure;

namespace LibraryApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private IAuthorsServices authorsServices = new AuthorsServices();
        private IBooksServices booksServices = new BooksServices();
        private readonly ILogger<AuthorsController> _logger;

        public BooksController(ILogger<AuthorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            BaseResponse<List<BookDto>> response = booksServices.GetBooks();
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetABook(string id)
        {
            BaseResponse<BookDto> response = booksServices.GetABook(Int32.Parse(id));
            return response.Status ? Ok(response) : BadRequest(response);
        }

        [HttpPost]
        [Route("addBook")]
        public IActionResult AddBook([FromBody] BookDto book)
        {
            BaseResponse<AuthorDTO> authorResponse = authorsServices.GetAnAuthor(book.AuthorId);
            if (authorResponse.Status)
            {
                BaseResponse<BookDto> response = booksServices.AddBook(book);
                return response.Status ? Ok(response) : BadRequest(response);
            }
            else
            {
                return BadRequest(authorResponse);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateBook([FromBody] BookDto book)
        {
            BaseResponse<BookDto> bookResponse = booksServices.GetABook(book.BookId);
            if (bookResponse.Status)
            {
                BaseResponse<BookDto> response = booksServices.UpdateBook(book);
                return response.Status ? Ok(response) : BadRequest(response);
            }
            else
            {
                return BadRequest(bookResponse);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteBook([FromBody] BookDto book)
        {
            BaseResponse<BookDto> bookResponse = booksServices.GetABook(book.BookId);
            if (bookResponse.Status)
            {
                BaseResponse<BookDto> response = booksServices.DeleteBook(book);
                return response.Status ? Ok(response) : BadRequest(response);
            }
            else
            {
                return BadRequest(bookResponse);
            }
        }
    }
}
