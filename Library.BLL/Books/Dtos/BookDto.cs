using Library.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Books.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }

        public string Title { get; set; }

        public int YearPublished { get; set; }

        public string Genre { get; set; }

        public int NumPages { get; set; }

        public int AuthorId { get; set; }

    }
}
