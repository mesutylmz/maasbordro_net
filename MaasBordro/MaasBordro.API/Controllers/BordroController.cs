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
    public class BordroController : ApiController
    {
        private IBordroRepo _bordroRepo;

        public BordroController(IBordroRepo bordroRepo) 
        {
            _bordroRepo = bordroRepo;
        }

        public HttpResponseMessage Get()
        {
            var entityList = _bordroRepo.GetAllBordro();
            return Request.CreateResponse(HttpStatusCode.OK, entityList);
        }
        public HttpResponseMessage Get(int id)
        {

            var entity = _bordroRepo.GetById(id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bordro with id " + id.ToString() + " not found");
            }
            
        }
        public HttpResponseMessage Get(String pind,String dind)
        {
            var entityList = _bordroRepo.GetByPindAndDind(pind,dind);
            if (entityList != null && entityList.Count > 0) {
                return Request.CreateResponse(HttpStatusCode.OK, entityList);
            }
            else 
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound,"With given pind,dind bordro not found");
            }
        }
        public HttpResponseMessage Post([FromBody] TBL_BORDRO bordro)
        {
            try
            {
                _bordroRepo.CreateBordro(bordro);            
                var message = Request.CreateResponse(HttpStatusCode.Created, bordro);
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
                var entity = _bordroRepo.DeleteBordro(id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bordro with id " + id.ToString() + " not found");
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

        

        public HttpResponseMessage Put(int id, [FromBody] TBL_BORDRO bordro)
        {
            try
            {
                var entity = _bordroRepo.UpdateBordro(id,bordro);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Bordro with id " + id.ToString() + " not found.");
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
