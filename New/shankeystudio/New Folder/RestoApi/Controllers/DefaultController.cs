using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RestoApi.Models;

namespace RestoApi.Controllers
{
    public class DefaultController : ApiController
    {
        ModelManager modelManager = new ModelManager();
        [HttpGet]
        [Route("api/Default/addGuest")]
        public IHttpActionResult addGuest()
        {
            return Ok(modelManager.displayReservation());
        }
        [HttpPost]
        [Route("api/Default/addGuest")]
        public IHttpActionResult addGuest(GuestModel guestModel)
        {
            modelManager.addGuest(guestModel);
            return Ok();
        }
    }
}
