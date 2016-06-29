using System.Collections.Generic;
using System.Web.Http;
using Appi18n.Application.Model;
using Appi18n.Application.Service;
using Appi18n.Web.Extensions;
using Appi18n.Web.Models;

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
            var result = new Result<IEnumerable<Note>>(service.GetAll());

            return result.CreateResponse(this);
        }
    }
}
