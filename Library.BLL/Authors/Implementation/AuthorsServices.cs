using Library.Entity;
using Library.BLL.Authors.Dtos;
using Library.DAL.DBContext;
using Library.DAL.Repository;
using Library.DAL.Repository.Implementation;

namespace Library.BLL.Authors.Implementation
{
    public class AuthorsServices : IAuthorsServices
    {
        private readonly IAuthorsRepository repository;

        public AuthorsServices(IAuthorsRepository repository)
        {
            this.repository = repository;
        }

        public BaseResponse<AuthorDTO> AddAuthor(AuthorDTO author)
        {
            BaseResponse<AuthorDTO> response = new BaseResponse<AuthorDTO>();
            try
            {
                AuthorTbl newAuthor = repository.Create(transformToEntity(author));
                if (newAuthor != null)
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

        public BaseResponse<List<AuthorDTO>> GetAuthors()
        {
            BaseResponse<List<AuthorDTO>> response = new BaseResponse<List<AuthorDTO>>();
            try
            {
                List<AuthorTbl> authorsEntity = repository.GetAll();
                if (authorsEntity.Count > 0)
                {
                    List<AuthorDTO> authorDTOs = new List<AuthorDTO>();
                    foreach (var authorEntity in authorsEntity)
                    {
                        AuthorDTO authorDTO = transformToDto(authorEntity);
                        authorDTOs.Add(authorDTO);
                    }
                    response.Data = authorDTOs;
                }
                else
                {
                    response.Data = new List<AuthorDTO>();
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

        public BaseResponse<AuthorDTO> GetAnAuthor(int id)
        {
            BaseResponse<AuthorDTO> response = new BaseResponse<AuthorDTO>();
            try
            {
                AuthorTbl author = repository.GetById(id);
                if (author != null)
                {
                    response.Status = true;
                    response.Message = Constants.Messages.SuccessMessage;
                    response.Data = transformToDto(author);
                }
                else
                {
                    response.Status = false;
                    response.Message = Constants.Messages.NoFoundAuthorItems;
                }
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = Constants.Messages.ErrorMessage;
            }
            return response;
        }

        public BaseResponse<AuthorDTO> UpdateAuthor(AuthorDTO author)
        {
            BaseResponse<AuthorDTO> response = new BaseResponse<AuthorDTO>();
            try
            {
                AuthorTbl updateAuthor = repository.Update(transformToEntity(author));
                response.Status = true;
                response.Message = Constants.Messages.SuccessMessage;
                response.Data = transformToDto(updateAuthor);
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = Constants.Messages.ErrorMessage;
            }
            return response;
        }

        public BaseResponse<AuthorDTO> DeleteAuthor(AuthorDTO author)
        {
            BaseResponse<AuthorDTO> response = new BaseResponse<AuthorDTO>();
            try
            {
                AuthorTbl deletedAuthor = repository.Delete(transformToEntity(author));
                response.Status = true;
                response.Message = Constants.Messages.SuccessMessage;
                response.Data = transformToDto(deletedAuthor);
            }
            catch (Exception)
            {
                response.Status = false;
                response.Message = Constants.Messages.ErrorMessage;
            }
            return response;
        }

        private AuthorDTO transformToDto(AuthorTbl entity) 
        {
            AuthorDTO dto = new AuthorDTO();
            dto.AuthorId = entity.AuthorId;
            dto.FullName = entity.FullName;
            dto.BirthDate = entity.BirthDate;
            dto.BirthTown = entity.BirthTown;
            dto.Email = entity.Email;
            return dto;
        }

        private AuthorTbl transformToEntity(AuthorDTO entity)
        {
            AuthorTbl dto = new AuthorTbl();
            dto.AuthorId = entity.AuthorId;
            dto.FullName = entity.FullName;
            dto.BirthDate = entity.BirthDate;
            dto.BirthTown = entity.BirthTown;
            dto.Email = entity.Email;
            return dto;
        }

    }
}
