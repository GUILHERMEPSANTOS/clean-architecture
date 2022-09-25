using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class AccountController : ControllerBase
    {
     private readonly IAuthenticate _authenticate;

     public AccountController(IAuthenticate authenticate)
     {
        _authenticate = authenticate;
     }  
    }
}