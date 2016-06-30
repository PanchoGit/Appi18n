using System;
using System.Web.Http;
using Appi18n.Application.Model;
using Appi18n.Application.Service;
using Common;

namespace Appi18n.Web.Controllers.Api
{
    public class NoteController : ApiController
    {
        private readonly INoteService service;

        public NoteController(INoteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = service.GetAll();

            return result.CreateResponse(this);
        }

        [HttpPost]
        public IHttpActionResult Save(Note model)
        {
            //model.Date = model.Date.ToUniversalTime();

            var result = service.Save(model);

            return result.CreateResponse(this);
        }
    }
}
