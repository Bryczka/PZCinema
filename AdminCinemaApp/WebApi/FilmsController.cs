using CinemaDatabase;
using CinemaDatabase.Persistence;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminCinemaApp
{

    public class FilmsController : ApiController
    {

        // GET api/demo 

        public HttpResponseMessage Get()
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<Film> ListFilms = new List<Film>();

            foreach (Film film in context.Films)
            {

                ListFilms.Add(unitOfWork.Film.Get(film.Id));

            }
            var json = ListFilms;
            return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);

        }

        // GET api/demo/5 
        public HttpResponseMessage Get(int id)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var json = unitOfWork.Film.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);
        }

        // POST api/demo 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/demo/5 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/demo/5 
        public void Delete(int id)
        {
        }


    }
}