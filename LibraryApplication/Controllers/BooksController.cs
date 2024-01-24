using Microsoft.AspNetCore.Mvc;
using Library.BLL;
using Library.BLL.Books;
using Library.BLL.Books.Dtos;
using Library.BLL.Books.Implementation;

namespace LibraryApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
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
            BaseResponse<List<BooksDto>> response = booksServices.GetBooks();
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAnAuthor(string id)
        {
            BaseResponse<BooksDto> response = booksServices.GetABook(Int32.Parse(id));
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        [Route("addAuthor")]
        public IActionResult AddAuthor([FromBody] BooksDto book)
        {
            BaseResponse<BooksDto> response = booksServices.AddBook(book);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateAuthor([FromBody] BooksDto book)
        {
            BaseResponse<BooksDto> response = booksServices.UpdateBook(book);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult DeleteAuthor([FromBody] BooksDto book)
        {
            BaseResponse<BooksDto> response = booksServices.DeleteBook(book);
            if (response.Status)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
