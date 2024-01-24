using Library.BLL.Authors.Dtos;

namespace Library.BLL.Authors
{
    public interface IAuthorsServices
    {
        public BaseResponse<List<AuthorDTO>> GetAuthors();
        public BaseResponse<AuthorDTO> GetAnAuthor(int id);
        public BaseResponse<AuthorDTO> AddAuthor(AuthorDTO author);
        public BaseResponse<AuthorDTO> UpdateAuthor(AuthorDTO author);
        public BaseResponse<AuthorDTO> DeleteAuthor(AuthorDTO author);
    }
}
