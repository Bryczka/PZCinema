using CinemaDatabase;
using CinemaDatabase.Persistence;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminCinemaApp
{

    public class FilmShowsController : ApiController
    {

        // GET api/demo 


        public HttpResponseMessage Get()
        {

            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<FilmShow> ListFilmShows = new List<FilmShow>();

            foreach (FilmShow filmshow in unitOfWork.FilmShow.GetAll())
            {
                ListFilmShows.Add(unitOfWork.FilmShow.Get(filmshow.Id));
            }

            var json = ListFilmShows;
            return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);

        }

        // GET api/demo/5 
        public HttpResponseMessage Get(int id)
        {

            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            var json = unitOfWork.FilmShow.GetDetailed(x => x.Film.Id == id);
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