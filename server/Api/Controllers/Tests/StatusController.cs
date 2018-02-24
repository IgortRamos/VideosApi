using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers.Tests
{
    [Authorize]
    [Route("[controller]")]
    public class StatusController : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Status() => Ok(new { Status = HttpStatusCode.OK });
    }
}