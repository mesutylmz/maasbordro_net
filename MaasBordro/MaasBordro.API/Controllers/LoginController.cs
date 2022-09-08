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
    public class LoginController : ApiController
    {

        private IPersonelRepo _personelRepo;
        public LoginController(IPersonelRepo personelRepo) 
        {
            _personelRepo = personelRepo;
        }

        public HttpResponseMessage Get(string tcNo,string sifre)
        {
            
            try
            {
                var entities = _personelRepo.GetByTcNoAndSifre(tcNo,sifre);
                if (entities != null && entities.Count > 0)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, "Login successful");
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Login is not successful");
                }
            }
            catch(Exception ex) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex);
            }
        }
        
    }
}
