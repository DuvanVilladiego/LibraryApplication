using Library.BLL;
using Library.BLL.Authors;
using Library.BLL.Authors.Dtos;
using Library.BLL.Authors.Implementation;
using Library.DAL.Repository.Implementation;
using Library.IOC;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly ILogger<AuthorsController> _logger;
        private IAuthorsServices authorsServices = new AuthorsServices(new AuthorsRepository());
        private LogUtilities<AuthorsController> _logUtilities;

        public AuthorsController(ILogger<AuthorsController> logger)
        {
            _logger = logger;
            _logUtilities = new LogUtilities<AuthorsController>(_logger);
        }

        [HttpGet]
        [Route("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                _logUtilities.LogInformation("Starting GetAll Authors endpoint service.");
                BaseResponse<List<AuthorDTO>> response = authorsServices.GetAuthors();
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
        public IActionResult GetAnAuthor(string id)
        {
            try
            {
                _logUtilities.LogInformation("Starting GetAnAuthor endpoint service.");
                BaseResponse<AuthorDTO> response = authorsServices.GetAnAuthor(Int32.Parse(id));
                _logUtilities.LogInformation("GetAll GetAnAuthor executed successfully.");
                return response.Status ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                _logUtilities.LogError($"Error in GetAnAuthor endpoint: {ex.Message}");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

        [HttpPost]
        [Route("addAuthor")]
        public IActionResult AddAuthor([FromBody] AuthorDTO author)
        {
            try
            {
                _logUtilities.LogInformation("Starting AddAuthor endpoint service.");
                BaseResponse<AuthorDTO> response = authorsServices.AddAuthor(author);
                _logUtilities.LogInformation("GetAll AddAuthor executed successfully.");
                return response.Status ? Ok(response) : BadRequest(response);
            }
            catch (Exception ex)
            {
                _logUtilities.LogError($"Error in AddAuthor endpoint: {ex.Message}");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

        [HttpPut]
        [Route("update")]
        public IActionResult UpdateAuthor([FromBody] AuthorDTO author)
        {
            try
            {
                _logUtilities.LogInformation("Starting UpdateBook endpoint service");
                _logUtilities.LogInformation("Starting GetAnAuthor service validation.");
                BaseResponse<AuthorDTO> authorResponse = authorsServices.GetAnAuthor(author.AuthorId);
                _logUtilities.LogInformation("GetAnAuthor service validation successfully.");
                if (authorResponse.Status)
                {
                    BaseResponse<AuthorDTO> response = authorsServices.UpdateAuthor(author);
                    _logUtilities.LogInformation("UpdateAuthor endpoint executed successfully.");
                    return response.Status ? Ok(response) : BadRequest(response);
                }
                else
                {
                    return BadRequest(authorResponse);
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
        public IActionResult DeleteAuthor([FromBody] AuthorDTO author)
        {
            try
            {
                _logUtilities.LogInformation("Starting DeleteAuthor endpoint service");
                _logUtilities.LogInformation("Starting GetAnAuthor service validation.");
                BaseResponse<AuthorDTO> authorResponse = authorsServices.GetAnAuthor(author.AuthorId);
                _logUtilities.LogInformation("GetAnAuthor service validation successfully.");
                if (authorResponse.Status)
                {
                    BaseResponse<AuthorDTO> response = authorsServices.DeleteAuthor(author);
                    _logUtilities.LogInformation("DeleteAuthor endpoint executed successfully.");
                    return response.Status ? Ok(response) : BadRequest(response);
                }
                else
                {
                    return BadRequest(authorResponse);
                }
            }
            catch (Exception ex)
            {
                _logUtilities.LogError($"Error in DeleteAuthor endpoint: {ex.Message}");
                return StatusCode(500, "An error occurred. Please try again later.");
            }
        }

    }
}
