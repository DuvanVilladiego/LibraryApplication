namespace Library.Entity;

public partial class AuthorTbl
{
    public int AuthorId { get; set; }

    public string FullName { get; set; }

    public DateOnly BirthDate { get; set; }

    public string BirthTown { get; set; }

    public string Email { get; set; }

    public virtual ICollection<BookTbl> BookTbls { get; set; } = new List<BookTbl>();
}
