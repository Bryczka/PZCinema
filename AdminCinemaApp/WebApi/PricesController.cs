using CinemaDatabase;
using CinemaDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace AdminCinemaApp.WebApi
{
    public class PricesController : ApiController
    {

        // GET api/demo 

        public HttpResponseMessage Get()
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<Price> ListPrices = new List<Price>();

            foreach (Price price in context.Prices)
            {

                ListPrices.Add(unitOfWork.Price.Get(price.Id));

            }
            var json = ListPrices;
            return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);

        }

        // GET api/demo/5 
        public HttpResponseMessage Get(int id)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var json = unitOfWork.Price.Get(id);

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
