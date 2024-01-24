using Library.BLL;
using Library.BLL.Authors;
using Library.BLL.Authors.Dtos;
using Library.BLL.Authors.Implementation;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private IAuthorsServices authorsServices = new AuthorsServices();
        private readonly ILogger<AuthorsController> _logger;

        public AuthorsController(ILogger<AuthorsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            BaseResponse<List<AuthorDTO>> response = authorsServices.GetAuthors();
            if (response.Status)
            {
                return Ok(response);

            } else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetAnAuthor(string id)
        {
            BaseResponse<AuthorDTO> response = authorsServices.GetAnAuthor(Int32.Parse(id));
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
        public IActionResult AddAuthor([FromBody] AuthorDTO author)
        {
            BaseResponse<AuthorDTO> response = authorsServices.AddAuthor(author);
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
        public IActionResult UpdateAuthor([FromBody] AuthorDTO author)
        {
            BaseResponse<AuthorDTO> response = authorsServices.UpdateAuthor(author);
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
        public IActionResult DeleteAuthor([FromBody] AuthorDTO author)
        {
            BaseResponse<AuthorDTO> response = authorsServices.DeleteAuthor(author);
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
