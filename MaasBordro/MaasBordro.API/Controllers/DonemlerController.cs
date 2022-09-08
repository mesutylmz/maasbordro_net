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
    public class DonemlerController : ApiController
    {
        private IDonemlerRepo _donemlerRepo;

        public DonemlerController(IDonemlerRepo donemlerRepo)
        {
            _donemlerRepo = donemlerRepo;
        }
        public HttpResponseMessage Get()
        {
            var entityList = _donemlerRepo.GetAllDonemler();
            return Request.CreateResponse(HttpStatusCode.OK, entityList);
        }

        public HttpResponseMessage Get(int id)
        {

            var entity = _donemlerRepo.GetById(id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Donemler with id " + id.ToString() + " not found");
            }
            
        }

        public HttpResponseMessage Post([FromBody] TBL_DONEMLER donemler)
        {
            try
            {
                _donemlerRepo.CreateDonemler(donemler);
                var message = Request.CreateResponse(HttpStatusCode.Created, donemler);
                return message;
                
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        { 
            try
            {
                var entity = _donemlerRepo.DeleteDonemler(id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Donemler with id " + id.ToString() + " not found");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] TBL_DONEMLER donemler)
        {
           
            try
            {
                var entity = _donemlerRepo.UpdateDonemler(id,donemler);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Donemler with id " + id.ToString() + " not found.");
                }
                else
                {  
                    return Request.CreateResponse(HttpStatusCode.OK, entity);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }

        }

    }
}
