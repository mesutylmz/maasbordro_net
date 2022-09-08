using MaasBordro.API.Security;
using MaasBordro.DAL;
using MaasBordro.DAL.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MaasBordro.API.Controllers
{
    [BasicAuth]
    public class PersonelController : ApiController
    {
        private IPersonelRepo _personelRepo;

        public PersonelController(IPersonelRepo personelRepo) 
        {
            this._personelRepo = personelRepo;
        }

        public HttpResponseMessage Get() {
        
            var entities = _personelRepo.GetAllPersonel();
            return Request.CreateResponse(HttpStatusCode.OK, entities);

        }

        public HttpResponseMessage Get(int id) 
        {
            var entity = _personelRepo.GetById(id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Personel with id " + id.ToString() + " not found");
            }

        }

        public HttpResponseMessage Post([FromBody] TBL_PERSONEL personel) 
        {
            try
            {
                _personelRepo.CreatePersonel(personel);
                var message = Request.CreateResponse(HttpStatusCode.Created, personel);
                return message;
                
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var entity = _personelRepo.DeletePersonel(id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Personel with id " + id.ToString() + " not found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch(Exception ex) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }

        

        public HttpResponseMessage Put(int id ,[FromBody] TBL_PERSONEL personel) 
        {
           
            try
            {
                var entity = _personelRepo.UpdatePersonel(id, personel);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Personel with id " + id.ToString() + " not found.");
                }
                else
                { 
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch(Exception ex) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }               
        }
        
    }
}
