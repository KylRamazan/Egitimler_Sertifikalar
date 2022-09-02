using BookStoreWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreWebAPI.Controllers
{
  [Route("[controller]s")]
  [ApiController]
  public class BookController : ControllerBase
  {
    private static List<Book> BookList = new List<Book>()
    {
      new Book{
        BookId = 1,
        Title = "Lean Startup",
        GenreId = 1, // Personel Growth
        PageCount = 200,
        PublishDate = new DateTime(2001,06,12)
      },
      new Book{
        BookId = 2,
        Title = "Herland",
        GenreId = 2, // Science Fiction
        PageCount = 250,
        PublishDate = new DateTime(2010,05,23)
      },
      new Book{
        BookId = 3,
        Title = "Dune",
        GenreId = 2, // Science Fiction
        PageCount = 540,
        PublishDate = new DateTime(2002,12,21)
      }
    };

    [HttpGet]
    public List<Book> GetAll()
    {
      return BookList.OrderBy(x => x.BookId).ToList();
    }

    [HttpGet("{id}")]// FromQuery ile alinabilir fakat bu yol en cok tercih edilen yontemdir.
    public Book GetById(int id)
    {
      return BookList.Where(x => x.BookId == id).SingleOrDefault();
    }

    //[HttpGet]
    //public Book Books([FromQuery] string id)
    //{
    //  return BookList.Where(x => x.BookId == Convert.ToInt32(id)).SingleOrDefault();
    //}

    [HttpPost]
    public IActionResult AddBook([FromBody] Book newBook)
    {
      var book = BookList.SingleOrDefault(x => x.Title == newBook.Title);
      if (book != null) // book is not null => olarak da kullanilabilir.
        return BadRequest();

      BookList.Add(newBook);
      return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id,[FromBody] Book updatedBook)
    {
      var book = BookList.SingleOrDefault(x => x.BookId == id);
      if (book == null) // book is null => olarak da kullanilabilir.
        return BadRequest();

      book.BookId = updatedBook.BookId != default ? updatedBook.BookId : book.BookId;
      book.Title = updatedBook.Title != default ? updatedBook.Title : book.Title;
      book.GenreId = updatedBook.GenreId != default ? updatedBook.GenreId : book.GenreId;
      book.PageCount = updatedBook.PageCount != default ? updatedBook.PageCount : book.PageCount;
      book.PublishDate = updatedBook.PublishDate != default ? updatedBook.PublishDate : book.PublishDate;

      return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
      var book = BookList.SingleOrDefault(x => x.BookId == id);
      if (book == null) // book is null => olarak da kullanilabilir.
        return BadRequest();

      BookList.Remove(book);
      return Ok();
    }

  }
}
