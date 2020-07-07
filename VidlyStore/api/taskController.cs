using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.AspNet.Identity;
using VidlyStore.Controllers.helper;
using VidlyStore.Dtos;
using VidlyStore.Models;

namespace VidlyStore.api
{
    [System.Web.Mvc.Authorize]
    public class taskController : ApiController
    {
        private ApplicationDbContext _context;
        private HelperController _helper;
        public taskController()
        {
           _helper = new HelperController();
           _context =new ApplicationDbContext();
        }
        
        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateNewtask()
        {
            _helper.AddTask();
            return Ok();
        }

     


    }

}
