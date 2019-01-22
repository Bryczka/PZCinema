using CinemaDatabase;
using CinemaDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminCinemaApp
{

    public class TicketsController : ApiController
    {
        // GET api/demo 

        public HttpResponseMessage Get(string email)
        {

            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            List<Ticket> ListTickets = new List<Ticket>();
            ListTickets = unitOfWork.Ticket.GetDetailed(x => x.UserEmail == email).ToList();
            var json = ListTickets;
           return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);

        }

        public HttpResponseMessage Get(int id, string tick)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            Ticket ticket = new Ticket();
            ticket= unitOfWork.Ticket.Get(id);
            var json = ticket;
            return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);

        }

        // GET api/demo/5 
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var json = unitOfWork.Ticket.GetDetailed(x => x.FilmShow.Id == id);
            MainWindow.reload = false;
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
            SendEmail sendEmail = new SendEmail();
            Ticket ticket = new Ticket();
            ticket = ticketResponse;


            unitOfWork.Ticket.Get(id).IsFree = ticket.IsFree;
            unitOfWork.Ticket.Get(id).Price = ticket.Price;
            unitOfWork.Ticket.Get(id).Type = ticket.Type;
            unitOfWork.Ticket.Get(id).IsBought = ticket.IsBought;
            unitOfWork.Ticket.Get(id).UserEmail = ticket.UserEmail;

            if (ticket.IsBought == false)
            {
                unitOfWork.Ticket.Get(id).ChooseTime = DateTime.Now;
            }
            else
            {
                unitOfWork.Ticket.Get(id).BuyTime = DateTime.Now;
                string email = ticket.UserEmail;
                string subject = "Your ticket to cinema";
                string message =

                    @"<html>
                      <body>
                      <p>Hi,</p>
                      <p>Thank you for choosing our cinema, yours tickets are available in our App after entering your e-mail address. Be in the cinema 15 minutes before a film. 
                        Don't forget to grab your phone with QR-code ticket.</p>
                      <p>See you soon,<br>Cinema428</br></p>
                      </body>
                      </html>
                     ";

                sendEmail.Send(subject, message, email);

            }
            unitOfWork.Complete();

            MainWindow.reload = false;

        }

        [HttpDelete]
        public void Delete(int id)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            unitOfWork.Ticket.Get(id).IsFree = true;
            unitOfWork.Ticket.Get(id).Price = 0;
            unitOfWork.Ticket.Get(id).Type = "";
            unitOfWork.Ticket.Get(id).IsBought = false;
            unitOfWork.Ticket.Get(id).UserEmail = "";
            unitOfWork.Complete();
            MainWindow.reload = false;
        }

        [HttpDelete]
        public void Delete(int id, string tick)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            unitOfWork.Ticket.Get(id).IsUsed = true;
            unitOfWork.Complete();
            MainWindow.reload = false;
        }


    }
}