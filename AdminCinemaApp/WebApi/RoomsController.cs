using CinemaDatabase;
using CinemaDatabase.Persistence;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminCinemaApp.WebApi
{
    public class RoomsController : ApiController
    {

        // GET api/demo 

        public HttpResponseMessage Get()
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<Room> ListRooms = new List<Room>();

            foreach (Room room in context.Rooms)
            {

                ListRooms.Add(unitOfWork.Room.Get(room.Id));

            }
            var json = ListRooms;
            return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);

        }

      
        public HttpResponseMessage Get(int id)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            var json = unitOfWork.Room.Get(id);
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
