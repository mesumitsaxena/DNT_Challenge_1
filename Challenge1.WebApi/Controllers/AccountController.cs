using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge1.WebApi.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        public int Index()
        {
            return 1;
        }
    }
}
