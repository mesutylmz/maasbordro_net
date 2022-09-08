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
    public class MudurlukController : ApiController
    {
        private IMudurlukRepo _mudurlukRepo;

        public MudurlukController(IMudurlukRepo mudurlukRepo) 
        {
            _mudurlukRepo = mudurlukRepo;
        }
        public HttpResponseMessage Get()
        { 
            var entityList = _mudurlukRepo.GetAllMudurluk();
            return Request.CreateResponse(HttpStatusCode.OK, entityList);  
        }

        public HttpResponseMessage Get(int id)
        {

            var entity = _mudurlukRepo.GetById(id);
            if (entity != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, entity);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Mudurluk with id " + id.ToString() + " not found");
            }
            
        }

        public HttpResponseMessage Post([FromBody] TBL_MUDURLUK mudurluk)
        {
            try
            {
                _mudurlukRepo.CreateMudurluk(mudurluk);
                var message = Request.CreateResponse(HttpStatusCode.Created, mudurluk);
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
                var entity = _mudurlukRepo.DeleteMudurluk(id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Mudurluk with id " + id.ToString() + " not found");
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

        public HttpResponseMessage Put(int id, [FromBody] TBL_MUDURLUK mudurluk)
        {
           
            try
            {
                var entity = _mudurlukRepo.UpdateMudurluk(id,mudurluk);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Muduruluk with id " + id.ToString() + " not found.");
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
