namespace Library.BLL.Authors.Dtos
{
    public class AuthorDTO
    {
        public int AuthorId { get; set; }

        public string FullName { get; set; }

        public DateOnly BirthDate { get; set; }

        public string BirthTown { get; set; }

        public string Email { get; set; }
    }
}
