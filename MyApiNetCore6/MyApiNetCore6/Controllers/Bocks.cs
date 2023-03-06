using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyApiNetCore6.Data;
using MyApiNetCore6.Models;
using MyApiNetCore6.ViewModels;

namespace MyApiNetCore6.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class Bocks : ControllerBase
    {
        private readonly BookStoreContext _context;
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public Bocks(BookStoreContext context, HttpClient httpClient, IMapper mapper)
        {
            _context = context;
            _httpClient = httpClient;
            _mapper = mapper;
        }

        // GET: Bocks 
        [HttpGet("users")] 
        public IActionResult GetAllBooks()
        {
            var ListBooks = _context.Books?.ToList();
            return Ok(ListBooks);

            // TODO:
            // Call sang con GET /users (Gitlab)
            // var result = GetUers();
            // return Ok(result);
        }

       // private async UserViewModel GetUers()
        //{
           // var baseUrl = "https://docs.gitlab.com/ee/api/users";
           // var result = await _httpClient.GetAsync($"{baseUrl}");

           // var users = new List<UserViewModel>();

            // TODO: map users from result into users list.
           // users = _mapper.Map<UserViewModel>(result);

           // return users;
        //}

        // GET: Bocks/Details/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _context.Books?.SingleOrDefault(item => item.Id == id);
            if(book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Bock/Create
        [HttpPost()]
        public IActionResult CreateBook(BookModels BookModel)
        {
            try
            {
                var item = new Book
                {
                    Title = BookModel.Title,
                    Description = BookModel.Description,
                    Price = BookModel.Price,
                    Quantity = BookModel.Quantity
                };

                _context.Add(item);
                _context.SaveChanges();
                return Ok(item);
            }
            catch
            {
                return BadRequest();
            }
        }

        // PUT: Book/Update
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, BookModels BookModedl)
        {

            var book = _context.Books?.SingleOrDefault(item => item.Id == id);
            if (book != null)
            {
                book.Title = BookModedl.Title;
                book.Description = BookModedl.Description;
                book.Price = BookModedl.Price;
                book.Quantity = BookModedl.Quantity;

                _context.SaveChanges();
                return NoContent();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                var book = _context.Books?.SingleOrDefault(item => item.Id == id);
                if (book != null)
                {
                    _context.Remove(book);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch 
            {
                return BadRequest();
            }
        }
    }
}
