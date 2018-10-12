using ADVDataModel;
using ADVWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ADVWebAPI.Controllers
{
    [RoutePrefix("api/BooksController")]
    public class BookController : ApiController
    {
        private ADV2017Entities db = new ADV2017Entities();

        ModelFactory _modelFactory;

        public BookController()
        {
            _modelFactory = new ModelFactory();
        }

        
        [HttpPost]
        [Route("PostBook")]
        public IHttpActionResult PostBook(Book Book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(Book);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                
                    throw;
                
            }

            return Ok();
        }


        [HttpPost]
        [Route("PostBooks")]
        public IHttpActionResult PostBooks(List<Book> books)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (Book e in books)
            {
                db.Books.Add(e);
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {

                throw;

            }

            return Ok();
        }

    }
}
