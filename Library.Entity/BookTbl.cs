namespace Library.Entity;

public partial class BookTbl
{
    public int BookId { get; set; }

    public string Title { get; set; }

    public int YearPublished { get; set; }

    public string Genre { get; set; }

    public int NumPages { get; set; }

    public int AuthorId { get; set; }

    public virtual AuthorTbl? Author { get; set; }
}
