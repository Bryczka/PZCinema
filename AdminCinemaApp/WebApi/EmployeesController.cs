﻿using CinemaDatabase;
using CinemaDatabase.Persistence;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AdminCinemaApp
{

    public class EmployeesController : ApiController
    {

        public bool Post(int id, [FromBody]string password)
        {

            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            Employee employee = new Employee();
            employee = unitOfWork.Employee.Get(id);
            string dbpass = BitConverter.ToString(employee.Password);
            if (dbpass.Equals(password))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public HttpResponseMessage Get(int id)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);

            var json = unitOfWork.Employee.Get(id);

            return Request.CreateResponse(HttpStatusCode.OK, json, Configuration.Formatters.JsonFormatter);
        }


        // POST api/demo 
        public void Post(Employee employeeResponse)
        {
            var context = new CinemaContext();
            UnitOfWork unitOfWork = new UnitOfWork(context);
            Employee employee = new Employee();
            employee = employeeResponse;
            unitOfWork.Employee.Add(employee);
            unitOfWork.Complete();
            MainWindow.reload = false;

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