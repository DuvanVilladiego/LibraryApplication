using Microsoft.AspNetCore.Mvc;
using Library.BLL;
using Library.BLL.Books;
using Library.BLL.Books.Dtos;
using Library.BLL.Books.Implementation;
using Library.BLL.Authors.Dtos;
using Library.BLL.Authors.Implementation;
using Library.BLL.Authors;
using Library.DAL.Repository.Implementation;
using Library.IOC;

namespace LibraryApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private IAuthorsServices authorsServices = new AuthorsServices(new AuthorsRepository());
        private IBooksServices booksServices = new BooksServices(new BooksRepository());
        private LogUtilities<BooksController> _logUtilities;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
            _logUtilities = new LogUtilities<BooksController>(_logger);
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                _logUtilities.LogInformation("Starting GetAll Books endpoint service.");
                BaseResponse<List<BookDto>> response = booksServices.GetBooks();
                _logUtilities.LogInformation("GetAll endpoint executed successfully.");
                return response.Status ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                _logUtilities.LogError($"Error in GetAll endpoint: {ex.Message}");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetABook(string id)
        {
            try
            {
                _logUtilities.LogInformation("Starting GetABook endpoint service.");
                BaseResponse<BookDto> response = booksServices.GetABook(Int32.Parse(id));
                _logUtilities.LogInformation("GetABook endpoint executed successfully.");
                return response.Status ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                _logUtilities.LogError($"Error in GetABook endpoint: {ex.Message}");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

        [HttpPost]
        [Route("addBook")]
        public IActionResult AddBook([FromBody] BookDto book)
        {
            try
            {
                _logUtilities.LogInformation("Starting AddBook endpoint service.");
                _logUtilities.LogInformation("Starting GetAnAuthor service validation.");
                BaseResponse<AuthorDTO> authorResponse = authorsServices.GetAnAuthor(book.AuthorId);
                _logUtilities.LogInformation("GetAnAuthor service validation successfully.");
                if (authorResponse.Status)
                {
                    BaseResponse<BookDto> response = booksServices.AddBook(book);
                    _logUtilities.LogInformation("AddBook endpoint executed successfully.");
                    return response.Status ? Ok(response) : BadRequest(response);
                }
                else
                {
                    return BadRequest(authorResponse);
                }
            }
            catch (Exception ex)
            {
                _logUtilities.LogError($"Error in AddBook endpoint: {ex.Message}");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateBook([FromBody] BookDto book)
        {
            try
            {
                _logUtilities.LogInformation("Starting UpdateBook endpoint service");
                _logUtilities.LogInformation("Starting GetABook service validation.");
                BaseResponse<BookDto> bookResponse = booksServices.GetABook(book.BookId);
                _logUtilities.LogInformation("GetABook service validation successfully.");
                if (bookResponse.Status)
                {
                    BaseResponse<BookDto> response = booksServices.UpdateBook(book);
                    _logUtilities.LogInformation("AddBook endpoint executed successfully.");
                    return response.Status ? Ok(response) : BadRequest(response);
                }
                else
                {
                    return BadRequest(bookResponse);
                }
            }
            catch (Exception ex)
            {
                _logUtilities.LogError($"Error in UpdateBook endpoint: {ex.Message}");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteBook([FromBody] BookDto book)
        {
            try
            {
                _logUtilities.LogInformation("Starting DeleteBook endpoint service");
                _logUtilities.LogInformation("Starting GetABook service validation.");
                BaseResponse<BookDto> bookResponse = booksServices.GetABook(book.BookId);
                _logUtilities.LogInformation("GetABook service validation successfully.");
                if (bookResponse.Status)
                {
                    BaseResponse<BookDto> response = booksServices.DeleteBook(book);
                    _logUtilities.LogInformation("DeleteBook endpoint executed successfully.");
                    return response.Status ? Ok(response) : BadRequest(response);
                }
                else
                {
                    return BadRequest(bookResponse);
                }
            }
            catch (Exception ex)
            {
                _logUtilities.LogError($"Error in DeleteBook endpoint: {ex.Message}");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }
    }
}
