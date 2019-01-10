using CinemaDatabase;
using CinemaDatabase.Persistence;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminCinemaApp
{

    public class TicketsController : ApiController
    {


        // GET api/demo 

        public string Get()
        {
            return null;

        }

        // GET api/demo/5 
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var json = unitOfWork.Ticket.GetDetailed(x => x.FilmShow.Id == id);
            return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);
        }

        // POST api/demo 
        public void Post([FromBody]string value)
        {
        }

        // PUT api/demo/5 
        [HttpPut]
        public void Put(int id, [FromBody]Ticket ticketResponse)
        {

            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            Ticket ticket = new Ticket();
            ticket = ticketResponse;


            unitOfWork.Ticket.Get(id).IsFree = ticket.IsFree;
            unitOfWork.Ticket.Get(id).Price = ticket.Price;
            unitOfWork.Ticket.Get(id).Type = ticket.Type;
            unitOfWork.Complete();

            MainWindow.test = false;

        }

        // DELETE api/demo/5 
        public void Delete(int id)
        {
        }


    }
}